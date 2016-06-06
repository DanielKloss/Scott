using BlackHole.UI.Helpers;
using BlackHole.UI.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using BlackHole.UI.Views;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System;

namespace BlackHole.UI.ViewModels
{
    public class GameViewModel : BasePropertyChanged
    {
        private Piece _lastPlayedPiece;
        private int _lastPlayedSpaceId;
        private bool _hasUndone;

        private Game _game;
        public Game game
        {
            get { return _game; }
            set
            {
                _game = value;
                RaisePropertyChanged(nameof(game));
            }
        }

        private bool _draggable;
        public bool draggable
        {
            get { return _draggable; }
            set
            {
                _draggable = value;
                RaisePropertyChanged(nameof(draggable));
            }
        }

        private ICommand _restartGameCommand;
        public ICommand restartGameCommand
        {
            get
            {
                if (_restartGameCommand == null)
                {
                    _restartGameCommand = new Command(RestartGame, () => true);
                }
                return _restartGameCommand;
            }
            set { _restartGameCommand = value; }
        }

        private ICommand _addPieceCommand;
        public ICommand addPieceCommand
        {
            get
            {
                if (_addPieceCommand == null)
                {
                    _addPieceCommand = new Command<int>(AddPiece, CanAddPiece);
                }
                return _addPieceCommand;
            }
            set { _addPieceCommand = value; }
        }

        private ICommand _undoCommand;
        public ICommand undoCommand
        {
            get
            {
                if (_undoCommand == null)
                {
                    _undoCommand = new Command(Undo, CanUndo);
                }
                return _undoCommand;
            }
            set { _undoCommand = value; }
        }

        private ICommand _navigateToSettingsCommand;
        public ICommand navigateToSettingsCommand
        {
            get
            {
                if (_navigateToSettingsCommand == null)
                {
                    _navigateToSettingsCommand = new Command(NavigateToSettings, () => true);
                }
                return _navigateToSettingsCommand;
            }
            set { _navigateToSettingsCommand = value; }
        }

        private void UpdateCommands()
        {
            ((Command)undoCommand).RaiseCanExecuteChanged();

            for (int i = 1; i <= 21; i++)
            {
                ((Command<int>)addPieceCommand).CanExecute(i);
            }
        }

        public GameViewModel()
        {
            game = new Game();
            GetDraggable();

            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                game = new Game()
                {
                    players = new ObservableCollection<Player>()
                    {
                         new Player(1, "") { isWinner=true, score=2 },
                         new Player(2, "") { isWinner=false, score=20 }
                    },
                    board = new Board()
                    {
                        scoringPieces = new ObservableCollection<Piece>()
                        {
                             new Piece() { pieceValue=2, player=1 },
                             new Piece() { pieceValue=2, player=2 },
                             new Piece() { pieceValue=3, player=2 },
                             new Piece() { pieceValue=4, player=2 },
                             new Piece() { pieceValue=5, player=2 },
                             new Piece() { pieceValue=6, player=2 },
                        }
                    },
                    isFinished = true
                };
            }
        }

        public void GetDraggable()
        {
            draggable = (bool)ApplicationData.Current.RoamingSettings.Values[((Application)Windows.UI.Xaml.Application.Current).canDragKey];
        }

        private void AddPiece(int boardSpace)
        {
            int lastPlayedSpaceId = boardSpace;
            Piece lastPlayedPiece = game.pieces[0];

            game.board.spaces[boardSpace - 1].containingPiece = lastPlayedPiece;
            game.pieces.RemoveAt(0);

            StartNextTurn(lastPlayedPiece, lastPlayedSpaceId);

            UpdateCommands();
        }

        private bool CanAddPiece(int boardSpace)
        {
            if (game.board.spaces[boardSpace - 1].containingPiece == null && game.isFinished != true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Undo()
        {
            _hasUndone = true;

            game.pieces.Insert(0, _lastPlayedPiece);
            game.board.spaces[_lastPlayedSpaceId - 1].containingPiece = null;

            if (_lastPlayedPiece.player == 2)
            {
                game.round--;
                game.turn++;
            }
            else
            {
                game.turn--;
            }

            UpdateCommands();
        }

        private bool CanUndo()
        {
            if (!_hasUndone && game.pieces.Count < 20 && !game.isFinished)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void StartNextTurn(Piece playedPiece, int playedSpaceId)
        {
            _lastPlayedPiece = _lastPlayedPiece = playedPiece;
            _lastPlayedSpaceId = playedSpaceId;

            if (playedPiece.player == 1)
            {
                game.turn++;
            }
            else
            {
                if (playedPiece.pieceValue == 10)
                {
                    Space blackHole = game.board.GetBlackHole();
                    game.board.GetScoringPieces(blackHole);
                    game.WorkOutWinner(game.board.scoringPieces);
                }
                else
                {
                    game.round++;
                    game.turn--;
                }
            }

            _hasUndone = false;
        }

        private void RestartGame()
        {
            ((Frame)Window.Current.Content).Navigate(typeof(GameView), true);
        }

        private void NavigateToSettings()
        {
            ((Frame)Window.Current.Content).Navigate(typeof(SettingsView));
        }
    }
}

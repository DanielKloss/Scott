using BlackHole.UI.Helpers;
using BlackHole.UI.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;
using Windows.UI.Xaml;
using BlackHole.UI.Views;

namespace BlackHole.UI.ViewModels
{
    public class GameViewModel : BasePropertyChanged
    {
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

        public GameViewModel()
        {
            game = new Game();

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

        public void StartNextTurn(Piece playedPiece)
        {
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
        }

        private void RestartGame()
        {
            ((App)Application.Current).rootFrame.Navigate(typeof(GameView));
        }
    }
}

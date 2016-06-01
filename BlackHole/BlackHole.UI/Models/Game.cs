using BlackHole.UI.Helpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BlackHole.UI.Models
{
    public class Game : BasePropertyChanged
    {
        private ObservableCollection<Player> _players;
        public ObservableCollection<Player> players
        {
            get { return _players; }
            set
            {
                _players = value;
                RaisePropertyChanged(nameof(players));
            }
        }

        private ObservableCollection<Piece> _pieces;
        public ObservableCollection<Piece> pieces
        {
            get { return _pieces; }
            set
            {
                _pieces = value;
                RaisePropertyChanged(nameof(pieces));
            }
        }

        private Board _board;
        public Board board
        {
            get { return _board; }
            set
            {
                _board = value;
                RaisePropertyChanged(nameof(board));
            }
        }

        private int _round;
        public int round
        {
            get { return _round; }
            set
            {
                _round = value;
                RaisePropertyChanged(nameof(round));
            }
        }

        private int _turn;
        public int turn
        {
            get { return _turn; }
            set
            {
                _turn = value;
                RaisePropertyChanged(nameof(turn));
            }
        }

        private bool _isFinished;
        public bool isFinished
        {
            get { return _isFinished; }
            set
            {
                _isFinished = value;
                RaisePropertyChanged(nameof(isFinished));
            }
        }

        private bool _isDraw;
        public bool isDraw
        {
            get { return _isDraw; }
            set
            {
                _isDraw = value;
                RaisePropertyChanged(nameof(isDraw));
            }
        }

        public Game()
        {
            players = new ObservableCollection<Player>() { new Player(1, "Player1"), new Player(2, "Player2") };
            board = new Board();

            pieces = new ObservableCollection<Piece>();

            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 2; j++)
                {
                    pieces.Add(new Piece() { player = j, pieceValue = i });
                }
            }

            round = 1;
            turn = 1;
            isDraw = false;
            isFinished = false;
        }

        public void WorkOutWinner(ObservableCollection<Piece> scoringPieces)
        {
            foreach (Piece scoringPiece in scoringPieces)
            {
                players.Single(p => p.id == scoringPiece.player).score += scoringPiece.pieceValue;
            }

            if (players.Single(p => p.id == 1).score > players.Single(p => p.id == 2).score)
            {
                players.Single(p => p.id == 2).isWinner = true;
            }
            else if (players.Single(p => p.id == 2).score > players.Single(p => p.id == 1).score)
            {
                players.Single(p => p.id == 1).isWinner = true;
            }
            else
            {
                isDraw = true;
            }
        }
    }
}

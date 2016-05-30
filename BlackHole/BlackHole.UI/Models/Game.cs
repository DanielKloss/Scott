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
        }

        public int WorkOutWinner(List<Piece> scoringPieces)
        {
            foreach (Piece scoringPiece in scoringPieces)
            {
                players.Single(p => p.id == scoringPiece.player).score += scoringPiece.pieceValue;
            }

            if (players.Single(p => p.id == 1).score > players.Single(p => p.id == 2).score)
            {
                return 2;
            }
            else if (players.Single(p => p.id == 2).score > players.Single(p => p.id == 1).score)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}

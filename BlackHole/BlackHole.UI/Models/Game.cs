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
                RaisePropertyChanged("players");
            }
        }

        private Board _board;
        public Board board
        {
            get { return _board; }
            set
            {
                _board = value;
                RaisePropertyChanged("board");
            }
        }

        private int _round;
        public int round
        {
            get { return _round; }
            set
            {
                _round = value;
                RaisePropertyChanged("round");
            }
        }

        private int _turn;
        public int turn
        {
            get { return _turn; }
            set
            {
                _turn = value;
                RaisePropertyChanged("turn");
            }
        }

        public Game()
        {
            players = new ObservableCollection<Player>() { new Player(1, "Player1"), new Player(2, "Player2") };
            board = new Board();
            round = 1;
            turn = 1;
        }

        public void WorkOutWinner()
        {
            List<Piece> scoringPieces = board.GetScoringPieces();

            foreach (Piece scoringPiece in scoringPieces)
            {
                players.Single(p => p.id == scoringPiece.player).score += scoringPiece.value;
            }

            if (players.Single(p => p.id == 1).score > players.Single(p => p.id == 2).score)
            {
                //Player 2 Wins
            }
            else if (players.Single(p => p.id == 2).score > players.Single(p => p.id == 1).score)
            {
                //Player 1 Wins
            }
            else
            {
                //Draw!
            }
        }
    }
}

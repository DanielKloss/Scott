using System;
using BlackHole.UI.Helpers;
using BlackHole.UI.Models;
using System.Linq;

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
                RaisePropertyChanged("game");
            }
        }

        public GameViewModel()
        {
            game = new Game();
        }

        public void StartNextTurn(Piece playedPiece)
        {
            if (playedPiece.player == 1)
            {
                game.turn++;
            }
            else
            {
                if (playedPiece.value == 10)
                {
                    game.WorkOutWinner();
                }
                else
                {
                    game.round++;
                    game.turn--;
                }
            }

        }
    }
}

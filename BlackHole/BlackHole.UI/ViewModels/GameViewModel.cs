using BlackHole.UI.Helpers;
using BlackHole.UI.Models;

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
                if (playedPiece.pieceValue == 10)
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

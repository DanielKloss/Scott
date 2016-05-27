using BlackHole.UI.Helpers;

namespace BlackHole.UI.Models
{
    public class Piece : BasePropertyChanged
    {
        private int _pieceValue;
        public int pieceValue
        {
            get { return _pieceValue; }
            set
            {
                _pieceValue = value;
                RaisePropertyChanged(nameof(pieceValue));
            }
        }

        private int _player;
        public int player
        {
            get { return _player; }
            set
            {
                _player = value;
                RaisePropertyChanged(nameof(player));
            }
        }

    }
}

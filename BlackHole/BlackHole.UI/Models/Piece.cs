using BlackHole.UI.Helpers;

namespace BlackHole.UI.Models
{
    public class Piece : BasePropertyChanged
    {
        private int _value;
        public int value
        {
            get { return _value; }
            set
            {
                _value = value;
                RaisePropertyChanged("value");
            }
        }

        private int _player;
        public int player
        {
            get { return _player; }
            set
            {
                _player = value;
                RaisePropertyChanged("player");
            }
        }

    }
}

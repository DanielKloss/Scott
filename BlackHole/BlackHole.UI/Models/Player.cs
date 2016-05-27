using BlackHole.UI.Helpers;
using Windows.UI;

namespace BlackHole.UI.Models
{
    public class Player : BasePropertyChanged
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged(nameof(id));
            }
        }

        private string _name;
        public string name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged(nameof(name));
            }
        }

        private int _score;
        public int score
        {
            get { return _score; }
            set
            {
                _score = value;
                RaisePropertyChanged(nameof(score));
            }
        }

        private Color _colour;
        public Color colour
        {
            get { return _colour; }
            set
            {
                _colour = value;
                RaisePropertyChanged(nameof(colour));
            }
        }


        public Player(int Id, string Name)
        {
            id = Id;
            name = Name;
        }

    }
}

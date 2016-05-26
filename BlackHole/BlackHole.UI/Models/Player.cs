using BlackHole.UI.Helpers;

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
                RaisePropertyChanged("id");
            }
        }

        private string _name;
        public string name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged("name");
            }
        }

        private int _score;
        public int score
        {
            get { return _score; }
            set
            {
                _score = value;
                RaisePropertyChanged("score");
            }
        }

        public Player(int Id, string Name)
        {
            id = Id;
            name = Name;
        }

    }
}

using BlackHole.UI.Helpers;
using System.Collections.Generic;

namespace BlackHole.UI.Models
{
    public class Space : BasePropertyChanged
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

        private List<int> _surroundingSpaces;
        public List<int> surroundingSpaces
        {
            get { return _surroundingSpaces; }
            set
            {
                _surroundingSpaces = value;
                RaisePropertyChanged("surroundingSpaces");
            }
        }

        private Piece _containingPiece;
        public Piece containingPiece
        {
            get { return _containingPiece; }
            set
            {
                _containingPiece = value;
                RaisePropertyChanged("containingPiece");
            }
        }

        public Space(int Id, List<int> SurroundingSpaces)
        {
            id = Id;
            surroundingSpaces = SurroundingSpaces;
        }
    }
}

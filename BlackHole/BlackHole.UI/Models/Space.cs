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
                RaisePropertyChanged(nameof(id));
            }
        }

        private List<int> _surroundingSpaces;
        public List<int> surroundingSpaces
        {
            get { return _surroundingSpaces; }
            set
            {
                _surroundingSpaces = value;
                RaisePropertyChanged(nameof(surroundingSpaces));
            }
        }

        private Piece _containingPiece;
        public Piece containingPiece
        {
            get { return _containingPiece; }
            set
            {
                _containingPiece = value;
                RaisePropertyChanged(nameof(containingPiece));
            }
        }

        private bool _isBlackHole;
        public bool isBlackHole
        {
            get { return _isBlackHole; }
            set
            {
                _isBlackHole = value;
                RaisePropertyChanged(nameof(isBlackHole));
            }
        }

        private bool _isSurrounding;
        public bool isSurrounding
        {
            get { return _isSurrounding; }
            set
            {
                _isSurrounding = value;
                RaisePropertyChanged(nameof(isSurrounding));
            }
        }

        public Space(int Id, List<int> SurroundingSpaces)
        {
            id = Id;
            surroundingSpaces = SurroundingSpaces;
            isBlackHole = false;
            isSurrounding = false;
        }
    }
}

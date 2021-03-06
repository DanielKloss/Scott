using BlackHole.UI.Helpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BlackHole.UI.Models
{
    public class Board : BasePropertyChanged
    {
        private ObservableCollection<Space> _spaces;
        public ObservableCollection<Space> spaces
        {
            get { return _spaces; }
            set
            {
                _spaces = value;
                RaisePropertyChanged(nameof(spaces));
            }
        }

        private ObservableCollection<int> _suckedNumbers;
        public ObservableCollection<int> suckedNumbers
        {
            get { return _suckedNumbers; }
            set
            {
                _suckedNumbers = value;
                RaisePropertyChanged(nameof(suckedNumbers));
            }
        }

        private ObservableCollection<Space> _suckedSpaces;
        public ObservableCollection<Space> suckedSpaces
        {
            get { return _suckedSpaces; }
            set
            {
                _suckedSpaces = value;
                RaisePropertyChanged(nameof(suckedSpaces));
            }
        }

        private ObservableCollection<Piece> _scoringPieces;
        public ObservableCollection<Piece> scoringPieces
        {
            get { return _scoringPieces; }
            set
            {
                _scoringPieces = value;
                RaisePropertyChanged(nameof(scoringPieces));
            }
        }

        public Board()
        {
            spaces = new ObservableCollection<Space>();


            spaces.Add(new Space(1, new List<int>() { 2, 3 }));
            spaces.Add(new Space(2, new List<int>() { 1, 3, 4, 5 }));
            spaces.Add(new Space(3, new List<int>() { 1, 2, 5, 6 }));
            spaces.Add(new Space(4, new List<int>() { 2, 5, 7, 8 }));
            spaces.Add(new Space(5, new List<int>() { 2, 3, 4, 6, 8, 9 }));
            spaces.Add(new Space(6, new List<int>() { 3, 5, 9, 10 }));
            spaces.Add(new Space(7, new List<int>() { 4, 8, 11, 12 }));
            spaces.Add(new Space(8, new List<int>() { 4, 5, 7, 9, 12, 13 }));
            spaces.Add(new Space(9, new List<int>() { 5, 6, 8, 10, 13, 14 }));
            spaces.Add(new Space(10, new List<int>() { 6, 9, 14, 15 }));
            spaces.Add(new Space(11, new List<int>() { 7, 12, 16, 17 }));
            spaces.Add(new Space(12, new List<int>() { 7, 8, 11, 13, 17, 18 }));
            spaces.Add(new Space(13, new List<int>() { 8, 9, 12, 14, 18, 19 }));
            spaces.Add(new Space(14, new List<int>() { 9, 10, 13, 15, 19, 20 }));
            spaces.Add(new Space(15, new List<int>() { 10, 14, 20, 21 }));
            spaces.Add(new Space(16, new List<int>() { 11, 17 }));
            spaces.Add(new Space(17, new List<int>() { 11, 12, 16, 18 }));
            spaces.Add(new Space(18, new List<int>() { 12, 13, 17, 19 }));
            spaces.Add(new Space(19, new List<int>() { 13, 14, 18, 20 }));
            spaces.Add(new Space(20, new List<int>() { 14, 15, 19, 21 }));
            spaces.Add(new Space(21, new List<int>() { 15, 20 }));
        }

        public Space GetBlackHole()
        {
            foreach (Space space in spaces)
            {
                if (space.containingPiece == null)
                {
                    space.isBlackHole = true;
                    return space;
                }
            }

            return null;
        }

        public void GetScoringPieces(Space balckHole)
        {
            scoringPieces = new ObservableCollection<Piece>();

            foreach (int suckedNumber in balckHole.surroundingSpaces)
            {
                spaces.Single(s => s.id == suckedNumber).isSurrounding = true;
                scoringPieces.Add(spaces.Single(s => s.id == suckedNumber).containingPiece);
            }
        }
    }
}

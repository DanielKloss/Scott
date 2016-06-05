using BlackHole.UI.Models;
using BlackHole.UI.ViewModels;
using System.Linq;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace BlackHole.UI.Views.Controls
{
    public sealed partial class PlayerPiece : UserControl
    {
        FrameworkElement parent;

        public PlayerPiece()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty valueProperty = DependencyProperty.Register("Value", typeof(int), typeof(PlayerPiece), new PropertyMetadata(0));
        public int Value
        {
            get { return (int)GetValue(valueProperty); }
            set { SetValue(valueProperty, value); }
        }

        public static readonly DependencyProperty playerProperty = DependencyProperty.Register("Player", typeof(int), typeof(PlayerPiece), new PropertyMetadata(0));
        public int Player
        {
            get { return (int)GetValue(playerProperty); }
            set { SetValue(playerProperty, value); }
        }

        public PlayerPiece(PlayerPiece c)
        {
            InitializeComponent();
        }

        private void control_DragStarting(UIElement sender, DragStartingEventArgs e)
        {
            parent = VisualTreeHelper.GetParent(sender) as FrameworkElement;

            while (parent.DataContext == null || parent.DataContext.GetType() != typeof(GameViewModel))
            {
                parent = VisualTreeHelper.GetParent(parent) as FrameworkElement;
            }

            if (Player == ((GameViewModel)parent.DataContext).game.turn && Value == ((GameViewModel)parent.DataContext).game.round)
            {
                e.Data.SetText(Player + "," + Value);
                e.Data.RequestedOperation = DataPackageOperation.Move;

                ((GameViewModel)parent.DataContext).game.pieces.Remove(((GameViewModel)parent.DataContext).game.pieces.Single(p => p.player == Player && p.pieceValue == Value));
            }
        }

        private void control_DropCompleted(UIElement sender, DropCompletedEventArgs e)
        {
            if (e.DropResult == DataPackageOperation.None)
            {
                ((GameViewModel)parent.DataContext).game.pieces.Insert(0, new Piece() { player = Player, pieceValue = Value });
            }
        }
    }
}

using BlackHole.UI.ViewModels;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace BlackHole.UI.Views.Controls
{
    public sealed partial class PlayerPiece : UserControl
    {
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
            circleUI.Fill = c.circleUI.Fill;
        }

        private void control_DragStarting(UIElement sender, DragStartingEventArgs e)
        {
            if (Player == ((GameViewModel)DataContext).game.turn && Value == ((GameViewModel)DataContext).game.round)
            {
                e.Data.SetText(Player + "," + Value);
                e.Data.RequestedOperation = DataPackageOperation.Move;

                var parent = VisualTreeHelper.GetParent(sender) as Panel;
                parent.Children.Remove(sender);
            }
        }
    }
}

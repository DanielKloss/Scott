using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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
        }
    }
}

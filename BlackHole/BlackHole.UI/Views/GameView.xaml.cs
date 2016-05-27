using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace BlackHole.UI.Views
{
    public sealed partial class GameView : Page
    {
        public GameView()
        {
            InitializeComponent();
        }

        private void Grid_DragLeave(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.None;
        }
    }
}

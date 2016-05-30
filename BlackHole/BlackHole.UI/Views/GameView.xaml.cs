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

        private void page_DragLeave(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.None;
        }

        private void page_DragOver(object sender, DragEventArgs e)
        {
            e.DragUIOverride.IsGlyphVisible = false;
        }
    }
}

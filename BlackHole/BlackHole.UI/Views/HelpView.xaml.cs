using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace BlackHole.UI.Views
{
    public sealed partial class HelpView : Page
    {
        public HelpView()
        {
            InitializeComponent();

            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }
    }
}

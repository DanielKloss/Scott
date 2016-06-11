using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace BlackHole.UI.Views
{
    public sealed partial class AboutView : Page
    {
        public AboutView()
        {
            InitializeComponent();

            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }
    }
}

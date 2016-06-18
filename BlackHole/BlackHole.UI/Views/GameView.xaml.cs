using BlackHole.UI.ViewModels;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace BlackHole.UI.Views
{
    public sealed partial class GameView : Page
    {
        public GameView()
        {
            InitializeComponent();

            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            if (e.Parameter != null && (bool)e.Parameter == true)
            {
                NavigationCacheMode = NavigationCacheMode.Disabled;
            }

            base.OnNavigatingFrom(e);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ((GameViewModel)DataContext).GetDraggable();

            base.OnNavigatedTo(e);
        }
    }
}

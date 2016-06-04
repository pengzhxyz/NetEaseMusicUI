using Windows.UI.Core;
using Windows.UI.Xaml.Navigation;
using NetEaseMusicUI.ViewModel;

namespace NetEaseMusicUI
{
    public sealed partial class MainPage
    {
        public MainViewModel Vm => (MainViewModel)DataContext;

        public MainPage()
        {
            InitializeComponent();
            this.pagemenuListView.SelectionChanged += PagemenuListView_SelectionChanged;
            this.mymusicListView.SelectionChanged += MymusicListView_SelectionChanged;
            this.myMusicFlag.Tapped += MyMusicFlag_Tapped;
            SystemNavigationManager.GetForCurrentView().BackRequested += SystemNavigationManagerBackRequested;

            this.Loaded += MainPage_Loaded;

        }

        private void MainPage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.ContentFrame.Navigate(typeof(Views.DevelopMusicPage));
        }

        private void MyMusicFlag_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            this.RootSplitView.IsPaneOpen = true;
        }

        private void SystemNavigationManagerBackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                e.Handled = true;
                Frame.GoBack();
            }
        }

        #region MenuItemListSelectionChanged
        private void MymusicListView_SelectionChanged(object sender, Windows.UI.Xaml.Controls.SelectionChangedEventArgs e)
        {
            if (mymusicListView.SelectedIndex>-1)
            {
                pagemenuListView.SelectedIndex = -1;
            }
        }

        private void PagemenuListView_SelectionChanged(object sender, Windows.UI.Xaml.Controls.SelectionChangedEventArgs e)
        {
            if (pagemenuListView.SelectedIndex > -1)
            {
                mymusicListView.SelectedIndex = -1;
            }
        }

        #endregion

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
        }
    }
}

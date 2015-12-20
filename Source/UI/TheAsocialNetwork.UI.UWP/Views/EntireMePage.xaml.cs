namespace TheAsocialNetwork.UI.UWP.Views
{
    using Windows.UI.Xaml.Controls;
    using TheAsocialNetwork.UI.UWP.ViewModels;
    using Windows.UI.Xaml.Navigation;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EntireMePage : Page
    {
        public EntireMePage()
        {
            this.InitializeComponent();
     
            this.ViewModel = new ListedPostViewModel();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        public ListedPostViewModel ViewModel
        {
            get
            {
                return this.DataContext as ListedPostViewModel;
            }
            private set
            {
                this.DataContext = value;
            }
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(
                typeof(PostDetailedPage),
                e.ClickedItem,
                new Windows.UI.Xaml.Media.Animation.DrillInNavigationTransitionInfo());
        }
    }
}

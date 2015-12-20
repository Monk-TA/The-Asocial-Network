namespace TheAsocialNetwork.UI.UWP.Controls
{
    using Windows.UI.Xaml.Controls;
    using TheAsocialNetwork.UI.UWP.ViewModels;

    public sealed partial class PostPreviewControl : UserControl
    {
        public PostPreviewControl()
        {
            this.InitializeComponent();
            this.ViewModel = new PostViewModel();
        }

        public PostViewModel ViewModel
        {
            get
            {
                return this.DataContext as PostViewModel;
            }
            private set
            {
                this.DataContext = value;
            }
        }
    }
}

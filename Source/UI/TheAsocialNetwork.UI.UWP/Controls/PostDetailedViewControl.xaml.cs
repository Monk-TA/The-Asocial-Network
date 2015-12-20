
namespace TheAsocialNetwork.UI.UWP.Controls
{
    using Windows.UI.Xaml.Controls;
    using TheAsocialNetwork.UI.UWP.ViewModels;

    public sealed partial class PostDetailedViewControl : UserControl
    {
        public PostDetailedViewControl()
        {
            this.InitializeComponent();
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

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

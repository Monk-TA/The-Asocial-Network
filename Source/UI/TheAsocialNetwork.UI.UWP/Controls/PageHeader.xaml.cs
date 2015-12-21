namespace TheAsocialNetwork.UI.UWP.Controls
{
    using System;
    using Windows.Foundation;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using TheAsocialNetwork.UI.UWP.Services.Data.Parse;
    using TheAsocialNetwork.UI.UWP.Views;

    public sealed partial class PageHeader : UserControl
    {
        public PageHeader()
        {
            this.InitializeComponent();

            this.Loaded += (s, a) =>
            {
                AppShell.Current.TogglePaneButtonRectChanged += Current_TogglePaneButtonSizeChanged;
                this.titleBar.Margin = new Thickness(AppShell.Current.TogglePaneButtonRect.Right, 0, 0, 0);
            };
        }

        private void Current_TogglePaneButtonSizeChanged(AppShell sender, Rect e)
        {
            this.titleBar.Margin = new Thickness(e.Right, 0, 0, 0);
        }

        public UIElement HeaderContent
        {
            get { return (UIElement)this.GetValue(HeaderContentProperty); }
            set { this.SetValue(HeaderContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HeaderContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderContentProperty =
            DependencyProperty.Register("HeaderContent", typeof(UIElement), typeof(PageHeader), new PropertyMetadata(DependencyProperty.UnsetValue));

        private void PageHeader_AddButtonClick(object sender, ItemClickEventArgs e)
        {
            //(Window.Current.Content as AppShell)
            //.AppFrame
            //.Navigate(
            //    typeof(AddPostPage),
            //    e.ClickedItem,
            //    new Windows.UI.Xaml.Media.Animation.DrillInNavigationTransitionInfo());
        }

        private void PageHeader_AddButtonClick(object sender, RoutedEventArgs e)
        {
            (Window.Current.Content as AppShell)
            .AppFrame
            .Navigate(
                typeof(AddPostPage),
                e.OriginalSource,
                new Windows.UI.Xaml.Media.Animation.DrillInNavigationTransitionInfo());
        }

        private async void titleBar_DoubleTapped(object sender, Windows.UI.Xaml.Input.DoubleTappedRoutedEventArgs e)
        {
            var parseService = new ParseAuthenticationService();
            var isLoggedOut = await parseService.LogOutAsync();

            if (isLoggedOut)
            {
                (Window.Current.Content as AppShell)
                 .AppFrame
                 .Navigate(
                     typeof(IdentityPage),
                     e.OriginalSource,
                     new Windows.UI.Xaml.Media.Animation.DrillInNavigationTransitionInfo());
            }
        }

        private void titleBar_Holding(object sender, Windows.UI.Xaml.Input.HoldingRoutedEventArgs e)
        {
            Windows.System.Launcher.LaunchUriAsync(new Uri("http://www.quotev.com/quiz/961137/The-Psychopath-Test"));
        }
    }
}

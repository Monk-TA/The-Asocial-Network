namespace TheAsocialNetwork.UI.UWP.Views
{
    using System;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;
    using TheAsocialNetwork.UI.UWP.Services.Apis;
    using TheAsocialNetwork.UI.UWP.Services.Data.Parse;

    public sealed partial class LoginPage : Page
    {
        private ParseAuthenticationService parseService;
        private NotificationService notifier;

        public LoginPage()
        {
            this.InitializeComponent();
            this.parseService = new ParseAuthenticationService();
            this.notifier = new NotificationService();
        }

        private async void ButtonLoginOnClick(object sender, RoutedEventArgs e)
        {
            var succes = await this.parseService.LogInAsync(this.UserName.Text, this.Password.Password);

            if (succes)
            {
                // notifier.ShowSuccessToast("Success, you are now logged in!");
                this.SetMainNavigation();
            }
            else
            {
                this.InvalidInputMessage.Visibility = Visibility.Visible;
                this.notifier.ShowSuccessToast("Wrong input!");
            }
        }

        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Window.Current.Content = this;

            base.OnNavigatedTo(e);
        }

        private void SetMainNavigation()
        {
            AppShell shell = Window.Current.Content as AppShell;

            if (shell == null)
            {
                shell = new AppShell();

                shell.Language = Windows.Globalization.ApplicationLanguages.Languages[0];

                shell.AppFrame.NavigationFailed += this.OnNavigationFailed;

                Window.Current.Content = shell;

                if (shell.AppFrame.Content == null)
                {
                    shell.AppFrame.Navigate(typeof(LandingPage), new RoutedEventArgs(), new Windows.UI.Xaml.Media.Animation.SuppressNavigationTransitionInfo());
                }

                Window.Current.Activate();
            }

            Window.Current.Content = shell;
        }
    }
}

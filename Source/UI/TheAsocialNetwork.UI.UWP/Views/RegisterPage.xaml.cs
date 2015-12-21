namespace TheAsocialNetwork.UI.UWP.Views
{
    using System;
    using System.Text.RegularExpressions;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;
    using TheAsocialNetwork.UI.UWP.Services.Apis;
    using TheAsocialNetwork.UI.UWP.Services.Data.Parse;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegisterPage : Page
    {
        private ParseAuthenticationService parseService;
        private NotificationService notifier;

        public RegisterPage()
        {
            this.InitializeComponent();
            this.parseService = new ParseAuthenticationService();
            this.notifier = new NotificationService();
        }

        private async void ButtonRegisterOnClick(object sender, RoutedEventArgs e)
        {
            if (!this.ValidateInput())
            {
                return;
            }

            var succes = await this.parseService.RegisterAsync(this.UserName.Text, this.Password.Password, this.Email.Text);

            if (succes)
            {
                this.notifier.ShowSuccessToast("Success, you are now logged in!");
                this.SetMainNavigation();
            }
            else
            {
                this.notifier.ShowSuccessToast("Something really bad happened!");
            }
        }

        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        private bool ValidateInput()
        {
            var isValidInput = true;

            if (this.UserName.Text.Length < 6)
            {
                this.InvalidInputMessage.Text = "Username must be at least 6 symbols";
                isValidInput = false;
            }

            if (!this.ValidateEmail(this.Email.Text))
            {
                this.InvalidInputMessage.Text = "Invalid email";
                isValidInput = false;
            }

            if (this.Password.Password.Length < 6 
                || this.Password.Password != this.ConfirmPassword.Password)
            {
                this.InvalidInputMessage.Text = "Incorrect password or not matching password confirm (password must be at least 6 symbols)";
                isValidInput = false;
            }

            return isValidInput;
        }

        private bool ValidateEmail(string email)
        {
            return Regex.IsMatch(email,
                @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
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

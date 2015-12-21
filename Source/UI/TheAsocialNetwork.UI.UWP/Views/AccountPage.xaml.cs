namespace TheAsocialNetwork.UI.UWP.Views
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices.WindowsRuntime;
    using System.Threading.Tasks;
    using Windows.Media.Capture;
    using Parse;
    using TheAsocialNetwork.UI.UWP.Helpers.Data;
    using TheAsocialNetwork.UI.UWP.Services.Data.Parse;
    using TheAsocialNetwork.UI.UWP.Services.Data.SqLite;
    using Windows.Storage.Streams;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media.Imaging;
    using Windows.UI.Xaml.Navigation;
    using TheAsocialNetwork.UI.UWP.Models.SqLite;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AccountPage : Page
    {
        public AccountPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }
    }
}

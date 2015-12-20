using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TheAsocialNetwork.UI.UWP.Views
{
    using Windows.UI.Popups;
    using TheAsocialNetwork.UI.UWP.ViewModels;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PostDetailedPage : Page
    {
        public PostDetailedPage()
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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           this.ViewModel = e.Parameter as PostViewModel;

            base.OnNavigatedTo(e);
        }

        public string Message { get; set; }
    }
}

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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace TheAsocialNetwork.UI.UWP.Controls
{
    using TheAsocialNetwork.UI.UWP.ViewModels;
    using TheAsocialNetwork.UI.UWP.Views;

    public sealed partial class AddPostControl : UserControl
    {
        public AddPostControl()
        {
            this.InitializeComponent();
        }

        private async void ButtonSaveOnClick(object sender, RoutedEventArgs e)
        {
            (this.DataContext as AddPostViewModel).HandleSavePostCommand();

            (Window.Current.Content as AppShell)
                 .AppFrame
                 .Navigate(
                     typeof(EntireMePage),
                     e.OriginalSource,
                     new Windows.UI.Xaml.Media.Animation.DrillInNavigationTransitionInfo());

        }

        //public AddPostViewModel ViewModel
        //{
        //    get
        //    {
        //        return this.DataContext as AddPostViewModel;
        //    }
        //    private set
        //    {
        //        this.DataContext = value;
        //    }
        //}
    }
}

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
    using TheAsocialNetwork.UI.UWP.Services.Data.Parse;
    using TheAsocialNetwork.UI.UWP.Views;

    public sealed partial class ImageControl : UserControl
    {
        public ImageControl()
        {
            this.InitializeComponent();
        }

        private async void UIElement_OnDoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            var ps = new ParsePostsService();

            //  var res = await ps.DeleteImageByPostAndInageId(null, "8FOqVSNnat");

            (Window.Current.Content as AppShell)
            .AppFrame
            .Navigate(
                typeof(ImageFullScreenView),
                this.DataContext,
                new Windows.UI.Xaml.Media.Animation.DrillInNavigationTransitionInfo());
        }
    }
}

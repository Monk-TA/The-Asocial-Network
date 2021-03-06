﻿using System;
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
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class IdentityPage : Page
    {
        public IdentityPage()
        {
            this.InitializeComponent();
        }

        private void ButtonLoginCLick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LoginPage), new RoutedEventArgs(), new Windows.UI.Xaml.Media.Animation.SuppressNavigationTransitionInfo());
        }

        private void ButtonRegisterCLick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RegisterPage), new RoutedEventArgs(), new Windows.UI.Xaml.Media.Animation.SuppressNavigationTransitionInfo());
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Window.Current.Content = this;

            base.OnNavigatedTo(e);
        }
    }
}

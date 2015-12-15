﻿namespace TheAsocialNetwork.UI.UWP.Convertors
{
    using System;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Data;

    public class InverseBooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                if ((bool)value)
                {
                    return Visibility.Collapsed;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
            catch
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            try
            {
                if ((bool)value)
                {
                    return Visibility.Collapsed;
                }
            }
            catch { }

            return Visibility.Visible;
        }
    }
}

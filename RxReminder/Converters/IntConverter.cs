﻿using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace RxReminder.Converters
{
    public class IntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int intValue)
            {
                return intValue.ToString();
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string stringValue && int.TryParse(stringValue, out int intValue))
            {
                return intValue;
            }
            return 0;
        }
    }
}

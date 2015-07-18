using System;
using System.Globalization;
using System.Windows.Data;
using Hell1024.model;

namespace Hell1024.views.converter
{
    public class IntToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var i = System.Convert.ToInt32(value);
            if (i == Core.BackGround || i == Core.None || i == Core.OutOfRange || i == Core.WillDelete) return "";
            return Math.Abs(i).ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new Exception();
        }
    }
}
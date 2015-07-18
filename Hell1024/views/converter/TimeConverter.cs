using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Hell1024.views.converter
{
    public class TimeConverter : IValueConverter
    {
        public const long TickCount = (long)1e7;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var param = parameter.ToString();
            var times = int.Parse(param);
            var tick = System.Convert.ToInt64(Properties.Settings.Default.AnimationSpeed * TickCount);
            return new Duration(new TimeSpan(times * tick));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        static public Duration Times(int times)
        {
            var tick = System.Convert.ToInt64(Properties.Settings.Default.AnimationSpeed * TickCount);
            return new Duration(new TimeSpan(times * tick));
        }
    }
}
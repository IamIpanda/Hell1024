using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Hell1024.views.converter
{
    public class ColorDescriptionConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var i = System.Convert.ToInt32(value);
            return SearchDescription(i);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        static public model.ColorDescription SearchDescription(long num)
        {
            return Application.Current.FindResource(string.Format("Color-{0}", num)) as model.ColorDescription;
           
        }
    }

    public class ColorDescriptionFollowerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var i = System.Convert.ToInt32(value);
            return i == model.Core.BackGround
                ? ColorDescriptionConverter.SearchDescription(model.Core.BackGround).BackColor
                : ColorDescriptionConverter.SearchDescription(model.Core.WillDelete).BackColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
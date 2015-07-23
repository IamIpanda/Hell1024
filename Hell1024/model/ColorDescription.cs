using System.Windows;
using System.Windows.Media;

namespace Hell1024.model
{
    public class ColorDescription : DependencyObject
    {
        public static readonly DependencyProperty ForeColorProperty = DependencyProperty.Register(
            "ForeColor", typeof (Color), typeof (ColorDescription), new PropertyMetadata(default(Color)));

        public Color ForeColor
        {
            get { return (Color) GetValue(ForeColorProperty); }
            set { SetValue(ForeColorProperty, value); }
        }

        public static readonly DependencyProperty BackColorProperty = DependencyProperty.Register(
            "BackColor", typeof (Color), typeof (ColorDescription), new PropertyMetadata(default(Color)));

        public Color BackColor
        {
            get { return (Color) GetValue(BackColorProperty); }
            set { SetValue(BackColorProperty, value); }
        }

        public static readonly DependencyProperty BorderColorProperty = DependencyProperty.Register(
            "BorderColor", typeof (Color), typeof (ColorDescription), new PropertyMetadata(default(Color)));

        public Color BorderColor
        {
            get { return (Color) GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }
    }
}
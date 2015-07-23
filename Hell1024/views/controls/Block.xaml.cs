using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Hell1024.model;
using Hell1024.views.converter;

namespace Hell1024.views.controls
{
    /// <summary>
    /// Block.xaml 的交互逻辑
    /// </summary>
    public partial class Block : UserControl
    {
        static converter.ColorDescriptionConverter colorDescriptionConverter = new ColorDescriptionConverter();
        public Block()
        {
            InitializeComponent();
            var binding = new Binding
            {
                RelativeSource = RelativeSource.Self,
                Path = new PropertyPath("Value"),
                Converter = colorDescriptionConverter
            };
            SetBinding(ColorDescriptionProperty, binding);
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value", typeof(long), typeof(Block), new PropertyMetadata((long)0));

        public long Value
        {
            get { return (long)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ColorDescriptionProperty = DependencyProperty.Register(
            "ColorDescription", typeof (model.ColorDescription), typeof (Block), new FrameworkPropertyMetadata(default(ColorDescription)));

        public model.ColorDescription ColorDescription
        {
            get { return (model.ColorDescription) GetValue(ColorDescriptionProperty); }
            set { SetValue(ColorDescriptionProperty, value); }
        }

        public Viewbox Box
        {
            get { return this.viewbox; }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hell1024.views.controls
{
    /// <summary>
    /// Block.xaml 的交互逻辑
    /// </summary>
    public partial class Block : UserControl
    {
        public Block()
        {
            InitializeComponent();
        }


        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value", typeof (long), typeof (Block), new PropertyMetadata((long) 0));

        public long Value
        {
            get { return (long) GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
    }
}

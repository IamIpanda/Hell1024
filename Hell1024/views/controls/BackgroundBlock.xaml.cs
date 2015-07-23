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
    /// BackgroundBlock.xaml 的交互逻辑
    /// </summary>
    public partial class BackgroundBlock : UserControl
    {
        public BackgroundBlock(Block pioneer)
        {
            PioneerBlock = pioneer;
            InitializeComponent();
        }

        public static readonly DependencyProperty PioneerBlockProperty = DependencyProperty.Register(
            "PioneerBlock", typeof (Block), typeof (BackgroundBlock), new PropertyMetadata(default(Block)));

        public Block PioneerBlock
        {
            get { return (Block) GetValue(PioneerBlockProperty); }
            set { SetValue(PioneerBlockProperty, value); }
        }
    }
}

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
using Hell1024.model;

namespace Hell1024.views.controls
{
    /// <summary>
    /// Playground.xaml 的交互逻辑
    /// </summary>
    public partial class Playground : UserControl
    {
        public Playground()
        {
            InitializeComponent();
        }

        private Core core;
        public Core Value
        {
            get { return core; }
            set
            {
                core = value;
                help.PlaygroundHelp.GenerateGrid(Grid, value); }
        }

        private Block[,] Blocks;
    }
}

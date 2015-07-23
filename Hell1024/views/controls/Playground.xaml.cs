using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
                Blocks = help.PlaygroundHelp.GenerateGrid(Grid, value); }
        }

#pragma warning disable 649
        private Block[,] Blocks;
#pragma warning restore 649

        public Block this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= BlocksWidth || j < 0 || j >= BlocksHeight)
                    return null;
                return Blocks[i, j];
            }
        }

        public int BlocksWidth => Blocks.GetLength(0);

        public int BlocksHeight => Blocks.GetLength(1);

        public bool isBusy { get; internal set; } = false;
    }
}

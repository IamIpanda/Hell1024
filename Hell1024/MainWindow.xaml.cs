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

namespace Hell1024
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var c = new Core(5);
            c[0] = new List<long>() { 2, 2, 2, 0, 2 };
            c[1] = new List<long>() { 2, 2, 0, 2, 2 };
            c[2] = new List<long>() { 2, 0, 2, 0, 2 };
            c[3] = new List<long>() { 0, 0, 0, 2, 2 };
            c[4] = new List<long>() { 0, 0, 2, 4, 2 };
            c[5] = new List<long>() { 0, -1, 0, -1, -1 };
            c[6] = new List<long>() { -2, -2, -2, -2, -2 };
            c[7] = new List<long>() { -2, -2, -2, -2, -2 };
            c[8] = new List<long>() { -2, -2, -2, -2, -2 };
            c[9] = new List<long>() { -2, -2, -2, -2, -2 };
            c[10] = new List<long>() { -2, -2, -2, -2, -2 };

            pg.Value = c;
        }
    }
}

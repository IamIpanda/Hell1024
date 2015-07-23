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
using Hell1024.views.controls.help;

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
            
            var c = Game.Instance.Core;
            pg.Value = c;
            Game.Instance.NewGame();
            pg.ExecuteAnimationList();
        }

        private void MainWindow_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (pg.isBusy) return;
            switch (e.Key) {
                case Key.Up:
                    pg.MoveUp();
                    checkScore();
                    break;
                case Key.Down:
                    pg.MoveDown();
                    checkScore();
                    break;
                case Key.Left: 
                    pg.MoveLeft();
                    checkScore();
                    break;
                case Key.Right:
                    pg.MoveRight();
                    checkScore();
                    break;
            }
        }

        public void checkScore()
        {
            if (Game.Instance.Core.ToAddScore == 0) return;
            Score.ToAddValue = Game.Instance.Core.ToAddScore;
            Game.Instance.Core.ToAddScore = 0;
        }

        private void Border_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Game.Instance.NewGame();
            pg.ExecuteAnimationList();
        }
    }
}

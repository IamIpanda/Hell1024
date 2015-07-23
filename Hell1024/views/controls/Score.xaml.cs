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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Hell1024.model;

namespace Hell1024.views.controls
{
    /// <summary>
    /// Score.xaml 的交互逻辑
    /// </summary>
    public partial class Score : UserControl
    {
        public Score()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value", typeof (long), typeof (Score), new PropertyMetadata((long)0));

        public long Value
        {
            get { return (long) GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ToAddValueProperty = DependencyProperty.Register(
            "ToAddValue", typeof (long), typeof (Score), new PropertyMetadata((long)0, ToAddValueChangedCallBack));


        public long ToAddValue
        {
            get { return (long) GetValue(ToAddValueProperty); }
            set { SetValue(ToAddValueProperty, value); }
        }


        private static void ToAddValueChangedCallBack(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var value = Convert.ToInt64(dependencyPropertyChangedEventArgs.NewValue);
            if (value == 0) return;
            var score = dependencyObject as Score;
            var block = score?.score_add;
            if (block == null) return;
            if (block.HasAnimatedProperties)
                score.Storyboard_Completed(score, new EventArgs());
            block.Text = (value > 0 ? "+" : "") + value;
            var storyboard = resource.Animation.Instance["ScoreAdded"];
            ((ThicknessAnimation) storyboard.Children[0]).To = new Thickness(0, -block.ActualHeight / 2, 0, block.ActualHeight / 2);
            storyboard.Completed += score.Storyboard_Completed;
            block.BeginStoryboard(storyboard);
        }

        private void Storyboard_Completed(object sender, EventArgs e)
        {
            score_add.Text = "";
            score_add.BeginAnimation(MarginProperty, null);
            score_add.BeginAnimation(OpacityProperty, null);
            Value += ToAddValue;
            // 分数上传
            Game.Instance.Core.Score = Value;
            ToAddValue = 0;
        }
    }
}

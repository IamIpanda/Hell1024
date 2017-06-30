using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hell1024.views.controls
{
    /// <summary>
    /// ShadowButton.xaml 的交互逻辑
    /// </summary>
    public partial class ShadowButton : UserControl
    {
        private BlurEffect effect;
        public ShadowButton()
        {
            InitializeComponent();
            effect = TextBlock.Effect as BlurEffect;
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            "Some Text Here", typeof (string), typeof (ShadowButton), new PropertyMetadata(default(string)));

        public string Text
        {
            get { return (string) GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public void ToClear()
        {
            var animation = resource.Animation.Instance.SearchAnimationResouce<DoubleAnimation>("CountTo0");
            effect?.BeginAnimation(BlurEffect.RadiusProperty, animation);
        }

        public void ToBlur()
        {
            var animation = resource.Animation.Instance.SearchAnimationResouce<DoubleAnimation>("CountTo3");
            effect?.BeginAnimation(BlurEffect.RadiusProperty, animation);
        }

        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            ToClear();
        }

        private void TextBlock_MouseLeave(object sender, MouseEventArgs e)
        {
            ToBlur();
        }
    }
}

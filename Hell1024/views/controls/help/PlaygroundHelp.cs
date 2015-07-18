using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Hell1024.model;

namespace Hell1024.views.controls.help
{
    public static class PlaygroundHelp
    {
        private static readonly int margin_value = 4;

        private static void Erase(Grid grid)
        {
            grid.Children.Clear();
            grid.ColumnDefinitions.Clear();
            grid.RowDefinitions.Clear();
        }

        private static ColumnDefinition GenerateColumn()
        {
            return new ColumnDefinition
            {
                Width = new GridLength(1, GridUnitType.Star)
            };
        }

        private static RowDefinition GenerateRow()
        {
            return new RowDefinition()
            {
                Height = new GridLength(1, GridUnitType.Star)
            };
        }

        private static ColumnDefinition GenerateLeftRightColumn()
        {
            return new ColumnDefinition()
            {
                Width = new GridLength(margin_value, GridUnitType.Pixel)
            };
        }

        private static RowDefinition GenerateTopBottomRow()
        {
            return new RowDefinition()
            {
                Height = new GridLength(margin_value, GridUnitType.Pixel)
            };
        }

        private static Block GenerateBlock(long value)
        {
            return new Block()
            {
                Margin = new Thickness(margin_value),
                Value = value
            };
        }

        public static Block[, ] GenerateGrid(Grid grid, Core data)
        {
            Erase(grid);
            grid.ColumnDefinitions.Add(GenerateLeftRightColumn());
            for (var i = 0; i < data.Width; i++)
                grid.ColumnDefinitions.Add(GenerateColumn());
            grid.ColumnDefinitions.Add(GenerateLeftRightColumn());
            grid.RowDefinitions.Add(GenerateTopBottomRow());
            for(var j = 0; j < data.Height; j++)
                grid.RowDefinitions.Add(GenerateRow());
            grid.RowDefinitions.Add(GenerateTopBottomRow());
            var answer = new Block[data.Width, data.Height];
            for (var i = 0; i < data.Width; i++)
                for (var j = 0; j < data.Height; j++)
                {
                    var block = GenerateBlock(data[i, j]);
                    block.SetValue(Grid.RowProperty, j + 1);
                    block.SetValue(Grid.ColumnProperty, i + 1);
                    grid.Children.Add(block);
                }
            return answer;
        }

        static public Thickness ToTarget(Block block, int from_x, int from_y, int to_x, int to_y)
        {
            var move_x = to_x - from_x;
            var move_y = to_y - from_y;
            return new Thickness(
                block.Margin.Left + move_x * block.ActualWidth,
                block.Margin.Top + move_y * block.ActualHeight,
                block.Margin.Right - move_x * block.ActualWidth,
                block.Margin.Bottom - move_y * block.ActualHeight);
        }

        static public ThicknessAnimation MoveAnimation(Block block, int from_x, int from_y, int to_x, int to_y)
        {
            var animation = new ThicknessAnimation
            {
                To = ToTarget(block, from_x, from_y, to_x, to_y),
                Duration = converter.TimeConverter.Times(2),
                AccelerationRatio = 0.6
            };
            block.BeginAnimation(FrameworkElement.MarginProperty, animation);
            return animation;
        }


    }
}
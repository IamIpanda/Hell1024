using Hell1024.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using Action = Hell1024.model.Action;

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

        public static Block[,] GenerateGrid(Grid grid, Core data)
        {
            Erase(grid);
            grid.ColumnDefinitions.Add(GenerateLeftRightColumn());
            for (var i = 0; i < data.Width; i++)
                grid.ColumnDefinitions.Add(GenerateColumn());
            grid.ColumnDefinitions.Add(GenerateLeftRightColumn());
            grid.RowDefinitions.Add(GenerateTopBottomRow());
            for (var j = 0; j < data.Height; j++)
                grid.RowDefinitions.Add(GenerateRow());
            grid.RowDefinitions.Add(GenerateTopBottomRow());
            var answer = new Block[data.Width, data.Height];
            var temp_list = new List<Block>();
            for (var i = 0; i < data.Width; i++)
                for (var j = 0; j < data.Height; j++)
                {
                    var block = GenerateBlock(data[i, j]);
                    block.SetValue(Grid.RowProperty, j + 1);
                    block.SetValue(Grid.ColumnProperty, i + 1);
                    var back = new BackgroundBlock(block) { Margin = new Thickness(margin_value) };
                    back.SetValue(Grid.RowProperty, j + 1);
                    back.SetValue(Grid.ColumnProperty, i + 1);
                    grid.Children.Add(back);
                    temp_list.Add(block);
                    answer[i, j] = block;
                }
            foreach (var block in temp_list)
                grid.Children.Add(block);
            return answer;
        }

        public static Thickness ToTarget(Block block, int from_x, int from_y, int to_x, int to_y)
        {
            var move_x = to_x - from_x;
            var move_y = to_y - from_y;
            return new Thickness(
                block.Margin.Left + move_x * (block.ActualWidth + margin_value * 2) - margin_value,
                block.Margin.Top + move_y * (block.ActualHeight + margin_value * 2) - margin_value,
                block.Margin.Right - move_x * (block.ActualWidth + margin_value * 2) - margin_value,
                block.Margin.Bottom - move_y * (block.ActualHeight + margin_value * 2) - margin_value);
        }

        static public Storyboard MoveAnimation(this Block block, int from_x, int from_y, int to_x, int to_y)
        {
            var animation = new ThicknessAnimation
            {
                To = ToTarget(block, from_x, from_y, to_x, to_y),
                Duration = converter.TimeConverter.Times(2),
                AccelerationRatio = 0.6
            };
            block.traveller.BeginAnimation(FrameworkElement.MarginProperty, animation);
            var storyboard = new Storyboard();
            storyboard.Children.Add(animation);
            animation.SetValue(Storyboard.TargetPropertyProperty, new PropertyPath("Margin"));
            return storyboard;
        }

        static public Storyboard AppearAnimation(this Block block)
        {
            var storyboard = resource.Animation.Instance["EmphasizeStoryboard"].Clone();
            block.traveller.BeginStoryboard(storyboard);
            return storyboard;
        }

        static public Storyboard ChangeToAnimation(this Block block, long value)
        {
            throw new NotImplementedException();
        }

        static public Storyboard DisappearAnimation(this Block block)
        {
            var storyboard = resource.Animation.Instance["DeleteStoryboard"].Clone();
            block.traveller.BeginStoryboard(storyboard);
            return storyboard;
        }

        static public KeyValuePair<Block, Storyboard> ExecuteAnimation(this Playground playground, Action action)
        {
            switch (action.Type)
            {
                case ActionType.Appear:
                    var appearing_block = playground[action.Position.X, action.Position.Y];
                    appearing_block.Value = action.Number;
                    return new KeyValuePair<Block, Storyboard>(appearing_block, appearing_block.AppearAnimation());

                case ActionType.Disappear:
                    var disappearing_block = playground[action.Position.X, action.Position.Y];
                    return new KeyValuePair<Block, Storyboard>(disappearing_block, disappearing_block.DisappearAnimation());

                case ActionType.Move:
                    var moving_block = playground[action.From.X, action.From.Y];
                    return new KeyValuePair<Block, Storyboard>(moving_block, moving_block.MoveAnimation(action.From.X, action.From.Y, action.To.X, action.To.Y));
            }
            return new KeyValuePair<Block, Storyboard>(null, null);
        }

        public static void ExecuteAnimationList(this Playground playground, EventHandler finish = null)
        {
            ResetBlocks(playground);
            var list = Game.Instance.Move.Pop();
            if (list == null)
            {
                finish?.Invoke(playground, new EventArgs());
                return;
            }
            var animations = new List<KeyValuePair<Block, Storyboard>>();
            // ReSharper disable once LoopCanBePartlyConvertedToQuery
            foreach (var action in list)
            {
                Game.Instance.Core.Execute(action);
                var response = playground.ExecuteAnimation(action);
                if (response.Key != null)
                    animations.Add(response);
            }
            if (animations.Count == 0)
                // ReSharper disable once TailRecursiveCall
                ExecuteAnimationList(playground, finish);
            else
                animations.Last(pair => true).Value.Completed +=
                    (sender, args) => ExecuteAnimationList(playground, finish);
            foreach (var keyValuePair in animations)
                keyValuePair.Key.traveller.BeginStoryboard(keyValuePair.Value);
        }

        static public void ResetBlocks(this Playground playground)
        {
            for (var i = 0; i < playground.BlocksWidth; i++)
                for (var j = 0; j < playground.BlocksHeight; j++)
                {
                    playground[i, j].traveller.BeginAnimation(FrameworkElement.MarginProperty, null);
                    playground[i, j].traveller.BeginAnimation(UIElement.OpacityProperty, null);
                    playground[i, j].traveller.SetValue(Panel.ZIndexProperty, 0);
                    playground[i, j].Value = Game.Instance.Core[i, j];
                }
        }

        static public void Execute(this Playground playground)
        {
            playground.isBusy = true;
            playground.ExecuteAnimationList(delegate
            {
                Game.Instance.Generate();
                playground.ExecuteAnimationList((sender, args) => playground.isBusy = false);
            });
        }

        static public void MoveUp(this Playground playground)
        {
            Game.Instance.Behave.MoveUp();
            playground.Execute();
        }

        static public void MoveDown(this Playground playground)
        {
            Game.Instance.Behave.MoveDown();
            playground.Execute();
        }

        static public void MoveLeft(this Playground playground)
        {
            Game.Instance.Behave.MoveLeft();
            playground.Execute();
        }

        static public void MoveRight(this Playground playground)
        {
            Game.Instance.Behave.MoveRight();
            playground.Execute();
        }
    }
}
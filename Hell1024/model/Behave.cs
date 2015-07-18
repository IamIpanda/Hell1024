using System;
using System.Drawing;
using System.Windows.Controls.Primitives;

namespace Hell1024.model
{
    public class Behave
    {
        public Movement TargetMovement { get; set; }
        public Core TargetCore { get; set; }

        public Behave(Movement target_movement = null, Core target_core = null)
        {
            TargetMovement = target_movement ?? Game.Instance.Move;
            TargetCore = target_core ?? Game.Instance.Core;
        }

        protected Core Move(int x_move, int y_move, int x_start, int y_start, int step_x_move, int step_y_move)
        {
            // 初始化
            var answer = new Core(TargetCore);
            var record = new Core(TargetCore.GameSize);
            if (x_start < 0) x_start += answer.Width;
            if (y_start < 0) y_start += answer.Height;
            var during_step_x_move = -x_move;
            var during_step_y_move = -y_move;
            var x = x_start;
            var y = y_start;
            // 逐行/逐列处理
            while (answer[x_start, y_start] != Core.OutOfRange)
            {
                x = x_start;
                y = y_start;
                while (answer[x, y] != Core.OutOfRange)
                {
                    if (answer[x, y] != Core.None && answer[x, y] != Core.BackGround)
                    {
                        
                        var now_number = answer[x, y];
                        // 反方向检查
                        var predict = answer.LatestBlock(x, y, -x_move, -y_move);
                        var predict_number = answer[predict.X, predict.Y];
                        // 如果反方向上已经存在了一个负值，那么停止
                        if (predict_number + now_number == 0) goto while_out;
                        // 取目标单元移动位置
                        var to = answer.LatestBlock(x, y, x_move, y_move);
                        var to_number = answer[to.X, to.Y];
                        if (to_number == now_number)
                        {
                            // 合并
                            answer.Execute(TargetMovement.Move(x, y, to.X, to.Y));
                            answer.Execute(TargetMovement.Appear(to.X, to.Y, 2 * to_number, 1));
                            record[to.X, to.Y] = answer[to.X, to.Y]; // 记录
                            answer[to.X, to.Y] = Core.BackGround; // 此位置已行动
                        }
                        else if (to_number + now_number == 0)
                        {
                            // 湮灭
                            answer.Execute(TargetMovement.Move(x, y, to.X, to.Y));
                            answer.Execute(TargetMovement.Disappear(to.X, to.Y, 1));
                            record[to.X, to.Y] = Core.WillDelete; // 记录
                            answer[to.X, to.Y] = Core.BackGround; // 此位置已行动
                        }
                        else
                        {
                            // 移动
                            to.Offset(-x_move, -y_move);
                            answer.Execute(TargetMovement.Move(x, y, to.X, to.Y));
                        }
                    }
                while_out:
                    x += during_step_x_move;
                    y += during_step_y_move;
                }
                x_start += step_x_move;
                y_start += step_y_move;
            }
            return answer.AddFrom(record);
        }

        public Core MoveLeft()
        {
            return Move(-1, 0, 1, 0, 0, 1);
        }

        public Core MoveRight()
        {
            return Move(1, 0, -2, 0, 0, 1);
        }

        public Core MoveUp()
        {
            return Move(0, -1, 0, 1, 1, 0);
        }

        public Core MoveDown()
        {
            return Move(0, 1, 0, -2, 1, 0);
        }

        public void Shuffle()
        {
            
        }

        public void Generate()
        {
            
        }
    }
}
using System.Drawing;
using System.Dynamic;
using System.Linq;

namespace Hell1024.model
{
    public class Door
    {
        public long[,] Value { get; set; } = null;
        public Rectangle Area { get; private set; }
        public Core TargetCore { get; private set; }
        public Movement TargetMovement { get; private set; }

        public Door(Core target_core, Rectangle area, Movement target_movement)
        {
            Area = area;
            TargetCore = target_core;
            TargetMovement = target_movement;
            Value = new long[Area.Width, Area.Height];
        }

        public void Post()
        {
            for (var i = Area.Left; i < Area.Right; i++)
                for (var j = Area.Top; j < Area.Bottom; j++)
                    TargetCore[i, j] = Value[i - Area.Left, j - Area.Top];
        }

        public void Post(int moment)
        {
            for (var i = Area.Left; i <= Area.Right; i++)
                for (var j = Area.Top; j <= Area.Bottom; j++)
                {
                    var x = i - Area.Left;
                    var y = j = Area.Top;
                    var target = Value[x, y];
                    if (target == Core.BackGround)
                        TargetMovement.Disappear(i, j, moment);
                    else
                        TargetMovement.Appear(i, j, target, moment);
                }
        }

        public void SetValue(params long[] to_set_value)
        {
            for (var i = 0; i < to_set_value.Length && i < Value.Length; i++)
            {
                var x = i % Area.Width;
                var y = i / Area.Width;
                Value[x, y] = to_set_value[i];
            }
        }

        public long this[int index]
        {
            get { return Value[index % Area.Width, index / Area.Width]; }
            set { Value[index % Area.Width, index / Area.Width] = value; }
        }

        public bool isAllClose
        {
            get
            {
                for (var i = 0; i < Area.Width; i++)
                    for (var j = 0; j < Area.Height; j++)
                        if (Value[i,j] != Core.BackGround)
                            return false;
                return true;
            }
        }

        public bool FitTarget(params long[] to_fit_value)
        {
            for (var i = 0; i < to_fit_value.Length && i < Value.Length; i++)
            {
                var x = i % Area.Width;
                var y = i / Area.Width;
                if (Value[x, y] != to_fit_value[i])
                    return false;
            }
            return true;
        }
    }
}
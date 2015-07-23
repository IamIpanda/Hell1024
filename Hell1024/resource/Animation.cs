using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace Hell1024.resource
{
    public class Animation
    {
        static Animation()
        {
            Instance = new Animation();
        }

        protected Animation()
        {
        }

        public static Animation Instance { get; set; }

        public Storyboard this[string str]
        {
            get
            {
                try
                {
                    var obj = Application.Current.FindResource(str);
                    var st = obj as Storyboard;
                    return st == null ? null : st.Clone();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    return null;
                }
            }
        }

        public T SearchAnimationResouce<T>(string str) where T : AnimationTimeline
        {
            try
            {
                var obj = Application.Current.FindResource(str);
                var st = obj as T;
                return st == null ? null : st.Clone() as T;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return null;
            }
        }
    }

    public static class AwaitAnimationExtension
    {
        public static Task BeginAndWaitForStoryboard(this Storyboard st, FrameworkElement target = null)
        {
            var tcs = new TaskCompletionSource<object>();
            EventHandler f = null;
            f = delegate
            {
                st.Completed -= f;
                tcs.TrySetResult(null);
            };
            st.Completed += f;
            if (target == null) st.Begin();
            else st.Begin(target);
            return tcs.Task;
        }

        public static Task BeginAndWaitForStoryboard(this AnimationTimeline an, FrameworkElement target,
            DependencyProperty property)
        {
            var tcs = new TaskCompletionSource<object>();
            EventHandler f = null;
            f = delegate
            {
                an.Completed -= f;
                tcs.TrySetResult(null);
            };
            an.Completed += f;
            if (target != null) target.BeginAnimation(property, an);
            return tcs.Task;
        }
    }
}
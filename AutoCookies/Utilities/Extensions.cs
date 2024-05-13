using System.Diagnostics;

namespace AutoCookies.Utilities
{
    public static class Extensions
    {
        public static T WaitFor<T>(this T obj, Func<T, bool> func)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var conditionPassed = false;

            while (stopWatch.Elapsed.TotalSeconds < Properties.DefaultTimeout && !conditionPassed)
            {
                try
                {
                    conditionPassed = func.Invoke(obj);
                }
                catch (Exception _)
                {
                    // ignore
                }
            }
            stopWatch.Stop();
            return conditionPassed ? obj : throw new("Timed out waiting for condition");
        }

        public static T WaitForDisplayed<T>(this T element) where T : IDisplayable
        {
            return element.WaitFor(e => e.IsDisplayed());
        }
    }
}

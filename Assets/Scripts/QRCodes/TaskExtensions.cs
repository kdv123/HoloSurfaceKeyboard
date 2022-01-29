using System;
using System.Threading.Tasks;

namespace MRKTExtensions.Utilities
{
    /**
     * Author : Joshua Reynolds
     * Adapted from : Joost van Schaik
      * https://localjoost.github.io/Positioning-QR-codes-in-space-with-HoloLens-2-building-a-'poor-man's-Vuforia'/
      * https://localjoost.github.io/Reading-QR-codes-with-an-MRTK2-Extension-Service/
     * Description : custom tasks
     */
    public static class TaskExtensions
    {
        public static async Task AwaitWithTimeout<T>(this Task<T> task, int timeout, Action<T> success, Action error)
        {
            if (await Task.WhenAny(task, Task.Delay(timeout)) == task)
            {
                success?.Invoke(task.Result);
            }
            else
            {
                error?.Invoke();
            }
        }
    }
}

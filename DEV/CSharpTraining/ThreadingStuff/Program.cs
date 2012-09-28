using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingStuff
{
    public class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cancellationTokenSource = 
                new CancellationTokenSource();
            Task writeStarTask = Task.Run(()=>
                {
                    while (!cancellationTokenSource.Token.IsCancellationRequested)
                    {
                        Console.Write("*");
                    }
                }, cancellationTokenSource.Token );
            Console.WriteLine("ENTER to request cancellation");
            Console.ReadLine();

            // Why not use just bool?
            cancellationTokenSource.Cancel();
            Console.WriteLine("After Cancellation");
            Thread.Sleep(1000);
            Console.WriteLine("ENTER to shutdown");
            Console.ReadLine();
        }
    }
}

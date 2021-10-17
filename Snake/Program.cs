using Snake.Logica;
using Snake.Model;
using Snake.View;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        async static Task Main(string[] args)
        {
            while (true)
            {
                var worker = new Worker(50, 20);
                new WriteToConsole(worker.Current);
                Task task = null;
                CancellationTokenSource cancellation = new CancellationTokenSource();
                while (await worker.MoveShakeAsync(200))
                {
                    if (task == null)
                    {
                        task = Task.Run(() =>
                       GetKeys(worker.Snake, cancellation.Token)
                       );
                    }
                }
                cancellation.Cancel();
                Console.Clear();
            }
            
            Console.ReadKey();
        }
        static void GetKeys(SnakeObj snake, CancellationToken cancellationToken)
        {
            while (true)
            {
                if (cancellationToken.IsCancellationRequested) break;
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.A)
                    snake.Left();
                else if (key == ConsoleKey.D)
                    snake.Right();
                else if (key == ConsoleKey.S)
                    snake.Down();
                else if (key == ConsoleKey.W)
                    snake.Up();
            }
        }
    }
}

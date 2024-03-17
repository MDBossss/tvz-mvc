using System;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace TaskWaitAllExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task koji čeka 1 sekundu.
            Task task1 = Task.Run(() =>
            {
                Console.WriteLine("Task 1: Start");
                Thread.Sleep(1000);
                Console.WriteLine("Task 1: Finish");
            });

            // Task koji čeka 1.5 sekunde.
            Task task2 = Task.Run(() =>
            {
                Console.WriteLine("Task 2: Start");
                Thread.Sleep(1000);
                Console.WriteLine("Task 2: Finish");
            });

            Task sleepF1Task = SleepF1();

            // Čekanje na dovršetak oba taska.
            Console.WriteLine("Main: Wait for tasks");
            Task.WaitAll(task1, task2, sleepF1Task);
            Console.WriteLine("Main: Tasks finished");

            // WaitAll ceka sve da zavrse
            // WaitAny ceka da bilo koji zavrsi

            Console.ReadKey();


            static async Task SleepF1()
            {
                Console.WriteLine("SleepF1 Start");
                await SleepF2();
                Console.WriteLine("SleepF1 Finish");

            }

            static async Task SleepF2()
            {
                Console.WriteLine("SleepF2 Start");
                await Task.Delay(2000);
                Console.WriteLine("SleepF2 Finish");
            }






        }
    }
}

using System;
using System.Runtime.InteropServices;

namespace lab4
{

    class Program
    {
        [DllImport("E:\\C# tasks\\C#\\Lab4\\Lab4\\lib.dll", CharSet = CharSet.Ansi)]
        static extern void SyntaxError(string filename);
        static void Main(string[] args)
        {
            Console.Title = ("С#");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            //int size = Convert.ToInt32(Console.ReadLine());
            //int[] array = new int[size];
            //Random rand = new Random();
            //for(int i = 0; i < size; i++)
            //{
            //    array[i] = rand.Next(100);
            //}
            //Sort(array, size);
            Console.SetWindowSize(45, 10);
            while (true)
            {
                long PhysicalAvailable = PerformanceInfo.GetPhysicalAvailableMemoryInMiB();
                long TotalMemory = PerformanceInfo.GetTotalMemoryInMiB();
                long NanPhysicalAvailable = TotalMemory - PhysicalAvailable;
                decimal percentFree = ((decimal)PhysicalAvailable / (decimal)TotalMemory) * 100;
                decimal percentOccupied = 100 - percentFree;
                long KernelPaged = PerformanceInfo.GetKernelPagedInMiB();
                long KernelTotal = PerformanceInfo.GetKernelTotalInMiB();
                decimal PercentFree = ((decimal)KernelPaged / (decimal)KernelTotal) * 100;
                decimal PercentOccupied = 100 - PercentFree;
                long SystemCash = PerformanceInfo.GetSystemCacheInMiB();

                Console.WriteLine($"Физическая память { NanPhysicalAvailable } / {TotalMemory} mb");
                Console.WriteLine($"Свободно {percentFree} %");
                Console.WriteLine($"Знаято {percentOccupied} %");

                Console.WriteLine($"Выгружаеммый пул {KernelPaged} mb");
                Console.WriteLine($"Весь пул {KernelTotal} mb");
                Console.WriteLine($"Свободно {PercentFree} %");
                Console.WriteLine($"Знаято {PercentOccupied} %");

                Console.WriteLine($"Системный кеш {SystemCash} mb");

                System.Threading.Thread.Sleep(600);
                Console.Clear();
            }
        }
    }
}
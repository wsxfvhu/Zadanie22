using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha1
{
    internal class Program
    {
        static void CreateArray(int n,int[] array)
        {
            Random random = new Random();
            Console.Write("Массив: ");
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(0, 100);
                Console.Write($" {array[i]} ");
            }
            Console.WriteLine();
        }
        static void GetArraySum(Task task, object arr)
        {
            int[] array = (int[])arr;
            Console.WriteLine($"Сумма элементов массива: {array.Sum()}");
        }
        static void GetArrayMax(Task task, object arr)
        {
            int[] array = (int[])arr;
            Console.WriteLine($"Максимальное значение в массиве: {array.Max()}");
        }
        static void Main(string[] args)
        {
            Console.Write("Введите размер массива: ");
            int n = Int32.Parse(Console.ReadLine());
            int[] array = new int[n];
            Task task1 = new Task(() =>CreateArray(n,array));
            Action<Task, object> action2 = new Action<Task, object>(GetArraySum);
            Action<Task, object> action3 = new Action<Task, object>(GetArrayMax);
            Task task2 = task1.ContinueWith(action2, array);
            Task task3 = task1.ContinueWith(action3, array);
            task1.Start();
            Console.ReadKey();
        }
    }
}

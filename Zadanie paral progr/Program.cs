using System;
using System.Threading.Tasks;

namespace Zadanie_parallelnoe_programm
{
    class Program
    {

        public static int SummaVMassive(object array)
        {
            int[] array1 = (int[])array;
            int sum = 0;
            foreach (int q in array1)
            {
                sum += q;
            }
            Console.WriteLine($"Сумма чисел массива равна {sum}");
            return sum;
        }
        public static int MaxVMassive(Task<int> task, object array)
        {
            int[] array1 = (int[])array;
            int max = 0;
            foreach (int q in array1)
            {
                if (q > max)
                {
                    max = q;
                }
            }
            Console.WriteLine($"Максимальное число в массиве равно {max}");
            return max;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер численного массива, затем нажмите ENTER");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] massiv = new int[n];
            Random random = new Random();
            for (int k = 0; k < n; k++)
            {
                massiv[k] = random.Next();
            }
            Func <object,int> func1 = SummaVMassive;
            Task<int> task1 = new Task<int>(func1, massiv);
            Func<Task<int>,object, int> func2 = MaxVMassive;
            Task<int> task2 = task1.ContinueWith<int>(func2, massiv);
            task1.Start();
            Console.ReadKey();
        }
    }
}

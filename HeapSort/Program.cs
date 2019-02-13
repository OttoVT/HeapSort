using System;
using HeapSort.Implementation;

namespace HeapSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[]
            {
                4, 50, 3, 28, 17, 47, 1
            };

            BinaryHeap<int>.HeapSort(array);

            foreach (var item in array)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}

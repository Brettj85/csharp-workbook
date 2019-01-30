using System;
using System.Collections.Generic;
using System.Linq;


namespace sort
{
    public class Program
    {
        public static void Main()
        {
            int[] arr = new int[15] { 213, 3, 4, 11, 20, 189, 2, 98, 90, 16, 76, 92, 123, 164, 247 };
            Sort(arr);
            PrintResults(arr);
        }

        private static void Sort(int[] arr)
        {
            int i, j, min;
            for (i = 0; i < arr.Length; i++)
            {
                min = i;
                for (j = 0; j < arr.Length; j++)
                {
                    if (arr[j] > arr[min])
                    {
                        min = j;
                        Swap(ref arr[i], ref arr[min]);
                    }
                }
            }
        }

        private static void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }
        private static void PrintResults(int[] arr)
        {
            Console.WriteLine("Sorted Values:");
            for (int i = 0; i < arr.Length; i++)
                Console.WriteLine(arr[i]);
        }
    }
}

﻿using System;

namespace sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayToSort = new int[20] { 3, 64, 5, 6, 677, 8, 889, 44, 33, 2, 2221, 44, 55, 6, 77, 88, 89, 45, 32, 6 };
            SortArray(arrayToSort);
            for (int i = 0; i < arrayToSort.Length; i++)
            {
                Console.Write("{0}, ", arrayToSort[i]);
            }

        }

        public static void Sortparts(int[] array)
        {
            //sort the array here
            int min;
            for (int i = 0; i < array.Length; i++)
            {
                min = i;
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[j] > array[min])
                    {
                        min = j;
                        int placeHolder = array[i];
                        array[i] = array[min];
                    }
                }
            }
        }
    }
}

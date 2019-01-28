﻿using System;
using System.Threading;
using System.Linq;



public class SortWithMultiThread
{
    //used for sorting an arr of unique values
    public static int[] PartialSort(int[] arr)
    {
        int[] arrayToSort = arr;

        int[] smallerThanAverage = new int[arrayToSort.Length];
        int average;
        int indexOfLowerHalf = 0;
        int indexOfHigherHalf = arrayToSort.Length - 1;
        int sum = arrayToSort.Sum();
        average = sum / arrayToSort.Length;

        for (int i = 0; i < arrayToSort.Length; i++)
        {
            if (arrayToSort[i] <= average)
            {
                smallerThanAverage[indexOfLowerHalf] = arrayToSort[i];
                indexOfLowerHalf++;
            }
            else
            {
                smallerThanAverage[indexOfHigherHalf] = arrayToSort[i];
                indexOfHigherHalf--;
            }
        }
        int[] asyncSortThis = new int[(smallerThanAverage.Length / 2) - 1];
        int j = 0;
        for (int i = (smallerThanAverage.Length / 2) + 1; j < asyncSortThis.Length; i++)
        {
            asyncSortThis[j] = smallerThanAverage[i];
            j++;
        }
        int[] smallerArr = asyncSortThis;
        return smallerArr;
    }

    public static void Main()
    {
        //split-half sort array into 2 sub arrays 1 containg the numbers that are > than average and one <= average 
        int[] inputArray = new int[20] { 13, 57, 34, 151, 70, 68, 222, 149, 64, 165, 1, 5, 4, 11, 20, 8, 2, 98, 90, 16 };
        int[] splitHalf = PartialSort(inputArray);

        int[] asyncSortThis = new int[(splitHalf.Length / 2) - 1];
        int j = 0;
        for (int i = (splitHalf.Length / 2) + 1; j < asyncSortThis.Length; i++)
        {
            asyncSortThis[j] = splitHalf[i];
            j++;
        }


        // The constructor for a Thread.        
        Thread sortingThread = new Thread(new ThreadStart(() => PartialSort(asyncSortThis)));
        //start thread
        sortingThread.Start();

        PartialSort(int[] arr);
        // Yield the rest of the time slice.
        Thread.Sleep(0);


        //join threads
        sortingThread.Join();
        //Join has returned
        Console.ReadLine();
    }
}
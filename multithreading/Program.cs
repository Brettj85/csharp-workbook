using System;
using System.Threading;
using System.Linq;



public class SortWithMultiThread
{

    public static void PartialSort(int[] arr)
    {
        for (int i = 0; i < 10; i++)
        {

            // Yield the rest of the time slice.
            Thread.Sleep(0);
        }
    }

    public static void Main()
    {
        //split-half sort array into 2 sub arrays 1 containg the numbers that are > than average and one <= average 
        int[] arrayToSort = new int[20] { 13, 57, 34, 151, 70, 68, 222, 149, 64, 165, 1, 5, 4, 11, 20, 8, 2, 98, 90, 16 };

        int[] smallerThanAverage = new int[20];
        int average;
        int indexOfLowerHalf = 0;
        int indexOfHigherHalf = 19;
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

        int[] asyncSortThis = new int[10];
        int j = 0;
        for (int i = 11; i < smallerThanAverage.Length; i++)
        {
            asyncSortThis[j] = smallerThanAverage[i];
            j++;
        }


        // The constructor for the Thread.
        Thread sortingThread = new Thread(new ThreadStart(() => PartialSort(asyncSortThis)));
        //start thread
        sortingThread.Start();

        for (int i = 0; i < 10; i++)
        {
            // Yield the rest of the time slice.
            Thread.Sleep(0);
        }

        //join threads
        sortingThread.Join();
        //Join has returned
        Console.ReadLine();
    }
}
using System;
using System.Threading;


public class SortWithMultiThread
{
    public static void PartialSort()
    {
        for (int i = 0; i < 10; i++)
        {

            // Yield the rest of the time slice.
            Thread.Sleep(0);
        }
    }

    public static void Main()
    {

        // The constructor for the Thread.
        Thread sortingThread = new Thread(new ThreadStart(PartialSort));

        //start thread
        sortingThread.Start();

        for (int i = 0; i < 4; i++)
        {

            Thread.Sleep(0);
        }

        //join threads
        sortingThread.Join();
        //Join has returned
        Console.ReadLine();
    }
}
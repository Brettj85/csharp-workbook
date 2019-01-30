using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var results = new List<int> { 4, 5, 10, 12, 14, 20, 1, 205, 26, 31, 120, 2, 3, 72, 40, 100, 140 };
        double average = results.Average();

        //split it into 2 with higher than average and lower values being in one or the other respectivly

        //keep splitting till each group has 2 (account for an odd amount of numbers)
        // note on this all groups must remain in order 

        //sort the groups of 2 at the same time

        //combine all the groups together


        //output result
    }
}


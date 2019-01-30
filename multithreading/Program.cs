using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var value_to_sort = new List<int> { 4, 5, 10, 12, 14, 20, 1, 205, 26, 31, 120, 2, 3, 72, 40, 100, 140 };
        var split_lists = SplitList(value_to_sort);
        var returned_results = SplitMore(split_lists).Result;
        var final_list = MergeSortedResults(returned_results);

        Console.WriteLine(final_list);
    }
    private static object SplitList(List<int> unsorted)
    {
        double average = unsorted.Average();
        var partial_sort = new ReturnedList();
        foreach (var num in unsorted)
        {
            if (num <= average)
            {
                partial_sort.less_than.Add(num);
            }
            else
            {
                partial_sort.greater_than.Add(num);
            }
        }
        return partial_sort;
    }
    private static List<int> MergeSortedResults(List<ReturnedList> nums)
    {

        return num;
    }
    private async Task<List<ReturnedList>> SplitAgain(List<ReturnedList> numbers)
    {

    }

    private async Task<List<int>> SplitMore(ReturnedList numbers)
    {
        //take in # of things to split
        int length = numbers.less_than.Count() + numbers.greater_than.Count();
        List<ReturnedList> split_numbers = new List<ReturnedList> { };
        List<ReturnedList> multiplied_splits = new List<ReturnedList> { };
        multiplied_splits[1] = numbers;
        while (length >= split_numbers.Count())
        {
            for (int i = 0; i < multiplied_splits.Count(); i++)
            {

            }
        }





        //loop through and do the following until there are 2 lists with 1 item each 
        //do this by splitting into x # of tasks with x # of tasks each. need a good peice of reusable code here. need to think about it...
        //split the larger side and the smaller side at the same time 
        //return 4 "returned lists" then 6 then so-on
        var something = new List<object> { nums, nums };
        await Task.WhenAll();
        return something;
    }

    private class ReturnedList
    {
        public List<int> less_than = new List<int>();
        public List<int> greater_than = new List<int>();
    }
}


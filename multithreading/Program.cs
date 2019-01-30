using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace AsyncSort
{
    public class Program
    {
        public static void Main()
        {
            var value_to_sort = new List<int> { 4, 5, 10, 12, 14, 20, 1, 205, 26, 31, 120, 2, 3, 72, 40, 100, 140 };
            var split_lists = ReturnSortedValues(value_to_sort).results;
            var final_list = MergeSortedResults(split_lists);

            Console.WriteLine(final_list);
        }

        public static async Task<ReturnedObjects> SplitList(List<int> nums)
        {
            var convert_too_class = new ReturnedList();
            var list_of_returns = new ReturnedObjects();

            await ();
        }
        public async task<ReturnedObjects> ReturnSortedValues(List<int> nums)
        {
            double average = nums.Average();
            List<ReturnedList> results = new List<ReturnedList>();
            List<ReturnedObjects> return_objects = new List<ReturnedObjects>();
            foreach (var num in nums)
            {
                if (num > average)
                {
                    results.less_than.add(num);
                }
            }
        }

        public class ReturnedList
        {
            public List<int> less_than = new List<int>();
            public List<int> greater_than = new List<int>();
        }

        public class ReturnedObjects
        {
            public List<ReturnedList> less_than = new List<ReturnedList>();
            public List<ReturnedList> greater_than = new List<ReturnedList>();
        }
    }
}
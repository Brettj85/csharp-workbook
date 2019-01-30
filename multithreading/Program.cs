using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace AsyncSort
{
    public class Program
    {
        public class Lists
        {
            public List<int> less_than = new List<int>();
            public List<int> greater_than = new List<int>();
        }
        public class Objects
        {
            public List<Lists> lists_objects = new List<Lists>();
        }
        public class Tasks
        {
            public List<Task<Lists>> task_list = new List<Task<Lists>>();
        }
        public static void Main()
        {
            var value_to_sort = new List<int> { 4, 5, 10, 12, 14, 20, 1, 205, 26, 31, 120, 2, 3, 72, 40, 100, 140 };
            Program start = new Program();
            string sorted_list = start.ReturnSortedValues(value_to_sort);
            Console.WriteLine(sorted_list);
        }
        private string ReturnSortedValues(List<int> numbers)
        {
            var sort_me = new Objects();
            var semi_sorted = new Objects();
            Lists starting_lists = new Lists();
            int i = 0;
            int j = 0;
            foreach (var num in numbers)
            {
                if (num <= numbers.Average())
                {
                    starting_lists.less_than[i] = num;
                    i++;
                }
                else
                {
                    starting_lists.greater_than[j] = num;
                    i++;
                }
            }
            sort_me.lists_objects[0] = starting_lists;

            while (sort_me.lists_objects.Count != numbers.Count / 2)
            {
                var return_tasks = Sorted(sort_me).Result;
                foreach (var tsk in return_tasks.task_list)
                {
                    semi_sorted.lists_objects.Add(tsk.Result);
                }

                // foreach (var num in nums)
                // {
                //     taskListGreater.Add(GreaterThanAverage(num, avg));
                // }

                // await Task.WhenAll(return_tasks);
                // var sort =
                // sort_me = sort;
            }

            return "print this";
        }

        public static async Task<List<Objects>> Sorted(Objects double_me)
        {
            var semi_sorted = new Objects();
            semi_sorted.lists_objects = double_me.lists_objects;

            var simplified = semi_sorted.lists_objects;
            var task_list = new List<Task<object>>();
            List<Objects> return_this = new List<Objects>();
            for (int i = 0; i > semi_sorted.lists_objects.Count; i++)
            {
                task_list.Add(AsyncListSort(simplified);
            }
            await Task.WhenAll(task_list);

            return return_this;
        }
        public static async Task<List<Tasks>> AsyncListSort(List<Task<Objects>> double_me)
        {

        }
    }
}
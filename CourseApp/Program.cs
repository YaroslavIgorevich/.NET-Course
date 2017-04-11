using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CourseApp.TreeStructure;

namespace CourseApp
{
    class Program
    {
        static void PrintItems(KeyValue[] items)
        {           
            foreach (var item in items)
            {
                Console.Write(item.Key + " ");
            }
            Console.WriteLine();            
        }

        static void Main(string[] args)
        {
            var simpleItems = new KeyValue[]
            {
	            new KeyValue {Key = "1", Value = "One"},
                new KeyValue {Key = "2", Value = "No way!"},
                new KeyValue {Key = "12", Value = "Night"},
                new KeyValue {Key = "111", Value = "To start"}
            };

            var treeStructure = new TreeStructure();
            treeStructure.Initialize(simpleItems);
            treeStructure.print();

            Console.WriteLine();

            treeStructure.Add(new KeyValue { Key = "11", Value = "New one" });
            treeStructure.print();

            Console.WriteLine();

            treeStructure.Add(new KeyValue { Key = "001", Value = "Lol" });
            treeStructure.print();

            Console.WriteLine();

            Console.WriteLine("Find 12: ");
            treeStructure.FindOptimized("12")
                .ForEach(node => Console.Write($"{node} "));

            Console.WriteLine("\n");

            Console.WriteLine("Find 111: ");
            treeStructure.FindOptimized("111")
                .ForEach(node => Console.Write($"{node} "));

            Console.WriteLine("\n");

            var temp = new Temperature(10, isCelcius: true);
            Console.WriteLine($"Initial temperature in C: {temp}");
            Console.WriteLine($"Converted temperature to F: {Temperature.ConvertToF(temp)}");
            Console.WriteLine($"And now back to C: {Temperature.ConvertToC(temp)}");

            Console.WriteLine();

            var temp1 = new Temperature(10, isCelcius: true);
            var temp2 = new Temperature(33.8, isCelcius: false);
            var temp3 = new Temperature(50, isCelcius: false);
            var daily = new[] { temp1, temp2, temp3 };

            Console.WriteLine($"t1 = {temp1}");
            Console.WriteLine($"t2 = {temp2}");
            Console.WriteLine($"t3 = {temp3}");

            Console.WriteLine();

            Console.WriteLine($"t1 + t2 = {temp1 + temp2}");
            Console.WriteLine($"t1 - t2 = {temp1 - temp2}");
            Console.WriteLine($"t1 + 13 = {temp1 + 13}");
            Console.WriteLine($"t1 - 26 = {temp1 - 26}");
            Console.WriteLine($"t1 + 7.6 = {temp1 + 7.6}");
            Console.WriteLine($"t3 == t1? (Yes, they are): {temp3 == temp1}");

            Console.WriteLine();

            Console.WriteLine("Enter a scale for average (C/F):");
            string scale = Console.ReadLine();

            Console.WriteLine($"An average of t1, t2 and t3: {Temperature.GetAverage(daily, scale)}");           
        }
    }
}

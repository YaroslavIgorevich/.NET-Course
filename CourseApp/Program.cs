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
                Console.Write(item.key + " ");
            }
            Console.WriteLine();            
        }

        static void Main(string[] args)
        {
            var simpleItems = new KeyValue[]
            {
	            new KeyValue {key = "1", value = "One"},
                new KeyValue {key = "2", value = "No way!"},
                new KeyValue {key = "12", value = "Night"},
                new KeyValue {key = "111", value = "To start"}
            };

            var treeStructure = new TreeStructure();
            treeStructure.Initialize(simpleItems);            

            PrintItems(treeStructure.Find("111"));

            treeStructure.Add(new KeyValue { key = "11", value = "Day" });

            PrintItems(treeStructure.Find("12"));

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
            Console.WriteLine($"An average of t1, t2 and t3: {Temperature.GetAverage(daily)}");
        }
    }
}

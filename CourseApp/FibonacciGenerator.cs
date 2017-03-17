using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp
{
    class FibonacciGenerator
    {   
        public void Generate()
        {
            var valid = true;
            var number = 1;

            do {
                Console.WriteLine("Please, enter a number:");
                var userInput = Console.ReadLine();                

                try
                {
                    number = Int32.Parse(userInput);
                    valid = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Invalid input");
                    valid = false;
                }
            } while (!valid);

            Console.WriteLine("Recursively: ");
            Console.Write(1 + " ");
            GenerateRecursively(number, true);

            Console.Write(Environment.NewLine);

            Console.WriteLine("Iteratively: ");
            GenerateIteratively(number);
        }

        public int GenerateRecursively(int number, bool print)
        {
            int currentElement = (number == 1 || number == 2) ? 1 : GenerateRecursively(number - 1, print) + GenerateRecursively(number - 2, false);

            if (print) { Console.Write(currentElement + " "); }

            return currentElement;            
        }

        public void GenerateIteratively(int number)
        {
            var prev = 1;
            var prevPrev = 1;
            var current = 1;

            for (var i = 0; i < number; i++)
            {
                if (i > 1)
                {
                    current = prev + prevPrev;
                    prevPrev = prev;
                    prev = current;
                }

                Console.Write(current + " ");                                
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp
{
    class FibonacciGenerator
    {   
        public void generate()
        {
            bool valid = true;
            int number = 1;

            do {
                Console.WriteLine("Please, enter a number:");
                string userInput = Console.ReadLine();                

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
            generateRecursively(number, true);

            Console.Write(Environment.NewLine);

            Console.WriteLine("Iteratively: ");
            generateIteratively(number);
        }

        public int generateRecursively(int number, bool print)
        {
            int currentElement = (number == 1 || number == 2) ? 1 : generateRecursively(number - 1, print) + generateRecursively(number - 2, false);

            if (print)
                Console.Write(currentElement + " ");

            return currentElement;            
        }

        public void generateIteratively(int number)
        {
            int prev = 1;
            int prevPrev = 1;
            int current = 1;

            for (int i = 0; i < number; i++)
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

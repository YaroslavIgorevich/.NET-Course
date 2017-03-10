using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PyramidBuilder builder = new PyramidBuilder();
            builder.build(25);

            FibonacciGenerator fibGenerator = new FibonacciGenerator();
            fibGenerator.generate();
        }
    }
}

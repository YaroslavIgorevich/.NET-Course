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
            var builder = new PyramidBuilder();
            builder.Build(25);

            var fibGenerator = new FibonacciGenerator();
            fibGenerator.Generate();
        }
    }
}

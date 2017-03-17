using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp
{
    class PyramidBuilder
    {
        public void Build(int rows)
        {
            var baseSize = 1 + (rows - 1) * 2;            
            int r, l; 
            r = l = baseSize / 2;
            BuildRow(r, l, baseSize);            
        }

        private void BuildRow(int r, int l, int baseSize)
        {
            for (var i = 0; i < baseSize; i++)
            {
                if (i >= l && i <= r)
                {
                    Console.Write('*');
                } else
                {
                    Console.Write(' ');
                }
            }

            Console.WriteLine();

            r++;
            l--;

            if (r - l < baseSize)
                BuildRow(r, l, baseSize);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp
{
    class PyramidBuilder
    {
        public void build(int rows)
        {
            int baseSize = 1 + (rows - 1) * 2;            
            int r, l; 
            r = l = baseSize / 2;
            buildRow(r, l, baseSize);            
        }

        private void buildRow(int r, int l, int baseSize)
        {
            for (int i = 0; i < baseSize; i++)
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
                buildRow(r, l, baseSize);
        }
    }
}

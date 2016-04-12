using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miracle
{
    class Scales
    {
        public static int[,] AllScales =
        {
            {0,2,4,5,7,9,11 },  //major
            {0,2,3,5,7,8,10 },   //minor
            {0,3,5,6,7,10,12 },  //blues
            {0,2,4,5,7,4,7 },   //test
            {0,2,3,5,12,7,3 }   //test2
        };

        public static int[] Major = { 0, 2, 4, 5, 7, 9, 11 };
    }
}

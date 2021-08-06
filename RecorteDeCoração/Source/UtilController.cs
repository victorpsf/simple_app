using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecorteDeCoração.Source
{
    class UtilController
    {
        public static int random(int min, int max)
        {
            Random rand = new Random();
            if (min > max) {
                int rep = min;

                min = max;
                max = rep;
            }

            return rand.Next(min, max);
        }

        public static bool in_array_int(int[] array, int value)
        {
            return Array.Exists(array, element => element == value);
        }
    }
}

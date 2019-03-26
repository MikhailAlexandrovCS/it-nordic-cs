using System;
using System.Collections.Generic;
using System.Text;

namespace TaksHW3_NewVersion
{
    class ValuesOutputer
    {
        public static void OutputInfoAfterFourYears(Person[] people)
        {
            for (int i = 0; i < people.Length; i++)
                people[i].WritePersonInfoToConsole();
        }
    }
}

using Hub.Retailer.Common.Extensions;
using System;
using System.Collections.Generic;

namespace Hub.Retailer.Common.Helpers
{
    public static class MiscHelper
    {
        public static long Get_Valid_NMI_By_State(string state, int numberOfNMI)
        {
            var random = new Random();

            var listNMIBlock = new Dictionary<string, List<Tuple<long, long>>>
            {
                {"TAS", new List<Tuple<long, long>> { new Tuple<long, long>(8000000000 + numberOfNMI, 8000099999 - numberOfNMI) }},
            };

            var nmiBlock = listNMIBlock[state]?.PickRandom();

            return Get_Random_Long_Number(nmiBlock.Item1, nmiBlock.Item2);
        }

        private static long Get_Random_Long_Number(long min, long max)
        {
            var number = max - min;
            var random = Generate_Int_Of_Range(0, (int)number);
            return min + random;
        }

        public static int Generate_Int_Of_Range(int min, int max)
        {
            return new Random().Next(min, max);
        }

    }
}

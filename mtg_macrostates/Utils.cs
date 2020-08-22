
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace MTG
{

    public static class Utils
    {
        public static BigInteger NChooseK(int N, int K)
        {
            BigInteger result = 1;
            for (int i = 1; i <= K; i++)
            {
                result *= N - (K - i);
                result /= i;
            }
            return result;
        }
    }
}
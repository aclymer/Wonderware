using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wonderware.HelperClasses
{
    public class SmartStringComparison
    {
        public static bool Equals(String l_sLeft, String l_sRight)
        {
            if (l_sLeft == null || l_sRight == null)
            {
                return false;
            }
            if (l_sLeft.Length != l_sRight.Length)
            {
                return false;
            }
            for (int iter = 0; iter < l_sLeft.Length; iter++)
            {
                if (l_sLeft[iter] != l_sRight[iter])
                {
                    return false;
                }
            }
            return true;
        }
    }
}

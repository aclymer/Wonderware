using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wonderware.HelperClasses
{
    public class ComparableStringList : List<String>
    {
        public bool Equals(ComparableStringList p_Compare)
        {
            if (p_Compare.Count == this.Count)
            {
                for (int iter = 0; iter < p_Compare.Count; iter++)
                {
                    if (this[iter] != p_Compare[iter])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
    }
}

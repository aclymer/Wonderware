using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wonderware.Process_Connection
{
	public interface IProcessConnectionServer 
	{
        Object[] GetProperties(long[] p_IDs);
        void SetProperties(long[] p_IDs, Object[] p_Values);
        void CallTest();
        long CreateUniqueKey(int l_iAutomationFunctionId, int l_iPortId);
    };
}

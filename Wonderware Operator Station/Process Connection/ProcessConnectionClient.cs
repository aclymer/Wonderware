using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wonderware.Management;
using Wonderware.Operator_Station;
using System.Diagnostics;

namespace Wonderware.Process_Connection
{
    public class ProcessConnectionClient
    {
        public static ProcessConnectionClient Instance;
        private IProcessConnectionServer ProcessConnectionServer;
        private Dictionary<long, Object> GetValueDictionary;

        public ProcessConnectionClient()
        {
            GetValueDictionary = new Dictionary<long, object>();
        }

        static ProcessConnectionClient()
        {
            Instance = new ProcessConnectionClient();
            Instance.ConnectToServer();
        }

        private void ConnectToServer()
        {
            ProcessConnectionServer = Activator.GetObject(typeof(IProcessConnectionServer), "tcp://" + Workbench.ServerIP + ":" + Workbench.ServerPort + "/Wonderware_ProcessConnectionServer") as IProcessConnectionServer;
        }

        public void ReconnectConnectToServer()
        {
            if (TestConnection() == false)
            {
                ProcessConnectionServer = Activator.GetObject(typeof(IProcessConnectionServer), "tcp://" + Workbench.ServerIP + ":" + Workbench.ServerPort + "/Wonderware_ProcessConnectionServer") as IProcessConnectionServer;
            }
        }

        public bool TestConnection()
        {
            if (ProcessConnectionServer != null)
            {
                try
                {
                    ProcessConnectionServer.CallTest();
                }
                catch (Exception ex)
                {
                    ProcessConnectionServer = null;
                    System.Diagnostics.Debug.WriteLine("Unable to connect to process connection server. Server is probably down : " + ex.Message, Database.ErrorTitle);
                    return false;
                }
                return true;
            }
            return false;
        }


        public void GetData()
        {
            if (ProcessConnectionServer != null && TestConnection() == true)
            {
                try
                {
                    if (Keys != null)
                    {
                        Object[] l_NewValues = ProcessConnectionServer.GetProperties(Keys);
                        int l_iIndexCount = 0;
                        foreach (long l_iKey in Keys)
                        {
                            Object l_NewValue = l_NewValues[l_iIndexCount];
                            GetValueDictionary[l_iKey] = l_NewValue;
                            l_iIndexCount++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Exception occured during ProcessConnection GetData() : " + ex.Message, Database.ErrorTitle);
                }
            }
        }

        public void AddGetDataPoint(int l_iAutomationFunctionId, int l_iPortId)
        {
            long l_iUniqueKey = CreateUniqueKey(l_iAutomationFunctionId, l_iPortId);
            if (GetValueDictionary.ContainsKey(l_iUniqueKey) == false)
            {
                GetValueDictionary.Add(l_iUniqueKey, null);
                Keys = GetValueDictionary.Keys.ToArray();
            }
        }

        long[] Keys;

        public Object GetDataPoint(int l_iAutomationFunctionId, int l_iPortId)
        {
            if (ProcessConnectionServer != null)// && TestConnection() == true)
            {
                long l_iUniqueKey = CreateUniqueKey(l_iAutomationFunctionId, l_iPortId);
                Object l_Value = null;
                if (GetValueDictionary.TryGetValue(l_iUniqueKey, out l_Value) == true)
                {
                    return l_Value;
                }
            }
            return null;
        }

        public long CreateUniqueKey(int l_iAutomationFunctionId, int l_iPortId)
        {
	    	return l_iAutomationFunctionId + 10000000000*l_iPortId;
        }

        public void SetDataPoint(int l_iAutomationFunctionId, int l_iPortId, Object p_Value)
        {
            if (ProcessConnectionServer != null && TestConnection() == true)
            {
                long l_iUniqueKey = CreateUniqueKey(l_iAutomationFunctionId, l_iPortId);
                long[] SetValueKey = new long[] { l_iUniqueKey };
                Object p_ValueUsed = p_Value;
                Type l_ValueType = p_Value.GetType();
                switch (l_ValueType.Name.ToLower())
                {
                    case "float":
                    case "single":
                        {
                            float l_fValue = (float)p_Value;
                            double l_dValue = System.Convert.ToDouble(l_fValue);
                            p_ValueUsed = l_dValue;
                        }
                        break;
                    default:
                        break;
                }
                Object[] SetValue = new Object[] { p_ValueUsed };
                ProcessConnectionServer.SetProperties(SetValueKey, SetValue);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Text;
using System.Threading.Tasks;
using Wonderware.Data;
using System.IO;
using System.Diagnostics;
using System.Windows.Media.Imaging;

namespace Wonderware.Management
{
    public enum DataSourceType { Copy };
    public enum CopyDataSources { HMIDiagrams };

    public class Database
    {

#region Constructors/Destructors

        //
        // Constructors/Desctuctors
        //

        public Database()
        {
            m_HMIDiagrams = new HMIDiagramDictionary();
            Instance = this;
        }

        public static Database Instance;

        ~Database()
        {
            m_HMIDiagrams = null;
        }

        public void Clear()
        {
            m_HMIDiagrams.Clear();
        }

#endregion Constructors/Destructors

#region Data items

        //
        // Data items
        //

        private HMIDiagramDictionary m_HMIDiagrams;
        

#endregion Data items

#region Members

        //
        // Members
        //

        public static string ErrorTitle = "ERROR";
        public static string InfoTitle = "INFO";
        public static String RootDataDirectory = Wonderware.Properties.Resources.RootDataDirectory;
        public static String RootSaveDirectory = Wonderware.Properties.Resources.RootSaveDirectory;
        public DirectoryInfo m_RootPath;

#endregion Members

#region Properties

        //
        // Properties
        //

        public long LoadTime;
        public int FilesLoaded;

#endregion Properties

#region Methods

        //
        // Methods
        //

        public void LoadAsync(String p_sPath)
        {
            Clear();
            LoadTime = -1;
            FilesLoaded = 0;
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            m_RootPath = new DirectoryInfo(p_sPath);
            RootDataDirectory = m_RootPath.FullName;
            if (m_RootPath.Exists == false)
            {
                Debug.WriteLine("Directory doesn't exist : " + m_RootPath.FullName, ErrorTitle);
                return;
            }
            List<DataSourceType> l_DataSourceTypes = new List<DataSourceType>
            {
                DataSourceType.Copy
            };
            Task[] tasks = new Task[l_DataSourceTypes.Count];
            int iter = 0;
            foreach (DataSourceType l_DataSourceType in l_DataSourceTypes)
            {
                tasks[iter] = Task.Factory.StartNew(() => LoadDataAsync(l_DataSourceType));
                iter++;
            }
            Task.WaitAll(tasks);
            Debug.WriteLine("Done!", InfoTitle);
            sw.Stop();
            Debug.WriteLine("Elapsed=" + sw.ElapsedMilliseconds + "ms\n", InfoTitle);
            LoadTime = sw.ElapsedMilliseconds;
        }

        private void LoadDataAsync(DataSourceType p_DataSourceType)
        {
            switch (p_DataSourceType)
            {
                case DataSourceType.Copy:
                    LoadDataCopyDirectoryAsync();
                    break;
                default:
                    break;
            }
        }

        private void LoadDataCopyDirectoryAsync()
        {
            DirectoryInfo[] l_CopyDataDirectories = m_RootPath.GetDirectories("Copy", SearchOption.TopDirectoryOnly);
            if (l_CopyDataDirectories.Length < 1)
            {
                Debug.WriteLine("No 'Copy' directory present in : " + m_RootPath.FullName, Database.ErrorTitle);
            }
            if (l_CopyDataDirectories.Length > 1)
            {
                Debug.WriteLine("More than one 'Copy' directory present in : " + m_RootPath.FullName, Database.ErrorTitle);
            }
            DirectoryInfo l_DataCopyDirectory = l_CopyDataDirectories[0];
            Debug.WriteLine("Loading 'Copy' directory  : " + l_DataCopyDirectory.FullName, "START");
            {
                List<CopyDataSources> l_CopyDataSources = new List<CopyDataSources>
                {
                    CopyDataSources.HMIDiagrams
                };
                Task[] tasks = new Task[l_CopyDataSources.Count];
                int iter = 0;
                foreach (CopyDataSources l_CopyDataSource in l_CopyDataSources)
                {
                    tasks[iter] = Task.Factory.StartNew(() => LoadCopyDataAsync(l_CopyDataSource, l_DataCopyDirectory));
                    iter++;
                }
                Task.WaitAll(tasks);
            }
            Debug.WriteLine("Loading 'Copy' directory  : " + l_DataCopyDirectory.FullName, "DONE");
        }

        private void LoadCopyDataAsync(CopyDataSources p_CopyDataSources, DirectoryInfo p_DataCopyDirectory)
        {
            switch (p_CopyDataSources)
            {
                case CopyDataSources.HMIDiagrams:
                        LoadHMIDiagramsCopyDirectoryAsync(p_DataCopyDirectory);
                    break;
                default:
                    break;
            }
        }

        private void LoadHMIDiagramsCopyDirectoryAsync(DirectoryInfo p_DataCopyDirectory)
        {
            DirectoryInfo[] l_HMIDiagramDataDirectories = p_DataCopyDirectory.GetDirectories("HMIDiagrams", SearchOption.TopDirectoryOnly);
            if (l_HMIDiagramDataDirectories.Length < 1)
            {
                Debug.WriteLine("No 'HMIDiagrams' directory present in : " + p_DataCopyDirectory.FullName, Database.ErrorTitle);
                return;
            }
            DirectoryInfo l_HMIDiagramDataDirectory = l_HMIDiagramDataDirectories[0];

            String l_sHMIDiagramXML = "*.xml";
            FileInfo[] l_HMIDiagramFiles = l_HMIDiagramDataDirectory.GetFiles(l_sHMIDiagramXML, SearchOption.AllDirectories);

            HMIDiagramsTotal = l_HMIDiagramFiles.Length;
            HMIDiagramsCount = 0;

            foreach (FileInfo l_HMIDiagramFile in l_HMIDiagramFiles)
            {
                DirectoryInfo l_CurrentDirectory = l_HMIDiagramFile.Directory;

                HMIDiagram l_HMIDiagram = LoadHMIDiagramAsync(l_HMIDiagramFile);
                l_HMIDiagram.IcDiagramXmlFile = l_HMIDiagramFile;
                if (m_HMIDiagrams.ContainsKey(l_HMIDiagram.ID) == false)
                {
                    m_HMIDiagrams.Add(l_HMIDiagram.ID, l_HMIDiagram);
                }
                else
                {
                    Debug.WriteLine("Duplicate HMI diagram id's found", Database.ErrorTitle);
                }
                FilesLoaded++;
                HMIDiagramsCount++;
            }
        }

        private HMIDiagram LoadHMIDiagramAsync(FileInfo p_ProtoTypeFileInfo)
        {
            HMIDiagram l_HMIDiagram = new HMIDiagram();

			l_HMIDiagram.LoadFileAsync(p_ProtoTypeFileInfo, "WINDOW");

            return l_HMIDiagram;
        }


        public HMIDiagramDictionary GetHMIDiagrams()
        {
            return m_HMIDiagrams;
        }

        public HMIDiagram GetHMIDiagram(String p_sID)
        {
            HMIDiagram l_HMIDiagram = null;

            if (m_HMIDiagrams.TryGetValue(p_sID, out l_HMIDiagram) == false)
            {
                //throw new ItemNotFoundException("FunctionDiagram not found", p_iIndex);
            }

            return l_HMIDiagram;
        }


        public int HMIDiagramsCount;
        public int HMIDiagramsTotal;

#endregion Methods

    }
}

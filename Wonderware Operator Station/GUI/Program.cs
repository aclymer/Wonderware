using Wonderware.Data;
using Wonderware.Management;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wonderware.Operator_Station
{
	public static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			if (args.Length == 3)
			{
				string sDatabasePath = args[0];
				if (sDatabasePath == string.Empty)
				{
					MessageBox.Show("DatabasePath argument empty!", "App Closing", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else if (Directory.Exists(sDatabasePath) == false)
				{
					MessageBox.Show("DatabasePath doesn't exist!\n\"" + sDatabasePath + "\"", "App Closing", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					String l_sServerIP = args[1];
					Workbench.ServerIP = l_sServerIP;
					int l_iUpdateRate = 2500;
					if (int.TryParse(args[2], out l_iUpdateRate) == true)
					{
						Workbench.RefreshRate = l_iUpdateRate;
					}
					LaunchApplication(sDatabasePath);
				}
			}
			else if (args.Length == 1)
			{
				string sDatabasePath = args[0];
				if (sDatabasePath == string.Empty)
				{
					MessageBox.Show("DatabasePath argument empty!", "App Closing", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else if (Directory.Exists(sDatabasePath) == false)
				{
					MessageBox.Show("DatabasePath doesn't exist!\n\"" + sDatabasePath + "\"", "App Closing", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					LaunchApplication(sDatabasePath);
				}
			}
			else if (args.Length == 0)
			{
				LaunchApplication(Database.RootDataDirectory);
			}
			else
			{
				MessageBox.Show("To many arguments!", "App Closing", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private static void LaunchApplication(String p_sDatabasePath)
		{
			LaunchDialog l_LaunchDialog = new LaunchDialog(p_sDatabasePath);
			l_LaunchDialog.ShowDialog();
			if (l_LaunchDialog.Done == true &&
				l_LaunchDialog.Success == true)
			{
				Screen l_Screen = Screen.FromPoint(l_LaunchDialog.Location);
				Workbench l_Workbench = new Workbench(l_LaunchDialog.Database);
				l_Workbench.StartPosition = FormStartPosition.Manual;
				l_Workbench.Location = new System.Drawing.Point(l_Screen.Bounds.X, l_Screen.Bounds.Y);
				Application.Run(l_Workbench);
			}
		}

		private static void ClearImmediateWindow()
		{
			EnvDTE80.DTE2 dte = Marshal.GetActiveObject("VisualStudio.DTE.11.0") as EnvDTE80.DTE2;
			EnvDTE.Window currentActiveWindow = dte.ActiveWindow;
			dte.Windows.Item("{ECB7191A-597B-41F5-9843-03A4CF275DDE}").Activate();
			dte.ExecuteCommand("Edit.SelectAll");
			dte.ExecuteCommand("Edit.ClearAll");
			currentActiveWindow.Activate();
			Marshal.ReleaseComObject(dte);
		}
	}
}

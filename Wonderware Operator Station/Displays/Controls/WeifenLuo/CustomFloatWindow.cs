using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeifenLuo.WinFormsUI.Docking;

namespace Wonderware.Operator_Station
{
	public class CustomFloatWindow : WeifenLuo.WinFormsUI.Docking.FloatWindow
	{
		public CustomFloatWindow(DockPanel dockPanel, DockPane pane)
			: base(dockPanel, pane)
		{
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			ShowInTaskbar = true;
			Owner = null;
			DoubleClickTitleBarToDock = false;
		}

		public CustomFloatWindow(DockPanel dockPanel, DockPane pane, System.Drawing.Rectangle bounds)
			: base(dockPanel, pane, bounds)
		{
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			ShowInTaskbar = true;
			Owner = null;
			DoubleClickTitleBarToDock = false;
		}
	}
}

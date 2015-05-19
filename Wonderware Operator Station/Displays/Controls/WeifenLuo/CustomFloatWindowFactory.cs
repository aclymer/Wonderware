using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeifenLuo.WinFormsUI.Docking;

namespace Wonderware.Operator_Station
{
    public class CustomFloatWindowFactory : DockPanelExtender.IFloatWindowFactory
    {
        public FloatWindow CreateFloatWindow(DockPanel dockPanel, DockPane pane, System.Drawing.Rectangle bounds)
        {
            return new WorkbenchSubScreen(dockPanel, pane, bounds);
            //return new CustomFloatWindow(dockPanel, pane, bounds);
        }

        public FloatWindow CreateFloatWindow(DockPanel dockPanel, DockPane pane)
        {
            return new WorkbenchSubScreen(dockPanel, pane);
            //return new CustomFloatWindow(dockPanel, pane);
        }
    }
}

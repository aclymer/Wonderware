using Wonderware.Data;
using Wonderware.Management;
using System.Windows.Forms.Integration;

namespace Wonderware.Operator_Station
{
    public class HMIDiagramElementHost : ElementHost, IDynamicDataGraphic
    {
        public HMIDiagramFrameworkElement PlantDisplayFrameworkElement;

        public HMIDiagramElementHost(HMIDiagram p_HMIDiagram, Database p_Database)
        {
            PlantDisplayFrameworkElement = new HMIDiagramFrameworkElement(p_HMIDiagram, p_Database);
            Child = PlantDisplayFrameworkElement;
        }

        ~HMIDiagramElementHost()
        {
            PlantDisplayFrameworkElement = null;
            Child = null;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public void DisposeChildren()
        {
            if (PlantDisplayFrameworkElement != null)
            {
                PlantDisplayFrameworkElement.Dispose();
            }
            PlantDisplayFrameworkElement = null;
            base.Dispose();
        }

        public virtual void UpdateGUI()
        {
            IDynamicDataGraphic l_DynamicDataGraphic = PlantDisplayFrameworkElement as IDynamicDataGraphic;
            if (l_DynamicDataGraphic != null)
            {
                l_DynamicDataGraphic.UpdateGUI();
            }
        }

        public virtual void Draw()
        {
            IDynamicDataGraphic l_DynamicDataGraphic = PlantDisplayFrameworkElement as IDynamicDataGraphic;
            if (l_DynamicDataGraphic != null)
            {
                l_DynamicDataGraphic.Draw();
            }
        }
    }
}

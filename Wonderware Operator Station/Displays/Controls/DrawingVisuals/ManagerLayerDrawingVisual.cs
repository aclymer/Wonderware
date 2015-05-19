using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Wonderware.Operator_Station
{
    public class ManagerLayerDrawingVisual : DrawingVisual
    {
        public int LayerIndex = 0;

        public ManagerLayerDrawingVisual(int p_iLayer)
        {
            LayerIndex = p_iLayer;
        }

        ~ManagerLayerDrawingVisual()
        {
        }

        public void Dispose()
        {
            if (Children != null)
            {
                foreach (DrawingVisual l_DrawingVisual in Children)
                {
                    BaseDrawingVisual l_BaseDrawingVisual = l_DrawingVisual as BaseDrawingVisual;
                    if (l_BaseDrawingVisual != null)
                    {
                        l_BaseDrawingVisual.Dispose();
                    }
                }
                Children.Clear();
            }
        }

        public void Add(GraphicPrimitiveDrawingVisual p_GraphicPrimitiveDrawingVisual)
        {
            if (Children.Contains(p_GraphicPrimitiveDrawingVisual) == false)
            {
                Children.Add(p_GraphicPrimitiveDrawingVisual);
            }
        }

        public void Add(BaseDrawingVisual p_BaseDrawingVisual)
        {
            if (Children.Contains(p_BaseDrawingVisual) == false)
            {
                Children.Add(p_BaseDrawingVisual);
            }
        }

        public void Remove(GraphicPrimitiveDrawingVisual p_GraphicPrimitiveDrawingVisual)
        {
            if (Children.Contains(p_GraphicPrimitiveDrawingVisual) == true)
            {
                Children.Remove(p_GraphicPrimitiveDrawingVisual);
            }
        }

        public void Remove(BaseDrawingVisual p_BaseDrawingVisual)
        {
            if (Children.Contains(p_BaseDrawingVisual) == true)
            {
                Children.Remove(p_BaseDrawingVisual);
            }
        }
    }

    public class ManagerLayerDrawingVisualList : List<ManagerLayerDrawingVisual>
    {
        public ManagerLayerDrawingVisual GetLayer(int l_iIndex)
        {
            int l_iCountLayers = 0;
            foreach (ManagerLayerDrawingVisual l_ManagerLayerDrawingVisual in this)
            {
                if (l_iIndex == l_ManagerLayerDrawingVisual.LayerIndex)
                {
                    return l_ManagerLayerDrawingVisual;
                }
                if (l_ManagerLayerDrawingVisual.LayerIndex > l_iIndex)
                {
                    break;
                }
                l_iCountLayers++;
            }
            ManagerLayerDrawingVisual l_NewLayer = new ManagerLayerDrawingVisual(l_iIndex);
            this.Insert(l_iCountLayers, l_NewLayer);
            return l_NewLayer;
        }
    }

}

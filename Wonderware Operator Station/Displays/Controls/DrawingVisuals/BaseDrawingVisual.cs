using Wonderware.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Wonderware.Operator_Station
{
    public class BaseDrawingVisual : DrawingVisual
    {
        public List<BaseDrawingVisual> ChildrenDrawingVisuals;
        public BaseDrawingVisual ParentDrawingVisual;

        public BaseDrawingVisual()
        {
            ChildrenDrawingVisuals = new List<BaseDrawingVisual>();
        }

        ~BaseDrawingVisual()
        {
        }

        public virtual void Dispose()
        {
            if (ChildrenDrawingVisuals != null)
            {
                foreach (BaseDrawingVisual l_BaseDrawingVisual in ChildrenDrawingVisuals)
                {
                    l_BaseDrawingVisual.Dispose();
                }
                ChildrenDrawingVisuals.Clear();
            }
            ChildrenDrawingVisuals = null;
            ParentDrawingVisual = null;
        }

        public void AddDrawingVisualChild(GraphicObject p_GraphicObject)
        {
            GraphicPrimitive l_GraphicPrimitive = p_GraphicObject as GraphicPrimitive;
            if (l_GraphicPrimitive != null)
            {
                GraphicPrimitiveDrawingVisual l_GraphicPrimitiveDrawingVisual = new GraphicPrimitiveDrawingVisual(l_GraphicPrimitive);
                AddBaseDrawingVisualChild(l_GraphicPrimitiveDrawingVisual);
            }
        }


        public void AddBaseDrawingVisualChild(BaseDrawingVisual l_BaseDrawingVisual)
        {
            l_BaseDrawingVisual.ParentDrawingVisual = this;
            ChildrenDrawingVisuals.Add(l_BaseDrawingVisual);
        }

        public virtual void SetBounds(TransformGroup p_TransformGroup)
        {
            foreach (BaseDrawingVisual l_BaseDrawingVisual in ChildrenDrawingVisuals)
            {
                l_BaseDrawingVisual.SetBounds(p_TransformGroup);
            }
        }

        public virtual void Draw(TransformGroup p_TransformGroup, ManagerLayerDrawingVisualList Layers, bool l_bForceVisible, bool l_bParentVisible, int p_iParentBaseLayer, bool l_bForceRedraw)
        {
            foreach (BaseDrawingVisual l_BaseDrawingVisual in ChildrenDrawingVisuals)
            {
                l_BaseDrawingVisual.Draw(p_TransformGroup, Layers, l_bForceVisible, l_bParentVisible, p_iParentBaseLayer, l_bForceRedraw);
            }
        }

        public virtual void Blink(bool p_bPhase)
        {
            foreach (BaseDrawingVisual l_BaseDrawingVisual in ChildrenDrawingVisuals)
            {
                l_BaseDrawingVisual.Blink(p_bPhase);
            }
        }

        public GraphicPrimitiveDrawingVisual GetGraphicPrimitiveDrawingVisual()
        {
            GraphicPrimitiveDrawingVisual l_GraphicPrimitiveDrawingVisual = this as GraphicPrimitiveDrawingVisual;
            if (l_GraphicPrimitiveDrawingVisual != null)
            {
                return l_GraphicPrimitiveDrawingVisual;
            }
            BaseDrawingVisual l_BaseDrawingVisual = ParentDrawingVisual as BaseDrawingVisual;
            if (l_BaseDrawingVisual != null)
            {
                return l_BaseDrawingVisual.GetGraphicPrimitiveDrawingVisual();
            }
            return null;
        }
    }
}

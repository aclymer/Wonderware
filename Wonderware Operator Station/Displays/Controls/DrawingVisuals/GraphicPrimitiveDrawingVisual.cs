using Wonderware.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Wonderware.Operator_Station
{
	public class GraphicPrimitiveDrawingVisual : BaseDrawingVisual
	{
		public GraphicPrimitiveDrawingVisual(GraphicPrimitive p_GraphicPrimitive)
		{
			GraphicPrimitive = p_GraphicPrimitive;
		}

		~GraphicPrimitiveDrawingVisual()
		{
		}

		public override void Dispose()
		{
			GraphicPrimitive = null;
			base.Dispose();
		}

		public override void SetBounds(TransformGroup p_TransformGroup)
		{
			GraphicPrimitive.SetBounds(p_TransformGroup);
			System.Windows.Rect l_ElementBounds = GraphicPrimitive.GetBounds();
		}

		public override void Draw(TransformGroup p_TransformGroup, ManagerLayerDrawingVisualList Layers, bool l_bForceVisible, bool l_bParentVisible, int p_iParentBaseLayer, bool l_bForceRedraw)
		{
			ManagerLayerDrawingVisual l_ManagerLayerDrawingVisual = Layers.GetLayer(p_iParentBaseLayer);

			if (l_bParentVisible == true &&
				(GraphicPrimitive.visible == true || l_bForceVisible == true))
			{
				GraphicPrimitive.ApplyRenderBounds(p_TransformGroup);
				DrawingContext drawingContext = RenderOpen();
				
				HMIDiagram l_HMIDiagram = GraphicPrimitive.Parent as HMIDiagram;
				if (l_HMIDiagram != null)
				{
					System.Windows.Point l_RelativePoint = new System.Windows.Point((GraphicPrimitive.Parent as HMIDiagram).DIMENSION.LEFT, (GraphicPrimitive.Parent as HMIDiagram).DIMENSION.TOP);
					TranslateTransform l_Transform = new TranslateTransform(l_RelativePoint.X, l_RelativePoint.Y);
					drawingContext.PushTransform(l_Transform);
				}
				
				GraphicPrimitive.Render(drawingContext);
				drawingContext.Close();
				l_ManagerLayerDrawingVisual.Add(this);
			}
			else
			{
				l_ManagerLayerDrawingVisual.Remove(this);
			}
		}

		public GraphicPrimitive GraphicPrimitive;
	}
}

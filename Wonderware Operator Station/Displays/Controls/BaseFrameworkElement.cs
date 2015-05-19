using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wonderware.Data;
using System.IO;
using System.Diagnostics;
using Wonderware.Management;
using Wonderware.Process_Connection;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;

namespace Wonderware.Operator_Station
{
    public abstract class BaseFrameworkElement : FrameworkElement, IDynamicDataGraphic
    {
        public VisualCollection _layers;
        public ManagerLayerDrawingVisualList BackgroundLayers;
        public ManagerLayerDrawingVisualList Layers;
        public List<BaseDrawingVisual> Children;
        private BaseDrawingVisual SelectedVisual;
        public bool FinishedContruction = false;

        public BaseFrameworkElement()
        {
            Layers = new ManagerLayerDrawingVisualList();
            BackgroundLayers = new ManagerLayerDrawingVisualList();
            Visibility = System.Windows.Visibility.Visible;
            _layers = new VisualCollection(this);
            Children = new List<BaseDrawingVisual>();
            MouseDown += BaseFrameworkElement_MouseDown;
            MouseUp += BaseFrameworkElement_MouseUp;
        }

        ~BaseFrameworkElement()
        {
        }

        public virtual void Dispose()
        {
            if (_layers != null)
            {
                foreach (ManagerLayerDrawingVisual l_ManagerLayerDrawingVisual in _layers)
                {
                    l_ManagerLayerDrawingVisual.Dispose();
                }
                _layers.Clear();
            }
            SelectedVisual = null;
            if (BackgroundLayers != null)
            {
                BackgroundLayers.Clear();
            }
            BackgroundLayers = null;
            if (Layers != null)
            {
                Layers.Clear();
            }
            Layers = null;
            if (Children != null)
            {
                foreach (BaseDrawingVisual l_BaseDrawingVisual in Children)
                {
                    l_BaseDrawingVisual.Dispose();
                }
                Children.Clear();
            }
            Children = null;
            MouseDown -= BaseFrameworkElement_MouseDown;
            MouseUp -= BaseFrameworkElement_MouseUp;
        }

        public abstract void SetBounds();

        public abstract void Draw();

        public virtual void UpdateGUI()
        {
            if (FinishedContruction == true)
            {
                if (_layers.Count != BackgroundLayers.Count + Layers.Count)
                {
                    _layers.Clear();
                    foreach (ManagerLayerDrawingVisual l_ManagerLayerDrawingVisual in BackgroundLayers)
                    {
                        _layers.Add(l_ManagerLayerDrawingVisual);
                    }
                    foreach (ManagerLayerDrawingVisual l_ManagerLayerDrawingVisual in Layers)
                    {
                        _layers.Add(l_ManagerLayerDrawingVisual);
                    }
                }
                InvalidateVisual();
            }
        }

        protected override int VisualChildrenCount
        {
            get { return _layers.Count; }
        }

        protected override Visual GetVisualChild(int index)
        {
            if (index < 0 || index >= _layers.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            return _layers[index];
        }

        private void BaseFrameworkElement_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                if (e.ClickCount == 1)
                {
                    System.Windows.Point l_HitPoint = e.GetPosition(this);
                    HitTestResult l_HitTestResult = VisualTreeHelper.HitTest(this, l_HitPoint);
                    BaseDrawingVisual l_BaseDrawingVisual = l_HitTestResult.VisualHit as BaseDrawingVisual;
                    SelectedVisual = l_BaseDrawingVisual;
                    VisualSelected(SelectedVisual, System.Windows.Forms.Control.MousePosition);
                }
                else if (e.ClickCount == 2)
				{
					System.Windows.Point l_HitPoint = e.GetPosition(this);
					HitTestResult l_HitTestResult = VisualTreeHelper.HitTest(this, l_HitPoint);
					BaseDrawingVisual l_BaseDrawingVisual = l_HitTestResult.VisualHit as BaseDrawingVisual;
					SelectedVisual = l_BaseDrawingVisual;
                    VisualDoubleClicked(SelectedVisual, System.Windows.Forms.Control.MousePosition);
                }
            }
            else if (e.RightButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                if (e.ClickCount == 1)
                {
                    System.Windows.Point l_HitPoint = e.GetPosition(this);
                    HitTestResult l_HitTestResult = VisualTreeHelper.HitTest(this, l_HitPoint);
                    BaseDrawingVisual l_BaseDrawingVisual = l_HitTestResult.VisualHit as BaseDrawingVisual;
                    SelectedVisual = l_BaseDrawingVisual;
                    VisualSelected(SelectedVisual, System.Windows.Forms.Control.MousePosition);
                }
            }
        }

        private void BaseFrameworkElement_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Released)
            {
                if (e.ClickCount == 1)
                {
                    VisualClicked(SelectedVisual, System.Windows.Forms.Control.MousePosition);
                }
            }
        }

        protected virtual void VisualSelected(BaseDrawingVisual p_ClickedVisual, System.Drawing.Point p_ClickPosition)
		{
        }

        protected virtual void VisualClicked(BaseDrawingVisual p_ClickedVisual, System.Drawing.Point p_ClickPosition)
        {
        }

        protected virtual void VisualDoubleClicked(BaseDrawingVisual p_ClickedVisual, System.Drawing.Point p_ClickPosition)
        {
        }
    }
}

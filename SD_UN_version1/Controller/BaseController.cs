using SD_UN_version1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
namespace SD_UN_version1.Controller
{
    public class BaseController
    {
        public virtual void SelectElement(GraphicElement el) { }
        public virtual void SelectOnlyElement(GraphicElement el) { }
        public virtual void SetAnchorCursor(GraphicElement el) { }
        public virtual void DragSelectedElements(Point delta) { }
        public virtual void DeselectCurrentSelectedElements() { }
        public virtual void DeselectGroupedElements() { }
        public virtual void DeselectElement(GraphicElement el) { }
        protected List<GraphicElement> elements;
        protected List<GraphicElement> selectedElements;
        public ReadOnlyCollection<GraphicElement> SelectedElements { get { return selectedElements.AsReadOnly(); } }
        protected Canvas canvas;
        public BaseController(Canvas canvas)
        {
            this.canvas = canvas;
            elements = new List<GraphicElement>();
            selectedElements = new List<GraphicElement>();
        }
        public bool IsRootShapeSelectable(Point p)
        {
            return elements.Any(e => e.IsSelectable(p) && e.Parent == null);
        }

        public bool IsChildShapeSelectable(Point p)
        {
            return elements.Any(e => e.IsSelectable(p) && e.Parent != null);
        }

        public GraphicElement GetRootShapeAt(Point p)
        {
            return elements.FirstOrDefault(e => e.IsSelectable(p) && e.Parent == null);
        }

        public GraphicElement GetChildShapeAt(Point p)
        {
            return elements.FirstOrDefault(e => e.IsSelectable(p) && e.Parent != null);
        }
        public virtual bool IsMultiSelect()
        {
            return !((System.Windows.Forms.Control.ModifierKeys & (Keys.Control | Keys.Shift)) == 0);
        }
        public void AddElement(GraphicElement el)
        {
            elements.Add(el);
        }
        public void AddElements(List<GraphicElement> els)
        {
            elements.AddRange(els);
        }

    }
}

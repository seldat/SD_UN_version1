using DevExpress.Mvvm.Native;
using SD_UN_version1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SD_UN_version1.Controller
{
    public class CanvasController:BaseController
    {
        public CanvasController(Canvas canvas):base(canvas)
        {

        }
        public override void DragSelectedElements(Point delta)
        {
            MoveSelectedElements(delta);
        }
        public void MoveSelectedElements(Point delta)
        {
            // TODO: We shouldn't even be calling this method if there are no selected elements!
           if (selectedElements.Count == 0) return;
            double dx = delta.X;
            double dy = delta.Y;
            List<GraphicElement> intersections = new List<GraphicElement>();
            IEnumerable<GraphicElement> distinctIntersections = intersections.Distinct();
            List<GraphicElement> connectors = new List<GraphicElement>();
            Console.WriteLine(delta.ToString());
            elements.ForEach(el =>
            {
                 el.Move(delta);
                 el.UpdatePath();
            });
        }
        public void SelectElement(GraphicElement el)
        {
            selectedElements.Add(el);
        }
        public override void DeselectGroupedElements()
        {
            List<GraphicElement> elementsToRemove = new List<GraphicElement>();
            selectedElements.Where(el => el.Parent != null).ForEach(el =>
            {
                el.Deselect();
                elementsToRemove.Add(el);
            });
            elementsToRemove.ForEach(el => selectedElements.Remove(el));
        }
    }
}

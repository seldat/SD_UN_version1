using SD_UN_version1.Model.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using static SD_UN_version1.Model.Shapes.ShapeAnchor;

namespace SD_UN_version1.Model
{
    public class GraphicElement
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public System.Drawing.Font TextFont { get; set; }
        public Color TextColor { get; set; }
        public ContentAlignment TextAlign { get; set; }
        public BorderShape DisplayRectangle { get; set; }
        // TODO: Text location - left, top, right, middle, bottom

        protected bool HasCornerAnchors { get; set; }
        protected bool HasCenterAnchors { get; set; }
        protected bool HasLeftRightAnchors { get; set; }
        protected bool HasTopBottomAnchors { get; set; }

        protected bool HasCornerConnections { get; set; }
        protected bool HasCenterConnections { get; set; }
        protected bool HasLeftRightConnections { get; set; }
        protected bool HasTopBottomConnections { get; set; }

        protected Bitmap background;
        protected System.Windows.Shapes.Rectangle backgroundRectangle;
        protected Pen selectionPen;
        protected Pen altSelectionPen;
        protected Pen tagPen;
        protected Pen altTagPen;
        protected Pen anchorPen = new Pen(Color.Black);
        protected Pen connectionPointPen = new Pen(Color.Blue);
        protected SolidBrush anchorBrush = new SolidBrush(Color.Black);
        protected int anchorWidthHeight = 6;        // TODO: Make const?
        public Canvas canvas;

        protected bool disposed;
        protected bool removed;
        public GraphicElement(Canvas canvas)
        {
            this.canvas = canvas;
            HasCenterAnchors = true;
            HasCornerAnchors = true;
            HasLeftRightAnchors = false;
            HasTopBottomAnchors = false;
            HasCenterConnections = true;
            HasCornerConnections = true;
            HasLeftRightConnections = false;
            HasTopBottomConnections = false;
        }
        public virtual List<ShapeAnchor> GetAnchors()
        {
            List<ShapeAnchor> anchors = new List<ShapeAnchor>();
            AnchorBox r;
            int anchorSize = 6;
            if (HasCornerAnchors)
            {
                r =new AnchorBox(DisplayRectangle.TopLeft(), anchorSize);
                anchors.Add(new ShapeAnchor(GripType.TopLeft, r, Cursors.SizeNWSE));
                r = new AnchorBox(DisplayRectangle.TopRight(), anchorSize);
                anchors.Add(new ShapeAnchor(GripType.TopRight, r, Cursors.SizeNESW));
                r = new AnchorBox(DisplayRectangle.BottomLeft(), anchorSize);
                anchors.Add(new ShapeAnchor(GripType.BottomLeft, r, Cursors.SizeNESW));
                r = new AnchorBox(DisplayRectangle.BottomRight(), anchorSize);
                anchors.Add(new ShapeAnchor(GripType.BottomRight, r, Cursors.SizeNWSE));
            }

            if (HasCenterAnchors || HasLeftRightAnchors)
            {
              /*  r = ExtensionMethod.AnchorBox(DisplayRectangle.LeftMiddle(), anchorSize);
                anchors.Add(new ShapeAnchor(GripType.LeftMiddle, r, Cursors.SizeWE));
                r = ExtensionMethod.AnchorBox(DisplayRectangle.RightMiddle(), anchorSize);
                anchors.Add(new ShapeAnchor(GripType.RightMiddle, r, Cursors.SizeWE));*/
            }

            if (HasCenterAnchors || HasTopBottomAnchors)
            {
               /* r = ExtensionMethod.AnchorBox(DisplayRectangle.TopMiddle(), anchorSize);
                anchors.Add(new ShapeAnchor(GripType.TopMiddle, r, Cursors.SizeNS));
                r = ExtensionMethod.AnchorBox(DisplayRectangle.BottomMiddle(), anchorSize);
                anchors.Add(new ShapeAnchor(GripType.BottomMiddle, r, Cursors.SizeNS));*/
            }

            return anchors;
        }
        public virtual void DrawAnchors()
        {
            GetAnchors().ForEach((a =>
            {
                a.anchorBox.Move();
                Draw(a.anchorBox.rectangle);
            }));
        }
        protected virtual void RemoveAnchors()
        {
            GetAnchors().ForEach((a =>
            {
                Remove(a.anchorBox.rectangle);
            }));
        }
        protected virtual void Remove(UIElement element)
        {
            this.canvas.Children.Remove(element);
        }
        protected virtual void Draw(UIElement element)
        {
            this.canvas.Children.Add(element);
        }
        public virtual void UpdateProperties()
        {

        }
        public virtual void Draw()
        {

        }

        public virtual System.Windows.Point GetLocation()
        {
            return new System.Windows.Point(Canvas.GetLeft(DisplayRectangle),Canvas.GetTop(DisplayRectangle));
        }

    }
}

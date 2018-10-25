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
using System.Windows.Media;
using System.Windows.Shapes;
using static SD_UN_version1.Model.Shapes.ShapeAnchor;

namespace SD_UN_version1.Model
{
    public class GraphicElement
    {
        public string Name { get; set; }
        public string Text { get; set; }
        //public System.Drawing.Font TextFont { get; set; }
       // public Color TextColor { get; set; }
        //public ContentAlignment TextAlign { get; set; }
        public BorderShape DisplayRectangle { get; set; }
        // TODO: Text location - left, top, right, middle, bottom
        public virtual bool Selected { get; protected set; }
        protected bool HasCornerAnchors { get; set; }
        protected bool HasCenterAnchors { get; set; }
        protected bool HasLeftRightAnchors { get; set; }
        protected bool HasTopBottomAnchors { get; set; }

        protected bool HasCornerConnections { get; set; }
        protected bool HasCenterConnections { get; set; }
        protected bool HasLeftRightConnections { get; set; }
        protected bool HasTopBottomConnections { get; set; }
        public bool isSelected { get; set; }
        public GraphicElement Parent { get; set; }
        protected SolidColorBrush selectionPen;
        /* protected Bitmap background;
         protected System.Windows.Shapes.Rectangle backgroundRectangle;
         protected Pen selectionPen;
         protected Pen altSelectionPen;
         protected Pen tagPen;
         protected Pen altTagPen;
         protected Pen anchorPen = new Pen(Color.Black);
         protected Pen connectionPointPen = new Pen(Color.Blue);
         protected SolidBrush anchorBrush = new SolidBrush(Color.Black);*/
        protected int anchorWidthHeight = 6;        // TODO: Make const?
        public Canvas canvas;

        protected bool disposed;
        protected bool removed;
        public virtual void UpdatePath() { }
        public virtual void UpdateProperties() { }
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
            selectionPen = new SolidColorBrush(Colors.Red);
        }
        public virtual List<ShapeAnchor> GetAnchors()
        {
            // draw anchors 
            List<ShapeAnchor> anchors = new List<ShapeAnchor>();
            AnchorBox r;
            int anchorSize = 6;
            if (HasCornerAnchors) // tai cac canh
            {
                Point newPoint = new Point();
                newPoint = DisplayRectangle.TopLeft();
                r =new AnchorBox(DisplayRectangle.TopLeft(), anchorSize);
                anchors.Add(new ShapeAnchor(GripType.TopLeft, r, Cursors.SizeNWSE));
                newPoint = DisplayRectangle.TopRight();
                newPoint.Offset(-anchorWidthHeight, 0);
                r = new AnchorBox(newPoint, anchorSize);
                anchors.Add(new ShapeAnchor(GripType.TopRight, r, Cursors.SizeNESW));
                newPoint = DisplayRectangle.BottomLeft();
                newPoint.Offset(0, -anchorWidthHeight);
                r = new AnchorBox(newPoint, anchorSize);
                anchors.Add(new ShapeAnchor(GripType.BottomLeft, r, Cursors.SizeNESW));
                newPoint = DisplayRectangle.BottomRight();
                newPoint.Offset(-anchorWidthHeight, -anchorWidthHeight);
                r = new AnchorBox(newPoint, anchorSize);
                anchors.Add(new ShapeAnchor(GripType.BottomRight, r, Cursors.SizeNWSE));
            }

            if (HasCenterAnchors || HasLeftRightAnchors) // tai trai va phai
            {
                Point newPoint = DisplayRectangle.LeftMiddle();
                newPoint.Offset(0, -anchorWidthHeight / 2);
                r = new AnchorBox(newPoint, anchorSize);
                anchors.Add(new ShapeAnchor(GripType.LeftMiddle, r, Cursors.SizeWE));
                newPoint = DisplayRectangle.RightMiddle();
                newPoint.Offset(0, -anchorWidthHeight / 2);
                r = new AnchorBox(newPoint, anchorSize);
                anchors.Add(new ShapeAnchor(GripType.RightMiddle, r, Cursors.SizeWE));
            }

            if (HasCenterAnchors || HasTopBottomAnchors) // tai vi tri tren va duoi
            {
                Point newPoint = new Point();
                newPoint = DisplayRectangle.TopMiddle();
                newPoint.Offset(-anchorWidthHeight / 2, 0);
                r = new AnchorBox(newPoint, anchorSize);
                anchors.Add(new ShapeAnchor(GripType.TopMiddle, r, Cursors.SizeNS));
                newPoint = DisplayRectangle.BottomMiddle();
                newPoint.Offset(-anchorWidthHeight / 2, -anchorWidthHeight);
                r = new AnchorBox(newPoint, anchorSize);
                anchors.Add(new ShapeAnchor(GripType.BottomMiddle, r, Cursors.SizeNS));
            }

            return anchors;
        }
        public virtual void Select()
        {
            Selected = true;
        }

        public virtual void Deselect()
        {
            Selected = false;
        }
        public virtual bool IsSelectable(Point p)
        {
            return DisplayRectangle.Contain(p);
        }
        public virtual BorderShape DefaultRectangle()
        {
            return new BorderShape(20, 20, 60, 60);
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
        public virtual void Draw()
        {
             DrawSelection();
            
        }


        public virtual void Move(Point delta)
        {
            DisplayRectangle.Move(delta);
        }
        protected virtual void DrawSelection()
        {
            if (!isSelected)
            {
                DisplayRectangle.BorderBrush = new SolidColorBrush(Colors.Black);
            }
            else
            {
                DisplayRectangle.BorderBrush = selectionPen;
            }
        }
        public virtual System.Windows.Point GetLocation()
        {
            return new System.Windows.Point(Canvas.GetLeft(DisplayRectangle),Canvas.GetTop(DisplayRectangle));
        }

    }
}

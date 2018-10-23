using SD_UN_version1.Connectors;
using SD_UN_version1.Model.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using static SD_UN_version1.Model.Shapes.ShapeAnchor;

namespace SD_UN_version1.Model.Connectors
{
    class DiagonalConnector:DynamicConnector
    {
        Line diagonalLine = new Line();
        public DiagonalConnector(Canvas canvas):base(canvas)
        {
            Initialize();
            canvas.Children.Add(diagonalLine);
        }
        public DiagonalConnector(Canvas canvas, Point start, Point end) : base(canvas)
        {
            StartPoint = start;
            EndPoint = end;
            DisplayRectangle = RecalcDisplayRectangle();
            Initialize();
            canvas.Children.Add(diagonalLine);
        }
        public void Initialize()
        {

        }
        public override List<ShapeAnchor> GetAnchors()
        {
            List<ShapeAnchor> anchors = new List<ShapeAnchor>();
            AnchorBox r;
            Point newPoint = new Point();
            newPoint = StartPoint;
            newPoint.Offset(-anchorWidthHeight / 2, -anchorWidthHeight / 2);
            r = new AnchorBox(newPoint, anchorWidthHeight);
            anchors.Add(new ShapeAnchor(GripType.Start, r, Cursors.Arrow));
            newPoint = EndPoint;
            newPoint.Offset(-anchorWidthHeight / 2, -anchorWidthHeight / 2);
            r = new AnchorBox(newPoint, anchorWidthHeight);
            anchors.Add(new ShapeAnchor(GripType.End, r, Cursors.Arrow));
            return anchors;
        }
        public override void Draw()
        {
            if (ShowConnectorAsSelected)
            {
                diagonalLine.Stroke = new SolidColorBrush(Colors.Red);
            }
            else
            {
                diagonalLine.Stroke = new SolidColorBrush(Colors.Black);
            }
            diagonalLine.X1 = StartPoint.X;
            diagonalLine.Y1 = StartPoint.Y;
            diagonalLine.X2 = EndPoint.X;
            diagonalLine.Y2 = EndPoint.Y;
            base.Draw();
        }
    }
}

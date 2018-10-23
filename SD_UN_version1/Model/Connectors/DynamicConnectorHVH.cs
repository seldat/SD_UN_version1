using SD_UN_version1.Connectors;
using SD_UN_version1.Model.Shapes;
using SD_UN_version1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static SD_UN_version1.Model.Shapes.ShapeAnchor;

namespace SD_UN_version1.Model.Connectors
{
    class DynamicConnectorHVH : DynamicConnector
    {
        public DynamicConnectorHVH(Canvas canvas):base(canvas)
        {

        }
        public DynamicConnectorHVH(Canvas canvas, Point start, Point end) : base(canvas)
        {
            Initialize();
            StartPoint = start;
            EndPoint = end;
            DisplayRectangle = RecalcDisplayRectangle();
        }
        public void Initialize()
        {
            lines.Add(new HorizontalLine(canvas));
            lines.Add(new VerticalLine(canvas));
            lines.Add(new HorizontalLine(canvas));
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
        public override void UpdatePath()
        {
            UpdateCaps();

            if (StartPoint.X < EndPoint.X)
            {
                lines[0].DisplayRectangle = new BorderShape(StartPoint.X, StartPoint.Y - Constants.MIN_HEIGHT / 2, (EndPoint.X - StartPoint.X) / 2, Constants.MIN_HEIGHT);
            }
            else
            {
                lines[0].DisplayRectangle = new BorderShape(EndPoint.X + (StartPoint.X - EndPoint.X) / 2, StartPoint.Y - Constants.MIN_HEIGHT / 2, (StartPoint.X - EndPoint.X) / 2, Constants.MIN_HEIGHT);
            }

            if (StartPoint.Y < EndPoint.Y)
            {
                lines[1].DisplayRectangle = new BorderShape(StartPoint.X + (EndPoint.X - StartPoint.X) / 2 - Constants.MIN_WIDTH / 2, StartPoint.Y, Constants.MIN_WIDTH, EndPoint.Y - StartPoint.Y);
            }
            else
            {
                lines[1].DisplayRectangle = new BorderShape(EndPoint.X + (StartPoint.X - EndPoint.X) / 2 - Constants.MIN_WIDTH / 2, EndPoint.Y, Constants.MIN_WIDTH, StartPoint.Y - EndPoint.Y);
            }

            if (StartPoint.X < EndPoint.X)
            {
                lines[2].DisplayRectangle = new BorderShape(StartPoint.X + (EndPoint.X - StartPoint.X) / 2, EndPoint.Y - Constants.MIN_HEIGHT / 2, (EndPoint.X - StartPoint.X) / 2, Constants.MIN_HEIGHT);
            }
            else
            {
                lines[2].DisplayRectangle = new BorderShape(EndPoint.X, EndPoint.Y - Constants.MIN_HEIGHT / 2, (StartPoint.X - EndPoint.X) / 2, Constants.MIN_HEIGHT);
            }

            lines.ForEach(l => l.UpdatePath());
        }
        protected void UpdateCaps()
        {
            if (StartPoint.X < EndPoint.X)
            {
                lines[0].EndCap = AvailableLineCap.None;
                lines[2].StartCap = AvailableLineCap.None;
                lines[0].StartCap = StartCap;
                lines[2].EndCap = EndCap;
            }
            else
            {
                lines[0].StartCap = AvailableLineCap.None;
                lines[2].EndCap = AvailableLineCap.None;
                lines[0].EndCap = StartCap;
                lines[2].StartCap = EndCap;
            }
            lines.ForEach(l => l.UpdateProperties());
        }
    }
}

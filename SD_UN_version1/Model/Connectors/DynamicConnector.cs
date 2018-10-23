using SD_UN_version1.Connectors;
using SD_UN_version1.Model.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SD_UN_version1.Model.Connectors
{
    public abstract class DynamicConnector:Connector
    {
        protected List<LineShape> lines = new List<LineShape>();
        protected Point StartPoint { get; set; }
        protected Point EndPoint { get; set; }
        public DynamicConnector(Canvas canvas):base(canvas)
        {
            HasCornerAnchors = false;
            HasCenterAnchors = false;
            HasTopBottomAnchors = false;
            HasLeftRightAnchors = false;
        }
        public override void Draw()
        {
            lines.ForEach(l => l.Draw());
        }
        protected BorderShape RecalcDisplayRectangle()
        {
            double x1 = Math.Min(StartPoint.X,EndPoint.X);
            double y1 = Math.Min(StartPoint.Y,EndPoint.Y);
            double x2 = Math.Max(StartPoint.X,EndPoint.X);
            double y2 = Math.Max(StartPoint.Y,EndPoint.Y);
            return new BorderShape(x1, y1, x2 - x1, y2 - y1);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SD_UN_version1.Model.Shapes
{
    class VerticalLine : LineShape
    {
        Line verticalLine = new Line();
        public VerticalLine(Canvas canvas):base(canvas)
        {
            HasCornerAnchors = false;
            HasCenterAnchors = false;
            HasTopBottomAnchors = true;
            HasCornerConnections = false;
            HasCenterConnections = false;
            HasTopBottomConnections = true;
            canvas.Children.Add(verticalLine);
        }
        public override void Draw()
        {
            if (ShowConnectorAsSelected)
            {
                verticalLine.Stroke = new SolidColorBrush(Colors.Red);
            }
            else
            {
                verticalLine.Stroke = new SolidColorBrush(Colors.Black);
            }
            verticalLine.X1 = DisplayRectangle.TopMiddle().X;
            verticalLine.Y1 = DisplayRectangle.TopMiddle().Y;
            verticalLine.X2 = DisplayRectangle.BottomMiddle().X;
            verticalLine.Y2 = DisplayRectangle.BottomMiddle().Y;
            base.Draw();
        }
    }
}

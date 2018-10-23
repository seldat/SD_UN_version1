using SD_UN_version1.Connectors;
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
    class HorizontalLine:LineShape
    {
        Line horizontalLine = new Line();
        public HorizontalLine(Canvas canvas):base(canvas)
        {
            HasCornerAnchors = false;
            HasCenterAnchors = false;
            HasLeftRightAnchors = true;
            HasCornerConnections = false;
            HasCenterConnections = false;
            HasLeftRightConnections = true;
            canvas.Children.Add(horizontalLine);
        }
        public override void Draw()
        {
            if(ShowConnectorAsSelected)
            {
                horizontalLine.Stroke = new SolidColorBrush(Colors.Red);
            }
            else
            {
                horizontalLine.Stroke = new SolidColorBrush(Colors.Black);
            }
            horizontalLine.X1 = DisplayRectangle.LeftMiddle().X;
            horizontalLine.Y1 = DisplayRectangle.LeftMiddle().Y;
            horizontalLine.X2 = DisplayRectangle.RightMiddle().X;
            horizontalLine.Y2 = DisplayRectangle.RightMiddle().Y;
            base.Draw();
        }
    }
}

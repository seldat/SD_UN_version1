using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SD_UN_version1.Model.Shapes
{
    public class AnchorBox
    {
        public Rectangle rectangle{ get; protected set; }
        public Point location { get; set; }
        public AnchorBox(Point location, int anchorSize)
        {
            this.location=location;
            rectangle = new Rectangle();
            rectangle.Width = anchorSize;
            rectangle.Height = anchorSize;
            rectangle.Fill = new SolidColorBrush(Colors.Black);

        }
        public virtual void Move()
        {
            Canvas.SetLeft(rectangle, location.X);
            Canvas.SetTop(rectangle, location.Y);
        }
    }
}

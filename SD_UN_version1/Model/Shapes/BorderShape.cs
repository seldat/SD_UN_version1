using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SD_UN_version1.Model.Shapes
{
    public class BorderShape:Border
    {
        public const int BOX_SIZE_ANCHOR = 3;
        public Point location { get; set; }
        public int size { get; set; }
        public Canvas canvas;
        public BorderShape(Point location) {
            this.Width = 50;
            this.Height = 50;
            Canvas.SetLeft(this,location.X);
            Canvas.SetTop(this, location.Y);
            this.Background = new SolidColorBrush(Colors.Red);
            this.location = location;
            this.BorderThickness = new Thickness(1);
            this.BorderBrush = new SolidColorBrush(Colors.Black);
            
        }
        public BorderShape(Point location,double w, double h)
        {
            this.Width = w;
            this.Height = h;
            Canvas.SetLeft(this, location.X);
            Canvas.SetTop(this, location.Y);
            this.Background = new SolidColorBrush(Colors.Red);
            this.location = location;
            this.BorderThickness = new Thickness(1);
            this.BorderBrush = new SolidColorBrush(Colors.Black);
        }
        public BorderShape(double x,double y, double w, double h)
        {
            this.Width = w;
            this.Height = h;
            Canvas.SetLeft(this, x);
            Canvas.SetTop(this, y);
            this.Background = new SolidColorBrush(Colors.Red);
            this.location= new Point(x,y);
            this.BorderThickness = new Thickness(1);
            this.BorderBrush = new SolidColorBrush(Colors.Black);

        }
        public void Move(Point p)
        {
            Canvas.SetLeft(this, p.X);
            Canvas.SetTop(this, p.Y);
            location = p;
        }
        public Point TopLeft()
        {
            
            return new Point(location.X, location.Y);
        }
        public Point TopRight()
        {
            return new Point(location.X + this.Width, location.Y);
        }
        public Point TopMiddle()
        {
            return new Point(location.X + this.Width / 2 , location.Y);
        }
        public Point LeftMiddle()
        {
            return new Point(location.X, location.Y + this.Height / 2 );
        }

        public Point RightMiddle()
        {
            return new Point(location.X + this.Width , location.Y+ this.Height / 2);
        }
        public Point BottomLeft()
        {
            return new Point(location.X, location.Y + this.Height);
        }
        public Point BottomRight()
        {
            return new Point(location.X + this.Width, location.X + this.Height);
        }
        public Point BottomMiddle()
        {
            return new Point(location.X + this.Width / 2 , location.Y + this.Height);
        }
        public bool Contain(Point pInside)
        {
            Point[] pointCollection = new Point[4] { TopLeft(),TopRight(),BottomRight(),BottomLeft() };
            return ExtensionMethod.IsInPolygon(pointCollection, pInside);
        }
    }
}

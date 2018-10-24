using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;

namespace SD_UN_version1.Model.Shapes
{
    public class ShapeAnchor
    {
        public const int PROXIMITY = 6;
        public enum GripType
        {
            None,
            TopLeft,
            TopRight,
            BottomLeft,
            BottomRight,
            LeftMiddle,
            RightMiddle,
            TopMiddle,
            BottomMiddle,

            // for lines:
            Start,
            End,
        };
        public GripType Type { get; protected set; }
        public AnchorBox anchorBox { get; protected set; }
        public Cursor Cursor { get; protected set; }
        public ShapeAnchor(GripType type, AnchorBox abx, Cursor cursor)
        {
            this.Type = type;
            this.anchorBox = abx;
            this.Cursor = cursor;
        }
        public bool Near(Point p)
        {
            double cx = anchorBox.location.X + anchorBox.rectangle.Width / 2;
            double cy = anchorBox.location.Y + anchorBox.rectangle.Height / 2;

            return Math.Abs(p.X - cx) <= PROXIMITY && Math.Abs(p.Y - cy) <= PROXIMITY;
        }
    }
}

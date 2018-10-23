using SD_UN_version1.Connectors;
using SD_UN_version1.Model.ShapeProperties;
using SD_UN_version1.Model.Shapes;
using SD_UN_version1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace SD_UN_version1.Model
{
   public abstract class LineShape: Connector
    {
        protected CappedLine cappedLine = new CappedLine();
        public LineShape(Canvas canvas):base(canvas)
        {
        }

       public ElementProperties CreateProperties()
        {
            return new LineProperties(this);
        }

        public override void UpdateProperties()
        {
            
            if (StartCap == AvailableLineCap.None)
            {
                cappedLine.BeginCap = Geometry.Parse(Constants.ANCHOR_NONE);
            }
            else
            {
                cappedLine.BeginCap = StartCap == AvailableLineCap.Arrow ? Geometry.Parse(Constants.ANCHOR_ARROW) : Geometry.Parse(Constants.ANCHOR_SQUARE);
            }

            if (EndCap == AvailableLineCap.None)
            {
                cappedLine.EndCap = Geometry.Parse(Constants.ANCHOR_NONE);
            }
            else
            {
                cappedLine.EndCap = EndCap == AvailableLineCap.Arrow ? Geometry.Parse(Constants.ANCHOR_ARROW) : Geometry.Parse(Constants.ANCHOR_SQUARE);
            }

            base.UpdateProperties();
        }
    }
}

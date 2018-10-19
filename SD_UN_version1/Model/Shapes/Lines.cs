using SD_UN_version1.Connectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SD_UN_version1.Model
{
   public abstract class Lines:Connector
    {
        public Lines(Canvas canvas):base(canvas)
        {
        }

       /* public override ElementProperties CreateProperties()
        {
            return new LineProperties(this);
        }*/

        public override void UpdateProperties()
        {
            
            /*if (StartCap == AvailableLineCap.None)
            {
                BorderPen.StartCap = LineCap.NoAnchor;
            }
            else
            {
                BorderPen.CustomStartCap = StartCap == AvailableLineCap.Arrow ? adjCapArrow : adjCapDiamond;
            }

            if (EndCap == AvailableLineCap.None)
            {
                BorderPen.EndCap = LineCap.NoAnchor;
            }
            else
            {
                BorderPen.CustomEndCap = EndCap == AvailableLineCap.Arrow ? adjCapArrow : adjCapDiamond;
            }*/

            //  base.UpdateProperties();
        }
    }
}

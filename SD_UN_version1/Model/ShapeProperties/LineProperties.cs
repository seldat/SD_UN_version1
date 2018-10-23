using SD_UN_version1.Connectors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD_UN_version1.Model.ShapeProperties
{
   public class LineProperties:ElementProperties
    {
        [Category("Endcaps")]
        public AvailableLineCap StartCap { get; set; }
        [Category("Endcaps")]
        public AvailableLineCap EndCap { get; set; }

        public LineProperties(LineShape el) : base(el)
        {
            StartCap = el.StartCap;
            EndCap = el.EndCap;
        }

        public override void Update(GraphicElement el, string label)
        {
            // X1
            //(label == nameof(StartCap)).If(() => this.ChangePropertyWithUndoRedo<AvailableLineCap>(el, nameof(StartCap), nameof(StartCap)));
            //(label == nameof(EndCap)).If(() => this.ChangePropertyWithUndoRedo<AvailableLineCap>(el, nameof(EndCap), nameof(EndCap)));
            if (label == nameof(StartCap)) { ((Connector)el).StartCap = StartCap; };
            if (label == nameof(EndCap)) { ((Connector)el).EndCap = EndCap; } ;
            base.Update(el, label);
        }
    }
}

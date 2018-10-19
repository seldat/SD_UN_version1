using SD_UN_version1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SD_UN_version1.Connectors
{
    public enum AvailableLineCap
    {
        None,
        Arrow,
        Diamond,
    }
    public  abstract class Connector:GraphicElement
    {
        public AvailableLineCap StartCap { get; set; }
        public AvailableLineCap EndCap { get; set; }
        public Connector(Canvas canvas):base(canvas)
        {

        }
    
       /* public override void Serialize()
        {

        }

        public override void Deserialize()
        {

        }

        public override void FinalFixup()
        {

        }

        public override void SetConnection()
        {

        }

        public override void RemoveConnection(GripType gt)
        {

        }

        public void DisconnectShapeFromConnector(GripType gt)
        {
     // Else
        }

        public void DetachAll()
        {

        }*/
    }
}

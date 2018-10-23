using SD_UN_version1.InterfaceServices;
using SD_UN_version1.Model.Shapes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SD_UN_version1.Model.ShapeProperties
{
    public abstract class ElementProperties:IPropertyObject
    {
        GraphicElement element;
        [Category("Element")]
        public string Name { get; set; }
        [Category("Element")]
        public string ShapeName { get { return element?.GetType().Name; } }
        [Category("Element")]
        public BorderShape borderShape{ get; set; }

        [Category("Border")]
        public Color BorderColor { get; set; }
        public int BorderWidth { get; set; }

        [Category("Fill")]
        public Color FillColor { get; set; }

        public ElementProperties(GraphicElement el)
        {
            this.element = el;
            borderShape = el.DisplayRectangle;
            Name = el.Name;
        }
        public virtual void UpdateFrom(GraphicElement el)
        {
            // The only property that can change.
            borderShape = el.DisplayRectangle;
        }

        public virtual void Update(GraphicElement el, string label)
        {
            // X1
            //(label == nameof(Rectangle)).If(() => this.ChangePropertyWithUndoRedo<Rectangle>(el, nameof(el.DisplayRectangle), nameof(Rectangle)));
            //(label == nameof(BorderColor)).If(() => this.ChangePropertyWithUndoRedo<Color>(el, nameof(el.BorderPenColor), nameof(BorderColor)));
            //(label == nameof(BorderWidth)).If(() => this.ChangePropertyWithUndoRedo<int>(el, nameof(el.BorderPenWidth), nameof(BorderWidth)));
            //(label == nameof(FillColor)).If(() => this.ChangePropertyWithUndoRedo<Color>(el, nameof(el.FillColor), nameof(FillColor)));
            if (label == nameof(borderShape)) { el.DisplayRectangle = borderShape; };
            if(label == nameof(Name)){ el.Name = Name; };
        }

        public virtual void Update(string label) { }

    }
}

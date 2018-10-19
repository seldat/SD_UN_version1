using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SD_UN_version1.MouseControllerService
{
    class MouseController
    {
        public class MouseRouter
        {
            public MouseController.RouteName RouteName { get; set; }
            public MouseController.MouseEvent MouseEvent { get; set; }
            public Func<bool> Condition { get; set; }
            public Action<MouseEventArgs> Action { get; set; }
            public Action Else { get; set; }
            public Action Debug { get; set; }
        }

        public enum MouseEvent
        {
            MouseDown,
            MouseUp,
            MouseMove,
            MouseDoubleClick,
        }
        public enum RouteName
        {
            FireMouseClickEvent,
            CanvasFocus,
            StartDragSurface,
            EndDragSurface,
            EndDragSurfaceWithDeselect,
            DragSurface,
            StartDragSelectionBox,
            EndDragSelectionBox,
            DragSelectionBox,
            StartShapeDrag,
            EndShapeDrag,
            StartAnchorDrag,
            EndAnchorDrag,
            DragShapes,
            DragAnchor,
            HoverOverShape,
            ShowAnchors,
            ShowAnchorCursor,
            ClearAnchorCursor,
            HideAnchors,
            SelectSingleShapeMouseUp,
            SelectSingleShapeMouseDown,
            SelectSingleGroupedShape,
            AddSelectedShape,
            RemoveSelectedShape,
            EditShapeText,
        }
        protected Point LastMousePosition { get; set; }
        protected Point CurrentMousePosition { get; set; }
      //  protected MouseButtons CurrentButtons { get; set; }
        protected bool DraggingSurface { get; set; }
        protected bool DraggingShapes { get; set; }
        protected bool DraggingAnchor { get; set; }
        protected bool DraggingOccurred { get; set; }
        protected bool DraggingSurfaceOccurred { get; set; }
        protected bool SelectingShapes { get; set; }
      //  protected GraphicElement HoverShape { get; set; }
      //  protected ShapeAnchor SelectedAnchor { get; set; }
      //  protected GraphicElement SelectionBox { get; set; }
        protected bool DraggingSelectionBox { get; set; }
        protected Point StartSelectionPosition { get; set; }
        public virtual void InitializeBehavior()
        {
        }
        protected virtual void DragCanvas()
        {
        }
        protected void ShowAnchors()
        {
        }
        protected void ChangeAnchors()
        {
        }
        protected void HideAnchors()
        {
        }
        protected void DragSelectionBox()
        {

        }
    }
}

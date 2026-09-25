using System;
using System.Drawing;
using System.Windows.Forms;

namespace UtilityLib.Controls.Rendering
{
    // Recolors a native child window the control does not own (up-down arrows)
    // NativeWindow releases the handle by itself on WM_NCDESTROY
    internal class NativeRecolorWindow : NativeWindow
    {
        private readonly Func<NativeRecolor.Recolorer> _recolor;
        private Bitmap _lastFrame;

        public NativeRecolorWindow(nint handle, Func<NativeRecolor.Recolorer> recolor)
        {
            _recolor = recolor;
            AssignHandle(handle);
        }

        protected override void OnHandleChange()
        {
            base.OnHandleChange();
            if (Handle == nint.Zero)
            {
                _lastFrame?.Dispose();
                _lastFrame = null;
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == NativeRecolor.WM_PAINT)
            {
                NativeRecolor.Paint(Handle, msg => DefWndProc(ref msg), _recolor(), ref _lastFrame);
                return;
            }
            base.WndProc(ref m);
        }
    }
}

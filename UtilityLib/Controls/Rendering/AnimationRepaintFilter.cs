using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace UtilityLib.Controls.Rendering
{
    // Animations (calendar month change) are driven by timer callbacks that paint straight
    // to the screen and never reach WndProc. Run the callback here, then repaint right away
    // so the light frame is replaced before it is shown.
    internal class AnimationRepaintFilter : IMessageFilter
    {
        private const int WM_TIMER = 0x113;
        private const uint RDW_INVALIDATE = 0x1;
        private const uint RDW_UPDATENOW = 0x100;

        private readonly Func<nint> _handle;

        public AnimationRepaintFilter(Func<nint> handle)
        {
            _handle = handle;
        }

        public bool PreFilterMessage(ref Message m)
        {
            nint handle = _handle();
            if (m.Msg != WM_TIMER || handle == nint.Zero || m.HWnd != handle)
                return false;

            MSG msg = new MSG { hwnd = m.HWnd, message = m.Msg, wParam = m.WParam, lParam = m.LParam };
            DispatchMessage(ref msg);
            if (IsWindow(handle))
                RedrawWindow(handle, nint.Zero, nint.Zero, RDW_INVALIDATE | RDW_UPDATENOW);
            return true;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MSG
        {
            public nint hwnd;
            public int message;
            public nint wParam;
            public nint lParam;
            public int time;
            public int ptX;
            public int ptY;
        }

        [DllImport("user32.dll")]
        private static extern nint DispatchMessage(ref MSG msg);

        [DllImport("user32.dll")]
        private static extern bool IsWindow(nint hWnd);

        [DllImport("user32.dll")]
        private static extern bool RedrawWindow(nint hWnd, nint lprcUpdate, nint hrgnUpdate, uint flags);
    }
}

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.ComponentModel;

namespace UtilityLib.Controls
{
    // DateTimePicker ignores BackColor and, with visual styles, the Calendar* colors too.
    // The field, the up-down arrows and the drop down calendar are recolored after native painting.
    public class DarkDateTimePicker : DateTimePicker
    {
        private Color _borderColor = CustomColors.BORDER_COLOR;
        private Color _calendarBackColor = Color.Black;
        private NativeRecolorWindow _upDown;
        private NativeRecolorWindow _calendar;
        private Bitmap _lastFrame;
        private NativeFillWindow _popup;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; Invalidate(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color CalendarBackColor
        {
            get { return _calendarBackColor; }
            set { _calendarBackColor = value; }
        }

        public DarkDateTimePicker()
        {
            try
            {
                Font = new Font("Arial", 8, FontStyle.Regular);
            }
            catch
            {
                Font = SystemFonts.DefaultFont;
            }
            BackColor = Color.Black;
            ForeColor = Color.WhiteSmoke;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            // Changing ShowUpDown recreates the handle, so this covers it
            nint upDown = GetPickerInfo().hwndUD;
            _upDown = upDown == nint.Zero ? null
                : new NativeRecolorWindow(upDown, () => NativeRecolor.Grayscale(BackColor, ForeColor));
        }

        protected override void OnDropDown(EventArgs eventargs)
        {
            base.OnDropDown(eventargs);
            nint calendar = SendMessage(Handle, DTM_GETMONTHCAL, nint.Zero, nint.Zero);
            if (calendar == nint.Zero)
                return;

            _calendar = new NativeRecolorWindow(calendar, () => NativeRecolor.InvertKeepingAccents(_calendarBackColor, ForeColor));

            nint popup = GetPickerInfo().hwndDropDown;
            if (popup != nint.Zero)
                _popup = new NativeFillWindow(popup, _borderColor);
        }

        protected override void OnCloseUp(EventArgs eventargs)
        {
            _calendar = null;
            _popup = null;
            base.OnCloseUp(eventargs);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _lastFrame?.Dispose();
                _lastFrame = null;
            }
            base.Dispose(disposing);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == NativeRecolor.WM_PAINT)
            {
                NativeRecolor.Paint(Handle, msg => DefWndProc(ref msg), RecolorField, ref _lastFrame, PaintBorder);
                return;
            }
            base.WndProc(ref m);
        }

        private void RecolorField(byte[] pixels, int stride, int width, int height)
        {
            Color fore = Enabled ? ForeColor : DarkTheme.DISABLED_TEXT_COLOR;
            Rectangle keep = FindSelectionHighlight(pixels, stride, width, height);
            NativeRecolor.Grayscale(BackColor, fore, keep)(pixels, stride, width, height);
        }

        private void PaintBorder(Graphics g, Size size)
        {
            using (Pen p = new Pen(_borderColor))
            {
                g.DrawRectangle(p, 0, 0, size.Width - 1, size.Height - 1);
            }
        }

        // The date part being edited is drawn with the highlight color; leave it as is.
        // Edges and the drop down button are skipped, they use the same color when focused or hovered.
        private Rectangle FindSelectionHighlight(byte[] pixels, int stride, int width, int height)
        {
            Color highlight = SystemColors.Highlight;
            int right = width - 2;
            RECT button = GetPickerInfo().rcButton;
            if (button.Left > 0)
                right = Math.Min(right, button.Left);

            int minX = int.MaxValue, minY = int.MaxValue, maxX = -1, maxY = -1;
            for (int y = 2; y < height - 2; y++)
            {
                for (int x = 2; x < right; x++)
                {
                    int i = y * stride + x * 4;
                    if (Math.Abs(pixels[i] - highlight.B) < 8
                        && Math.Abs(pixels[i + 1] - highlight.G) < 8
                        && Math.Abs(pixels[i + 2] - highlight.R) < 8)
                    {
                        minX = Math.Min(minX, x);
                        maxX = Math.Max(maxX, x);
                        minY = Math.Min(minY, y);
                        maxY = Math.Max(maxY, y);
                    }
                }
            }
            return maxX < 0 ? Rectangle.Empty : Rectangle.FromLTRB(minX, minY, maxX + 1, maxY + 1);
        }

        private DATETIMEPICKERINFO GetPickerInfo()
        {
            DATETIMEPICKERINFO info = new DATETIMEPICKERINFO { cbSize = Marshal.SizeOf(typeof(DATETIMEPICKERINFO)) };
            SendMessage(Handle, DTM_GETDATETIMEPICKERINFO, nint.Zero, ref info);
            return info;
        }

        private const int DTM_GETMONTHCAL = 0x1008;
        private const int DTM_GETDATETIMEPICKERINFO = 0x100E;

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left, Top, Right, Bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct DATETIMEPICKERINFO
        {
            public int cbSize;
            public RECT rcCheck;
            public int stateCheck;
            public RECT rcButton;
            public int stateButton;
            public nint hwndEdit;
            public nint hwndUD;
            public nint hwndDropDown;
        }

        [DllImport("user32.dll")]
        private static extern nint SendMessage(nint hWnd, int msg, nint wParam, nint lParam);

        [DllImport("user32.dll")]
        private static extern nint SendMessage(nint hWnd, int msg, nint wParam, ref DATETIMEPICKERINFO lParam);
    }
}

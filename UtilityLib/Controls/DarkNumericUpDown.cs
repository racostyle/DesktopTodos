using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using UtilityLib.Controls.Theming;
using System.ComponentModel;

namespace UtilityLib.Controls
{
    // The text part takes BackColor, but the up-down buttons and the border are drawn
    // with light system colors, so both are painted over
    public class DarkNumericUpDown : NumericUpDown
    {
        private enum ButtonPart { None, Up, Down }

        private Color _borderColor = CustomColors.BORDER_COLOR;
        private Color _buttonColor = Color.Black;
        private Color _buttonHoverColor = CustomColors.TEXT_BOX_COLOR;
        private Color _buttonPressedColor = Color.FromArgb(70, 70, 70);
        private readonly Control _buttons;
        private readonly MessageWatcher _buttonsWatcher;
        private ButtonPart _hover = ButtonPart.None;
        private ButtonPart _pressed = ButtonPart.None;


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; Invalidate(); _buttons?.Invalidate(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color ButtonColor
        {
            get { return _buttonColor; }
            set { _buttonColor = value; _buttons?.Invalidate(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color ButtonHoverColor
        {
            get { return _buttonHoverColor; }
            set { _buttonHoverColor = value; _buttons?.Invalidate(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color ButtonPressedColor
        {
            get { return _buttonPressedColor; }
            set { _buttonPressedColor = value; _buttons?.Invalidate(); }
        }

        public DarkNumericUpDown()
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
            BorderStyle = BorderStyle.FixedSingle;

            // Controls[0] is the internal UpDownButtons control. It handles the mouse without
            // raising the mouse events, so hover and press are read from its messages.
            _buttons = Controls[0];
            _buttons.Paint += (s, e) => PaintButtons(e.Graphics);
            _buttonsWatcher = new MessageWatcher(OnButtonsMessage);
            _buttons.HandleCreated += (s, e) => _buttonsWatcher.AssignHandle(_buttons.Handle);
            _buttons.HandleDestroyed += (s, e) => _buttonsWatcher.ReleaseHandle();
        }

        private void OnButtonsMessage(Message m)
        {
            switch (m.Msg)
            {
                case WM_MOUSEMOVE:
                    RequestMouseLeave(m.HWnd);
                    SetState(PartAt(m.LParam), _pressed);
                    break;
                case WM_MOUSELEAVE:
                    SetState(ButtonPart.None, _pressed);
                    break;
                case WM_LBUTTONDOWN:
                case WM_LBUTTONDBLCLK:
                    SetState(PartAt(m.LParam), PartAt(m.LParam));
                    break;
                case WM_LBUTTONUP:
                case WM_CAPTURECHANGED:
                    Point cursor = _buttons.PointToClient(Cursor.Position);
                    ButtonPart hover = _buttons.ClientRectangle.Contains(cursor)
                        ? cursor.Y < _buttons.ClientSize.Height / 2 ? ButtonPart.Up : ButtonPart.Down
                        : ButtonPart.None;
                    if (hover != ButtonPart.None)
                        RequestMouseLeave(m.HWnd);
                    SetState(hover, ButtonPart.None);
                    break;
            }
        }

        // Mouse capture during a press cancels the WM_MOUSELEAVE request, so it is renewed here
        private static void RequestMouseLeave(nint hwnd)
        {
            TRACKMOUSEEVENT track = new TRACKMOUSEEVENT
            {
                cbSize = Marshal.SizeOf(typeof(TRACKMOUSEEVENT)),
                dwFlags = TME_LEAVE,
                hwndTrack = hwnd
            };
            TrackMouseEvent(ref track);
        }

        private ButtonPart PartAt(nint lParam)
        {
            int y = (short)((int)lParam.ToInt64() >> 16 & 0xFFFF);
            return y < _buttons.ClientSize.Height / 2 ? ButtonPart.Up : ButtonPart.Down;
        }

        private void SetState(ButtonPart hover, ButtonPart pressed)
        {
            if (_hover != hover || _pressed != pressed)
            {
                _hover = hover;
                _pressed = pressed;
                _buttons.Invalidate();
            }
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            _buttons.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (SolidBrush background = new SolidBrush(BackColor))
            using (Region around = new Region(ClientRectangle))
            {
                // The gap between the border and the text box is left light
                around.Exclude(Controls[1].Bounds);
                around.Exclude(_buttons.Bounds);
                e.Graphics.FillRegion(background, around);
            }
            using (Pen p = new Pen(_borderColor))
            {
                e.Graphics.DrawRectangle(p, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
            }
        }

        private void PaintButtons(Graphics g)
        {
            int width = _buttons.ClientSize.Width;
            int height = _buttons.ClientSize.Height;
            int half = height / 2;
            Rectangle up = new Rectangle(0, 0, width, half);
            Rectangle down = new Rectangle(0, half, width, height - half);

            PaintButton(g, up, ButtonPart.Up);
            PaintButton(g, down, ButtonPart.Down);

            using (Pen p = new Pen(_borderColor))
            {
                g.DrawLine(p, 0, 0, 0, height);
                g.DrawLine(p, 0, half, width, half);
            }
        }

        private void PaintButton(Graphics g, Rectangle bounds, ButtonPart part)
        {
            Color fill = !Enabled ? _buttonColor
                : _pressed == part ? _buttonPressedColor
                : _hover == part ? _buttonHoverColor
                : _buttonColor;
            using (SolidBrush brush = new SolidBrush(fill))
            {
                g.FillRectangle(brush, bounds);
            }

            int cx = bounds.Left + bounds.Width / 2;
            int cy = bounds.Top + bounds.Height / 2;
            int size = Math.Max(2, Math.Min(bounds.Width / 4, bounds.Height / 2 - 1));
            Point[] arrow = part == ButtonPart.Up
                ? new[] { new Point(cx - size, cy + size / 2), new Point(cx + size + 1, cy + size / 2), new Point(cx, cy - size / 2 - 1) }
                : new[] { new Point(cx - size, cy - size / 2), new Point(cx + size + 1, cy - size / 2), new Point(cx, cy + size / 2 + 1) };
            using (SolidBrush brush = new SolidBrush(Enabled ? ForeColor : DarkTheme.DISABLED_TEXT_COLOR))
            {
                g.FillPolygon(brush, arrow);
            }
        }

        // Sees a control's messages after the control has handled them
        private class MessageWatcher : NativeWindow
        {
            private readonly Action<Message> _onMessage;

            public MessageWatcher(Action<Message> onMessage)
            {
                _onMessage = onMessage;
            }

            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);
                _onMessage(m);
            }
        }

        private const int WM_MOUSEMOVE = 0x200;
        private const int WM_LBUTTONDOWN = 0x201;
        private const int WM_LBUTTONUP = 0x202;
        private const int WM_LBUTTONDBLCLK = 0x203;
        private const int WM_CAPTURECHANGED = 0x215;
        private const int WM_MOUSELEAVE = 0x2A3;
        private const int TME_LEAVE = 0x2;

        [StructLayout(LayoutKind.Sequential)]
        private struct TRACKMOUSEEVENT
        {
            public int cbSize;
            public int dwFlags;
            public nint hwndTrack;
            public int dwHoverTime;
        }

        [DllImport("user32.dll")]
        private static extern bool TrackMouseEvent(ref TRACKMOUSEEVENT lpEventTrack);
    }
}

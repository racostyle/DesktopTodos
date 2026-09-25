using System.ComponentModel;
using UtilityLib.Controls.Theming;

namespace UtilityLib.Controls
{
    public class DarkComboBox : ComboBox
    {
        private Color _borderColor = CustomColors.BORDER_COLOR;
        private nint _disabledEditBrush = nint.Zero;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; Invalidate(); }
        }

        public DarkComboBox()
        {
            try
            {
                Font = new Font("Arial", 8, FontStyle.Regular);
            }
            catch
            {
                Font = SystemFonts.DefaultFont;
            }
            FlatStyle = FlatStyle.Flat;
            BackColor = Color.Black;
            ForeColor = Color.WhiteSmoke;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            DarkTheme.Apply(Handle, DarkTheme.COMBO_BOX);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            int thickness = 1;
            int halfThickness = thickness / 2;
            using (Pen p = new Pen(_borderColor, thickness))
            {
                e.Graphics.DrawRectangle(p, new Rectangle(halfThickness, halfThickness,
                    ClientSize.Width - thickness - 1, ClientSize.Height - thickness - 1));
            }
        }

        private Rectangle DropDownButtonRect
        {
            get
            {
                int width = SystemInformation.HorizontalScrollBarArrowWidth + 2;
                return new Rectangle(ClientSize.Width - width, 0, width, ClientSize.Height);
            }
        }

        // Flat ComboBox draws its button and disabled state with light system colors
        private void PaintDropDownButton(Graphics g)
        {
            Rectangle button = DropDownButtonRect;
            using (SolidBrush brush = new SolidBrush(BackColor))
            {
                g.FillRectangle(brush, button);
            }
            using (Pen p = new Pen(_borderColor))
            {
                g.DrawLine(p, button.Left, button.Top, button.Left, button.Bottom);
            }

            int cx = button.Left + button.Width / 2;
            int cy = button.Top + button.Height / 2;
            Point[] arrow =
            {
                new Point(cx - 3, cy - 1),
                new Point(cx + 4, cy - 1),
                new Point(cx, cy + 3)
            };
            using (SolidBrush brush = new SolidBrush(Enabled ? ForeColor : DarkTheme.DISABLED_TEXT_COLOR))
            {
                g.FillPolygon(brush, arrow);
            }
        }

        private void PaintDisabled(Graphics g)
        {
            using (SolidBrush brush = new SolidBrush(BackColor))
            {
                g.FillRectangle(brush, ClientRectangle);
            }
            Rectangle textRect = new Rectangle(3, 0, ClientSize.Width - DropDownButtonRect.Width - 3, ClientSize.Height);
            TextRenderer.DrawText(g, Text, Font, textRect, DarkTheme.DISABLED_TEXT_COLOR,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.EndEllipsis);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            // Selected text stays highlighted in the disabled edit box
            if (!Enabled && DropDownStyle != ComboBoxStyle.DropDownList)
                SelectionLength = 0;
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            ReleaseDisabledEditBrush();
        }

        private void ReleaseDisabledEditBrush()
        {
            if (_disabledEditBrush != nint.Zero)
            {
                DarkTheme.DeleteObject(_disabledEditBrush);
                _disabledEditBrush = nint.Zero;
            }
        }

        protected override void Dispose(bool disposing)
        {
            ReleaseDisabledEditBrush();
            base.Dispose(disposing);
        }

        protected override void WndProc(ref Message m)
        {
            // The disabled edit box asks for its colors with WM_CTLCOLORSTATIC,
            // which WinForms leaves to Windows (light gray)
            const int WM_CTLCOLORSTATIC = 0x138;
            if (m.Msg == WM_CTLCOLORSTATIC)
            {
                if (_disabledEditBrush == nint.Zero)
                    _disabledEditBrush = DarkTheme.CreateSolidBrush(ColorTranslator.ToWin32(BackColor));
                DarkTheme.SetTextColor(m.WParam, ColorTranslator.ToWin32(DarkTheme.DISABLED_TEXT_COLOR));
                DarkTheme.SetBkColor(m.WParam, ColorTranslator.ToWin32(BackColor));
                m.Result = _disabledEditBrush;
                return;
            }

            base.WndProc(ref m);

            // WM_PAINT message
            const int WM_PAINT = 0xF;
            if (m.Msg == WM_PAINT)
            {
                using (Graphics g = Graphics.FromHwnd(Handle))
                {
                    if (!Enabled)
                        PaintDisabled(g);
                    PaintDropDownButton(g);

                    int thickness = 1;
                    using (Pen p = new Pen(_borderColor, thickness))
                    {
                        g.DrawRectangle(p, new Rectangle(0, 0, Width - thickness, Height - thickness));
                    }
                }
            }
        }
    }
}

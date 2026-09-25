using System.ComponentModel;
using UtilityLib.Controls.Theming;

namespace UtilityLib.Controls
{
    public class DarkListView : ListView
    {
        private Color _borderColor = CustomColors.BORDER_COLOR;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; Invalidate(); }
        }

        public DarkListView()
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
            // Owner draw only the column headers, the themed header text is unreadable
            OwnerDraw = true;
        }

        protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(CustomColors.PANEL_COLOR))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }
            using (Pen p = new Pen(_borderColor))
            {
                e.Graphics.DrawLine(p, e.Bounds.Right - 1, e.Bounds.Top, e.Bounds.Right - 1, e.Bounds.Bottom);
            }

            Rectangle textRect = new Rectangle(e.Bounds.X + 4, e.Bounds.Y, e.Bounds.Width - 8, e.Bounds.Height);
            TextFormatFlags flags = TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.EndEllipsis;
            if (e.Header.TextAlign == HorizontalAlignment.Center)
                flags |= TextFormatFlags.HorizontalCenter;
            else if (e.Header.TextAlign == HorizontalAlignment.Right)
                flags |= TextFormatFlags.Right;
            TextRenderer.DrawText(e.Graphics, e.Header.Text, Font, textRect, ForeColor, flags);
        }

        protected override void OnDrawItem(DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
            base.OnDrawItem(e);
        }

        protected override void OnDrawSubItem(DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
            base.OnDrawSubItem(e);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            DarkTheme.Apply(Handle, DarkTheme.EXPLORER);

            const int LVM_GETHEADER = 0x101F;
            nint header = DarkTheme.SendMessage(Handle, LVM_GETHEADER, nint.Zero, nint.Zero);
            if (header != nint.Zero)
                DarkTheme.Apply(header, DarkTheme.ITEMS_VIEW);
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

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            // WM_PAINT message
            const int WM_PAINT = 0xF;
            if (m.Msg == WM_PAINT)
            {
                using (Graphics g = Graphics.FromHwnd(Handle))
                {
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

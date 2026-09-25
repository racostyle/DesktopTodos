using System.ComponentModel;
using UtilityLib.Controls.Theming;

namespace UtilityLib.Controls
{
    public class DarkRichTextBox : RichTextBox
    {
        private Color _borderColor = CustomColors.BORDER_COLOR;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; Invalidate(); }
        }

        public DarkRichTextBox()
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
            BorderStyle = BorderStyle.None;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            DarkTheme.Apply(Handle, DarkTheme.EXPLORER);
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
            try
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
            catch { }
        }
    }
}

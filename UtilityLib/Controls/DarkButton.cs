using System.ComponentModel;

namespace UtilityLib.Controls
{
    public class DarkButton : Button
    {
        private Color borderColor = CustomColors.BORDER_COLOR;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; Invalidate(); }
        }

        public DarkButton()
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
            FlatAppearance.BorderSize = 0;
            TextAlign = ContentAlignment.MiddleCenter;
            ForeColor = Color.WhiteSmoke;
            BackColor = Color.Black;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            if (!Enabled)
            {
                // Default disabled text is nearly black on a dark background
                using (SolidBrush brush = new SolidBrush(BackColor))
                {
                    pevent.Graphics.FillRectangle(brush, ClientRectangle);
                }
                TextRenderer.DrawText(pevent.Graphics, Text, Font, ClientRectangle, DarkTheme.DISABLED_TEXT_COLOR,
                    DarkTheme.ToTextFormat(TextAlign));
            }
            int thickness = 2;
            int halfThickness = thickness / 2;
            using (Pen p = new Pen(borderColor, thickness))
            {
                pevent.Graphics.DrawRectangle(p, new Rectangle(halfThickness, halfThickness,
                    ClientSize.Width - thickness, ClientSize.Height - thickness));
            }
        }
    }
}

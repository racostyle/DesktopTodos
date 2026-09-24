namespace UtilityLib.Controls
{
    public class DarkLabel : Label
    {
        public DarkLabel()
        {
            try
            {
                Font = new Font("Arial", 8, FontStyle.Regular);
            }
            catch
            {
                Font = SystemFonts.DefaultFont;
            }

            TextAlign = ContentAlignment.MiddleLeft;
            ForeColor = Color.WhiteSmoke;
            BackColor = CustomColors.BACKGROUND_COLOR;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Enabled)
            {
                base.OnPaint(e);
                return;
            }
            // Default disabled text is nearly black on a dark background
            TextFormatFlags flags = DarkTheme.ToTextFormat(TextAlign);
            if (AutoEllipsis)
                flags |= TextFormatFlags.EndEllipsis;
            TextRenderer.DrawText(e.Graphics, Text, Font, ClientRectangle, DarkTheme.DISABLED_TEXT_COLOR, flags);
        }
    }
}

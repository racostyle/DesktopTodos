using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace UtilityLib.Controls
{
    public class DarkCheckBox : CheckBox
    {
        private Color _boxBorderColor = Color.Gray;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color BoxBorderColor
        {
            get { return _boxBorderColor; }
            set { _boxBorderColor = value; Invalidate(); }
        }

        public DarkCheckBox()
        {
            // Native check box draws a white box and near black disabled text
            SetStyle(ControlStyles.UserPaint
                | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw, true);

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
            Graphics g = e.Graphics;
            using (SolidBrush background = new SolidBrush(BackColor))
            {
                g.FillRectangle(background, ClientRectangle);
            }

            int boxSize = LogicalToDeviceUnits(13);
            Rectangle box = new Rectangle(0, (ClientSize.Height - boxSize) / 2, boxSize - 1, boxSize - 1);
            Color markColor = Enabled ? ForeColor : DarkTheme.DISABLED_TEXT_COLOR;

            using (SolidBrush boxBrush = new SolidBrush(Color.Black))
            {
                g.FillRectangle(boxBrush, box);
            }
            using (Pen borderPen = new Pen(Enabled ? _boxBorderColor : CustomColors.BORDER_COLOR))
            {
                g.DrawRectangle(borderPen, box);
            }

            if (CheckState == CheckState.Checked)
            {
                SmoothingMode oldMode = g.SmoothingMode;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen markPen = new Pen(markColor, LogicalToDeviceUnits(2)))
                {
                    g.DrawLines(markPen, new[]
                    {
                        new PointF(box.Left + box.Width * 0.22f, box.Top + box.Height * 0.52f),
                        new PointF(box.Left + box.Width * 0.42f, box.Top + box.Height * 0.72f),
                        new PointF(box.Left + box.Width * 0.78f, box.Top + box.Height * 0.30f)
                    });
                }
                g.SmoothingMode = oldMode;
            }
            else if (CheckState == CheckState.Indeterminate)
            {
                Rectangle inner = box;
                inner.Inflate(-3, -3);
                using (SolidBrush markBrush = new SolidBrush(markColor))
                {
                    g.FillRectangle(markBrush, inner.X, inner.Y, inner.Width + 1, inner.Height + 1);
                }
            }

            int textLeft = box.Right + LogicalToDeviceUnits(4);
            Rectangle textRect = new Rectangle(textLeft, 0, ClientSize.Width - textLeft, ClientSize.Height);
            TextRenderer.DrawText(g, Text, Font, textRect,
                Enabled ? ForeColor : DarkTheme.DISABLED_TEXT_COLOR,
                DarkTheme.ToTextFormat(TextAlign));

            if (Focused && ShowFocusCues)
                ControlPaint.DrawFocusRectangle(g, textRect, ForeColor, BackColor);
        }
    }
}

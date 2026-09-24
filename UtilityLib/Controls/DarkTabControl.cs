using System.ComponentModel;

namespace UtilityLib.Controls
{
    public class DarkTabControl : TabControl
    {
        private Color _backgroundColor = CustomColors.BACKGROUND_COLOR;
        private Color _borderColor = CustomColors.BORDER_COLOR;
        private Color _selectedTabColor = CustomColors.BACKGROUND_COLOR;
        private Color _tabColor = CustomColors.PANEL_COLOR;
        private Color _hoverTabColor = CustomColors.TEXT_BOX_COLOR;
        private Color _inactiveTextColor = Color.Gray;
        private int _hoverIndex = -1;

        // TabControl ignores BackColor, so the strip behind the tabs uses this instead
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

        // TabControl ignores BackColor, so the strip behind the tabs uses this instead
        public Color BackgroundColor
        {
            get { return _backgroundColor; }
            set { _backgroundColor = value; Invalidate(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; Invalidate(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color SelectedTabColor
        {
            get { return _selectedTabColor; }
            set { _selectedTabColor = value; Invalidate(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color TabColor
        {
            get { return _tabColor; }
            set { _tabColor = value; Invalidate(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color HoverTabColor
        {
            get { return _hoverTabColor; }
            set { _hoverTabColor = value; Invalidate(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color InactiveTextColor
        {
            get { return _inactiveTextColor; }
            set { _inactiveTextColor = value; Invalidate(); }
        }

        public DarkTabControl()
        {
            // Paint everything ourselves, otherwise the native control draws
            // a light 3D border and an unpaintable strip next to the tabs
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
            ForeColor = Color.WhiteSmoke;
            Padding = new Point(10, 4);
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            // Designer sets page properties after adding them, so re-apply here
            foreach (TabPage page in TabPages)
                ApplyPageStyle(page);
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            if (e.Control is TabPage page)
                ApplyPageStyle(page);
        }

        private void ApplyPageStyle(TabPage page)
        {
            page.UseVisualStyleBackColor = false;
            page.BackColor = _selectedTabColor;
            page.ForeColor = ForeColor;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            using (SolidBrush background = new SolidBrush(_backgroundColor))
            {
                g.FillRectangle(background, ClientRectangle);
            }

            // Page area border
            Rectangle pageRect = DisplayRectangle;
            pageRect.Inflate(1, 1);
            using (Pen borderPen = new Pen(_borderColor))
            {
                g.DrawRectangle(borderPen, pageRect);
            }

            for (int i = 0; i < TabCount; i++)
            {
                if (i != SelectedIndex)
                    DrawTab(g, i);
            }
            // Selected tab last so it overlaps the page border
            if (SelectedIndex >= 0)
                DrawTab(g, SelectedIndex);
        }

        private void DrawTab(Graphics g, int index)
        {
            Rectangle tabRect = GetTabRect(index);
            bool selected = index == SelectedIndex;

            Color fill = selected ? _selectedTabColor
                : index == _hoverIndex ? _hoverTabColor
                : _tabColor;

            if (selected)
            {
                // Enlarge the selected tab so it merges with the page area
                tabRect.Inflate(1, 1);
                if (Alignment == TabAlignment.Top)
                    tabRect.Height += 1;
                else if (Alignment == TabAlignment.Bottom)
                    tabRect.Y -= 1;
            }

            using (SolidBrush brush = new SolidBrush(fill))
            {
                g.FillRectangle(brush, tabRect);
            }

            using (Pen borderPen = new Pen(_borderColor))
            {
                if (selected && Alignment == TabAlignment.Top)
                {
                    // Leave the bottom edge open so the tab joins the page
                    g.DrawLine(borderPen, tabRect.Left, tabRect.Bottom, tabRect.Left, tabRect.Top);
                    g.DrawLine(borderPen, tabRect.Left, tabRect.Top, tabRect.Right - 1, tabRect.Top);
                    g.DrawLine(borderPen, tabRect.Right - 1, tabRect.Top, tabRect.Right - 1, tabRect.Bottom);
                }
                else
                {
                    g.DrawRectangle(borderPen, tabRect.X, tabRect.Y, tabRect.Width - 1, tabRect.Height - 1);
                }
            }

            TextRenderer.DrawText(g, TabPages[index].Text, Font, tabRect,
                selected ? ForeColor : _inactiveTextColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                | TextFormatFlags.SingleLine | TextFormatFlags.EndEllipsis);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            int index = -1;
            for (int i = 0; i < TabCount; i++)
            {
                if (GetTabRect(i).Contains(e.Location))
                {
                    index = i;
                    break;
                }
            }
            if (index != _hoverIndex)
            {
                _hoverIndex = index;
                Invalidate();
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (_hoverIndex != -1)
            {
                _hoverIndex = -1;
                Invalidate();
            }
        }
    }
}

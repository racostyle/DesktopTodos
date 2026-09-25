using System.ComponentModel;
using System.Globalization;
using System.Runtime.InteropServices;
using UtilityLib.Controls.Rendering;
using UtilityLib.Controls.Theming;

namespace UtilityLib.Controls
{
    // DateTimePicker ignores BackColor, so the field and the up-down arrows are recolored after
    // native painting. The native drop down can only pick a date and cannot host other controls,
    // so it is replaced by a popup with a DarkMonthCalendar and a time picker.
    public class DarkDateTimePicker : DateTimePicker
    {
        private Color _borderColor = CustomColors.BORDER_COLOR;
        private Color _calendarBackColor = Color.Black;
        private bool _showTimeInDropDown = true;
        private string _dropDownTimeFormat = "HH:mm";
        private NativeRecolorWindow _upDown;
        private Bitmap _lastFrame;
        private DropDownPopup _dropDown;
        private int _dropDownClosedAt;

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

        // Adds a time picker under the calendar in the drop down
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowTimeInDropDown
        {
            get { return _showTimeInDropDown; }
            set { _showTimeInDropDown = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DropDownTimeFormat
        {
            get { return _dropDownTimeFormat; }
            set { _dropDownTimeFormat = value; }
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

            DateTimeFormatInfo formats = CultureInfo.CurrentCulture.DateTimeFormat;
            Format = DateTimePickerFormat.Custom;
            CustomFormat = formats.ShortDatePattern + " " + formats.ShortTimePattern;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            // Changing ShowUpDown recreates the handle, so this covers it
            nint upDown = GetPickerInfo().hwndUD;
            _upDown = upDown == nint.Zero ? null
                : new NativeRecolorWindow(upDown, () => NativeRecolor.Grayscale(BackColor, ForeColor));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dropDown?.Close();
                _lastFrame?.Dispose();
                _lastFrame = null;
            }
            base.Dispose(disposing);
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case NativeRecolor.WM_PAINT:
                    NativeRecolor.Paint(Handle, msg => DefWndProc(ref msg), RecolorField, ref _lastFrame, PaintBorder);
                    return;

                case WM_LBUTTONDOWN:
                case WM_LBUTTONDBLCLK:
                    if (!ShowUpDown && IsOnDropDownButton(m.LParam))
                    {
                        Focus();
                        ShowDropDown();
                        return;
                    }
                    break;

                case WM_KEYDOWN:
                    if ((int)m.WParam == VK_F4 && !ShowUpDown)
                    {
                        ShowDropDown();
                        return;
                    }
                    break;

                case WM_SYSKEYDOWN:
                    if (((int)m.WParam == VK_DOWN || (int)m.WParam == VK_UP) && !ShowUpDown)
                    {
                        ShowDropDown();
                        return;
                    }
                    break;
            }
            base.WndProc(ref m);
        }

        private bool IsOnDropDownButton(nint lParam)
        {
            int packed = (int)lParam.ToInt64();
            Point point = new Point((short)(packed & 0xFFFF), (short)(packed >> 16 & 0xFFFF));
            RECT button = GetPickerInfo().rcButton;
            return Rectangle.FromLTRB(button.Left, button.Top, button.Right, button.Bottom).Contains(point);
        }

        private void ShowDropDown()
        {
            // The click that closed the popup (on the button) must not open it again
            if (_dropDown != null || !Enabled || unchecked(Environment.TickCount - _dropDownClosedAt) < 250)
                return;

            DateTime originalValue = Value;
            bool originalChecked = Checked;
            int gap = LogicalToDeviceUnits(6);

            DarkMonthCalendar calendar = new DarkMonthCalendar
            {
                MaxSelectionCount = 1,
                MinDate = MinDate,
                MaxDate = MaxDate,
                Font = CalendarFont,
                BackColor = _calendarBackColor,
                ForeColor = ForeColor,
                Location = Point.Empty
            };
            calendar.SetDate(Value.Date);

            Panel panel = new Panel { BackColor = _calendarBackColor, Margin = Padding.Empty };
            panel.Controls.Add(calendar);
            // The calendar gets its real size once it has a handle
            panel.CreateControl();
            panel.Size = calendar.Size;

            DropDownPopup popup = new DropDownPopup(_calendarBackColor, _borderColor);

            calendar.DateChanged += (s, e) => SetPickedValue(e.Start.Date + Value.TimeOfDay);
            if (_showTimeInDropDown)
            {
                AddTimeRow(panel, calendar, gap, popup);
            }
            else
            {
                // Without a time to set, picking a day is the last step
                calendar.DateSelected += (s, e) => popup.Close(ToolStripDropDownCloseReason.ItemClicked);
            }

            ToolStripControlHost host = new ToolStripControlHost(panel)
            {
                AutoSize = false,
                Size = panel.Size,
                Margin = Padding.Empty,
                Padding = Padding.Empty
            };
            popup.Items.Add(host);
            popup.Content = panel;
            popup.Closed += (s, e) =>
            {
                if (popup.Cancelled)
                {
                    Value = originalValue;
                    Checked = originalChecked;
                }
                _dropDown = null;
                _dropDownClosedAt = Environment.TickCount;
                BeginInvoke(popup.Dispose);
                OnCloseUp(EventArgs.Empty);
            };

            _dropDown = popup;
            OnDropDown(EventArgs.Empty);
            popup.Show(this, new Point(0, Height));
            calendar.Focus();
        }

        private void AddTimeRow(Panel panel, MonthCalendar calendar, int gap, DropDownPopup popup)
        {
            DarkDateTimePicker timePicker = new DarkDateTimePicker
            {
                Format = DateTimePickerFormat.Custom,
                CustomFormat = _dropDownTimeFormat,
                ShowUpDown = true,
                Value = Value,
                BackColor = BackColor,
                ForeColor = ForeColor,
                BorderColor = _borderColor
            };
            int textWidth = TextRenderer.MeasureText(new DateTime(2000, 12, 28, 22, 58, 58).ToString(_dropDownTimeFormat), timePicker.Font).Width;
            timePicker.Width = textWidth + SystemInformation.VerticalScrollBarWidth + LogicalToDeviceUnits(12);
            int rowTop = calendar.Bottom + gap;
            int rowHeight = timePicker.Height;

            DarkLabel label = new DarkLabel
            {
                Text = "Time",
                AutoSize = true,
                BackColor = _calendarBackColor,
                ForeColor = ForeColor
            };
            label.Location = new Point(gap, rowTop + (rowHeight - label.PreferredHeight) / 2);
            timePicker.Location = new Point(label.Left + label.PreferredWidth + gap, rowTop);

            DarkButton okButton = new DarkButton
            {
                Text = "OK",
                Size = new Size(LogicalToDeviceUnits(50), rowHeight),
                BorderColor = _borderColor
            };
            okButton.Location = new Point(calendar.Width - gap - okButton.Width, rowTop);

            timePicker.ValueChanged += (s, e) => SetPickedValue(Value.Date + timePicker.Value.TimeOfDay);
            okButton.Click += (s, e) => popup.Close(ToolStripDropDownCloseReason.ItemClicked);

            panel.Controls.Add(label);
            panel.Controls.Add(timePicker);
            panel.Controls.Add(okButton);
            panel.Height = rowTop + rowHeight + gap;
        }

        private void SetPickedValue(DateTime value)
        {
            if (value < MinDate)
                value = MinDate;
            if (value > MaxDate)
                value = MaxDate;
            Value = value;
            if (ShowCheckBox)
                Checked = true;
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

        private class DropDownPopup : ToolStripDropDown
        {
            // Closed with Escape: the picked value is reverted
            public bool Cancelled { get; private set; }

            // Set once the content exists; Tab moves focus inside it
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public Control Content { get; set; }

            public DropDownPopup(Color backColor, Color borderColor)
            {
                Padding = new Padding(1);
                DropShadowEnabled = false;
                Renderer = new DropDownRenderer(backColor, borderColor);
            }

            // ToolStripDropDown uses Tab to move between its items, not between hosted controls
            protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
            {
                if ((keyData & Keys.KeyCode) == Keys.Tab && (keyData & (Keys.Control | Keys.Alt)) == 0 && Content != null)
                {
                    // SelectNextControl does not move focus here, there is no ContainerControl above
                    List<Control> stops = new List<Control>();
                    foreach (Control child in Content.Controls)
                    {
                        if (child.TabStop && child.CanSelect)
                            stops.Add(child);
                    }
                    stops.Sort((a, b) => a.TabIndex.CompareTo(b.TabIndex));
                    if (stops.Count > 0)
                    {
                        int current = stops.FindIndex(c => c.ContainsFocus);
                        int step = (keyData & Keys.Shift) == 0 ? 1 : -1;
                        int next = current < 0 ? 0 : (current + step + stops.Count) % stops.Count;
                        stops[next].Focus();
                    }
                    return true;
                }
                return base.ProcessCmdKey(ref msg, keyData);
            }

            protected override bool ProcessDialogKey(Keys keyData)
            {
                if (keyData == Keys.Escape)
                {
                    Cancelled = true;
                    Close(ToolStripDropDownCloseReason.Keyboard);
                    return true;
                }
                if (keyData == Keys.Enter)
                {
                    Close(ToolStripDropDownCloseReason.Keyboard);
                    return true;
                }
                return base.ProcessDialogKey(keyData);
            }
        }

        private class DropDownRenderer : ToolStripRenderer
        {
            private readonly Color _backColor;
            private readonly Color _borderColor;

            public DropDownRenderer(Color backColor, Color borderColor)
            {
                _backColor = backColor;
                _borderColor = borderColor;
            }

            protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
            {
                using (SolidBrush brush = new SolidBrush(_backColor))
                {
                    e.Graphics.FillRectangle(brush, e.AffectedBounds);
                }
            }

            protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
            {
                using (Pen p = new Pen(_borderColor))
                {
                    e.Graphics.DrawRectangle(p, 0, 0, e.ToolStrip.Width - 1, e.ToolStrip.Height - 1);
                }
            }
        }

        private const int WM_KEYDOWN = 0x100;
        private const int WM_SYSKEYDOWN = 0x104;
        private const int WM_LBUTTONDOWN = 0x201;
        private const int WM_LBUTTONDBLCLK = 0x203;
        private const int VK_F4 = 0x73;
        private const int VK_UP = 0x26;
        private const int VK_DOWN = 0x28;
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
        private static extern nint SendMessage(nint hWnd, int msg, nint wParam, ref DATETIMEPICKERINFO lParam);
    }
}

using UtilityLib.Controls.Rendering;

namespace UtilityLib.Controls
{
    // MonthCalendar ignores its colors while visual styles are on,
    // so it is recolored after native painting (see NativeRecolor)
    public class DarkMonthCalendar : MonthCalendar
    {
        private readonly AnimationRepaintFilter _animationFilter;
        private Bitmap _lastFrame;

        public DarkMonthCalendar()
        {
            BackColor = Color.Black;
            ForeColor = Color.WhiteSmoke;
            _animationFilter = new AnimationRepaintFilter(() => IsHandleCreated ? Handle : nint.Zero);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            Application.AddMessageFilter(_animationFilter);
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            Application.RemoveMessageFilter(_animationFilter);
            base.OnHandleDestroyed(e);
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
                NativeRecolor.Paint(Handle, msg => DefWndProc(ref msg),
                    NativeRecolor.InvertKeepingAccents(BackColor, ForeColor), ref _lastFrame);
                return;
            }
            base.WndProc(ref m);
        }
    }
}

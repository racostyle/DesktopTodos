using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace UtilityLib.Controls.Rendering
{
    // Some native controls (DateTimePicker, MonthCalendar, UpDown) always paint light.
    // These helpers let them paint into a bitmap, recolor it dark and put it on screen.
    internal static class NativeRecolor
    {
        public delegate void Recolorer(byte[] pixels, int stride, int width, int height);

        public const int WM_PAINT = 0xF;
        private const int WM_PRINTCLIENT = 0x318;
        private const int PRF_CLIENT = 0x4;
        private static readonly Color UNPAINTED = Color.FromArgb(255, 3, 251, 7);

        // lastFrame keeps the previous result. While an animation runs, the control paints
        // nothing on WM_PRINTCLIENT, and the previous frame is shown instead of a blank one.
        public static void Paint(nint hwnd, Action<Message> defWndProc, Recolorer recolor, ref Bitmap lastFrame,
            Action<Graphics, Size> overlay = null)
        {
            nint hdc = BeginPaint(hwnd, out PAINTSTRUCT ps);
            try
            {
                GetClientRect(hwnd, out RECT client);
                int width = client.Right - client.Left;
                int height = client.Bottom - client.Top;
                if (width <= 0 || height <= 0)
                    return;

                Bitmap frame = Render(hwnd, defWndProc, recolor, width, height);
                if (frame != null)
                {
                    lastFrame?.Dispose();
                    lastFrame = frame;
                }
                if (lastFrame == null || lastFrame.Width != width || lastFrame.Height != height)
                    return;

                using (Graphics g = Graphics.FromHdc(hdc))
                {
                    g.DrawImageUnscaled(lastFrame, 0, 0);
                    overlay?.Invoke(g, new Size(width, height));
                }
            }
            finally
            {
                EndPaint(hwnd, ref ps);
            }
        }

        // Returns null when the control painted nothing
        private static Bitmap Render(nint hwnd, Action<Message> defWndProc, Recolorer recolor, int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            using (Graphics bitmapGraphics = Graphics.FromImage(bitmap))
            {
                // An unlikely color, if it is still everywhere afterwards nothing was painted
                bitmapGraphics.Clear(UNPAINTED);
                nint bitmapDc = bitmapGraphics.GetHdc();
                defWndProc(Message.Create(hwnd, WM_PRINTCLIENT, bitmapDc, PRF_CLIENT));
                bitmapGraphics.ReleaseHdc(bitmapDc);
            }

            BitmapData data = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            bool painted = false;
            try
            {
                byte[] pixels = new byte[data.Stride * height];
                Marshal.Copy(data.Scan0, pixels, 0, pixels.Length);
                for (int i = 0; i < pixels.Length && !painted; i += 4)
                    painted = pixels[i] != UNPAINTED.B || pixels[i + 1] != UNPAINTED.G || pixels[i + 2] != UNPAINTED.R;
                if (painted)
                {
                    // Parts the control skipped (e.g. its border) count as background
                    for (int i = 0; i < pixels.Length; i += 4)
                    {
                        if (pixels[i] == UNPAINTED.B && pixels[i + 1] == UNPAINTED.G && pixels[i + 2] == UNPAINTED.R)
                        {
                            pixels[i] = 255;
                            pixels[i + 1] = 255;
                            pixels[i + 2] = 255;
                        }
                    }
                    recolor(pixels, data.Stride, width, height);
                    for (int i = 3; i < pixels.Length; i += 4)
                        pixels[i] = 255;
                    Marshal.Copy(pixels, 0, data.Scan0, pixels.Length);
                }
            }
            finally
            {
                bitmap.UnlockBits(data);
            }

            if (painted)
                return bitmap;
            bitmap.Dispose();
            return null;
        }

        // White becomes back, black becomes fore, colors are dropped
        public static Recolorer Grayscale(Color back, Color fore, Rectangle keep = default)
        {
            return (pixels, stride, width, height) =>
            {
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if (keep.Contains(x, y))
                            continue;
                        int i = y * stride + x * 4;
                        int gray = (pixels[i + 2] * 299 + pixels[i + 1] * 587 + pixels[i] * 114) / 1000;
                        pixels[i] = Blend(back.B, fore.B, 255 - gray);
                        pixels[i + 1] = Blend(back.G, fore.G, 255 - gray);
                        pixels[i + 2] = Blend(back.R, fore.R, 255 - gray);
                    }
                }
            };
        }

        // Light becomes dark. Accent colors (selection fill, today marker) keep their hue,
        // everything else goes gray so ClearType fringes do not turn into colored halos.
        // Accents are told apart from fringes by forming horizontal runs of one color.
        public static Recolorer InvertKeepingAccents(Color back, Color fore)
        {
            return (pixels, stride, width, height) =>
            {
                List<int> accents = FindAccentColors(pixels, stride, width, height);
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int i = y * stride + x * 4;
                        int b = pixels[i], g = pixels[i + 1], r = pixels[i + 2];
                        if (IsAccent(r, g, b, accents))
                        {
                            // Invert lightness only: shift all channels so max + min flips
                            int shift = 255 - Math.Max(r, Math.Max(g, b)) - Math.Min(r, Math.Min(g, b));
                            pixels[i] = Blend(back.B, fore.B, Clamp(b + shift));
                            pixels[i + 1] = Blend(back.G, fore.G, Clamp(g + shift));
                            pixels[i + 2] = Blend(back.R, fore.R, Clamp(r + shift));
                        }
                        else
                        {
                            int gray = (r * 299 + g * 587 + b * 114) / 1000;
                            pixels[i] = Blend(back.B, fore.B, 255 - gray);
                            pixels[i + 1] = Blend(back.G, fore.G, 255 - gray);
                            pixels[i + 2] = Blend(back.R, fore.R, 255 - gray);
                        }
                    }
                }
            };
        }

        private const int MIN_ACCENT_CHROMA = 24;
        private const int MIN_ACCENT_RUN = 4;
        private const int ACCENT_TOLERANCE = 6;

        private static List<int> FindAccentColors(byte[] pixels, int stride, int width, int height)
        {
            List<int> accents = new List<int>();
            for (int y = 0; y < height; y++)
            {
                int run = 0;
                for (int x = 1; x < width; x++)
                {
                    int i = y * stride + x * 4;
                    int b = pixels[i], g = pixels[i + 1], r = pixels[i + 2];
                    bool sameAsLeft = Math.Abs(b - pixels[i - 4]) <= 2
                        && Math.Abs(g - pixels[i - 3]) <= 2
                        && Math.Abs(r - pixels[i - 2]) <= 2;
                    run = sameAsLeft ? run + 1 : 0;
                    if (run == MIN_ACCENT_RUN - 1 && Chroma(r, g, b) >= MIN_ACCENT_CHROMA && !IsAccent(r, g, b, accents))
                        accents.Add(r << 16 | g << 8 | b);
                }
            }
            return accents;
        }

        private static bool IsAccent(int r, int g, int b, List<int> accents)
        {
            if (Chroma(r, g, b) < MIN_ACCENT_CHROMA)
                return false;
            foreach (int accent in accents)
            {
                if (Math.Abs(r - (accent >> 16 & 0xFF)) <= ACCENT_TOLERANCE
                    && Math.Abs(g - (accent >> 8 & 0xFF)) <= ACCENT_TOLERANCE
                    && Math.Abs(b - (accent & 0xFF)) <= ACCENT_TOLERANCE)
                    return true;
            }
            return false;
        }

        private static int Chroma(int r, int g, int b)
        {
            return Math.Max(r, Math.Max(g, b)) - Math.Min(r, Math.Min(g, b));
        }

        private static int Clamp(int value)
        {
            return value < 0 ? 0 : value > 255 ? 255 : value;
        }

        private static byte Blend(byte back, byte fore, int amount)
        {
            return (byte)(back + (fore - back) * amount / 255);
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left, Top, Right, Bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct PAINTSTRUCT
        {
            public nint hdc;
            public bool fErase;
            public RECT rcPaint;
            public bool fRestore;
            public bool fIncUpdate;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public byte[] rgbReserved;
        }

        [DllImport("user32.dll")]
        private static extern nint BeginPaint(nint hWnd, out PAINTSTRUCT lpPaint);

        [DllImport("user32.dll")]
        private static extern bool EndPaint(nint hWnd, ref PAINTSTRUCT lpPaint);

        [DllImport("user32.dll")]
        private static extern bool GetClientRect(nint hWnd, out RECT lpRect);
    }
}

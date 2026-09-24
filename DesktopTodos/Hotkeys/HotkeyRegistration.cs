using System.Runtime.InteropServices;

namespace DesktopTodos.Hotkeys
{
    /// <summary>
    /// Registers system-wide (global) hotkeys without needing a Form.
    /// Uses its own hidden message-only window to receive WM_HOTKEY.
    /// Create and use it on the UI thread (the thread running Application.Run).
    /// </summary>
    internal class HotkeyRegistration : IDisposable
    {

        private readonly MessageWindow _window;
        private readonly Dictionary<int, Registration> _registered;
        private readonly Action _hotkeyCallback;
        private int _nextId = 1;          // valid app ids: 0x0000 - 0xBFFF
        private bool _disposed;

        /// <summary>Raised on the UI thread when a registered hotkey is pressed.</summary>
        private event EventHandler<HotkeyPressedEventArgs> _hotkeyPressedEvent;

        public HotkeyRegistration(Action hotkeyCallback)
        {
            _window = new MessageWindow(this);
            _registered = new Dictionary<int, Registration>();

            _hotkeyPressedEvent += OnHotkeyManager_HotkeyPressed;
            _hotkeyCallback = hotkeyCallback;
        }

        private void OnHotkeyManager_HotkeyPressed(object? sender, HotkeyPressedEventArgs e)
        {
            _hotkeyCallback.Invoke();
        }

        /// <summary>
        /// Tries to register a hotkey. Returns false if the key is invalid
        /// or already taken by another program.
        /// </summary>
        /// <param name="hotkey">Modifiers + key, e.g. Keys.Control | Keys.Shift | Keys.P</param>
        /// <param name="win">True to include the Windows key (Keys has no Win modifier).</param>
        /// <param name="id">Id of the registration, used for Unregister/TryReplace.</param>
        public bool TryRegister(Keys hotkey, bool win, out int id)
        {
            ThrowIfDisposed();
            id = 0;

            if (_nextId > 0xBFFF)
                return false;

            if (!RegisterNative(_nextId, hotkey, win))
                return false;

            id = _nextId++;
            _registered[id] = new Registration(hotkey, win);
            return true;
        }

        public bool TryRegister(Keys hotkey, out int id)
        {
            return TryRegister(hotkey, false, out id);
        }

        /// <summary>
        /// Swaps an existing registration for a new key combination, keeping the same id.
        /// If the new combination can't be registered, the old one is restored and false is returned.
        /// </summary>
        public bool TryReplace(int id, Keys newHotkey, bool win = false)
        {
            ThrowIfDisposed();

            Registration old;
            if (!_registered.TryGetValue(id, out old))
                return false;

            NativeMethods.UnregisterHotKey(_window.Handle, id);

            if (RegisterNative(id, newHotkey, win))
            {
                _registered[id] = new Registration(newHotkey, win);
                return true;
            }

            RegisterNative(id, old.Hotkey, old.Win);   // restore previous
            return false;
        }

        public bool Unregister(int id)
        {
            ThrowIfDisposed();

            if (!_registered.Remove(id))
                return false;

            return NativeMethods.UnregisterHotKey(_window.Handle, id);
        }

        public void UnregisterAll()
        {
            ThrowIfDisposed();

            foreach (int id in _registered.Keys)
                NativeMethods.UnregisterHotKey(_window.Handle, id);

            _registered.Clear();
        }

        /// <summary>True if the hotkey is currently registered by this manager.</summary>
        public bool IsRegistered(int id)
        {
            return _registered.ContainsKey(id);
        }

        public void Dispose()
        {
            if (_disposed) return;

            UnregisterAll();
            _window.DestroyHandle();
            _disposed = true;
        }

        // ---------------------------------------------------------------------

        private bool RegisterNative(int id, Keys hotkey, bool win)
        {
            Keys key = hotkey & Keys.KeyCode;
            if (key == Keys.None)
                return false;

            return NativeMethods.RegisterHotKey(_window.Handle, id, ToModifiers(hotkey, win), (uint)key);
        }

        private static uint ToModifiers(Keys hotkey, bool win)
        {
            uint mods = NativeMethods.MOD_NOREPEAT;
            if ((hotkey & Keys.Control) == Keys.Control) mods |= NativeMethods.MOD_CONTROL;
            if ((hotkey & Keys.Alt) == Keys.Alt) mods |= NativeMethods.MOD_ALT;
            if ((hotkey & Keys.Shift) == Keys.Shift) mods |= NativeMethods.MOD_SHIFT;
            if (win) mods |= NativeMethods.MOD_WIN;
            return mods;
        }

        private void OnHotkeyMessage(int id)
        {
            Registration reg;
            if (!_registered.TryGetValue(id, out reg))
                return;

            var handler = _hotkeyPressedEvent;
            if (handler != null)
                handler(this, new HotkeyPressedEventArgs(id, reg.Hotkey, reg.Win));
        }

        private void ThrowIfDisposed()
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(HotkeyRegistration));
        }

        // ---------------------------------------------------------------------

        private struct Registration
        {
            public readonly Keys Hotkey;
            public readonly bool Win;

            public Registration(Keys hotkey, bool win)
            {
                Hotkey = hotkey;
                Win = win;
            }
        }

        /// <summary>Hidden message-only window that receives WM_HOTKEY.</summary>
        private sealed class MessageWindow : NativeWindow
        {
            private static readonly IntPtr HWND_MESSAGE = new IntPtr(-3);
            private const int WM_HOTKEY = 0x0312;

            private readonly HotkeyRegistration _owner;

            public MessageWindow(HotkeyRegistration owner)
            {
                _owner = owner;
                CreateHandle(new CreateParams { Parent = HWND_MESSAGE });
            }

            protected override void WndProc(ref Message m)
            {
                if (m.Msg == WM_HOTKEY)
                    _owner.OnHotkeyMessage(m.WParam.ToInt32());

                base.WndProc(ref m);
            }
        }

        private static class NativeMethods
        {
            public const uint MOD_ALT = 0x0001;
            public const uint MOD_CONTROL = 0x0002;
            public const uint MOD_SHIFT = 0x0004;
            public const uint MOD_WIN = 0x0008;
            public const uint MOD_NOREPEAT = 0x4000;

            [DllImport("user32.dll", SetLastError = true)]
            public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

            [DllImport("user32.dll", SetLastError = true)]
            public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        }
    }

    public sealed class HotkeyPressedEventArgs : EventArgs
    {
        public int Id { get; }
        public Keys Hotkey { get; }
        public bool Win { get; }

        public HotkeyPressedEventArgs(int id, Keys hotkey, bool win)
        {
            Id = id;
            Hotkey = hotkey;
            Win = win;
        }
    }
}




namespace DesktopTodos.Hotkeys
{
    internal class HotkeyManager
    {
        private readonly HotkeyCreation _hotkeyCreation;
        private readonly HotkeyRegistration _hotkeyRegistration;

        private int _hotkeyId;                 // 0 = nothing registered
        private Keys _currentHotkey = Keys.None;

        public HotkeyManager(HotkeyCreation hotkeyCreation, HotkeyRegistration hotkeyRegistration)
        {
            _hotkeyCreation = hotkeyCreation;
            _hotkeyRegistration = hotkeyRegistration;
        }

        internal void Dispose()
        {
            _hotkeyRegistration.Dispose();
        }

        internal bool TryCreateHotkey(TextBox sender, KeyEventArgs e)
        {
            if (_hotkeyCreation.TryCreateHotkey(sender, e, out var hotkey))
            {
                _currentHotkey = hotkey;

                return true;
            }

            return false;
        }
    }
}

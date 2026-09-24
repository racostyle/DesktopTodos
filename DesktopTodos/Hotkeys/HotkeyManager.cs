

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
            if (!_hotkeyCreation.TryCreateHotkey(sender, e, out var hotkey))
                return false;

            if (_currentHotkey == hotkey)
                return false;

            if (ApplyHotkey(hotkey))
            {
                _currentHotkey = hotkey;
                _hotkeyId = (int)hotkey;
                return true;
            }

            sender.ForeColor = Color.Red;
            sender.Text = "Already used by another program.";
            return false;
        }

        private bool ApplyHotkey(Keys hotkey)
        {
            // clear
            if (hotkey == Keys.None)
            {
                if (_hotkeyId != 0) 
                    _hotkeyRegistration.Unregister(_hotkeyId);
                
                _hotkeyId = 0;
                _currentHotkey = Keys.None;
                return true;
            }

            bool ok = _hotkeyId != 0
                ? _hotkeyRegistration.TryReplace(_hotkeyId, hotkey)       // swap, restores old on failure
                : _hotkeyRegistration.TryRegister(hotkey, out _hotkeyId); // first registration

            if (ok) _currentHotkey = hotkey;
            return ok;
        }

    }
}

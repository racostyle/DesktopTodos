
using DesktopTodos.Hotkeys;

namespace DesktopTodos.tabs
{
    internal partial class SettingsControl : UserControl
    {
        private readonly UserSettingsHandler _userSettingsHandler;
        private readonly HotkeyCreation _hotkeyCreation;

        public SettingsControl(UserSettingsHandler userSettingsHandler, HotkeyCreation hotkeyCreation)
        {
            InitializeComponent();
            _userSettingsHandler = userSettingsHandler;
            _hotkeyCreation = hotkeyCreation;
            _userSettingsHandler.Unpack(this);

            tbNewTaskHotkey.KeyDown += OnTbNewTaskHotkey_KeyDown;
        }

        private void OnTbNewTaskHotkey_KeyDown(object? sender, KeyEventArgs e)
        {
            if (sender is TextBox)
                _hotkeyCreation.ValidateAndCreateHotkey((TextBox)sender, e);
        }

        private void OnBtnSaveSettings_Click(object sender, EventArgs e)
        {
            _userSettingsHandler.Pack(this);
        }

        private void OnBtnValidateHotkey_Click(object sender, EventArgs e)
        {

        }
    }
}

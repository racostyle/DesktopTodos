
using DesktopTodos.Hotkeys;
using System.Windows.Forms;

namespace DesktopTodos.Tabs
{
    internal partial class SettingsControl : UserControl
    {
        private readonly UserSettingsHandler _userSettingsHandler;
        private readonly HotkeyManager _hotkeyManager;

        public SettingsControl(UserSettingsHandler userSettingsHandler, HotkeyManager hotkeyManager)
        {
            InitializeComponent();
            _userSettingsHandler = userSettingsHandler;
            _hotkeyManager = hotkeyManager;
            _userSettingsHandler.Unpack(this);

            tbNewTaskHotkey.KeyDown += OnTbNewTaskHotkey_KeyDown;
        }

        private void OnTbNewTaskHotkey_KeyDown(object? sender, KeyEventArgs e)
        {
            if (sender is TextBox)
            {
                var hotkey = _hotkeyManager.TryCreateHotkey((TextBox)sender, e);
            }
        }

        private void OnBtnSaveSettings_Click(object sender, EventArgs e)
        {
            _userSettingsHandler.Pack(this);
        }
    }
}

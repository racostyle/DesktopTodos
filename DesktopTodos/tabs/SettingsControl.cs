
namespace DesktopTodos.tabs
{
    internal partial class SettingsControl : UserControl
    {
        private readonly UserSettingsHandler _userSettingsHandler;

        public SettingsControl(UserSettingsHandler userSettingsHandler)
        {
            InitializeComponent();
            _userSettingsHandler = userSettingsHandler;

            _userSettingsHandler.Unpack(this);
        }

        private void OnBtnSaveSettings_Click(object sender, EventArgs e)
        {
            _userSettingsHandler.Pack(this);
        }
    }
}

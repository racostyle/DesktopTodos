
using DesktopTodos.tabs;
using UtilityLib.Configurations;

namespace DesktopTodos
{
    public partial class DesktopTodosForm : Form
    {
        private readonly UserSettingsHandler _userSettingsHandler;

        private readonly TasksControl _tasksControl;
        private readonly HistoryControl _historyControl;
        private readonly SettingsControl _settingsControl;

        public DesktopTodosForm()
        {
            InitializeComponent();

            _userSettingsHandler = new UserSettingsHandler(new ConfigurationAdapter()
                .ConfigureHandler<Handler_TextBox>()
                .ConfigureHandler<Handler_ComboBox>()
                .ConfigureHandler<Handler_CheckBox>());

            _tasksControl = new TasksControl();
            _historyControl = new HistoryControl();
            _settingsControl = new SettingsControl(
                _userSettingsHandler, 
                new Hotkeys.HotkeyCreation());

            Init();
        }

        private void Init()
        {
            AddUserControlToTabPage(_tasksControl, tabTasks);
            AddUserControlToTabPage(_historyControl, tabHistory);
            AddUserControlToTabPage(_settingsControl, tabSettings);
        }

        private void AddUserControlToTabPage(UserControl control, TabPage page)
        {
            control.Location = new Point(0, 0);
            control.Dock = DockStyle.Fill;
            page.Controls.Add(control);
        }
    }
}

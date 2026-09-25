
using DesktopTodos.Hotkeys;
using DesktopTodos.Settings.Settings;
using DesktopTodos.Tabs;
using UtilityLib.Configurations;

namespace DesktopTodos
{
    public partial class DesktopTodosForm : Form
    {
        private readonly UserSettingsHandler _userSettingsHandler;

        private readonly HotkeyManager _hotkeyManager;

        private readonly TasksControl _tasksControl;
        private readonly HistoryControl _historyControl;
        private readonly SettingsControl _settingsControl;

        private NotifyIcon _trayIcon;

       
        public DesktopTodosForm()
        {
            InitializeComponent();

            _userSettingsHandler = new UserSettingsHandler(new ConfigurationAdapter()
                .ConfigureHandler<Handler_TextBox>()
                .ConfigureHandler<Handler_ComboBox>()
                .ConfigureHandler<Handler_CheckBox>());

            _hotkeyManager = new HotkeyManager(
                new HotkeyCreation(),
                new HotkeyRegistration(HotkeyPressedCallback));

            _tasksControl = new TasksControl();
            _historyControl = new HistoryControl();
            _settingsControl = new SettingsControl(
                _userSettingsHandler,
                _hotkeyManager);

            Init();

            this.Disposed += OnDesktopTodosForm_Disposed;
        }

        private void Init()
        {
            AddUserControlToTabPage(_tasksControl, tabTasks);
            AddUserControlToTabPage(_historyControl, tabHistory);
            AddUserControlToTabPage(_settingsControl, tabSettings);

            InitializeTrayIcon();
        }

        private void InitializeTrayIcon()
        {
            _trayIcon = new NotifyIcon
            {
                Icon = this.Icon,
                Text = "TODOs",
                Visible = true
            };

            _trayIcon.DoubleClick += (_, _) => RestoreFromTray();
        }

        private void AddUserControlToTabPage(UserControl control, TabPage page)
        {
            control.Location = new Point(0, 0);
            control.Dock = DockStyle.Fill;
            page.Controls.Add(control);
        }
        private void HotkeyPressedCallback()
        {
            tabControl.SelectTab(1);
            RestoreFromTray();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (WindowState == FormWindowState.Minimized)
                MinimizeToTray();
        }

        private void MinimizeToTray()
        {
            this.Hide();
            this.ShowInTaskbar = false;
        }
        private void RestoreFromTray()
        {
            this.Show();
            this.ShowInTaskbar = true;

            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;

            this.Activate();
            this.BringToFront();
        }

        private void OnDesktopTodosForm_Disposed(object? sender, EventArgs e)
        {
            _hotkeyManager.Dispose();
        }

       
    }
}

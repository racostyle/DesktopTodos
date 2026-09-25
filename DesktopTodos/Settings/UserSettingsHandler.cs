using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using UtilityLib.Configurations;

namespace DesktopTodos.Settings.Settings
{
    internal class UserSettingsHandler
    {
        private readonly string BASE_LOCATION = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DesktopTodos", "Settings");
        private readonly string APP_NAME = "appsettings.json";

        private readonly ConfigurationAdapter _adapter;
        private readonly SettingsAccessor _settings;
        private Dictionary<string, string> _config;

        internal SettingsAccessor Settings => _settings;

        public UserSettingsHandler(ConfigurationAdapter adapter)
        {
            _adapter = adapter;
            _settings = new SettingsAccessor(() => _config);

            if (!Directory.Exists(BASE_LOCATION))
                Directory.CreateDirectory(BASE_LOCATION);
        }

        internal void Pack(Control control)
        {
            try
            {
                _config = _adapter.PackControls(control);

                var text = JsonSerializer.Serialize(_config);
                File.WriteAllText(Path.Combine(BASE_LOCATION, APP_NAME), text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        internal void Unpack(Control control)
        {
            try
            {
                var file = Path.Combine(BASE_LOCATION, APP_NAME);
                if (!File.Exists(file)) return;

                var text = File.ReadAllText(file);

                if (string.IsNullOrEmpty(text)) return;

                _config = JsonSerializer.Deserialize<Dictionary<string, string>>(text)!;

                _adapter.UnpackControls(control, _config);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}

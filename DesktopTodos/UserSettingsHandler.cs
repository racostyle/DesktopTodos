using System.Text.Json;
using UtilityLib.Configurations;

namespace DesktopTodos
{
    internal class UserSettingsHandler
    {
        private readonly string BASE_LOCATION = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DesktopTodos", "Settings");
        private readonly string APP_NAME = "appsettings.json";

        private readonly ConfigurationAdapter _adapter;
        private Dictionary<string, string> _settings;

        internal Dictionary<string, string> Settings => _settings;


        public UserSettingsHandler(ConfigurationAdapter adapter)
        {
            _adapter = adapter;

            if (!Directory.Exists(BASE_LOCATION))
                Directory.CreateDirectory(BASE_LOCATION);
        }

        internal void Pack(Control control)
        {
            try
            {
                _settings = _adapter.PackControls(control);

                var text = JsonSerializer.Serialize(_settings);
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

                _settings = JsonSerializer.Deserialize<Dictionary<string, string>>(text)!;

                _adapter.UnpackControls(control, _settings);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}

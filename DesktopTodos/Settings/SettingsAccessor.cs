using System.Xml.Linq;

namespace DesktopTodos.Settings
{
    internal class SettingsAccessor
    {
        private readonly Func<Dictionary<string, string>> _configFactory;

        public SettingsAccessor(Func<Dictionary<string, string>> configFactory)
        {
            _configFactory = configFactory;
        }

        internal bool AreSoundAlertsEnabled => GetBool("AreSoundAlerts");
        internal bool AreVisualAlertsEnabled => GetBool("AreVisualAlerts");

        internal string HotkeyKeys => _configFactory.Invoke()["NewTaskHotkey"];

        private bool GetBool(string name)
        {
            var text = _configFactory.Invoke()[name];

            if (bool.TryParse(text, out var value)) 
                return value;

            return false;
        }
    }
}

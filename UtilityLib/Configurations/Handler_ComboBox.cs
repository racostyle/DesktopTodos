using System.Linq;
using System.Windows.Forms;
using UtilityLib.Configurations.Utilities;

namespace UtilityLib.Configurations
{
    public class Handler_ComboBox : IControlHandler
    {
        public void AssignValueToControl(Control ctrl, string value)
        {
            ((ComboBox)ctrl).Text = value;
        }
        public string GetControlValue(Control ctrl) => ((ComboBox)ctrl).Text ?? "";
        public string GetControlNameWithoutPrefix(Control ctrl) => new string(ctrl.Name.SkipWhile(x => char.IsLower(x)).ToArray());

        public bool DoesMatchTo(Control ctrl)
        {
            if (ctrl is ComboBox)
            {
                if (ControlCheckHandler.Shared.Check<ComboBox>(ctrl, "cbb"))
                    return true;
            }
            return false;
        }
    }
}

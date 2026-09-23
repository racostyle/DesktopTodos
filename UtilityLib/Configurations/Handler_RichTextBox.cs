using System.Linq;
using System.Windows.Forms;
using UtilityLib.Configurations.Utilities;

namespace UtilityLib.Configurations
{
    public class Handler_RichTextBox : IControlHandler 
    {
        public void AssignValueToControl(Control ctrl, string value)
        {
            ((RichTextBox)ctrl).Text = value;
        }
        public string GetControlValue(Control ctrl) => ((RichTextBox)ctrl).Text ?? "";
        public string GetControlNameWithoutPrefix(Control ctrl) => new string(ctrl.Name.SkipWhile(x => char.IsLower(x)).ToArray());
        public bool DoesMatchTo(Control ctrl)
        {
            if (ctrl is RichTextBox)
            {
                if (ControlCheckHandler.Shared.Check<RichTextBox>(ctrl, "rtb"))
                    return true;
            }
            return false;
        }
    }
}

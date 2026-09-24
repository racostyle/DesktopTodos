namespace DesktopTodos.Hotkeys
{
    internal class HotkeyCreation
    {
        private Keys _hotkey = Keys.None;

        internal void ValidateAndCreateHotkey(TextBox textBox, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;   // don't type into the box
      
            // Backspace/Delete alone clears it
            if (e.Modifiers == Keys.None && (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete))
            {
                _hotkey = Keys.None;
                textBox.ForeColor = Color.Red;
                textBox.Text = "(none)";
                return;
            }

            // Only a modifier held so far: show it and wait for the actual key
            if (e.KeyCode is Keys.ControlKey or Keys.ShiftKey or Keys.Menu or Keys.LWin or Keys.RWin)
            {
                textBox.Text = FormatHotkey(e.Modifiers) + "...";
                return;
            }

            _hotkey = e.Modifiers | e.KeyCode;

            if (!TryValidateHotkey(_hotkey, out var info))
            {
                _hotkey = Keys.None;
                textBox.ForeColor = Color.Red;
                textBox.Text = info;
                return;
            }

            textBox.ForeColor = Color.LightGreen;
            textBox.Text = FormatHotkey(_hotkey);
        }

        private static string FormatHotkey(Keys k)
        {
            var parts = new List<string>();
            if (k.HasFlag(Keys.Control)) parts.Add("Ctrl");
            if (k.HasFlag(Keys.Shift)) parts.Add("Shift");
            if (k.HasFlag(Keys.Alt)) parts.Add("Alt");
            Keys key = k & Keys.KeyCode;
            if (key != Keys.None) parts.Add(key.ToString());
            return string.Join(" + ", parts);
        }

        private bool TryValidateHotkey(Keys hotkey, out string value)
        {
            Keys key = hotkey & Keys.KeyCode;
            Keys mods = hotkey & Keys.Modifiers;
            bool isFKey = key >= Keys.F1 && key <= Keys.F24;

            if (key == Keys.None)
            {
                value = "Press a key together with the modifiers.";
                return false;
            }
                

            if (mods == Keys.None && !isFKey)
            {
                value = "Add Ctrl, Alt or Shift.";
                return false;
            }

            if (mods == Keys.Shift && !isFKey)
            {
                value = "Shift + a key just types a character.";
                return false;
            }

            if (mods == (Keys.Control | Keys.Alt))
            {
                value = "Ctrl+Alt acts as AltGr on Slovenian/European keyboards. Add Shift.";
                return false;
            }

            value = string.Empty;
            return true; // valid
        }


    }
}

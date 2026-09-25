namespace DesktopTodos.Hotkeys
{
    internal class HotkeyCreation
    {
        private Keys _hotkey = Keys.None;

        internal bool TryCreateHotkey(TextBox textBox, KeyEventArgs e, out Keys hotkey)
        {
            e.SuppressKeyPress = true;
            hotkey = Keys.None;

            // Backspace/Delete alone clears it -> final choice: "no hotkey"
            if (e.Modifiers == Keys.None && (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete))
            {
                textBox.ForeColor = Color.Red;
                textBox.Text = "(none)";
                return true;
            }

            // Only a modifier held so far -> not finished yet
            if (e.KeyCode is Keys.ControlKey or Keys.ShiftKey or Keys.Menu or Keys.LWin or Keys.RWin)
            {
                textBox.ForeColor = SystemColors.WindowText;
                textBox.Text = FormatHotkey(e.Modifiers) + "...";
                return false;
            }

            var candidate = e.Modifiers | e.KeyCode;

            if (!TryValidateHotkey(candidate, out var info))
            {
                textBox.ForeColor = Color.Red;
                textBox.Text = info;
                return false;              // invalid -> keep the current hotkey
            }

            textBox.ForeColor = Color.Green;
            textBox.Text = FormatHotkey(candidate);
            hotkey = candidate;
            return true;
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

        private static bool TryValidateHotkey(Keys hotkey, out string value)
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

        /// <summary>
        /// Reverse of FormatHotkey: "Ctrl + Shift + Alt + N" -> Keys.
        /// Returns Keys.None for empty, "(none)" or unrecognized text.
        /// </summary>
        internal Keys ParseHotkeyFromString(string? text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return Keys.None;

            Keys result = Keys.None;
            Keys key = Keys.None;

            foreach (var raw in text.Split('+'))
            {
                var part = raw.Trim();

                switch (part.ToLowerInvariant())
                {
                    case "ctrl": result |= Keys.Control; break;
                    case "shift": result |= Keys.Shift; break;
                    case "alt": result |= Keys.Alt; break;
                    default:
                        if (key != Keys.None)                                    // two main keys
                            return Keys.None;
                        if (!Enum.TryParse(part, ignoreCase: true, out key))     // "N", "F5", "D1"...
                            return Keys.None;
                        break;
                }
            }

            return key == Keys.None ? Keys.None : result | key;
        }

    }
}

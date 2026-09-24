using UtilityLib;

namespace DesktopTodos.tabs
{
    partial class SettingsControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            darkLabel1 = new UtilityLib.Controls.DarkLabel();
            tbNewTaskHotkey = new UtilityLib.Controls.DarkTextBox();
            chbAreSoundAlerts = new UtilityLib.Controls.DarkCheckBox();
            chbAreVisualAlerts = new UtilityLib.Controls.DarkCheckBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            btnSaveSettings = new UtilityLib.Controls.DarkButton();
            tableLayoutPanel3 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(866, 574);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // darkLabel1
            // 
            darkLabel1.Anchor = AnchorStyles.Left;
            darkLabel1.AutoSize = true;
            darkLabel1.BackColor = Color.FromArgb(25, 25, 25);
            darkLabel1.Font = new Font("Arial", 8F);
            darkLabel1.ForeColor = Color.WhiteSmoke;
            darkLabel1.Location = new Point(3, 17);
            darkLabel1.Name = "darkLabel1";
            darkLabel1.Size = new Size(109, 16);
            darkLabel1.TabIndex = 0;
            darkLabel1.Text = "New task hotkey";
            darkLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbNewTaskHotkey
            // 
            tbNewTaskHotkey.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tbNewTaskHotkey.BackColor = Color.Black;
            tbNewTaskHotkey.BorderStyle = BorderStyle.FixedSingle;
            tbNewTaskHotkey.Font = new Font("Arial", 8F);
            tbNewTaskHotkey.ForeColor = Color.WhiteSmoke;
            tbNewTaskHotkey.Location = new Point(289, 13);
            tbNewTaskHotkey.Name = "tbNewTaskHotkey";
            tbNewTaskHotkey.ReadOnly = true;
            tbNewTaskHotkey.Size = new Size(280, 23);
            tbNewTaskHotkey.TabIndex = 2;
            tbNewTaskHotkey.Text = "Ctrl + Shift + Alt + N";
            // 
            // chbAreSoundAlerts
            // 
            chbAreSoundAlerts.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            chbAreSoundAlerts.AutoSize = true;
            chbAreSoundAlerts.BackColor = Color.FromArgb(25, 25, 25);
            chbAreSoundAlerts.Font = new Font("Arial", 8F);
            chbAreSoundAlerts.ForeColor = Color.WhiteSmoke;
            chbAreSoundAlerts.Location = new Point(3, 65);
            chbAreSoundAlerts.Name = "chbAreSoundAlerts";
            chbAreSoundAlerts.Size = new Size(280, 20);
            chbAreSoundAlerts.TabIndex = 3;
            chbAreSoundAlerts.Text = "Use sound alerts";
            chbAreSoundAlerts.UseVisualStyleBackColor = false;
            // 
            // chbAreVisualAlerts
            // 
            chbAreVisualAlerts.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            chbAreVisualAlerts.AutoSize = true;
            chbAreVisualAlerts.BackColor = Color.FromArgb(25, 25, 25);
            chbAreVisualAlerts.Font = new Font("Arial", 8F);
            chbAreVisualAlerts.ForeColor = Color.WhiteSmoke;
            chbAreVisualAlerts.Location = new Point(3, 115);
            chbAreVisualAlerts.Name = "chbAreVisualAlerts";
            chbAreVisualAlerts.Size = new Size(280, 20);
            chbAreVisualAlerts.TabIndex = 4;
            chbAreVisualAlerts.Text = "Use visual alerts";
            chbAreVisualAlerts.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.Controls.Add(btnSaveSettings, 1, 0);
            tableLayoutPanel2.Location = new Point(3, 527);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(860, 44);
            tableLayoutPanel2.TabIndex = 5;
            // 
            // btnSaveSettings
            // 
            btnSaveSettings.BackColor = Color.Black;
            btnSaveSettings.Dock = DockStyle.Fill;
            btnSaveSettings.FlatAppearance.BorderSize = 0;
            btnSaveSettings.FlatStyle = FlatStyle.Flat;
            btnSaveSettings.Font = new Font("Arial", 8F);
            btnSaveSettings.ForeColor = Color.WhiteSmoke;
            btnSaveSettings.Location = new Point(289, 3);
            btnSaveSettings.Name = "btnSaveSettings";
            btnSaveSettings.Size = new Size(280, 38);
            btnSaveSettings.TabIndex = 0;
            btnSaveSettings.Text = "Save Settings";
            btnSaveSettings.UseVisualStyleBackColor = false;
            btnSaveSettings.Click += OnBtnSaveSettings_Click;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.Controls.Add(tbNewTaskHotkey, 1, 0);
            tableLayoutPanel3.Controls.Add(darkLabel1, 0, 0);
            tableLayoutPanel3.Controls.Add(chbAreVisualAlerts, 0, 2);
            tableLayoutPanel3.Controls.Add(chbAreSoundAlerts, 0, 1);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 4;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(860, 518);
            tableLayoutPanel3.TabIndex = 6;
            // 
            // SettingsControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            Controls.Add(tableLayoutPanel1);
            Name = "SettingsControl";
            Size = new Size(866, 574);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private UtilityLib.Controls.DarkLabel darkLabel1;
        private UtilityLib.Controls.DarkTextBox tbNewTaskHotkey;
        private UtilityLib.Controls.DarkCheckBox chbAreSoundAlerts;
        private UtilityLib.Controls.DarkCheckBox chbAreVisualAlerts;
        private TableLayoutPanel tableLayoutPanel2;
        private UtilityLib.Controls.DarkButton btnSaveSettings;
        private TableLayoutPanel tableLayoutPanel3;
    }
}

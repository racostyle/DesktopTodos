using UtilityLib;
using UtilityLib.Controls;

namespace DesktopTodos
{
    partial class DesktopTodosForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DesktopTodosForm));
            tabControl = new DarkTabControl();
            tabTasks = new TabPage();
            tabHistory = new TabPage();
            tabSettings = new TabPage();
            tabControl.SuspendLayout();
            tabTasks.SuspendLayout();
            tabHistory.SuspendLayout();
            tabSettings.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.AllowDrop = true;
            tabControl.Controls.Add(tabTasks);
            tabControl.Controls.Add(tabHistory);
            tabControl.Controls.Add(tabSettings);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Font = new Font("Arial", 8F);
            tabControl.ForeColor = Color.WhiteSmoke;
            tabControl.Location = new Point(0, 0);
            tabControl.Margin = new Padding(3, 0, 0, 0);
            tabControl.Name = "tabControl";
            tabControl.Padding = new Point(10, 4);
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(800, 450);
            tabControl.TabIndex = 2;
            // 
            // tabTasks
            // 
            tabTasks.AllowDrop = true;
            tabTasks.BackColor = Color.FromArgb(25, 25, 25);
            tabTasks.ForeColor = Color.WhiteSmoke;
            tabTasks.Location = new Point(4, 31);
            tabTasks.Name = "tabTasks";
            tabTasks.Padding = new Padding(3);
            tabTasks.Size = new Size(792, 415);
            tabTasks.TabIndex = 0;
            tabTasks.Text = "Tasks";
            // 
            // tabHistory
            // 
            tabHistory.BackColor = Color.FromArgb(25, 25, 25);
            tabHistory.ForeColor = Color.WhiteSmoke;
            tabHistory.Location = new Point(4, 31);
            tabHistory.Name = "tabHistory";
            tabHistory.Padding = new Padding(3);
            tabHistory.Size = new Size(792, 415);
            tabHistory.TabIndex = 1;
            tabHistory.Text = "History";
            // 
            // tabSettings
            // 
            tabSettings.BackColor = Color.FromArgb(25, 25, 25);
            tabSettings.ForeColor = Color.WhiteSmoke;
            tabSettings.Location = new Point(4, 31);
            tabSettings.Name = "tabSettings";
            tabSettings.Size = new Size(792, 415);
            tabSettings.TabIndex = 2;
            tabSettings.Text = "Settings";
            // DesktopTodosForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "DesktopTodosForm";
            Text = "Desktop Todos";
            tabControl.ResumeLayout(false);
            tabTasks.ResumeLayout(false);
            tabHistory.ResumeLayout(false);
            tabSettings.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private DarkButton btnHistory;
        private DarkButton btnSettings;
        private DarkButton btnAdd;
        private DarkTabControl tabControl;
        private TabPage tabTasks;
        private TabPage tabHistory;
        private TabPage tabSettings;
    }
}

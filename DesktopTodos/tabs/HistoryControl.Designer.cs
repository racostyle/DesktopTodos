using UtilityLib;

namespace DesktopTodos.tabs
{
    partial class HistoryControl
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
            darkLabel1 = new UtilityLib.Controls.DarkLabel();
            SuspendLayout();
            // 
            // darkLabel1
            // 
            darkLabel1.AutoSize = true;
            darkLabel1.BackColor = Color.FromArgb(25, 25, 25);
            darkLabel1.Font = new Font("Arial", 8F);
            darkLabel1.ForeColor = Color.WhiteSmoke;
            darkLabel1.Location = new Point(81, 57);
            darkLabel1.Name = "darkLabel1";
            darkLabel1.Size = new Size(50, 16);
            darkLabel1.TabIndex = 0;
            darkLabel1.Text = "History";
            darkLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // HistoryControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            Controls.Add(darkLabel1);
            Name = "HistoryControl";
            Size = new Size(552, 319);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UtilityLib.Controls.DarkLabel darkLabel1;
    }
}

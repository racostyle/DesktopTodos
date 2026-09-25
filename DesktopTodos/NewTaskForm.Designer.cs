using UtilityLib;

namespace DesktopTodos
{
    partial class NewTaskForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            newTaskControl1 = new DesktopTodos.Tabs.NewTaskControl();
            SuspendLayout();
            // 
            // newTaskControl1
            // 
            newTaskControl1.BackColor = Color.FromArgb(25, 25, 25);
            newTaskControl1.Dock = DockStyle.Fill;
            newTaskControl1.Location = new Point(0, 0);
            newTaskControl1.Name = "newTaskControl1";
            newTaskControl1.Size = new Size(800, 450);
            newTaskControl1.TabIndex = 0;
            // 
            // NewTaskForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            ClientSize = new Size(800, 450);
            Controls.Add(newTaskControl1);
            Name = "NewTaskForm";
            Text = "NewTaskForm";
            ResumeLayout(false);
        }

        #endregion

        private Tabs.NewTaskControl newTaskControl1;
    }
}
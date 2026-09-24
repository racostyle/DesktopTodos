using UtilityLib;

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
            tableLayoutPanel1 = new TableLayoutPanel();
            flpTodos = new FlowLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            btnAdd = new UtilityLib.Controls.DarkButton();
            btnSettings = new UtilityLib.Controls.DarkButton();
            btnHistory = new UtilityLib.Controls.DarkButton();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.Controls.Add(flpTodos, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // flpTodos
            // 
            flpTodos.Dock = DockStyle.Fill;
            flpTodos.FlowDirection = FlowDirection.TopDown;
            flpTodos.Location = new Point(3, 3);
            flpTodos.Name = "flpTodos";
            flpTodos.Size = new Size(694, 444);
            flpTodos.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(btnHistory, 0, 2);
            tableLayoutPanel2.Controls.Add(btnSettings, 0, 1);
            tableLayoutPanel2.Controls.Add(btnAdd, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(703, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(94, 444);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.Black;
            btnAdd.Dock = DockStyle.Fill;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Arial", 28.2F, FontStyle.Bold);
            btnAdd.ForeColor = Color.WhiteSmoke;
            btnAdd.Location = new Point(3, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(88, 94);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "+";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnSettings
            // 
            btnSettings.BackColor = Color.Black;
            btnSettings.Dock = DockStyle.Fill;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Arial", 28.2F, FontStyle.Bold);
            btnSettings.ForeColor = Color.WhiteSmoke;
            btnSettings.Location = new Point(3, 103);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(88, 94);
            btnSettings.TabIndex = 1;
            btnSettings.Text = "⚙";
            btnSettings.UseVisualStyleBackColor = false;
            // 
            // btnHistory
            // 
            btnHistory.BackColor = Color.Black;
            btnHistory.Dock = DockStyle.Fill;
            btnHistory.FlatAppearance.BorderSize = 0;
            btnHistory.FlatStyle = FlatStyle.Flat;
            btnHistory.Font = new Font("Arial", 28.2F, FontStyle.Bold);
            btnHistory.ForeColor = Color.WhiteSmoke;
            btnHistory.Location = new Point(3, 203);
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new Size(88, 94);
            btnHistory.TabIndex = 2;
            btnHistory.Text = "☰";
            btnHistory.UseVisualStyleBackColor = false;
            // 
            // DesktopTodosForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "DesktopTodosForm";
            Text = "Desktop Todos";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flpTodos;
        private TableLayoutPanel tableLayoutPanel2;
        private UtilityLib.Controls.DarkButton btnHistory;
        private UtilityLib.Controls.DarkButton btnSettings;
        private UtilityLib.Controls.DarkButton btnAdd;
    }
}

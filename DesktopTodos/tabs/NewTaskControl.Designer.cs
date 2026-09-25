using UtilityLib;

namespace DesktopTodos.Tabs
{
    partial class NewTaskControl
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
            darkTextBox1 = new UtilityLib.Controls.DarkTextBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            darkLabel1 = new UtilityLib.Controls.DarkLabel();
            pckrStartDate = new UtilityLib.Controls.DarkDateTimePicker();
            pckrStartTime = new UtilityLib.Controls.DarkDateTimePicker();
            chbTriggerStartAlert = new UtilityLib.Controls.DarkCheckBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            darkLabel2 = new UtilityLib.Controls.DarkLabel();
            pckrEndDate = new UtilityLib.Controls.DarkDateTimePicker();
            pckrEndTime = new UtilityLib.Controls.DarkDateTimePicker();
            chbTriggerEndAlert = new UtilityLib.Controls.DarkCheckBox();
            tableLayoutPanel5 = new TableLayoutPanel();
            btnCancel = new UtilityLib.Controls.DarkButton();
            btnSave = new UtilityLib.Controls.DarkButton();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(darkTextBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel5, 0, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 95F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50.0000076F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.Size = new Size(674, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // darkTextBox1
            // 
            darkTextBox1.BackColor = Color.Black;
            darkTextBox1.BorderStyle = BorderStyle.FixedSingle;
            tableLayoutPanel1.SetColumnSpan(darkTextBox1, 2);
            darkTextBox1.Dock = DockStyle.Fill;
            darkTextBox1.Font = new Font("Arial", 8F);
            darkTextBox1.ForeColor = Color.WhiteSmoke;
            darkTextBox1.Location = new Point(3, 3);
            darkTextBox1.Multiline = true;
            darkTextBox1.Name = "darkTextBox1";
            darkTextBox1.Size = new Size(668, 146);
            darkTextBox1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel1.SetColumnSpan(tableLayoutPanel2, 2);
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel4, 1, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 155);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(668, 89);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(darkLabel1, 0, 0);
            tableLayoutPanel3.Controls.Add(pckrStartDate, 0, 1);
            tableLayoutPanel3.Controls.Add(pckrStartTime, 1, 1);
            tableLayoutPanel3.Controls.Add(chbTriggerStartAlert, 0, 2);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(328, 83);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // darkLabel1
            // 
            darkLabel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            darkLabel1.AutoSize = true;
            darkLabel1.BackColor = Color.FromArgb(25, 25, 25);
            darkLabel1.Font = new Font("Arial", 8F);
            darkLabel1.ForeColor = Color.WhiteSmoke;
            darkLabel1.Location = new Point(3, 9);
            darkLabel1.Name = "darkLabel1";
            darkLabel1.Size = new Size(71, 16);
            darkLabel1.TabIndex = 0;
            darkLabel1.Text = "Start Time";
            darkLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pckrStartDate
            // 
            pckrStartDate.BackColor = Color.Black;
            pckrStartDate.Dock = DockStyle.Fill;
            pckrStartDate.Font = new Font("Arial", 8F);
            pckrStartDate.ForeColor = Color.WhiteSmoke;
            pckrStartDate.Format = DateTimePickerFormat.Short;
            pckrStartDate.Location = new Point(3, 28);
            pckrStartDate.Name = "pckrStartDate";
            pckrStartDate.Size = new Size(158, 23);
            pckrStartDate.TabIndex = 1;
            // 
            // pckrStartTime
            // 
            pckrStartTime.BackColor = Color.Black;
            pckrStartTime.Dock = DockStyle.Fill;
            pckrStartTime.Font = new Font("Arial", 8F);
            pckrStartTime.ForeColor = Color.WhiteSmoke;
            pckrStartTime.Format = DateTimePickerFormat.Time;
            pckrStartTime.Location = new Point(167, 28);
            pckrStartTime.Name = "pckrStartTime";
            pckrStartTime.Size = new Size(158, 23);
            pckrStartTime.TabIndex = 2;
            // 
            // chbTriggerStartAlert
            // 
            chbTriggerStartAlert.AutoSize = true;
            chbTriggerStartAlert.BackColor = Color.FromArgb(25, 25, 25);
            chbTriggerStartAlert.Font = new Font("Arial", 8F);
            chbTriggerStartAlert.ForeColor = Color.WhiteSmoke;
            chbTriggerStartAlert.Location = new Point(3, 57);
            chbTriggerStartAlert.Name = "chbTriggerStartAlert";
            chbTriggerStartAlert.Size = new Size(93, 20);
            chbTriggerStartAlert.TabIndex = 3;
            chbTriggerStartAlert.Text = "Fire Alarm";
            chbTriggerStartAlert.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(darkLabel2, 0, 0);
            tableLayoutPanel4.Controls.Add(pckrEndDate, 0, 1);
            tableLayoutPanel4.Controls.Add(pckrEndTime, 1, 1);
            tableLayoutPanel4.Controls.Add(chbTriggerEndAlert, 0, 2);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(337, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 3;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Size = new Size(328, 83);
            tableLayoutPanel4.TabIndex = 1;
            // 
            // darkLabel2
            // 
            darkLabel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            darkLabel2.AutoSize = true;
            darkLabel2.BackColor = Color.FromArgb(25, 25, 25);
            darkLabel2.Font = new Font("Arial", 8F);
            darkLabel2.ForeColor = Color.WhiteSmoke;
            darkLabel2.Location = new Point(3, 9);
            darkLabel2.Name = "darkLabel2";
            darkLabel2.Size = new Size(66, 16);
            darkLabel2.TabIndex = 0;
            darkLabel2.Text = "End Time";
            darkLabel2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pckrEndDate
            // 
            pckrEndDate.BackColor = Color.Black;
            pckrEndDate.Dock = DockStyle.Fill;
            pckrEndDate.Font = new Font("Arial", 8F);
            pckrEndDate.ForeColor = Color.WhiteSmoke;
            pckrEndDate.Format = DateTimePickerFormat.Short;
            pckrEndDate.Location = new Point(3, 28);
            pckrEndDate.Name = "pckrEndDate";
            pckrEndDate.Size = new Size(158, 23);
            pckrEndDate.TabIndex = 1;
            // 
            // pckrEndTime
            // 
            pckrEndTime.BackColor = Color.Black;
            pckrEndTime.Dock = DockStyle.Fill;
            pckrEndTime.Font = new Font("Arial", 8F);
            pckrEndTime.ForeColor = Color.WhiteSmoke;
            pckrEndTime.Format = DateTimePickerFormat.Time;
            pckrEndTime.Location = new Point(167, 28);
            pckrEndTime.Name = "pckrEndTime";
            pckrEndTime.Size = new Size(158, 23);
            pckrEndTime.TabIndex = 2;
            // 
            // chbTriggerEndAlert
            // 
            chbTriggerEndAlert.AutoSize = true;
            chbTriggerEndAlert.BackColor = Color.FromArgb(25, 25, 25);
            chbTriggerEndAlert.Font = new Font("Arial", 8F);
            chbTriggerEndAlert.ForeColor = Color.WhiteSmoke;
            chbTriggerEndAlert.Location = new Point(3, 57);
            chbTriggerEndAlert.Name = "chbTriggerEndAlert";
            chbTriggerEndAlert.Size = new Size(93, 20);
            chbTriggerEndAlert.TabIndex = 3;
            chbTriggerEndAlert.Text = "Fire Alarm";
            chbTriggerEndAlert.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel5.ColumnCount = 4;
            tableLayoutPanel1.SetColumnSpan(tableLayoutPanel5, 2);
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel5.Controls.Add(btnCancel, 1, 0);
            tableLayoutPanel5.Controls.Add(btnSave, 2, 0);
            tableLayoutPanel5.Location = new Point(3, 402);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Size = new Size(668, 45);
            tableLayoutPanel5.TabIndex = 2;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnCancel.BackColor = Color.Black;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Arial", 8F);
            btnCancel.ForeColor = Color.WhiteSmoke;
            btnCancel.Location = new Point(170, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(161, 39);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnSave.BackColor = Color.Black;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Arial", 8F);
            btnSave.ForeColor = Color.WhiteSmoke;
            btnSave.Location = new Point(337, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(161, 39);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // NewTaskControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            Controls.Add(tableLayoutPanel1);
            Name = "NewTaskControl";
            Size = new Size(674, 450);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            tableLayoutPanel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private UtilityLib.Controls.DarkTextBox darkTextBox1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private UtilityLib.Controls.DarkLabel darkLabel1;
        private UtilityLib.Controls.DarkDateTimePicker pckrStartDate;
        private UtilityLib.Controls.DarkDateTimePicker pckrStartTime;
        private UtilityLib.Controls.DarkCheckBox chbTriggerStartAlert;
        private TableLayoutPanel tableLayoutPanel4;
        private UtilityLib.Controls.DarkLabel darkLabel2;
        private UtilityLib.Controls.DarkDateTimePicker pckrEndDate;
        private UtilityLib.Controls.DarkDateTimePicker pckrEndTime;
        private UtilityLib.Controls.DarkCheckBox chbTriggerEndAlert;
        private TableLayoutPanel tableLayoutPanel5;
        private UtilityLib.Controls.DarkButton btnCancel;
        private UtilityLib.Controls.DarkButton btnSave;
    }
}

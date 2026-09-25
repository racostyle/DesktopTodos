using System.Windows.Forms;
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
            tbTodoText = new UtilityLib.Controls.DarkTextBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel4 = new TableLayoutPanel();
            chbHasEndTime = new UtilityLib.Controls.DarkCheckBox();
            pckrEndDateTime = new UtilityLib.Controls.DarkDateTimePicker();
            chbTriggerEndAlert = new UtilityLib.Controls.DarkCheckBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            darkLabel1 = new UtilityLib.Controls.DarkLabel();
            pckrStartDateTime = new UtilityLib.Controls.DarkDateTimePicker();
            chbTriggerStartAlert = new UtilityLib.Controls.DarkCheckBox();
            tableLayoutPanel5 = new TableLayoutPanel();
            btnCancel = new UtilityLib.Controls.DarkButton();
            btnSave = new UtilityLib.Controls.DarkButton();
            tableLayoutPanel6 = new TableLayoutPanel();
            tableLayoutPanel7 = new TableLayoutPanel();
            darkLabel2 = new UtilityLib.Controls.DarkLabel();
            chbDoRepeat = new UtilityLib.Controls.DarkCheckBox();
            numIntervalValue = new UtilityLib.Controls.DarkNumericUpDown();
            cbbRepeatIntervalType = new UtilityLib.Controls.DarkComboBox();
            cbbRepeatIntervalDays = new UtilityLib.Controls.DarkComboBox();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numIntervalValue).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(tbTodoText, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel5, 0, 3);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel6, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(2, 3, 2, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 110F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 180F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.Size = new Size(836, 576);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tbTodoText
            // 
            tbTodoText.BackColor = Color.Black;
            tbTodoText.BorderStyle = BorderStyle.FixedSingle;
            tableLayoutPanel1.SetColumnSpan(tbTodoText, 2);
            tbTodoText.Dock = DockStyle.Fill;
            tbTodoText.Font = new Font("Arial", 12F);
            tbTodoText.ForeColor = Color.WhiteSmoke;
            tbTodoText.Location = new Point(2, 3);
            tbTodoText.Margin = new Padding(2, 3, 2, 3);
            tbTodoText.Multiline = true;
            tbTodoText.Name = "tbTodoText";
            tbTodoText.Size = new Size(832, 230);
            tbTodoText.TabIndex = 0;
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
            tableLayoutPanel2.Location = new Point(2, 239);
            tableLayoutPanel2.Margin = new Padding(2, 3, 2, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(832, 104);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.BackColor = Color.FromArgb(20, 20, 20);
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Controls.Add(chbHasEndTime, 0, 0);
            tableLayoutPanel4.Controls.Add(pckrEndDateTime, 0, 1);
            tableLayoutPanel4.Controls.Add(chbTriggerEndAlert, 0, 2);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(418, 3);
            tableLayoutPanel4.Margin = new Padding(2, 3, 2, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 3;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel4.Size = new Size(412, 98);
            tableLayoutPanel4.TabIndex = 1;
            // 
            // chbHasEndTime
            // 
            chbHasEndTime.AutoSize = true;
            chbHasEndTime.BackColor = Color.FromArgb(20, 20, 20);
            chbHasEndTime.Font = new Font("Arial", 12F);
            chbHasEndTime.ForeColor = Color.WhiteSmoke;
            chbHasEndTime.Location = new Point(2, 3);
            chbHasEndTime.Margin = new Padding(2, 3, 2, 3);
            chbHasEndTime.Name = "chbHasEndTime";
            chbHasEndTime.Size = new Size(109, 26);
            chbHasEndTime.TabIndex = 4;
            chbHasEndTime.Text = "End time";
            chbHasEndTime.UseVisualStyleBackColor = false;
            // 
            // pckrEndDateTime
            // 
            pckrEndDateTime.BackColor = Color.Black;
            pckrEndDateTime.CustomFormat = "dddd\tdd.MM.yyyy HH:mm";
            pckrEndDateTime.Dock = DockStyle.Fill;
            pckrEndDateTime.Font = new Font("Arial", 12F);
            pckrEndDateTime.ForeColor = Color.WhiteSmoke;
            pckrEndDateTime.Format = DateTimePickerFormat.Custom;
            pckrEndDateTime.Location = new Point(2, 35);
            pckrEndDateTime.Margin = new Padding(2, 3, 2, 3);
            pckrEndDateTime.Name = "pckrEndDateTime";
            pckrEndDateTime.Size = new Size(408, 30);
            pckrEndDateTime.TabIndex = 1;
            // 
            // chbTriggerEndAlert
            // 
            chbTriggerEndAlert.AutoSize = true;
            chbTriggerEndAlert.BackColor = Color.FromArgb(20, 20, 20);
            chbTriggerEndAlert.Font = new Font("Arial", 12F);
            chbTriggerEndAlert.ForeColor = Color.WhiteSmoke;
            chbTriggerEndAlert.Location = new Point(2, 67);
            chbTriggerEndAlert.Margin = new Padding(2, 3, 2, 3);
            chbTriggerEndAlert.Name = "chbTriggerEndAlert";
            chbTriggerEndAlert.Size = new Size(159, 27);
            chbTriggerEndAlert.TabIndex = 3;
            chbTriggerEndAlert.Text = "Fire end alarm";
            chbTriggerEndAlert.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.BackColor = Color.FromArgb(20, 20, 20);
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(darkLabel1, 0, 0);
            tableLayoutPanel3.Controls.Add(pckrStartDateTime, 0, 1);
            tableLayoutPanel3.Controls.Add(chbTriggerStartAlert, 0, 2);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(2, 3);
            tableLayoutPanel3.Margin = new Padding(2, 3, 2, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.Size = new Size(412, 98);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // darkLabel1
            // 
            darkLabel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            darkLabel1.AutoSize = true;
            darkLabel1.BackColor = Color.Transparent;
            darkLabel1.Font = new Font("Arial", 12F);
            darkLabel1.ForeColor = Color.WhiteSmoke;
            darkLabel1.Location = new Point(2, 9);
            darkLabel1.Margin = new Padding(2, 0, 2, 0);
            darkLabel1.Name = "darkLabel1";
            darkLabel1.Size = new Size(101, 23);
            darkLabel1.TabIndex = 0;
            darkLabel1.Text = "Start Time";
            darkLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pckrStartDateTime
            // 
            pckrStartDateTime.BackColor = Color.Black;
            pckrStartDateTime.CustomFormat = "dddd\tdd.MM.yyyy HH:mm";
            pckrStartDateTime.Dock = DockStyle.Fill;
            pckrStartDateTime.Font = new Font("Arial", 12F);
            pckrStartDateTime.ForeColor = Color.WhiteSmoke;
            pckrStartDateTime.Format = DateTimePickerFormat.Custom;
            pckrStartDateTime.Location = new Point(2, 35);
            pckrStartDateTime.Margin = new Padding(2, 3, 2, 3);
            pckrStartDateTime.Name = "pckrStartDateTime";
            pckrStartDateTime.Size = new Size(408, 30);
            pckrStartDateTime.TabIndex = 1;
            // 
            // chbTriggerStartAlert
            // 
            chbTriggerStartAlert.AutoSize = true;
            chbTriggerStartAlert.BackColor = Color.FromArgb(20, 20, 20);
            chbTriggerStartAlert.Font = new Font("Arial", 12F);
            chbTriggerStartAlert.ForeColor = Color.WhiteSmoke;
            chbTriggerStartAlert.Location = new Point(2, 67);
            chbTriggerStartAlert.Margin = new Padding(2, 3, 2, 3);
            chbTriggerStartAlert.Name = "chbTriggerStartAlert";
            chbTriggerStartAlert.Size = new Size(167, 27);
            chbTriggerStartAlert.TabIndex = 3;
            chbTriggerStartAlert.Text = "Fire start alarm";
            chbTriggerStartAlert.UseVisualStyleBackColor = false;
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
            tableLayoutPanel5.Location = new Point(2, 529);
            tableLayoutPanel5.Margin = new Padding(2, 3, 2, 3);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Size = new Size(832, 44);
            tableLayoutPanel5.TabIndex = 2;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnCancel.BackColor = Color.Black;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Arial", 12F);
            btnCancel.ForeColor = Color.WhiteSmoke;
            btnCancel.Location = new Point(210, 3);
            btnCancel.Margin = new Padding(2, 3, 2, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(204, 38);
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
            btnSave.Font = new Font("Arial", 12F);
            btnSave.ForeColor = Color.WhiteSmoke;
            btnSave.Location = new Point(418, 3);
            btnSave.Margin = new Padding(2, 3, 2, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(204, 38);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += OnBtnSave_Click;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 2;
            tableLayoutPanel1.SetColumnSpan(tableLayoutPanel6, 2);
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.Controls.Add(tableLayoutPanel7, 0, 0);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(3, 349);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 3;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.Size = new Size(830, 174);
            tableLayoutPanel6.TabIndex = 3;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.BackColor = Color.FromArgb(20, 20, 20);
            tableLayoutPanel7.ColumnCount = 6;
            tableLayoutPanel6.SetColumnSpan(tableLayoutPanel7, 2);
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 15F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel7.Controls.Add(darkLabel2, 1, 0);
            tableLayoutPanel7.Controls.Add(chbDoRepeat, 0, 0);
            tableLayoutPanel7.Controls.Add(numIntervalValue, 2, 0);
            tableLayoutPanel7.Controls.Add(cbbRepeatIntervalType, 3, 0);
            tableLayoutPanel7.Controls.Add(cbbRepeatIntervalDays, 5, 0);
            tableLayoutPanel7.Dock = DockStyle.Fill;
            tableLayoutPanel7.Location = new Point(3, 3);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 1;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.Size = new Size(824, 94);
            tableLayoutPanel7.TabIndex = 4;
            // 
            // darkLabel2
            // 
            darkLabel2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            darkLabel2.AutoSize = true;
            darkLabel2.BackColor = Color.FromArgb(20, 20, 20);
            darkLabel2.Font = new Font("Arial", 12F);
            darkLabel2.ForeColor = Color.WhiteSmoke;
            darkLabel2.Location = new Point(182, 35);
            darkLabel2.Margin = new Padding(2, 0, 2, 0);
            darkLabel2.Name = "darkLabel2";
            darkLabel2.Size = new Size(172, 23);
            darkLabel2.TabIndex = 6;
            darkLabel2.Text = "Repeat every";
            darkLabel2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // chbDoRepeat
            // 
            chbDoRepeat.Anchor = AnchorStyles.Left;
            chbDoRepeat.AutoSize = true;
            chbDoRepeat.BackColor = Color.FromArgb(20, 20, 20);
            chbDoRepeat.Font = new Font("Arial", 12F);
            chbDoRepeat.ForeColor = Color.WhiteSmoke;
            chbDoRepeat.Location = new Point(2, 33);
            chbDoRepeat.Margin = new Padding(2, 3, 2, 3);
            chbDoRepeat.Name = "chbDoRepeat";
            chbDoRepeat.Size = new Size(133, 27);
            chbDoRepeat.TabIndex = 5;
            chbDoRepeat.Text = "Repeatable";
            chbDoRepeat.UseVisualStyleBackColor = false;
            // 
            // numIntervalValue
            // 
            numIntervalValue.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            numIntervalValue.BackColor = Color.Black;
            numIntervalValue.BorderStyle = BorderStyle.FixedSingle;
            numIntervalValue.Font = new Font("Arial", 12F);
            numIntervalValue.ForeColor = Color.WhiteSmoke;
            numIntervalValue.Location = new Point(359, 32);
            numIntervalValue.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            numIntervalValue.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numIntervalValue.Name = "numIntervalValue";
            numIntervalValue.Size = new Size(94, 30);
            numIntervalValue.TabIndex = 7;
            numIntervalValue.TextAlign = HorizontalAlignment.Center;
            numIntervalValue.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // cbbRepeatIntervalType
            // 
            cbbRepeatIntervalType.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cbbRepeatIntervalType.BackColor = Color.Black;
            cbbRepeatIntervalType.FlatStyle = FlatStyle.Flat;
            cbbRepeatIntervalType.Font = new Font("Arial", 12F);
            cbbRepeatIntervalType.ForeColor = Color.WhiteSmoke;
            cbbRepeatIntervalType.FormattingEnabled = true;
            cbbRepeatIntervalType.Location = new Point(459, 31);
            cbbRepeatIntervalType.Name = "cbbRepeatIntervalType";
            cbbRepeatIntervalType.Size = new Size(170, 31);
            cbbRepeatIntervalType.TabIndex = 8;
            // 
            // cbbRepeatIntervalDays
            // 
            cbbRepeatIntervalDays.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cbbRepeatIntervalDays.BackColor = Color.Black;
            cbbRepeatIntervalDays.FlatStyle = FlatStyle.Flat;
            cbbRepeatIntervalDays.Font = new Font("Arial", 12F);
            cbbRepeatIntervalDays.ForeColor = Color.WhiteSmoke;
            cbbRepeatIntervalDays.FormattingEnabled = true;
            cbbRepeatIntervalDays.Location = new Point(650, 31);
            cbbRepeatIntervalDays.Name = "cbbRepeatIntervalDays";
            cbbRepeatIntervalDays.Size = new Size(171, 31);
            cbbRepeatIntervalDays.TabIndex = 9;
            // 
            // NewTaskControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(2, 3, 2, 3);
            Name = "NewTaskControl";
            Size = new Size(836, 576);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel7.ResumeLayout(false);
            tableLayoutPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numIntervalValue).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private UtilityLib.Controls.DarkTextBox tbTodoText;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private UtilityLib.Controls.DarkLabel darkLabel1;
        private UtilityLib.Controls.DarkDateTimePicker pckrStartDateTime;
        private UtilityLib.Controls.DarkCheckBox chbTriggerStartAlert;
        private TableLayoutPanel tableLayoutPanel4;
        private UtilityLib.Controls.DarkDateTimePicker pckrEndDateTime;
        private UtilityLib.Controls.DarkCheckBox chbTriggerEndAlert;
        private TableLayoutPanel tableLayoutPanel5;
        private UtilityLib.Controls.DarkButton btnCancel;
        private UtilityLib.Controls.DarkButton btnSave;
        private UtilityLib.Controls.DarkCheckBox chbHasEndTime;
        private TableLayoutPanel tableLayoutPanel6;
        private TableLayoutPanel tableLayoutPanel7;
        private UtilityLib.Controls.DarkLabel darkLabel2;
        private UtilityLib.Controls.DarkCheckBox chbDoRepeat;
        private UtilityLib.Controls.DarkNumericUpDown numIntervalValue;
        private UtilityLib.Controls.DarkComboBox cbbRepeatIntervalType;
        private UtilityLib.Controls.DarkComboBox cbbRepeatIntervalDays;
    }
}

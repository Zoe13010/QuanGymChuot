
namespace QuanGymChuot.Library.Controls
{
    partial class Form_UserPurPack
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
            this.cbUserName = new System.Windows.Forms.ComboBox();
            this.dtpCurRegDate = new System.Windows.Forms.DateTimePicker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpCurExpDate = new System.Windows.Forms.DateTimePicker();
            this.tbCurExpDay = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbCurComboPack = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbUserName
            // 
            this.cbUserName.FormattingEnabled = true;
            this.cbUserName.Location = new System.Drawing.Point(201, 67);
            this.cbUserName.MaxDropDownItems = 2;
            this.cbUserName.Name = "cbUserName";
            this.cbUserName.Size = new System.Drawing.Size(385, 25);
            this.cbUserName.TabIndex = 39;
            // 
            // dtpCurRegDate
            // 
            this.dtpCurRegDate.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpCurRegDate.CustomFormat = "dd/MM/yyyy hh:mm:ss tt";
            this.dtpCurRegDate.Enabled = false;
            this.dtpCurRegDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCurRegDate.Location = new System.Drawing.Point(201, 139);
            this.dtpCurRegDate.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpCurRegDate.MinDate = new System.DateTime(2001, 1, 1, 0, 0, 0, 0);
            this.dtpCurRegDate.Name = "dtpCurRegDate";
            this.dtpCurRegDate.Size = new System.Drawing.Size(206, 25);
            this.dtpCurRegDate.TabIndex = 38;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(559, 587);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 35);
            this.btnCancel.TabIndex = 37;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(451, 587);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(102, 35);
            this.btnAccept.TabIndex = 36;
            this.btnAccept.Text = "Create";
            this.btnAccept.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label7.Location = new System.Drawing.Point(28, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(224, 25);
            this.label7.TabIndex = 35;
            this.label7.Text = "Create a new registration";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 181);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 19);
            this.label8.TabIndex = 32;
            this.label8.Text = "Expired in";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 19);
            this.label4.TabIndex = 29;
            this.label4.Text = "Registration date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 19);
            this.label3.TabIndex = 28;
            this.label3.Text = "Combo name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 19);
            this.label2.TabIndex = 27;
            this.label2.Text = "User name";
            // 
            // tbID
            // 
            this.tbID.BackColor = System.Drawing.Color.White;
            this.tbID.Location = new System.Drawing.Point(201, 31);
            this.tbID.Name = "tbID";
            this.tbID.ReadOnly = true;
            this.tbID.Size = new System.Drawing.Size(385, 25);
            this.tbID.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 19);
            this.label1.TabIndex = 31;
            this.label1.Text = "ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 19);
            this.label5.TabIndex = 41;
            this.label5.Text = "Quality";
            // 
            // dtpCurExpDate
            // 
            this.dtpCurExpDate.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpCurExpDate.CustomFormat = "dd/MM/yyyy hh:mm:ss tt";
            this.dtpCurExpDate.Enabled = false;
            this.dtpCurExpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCurExpDate.Location = new System.Drawing.Point(201, 175);
            this.dtpCurExpDate.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpCurExpDate.MinDate = new System.DateTime(2001, 1, 1, 0, 0, 0, 0);
            this.dtpCurExpDate.Name = "dtpCurExpDate";
            this.dtpCurExpDate.Size = new System.Drawing.Size(206, 25);
            this.dtpCurExpDate.TabIndex = 38;
            // 
            // tbCurExpDay
            // 
            this.tbCurExpDay.BackColor = System.Drawing.Color.White;
            this.tbCurExpDay.Location = new System.Drawing.Point(201, 211);
            this.tbCurExpDay.Name = "tbCurExpDay";
            this.tbCurExpDay.ReadOnly = true;
            this.tbCurExpDay.Size = new System.Drawing.Size(206, 25);
            this.tbCurExpDay.TabIndex = 30;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(201, 66);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(130, 25);
            this.textBox2.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(413, 214);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 19);
            this.label6.TabIndex = 32;
            this.label6.Text = "day(s)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbCurComboPack);
            this.groupBox1.Controls.Add(this.tbID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtpCurExpDate);
            this.groupBox1.Controls.Add(this.cbUserName);
            this.groupBox1.Controls.Add(this.dtpCurRegDate);
            this.groupBox1.Controls.Add(this.tbCurExpDay);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(45, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(616, 260);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registration Information";
            // 
            // tbCurComboPack
            // 
            this.tbCurComboPack.BackColor = System.Drawing.Color.White;
            this.tbCurComboPack.Location = new System.Drawing.Point(201, 103);
            this.tbCurComboPack.Name = "tbCurComboPack";
            this.tbCurComboPack.ReadOnly = true;
            this.tbCurComboPack.Size = new System.Drawing.Size(385, 25);
            this.tbCurComboPack.TabIndex = 30;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 214);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 19);
            this.label10.TabIndex = 29;
            this.label10.Text = "Expired in (days)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.comboBox2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.dateTimePicker2);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Location = new System.Drawing.Point(45, 332);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(616, 188);
            this.groupBox2.TabIndex = 43;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Purchase and add new Combo Pack";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(123, 19);
            this.label11.TabIndex = 28;
            this.label11.Text = "New Combo name";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.comboBox2.Location = new System.Drawing.Point(201, 30);
            this.comboBox2.MaxDropDownItems = 2;
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(385, 25);
            this.comboBox2.TabIndex = 39;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarMonthBackground = System.Drawing.Color.White;
            this.dateTimePicker2.CustomFormat = "dd/MM/yyyy hh:mm:ss tt";
            this.dateTimePicker2.Enabled = false;
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(201, 102);
            this.dateTimePicker2.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker2.MinDate = new System.DateTime(2001, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(206, 25);
            this.dateTimePicker2.TabIndex = 38;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(21, 141);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(139, 19);
            this.label14.TabIndex = 29;
            this.label14.Text = "New expired in (days)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(21, 108);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 19);
            this.label12.TabIndex = 32;
            this.label12.Text = "New expired in";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.White;
            this.textBox4.Location = new System.Drawing.Point(201, 138);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(206, 25);
            this.textBox4.TabIndex = 30;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(413, 141);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 19);
            this.label13.TabIndex = 32;
            this.label13.Text = "day(s)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(41, 529);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 19);
            this.label9.TabIndex = 44;
            this.label9.Text = "You are a new user.";
            // 
            // Form_UserPurPack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(709, 651);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.label7);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_UserPurPack";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.Form_UserPurPack_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbUserName;
        private System.Windows.Forms.DateTimePicker dtpCurRegDate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpCurExpDate;
        private System.Windows.Forms.TextBox tbCurExpDay;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox tbCurComboPack;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
    }
}
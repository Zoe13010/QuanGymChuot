
namespace QuanGymChuot.Library.Controls
{
    partial class Form_ComboPack
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbDayCount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbInfo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbCanUse = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dtpAddDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // tbID
            // 
            this.tbID.BackColor = System.Drawing.Color.White;
            this.tbID.Location = new System.Drawing.Point(243, 69);
            this.tbID.Name = "tbID";
            this.tbID.ReadOnly = true;
            this.tbID.Size = new System.Drawing.Size(385, 25);
            this.tbID.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Combo Name";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(243, 105);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(385, 25);
            this.tbName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Combo Price";
            // 
            // tbPrice
            // 
            this.tbPrice.Location = new System.Drawing.Point(243, 141);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(385, 25);
            this.tbPrice.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Combo Days Count";
            // 
            // tbDayCount
            // 
            this.tbDayCount.Location = new System.Drawing.Point(243, 177);
            this.tbDayCount.Name = "tbDayCount";
            this.tbDayCount.Size = new System.Drawing.Size(385, 25);
            this.tbDayCount.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(63, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Combo Information";
            // 
            // tbInfo
            // 
            this.tbInfo.Location = new System.Drawing.Point(243, 214);
            this.tbInfo.Multiline = true;
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.Size = new System.Drawing.Size(385, 77);
            this.tbInfo.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(63, 304);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "Can Use?";
            // 
            // cbCanUse
            // 
            this.cbCanUse.AutoSize = true;
            this.cbCanUse.Location = new System.Drawing.Point(243, 302);
            this.cbCanUse.Name = "cbCanUse";
            this.cbCanUse.Size = new System.Drawing.Size(48, 23);
            this.cbCanUse.TabIndex = 5;
            this.cbCanUse.Text = "Yes";
            this.cbCanUse.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label7.Location = new System.Drawing.Point(28, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(231, 25);
            this.label7.TabIndex = 3;
            this.label7.Text = "Create a new Combo Pack";
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(418, 383);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(102, 35);
            this.btnAccept.TabIndex = 6;
            this.btnAccept.Text = "Create";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(526, 383);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 35);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dtpAddDate
            // 
            this.dtpAddDate.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpAddDate.Checked = false;
            this.dtpAddDate.CustomFormat = "dd/MM/yyyy hh:mm:ss tt";
            this.dtpAddDate.Enabled = false;
            this.dtpAddDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAddDate.Location = new System.Drawing.Point(243, 336);
            this.dtpAddDate.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpAddDate.MinDate = new System.DateTime(2001, 1, 1, 0, 0, 0, 0);
            this.dtpAddDate.Name = "dtpAddDate";
            this.dtpAddDate.Size = new System.Drawing.Size(385, 25);
            this.dtpAddDate.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(63, 342);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 19);
            this.label8.TabIndex = 0;
            this.label8.Text = "Added date";
            // 
            // Form_ComboPack
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(709, 448);
            this.Controls.Add(this.dtpAddDate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbCanUse);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbInfo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbDayCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbPrice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbID);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_ComboPack";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.Form_ComboPack_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbDayCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbInfo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbCanUse;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DateTimePicker dtpAddDate;
        private System.Windows.Forms.Label label8;
    }
}
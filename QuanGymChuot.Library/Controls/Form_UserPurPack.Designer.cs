
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
            this.tbNewComboQty = new System.Windows.Forms.TextBox();
            this.lbCurExpDay = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbCurComboPack = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lbCurExpDate = new System.Windows.Forms.Label();
            this.lbCurRegDate = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbNewComboPack = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lbNewExpDate = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbUserName
            // 
            this.cbUserName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbUserName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbUserName.Location = new System.Drawing.Point(201, 67);
            this.cbUserName.Name = "cbUserName";
            this.cbUserName.Size = new System.Drawing.Size(385, 25);
            this.cbUserName.Sorted = true;
            this.cbUserName.TabIndex = 39;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(559, 479);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 35);
            this.btnCancel.TabIndex = 37;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(451, 479);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(102, 35);
            this.btnAccept.TabIndex = 36;
            this.btnAccept.Text = "Create";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
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
            this.label3.Size = new System.Drawing.Size(140, 19);
            this.label3.TabIndex = 28;
            this.label3.Text = "Current combo name";
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
            // tbNewComboQty
            // 
            this.tbNewComboQty.BackColor = System.Drawing.Color.White;
            this.tbNewComboQty.Enabled = false;
            this.tbNewComboQty.Location = new System.Drawing.Point(201, 66);
            this.tbNewComboQty.Name = "tbNewComboQty";
            this.tbNewComboQty.Size = new System.Drawing.Size(130, 25);
            this.tbNewComboQty.TabIndex = 30;
            this.tbNewComboQty.Text = "1";
            this.tbNewComboQty.TextChanged += new System.EventHandler(this.tbNewComboQty_TextChanged);
            // 
            // lbCurExpDay
            // 
            this.lbCurExpDay.AutoSize = true;
            this.lbCurExpDay.Location = new System.Drawing.Point(197, 214);
            this.lbCurExpDay.Name = "lbCurExpDay";
            this.lbCurExpDay.Size = new System.Drawing.Size(45, 19);
            this.lbCurExpDay.TabIndex = 32;
            this.lbCurExpDay.Text = "day(s)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbCurComboPack);
            this.groupBox1.Controls.Add(this.tbID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lbCurExpDate);
            this.groupBox1.Controls.Add(this.lbCurRegDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbUserName);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lbCurExpDay);
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
            // lbCurExpDate
            // 
            this.lbCurExpDate.AutoSize = true;
            this.lbCurExpDate.Location = new System.Drawing.Point(197, 181);
            this.lbCurExpDate.Name = "lbCurExpDate";
            this.lbCurExpDate.Size = new System.Drawing.Size(165, 19);
            this.lbCurExpDate.TabIndex = 29;
            this.lbCurExpDate.Text = "dd/MM/yyyy hh:mm:ss tt";
            // 
            // lbCurRegDate
            // 
            this.lbCurRegDate.AutoSize = true;
            this.lbCurRegDate.Location = new System.Drawing.Point(197, 145);
            this.lbCurRegDate.Name = "lbCurRegDate";
            this.lbCurRegDate.Size = new System.Drawing.Size(165, 19);
            this.lbCurRegDate.TabIndex = 29;
            this.lbCurRegDate.Text = "dd/MM/yyyy hh:mm:ss tt";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.cbNewComboPack);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tbNewComboQty);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.lbNewExpDate);
            this.groupBox2.Location = new System.Drawing.Point(45, 332);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(616, 141);
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
            // cbNewComboPack
            // 
            this.cbNewComboPack.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbNewComboPack.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbNewComboPack.Items.AddRange(new object[] {
            "Female",
            "Male"});
            this.cbNewComboPack.Location = new System.Drawing.Point(201, 30);
            this.cbNewComboPack.MaxDropDownItems = 2;
            this.cbNewComboPack.Name = "cbNewComboPack";
            this.cbNewComboPack.Size = new System.Drawing.Size(385, 25);
            this.cbNewComboPack.TabIndex = 39;
            this.cbNewComboPack.SelectedIndexChanged += new System.EventHandler(this.cbNewComboPack_SelectedIndexChanged);
            this.cbNewComboPack.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbNewComboPack_KeyDown);
            this.cbNewComboPack.Leave += new System.EventHandler(this.cbNewComboPack_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(21, 105);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 19);
            this.label12.TabIndex = 32;
            this.label12.Text = "New expired in";
            // 
            // lbNewExpDate
            // 
            this.lbNewExpDate.AutoSize = true;
            this.lbNewExpDate.Location = new System.Drawing.Point(197, 105);
            this.lbNewExpDate.Name = "lbNewExpDate";
            this.lbNewExpDate.Size = new System.Drawing.Size(165, 19);
            this.lbNewExpDate.TabIndex = 29;
            this.lbNewExpDate.Text = "dd/MM/yyyy hh:mm:ss tt";
            // 
            // Form_UserPurPack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(709, 527);
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
        private System.Windows.Forms.TextBox tbNewComboQty;
        private System.Windows.Forms.Label lbCurExpDay;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbNewComboPack;
        private System.Windows.Forms.TextBox tbCurComboPack;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbCurExpDate;
        private System.Windows.Forms.Label lbCurRegDate;
        private System.Windows.Forms.Label lbNewExpDate;
    }
}
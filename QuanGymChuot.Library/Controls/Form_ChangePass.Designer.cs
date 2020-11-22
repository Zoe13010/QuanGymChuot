
namespace QuanGymChuot.Library.Controls
{
    partial class Form_ChangePass
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
            this.gbChangePass = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPassNewConfirm = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPassNew = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.tbPassOld = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChangePass = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbStatus = new System.Windows.Forms.Label();
            this.bwChangePass = new System.ComponentModel.BackgroundWorker();
            this.gbChangePass.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbChangePass
            // 
            this.gbChangePass.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbChangePass.Controls.Add(this.label6);
            this.gbChangePass.Controls.Add(this.label5);
            this.gbChangePass.Controls.Add(this.label4);
            this.gbChangePass.Controls.Add(this.tbPassNewConfirm);
            this.gbChangePass.Controls.Add(this.label3);
            this.gbChangePass.Controls.Add(this.tbPassNew);
            this.gbChangePass.Controls.Add(this.label2);
            this.gbChangePass.Controls.Add(this.tbUser);
            this.gbChangePass.Controls.Add(this.tbPassOld);
            this.gbChangePass.Controls.Add(this.label1);
            this.gbChangePass.Location = new System.Drawing.Point(12, 12);
            this.gbChangePass.Name = "gbChangePass";
            this.gbChangePass.Size = new System.Drawing.Size(682, 194);
            this.gbChangePass.TabIndex = 0;
            this.gbChangePass.TabStop = false;
            this.gbChangePass.Text = "Change Password";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(418, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(233, 36);
            this.label6.TabIndex = 5;
            this.label6.Text = "Confirm New Password must match with New Password.";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(418, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(233, 36);
            this.label5.TabIndex = 4;
            this.label5.Text = "New Password must be 6 characters or later.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Username";
            // 
            // tbPassNewConfirm
            // 
            this.tbPassNewConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPassNewConfirm.Location = new System.Drawing.Point(205, 142);
            this.tbPassNewConfirm.Name = "tbPassNewConfirm";
            this.tbPassNewConfirm.Size = new System.Drawing.Size(207, 25);
            this.tbPassNewConfirm.TabIndex = 3;
            this.tbPassNewConfirm.UseSystemPasswordChar = true;
            this.tbPassNewConfirm.TextChanged += new System.EventHandler(this.tbPass_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Confirm New Password";
            // 
            // tbPassNew
            // 
            this.tbPassNew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPassNew.Location = new System.Drawing.Point(205, 106);
            this.tbPassNew.Name = "tbPassNew";
            this.tbPassNew.Size = new System.Drawing.Size(207, 25);
            this.tbPassNew.TabIndex = 2;
            this.tbPassNew.UseSystemPasswordChar = true;
            this.tbPassNew.TextChanged += new System.EventHandler(this.tbPass_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "New Password";
            // 
            // tbUser
            // 
            this.tbUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUser.BackColor = System.Drawing.Color.White;
            this.tbUser.Enabled = false;
            this.tbUser.Location = new System.Drawing.Point(205, 34);
            this.tbUser.Name = "tbUser";
            this.tbUser.ReadOnly = true;
            this.tbUser.Size = new System.Drawing.Size(207, 25);
            this.tbUser.TabIndex = 0;
            // 
            // tbPassOld
            // 
            this.tbPassOld.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPassOld.Location = new System.Drawing.Point(205, 70);
            this.tbPassOld.Name = "tbPassOld";
            this.tbPassOld.Size = new System.Drawing.Size(207, 25);
            this.tbPassOld.TabIndex = 1;
            this.tbPassOld.UseSystemPasswordChar = true;
            this.tbPassOld.TextChanged += new System.EventHandler(this.tbPass_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Old Password";
            // 
            // btnChangePass
            // 
            this.btnChangePass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangePass.Enabled = false;
            this.btnChangePass.Location = new System.Drawing.Point(448, 235);
            this.btnChangePass.Name = "btnChangePass";
            this.btnChangePass.Size = new System.Drawing.Size(141, 31);
            this.btnChangePass.TabIndex = 4;
            this.btnChangePass.Text = "Change Password";
            this.btnChangePass.UseVisualStyleBackColor = true;
            this.btnChangePass.Click += new System.EventHandler(this.btnChangePass_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(595, 235);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 31);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbStatus
            // 
            this.lbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(12, 215);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(29, 17);
            this.lbStatus.TabIndex = 6;
            this.lbStatus.Text = "Idle";
            this.lbStatus.Visible = false;
            // 
            // bwChangePass
            // 
            this.bwChangePass.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwChangePass_DoWork);
            this.bwChangePass.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwChangePass_RunWorkerCompleted);
            // 
            // Form_ChangePass
            // 
            this.AcceptButton = this.btnChangePass;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(706, 278);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.btnChangePass);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gbChangePass);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_ChangePass";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.gbChangePass.ResumeLayout(false);
            this.gbChangePass.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbChangePass;
        private System.Windows.Forms.TextBox tbPassNewConfirm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPassNew;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPassOld;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChangePass;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.ComponentModel.BackgroundWorker bwChangePass;
    }
}
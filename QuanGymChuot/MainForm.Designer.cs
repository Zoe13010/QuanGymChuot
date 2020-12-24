namespace QuanGymChuot
{
    partial class MainForm
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
            this.pnStatus = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lbStatus = new System.Windows.Forms.Label();
            this.btnChangePass = new System.Windows.Forms.Button();
            this.bwInitListView = new System.ComponentModel.BackgroundWorker();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPagePaymentHistory = new System.Windows.Forms.TabPage();
            this.lvcPaymentHistory = new QuanGymChuot.Library.Controls.ListViewControl();
            this.tabPageUserInfo = new System.Windows.Forms.TabPage();
            this.lvcUserInfo = new QuanGymChuot.Library.Controls.ListViewControl();
            this.tabPageComboPack = new System.Windows.Forms.TabPage();
            this.lvcComboPack = new QuanGymChuot.Library.Controls.ListViewControl();
            this.login1 = new QuanGymChuot.Library.Controls.Login();
            this.pnStatus.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPagePaymentHistory.SuspendLayout();
            this.tabPageUserInfo.SuspendLayout();
            this.tabPageComboPack.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnStatus
            // 
            this.pnStatus.Controls.Add(this.btnLogout);
            this.pnStatus.Controls.Add(this.lbStatus);
            this.pnStatus.Controls.Add(this.btnChangePass);
            this.pnStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnStatus.Location = new System.Drawing.Point(0, 552);
            this.pnStatus.Name = "pnStatus";
            this.pnStatus.Size = new System.Drawing.Size(975, 31);
            this.pnStatus.TabIndex = 2;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.Location = new System.Drawing.Point(894, 2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(77, 27);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(6, 6);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(241, 19);
            this.lbStatus.TabIndex = 3;
            this.lbStatus.Text = "Login using your account to continue.";
            // 
            // btnChangePass
            // 
            this.btnChangePass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangePass.Location = new System.Drawing.Point(696, 2);
            this.btnChangePass.Name = "btnChangePass";
            this.btnChangePass.Size = new System.Drawing.Size(192, 27);
            this.btnChangePass.TabIndex = 4;
            this.btnChangePass.Text = "Change Account Password";
            this.btnChangePass.UseVisualStyleBackColor = true;
            this.btnChangePass.Click += new System.EventHandler(this.btnChangePass_Click);
            // 
            // bwInitListView
            // 
            this.bwInitListView.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwInitListView_DoWork);
            this.bwInitListView.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwInitListView_RunWorkerCompleted);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPagePaymentHistory);
            this.tabControl.Controls.Add(this.tabPageUserInfo);
            this.tabControl.Controls.Add(this.tabPageComboPack);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(975, 552);
            this.tabControl.TabIndex = 3;
            // 
            // tabPagePaymentHistory
            // 
            this.tabPagePaymentHistory.BackColor = System.Drawing.Color.White;
            this.tabPagePaymentHistory.Controls.Add(this.lvcPaymentHistory);
            this.tabPagePaymentHistory.Location = new System.Drawing.Point(4, 26);
            this.tabPagePaymentHistory.Name = "tabPagePaymentHistory";
            this.tabPagePaymentHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePaymentHistory.Size = new System.Drawing.Size(967, 522);
            this.tabPagePaymentHistory.TabIndex = 3;
            this.tabPagePaymentHistory.Text = "Payment History";
            // 
            // lvcPaymentHistory
            // 
            this.lvcPaymentHistory.BackColor = System.Drawing.Color.White;
            this.lvcPaymentHistory.Description = "Manage ....";
            this.lvcPaymentHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvcPaymentHistory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lvcPaymentHistory.Location = new System.Drawing.Point(3, 3);
            this.lvcPaymentHistory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvcPaymentHistory.MsgBoxDelTitle = null;
            this.lvcPaymentHistory.Name = "lvcPaymentHistory";
            this.lvcPaymentHistory.Size = new System.Drawing.Size(961, 516);
            this.lvcPaymentHistory.TabIndex = 4;
            this.lvcPaymentHistory.Title = "Payment History";
            this.lvcPaymentHistory.RequestCreate += new System.EventHandler(this.lvcUserPurPack_RequestCreate);
            this.lvcPaymentHistory.RequestDelete += new System.EventHandler(this.lvcUserPurPack_RequestDelete);
            this.lvcPaymentHistory.RequestRefresh += new System.EventHandler(this.lvcUserPurPack_RequestRefresh);
            this.lvcPaymentHistory.RequestEdit += new System.EventHandler(this.lvcUserPurPack_RequestEdit);
            // 
            // tabPageUserInfo
            // 
            this.tabPageUserInfo.BackColor = System.Drawing.Color.White;
            this.tabPageUserInfo.Controls.Add(this.lvcUserInfo);
            this.tabPageUserInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPageUserInfo.Name = "tabPageUserInfo";
            this.tabPageUserInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUserInfo.Size = new System.Drawing.Size(967, 526);
            this.tabPageUserInfo.TabIndex = 2;
            this.tabPageUserInfo.Text = "User Information";
            // 
            // lvcUserInfo
            // 
            this.lvcUserInfo.BackColor = System.Drawing.Color.White;
            this.lvcUserInfo.Description = "Manage information of users";
            this.lvcUserInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvcUserInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lvcUserInfo.Location = new System.Drawing.Point(3, 3);
            this.lvcUserInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvcUserInfo.MsgBoxDelTitle = null;
            this.lvcUserInfo.Name = "lvcUserInfo";
            this.lvcUserInfo.Size = new System.Drawing.Size(961, 520);
            this.lvcUserInfo.TabIndex = 4;
            this.lvcUserInfo.Title = "User Information";
            this.lvcUserInfo.RequestCreate += new System.EventHandler(this.lvcUserInfo_RequestCreate);
            this.lvcUserInfo.RequestDelete += new System.EventHandler(this.lvcUserInfo_RequestDelete);
            this.lvcUserInfo.RequestRefresh += new System.EventHandler(this.lvcUserInfo_RequestRefresh);
            this.lvcUserInfo.RequestEdit += new System.EventHandler(this.lvcUserInfo_RequestEdit);
            // 
            // tabPageComboPack
            // 
            this.tabPageComboPack.BackColor = System.Drawing.Color.White;
            this.tabPageComboPack.Controls.Add(this.lvcComboPack);
            this.tabPageComboPack.Location = new System.Drawing.Point(4, 22);
            this.tabPageComboPack.Name = "tabPageComboPack";
            this.tabPageComboPack.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageComboPack.Size = new System.Drawing.Size(967, 526);
            this.tabPageComboPack.TabIndex = 1;
            this.tabPageComboPack.Text = "Combo Packs";
            // 
            // lvcComboPack
            // 
            this.lvcComboPack.BackColor = System.Drawing.Color.White;
            this.lvcComboPack.Description = "Manage combo pack which user can choose";
            this.lvcComboPack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvcComboPack.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lvcComboPack.Location = new System.Drawing.Point(3, 3);
            this.lvcComboPack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvcComboPack.MsgBoxDelTitle = null;
            this.lvcComboPack.Name = "lvcComboPack";
            this.lvcComboPack.Size = new System.Drawing.Size(961, 520);
            this.lvcComboPack.TabIndex = 5;
            this.lvcComboPack.Title = "Combo Pack";
            this.lvcComboPack.RequestCreate += new System.EventHandler(this.lvcComboPack_RequestCreate);
            this.lvcComboPack.RequestDelete += new System.EventHandler(this.lvcComboPack_RequestDelete);
            this.lvcComboPack.RequestRefresh += new System.EventHandler(this.lvcComboPack_RequestRefresh);
            this.lvcComboPack.RequestEdit += new System.EventHandler(this.lvcComboPack_RequestEdit);
            // 
            // login1
            // 
            this.login1.BackColor = System.Drawing.Color.White;
            this.login1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.login1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.login1.Location = new System.Drawing.Point(0, 0);
            this.login1.MinimumSize = new System.Drawing.Size(467, 261);
            this.login1.Name = "login1";
            this.login1.Size = new System.Drawing.Size(975, 552);
            this.login1.SqlConnectionString = null;
            this.login1.TabIndex = 0;
            this.login1.LoginSuccessful += new System.EventHandler(this.login1_LoginSuccessful);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(975, 583);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.login1);
            this.Controls.Add(this.pnStatus);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Quán Gym Chuột";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnStatus.ResumeLayout(false);
            this.pnStatus.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPagePaymentHistory.ResumeLayout(false);
            this.tabPageUserInfo.ResumeLayout(false);
            this.tabPageComboPack.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Library.Controls.Login login1;
        private System.Windows.Forms.Panel pnStatus;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnChangePass;
        private System.ComponentModel.BackgroundWorker bwInitListView;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageComboPack;
        private Library.Controls.ListViewControl lvcComboPack;
        private System.Windows.Forms.TabPage tabPageUserInfo;
        private Library.Controls.ListViewControl lvcUserInfo;
        private System.Windows.Forms.TabPage tabPagePaymentHistory;
        private Library.Controls.ListViewControl lvcPaymentHistory;
    }
}
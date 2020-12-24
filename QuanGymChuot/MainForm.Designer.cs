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
            this.tabPagePaymentManager = new System.Windows.Forms.TabPage();
            this.tabPageUserInfo = new System.Windows.Forms.TabPage();
            this.tabPagePackInfo = new System.Windows.Forms.TabPage();
            this.lvcPaymentManager = new QuanGymChuot.Library.Controls.ListViewControl();
            this.lvcUserInfo = new QuanGymChuot.Library.Controls.ListViewControl();
            this.lvcPackManager = new QuanGymChuot.Library.Controls.ListViewControl();
            this.login1 = new QuanGymChuot.Library.Controls.Login();
            this.pnStatus.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPagePaymentManager.SuspendLayout();
            this.tabPageUserInfo.SuspendLayout();
            this.tabPagePackInfo.SuspendLayout();
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
            this.pnStatus.Size = new System.Drawing.Size(1062, 31);
            this.pnStatus.TabIndex = 2;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.Location = new System.Drawing.Point(981, 2);
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
            this.btnChangePass.Location = new System.Drawing.Point(783, 2);
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
            this.tabControl.Controls.Add(this.tabPagePaymentManager);
            this.tabControl.Controls.Add(this.tabPageUserInfo);
            this.tabControl.Controls.Add(this.tabPagePackInfo);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1062, 552);
            this.tabControl.TabIndex = 3;
            // 
            // tabPagePaymentManager
            // 
            this.tabPagePaymentManager.BackColor = System.Drawing.Color.White;
            this.tabPagePaymentManager.Controls.Add(this.lvcPaymentManager);
            this.tabPagePaymentManager.Location = new System.Drawing.Point(4, 26);
            this.tabPagePaymentManager.Name = "tabPagePaymentManager";
            this.tabPagePaymentManager.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePaymentManager.Size = new System.Drawing.Size(1054, 522);
            this.tabPagePaymentManager.TabIndex = 3;
            this.tabPagePaymentManager.Text = "Payment Manager";
            // 
            // tabPageUserInfo
            // 
            this.tabPageUserInfo.BackColor = System.Drawing.Color.White;
            this.tabPageUserInfo.Controls.Add(this.lvcUserInfo);
            this.tabPageUserInfo.Location = new System.Drawing.Point(4, 26);
            this.tabPageUserInfo.Name = "tabPageUserInfo";
            this.tabPageUserInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUserInfo.Size = new System.Drawing.Size(1054, 522);
            this.tabPageUserInfo.TabIndex = 2;
            this.tabPageUserInfo.Text = "User Information";
            // 
            // tabPagePackInfo
            // 
            this.tabPagePackInfo.BackColor = System.Drawing.Color.White;
            this.tabPagePackInfo.Controls.Add(this.lvcPackManager);
            this.tabPagePackInfo.Location = new System.Drawing.Point(4, 26);
            this.tabPagePackInfo.Name = "tabPagePackInfo";
            this.tabPagePackInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePackInfo.Size = new System.Drawing.Size(1054, 522);
            this.tabPagePackInfo.TabIndex = 1;
            this.tabPagePackInfo.Text = "Gym Package Manager";
            // 
            // lvcPaymentManager
            // 
            this.lvcPaymentManager.BackColor = System.Drawing.Color.White;
            this.lvcPaymentManager.Description = "Manage current payment and payment history";
            this.lvcPaymentManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvcPaymentManager.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lvcPaymentManager.Location = new System.Drawing.Point(3, 3);
            this.lvcPaymentManager.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvcPaymentManager.MsgBoxDelTitle = "Quán Gym Chuột";
            this.lvcPaymentManager.Name = "lvcPaymentManager";
            this.lvcPaymentManager.Size = new System.Drawing.Size(1048, 516);
            this.lvcPaymentManager.TabIndex = 4;
            this.lvcPaymentManager.Title = "Payment Manger";
            this.lvcPaymentManager.RequestCreate += new System.EventHandler(this.lvcPaymentManager_RequestCreate);
            this.lvcPaymentManager.RequestDelete += new System.EventHandler(this.lvcPaymentManager_RequestDelete);
            this.lvcPaymentManager.RequestRefresh += new System.EventHandler(this.lvcPaymentManager_RequestRefresh);
            this.lvcPaymentManager.RequestEdit += new System.EventHandler(this.lvcPaymentManager_RequestEdit);
            // 
            // lvcUserInfo
            // 
            this.lvcUserInfo.BackColor = System.Drawing.Color.White;
            this.lvcUserInfo.Description = "Manage information of users";
            this.lvcUserInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvcUserInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lvcUserInfo.Location = new System.Drawing.Point(3, 3);
            this.lvcUserInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvcUserInfo.MsgBoxDelTitle = "Quán Gym Chuột";
            this.lvcUserInfo.Name = "lvcUserInfo";
            this.lvcUserInfo.Size = new System.Drawing.Size(1048, 516);
            this.lvcUserInfo.TabIndex = 4;
            this.lvcUserInfo.Title = "User Information";
            this.lvcUserInfo.RequestCreate += new System.EventHandler(this.lvcUserInfo_RequestCreate);
            this.lvcUserInfo.RequestDelete += new System.EventHandler(this.lvcUserInfo_RequestDelete);
            this.lvcUserInfo.RequestRefresh += new System.EventHandler(this.lvcUserInfo_RequestRefresh);
            this.lvcUserInfo.RequestEdit += new System.EventHandler(this.lvcUserInfo_RequestEdit);
            // 
            // lvcPackManager
            // 
            this.lvcPackManager.BackColor = System.Drawing.Color.White;
            this.lvcPackManager.Description = "Manage gym package which user can choose";
            this.lvcPackManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvcPackManager.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lvcPackManager.Location = new System.Drawing.Point(3, 3);
            this.lvcPackManager.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvcPackManager.MsgBoxDelTitle = "Quán Gym Chuột";
            this.lvcPackManager.Name = "lvcPackManager";
            this.lvcPackManager.Size = new System.Drawing.Size(1048, 516);
            this.lvcPackManager.TabIndex = 5;
            this.lvcPackManager.Title = "Gym Package Manager";
            this.lvcPackManager.RequestCreate += new System.EventHandler(this.lvcComboPack_RequestCreate);
            this.lvcPackManager.RequestDelete += new System.EventHandler(this.lvcComboPack_RequestDelete);
            this.lvcPackManager.RequestRefresh += new System.EventHandler(this.lvcComboPack_RequestRefresh);
            this.lvcPackManager.RequestEdit += new System.EventHandler(this.lvcComboPack_RequestEdit);
            // 
            // login1
            // 
            this.login1.BackColor = System.Drawing.Color.White;
            this.login1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.login1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.login1.Location = new System.Drawing.Point(0, 0);
            this.login1.MinimumSize = new System.Drawing.Size(467, 261);
            this.login1.Name = "login1";
            this.login1.Size = new System.Drawing.Size(1062, 552);
            this.login1.SqlConnectionString = null;
            this.login1.TabIndex = 0;
            this.login1.LoginSuccessful += new System.EventHandler(this.login1_LoginSuccessful);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1062, 583);
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
            this.tabPagePaymentManager.ResumeLayout(false);
            this.tabPageUserInfo.ResumeLayout(false);
            this.tabPagePackInfo.ResumeLayout(false);
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
        private System.Windows.Forms.TabPage tabPagePackInfo;
        private Library.Controls.ListViewControl lvcPackManager;
        private System.Windows.Forms.TabPage tabPageUserInfo;
        private Library.Controls.ListViewControl lvcUserInfo;
        private System.Windows.Forms.TabPage tabPagePaymentManager;
        private Library.Controls.ListViewControl lvcPaymentManager;
    }
}
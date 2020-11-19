namespace QuanGymChuot.Library.Controls
{
    partial class Login
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
            this.lbUser = new System.Windows.Forms.Label();
            this.lbPass = new System.Windows.Forms.Label();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.gbLoginArea = new System.Windows.Forms.GroupBox();
            this.cbShowPass = new System.Windows.Forms.CheckBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.pbLoading = new System.Windows.Forms.ProgressBar();
            this.lbStatus = new System.Windows.Forms.Label();
            this.bwServerCheck = new System.ComponentModel.BackgroundWorker();
            this.bwLoginProcess = new System.ComponentModel.BackgroundWorker();
            this.pnMain = new System.Windows.Forms.Panel();
            this.gbLoginArea.SuspendLayout();
            this.pnMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbUser
            // 
            this.lbUser.AutoSize = true;
            this.lbUser.Location = new System.Drawing.Point(32, 40);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(77, 19);
            this.lbUser.TabIndex = 0;
            this.lbUser.Text = "User Name";
            // 
            // lbPass
            // 
            this.lbPass.AutoSize = true;
            this.lbPass.Location = new System.Drawing.Point(32, 71);
            this.lbPass.Name = "lbPass";
            this.lbPass.Size = new System.Drawing.Size(67, 19);
            this.lbPass.TabIndex = 0;
            this.lbPass.Text = "Password";
            // 
            // tbUser
            // 
            this.tbUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUser.Location = new System.Drawing.Point(115, 37);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(300, 25);
            this.tbUser.TabIndex = 1;
            this.tbUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbLogin_KeyDown);
            // 
            // tbPass
            // 
            this.tbPass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPass.Location = new System.Drawing.Point(115, 68);
            this.tbPass.Name = "tbPass";
            this.tbPass.Size = new System.Drawing.Size(300, 25);
            this.tbPass.TabIndex = 1;
            this.tbPass.UseSystemPasswordChar = true;
            this.tbPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbLogin_KeyDown);
            // 
            // gbLoginArea
            // 
            this.gbLoginArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbLoginArea.Controls.Add(this.cbShowPass);
            this.gbLoginArea.Controls.Add(this.btnLogin);
            this.gbLoginArea.Controls.Add(this.tbUser);
            this.gbLoginArea.Controls.Add(this.tbPass);
            this.gbLoginArea.Controls.Add(this.lbUser);
            this.gbLoginArea.Controls.Add(this.lbPass);
            this.gbLoginArea.Location = new System.Drawing.Point(3, 4);
            this.gbLoginArea.Name = "gbLoginArea";
            this.gbLoginArea.Size = new System.Drawing.Size(461, 172);
            this.gbLoginArea.TabIndex = 2;
            this.gbLoginArea.TabStop = false;
            this.gbLoginArea.Text = "Login";
            // 
            // cbShowPass
            // 
            this.cbShowPass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbShowPass.AutoSize = true;
            this.cbShowPass.Location = new System.Drawing.Point(300, 99);
            this.cbShowPass.Name = "cbShowPass";
            this.cbShowPass.Size = new System.Drawing.Size(123, 23);
            this.cbShowPass.TabIndex = 3;
            this.cbShowPass.Text = "Show Password";
            this.cbShowPass.UseVisualStyleBackColor = true;
            this.cbShowPass.CheckedChanged += new System.EventHandler(this.cbShowPass_CheckedChanged);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(156, 128);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(144, 34);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // pbLoading
            // 
            this.pbLoading.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLoading.Enabled = false;
            this.pbLoading.Location = new System.Drawing.Point(3, 182);
            this.pbLoading.MarqueeAnimationSpeed = 20;
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.Size = new System.Drawing.Size(461, 10);
            this.pbLoading.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbLoading.TabIndex = 3;
            // 
            // lbStatus
            // 
            this.lbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbStatus.Location = new System.Drawing.Point(3, 197);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(461, 60);
            this.lbStatus.TabIndex = 4;
            this.lbStatus.Text = "Line 1\r\nLine 2\r\nLine 3";
            this.lbStatus.Click += new System.EventHandler(this.lbStatus_Click);
            // 
            // bwServerCheck
            // 
            this.bwServerCheck.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwServerCheck_DoWork);
            this.bwServerCheck.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwServerCheck_RunWorkerCompleted);
            // 
            // bwLoginProcess
            // 
            this.bwLoginProcess.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwLoginProcess_DoWork);
            this.bwLoginProcess.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwLoginProcess_RunWorkerCompleted);
            // 
            // pnMain
            // 
            this.pnMain.Controls.Add(this.gbLoginArea);
            this.pnMain.Controls.Add(this.lbStatus);
            this.pnMain.Controls.Add(this.pbLoading);
            this.pnMain.Location = new System.Drawing.Point(0, 0);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(467, 261);
            this.pnMain.TabIndex = 5;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnMain);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(467, 261);
            this.Name = "Login";
            this.Size = new System.Drawing.Size(467, 261);
            this.Load += new System.EventHandler(this.Login_Load);
            this.SizeChanged += new System.EventHandler(this.Login_SizeChanged);
            this.gbLoginArea.ResumeLayout(false);
            this.gbLoginArea.PerformLayout();
            this.pnMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbUser;
        private System.Windows.Forms.Label lbPass;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.GroupBox gbLoginArea;
        private System.Windows.Forms.CheckBox cbShowPass;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.ProgressBar pbLoading;
        private System.Windows.Forms.Label lbStatus;
        private System.ComponentModel.BackgroundWorker bwServerCheck;
        private System.ComponentModel.BackgroundWorker bwLoginProcess;
        private System.Windows.Forms.Panel pnMain;
    }
}

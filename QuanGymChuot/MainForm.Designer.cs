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
            this.lvComboPack = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvUserInfo = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvUserPurPack = new System.Windows.Forms.ListView();
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnStatus = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lbStatus = new System.Windows.Forms.Label();
            this.btnChangePass = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageComboPack = new System.Windows.Forms.TabPage();
            this.btnCPDelete = new System.Windows.Forms.Button();
            this.btnCPEdit = new System.Windows.Forms.Button();
            this.btnCPNew = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageUserInfo = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPageUserPurPack = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnTabUserPurchasedPack = new System.Windows.Forms.Button();
            this.btnTabUserInfo = new System.Windows.Forms.Button();
            this.btnTabComboPack = new System.Windows.Forms.Button();
            this.bwInitListView = new System.ComponentModel.BackgroundWorker();
            this.login1 = new QuanGymChuot.Library.Controls.Login();
            this.pnStatus.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageComboPack.SuspendLayout();
            this.tabPageUserInfo.SuspendLayout();
            this.tabPageUserPurPack.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvComboPack
            // 
            this.lvComboPack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvComboPack.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader13,
            this.columnHeader5,
            this.columnHeader4});
            this.lvComboPack.FullRowSelect = true;
            this.lvComboPack.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvComboPack.HideSelection = false;
            this.lvComboPack.Location = new System.Drawing.Point(6, 71);
            this.lvComboPack.Name = "lvComboPack";
            this.lvComboPack.Size = new System.Drawing.Size(760, 430);
            this.lvComboPack.TabIndex = 1;
            this.lvComboPack.UseCompatibleStateImageBehavior = false;
            this.lvComboPack.View = System.Windows.Forms.View.Details;
            this.lvComboPack.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvComboPack_ItemSelectionChanged);
            this.lvComboPack.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvComboPack_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader1.Width = 43;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Package Name";
            this.columnHeader2.Width = 147;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Package Price";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 115;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Package Count";
            this.columnHeader13.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader13.Width = 98;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Can Be Used";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 87;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Package Info";
            this.columnHeader4.Width = 243;
            // 
            // lvUserInfo
            // 
            this.lvUserInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvUserInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.lvUserInfo.FullRowSelect = true;
            this.lvUserInfo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvUserInfo.HideSelection = false;
            this.lvUserInfo.Location = new System.Drawing.Point(6, 71);
            this.lvUserInfo.Name = "lvUserInfo";
            this.lvUserInfo.Size = new System.Drawing.Size(760, 466);
            this.lvUserInfo.TabIndex = 1;
            this.lvUserInfo.UseCompatibleStateImageBehavior = false;
            this.lvUserInfo.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "ID";
            this.columnHeader6.Width = 47;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Name";
            this.columnHeader7.Width = 388;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Gender";
            this.columnHeader8.Width = 62;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Phone";
            this.columnHeader9.Width = 91;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Registration Date";
            this.columnHeader10.Width = 140;
            // 
            // lvUserPurPack
            // 
            this.lvUserPurPack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvUserPurPack.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16});
            this.lvUserPurPack.FullRowSelect = true;
            this.lvUserPurPack.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvUserPurPack.HideSelection = false;
            this.lvUserPurPack.Location = new System.Drawing.Point(6, 71);
            this.lvUserPurPack.Name = "lvUserPurPack";
            this.lvUserPurPack.Size = new System.Drawing.Size(760, 466);
            this.lvUserPurPack.TabIndex = 1;
            this.lvUserPurPack.UseCompatibleStateImageBehavior = false;
            this.lvUserPurPack.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "ID";
            this.columnHeader11.Width = 55;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "User Name";
            this.columnHeader12.Width = 191;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Purchased Package Name";
            this.columnHeader14.Width = 169;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Purchased Package Date";
            this.columnHeader15.Width = 160;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Expired in";
            this.columnHeader16.Width = 160;
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
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl.Controls.Add(this.tabPageComboPack);
            this.tabControl.Controls.Add(this.tabPageUserInfo);
            this.tabControl.Controls.Add(this.tabPageUserPurPack);
            this.tabControl.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControl.Location = new System.Drawing.Point(195, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(780, 552);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 3;
            this.tabControl.TabStop = false;
            // 
            // tabPageComboPack
            // 
            this.tabPageComboPack.BackColor = System.Drawing.Color.White;
            this.tabPageComboPack.Controls.Add(this.btnCPDelete);
            this.tabPageComboPack.Controls.Add(this.btnCPEdit);
            this.tabPageComboPack.Controls.Add(this.btnCPNew);
            this.tabPageComboPack.Controls.Add(this.label6);
            this.tabPageComboPack.Controls.Add(this.label1);
            this.tabPageComboPack.Controls.Add(this.lvComboPack);
            this.tabPageComboPack.Location = new System.Drawing.Point(4, 5);
            this.tabPageComboPack.Name = "tabPageComboPack";
            this.tabPageComboPack.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageComboPack.Size = new System.Drawing.Size(772, 543);
            this.tabPageComboPack.TabIndex = 1;
            this.tabPageComboPack.Text = "ComboPack";
            // 
            // btnCPDelete
            // 
            this.btnCPDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCPDelete.Enabled = false;
            this.btnCPDelete.Location = new System.Drawing.Point(675, 507);
            this.btnCPDelete.Name = "btnCPDelete";
            this.btnCPDelete.Size = new System.Drawing.Size(89, 30);
            this.btnCPDelete.TabIndex = 4;
            this.btnCPDelete.Text = "Delete";
            this.btnCPDelete.UseVisualStyleBackColor = true;
            this.btnCPDelete.Click += new System.EventHandler(this.btnCPDelete_Click);
            // 
            // btnCPEdit
            // 
            this.btnCPEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCPEdit.Enabled = false;
            this.btnCPEdit.Location = new System.Drawing.Point(580, 507);
            this.btnCPEdit.Name = "btnCPEdit";
            this.btnCPEdit.Size = new System.Drawing.Size(89, 30);
            this.btnCPEdit.TabIndex = 4;
            this.btnCPEdit.Text = "Edit";
            this.btnCPEdit.UseVisualStyleBackColor = true;
            this.btnCPEdit.Click += new System.EventHandler(this.btnCPEdit_Click);
            // 
            // btnCPNew
            // 
            this.btnCPNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCPNew.Location = new System.Drawing.Point(465, 507);
            this.btnCPNew.Name = "btnCPNew";
            this.btnCPNew.Size = new System.Drawing.Size(109, 30);
            this.btnCPNew.TabIndex = 4;
            this.btnCPNew.Text = "Create New...";
            this.btnCPNew.UseVisualStyleBackColor = true;
            this.btnCPNew.Click += new System.EventHandler(this.btnCPNew_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.label6.Location = new System.Drawing.Point(8, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(398, 28);
            this.label6.TabIndex = 3;
            this.label6.Text = "Manage combo pack which user can choose.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "Combo Packs";
            // 
            // tabPageUserInfo
            // 
            this.tabPageUserInfo.BackColor = System.Drawing.Color.White;
            this.tabPageUserInfo.Controls.Add(this.label5);
            this.tabPageUserInfo.Controls.Add(this.label2);
            this.tabPageUserInfo.Controls.Add(this.lvUserInfo);
            this.tabPageUserInfo.Location = new System.Drawing.Point(4, 5);
            this.tabPageUserInfo.Name = "tabPageUserInfo";
            this.tabPageUserInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUserInfo.Size = new System.Drawing.Size(772, 543);
            this.tabPageUserInfo.TabIndex = 2;
            this.tabPageUserInfo.Text = "UserInfo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.label5.Location = new System.Drawing.Point(8, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(267, 28);
            this.label5.TabIndex = 3;
            this.label5.Text = "Manage information of users.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 37);
            this.label2.TabIndex = 2;
            this.label2.Text = "User Information";
            // 
            // tabPageUserPurPack
            // 
            this.tabPageUserPurPack.BackColor = System.Drawing.Color.White;
            this.tabPageUserPurPack.Controls.Add(this.label4);
            this.tabPageUserPurPack.Controls.Add(this.label3);
            this.tabPageUserPurPack.Controls.Add(this.lvUserPurPack);
            this.tabPageUserPurPack.Location = new System.Drawing.Point(4, 5);
            this.tabPageUserPurPack.Name = "tabPageUserPurPack";
            this.tabPageUserPurPack.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUserPurPack.Size = new System.Drawing.Size(772, 543);
            this.tabPageUserPurPack.TabIndex = 3;
            this.tabPageUserPurPack.Text = "UserPurchasedPack";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.label4.Location = new System.Drawing.Point(8, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(366, 28);
            this.label4.TabIndex = 3;
            this.label4.Text = "Manage packs which user has purchased.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.label3.Location = new System.Drawing.Point(6, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(258, 37);
            this.label3.TabIndex = 2;
            this.label3.Text = "User Purchased Pack";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnTabUserPurchasedPack);
            this.panel2.Controls.Add(this.btnTabUserInfo);
            this.panel2.Controls.Add(this.btnTabComboPack);
            this.panel2.Controls.Add(this.tabControl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(975, 552);
            this.panel2.TabIndex = 4;
            // 
            // btnTabUserPurchasedPack
            // 
            this.btnTabUserPurchasedPack.Location = new System.Drawing.Point(0, 0);
            this.btnTabUserPurchasedPack.Name = "btnTabUserPurchasedPack";
            this.btnTabUserPurchasedPack.Size = new System.Drawing.Size(195, 42);
            this.btnTabUserPurchasedPack.TabIndex = 4;
            this.btnTabUserPurchasedPack.Text = "User Purchased Pack Tab";
            this.btnTabUserPurchasedPack.UseVisualStyleBackColor = true;
            this.btnTabUserPurchasedPack.Click += new System.EventHandler(this.btnTabUserPurchasedPack_Click);
            // 
            // btnTabUserInfo
            // 
            this.btnTabUserInfo.Location = new System.Drawing.Point(0, 48);
            this.btnTabUserInfo.Name = "btnTabUserInfo";
            this.btnTabUserInfo.Size = new System.Drawing.Size(195, 42);
            this.btnTabUserInfo.TabIndex = 4;
            this.btnTabUserInfo.Text = "User Information Tab";
            this.btnTabUserInfo.UseVisualStyleBackColor = true;
            this.btnTabUserInfo.Click += new System.EventHandler(this.btnTabUserInfo_Click);
            // 
            // btnTabComboPack
            // 
            this.btnTabComboPack.Location = new System.Drawing.Point(0, 96);
            this.btnTabComboPack.Name = "btnTabComboPack";
            this.btnTabComboPack.Size = new System.Drawing.Size(195, 42);
            this.btnTabComboPack.TabIndex = 4;
            this.btnTabComboPack.Text = "Combo Packs Tab";
            this.btnTabComboPack.UseVisualStyleBackColor = true;
            this.btnTabComboPack.Click += new System.EventHandler(this.btnTabComboPack_Click);
            // 
            // bwInitListView
            // 
            this.bwInitListView.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwInitListView_DoWork);
            this.bwInitListView.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwInitListView_RunWorkerCompleted);
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
            this.Controls.Add(this.panel2);
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
            this.tabPageComboPack.ResumeLayout(false);
            this.tabPageComboPack.PerformLayout();
            this.tabPageUserInfo.ResumeLayout(false);
            this.tabPageUserInfo.PerformLayout();
            this.tabPageUserPurPack.ResumeLayout(false);
            this.tabPageUserPurPack.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Library.Controls.Login login1;
        private System.Windows.Forms.ListView lvComboPack;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ListView lvUserInfo;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ListView lvUserPurPack;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.Panel pnStatus;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageComboPack;
        private System.Windows.Forms.TabPage tabPageUserInfo;
        private System.Windows.Forms.TabPage tabPageUserPurPack;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnChangePass;
        private System.Windows.Forms.Button btnTabUserPurchasedPack;
        private System.Windows.Forms.Button btnTabUserInfo;
        private System.Windows.Forms.Button btnTabComboPack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCPNew;
        private System.ComponentModel.BackgroundWorker bwInitListView;
        private System.Windows.Forms.Button btnCPEdit;
        private System.Windows.Forms.Button btnCPDelete;
    }
}
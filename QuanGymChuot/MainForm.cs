using QuanGymChuot.Library.Controls;
using QuanGymChuot.Library.SqlServer;
using QuanGymChuot.Library.SqlServer.DataFromTable;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace QuanGymChuot
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Mau Connection string mac dinh.
        /// </summary>
        readonly string ConnectionString = "Data Source={0};Initial Catalog={1};Integrated Security=True";

        /// <summary>
        /// Tieu de mac dinh.
        /// </summary>
        readonly string DefaultTitle = "Quán Gym Chuột";

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ket noi den server truoc khi dang nhap.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Doi ten tieu de.
            ChangeTitleUserLoggedIn("Login");
            // Hien va dua control dang nhap len truoc.
            login1.BringToFront();
            login1.Show();
            // Gan Connection String - No se tim tu dong nen khong can phai thay doi gi ca.
            login1.SqlConnectionString = String.Format(this.ConnectionString, System.Environment.MachineName, "QuanGymChuot");
            // Ket noi den server de dang nhap.
            login1.ConnectServer();
            // Dat van ban trang thai.
            ChangeStatusPanel(false, "Login using your account to continue.");
        }

        /// <summary>
        /// Hanh dong sau khi dang nhap thanh cong.
        /// </summary>
        private void login1_LoginSuccessful(object sender, EventArgs e)
        {
            bwInitListView.RunWorkerAsync();
            // Hien thi tab trong tabcontrol la UserPurchasedPack
            tabControl.SelectedIndex = 2;
        }

        /// <summary>
        /// Ham nay se lay du lieu SQL Server duoi nen (khong bi loi Form).
        /// </summary>
        private void bwInitListView_DoWork(object sender, DoWorkEventArgs e)
        { LoadDataFromSQLServer(); }

        /// <summary>
        /// Ham nay se chay sau khi lay du lieu tu SQL Server.
        /// </summary>
        private void bwInitListView_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // TODO: COMMENT HERE!
            ChangeStatusPanel(true, String.Format("Logged in as {0}!", Account.CurrentAccount.UserName));
            // An control dang nhap.
            login1.Hide();
            // Xoa toan bo thong tin o control dang nhap.
            login1.ClearPassword();

            // TODO: COMMENT HERE!
            ChangeTitleUserLoggedIn("Logged in as " + Account.CurrentAccount.UserName);
        }

        /// <summary>
        /// Lay du lieu tu SQL Server.
        /// </summary>
        private void LoadDataFromSQLServer()
        {
            ClearListViewData();
            LoadDataFromUserInfo();
            LoadDataFromUserPurchasedPack();
            LoadDataFromComboPackNew();
        }

        /// <summary>
        /// Lay du lieu tu bang ComboPack.
        /// </summary>
        private void LoadDataFromComboPackNew()
        {
            if (tabPageComboPack.InvokeRequired) tabPageComboPack.Invoke((MethodInvoker)delegate { LoadDataFromComboPackNew(); });
            else
            {
                lvcComboPack.ClearAll();
                lvcComboPack.ListView.Columns.Add("ID", 48);
                lvcComboPack.ListView.Columns.Add("Name", 140);
                lvcComboPack.ListView.Columns.Add("Price (VND)", 86);
                lvcComboPack.ListView.Columns.Add("Days", 64);
                lvcComboPack.ListView.Columns.Add("Can used?", 72);
                lvcComboPack.ListView.Columns.Add("Info", 294);

                foreach (ComboPack.ComboPackItem cpitem in ComboPack.GetAll())
                {
                    string[] s = new string[]
                    {
                        cpitem.ID.ToString(),
                        cpitem.Name,
                        cpitem.Price.ToString(),
                        cpitem.DayCount.ToString(),
                        cpitem.CanUse ? "Yes" : "No",
                        cpitem.Info != null ? cpitem.Info : "(no information)"
                    };
                    lvcComboPack.ListView.Items.Add(new ListViewItem(s));
                }
            }
        }

        /// <summary>
        /// Lay du lieu tai bang UserInfo.
        /// </summary>
        private void LoadDataFromUserInfo()
        {
            if (lvUserInfo.InvokeRequired) lvUserInfo.Invoke((MethodInvoker)delegate { LoadDataFromUserInfo(); });
            else foreach (UserInfo.UserInfoItem uiitem in UserInfo.GetAll())
                {
                    string[] s = new string[]
                    {
                        uiitem.ID.ToString(),
                        uiitem.Name,
                        uiitem.Gender ? "Male" : "Female",
                        uiitem.Phone,
                        uiitem.RegDate.ToString()
                    };
                    lvUserInfo.Items.Add(new ListViewItem(s));
                }
        }

        /// <summary>
        /// Lay du lieu tai bang UserPurchasedPack.
        /// </summary>
        private void LoadDataFromUserPurchasedPack()
        {
            if (lvUserPurPack.InvokeRequired) lvUserPurPack.Invoke((MethodInvoker)delegate { LoadDataFromUserPurchasedPack(); });
            else foreach (UserPurchasedPack.UserPurchasedItem upiitem in UserPurchasedPack.GetAll())
                {
                    string[] s = new string[]
                    {
                    upiitem.ID.ToString(),
                    upiitem.UserName,
                    upiitem.PackageName,
                    upiitem.PackageRegDate.ToString(),
                    upiitem.PackageExpDate.ToString()
                    };
                    lvUserPurPack.Items.Add(new ListViewItem(s));
                }
        }

        /// <summary>
        /// Xoa du lieu hien thi trong listview.
        /// </summary>
        private void ClearListViewData()
        {
            if (tabControl.InvokeRequired) tabControl.Invoke((MethodInvoker)delegate { ClearListViewData(); });
            else
            {
                lvUserInfo.Items.Clear();
                lvUserPurPack.Items.Clear();
                lvcComboPack.ClearAllItems();
            }
        }

        /// <summary>
        /// Thay doi tieu de phan mem voi ten dang nhap.
        /// </summary>
        /// <param name="s">Ten dang nhap</param>
        private void ChangeTitleUserLoggedIn(string s = null)
        {
            if (this.InvokeRequired) this.Invoke((MethodInvoker)delegate { ChangeTitleUserLoggedIn(s); });
            else
            {
                if (s == null)
                    this.Text = DefaultTitle;
                else
                    this.Text = String.Format("{0} - {1}", DefaultTitle, s);
            }
        }

        /// <summary>
        /// Thay doi hien thi cua thanh trang thai (o duoi cung).
        /// </summary>
        /// <param name="btnEnabled">Bat/tat nut lien quan den tai khoan.</param>
        /// <param name="lbStatusText">Thay doi van ban.</param>
        private void ChangeStatusPanel(bool btnEnabled, string lbStatusText)
        {
            if (pnStatus.InvokeRequired) pnStatus.Invoke((MethodInvoker)delegate { ChangeStatusPanel(btnEnabled, lbStatusText); });
            else
            {
                btnChangePass.Visible = btnEnabled;
                btnLogout.Visible = btnEnabled;
                lbStatus.Text = lbStatusText;
            }
        }

        /// <summary>
        /// Hanh dong sau khi dong cua so chuong trinh.
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Ngat ket noi khoi SQL Server khi thoat chuong trinh.
            Connection.Disconnect();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Dang xuat khoi he thong.
            Account.LogOut();
            // Xoa du lieu tren listview
            ClearListViewData();
            // Hien lai control dang nhap
            Connection.Disconnect();
            // Ket noi lai den server de dang nhap.
            ChangeTitleUserLoggedIn("Login");
            MainForm_Load(this, new EventArgs());
        }

        private void btnTabUserPurchasedPack_Click(object sender, EventArgs e)
        { tabControl.SelectedIndex = 2; }

        private void btnTabUserInfo_Click(object sender, EventArgs e)
        { tabControl.SelectedIndex = 1; }

        private void btnTabComboPack_Click(object sender, EventArgs e)
        { tabControl.SelectedIndex = 0; }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            Form_ChangePass form = new Form_ChangePass(Account.CurrentAccount.UserName);
            form.Top = this.Top + (this.Height / 2 - form.Height / 2);
            form.Left = this.Left + (this.Width / 2 - form.Width / 2);
            form.ShowDialog();
        }

        #region ComboPack
        private void lvcComboPack_RequestCreate(object sender, EventArgs e)
        {
            Form_ComboPack form = new Form_ComboPack();
            form.CreateMode = true;
            form.Top = this.Top + (this.Height / 2 - form.Height / 2);
            form.Left = this.Left + (this.Width / 2 - form.Width / 2);
            form.ShowDialog();

            bwInitListView.RunWorkerAsync();
        }

        private void lvcComboPack_RequestDelete(object sender, EventArgs e)
        {
            ListViewControl lv = (ListViewControl)sender;
            for (int i = 0; i < lv.SelectedItemCount; i++)
            {
                long ID;
                long.TryParse(lv.ListView.SelectedItems[i].Text, out ID);
                ComboPack.DeleteObject(ID);
            }

            bwInitListView.RunWorkerAsync();
        }

        private void lvcComboPack_RequestEdit(object sender, EventArgs e)
        {
            Form_ComboPack form = new Form_ComboPack();
            form.CreateMode = false;
            int.TryParse(lvcComboPack.ListView.SelectedItems[0].Text, out int idTemp);
            form.ID = idTemp;
            form.Top = this.Top + (this.Height / 2 - form.Height / 2);
            form.Left = this.Left + (this.Width / 2 - form.Width / 2);
            form.ShowDialog();

            bwInitListView.RunWorkerAsync();
        }

        private void lvcComboPack_RequestRefresh(object sender, EventArgs e)
        {
            lvcComboPack.ClearAll();
            LoadDataFromComboPackNew();
        }
        #endregion
    }
}

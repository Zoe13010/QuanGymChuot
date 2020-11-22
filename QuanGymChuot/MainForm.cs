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
        /// Mẫu Connection String mặc định.
        /// </summary>
        readonly string ConnectionString = "Data Source=tcp:{0}, 1433;Initial Catalog={1};Integrated Security=True";

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event Load khi Form hiển thị.
        /// Kết nối đến server trước khi đăng nhập.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Hiển thị và đưa Control đăng nhập lên trước.
            login1.BringToFront();
            login1.Show();
            // Gán Connection String - nó sẽ tìm tự động. Nếu không tìm được, hãy sửa nó bằng tay tại đây.
            login1.SqlConnectionString = String.Format(this.ConnectionString, System.Environment.MachineName, "QuanGymChuot");
            // Kết nối đến server và focus Control.
            login1.ConnectServer();
            login1.Focus();
            // Thay đổi hiển thị trạng thái.
            ChangePanelAccount(false, "Login using your account to continue.");
        }

        /// <summary>
        /// Event khi đăng nhập thành công.
        /// Hiện ra menu chính.
        /// </summary>
        private void login1_LoginSuccessful(object sender, EventArgs e)
        {
            bwInitListView.RunWorkerAsync();
            // Hiển thị ListViewControl UserPurchasedPack lên trước.
            tabControl.SelectedIndex = 0;
        }

        /// <summary>
        /// Event khi bắt đầu Background Worker.
        /// Lấy dữ liệu toàn bộ bảng trong Database QuanGymChuot.
        /// </summary>
        private void bwInitListView_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadDataFromComboPackNew();
            LoadDataFromUserInfoNew();
            LoadDataFromUserPurchasedPackNew();
        }

        /// <summary>
        /// Event khi chạy xong Background Worker.
        /// Sau khi lấy toàn bộ dữ liệu của Database QuanGymChuot.
        /// </summary>
        private void bwInitListView_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // TODO: COMMENT HERE!
            ChangePanelAccount(true, String.Format("Logged in as {0}!", Account.CurrentAccount.UserName));
            // Ẩn Control đăng nhập.
            login1.Hide();
            // Xóa mật khẩu của Control đăng nhập.
            login1.ClearPassword();
        }

        /// <summary>
        /// Lấy dữ liệu từ bảng ComboPack.
        /// </summary>
        private void LoadDataFromComboPackNew()
        {
            if (tabPageComboPack.InvokeRequired) tabPageComboPack.Invoke((MethodInvoker)delegate { LoadDataFromComboPackNew(); });
            else
            {
                lvcComboPack.ClearAll();
                lvcComboPack.ListView.Columns.Add("ID", 48);
                lvcComboPack.ListView.Columns.Add("Name", 182);
                lvcComboPack.ListView.Columns.Add("Price (VND)", 86);
                lvcComboPack.ListView.Columns.Add("Days", 64);
                lvcComboPack.ListView.Columns.Add("Can use?", 72);
                lvcComboPack.ListView.Columns.Add("Added Date", 156);
                lvcComboPack.ListView.Columns.Add("Info", 284);

                foreach (ComboPack.ComboPackItem cpitem in ComboPack.GetAll())
                {
                    string[] s = new string[]
                    {
                        cpitem.ID.ToString(),
                        cpitem.Name,
                        cpitem.Price.ToString(),
                        cpitem.DayCount.ToString(),
                        cpitem.CanUse ? "Yes" : "No",
                        cpitem.AddedDate.ToString(),
                        cpitem.Info != null ? cpitem.Info : "(no information)"
                    };
                    lvcComboPack.ListView.Items.Add(new ListViewItem(s));
                }
            }
        }

        /// <summary>
        /// Lấy dữ liệu từ bảng UserInfo.
        /// </summary>
        private void LoadDataFromUserInfoNew()
        {
            if (lvcUserInfo.InvokeRequired) lvcUserInfo.Invoke((MethodInvoker)delegate { LoadDataFromUserInfoNew(); });
            else
            {
                lvcUserInfo.ClearAll();
                lvcUserInfo.ListView.Columns.Add("ID", 48);
                lvcUserInfo.ListView.Columns.Add("Name", 518);
                lvcUserInfo.ListView.Columns.Add("Gender", 70);
                lvcUserInfo.ListView.Columns.Add("Phone", 100);
                lvcUserInfo.ListView.Columns.Add("Registration Date", 156);

                foreach (UserInfo.UserInfoItem uiitem in UserInfo.GetAll())
                {
                    string[] s = new string[]
                    {
                        uiitem.ID.ToString(),
                        uiitem.Name,
                        uiitem.Gender ? "Male" : "Female",
                        uiitem.Phone,
                        uiitem.RegDate.ToString()
                    };
                    lvcUserInfo.ListView.Items.Add(new ListViewItem(s));
                }
            }
        }

        /// <summary>
        /// Lấy dữ liệu từ bảng UserPurchasedPack.
        /// </summary>
        private void LoadDataFromUserPurchasedPackNew()
        {
            if (lvcUserPurPack.InvokeRequired) lvcUserPurPack.Invoke((MethodInvoker)delegate { LoadDataFromUserPurchasedPackNew(); });
            else
            {
                lvcUserPurPack.ClearAll();
                lvcUserPurPack.ListView.Columns.Add("ID", 48);
                lvcUserPurPack.ListView.Columns.Add("User Name", 318);
                lvcUserPurPack.ListView.Columns.Add("Package Name", 214);
                lvcUserPurPack.ListView.Columns.Add("Purchased Date", 156);
                lvcUserPurPack.ListView.Columns.Add("Expired in", 156);

                foreach (UserPurchasedPack.UserPurchasedPackItem upiitem in UserPurchasedPack.GetAll())
                {
                    string[] s = new string[]
                    {
                        upiitem.ID.ToString(),
                        upiitem.UserName,
                        upiitem.PackageName,
                        upiitem.PackageRegDate.ToString(),
                        upiitem.PackageExpDate.ToString()
                    };
                    lvcUserPurPack.ListView.Items.Add(new ListViewItem(s));
                }
            }
        }

        /// <summary>
        /// Thay đổi hiển thị của panel Tài khoản.
        /// </summary>
        /// <param name="btnEnabled">Bật/Tắt nút.</param>
        /// <param name="lbStatusText">Văn bản cần đổi.</param>
        private void ChangePanelAccount(bool btnEnabled, string lbStatusText)
        {
            if (pnStatus.InvokeRequired) pnStatus.Invoke((MethodInvoker)delegate { ChangePanelAccount(btnEnabled, lbStatusText); });
            else
            {
                btnChangePass.Visible = btnEnabled;
                btnLogout.Visible = btnEnabled;
                lbStatus.Text = lbStatusText;
            }
        }

        /// <summary>
        /// Event khi đóng Form.
        /// Ngắt kết nối khỏi SQL Server trước khi thoát chương trình.
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Connection.Disconnect();
        }

        #region Account Panel
        private void btnChangePass_Click(object sender, EventArgs e)
        {
            Form_ChangePass form = new Form_ChangePass(Account.CurrentAccount.UserName);
            form.Top = this.Top + (this.Height / 2 - form.Height / 2);
            form.Left = this.Left + (this.Width / 2 - form.Width / 2);
            form.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Đăng xuất tài khoản khỏi hệ thống.
            Account.LogOut();
            // Ngắt kết nối hiện tại.
            Connection.Disconnect();
            // Xóa toàn bộ dữ liệu trên ListView.
            lvcComboPack.ClearAll();
            lvcUserInfo.ClearAll();
            lvcUserPurPack.ClearAll();
            // Kết nối lại đến server để đăng nhập.
            MainForm_Load(this, new EventArgs());
        }
        #endregion

        #region Combo Packs panel
        private void lvcComboPack_RequestCreate(object sender, EventArgs e)
        {
            Form_ComboPack form = new Form_ComboPack();
            form.CreateMode = true;
            form.Top = this.Top + (this.Height / 2 - form.Height / 2);
            form.Left = this.Left + (this.Width / 2 - form.Width / 2);
            
            if (form.ShowDialog() == DialogResult.OK)
                bwInitListView.RunWorkerAsync();
            else lvcComboPack.ListView.Focus();
        }

        private void lvcComboPack_RequestEdit(object sender, EventArgs e)
        {
            Form_ComboPack form = new Form_ComboPack();
            form.CreateMode = false;
            int idTemp;
            int.TryParse(lvcComboPack.ListView.SelectedItems[0].Text, out idTemp);
            form.ID = idTemp;
            form.Top = this.Top + (this.Height / 2 - form.Height / 2);
            form.Left = this.Left + (this.Width / 2 - form.Width / 2);

            if (form.ShowDialog() == DialogResult.OK)
                bwInitListView.RunWorkerAsync();
            else lvcComboPack.ListView.Focus();
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

        private void lvcComboPack_RequestRefresh(object sender, EventArgs e)
        {
            lvcComboPack.ClearAll();
            LoadDataFromComboPackNew();
        }
        #endregion

        #region User Information panel
        private void lvcUserInfo_RequestRefresh(object sender, EventArgs e)
        {
            lvcUserInfo.ClearAll();
            LoadDataFromUserInfoNew();
        }

        private void lvcUserInfo_RequestCreate(object sender, EventArgs e)
        {
            Form_UserInfo form = new Form_UserInfo();
            form.CreateMode = true;
            form.Top = this.Top + (this.Height / 2 - form.Height / 2);
            form.Left = this.Left + (this.Width / 2 - form.Width / 2);

            if (form.ShowDialog() == DialogResult.OK)
                bwInitListView.RunWorkerAsync();
            else lvcUserInfo.ListView.Focus();
        }

        private void lvcUserInfo_RequestDelete(object sender, EventArgs e)
        {
            ListViewControl lv = (ListViewControl)sender;
            for (int i = 0; i < lv.SelectedItemCount; i++)
            {
                long ID;
                long.TryParse(lv.ListView.SelectedItems[i].Text, out ID);
                UserInfo.DeleteObject(ID);
            }

            bwInitListView.RunWorkerAsync();
        }

        private void lvcUserInfo_RequestEdit(object sender, EventArgs e)
        {
            Form_UserInfo form = new Form_UserInfo();
            form.CreateMode = false;
            int idTemp;
            int.TryParse(lvcUserInfo.ListView.SelectedItems[0].Text, out idTemp);
            form.ID = idTemp;
            form.Top = this.Top + (this.Height / 2 - form.Height / 2);
            form.Left = this.Left + (this.Width / 2 - form.Width / 2);

            if (form.ShowDialog() == DialogResult.OK)
                bwInitListView.RunWorkerAsync();
            else lvcUserInfo.ListView.Focus();
        }
        #endregion

        #region User Purchased Pack panel
        private void lvcUserPurPack_RequestRefresh(object sender, EventArgs e)
        {
            lvcUserPurPack.ClearAll();
            LoadDataFromUserPurchasedPackNew();
        }

        private void lvcUserPurPack_RequestEdit(object sender, EventArgs e)
        {
            Form_UserPurPack form = new Form_UserPurPack();
            form.CreateMode = false;
            int idTemp;
            int.TryParse(lvcUserPurPack.ListView.SelectedItems[0].Text, out idTemp);
            form.ID = idTemp;
            form.Top = this.Top + (this.Height / 2 - form.Height / 2);
            form.Left = this.Left + (this.Width / 2 - form.Width / 2);

            if (form.ShowDialog() == DialogResult.OK)
                bwInitListView.RunWorkerAsync();
            else lvcUserInfo.ListView.Focus();
        }

        private void lvcUserPurPack_RequestDelete(object sender, EventArgs e)
        {
            ListViewControl lv = (ListViewControl)sender;
            for (int i = 0; i < lv.SelectedItemCount; i++)
            {
                long ID;
                long.TryParse(lv.ListView.SelectedItems[i].Text, out ID);
                UserPurchasedPack.DeleteObject(ID);
            }

            bwInitListView.RunWorkerAsync();
        }
        #endregion
    }
}

using QuanGymChuot.Library.Controls;
using QuanGymChuot.Library.SqlServer;
using QuanGymChuot.Library.SqlServer.DataFromTable;
using System;
using System.Collections.Generic;
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
            ChangePanelAccount(false, "Executing query...");
            LoadDataFromComboPack();
            LoadDataFromUserInfo();
            LoadDataFromPaymentManager();
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
        private void LoadDataFromComboPack()
        {
            if (tabPagePackInfo.InvokeRequired) tabPagePackInfo.Invoke((MethodInvoker)delegate { LoadDataFromComboPack(); });
            else
            {
                lvcPackManager.ClearAll();
                lvcPackManager.ListView.Columns.Add("ID", 48);
                lvcPackManager.ListView.Columns.Add("Name", 182);
                lvcPackManager.ListView.Columns.Add("Price (VND)", 86);
                lvcPackManager.ListView.Columns.Add("Days", 64);
                lvcPackManager.ListView.Columns.Add("Can use?", 72);
                lvcPackManager.ListView.Columns.Add("Added Date", 156);
                lvcPackManager.ListView.Columns.Add("Info", 284);

                foreach (PackItem cpitem in PackManager.GetAll())
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
                    lvcPackManager.ListView.Items.Add(new ListViewItem(s));
                }
            }
        }

        /// <summary>
        /// Lấy dữ liệu từ bảng UserInfo.
        /// </summary>
        private void LoadDataFromUserInfo()
        {
            if (lvcUserInfo.InvokeRequired) lvcUserInfo.Invoke((MethodInvoker)delegate { LoadDataFromUserInfo(); });
            else
            {
                lvcUserInfo.ClearAll();
                lvcUserInfo.ListView.Columns.Add("ID", 48);
                lvcUserInfo.ListView.Columns.Add("Name", 518);
                lvcUserInfo.ListView.Columns.Add("Gender", 70);
                lvcUserInfo.ListView.Columns.Add("Phone", 100);
                lvcUserInfo.ListView.Columns.Add("Registration Date", 156);

                foreach (UserItem uiitem in UserInfo.GetAll())
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
        /// Lấy dữ liệu từ bảng PaymentManager.
        /// </summary>
        private void LoadDataFromPaymentManager()
        {
            if (lvcPaymentManager.InvokeRequired) lvcPaymentManager.Invoke((MethodInvoker)delegate { LoadDataFromPaymentManager(); });
            else
            {
                lvcPaymentManager.ClearAll();
                lvcPaymentManager.ListView.Columns.Add("Payment ID", 80);
                lvcPaymentManager.ListView.Columns.Add("User Name", 318);
                lvcPaymentManager.ListView.Columns.Add("Package Name", 214);
                lvcPaymentManager.ListView.Columns.Add("Purchased Date", 156);
                lvcPaymentManager.ListView.Columns.Add("Expired in", 156);
                lvcPaymentManager.ListView.Columns.Add("System Note", 318);

                foreach (PaymentItem upiitem in PaymentManager.GetAll())
                {
                    string[] s = new string[]
                    {
                        upiitem.ID.ToString(),
                        upiitem.UserName,
                        upiitem.PackName,
                        upiitem.PackRegDate.ToString(),
                        (upiitem.PackExpDate > DateTime.Now) ? upiitem.PackExpDate.ToString() : "Expired",
                        upiitem.Note
                    };
                    lvcPaymentManager.ListView.Items.Add(new ListViewItem(s));
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
            lvcPackManager.ClearAll();
            lvcUserInfo.ClearAll();
            lvcPaymentManager.ClearAll();
            // Kết nối lại đến server để đăng nhập.
            MainForm_Load(this, new EventArgs());
        }
        #endregion

        #region Package Info panel
        private void lvcComboPack_RequireForm(bool createMode = true, int ID = 0)
        {
            Form_ManagePack form = new Form_ManagePack();
            form.CreateMode = createMode;
            form.ID = ID;
            form.Top = this.Top + (this.Height / 2 - form.Height / 2);
            form.Left = this.Left + (this.Width / 2 - form.Width / 2);

            if (form.ShowDialog() == DialogResult.OK)
                bwInitListView.RunWorkerAsync();
            else lvcPackManager.ListView.Focus();
        }

        private void lvcComboPack_RequestCreate(object sender, EventArgs e)
        {
            lvcComboPack_RequireForm(true);
        }

        private void lvcComboPack_RequestEdit(object sender, EventArgs e)
        {
            int idTemp;
            int.TryParse(lvcPackManager.ListView.SelectedItems[0].Text, out idTemp);
            lvcComboPack_RequireForm(false, idTemp);
        }

        private void lvcComboPack_RequestDelete(object sender, EventArgs e)
        {
            ListViewControl lv = (ListViewControl)sender;
            for (int i = 0; i < lv.SelectedItemCount; i++)
            {
                long ID;
                long.TryParse(lv.ListView.SelectedItems[i].Text, out ID);
                PackManager.Delete(new Dictionary<string, string>() { { "ID", ID.ToString() } });
            }

            bwInitListView.RunWorkerAsync();
        }

        private void lvcComboPack_RequestRefresh(object sender, EventArgs e)
        {
            lvcPackManager.ClearAll();
            LoadDataFromComboPack();
        }
        #endregion

        #region User Information panel
        private void lvcUserInfo_RequireForm(bool createMode = true, int ID = 0)
        {
            Form_ManageUser form = new Form_ManageUser();
            form.CreateMode = createMode;
            form.ID = ID;
            form.Top = this.Top + (this.Height / 2 - form.Height / 2);
            form.Left = this.Left + (this.Width / 2 - form.Width / 2);

            if (form.ShowDialog() == DialogResult.OK)
                bwInitListView.RunWorkerAsync();
            else lvcUserInfo.ListView.Focus();
        }

        private void lvcUserInfo_RequestRefresh(object sender, EventArgs e)
        {
            lvcUserInfo.ClearAll();
            LoadDataFromUserInfo();
        }

        private void lvcUserInfo_RequestCreate(object sender, EventArgs e)
        {
            lvcUserInfo_RequireForm(true);
        }

        private void lvcUserInfo_RequestDelete(object sender, EventArgs e)
        {
            ListViewControl lv = (ListViewControl)sender;
            for (int i = 0; i < lv.SelectedItemCount; i++)
            {
                long ID;
                long.TryParse(lv.ListView.SelectedItems[i].Text, out ID);
                UserInfo.Delete(new Dictionary<string, string>() { { "ID", ID.ToString() } });
            }

            bwInitListView.RunWorkerAsync();
        }

        private void lvcUserInfo_RequestEdit(object sender, EventArgs e)
        {
            int idTemp;
            int.TryParse(lvcUserInfo.ListView.SelectedItems[0].Text, out idTemp);
            lvcUserInfo_RequireForm(false, idTemp);
        }
        #endregion

        #region Payment Manager panel
        private void lvcPaymentManager_RequireForm(bool createMode = true, int ID = 0)
        {
            Form_ManagePayment form = new Form_ManagePayment();
            form.CreateMode = createMode;
            form.ID = ID;

            // Căn giữa Form để tạo/sửa ở giữa Form chính.
            form.Top = this.Top + (this.Height / 2 - form.Height / 2);
            form.Left = this.Left + (this.Width / 2 - form.Width / 2);

            if (form.ShowDialog() == DialogResult.OK)
                bwInitListView.RunWorkerAsync();
            else lvcPaymentManager.ListView.Focus();
        }

        private void lvcPaymentManager_RequestRefresh(object sender, EventArgs e)
        {
            lvcPaymentManager.ClearAll();
            LoadDataFromPaymentManager();
        }

        private void lvcPaymentManager_RequestCreate(object sender, EventArgs e)
        {
            lvcPaymentManager_RequireForm(true);
        }

        private void lvcPaymentManager_RequestEdit(object sender, EventArgs e)
        {
            int idTemp;
            int.TryParse(lvcPaymentManager.ListView.SelectedItems[0].Text, out idTemp);
            lvcPaymentManager_RequireForm(false, idTemp);
        }

        private void lvcPaymentManager_RequestDelete(object sender, EventArgs e)
        {
            ListViewControl lv = (ListViewControl)sender;
            for (int i = 0; i < lv.SelectedItemCount; i++)
            {
                long ID;
                long.TryParse(lv.ListView.SelectedItems[i].Text, out ID);
                PaymentManager.Delete(new Dictionary<string, string>() { { "ID", ID.ToString() } });
            }
            bwInitListView.RunWorkerAsync();
        }
        #endregion
    }
}

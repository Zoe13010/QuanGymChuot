using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace QuanGymChuot.Library.Controls
{
    public partial class Login : UserControl
    {
        private string sqlConnectionString = null;

        /// <summary>
        /// Tinh trang ket noi hien tai.
        /// 0: Dang ket noi (khong the thao tac)
        /// 1: Chua ket noi (co the thao tac)
        /// 2: Da ket noi (co the dang nhap)
        /// </summary>
        private byte sqlConnectionStatus = 0;

        public Login()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Set connection string which use to connect SQL Server.
        /// </summary>
        public string SqlConnectionString
        {
            get { return sqlConnectionString; }
            set
            {
                if (sqlConnectionString != value)
                    sqlConnectionString = value;
            }
        }

        /// <summary>
        /// Ket noi den SQL Server.
        /// </summary>
        public void ConnectServer()
        {
            bwServerCheck.RunWorkerAsync();
        }

        /// <summary>
        /// Xoa thong tin da dien trong khung dang nhap.
        /// </summary>
        public void ClearPassword()
        {
            tbPass.Clear();
        }

        /// <summary>
        /// Get user name in textbox which user typed.
        /// </summary>
        public string UserName
        {
            get { return tbUser.Text; }
        }

        /// <summary>
        /// Get password in textbox which user typed (encrypted with MD5).
        /// </summary>
        public string PasswordMD5
        {
            get { return MD5Encrypt.Hash(tbPass.Text); }
        }

        /// <summary>
        /// Occurs when login successfully.
        /// </summary>
        public event EventHandler LoginSuccessful;

        /// <summary>
        /// Bat hoac tat khung dang nhap.
        /// </summary>
        /// <param name="enable">True/False tuong ung voi Bat/Tat.</param>
        private void EnableLoginArea(bool enable)
        {
            if (gbLoginArea.InvokeRequired) gbLoginArea.Invoke((MethodInvoker)delegate { EnableLoginArea(enable); });
            else
            {
                if (enable == false)
                    cbShowPass.Checked = enable;
                gbLoginArea.Enabled = enable;
            }
        }

        /// <summary>
        /// Sua doi khu vuc thong bao.
        /// </summary>
        /// <param name="progShow">True/False tuong ung voi Hien/An thanh tien trinh.</param>
        /// <param name="message">Thong bao se dat (null - khong co chuoi ki tu - de</param>
        private void SetStatusArea(bool progShow, string message = null)
        {
            if (this.InvokeRequired) this.Invoke((MethodInvoker)delegate { SetStatusArea(progShow, message); });
            else
            {
                pbLoading.Enabled = progShow;
                pbLoading.Visible = progShow;
                if (message != null) lbStatus.Text = message;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            Login_SizeChanged(gbLoginArea, new EventArgs());
            // Chi thay doi neu o trong che do chinh sua (Design Mode).
            if (DesignMode)
            {
                pbLoading.MarqueeAnimationSpeed = 20;
                SetStatusArea(true, "This control is in Design Mode!");
            }
        }

        private void cbShowPass_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            tbPass.UseSystemPasswordChar = !cb.Checked;
        }

        private void lbStatus_Click(object sender, EventArgs e)
        {
            if (sqlConnectionStatus == 1)
                bwServerCheck.RunWorkerAsync();
        }

        private void Login_SizeChanged(object sender, EventArgs e)
        {
            if (pnMain.InvokeRequired) pnMain.Invoke((MethodInvoker)delegate { Login_SizeChanged(sender, e); });
            else
            {
                pnMain.Left = this.Width / 2 - pnMain.Width / 2;
                pnMain.Top = this.Height / 2 - pnMain.Height / 2;
            }
        }

        private void tbLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bwLoginProcess.RunWorkerAsync();
                e.SuppressKeyPress = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bwLoginProcess.RunWorkerAsync();
        }

        /// <summary>
        /// Cac lenh trong khi kiem tra ket noi SQL Server.
        /// </summary>
        private void bwServerCheck_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                // Tam thoi tat khung dang nhap.
                EnableLoginArea(false);
                // Dat thong bao la dang ket noi den SQL Server.
                SetStatusArea(true, "Connecting to SQL Server...");
                sqlConnectionStatus = 0;

                if (sqlConnectionString == null || sqlConnectionString.Length == 0)
                    throw new ApplicationException("Your connection string is empty!");

                Library.SqlServer.Connection.ConnectionString = sqlConnectionString;
                Library.Result result = Library.SqlServer.Connection.Connect();

                e.Result = result.Clone();
            }
            catch (Exception ex)
            {
                e.Result = new Library.Result() { Completed = false, Message = ex.Message.Clone() };
            }
        }

        /// <summary>
        /// Ket qua sau khi kiem tra ket noi SQL Server.
        /// </summary>
        private void bwServerCheck_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Library.Result result = (Library.Result)e.Result;
            if (result.Completed)
            {
                EnableLoginArea(true);
                SetStatusArea(false, "Type your account to login form and click \"Login\" to continue.");
                sqlConnectionStatus = 2;
                tbUser.Focus();
            }
            else
            {
                sqlConnectionStatus = 1;
                SetStatusArea(false, "Error while connecting to SQL Server!\nClick this message to try to connect again.");
                MessageBox.Show(String.Format("Error while connecting to SQL Server!\nPlease check your server connection and try again.\n\nMessages:\n{0}", result.Message.ToString()),
                                "Quán Gym Chuột",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cac lenh trong qua trinh dang nhap.
        /// </summary>
        private void bwLoginProcess_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                // Neu khong co du lieu trong o 'Username' va 'Password', huy bo qua trinh.
                if (tbUser.Text == null || tbUser.Text.Length == 0 || tbPass.Text == null || tbPass.Text.Length == 0)
                {
                    EnableLoginArea(true);
                    throw new ApplicationException("Username or password can't be empty!");
                }

                // Tam thoi tat khung dang nhap.
                EnableLoginArea(false);
                // Dat thong bao la dang dang nhap.
                SetStatusArea(true, "Logging in...");

                // Kiem tra ket noi va luu ket qua vao 'cState'.
                ConnectionState cState = Library.SqlServer.Connection.CheckConnectionStatus();
                // Neu khong ket noi duoc, thong bao loi de ket noi lai SQL Server.
                if ((cState == ConnectionState.Closed) || (cState != ConnectionState.Open))
                {
                    sqlConnectionStatus = 1;
                    throw new ApplicationException("Error while logging in!\nIt looks like SQL Server was broken.\nClick this message to try to connect again.");
                }

                // Dang nhap va tra ket qua ve 'result'
                Library.Result result = Library.SqlServer.Account.LogIn(tbUser.Text, Library.MD5Encrypt.Hash(tbPass.Text));

                if (result.Completed)
                    // Thong bao da thanh cong.
                    result.Message = "Logged in! You will be directed to main menu soon...";
                else
                    // Bat khung dang nhap de dang nhap lai neu khong the dang nhap.
                    EnableLoginArea(true);

                e.Result = result.Clone();
            }
            catch (ApplicationException exApp)
            {
                e.Result = new Library.Result() { Completed = false, Message = exApp.Message.Clone() };
            }
            catch (Exception ex)
            {
                e.Result = new Library.Result() { Completed = false, Message = ex.ToString() };
            }
        }

        /// <summary>
        /// Ket qua sau khi dang nhap.
        /// </summary>
        private void bwLoginProcess_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Library.Result result = (Library.Result)e.Result;
            if (result.Completed)
            {
                SetStatusArea(true, result.Message.ToString());
                if (LoginSuccessful != null)
                    LoginSuccessful(this, new EventArgs());
            }
            else
            {
                SetStatusArea(false, result.Message.ToString());
            }
        }
    }
}

using System;
using System.Windows.Forms;

namespace QuanGymChuot.Library.Controls
{
    public partial class Form_ChangePass : Form
    {
        public Form_ChangePass(string username)
        {
            InitializeComponent();
            tbUser.Clear();
            tbUser.AppendText(username);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbPass_TextChanged(object sender, EventArgs e)
        {
            label5.Visible = (tbPassNew.TextLength < 6) ? true : false;
            label6.Visible = (tbPassNewConfirm.TextLength < 6 || tbPassNew.Text != tbPassNewConfirm.Text) ? true : false;

            if (tbPassNew.TextLength < 6 ||
                tbPassNewConfirm.Text != tbPassNew.Text)
                btnChangePass.Enabled = false;
            else btnChangePass.Enabled = true;
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            bwChangePass.RunWorkerAsync();
        }

        private void bwChangePass_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            gbChangePass.Invoke((MethodInvoker)delegate { gbChangePass.Enabled = false; });
            lbStatus.Invoke((MethodInvoker)delegate
            {
                lbStatus.Visible = true;
                lbStatus.Text = "Chaging password...";
            });

            e.Result =  Library.SqlServer.Account.ChangePassword(tbUser.Text,
                                                                 Library.MD5Encrypt.Hash(tbPassOld.Text),
                                                                 Library.MD5Encrypt.Hash(tbPassNew.Text));
        }

        private void bwChangePass_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            var result = (Library.Result)e.Result;
            if (result.Completed)
            {
                Library.SqlServer.Account.CurrentAccount.Set(tbUser.Text, Library.MD5Encrypt.Hash(tbPassNew.Text));
                lbStatus.Invoke((MethodInvoker)delegate { lbStatus.Text = "Password changed!"; });

                MessageBox.Show(String.Format("Username: {0}\nPassword changed!\nClick OK to close dialog.", tbUser.Text),
                                "Quán Gym Chuột",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                lbStatus.Invoke((MethodInvoker)delegate { lbStatus.Text = result.Message.ToString(); });
                gbChangePass.Invoke((MethodInvoker)delegate { gbChangePass.Enabled = true; });
            }
        }
    }
}

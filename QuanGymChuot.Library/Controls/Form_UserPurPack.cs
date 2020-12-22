using QuanGymChuot.Library.SqlServer.DataFromTable;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QuanGymChuot.Library.Controls
{
    public partial class Form_UserPurPack : Form
    {
        public bool CreateMode = true;
        public int ID = 0;
        private UserPurchasedPackItem upiItenOld;

        public Form_UserPurPack()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }

        private void Form_UserPurPack_Load(object sender, EventArgs e)
        {
            if (!CreateMode)
            {
                // upiItenOld = UserPurchasedPack.FindFirstObjectById(ID);
                upiItenOld = UserPurchasedPack.GetFirstObject(new Dictionary<string, string>() { { "B3.ID", ID.ToString() } });
                tbID.Text = upiItenOld.ID.ToString();
                cbUserName.Text = upiItenOld.UserName;
                tbCurComboPack.Text = upiItenOld.PackageName;
                lbCurRegDate.Text = String.Format("{0:dd/MM/yyyy hh:mm:ss tt}", upiItenOld.PackageRegDate);
                lbCurExpDate.Text = String.Format("{0:dd/MM/yyyy hh:mm:ss tt}", upiItenOld.PackageExpDate);
                var curTD = upiItenOld.PackageExpDate - DateTime.Now;
                if (UserPackExpired())
                {
                    lbCurExpDay.Text = "Expired";
                }
                else lbCurExpDay.Text = String.Format("{0} day{1} {2} hour{3}",
                                                      curTD.TotalDays < 0 ? 0 : Math.Round(curTD.TotalDays, 0),
                                                      curTD.TotalDays == 1 ? null : "s",
                                                      curTD.Hours < 0 ? 0 : Math.Round((double)curTD.Hours, 0),
                                                      curTD.Hours == 1 ? null : "s");
                cbUserName.Enabled = false;

                label7.Text = "Renew Combo Pack";
                btnAccept.Text = "Save";
            }
            else
            {
                var userInfo = UserInfo.GetAll();
                cbUserName.Items.Clear();
                cbUserName.Items.Add("(choose a registered name)");
                for (int i = 0; i < userInfo.Count; i++)
                    cbUserName.Items.Add(userInfo[i].Name);
                cbUserName.SelectedIndex = 0;

                lbCurRegDate.Text = String.Format("{0:dd/MM/yyyy hh:mm:ss tt}", DateTime.Now);
                lbCurExpDate.Text = String.Format("{0:dd/MM/yyyy hh:mm:ss tt}", DateTime.Now);
                lbNewExpDate.Text = String.Format("{0:dd/MM/yyyy hh:mm:ss tt}", DateTime.Now);
                lbCurExpDay.Text = "Unregistered";
                tbCurComboPack.Enabled = false;

                label7.Text = "Buy new Combo Pack";
                btnAccept.Text = "Accept";
            }

            var comboInfo = ComboPack.GetAll();
            cbNewComboPack.Items.Clear();
            cbNewComboPack.Items.Add("(choose a combo pack)");
            for (int i = 0; i < comboInfo.Count; i++)
                cbNewComboPack.Items.Add(comboInfo[i].Name);
            cbNewComboPack.SelectedIndex = 0;
        }

        private void cbNewComboPack_Leave(object sender, EventArgs e)
        {
            if (!cbNewComboPack.Items.Contains(cbNewComboPack.Text))
                cbNewComboPack.SelectedIndex = 0;
        }

        private void cbNewComboPack_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbNewComboPack_Leave(cbNewComboPack, new EventArgs());
            }
        }

        private void cbNewComboPack_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (groupBox2.InvokeRequired) groupBox2.Invoke((MethodInvoker)delegate { cbNewComboPack_SelectedIndexChanged(sender, e); });
            else
            {
                if (((ComboBox)sender).SelectedIndex == 0)
                {
                    tbNewComboQty.Text = "0";
                    tbNewComboQty.Enabled = false;
                    lbNewExpDate.Enabled = false;
                }
                else
                {
                    tbNewComboQty.Text = "1";
                    tbNewComboQty.Enabled = true;
                    lbNewExpDate.Enabled = true;
                }
            }
        }

        private bool UserPackExpired()
        {
            if (upiItenOld.PackageExpDate < DateTime.Now)
                return true;
            return false;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (!CreateMode)
            {
                int d;
                int.TryParse(tbNewComboQty.Text, out d);
                UserPurchasedPack.Update(upiItenOld.ID, cbNewComboPack.Text, d);
                this.Close();
            }
            else
            {

            }
        }

        private void tbNewComboQty_TextChanged(object sender, EventArgs e)
        {
            // TODO: Change pack info 
        }
    }
}

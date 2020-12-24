using QuanGymChuot.Library.SqlServer.DataFromTable;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QuanGymChuot.Library.Controls
{
    public partial class Form_ManagePayment : Form
    {
        public bool CreateMode = true;
        public int ID = 0;
        private PaymentItem mpItemOld;

        public Form_ManagePayment()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }

        private void Form_ManagePayment_Load(object sender, EventArgs e)
        {
            if (!this.CreateMode)
            {
                mpItemOld = PaymentManager.GetFirstObject(new Dictionary<string, string>() { { "B3.ID", ID.ToString() } });
                tbID.Text = mpItemOld.ID.ToString();
                cbUserName.Text = mpItemOld.UserName;
                tbCurPackItem.Text = mpItemOld.PackName;
                lbCurRegDate.Text = String.Format("{0:dd/MM/yyyy hh:mm:ss tt}", mpItemOld.PackRegDate);
                lbCurExpDate.Text = String.Format("{0:dd/MM/yyyy hh:mm:ss tt}", mpItemOld.PackExpDate);
                var curTD = mpItemOld.PackExpDate - DateTime.Now;
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

                this.Text = "View or renew package";
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
                lbCurExpDay.Text = "Unregistered";
                tbCurPackItem.Enabled = false;

                this.Text = "Buy new package";
                btnAccept.Text = "Create";
            }

            var packItem = PackManager.GetAll();
            cbNewPackItem.Items.Clear();
            cbNewPackItem.Items.Add("(choose a package)");
            for (int i = 0; i < packItem.Count; i++)
                if (packItem[i].CanUse)
                    cbNewPackItem.Items.Add(packItem[i].Name);
            cbNewPackItem.SelectedIndex = 0;
        }

        private void cbNewComboPack_Leave(object sender, EventArgs e)
        {
            if (!cbNewPackItem.Items.Contains(cbNewPackItem.Text))
                cbNewPackItem.SelectedIndex = 0;
        }

        private void cbNewComboPack_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbNewComboPack_Leave(cbNewPackItem, new EventArgs());
            }
        }

        private bool UserPackExpired()
        {
            if (mpItemOld.PackExpDate < DateTime.Now)
                return true;
            return false;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbUserName.SelectedIndex == 0)
                    throw new ApplicationException("User does not exist! Please choose a vaild user.");
                if (cbNewPackItem.SelectedIndex == 0)
                    throw new ApplicationException("Package does not exist! Please choose a vaild package.");

                PaymentItem varPayItem = new PaymentItem();
                PackItem varPackItem = PackManager.GetFirstObject(new Dictionary<string, string>() { { "Name", String.Format("N\'{0}\'", cbNewPackItem.Text) } });

                varPayItem.UserID = UserInfo.GetFirstObject(new Dictionary<string, string>() { { "Name", String.Format("N\'{0}\'", cbUserName.Text) } }).ID;
                bool continueExecute = false;
                if (PaymentManager.GetRemainPaymentByUserID(varPayItem.UserID).Count != 0)
                {
                    DialogResult dg = MessageBox.Show("This user have non-expired payment record!\nContinue will set other record to expired.\n\nAre you sure you want to continue?",
                                                      "Quán Gym Chuột",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);
                    if (dg == DialogResult.Yes)
                        continueExecute = true;
                }
                else continueExecute = true;

                if (continueExecute)
                {
                    PaymentManager.SetRemainPaymentToExpiredByUserID(varPayItem.UserID);
                    varPayItem.PackID = varPackItem.ID;
                    varPayItem.PackRegDate = DateTime.Now;
                    varPayItem.PackExpDate = varPayItem.PackRegDate.AddDays(varPackItem.DayCount);
                    PaymentManager.Create(varPayItem);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Error while creating a new payment!\nCheck error and try again.\n\nError message:\n{0}", ex.Message),
                                "Quán Gym Chuột",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}

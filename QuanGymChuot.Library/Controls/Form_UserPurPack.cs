using QuanGymChuot.Library.SqlServer.DataFromTable;
using System;
using System.Windows.Forms;

namespace QuanGymChuot.Library.Controls
{
    public partial class Form_UserPurPack : Form
    {
        public bool CreateMode = true;
        public int ID = 0;
        private UserPurchasedPack.UserPurchasedPackItem upiItenOld;//, upiItenNew;

        public Form_UserPurPack()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }

        private void Form_UserPurPack_Load(object sender, System.EventArgs e)
        {
            if (!CreateMode)
            {
                upiItenOld = UserPurchasedPack.FindFirstObjectById(ID);
                tbID.Text = upiItenOld.ID.ToString();
                cbUserName.Text = upiItenOld.UserName;
                tbCurComboPack.Text = upiItenOld.PackageName;
                lbCurRegDate.Text = String.Format("{0:dd/MM/yyyy hh:mm:ss tt}", upiItenOld.PackageRegDate);
                lbCurExpDate.Text = String.Format("{0:dd/MM/yyyy hh:mm:ss tt}", upiItenOld.PackageExpDate);
                var curTD = upiItenOld.PackageExpDate - DateTime.Now;
                lbCurExpDay.Text = String.Format("{0} day{1} {2} hour{3}",
                                                 curTD.TotalDays < 0 ? 0 : Math.Round(curTD.TotalDays, 0),
                                                 curTD.TotalDays == 1 ? null : "s",
                                                 curTD.Hours < 0 ? 0 : Math.Round((double)curTD.Hours, 0),
                                                 curTD.Hours == 1 ? null : "s");

                cbUserName.Enabled = false;
                label7.Text = "Renew or buy new Combo Pack";
                btnAccept.Text = "Save";
            }
            else
            {
                var userInfo = UserInfo.GetAll();
                cbUserName.Items.Clear();
                for (int i = 0; i < userInfo.Count; i++)
                    cbUserName.Items.Add(userInfo[i].Name);

                lbCurRegDate.Text = String.Format("{0:dd/MM/yyyy hh:mm:ss tt}", DateTime.Now);
                lbCurExpDate.Text = String.Format("{0:dd/MM/yyyy hh:mm:ss tt}", DateTime.Now);
                lbNewExpDate.Text = String.Format("{0:dd/MM/yyyy hh:mm:ss tt}", DateTime.Now);
                lbCurExpDay.Text = "0 days 0 hours";
                tbCurComboPack.Enabled = false;

                label7.Text = "Buy new Combo Pack";
                btnAccept.Text = "Accept";
            }

            var comboInfo = ComboPack.GetAll();
            cbNewComboPack.Items.Clear();
            for (int i = 0; i < comboInfo.Count; i++)
                cbNewComboPack.Items.Add(comboInfo[i].Name);
        }
    }
}

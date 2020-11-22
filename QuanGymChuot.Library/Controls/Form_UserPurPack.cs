using QuanGymChuot.Library.SqlServer.DataFromTable;
using System;
using System.Windows.Forms;

namespace QuanGymChuot.Library.Controls
{
    public partial class Form_UserPurPack : Form
    {
        public bool CreateMode = true;
        public int ID = 0;
        private UserPurchasedPack.UserPurchasedPackItem upiItenOld, upiItenNew;

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
                dtpCurRegDate.Value = upiItenOld.PackageRegDate;
                dtpCurExpDate.Value = upiItenOld.PackageExpDate;
                double day = (dtpCurExpDate.Value - DateTime.Now).TotalDays;
                tbCurExpDay.Text = Math.Round(day < 0 ? 0 : day, 0).ToString();

                label7.Text = "Renew or buy new Combo Pack";
                btnAccept.Text = "Save";
            }
            else
            {
                label7.Text = "Buy new Combo Pack";
                btnAccept.Text = "Accept";
                dtpCurRegDate.Value = DateTime.Now;
            }
        }
    }
}

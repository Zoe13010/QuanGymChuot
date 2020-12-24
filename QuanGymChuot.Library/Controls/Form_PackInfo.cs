using QuanGymChuot.Library.SqlServer.DataFromTable;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QuanGymChuot.Library.Controls
{
    public partial class Form_PackInfo : Form
    {
        public bool CreateMode = true;
        public int ID = 0;
        private PackItem cpItemOld, cpItemNew;

        public Form_PackInfo()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }

        private void Form_ComboPack_Load(object sender, EventArgs e)
        {
            if (!CreateMode)
            {
                cpItemOld = PackManager.GetFirstObject(new Dictionary<string, string>() { { "ID", ID.ToString() } });
                tbID.Text = cpItemOld.ID.ToString();
                tbName.Text = cpItemOld.Name;
                tbPrice.Text = cpItemOld.Price.ToString();
                tbDayCount.Text = cpItemOld.DayCount.ToString();
                tbInfo.Text = cpItemOld.Info;
                cbCanUse.Checked = cpItemOld.CanUse;
                lbAddDate.Text = String.Format("{0:dd/MM/yyyy hh:mm:ss tt}", cpItemOld.AddedDate);

                this.Text = "View or edit package information";
                btnAccept.Text = "Save";
            }
            else
            {
                tbID.Enabled = false;
                lbAddDate.Visible = false;
                label8.Visible = false;
                this.Text = "Create a new package information";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            cpItemNew = new PackItem();
            cpItemNew.Name = tbName.TextLength == 0 ? null : tbName.Text;
            long.TryParse(tbPrice.Text, out cpItemNew.Price);
            long.TryParse(tbDayCount.Text, out cpItemNew.DayCount);
            cpItemNew.Info = tbInfo.TextLength == 0 ? null : tbInfo.Text;
            cpItemNew.CanUse = cbCanUse.Checked;

            if (CreateMode)
            {
                PackManager.Create(cpItemNew);
            }
            else
            {
                PackManager.Change(new Dictionary<string, string>() { { "ID", cpItemOld.ID.ToString() } }, cpItemNew);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

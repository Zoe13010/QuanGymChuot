using QuanGymChuot.Library.SqlServer.DataFromTable;
using System;
using System.Windows.Forms;

namespace QuanGymChuot.Library.Controls
{
    public partial class Form_ComboPack : Form
    {
        public bool CreateMode = true;
        public int ID = 0;
        private ComboPack.ComboPackItem cpItemOld, cpItemNew;

        public Form_ComboPack()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }

        private void ComboPack_Edit_Load(object sender, EventArgs e)
        {
            if (!CreateMode)
            {
                cpItemOld = ComboPack.FindFirstObjectById(ID);
                tbID.Text = cpItemOld.ID.ToString();
                tbName.Text = cpItemOld.Name;
                tbPrice.Text = cpItemOld.Price.ToString();
                tbDayCount.Text = cpItemOld.DayCount.ToString();
                tbInfo.Text = cpItemOld.Info;
                cbCanUse.Checked = cpItemOld.CanUse;
                dtpAddDate.Value = cpItemOld.AddedDate;

                label7.Text = "Edit Combo Pack information";
                btnAccept.Text = "Save";
            }
            else
            {
                tbID.Enabled = false;
                dtpAddDate.Visible = false;
                label8.Visible = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            cpItemNew = new ComboPack.ComboPackItem();
            cpItemNew.Name = tbName.TextLength == 0 ? null : tbName.Text;
            long.TryParse(tbPrice.Text, out cpItemNew.Price);
            long.TryParse(tbDayCount.Text, out cpItemNew.DayCount);
            cpItemNew.Info = tbInfo.TextLength == 0 ? null : tbInfo.Text;
            cpItemNew.CanUse = cbCanUse.Checked;

            if (CreateMode)
            {
                ComboPack.Create(cpItemNew);
            }
            else
            {
                ComboPack.ChangeObject(cpItemOld.ID, cpItemNew);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

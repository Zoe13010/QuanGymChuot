using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QuanGymChuot.Library.SqlServer.DataFromTable.ComboPack;

namespace QuanGymChuot.Library.Controls
{
    public partial class ComboPack_Edit : Form
    {
        public bool CreateMode = true;
        public int ID = 0;
        private ComboPackItem cpItemOld, cpItemNew;

        public ComboPack_Edit()
        {
            InitializeComponent();
        }

        private void ComboPack_Edit_Load(object sender, EventArgs e)
        {
            if (!CreateMode)
            {
                cpItemOld = FindObjectById(ID);
                tbID.Text = cpItemOld.ID.ToString();
                tbName.Text = cpItemOld.Name;
                tbPrice.Text = cpItemOld.Price.ToString();
                tbDayCount.Text = cpItemOld.DayCount.ToString();
                tbInfo.Text = cpItemOld.Info;
                cbCanUse.Checked = cpItemOld.CanUse;

                label7.Text = "Edit Combo Pack information";
                btnAccept.Text = "Save";
                this.Text = String.Format("Edit ComboPack [{0}]", cpItemOld.Name);
            }
            else
            {
                this.Text = "New ComboPack";
                tbID.Enabled = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            cpItemNew = new ComboPackItem();
            cpItemNew.Name = tbName.TextLength == 0 ? null : tbName.Text;
            long.TryParse(tbPrice.Text, out cpItemNew.Price);
            long.TryParse(tbDayCount.Text, out cpItemNew.DayCount);
            cpItemNew.Info = tbInfo.TextLength == 0 ? null : tbInfo.Text;
            cpItemNew.CanUse = cbCanUse.Checked;

            if (CreateMode)
            {
                Create(cpItemNew);
            }
            else
            {
                ChangeObject(cpItemOld.ID, cpItemNew);
            }

            this.Close();
        }
    }
}

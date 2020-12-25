using QuanGymChuot.Library.SqlServer.DataFromTable;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QuanGymChuot.Library.Controls
{
    public partial class Form_ManageUser : Form
    {
        public bool CreateMode = true;
        public int ID = 0;
        private UserItem uiItemOld, uiItemNew;

        public Form_ManageUser()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }

        private void Form_UserInfo_Load(object sender, EventArgs e)
        {
            if (!CreateMode)
            {
                uiItemOld = UserInfo.GetFirstObject(new Dictionary<string, string>() { { "ID", ID.ToString() } });

                tbID.Text = uiItemOld.ID.ToString();
                tbName.Text = uiItemOld.Name;
                cbGender.SelectedIndex = (uiItemOld.Gender) ? 1 : 0;
                tbPhone.Text = uiItemOld.Phone;
                lbRegDate.Text = String.Format("{0:dd/MM/yyyy hh:mm:ss tt}", uiItemOld.RegDate);

                this.Text = "View or edit user information";
                btnAccept.Text = "Save";
            }
            else
            {
                tbID.Enabled = false;
                lbRegDate.Visible = false;
                label8.Visible = false;
                cbGender.SelectedIndex = 0;
                this.Text = "Create new user information";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            uiItemNew = new UserItem();
            uiItemNew.Name = tbName.TextLength == 0 ? null : tbName.Text;
            uiItemNew.Gender = (cbGender.SelectedIndex == 1) ? true : false;
            uiItemNew.Phone = tbPhone.Text;

            bool successful = false;
            if (CreateMode)
            {
                successful = UserInfo.Create(uiItemNew);
            }
            else
            {
                successful = UserInfo.Change(new Dictionary<string, string>() { { "ID", ID.ToString() } }, uiItemNew); ;
            }

            if (successful)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}

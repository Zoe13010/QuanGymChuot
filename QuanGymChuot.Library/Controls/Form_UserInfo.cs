using QuanGymChuot.Library.SqlServer.DataFromTable;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QuanGymChuot.Library.Controls
{
    public partial class Form_UserInfo : Form
    {
        public bool CreateMode = true;
        public int ID = 0;
        private UserInfoItem uiItemOld, uiItemNew;

        public Form_UserInfo()
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
                cbGender.SelectedIndex = (!uiItemOld.Gender) ? 1 : 0;
                tbPhone.Text = uiItemOld.Phone;
                lbRegDate.Text = String.Format("{0:dd/MM/yyyy hh:mm:ss tt}", uiItemOld.RegDate);

                label7.Text = "Edit user information";
                btnAccept.Text = "Save";
            }
            else
            {
                tbID.Enabled = false;
                lbRegDate.Visible = false;
                label8.Visible = false;
                cbGender.SelectedIndex = 0;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            uiItemNew = new UserInfoItem();
            uiItemNew.Name = tbName.TextLength == 0 ? null : tbName.Text;
            uiItemNew.Gender = (cbGender.SelectedIndex == 0) ? true : false;
            uiItemNew.Phone = tbPhone.Text;

            if (CreateMode)
            {
                UserInfo.Create(uiItemNew);
            }
            else
            {
                UserInfo.Change(new Dictionary<string, string>() { { "ID", ID.ToString() } }, uiItemNew); ;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

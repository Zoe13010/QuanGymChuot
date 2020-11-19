using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QuanGymChuot.Library.Controls
{
    public partial class ListViewData : UserControl
    {
        public ListViewData()
        {
            InitializeComponent();
        }

        public string Title
        {
            get { return label1.Text; }
            set
            {
                if (label1.Text != value)
                    label1.Text = value;
            }
        }

        public string Description
        {
            get { return label6.Text; }
            set
            {
                if (label6.Text != value)
                    label6.Text = value;
            }
        }

        public int SelectedItemCount
        {
            get
            {
                if (listView == null)
                    return 0;
                else
                    return listView.SelectedItems.Count;
            }
        }

        public ListView ListView
        {
            get { return listView; }
            set
            {
                if (listView != value)
                    listView = value;
            }
        }

        public event EventHandler RequestCreate;
        public event EventHandler RequestDelete;
        public event EventHandler RequestRefresh;
        public event EventHandler RequestEdit;

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (RequestRefresh != null)
                RequestRefresh(this, new EventArgs());
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (RequestCreate != null)
                RequestCreate(this, new EventArgs());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (SelectedItemCount > 0)
            {
                if (RequestDelete != null)
                    RequestDelete(this, new EventArgs());
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (SelectedItemCount == 1)
            {
                if (RequestEdit != null)
                    RequestEdit(this, new EventArgs());
            }
        }

        private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnEdit_Click(btnEdit, new EventArgs());
        }

        private void listView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                btnDelete_Click(btnDelete, new EventArgs());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QuanGymChuot.Library.Controls
{
    public partial class ListViewControl : UserControl
    {
        private string msgBoxDelTitle = null;

        public ListViewControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Lấy hoặc thay đổi tiêu đề của Control này.
        /// </summary>
        public string Title
        {
            get { return label1.Text; }
            set
            {
                if (label1.Text != value)
                    label1.Text = value;
            }
        }

        /// <summary>
        /// Lấy hoặc thay đổi mô tả của Control này.
        /// </summary>
        public string Description
        {
            get { return label6.Text; }
            set
            {
                if (label6.Text != value)
                    label6.Text = value;
            }
        }

        /// <summary>
        /// Lấy số hàng đã được chọn trong Control này.
        /// </summary>
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

        /// <summary>
        /// Lấy hoặc thay đổi tiêu đề thông báo xóa.
        /// </summary>
        public string MsgBoxDelTitle
        {
            get { return msgBoxDelTitle; }
            set
            {
                if (msgBoxDelTitle != value)
                    msgBoxDelTitle = value;
            }
        }

        /// <summary>
        /// Lấy hoặc trả về ListView trong Control.
        /// </summary>
        public ListView ListView
        {
            get { return listView; }
            set
            {
                if (listView != value)
                    listView = value;
            }
        }

        /// <summary>
        /// Sẽ chạy khi yêu cầu tạo một dữ liệu mới.
        /// </summary>
        public event EventHandler RequestCreate;

        /// <summary>
        /// Sẽ chạy khi yêu cầu xóa dữ liệu.
        /// </summary>
        public event EventHandler RequestDelete;
        
        /// <summary>
        /// Sẽ chạy khi yêu cầu làm mới dữ liệu.
        /// </summary>
        public event EventHandler RequestRefresh;

        /// <summary>
        /// Sẽ chạy khi yêu cầu chỉnh sửa dữ liệu.
        /// </summary>
        public event EventHandler RequestEdit;

        /// <summary>
        /// Xóa mọi thứ trong Control ListView.
        /// </summary>
        public void ClearAll()
        {
            listView.Clear();
        }

        /// <summary>
        /// Xóa mọi dữ liệu (ngoại trừ các cột) trong Control ListView.
        /// </summary>
        public void ClearAllItems()
        {
            listView.Items.Clear();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (RequestRefresh != null)
            {
                RequestRefresh(this, new EventArgs());
                RefreshButtonState();
            }
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
                DialogResult msgResult =
                    MessageBox.Show(String.Format("You are about to delete {0}.\nThis action cannot be undone!\n\nAre you sure you want to continue?",
                                                  listView.SelectedItems.Count.ToString() + (listView.SelectedItems.Count == 1 ? " item" : " items")),
                                    MsgBoxDelTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.Yes)
                {
                    if (RequestDelete != null)
                        RequestDelete(this, new EventArgs());
                }
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
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
            {
                foreach (ListViewItem lvItem in listView.Items)
                {
                    lvItem.Selected = true;
                }
            }
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshButtonState();
        }

        private void listView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            RefreshButtonState();
        }

        /// <summary>
        /// Làm mới/kiểm tra điều kiện để bật/tắt các nút.
        /// </summary>
        private void RefreshButtonState()
        {
            ListView lv = listView;
            btnEdit.Enabled = (lv.SelectedItems.Count == 1);
            btnDelete.Enabled = (lv.SelectedItems.Count > 0);
        }
    }
}

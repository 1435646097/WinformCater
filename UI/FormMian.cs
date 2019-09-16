using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using Bll;
namespace UI
{
    public partial class FormMian : Form
    {
        public FormMian()
        {
            InitializeComponent();
        }

        private void FormMian_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormMian_Load(object sender, EventArgs e)
        {
            //if (this.Tag.ToString()=="0")
            //{
            //menuManager.Visible = false;
            //}
            List<HallInfo> hiList = new HallInfoBll().GetList();
            foreach (HallInfo item in hiList)
            {
                TabPage tabPage = new TabPage(item.HTitle);
                tabPage.Tag = item.HId;
                tabHall.TabPages.Add(tabPage);
            }

            tabHall_SelectedIndexChanged(null, null);
        }

        private void menuMeber_Click(object sender, EventArgs e)
        {
            MemberInfoList member = MemberInfoList.Create();
            member.Focus();
            member.Show();
        }

        private void menuManager_Click(object sender, EventArgs e)
        {
            ManagerInfoList managerInfoList = ManagerInfoList.Create();
            managerInfoList.Focus();
            managerInfoList.Show();
        }

        private void menuDish_Click(object sender, EventArgs e)
        {
            DishInfoList dishInfoList = DishInfoList.Create();
            dishInfoList.Focus();
            dishInfoList.Show();
        }

        private void menuTable_Click(object sender, EventArgs e)
        {
            TableInfoList tiList = TableInfoList.Create();
            tiList.Show();
            tiList.Focus();
        }

        private void tabHall_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage tabPage = tabHall.SelectedTab;
            ListView listView = new ListView();
            listView.Dock = DockStyle.Fill;
            listView.LargeImageList = imageList1;
            listView.DoubleClick += ListView_DoubleClick;
            listView.Click += ListView_Click;

            TableInfo tableInfo = new TableInfo();
            tableInfo.THallId = Convert.ToInt32(tabPage.Tag);
            tableInfo.HState = -1;
            List<TableInfo> tiList = new TableInfoBll().GetList(tableInfo);
            foreach (TableInfo item in tiList)
            {
                ListViewItem listViewItem = new ListViewItem(item.TTitle, item.TIsFree ? 0 : 1);
                listViewItem.Tag = item.TId;
                listView.Items.Add(listViewItem);
            }
            tabPage.Controls.Add(listView);
        }
        private ListViewItem listViewItem = new ListViewItem();
        private void ListView_Click(object sender, EventArgs e)
        {
            ListView listView = sender as ListView;
            listViewItem = listView.SelectedItems[0];
        }

        private void ListView_DoubleClick(object sender, EventArgs e)
        {
            ListView listView = sender as ListView;
            ListViewItem listViewItem = listView.SelectedItems[0];
            int tId = Convert.ToInt32(listViewItem.Tag);
            OrderInfoBll oiBll = new OrderInfoBll();
            if (listViewItem.ImageIndex == 0)
            {
                if (oiBll.KaiDan(tId))
                {
                    listViewItem.ImageIndex = 1;
                }
            }
            else
            {

            }
            OrderInfoList oiList = new OrderInfoList();
            oiList.Tag = tId;
            oiList.Show();
        }

        private void menuOrder_Click(object sender, EventArgs e)
        {
            if (listViewItem.Tag == null)
            {
                MessageBox.Show("请选择需要结账的餐桌");
                return;
            }
            if (listViewItem.ImageIndex == 0)
            {
                MessageBox.Show("此卓还未开单");
                return;
            }
            OrderPay op = OrderPay.Create();
            op.Tag = listViewItem.Tag;
            op.ChangePictureEvent += ChangeFree;
            op.Show();
            op.Focus();
        }
        private void ChangeFree()
        {
            listViewItem.ImageIndex = 0;
        }
    }
}

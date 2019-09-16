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
    public partial class HallInfoList : Form
    {
        private HallInfoList()
        {
            InitializeComponent();
        }
        private static HallInfoList hiList;
        public static HallInfoList Create()
        {
            if (hiList==null|| hiList.IsDisposed)
            {
                hiList = new HallInfoList();
            }
            return hiList;
        }
        private void HallInfoList_Load(object sender, EventArgs e)
        {
            LoadList();
        }
        HallInfoBll hib = new HallInfoBll();
        void LoadList()
        {
            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = hib.GetList();
        }
        public event Action LoadType;
        private void btnSave_Click(object sender, EventArgs e)
        {
            HallInfo hi = new HallInfo();
            hi.HTitle = txtTitle.Text;
            if (btnSave.Text.Equals("添加"))
            {
                if (new HallInfoBll().Insert(hi))
                {
                    LoadList();
                    LoadType();
                }
                else
                {
                    MessageBox.Show("添加失败，请稍后重试");
                }
            }
            else
            {
                hi.HId = Convert.ToInt32(txtId.Text);
                if (new HallInfoBll().Update(hi))
                {
                    LoadList();
                    LoadType();
                    btnCancel.PerformClick();
                }
                else
                {
                    MessageBox.Show("修改失败，请稍后重试");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtId.Text = "添加时无编号";
            txtTitle.Text = "";
            btnSave.Text = "添加";
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgvList.SelectedRows[0].Cells["column1"].Value.ToString();
            txtTitle.Text = dgvList.SelectedRows[0].Cells["column2"].Value.ToString();
            btnSave.Text = "修改";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (new HallInfoBll().Delete(Convert.ToInt32(dgvList.SelectedRows[0].Cells["column1"].Value)))
            {
                LoadList();
                LoadType();
            }
            else
            {
                MessageBox.Show("删除失败，请稍后重试");
            }
        }
    }
}

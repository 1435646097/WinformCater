using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bll;
using Model;

namespace UI
{
    public partial class DishTypeInfoList : Form
    {
        public DishTypeInfoList()
        {
            InitializeComponent();
        }

        private void DishTypeInfoList_Load(object sender, EventArgs e)
        {
            LoadList();
        }
        public event Action Type;
        DishTypeInfoBll dishTypeInfoBll = new DishTypeInfoBll();
        void LoadList()
        {
            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = dishTypeInfoBll.GetList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DishTypeInfo dishTypeInfo = new DishTypeInfo();
            dishTypeInfo.DTitle = txtTitle.Text;
            if (btnSave.Text.Equals("添加"))
            {
                if (dishTypeInfoBll.Insert(dishTypeInfo))
                {
                    LoadList();
                    btnCancel.PerformClick();
                    Type();
                }
                else
                {
                    MessageBox.Show("添加失败请稍后重试");
                }
            }
            else
            {
                dishTypeInfo.DId = Convert.ToInt32(txtId.Text);
                if (dishTypeInfoBll.Update(dishTypeInfo))
                {
                    LoadList();
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
            txtId.Text = "添加时无ID";
            txtTitle.Text = "";
            btnSave.Text = "添加";
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgvList.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
            txtTitle.Text = dgvList.Rows[e.RowIndex].Cells["Column2"].Value.ToString();
            btnSave.Text = "修改";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dishTypeInfoBll.Delete(Convert.ToInt32(dgvList.SelectedRows[0].Cells["Column1"].Value)))
            {
                LoadList();
                btnCancel.PerformClick();
                Type();
            }
            else
            {
                MessageBox.Show("删除失败，请稍后重试");
            }
        }
    }
}

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
using Common;

namespace UI
{
    public partial class DishInfoList : Form
    {
        private DishInfoList()
        {
            InitializeComponent();
        }
        private static DishInfoList dish;
        public static DishInfoList Create()
        {
            if (dish == null || dish.IsDisposed)
            {
                dish = new DishInfoList();
            }
            return dish;
        }
        private void DishInfoList_Load(object sender, EventArgs e)
        {
            LoadList();
            LoadTypeList();
        }
        DishInfoBll dishInfoBll = new DishInfoBll();
        private void LoadList()
        {
            dgvList.AutoGenerateColumns = false;
            DishInfo dishInfo = new DishInfo();
            if (txtTitleSearch.Text != "")
            {
                dishInfo.DTitle = txtTitleSearch.Text;
            }
            if (ddlTypeSearch.SelectedIndex > 0)
            {
                dishInfo.DTypeId = Convert.ToInt32(ddlTypeSearch.SelectedValue);
            }
            dgvList.DataSource = dishInfoBll.GetList(dishInfo);
        }
        private void LoadTypeList()
        {
            DishTypeInfoBll dishTypeInfoBll = new DishTypeInfoBll();
            //第一个下拉框
            ddlTypeAdd.DisplayMember = "DTitle";
            ddlTypeAdd.ValueMember = "DId";
            ddlTypeAdd.DataSource = dishTypeInfoBll.GetList();
            //第二个下拉框
            List<DishTypeInfo> list = dishTypeInfoBll.GetList();
            list.Insert(0, new DishTypeInfo()
            {
                DId = 0,
                DTitle = "全部"
            });
            ddlTypeSearch.DisplayMember = "DTitle";
            ddlTypeSearch.ValueMember = "DId";
            ddlTypeSearch.DataSource = list;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtId.Text = "添加时无编号";
            txtChar.Text = "";
            txtPrice.Text = "";
            txtTitleSave.Text = "";
            ddlTypeAdd.SelectedIndex = 0;
            btnSave.Text = "添加";
        }

        private void txtTitleSave_Leave(object sender, EventArgs e)
        {
            txtChar.Text = PinYinHelper.GetPinYin(txtTitleSave.Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DishInfo dishInfo = new DishInfo();
            dishInfo.DChar = txtChar.Text;
            dishInfo.DPrice = Convert.ToDecimal(txtPrice.Text);
            dishInfo.DTitle = txtTitleSave.Text;
            dishInfo.DTypeId = Convert.ToInt32(ddlTypeAdd.SelectedValue);
            if (btnSave.Text.Equals("添加"))
            {
                if (dishInfoBll.Insert(dishInfo))
                {
                    LoadList();
                    LoadTypeList();
                    btnCancel.PerformClick();
                }
                else
                {
                    MessageBox.Show("添加失败，请稍后重试");
                }
            }
            else
            {
                dishInfo.DId = Convert.ToInt32(txtId.Text);
                if (dishInfoBll.Update(dishInfo))
                {
                    LoadList();
                    LoadTypeList();
                    btnCancel.PerformClick();
                }
                else
                {
                    MessageBox.Show("修改失败，请稍后重试");
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dishInfoBll.Delete(Convert.ToInt32(dgvList.SelectedRows[0].Cells["Column1"].Value)))
            {
                MessageBox.Show("删除成功");
                LoadList();
                LoadTypeList();
            }
            else
            {
                MessageBox.Show("删除失败");
            }
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Text = "修改";
            txtId.Text = dgvList.SelectedRows[0].Cells["Column1"].Value.ToString();
            txtTitleSave.Text = dgvList.SelectedRows[0].Cells["Column2"].Value.ToString();
            ddlTypeAdd.Text = dgvList.SelectedRows[0].Cells["Column3"].Value.ToString();
            txtPrice.Text = dgvList.SelectedRows[0].Cells["Column4"].Value.ToString();
            txtChar.Text = dgvList.SelectedRows[0].Cells["Column5"].Value.ToString();
        }

        private void btnSearchAll_Click(object sender, EventArgs e)
        {
            txtTitleSearch.Text = "";
            ddlTypeSearch.SelectedIndex = 0;
            LoadList();
            LoadTypeList();
        }

        private void txtTitleSearch_Leave(object sender, EventArgs e)
        {
            LoadList();
        }

        private void ddlTypeSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadList();
        }

        private void btnAddType_Click(object sender, EventArgs e)
        {
            DishTypeInfoList dishTypeInfoList = new DishTypeInfoList();
            dishTypeInfoList.Type += LoadTypeList;
            dishTypeInfoList.Show();
        }
    }
}

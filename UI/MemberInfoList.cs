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
    public partial class MemberInfoList : Form
    {
        private MemberInfoList()
        {
            InitializeComponent();
        }
        private static MemberInfoList memberInfoList;
        public static MemberInfoList Create()
        {
            if (memberInfoList==null|| memberInfoList.IsDisposed)
            {
                memberInfoList = new MemberInfoList();
            }
            return memberInfoList;
        }
        MemberInfoBll MemberInfoBll = new MemberInfoBll();
        private void MemberInfoList_Load(object sender, EventArgs e)
        {
            LoadList();
            LoadType();
            ddlType.SelectedIndex = 0;
        }
        void LoadList()
        {
            dgvList.AutoGenerateColumns = false;
            MemberInfo memberInfo = new MemberInfo();
            memberInfo.MName = txtNameSearch.Text;
            memberInfo.MPhone = txtPhoneSearch.Text;
            dgvList.DataSource = MemberInfoBll.GetList(memberInfo);
        }
        void LoadType()
        {
            MemberTypeInfoBll memberTypeInfoBll = new MemberTypeInfoBll();
            ddlType.DisplayMember = "MTitle";
            ddlType.ValueMember = "MId";
            ddlType.DataSource = memberTypeInfoBll.Select();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            MemberInfo memberInfo = new MemberInfo();
            memberInfo.MMoney = Convert.ToDecimal(txtMoney.Text);
            memberInfo.MName = txtNameAdd.Text;
            memberInfo.MPhone = txtPhoneAdd.Text;
            memberInfo.MTitle = ddlType.SelectedItem.ToString();
            memberInfo.MTypeId = Convert.ToInt32(ddlType.SelectedValue);
            if (btnSave.Text.Equals("添加"))
            {
                if (MemberInfoBll.Insert(memberInfo))
                {
                    LoadList();
                    btnCancel.PerformClick();
                }
                else
                {
                    MessageBox.Show("添加失败请稍后重试");
                }
            }
            else
            {
                memberInfo.MId = Convert.ToInt32(txtId.Text);
                if (MemberInfoBll.Update(memberInfo))
                {
                    LoadList();
                    btnCancel.PerformClick();
                }
                else
                {
                    MessageBox.Show("修改失败请稍后重试");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtMoney.Text = "";
            txtNameAdd.Text = "";
            txtPhoneAdd.Text = "";
            ddlType.SelectedIndex = 0;
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgvList.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
            txtNameAdd.Text = dgvList.Rows[e.RowIndex].Cells["Column2"].Value.ToString();
            ddlType.Text = dgvList.Rows[e.RowIndex].Cells["Column3"].Value.ToString();
            txtPhoneAdd.Text = dgvList.Rows[e.RowIndex].Cells["Column4"].Value.ToString();
            txtMoney.Text = dgvList.Rows[e.RowIndex].Cells["Column5"].Value.ToString();
            btnSave.Text = "修改";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (MemberInfoBll.Delete(Convert.ToInt32(txtId.Text)))
            {
                MessageBox.Show("删除成功");
                LoadList();
                LoadType();
                ddlType.SelectedIndex = 0;
            }
        }

        private void btnSearchAll_Click(object sender, EventArgs e)
        {
            txtNameSearch.Text = "";
            txtPhoneSearch.Text = "";
            MemberInfoList_Load(null, null);
        }

        private void txtNameSearch_Leave(object sender, EventArgs e)
        {
            MemberInfoList_Load(null, null);
        }

        private void txtPhoneSearch_Leave(object sender, EventArgs e)
        {
            MemberInfoList_Load(null, null);
        }

        private void btnAddType_Click(object sender, EventArgs e)
        {
            MemberTypeInfoList memberTypeInfo = MemberTypeInfoList.Create();
            memberTypeInfo.Focus();
            memberTypeInfo.UpdateList += LoadListType;
            memberTypeInfo.Show();
        }
        private void LoadListType()
        {
            LoadList();
            LoadType();
        }
    }
}

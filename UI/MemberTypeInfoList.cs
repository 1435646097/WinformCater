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
    public partial class MemberTypeInfoList : Form
    {
        private MemberTypeInfoList()
        {
            InitializeComponent();
        }
        private static MemberTypeInfoList memberTypeInfoList;
        public static MemberTypeInfoList Create()
        {
            if (memberTypeInfoList==null|| memberTypeInfoList.IsDisposed)
            {
                memberTypeInfoList = new MemberTypeInfoList();
            }
            return memberTypeInfoList;
        }
        MemberTypeInfoBll MemberTypeInfoBll = new MemberTypeInfoBll();
        private void MemberTypeInfoList_Load(object sender, EventArgs e)
        {
            LoadList();
        }
        void LoadList()
        {
            List<MemberTypeInfo> memberTypeInfos = MemberTypeInfoBll.Select();
            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = memberTypeInfos;
        }
        public event Action UpdateList;
        private void btnSave_Click(object sender, EventArgs e)
        {
            MemberTypeInfo memberTypeInfo = new MemberTypeInfo();
            memberTypeInfo.MDiscount = Convert.ToDecimal(txtDiscount.Text);
            memberTypeInfo.MTitle = txtTitle.Text;
            if (btnSave.Text.Equals("添加"))
            {
                if (MemberTypeInfoBll.Insert(memberTypeInfo))
                {
                    MessageBox.Show("添加成功");
                    LoadList();
                    UpdateList();
                    btnCancel.PerformClick();
                }
                else
                {
                    MessageBox.Show("添加失败，请稍后重试");
                }
            }
            else
            {
                memberTypeInfo.MId = Convert.ToInt32(txtId.Text);
                if (MemberTypeInfoBll.Update(memberTypeInfo))
                {
                    MessageBox.Show("修改成功");
                    LoadList();
                    UpdateList();
                    btnCancel.PerformClick();
                }
                else
                {
                    MessageBox.Show("修改失败");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtId.Text = "添加时无编号";
            txtDiscount.Text = "";
            txtTitle.Text = "";
            btnSave.Text = "添加";
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Text = "修改";
            txtId.Text = dgvList.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
            txtTitle.Text = dgvList.Rows[e.RowIndex].Cells["Column2"].Value.ToString();
            txtDiscount.Text = dgvList.Rows[e.RowIndex].Cells["Column3"].Value.ToString();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvList.SelectedRows[0].Cells["Column1"].Value);
            DialogResult result = MessageBox.Show("确定要删除嘛？", "提示", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                if (MemberTypeInfoBll.Delete(id))
                {
                    LoadList();
                    UpdateList();
                }
                else
                {
                    MessageBox.Show("删除失败，请稍后重试");
                }
            }
            
        }
    }
}

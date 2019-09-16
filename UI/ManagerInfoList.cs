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
    public partial class ManagerInfoList : Form
    {
        private ManagerInfoList()
        {
            InitializeComponent();
        }
        private static ManagerInfoList managerInfoList;
        public static ManagerInfoList Create()
        {
            if (managerInfoList==null|| managerInfoList.IsDisposed)
            {
                managerInfoList = new ManagerInfoList();
            }
            return managerInfoList;
        }
        ManagerInfoBll miBll = new ManagerInfoBll();

        private void ManagerInfoList_Load(object sender, EventArgs e)
        {
           LoadList();
        }

        private void LoadList()
        {
            gvList.AutoGenerateColumns = false;
            gvList.DataSource = miBll.GetList();
        }

        private void gvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                switch (e.Value.ToString())
                {
                    case "1":
                        e.Value = "经理";
                        break;
                    case "0":
                        e.Value = "店员";
                        break;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //接收控件的值，用于构造对象
            ManagerInfo mi=new ManagerInfo()
            {
                MName = txtName.Text,
                MPwd = txtPwd.Text,
                MType = rb1.Checked?1:0
            };
            //判断当前是要进行添加操作，还是要进行修改操作
            if (btnSave.Text == "添加")
            {
                //调用执行添加，如果成功则刷新，失败则提示
                if (miBll.Add(mi))
                {
                    btnCancel_Click(null, null);
                    LoadList();
                }
                else
                {
                    MessageBox.Show("添加失败，请稍候重试");
                }
            }
            else
            {
                //如果是修改，则需要指定主键
                mi.Mid = Convert.ToInt32(txtId.Text);
                //调用执行修改，如果成功则刷新，失败则提示
                if (miBll.Edit(mi))
                {
                    btnCancel_Click(null, null);
                    LoadList();
                }
                else
                {
                    MessageBox.Show("修改失败，请稍候重试");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //将所有的控件恢复默认值
            txtId.Text = "添加时无编号";
            txtName.Text = "";
            txtPwd.Text = "";
            rb2.Checked = true;
            btnSave.Text = "添加";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            //获取选中的行
            var rows = gvList.SelectedRows;
            if (rows.Count > 0)
            {
                //如果选中行大于0，则提示确认
                DialogResult result = MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    //确认删除，则获取主键，调用
                    int id = Convert.ToInt32(rows[0].Cells[0].Value);
                    if (miBll.Remove(id))
                    {
                        //删除成功，则刷新
                        LoadList();
                    }
                    else
                    {
                        MessageBox.Show("删除失败，请稍候重试");
                    }
                }
            }
            else
            {
                MessageBox.Show("二货，还没选中要删除的行呢");
            }
        }

        private void gvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = gvList.Rows[e.RowIndex];//获取双击的行
            //当双击单元格时，将内容显示到控件中，以备修改
            txtId.Text = row.Cells[0].Value.ToString();
            txtName.Text = row.Cells[1].Value.ToString();
            txtPwd.Text = "******";//因为密码进行了md5加密，所以设置默认值，以确定是否进行过修改
            if (row.Cells[2].Value.ToString() == "1")
            {
                rb1.Checked = true;
            }
            else
            {
                rb2.Checked = true;
            }
            btnSave.Text = "修改";
        }
    }
}

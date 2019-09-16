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
    public partial class TableInfoList : Form
    {
        private TableInfoList()
        {
            InitializeComponent();
        }
        private static TableInfoList tiList;
        public static TableInfoList Create()
        {
            if (tiList==null||tiList.IsDisposed)
            {
                tiList = new TableInfoList();
            }
            return tiList;
        }
        private void TableInfoList_Load(object sender, EventArgs e)
        {
            LoadList();
            LoadSearch();
        }
        private TableInfoBll tiBll = new TableInfoBll();
        private HallInfoBll hiBll = new HallInfoBll();
        private void LoadList()
        {
            dgvList.AutoGenerateColumns = false;
            TableInfo ti = new TableInfo();
            ti.HState = Convert.ToInt32(ddlFreeSearch.SelectedValue);
            ti.THallId = Convert.ToInt32(ddlHallSearch.SelectedValue);
            dgvList.DataSource = tiBll.GetList(ti);
        }
        private void LoadSearch()
        {
            List<HallInfo> HallList = hiBll.GetList();
            ddlHallAdd.DisplayMember = "HTitle";
            ddlHallAdd.ValueMember = "HId";
            ddlHallAdd.DataSource = hiBll.GetList();
            HallList.Insert(0, new HallInfo()
            {
                HId = 0,
                HTitle = "全部"
            });
            ddlHallSearch.DisplayMember = "HTitle";
            ddlHallSearch.ValueMember = "HId";
            ddlHallSearch.DataSource = HallList;
            List<TableInfo> tiList = new List<TableInfo>();
            tiList.Add(new TableInfo()
            {
                HState = -1,
                TTitle = "全部"
            });
            tiList.Add(new TableInfo()
            {
                HState = 0,
                TTitle = "非空闲"
            });
            tiList.Add(new TableInfo()
            {
                HState = 1,
                TTitle = "空闲"
            });
            ddlFreeSearch.DisplayMember = "TTitle";
            ddlFreeSearch.ValueMember = "HState";
            ddlFreeSearch.DataSource = tiList;
        }
        private void dgvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                if (Convert.ToBoolean(e.Value))
                {
                    e.Value = "是";
                }
                else
                {
                    e.Value = "否";
                }
            }
        }

        private void ddlHallSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadList();
        }

        private void ddlFreeSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadList();
        }

        private void btnSearchAll_Click(object sender, EventArgs e)
        {
            ddlFreeSearch.SelectedIndex = 0;
            ddlHallSearch.SelectedIndex = 0;
            LoadList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TableInfo ti = new TableInfo();
            ti.TTitle = txtTitle.Text;
            ti.THallId = Convert.ToInt32(ddlHallAdd.SelectedValue);
            ti.TIsFree = rbFree.Checked;
            if (btnSave.Text.Equals("添加"))
            {
                if (tiBll.Insert(ti))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("添加失败，请稍后重试");
                }
            }
            else
            {
                ti.TId = Convert.ToInt32(txtId.Text);
                if (tiBll.Update(ti))
                {
                    LoadList();
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
            ddlHallAdd.SelectedIndex = 0;
            rbFree.Checked = true;
            btnSave.Text = "添加";
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgvList.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
            txtTitle.Text = dgvList.Rows[e.RowIndex].Cells["Column2"].Value.ToString();
            ddlHallAdd.Text = dgvList.Rows[e.RowIndex].Cells["Column3"].Value.ToString();
            if (Convert.ToBoolean(dgvList.Rows[e.RowIndex].Cells["Column4"].Value))
            {
                rbFree.Checked = true;
            }
            else
            {
                rbUnFree.Checked = true;
            }
            btnSave.Text = "修改";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvList.SelectedRows[0].Cells["column1"].Value);
            DialogResult result = MessageBox.Show("是否删除？","提示",MessageBoxButtons.OKCancel);
            if (result==DialogResult.OK)
            {
                if (tiBll.Delete(id))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("删除失败，请稍后重试");
                }
            }
        }

        private void btnAddHall_Click(object sender, EventArgs e)
        {
            HallInfoList hallInfoList = HallInfoList.Create();
            hallInfoList.LoadType += LoadSearch;
            hallInfoList.Show();
            hallInfoList.Focus();
        }
    }
}

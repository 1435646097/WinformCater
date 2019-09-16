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
    public partial class OrderInfoList : Form
    {
        public OrderInfoList()
        {
            InitializeComponent();
        }
        OrderInfoBll oiBll = new OrderInfoBll();
        int orderId;
        private void OrderInfoList_Load(object sender, EventArgs e)
        {
            orderId = oiBll.GetOrderId(Convert.ToInt32(this.Tag));
            LoadDishInfo();
            LoadDishType();
            LoadOrderList();
        }

        private void LoadDishType()
        {
            DishTypeInfoBll dtBll = new DishTypeInfoBll();
            List<DishTypeInfo> dtList = dtBll.GetList();
            dtList.Insert(0, new DishTypeInfo()
            {
                DId = 0,
                DTitle = "全部"
            });
            ddlType.DisplayMember = "DTitle";
            ddlType.ValueMember = "DId";
            ddlType.DataSource = dtList;
        }
        private void LoadDishInfo()
        {
            DishInfoBll diBll = new DishInfoBll();
            DishInfo di = new DishInfo();
            dgvAllDish.AutoGenerateColumns = false;
            dgvAllDish.DataSource = diBll.GetList(di);
        }

        private void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DishInfo di = new DishInfo();
            di.DTypeId = Convert.ToInt32(ddlType.SelectedValue);
            di.DChar = txtTitle.Text;
            dgvAllDish.DataSource = new DishInfoBll().GetList(di);
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            DishInfo di = new DishInfo();
            di.DTypeId = Convert.ToInt32(ddlType.SelectedValue);
            di.DChar = txtTitle.Text;
            dgvAllDish.DataSource = new DishInfoBll().GetList(di);
        }

        private void dgvAllDish_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int dishId = Convert.ToInt32(dgvAllDish.Rows[e.RowIndex].Cells[0].Value);
            if (oiBll.DianCai(orderId, dishId))
            {
                LoadOrderList();
            }
        }

        private void LoadOrderList()
        {
            dgvOrderDetail.AutoGenerateColumns = false;
            dgvOrderDetail.DataSource = oiBll.GetOrderDetial(orderId);
            GetSumMoney();
        }

        private void dgvOrderDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            OrderDetailInfo odi = new OrderDetailInfo();
            odi.Count = Convert.ToInt32(dgvOrderDetail.SelectedRows[0].Cells["Column7"].Value);
            odi.OId = Convert.ToInt32(dgvOrderDetail.SelectedRows[0].Cells["Column5"].Value);
            if (oiBll.UpdateDishCount(odi))
            {
                GetSumMoney();
            }
        }
        private void GetSumMoney()
        {
            DataGridViewRowCollection rows = dgvOrderDetail.Rows;
            double sum = 0;
            for (int i = 0; i < rows.Count; i++)
            {
                sum += Convert.ToDouble(rows[i].Cells[2].Value) * Convert.ToDouble(rows[i].Cells[3].Value);
            }
            lblMoney.Text = sum.ToString();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvOrderDetail.SelectedRows[0].Cells[0].Value);
            if (oiBll.Delete(id))
            {
                LoadOrderList();
            }
            else
            {
                MessageBox.Show("删除失败，请稍后重试");
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (oiBll.XiaDan(orderId,Convert.ToDouble(lblMoney.Text)))
            {
                this.Close();
            }
        }
    }
}

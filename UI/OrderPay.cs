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
    public partial class OrderPay : Form
    {
        private OrderPay()
        {
            InitializeComponent();
        }
        private static OrderPay orderPay;
        public static OrderPay Create()
        {
            if (orderPay == null || orderPay.IsDisposed)
            {
                orderPay = new OrderPay();
            }
            return orderPay;
        }
        OrderInfoBll oiBll = new OrderInfoBll();
        private void OrderPay_Load(object sender, EventArgs e)
        {
            gbMember.Enabled = false;
            this.Text = this.Tag.ToString() + "的账单";
            lblPayMoney.Text = oiBll.GetMoneyByTid(Convert.ToInt32(this.Tag)).ToString();
            lblPayMoneyDiscount.Text = lblPayMoney.Text;
        }

        private void cbkMember_CheckedChanged(object sender, EventArgs e)
        {
            gbMember.Enabled = cbkMember.Checked;
            if (!cbkMember.Checked)
            {
                txtId.Text = "";
                txtPhone.Text = "";
                lblMoney.Text = "";
                lblTypeTitle.Text = "普通会员";
                lblDiscount.Text = 1.ToString();
                lblPayMoneyDiscount.Text = lblPayMoney.Text;
                cbkMoney.Checked = false;
            }
        }

        private void txtId_Leave(object sender, EventArgs e)
        {
            LoadMember();
        }

        private void txtPhone_Leave(object sender, EventArgs e)
        {
            LoadMember();
        }
        private void LoadMember()
        {
            MemberInfo mi = new MemberInfo();
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                mi.MId = Convert.ToInt32(txtId.Text);
            }
            mi.MPhone = txtPhone.Text;
            MemberInfoBll miBll = new MemberInfoBll();
            List<MemberInfo> miList = miBll.GetList(mi);
            if (miList.Count == 1)
            {
                lblDiscount.Text = miList[0].MDiscount.ToString();
                txtPhone.Text = miList[0].MPhone.ToString();
                lblMoney.Text = miList[0].MMoney.ToString();
                lblTypeTitle.Text = miList[0].MTitle;
                lblPayMoneyDiscount.Text = (Convert.ToDouble(lblPayMoney.Text) * Convert.ToDouble(lblDiscount.Text)).ToString();
            }
            else
            {
                MessageBox.Show("会员编号不符，请重新输入");
            }
        }
        public event Action ChangePictureEvent;
        private void btnOrderPay_Click(object sender, EventArgs e)
        {
            decimal discount = 0;
            int memberId = 0;
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                memberId = Convert.ToInt32(txtId.Text);
                discount = Convert.ToDecimal(lblDiscount.Text);
            }
            decimal payMoney = 0;
            if (cbkMoney.Checked)
            {
                decimal totalMoney = decimal.Parse(lblMoney.Text);
                decimal payDiscount = decimal.Parse(lblPayMoneyDiscount.Text);
                if (totalMoney > payDiscount)
                {
                    payMoney = payDiscount;
                }
                else
                {
                    payMoney = totalMoney;
                }
            }

            if (oiBll.JieZhang(Convert.ToInt32(this.Tag), memberId, discount, payMoney))
            {
                ChangePictureEvent();
                this.Close();
            }
            else
            {
                MessageBox.Show("error");
            }

        }
    }
}

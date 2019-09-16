namespace UI
{
    partial class OrderPay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label8 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOrderPay = new System.Windows.Forms.Button();
            this.lblTypeTitle = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPayMoney = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbkMoney = new System.Windows.Forms.CheckBox();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPayMoneyDiscount = new System.Windows.Forms.Label();
            this.gbMember = new System.Windows.Forms.GroupBox();
            this.lblMoney = new System.Windows.Forms.Label();
            this.cbkMember = new System.Windows.Forms.CheckBox();
            this.gbMember.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(203, 222);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 15);
            this.label8.TabIndex = 21;
            this.label8.Text = "应收金额：";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(175, 260);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(127, 29);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "暂不结账";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 106);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "账户余额：";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(92, 65);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(233, 25);
            this.txtPhone.TabIndex = 3;
            this.txtPhone.Leave += new System.EventHandler(this.txtPhone_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "手 机 号：";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(92, 24);
            this.txtId.Margin = new System.Windows.Forms.Padding(4);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(233, 25);
            this.txtId.TabIndex = 1;
            this.txtId.Leave += new System.EventHandler(this.txtId_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "会员编号：";
            // 
            // btnOrderPay
            // 
            this.btnOrderPay.Location = new System.Drawing.Point(25, 260);
            this.btnOrderPay.Margin = new System.Windows.Forms.Padding(4);
            this.btnOrderPay.Name = "btnOrderPay";
            this.btnOrderPay.Size = new System.Drawing.Size(127, 29);
            this.btnOrderPay.TabIndex = 19;
            this.btnOrderPay.Text = "确认结账";
            this.btnOrderPay.UseVisualStyleBackColor = true;
            this.btnOrderPay.Click += new System.EventHandler(this.btnOrderPay_Click);
            // 
            // lblTypeTitle
            // 
            this.lblTypeTitle.AutoSize = true;
            this.lblTypeTitle.Location = new System.Drawing.Point(92, 136);
            this.lblTypeTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTypeTitle.Name = "lblTypeTitle";
            this.lblTypeTitle.Size = new System.Drawing.Size(67, 15);
            this.lblTypeTitle.TabIndex = 7;
            this.lblTypeTitle.Text = "普通会员";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 136);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "会员等级：";
            // 
            // lblPayMoney
            // 
            this.lblPayMoney.AutoSize = true;
            this.lblPayMoney.Location = new System.Drawing.Point(118, 222);
            this.lblPayMoney.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPayMoney.Name = "lblPayMoney";
            this.lblPayMoney.Size = new System.Drawing.Size(15, 15);
            this.lblPayMoney.TabIndex = 18;
            this.lblPayMoney.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 222);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 15);
            this.label7.TabIndex = 15;
            this.label7.Text = "消费金额：";
            // 
            // cbkMoney
            // 
            this.cbkMoney.AutoSize = true;
            this.cbkMoney.Location = new System.Drawing.Point(193, 105);
            this.cbkMoney.Margin = new System.Windows.Forms.Padding(4);
            this.cbkMoney.Name = "cbkMoney";
            this.cbkMoney.Size = new System.Drawing.Size(89, 19);
            this.cbkMoney.TabIndex = 10;
            this.cbkMoney.Text = "使用余额";
            this.cbkMoney.UseVisualStyleBackColor = true;
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(273, 136);
            this.lblDiscount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(15, 15);
            this.lblDiscount.TabIndex = 9;
            this.lblDiscount.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(191, 136);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "折    扣：";
            // 
            // lblPayMoneyDiscount
            // 
            this.lblPayMoneyDiscount.AutoSize = true;
            this.lblPayMoneyDiscount.Location = new System.Drawing.Point(299, 222);
            this.lblPayMoneyDiscount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPayMoneyDiscount.Name = "lblPayMoneyDiscount";
            this.lblPayMoneyDiscount.Size = new System.Drawing.Size(15, 15);
            this.lblPayMoneyDiscount.TabIndex = 22;
            this.lblPayMoneyDiscount.Text = "0";
            // 
            // gbMember
            // 
            this.gbMember.Controls.Add(this.cbkMoney);
            this.gbMember.Controls.Add(this.lblDiscount);
            this.gbMember.Controls.Add(this.label6);
            this.gbMember.Controls.Add(this.lblTypeTitle);
            this.gbMember.Controls.Add(this.label4);
            this.gbMember.Controls.Add(this.lblMoney);
            this.gbMember.Controls.Add(this.label3);
            this.gbMember.Controls.Add(this.txtPhone);
            this.gbMember.Controls.Add(this.label2);
            this.gbMember.Controls.Add(this.txtId);
            this.gbMember.Controls.Add(this.label1);
            this.gbMember.Location = new System.Drawing.Point(13, 40);
            this.gbMember.Margin = new System.Windows.Forms.Padding(4);
            this.gbMember.Name = "gbMember";
            this.gbMember.Padding = new System.Windows.Forms.Padding(4);
            this.gbMember.Size = new System.Drawing.Size(343, 166);
            this.gbMember.TabIndex = 17;
            this.gbMember.TabStop = false;
            this.gbMember.Text = "会员信息";
            // 
            // lblMoney
            // 
            this.lblMoney.AutoSize = true;
            this.lblMoney.Location = new System.Drawing.Point(92, 106);
            this.lblMoney.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMoney.Name = "lblMoney";
            this.lblMoney.Size = new System.Drawing.Size(15, 15);
            this.lblMoney.TabIndex = 5;
            this.lblMoney.Text = "0";
            // 
            // cbkMember
            // 
            this.cbkMember.AutoSize = true;
            this.cbkMember.Location = new System.Drawing.Point(14, 13);
            this.cbkMember.Margin = new System.Windows.Forms.Padding(4);
            this.cbkMember.Name = "cbkMember";
            this.cbkMember.Size = new System.Drawing.Size(74, 19);
            this.cbkMember.TabIndex = 16;
            this.cbkMember.Text = "是会员";
            this.cbkMember.UseVisualStyleBackColor = true;
            this.cbkMember.CheckedChanged += new System.EventHandler(this.cbkMember_CheckedChanged);
            // 
            // OrderPay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 322);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOrderPay);
            this.Controls.Add(this.lblPayMoney);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblPayMoneyDiscount);
            this.Controls.Add(this.gbMember);
            this.Controls.Add(this.cbkMember);
            this.Name = "OrderPay";
            this.Text = "结账付款";
            this.Load += new System.EventHandler(this.OrderPay_Load);
            this.gbMember.ResumeLayout(false);
            this.gbMember.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOrderPay;
        private System.Windows.Forms.Label lblTypeTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPayMoney;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cbkMoney;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPayMoneyDiscount;
        private System.Windows.Forms.GroupBox gbMember;
        private System.Windows.Forms.Label lblMoney;
        private System.Windows.Forms.CheckBox cbkMember;
    }
}
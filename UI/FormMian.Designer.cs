namespace UI
{
    partial class FormMian
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMian));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuManager = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTable = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDish = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMeber = new System.Windows.Forms.ToolStripMenuItem();
            this.exit = new System.Windows.Forms.ToolStripMenuItem();
            this.tabHall = new System.Windows.Forms.TabControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(64, 64);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuManager,
            this.menuOrder,
            this.menuTable,
            this.menuDish,
            this.menuMeber,
            this.exit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(811, 72);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuManager
            // 
            this.menuManager.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuManager.Image = global::UI.Properties.Resources.menuManager;
            this.menuManager.Name = "menuManager";
            this.menuManager.Size = new System.Drawing.Size(76, 68);
            this.menuManager.Text = "menuManager";
            this.menuManager.Click += new System.EventHandler(this.menuManager_Click);
            // 
            // menuOrder
            // 
            this.menuOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuOrder.Image = global::UI.Properties.Resources.menuOrder;
            this.menuOrder.Name = "menuOrder";
            this.menuOrder.Size = new System.Drawing.Size(76, 68);
            this.menuOrder.Text = "menuOrder";
            this.menuOrder.Click += new System.EventHandler(this.menuOrder_Click);
            // 
            // menuTable
            // 
            this.menuTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuTable.Image = global::UI.Properties.Resources.menuTable;
            this.menuTable.Name = "menuTable";
            this.menuTable.Size = new System.Drawing.Size(76, 68);
            this.menuTable.Text = "menuTable";
            this.menuTable.Click += new System.EventHandler(this.menuTable_Click);
            // 
            // menuDish
            // 
            this.menuDish.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuDish.Image = global::UI.Properties.Resources.menuDish;
            this.menuDish.Name = "menuDish";
            this.menuDish.Size = new System.Drawing.Size(76, 68);
            this.menuDish.Text = "menuDish";
            this.menuDish.Click += new System.EventHandler(this.menuDish_Click);
            // 
            // menuMeber
            // 
            this.menuMeber.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuMeber.Image = global::UI.Properties.Resources.menuMember;
            this.menuMeber.Name = "menuMeber";
            this.menuMeber.Size = new System.Drawing.Size(76, 68);
            this.menuMeber.Text = "menuMember";
            this.menuMeber.Click += new System.EventHandler(this.menuMeber_Click);
            // 
            // exit
            // 
            this.exit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.exit.Image = global::UI.Properties.Resources.menuQuit;
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(76, 68);
            this.exit.Text = "Exit";
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // tabHall
            // 
            this.tabHall.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabHall.Location = new System.Drawing.Point(0, 72);
            this.tabHall.Name = "tabHall";
            this.tabHall.SelectedIndex = 0;
            this.tabHall.Size = new System.Drawing.Size(811, 398);
            this.tabHall.TabIndex = 1;
            this.tabHall.SelectedIndexChanged += new System.EventHandler(this.tabHall_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "desk1.png");
            this.imageList1.Images.SetKeyName(1, "desk2.png");
            // 
            // FormMian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 470);
            this.Controls.Add(this.tabHall);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMian";
            this.Text = "订餐中心";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMian_FormClosed);
            this.Load += new System.EventHandler(this.FormMian_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuManager;
        private System.Windows.Forms.ToolStripMenuItem menuOrder;
        private System.Windows.Forms.ToolStripMenuItem menuTable;
        private System.Windows.Forms.ToolStripMenuItem menuDish;
        private System.Windows.Forms.ToolStripMenuItem menuMeber;
        private System.Windows.Forms.ToolStripMenuItem exit;
        private System.Windows.Forms.TabControl tabHall;
        private System.Windows.Forms.ImageList imageList1;
    }
}
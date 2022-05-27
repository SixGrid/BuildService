namespace BuildService.Client.WinForms
{
    partial class MainDashboard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainDashboard));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listView_Auth = new System.Windows.Forms.ListView();
            this.toolStrip_Auth = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_AuthAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_AuthEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_AuthRemove = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip_Connections = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_ConnectionAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_ConnectionEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_ConnectionRemove = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_ConnectionConnect = new System.Windows.Forms.ToolStripButton();
            this.listView_Connections = new System.Windows.Forms.ListView();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStripContainer2 = new System.Windows.Forms.ToolStripContainer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip_Auth.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.toolStrip_Connections.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStripContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(800, 426);
            this.splitContainer1.SplitterDistance = 203;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer2.Size = new System.Drawing.Size(203, 426);
            this.splitContainer2.SplitterDistance = 212;
            this.splitContainer2.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.listView_Auth, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip_Auth, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(203, 212);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // listView_Auth
            // 
            this.listView_Auth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_Auth.FullRowSelect = true;
            this.listView_Auth.GridLines = true;
            this.listView_Auth.Location = new System.Drawing.Point(3, 28);
            this.listView_Auth.MultiSelect = false;
            this.listView_Auth.Name = "listView_Auth";
            this.listView_Auth.Size = new System.Drawing.Size(197, 181);
            this.listView_Auth.TabIndex = 0;
            this.listView_Auth.UseCompatibleStateImageBehavior = false;
            this.listView_Auth.View = System.Windows.Forms.View.Details;
            // 
            // toolStrip_Auth
            // 
            this.toolStrip_Auth.AllowMerge = false;
            this.toolStrip_Auth.AutoSize = false;
            this.toolStrip_Auth.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_Auth.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_AuthAdd,
            this.toolStripButton_AuthEdit,
            this.toolStripButton_AuthRemove});
            this.toolStrip_Auth.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_Auth.Name = "toolStrip_Auth";
            this.toolStrip_Auth.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip_Auth.Size = new System.Drawing.Size(203, 25);
            this.toolStrip_Auth.Stretch = true;
            this.toolStrip_Auth.TabIndex = 1;
            this.toolStrip_Auth.Text = "toolStrip1";
            // 
            // toolStripButton_AuthAdd
            // 
            this.toolStripButton_AuthAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_AuthAdd.Image = global::BuildService.Client.WinForms.Properties.Resources.user__plus;
            this.toolStripButton_AuthAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_AuthAdd.Name = "toolStripButton_AuthAdd";
            this.toolStripButton_AuthAdd.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_AuthAdd.Text = "toolStripButton_AuthAdd";
            // 
            // toolStripButton_AuthEdit
            // 
            this.toolStripButton_AuthEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_AuthEdit.Image = global::BuildService.Client.WinForms.Properties.Resources.user__pencil;
            this.toolStripButton_AuthEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_AuthEdit.Name = "toolStripButton_AuthEdit";
            this.toolStripButton_AuthEdit.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_AuthEdit.Text = "toolStripButton_AuthEdit";
            // 
            // toolStripButton_AuthRemove
            // 
            this.toolStripButton_AuthRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_AuthRemove.Image = global::BuildService.Client.WinForms.Properties.Resources.user__minus;
            this.toolStripButton_AuthRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_AuthRemove.Name = "toolStripButton_AuthRemove";
            this.toolStripButton_AuthRemove.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_AuthRemove.Text = "toolStripButton_AuthRemove";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.toolStrip_Connections, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.listView_Connections, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(203, 210);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // toolStrip_Connections
            // 
            this.toolStrip_Connections.AutoSize = false;
            this.toolStrip_Connections.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_Connections.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_ConnectionAdd,
            this.toolStripButton_ConnectionEdit,
            this.toolStripButton_ConnectionRemove,
            this.toolStripButton_ConnectionConnect});
            this.toolStrip_Connections.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip_Connections.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_Connections.Name = "toolStrip_Connections";
            this.toolStrip_Connections.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip_Connections.Size = new System.Drawing.Size(203, 25);
            this.toolStrip_Connections.Stretch = true;
            this.toolStrip_Connections.TabIndex = 0;
            this.toolStrip_Connections.Text = "toolStrip2";
            // 
            // toolStripButton_ConnectionAdd
            // 
            this.toolStripButton_ConnectionAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_ConnectionAdd.Image = global::BuildService.Client.WinForms.Properties.Resources.server__plus;
            this.toolStripButton_ConnectionAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ConnectionAdd.Name = "toolStripButton_ConnectionAdd";
            this.toolStripButton_ConnectionAdd.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_ConnectionAdd.Text = "toolStripButton_ConnectionAdd";
            // 
            // toolStripButton_ConnectionEdit
            // 
            this.toolStripButton_ConnectionEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_ConnectionEdit.Image = global::BuildService.Client.WinForms.Properties.Resources.server__pencil;
            this.toolStripButton_ConnectionEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ConnectionEdit.Name = "toolStripButton_ConnectionEdit";
            this.toolStripButton_ConnectionEdit.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_ConnectionEdit.Text = "toolStripButton_ConnectionEdit";
            // 
            // toolStripButton_ConnectionRemove
            // 
            this.toolStripButton_ConnectionRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_ConnectionRemove.Image = global::BuildService.Client.WinForms.Properties.Resources.server__minus;
            this.toolStripButton_ConnectionRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ConnectionRemove.Name = "toolStripButton_ConnectionRemove";
            this.toolStripButton_ConnectionRemove.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_ConnectionRemove.Text = "toolStripButton_ConnectionRemove";
            // 
            // toolStripButton_ConnectionConnect
            // 
            this.toolStripButton_ConnectionConnect.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_ConnectionConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_ConnectionConnect.Image = global::BuildService.Client.WinForms.Properties.Resources.plug__arrow;
            this.toolStripButton_ConnectionConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ConnectionConnect.Name = "toolStripButton_ConnectionConnect";
            this.toolStripButton_ConnectionConnect.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_ConnectionConnect.Text = "toolStripButton_ConnectionConnect";
            // 
            // listView_Connections
            // 
            this.listView_Connections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_Connections.FullRowSelect = true;
            this.listView_Connections.GridLines = true;
            this.listView_Connections.Location = new System.Drawing.Point(3, 28);
            this.listView_Connections.MultiSelect = false;
            this.listView_Connections.Name = "listView_Connections";
            this.listView_Connections.Size = new System.Drawing.Size(197, 179);
            this.listView_Connections.TabIndex = 3;
            this.listView_Connections.UseCompatibleStateImageBehavior = false;
            this.listView_Connections.View = System.Windows.Forms.View.Details;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(150, 150);
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(150, 175);
            this.toolStripContainer1.TabIndex = 4;
            // 
            // toolStripContainer2
            // 
            // 
            // toolStripContainer2.ContentPanel
            // 
            this.toolStripContainer2.ContentPanel.Size = new System.Drawing.Size(150, 150);
            this.toolStripContainer2.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer2.Name = "toolStripContainer2";
            this.toolStripContainer2.Size = new System.Drawing.Size(150, 175);
            this.toolStripContainer2.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MainDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainDashboard";
            this.Text = "Build Service - Dashboard";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.toolStrip_Auth.ResumeLayout(false);
            this.toolStrip_Auth.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.toolStrip_Connections.ResumeLayout(false);
            this.toolStrip_Connections.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStripContainer2.ResumeLayout(false);
            this.toolStripContainer2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SplitContainer splitContainer1;
        private MenuStrip menuStrip1;
        private ListView listView_Auth;
        private SplitContainer splitContainer2;
        private ToolStrip toolStrip_Auth;
        private ToolStripButton toolStripButton_AuthAdd;
        private ToolStripButton toolStripButton_AuthEdit;
        private ToolStripButton toolStripButton_AuthRemove;
        private ToolStrip toolStrip_Connections;
        private ToolStripButton toolStripButton_ConnectionAdd;
        private ToolStripButton toolStripButton_ConnectionEdit;
        private ToolStripButton toolStripButton_ConnectionRemove;
        private ToolStripButton toolStripButton_ConnectionConnect;
        private ToolStripContainer toolStripContainer1;
        private ListView listView_Connections;
        private ToolStripContainer toolStripContainer2;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
    }
}
namespace ArborFamiliae.Desktop.Views.Database
{
    partial class NewDatabaseView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            mvvmContext1 = new DevExpress.Utils.MVVM.MVVMContext(components);
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            txtName = new DevExpress.XtraEditors.TextEdit();
            txtDatabase = new DevExpress.XtraEditors.TextEdit();
            txtPassword = new DevExpress.XtraEditors.TextEdit();
            txtUsername = new DevExpress.XtraEditors.TextEdit();
            txtServer = new DevExpress.XtraEditors.TextEdit();
            comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDatabase.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPassword.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtUsername.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtServer.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxEdit1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).BeginInit();
            SuspendLayout();
            // 
            // mvvmContext1
            // 
            mvvmContext1.ContainerControl = this;
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(txtName);
            layoutControl1.Controls.Add(txtDatabase);
            layoutControl1.Controls.Add(txtPassword);
            layoutControl1.Controls.Add(txtUsername);
            layoutControl1.Controls.Add(txtServer);
            layoutControl1.Controls.Add(comboBoxEdit1);
            layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControl1.Location = new System.Drawing.Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.Root = Root;
            layoutControl1.Size = new System.Drawing.Size(399, 171);
            layoutControl1.TabIndex = 4;
            layoutControl1.Text = "layoutControl1";
            // 
            // txtName
            // 
            txtName.Location = new System.Drawing.Point(101, 36);
            txtName.Name = "txtName";
            txtName.Size = new System.Drawing.Size(286, 20);
            txtName.StyleController = layoutControl1;
            txtName.TabIndex = 2;
            // 
            // txtDatabase
            // 
            txtDatabase.Location = new System.Drawing.Point(101, 132);
            txtDatabase.Name = "txtDatabase";
            txtDatabase.Size = new System.Drawing.Size(286, 20);
            txtDatabase.StyleController = layoutControl1;
            txtDatabase.TabIndex = 6;
            // 
            // txtPassword
            // 
            txtPassword.Location = new System.Drawing.Point(101, 108);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new System.Drawing.Size(286, 20);
            txtPassword.StyleController = layoutControl1;
            txtPassword.TabIndex = 5;
            // 
            // txtUsername
            // 
            txtUsername.Location = new System.Drawing.Point(101, 84);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new System.Drawing.Size(286, 20);
            txtUsername.StyleController = layoutControl1;
            txtUsername.TabIndex = 4;
            // 
            // txtServer
            // 
            txtServer.Location = new System.Drawing.Point(101, 60);
            txtServer.Name = "txtServer";
            txtServer.Size = new System.Drawing.Size(286, 20);
            txtServer.StyleController = layoutControl1;
            txtServer.TabIndex = 3;
            // 
            // comboBoxEdit1
            // 
            comboBoxEdit1.Location = new System.Drawing.Point(101, 12);
            comboBoxEdit1.Name = "comboBoxEdit1";
            comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            comboBoxEdit1.Properties.Items.AddRange(new object[] { "MySql" });
            comboBoxEdit1.Size = new System.Drawing.Size(286, 20);
            comboBoxEdit1.StyleController = layoutControl1;
            comboBoxEdit1.TabIndex = 0;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem3, layoutControlItem4, layoutControlItem5, layoutControlItem6, layoutControlItem7 });
            Root.Name = "Root";
            Root.Size = new System.Drawing.Size(399, 171);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = comboBoxEdit1;
            layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new System.Drawing.Size(379, 24);
            layoutControlItem1.Text = "Database Type:";
            layoutControlItem1.TextSize = new System.Drawing.Size(77, 13);
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = txtServer;
            layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new System.Drawing.Size(379, 24);
            layoutControlItem3.Text = "Server";
            layoutControlItem3.TextSize = new System.Drawing.Size(77, 13);
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = txtUsername;
            layoutControlItem4.Location = new System.Drawing.Point(0, 72);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new System.Drawing.Size(379, 24);
            layoutControlItem4.Text = "Username";
            layoutControlItem4.TextSize = new System.Drawing.Size(77, 13);
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.Control = txtPassword;
            layoutControlItem5.Location = new System.Drawing.Point(0, 96);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.Size = new System.Drawing.Size(379, 24);
            layoutControlItem5.Text = "Password";
            layoutControlItem5.TextSize = new System.Drawing.Size(77, 13);
            // 
            // layoutControlItem6
            // 
            layoutControlItem6.Control = txtDatabase;
            layoutControlItem6.Location = new System.Drawing.Point(0, 120);
            layoutControlItem6.Name = "layoutControlItem6";
            layoutControlItem6.Size = new System.Drawing.Size(379, 31);
            layoutControlItem6.Text = "Database";
            layoutControlItem6.TextSize = new System.Drawing.Size(77, 13);
            // 
            // layoutControlItem7
            // 
            layoutControlItem7.Control = txtName;
            layoutControlItem7.Location = new System.Drawing.Point(0, 24);
            layoutControlItem7.Name = "layoutControlItem7";
            layoutControlItem7.Size = new System.Drawing.Size(379, 24);
            layoutControlItem7.Text = "Family Name";
            layoutControlItem7.TextSize = new System.Drawing.Size(77, 13);
            // 
            // NewDatabaseView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(layoutControl1);
            Name = "NewDatabaseView";
            Size = new System.Drawing.Size(399, 171);
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDatabase.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPassword.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtUsername.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtServer.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxEdit1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.Utils.MVVM.MVVMContext mvvmContext1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.TextEdit txtDatabase;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.TextEdit txtUsername;
        private DevExpress.XtraEditors.TextEdit txtServer;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
    }
}

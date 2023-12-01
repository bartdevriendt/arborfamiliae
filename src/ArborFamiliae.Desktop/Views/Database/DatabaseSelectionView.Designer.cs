using ArborFamiliae.Data.InternalModels;
using ArborFamiliae.ViewModels.Database;

namespace ArborFamiliae.Desktop.Views.Database
{
    partial class DatabaseSelectionView
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
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            familyTreeDatabaseBindingSource = new System.Windows.Forms.BindingSource(components);
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            colDatabaseType = new DevExpress.XtraGrid.Columns.GridColumn();
            colName = new DevExpress.XtraGrid.Columns.GridColumn();
            colServer = new DevExpress.XtraGrid.Columns.GridColumn();
            colUsername = new DevExpress.XtraGrid.Columns.GridColumn();
            colDatabase = new DevExpress.XtraGrid.Columns.GridColumn();
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            btnAddDatabase = new DevExpress.XtraEditors.SimpleButton();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)mvvmContext1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)familyTreeDatabaseBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).BeginInit();
            SuspendLayout();
            // 
            // mvvmContext1
            // 
            mvvmContext1.ContainerControl = this;
            // 
            // gridControl1
            // 
            gridControl1.DataSource = familyTreeDatabaseBindingSource;
            gridControl1.Location = new System.Drawing.Point(12, 38);
            gridControl1.MainView = gridView1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new System.Drawing.Size(1049, 743);
            gridControl1.TabIndex = 0;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // familyTreeDatabaseBindingSource
            // 
            familyTreeDatabaseBindingSource.DataSource = typeof(FamilyTreeDatabase);
            // 
            // gridView1
            // 
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colDatabaseType, colName, colServer, colUsername, colDatabase });
            gridView1.CustomizationFormBounds = new System.Drawing.Rectangle(1396, 629, 264, 272);
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsCustomization.AllowGroup = false;
            gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colDatabaseType
            // 
            colDatabaseType.FieldName = "DatabaseType";
            colDatabaseType.Name = "colDatabaseType";
            colDatabaseType.Visible = true;
            colDatabaseType.VisibleIndex = 0;
            // 
            // colName
            // 
            colName.FieldName = "Name";
            colName.Name = "colName";
            colName.Visible = true;
            colName.VisibleIndex = 1;
            // 
            // colServer
            // 
            colServer.FieldName = "Server";
            colServer.Name = "colServer";
            colServer.Visible = true;
            colServer.VisibleIndex = 2;
            // 
            // colUsername
            // 
            colUsername.FieldName = "Username";
            colUsername.Name = "colUsername";
            colUsername.Visible = true;
            colUsername.VisibleIndex = 3;
            // 
            // colDatabase
            // 
            colDatabase.FieldName = "Database";
            colDatabase.Name = "colDatabase";
            colDatabase.Visible = true;
            colDatabase.VisibleIndex = 4;
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(btnAddDatabase);
            layoutControl1.Controls.Add(gridControl1);
            layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControl1.Location = new System.Drawing.Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.Root = Root;
            layoutControl1.Size = new System.Drawing.Size(1073, 793);
            layoutControl1.TabIndex = 1;
            layoutControl1.Text = "layoutControl1";
            // 
            // btnAddDatabase
            // 
            btnAddDatabase.Location = new System.Drawing.Point(12, 12);
            btnAddDatabase.Name = "btnAddDatabase";
            btnAddDatabase.Size = new System.Drawing.Size(155, 22);
            btnAddDatabase.StyleController = layoutControl1;
            btnAddDatabase.TabIndex = 2;
            btnAddDatabase.Text = "Add New";
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem3, emptySpaceItem1 });
            Root.Name = "Root";
            Root.Size = new System.Drawing.Size(1073, 793);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = gridControl1;
            layoutControlItem1.Location = new System.Drawing.Point(0, 26);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new System.Drawing.Size(1053, 747);
            layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = btnAddDatabase;
            layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new System.Drawing.Size(159, 26);
            layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.AllowHotTrack = false;
            emptySpaceItem1.Location = new System.Drawing.Point(159, 0);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new System.Drawing.Size(894, 26);
            emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // DatabaseSelectionView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(layoutControl1);
            Name = "DatabaseSelectionView";
            Size = new System.Drawing.Size(1073, 793);
            ((System.ComponentModel.ISupportInitialize)mvvmContext1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)familyTreeDatabaseBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.Utils.MVVM.MVVMContext mvvmContext1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private System.Windows.Forms.BindingSource familyTreeDatabaseBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colDatabaseType;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colServer;
        private DevExpress.XtraGrid.Columns.GridColumn colUsername;
        private DevExpress.XtraGrid.Columns.GridColumn colDatabase;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SimpleButton btnAddDatabase;
    }
}

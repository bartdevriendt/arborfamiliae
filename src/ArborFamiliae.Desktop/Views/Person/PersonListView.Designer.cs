using ArborFamiliae.ViewModels.Person;
using DevExpress.XtraGrid.Columns;

namespace ArborFamiliae.Desktop.Views
{
    partial class PersonListView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonListView));
            mvvmContext1 = new DevExpress.Utils.MVVM.MVVMContext(components);
            personListModelBindingSource = new System.Windows.Forms.BindingSource(components);
            gcPersons = new DevExpress.XtraGrid.GridControl();
            gvPersons = new DevExpress.XtraGrid.Views.Grid.GridView();
            colArborId = new GridColumn();
            colBirthDate = new GridColumn();
            colDeathDate = new GridColumn();
            colFirstName = new GridColumn();
            colFullName = new GridColumn();
            colGender = new GridColumn();
            colId = new GridColumn();
            colSurname = new GridColumn();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            searchControl1 = new DevExpress.XtraEditors.SearchControl();
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            sbAddPerson = new DevExpress.XtraEditors.SimpleButton();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)mvvmContext1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)personListModelBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gcPersons).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvPersons).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)searchControl1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            SuspendLayout();
            // 
            // mvvmContext1
            // 
            mvvmContext1.ContainerControl = this;
            mvvmContext1.ViewModelType = typeof(PersonListViewModel);
            // 
            // personListModelBindingSource
            // 
            personListModelBindingSource.DataSource = typeof(Domain.Person.PersonListModel);
            // 
            // gcPersons
            // 
            gcPersons.DataSource = personListModelBindingSource;
            gcPersons.Location = new System.Drawing.Point(12, 46);
            gcPersons.MainView = gvPersons;
            gcPersons.Name = "gcPersons";
            gcPersons.Size = new System.Drawing.Size(1010, 603);
            gcPersons.TabIndex = 0;
            gcPersons.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvPersons, gridView1 });
            // 
            // gvPersons
            // 
            gvPersons.Columns.AddRange(new GridColumn[] { colArborId, colBirthDate, colDeathDate, colFirstName, colFullName, colGender, colId, colSurname });
            gvPersons.GridControl = gcPersons;
            gvPersons.GroupCount = 1;
            gvPersons.Name = "gvPersons";
            gvPersons.OptionsBehavior.Editable = false;
            gvPersons.SortInfo.AddRange(new GridColumnSortInfo[] { new GridColumnSortInfo(colSurname, DevExpress.Data.ColumnSortOrder.Ascending) });
            // 
            // colArborId
            // 
            colArborId.FieldName = "ArborId";
            colArborId.Name = "colArborId";
            colArborId.Visible = true;
            colArborId.VisibleIndex = 1;
            // 
            // colBirthDate
            // 
            colBirthDate.FieldName = "BirthDate";
            colBirthDate.Name = "colBirthDate";
            colBirthDate.Visible = true;
            colBirthDate.VisibleIndex = 4;
            // 
            // colDeathDate
            // 
            colDeathDate.FieldName = "DeathDate";
            colDeathDate.Name = "colDeathDate";
            colDeathDate.Visible = true;
            colDeathDate.VisibleIndex = 5;
            // 
            // colFirstName
            // 
            colFirstName.FieldName = "FirstName";
            colFirstName.Name = "colFirstName";
            colFirstName.Visible = true;
            colFirstName.VisibleIndex = 2;
            // 
            // colFullName
            // 
            colFullName.FieldName = "FullName";
            colFullName.Name = "colFullName";
            colFullName.OptionsColumn.ReadOnly = true;
            colFullName.Visible = true;
            colFullName.VisibleIndex = 0;
            // 
            // colGender
            // 
            colGender.FieldName = "Gender";
            colGender.Name = "colGender";
            colGender.Visible = true;
            colGender.VisibleIndex = 3;
            // 
            // colId
            // 
            colId.FieldName = "Id";
            colId.Name = "colId";
            // 
            // colSurname
            // 
            colSurname.FieldName = "Surname";
            colSurname.Name = "colSurname";
            colSurname.Visible = true;
            colSurname.VisibleIndex = 2;
            // 
            // gridView1
            // 
            gridView1.GridControl = gcPersons;
            gridView1.Name = "gridView1";
            // 
            // searchControl1
            // 
            searchControl1.Location = new System.Drawing.Point(12, 12);
            searchControl1.Margin = new System.Windows.Forms.Padding(2);
            searchControl1.MaximumSize = new System.Drawing.Size(0, 30);
            searchControl1.MinimumSize = new System.Drawing.Size(0, 30);
            searchControl1.Name = "searchControl1";
            searchControl1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Repository.ClearButton(), new DevExpress.XtraEditors.Repository.SearchButton() });
            searchControl1.Size = new System.Drawing.Size(911, 30);
            searchControl1.StyleController = layoutControl1;
            searchControl1.TabIndex = 4;
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(sbAddPerson);
            layoutControl1.Controls.Add(gcPersons);
            layoutControl1.Controls.Add(searchControl1);
            layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControl1.Location = new System.Drawing.Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.Root = Root;
            layoutControl1.Size = new System.Drawing.Size(1034, 661);
            layoutControl1.TabIndex = 6;
            layoutControl1.Text = "layoutControl1";
            // 
            // sbAddPerson
            // 
            sbAddPerson.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            sbAddPerson.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            sbAddPerson.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("sbAddPerson.ImageOptions.SvgImage");
            sbAddPerson.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            sbAddPerson.Location = new System.Drawing.Point(927, 12);
            sbAddPerson.MaximumSize = new System.Drawing.Size(95, 30);
            sbAddPerson.MinimumSize = new System.Drawing.Size(95, 30);
            sbAddPerson.Name = "sbAddPerson";
            sbAddPerson.Size = new System.Drawing.Size(95, 30);
            sbAddPerson.StyleController = layoutControl1;
            sbAddPerson.TabIndex = 5;
            sbAddPerson.Text = "Add Person";
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem2, layoutControlItem4 });
            Root.Name = "Root";
            Root.Size = new System.Drawing.Size(1034, 661);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = searchControl1;
            layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new System.Drawing.Size(915, 34);
            layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = gcPersons;
            layoutControlItem2.Location = new System.Drawing.Point(0, 34);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new System.Drawing.Size(1014, 607);
            layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = sbAddPerson;
            layoutControlItem4.Location = new System.Drawing.Point(915, 0);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new System.Drawing.Size(99, 34);
            layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = sbAddPerson;
            layoutControlItem3.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 0);
            layoutControlItem3.Location = new System.Drawing.Point(694, 0);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new System.Drawing.Size(101, 40);
            layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem3.TextVisible = false;
            // 
            // PersonListView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(layoutControl1);
            Name = "PersonListView";
            Size = new System.Drawing.Size(1034, 661);
            ((System.ComponentModel.ISupportInitialize)mvvmContext1).EndInit();
            ((System.ComponentModel.ISupportInitialize)personListModelBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gcPersons).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvPersons).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)searchControl1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.Utils.MVVM.MVVMContext mvvmContext1;
        private System.Windows.Forms.BindingSource personListModelBindingSource;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton sbAddPerson;
        private DevExpress.XtraGrid.GridControl gcPersons;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPersons;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SearchControl searchControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.Columns.GridColumn colArborId;
        private DevExpress.XtraGrid.Columns.GridColumn colSurname;
        private DevExpress.XtraGrid.Columns.GridColumn colFirstName;
        private DevExpress.XtraGrid.Columns.GridColumn colGender;
        private DevExpress.XtraGrid.Columns.GridColumn colBirthDate;
        private DevExpress.XtraGrid.Columns.GridColumn colDeathDate;
        private DevExpress.XtraGrid.Columns.GridColumn colFullName;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}

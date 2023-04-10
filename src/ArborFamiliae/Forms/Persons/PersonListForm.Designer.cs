namespace ArborFamiliae.Forms.Persons;

partial class PersonListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonListForm));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.personListModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvPersons = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSurname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGender = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateOfBirth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateOfDeath = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personListModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPersons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            resources.ApplyResources(this.gridControl1, "gridControl1");
            this.gridControl1.DataSource = this.personListModelBindingSource;
            this.gridControl1.MainView = this.gvPersons;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPersons});
            // 
            // personListModelBindingSource
            // 
            this.personListModelBindingSource.DataSource = typeof(ArborFamiliae.Domain.Person.PersonListModel);
            // 
            // gvPersons
            // 
            resources.ApplyResources(this.gvPersons, "gvPersons");
            this.gvPersons.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSurname,
            this.colFullName,
            this.colGender,
            this.colDateOfBirth,
            this.colDateOfDeath,
            this.gridColumn1});
            this.gvPersons.GridControl = this.gridControl1;
            this.gvPersons.GroupCount = 1;
            this.gvPersons.Name = "gvPersons";
            this.gvPersons.OptionsBehavior.Editable = false;
            this.gvPersons.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colSurname, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvPersons.DoubleClick += new System.EventHandler(this.gvPersons_DoubleClick);
            // 
            // colSurname
            // 
            resources.ApplyResources(this.colSurname, "colSurname");
            this.colSurname.FieldName = "Surname";
            this.colSurname.Name = "colSurname";
            // 
            // colFullName
            // 
            resources.ApplyResources(this.colFullName, "colFullName");
            this.colFullName.FieldName = "FullName";
            this.colFullName.Name = "colFullName";
            this.colFullName.OptionsColumn.ReadOnly = true;
            // 
            // colGender
            // 
            resources.ApplyResources(this.colGender, "colGender");
            this.colGender.FieldName = "Gender";
            this.colGender.Name = "colGender";
            // 
            // colDateOfBirth
            // 
            resources.ApplyResources(this.colDateOfBirth, "colDateOfBirth");
            this.colDateOfBirth.FieldName = "BirthDate";
            this.colDateOfBirth.Name = "colDateOfBirth";
            // 
            // colDateOfDeath
            // 
            resources.ApplyResources(this.colDateOfDeath, "colDateOfDeath");
            this.colDateOfDeath.FieldName = "DeathDate";
            this.colDateOfDeath.Name = "colDateOfDeath";
            // 
            // gridColumn1
            // 
            resources.ApplyResources(this.gridColumn1, "gridColumn1");
            this.gridColumn1.FieldName = "ArborId";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // ribbonControl1
            // 
            resources.ApplyResources(this.ribbonControl1, "ribbonControl1");
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.btnAdd,
            this.btnEdit,
            this.btnDelete});
            this.ribbonControl1.MaxItemId = 4;
            this.ribbonControl1.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            // 
            // btnAdd
            // 
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.Id = 1;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAdd_ItemClick);
            // 
            // btnEdit
            // 
            resources.ApplyResources(this.btnEdit, "btnEdit");
            this.btnEdit.Id = 2;
            this.btnEdit.Name = "btnEdit";
            // 
            // btnDelete
            // 
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.Id = 3;
            this.btnDelete.Name = "btnDelete";
            // 
            // ribbonPage1
            // 
            resources.ApplyResources(this.ribbonPage1, "ribbonPage1");
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            resources.ApplyResources(this.ribbonPageGroup1, "ribbonPageGroup1");
            this.ribbonPageGroup1.ItemLinks.Add(this.btnAdd);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnEdit);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDelete);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // PersonListForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.gridControl1);
            this.Name = "PersonListForm";
            this.Load += new System.EventHandler(this.PersonListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personListModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPersons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private DevExpress.XtraGrid.GridControl gridControl1;
    private DevExpress.XtraGrid.Views.Grid.GridView gvPersons;
    private System.Windows.Forms.BindingSource personListModelBindingSource;
    private DevExpress.XtraGrid.Columns.GridColumn colSurname;
    private DevExpress.XtraGrid.Columns.GridColumn colFullName;
    private DevExpress.XtraGrid.Columns.GridColumn colGender;
    private DevExpress.XtraGrid.Columns.GridColumn colDateOfBirth;
    private DevExpress.XtraGrid.Columns.GridColumn colDateOfDeath;
    private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
    private DevExpress.XtraBars.BarButtonItem btnAdd;
    private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
    private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
    private DevExpress.XtraBars.BarButtonItem btnEdit;
    private DevExpress.XtraBars.BarButtonItem btnDelete;
    private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
}

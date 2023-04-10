namespace ArborFamiliae.Forms.Events
{
    partial class AddEditEventForm
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
            ArborFamiliae.Domain.Events.ArborDateModel arborDateModel1 = new ArborFamiliae.Domain.Events.ArborDateModel();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.RoleLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.eventAddEditModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TypeLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.DateTextTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.DescriptionTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.PlaceNameTextEdit = new DevExpress.XtraEditors.ButtonEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForRole = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForType = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDateText = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForPlaceName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDescription = new DevExpress.XtraLayout.LayoutControlItem();
            this.ucDateEdit1 = new ArborFamiliae.Controls.ucDateEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoleLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventAddEditModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TypeLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateTextTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlaceNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDateText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPlaceName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.ucDateEdit1);
            this.dataLayoutControl1.Controls.Add(this.RoleLookUpEdit);
            this.dataLayoutControl1.Controls.Add(this.TypeLookUpEdit);
            this.dataLayoutControl1.Controls.Add(this.DateTextTextEdit);
            this.dataLayoutControl1.Controls.Add(this.DescriptionTextEdit);
            this.dataLayoutControl1.Controls.Add(this.PlaceNameTextEdit);
            this.dataLayoutControl1.DataSource = this.eventAddEditModelBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(980, 627);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // RoleLookUpEdit
            // 
            this.RoleLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.eventAddEditModelBindingSource, "Role", true));
            this.RoleLookUpEdit.Location = new System.Drawing.Point(79, 12);
            this.RoleLookUpEdit.Name = "RoleLookUpEdit";
            this.RoleLookUpEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.RoleLookUpEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.RoleLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RoleLookUpEdit.Properties.NullText = "";
            this.RoleLookUpEdit.Properties.PopupSizeable = false;
            this.RoleLookUpEdit.Size = new System.Drawing.Size(889, 20);
            this.RoleLookUpEdit.StyleController = this.dataLayoutControl1;
            this.RoleLookUpEdit.TabIndex = 4;
            // 
            // eventAddEditModelBindingSource
            // 
            this.eventAddEditModelBindingSource.DataSource = typeof(ArborFamiliae.Domain.Events.EventAddEditModel);
            // 
            // TypeLookUpEdit
            // 
            this.TypeLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.eventAddEditModelBindingSource, "Type", true));
            this.TypeLookUpEdit.Location = new System.Drawing.Point(79, 36);
            this.TypeLookUpEdit.Name = "TypeLookUpEdit";
            this.TypeLookUpEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.TypeLookUpEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.TypeLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TypeLookUpEdit.Properties.NullText = "";
            this.TypeLookUpEdit.Properties.PopupSizeable = false;
            this.TypeLookUpEdit.Size = new System.Drawing.Size(889, 20);
            this.TypeLookUpEdit.StyleController = this.dataLayoutControl1;
            this.TypeLookUpEdit.TabIndex = 5;
            // 
            // DateTextTextEdit
            // 
            this.DateTextTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.eventAddEditModelBindingSource, "DateText", true));
            this.DateTextTextEdit.Location = new System.Drawing.Point(79, 84);
            this.DateTextTextEdit.Name = "DateTextTextEdit";
            this.DateTextTextEdit.Size = new System.Drawing.Size(889, 20);
            this.DateTextTextEdit.StyleController = this.dataLayoutControl1;
            this.DateTextTextEdit.TabIndex = 6;
            // 
            // DescriptionTextEdit
            // 
            this.DescriptionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.eventAddEditModelBindingSource, "Description", true));
            this.DescriptionTextEdit.Location = new System.Drawing.Point(79, 132);
            this.DescriptionTextEdit.Name = "DescriptionTextEdit";
            this.DescriptionTextEdit.Size = new System.Drawing.Size(889, 20);
            this.DescriptionTextEdit.StyleController = this.dataLayoutControl1;
            this.DescriptionTextEdit.TabIndex = 8;
            // 
            // PlaceNameTextEdit
            // 
            this.PlaceNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.eventAddEditModelBindingSource, "PlaceName", true));
            this.PlaceNameTextEdit.Location = new System.Drawing.Point(79, 108);
            this.PlaceNameTextEdit.Name = "PlaceNameTextEdit";
            this.PlaceNameTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.PlaceNameTextEdit.Size = new System.Drawing.Size(889, 20);
            this.PlaceNameTextEdit.StyleController = this.dataLayoutControl1;
            this.PlaceNameTextEdit.TabIndex = 7;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(980, 627);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowDrawBackground = false;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForRole,
            this.ItemForType,
            this.ItemForDateText,
            this.ItemForPlaceName,
            this.ItemForDescription,
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.Size = new System.Drawing.Size(960, 607);
            // 
            // ItemForRole
            // 
            this.ItemForRole.Control = this.RoleLookUpEdit;
            this.ItemForRole.Location = new System.Drawing.Point(0, 0);
            this.ItemForRole.Name = "ItemForRole";
            this.ItemForRole.Size = new System.Drawing.Size(960, 24);
            this.ItemForRole.Text = "Role";
            this.ItemForRole.TextSize = new System.Drawing.Size(55, 13);
            // 
            // ItemForType
            // 
            this.ItemForType.Control = this.TypeLookUpEdit;
            this.ItemForType.Location = new System.Drawing.Point(0, 24);
            this.ItemForType.Name = "ItemForType";
            this.ItemForType.Size = new System.Drawing.Size(960, 24);
            this.ItemForType.Text = "Type";
            this.ItemForType.TextSize = new System.Drawing.Size(55, 13);
            // 
            // ItemForDateText
            // 
            this.ItemForDateText.Control = this.DateTextTextEdit;
            this.ItemForDateText.Location = new System.Drawing.Point(0, 72);
            this.ItemForDateText.Name = "ItemForDateText";
            this.ItemForDateText.Size = new System.Drawing.Size(960, 24);
            this.ItemForDateText.Text = "Date Text";
            this.ItemForDateText.TextSize = new System.Drawing.Size(55, 13);
            // 
            // ItemForPlaceName
            // 
            this.ItemForPlaceName.Control = this.PlaceNameTextEdit;
            this.ItemForPlaceName.Location = new System.Drawing.Point(0, 96);
            this.ItemForPlaceName.Name = "ItemForPlaceName";
            this.ItemForPlaceName.Size = new System.Drawing.Size(960, 24);
            this.ItemForPlaceName.Text = "Place Name";
            this.ItemForPlaceName.TextSize = new System.Drawing.Size(55, 13);
            // 
            // ItemForDescription
            // 
            this.ItemForDescription.Control = this.DescriptionTextEdit;
            this.ItemForDescription.Location = new System.Drawing.Point(0, 120);
            this.ItemForDescription.Name = "ItemForDescription";
            this.ItemForDescription.Size = new System.Drawing.Size(960, 487);
            this.ItemForDescription.Text = "Description";
            this.ItemForDescription.TextSize = new System.Drawing.Size(55, 13);
            // 
            // ucDateEdit1
            // 
            this.ucDateEdit1.DataBindings.Add(new System.Windows.Forms.Binding("DateModel", this.eventAddEditModelBindingSource, "Date", true));
            this.ucDateEdit1.DataBindings.Add(new System.Windows.Forms.Binding("DateText", this.eventAddEditModelBindingSource, "DateText", true));
            arborDateModel1.Calendar = ArborFamiliae.Domain.Events.DateCalendar.CAL_GREGORIAN;
            arborDateModel1.Day = 0;
            arborDateModel1.Day2 = 0;
            arborDateModel1.Modifier = ArborFamiliae.Domain.Events.DateModifier.MOD_NONE;
            arborDateModel1.Month = 0;
            arborDateModel1.Month2 = 0;
            arborDateModel1.NewYear = ArborFamiliae.Domain.Events.DateNewYear.NEWYEAR_JAN1;
            arborDateModel1.Quality = ArborFamiliae.Domain.Events.DateQuality.QUAL_NONE;
            arborDateModel1.SlashDate1 = false;
            arborDateModel1.SlashDate2 = false;
            arborDateModel1.SortValue = 0;
            arborDateModel1.Text = "0-0-0";
            arborDateModel1.Year = 0;
            arborDateModel1.Year2 = 0;
            this.ucDateEdit1.DateModel = arborDateModel1;
            this.ucDateEdit1.DateText = "";
            this.ucDateEdit1.Location = new System.Drawing.Point(79, 60);
            this.ucDateEdit1.Name = "ucDateEdit1";
            this.ucDateEdit1.Size = new System.Drawing.Size(889, 20);
            this.ucDateEdit1.TabIndex = 9;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.ucDateEdit1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(960, 24);
            this.layoutControlItem1.Text = "Date";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(55, 13);
            // 
            // AddEditEventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 627);
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "AddEditEventForm";
            this.Text = "AddEditEventForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RoleLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventAddEditModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TypeLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateTextTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlaceNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDateText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPlaceName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.LookUpEdit RoleLookUpEdit;
        private System.Windows.Forms.BindingSource eventAddEditModelBindingSource;
        private DevExpress.XtraEditors.LookUpEdit TypeLookUpEdit;
        private DevExpress.XtraEditors.TextEdit DateTextTextEdit;
        private DevExpress.XtraEditors.TextEdit DescriptionTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForRole;
        private DevExpress.XtraLayout.LayoutControlItem ItemForType;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDateText;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPlaceName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDescription;
        private DevExpress.XtraEditors.ButtonEdit PlaceNameTextEdit;
        private Controls.ucDateEdit ucDateEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}
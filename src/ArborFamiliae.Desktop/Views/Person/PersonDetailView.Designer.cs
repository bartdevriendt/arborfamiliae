using ArborFamiliae.ViewModels.Person;

namespace ArborFamiliae.Desktop.Views.Person
{
    partial class PersonDetailView
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
            dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            PreferredTitleTextEdit = new DevExpress.XtraEditors.TextEdit();
            personAddEditModelBindingSource = new System.Windows.Forms.BindingSource(components);
            PreferredNickTextEdit = new DevExpress.XtraEditors.TextEdit();
            PreferredCallTextEdit = new DevExpress.XtraEditors.TextEdit();
            PreferredGivenNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            PreferredSuffixTextEdit = new DevExpress.XtraEditors.TextEdit();
            PreferredSurnamePrefixTextEdit = new DevExpress.XtraEditors.TextEdit();
            PreferredSurnameTextEdit = new DevExpress.XtraEditors.TextEdit();
            GenderLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            ArborIdTextEdit = new DevExpress.XtraEditors.TextEdit();
            DisplayNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            ItemForPreferredNameType = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForPreferredTitle = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForPreferredNick = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForPreferredCall = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForPreferredGivenName = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForPreferredSuffix = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForPreferredSurnamePrefix = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForPreferredSurname = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForGender = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForArborId = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForDisplayName = new DevExpress.XtraLayout.LayoutControlItem();
            button1 = new System.Windows.Forms.Button();
            PreferredNameTypeComboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)mvvmContext1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataLayoutControl1).BeginInit();
            dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PreferredTitleTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)personAddEditModelBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PreferredNickTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PreferredCallTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PreferredGivenNameTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PreferredSuffixTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PreferredSurnamePrefixTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PreferredSurnameTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GenderLookUpEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ArborIdTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DisplayNameTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPreferredNameType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPreferredTitle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPreferredNick).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPreferredCall).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPreferredGivenName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPreferredSuffix).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPreferredSurnamePrefix).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPreferredSurname).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForGender).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForArborId).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDisplayName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PreferredNameTypeComboBoxEdit.Properties).BeginInit();
            SuspendLayout();
            // 
            // mvvmContext1
            // 
            mvvmContext1.ContainerControl = this;
            mvvmContext1.ViewModelType = typeof(PersonDetailViewModel);
            // 
            // dataLayoutControl1
            // 
            dataLayoutControl1.Controls.Add(PreferredTitleTextEdit);
            dataLayoutControl1.Controls.Add(PreferredNickTextEdit);
            dataLayoutControl1.Controls.Add(PreferredCallTextEdit);
            dataLayoutControl1.Controls.Add(PreferredGivenNameTextEdit);
            dataLayoutControl1.Controls.Add(PreferredSuffixTextEdit);
            dataLayoutControl1.Controls.Add(PreferredSurnamePrefixTextEdit);
            dataLayoutControl1.Controls.Add(PreferredSurnameTextEdit);
            dataLayoutControl1.Controls.Add(GenderLookUpEdit);
            dataLayoutControl1.Controls.Add(ArborIdTextEdit);
            dataLayoutControl1.Controls.Add(DisplayNameTextEdit);
            dataLayoutControl1.Controls.Add(PreferredNameTypeComboBoxEdit);
            dataLayoutControl1.DataSource = personAddEditModelBindingSource;
            dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            dataLayoutControl1.Name = "dataLayoutControl1";
            dataLayoutControl1.Root = Root;
            dataLayoutControl1.Size = new System.Drawing.Size(1272, 831);
            dataLayoutControl1.TabIndex = 0;
            dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // PreferredTitleTextEdit
            // 
            PreferredTitleTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", personAddEditModelBindingSource, "PreferredTitle", true));
            PreferredTitleTextEdit.Location = new System.Drawing.Point(772, 12);
            PreferredTitleTextEdit.Name = "PreferredTitleTextEdit";
            PreferredTitleTextEdit.Size = new System.Drawing.Size(488, 20);
            PreferredTitleTextEdit.StyleController = dataLayoutControl1;
            PreferredTitleTextEdit.TabIndex = 5;
            // 
            // personAddEditModelBindingSource
            // 
            personAddEditModelBindingSource.DataSource = typeof(Domain.Person.PersonAddEditModel);
            // 
            // PreferredNickTextEdit
            // 
            PreferredNickTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", personAddEditModelBindingSource, "PreferredNick", true));
            PreferredNickTextEdit.Location = new System.Drawing.Point(146, 36);
            PreferredNickTextEdit.Name = "PreferredNickTextEdit";
            PreferredNickTextEdit.Size = new System.Drawing.Size(488, 20);
            PreferredNickTextEdit.StyleController = dataLayoutControl1;
            PreferredNickTextEdit.TabIndex = 6;
            // 
            // PreferredCallTextEdit
            // 
            PreferredCallTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", personAddEditModelBindingSource, "PreferredCall", true));
            PreferredCallTextEdit.Location = new System.Drawing.Point(772, 36);
            PreferredCallTextEdit.Name = "PreferredCallTextEdit";
            PreferredCallTextEdit.Size = new System.Drawing.Size(488, 20);
            PreferredCallTextEdit.StyleController = dataLayoutControl1;
            PreferredCallTextEdit.TabIndex = 7;
            // 
            // PreferredGivenNameTextEdit
            // 
            PreferredGivenNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", personAddEditModelBindingSource, "PreferredGivenName", true));
            PreferredGivenNameTextEdit.Location = new System.Drawing.Point(146, 60);
            PreferredGivenNameTextEdit.Name = "PreferredGivenNameTextEdit";
            PreferredGivenNameTextEdit.Size = new System.Drawing.Size(488, 20);
            PreferredGivenNameTextEdit.StyleController = dataLayoutControl1;
            PreferredGivenNameTextEdit.TabIndex = 8;
            // 
            // PreferredSuffixTextEdit
            // 
            PreferredSuffixTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", personAddEditModelBindingSource, "PreferredSuffix", true));
            PreferredSuffixTextEdit.Location = new System.Drawing.Point(772, 60);
            PreferredSuffixTextEdit.Name = "PreferredSuffixTextEdit";
            PreferredSuffixTextEdit.Size = new System.Drawing.Size(488, 20);
            PreferredSuffixTextEdit.StyleController = dataLayoutControl1;
            PreferredSuffixTextEdit.TabIndex = 9;
            // 
            // PreferredSurnamePrefixTextEdit
            // 
            PreferredSurnamePrefixTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", personAddEditModelBindingSource, "PreferredSurnamePrefix", true));
            PreferredSurnamePrefixTextEdit.Location = new System.Drawing.Point(146, 84);
            PreferredSurnamePrefixTextEdit.Name = "PreferredSurnamePrefixTextEdit";
            PreferredSurnamePrefixTextEdit.Size = new System.Drawing.Size(488, 20);
            PreferredSurnamePrefixTextEdit.StyleController = dataLayoutControl1;
            PreferredSurnamePrefixTextEdit.TabIndex = 10;
            // 
            // PreferredSurnameTextEdit
            // 
            PreferredSurnameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", personAddEditModelBindingSource, "PreferredSurname", true));
            PreferredSurnameTextEdit.Location = new System.Drawing.Point(772, 84);
            PreferredSurnameTextEdit.Name = "PreferredSurnameTextEdit";
            PreferredSurnameTextEdit.Size = new System.Drawing.Size(488, 20);
            PreferredSurnameTextEdit.StyleController = dataLayoutControl1;
            PreferredSurnameTextEdit.TabIndex = 11;
            // 
            // GenderLookUpEdit
            // 
            GenderLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", personAddEditModelBindingSource, "Gender", true));
            GenderLookUpEdit.Location = new System.Drawing.Point(146, 108);
            GenderLookUpEdit.Name = "GenderLookUpEdit";
            GenderLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            GenderLookUpEdit.Properties.NullText = "";
            GenderLookUpEdit.Size = new System.Drawing.Size(488, 20);
            GenderLookUpEdit.StyleController = dataLayoutControl1;
            GenderLookUpEdit.TabIndex = 12;
            // 
            // ArborIdTextEdit
            // 
            ArborIdTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", personAddEditModelBindingSource, "ArborId", true));
            ArborIdTextEdit.Location = new System.Drawing.Point(772, 108);
            ArborIdTextEdit.Name = "ArborIdTextEdit";
            ArborIdTextEdit.Size = new System.Drawing.Size(488, 20);
            ArborIdTextEdit.StyleController = dataLayoutControl1;
            ArborIdTextEdit.TabIndex = 13;
            // 
            // DisplayNameTextEdit
            // 
            DisplayNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", personAddEditModelBindingSource, "DisplayName", true));
            DisplayNameTextEdit.Location = new System.Drawing.Point(146, 132);
            DisplayNameTextEdit.Name = "DisplayNameTextEdit";
            DisplayNameTextEdit.Properties.ReadOnly = true;
            DisplayNameTextEdit.Size = new System.Drawing.Size(1114, 20);
            DisplayNameTextEdit.StyleController = dataLayoutControl1;
            DisplayNameTextEdit.TabIndex = 14;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlGroup1 });
            Root.Name = "Root";
            Root.Size = new System.Drawing.Size(1272, 831);
            Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            layoutControlGroup1.AllowDrawBackground = false;
            layoutControlGroup1.GroupBordersVisible = false;
            layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { ItemForPreferredNameType, ItemForPreferredTitle, ItemForPreferredNick, ItemForPreferredCall, ItemForPreferredGivenName, ItemForPreferredSuffix, ItemForPreferredSurnamePrefix, ItemForPreferredSurname, ItemForGender, ItemForArborId, ItemForDisplayName });
            layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            layoutControlGroup1.Name = "autoGeneratedGroup0";
            layoutControlGroup1.Size = new System.Drawing.Size(1252, 811);
            // 
            // ItemForPreferredNameType
            // 
            ItemForPreferredNameType.Control = PreferredNameTypeComboBoxEdit;
            ItemForPreferredNameType.Location = new System.Drawing.Point(0, 0);
            ItemForPreferredNameType.Name = "ItemForPreferredNameType";
            ItemForPreferredNameType.Size = new System.Drawing.Size(626, 24);
            ItemForPreferredNameType.Text = "Preferred Name Type";
            ItemForPreferredNameType.TextSize = new System.Drawing.Size(122, 13);
            // 
            // ItemForPreferredTitle
            // 
            ItemForPreferredTitle.Control = PreferredTitleTextEdit;
            ItemForPreferredTitle.Location = new System.Drawing.Point(626, 0);
            ItemForPreferredTitle.Name = "ItemForPreferredTitle";
            ItemForPreferredTitle.Size = new System.Drawing.Size(626, 24);
            ItemForPreferredTitle.Text = "Preferred Title";
            ItemForPreferredTitle.TextSize = new System.Drawing.Size(122, 13);
            // 
            // ItemForPreferredNick
            // 
            ItemForPreferredNick.Control = PreferredNickTextEdit;
            ItemForPreferredNick.Location = new System.Drawing.Point(0, 24);
            ItemForPreferredNick.Name = "ItemForPreferredNick";
            ItemForPreferredNick.Size = new System.Drawing.Size(626, 24);
            ItemForPreferredNick.Text = "Preferred Nick";
            ItemForPreferredNick.TextSize = new System.Drawing.Size(122, 13);
            // 
            // ItemForPreferredCall
            // 
            ItemForPreferredCall.Control = PreferredCallTextEdit;
            ItemForPreferredCall.Location = new System.Drawing.Point(626, 24);
            ItemForPreferredCall.Name = "ItemForPreferredCall";
            ItemForPreferredCall.Size = new System.Drawing.Size(626, 24);
            ItemForPreferredCall.Text = "Preferred Call";
            ItemForPreferredCall.TextSize = new System.Drawing.Size(122, 13);
            // 
            // ItemForPreferredGivenName
            // 
            ItemForPreferredGivenName.Control = PreferredGivenNameTextEdit;
            ItemForPreferredGivenName.Location = new System.Drawing.Point(0, 48);
            ItemForPreferredGivenName.Name = "ItemForPreferredGivenName";
            ItemForPreferredGivenName.Size = new System.Drawing.Size(626, 24);
            ItemForPreferredGivenName.Text = "Preferred Given Name";
            ItemForPreferredGivenName.TextSize = new System.Drawing.Size(122, 13);
            // 
            // ItemForPreferredSuffix
            // 
            ItemForPreferredSuffix.Control = PreferredSuffixTextEdit;
            ItemForPreferredSuffix.Location = new System.Drawing.Point(626, 48);
            ItemForPreferredSuffix.Name = "ItemForPreferredSuffix";
            ItemForPreferredSuffix.Size = new System.Drawing.Size(626, 24);
            ItemForPreferredSuffix.Text = "Preferred Suffix";
            ItemForPreferredSuffix.TextSize = new System.Drawing.Size(122, 13);
            // 
            // ItemForPreferredSurnamePrefix
            // 
            ItemForPreferredSurnamePrefix.Control = PreferredSurnamePrefixTextEdit;
            ItemForPreferredSurnamePrefix.Location = new System.Drawing.Point(0, 72);
            ItemForPreferredSurnamePrefix.Name = "ItemForPreferredSurnamePrefix";
            ItemForPreferredSurnamePrefix.Size = new System.Drawing.Size(626, 24);
            ItemForPreferredSurnamePrefix.Text = "Preferred Surname Prefix";
            ItemForPreferredSurnamePrefix.TextSize = new System.Drawing.Size(122, 13);
            // 
            // ItemForPreferredSurname
            // 
            ItemForPreferredSurname.Control = PreferredSurnameTextEdit;
            ItemForPreferredSurname.Location = new System.Drawing.Point(626, 72);
            ItemForPreferredSurname.Name = "ItemForPreferredSurname";
            ItemForPreferredSurname.Size = new System.Drawing.Size(626, 24);
            ItemForPreferredSurname.Text = "Preferred Surname";
            ItemForPreferredSurname.TextSize = new System.Drawing.Size(122, 13);
            // 
            // ItemForGender
            // 
            ItemForGender.Control = GenderLookUpEdit;
            ItemForGender.Location = new System.Drawing.Point(0, 96);
            ItemForGender.Name = "ItemForGender";
            ItemForGender.Size = new System.Drawing.Size(626, 24);
            ItemForGender.Text = "Gender";
            ItemForGender.TextSize = new System.Drawing.Size(122, 13);
            // 
            // ItemForArborId
            // 
            ItemForArborId.Control = ArborIdTextEdit;
            ItemForArborId.Location = new System.Drawing.Point(626, 96);
            ItemForArborId.Name = "ItemForArborId";
            ItemForArborId.Size = new System.Drawing.Size(626, 24);
            ItemForArborId.Text = "Arbor Id";
            ItemForArborId.TextSize = new System.Drawing.Size(122, 13);
            // 
            // ItemForDisplayName
            // 
            ItemForDisplayName.Control = DisplayNameTextEdit;
            ItemForDisplayName.Location = new System.Drawing.Point(0, 120);
            ItemForDisplayName.Name = "ItemForDisplayName";
            ItemForDisplayName.Size = new System.Drawing.Size(1252, 691);
            ItemForDisplayName.Text = "Display Name";
            ItemForDisplayName.TextSize = new System.Drawing.Size(122, 13);
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(37, 329);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(42, 60);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // PreferredNameTypeComboBoxEdit
            // 
            PreferredNameTypeComboBoxEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", personAddEditModelBindingSource, "PreferredNameType", true));
            PreferredNameTypeComboBoxEdit.Location = new System.Drawing.Point(146, 12);
            PreferredNameTypeComboBoxEdit.Name = "PreferredNameTypeComboBoxEdit";
            PreferredNameTypeComboBoxEdit.Properties.Appearance.Options.UseTextOptions = true;
            PreferredNameTypeComboBoxEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            PreferredNameTypeComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            PreferredNameTypeComboBoxEdit.Size = new System.Drawing.Size(488, 20);
            PreferredNameTypeComboBoxEdit.StyleController = dataLayoutControl1;
            PreferredNameTypeComboBoxEdit.TabIndex = 4;
            // 
            // PersonDetailView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(button1);
            Controls.Add(dataLayoutControl1);
            Name = "PersonDetailView";
            Size = new System.Drawing.Size(1272, 831);
            ((System.ComponentModel.ISupportInitialize)mvvmContext1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataLayoutControl1).EndInit();
            dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PreferredTitleTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)personAddEditModelBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)PreferredNickTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)PreferredCallTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)PreferredGivenNameTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)PreferredSuffixTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)PreferredSurnamePrefixTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)PreferredSurnameTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)GenderLookUpEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)ArborIdTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)DisplayNameTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPreferredNameType).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPreferredTitle).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPreferredNick).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPreferredCall).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPreferredGivenName).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPreferredSuffix).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPreferredSurnamePrefix).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPreferredSurname).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForGender).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForArborId).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDisplayName).EndInit();
            ((System.ComponentModel.ISupportInitialize)PreferredNameTypeComboBoxEdit.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.Utils.MVVM.MVVMContext mvvmContext1;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private System.Windows.Forms.BindingSource personAddEditModelBindingSource;
        private DevExpress.XtraEditors.TextEdit PreferredTitleTextEdit;
        private DevExpress.XtraEditors.TextEdit PreferredNickTextEdit;
        private DevExpress.XtraEditors.TextEdit PreferredCallTextEdit;
        private DevExpress.XtraEditors.TextEdit PreferredGivenNameTextEdit;
        private DevExpress.XtraEditors.TextEdit PreferredSuffixTextEdit;
        private DevExpress.XtraEditors.TextEdit PreferredSurnamePrefixTextEdit;
        private DevExpress.XtraEditors.TextEdit PreferredSurnameTextEdit;
        private DevExpress.XtraEditors.LookUpEdit GenderLookUpEdit;
        private DevExpress.XtraEditors.TextEdit ArborIdTextEdit;
        private DevExpress.XtraEditors.TextEdit DisplayNameTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPreferredNameType;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPreferredTitle;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPreferredNick;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPreferredCall;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPreferredGivenName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPreferredSuffix;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPreferredSurnamePrefix;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPreferredSurname;
        private DevExpress.XtraLayout.LayoutControlItem ItemForGender;
        private DevExpress.XtraLayout.LayoutControlItem ItemForArborId;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDisplayName;
        private System.Windows.Forms.Button button1;
        private DevExpress.XtraEditors.ComboBoxEdit PreferredNameTypeComboBoxEdit;
    }
}

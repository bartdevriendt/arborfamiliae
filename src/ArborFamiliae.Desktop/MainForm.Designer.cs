namespace ArborFamiliae.Desktop
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            navigationGroup = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            accPerson = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            accFamily = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            mainPanel = new DevExpress.XtraEditors.PanelControl();
            navigationFrame = new DevExpress.XtraBars.Navigation.NavigationFrame();
            pnlNavigationBar = new DevExpress.XtraEditors.PanelControl();
            breadCrumbEdit1 = new DevExpress.XtraEditors.BreadCrumbEdit();
            mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(components);
            ((System.ComponentModel.ISupportInitialize)accordionControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fluentDesignFormControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mainPanel).BeginInit();
            mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)navigationFrame).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlNavigationBar).BeginInit();
            pnlNavigationBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)breadCrumbEdit1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mvvmContext).BeginInit();
            SuspendLayout();
            // 
            // accordionControl1
            // 
            accordionControl1.AllowItemSelection = true;
            accordionControl1.Appearance.AccordionControl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            accordionControl1.Appearance.AccordionControl.Options.UseForeColor = true;
            accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { navigationGroup });
            accordionControl1.Location = new System.Drawing.Point(0, 31);
            accordionControl1.Name = "accordionControl1";
            accordionControl1.OptionsMinimizing.AllowMinimizeMode = DevExpress.Utils.DefaultBoolean.False;
            accordionControl1.OptionsMinimizing.FooterHeight = 60;
            accordionControl1.OptionsMinimizing.State = DevExpress.XtraBars.Navigation.AccordionControlState.Minimized;
            accordionControl1.RootDisplayMode = DevExpress.XtraBars.Navigation.AccordionControlRootDisplayMode.Footer;
            accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            accordionControl1.Size = new System.Drawing.Size(70, 442);
            accordionControl1.TabIndex = 1;
            accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // navigationGroup
            // 
            navigationGroup.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { accPerson, accFamily });
            navigationGroup.Expanded = true;
            navigationGroup.Name = "navigationGroup";
            navigationGroup.Text = "Navigation";
            // 
            // accPerson
            // 
            accPerson.Expanded = true;
            accPerson.Height = 60;
            accPerson.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("accPerson.ImageOptions.SvgImage");
            accPerson.Name = "accPerson";
            accPerson.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            accPerson.Tag = "PersonListView";
            accPerson.Text = "Person";
            // 
            // accFamily
            // 
            accFamily.Height = 60;
            accFamily.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("accFamily.ImageOptions.SvgImage");
            accFamily.Name = "accFamily";
            accFamily.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            accFamily.Tag = "FamilyListView";
            accFamily.Text = "Family";
            // 
            // fluentDesignFormControl1
            // 
            fluentDesignFormControl1.FluentDesignForm = this;
            fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            fluentDesignFormControl1.Size = new System.Drawing.Size(691, 31);
            fluentDesignFormControl1.TabIndex = 2;
            fluentDesignFormControl1.TabStop = false;
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(navigationFrame);
            mainPanel.Controls.Add(pnlNavigationBar);
            mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            mainPanel.Location = new System.Drawing.Point(70, 31);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new System.Drawing.Size(621, 442);
            mainPanel.TabIndex = 3;
            // 
            // navigationFrame
            // 
            navigationFrame.AllowTransitionAnimation = DevExpress.Utils.DefaultBoolean.False;
            navigationFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            navigationFrame.Location = new System.Drawing.Point(2, 37);
            navigationFrame.Name = "navigationFrame";
            navigationFrame.SelectedPage = null;
            navigationFrame.Size = new System.Drawing.Size(617, 403);
            navigationFrame.TabIndex = 2;
            navigationFrame.Text = "navigationFrame1";
            // 
            // pnlNavigationBar
            // 
            pnlNavigationBar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlNavigationBar.Controls.Add(breadCrumbEdit1);
            pnlNavigationBar.Dock = System.Windows.Forms.DockStyle.Top;
            pnlNavigationBar.Location = new System.Drawing.Point(2, 2);
            pnlNavigationBar.Name = "pnlNavigationBar";
            pnlNavigationBar.Size = new System.Drawing.Size(617, 35);
            pnlNavigationBar.TabIndex = 1;
            // 
            // breadCrumbEdit1
            // 
            breadCrumbEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            breadCrumbEdit1.Location = new System.Drawing.Point(0, 0);
            breadCrumbEdit1.Name = "breadCrumbEdit1";
            breadCrumbEdit1.Properties.AllowEdit = false;
            breadCrumbEdit1.Properties.AllowNodeDropDown = false;
            breadCrumbEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            breadCrumbEdit1.Properties.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
            breadCrumbEdit1.Properties.Appearance.Options.UseBackColor = true;
            breadCrumbEdit1.Properties.Appearance.Options.UseFont = true;
            breadCrumbEdit1.Properties.AutoHeight = false;
            breadCrumbEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            breadCrumbEdit1.Properties.ShowPathSuggestions = false;
            breadCrumbEdit1.Size = new System.Drawing.Size(617, 35);
            breadCrumbEdit1.TabIndex = 0;
            // 
            // mvvmContext
            // 
            mvvmContext.ContainerControl = this;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(691, 473);
            Controls.Add(mainPanel);
            Controls.Add(accordionControl1);
            Controls.Add(fluentDesignFormControl1);
            FluentDesignFormControl = fluentDesignFormControl1;
            Name = "MainForm";
            NavigationControl = accordionControl1;
            Text = "Arbor Familiae";
            ((System.ComponentModel.ISupportInitialize)accordionControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)fluentDesignFormControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)mainPanel).EndInit();
            mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)navigationFrame).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlNavigationBar).EndInit();
            pnlNavigationBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)breadCrumbEdit1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)mvvmContext).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accPerson;
        private DevExpress.XtraBars.Navigation.AccordionControlElement navigationGroup;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accFamily;
        private DevExpress.XtraEditors.PanelControl mainPanel;
        private DevExpress.XtraEditors.PanelControl pnlNavigationBar;
        private DevExpress.XtraEditors.BreadCrumbEdit breadCrumbEdit1;
        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
    }
}


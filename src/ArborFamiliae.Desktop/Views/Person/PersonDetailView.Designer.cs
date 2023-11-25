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
            ((System.ComponentModel.ISupportInitialize)mvvmContext1).BeginInit();
            SuspendLayout();
            // 
            // mvvmContext1
            // 
            mvvmContext1.ContainerControl = this;
            mvvmContext1.ViewModelType = typeof(PersonDetailViewModel);
            // 
            // PersonDetailView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Name = "PersonDetailView";
            Size = new System.Drawing.Size(1272, 831);
            ((System.ComponentModel.ISupportInitialize)mvvmContext1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.Utils.MVVM.MVVMContext mvvmContext1;
    }
}

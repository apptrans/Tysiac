namespace TysiacClassLibrary
{
    partial class GraczControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraczControl));
            this.labelGracz = new System.Windows.Forms.Label();
            this.pictureBoxGracz = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGracz)).BeginInit();
            this.SuspendLayout();
            // 
            // labelGracz
            // 
            resources.ApplyResources(this.labelGracz, "labelGracz");
            this.labelGracz.ForeColor = System.Drawing.Color.Transparent;
            this.labelGracz.Name = "labelGracz";
            // 
            // pictureBoxGracz
            // 
            this.pictureBoxGracz.Image = global::TysiacClassLibrary.Properties.Resources.cat;
            resources.ApplyResources(this.pictureBoxGracz, "pictureBoxGracz");
            this.pictureBoxGracz.Name = "pictureBoxGracz";
            this.pictureBoxGracz.TabStop = false;
            // 
            // GraczControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.labelGracz);
            this.Controls.Add(this.pictureBoxGracz);
            this.Name = "GraczControl";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGracz)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxGracz;
        private System.Windows.Forms.Label labelGracz;
    }
}

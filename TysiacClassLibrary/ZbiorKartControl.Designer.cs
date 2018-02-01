namespace TysiacClassLibrary
{
    partial class ZbiorKartControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZbiorKartControl));
            this.labelLicznik = new System.Windows.Forms.Label();
            this.labelNazwa = new System.Windows.Forms.Label();
            this.buttonSort = new System.Windows.Forms.Button();
            this.pictureBoxKarta = new System.Windows.Forms.PictureBox();
            this.toolTipZbiorKart = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKarta)).BeginInit();
            this.SuspendLayout();
            // 
            // labelLicznik
            // 
            resources.ApplyResources(this.labelLicznik, "labelLicznik");
            this.labelLicznik.BackColor = System.Drawing.Color.White;
            this.labelLicznik.Name = "labelLicznik";
            this.toolTipZbiorKart.SetToolTip(this.labelLicznik, resources.GetString("labelLicznik.ToolTip"));
            // 
            // labelNazwa
            // 
            resources.ApplyResources(this.labelNazwa, "labelNazwa");
            this.labelNazwa.BackColor = System.Drawing.Color.Transparent;
            this.labelNazwa.ForeColor = System.Drawing.Color.White;
            this.labelNazwa.Name = "labelNazwa";
            // 
            // buttonSort
            // 
            this.buttonSort.BackColor = System.Drawing.SystemColors.ControlDark;
            resources.ApplyResources(this.buttonSort, "buttonSort");
            this.buttonSort.Name = "buttonSort";
            this.toolTipZbiorKart.SetToolTip(this.buttonSort, resources.GetString("buttonSort.ToolTip"));
            this.buttonSort.UseVisualStyleBackColor = false;
            this.buttonSort.Click += new System.EventHandler(this.buttonSort_Click);
            // 
            // pictureBoxKarta
            // 
            this.pictureBoxKarta.BackgroundImage = global::TysiacClassLibrary.Properties.Resources.cardSkin;
            resources.ApplyResources(this.pictureBoxKarta, "pictureBoxKarta");
            this.pictureBoxKarta.Name = "pictureBoxKarta";
            this.pictureBoxKarta.TabStop = false;
            // 
            // toolTipZbiorKart
            // 
            this.toolTipZbiorKart.IsBalloon = true;
            this.toolTipZbiorKart.ShowAlways = true;
            // 
            // ZbiorKartControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.buttonSort);
            this.Controls.Add(this.pictureBoxKarta);
            this.Controls.Add(this.labelNazwa);
            this.Controls.Add(this.labelLicznik);
            this.Name = "ZbiorKartControl";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKarta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLicznik;
        private System.Windows.Forms.Label labelNazwa;
        private System.Windows.Forms.PictureBox pictureBoxKarta;
        private System.Windows.Forms.Button buttonSort;
        private System.Windows.Forms.ToolTip toolTipZbiorKart;
    }
}

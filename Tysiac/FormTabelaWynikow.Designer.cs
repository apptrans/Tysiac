namespace Tysiac
{
    partial class FormTabelaWynikow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTabelaWynikow));
            this.listViewWyniki = new System.Windows.Forms.ListView();
            this.columnHeaderLp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderGraczRozdajacy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderGracz1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderGracz2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderGracz3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewWyniki
            // 
            resources.ApplyResources(this.listViewWyniki, "listViewWyniki");
            this.listViewWyniki.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderLp,
            this.columnHeaderGraczRozdajacy,
            this.columnHeaderGracz1,
            this.columnHeaderGracz2,
            this.columnHeaderGracz3});
            this.listViewWyniki.Name = "listViewWyniki";
            this.listViewWyniki.UseCompatibleStateImageBehavior = false;
            this.listViewWyniki.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderLp
            // 
            resources.ApplyResources(this.columnHeaderLp, "columnHeaderLp");
            // 
            // columnHeaderGraczRozdajacy
            // 
            resources.ApplyResources(this.columnHeaderGraczRozdajacy, "columnHeaderGraczRozdajacy");
            // 
            // columnHeaderGracz1
            // 
            resources.ApplyResources(this.columnHeaderGracz1, "columnHeaderGracz1");
            // 
            // columnHeaderGracz2
            // 
            resources.ApplyResources(this.columnHeaderGracz2, "columnHeaderGracz2");
            // 
            // columnHeaderGracz3
            // 
            resources.ApplyResources(this.columnHeaderGracz3, "columnHeaderGracz3");
            // 
            // buttonClose
            // 
            resources.ApplyResources(this.buttonClose, "buttonClose");
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonWyniki_Click);
            // 
            // FormTabelaWynikow
            // 
            this.AcceptButton = this.buttonClose;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.listViewWyniki);
            this.Name = "FormTabelaWynikow";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewWyniki;
        private System.Windows.Forms.ColumnHeader columnHeaderLp;
        private System.Windows.Forms.ColumnHeader columnHeaderGraczRozdajacy;
        private System.Windows.Forms.ColumnHeader columnHeaderGracz1;
        private System.Windows.Forms.ColumnHeader columnHeaderGracz2;
        private System.Windows.Forms.ColumnHeader columnHeaderGracz3;
        private System.Windows.Forms.Button buttonClose;
    }
}
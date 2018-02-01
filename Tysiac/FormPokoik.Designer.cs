namespace Tysiac
{
    partial class FormPokoik
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPokoik));
            this.labelStoliki = new System.Windows.Forms.Label();
            this.buttonNowyStolik = new System.Windows.Forms.Button();
            this.listBoxStoliki = new System.Windows.Forms.ListBox();
            this.buttonGracz1 = new System.Windows.Forms.Button();
            this.buttonGracz2 = new System.Windows.Forms.Button();
            this.buttonGracz3 = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonSendMessage = new System.Windows.Forms.Button();
            this.richTextTxMessage = new System.Windows.Forms.RichTextBox();
            this.textBoxConnectStatus = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextRxMessage = new System.Windows.Forms.RichTextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.labelNickGracza = new System.Windows.Forms.Label();
            this.textBoxNickGracza = new System.Windows.Forms.TextBox();
            this.buttonUsunStolik = new System.Windows.Forms.Button();
            this.buttonLogon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelStoliki
            // 
            resources.ApplyResources(this.labelStoliki, "labelStoliki");
            this.labelStoliki.Name = "labelStoliki";
            // 
            // buttonNowyStolik
            // 
            resources.ApplyResources(this.buttonNowyStolik, "buttonNowyStolik");
            this.buttonNowyStolik.Name = "buttonNowyStolik";
            this.buttonNowyStolik.UseVisualStyleBackColor = true;
            this.buttonNowyStolik.Click += new System.EventHandler(this.buttonNowyStolik_Click);
            // 
            // listBoxStoliki
            // 
            this.listBoxStoliki.DisplayMember = "Rozmowa";
            this.listBoxStoliki.FormattingEnabled = true;
            resources.ApplyResources(this.listBoxStoliki, "listBoxStoliki");
            this.listBoxStoliki.Name = "listBoxStoliki";
            this.listBoxStoliki.ValueMember = "Rozmowa";
            this.listBoxStoliki.SelectedIndexChanged += new System.EventHandler(this.listBoxStoliki_SelectedIndexChanged);
            // 
            // buttonGracz1
            // 
            resources.ApplyResources(this.buttonGracz1, "buttonGracz1");
            this.buttonGracz1.Name = "buttonGracz1";
            this.buttonGracz1.UseVisualStyleBackColor = true;
            this.buttonGracz1.Click += new System.EventHandler(this.buttonGracz1_Click);
            // 
            // buttonGracz2
            // 
            resources.ApplyResources(this.buttonGracz2, "buttonGracz2");
            this.buttonGracz2.Name = "buttonGracz2";
            this.buttonGracz2.UseVisualStyleBackColor = true;
            this.buttonGracz2.Click += new System.EventHandler(this.buttonGracz2_Click);
            // 
            // buttonGracz3
            // 
            resources.ApplyResources(this.buttonGracz3, "buttonGracz3");
            this.buttonGracz3.Name = "buttonGracz3";
            this.buttonGracz3.UseVisualStyleBackColor = true;
            this.buttonGracz3.Click += new System.EventHandler(this.buttonGracz3_Click);
            // 
            // buttonClose
            // 
            resources.ApplyResources(this.buttonClose, "buttonClose");
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Click += new System.EventHandler(this.ButtonCloseClick);
            // 
            // buttonSendMessage
            // 
            resources.ApplyResources(this.buttonSendMessage, "buttonSendMessage");
            this.buttonSendMessage.Name = "buttonSendMessage";
            this.buttonSendMessage.Click += new System.EventHandler(this.ButtonSendMessageClick);
            // 
            // richTextTxMessage
            // 
            resources.ApplyResources(this.richTextTxMessage, "richTextTxMessage");
            this.richTextTxMessage.Name = "richTextTxMessage";
            // 
            // textBoxConnectStatus
            // 
            this.textBoxConnectStatus.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxConnectStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.textBoxConnectStatus, "textBoxConnectStatus");
            this.textBoxConnectStatus.Name = "textBoxConnectStatus";
            this.textBoxConnectStatus.ReadOnly = true;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // richTextRxMessage
            // 
            resources.ApplyResources(this.richTextRxMessage, "richTextRxMessage");
            this.richTextRxMessage.Name = "richTextRxMessage";
            this.richTextRxMessage.ReadOnly = true;
            // 
            // textBoxPort
            // 
            resources.ApplyResources(this.textBoxPort, "textBoxPort");
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.ReadOnly = true;
            // 
            // buttonConnect
            // 
            resources.ApplyResources(this.buttonConnect, "buttonConnect");
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Click += new System.EventHandler(this.ButtonConnectClick);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // textBoxIP
            // 
            resources.ApplyResources(this.textBoxIP, "textBoxIP");
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.ReadOnly = true;
            // 
            // buttonDisconnect
            // 
            resources.ApplyResources(this.buttonDisconnect, "buttonDisconnect");
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Click += new System.EventHandler(this.ButtonDisconnectClick);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // btnClear
            // 
            resources.ApplyResources(this.btnClear, "btnClear");
            this.btnClear.Name = "btnClear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // labelNickGracza
            // 
            resources.ApplyResources(this.labelNickGracza, "labelNickGracza");
            this.labelNickGracza.Name = "labelNickGracza";
            // 
            // textBoxNickGracza
            // 
            resources.ApplyResources(this.textBoxNickGracza, "textBoxNickGracza");
            this.textBoxNickGracza.Name = "textBoxNickGracza";
            this.textBoxNickGracza.TextChanged += new System.EventHandler(this.textBoxNickGracza_TextChanged);
            // 
            // buttonUsunStolik
            // 
            resources.ApplyResources(this.buttonUsunStolik, "buttonUsunStolik");
            this.buttonUsunStolik.Name = "buttonUsunStolik";
            this.buttonUsunStolik.UseVisualStyleBackColor = true;
            this.buttonUsunStolik.Click += new System.EventHandler(this.buttonUsunStolik_Click);
            // 
            // buttonLogon
            // 
            resources.ApplyResources(this.buttonLogon, "buttonLogon");
            this.buttonLogon.Name = "buttonLogon";
            this.buttonLogon.UseVisualStyleBackColor = true;
            this.buttonLogon.Click += new System.EventHandler(this.buttonLogon_Click);
            // 
            // FormPokoik
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonLogon);
            this.Controls.Add(this.buttonUsunStolik);
            this.Controls.Add(this.labelNickGracza);
            this.Controls.Add(this.textBoxNickGracza);
            this.Controls.Add(this.labelStoliki);
            this.Controls.Add(this.buttonGracz3);
            this.Controls.Add(this.buttonGracz2);
            this.Controls.Add(this.buttonGracz1);
            this.Controls.Add(this.listBoxStoliki);
            this.Controls.Add(this.buttonNowyStolik);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.buttonDisconnect);
            this.Controls.Add(this.buttonSendMessage);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.textBoxConnectStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.richTextTxMessage);
            this.Controls.Add(this.richTextRxMessage);
            this.Name = "FormPokoik";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormPokoik_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelStoliki;
        private System.Windows.Forms.Button buttonNowyStolik;
        private System.Windows.Forms.ListBox listBoxStoliki;
        private System.Windows.Forms.Button buttonGracz1;
        private System.Windows.Forms.Button buttonGracz2;
        private System.Windows.Forms.Button buttonGracz3;

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.RichTextBox richTextRxMessage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxConnectStatus;
        private System.Windows.Forms.RichTextBox richTextTxMessage;
        private System.Windows.Forms.Button buttonSendMessage;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelNickGracza;
        private System.Windows.Forms.TextBox textBoxNickGracza;
        private System.Windows.Forms.Button buttonUsunStolik;
        private System.Windows.Forms.Button buttonLogon;
    }
}


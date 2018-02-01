namespace TysiacServer
{
    partial class formTysiacServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formTysiacServer));
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonSendMsg = new System.Windows.Forms.Button();
            this.buttonStartListen = new System.Windows.Forms.Button();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.richTextBoxSendMsg = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonStopListen = new System.Windows.Forms.Button();
            this.textBoxMsg = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.richTextBoxReceivedMsg = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            resources.ApplyResources(this.buttonClose, "buttonClose");
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Click += new System.EventHandler(this.ButtonCloseClick);
            // 
            // buttonSendMsg
            // 
            resources.ApplyResources(this.buttonSendMsg, "buttonSendMsg");
            this.buttonSendMsg.Name = "buttonSendMsg";
            this.buttonSendMsg.Click += new System.EventHandler(this.ButtonSendMsgClick);
            // 
            // buttonStartListen
            // 
            resources.ApplyResources(this.buttonStartListen, "buttonStartListen");
            this.buttonStartListen.Name = "buttonStartListen";
            this.buttonStartListen.Click += new System.EventHandler(this.ButtonStartListenClick);
            // 
            // textBoxIP
            // 
            resources.ApplyResources(this.textBoxIP, "textBoxIP");
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.ReadOnly = true;
            // 
            // richTextBoxSendMsg
            // 
            resources.ApplyResources(this.richTextBoxSendMsg, "richTextBoxSendMsg");
            this.richTextBoxSendMsg.Name = "richTextBoxSendMsg";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // buttonStopListen
            // 
            resources.ApplyResources(this.buttonStopListen, "buttonStopListen");
            this.buttonStopListen.Name = "buttonStopListen";
            this.buttonStopListen.Click += new System.EventHandler(this.ButtonStopListenClick);
            // 
            // textBoxMsg
            // 
            this.textBoxMsg.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxMsg.ForeColor = System.Drawing.SystemColors.HotTrack;
            resources.ApplyResources(this.textBoxMsg, "textBoxMsg");
            this.textBoxMsg.Name = "textBoxMsg";
            this.textBoxMsg.ReadOnly = true;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // textBoxPort
            // 
            resources.ApplyResources(this.textBoxPort, "textBoxPort");
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.ReadOnly = true;
            // 
            // richTextBoxReceivedMsg
            // 
            resources.ApplyResources(this.richTextBoxReceivedMsg, "richTextBoxReceivedMsg");
            this.richTextBoxReceivedMsg.Name = "richTextBoxReceivedMsg";
            this.richTextBoxReceivedMsg.ReadOnly = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // labelStatus
            // 
            resources.ApplyResources(this.labelStatus, "labelStatus");
            this.labelStatus.Name = "labelStatus";
            // 
            // btnClear
            // 
            resources.ApplyResources(this.btnClear, "btnClear");
            this.btnClear.Name = "btnClear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // formTysiacServer
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.textBoxMsg);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.richTextBoxReceivedMsg);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonSendMsg);
            this.Controls.Add(this.richTextBoxSendMsg);
            this.Controls.Add(this.buttonStopListen);
            this.Controls.Add(this.buttonStartListen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "formTysiacServer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formTysiacServer_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBoxReceivedMsg;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxMsg;
        private System.Windows.Forms.Button buttonStopListen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBoxSendMsg;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.Button buttonStartListen;
        private System.Windows.Forms.Button buttonSendMsg;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button btnClear;
    }
}


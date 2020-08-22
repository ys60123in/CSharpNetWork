namespace TCPServer
{
    partial class TCPServer
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.listBox_User = new System.Windows.Forms.ListBox();
            this.label_IP = new System.Windows.Forms.Label();
            this.label_Port = new System.Windows.Forms.Label();
            this.textBox_ServerIP = new System.Windows.Forms.TextBox();
            this.textBox_ServerPort = new System.Windows.Forms.TextBox();
            this.button_Start = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "線上使用者";
            // 
            // listBox_User
            // 
            this.listBox_User.FormattingEnabled = true;
            this.listBox_User.ItemHeight = 12;
            this.listBox_User.Location = new System.Drawing.Point(12, 24);
            this.listBox_User.Name = "listBox_User";
            this.listBox_User.Size = new System.Drawing.Size(120, 112);
            this.listBox_User.TabIndex = 1;
            // 
            // label_IP
            // 
            this.label_IP.AutoSize = true;
            this.label_IP.Location = new System.Drawing.Point(148, 29);
            this.label_IP.Name = "label_IP";
            this.label_IP.Size = new System.Drawing.Size(48, 12);
            this.label_IP.TabIndex = 2;
            this.label_IP.Text = "Server IP";
            // 
            // label_Port
            // 
            this.label_Port.AutoSize = true;
            this.label_Port.Location = new System.Drawing.Point(139, 61);
            this.label_Port.Name = "label_Port";
            this.label_Port.Size = new System.Drawing.Size(57, 12);
            this.label_Port.TabIndex = 3;
            this.label_Port.Text = "Server Port";
            // 
            // textBox_ServerIP
            // 
            this.textBox_ServerIP.Location = new System.Drawing.Point(208, 26);
            this.textBox_ServerIP.Name = "textBox_ServerIP";
            this.textBox_ServerIP.Size = new System.Drawing.Size(100, 22);
            this.textBox_ServerIP.TabIndex = 4;
            // 
            // textBox_ServerPort
            // 
            this.textBox_ServerPort.Location = new System.Drawing.Point(208, 58);
            this.textBox_ServerPort.Name = "textBox_ServerPort";
            this.textBox_ServerPort.Size = new System.Drawing.Size(100, 22);
            this.textBox_ServerPort.TabIndex = 5;
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(233, 113);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(75, 23);
            this.button_Start.TabIndex = 6;
            this.button_Start.Text = "啟動伺服器";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // TCPServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 147);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.textBox_ServerPort);
            this.Controls.Add(this.textBox_ServerIP);
            this.Controls.Add(this.label_Port);
            this.Controls.Add(this.label_IP);
            this.Controls.Add(this.listBox_User);
            this.Controls.Add(this.label1);
            this.Name = "TCPServer";
            this.Text = "TCP Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TCPServer_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox_User;
        private System.Windows.Forms.Label label_IP;
        private System.Windows.Forms.Label label_Port;
        private System.Windows.Forms.TextBox textBox_ServerIP;
        private System.Windows.Forms.TextBox textBox_ServerPort;
        private System.Windows.Forms.Button button_Start;
    }
}


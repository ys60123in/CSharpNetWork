namespace UDPMessenger
{
    partial class UDPMsgr
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
            this.label_ListenPort = new System.Windows.Forms.Label();
            this.label_ReceiveMsg = new System.Windows.Forms.Label();
            this.label_TargetIP = new System.Windows.Forms.Label();
            this.label_TargetPort = new System.Windows.Forms.Label();
            this.label_TransferMsg = new System.Windows.Forms.Label();
            this.textBox_ListenPort = new System.Windows.Forms.TextBox();
            this.textBox_ReceiveMsg = new System.Windows.Forms.TextBox();
            this.textBox_TargetIP = new System.Windows.Forms.TextBox();
            this.textBox_TargetPort = new System.Windows.Forms.TextBox();
            this.textBox_TransferMsg = new System.Windows.Forms.TextBox();
            this.button_StartReceive = new System.Windows.Forms.Button();
            this.button_Transfer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_ListenPort
            // 
            this.label_ListenPort.AutoSize = true;
            this.label_ListenPort.Location = new System.Drawing.Point(22, 18);
            this.label_ListenPort.Name = "label_ListenPort";
            this.label_ListenPort.Size = new System.Drawing.Size(48, 12);
            this.label_ListenPort.TabIndex = 0;
            this.label_ListenPort.Text = "接聽Port";
            // 
            // label_ReceiveMsg
            // 
            this.label_ReceiveMsg.AutoSize = true;
            this.label_ReceiveMsg.Location = new System.Drawing.Point(22, 52);
            this.label_ReceiveMsg.Name = "label_ReceiveMsg";
            this.label_ReceiveMsg.Size = new System.Drawing.Size(53, 12);
            this.label_ReceiveMsg.TabIndex = 1;
            this.label_ReceiveMsg.Text = "接收文字";
            // 
            // label_TargetIP
            // 
            this.label_TargetIP.AutoSize = true;
            this.label_TargetIP.Location = new System.Drawing.Point(31, 105);
            this.label_TargetIP.Name = "label_TargetIP";
            this.label_TargetIP.Size = new System.Drawing.Size(39, 12);
            this.label_TargetIP.TabIndex = 2;
            this.label_TargetIP.Text = "目標IP";
            // 
            // label_TargetPort
            // 
            this.label_TargetPort.AutoSize = true;
            this.label_TargetPort.Location = new System.Drawing.Point(22, 138);
            this.label_TargetPort.Name = "label_TargetPort";
            this.label_TargetPort.Size = new System.Drawing.Size(48, 12);
            this.label_TargetPort.TabIndex = 3;
            this.label_TargetPort.Text = "目標Port";
            // 
            // label_TransferMsg
            // 
            this.label_TransferMsg.AutoSize = true;
            this.label_TransferMsg.Location = new System.Drawing.Point(22, 172);
            this.label_TransferMsg.Name = "label_TransferMsg";
            this.label_TransferMsg.Size = new System.Drawing.Size(53, 12);
            this.label_TransferMsg.TabIndex = 4;
            this.label_TransferMsg.Text = "傳送文字";
            // 
            // textBox_ListenPort
            // 
            this.textBox_ListenPort.Location = new System.Drawing.Point(76, 15);
            this.textBox_ListenPort.Name = "textBox_ListenPort";
            this.textBox_ListenPort.Size = new System.Drawing.Size(100, 22);
            this.textBox_ListenPort.TabIndex = 5;
            // 
            // textBox_ReceiveMsg
            // 
            this.textBox_ReceiveMsg.Location = new System.Drawing.Point(76, 49);
            this.textBox_ReceiveMsg.Name = "textBox_ReceiveMsg";
            this.textBox_ReceiveMsg.Size = new System.Drawing.Size(402, 22);
            this.textBox_ReceiveMsg.TabIndex = 6;
            // 
            // textBox_TargetIP
            // 
            this.textBox_TargetIP.Location = new System.Drawing.Point(76, 102);
            this.textBox_TargetIP.Name = "textBox_TargetIP";
            this.textBox_TargetIP.Size = new System.Drawing.Size(100, 22);
            this.textBox_TargetIP.TabIndex = 7;
            // 
            // textBox_TargetPort
            // 
            this.textBox_TargetPort.Location = new System.Drawing.Point(76, 135);
            this.textBox_TargetPort.Name = "textBox_TargetPort";
            this.textBox_TargetPort.Size = new System.Drawing.Size(100, 22);
            this.textBox_TargetPort.TabIndex = 8;
            // 
            // textBox_TransferMsg
            // 
            this.textBox_TransferMsg.Location = new System.Drawing.Point(76, 169);
            this.textBox_TransferMsg.Name = "textBox_TransferMsg";
            this.textBox_TransferMsg.Size = new System.Drawing.Size(402, 22);
            this.textBox_TransferMsg.TabIndex = 9;
            // 
            // button_StartReceive
            // 
            this.button_StartReceive.Location = new System.Drawing.Point(484, 48);
            this.button_StartReceive.Name = "button_StartReceive";
            this.button_StartReceive.Size = new System.Drawing.Size(75, 23);
            this.button_StartReceive.TabIndex = 10;
            this.button_StartReceive.Text = "啟動接收";
            this.button_StartReceive.UseVisualStyleBackColor = true;
            this.button_StartReceive.Click += new System.EventHandler(this.button_StartReceive_Click);
            // 
            // button_Transfer
            // 
            this.button_Transfer.Location = new System.Drawing.Point(484, 168);
            this.button_Transfer.Name = "button_Transfer";
            this.button_Transfer.Size = new System.Drawing.Size(75, 23);
            this.button_Transfer.TabIndex = 11;
            this.button_Transfer.Text = "傳送";
            this.button_Transfer.UseVisualStyleBackColor = true;
            this.button_Transfer.Click += new System.EventHandler(this.button_Transfer_Click);
            // 
            // UDPMsgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 207);
            this.Controls.Add(this.button_Transfer);
            this.Controls.Add(this.button_StartReceive);
            this.Controls.Add(this.textBox_TransferMsg);
            this.Controls.Add(this.textBox_TargetPort);
            this.Controls.Add(this.textBox_TargetIP);
            this.Controls.Add(this.textBox_ReceiveMsg);
            this.Controls.Add(this.textBox_ListenPort);
            this.Controls.Add(this.label_TransferMsg);
            this.Controls.Add(this.label_TargetPort);
            this.Controls.Add(this.label_TargetIP);
            this.Controls.Add(this.label_ReceiveMsg);
            this.Controls.Add(this.label_ListenPort);
            this.Name = "UDPMsgr";
            this.Text = "UDP即時通";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UDPMsgr_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_ListenPort;
        private System.Windows.Forms.Label label_ReceiveMsg;
        private System.Windows.Forms.Label label_TargetIP;
        private System.Windows.Forms.Label label_TargetPort;
        private System.Windows.Forms.Label label_TransferMsg;
        private System.Windows.Forms.TextBox textBox_ListenPort;
        private System.Windows.Forms.TextBox textBox_ReceiveMsg;
        private System.Windows.Forms.TextBox textBox_TargetIP;
        private System.Windows.Forms.TextBox textBox_TargetPort;
        private System.Windows.Forms.TextBox textBox_TransferMsg;
        private System.Windows.Forms.Button button_StartReceive;
        private System.Windows.Forms.Button button_Transfer;
    }
}


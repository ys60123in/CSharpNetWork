namespace TCPChatRoomClient
{
    partial class TCPChatRoomClient
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
            this.button_Login = new System.Windows.Forms.Button();
            this.label_ServerIP = new System.Windows.Forms.Label();
            this.textBox_ServerIP = new System.Windows.Forms.TextBox();
            this.label_UserName = new System.Windows.Forms.Label();
            this.label_ServerPort = new System.Windows.Forms.Label();
            this.textBox_UserName = new System.Windows.Forms.TextBox();
            this.textBox_ServerPort = new System.Windows.Forms.TextBox();
            this.button_Broadcast = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Messages = new System.Windows.Forms.TextBox();
            this.listBox_User = new System.Windows.Forms.ListBox();
            this.button_Enter = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Msg = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_Login
            // 
            this.button_Login.Location = new System.Drawing.Point(273, 61);
            this.button_Login.Name = "button_Login";
            this.button_Login.Size = new System.Drawing.Size(75, 23);
            this.button_Login.TabIndex = 0;
            this.button_Login.Text = "登入伺服器";
            this.button_Login.UseVisualStyleBackColor = true;
            this.button_Login.Click += new System.EventHandler(this.button_Login_Click);
            // 
            // label_ServerIP
            // 
            this.label_ServerIP.AutoSize = true;
            this.label_ServerIP.Location = new System.Drawing.Point(8, 23);
            this.label_ServerIP.Name = "label_ServerIP";
            this.label_ServerIP.Size = new System.Drawing.Size(51, 12);
            this.label_ServerIP.TabIndex = 1;
            this.label_ServerIP.Text = "伺服器IP";
            // 
            // textBox_ServerIP
            // 
            this.textBox_ServerIP.Location = new System.Drawing.Point(65, 20);
            this.textBox_ServerIP.Name = "textBox_ServerIP";
            this.textBox_ServerIP.Size = new System.Drawing.Size(100, 22);
            this.textBox_ServerIP.TabIndex = 2;
            // 
            // label_UserName
            // 
            this.label_UserName.AutoSize = true;
            this.label_UserName.Location = new System.Drawing.Point(6, 64);
            this.label_UserName.Name = "label_UserName";
            this.label_UserName.Size = new System.Drawing.Size(53, 12);
            this.label_UserName.TabIndex = 3;
            this.label_UserName.Text = "玩家名稱";
            // 
            // label_ServerPort
            // 
            this.label_ServerPort.AutoSize = true;
            this.label_ServerPort.Location = new System.Drawing.Point(182, 23);
            this.label_ServerPort.Name = "label_ServerPort";
            this.label_ServerPort.Size = new System.Drawing.Size(60, 12);
            this.label_ServerPort.TabIndex = 4;
            this.label_ServerPort.Text = "伺服器Port";
            // 
            // textBox_UserName
            // 
            this.textBox_UserName.Location = new System.Drawing.Point(65, 61);
            this.textBox_UserName.Name = "textBox_UserName";
            this.textBox_UserName.Size = new System.Drawing.Size(100, 22);
            this.textBox_UserName.TabIndex = 5;
            // 
            // textBox_ServerPort
            // 
            this.textBox_ServerPort.Location = new System.Drawing.Point(248, 20);
            this.textBox_ServerPort.Name = "textBox_ServerPort";
            this.textBox_ServerPort.Size = new System.Drawing.Size(100, 22);
            this.textBox_ServerPort.TabIndex = 6;
            // 
            // button_Broadcast
            // 
            this.button_Broadcast.Location = new System.Drawing.Point(354, 19);
            this.button_Broadcast.Name = "button_Broadcast";
            this.button_Broadcast.Size = new System.Drawing.Size(84, 23);
            this.button_Broadcast.TabIndex = 7;
            this.button_Broadcast.Text = "廣播";
            this.button_Broadcast.UseVisualStyleBackColor = true;
            this.button_Broadcast.Click += new System.EventHandler(this.button_Broadcast_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(365, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "線上使用者";
            // 
            // textBox_Messages
            // 
            this.textBox_Messages.Location = new System.Drawing.Point(8, 95);
            this.textBox_Messages.Multiline = true;
            this.textBox_Messages.Name = "textBox_Messages";
            this.textBox_Messages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Messages.Size = new System.Drawing.Size(340, 208);
            this.textBox_Messages.TabIndex = 9;
            // 
            // listBox_User
            // 
            this.listBox_User.FormattingEnabled = true;
            this.listBox_User.ItemHeight = 12;
            this.listBox_User.Location = new System.Drawing.Point(354, 95);
            this.listBox_User.Name = "listBox_User";
            this.listBox_User.Size = new System.Drawing.Size(84, 208);
            this.listBox_User.TabIndex = 10;
            // 
            // button_Enter
            // 
            this.button_Enter.Enabled = false;
            this.button_Enter.Location = new System.Drawing.Point(354, 309);
            this.button_Enter.Name = "button_Enter";
            this.button_Enter.Size = new System.Drawing.Size(84, 23);
            this.button_Enter.TabIndex = 11;
            this.button_Enter.Text = "送出";
            this.button_Enter.UseVisualStyleBackColor = true;
            this.button_Enter.Click += new System.EventHandler(this.button_Enter_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 314);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "發言內容";
            // 
            // textBox_Msg
            // 
            this.textBox_Msg.Location = new System.Drawing.Point(65, 309);
            this.textBox_Msg.Name = "textBox_Msg";
            this.textBox_Msg.Size = new System.Drawing.Size(283, 22);
            this.textBox_Msg.TabIndex = 13;
            // 
            // TCPChatRoomClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 339);
            this.Controls.Add(this.textBox_Msg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_Enter);
            this.Controls.Add(this.listBox_User);
            this.Controls.Add(this.textBox_Messages);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Broadcast);
            this.Controls.Add(this.textBox_ServerPort);
            this.Controls.Add(this.textBox_UserName);
            this.Controls.Add(this.label_ServerPort);
            this.Controls.Add(this.label_UserName);
            this.Controls.Add(this.textBox_ServerIP);
            this.Controls.Add(this.label_ServerIP);
            this.Controls.Add(this.button_Login);
            this.Name = "TCPChatRoomClient";
            this.Text = "TCP Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TCPClient_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Login;
        private System.Windows.Forms.Label label_ServerIP;
        private System.Windows.Forms.TextBox textBox_ServerIP;
        private System.Windows.Forms.Label label_UserName;
        private System.Windows.Forms.Label label_ServerPort;
        private System.Windows.Forms.TextBox textBox_UserName;
        private System.Windows.Forms.TextBox textBox_ServerPort;
        private System.Windows.Forms.Button button_Broadcast;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Messages;
        private System.Windows.Forms.ListBox listBox_User;
        private System.Windows.Forms.Button button_Enter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Msg;
    }
}


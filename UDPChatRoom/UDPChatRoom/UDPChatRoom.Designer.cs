namespace UDPChatRoom
{
    partial class UDPChatRoom
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
            this.label_OnlineUser = new System.Windows.Forms.Label();
            this.label_Msg = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listBox_OnlineUser = new System.Windows.Forms.ListBox();
            this.listBox_Msg = new System.Windows.Forms.ListBox();
            this.textBox_User = new System.Windows.Forms.TextBox();
            this.textBox_Msg = new System.Windows.Forms.TextBox();
            this.button_Connect = new System.Windows.Forms.Button();
            this.button_Broadcast = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_OnlineUser
            // 
            this.label_OnlineUser.AutoSize = true;
            this.label_OnlineUser.Location = new System.Drawing.Point(46, 13);
            this.label_OnlineUser.Name = "label_OnlineUser";
            this.label_OnlineUser.Size = new System.Drawing.Size(65, 12);
            this.label_OnlineUser.TabIndex = 0;
            this.label_OnlineUser.Text = "線上使用者";
            // 
            // label_Msg
            // 
            this.label_Msg.AutoSize = true;
            this.label_Msg.Location = new System.Drawing.Point(370, 13);
            this.label_Msg.Name = "label_Msg";
            this.label_Msg.Size = new System.Drawing.Size(53, 12);
            this.label_Msg.TabIndex = 1;
            this.label_Msg.Text = "訊息視窗";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(159, 285);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "我是：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(159, 315);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "訊息：";
            // 
            // listBox_OnlineUser
            // 
            this.listBox_OnlineUser.FormattingEnabled = true;
            this.listBox_OnlineUser.ItemHeight = 12;
            this.listBox_OnlineUser.Location = new System.Drawing.Point(12, 33);
            this.listBox_OnlineUser.Name = "listBox_OnlineUser";
            this.listBox_OnlineUser.Size = new System.Drawing.Size(141, 328);
            this.listBox_OnlineUser.TabIndex = 4;
            // 
            // listBox_Msg
            // 
            this.listBox_Msg.FormattingEnabled = true;
            this.listBox_Msg.ItemHeight = 12;
            this.listBox_Msg.Location = new System.Drawing.Point(159, 33);
            this.listBox_Msg.Name = "listBox_Msg";
            this.listBox_Msg.Size = new System.Drawing.Size(470, 232);
            this.listBox_Msg.TabIndex = 5;
            // 
            // textBox_User
            // 
            this.textBox_User.Location = new System.Drawing.Point(206, 282);
            this.textBox_User.Name = "textBox_User";
            this.textBox_User.Size = new System.Drawing.Size(342, 22);
            this.textBox_User.TabIndex = 6;
            // 
            // textBox_Msg
            // 
            this.textBox_Msg.Location = new System.Drawing.Point(206, 312);
            this.textBox_Msg.Name = "textBox_Msg";
            this.textBox_Msg.Size = new System.Drawing.Size(423, 22);
            this.textBox_Msg.TabIndex = 7;
            this.textBox_Msg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Msg_KeyDown);
            // 
            // button_Connect
            // 
            this.button_Connect.Location = new System.Drawing.Point(554, 281);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(75, 23);
            this.button_Connect.TabIndex = 8;
            this.button_Connect.Text = "上線";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // button_Broadcast
            // 
            this.button_Broadcast.Location = new System.Drawing.Point(554, 340);
            this.button_Broadcast.Name = "button_Broadcast";
            this.button_Broadcast.Size = new System.Drawing.Size(75, 23);
            this.button_Broadcast.TabIndex = 9;
            this.button_Broadcast.Text = "廣播";
            this.button_Broadcast.UseVisualStyleBackColor = true;
            this.button_Broadcast.Click += new System.EventHandler(this.button_Broadcast_Click);
            // 
            // UDPChatRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 369);
            this.Controls.Add(this.button_Broadcast);
            this.Controls.Add(this.button_Connect);
            this.Controls.Add(this.textBox_Msg);
            this.Controls.Add(this.textBox_User);
            this.Controls.Add(this.listBox_Msg);
            this.Controls.Add(this.listBox_OnlineUser);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_Msg);
            this.Controls.Add(this.label_OnlineUser);
            this.Name = "UDPChatRoom";
            this.Text = "UDP聊天室";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UDPChatRoom_FormClosing);
            this.Load += new System.EventHandler(this.UDPChatRoom_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_OnlineUser;
        private System.Windows.Forms.Label label_Msg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBox_OnlineUser;
        private System.Windows.Forms.ListBox listBox_Msg;
        private System.Windows.Forms.TextBox textBox_User;
        private System.Windows.Forms.TextBox textBox_Msg;
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.Button button_Broadcast;
    }
}


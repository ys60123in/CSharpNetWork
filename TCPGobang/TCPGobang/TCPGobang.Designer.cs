namespace TCPGobang
{
    partial class TCPGobang
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
            this.panel_Board = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_ServerIP = new System.Windows.Forms.TextBox();
            this.textBox_ServerPort = new System.Windows.Forms.TextBox();
            this.textBox_UserName = new System.Windows.Forms.TextBox();
            this.button_Login = new System.Windows.Forms.Button();
            this.listBox_OnlineUser = new System.Windows.Forms.ListBox();
            this.textBox_SysMsg = new System.Windows.Forms.TextBox();
            this.button_Reset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel_Board
            // 
            this.panel_Board.BackColor = System.Drawing.Color.White;
            this.panel_Board.Location = new System.Drawing.Point(0, 0);
            this.panel_Board.Name = "panel_Board";
            this.panel_Board.Size = new System.Drawing.Size(570, 570);
            this.panel_Board.TabIndex = 0;
            this.panel_Board.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_Board_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(576, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "伺服器IP：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(576, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "伺服器Port：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(576, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "玩家名稱：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(576, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "線上使用者";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(576, 498);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "系統訊息";
            // 
            // textBox_ServerIP
            // 
            this.textBox_ServerIP.Location = new System.Drawing.Point(578, 24);
            this.textBox_ServerIP.Name = "textBox_ServerIP";
            this.textBox_ServerIP.Size = new System.Drawing.Size(120, 22);
            this.textBox_ServerIP.TabIndex = 6;
            // 
            // textBox_ServerPort
            // 
            this.textBox_ServerPort.Location = new System.Drawing.Point(578, 73);
            this.textBox_ServerPort.Name = "textBox_ServerPort";
            this.textBox_ServerPort.Size = new System.Drawing.Size(120, 22);
            this.textBox_ServerPort.TabIndex = 7;
            // 
            // textBox_UserName
            // 
            this.textBox_UserName.Location = new System.Drawing.Point(578, 141);
            this.textBox_UserName.Name = "textBox_UserName";
            this.textBox_UserName.Size = new System.Drawing.Size(120, 22);
            this.textBox_UserName.TabIndex = 8;
            // 
            // button_Login
            // 
            this.button_Login.Location = new System.Drawing.Point(578, 169);
            this.button_Login.Name = "button_Login";
            this.button_Login.Size = new System.Drawing.Size(120, 23);
            this.button_Login.TabIndex = 9;
            this.button_Login.Text = "登入伺服器";
            this.button_Login.UseVisualStyleBackColor = true;
            this.button_Login.Click += new System.EventHandler(this.button_Login_Click);
            // 
            // listBox_OnlineUser
            // 
            this.listBox_OnlineUser.FormattingEnabled = true;
            this.listBox_OnlineUser.ItemHeight = 12;
            this.listBox_OnlineUser.Location = new System.Drawing.Point(578, 216);
            this.listBox_OnlineUser.Name = "listBox_OnlineUser";
            this.listBox_OnlineUser.Size = new System.Drawing.Size(120, 268);
            this.listBox_OnlineUser.TabIndex = 10;
            // 
            // textBox_SysMsg
            // 
            this.textBox_SysMsg.Location = new System.Drawing.Point(578, 513);
            this.textBox_SysMsg.Name = "textBox_SysMsg";
            this.textBox_SysMsg.Size = new System.Drawing.Size(120, 22);
            this.textBox_SysMsg.TabIndex = 11;
            // 
            // button_Reset
            // 
            this.button_Reset.Location = new System.Drawing.Point(578, 543);
            this.button_Reset.Name = "button_Reset";
            this.button_Reset.Size = new System.Drawing.Size(120, 23);
            this.button_Reset.TabIndex = 12;
            this.button_Reset.Text = "清除重玩";
            this.button_Reset.UseVisualStyleBackColor = true;
            this.button_Reset.Click += new System.EventHandler(this.button_Reset_Click);
            // 
            // TCPGobang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 571);
            this.Controls.Add(this.button_Reset);
            this.Controls.Add(this.textBox_SysMsg);
            this.Controls.Add(this.listBox_OnlineUser);
            this.Controls.Add(this.button_Login);
            this.Controls.Add(this.textBox_UserName);
            this.Controls.Add(this.textBox_ServerPort);
            this.Controls.Add(this.textBox_ServerIP);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel_Board);
            this.Name = "TCPGobang";
            this.Text = "線上五子棋";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TCPGobang_FormClosing);
            this.Load += new System.EventHandler(this.TCPGobang_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_Board;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_ServerIP;
        private System.Windows.Forms.TextBox textBox_ServerPort;
        private System.Windows.Forms.TextBox textBox_UserName;
        private System.Windows.Forms.Button button_Login;
        private System.Windows.Forms.ListBox listBox_OnlineUser;
        private System.Windows.Forms.TextBox textBox_SysMsg;
        private System.Windows.Forms.Button button_Reset;
    }
}


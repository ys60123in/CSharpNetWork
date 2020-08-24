namespace TCPShooter
{
    partial class TCPShooter
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
            this.components = new System.ComponentModel.Container();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox_SysMsg = new System.Windows.Forms.TextBox();
            this.listBox_OnlineUser = new System.Windows.Forms.ListBox();
            this.button_Login = new System.Windows.Forms.Button();
            this.textBox_UserName = new System.Windows.Forms.TextBox();
            this.textBox_ServerPort = new System.Windows.Forms.TextBox();
            this.textBox_ServerIP = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_Board = new System.Windows.Forms.Panel();
            this.label_Score = new System.Windows.Forms.Label();
            this.timer_Self = new System.Windows.Forms.Timer(this.components);
            this.timer_Enemy = new System.Windows.Forms.Timer(this.components);
            this.Q = new System.Windows.Forms.PictureBox();
            this.P = new System.Windows.Forms.PictureBox();
            this.panel_Board.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Q)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.P)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(680, 548);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(18, 19);
            this.button2.TabIndex = 25;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBox_SysMsg
            // 
            this.textBox_SysMsg.Location = new System.Drawing.Point(578, 396);
            this.textBox_SysMsg.Name = "textBox_SysMsg";
            this.textBox_SysMsg.Size = new System.Drawing.Size(120, 22);
            this.textBox_SysMsg.TabIndex = 24;
            // 
            // listBox_OnlineUser
            // 
            this.listBox_OnlineUser.FormattingEnabled = true;
            this.listBox_OnlineUser.ItemHeight = 12;
            this.listBox_OnlineUser.Location = new System.Drawing.Point(578, 217);
            this.listBox_OnlineUser.Name = "listBox_OnlineUser";
            this.listBox_OnlineUser.Size = new System.Drawing.Size(120, 148);
            this.listBox_OnlineUser.TabIndex = 23;
            this.listBox_OnlineUser.SelectedIndexChanged += new System.EventHandler(this.listBox_OnlineUser_SelectedIndexChanged);
            // 
            // button_Login
            // 
            this.button_Login.Location = new System.Drawing.Point(578, 170);
            this.button_Login.Name = "button_Login";
            this.button_Login.Size = new System.Drawing.Size(120, 23);
            this.button_Login.TabIndex = 22;
            this.button_Login.Text = "登入伺服器";
            this.button_Login.UseVisualStyleBackColor = true;
            this.button_Login.Click += new System.EventHandler(this.button_Login_Click);
            // 
            // textBox_UserName
            // 
            this.textBox_UserName.Location = new System.Drawing.Point(578, 142);
            this.textBox_UserName.Name = "textBox_UserName";
            this.textBox_UserName.Size = new System.Drawing.Size(120, 22);
            this.textBox_UserName.TabIndex = 21;
            // 
            // textBox_ServerPort
            // 
            this.textBox_ServerPort.Location = new System.Drawing.Point(578, 74);
            this.textBox_ServerPort.Name = "textBox_ServerPort";
            this.textBox_ServerPort.Size = new System.Drawing.Size(120, 22);
            this.textBox_ServerPort.TabIndex = 20;
            // 
            // textBox_ServerIP
            // 
            this.textBox_ServerIP.Location = new System.Drawing.Point(578, 25);
            this.textBox_ServerIP.Name = "textBox_ServerIP";
            this.textBox_ServerIP.Size = new System.Drawing.Size(120, 22);
            this.textBox_ServerIP.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(576, 381);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "系統訊息";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(576, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "線上使用者";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(576, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "玩家名稱：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(576, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "伺服器Port：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(576, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "伺服器IP：";
            // 
            // panel_Board
            // 
            this.panel_Board.BackColor = System.Drawing.Color.White;
            this.panel_Board.Controls.Add(this.P);
            this.panel_Board.Controls.Add(this.Q);
            this.panel_Board.Location = new System.Drawing.Point(0, 0);
            this.panel_Board.Name = "panel_Board";
            this.panel_Board.Size = new System.Drawing.Size(570, 570);
            this.panel_Board.TabIndex = 13;
            // 
            // label_Score
            // 
            this.label_Score.AutoSize = true;
            this.label_Score.Location = new System.Drawing.Point(576, 450);
            this.label_Score.Name = "label_Score";
            this.label_Score.Size = new System.Drawing.Size(11, 12);
            this.label_Score.TabIndex = 26;
            this.label_Score.Text = "0";
            // 
            // timer_Self
            // 
            this.timer_Self.Enabled = true;
            this.timer_Self.Interval = 25;
            this.timer_Self.Tick += new System.EventHandler(this.timer_Self_Tick);
            // 
            // timer_Enemy
            // 
            this.timer_Enemy.Enabled = true;
            this.timer_Enemy.Interval = 25;
            this.timer_Enemy.Tick += new System.EventHandler(this.timer_Enemy_Tick);
            // 
            // Q
            // 
            this.Q.Image = global::TCPShooter.Properties.Resources.ShooterX;
            this.Q.Location = new System.Drawing.Point(250, 3);
            this.Q.Name = "Q";
            this.Q.Size = new System.Drawing.Size(44, 52);
            this.Q.TabIndex = 0;
            this.Q.TabStop = false;
            this.Q.Tag = "G";
            // 
            // P
            // 
            this.P.Image = global::TCPShooter.Properties.Resources.Shooter;
            this.P.Location = new System.Drawing.Point(250, 515);
            this.P.Name = "P";
            this.P.Size = new System.Drawing.Size(44, 52);
            this.P.TabIndex = 1;
            this.P.TabStop = false;
            this.P.Tag = "G";
            // 
            // TCPShooter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 571);
            this.Controls.Add(this.label_Score);
            this.Controls.Add(this.button2);
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
            this.KeyPreview = true;
            this.Name = "TCPShooter";
            this.Text = "線上射擊遊戲";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TCPShooter_FormClosing);
            this.Load += new System.EventHandler(this.TCPShooter_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TCPShooter_KeyDown);
            this.panel_Board.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Q)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.P)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox_SysMsg;
        private System.Windows.Forms.ListBox listBox_OnlineUser;
        private System.Windows.Forms.Button button_Login;
        private System.Windows.Forms.TextBox textBox_UserName;
        private System.Windows.Forms.TextBox textBox_ServerPort;
        private System.Windows.Forms.TextBox textBox_ServerIP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_Board;
        private System.Windows.Forms.Label label_Score;
        private System.Windows.Forms.Timer timer_Self;
        private System.Windows.Forms.Timer timer_Enemy;
        private System.Windows.Forms.PictureBox P;
        private System.Windows.Forms.PictureBox Q;
    }
}


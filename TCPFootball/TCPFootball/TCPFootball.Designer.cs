namespace TCPFootball
{
    partial class TCPFootball
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
            this.textBox_SysMsg = new System.Windows.Forms.TextBox();
            this.listBox_Enemy = new System.Windows.Forms.ListBox();
            this.button_Login = new System.Windows.Forms.Button();
            this.textBox_UserName = new System.Windows.Forms.TextBox();
            this.textBox_ServerPort = new System.Windows.Forms.TextBox();
            this.textBox_ServerIP = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox_Team = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button_Start = new System.Windows.Forms.Button();
            this.label_Power = new System.Windows.Forms.Label();
            this.LSB = new System.Windows.Forms.Label();
            this.LSA = new System.Windows.Forms.Label();
            this.pictureBox_Field = new System.Windows.Forms.PictureBox();
            this.timer_FMove = new System.Windows.Forms.Timer(this.components);
            this.label_divider = new System.Windows.Forms.Label();
            this.LB = new System.Windows.Forms.Label();
            this.LA = new System.Windows.Forms.Label();
            this.ball = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Field)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_SysMsg
            // 
            this.textBox_SysMsg.Location = new System.Drawing.Point(416, 171);
            this.textBox_SysMsg.Name = "textBox_SysMsg";
            this.textBox_SysMsg.Size = new System.Drawing.Size(120, 22);
            this.textBox_SysMsg.TabIndex = 22;
            // 
            // listBox_Enemy
            // 
            this.listBox_Enemy.FormattingEnabled = true;
            this.listBox_Enemy.ItemHeight = 12;
            this.listBox_Enemy.Location = new System.Drawing.Point(416, 211);
            this.listBox_Enemy.Name = "listBox_Enemy";
            this.listBox_Enemy.Size = new System.Drawing.Size(120, 76);
            this.listBox_Enemy.TabIndex = 21;
            // 
            // button_Login
            // 
            this.button_Login.Location = new System.Drawing.Point(416, 130);
            this.button_Login.Name = "button_Login";
            this.button_Login.Size = new System.Drawing.Size(120, 23);
            this.button_Login.TabIndex = 20;
            this.button_Login.Text = "登入伺服器";
            this.button_Login.UseVisualStyleBackColor = true;
            this.button_Login.Click += new System.EventHandler(this.button_Login_Click);
            // 
            // textBox_UserName
            // 
            this.textBox_UserName.Location = new System.Drawing.Point(416, 102);
            this.textBox_UserName.Name = "textBox_UserName";
            this.textBox_UserName.Size = new System.Drawing.Size(120, 22);
            this.textBox_UserName.TabIndex = 19;
            // 
            // textBox_ServerPort
            // 
            this.textBox_ServerPort.Location = new System.Drawing.Point(416, 62);
            this.textBox_ServerPort.Name = "textBox_ServerPort";
            this.textBox_ServerPort.Size = new System.Drawing.Size(120, 22);
            this.textBox_ServerPort.TabIndex = 18;
            // 
            // textBox_ServerIP
            // 
            this.textBox_ServerIP.Location = new System.Drawing.Point(416, 22);
            this.textBox_ServerIP.Name = "textBox_ServerIP";
            this.textBox_ServerIP.Size = new System.Drawing.Size(120, 22);
            this.textBox_ServerIP.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(414, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "系統訊息";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(414, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "敵隊隊友";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(414, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "玩家名稱：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(414, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "伺服器Port：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(414, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "伺服器IP：";
            // 
            // listBox_Team
            // 
            this.listBox_Team.FormattingEnabled = true;
            this.listBox_Team.ItemHeight = 12;
            this.listBox_Team.Location = new System.Drawing.Point(416, 429);
            this.listBox_Team.Name = "listBox_Team";
            this.listBox_Team.Size = new System.Drawing.Size(120, 76);
            this.listBox_Team.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(414, 414);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 23;
            this.label6.Text = "本隊隊友";
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(416, 511);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(120, 23);
            this.button_Start.TabIndex = 25;
            this.button_Start.Text = "開始遊戲";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // label_Power
            // 
            this.label_Power.AutoSize = true;
            this.label_Power.Location = new System.Drawing.Point(414, 547);
            this.label_Power.Name = "label_Power";
            this.label_Power.Size = new System.Drawing.Size(11, 12);
            this.label_Power.TabIndex = 26;
            this.label_Power.Text = "0";
            // 
            // LSB
            // 
            this.LSB.AutoSize = true;
            this.LSB.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LSB.Location = new System.Drawing.Point(414, 310);
            this.LSB.Name = "LSB";
            this.LSB.Size = new System.Drawing.Size(102, 16);
            this.LSB.TabIndex = 27;
            this.LSB.Text = "敵隊得分：0";
            // 
            // LSA
            // 
            this.LSA.AutoSize = true;
            this.LSA.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LSA.Location = new System.Drawing.Point(414, 335);
            this.LSA.Name = "LSA";
            this.LSA.Size = new System.Drawing.Size(102, 16);
            this.LSA.TabIndex = 28;
            this.LSA.Text = "本隊得分：0";
            // 
            // pictureBox_Field
            // 
            this.pictureBox_Field.BackColor = System.Drawing.Color.White;
            this.pictureBox_Field.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_Field.Name = "pictureBox_Field";
            this.pictureBox_Field.Size = new System.Drawing.Size(400, 600);
            this.pictureBox_Field.TabIndex = 29;
            this.pictureBox_Field.TabStop = false;
            // 
            // timer_FMove
            // 
            this.timer_FMove.Enabled = true;
            this.timer_FMove.Interval = 200;
            this.timer_FMove.Tick += new System.EventHandler(this.timer_FMove_Tick);
            // 
            // label_divider
            // 
            this.label_divider.BackColor = System.Drawing.Color.Black;
            this.label_divider.Location = new System.Drawing.Point(0, 299);
            this.label_divider.Name = "label_divider";
            this.label_divider.Size = new System.Drawing.Size(400, 2);
            this.label_divider.TabIndex = 30;
            // 
            // LB
            // 
            this.LB.Image = global::TCPFootball.Properties.Resources.gate2;
            this.LB.Location = new System.Drawing.Point(150, 0);
            this.LB.Name = "LB";
            this.LB.Size = new System.Drawing.Size(100, 10);
            this.LB.TabIndex = 31;
            // 
            // LA
            // 
            this.LA.Image = global::TCPFootball.Properties.Resources.gate1;
            this.LA.Location = new System.Drawing.Point(150, 590);
            this.LA.Name = "LA";
            this.LA.Size = new System.Drawing.Size(100, 10);
            this.LA.TabIndex = 32;
            // 
            // ball
            // 
            this.ball.BackColor = System.Drawing.Color.Transparent;
            this.ball.Image = global::TCPFootball.Properties.Resources.ball;
            this.ball.Location = new System.Drawing.Point(188, 396);
            this.ball.Name = "ball";
            this.ball.Size = new System.Drawing.Size(30, 30);
            this.ball.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ball.TabIndex = 33;
            this.ball.TabStop = false;
            this.ball.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(526, 577);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(21, 23);
            this.button1.TabIndex = 34;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // TCPFootball
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 600);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ball);
            this.Controls.Add(this.LA);
            this.Controls.Add(this.LB);
            this.Controls.Add(this.label_divider);
            this.Controls.Add(this.pictureBox_Field);
            this.Controls.Add(this.LSA);
            this.Controls.Add(this.LSB);
            this.Controls.Add(this.label_Power);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.listBox_Team);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_SysMsg);
            this.Controls.Add(this.listBox_Enemy);
            this.Controls.Add(this.button_Login);
            this.Controls.Add(this.textBox_UserName);
            this.Controls.Add(this.textBox_ServerPort);
            this.Controls.Add(this.textBox_ServerIP);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "TCPFootball";
            this.Text = "線上足球遊戲";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TCPFootball_FormClosing);
            this.Load += new System.EventHandler(this.TCPFootball_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TCPFootball_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Field)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_SysMsg;
        private System.Windows.Forms.ListBox listBox_Enemy;
        private System.Windows.Forms.Button button_Login;
        private System.Windows.Forms.TextBox textBox_UserName;
        private System.Windows.Forms.TextBox textBox_ServerPort;
        private System.Windows.Forms.TextBox textBox_ServerIP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox_Team;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.Label label_Power;
        private System.Windows.Forms.Label LSB;
        private System.Windows.Forms.Label LSA;
        private System.Windows.Forms.PictureBox pictureBox_Field;
        private System.Windows.Forms.Timer timer_FMove;
        private System.Windows.Forms.Label label_divider;
        private System.Windows.Forms.Label LB;
        private System.Windows.Forms.Label LA;
        private System.Windows.Forms.PictureBox ball;
        private System.Windows.Forms.Button button1;
    }
}


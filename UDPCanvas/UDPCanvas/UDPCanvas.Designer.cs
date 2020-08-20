namespace UDPCanvas
{
    partial class UDPCanvas
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
            this.textBox_TargetPort = new System.Windows.Forms.TextBox();
            this.textBox_TargetIP = new System.Windows.Forms.TextBox();
            this.textBox_ListenPort = new System.Windows.Forms.TextBox();
            this.label_TargetPort = new System.Windows.Forms.Label();
            this.label_TargetIP = new System.Windows.Forms.Label();
            this.label_ListenPort = new System.Windows.Forms.Label();
            this.button_Connect = new System.Windows.Forms.Button();
            this.radioButton_Red = new System.Windows.Forms.RadioButton();
            this.radioButton_Green = new System.Windows.Forms.RadioButton();
            this.radioButton_Blue = new System.Windows.Forms.RadioButton();
            this.radioButton_Black = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // textBox_TargetPort
            // 
            this.textBox_TargetPort.Location = new System.Drawing.Point(224, 12);
            this.textBox_TargetPort.Name = "textBox_TargetPort";
            this.textBox_TargetPort.Size = new System.Drawing.Size(100, 22);
            this.textBox_TargetPort.TabIndex = 14;
            // 
            // textBox_TargetIP
            // 
            this.textBox_TargetIP.Location = new System.Drawing.Point(57, 12);
            this.textBox_TargetIP.Name = "textBox_TargetIP";
            this.textBox_TargetIP.Size = new System.Drawing.Size(100, 22);
            this.textBox_TargetIP.TabIndex = 13;
            // 
            // textBox_ListenPort
            // 
            this.textBox_ListenPort.Location = new System.Drawing.Point(388, 12);
            this.textBox_ListenPort.Name = "textBox_ListenPort";
            this.textBox_ListenPort.Size = new System.Drawing.Size(100, 22);
            this.textBox_ListenPort.TabIndex = 12;
            // 
            // label_TargetPort
            // 
            this.label_TargetPort.AutoSize = true;
            this.label_TargetPort.Location = new System.Drawing.Point(170, 15);
            this.label_TargetPort.Name = "label_TargetPort";
            this.label_TargetPort.Size = new System.Drawing.Size(48, 12);
            this.label_TargetPort.TabIndex = 11;
            this.label_TargetPort.Text = "目標Port";
            // 
            // label_TargetIP
            // 
            this.label_TargetIP.AutoSize = true;
            this.label_TargetIP.Location = new System.Drawing.Point(12, 15);
            this.label_TargetIP.Name = "label_TargetIP";
            this.label_TargetIP.Size = new System.Drawing.Size(39, 12);
            this.label_TargetIP.TabIndex = 10;
            this.label_TargetIP.Text = "目標IP";
            // 
            // label_ListenPort
            // 
            this.label_ListenPort.AutoSize = true;
            this.label_ListenPort.Location = new System.Drawing.Point(334, 15);
            this.label_ListenPort.Name = "label_ListenPort";
            this.label_ListenPort.Size = new System.Drawing.Size(48, 12);
            this.label_ListenPort.TabIndex = 9;
            this.label_ListenPort.Text = "接聽Port";
            // 
            // button_Connect
            // 
            this.button_Connect.Location = new System.Drawing.Point(505, 12);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(75, 23);
            this.button_Connect.TabIndex = 15;
            this.button_Connect.Text = "連線";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // radioButton_Red
            // 
            this.radioButton_Red.AutoSize = true;
            this.radioButton_Red.Location = new System.Drawing.Point(14, 51);
            this.radioButton_Red.Name = "radioButton_Red";
            this.radioButton_Red.Size = new System.Drawing.Size(42, 16);
            this.radioButton_Red.TabIndex = 16;
            this.radioButton_Red.TabStop = true;
            this.radioButton_Red.Text = "Red";
            this.radioButton_Red.UseVisualStyleBackColor = true;
            // 
            // radioButton_Green
            // 
            this.radioButton_Green.AutoSize = true;
            this.radioButton_Green.Location = new System.Drawing.Point(62, 51);
            this.radioButton_Green.Name = "radioButton_Green";
            this.radioButton_Green.Size = new System.Drawing.Size(51, 16);
            this.radioButton_Green.TabIndex = 17;
            this.radioButton_Green.TabStop = true;
            this.radioButton_Green.Text = "Green";
            this.radioButton_Green.UseVisualStyleBackColor = true;
            // 
            // radioButton_Blue
            // 
            this.radioButton_Blue.AutoSize = true;
            this.radioButton_Blue.Location = new System.Drawing.Point(119, 51);
            this.radioButton_Blue.Name = "radioButton_Blue";
            this.radioButton_Blue.Size = new System.Drawing.Size(45, 16);
            this.radioButton_Blue.TabIndex = 18;
            this.radioButton_Blue.TabStop = true;
            this.radioButton_Blue.Text = "Blue";
            this.radioButton_Blue.UseVisualStyleBackColor = true;
            // 
            // radioButton_Black
            // 
            this.radioButton_Black.AutoSize = true;
            this.radioButton_Black.Location = new System.Drawing.Point(172, 51);
            this.radioButton_Black.Name = "radioButton_Black";
            this.radioButton_Black.Size = new System.Drawing.Size(50, 16);
            this.radioButton_Black.TabIndex = 19;
            this.radioButton_Black.TabStop = true;
            this.radioButton_Black.Text = "Black";
            this.radioButton_Black.UseVisualStyleBackColor = true;
            // 
            // UDPCanvas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.radioButton_Black);
            this.Controls.Add(this.radioButton_Blue);
            this.Controls.Add(this.radioButton_Green);
            this.Controls.Add(this.radioButton_Red);
            this.Controls.Add(this.button_Connect);
            this.Controls.Add(this.textBox_TargetPort);
            this.Controls.Add(this.textBox_TargetIP);
            this.Controls.Add(this.textBox_ListenPort);
            this.Controls.Add(this.label_TargetPort);
            this.Controls.Add(this.label_TargetIP);
            this.Controls.Add(this.label_ListenPort);
            this.Name = "UDPCanvas";
            this.Text = "UDP塗鴉牆";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UDPCanvas_FormClosing);
            this.Load += new System.EventHandler(this.UDPCanvas_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UDPCanvas_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UDPCanvas_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.UDPCanvas_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_TargetPort;
        private System.Windows.Forms.TextBox textBox_TargetIP;
        private System.Windows.Forms.TextBox textBox_ListenPort;
        private System.Windows.Forms.Label label_TargetPort;
        private System.Windows.Forms.Label label_TargetIP;
        private System.Windows.Forms.Label label_ListenPort;
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.RadioButton radioButton_Red;
        private System.Windows.Forms.RadioButton radioButton_Green;
        private System.Windows.Forms.RadioButton radioButton_Blue;
        private System.Windows.Forms.RadioButton radioButton_Black;
    }
}


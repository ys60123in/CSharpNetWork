using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace TCPClient
{
    public partial class TCPClient : Form
    {
        Socket T; //通訊物件
        string User; //使用者

        public TCPClient()
        {
            InitializeComponent();
        }

        //關閉視窗代表離線登出
        private void TCPClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(button_Login.Enabled == false)
            {
                Send("9" + User); //傳送自己離線的訊息給伺服器
                T.Close(); //關閉網路通訊器T
            }
        }

        //登入伺服器
        private void button_Login_Click(object sender, EventArgs e)
        {
            string IP = textBox_ServerIP.Text; //伺服器IP
            int Port = int.Parse(textBox_ServerPort.Text); //伺服器Port
            IPEndPoint EP = new IPEndPoint(IPAddress.Parse(IP), Port); //伺服器的連線端點資訊

            //建立可以雙向通訊的TCP連線
            T = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            User = textBox_UserName.Text; //使用者名稱

            try
            {
                T.Connect(EP); //連上伺服器的端點EP(類似撥號給電話總機)
                Send("0" + User);
            }
            catch (Exception)
            {
                MessageBox.Show("無法連上伺服器! "); //連線失敗時顯示訊息
                return;
            }
            button_Login.Enabled = false; //讓連線按鍵失敗，避免重複連線
        }

        //傳送訊息給Server
        private void Send(String Str)
        {
            byte[] B = Encoding.Default.GetBytes(Str);
            T.Send(B, 0, B.Length, SocketFlags.None); //使用連線物件傳送資料
        }
    }
}

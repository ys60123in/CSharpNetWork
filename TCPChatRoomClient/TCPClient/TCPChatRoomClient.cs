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
using System.Threading;

namespace TCPChatRoomClient
{
    public partial class TCPChatRoomClient : Form
    {
        Socket T; //通訊物件
        Thread Th; //網路監聽執行緒
        string User; //使用者

        public TCPChatRoomClient()
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
            CheckForIllegalCrossThreadCalls = false; //忽略跨執行緒錯誤
            string IP = textBox_ServerIP.Text; //伺服器IP
            int Port = int.Parse(textBox_ServerPort.Text); //伺服器Port
            IPEndPoint EP = new IPEndPoint(IPAddress.Parse(IP), Port); //伺服器的連線端點資訊

            //建立可以雙向通訊的TCP連線
            T = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            User = textBox_UserName.Text; //使用者名稱

            try
            {
                T.Connect(EP); //連上伺服器的端點EP(類似撥號給電話總機)
                Th = new Thread(Listen); //建立監聽執行緒
                Th.IsBackground = true; //設為背景執行緒
                Th.Start(); //開始監聽
                textBox_Messages.Text = "已連線伺服器! " + "\r\n";
                Send("0" + User);
            }
            catch (Exception)
            {
                textBox_Messages.Text = "無法連上伺服器! " + "\r\n"; //連線失敗時顯示訊息
                return;
            }
            button_Login.Enabled = false; //讓連線按鍵失敗，避免重複連線
            button_Enter.Enabled = true; //如果連線成功則可以開始發送訊息
        }

        //廣播
        private void button_Broadcast_Click(object sender, EventArgs e)
        {
            listBox_User.ClearSelected(); //清除選取
        }

        //送出
        private void button_Enter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Msg.Text)) return; //未輸入訊息不得傳送資料
            if(listBox_User.SelectedIndex < 0) //未選取傳送對象(廣播)，命令碼:1
            {
                Send("1" + User + " 公告:" + textBox_Msg.Text);
            }
            else
            {
                Send("2" + "來自" + User + ":" + textBox_Msg.Text + "|" + listBox_User.SelectedItem);
                textBox_Messages.Text += "告訴" + listBox_User.SelectedItem + ":" + textBox_Msg.Text + "\r\n";
            }
            textBox_Msg.Text = ""; //清除發言框
        }

        //傳送訊息給Server
        private void Send(String Str)
        {
            byte[] B = Encoding.Default.GetBytes(Str);
            T.Send(B, 0, B.Length, SocketFlags.None); //使用連線物件傳送資料
        }

        //監聽Server信息
        private void Listen()
        {
            EndPoint ServerEP = (EndPoint)T.RemoteEndPoint; //Server的EndPoint
            byte[] B = new byte[1023]; //接收用的byte陣列
            int inLen = 0; //接收的位元組數目
            string Msg; //接收到的完整訊息
            string St; //命令碼
            string Str; //訊息內容(不含命令碼)
            while(true)
            {
                try
                {
                    inLen = T.ReceiveFrom(B, ref ServerEP); //收聽資訊並取得位元組數
                }
                catch (Exception)
                {
                    T.Close(); //關閉通訊器
                    listBox_User.Items.Clear(); //清除線上名單
                    MessageBox.Show("伺服器斷線了!");
                    button_Login.Enabled = true; //連線按鍵恢復可用
                    button_Enter.Enabled = false; //要連線後才可發送
                    Th.Abort(); //刪除執行緒
                }

                Msg = Encoding.Default.GetString(B, 0, inLen); //解讀完整訊息
                St = Msg.Substring(0, 1); //取命令碼(第1個字)
                Str = Msg.Substring(1); //取命令碼後的訊息

                switch(St)
                {
                    case "L":
                        listBox_User.Items.Clear(); //清除線上名單
                        string[] M = Str.Split(','); //拆解名單成陣列
                        for(int i = 0; i < M.Length; i++)
                        {
                            listBox_User.Items.Add(M[i]); //逐一加入名單
                        }
                        break;

                    case "1": //接收廣播訊息
                        textBox_Messages.Text += "(公開)" + Str + "\r\n"; //顯示訊息並換行
                        textBox_Messages.SelectionStart = textBox_Messages.Text.Length; //游標移到最後
                        textBox_Messages.ScrollToCaret(); //捲動到游標位置
                        break;

                    case "2":
                        textBox_Messages.Text += "(私密)" + Str + "\r\n"; //顯示私密訊息並換行
                        textBox_Messages.SelectionStart = textBox_Messages.Text.Length; //游標移到最後
                        textBox_Messages.ScrollToCaret(); //捲動到游標位置
                        break;
                }
            }
        }
    }
}

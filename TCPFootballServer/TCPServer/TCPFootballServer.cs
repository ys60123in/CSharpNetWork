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
using System.Collections;

namespace TCPFootballServer
{
    public partial class TCPFootballServer : Form
    {
        TcpListener Server; //伺服端網路監聽器(相當於電話總機)
        Socket Client; //給客戶用的連線物件(相當於電話分機)
        Thread Th_Svr; //伺服器監聽用執行緒(電話總機開放中)
        Thread Th_Clt; //客戶用的通話執行緒(電話分機連線中)
        Hashtable HT = new Hashtable(); //客戶名稱與通訊物件的集合(雜湊表) (Key:Name, Socket)

        public TCPFootballServer()
        {
            InitializeComponent();
        }

        private void TCPChatRoomServer_Load(object sender, EventArgs e)
        {
            textBox_ServerIP.Text = MyIP(); //呼叫函數找本機IP
        }

        //關閉視窗時
        private void TCPServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread(); //關閉所有執行緒
        }

        //開啟Server:用Server Thread來監聽Client
        private void button_Start_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; //忽略跨執行緒處理的錯誤(允許跨執行緒存取變數)
            Th_Svr = new Thread(ServerSub); //宣告監聽執行緒(副程式ServerSub)
            Th_Svr.IsBackground = true; //設定為背景執行任務
            Th_Svr.Start(); //啟動執行緒
            button_Start.Enabled = false; //讓案件無法使用(不能重複啟動伺服器)
        }

        //接受客戶連線要求的程式(如同電話總機)，針對每一個客戶會建立一個連線，以及獨立執行緒
        private void ServerSub()
        {
            //Server IP 和 Port
            IPEndPoint EP = new IPEndPoint(IPAddress.Parse(textBox_ServerIP.Text), int.Parse(textBox_ServerPort.Text));
            Server = new TcpListener(EP); //建立伺服器監聽器(總機)
            Server.Start(100); //啟動監聽允許最多連線人數100人
            while (true)
            {
                Client = Server.AcceptSocket(); //建立此刻護的連線物件Client
                Th_Clt = new Thread(Listen); //建立監聽這個客戶的獨立執行緒
                Th_Clt.IsBackground = true; //設定為背景執行緒
                Th_Clt.Start(); //開啟執行緒的運作
            }
        }

        //監聽客戶訊息的程式
        private void Listen()
        {
            Socket Sck = Client; //複製Client通訊物件至個別客戶專用物件Sck
            Thread Th = Th_Clt; //複製執行緒Th_Clt到區域變數Th
            while (true) //持續監聽客戶來的訊息
            {
                try //用Sck來接收此客戶訊息，inLen是接受訊息的byte數目
                {
                    byte[] B = new byte[1023]; //建立接收資料用的陣列，長度需大於可能的信息
                    int inLen = Sck.Receive(B); //接收網路資訊 (byte陣列)
                    string Msg = Encoding.Default.GetString(B, 0, inLen); //翻譯實際訊息(長度inLen)
                    string Cmd = Msg.Substring(0, 1); //取出命令碼(第一個字)
                    string Str = Msg.Substring(1); //取出命令碼後的訊息
                    switch (Cmd)
                    {
                        case "0": //有新使用者上線，新增使用者到名單
                            HT.Add(Str, Sck); //連線加入雜湊表(Key:使用者,Value:連線物件(Socket))
                            listBox_User.Items.Add(Str); //加入上線者名單
                            SendAll(OnlineList()); //將目前上線人名單回傳剛剛登入的人(包含他自己)
                            break;

                        case "1": //使用者傳送訊息給所有人
                            SendAll(Msg); //廣播訊息
                            break;

                        case "9":
                            HT.Remove(Str); //移除使用者名稱為Name的連線物件
                            listBox_User.Items.Remove(Str); //自上線者名單移除Name
                            SendAll("E" + Str); //傳送某用戶離線訊息給所有人
                            Th.Abort(); //結束此客戶的監聽執行緒
                            break;

                        default: //使用者傳送私密訊息
                            string[] C = Str.Split('|'); //切開訊息與收件者
                            SendTo(Cmd + C[0], C[1]); //C[0]是訊息，C[1]是收件者
                            break;
                    }
                }
                catch (Exception)
                {
                    //有錯誤時忽略，通常是客戶端無預警強制關閉程式，測試階段常發生
                }
            }
        }

        //找出本機IP
        private string MyIP()
        {
            string hn = Dns.GetHostName();
            IPAddress[] ip = Dns.GetHostEntry(hn).AddressList; //取得本機IP陣列
            foreach (IPAddress it in ip)
            {
                if (it.AddressFamily == AddressFamily.InterNetwork)
                {
                    return it.ToString(); //如果是IPv4則回傳此IP字串
                }
            }

            return ""; //找不到合格IP回傳空字串
        }

        //建立線上名單
        private string OnlineList()
        {
            string L = "L"; //代表線上名單的命令碼(字頭)
            for (int i = 0; i < listBox_User.Items.Count; i++)
            {
                L += listBox_User.Items[i]; //逐一將成員名單加入L字串
                //不是最後一個成員要加上","區隔
                if (i < listBox_User.Items.Count - 1)
                {
                    L += ",";
                }
            }

            return L;
        }

        //傳送訊息給指定的客戶
        private void SendTo(string Str, string User)
        {
            byte[] B = Encoding.Default.GetBytes(Str);
            Socket Sck = (Socket)HT[User]; //取出發送對象User的通訊物件
            Sck.Send(B, 0, B.Length, SocketFlags.None); //發送訊息
        }

        //傳送訊息給所有的線上客戶
        private void SendAll(string Str)
        {
            byte[] B = Encoding.Default.GetBytes(Str);
            foreach (Socket s in HT.Values) //HT雜湊表內所有的Socket
                s.Send(B, 0, B.Length, SocketFlags.None); //傳送資料
        }
    }
}

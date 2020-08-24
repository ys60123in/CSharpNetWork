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

namespace TCPShooter
{
    public partial class TCPShooter : Form
    {
        Socket T; //通訊物件
        Thread Th; //網路監聽執行緒
        string User; //使用者
        bool Xbang; //拖曳起點

        public TCPShooter()
        {
            InitializeComponent();
        }

        private void TCPShooter_Load(object sender, EventArgs e)
        {
            button2.Select(); //轉移焦點到button2
        }

        //關閉視窗離線
        private void TCPShooter_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (button_Login.Enabled == false)
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
                textBox_SysMsg.Text = "已連線伺服器! " + "\r\n";
                Send("0" + User);
            }
            catch (Exception)
            {
                textBox_SysMsg.Text = "無法連上伺服器! " + "\r\n"; //連線失敗時顯示訊息
                return;
            }
            button_Login.Enabled = false; //讓連線按鍵失敗，避免重複連線
            button2.Select(); //轉移焦點
        }

        //選擇對手後
        private void listBox_OnlineUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Select(); //轉移焦點
        }

        //傳送訊息給Server
        private void Send(string Str)
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
            while (true)
            {
                try
                {
                    inLen = T.ReceiveFrom(B, ref ServerEP); //收聽資訊並取得位元組數
                }
                catch (Exception)
                {
                    T.Close(); //關閉通訊器
                    listBox_OnlineUser.Items.Clear(); //清除線上名單
                    MessageBox.Show("伺服器斷線了!");
                    button_Login.Enabled = true; //連線按鍵恢復可用
                    Th.Abort(); //刪除執行緒
                }

                Msg = Encoding.Default.GetString(B, 0, inLen); //解讀完整訊息
                St = Msg.Substring(0, 1); //取命令碼(第1個字)
                Str = Msg.Substring(1); //取命令碼後的訊息

                switch (St)
                {
                    case "L":
                        listBox_OnlineUser.Items.Clear(); //清除線上名單
                        string[] M = Str.Split(','); //拆解名單成陣列
                        for (int i = 0; i < M.Length; i++)
                        {
                            listBox_OnlineUser.Items.Add(M[i]); //逐一加入名單
                        }
                        break;

                    case "3": //敵人移動槍枝
                        Q.Left = panel_Board.Width - int.Parse(Str) - Q.Width; //左右顛倒
                        break;

                    case "4": //敵人開槍
                        Xbang = true; //樹立敵方開炮旗標
                        break;
                }
            }
        }

        //移動槍枝與開槍的程式
        private void TCPShooter_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Z:
                    if(P.Left > panel_Board.Left - P.Width / 2) //不要讓飛機超出邊界太多
                        P.Left -= 5; //左移
                    break;

                case Keys.X:
                    if (P.Right < panel_Board.Right + P.Width / 2) //不要讓飛機超出邊界太多
                        P.Left += 5; //右移
                    break;

                case Keys.Space:
                    MyShot(); //開槍
                    break;
            }
            if (listBox_OnlineUser.SelectedIndex >= 0) //有選取遊戲對手，上線遊戲中
            {
                switch (e.KeyCode)
                {
                    case Keys.Z:
                        Send("3" + P.Left.ToString() + "|" + listBox_OnlineUser.SelectedItem); //傳送位置訊息
                        break;

                    case Keys.X:
                        Send("3" + P.Left.ToString() + "|" + listBox_OnlineUser.SelectedItem); //傳送位置訊息
                        break;

                    case Keys.Space:
                        Send("4" + "S" + "|" + listBox_OnlineUser.SelectedItem); //傳送開槍訊息
                        break;
                }
                button2.Select(); //轉移焦點
            }
        }

        //我的砲彈
        private void MyShot()
        {
            Label B = new Label(); //新子彈
            B.Tag = "B"; //註記為我的砲彈
            B.Width = 3;
            B.Height = 6;
            B.BackColor = Color.Red;
            B.Left = P.Left + P.Width / 2 - B.Width / 2; //我的飛機中央
            B.Top = P.Top - B.Height; //貼齊機頭
            panel_Board.Controls.Add(B); //加入元件B到panel_Board
        }

        //子彈飛行控制
        private void timer_Self_Tick(object sender, EventArgs e)
        {
            foreach (Control c in panel_Board.Controls)
            {
                string s = c.Tag.ToString();
                switch (s)
                {
                    case "B":
                        c.Top -= 5; //往上移動
                        if (c.Bottom < 0) c.Dispose(); //超出畫面子彈刪除
                        if (chkHit((Label)c, Q)) //如果擊中敵方飛機
                        {
                            c.Dispose(); //子彈刪除
                            label_Score.Text = (int.Parse(label_Score.Text) + 1).ToString(); //得分累加
                        }
                        break;
                    case "X":
                        c.Top += 5; //往下移動
                        if (c.Top > panel_Board.Height) c.Dispose(); //超出畫面子彈刪除
                        break;
                }
            }
        }

        //砲彈偵測碰撞程式
        private bool chkHit(Label B, PictureBox C)
        {
            if (B.Right < C.Left) return false; //子彈在物件之左(未碰撞)
            if (B.Left > C.Right) return false; //子彈在物件之右(未碰撞)
            if (B.Bottom < C.Top) return false; //子彈在物件之上(未碰撞)
            if (B.Top > C.Bottom) return false; //子彈在物件之下(未碰撞)
            return true; //已碰撞
        }

        //敵方砲彈
        private void XShot()
        {
            Label B = new Label(); //新子彈
            B.Tag = "X"; //註記為敵方的砲彈
            B.Width = 3;
            B.Height = 6;
            B.BackColor = Color.Gray;
            B.Left = Q.Left + Q.Width / 2 - B.Width / 2; //敵方的飛機中央
            B.Top = Q.Bottom; //貼齊機頭
            panel_Board.Controls.Add(B); //加入元件B到panel_Board
        }

        //敵方砲火繪製
        private void timer_Enemy_Tick(object sender, EventArgs e)
        {
            if (Xbang) //敵方開炮旗標豎起
            {
                XShot(); //繪製敵方新砲火
                Xbang = false; //降下旗標
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TCPGobang
{
    public partial class TCPGobang : Form
    {
        ShapeContainer CVS; //畫布物件(棋盤)
        byte[,] S; //對應棋盤狀態的陣列:0為空格，1為黑子，2為白子
        Socket T; //通訊物件
        Thread Th; //網路監聽執行緒
        string User; //使用者

        public TCPGobang()
        {
            InitializeComponent();
        }

        //繪製棋盤與加入畫布
        private void TCPGobang_Load(object sender, EventArgs e)
        {
            Bitmap bg = new Bitmap(570, 570); //棋盤影像物件
            Graphics g = Graphics.FromImage(bg); //棋盤影像繪圖物件
            g.Clear(Color.White); //設白色為背景色
            for (int i = 0; i < 19; i++)
            {
                g.DrawLine(Pens.Black, i * 30 + 15, 15, i * 30 + 15, 30 * 18 + 15); //畫19條垂直線
            }
            for (int j = 0; j < 19; j++)
            {
                g.DrawLine(Pens.Black, 15, j * 30 + 15, 30 * 18 + 15, j * 30 + 15); //畫19條水平線
            }
            panel_Board.BackgroundImage = bg; //貼上棋盤影像為panel背景
            CVS = new ShapeContainer(); //宣告畫布物件
            panel_Board.Controls.Add(CVS); //畫布物件加入panel_Board
            S = new byte[19, 19]; //宣告棋盤資訊陣列
        }

        //關閉視窗離線
        private void TCPGobang_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (button_Login.Enabled == false)
            {
                Send("9" + User); //傳送自己離線的訊息給伺服器
                T.Close(); //關閉網路通訊器T
            }
        }

        //登入
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
        }

        //重玩
        private void button_Reset_Click(object sender, EventArgs e)
        {
            if (listBox_OnlineUser.SelectedIndex >= 0) //如果有對手時
            {
                Send("5" + "C" + "|" + listBox_OnlineUser.SelectedItem);
                panel_Board.Enabled = false; //輪到對手，你不能繼續下棋
            }
            CVS.Shapes.Clear(); //清除棋子
            S = new byte[19, 19]; //清除棋盤資訊
            panel_Board.Enabled = true; //開放任一方下棋
        }

        //下棋的動作
        private void panel_Board_MouseDown(object sender, MouseEventArgs e)
        {
            int i = e.X / 30; //算出是第幾個水平向的棋格
            int j = e.Y / 30; //算出是第幾個垂直向的棋格
            if(S[i,j] == 0)
            {
                Chess(i, j, Color.Black); //畫黑子
                S[i, j] = 1; //記為黑子
                if (listBox_OnlineUser.SelectedIndex >= 0) //如果有對手時
                {
                    Send("6" + i.ToString() + "," + j.ToString() + "|" + listBox_OnlineUser.SelectedItem);
                    panel_Board.Enabled = false; //輪到對手，你不能繼續下棋
                }
                if (chk5(i, j, 1))
                {
                    MessageBox.Show("你贏了! ");
                    panel_Board.Enabled = false; //結束後設為必須重設才可下棋
                }
            }
        }

        //畫棋子的副程序
        private void Chess(int i, int j, Color BW)
        {
            OvalShape C = new OvalShape(); //建立一個圓形的Shape物件
            C.Width = 26; //寬
            C.Height = 26; //高
            C.Left = i * 30 + 2; //左邊座標
            C.Top = j * 30 + 2; //頂部座標
            C.FillStyle = FillStyle.Solid; //實心填滿
            C.FillColor = BW; //填黑或白色
            C.Parent = CVS; //將圓形Shape物件加入畫布(棋盤)
        }

        //檢查是否五連線的程式
        private bool chk5(int i, int j, byte tg)
        {
            //水平連線檢查
            int n = 0;
            for (int m = i - 4; m <= i + 4; m++)
            {
                n = nn(m, j, tg, n); //檢視下一格
                if (n == 5) return true;
            }
            //垂直連線檢查
            n = 0;
            for (int m = j - 4; m <= j + 4; m++)
            {
                n = nn(i, m, tg, n); //檢視下一格
                if (n == 5) return true;
            }
            //左上到右下檢查
            n = 0;
            for (int m = -4; m <= 4; m++)
            {
                n = nn(i + m, j + m, tg, n); //檢視下一格
                if (n == 5) return true;
            }
            //右上到左下檢查
            n = 0;
            for (int m = -4; m <= 4; m++)
            {
                n = nn(i - m, j + m, tg, n); //檢視下一格
                if (n == 5) return true;
            }

            return false;
        }
        //搭配檢查用(計算連線)
        private int nn(int i, int j, byte tg, int n)
        {
            if (i < 0 || i > 18 || j < 0 || j > 18) return n;
            if (S[i, j] == tg)
            {
                return n + 1; //累計數值+1
            }
            else
            {
                return 0;
            }
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

                    case "5": //清除棋盤訊息
                        CVS.Shapes.Clear(); //清除棋子
                        S = new byte[19, 19]; //清除棋盤資訊
                        panel_Board.Enabled = true; //開放任一方下棋
                        break;

                    case "6": //對手下棋訊息
                        string[] D = Str.Split(','); //切割座標訊息
                        int x = int.Parse(D[0]); //水平向的棋格
                        int y = int.Parse(D[1]); //垂直向的棋格
                        Chess(x, y, Color.White); //畫白子
                        S[x, y] = 2; //記為白子
                        panel_Board.Enabled = true; //對手下好了，換你下棋
                        if (chk5(x, y, 2))
                        {
                            MessageBox.Show("你輸了! "); //檢查對手是否五連線了
                            panel_Board.Enabled = false; //結束後設為必須重設才可下棋
                        }
                        break;
                }
            }
        }

        
    }
}

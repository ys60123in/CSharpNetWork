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

namespace TCPFootball
{
    public partial class TCPFootball : Form
    {
        Socket T; //通訊物件
        Thread Th; //網路監聽執行緒
        string User; //使用者
        bool run; //控制主表單無限迴圈開關
        bool receive = false; //接收到訊號旗標
        string Mesg = string.Empty; //接收到的公告信號內容
        Hashtable List = new Hashtable(); //所有線上玩家名單(Key=玩家名稱,value=玩家Label物件)
        int teamID; //User的戰隊分類(0:偶數隊,1:奇數隊)
        int tickID; //踢球的隊
        int ballvector = 0; //球的移動方向
        int ballpower = 0; //球的移動力量

        public TCPFootball()
        {
            InitializeComponent();
        }

        private void TCPFootball_Load(object sender, EventArgs e)
        {
            this.Show();
            run = true; //開啟主表單監聽旗標
            while (run)
            {
                if (receive)
                {
                    GetMessage();
                }
                Application.DoEvents();
            }
        }

        private void TCPFootball_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (button_Login.Enabled == false)
            {
                Send("9" + User); //傳送自己離線的訊息給伺服器
                T.Close(); //關閉網路通訊器T
            }
            run = false; //關閉主表單監聽旗標
            Application.DoEvents();
        }

        //主表單監聽到訊息後處理內容
        private void GetMessage()
        {
            string St = Mesg.Substring(0, 1); //命令碼
            string Str = Mesg.Substring(1); //訊息內容(不含命令碼)
            switch (St)
            {
                case "0": //玩家上線並分隊
                    Online(Str);
                    break;

                case "3": //開始遊戲
                    StartGame(Str);
                    break;

                case "4": //玩家移動
                    PlayerMove(Str);
                    break;

                case "5": //玩家踢球
                    TickBall(Str);
                    break;

                case "9": //玩家離線
                    Offline(Str);
                    break;
            }
        }

        //登入伺服器
        private void button_Login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_UserName.Text))
            {
                MessageBox.Show("請輸入玩家名稱!");
                return;
            }
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
            textBox_ServerIP.Enabled = false;
            textBox_ServerPort.Enabled = false;
            textBox_UserName.Enabled = false;
            button1.Select();
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
                    listBox_Team.Items.Clear(); //清除線上名單
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
                        string[] M = Str.Split(','); //拆解名單成陣列
                        string tm = ""; //User所在分隊
                        for (int i = 0; i < M.Length; i++)
                        {
                            if (M[i] == User)
                            {
                                if (i % 2 == 0)
                                    tm = "0"; //User在偶數隊
                                else
                                    tm = "1"; //User在奇數隊
                                break;
                            }
                        }
                        Mesg = "0" + tm + Str; //0代表上線分隊 + User分隊 + 線上名單
                        receive = true;
                        break;

                    case "E": //接收某玩家離線訊息
                        Mesg = "9" + Str; //9代表離線 + 玩家名稱
                        receive = true;
                        break;

                    case "1": //接收廣播訊息
                        Mesg = Str; //訊息複製到公用變數
                        receive = true; //開啟收到訊息旗標
                        break;
                }
            }
        }

        //產生User物件
        private void addme(string player, int i, int tm)
        {
            listBox_Team.Items.Add(player); //加入名單
            Label A = new Label();
            teamID = tm;
            A.Name = "L" + i.ToString(); //物件名稱
            A.Left = 25 + (listBox_Team.Items.Count - 1) * 50;
            A.Top = 570;
            A.AutoSize = false;
            A.Width = 30;
            A.Height = 30;
            A.Image = Properties.Resources.point; //User的物件顯示箭頭
            A.Tag = 0; //箭頭方向(0代表向上)
            pictureBox_Field.Controls.Add(A);
            List.Add(User, A); //加入線上玩家名單
        }

        //產生隊友物件
        private void team(string player, int i)
        {
            listBox_Team.Items.Add(player);
            Label A = new Label();
            A.Name = "L" + i.ToString(); //物件名稱
            A.Left = 25 + (listBox_Team.Items.Count - 1) * 50;
            A.Top = 570;
            A.Text = player; //物件顯示玩家名稱
            A.AutoSize = false;
            A.Width = 30;
            A.Height = 30;
            A.Image = Properties.Resources.team; //設定隊友物件綠色圖示
            pictureBox_Field.Controls.Add(A);
            List.Add(player, A); //加入線上玩家名單
        }

        //產生敵隊物件
        private void rivals(string player, int i)
        {
            listBox_Enemy.Items.Add(player);
            Label A = new Label();
            A.Name = "L" + i.ToString(); //物件名稱
            A.Text = player; //物件顯示玩家名稱
            A.AutoSize = false;
            A.Width = 30;
            A.Height = 30;
            A.Left = pictureBox_Field.Width - 25 - A.Width - (listBox_Enemy.Items.Count - 1) * 50;
            A.Top = 0;
            A.Image = Properties.Resources.rival; //設定對手物件藍色圖示
            pictureBox_Field.Controls.Add(A);
            List.Add(player, A); //加入線上玩家名單
        }

        //上線
        private void Online(string Str)
        {
            int tm = int.Parse(Str.Substring(0, 1)); //User所在分隊(0=偶數隊,1=奇數隊)
            string[] M = Str.Substring(1).Split(','); //線上名單
            if (List.ContainsKey(User) == false) //User未上線，接收全部上線名單
            {
                for (int i = 0; i < M.Length; i++)
                {
                    string player = M[i]; //玩家名稱
                    if (i % 2 == tm) //與User同隊
                    {
                        if (player == User) //User本人
                            addme(player, i, tm); //產生User的Label物件
                        else
                            team(player, i); //產生隊友的Label物件
                    }
                    else //與User敵隊
                    {
                        rivals(player, i); //產生敵隊的Label物件
                    }
                }
            }
            else //User已上線，接收新玩家資訊
            {
                string player = M[M.Length - 1]; //新上線玩家名稱
                if ((M.Length - 1) % 2 == teamID) //與User同隊
                    team(player, M.Length - 1); //產生隊友的Label物件
                else //與User敵隊
                    rivals(player, M.Length - 1); //產生敵隊的Label物件
            }
            receive = false; //關閉收訊旗標
            Mesg = ""; //清空訊息
        }

        //離線
        private void Offline(string Str)
        {
            //從清單上刪除離線玩家名稱
            for (int i = 0; i < listBox_Team.Items.Count; i++)
            {
                if (listBox_Team.Items[i].ToString() == Str)
                {
                    listBox_Team.Items.RemoveAt(i);
                    break;
                }
            }
            for (int i = 0; i < listBox_Enemy.Items.Count; i++)
            {
                if (listBox_Enemy.Items[i].ToString() == Str)
                {
                    listBox_Enemy.Items.RemoveAt(i);
                    break;
                }
            }
            Label A = List[Str] as Label; //從線上名單裡取得玩家的Label物件
            A.Dispose(); //刪除離線玩家的Label物件
            receive = false; //關閉收訊旗標
            Mesg = ""; //清空訊息
        }

        //開始遊戲發球
        private void button_Start_Click(object sender, EventArgs e)
        {
            //兩隊人數一樣才發球
            if (listBox_Team.Items.Count == 0 || listBox_Team.Items.Count != listBox_Enemy.Items.Count) return;
            Random ran = new Random(); //隨機發球
            int n = ran.Next(0, 1); //0發給偶數隊,1給奇數隊
            int x = (pictureBox_Field.Width - ball.Width) / 2; //球的X位置
            int y = (pictureBox_Field.Height - ball.Height) * 3 / 4; //球的Y位置
            Send("13" + n.ToString() + "," + x.ToString() + "," + y.ToString()); //送訊息(1=廣播,3=開始遊戲)
            button1.Select();
        }

        //開始遊戲，準備發球
        private void StartGame(string Str)
        {
            string[] M = Str.Split(','); //M[0]=分隊,M[1]=球的X座標,M[2]=球的Y座標
            if (int.Parse(M[0]) == teamID) //球發給User這隊
            {
                ball.Left = int.Parse(M[1]);
                ball.Top = int.Parse(M[2]);
            }
            else //球發給敵隊
            {
                //敵隊球的位置需上下相反，左右顛倒
                ball.Left = pictureBox_Field.Width - int.Parse(M[1]) - ball.Width;
                ball.Top = pictureBox_Field.Height - int.Parse(M[2]) - ball.Height;
            }
            ball.Visible = true; //顯示球
            //球員歸位
            for (int i = 0; i < listBox_Team.Items.Count; i++)
            {
                Label A = List[listBox_Team.Items[i].ToString()] as Label;
                A.Left = 25 + i * 50;
                A.Top = 570;
            }
            for (int i = 0; i < listBox_Enemy.Items.Count; i++)
            {
                Label A = List[listBox_Enemy.Items[i].ToString()] as Label;
                A.Left = pictureBox_Field.Width - 25 - A.Width - i * 50;
                A.Top = 0;
            }
            button_Start.Enabled = false; //關閉開始遊戲按鍵
            receive = false; //關閉收訊旗標
            Mesg = ""; //清空訊息
        }

        //鍵盤操作事件
        private void TCPFootball_KeyDown(object sender, KeyEventArgs e)
        {
            if (button_Login.Enabled == true) return; //還沒上線忽略鍵盤操作
            Label A = List[User] as Label; //取得User的Label物件
            switch (e.KeyCode)
            {
                case Keys.Left:
                    A.Left -= 5; //向左移動
                    if (A.Left < 0) A.Left = 0; //不可移出左邊界
                    break;

                case Keys.Right:
                    A.Left += 5; //向右移動
                    if (A.Right > pictureBox_Field.Right)
                        A.Left = pictureBox_Field.Right - A.Width; //不可移出右邊界
                    break;

                case Keys.Up:
                    A.Top -= 5; //向上移動
                    if (A.Top < pictureBox_Field.Height / 2)
                        A.Top = pictureBox_Field.Height / 2; //不可移出上邊界
                    break;

                case Keys.Down:
                    A.Top += 5; //向下移動
                    if (A.Bottom > pictureBox_Field.Height)
                        A.Top = pictureBox_Field.Height - A.Height; //不可移出下邊界
                    break;

                case Keys.Z: //改變踢球方向，左轉
                    int nz = int.Parse(A.Tag.ToString()) - 1; //取得物件內箭頭方向訊息後減1
                    if (nz == -1) nz = 7;
                    A.Tag = nz;
                    Turn(nz, A); //方向轉換
                    break;

                case Keys.X: //改變踢球方向，右轉
                    int nx = int.Parse(A.Tag.ToString()) + 1; //取得物件內箭頭方向訊息後加1
                    if (nx == 8) nx = 0;
                    A.Tag = nx;
                    Turn(nx, A); //方向轉換
                    break;

                case Keys.V: //力量增強
                    int n1 = int.Parse(label_Power.Text) + 5; //取得目前力量值+5
                    if (n1 > 50) n1 = 50; //達最大力量停止
                    label_Power.Text = n1.ToString(); //顯示目前力量
                    break;

                case Keys.C: //力量減少
                    int n2 = int.Parse(label_Power.Text) - 5; //取得目前力量值-5
                    if (n2 < 0) n2 = 0; //達最小力量停止
                    label_Power.Text = n2.ToString(); //顯示目前力量
                    break;
            }
            Send("14" + User + "," + A.Left.ToString() + "," + A.Top.ToString() + "," + teamID.ToString()); //送出User移動的位置訊息(1=廣播,4=移動)
            Application.DoEvents();
            if (chkHit(A)) //判斷是否有踢到球
                Send("15" + teamID.ToString() + "," + A.Tag.ToString() + "," +label_Power.Text); //有踢到球則送出踢球訊息(1=廣播,5=踢球)
        }

        //玩家移動
        private void PlayerMove(string Str)
        {
            string[] M = Str.Split(','); //M[0]=玩家,M[1]=玩家X位置,M[2]=玩家Y位置,M[3]=分隊
            if (M[0] == User) return; //User略過
            Label A = List[M[0]] as Label; //取得移動玩家的Label物件
            if (int.Parse(M[3]) == teamID) //隊友移動
            {
                A.Left = int.Parse(M[1]);
                A.Top = int.Parse(M[2]);
            }
            else //敵隊移動
            {
                //敵隊玩家的位置需上下相反，左右顛倒
                A.Left = pictureBox_Field.Width - int.Parse(M[1]) - A.Width;
                A.Top = pictureBox_Field.Height - int.Parse(M[2]) - A.Height;
            }
            receive = false; //關閉收訊旗標
            Mesg = ""; //清空訊息
        }

        //方向切換
        private void Turn(int n, Label A)
        {
            //改變顯示方向的圖
            if (n == 0) A.Image = Properties.Resources.point;
            if (n == 1) A.Image = Properties.Resources.point1;
            if (n == 2) A.Image = Properties.Resources.point2;
            if (n == 3) A.Image = Properties.Resources.point3;
            if (n == 4) A.Image = Properties.Resources.point4;
            if (n == 5) A.Image = Properties.Resources.point5;
            if (n == 6) A.Image = Properties.Resources.point6;
            if (n == 7) A.Image = Properties.Resources.point7;
        }

        //踢球的碰撞程式
        private bool chkHit(Label A)
        {
            int f = int.Parse(A.Tag.ToString()); //踢球方向
            Point pt = new Point(); //箭頭位置
            switch (f)
            {
                case 0:
                    pt = new Point(A.Left + A.Width / 2, A.Top); //箭頭正上方位置
                    break;
                case 1:
                    pt = new Point(A.Right, A.Top); //箭頭右上方位置
                    break;
                case 2:
                    pt = new Point(A.Right, A.Top + A.Height / 2); //箭頭正右方位置
                    break;
                case 3:
                    pt = new Point(A.Right, A.Bottom); //箭頭右下方位置
                    break;
                case 4:
                    pt = new Point(A.Left + A.Width / 2, A.Bottom); //箭頭正下方位置
                    break;
                case 5:
                    pt = new Point(A.Left, A.Bottom); //箭頭左下方位置
                    break;
                case 6:
                    pt = new Point(A.Left, A.Top + A.Height / 2); //箭頭正左方位置
                    break;
                case 7:
                    pt = new Point(A.Left, A.Top); //箭頭左上方位置
                    break;
            }
            if (pt.X > ball.Right) return false; //箭頭X位置在球的右邊，沒踢到
            if (pt.X < ball.Left) return false; //箭頭X位置在球的左邊，沒踢到
            if (pt.Y < ball.Top) return false; //箭頭Y位置在球的上邊，沒踢到
            if (pt.Y > ball.Bottom) return false; //箭頭Y位置在球的下邊，沒踢到
            return true;
        }

        //踢球
        private void TickBall(string Str)
        {
            string[] M = Str.Split(','); //M[0]=分隊,M[1]=方向,M[2]=力量
            tickID = int.Parse(M[0]); //踢球的隊伍
            ballvector = int.Parse(M[1]); //踢球的方向
            ballpower = int.Parse(M[2]); //踢球的力量
            receive = false; //關閉收訊旗標
            Mesg = ""; //清空訊息
            if (tickID == teamID) { return; } //與User同隊，不用換方向
            switch (ballvector) //敵隊踢球方向
            {
                case 0: //正上方
                    ballvector = 4; //正下方
                    break;
                case 1: //右上方
                    ballvector = 5; //左下方
                    break;
                case 2: //正右方
                    ballvector = 6; //正左方
                    break;
                case 3: //右下方
                    ballvector = 7; //左上方
                    break;
                case 4: //正下方
                    ballvector = 0; //正上方
                    break;
                case 5: //左下方
                    ballvector = 1; //右上方
                    break;
                case 6: //正左方
                    ballvector = 2; //正右方
                    break;
                case 7: //左上方
                    ballvector = 3; //右下方
                    break;
            }
        }

        //遊戲結束
        private void GameOver()
        {
            //球踢進我方的門
            if (ball.Bottom > LA.Top & ball.Left > LA.Left & ball.Right < LA.Right)
            {
                ballpower = 0; //力量歸0
                int score = int.Parse(LSB.Text.Substring(5)) + 1; //敵隊得分
                LSB.Text = "敵隊得分：" + score.ToString();
                if (score < 3) //換我方踢球
                {
                    //重新發球
                    ball.Left = (pictureBox_Field.Width - ball.Width) / 2;
                    ball.Top = (pictureBox_Field.Height - ball.Height) * 3 / 4;
                }
                else //遊戲結束
                {
                    MessageBox.Show("本隊輸了!");
                    button_Start.Enabled = true;
                    LSA.Text = "本隊得分：0";
                    LSB.Text = "敵隊得分：0";
                }
            }
            //球踢進敵方的門
            if (ball.Top < LB.Bottom & ball.Left > LB.Left & ball.Right < LB.Right)
            {
                ballpower = 0; //力量歸0
                int score = int.Parse(LSA.Text.Substring(5)) + 1; //本隊得分
                LSA.Text = "本隊得分：" + score.ToString();
                if (score < 3) //換敵方踢球
                {
                    //重新發球
                    ball.Left = (pictureBox_Field.Width - ball.Width) / 2;
                    ball.Top = (pictureBox_Field.Height - ball.Height) / 4;
                }
                else //遊戲結束
                {
                    MessageBox.Show("本隊贏了!");
                    button_Start.Enabled = true;
                    LSA.Text = "本隊得分：0";
                    LSB.Text = "敵隊得分：0";
                }
            }
        }

        //球移動程式
        private void timer_FMove_Tick(object sender, EventArgs e)
        {
            if (ballpower == 0) return; //球沒有移動力量
            switch (ballvector) //球的移動方向
            {
                case 0: //正上方
                    ball.Top -= ballpower;
                    if (ball.Top < pictureBox_Field.Top) ballvector = 4; //碰到上邊界反射往下
                    break;

                case 1: //右上方
                    ball.Left += ballpower;
                    ball.Top -= ballpower;
                    if (ball.Right > pictureBox_Field.Right) //碰到場地右邊
                        ballvector = 7; //反射往左上方
                    else if (ball.Top < pictureBox_Field.Top) //碰到場地上邊
                        ballvector = 3; //反射往右下方
                    break;

                case 2: //正右方
                    ball.Left += ballpower;
                    if (ball.Right > pictureBox_Field.Right) //碰到場地右邊
                        ballvector = 6; //碰到右邊界反射往左
                    break;

                case 3: //右下方
                    ball.Left += ballpower;
                    ball.Top += ballpower;
                    if (ball.Right > pictureBox_Field.Right) //碰到場地右邊
                        ballvector = 5; //反射往左下方
                    else if (ball.Bottom > pictureBox_Field.Bottom) //碰到場地下邊
                        ballvector = 1; //反射往右上方
                    break;

                case 4: //正下方
                    ball.Top += ballpower;
                    if (ball.Bottom > pictureBox_Field.Bottom) //碰到場地下邊
                        ballvector = 0; //碰到下邊界反射往上
                    break;

                case 5: //左下方
                    ball.Left -= ballpower;
                    ball.Top += ballpower;
                    if (ball.Left < pictureBox_Field.Left) //碰到場地左邊
                        ballvector = 3; //反射往右下方
                    else if (ball.Bottom > pictureBox_Field.Bottom) //碰到場地下邊
                        ballvector = 7; //反射往左上方
                    break;

                case 6: //正左方
                    ball.Left -= ballpower;
                    if (ball.Left < pictureBox_Field.Left) //碰到場地左邊
                        ballvector = 2; //碰到左邊界反射往右
                    break;

                case 7: //左上方
                    ball.Left -= ballpower;
                    ball.Top -= ballpower;
                    if (ball.Left < pictureBox_Field.Left) //碰到場地左邊
                        ballvector = 1; //反射往右上方
                    else if (ball.Top < pictureBox_Field.Top) //碰到場地上邊
                        ballvector = 5; //反射往左下方
                    break;
            }
            ballpower -= 1; //球移動力量減少
            GameOver(); //遊戲結束
        }
    }
}

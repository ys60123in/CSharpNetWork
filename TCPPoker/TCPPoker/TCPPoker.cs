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

namespace TCPPoker
{
    public partial class TCPPoker : Form
    {
        Socket T; //通訊物件
        Thread Th; //網路監聽執行緒
        string User; //使用者
        bool me; //輪到自己的旗標
        List<PictureBox> Pk = new List<PictureBox>(); //玩家手上的牌
        bool run; //控制主表單無限迴圈開關
        bool receive = false; //接收到訊號旗標
        string Mesg = string.Empty; //接收到的公告信號內容
        string[] P7 = new string[8]; //牌面出牌狀態
        string nextOne; // 下一位出牌者
        List<string> win = new List<string>(); //輸贏順位

        public TCPPoker()
        {
            InitializeComponent();
        }

        private void TCPPoker_Load(object sender, EventArgs e)
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

        //關閉表單
        private void TCPPoker_FormClosing(object sender, FormClosingEventArgs e)
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
                case "A": //發牌訊息
                    DealCards(Str); //新增牌面物件
                    break;

                case "B": //出牌訊息
                    PlayCards(Str); //牌桌上顯示出牌訊息
                    break;

                case "C": //某玩家牌出完了
                    string[] winner = Str.Split('|'); //出牌內容|出完牌的人
                    PlayCards(winner[0]); //牌桌上顯示出牌狀態
                    WinCards(winner[1]); //贏的玩家
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

                    case "1": //接收廣播訊息
                        Mesg = Str; //訊息複製到公用變數
                        receive = true; //開啟收到訊息旗標
                        break;

                    case "2":
                        textBox_SysMsg.Text = Str; //接收訊息內容
                        me = true; //輪到我出牌
                        button_Pass.Enabled = true; //開啟跳過按鍵
                        break;
                }
            }
        }

        //發牌
        private void button_Deal_Click(object sender, EventArgs e)
        {
            if (listBox_OnlineUser.Items.Count != 4)
            {
                MessageBox.Show("遊戲需要四人參加!");
                return;
            }
            List<string> myList = new List<string>(); //資料夾內所有圖檔路徑清單
            //取得執行幕錄下的PokerCards資料夾路徑
            string folerName = System.Environment.CurrentDirectory + "\\PokerCards";
            foreach (string fname in System.IO.Directory.GetFiles(folerName))
            {
                myList.Add(fname); //資料夾內所有檔案路徑加入清單
            }
            //隨機發牌
            List<string> ranList = new List<string>(); //隨機發牌圖檔路徑清單
            Random ran = new Random();
            while (myList.Count > 0) //洗牌
            {
                int RandKey = ran.Next(0, myList.Count - 1);
                string s = myList[RandKey];
                ranList.Add(s);
                myList.RemoveAt(RandKey);
            }
            int m = 52 / 4; //每人擁有牌數
            int mn = 0; //每人發牌計數
            int Pid = -1; //listBox_OnlineUser裡索引值
            string sendC = ""; //發牌內容
            for (int i = 0; i < 52; i++)
            {
                string[] Ps = ranList[i].Split('\\'); //切割檔案路徑
                string[] Pn = Ps[Ps.Length - 1].Split('.'); //切割檔名與副檔名(EX:黑桃2.png)

                mn++;
                if (mn == 1 || mn > m) //第一張牌
                {
                    mn = 1;
                    Pid += 1;
                    string player = listBox_OnlineUser.Items[Pid].ToString(); //依listBox裡名單順序發牌
                    sendC += player + "," + Pn[0] + ","; //(EX:玩家,牌1)
                }
                else
                {
                    if (mn < m) sendC += Pn[0] + ","; //串接發牌內容(EX:玩家,牌1,牌2,...)

                    if (mn == m) sendC += Pn[0] + "|"; //已達一個玩家的牌數，用"|"分割下一位玩家
                }
            }
            Send("1" + "A" + sendC); //送發牌訊息給所有人(1:廣播 A:發牌)
            me = true;
            textBox_SysMsg.Text = "輪到你出牌!"; //提醒出牌
            button_Pass.Enabled = true; //開啟跳過按鍵
        }

        //跳過
        private void button_Pass_Click(object sender, EventArgs e)
        {
            Send("2" + "輪到你出牌" + "|" + nextOne); //送出私人訊息給下一位出牌者
            textBox_SysMsg.Text = "等待...";
            button_Pass.Enabled = false;
        }

        //新增牌面物件
        private void DealCards(string s)
        {
            string[] F = s.Split('|'); //全部的牌依玩家分發
            int nc = 0; //每人收到牌數
            for (int i = 0; i < F.Length - 1; i++)
            {
                string[] U = F[i].Split(','); //玩家名稱,牌1,牌2
                nc = U.Length - 1; //每人收到牌數
                if (U[0] == User)
                {
                    for (int j = 1; j < U.Length; j++)
                    {
                        //牌的圖檔路徑
                        string fn1 = System.Environment.CurrentDirectory + "\\PokerCards\\" + U[j] + ".png";
                        PictureBox Pc = new PictureBox(); //宣告一個新的PictureBox物件
                        Pc.Name = "P" + j.ToString(); //物件名稱
                        Pc.Tag = U[j]; //牌面(花色+號碼)
                        Pc.Size = new Size(100, 140); //物件大小
                        Pc.SizeMode = PictureBoxSizeMode.StretchImage; //圖片顯示符合容器大小
                        Pc.Left = (j - 1) * 20; //圖片左邊位置
                        Pc.Top = label_RmCards.Bottom + 20; //圖片上邊位置
                        Pc.Image = Image.FromFile(fn1); //圖片路徑來源
                        //加入事件副程式(滑鼠按到牌面上的延伸動作)
                        Pc.MouseDown += new MouseEventHandler(PictureBox_MouseDown);
                        this.Controls.Add(Pc);
                        Pc.BringToFront(); //移到最前
                        Pk.Add(Pc); //把圖加入物件陣列(玩家手上的牌)
                    }
                }
            }
            label_RmCards.Text = "剩餘牌數:" + nc.ToString();
            button_Deal.Enabled = false; //不能重複發牌
            for (int i = 0; i < listBox_OnlineUser.Items.Count - 1; i++) //依listBox_OnlineUse名單決定出牌順序
            {
                if (User == listBox_OnlineUser.Items[i].ToString())
                {
                    nextOne = listBox_OnlineUser.Items[i + 1].ToString(); //決定下一位出牌者
                    break;
                }
            }
            if (User == listBox_OnlineUser.Items[listBox_OnlineUser.Items.Count - 1].ToString())
            {
                nextOne = listBox_OnlineUser.Items[0].ToString();
            }
            receive = false; //關閉收到訊息旗標
            Mesg = ""; //清空訊息
        }

        //出牌滑鼠事件
        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (me == false) return; //不能出牌
            PictureBox Pc = (PictureBox)sender; //被選到的牌
            if (e.Button == MouseButtons.Left) //選牌
            {
                //其他牌回原位
                for (int i = 0; i < Pk.Count; i++)
                {
                    PictureBox P0 = Pk[i];
                    P0.Top = label_RmCards.Bottom + 20;
                }
                Pc.Top = label_RmCards.Bottom; //選中的牌上移位置
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (Rules(Pc) == false) return; //規則判斷
                if (Pk.Count > 1) //剩餘多1張牌
                {
                    Send("1" + "B" + Pc.Tag); //送出出牌訊息(1=廣播,B=出牌)
                    Send("2" + "輪到你出牌!" + "|" + nextOne); //送出私人訊息給下一位出牌者(2=私訊)
                    textBox_SysMsg.Text = "等待...";
                }
                else
                {
                    //勝1張牌，我贏了
                    Send("1" + "C" + Pc.Tag + "|" + User); //送出出牌訊息(1=廣播,C=牌出完了)
                    if (win.Count < 2)
                    {
                        Send("2" + "輪到你出牌!" + "|" + nextOne); //前2名需送出私人訊息給下一位出牌者
                    }
                    textBox_SysMsg.Text = "結束遊戲!";
                }
                for (int i = 0; i < Pk.Count; i++) //刪除自己手上的牌
                {
                    PictureBox P0 = Pk[i];
                    if (P0.Name == Pc.Name)
                    {
                        Pk.RemoveAt(i); //刪除已出的牌
                        Pc.Dispose(); //刪除物件
                        break;
                    }
                }
                label_RmCards.Text = "剩餘牌數:" + Pk.Count.ToString();
                me = false; //關閉出牌旗標
                button_Pass.Enabled = false; //關閉跳過按鈕
            }
        }

        //出牌前判定規則出牌
        private bool Rules(PictureBox Pc)
        {
            int n = int.Parse(Pc.Tag.ToString().Substring(2)); //出牌的數字
            string m = Pc.Tag.ToString().Substring(0, 2); //出牌的花色

            if (n == 7)
            {
                return true;
            }
            else
            {
                for (int i = 0; i <= 6; i += 2)
                {
                    if (P7[i] == null) continue; //沒牌跳過
                    int nmax = int.Parse(P7[i].Substring(2)); //牌桌上上排數字
                    int nmin = int.Parse(P7[i + 1].Substring(2)); //牌桌上下排數字
                    string mm = P7[i].Substring(0, 2); //排面上花色
                    if (m != mm) continue; //花色不同
                    if (n == nmax + 1)
                    {
                        return true;
                    }
                    else if (n == nmin - 1)
                    {
                        return true;
                    }
                }
            }

            return false; //出牌錯誤
        }

        //牌桌上顯示出牌狀態
        private void PlayCards(string S)
        {
            int n = int.Parse(S.Substring(2)); //出牌的數字
            string m = S.Substring(0, 2); //出牌的花色
            string fn2 = System.Environment.CurrentDirectory + "\\PokerCards\\" + S + ".png"; //此牌的圖檔路徑
            if (n == 7) //牌面數字7
            {
                for (int i = 0; i <= 6; i += 2)
                {
                    if (P7[i] == null)
                    {
                        P7[i] = S; //出牌內容記錄在陣列裡
                        P7[i + 1] = S;
                        //取得表單內pictureBox物件
                        PictureBox P1 = this.Controls.Find("pictureBox" + (i + 1).ToString(), false).FirstOrDefault() as PictureBox;
                        PictureBox P2 = this.Controls.Find("pictureBox" + (i + 2).ToString(), false).FirstOrDefault() as PictureBox;
                        P1.Image = Image.FromFile(fn2);
                        P2.Image = Image.FromFile(fn2);
                        break;
                    }
                }
            }
            else //其他非7的牌面數字
            {
                for (int i = 0; i <= 6; i += 2)
                {
                    if (P7[i] == null) continue; //牌桌上空的
                    int nmax = int.Parse(P7[i].Substring(2)); //牌桌上上排數字
                    int nmin = int.Parse(P7[i + 1].Substring(2)); //牌桌上下排數字
                    string mm = P7[i].Substring(0, 2); //排面上花色
                    if (m != mm) continue; //花色不同
                    if (n == nmax + 1)
                    {
                        P7[i] = S;
                        PictureBox P1 = this.Controls.Find("pictureBox" + (i + 1).ToString(), false).FirstOrDefault() as PictureBox;
                        P1.Image = Image.FromFile(fn2);
                        break;
                    }
                    else if (n == nmin - 1)
                    {
                        P7[i + 1] = S;
                        PictureBox P2 = this.Controls.Find("pictureBox" + (i + 2).ToString(), false).FirstOrDefault() as PictureBox;
                        P2.Image = Image.FromFile(fn2);
                        break;
                    }
                }
            }
            receive = false; //關閉收到訊息旗標
            Mesg = ""; //清空訊息
        }

        //玩家贏牌
        private void WinCards(string S)
        {
            win.Add(S); //贏的玩家
            listBox_Rank.Items.Add("第" + win.Count.ToString() + "名:" + S);
            if (win.Count == 3) //第3名牌出完(遊戲結束)
            {
                textBox_SysMsg.Text = "遊戲結束!";
                me = false;
                button_Pass.Enabled = false;
            }
            else
            {
                //重新決定下一位出牌者
                nextOne = "";
                int meid = -1; //自己在名單上的索引位置
                for (int i = 0; i < listBox_OnlineUser.Items.Count; i++)
                {
                    if (listBox_OnlineUser.Items[i].ToString() == User)
                    {
                        meid = i;
                        break;
                    }
                }
                int nextid = meid + 1; //下一位出牌者在名單上的索引位置
                if (nextid == listBox_OnlineUser.Items.Count) nextid = 0;
                while (nextid != meid)
                {
                    bool ck = false; //是否在贏的名單上
                    nextOne = listBox_OnlineUser.Items[nextid].ToString(); //下一位玩家
                    for (int i = 0; i < win.Count; i++) //贏的玩家名單
                    {
                        if (nextOne == win[i])
                        {
                            ck = true; //此玩家已經贏了
                            break;
                        }
                    }
                    if (ck == false) break; //此玩家尚未出完牌
                    //此玩家已經贏了找下一位
                    if (nextid < listBox_OnlineUser.Items.Count - 1)
                    {
                        nextid += 1;
                    }
                    else
                    {
                        nextid = 0;
                    }
                }
            }
            receive = false; //關閉收到訊息旗標
            Mesg = ""; //清空訊息
        }
    }
}

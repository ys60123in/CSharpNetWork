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
using Microsoft.VisualBasic.PowerPacks;

namespace UDPCanvas
{
    public partial class UDPCanvas : Form
    {
        UdpClient U; //宣告UDP通訊物件
        Thread Th; //宣告監聽用執行緒
        //繪圖相關變數宣告
        ShapeContainer C; //畫布物件(本機繪圖用)
        ShapeContainer D; //畫布物件(遠端繪圖用)
        Point stP; //繪圖起點
        string p; //筆畫座標字串

        public UDPCanvas()
        {
            InitializeComponent();
        }

        //表單載入
        private void UDPCanvas_Load(object sender, EventArgs e)
        {
            C = new ShapeContainer(); //本機繪圖用
            this.Controls.Add(C); //加入畫布C到表單
            D = new ShapeContainer(); //遠端繪圖用
            this.Controls.Add(D); //加入畫布D到表單
        }

        private void button_Connect_Click(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false; //忽略跨執行緒錯誤
            Th = new Thread(Listen); //建立監聽執行緒，目標副程序->Listen
            Th.Start(); //啟動監聽執行緒
            button_Connect.Enabled = false; //使按鍵失效，不能(也不需要)重複開啟監聽
        }

        //監聽副程序
        private void Listen()
        {
            int Port = int.Parse(textBox_ListenPort.Text); //設定監聽用的通訊阜
            U = new UdpClient(Port); //監聽UDP監聽器實體
            //建立本機端點資訊
            IPEndPoint EP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), Port);
            while (true) //持續監聽的無限迴圈
            {
                byte[] B = U.Receive(ref EP); //訊息傳達時讀取資訊到B陣列
                string A = Encoding.Default.GetString(B); //翻譯B陣列為字串A
                string[] Z = A.Split('_'); //切割顏色與座標資訊
                string[] Q = Z[1].Split('/'); //切割座標資訊
                Point[] R = new Point[Q.Length]; //宣告座標點陣列
                for(int i = 0; i < Q.Length; i++) 
                {
                    string[] K = Q[i].Split(','); //切割X與Y座標
                    R[i].X = int.Parse(K[0]); //定義第i點X座標
                    R[i].Y = int.Parse(K[1]); //定義第i點Y座標
                }
                for (int i = 0; i < Q.Length - 1; i++)
                {
                    LineShape L = new LineShape(); //建立線段物件
                    L.StartPoint = R[i]; //線段起點
                    L.EndPoint = R[i + 1]; //線段終點
                    switch (Z[0]) //筆色
                    {
                        case "1": //紅筆
                            L.BorderColor = Color.Red;
                            break;
                        case "2": //亮綠色筆
                            L.BorderColor = Color.Lime;
                            break;
                        case "3": //藍筆
                            L.BorderColor = Color.Blue;
                            break;
                        case "4": //黑筆
                            L.BorderColor = Color.Black;
                            break;
                    }
                    L.Parent = D; //線段L加入畫布D(遠端使用者繪圖)
                }
            }
        }

        private void UDPCanvas_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Th.Abort(); //關閉監聽執行緒
                U.Close(); //關閉監聽器
            } 
            catch (Exception)
            {
                //忽略錯誤
            }
        }

        //本機端開始繪圖
        private void UDPCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            stP = e.Location; //起點
            p = stP.X.ToString() + "," + stP.Y.ToString(); //起點座標記錄
        }

        //本機繪圖中
        private void UDPCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                LineShape L = new LineShape(); //建立線段物件
                L.StartPoint = stP; //線段起點
                L.EndPoint = e.Location; //線段終點
                if(radioButton_Red.Checked) { L.BorderColor = Color.Red; } //紅筆
                if (radioButton_Green.Checked) { L.BorderColor = Color.Lime; } //亮綠色筆
                if (radioButton_Blue.Checked) { L.BorderColor = Color.Blue; } //藍筆
                if (radioButton_Black.Checked) { L.BorderColor = Color.Black; } //黑筆
                L.Parent = C; //線段加入畫布C
                stP = e.Location; //終點變起點
                p += "/" + stP.X.ToString() + "," + stP.Y.ToString(); //持續記錄座標
            }
        }

        //送出繪圖動作
        private void UDPCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            string IP = textBox_TargetIP.Text; //設定發送的目標IP
            int Port = int.Parse(textBox_TargetPort.Text); //設定發送的目標Port
            UdpClient S = new UdpClient(IP, Port); //建立UDP物件
            if (radioButton_Red.Checked) { p = "1_" + p; } //紅筆
            if (radioButton_Green.Checked) { p = "2_" + p; } //亮綠色筆
            if (radioButton_Blue.Checked) { p = "3_" + p; } //藍筆
            if (radioButton_Black.Checked) { p = "4_" + p; } //黑筆
            byte[] B = Encoding.Default.GetBytes(p); //翻譯p字串為B陣列
            S.Send(B, B.Length); //發送資料
            S.Close(); //關閉UDP物件
        }
    }
}

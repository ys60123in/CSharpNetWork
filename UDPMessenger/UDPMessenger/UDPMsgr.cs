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

namespace UDPMessenger
{
    public partial class UDPMsgr : Form
    {
        UdpClient U; //宣告UDP通訊物件
        Thread Th; //宣告監聽用執行緒

        public UDPMsgr()
        {
            InitializeComponent();
        }

        //啟動接收
        private void button_StartReceive_Click(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false; //忽略跨執行緒錯誤
            Th = new Thread(Listen); //建立監聽執行緒，目標副程序->Listen
            Th.Start(); //啟動監聽執行緒
            button_StartReceive.Enabled = false; //使按鍵失效，不能(也不需要)重複開啟監聽
        }

        //發送UDP訊息
        private void button_Transfer_Click(object sender, EventArgs e)
        {
            string IP = textBox_TargetIP.Text; //設定發送目標IP
            int Port = int.Parse(textBox_TargetPort.Text); //設定發送目標Port
            byte[] B = Encoding.Default.GetBytes(textBox_TransferMsg.Text); //字串翻譯成位元組陣列
            UdpClient S = new UdpClient(); //建立UDP通訊器
            S.Send(B, B.Length, IP, Port); //發送資料到指定位置
            S.Close(); //關閉通訊器
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
                byte[] B = U.Receive(ref EP); //訊息到達時讀取信息到B陣列
                textBox_ReceiveMsg.Text = Encoding.Default.GetString(B); //翻譯B陣列為字串
            }
        }

        //關閉監聽執行緒(如果有的話)
        private void UDPMsgr_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}

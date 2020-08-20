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
using System.Collections; //匯入集合物件功能

namespace UDPChatRoom
{
    public partial class UDPChatRoom : Form
    {
        UdpClient U; //宣告UDP通訊物件
        Thread Th; //宣告監聽用執行緒
        String MyName; //我的名稱
        ArrayList ips = new ArrayList(); //線上客戶IP列表
        const short Port = 2019; //本程式使用的通訊埠(頻道)
        string BC = IPAddress.Broadcast.ToString(); //廣播用IP

        public UDPChatRoom()
        {
            InitializeComponent();
        }

        private void UDPChatRoom_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false; //忽略跨執行續操作的錯誤
            this.Text += " " + MyIP(); //顯示本機IP於標題列
        }

        //關閉監聽執行緒(如果有的話)
        private void UDPChatRoom_FormClosing(object sender, FormClosingEventArgs e)
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

        //上線或離線的選擇
        private void button_Connect_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox_User.Text))
            {
                MessageBox.Show("請輸入姓名!");
                return;
            }

            MyName = textBox_User.Text; //我的名稱
            listBox_OnlineUser.Items.Clear(); //清除名單
            ips.Clear(); //清除線上人員IP陣列
            
            if(button_Connect.Text.Equals("上線"))
            {
                Th = new Thread(Listen); //建立監聽網路訊息的新執行緒
                Th.Start(); //啟動監聽執行緒
                Send(BC, "OnLine", ""); //公告上線訊息
                button_Connect.Text = "離線";
            }
            else
            {
                Send(BC, "OffLine", ""); //公告離線訊息
                Th.Abort(); //關閉監聽執行緒
                U.Close(); //關閉監聽器
                button_Connect.Text = "上線";
            }
        }

        //廣播
        private void button_Broadcast_Click(object sender, EventArgs e)
        {
            listBox_OnlineUser.ClearSelected();
        }

        //找出本機IP
        private string MyIP()
        {
            string hn = Dns.GetHostName(); //取得本機電腦名稱
            IPAddress[] ip = Dns.GetHostEntry(hn).AddressList; //取得本機IP陣列(可能有多個)
            foreach (IPAddress it in ip)
            {
                if (it.AddressFamily == AddressFamily.InterNetwork) //如果是IPv4格式
                {
                    return it.ToString(); //回傳此IP字串
                }
            }

            return ""; //找不到合格IP，回傳空字串
        }

        private void Send(string ToIP, string msg, string toWhom)
        {
            //訊息格式:我是誰+IP+訊息+發給誰
            string A = string.Format("{0}:{1}:{2}:{3}", MyName, MyIP(), msg, toWhom);
            Byte[] B = Encoding.Default.GetBytes(A); //字串翻譯成位元組列
            UdpClient V = new UdpClient(ToIP, Port); //建立UDP通訊物件
            V.Send(B, B.Length); //發送資料
        }

        //監聽副程序
        private void Listen()
        {
            U = new UdpClient(Port); //建立UDP通訊物件
            //接聽端點(IP+Port)
            IPEndPoint EP = new IPEndPoint(IPAddress.Parse(MyIP()), Port);
            while (true)
            {
                byte[] B = U.Receive(ref EP); //訊息到達時讀取信息到B陣列
                string A = Encoding.Default.GetString(B); //翻譯B陣列為字串A
                //切割訊息為:C[0] = 發訊者;C[1] = IP;C[2] = 訊息;C[3] = 發訊對象
                string[] C = A.Split(':');
                switch (C[2]) //根據訊息內容做動作
                {
                    case "OnLine":
                        listBox_OnlineUser.Items.Add(C[0]); //名稱加入列表
                        ips.Add(C[1]); //IP加入集合物件
                        if (C[0] != MyName) 
                        { 
                            Send(C[1], "AddMe", C[0]); //回應我也在線上 
                        }
                        break;
                    case "AddMe":
                        listBox_OnlineUser.Items.Add(C[0]); //名稱加入列表
                        ips.Add(C[1]); //IP加入集合物件
                        break;
                    case "OffLine":
                        listBox_OnlineUser.Items.Remove(C[0]); //移除名單
                        ips.Remove(C[1]); //移除IP
                        break;
                    default:
                        if (C[3] == "") //公開訊息(無指定收訊者)
                        {
                            listBox_Msg.Items.Add(C[0] + "(廣播):" + C[2]); //加入看板
                        }
                        else //私密訊息(有指定收訊者C[3])
                        {
                            listBox_Msg.Items.Add(C[0] + " to " + C[3] + " : " + C[2]); //加入看板
                        }
                        break;
                }
            }
        }

        //發送自訂訊息
        private void textBox_Msg_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(listBox_OnlineUser.SelectedIndex < 0) //未選擇發訊對象
                {
                    Send(BC, textBox_Msg.Text, "");
                }
                else //發送私密訊息
                {
                    Send(ips[listBox_OnlineUser.SelectedIndex].ToString(), textBox_Msg.Text, listBox_OnlineUser.SelectedItem.ToString());
                    listBox_Msg.Items.Add(MyName + " to " + listBox_OnlineUser.SelectedItem.ToString() + " : " + textBox_Msg.Text); //訊息寫入看板
                }
                textBox_Msg.Text = "";
            }
        }
    }
}

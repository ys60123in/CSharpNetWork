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

namespace UPDServer
{
    public partial class UDPServer : Form
    {
        Thread Th;
        const int Port = 2019;

        public UDPServer()
        {
            InitializeComponent();
        }

        private void UDPServer_Load(object sender, EventArgs e)
        {
            Th = new Thread(Listen); //建立監聽執行緒
            Th.IsBackground = true; //設為背景執行緒
            Th.Start();
        }

        private void UDPServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Th.Abort(); //關閉執行緒
        }

        //伺服器監聽程式
        private void Listen() 
        {
            UdpClient U = new UdpClient(Port);
            while(true)
            {
                IPEndPoint EP = new IPEndPoint(IPAddress.Any, Port); //建立監聽端點資訊(接收任何IP)
                byte[] B = U.Receive(ref EP);
                string A = Encoding.Default.GetString(B);
                string M = "Unknown Command";
                if (A == "Time?")
                {
                    M = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                }
                B = Encoding.Default.GetBytes(M);
                U.Send(B, B.Length, EP);
            }
        }
    }
}

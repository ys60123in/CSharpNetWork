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
using System.Xml.Xsl;

namespace UDPClient
{
    public partial class UDPClient : Form
    {
        const int Port = 2019;

        public UDPClient()
        {
            InitializeComponent();
        }

        private void button_Command_Click(object sender, EventArgs e)
        {
            UdpClient C = new UdpClient();
            IPEndPoint EP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), Port); //應為伺服器端所在IP
            C.Connect(EP);
            byte[] B = Encoding.Default.GetBytes(textBox_Command.Text); //送出問題
            C.Send(B, B.Length);
            byte[] R = C.Receive(ref EP); //原路接收訊息
            textBox_Result.Text = Encoding.Default.GetString(R);
        }
    }
}

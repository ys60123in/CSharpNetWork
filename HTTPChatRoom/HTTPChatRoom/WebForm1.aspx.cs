using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTTPChatRoom
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //發送
        protected void Button_Enter_Click(object sender, EventArgs e)
        {
            string A = TextBox_User.Text + "：" + TextBox_Msg.Text; //發言者：發言
            TextBox_Messages.Text += A + "\r\n"; //寫入看板
            Application[TextBox_ToWhom.Text] = A; //發給收訊者
            TextBox_Msg.Text = ""; //清除發言框
        }

        //檢視收訊的程式
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            if(Application[TextBox_User.Text] != null)
            {
                TextBox_Messages.Text += Application[TextBox_User.Text] + "\r\n"; //寫入看板
                Application[TextBox_User.Text] = null; //刪除訊息
            }
        }
    }
}
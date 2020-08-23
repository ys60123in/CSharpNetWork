using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTTPCanvas
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //資訊定時接收
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            if (H1.Value.Length > 0)
            {
                if(!string.IsNullOrEmpty(TextBox_ToWhom.Text)) //如有設定發送對象
                {
                    Application[TextBox_ToWhom.Text] = H1.Value; //送出
                    H1.Value = ""; //清除資訊
                }
            }

            if (!string.IsNullOrEmpty(TextBox_User.Text))
            {
                if (Application[TextBox_User.Text] != null) //如有訊息送達
                {
                    H2.Value = Application[TextBox_User.Text].ToString(); //接收資訊送至網頁
                    Application[TextBox_User.Text] = null; //清除訊息
                }
            }
        }
    }
}
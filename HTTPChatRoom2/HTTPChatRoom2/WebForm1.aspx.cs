using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace HTTPChatRoom2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //登入與登出
        protected void Button_Login_Click(object sender, EventArgs e)
        {
            if (Button_Login.Text == "上線") //嘗試上線
            {
                if(!string.IsNullOrEmpty(TextBox_User.Text))
                {
                    Session[TextBox_User.Text] = TextBox_User.Text; //記錄登入名稱
                    Application.Lock(); //鎖定網站公用變數
                    Hashtable L = (Hashtable)Application["L"]; //取得線上名單
                    L.Add(Session[TextBox_User.Text], DateTime.Now); //加自己到線上名單(名稱, 時間)
                    Application.UnLock(); //解除鎖定
                    Button_Login.Text = "離線"; //已登入顯示功能為登出
                }
            }
            else
            {
                Application.Lock(); //鎖定網站公用變數
                Hashtable L = (Hashtable)Application["L"]; //取得線上名單
                L.Remove(Session[TextBox_User.Text]); //移除名單中的我
                Application.UnLock(); //解除鎖定
                Session[TextBox_User.Text] = null; //清除登入名稱
                Button_Login.Text = "上線"; //已登出顯示功能為登入
            }
        }

        //發言
        protected void Button_Enter_Click(object sender, EventArgs e)
        {
            if(!(Session[TextBox_User.Text] == null))
            {
                Application.Lock(); //鎖定網站公用變數
                Queue Q = (Queue)Application["Q"]; //取得目前發言內容
                Q.Enqueue(TextBox_User.Text + "：" + TextBox_Msg.Text); //加入我的發言
                while(Q.Count > 5) //保存五筆資料
                {
                    Q.Dequeue(); //刪除最舊的資料
                }
                Application.UnLock(); //解除鎖定
            }
        }

        //定時更新
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            //更新發言
            Queue Q = (Queue)Application["Q"]; //取得目前發言內容
            TextBox_Messages.Text = ""; //清除看板
            foreach(var i in Q)
            {
                TextBox_Messages.Text += i + "\r\n"; //一一顯示留言
            }

            //更新線上名單
            Application.Lock(); //鎖定網站公用變數
            Hashtable L = (Hashtable)Application["L"]; //取得線上名單
            if(!(Session[TextBox_User.Text] == null)) //已登入
            {
                if(L[Session[TextBox_User.Text]] == null) //如果我不在名單內
                {
                    L.Add(Session[TextBox_User.Text], DateTime.Now); //重新登入我自己
                }
                else
                {
                    L[Session[TextBox_User.Text]] = DateTime.Now; //打卡更新時間
                }
            }
            Application.UnLock(); //解除鎖定
            ListBox_OnlineUser.Items.Clear(); //清除線上名單
            //在listBox中一一顯示名單
            foreach(var i in L.Keys)
            {
                ListBox_OnlineUser.Items.Add(i.ToString());
            }
        }
    }
}
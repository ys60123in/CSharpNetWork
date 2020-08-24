﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace HTTPGobang
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //繪製棋盤
            //Bitmap bmp = new Bitmap(570, 570);
            //Graphics g = Graphics.FromImage(bmp);
            //for (int i = 0; i < 19; i++) 
            //{
            //    g.DrawLine(Pens.Black, i * 30 + 15, 15, i * 30 + 15, 30 * 18 + 15);
            //}
            //for (int j = 0; j < 19; j++)
            //{
            //    g.DrawLine(Pens.Black, 15, j * 30 + 15, 30 * 18 + 15, j * 30 + 15);
            //}
            //bmp.Save(Server.MapPath("bg.gif"));
        }

        //重完按鍵
        protected void Button_Restart_Click(object sender, EventArgs e)
        {
            Application[TextBox_To.Text] = "0"; //發訊息要求對手重設棋盤
            H2clt.Value = "0"; //清除己方棋盤(送訊息到己方網頁)
        }

        //定時更新處理
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            if (H2svr.Value != "") //己方已有下棋動作(點擊棋盤)時
            {
                if (TextBox_To.Text != "")
                {
                    Application[TextBox_To.Text] = H2svr.Value; //發送下棋位置給對手
                }
                H2svr.Value = ""; //清除隱藏欄位，避免重複處理
            }
            if (TextBox_Me.Text != "")
            {
                if (Application[TextBox_Me.Text] != null) //對方有動作傳來
                {
                    H2clt.Value = Application[TextBox_Me.Text].ToString(); //取得訊息傳送到我的客戶端
                    Application[TextBox_Me.Text] = null; //刪除訊息
                }
            }
        }
    }
}
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="HTTPChatRoom2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Timer ID="Timer1" runat="server" Interval="2000" OnTick="Timer1_Tick">
                    </asp:Timer>
                    <br />
                    線上名單<br /> 
                    <asp:ListBox ID="ListBox_OnlineUser" runat="server" Width="200px"></asp:ListBox>
                    <br />
                    聊天看板<br /> 
                    <asp:TextBox ID="TextBox_Messages" runat="server" Rows="7" TextMode="MultiLine" Width="190px"></asp:TextBox>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <p>
            我是：<asp:TextBox ID="TextBox_User" runat="server"></asp:TextBox>
            <asp:Button ID="Button_Login" runat="server" OnClick="Button_Login_Click" Text="上線" />
        </p>
        <p>
            想說：<asp:TextBox ID="TextBox_Msg" runat="server"></asp:TextBox>
            <asp:Button ID="Button_Enter" runat="server" OnClick="Button_Enter_Click" Text="發言" />
        </p>
    </form>
</body>
</html>

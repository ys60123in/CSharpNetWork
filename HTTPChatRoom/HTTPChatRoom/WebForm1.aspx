<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="HTTPChatRoom.WebForm1" %>

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
                    <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick">
                    </asp:Timer>
                    <asp:TextBox ID="TextBox_Messages" runat="server" Rows="6" TextMode="MultiLine"></asp:TextBox>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <p>
            我是：<asp:TextBox ID="TextBox_User" runat="server"></asp:TextBox>
            要跟：<asp:TextBox ID="TextBox_ToWhom" runat="server"></asp:TextBox>
        </p>
        <p>
            講說：<asp:TextBox ID="TextBox_Msg" runat="server"></asp:TextBox>
            <asp:Button ID="Button_Enter" runat="server" OnClick="Button_Enter_Click" Text="送出" />
        </p>
    </form>
</body>
</html>

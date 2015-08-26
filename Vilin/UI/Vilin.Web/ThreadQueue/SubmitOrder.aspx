<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubmitOrder.aspx.cs" Inherits="Vilin.Web.ThreadQueue.SubmitOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <asp:Literal ID="litMsg" runat="server"></asp:Literal></div>
        <div>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /></div>
    </div>
    </form>
</body>
</html>

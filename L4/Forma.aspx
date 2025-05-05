<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forma.aspx.cs" Inherits="L4.Forma" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Styles.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Nekilnojamojo turto agentūra</h1>
            <asp:Button ID="Upload" runat="server" Text="Skaičiuoti" Width="80px" OnClick="Upload_Click" />
            <br />
        </div>
    </form>
</body>
</html>

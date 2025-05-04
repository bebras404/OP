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
            <asp:Table ID="Data1" runat="server"></asp:Table>
            <br />
            <asp:Table ID="Data2" runat="server"></asp:Table>
            <br />
            <asp:Table ID="Data3" runat="server"></asp:Table>
            <br />
            <asp:Label ID="MaxStreet" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="OldestLabel" runat="server" Text="Seniausi parduodami objektai"></asp:Label>
            <br />
            <asp:Table ID="OldestData" runat="server"></asp:Table>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Objektai esantys keliose agentūrose"></asp:Label>
            <br />
            <asp:Table ID="FastSell" runat="server"></asp:Table>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Itin dideli objektai"></asp:Label>
            <br />
            <asp:Table ID="Large" runat="server"></asp:Table>
            <br />



        </div>
    </form>
</body>
</html>

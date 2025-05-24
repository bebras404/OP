<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forma.aspx.cs" Inherits="LD5.Forma" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Styles.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server" visible="True">
        <div>
            Moduliai<br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Įkelti duomenis" />
            <br />
            <br />
            <asp:PlaceHolder ID="PH4" runat="server"></asp:PlaceHolder>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Įveskite dėstytojo vardą ir pavardę:" Visible="False"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox1" runat="server" Visible="False" Width="190px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Atrinkti" Visible="False" />
            <br />
            <br />
            <asp:PlaceHolder ID="PH3" runat="server"></asp:PlaceHolder>
            <br />
            <br />
            <asp:PlaceHolder ID="PH2" runat="server"></asp:PlaceHolder>
            <br />
            <br />
            <asp:PlaceHolder ID="PH1" runat="server"></asp:PlaceHolder>
        </div>
    </form>
</body>
</html>

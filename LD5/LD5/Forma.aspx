<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forma.aspx.cs" Inherits="LD5.Forma" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Styles.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Moduliai<br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Įkelti duomenis" />
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

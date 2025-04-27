<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form.aspx.cs" Inherits="Lab3.Forma" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="styles.css" />
</head>
<body>
    <form id="form1" runat="server">
        
        <h1>Premijos</h1>             
            <div>
                <asp:ValidationSummary ID="Summ" runat="server" CssClass="Summ" />
                <br />
                Įkelti darbuotojų sąrašą:<br />
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:RequiredFieldValidator ID="Val1" runat="server" ControlToValidate="FileUpload1" ErrorMessage="Prašome įkelti failą!" CssClass="val1"></asp:RequiredFieldValidator>
                <br />
                <br />
                Įkelti premijų sąrašą:<br />
                <asp:FileUpload ID="FileUpload2" runat="server" />
                <asp:RequiredFieldValidator ID="Val2" runat="server" ControlToValidate="FileUpload2" ErrorMessage="Prašome įkelti failą!" CssClass="val2"></asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:Button ID="Upload1" runat="server" Text="Įkelti failus ir susikaičiuoti" OnClick="Upload1_Click" />
                <br />
                <br />
                <asp:Table ID="PayoutsPerTheme" runat="server"></asp:Table>
                <br />
                <asp:Table ID="DataFile1" runat="server"></asp:Table>
                <br />
                <asp:Table ID="DataFile2" runat="server"></asp:Table>
                <br />
                Premijų skaičiavimo rezultatai:<br />
                <asp:Table ID="Results" runat="server">
                </asp:Table>
                <br />
                Darbuotojai uždirbę mažiau nei premijų vidurkis:<br />
                <asp:Table ID="LessAvg" runat="server">
                </asp:Table>
                Išrinkimas pagal temą:<br />
                <br />
                Pasirinkite temą: <br />
                <asp:TextBox ID="ThemeSelection" runat="server"></asp:TextBox>
                <br />
                <asp:Table ID="PickOut" runat="server">
                </asp:Table>
                <br />
                <br />
                <asp:Button ID="Pick" runat="server" OnClick="Pick_Click" Text="Išrinkti" />
            </div>
    </form>
</body>
</html>

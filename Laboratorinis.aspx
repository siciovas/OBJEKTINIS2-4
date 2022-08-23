<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Laboratorinis.aspx.cs" Inherits="LD4.Polimorfizmas.Laboratorinis" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="StyleSheet.css">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="LD4. Polimorfizmas"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="U4_11. Juvelyrikos parduotuvė."></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Show expensive juvelries!" />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label>
        <br />
        <br />
        <asp:Table ID="Table1" runat="server" GridLines="Both">
        </asp:Table>
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Unique juvelries!" />
        <br />
        <asp:Table ID="Table2" runat="server" GridLines="Both">
        </asp:Table>
        <br />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Cheaper than 300!" />
        <br />
        <asp:Table ID="Table3" runat="server" GridLines="Both">
        </asp:Table>
        <br />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Most expensive juvelries!" />
        <br />
        <asp:Table ID="Table4" runat="server" GridLines="Both">
        </asp:Table>
    </form>
</body>
</html>

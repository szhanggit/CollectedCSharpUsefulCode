<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetAreaPostOffice.aspx.cs" Inherits="GetPostOfficeNameByPinCode.GetAreaPostOffice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblPinCode" Text="Area Pin Code : " runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPinCode"  runat="server" Width="200" MaxLength="6" onkeypress='return event.charCode >= 48 && event.charCode <= 57'></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnSearch" Text="Search" runat="server" OnClick="btnSearch_Click" Enabled="true" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <asp:Label ID="lblMessage" Text="" runat="server"></asp:Label>
                    </td>
                </tr>

            </table>
        </div>
        <div>
            <asp:GridView ID="grdAreaPostOffice" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManageAllowances.aspx.cs" Inherits="EMS.ManageAllowances" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1 style="color:deeppink;">Manage Allowances</h1>
    <hr />
    <table ID="Table1" runat="server">
        <tr>
            <td>
                 <asp:Label ID="Employee" runat="server" Text="Employee:    "></asp:Label>
            </td>       
            <td>
                <asp:TextBox ID="EmployeeNameValue" runat="server"></asp:TextBox>
            
            </td>     
        </tr>
        <tr>
            <td>

            </td>
            <td>

            </td>
        </tr>
        <tr>
            <td>
                 <asp:Label ID="JobTitle" runat="server" Text="Job Title:    "></asp:Label>
            </td>       
            <td>
                <asp:DropDownList ID="JobTitleValue" runat="server" Height="24px" Width="161px"  ></asp:DropDownList>
            </td>     
        </tr>
        <tr>
            <td>

            </td>
            <td>

            </td>
        </tr>
        <tr>
            <td>
                 <asp:Label ID="Allowances" runat="server" Text=" Allowances:       "></asp:Label>
            </td>       
            <td>
                <asp:DropDownList ID="AllowancesValue" runat="server" Height="34px"  >
                    <asp:ListItem Text="Travel" Value="Travel"></asp:ListItem>
                    <asp:ListItem Text="House Rent" Value="House Rent"></asp:ListItem>
                    <asp:ListItem Text="Medical" Value="Medical"></asp:ListItem>
                    <asp:ListItem Text="Office Expense" Value="Office Expense"></asp:ListItem>
                </asp:DropDownList>
            </td>     
        </tr>
        <tr>
            <td>

            </td>
            <td>

            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="AllowanceAmount" runat="server" Text=" Allowance Amount:       "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="AllowanceAmountValue" runat="server" Height="28px" Width="107px"></asp:TextBox>
            </td>
        </tr>
    </table>
     

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Add" runat="server" Text="Add" Width="75px" Height="28px" OnClick="Add_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Delete" runat="server" Text="Delete" Width="75px" Height="28px" />
    <br />
    <br />
</asp:Content>


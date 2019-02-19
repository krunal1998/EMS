<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="GeneratePayslip.aspx.cs" Inherits="EMS.GeneratePayslip" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 33px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="color:deeppink;">Generate Payslip</h1>
    <hr />
    <table ID="Table1" runat="server">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Employee: "></asp:Label>
            </td>    
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" Height="32px" Width="175px"></asp:DropDownList>
            </td>    
        </tr>
        <tr>
            <td class="auto-style1">

            </td>
            <td class="auto-style1">

            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Payment Date: "></asp:Label>
            </td>    
            <td>
                <asp:TextBox ID="TextBox1" runat="server" TextMode="Date" placeholder="from date" Height="23px" Width="153px"></asp:TextBox>
            </td>    
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" Text="Generate" Height="33px" Width="145px" />
    <br />
    <br />
    <br />
</asp:Content>

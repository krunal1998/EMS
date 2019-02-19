<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NewParameter.aspx.cs" Inherits="EMS.NewParameter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 122px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="color:deeppink;">Add New Parameter</h1>
    <hr />  
    <table>
        <tr>
            <td class="auto-style1">Parameter Name</td>
            <td>
            <asp:textbox id="NameTextBox" runat="server" placeholder="Parameter name" /></td>
        </tr>
         <tr>
            <td class="auto-style1">Job Title</td>
            <td>
            <asp:textbox id="Textbox2" runat="server" placeholder="Job Title" /></td>
        </tr>
        <tr>
            <td class="auto-style1">Minimum Rating</td>
            <td>
                <asp:TextBox ID="DateTextBox" runat="server" placeholder="Minimum Rating"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Maximum Rating</td>
            <td>
                 <asp:TextBox ID="TextBox1" runat="server" placeholder="Minimum Rating"></asp:TextBox>
            </td>
        </tr>
    </table>
    <hr />
    <asp:Button ID="Add" runat="server" Text="Add" Width="78px" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Reset" runat="server" Text="Reset" Width="78px" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

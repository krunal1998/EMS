<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="GenerateReview.aspx.cs" Inherits="EMS.GenerateReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1 style="color:deeppink;">Generate Review</h1>
    <hr />

    <table style="padding:10px">
        <tr>
            <td style="width:100px;">Employee</td>
            <td>
            <asp:textbox id="NameTextBox" runat="server" placeholder="Employee name" /></td>
        </tr>
        <tr>
            <td style="width:100px;">From</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" TextMode="Date"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width:100px;">To</td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server" TextMode="Date"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width:100px;">Due Date</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Date"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width:100px;">Parameters</td>
            <td>
            <asp:textbox id="Textbox1" runat="server" placeholder="Parameter name"  /></td>
            <td>    
                <asp:LinkButton ID="Button1" runat="server" Text="Add new" />
            </td>
        </tr>
        <tr><td></td></tr>
        <tr >
            <td>Selected Parameters: </td>
        </tr>
        <tr>
            <td></td>
            <td>1. Punctuality (0-5)</td>
        </tr>
        <tr>
            <td></td>
            <td>2. Involvement (0-10)</td>
        </tr>
    </table>
    <hr/>
    <asp:Button ID="Add" runat="server" Text="Generate" Width="78px" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

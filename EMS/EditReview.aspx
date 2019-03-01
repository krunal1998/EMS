<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSupervisor.Master" AutoEventWireup="true" CodeBehind="EditReview.aspx.cs" Inherits="EMS.EditReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="color:deeppink;">Assess Review</h1>
    <hr />

    <table style="padding:10px">
        <tr>
            <td style="width:100px;">Employee</td> 
            <td>
            <asp:Label id="NameLabel" runat="server" text="Pratik Joshi" /></td>
        </tr>
        <tr>
            <td style="width:100px;">From</td>
            <td>
            <asp:Label id="FromLabel" runat="server" text="10-12-2018" /></td>
            <td>        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>        
            <td style="width:100px;">To:</td>
            <td>
            <asp:Label id="ToLabel" runat="server"  text="10-01-2019"/></td>
        </tr>
        
        
    </table>
    <hr/>
    <h3 style="color:deeppink">Parameters:</h3>
    <asp:Table ID ="ParametersTable" runat="server" CellPadding="10" GridLines="Both">
        <asp:TableRow>
            <asp:TableHeaderCell>Parameter</asp:TableHeaderCell>
            <asp:TableHeaderCell>Rating</asp:TableHeaderCell>
            <asp:TableHeaderCell>Comment</asp:TableHeaderCell>
        </asp:TableRow>
        <asp:TableRow></asp:TableRow>
    </asp:Table>
    
    <hr/>
    <asp:Button ID="Save" runat="server" Text="Save" Width="78px" OnClick="Save_Click" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

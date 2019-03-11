<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSupervisor.Master" AutoEventWireup="true" CodeBehind="CompletedReviews.aspx.cs" Inherits="EMS.CompletedReviews" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
       
         .CompletionList
        {
            background-color: #fff;
            margin-top: 0px;
            padding: 1px 0px 1px 0px;
            
        }
        .CompletionListItem
        {
            background-color: #3498db;
            margin: 0px;
            padding: 2px;
            color: #fff;
            border:1px solid black;

        }
        .CompletionListItemHighLight
        {   background-color: #34495e;
            margin: 0px;
            padding: 2px;
            color:#fff;

        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <h1 style="color:deeppink;">Completed Reviews</h1>
    <hr />
    <br />
    <table>
        <tr>
            <td >Employee Name</td>
            <td >
                <asp:TextBox ID="EnameTextBox" runat="server" placeholder="Type for hint"></asp:TextBox>
            </td>
            <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
            <td > Status:</td>
            <td >
                <asp:DropDownList ID="statusddl" runat="server">
                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                    <asp:ListItem Value="Completed" Text="Completed"></asp:ListItem>
                    <asp:ListItem Value="Assessed" Text="Assessed"></asp:ListItem>
                </asp:DropDownList>
            </td>    
        </tr>
        
        <tr>
            <td></td>
        </tr>
        <tr>
            <td style="width:150px">Due Date From:</td>
            <td>
                <asp:TextBox ID="fromdatetb" runat="server" TextMode="Date"></asp:TextBox>
            </td>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
            <td style="width:150px">Due Date To:</td>
            <td>
                <asp:TextBox ID="todatetb" runat="server" TextMode="Date"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="searchbutton" runat="server" Text="Search" OnClick="searchbutton_Click" />
            </td>
        </tr>
    </table>
    &nbsp;
      &nbsp;<cc1:AutoCompleteExtender ID="TextBox1_AutoCompleteExtender" runat="server" DelimiterCharacters=""

            Enabled="True" ServiceMethod="GetEmployeesList" MinimumPrefixLength="1" EnableCaching="false"  FirstRowSelected="true"
            CompletionListItemCssClass="CompletionListItem" CompletionListCssClass="CompletionList" CompletionListHighlightedItemCssClass="CompletionListItemHighLight"

            TargetControlID="EnameTextBox">

        </cc1:AutoCompleteExtender>
    
    <hr />
    <asp:ScriptManager ID="ScriptManager1" runat="server">

    </asp:ScriptManager>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Table ID="Table1" runat="server" GridLines="Both" >
            <asp:TableRow runat="server">
                <asp:TableHeaderCell runat="server" Width="200px">Employee</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server" Width="200px">Duration</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server" Width="200px">Due Date</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server" Width="200px">Status</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server" >Review</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server" Width ="100px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:TableHeaderCell>
                
            </asp:TableRow>

    </asp:Table>
    <asp:Label ID ="noreviewslabel" runat="server" Visible="false">No Completed reviews found!
    </asp:Label>
</asp:Content>

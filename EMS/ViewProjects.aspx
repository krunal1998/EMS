<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSupervisor.Master" AutoEventWireup="true" CodeBehind="ViewProjects.aspx.cs" Inherits="EMS.ViewProjects" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="color:deeppink;">Projects</h1>
    <hr />
    <br />
    <table>
        
        <tr>
            <td style="width:150px;">Project Name</td>
            <td>
                <asp:TextBox ID="ToDateTextBox" runat="server" ></asp:TextBox>
            </td>
        </tr>
        <tr>
             <td style="width:150px;">Status</td>
            <td>
                <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatDirection="Horizontal" CellPadding="2" CellSpacing="10">
                    <asp:ListItem>All</asp:ListItem>
                    <asp:ListItem>Ongoing</asp:ListItem>
                    <asp:ListItem>Completed</asp:ListItem>
                    
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td style="width:150px;">Employee Name</td>
            <td>
                <asp:TextBox ID="EnameTextBox" runat="server" placeholder="Type for hint"></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Search" runat="server" Text="Search" Width="78px" />
    
    <cc1:AutoCompleteExtender ID="TextBox1_AutoCompleteExtender" runat="server" DelimiterCharacters=""

            Enabled="True" ServiceMethod="GetListofCountries" MinimumPrefixLength="1" EnableCaching="false" ServicePath=""
            CompletionListItemCssClass="CompletionListItem" CompletionListCssClass="CompletionList" CompletionListHighlightedItemCssClass="CompletionListItemHighLight"

            TargetControlID="EnameTextBox">

        </cc1:AutoCompleteExtender>
    <asp:ScriptManager ID="ScriptManager1" runat="server">

    </asp:ScriptManager>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
      <br />
    <asp:Table ID="Table1" runat="server" GridLines="Both">
            <asp:TableRow runat="server">
                <asp:TableHeaderCell runat="server">Project Name</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">Employees</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">Start Date</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">Due Date</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">Project Details</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">Status</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:TableHeaderCell>
            </asp:TableRow>

            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Company Website</asp:TableCell>
                <asp:TableCell runat="server">1. Pratik Joshi</asp:TableCell>
                <asp:TableCell runat="server">10-01-2019</asp:TableCell>
                <asp:TableCell runat="server">25-04-2019</asp:TableCell>
                <asp:TableCell runat="server">Creating new UI for the company website</asp:TableCell>
                <asp:TableCell runat="server">Ongoing</asp:TableCell>
                <asp:TableCell runat="server"> <asp:Button runat="server" Text ="Edit"/> </asp:TableCell>
            </asp:TableRow>
    </asp:Table>

    <br />
<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;


</asp:Content>

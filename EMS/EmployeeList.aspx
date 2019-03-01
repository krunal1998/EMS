<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EmployeeList.aspx.cs" Inherits="EMS.EmployeeList" %>
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
        .auto-style1 {
            width: 114px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="color:deeppink;">&nbsp;Employee List</h1>
     <hr />
     <table>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label1" runat="server" Text="Employee Name:"></asp:Label>
               
            </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Width="146px" Height="25px"></asp:TextBox>      
                  <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Select name from list" ControlToValidate="TextBox1" OnServerValidate="CustomValidator1_ServerValidate" ValidationGroup="validationgroup1" ForeColor="Red"></asp:CustomValidator>          
            </td>
        </tr>
         <tr>
             <td class="auto-style1">

             </td>
             <td>

             </td>
         </tr>
    </table>
    <asp:Button ID="DirectView" runat="server" Text="View" Width="78px" ValidationGroup="validationgroup1" OnClick="DirectView_Click" />
    
    <cc1:AutoCompleteExtender ID="TextBox1_AutoCompleteExtender" runat="server" DelimiterCharacters="" 

            Enabled="True" ServiceMethod="GetListofEmployeeName" MinimumPrefixLength="1" EnableCaching="false" ServicePath="" FirstRowSelected="true" 
            CompletionListItemCssClass="CompletionListItem" CompletionListCssClass="CompletionList" CompletionListHighlightedItemCssClass="CompletionListItemHighLight"

            TargetControlID="TextBox1" >

        </cc1:AutoCompleteExtender>
    <asp:ScriptManager ID="ScriptManager1" runat="server">

    </asp:ScriptManager>

    &nbsp;<br />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
      <asp:Table ID="Table2" runat="server" GridLines="Both" Width="689px">
            <asp:TableRow runat="server">
                <asp:TableHeaderCell runat="server">Employee Name</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">Job Title</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">Employee Status</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:TableHeaderCell>
            </asp:TableRow>     
    </asp:Table>
</asp:Content>

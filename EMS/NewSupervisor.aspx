<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NewSupervisor.aspx.cs" Inherits="EMS.NewSupervisor" %>
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
       
        .auto-style4 {
            width: 113px;
        }
      </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css"/>
    <div class="container">
         <h1 style="color:deeppink;">New Supervisor</h1>
         <p style="color:deeppink;">&nbsp;</p>
    <table ID="Table2" runat="server" >
        <tr>
            <td class="auto-style4">
                <asp:Label ID="NewSupervisorName" runat="server" Text="New Supervisor: "></asp:Label>
            </td>    
            <td>
                <asp:TextBox ID="NewSupervisorNameValue" runat="server" Height="24px" Width="172px"></asp:TextBox>
                 <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Select name from list" ControlToValidate="NewSupervisorNameValue" OnServerValidate="CustomValidator1_ServerValidate" ValidationGroup="validationgroup1" ForeColor="Red"></asp:CustomValidator>          

            </td>      
        </tr>
     </table>
        </div>
        <cc1:AutoCompleteExtender ID="NewSupervisorNameValue_AutoCompleteExtender" runat="server" DelimiterCharacters="" 

            Enabled="True" ServiceMethod="GetListofNonSupervisorName" MinimumPrefixLength="1" EnableCaching="false" ServicePath="" FirstRowSelected="true" 
            CompletionListItemCssClass="CompletionListItem" CompletionListCssClass="CompletionList" CompletionListHighlightedItemCssClass="CompletionListItemHighLight"

            TargetControlID="NewSupervisorNameValue" >

        </cc1:AutoCompleteExtender>
    <asp:ScriptManager ID="ScriptManager1" runat="server">

    </asp:ScriptManager>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
        &nbsp;<br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
    <asp:Button ID="Add" runat="server" Text="Add" Width="94px" OnClick="Add_Click" CssClass="btn btn-success" />
           <br />
         <br />
           <br />
</asp:Content>

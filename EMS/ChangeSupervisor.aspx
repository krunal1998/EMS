<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ChangeSupervisor.aspx.cs" Inherits="EMS.Supervisor" %>
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
        .auto-style3 {
            width: 434px;
            height: 94px;
        }
        </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css"/>
    <div class="container">
         <h1 style="color:deeppink;">Change Supervisor</h1>
         <p style="color:deeppink;">&nbsp;</p>
    <table ID="Table2" runat="server" class="auto-style3" >
        <tr>
            <td>
                <asp:Label ID="EmployeeName" runat="server" Text="Employee Name: "></asp:Label>
            </td>    
            <td>
                <asp:TextBox ID="EmployeeNameValue" runat="server" Height="24px" Width="172px"></asp:TextBox>
                 <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Select name from list" ControlToValidate="EmployeeNameValue" OnServerValidate="CustomValidator1_ServerValidate" ValidationGroup="validationgroup1" ForeColor="Red"></asp:CustomValidator>          

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
                <asp:Label ID="SupervisorName" runat="server" Text="Supervisor Name: "></asp:Label>
            </td>    
            <td>
                <asp:TextBox ID="SupervisorNameValue" runat="server" Height="24px" Width="172px"></asp:TextBox>
           <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="Select name from list" ControlToValidate="SupervisorNameValue" OnServerValidate="CustomValidator2_ServerValidate" ValidationGroup="validationgroup1" ForeColor="Red"></asp:CustomValidator>                 


            </td>    
        </tr>
     </table>
        <cc1:AutoCompleteExtender ID="EmployeeNameValue_AutoCompleteExtender" runat="server" DelimiterCharacters="" 

            Enabled="True" ServiceMethod="GetListofEmployeeName" MinimumPrefixLength="1" EnableCaching="false" ServicePath="" FirstRowSelected="true" 
            CompletionListItemCssClass="CompletionListItem" CompletionListCssClass="CompletionList" CompletionListHighlightedItemCssClass="CompletionListItemHighLight"

            TargetControlID="EmployeeNameValue" >

        </cc1:AutoCompleteExtender>
    <asp:ScriptManager ID="ScriptManager1" runat="server">

    </asp:ScriptManager>
    
           <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" DelimiterCharacters="" 

            Enabled="True" ServiceMethod="GetListofSupervisorName" MinimumPrefixLength="1" EnableCaching="false" ServicePath="" FirstRowSelected="true" 
            CompletionListItemCssClass="CompletionListItem" CompletionListCssClass="CompletionList" CompletionListHighlightedItemCssClass="CompletionListItemHighLight"

            TargetControlID="SupervisorNameValue" >

        </cc1:AutoCompleteExtender>
  
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
          &nbsp;<br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
    <asp:Button ID="Change" runat="server" Text="Change" Width="94px" OnClick="Change_Click" CssClass="btn btn-success" />
           <br />
         <br />
           <br />
           
</asp:Content>
                                                                                                                                                          
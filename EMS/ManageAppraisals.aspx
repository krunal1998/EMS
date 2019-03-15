<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManageAppraisals.aspx.cs" Inherits="EMS.ManageAppraisals" %>
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
     <h1 style="color:deeppink;">Manage Appraisals</h1>
    <hr />
    <table ID="Table1" runat="server">
        <tr>
            <td>
                <asp:Label ID="Employee" runat="server" Text="Employee: "></asp:Label>
            </td>    
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                 <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Select name from list" ControlToValidate="TextBox1" OnServerValidate="CustomValidator1_ServerValidate" ValidationGroup="validationgroup1" ForeColor="Red"></asp:CustomValidator> 
            </td>      
        </tr>
        <tr>
            <td>

            </td>
            <td>

            </td>
        </tr>
        </table>
     <asp:Button ID="Show" runat="server" Text="Show" Width="78px" ValidationGroup="validationgroup1" OnClick="Show_Click" />
    
      <cc1:AutoCompleteExtender ID="TextBox1_AutoCompleteExtender" runat="server" DelimiterCharacters="" 

            Enabled="True" ServiceMethod="GetListofEmployeeName" MinimumPrefixLength="1" EnableCaching="false" ServicePath="" FirstRowSelected="true" 
            CompletionListItemCssClass="CompletionListItem" CompletionListCssClass="CompletionList" CompletionListHighlightedItemCssClass="CompletionListItemHighLight"

            TargetControlID="TextBox1" >

        </cc1:AutoCompleteExtender>
    <asp:ScriptManager ID="ScriptManager1" runat="server">

    </asp:ScriptManager>  
        
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowEditing="GridView1_RowEditing"  OnRowUpdating="GridView1_RowUpdating" 
        OnRowCancelingEdit="GridView1_RowCancelingEdit" DataKeyNames = "AllowanceId">
        <Columns>
            <asp:BoundField DataField="AllowanceId" ItemStyle-Width="200px"  ItemStyle-HorizontalAlign="Center" ReadOnly="true" Visible="false"/>
            <asp:BoundField DataField="AllowanceName" HeaderText="Allowance Name" ItemStyle-Width="200px" ReadOnly="true" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="AllowanceAmount" HeaderText="Allowance Amount" ItemStyle-Width="200px"                   ReadOnly="true"  ItemStyle-HorizontalAlign="Center" />
            <asp:TemplateField HeaderText="Action">
                <EditItemTemplate>
                    <asp:DropDownList ID="ActionDropDown" runat="server" Width="150px" >
                        <asp:ListItem Text="Increment" Value="Increment"></asp:ListItem>
                        <asp:ListItem Text="Decrement" Value="Decrement"></asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ChangeAmount" HeaderText="Change Amount" ItemStyle-Width="200px"  ItemStyle-HorizontalAlign="Center" />
            <asp:CommandField  ShowEditButton="true" ControlStyle-BorderStyle="Outset" ItemStyle-Width="78px"  ControlStyle-ForeColor="#000000" ItemStyle-HorizontalAlign="Center" />
           
        </Columns>
    </asp:GridView>
    <br />
    <asp:Label ID ="deleteerrorlabel" runat="server" ForeColor="Red" Visible="false"></asp:Label>
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Save" runat="server" Text="Save" Width="66px" />
    <br />
</asp:Content>

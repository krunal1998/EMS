<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Attendance.aspx.cs" Inherits="EMS.Attendance" %>
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
    <h1 style="color:deeppink;">Attendance</h1>
    <hr />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="EnameTextBox" runat="server" placeholder="Employee Name"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    Date:&nbsp;&nbsp;<asp:TextBox ID="DateTextBox" runat="server" TextMode="Date" ></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="ViewButton" runat="server" Text="View Attendance" OnClick="ViewButton_Click" ValidationGroup="group1" />    

    &nbsp;&nbsp;
    <asp:Button ID="ResetButton" runat="server"  Text="Reset" OnClick="ResetButton_Click" />

    <cc1:AutoCompleteExtender ID="TextBox1_AutoCompleteExtender" runat="server" DelimiterCharacters="" FirstRowSelected="true"

            Enabled="True" ServiceMethod="GetListofEmployeeName" MinimumPrefixLength="1" EnableCaching="false" ServicePath=""
            CompletionListItemCssClass="CompletionListItem" CompletionListCssClass="CompletionList" CompletionListHighlightedItemCssClass="CompletionListItemHighLight"

            TargetControlID="EnameTextBox">

        </cc1:AutoCompleteExtender>

    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Select name from list" ControlToValidate="EnameTextBox" OnServerValidate="CustomValidator1_ServerValidate" ValidationGroup="group1" ForeColor="Red"></asp:CustomValidator>
    <asp:ScriptManager ID="ScriptManager1" runat="server">

    </asp:ScriptManager>
    <br />
    <hr />


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDataBound="OnRowDataBound" EmptyDataText="No record found">
        <Columns>
            <asp:BoundField DataField="EmployeeId" HeaderText="Employee Id" ItemStyle-Width="200px" ReadOnly="true" ItemStyle-HorizontalAlign="Center"/>
            <asp:BoundField DataField="EmployeeName" HeaderText="Employee Name" ItemStyle-Width="200px" ReadOnly="true" ItemStyle-HorizontalAlign="Center"/>
            <asp:BoundField DataField="Date" HeaderText="Date" ItemStyle-Width="200px" ReadOnly="true" ItemStyle-HorizontalAlign="Center" />
            <asp:TemplateField HeaderText="Attendance">
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server" >
                        <asp:ListItem  Value="8" Text="Present(Full day)" />
                        <asp:ListItem  Value="4" Text="Present(Half day)" />
                        <asp:ListItem  Value="0" Text="Absent" />
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Attendance") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="200px" />
            </asp:TemplateField>
            
            <asp:CommandField ShowEditButton="true" ControlStyle-BorderStyle="Outset" ControlStyle-ForeColor="#000000" ItemStyle-HorizontalAlign="Center" >
<ControlStyle BorderStyle="Outset" ForeColor="Black"></ControlStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:CommandField>

        </Columns>
    </asp:GridView>
</asp:Content>

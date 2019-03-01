<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LeaveList.aspx.cs" Inherits="EMS.LeaveList" %>
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
    <h1 style="color:deeppink;">Leave List</h1>
    <hr />
    <br />
    <table>
        <tr>
            <td style="width:150px;">From</td>
            <td>
                <asp:TextBox ID="FromDateTextBox" runat="server" TextMode="Date" Text="2019-01-01" AutoPostBack="true"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please select From date" ValidationGroup="validationgroup1" ControlToValidate="FromDateTextBox" ForeColor="Red" ></asp:RequiredFieldValidator>
                &nbsp;
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="From Date must be less than To date" Operator="LessThanEqual" ValidationGroup="validationgroup1" Type="Date" ControlToCompare="ToDateTextBox" ControlToValidate="FromDateTextBox" ForeColor="Red"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td style="width:150px;">To</td>
            <td>
                <asp:TextBox ID="ToDateTextBox" runat="server" TextMode="Date" Text="2019-12-31"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please select To Date " ValidationGroup="validationgroup1" ControlToValidate="ToDateTextBox" ForeColor="Red"></asp:RequiredFieldValidator>
                
            </td>
        </tr>
        <tr>
             <td style="width:150px;">Leave Status</td>
            <td>
                <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatDirection="Horizontal" CellPadding="2" CellSpacing="10">
                    <asp:ListItem>Rejected</asp:ListItem>
                    <asp:ListItem>Pending</asp:ListItem>
                    <asp:ListItem>Approved</asp:ListItem>
                    <asp:ListItem>Consumed</asp:ListItem>
                    <asp:ListItem>Cancelled</asp:ListItem>

                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td style="width:150px;">Employee Name</td>
            <td>
                <asp:TextBox ID="EnameTextBox" runat="server" placeholder="Type for hint"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Select name from list" ControlToValidate="EnameTextBox" OnServerValidate="CustomValidator1_ServerValidate" ValidationGroup="validationgroup1" ForeColor="Red"></asp:CustomValidator>
            </td>
        </tr>
    </table> 
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Search" runat="server" Text="Search" Width="78px" ValidationGroup="validationgroup1" OnClick="Search_Click" />
    
    <cc1:AutoCompleteExtender ID="TextBox1_AutoCompleteExtender" runat="server" DelimiterCharacters="" 

            Enabled="True" ServiceMethod="GetListofEmployeeName" MinimumPrefixLength="1" EnableCaching="false" ServicePath="" FirstRowSelected="true" 
            CompletionListItemCssClass="CompletionListItem" CompletionListCssClass="CompletionList" CompletionListHighlightedItemCssClass="CompletionListItemHighLight"

            TargetControlID="EnameTextBox" >

        </cc1:AutoCompleteExtender>
    <asp:ScriptManager ID="ScriptManager1" runat="server">

    </asp:ScriptManager>

    <hr />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="LeaveId" OnRowDataBound="OnRowDataBound" EmptyDataText="No record found">
        <Columns>
            <asp:BoundField DataField="Date" HeaderText="Date" ItemStyle-Width="200px" ReadOnly="true" ItemStyle-HorizontalAlign="Center"/>
            <asp:BoundField DataField="EmployeeName" HeaderText="Employee Name" ItemStyle-Width="200px" ReadOnly="true" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="LeaveType" HeaderText="Leave Type" ItemStyle-Width="200px" ReadOnly="true" ItemStyle-HorizontalAlign="Center"/>
            <asp:BoundField DataField="LeaveBalance" HeaderText="Laeve Balance(Days)" ItemStyle-Width="200px" ReadOnly="true" ItemStyle-HorizontalAlign="Center"/>
            <asp:BoundField DataField="NumberOfDays" HeaderText="Number Of Days" ItemStyle-Width="200px" ReadOnly="true" ItemStyle-HorizontalAlign="Center"/>
            <asp:BoundField DataField="Status" HeaderText="Status" ItemStyle-Width="200px" ReadOnly="true" ItemStyle-HorizontalAlign="Center"/>
            <asp:BoundField DataField="Comment" HeaderText="Comment" ItemStyle-Width="200px" ReadOnly="true" ItemStyle-HorizontalAlign="Center"/>
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:DropDownList ID="ActionDropDown" runat="server" Width="150px" ></asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    

    <br />
<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
    <asp:Button ID="Save" runat="server" Text="Save" Width="78px" OnClick="Save_Click" />

</asp:Content>

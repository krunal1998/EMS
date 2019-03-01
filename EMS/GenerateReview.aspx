<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="GenerateReview.aspx.cs" Inherits="EMS.GenerateReview" %>
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
<h1 style="color:deeppink;">Generate Review</h1>
    <hr />

    <table style="padding:10px">
        <tr>
            <td style="width:100px;">Employee</td>
            <td>
                <asp:textbox id="NameTextBox" runat="server" placeholder="Employee name" OnTextChanged="NameTextBox_TextChanged" />
            </td>
            <td>
                <asp:Button ID ="fetchparametersButton" runat="server" Text="Fetch Parameters" OnClick="fetchparametersButton_Click" ValidationGroup="egroup"/>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Employee Name" ValidationGroup="egroup" ControlToValidate="NameTextBox" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width:100px;">From</td>
            <td>
                <asp:TextBox ID="FromDateTextBox" runat="server" TextMode="Date"></asp:TextBox>
            </td>
            <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="From Date cannot be empty" ValidationGroup="group" ControlToValidate="FromDateTextBox" ForeColor="Red"></asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr>
            <td style="width:100px;">To</td>
            <td>
                <asp:TextBox ID="ToDateTextBox" runat="server" TextMode="Date"></asp:TextBox>
            </td>
            <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="To Date cannot be empty" ValidationGroup="group" ControlToValidate="ToDateTextBox" ForeColor="Red"></asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr>
            <td style="width:100px;">Due Date</td>
            <td>
                <asp:TextBox ID="DueDateTextBox" runat="server" TextMode="Date"></asp:TextBox>
            </td>
            <td>    
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Due Date cannot be empty" ValidationGroup="group" ControlToValidate="DueDateTextBox" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr><td></td></tr>
        
    </table>
    <cc1:AutoCompleteExtender ID="TextBox1_AutoCompleteExtender" runat="server" DelimiterCharacters=""

            Enabled="True" ServiceMethod="GetEmployeesList" MinimumPrefixLength="1" EnableCaching="false"  FirstRowSelected="true"
            CompletionListItemCssClass="CompletionListItem" CompletionListCssClass="CompletionList" CompletionListHighlightedItemCssClass="CompletionListItemHighLight"

            TargetControlID="NameTextBox">

        </cc1:AutoCompleteExtender>
    
    
    <asp:ScriptManager ID="ScriptManager1" runat="server">

    </asp:ScriptManager>

    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="From Date must be less than To date" Operator="LessThanEqual" Type="Date" ControlToCompare="ToDateTextBox"  ValidationGroup="group" ControlToValidate="FromDateTextBox" ForeColor="Red"></asp:CompareValidator><br />
    <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Due date cannot be a past date" Operator="GreaterThanEqual" Type="Date" ValueToCompare="<%# DateTime.Today.ToShortDateString() %>"  ValidationGroup="group" ControlToValidate="DueDateTextBox" ForeColor="Red" ></asp:CompareValidator><br />
    <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="Due date must be greater than to date" Operator="GreaterThanEqual" Type="Date" ControlToCompare="ToDateTextBox"  ValidationGroup="group" ControlToValidate="DueDateTextBox" ForeColor="Red"></asp:CompareValidator><br />
    <asp:Label ID ="employeeError" Text="Select Employee and fetch job parameters first!" runat ="server" Visible="false" ForeColor="Red"></asp:Label>
    <br />
    <br/>
    
    <asp:Label ID="JobTitleLabel" runat="server"></asp:Label>
    <asp:Table ID ="SelectedParametersTable" runat="server" >
       
    </asp:Table>
    <asp:LinkButton ID="manageparameters" runat="server" Text="Manage Parameters..." Visible="false" OnClick="manageparameters_Click"/>
    <hr/>
    <asp:Button ID="Add" runat="server" Text="Generate" Width="78px" OnClick="Add_Click" ValidationGroup="group" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

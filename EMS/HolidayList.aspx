<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="HolidayList.aspx.cs" Inherits="EMS.HolidayList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="color:deeppink;">Holiday List</h1>
    <hr />
    <table>
        <tr>
            <td style="width:100px;">From</td>
            <td>
                <asp:TextBox ID="FromDateTextBox" runat="server" TextMode="Date"></asp:TextBox>
            </td>
            <td>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="From Date must be less than To date" Operator="LessThanEqual" Type="Date" ControlToCompare="ToDateTextBox"  ValidationGroup="group" ControlToValidate="FromDateTextBox" ForeColor="Red"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td style="width:100px;">To</td>
            <td>
                <asp:TextBox ID="ToDateTextBox" runat="server" TextMode="Date"></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />
    <asp:Button ID="Search" runat="server" Text="Search" Width="78px" ValidationGroup="group" OnClick="Search_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Reset" runat="server" Text="Reset" Width="78px" OnClick="Reset_Click" />
    <br />
    <hr />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
        <Columns>
            <asp:TemplateField>
        <ItemTemplate>
            <asp:CheckBox ID="HolidaySelector" runat="server" />
        </ItemTemplate>
    </asp:TemplateField>
            <asp:BoundField DataField="HolidayName" HeaderText="Holiday Name" ItemStyle-Width="200px" />
            <asp:BoundField DataField="HolidayDate" HeaderText="Holiday Date" ItemStyle-Width="200px" />
            <asp:BoundField DataField="WorkingHours" HeaderText="Working Hours" ItemStyle-Width="200px" />
            <asp:CommandField ShowEditButton="true"  />
        </Columns>
    </asp:GridView>
    <br />

    <asp:Button ID="DeleteButton" runat="server" Text="Delete" Width="78px" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="AddButton" runat="server" Text="Add New" Width="78px" OnClick="AddButton_Click" />
    
</asp:Content>

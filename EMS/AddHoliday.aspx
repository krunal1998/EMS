<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddHoliday.aspx.cs" Inherits="EMS.AddHoliday" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="color:deeppink;">Add Holiday</h1>
    <hr />  
    <table>
        <tr>
            <td style="width:100px;">Holiday Name</td>
            <td>
            <asp:textbox id="NameTextBox" runat="server" placeholder="holiday name" /></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Holiday Name" ValidationGroup="validationgroup" ControlToValidate="NameTextBox" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width:100px;">Date</td>
            <td>
                <asp:TextBox ID="DateTextBox" runat="server" TextMode="Date"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="select Holiday Date" ValidationGroup="validationgroup" ControlToValidate="DateTextBox" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width:100px;">Work Shift</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem  Value="4" Text="Half day" Selected="True" />
                    <asp:ListItem  Value="0" Text="Non-working day" />
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <asp:CheckBox ID="CheckBox1" runat="server" Text="Repeated Annually" Checked="true"/>
    <hr />
    <asp:Button ID="Add" runat="server" Text="Add" Width="78px" ValidationGroup="validationgroup" OnClick="Add_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Reset" runat="server" Text="Reset" Width="78px" OnClick="Reset_Click" />
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

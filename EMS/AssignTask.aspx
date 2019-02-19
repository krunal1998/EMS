<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSupervisor.Master" AutoEventWireup="true" CodeBehind="AssignTask.aspx.cs" Inherits="EMS.AssignTask" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="color:deeppink;">Edit Task</h1>
    <hr />

    <table style="padding:10px">
        <tr>
            <td style="width:100px;">Task Name</td>
            <td>
            <asp:textbox id="NameTextBox" runat="server" placeholder="Task name" /></td>
        </tr>
        <tr>
            <td style="width:100px;">Employee</td>
            <td>
            <asp:textbox id="Textbox3" runat="server" placeholder="Employee name" /></td>
        </tr>
        <tr>
            <td style="width:100px;">Project</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem  Value="4" Text="Company Website"/>
                    <asp:ListItem  Value="0" Text="Project2" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width:100px;">Assign Date</td>
            <td>
                <asp:TextBox ID="DateTextBox" runat="server" TextMode="Date"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width:100px;">Due Date</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Date"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width:100px;">Task Details</td>
            <td>
            <asp:textbox id="Textbox1" runat="server" placeholder="Task Details" TextMode="MultiLine" Height="39px" /></td>
        </tr>
         <tr>
            <td style="width:100px;">Status</td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server">
                    <asp:ListItem  Value="4" Text="Ongoing"/>
                    <asp:ListItem  Value="0" Text="Project2" />
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <hr/>
    <asp:Button ID="Add" runat="server" Text="Save" Width="78px" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

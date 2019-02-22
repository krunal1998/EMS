<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="WorkWeek.aspx.cs" Inherits="EMS.WorkWeek" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="color:deeppink;">Work Week Durations</h1>
    <hr />
    <table>
        <tr>
            <td style="width:100px;color:dodgerblue;">Monday </td>
            <td><asp:DropDownList ID="DropDownList1" runat="server" Enabled="false">
                    <asp:ListItem  Value="8" Text="Full day" Selected="True"/>
                    <asp:ListItem  Value="4" Text="Half day" />
                    <asp:ListItem  Value="0" Text="Non-working day" />
                </asp:DropDownList> </td>
        </tr>
        <tr>
            <td style="width:100px;color:dodgerblue;">Tuesday </td>
            <td><asp:DropDownList ID="DropDownList2" runat="server" Enabled="false" >
                    <asp:ListItem  Value="8" Text="Full day" Selected="True"/>
                    <asp:ListItem  Value="4" Text="Half day" />
                    <asp:ListItem  Value="0" Text="Non-working day" />
                </asp:DropDownList> </td>
        </tr>
        <tr>
            <td style="width:100px;color:dodgerblue;">Wednesday </td>
            <td><asp:DropDownList ID="DropDownList3" runat="server" Enabled="false">
                    <asp:ListItem  Value="8" Text="Full day" Selected="True"/>
                    <asp:ListItem  Value="4" Text="Half day" />
                    <asp:ListItem  Value="0" Text="Non-working day" />
                </asp:DropDownList> </td>
        </tr>
        <tr>
            <td style="width:100px;color:dodgerblue;">Thursday </td>
            <td><asp:DropDownList ID="DropDownList4" runat="server" Enabled="false">
                    <asp:ListItem  Value="8" Text="Full day" Selected="True"/>
                    <asp:ListItem  Value="4" Text="Half day" />
                    <asp:ListItem  Value="0" Text="Non-working day" />
                </asp:DropDownList> </td>
        </tr>
        <tr>
            <td style="width:100px;color:dodgerblue;">Friday </td>
            <td><asp:DropDownList ID="DropDownList5" runat="server" Enabled="false">
                    <asp:ListItem  Value="8" Text="Full day" Selected="True" />
                    <asp:ListItem  Value="4" Text="Half day" />
                    <asp:ListItem  Value="0" Text="Non-working day" />
                </asp:DropDownList> </td>
        </tr>
        <tr>
            <td style="width:100px;color:dodgerblue;">Saturday </td>
            <td><asp:DropDownList ID="DropDownList6" runat="server" Enabled="false">
                    <asp:ListItem  Value="8" Text="Full day"  Selected="True"/>
                    <asp:ListItem  Value="4" Text="Half day" />
                    <asp:ListItem  Value="0" Text="Non-working day"/>
                </asp:DropDownList> </td>
        </tr>
        <tr>
            <td style="width:100px;color:dodgerblue;">Sunday </td>
            <td><asp:DropDownList ID="DropDownList7" runat="server" Enabled="false">
                    <asp:ListItem  Value="8" Text="Full day" Selected="True"/>
                    <asp:ListItem  Value="4" Text="Half day" />
                    <asp:ListItem  Value="0" Text="Non-working day" />
                </asp:DropDownList> </td>
        </tr>
    </table>
    <hr />
    <asp:Button ID="EditButton" runat="server" Text="Edit" Width="78px" OnClick="EditButton_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="UpdateButton" runat="server" Text="Update" style="margin-left: 0px" Width="78px" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

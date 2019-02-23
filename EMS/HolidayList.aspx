<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="HolidayList.aspx.cs" Inherits="EMS.HolidayList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="color:deeppink;">Holiday List</h1>
    <hr />
    Add new holiday:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="AddButton" runat="server" Text="Add New" Width="78px" OnClick="AddButton_Click" />
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
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDataBound="OnRowDataBound">
        <Columns>
            <asp:TemplateField>
        <ItemTemplate>
            <asp:CheckBox ID="HolidaySelector" runat="server" />
        </ItemTemplate>
    </asp:TemplateField>
            <asp:BoundField DataField="HolidayName" HeaderText="Holiday Name" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
            </asp:BoundField>
            <asp:TemplateField HeaderText="Holiday Date">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("HolidayDate") %>' TextMode="Date"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("HolidayDate") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="200px" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Working Hours">
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server" >
                        <asp:ListItem  Value="4" Text="Half day" />
                        <asp:ListItem  Value="0" Text="Non-working day" />
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("WorkingHours") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Repeate Annually">
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownList2" runat="server" >
                        <asp:ListItem  Value="1" Text="Yes" />
                        <asp:ListItem  Value="0" Text="No" />
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("RepeatedAnnually") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="200px" />
            </asp:TemplateField>
            
            <asp:CommandField ShowEditButton="true" ControlStyle-BorderStyle="Outset" ControlStyle-ForeColor="#000000" ItemStyle-HorizontalAlign="Center" >
<ControlStyle BorderStyle="Outset" ForeColor="Black"></ControlStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:CommandField>
        </Columns>
    </asp:GridView>
    <br />

    <asp:Button ID="DeleteButton" runat="server" Text="Delete" Width="78px" OnClick="DeleteButton_Click" />
    
    
</asp:Content>

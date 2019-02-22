<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LeaveAllocation.aspx.cs" Inherits="EMS.LeaveAllocation" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 155px;
            height: 30px;
        }
        .auto-style2 {
            width: 115px;
            height: 30px;
        }
        .auto-style3 {
            width: 100px;
            height: 30px;
        }
        .auto-style4 {
            height: 30px;
        }
        .auto-style5 {
            width: 200px;
            height: 30px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="color:deeppink;">Leave Allocation</h1>
    <hr />
    <br />
    <table >
        <tr >
            <td class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Job Title:</td>
            <td class="auto-style4"><asp:DropDownList ID="DropDownList1" runat="server" >
                    <asp:ListItem  Value="0" Text="Select Job Title" />
                </asp:DropDownList>
            </td>
            <td class="auto-style1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Leave Type:</td>
            <td class="auto-style4"><asp:DropDownList ID="DropDownList2" runat="server" >
                    <asp:ListItem  Value="0" Text="Select Leave Type" />
                </asp:DropDownList>
            </td>
            <td class="auto-style5">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Number of days: </td>
            <td class="auto-style4">
                <asp:TextBox ID="DaysTextBox" runat="server" placeholder="Type number of days" Height="16px" Width="162px" ></asp:TextBox>
            </td>
            <td class="auto-style4"><asp:Button ID="Add" runat="server" Text="Add" width="78px" ValidationGroup="validationgroup" OnClick="Add_Click"/></td>
            
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Select Job Title" ControlToValidate="DropDownList1" ForeColor="Red" ValidationGroup="validationgroup" InitialValue="0" ></asp:RequiredFieldValidator>
            </td>
            <td></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Select Leave Type" ControlToValidate="DropDownList2" ForeColor="Red" ValidationGroup="validationgroup" InitialValue="0" ></asp:RequiredFieldValidator>
            </td>
            <td></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter number of days" ControlToValidate="DaysTextBox" ForeColor="Red" ValidationGroup="validationgroup" ></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    <hr />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="DropDownList3" runat="server" >
                    <asp:ListItem  Value="0" Text="Select Job Title" />
                </asp:DropDownList>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="DropDownList4" runat="server" >
                    <asp:ListItem  Value="0" Text="Select Leave Type" />
                </asp:DropDownList>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Search" runat="server" Text="Search" width="78px" OnClick="Search_Click"/>
    <br />
     <br />
    <hr />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit">
        <Columns>
            <asp:TemplateField>
        <ItemTemplate>
            <asp:CheckBox ID="Selector" runat="server" />
        </ItemTemplate>
    </asp:TemplateField>
            <asp:BoundField DataField="JobTitle" HeaderText="Job Title" ItemStyle-Width="200px" ReadOnly="true" ItemStyle-HorizontalAlign="Center"/>
            <asp:BoundField DataField="LeaveType" HeaderText="Leave Type" ItemStyle-Width="200px" ReadOnly="true" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="numberOfLeaves" HeaderText="Number Of Leaves" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center"/>
            <asp:CommandField ShowEditButton="true" ControlStyle-BorderStyle="Outset" ControlStyle-ForeColor="#000000" ItemStyle-HorizontalAlign="Center" />
        </Columns>
    </asp:GridView>
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="DeleteButton" runat="server" Text="Delete" Width="78px" OnClick="DeleteButton_Click" />
</asp:Content>

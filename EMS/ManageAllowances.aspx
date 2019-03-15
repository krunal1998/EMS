<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManageAllowances.aspx.cs" Inherits="EMS.ManageAllowances" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 155px;
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
    <h1 style="color:deeppink;">Manage Allowances</h1> 
    <hr />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="DropDownList3" runat="server" >
                    <asp:ListItem  Value="0" Text="Select Job Title" />
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
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowEditing="GridView1_RowEditing"  OnRowUpdating="GridView1_RowUpdating" 
        OnRowCancelingEdit="GridView1_RowCancelingEdit" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" DataKeyNames = "AllowanceId">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="Selector" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="AllowanceId" ItemStyle-Width="200px"  ItemStyle-HorizontalAlign="Center" ReadOnly="true" Visible="false"/>
            <asp:BoundField DataField="AllowanceName" HeaderText="Allowance Name" ItemStyle-Width="200px"  ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="DefaultAmount" HeaderText="Default Amount" ItemStyle-Width="200px"  ItemStyle-HorizontalAlign="Center" />
            <asp:CommandField  ShowEditButton="true" ControlStyle-BorderStyle="Outset" ItemStyle-Width="78px"  ControlStyle-ForeColor="#000000" ItemStyle-HorizontalAlign="Center" />
        </Columns>
    </asp:GridView>
    <asp:Table ID="addallowancestable" runat="server" GridLines="Both" Visible="false">
        <asp:TableRow>
            <asp:TableCell Width="20px">

            </asp:TableCell>
            <asp:TableCell Width="200px" HorizontalAlign="Center">
                <asp:TextBox ID ="newallowancetextbox" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell Width="200px" HorizontalAlign="Center">
                <asp:TextBox ID ="newdefaultamounttextbox" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell Width="78px" HorizontalAlign="Center">
                <asp:Button ID ="addbutton" runat="server" Text="Add"  OnClick="addbutton_Click"  />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    <asp:Label ID ="deleteerrorlabel" runat="server" ForeColor="Red" Visible="false"></asp:Label>
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="DeleteButton" runat="server" Text="Delete" Width="78px" OnClick="DeleteButton_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    <asp:Button ID="AddNewAllowanceButton" runat="server" Text="Add New" Width="78px" OnClick="AddNewAllowanceButton_Click" />
    
</asp:Content>



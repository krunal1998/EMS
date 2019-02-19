<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSupervisor.Master" AutoEventWireup="true" CodeBehind="EmployeeList.aspx.cs" Inherits="EMS.EmployeeList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 124px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="color:deeppink;">&nbsp;Employee List</h1>
     <hr />
     <table>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label1" runat="server" Text="Employee Name:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Width="146px" Height="25px"></asp:TextBox>                
            </td>
        </tr>
         <tr>
             <td>

             </td>
             <td>

             </td>
         </tr>
    </table>
    &nbsp;<br />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Height="106px" Width="632px" >
        <Columns>
            <asp:BoundField DataField="EmployeeName" HeaderText="Employee Name" ItemStyle-Width="200px" />
            <asp:BoundField DataField="EmployeePost" HeaderText="Employee Post" ItemStyle-Width="200px" />
            <asp:BoundField DataField="EmployeeStatus" HeaderText="Employee Status" ItemStyle-Width="200px" />
        </Columns>
    </asp:GridView>
     <br />
     <br />
</asp:Content>

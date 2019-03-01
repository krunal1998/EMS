<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DeleteEmployee.aspx.cs" Inherits="EMS.DeleteEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 209px;
        }
        .auto-style2 {
            height: 44px;
            width: 184px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <h1 style="color:deeppink;">Remove Employee</h1>
    <hr />
     <table ID="Table1" runat="server">
        <tr>
            <td>
                <asp:Label ID="EmployeeName" runat="server" Text="Employee Name: "></asp:Label>
            &nbsp;</td>    
            <td class="auto-style1">
                <asp:DropDownList ID="EmployeeNameValue" runat="server" Height="33px" Width="129px"></asp:DropDownList>
            </td>        
        </tr>
          <tr>
            <td>
                <asp:Label ID="Reason" runat="server" Text="Reason: "></asp:Label>
            </td>    
            <td class="auto-style1">
                <textarea id="ReasonValue" class="auto-style2"></textarea>
            </td>        
        </tr>
       </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Remove" runat="server" Text="Remove" Height="29px" Width="83px" />
    <br />
    <br />
    <br />
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="EMS.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1 style="color:deeppink;">Add Employee</h1>
    <hr />
    <table ID="Table1" runat="server">
        <tr>
            <td>
                <asp:Label ID="FullName" runat="server" Text="Full Name: "></asp:Label>
            </td>    
            <td>
                <asp:TextBox ID="FirstName" runat="server" placeholder="First Name"></asp:TextBox>
            </td>    
            <td>
                <asp:TextBox ID="MiddleName" runat="server" placeholder="Middle Name"></asp:TextBox>
            </td>    
            <td>
                <asp:TextBox ID="LastName" runat="server" placeholder="Last Name"></asp:TextBox>
            </td>    
        </tr>
        <tr>
            <td>
                 <asp:Label ID="EmployeeID" runat="server" Text="Employee ID: "></asp:Label>
            </td>     
            <td>
                 <asp:TextBox ID="EmployeeIDValue" runat="server"></asp:TextBox>
            </td>
        </tr>         
        <tr>
            <td>
                 <asp:Label ID="Supervisor" runat="server" Text="Supervisor: "></asp:Label>
            </td>           
            <td>
                 <asp:DropDownList ID="SupervisorValue" runat="server"  ></asp:DropDownList>
            </td>
        </tr>
    </table>
     <h3 style="color:deeppink;">Pay Structure</h3>
    <hr />
    <table ID="Table2" runat="server">
        <tr>
            <td>
                 <asp:Label ID="Post" runat="server" Text="Post:    "></asp:Label>
            </td>       
            <td>
                 <asp:DropDownList ID="PostValue" runat="server"  ></asp:DropDownList>
            </td>     
        </tr>
        <tr>
            <td>
                 <asp:Label ID="BasicPay" runat="server" Text="Basic Pay:    "></asp:Label>
            </td>       
            <td>
                <asp:TextBox ID="BasicPayValue" runat="server"></asp:TextBox>
            </td>     
        </tr>
        <tr>
            <td>
                 <asp:Label ID="Allowances" runat="server" Text="Allowances:       "></asp:Label>
            </td>       
            <td>
                <asp:CheckBoxList ID="AllowancesValue" runat="server">
                    <asp:ListItem Text="Travel" Value="Travel"></asp:ListItem>
                    <asp:ListItem Text="House Rent" Value="House Rent"></asp:ListItem>
                    <asp:ListItem Text="Medical" Value="Medical"></asp:ListItem>
                    <asp:ListItem Text="Office Expense" Value="Office Expense"></asp:ListItem>
                </asp:CheckBoxList>
            </td>     
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h3 style="color:deeppink;">Login Details</h3>
    <hr />
     <table ID="Table3" runat="server">
        <tr>
            <td>
                 <asp:Label ID="UserName" runat="server" Text="Username:    "></asp:Label>
            </td>       
            <td>
                <asp:TextBox ID="UserNameValue" runat="server"></asp:TextBox>
            </td>     
        </tr>
          <tr>
            <td>
                 <asp:Label ID="Password" runat="server" Text="Password:    "></asp:Label>
            </td>       
            <td>
                <asp:TextBox ID="PasswordValue" runat="server" TextMode="Password"></asp:TextBox>     
            </td>     
        </tr>
          <tr>
            <td>
                 <asp:Label ID="ConfirmPassword" runat="server" Text="Confirm Password:    "></asp:Label>
            </td>       
            <td>
                <asp:TextBox ID="ConfirmPasswordValue" runat="server" TextMode="Password"></asp:TextBox>                      
            </td>     
        </tr>
          <tr>
            <td>
                 <asp:Label ID="Status" runat="server" Text="Status:    "></asp:Label>
            </td>       
            <td>
                 <asp:DropDownList ID="StatusValue" runat="server"  >
                     <asp:ListItem Text="Enabled" Value="Enabled"></asp:ListItem>
                     <asp:ListItem Text="Disabled" Value="Disabled"></asp:ListItem>
                 </asp:DropDownList>               
            </td>     
        </tr>
     </table>
    &nbsp;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Save" runat="server" Text="Save" Width="94px" OnClick="Save_Click" />
</asp:Content>

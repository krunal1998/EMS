<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="EMS.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1 style="color:deeppink;">Add Employee</h1>
    <hr />
    <table ID="Table1" runat="server">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Full Name: "></asp:Label>
            </td>    
            <td>
                <asp:TextBox ID="TextBox1" runat="server" placeholder="First Name"></asp:TextBox>
            </td>    
            <td>
                <asp:TextBox ID="TextBox2" runat="server" placeholder="Middle Name"></asp:TextBox>
            </td>    
            <td>
                <asp:TextBox ID="TextBox3" runat="server" placeholder="Last Name"></asp:TextBox>
            </td>    
        </tr>
        <tr>
            <td>
                 <asp:Label ID="Label2" runat="server" Text="Employee ID: "></asp:Label>
            </td>     
            <td>
                 <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            </td>
        </tr>         
        <tr>
            <td>
                 <asp:Label ID="Label3" runat="server" Text="Supervisor: "></asp:Label>
            </td>           
            <td>
                 <asp:DropDownList ID="DropDownList1" runat="server"  ></asp:DropDownList>
            </td>
        </tr>
    </table>
     <h3 style="color:deeppink;">Pay Structure</h3>
    <hr />
    <table ID="Table2" runat="server">
        <tr>
            <td>
                 <asp:Label ID="Label4" runat="server" Text="Post:    "></asp:Label>
            </td>       
            <td>
                 <asp:DropDownList ID="DropDownList2" runat="server"  ></asp:DropDownList>
            </td>     
        </tr>
        <tr>
            <td>
                 <asp:Label ID="Label5" runat="server" Text="Basic Pay:    "></asp:Label>
            </td>       
            <td>
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            </td>     
        </tr>
        <tr>
            <td>
                 <asp:Label ID="Label6" runat="server" Text="Allowances:       "></asp:Label>
            </td>       
            <td>
                <asp:CheckBoxList ID="CheckBoxList1" runat="server">
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
                 <asp:Label ID="Label7" runat="server" Text="Username:    "></asp:Label>
            </td>       
            <td>
                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            </td>     
        </tr>
          <tr>
            <td>
                 <asp:Label ID="Label8" runat="server" Text="Password:    "></asp:Label>
            </td>       
            <td>
                <asp:TextBox ID="TextBox7" runat="server" TextMode="Password"></asp:TextBox>     
            </td>     
        </tr>
          <tr>
            <td>
                 <asp:Label ID="Label9" runat="server" Text="Confirm Password:    "></asp:Label>
            </td>       
            <td>
                <asp:TextBox ID="TextBox8" runat="server" TextMode="Password"></asp:TextBox>                      
            </td>     
        </tr>
          <tr>
            <td>
                 <asp:Label ID="Label10" runat="server" Text="Status:    "></asp:Label>
            </td>       
            <td>
                 <asp:DropDownList ID="DropDownList3" runat="server"  >
                     <asp:ListItem Text="Enabled" Value="Enabled"></asp:ListItem>
                     <asp:ListItem Text="Disabled" Value="Disabled"></asp:ListItem>
                 </asp:DropDownList>               
            </td>     
        </tr>
     </table>
    &nbsp;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" Text="Save" Width="94px" />
</asp:Content>

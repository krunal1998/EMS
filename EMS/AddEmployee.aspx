<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="EMS.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 231px;
            font-family:'Times New Roman', Times, serif;          
            font-size:large;
        }
        .auto-style2 {
            height: 17px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css"/>
    <div class="container">
     <h1 style="color:deeppink;">Add Employee</h1>
    <hr />
    <table ID="Table1" runat="server" class="auto-style1" >
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
            <td class="auto-style2">

            </td>
            <td class="auto-style2">
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter first name" ControlToValidate="FirstName" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style2">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter middle name" ControlToValidate="MiddleName" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
             <td class="auto-style2">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter last name" ControlToValidate="LastName" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
         <tr>
            <td>
                 <asp:Label ID="DOB" runat="server" Text="Date of Birth:    " ></asp:Label>
            </td>       
            <td>
                <asp:TextBox ID="DOBValue" runat="server" TextMode="Date" Height="33px" ></asp:TextBox>
            </td>     
        </tr>       
         <tr>
            <td>

            </td>
            <td>

            </td>
        </tr>
        <tr>
            <td>
                 <asp:Label ID="JobTitle" runat="server" Text="JobTitle:     " ></asp:Label>
            </td>       
            <td>
                 <asp:DropDownList ID="JobTitleValue" runat="server" Height="34px" Width="149px" AppendDataBoundItems="true">
                     <asp:ListItem Value="0" Text="Select Job Title"></asp:ListItem>
                 </asp:DropDownList>
               
            </td>     
        </tr>
         <tr>
            <td>

            </td>
            <td>

            </td>
        </tr>
         <tr>
            <td>
                 <asp:Label ID="Supervisor" runat="server" Text="Supervisor: " ></asp:Label>
            </td>           
            <td>
                 <asp:DropDownList ID="SupervisorValue" runat="server" Height="29px" Width="149px" AppendDataBoundItems="true" >
                     <asp:ListItem Value="0" Text="Select Supervisor"></asp:ListItem>
                 </asp:DropDownList>
            </td>
        </tr>
     </table>
    </div> 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css"/>
    <div class="container">
    &nbsp;&nbsp;&nbsp;
        <br />
        <asp:Label ID="EmployeeId" runat="server" Visible="false"></asp:Label>
        <br />
        <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Save" runat="server" Text="Save" Width="94px" OnClick="Save_Click" CssClass="btn btn-success" />
           </div>
</asp:Content>

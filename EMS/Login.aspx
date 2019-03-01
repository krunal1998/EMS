<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EMS.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #Table1 {
            height: 99px;
            width: 200px;
         
        }
        #logo {
            height: 100px;
            width: 106px;
        }
        .auto-style1 {
            width: 339px;
            height: 258px;
        }
        .auto-style3 {
            width: 185px;
        }
        .auto-style4 {
            width: 94px;
        }
        .auto-style5 {
            width: 187px;
        }
    </style>
</head>
<body style="height: 768px; width: 1281px; background-color:azure">
    <form id="form1" runat="server">
    <div style="align-content:center">
    
    
        <table id="Table1" runat="server" class="auto-style1">
            <tr>
                <td class="auto-style4">
                    <img id="logo" runat="server" src="Images/Navkar%20Enterprise%20Logo.png" class="auto-style3" />
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    Employee ID:
                </td>
                <td>
                    <asp:TextBox ID="Username" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style5">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter Username " ControlToValidate="Username" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    Password:
                </td>
                <td>
                    <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td class="auto-style5">
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter Password" ControlToValidate="Password" ForeColor="Red" Width="150px"></asp:RequiredFieldValidator>
                </td>
            </tr>
            
        </table>
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="ErrorMessage" runat="server" ForeColor="Red"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="LoginButton" runat="server" Text="Login" Width="105px" OnClick="LoginButton_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       
        </p>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                                       
        </p>
        </div>
    </form>
</body>
</html>

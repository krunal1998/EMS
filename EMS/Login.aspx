<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EMS.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #Table1 {
            height: 99px;
            width: 133px;
         
        }
        #logo {
            height: 100px;
            width: 106px;
        }
        .auto-style1 {
            width: 249px;
            height: 177px;
        }
    </style>
</head>
<body style="height: 768px; width: 1281px; background-color:azure">
    <form id="form1" runat="server">
    <div style="align-content:center">
    
    
        <table id="Table1" runat="server" class="auto-style1">
            <tr>
                <td>
                    <img id="logo" runat="server" src="Images/Navkar%20Enterprise%20Logo.png" />
                </td>
            </tr>
            <tr>
                <td>
                    Employee ID:
                </td>
                <td>
                    <asp:TextBox ID="Username" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Password:
                </td>
                <td>
                    <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            
        </table>
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="ErrorMessage" runat="server" ForeColor="Red"></asp:Label>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="LoginButton" runat="server" Text="Login" Width="105px" OnClick="LoginButton_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       
        </p>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink1" NavigateUrl="#" runat="server">Forgot Password?</asp:HyperLink>
                       
        </p>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                                       
        </p>
        </div>
    </form>
</body>
</html>

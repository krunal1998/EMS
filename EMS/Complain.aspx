<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Complain.aspx.cs" Inherits="EMS.Complain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 490px;
            height: 245px;
        }
        .auto-style2 {
            height: 54px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1 style="color:deeppink;">Complain Info</h1>
    <hr />
      <table ID="Table1" runat="server" class="auto-style1">
        <tr>
            <td>
                <asp:Label ID="ComplainType" runat="server" Text="Complain Type: "></asp:Label>
            </td>    
            <td>
                <asp:Label ID="ComplainTypeValue" runat="server"></asp:Label>
            </td>   
        </tr>
          <tr>
            <td>
                <asp:Label ID="EmployeeName" runat="server" Text="EmployeeName"></asp:Label>
            </td>    
            <td>
                <asp:Label ID="EmployeeNameValue" runat="server"></asp:Label>
            </td>   
        </tr>
        <tr>
            <td>
                 <asp:Label ID="ComplainDescription" runat="server" Text="Complain Description: "></asp:Label>
            </td>     
            <td>
                <asp:Label ID="ComplainDescriptionValue" runat="server"></asp:Label>
            </td>
        </tr>         
        <tr>
            <td>
                 <asp:Label ID="Status" runat="server" Text="Status: "></asp:Label>
            </td>           
            <td>
                <asp:DropDownList ID="StatusValue" runat="server" Height="26px" Width="100px" Enabled="false">
                     <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
                    <asp:ListItem Text="In Process" Value="In Process"></asp:ListItem>
                    <asp:ListItem Text="Solved" Value="Solved"></asp:ListItem>
                </asp:DropDownList>               
            </td>
        </tr>
          <tr>
            <td>
                <asp:Label ID="Feedback" runat="server" Text="Feedback"></asp:Label>
            </td>    
            <td>
                <asp:TextBox ID="FeedbackValue" runat="server" Enabled="false"></asp:TextBox>
            </td>   
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Edit" runat="server" Text="Edit" Height="34px" Width="76px" OnClick="Edit_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Save" runat="server" Text="Save" Height="34px" Width="76px" OnClick="Save_Click" />
    <br />
    <br />
    <br />
</asp:Content>


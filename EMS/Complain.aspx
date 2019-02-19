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
                <asp:Label ID="Label1" runat="server" Text="Complain Type: "></asp:Label>
            </td>    
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" Height="25px" Width="101px">
                     <asp:ListItem Text="" Value=""></asp:ListItem>
                    <asp:ListItem Text="" Value=""></asp:ListItem>
                    <asp:ListItem Text="" Value=""></asp:ListItem>
                    <asp:ListItem Text="" Value=""></asp:ListItem>
                </asp:DropDownList>
            </td>   
        </tr>
        <tr>
            <td>
                 <asp:Label ID="Label2" runat="server" Text="Complain Description: "></asp:Label>
            </td>     
            <td>
                <textarea id="TextArea1" cols="20" class="auto-style2"></textarea>
            </td>
        </tr>         
        <tr>
            <td>
                 <asp:Label ID="Label3" runat="server" Text="Status: "></asp:Label>
            </td>           
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server" Height="26px" Width="100px">
                     <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
                    <asp:ListItem Text="In Process" Value="In Process"></asp:ListItem>
                    <asp:ListItem Text="Solved" Value="Solved"></asp:ListItem>
                </asp:DropDownList>               
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" Text="Edit" Height="34px" Width="76px" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" Text="Save" Height="34px" Width="76px" />
    <br />
    <br />
    <br />
</asp:Content>


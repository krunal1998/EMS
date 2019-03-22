<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ComplainList.aspx.cs" Inherits="EMS.ComplainList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 187px;
        }
        .auto-style2 {
            width: 388px;
            height: 170px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="color:deeppink;">Complain List</h1>
    <hr />
      <table ID="Table1" runat="server" class="auto-style2">
        <tr>
            <td>
                <asp:Label ID="ComplainType" runat="server" Text="Complain Type: "></asp:Label>
            </td>    
            <td class="auto-style1">
                <asp:DropDownList ID="ComplainTypeValue" runat="server" Height="29px" Width="109px">
                    <asp:ListItem Text="None" Value="0"></asp:ListItem>
                     <asp:ListItem Text="Harassment" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Retaliation" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Discrimination" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Theft" Value="4"></asp:ListItem>
                    <asp:ListItem Text="Bullying" Value="5"></asp:ListItem>
                    <asp:ListItem Text="Leave Issues" Value="6"></asp:ListItem>
                    <asp:ListItem Text="Others Issues" Value="7"></asp:ListItem>

                </asp:DropDownList>
            </td>   
        </tr>
       
        <tr>
            <td>
                 <asp:Label ID="Status" runat="server" Text="Status: "></asp:Label>
            </td>           
            <td class="auto-style1">
                <asp:DropDownList ID="StatusValue" runat="server" Height="28px" Width="102px">
                    <asp:ListItem Text="None" Value=""></asp:ListItem>
                     <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
                    <asp:ListItem Text="In Process" Value="In Process"></asp:ListItem>
                    <asp:ListItem Text="Solved" Value="Solved"></asp:ListItem>
                </asp:DropDownList>               
            </td>
        </tr>
    </table>
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
    <asp:Button ID="Filter" runat="server" Text="Filter" OnClick="Filter_Click" Width="80px" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Reset" runat="server" Text="Reset" Width="80px" OnClick="Reset_Click" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Table ID="Table2" runat="server" GridLines="Both">
            <asp:TableRow runat="server">
                <asp:TableHeaderCell runat="server">Complain Type</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">Employee Name</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">Complain Description</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">Complain Status</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">Feedback</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:TableHeaderCell>
            </asp:TableRow>

       
    </asp:Table>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CompletedReviews.aspx.cs" Inherits="EMS.CompletedReviews" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <h1 style="color:deeppink;">Completed Reviews</h1>
    <hr />
    <br />
    <table>
        <tr>
            <td style="width:150px;">Employee Name</td>
            <td>
                <asp:TextBox ID="EnameTextBox" runat="server" placeholder="Type for hint"></asp:TextBox>
            </td>
        </tr>
    </table>
    &nbsp;
    <hr />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Table ID="Table1" runat="server" GridLines="Both" Height="96px" Width="826px">
            <asp:TableRow runat="server">
                <asp:TableHeaderCell runat="server">Employee</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">Start Date</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">End Date</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">Due Date</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">Status</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">Review</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:TableHeaderCell>
                
            </asp:TableRow>

            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Pratik Joshi</asp:TableCell>
                <asp:TableCell runat="server">10-12-2018</asp:TableCell>
                <asp:TableCell runat="server">10-01-2019</asp:TableCell>
                <asp:TableCell runat="server">25-02-2019</asp:TableCell>
                <asp:TableCell runat="server">Completed</asp:TableCell>

                <asp:TableCell runat="server">
                    <asp:Table runat="server" GridLines="Both">
                        <asp:TableRow runat="server">
                            <asp:TableHeaderCell runat="server">Parameters</asp:TableHeaderCell>
                            <asp:TableHeaderCell runat="server">Rating</asp:TableHeaderCell>
                            <asp:TableHeaderCell runat="server">Comment</asp:TableHeaderCell>
                        </asp:TableRow>                         
                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server">Punctuality</asp:TableCell>
                            <asp:TableCell runat="server">60%</asp:TableCell>
                            <asp:TableCell runat="server">Good going</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server">Involvement</asp:TableCell>
                            <asp:TableCell runat="server">90%</asp:TableCell>
                            <asp:TableCell runat="server">Shows good involvement</asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>

                </asp:TableCell>
                <asp:TableCell runat="server"> <asp:Button runat="server" Text ="Edit"/> </asp:TableCell>
            </asp:TableRow>
        
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Jay Joshi</asp:TableCell>
                <asp:TableCell runat="server">10-12-2018</asp:TableCell>
                <asp:TableCell runat="server">10-01-2019</asp:TableCell>
                <asp:TableCell runat="server">25-01-2019</asp:TableCell>
                <asp:TableCell runat="server">Completed</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:Table runat="server" GridLines="Both">
                        <asp:TableRow runat="server">
                            <asp:TableHeaderCell runat="server">Parameters</asp:TableHeaderCell>
                            <asp:TableHeaderCell runat="server">Rating</asp:TableHeaderCell>
                            <asp:TableHeaderCell runat="server">Comment</asp:TableHeaderCell>
                        </asp:TableRow>                         
                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server">Punctuality</asp:TableCell>
                            <asp:TableCell runat="server">80%</asp:TableCell>
                            <asp:TableCell runat="server">Can do better</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server">Involvement</asp:TableCell>
                            <asp:TableCell runat="server">70%</asp:TableCell>
                            <asp:TableCell runat="server">Can do better</asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>

                </asp:TableCell>
                <asp:TableCell runat="server">  </asp:TableCell>
            </asp:TableRow>
    </asp:Table>
</asp:Content>

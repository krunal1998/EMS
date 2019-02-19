<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSupervisor.Master" AutoEventWireup="true" CodeBehind="SupervisorDashboard.aspx.cs" Inherits="EMS.SupervisorDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        &nbsp;<h3><b>&nbsp; Quick Launch</b></h3>
    <br />
    <asp:ImageButton ID="Image2" runat="server" ImageUrl="~/Images/person.jpg" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:ImageButton ID="Image3" runat="server" ImageUrl="~/Images/list.png" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:ImageButton ID="Image4" runat="server" ImageUrl="~/Images/sheet.png" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:ImageButton ID="Image5" runat="server" ImageUrl="~/Images/person.jpg" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:ImageButton ID="Image6" runat="server" ImageUrl="~/Images/list.png" />
    <br />
    &nbsp;
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="#">Assign Leave</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="#">Leave List</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="#">Timesheets</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="#">Assign Task</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="#">Review List</asp:HyperLink>
    <br />
&nbsp;
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
&nbsp;
</asp:Content>

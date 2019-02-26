<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Qualifications.aspx.cs" Inherits="EMS.Qualifications" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     &nbsp;<br />
            <asp:Menu ID="Menu2" runat="server" BackColor="#FFFBD6" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="1.0em" ForeColor="#990000" StaticSubMenuIndent="10px" Orientation="Horizontal">
        <DynamicHoverStyle BackColor="#990000" ForeColor="White" />
        <DynamicMenuItemStyle HorizontalPadding="20px" VerticalPadding="10px" />
        <DynamicMenuStyle BackColor="#FFFBD6" />
        <DynamicSelectedStyle BackColor="#FFCC66" />
        <Items>
           <asp:MenuItem Text="Personal Details" Value=" Personal Details" ></asp:MenuItem>
            <asp:MenuItem Text="Contact Details" Value="Contact Details"></asp:MenuItem>
            <asp:MenuItem Text="Emergency Contacts" Value="Emergency Contacts"></asp:MenuItem>
            <asp:MenuItem Text="Qualifications" Value="Qualifications" Selected="true"></asp:MenuItem>
             <asp:MenuItem Text="Documents" Value="Documents"></asp:MenuItem>
        </Items>
        <StaticHoverStyle BackColor="#990000" ForeColor="White" />
        <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <StaticSelectedStyle BackColor="#FFCC66" />
    </asp:Menu>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <h1 style="color:deeppink;">Education</h1>
    <hr />
    &nbsp;<asp:Table ID="Table1" runat="server" Width="546px" Height="170px" BorderStyle="Double" GridLines="Both">
        <asp:TableHeaderRow ID="TableRow1" runat="server">
             <asp:TableCell runat="server">Degree</asp:TableCell>
                <asp:TableCell runat="server">Institution</asp:TableCell>
                <asp:TableCell runat="server">Start Year</asp:TableCell>
            <asp:TableCell runat="server">End Year</asp:TableCell>
            </asp:TableHeaderRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">B.tech</asp:TableCell>
                <asp:TableCell runat="server">DDU</asp:TableCell>
                <asp:TableCell runat="server">2001</asp:TableCell>
                <asp:TableCell runat="server">2007</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">M.tech</asp:TableCell>
                <asp:TableCell runat="server">IIT Kanpur</asp:TableCell>
                <asp:TableCell runat="server">2007</asp:TableCell>
                <asp:TableCell runat="server">2009</asp:TableCell>
        </asp:TableRow>
    </asp:Table>
      <h1 style="color:deeppink;">Work Experience</h1>
    <hr />
    <asp:Table ID="Table2" runat="server" Width="546px" Height="170px" BorderStyle="Double" GridLines="Both">
        <asp:TableHeaderRow ID="TableHeaderRow1" runat="server">
             <asp:TableCell runat="server">Company Name</asp:TableCell>
                <asp:TableCell runat="server">Job Title</asp:TableCell>
                <asp:TableCell runat="server">Start Date</asp:TableCell>
            <asp:TableCell runat="server">End Date</asp:TableCell>
            </asp:TableHeaderRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">XYZ Solutions</asp:TableCell>
                <asp:TableCell runat="server">Assistant Project Manager</asp:TableCell>
                <asp:TableCell runat="server">07/2011</asp:TableCell>
                <asp:TableCell runat="server">12/2018</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Infosys</asp:TableCell>
                <asp:TableCell runat="server">Web Designer</asp:TableCell>
                <asp:TableCell runat="server">10/2009</asp:TableCell>
                <asp:TableCell runat="server">11/2012</asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>


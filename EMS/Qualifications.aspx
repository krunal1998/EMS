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
           <asp:MenuItem Text="Personal Details" Value=" Personal Details" NavigateUrl="~/PersonalDetails.aspx"></asp:MenuItem>
            <asp:MenuItem Text="Contact Details" Value="Contact Details" NavigateUrl="~/ContactDetails.aspx"></asp:MenuItem>
            <asp:MenuItem Text="Emergency Contacts" Value="Emergency Contacts" NavigateUrl="~/EmergencyContacts.aspx"></asp:MenuItem>
            <asp:MenuItem Text="Qualifications" Value="Qualifications" Selected="true" NavigateUrl="~/Qualifications.aspx"></asp:MenuItem>
             <asp:MenuItem Text="Documents" Value="Documents" NavigateUrl="~/Documents.aspx"></asp:MenuItem>
        </Items>
        <StaticHoverStyle BackColor="#990000" ForeColor="White" />
        <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <StaticSelectedStyle BackColor="#FFCC66" />
    </asp:Menu>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <h1 style="color:deeppink;">Education</h1>
    <hr />
    &nbsp;<asp:Table ID="Table1" runat="server" Width="579px" Height="35px" BorderStyle="Double" GridLines="Both">
        <asp:TableRow runat="server">
             <asp:TableHeaderCell runat="server">Degree</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">Institution</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">Start Date</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">End Date</asp:TableHeaderCell>
            </asp:TableRow>
    </asp:Table>
      <h1 style="color:deeppink;">Work Experience</h1>
    <hr />
    <asp:Table ID="Table2" runat="server" Width="581px" Height="30px" BorderStyle="Double" GridLines="Both">
        <asp:TableRow runat="server">
             <asp:TableHeaderCell runat="server">Company Name</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">Job Title</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">Start Date</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">End Date</asp:TableHeaderCell>
            </asp:TableRow>
    </asp:Table>
</asp:Content>


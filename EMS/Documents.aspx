<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Documents.aspx.cs" Inherits="EMS.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 26px;
            width: 876px;
        }
    </style>

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
             <asp:MenuItem Text="Qualifications" Value="Qualifications" NavigateUrl="~/Qualifications.aspx"></asp:MenuItem>
             <asp:MenuItem Text="Documents" Value="Documents" Selected="true" NavigateUrl="~/Documents.aspx"></asp:MenuItem>
        </Items>
        <StaticHoverStyle BackColor="#990000" ForeColor="White" />
        <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <StaticSelectedStyle BackColor="#FFCC66" />
    </asp:Menu>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

     <h1 style="color:deeppink;">Documents</h1>
     <br />
     &nbsp;&nbsp;
     <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <br />
     <br />
     <asp:Table ID ="table2" runat="server">
     <asp:TableRow>
      <asp:TableCell>       
         <asp:Table ID="Table1" runat="server" GridLines="Both">
         </asp:Table>
      </asp:TableCell>
        <asp:TableCell >
            <asp:Image ID="expandedImage" runat="server" Width ="500" Height="500" Visible="false"/>
        </asp:TableCell>
     </asp:TableRow>    
     </asp:Table>     
     <br />
</asp:Content>

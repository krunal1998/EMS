<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSupervisor.Master" AutoEventWireup="true" CodeBehind="EmergencyContacts.aspx.cs" Inherits="EMS.E_mergencyContacts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 344px;
        }
        .auto-style2 {
            width: 428px;
            height: 180px;
        }
        .auto-style3 {
            width: 244px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Menu ID="Menu2" runat="server" BackColor="#FFFBD6" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="1.0em" ForeColor="#990000" StaticSubMenuIndent="10px" Orientation="Horizontal">
        <DynamicHoverStyle BackColor="#990000" ForeColor="White" />
        <DynamicMenuItemStyle HorizontalPadding="20px" VerticalPadding="2px" />
        <DynamicMenuStyle BackColor="#FFFBD6" />
        <DynamicSelectedStyle BackColor="#FFCC66" />
        <Items>
           <asp:MenuItem Text="Personal Details" Value="Personal Details" NavigateUrl="~/PersonalDetails.aspx" ></asp:MenuItem>
            <asp:MenuItem Text="Contact Details" Value="Contact Details" NavigateUrl="~/ContactDetails.aspx"></asp:MenuItem>
            <asp:MenuItem Text="Emergency Contacts" Value="Emergency Contacts" Selected="true" NavigateUrl="~/EmergencyContacts.aspx"></asp:MenuItem>
             <asp:MenuItem Text="Qualifications" Value="Qualifications" NavigateUrl="~/Qualifications.aspx"></asp:MenuItem>
             <asp:MenuItem Text="Documents" Value="Documents" NavigateUrl="~/Documents.aspx"></asp:MenuItem>
        </Items>
        <StaticHoverStyle BackColor="#990000" ForeColor="White" />
        <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <StaticSelectedStyle BackColor="#FFCC66" />
    </asp:Menu>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <h1 style="color:deeppink;">Emergency Contacts</h1>
     <hr />
                <table class="auto-style2">
                    <tr style="padding-bottom:20px">
                        <td class="auto-style3">
                           <h3><asp:Label ID="Name" runat="server" Text="Name:" ></asp:Label></h3>
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="NameValue" runat="server"></asp:Label>
                        </td>
                    </tr>
        
                     <tr style="padding-bottom:20px">
                        <td class="auto-style3">
                          <h3><asp:Label ID="Relation" runat="server" Text="Relation:"></asp:Label></h3>
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="RelationValue" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="padding-bottom:20px">
                        <td class="auto-style3">
                         <h3><asp:Label ID="TelephoneNo" runat="server" Text="Telephone No.:"></asp:Label></h3> 
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="TelephoneNoValue" runat="server"></asp:Label>
                        </td>
                    </tr>
                     <tr style="padding-bottom:20px">
                        <td class="auto-style3">
                          <h3><asp:Label ID="MobileNo" runat="server" Text="Mobile No.:"></asp:Label></h3> 
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="MobileNoValue" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSupervisor.Master" AutoEventWireup="true" CodeBehind="EmergencyContacts.aspx.cs" Inherits="EMS.E_mergencyContacts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Menu ID="Menu2" runat="server" BackColor="#FFFBD6" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="1.0em" ForeColor="#990000" StaticSubMenuIndent="10px" Orientation="Horizontal">
        <DynamicHoverStyle BackColor="#990000" ForeColor="White" />
        <DynamicMenuItemStyle HorizontalPadding="20px" VerticalPadding="2px" />
        <DynamicMenuStyle BackColor="#FFFBD6" />
        <DynamicSelectedStyle BackColor="#FFCC66" />
        <Items>
           <asp:MenuItem Text="Personal Details" Value="Personal Details" ></asp:MenuItem>
            <asp:MenuItem Text="Contact Details" Value="Contact Details" ></asp:MenuItem>
            <asp:MenuItem Text="Emergency Contacts" Value="Emergency Contacts" Selected="true"></asp:MenuItem>
        </Items>
        <StaticHoverStyle BackColor="#990000" ForeColor="White" />
        <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <StaticSelectedStyle BackColor="#FFCC66" />
    </asp:Menu>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <h1 style="color:deeppink;">Emergency Contacts</h1>
     <hr />
                <table>
                    <tr style="padding-bottom:20px">
                        <td>
                           <h3><asp:Label ID="Label1" runat="server" Text="Name:" ></asp:Label></h3>
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="Label2" runat="server" Text="Chirag Joshi"></asp:Label>
                        </td>
                    </tr>
        
                     <tr style="padding-bottom:20px">
                        <td>
                          <h3><asp:Label ID="Label5" runat="server" Text="Relation:"></asp:Label></h3>
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="Label6" runat="server" Text="Father"></asp:Label>
                        </td>
                    </tr>
                    <tr style="padding-bottom:20px">
                        <td style="padding-bottom:20px">
                         <h3><asp:Label ID="Label7" runat="server" Text="Telephone No.:"></asp:Label></h3> 
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="Label8" runat="server" Text="2546456"></asp:Label>
                        </td>
                    </tr>
                     <tr style="padding-bottom:20px">
                        <td>
                          <h3><asp:Label ID="Label9" runat="server" Text="Mobile No.:"></asp:Label></h3> 
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="Label3" runat="server" Text="8866556644"></asp:Label>
                        </td>
                    </tr>
                </table>
</asp:Content>

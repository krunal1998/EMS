<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSupervisor.Master" AutoEventWireup="true" CodeBehind="ContactDetails.aspx.cs" Inherits="EMS.ContactDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Menu ID="Menu2" runat="server" BackColor="#FFFBD6" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="1.0em" ForeColor="#990000" StaticSubMenuIndent="10px" Orientation="Horizontal">
        <DynamicHoverStyle BackColor="#990000" ForeColor="White" />
        <DynamicMenuItemStyle HorizontalPadding="20px" VerticalPadding="2px" />
        <DynamicMenuStyle BackColor="#FFFBD6" />
        <DynamicSelectedStyle BackColor="#FFCC66" />
        <Items>
           <asp:MenuItem Text="Personal Details" Value="Personal Details" ></asp:MenuItem>
            <asp:MenuItem Text="Contact Details" Value="Contact Details" Selected="true"></asp:MenuItem>
            <asp:MenuItem Text="Emergency Contacts" Value="Emergency Contacts"></asp:MenuItem>
        </Items>
        <StaticHoverStyle BackColor="#990000" ForeColor="White" />
        <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <StaticSelectedStyle BackColor="#FFCC66" />
    </asp:Menu>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1 style="color:deeppink;">Contact Details</h1>
    <hr />
     <table>
        <tr>           
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <table>
                    <tr style="padding-bottom:20px">
                        <td>
                           <h3> <asp:Label ID="Label1" runat="server" Text="Street:" ></asp:Label></h3>
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="Label2" runat="server" Text="44/A,Navkar Society"></asp:Label>
                        </td>
                    </tr>
        
                     <tr style="padding-bottom:20px">
                        <td>
                          <h3>  <asp:Label ID="Label5" runat="server" Text="Landmark:"></asp:Label></h3>
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="Label6" runat="server" Text="Tadwadi"></asp:Label>
                        </td>
                    </tr>
                    <tr style="padding-bottom:20px">
                        <td style="padding-bottom:20px">
                         <h3>  <asp:Label ID="Label7" runat="server" Text="City:"></asp:Label></h3> 
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="Label8" runat="server" Text="Surat"></asp:Label>
                        </td>
                    </tr>
                     <tr style="padding-bottom:20px">
                        <td>
                          <h3>  <asp:Label ID="Label9" runat="server" Text="State:"></asp:Label></h3> 
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="Label3" runat="server" Text="Gujarat"></asp:Label>
                        </td>
                    </tr>
                    <tr style="padding-bottom:20px">
                        <td>
                          <h3>   <asp:Label ID="Label10" runat="server" Text="Pincode:"></asp:Label></h3> 
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="Label11" runat="server" Text="395006"></asp:Label>
                        </td>
                    </tr>
                     <tr style="padding-bottom:20px">
                        <td>
                        <h3>     <asp:Label ID="Label12" runat="server" Text="Country:"></asp:Label></h3> 
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="Label4" runat="server" Text="India"></asp:Label>
                        </td>
                    </tr>
                    <tr style="padding-bottom:20px">
                        <td>
                        <h3>     <asp:Label ID="Label13" runat="server" Text="Telephone No.:"></asp:Label></h3> 
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="Label14" runat="server" Text="2255566"></asp:Label>
                        </td>
                    </tr>
                    <tr style="padding-bottom:20px">
                        <td>
                        <h3>     <asp:Label ID="Label15" runat="server" Text="Mobile No.:"></asp:Label></h3> 
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="Label16" runat="server" Text="9456118812"></asp:Label>
                        </td>
                    </tr>
                    <tr style="padding-bottom:20px">
                        <td>
                        <h3>     <asp:Label ID="Label17" runat="server" Text="Email ID:"></asp:Label></h3> 
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="Label18" runat="server" Text="navkar@gmail.com"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>          
    </table>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSupervisor.Master" AutoEventWireup="true" CodeBehind="PersonalDetails.aspx.cs" Inherits="EMS.PersonalDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 88px;
        }
        .auto-style3 {
            width: 82px;
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
           <asp:MenuItem Text="Personal Details" Value=" Personal Details" Selected="true"></asp:MenuItem>
            <asp:MenuItem Text="Contact Details" Value="Contact Details"></asp:MenuItem>
            <asp:MenuItem Text="Emergency Contacts" Value="Emergency Contacts"></asp:MenuItem>
        </Items>
        <StaticHoverStyle BackColor="#990000" ForeColor="White" />
        <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <StaticSelectedStyle BackColor="#FFCC66" />
    </asp:Menu>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1 style="color:deeppink;">Personal Details</h1>
    <hr />
     <table>
        <tr>           
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <table>
                    <tr style="padding-bottom:10px">
                        <td>
                           <h3> <asp:Label ID="Label1" runat="server" Text="Full Name:" ></asp:Label></h3>
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="Label2" runat="server" Text="Pratik"></asp:Label>
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="Label3" runat="server" Text="Chirag"></asp:Label>
                        </td>
                        <td class="auto-style3">
                            <asp:Label ID="Label4" runat="server" Text="Joshi"></asp:Label>
                        </td>
                    </tr>
        
                     <tr style="padding-bottom:20px">
                        <td>
                          <h3>  <asp:Label ID="Label5" runat="server" Text="Employee ID:"></asp:Label></h3>
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="Label6" runat="server" Text="18pcj12"></asp:Label>
                        </td>
                    </tr>
                    <tr style="padding-bottom:20px">
                        <td style="padding-bottom:20px">
                         <h3>  <asp:Label ID="Label7" runat="server" Text="Date of Birth:"></asp:Label></h3> 
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="Label8" runat="server" Text="1995/08/30"></asp:Label>
                        </td>
                    </tr>
                     <tr style="padding-bottom:20px">
                        <td>
                          <h3>  <asp:Label ID="Label9" runat="server" Text="Gender:"></asp:Label></h3> 
                        </td>
                        <td class="auto-style1">
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                                 <asp:ListItem Text="Male" Value="Male" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr style="padding-bottom:20px">
                        <td>
                          <h3>   <asp:Label ID="Label10" runat="server" Text="Nationality:"></asp:Label></h3> 
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="Label11" runat="server" Text="Indian"></asp:Label>
                        </td>
                    </tr>
                     <tr style="padding-bottom:20px">
                        <td>
                        <h3>     <asp:Label ID="Label12" runat="server" Text="Marital Status:"></asp:Label></h3> 
                        </td>
                        <td class="auto-style1">
                            <asp:DropDownList ID="DropDownList1" runat="server">
                                <asp:ListItem Text="Single" Value ="Single" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Married" Value ="Married"></asp:ListItem>                                  
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>          
    </table>
</asp:Content>

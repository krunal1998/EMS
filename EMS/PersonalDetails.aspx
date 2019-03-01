<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PersonalDetails.aspx.cs" Inherits="EMS.PersonalDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 88px;
        }
        .auto-style3 {
            width: 82px;
        }
        .auto-style4 {
            width: 109px;
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
           <asp:MenuItem Text="Personal Details" Value=" Personal Details" Selected="true" NavigateUrl="~/PersonalDetails.aspx"></asp:MenuItem>
            <asp:MenuItem Text="Contact Details" Value="Contact Details" NavigateUrl="~/ContactDetails.aspx"></asp:MenuItem>
            <asp:MenuItem Text="Emergency Contacts" Value="Emergency Contacts" NavigateUrl="~/EmergencyContacts.aspx"></asp:MenuItem>
             <asp:MenuItem Text="Qualifications" Value="Qualifications" NavigateUrl="~/Qualifications.aspx"></asp:MenuItem>
             <asp:MenuItem Text="Documents" Value="Documents" NavigateUrl="~/Documents.aspx"></asp:MenuItem>
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
                           <h3> <asp:Label ID="FullName" runat="server" Text="Full Name:" ></asp:Label></h3>
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="FirstName" runat="server"></asp:Label>
                        </td>
                        <td class="auto-style4">
                            <asp:Label ID="MiddleName" runat="server"></asp:Label>
                        </td>
                        <td class="auto-style3">
                            <asp:Label ID="LastName" runat="server"></asp:Label>
                        </td>
                    </tr>
        
                     <tr style="padding-bottom:20px">
                        <td>
                          <h3>  <asp:Label ID="EmployeeID" runat="server" Text="Employee ID:"></asp:Label></h3>
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="IDValue" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="padding-bottom:20px">
                        <td>
                         <h3>  <asp:Label ID="DOB" runat="server" Text="Date of Birth:"></asp:Label></h3> 
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="DOBValue" runat="server"></asp:Label>
                        </td>
                    </tr>
                     <tr style="padding-bottom:20px">
                        <td>
                          <h3>  <asp:Label ID="Gender" runat="server" Text="Gender:"></asp:Label></h3> 
                        </td>
                        <td class="auto-style1">
                        <asp:Label ID="GenValue" runat="server"></asp:Label>   
                        </td>
                    </tr>
                    <tr style="padding-bottom:20px">
                        <td>
                          <h3>   <asp:Label ID="Nationality" runat="server" Text="Nationality:"></asp:Label></h3> 
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="NationalityValue" runat="server"></asp:Label>
                        </td>
                    </tr>
                     <tr style="padding-bottom:20px">
                        <td>
                        <h3>     <asp:Label ID="MaritalStatus" runat="server" Text="Marital Status:"></asp:Label></h3> 
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="MaritalSatusValue" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>          
    </table>
</asp:Content>

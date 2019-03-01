<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ContactDetails.aspx.cs" Inherits="EMS.ContactDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 265px;
            height: 35px;
        }
        .auto-style2 {
            height: 39px;
        }
        .auto-style3 {
            width: 265px;
            height: 39px;
        }
        .auto-style4 {
            height: 51px;
        }
        .auto-style5 {
            width: 265px;
            height: 51px;
        }
        .auto-style6 {
            height: 37px;
        }
        .auto-style7 {
            width: 265px;
            height: 37px;
        }
        .auto-style8 {
            height: 40px;
        }
        .auto-style9 {
            width: 265px;
            height: 40px;
        }
        .auto-style10 {
            height: 41px;
        }
        .auto-style11 {
            width: 265px;
            height: 41px;
        }
        .auto-style12 {
            height: 43px;
        }
        .auto-style13 {
            width: 265px;
            height: 43px;
        }
        .auto-style14 {
            height: 35px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Menu ID="Menu2" runat="server" BackColor="#FFFBD6" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="1.0em" ForeColor="#990000" StaticSubMenuIndent="10px" Orientation="Horizontal">
        <DynamicHoverStyle BackColor="#990000" ForeColor="White" />
        <DynamicMenuItemStyle HorizontalPadding="20px" VerticalPadding="2px" />
        <DynamicMenuStyle BackColor="#FFFBD6" />
        <DynamicSelectedStyle BackColor="#FFCC66" />
        <Items>
           <asp:MenuItem Text="Personal Details" Value="Personal Details" NavigateUrl="~/PersonalDetails.aspx" ></asp:MenuItem>
            <asp:MenuItem Text="Contact Details" Value="Contact Details" Selected="true" NavigateUrl="~/ContactDetails.aspx"></asp:MenuItem>
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
    <h1 style="color:deeppink;">Contact Details</h1>
    <hr />
     <table>
        <tr>           
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <table>
                    <tr style="padding-bottom:20px">
                        <td class="auto-style14">
                           <h3> <asp:Label ID="Street" runat="server" Text="Street:" ></asp:Label></h3>
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="StreetValue" runat="server"></asp:Label>
                        </td>
                    </tr>
        
                     <tr style="padding-bottom:20px">
                        <td class="auto-style10">
                          <h3>  <asp:Label ID="Landmark" runat="server" Text="Landmark:"></asp:Label></h3>
                        </td>
                        <td class="auto-style11">
                            <asp:Label ID="LandmarkValue" runat="server" ></asp:Label>
                        </td>
                    </tr>
                    <tr style="padding-bottom:20px">
                        <td class="auto-style6">
                         <h3>  <asp:Label ID="City" runat="server" Text="City:"></asp:Label></h3> 
                        </td>
                        <td class="auto-style7">
                            <asp:Label ID="CityValue" runat="server"></asp:Label>
                        </td>
                    </tr>
                     <tr style="padding-bottom:20px">
                        <td class="auto-style12">
                          <h3>  <asp:Label ID="State" runat="server" Text="State:"></asp:Label></h3> 
                        </td>
                        <td class="auto-style13">
                            <asp:Label ID="StateValue" runat="server" ></asp:Label>
                        </td>
                    </tr>
                    <tr style="padding-bottom:20px">
                        <td class="auto-style10">
                          <h3>   <asp:Label ID="Pincode" runat="server" Text="Pincode:"></asp:Label></h3> 
                        </td>
                        <td class="auto-style11">
                            <asp:Label ID="PincodeValue" runat="server"></asp:Label>
                        </td>
                    </tr>
                     <tr style="padding-bottom:20px">
                        <td class="auto-style8">
                        <h3>     <asp:Label ID="Country" runat="server" Text="Country:"></asp:Label></h3> 
                        </td>
                        <td class="auto-style9">
                            <asp:Label ID="CountryValue" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="padding-bottom:20px">
                        <td class="auto-style6">
                        <h3>     <asp:Label ID="TelephoneNo" runat="server" Text="Telephone No.:"></asp:Label></h3> 
                        </td>
                        <td class="auto-style7">
                            <asp:Label ID="TelephoneNoValue" runat="server" ></asp:Label>
                        </td>
                    </tr>
                    <tr style="padding-bottom:20px">
                        <td class="auto-style4">
                        <h3>     <asp:Label ID="MobileNo" runat="server" Text="Mobile No.:"></asp:Label></h3> 
                        </td>
                        <td class="auto-style5">
                            <asp:Label ID="MobileNoValue" runat="server" ></asp:Label>
                        </td>
                    </tr>
                    <tr style="padding-bottom:20px">
                        <td class="auto-style2">
                        <h3>     <asp:Label ID="EmailID" runat="server" Text="Email ID:"></asp:Label></h3> 
                        </td>
                        <td class="auto-style3">
                            <asp:Label ID="EmailIDValue" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>          
    </table>
</asp:Content>

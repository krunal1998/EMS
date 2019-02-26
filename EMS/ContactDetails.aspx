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
             <asp:MenuItem Text="Qualifications" Value="Qualifications"></asp:MenuItem>
             <asp:MenuItem Text="Documents" Value="Documents"></asp:MenuItem>
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
                           <h3> <asp:Label ID="Street" runat="server" Text="Street:" ></asp:Label></h3>
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="StreetValue" runat="server"></asp:Label>
                        </td>
                    </tr>
        
                     <tr style="padding-bottom:20px">
                        <td>
                          <h3>  <asp:Label ID="Landmark" runat="server" Text="Landmark:"></asp:Label></h3>
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="LandmarkValue" runat="server" ></asp:Label>
                        </td>
                    </tr>
                    <tr style="padding-bottom:20px">
                        <td style="padding-bottom:20px">
                         <h3>  <asp:Label ID="City" runat="server" Text="City:"></asp:Label></h3> 
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="CityValue" runat="server"></asp:Label>
                        </td>
                    </tr>
                     <tr style="padding-bottom:20px">
                        <td>
                          <h3>  <asp:Label ID="State" runat="server" Text="State:"></asp:Label></h3> 
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="StateValue" runat="server" ></asp:Label>
                        </td>
                    </tr>
                    <tr style="padding-bottom:20px">
                        <td>
                          <h3>   <asp:Label ID="Pincode" runat="server" Text="Pincode:"></asp:Label></h3> 
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="PincodeValue" runat="server"></asp:Label>
                        </td>
                    </tr>
                     <tr style="padding-bottom:20px">
                        <td>
                        <h3>     <asp:Label ID="Country" runat="server" Text="Country:"></asp:Label></h3> 
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="CountryValue" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="padding-bottom:20px">
                        <td>
                        <h3>     <asp:Label ID="TelephoneNo" runat="server" Text="Telephone No.:"></asp:Label></h3> 
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="TelephoneNoValue" runat="server" ></asp:Label>
                        </td>
                    </tr>
                    <tr style="padding-bottom:20px">
                        <td>
                        <h3>     <asp:Label ID="MobileNo" runat="server" Text="Mobile No.:"></asp:Label></h3> 
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="MobileNoValue" runat="server" ></asp:Label>
                        </td>
                    </tr>
                    <tr style="padding-bottom:20px">
                        <td>
                        <h3>     <asp:Label ID="EmailID" runat="server" Text="Email ID:"></asp:Label></h3> 
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="EmailIDValue" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>          
    </table>
</asp:Content>

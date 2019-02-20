<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSupervisor.Master" AutoEventWireup="true" CodeBehind="AssessReview.aspx.cs" Inherits="EMS.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="color:deeppink;">Assess Review</h1>
    <hr />

    <table style="padding:10px">
        <tr>
            <td style="width:100px;">Employee</td> 
            <td>
            <asp:Label id="NameLabel" runat="server" text="Pratik Joshi" /></td>
        </tr>
        <tr>
            <td style="width:100px;">From</td>
            <td>
            <asp:Label id="FromLabel" runat="server" text="10-12-2018" /></td>
        </tr>
        <tr>
            <td style="width:100px;">To</td>
            <td>
            <asp:Label id="ToLabel" runat="server"  text="10-01-2019"/></td>
        </tr>
        <tr>
            <td style="width:100px;">Parameters</td>
            <td>
            <asp:Label id="ParameterLabel1" runat="server"  Text="Punctuality"/></td>
            
            <td>
               <asp:RadioButton ID="RadioButton1" runat="server" Text="1" Groupname="Parameter1"/>
               <asp:RadioButton ID="RadioButton2" runat="server" Text="2" Groupname="Parameter1"/>
                <asp:RadioButton ID="RadioButton3" runat="server" Text="3" Groupname="Parameter1"/>
               <asp:RadioButton ID="RadioButton4" runat="server" Text="4" Groupname="Parameter1"/>
               <asp:RadioButton ID="RadioButton5" runat="server" Text="5" Groupname="Parameter1"/>
                
                 
            </td>
        </tr>
        <tr>
            <td/>
            <td>
            <asp:Label id="Label1" runat="server" Text="Involvement" /></td>
            
            <td>
               <asp:RadioButton ID="RadioButton6" runat="server" Text="1" Groupname="Parameter2"/>
               <asp:RadioButton ID="RadioButton7" runat="server" Text="2" Groupname="Parameter2"/>
                <asp:RadioButton ID="RadioButton8" runat="server" Text="3" Groupname="Parameter2"/>
               <asp:RadioButton ID="RadioButton9" runat="server" Text="4" Groupname="Parameter2"/>
               <asp:RadioButton ID="RadioButton10" runat="server" Text="5" Groupname="Parameter2"/>
                <asp:RadioButton ID="RadioButton11" runat="server" Text="6" Groupname="Parameter2"/>
               <asp:RadioButton ID="RadioButton12" runat="server" Text="7" Groupname="Parameter2"/>
                <asp:RadioButton ID="RadioButton13" runat="server" Text="8" Groupname="Parameter2"/>
               <asp:RadioButton ID="RadioButton14" runat="server" Text="9" Groupname="Parameter2"/>
               <asp:RadioButton ID="RadioButton15" runat="server" Text="10" Groupname="Parameter2"/>
                 
            </td>
        </tr>
    </table>
    <hr/>
    <asp:Button ID="Add" runat="server" Text="Save" Width="78px" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

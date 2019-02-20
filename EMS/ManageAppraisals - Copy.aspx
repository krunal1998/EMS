<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManageAppraisals.aspx.cs" Inherits="EMS.ManageAppraisals" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 44px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1 style="color:deeppink;">Manage Appraisals</h1>
    <hr />
    <table ID="Table1" runat="server">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Employee: "></asp:Label>
            </td>    
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" Height="30px" Width="111px"></asp:DropDownList>
            </td>      
        </tr>
        <tr>
            <td>

            </td>
            <td>

            </td>
        </tr>
        <tr>
            <td>
                 <asp:Label ID="Label2" runat="server" Text="Post: "></asp:Label>
            </td>     
            <td>
                  <asp:DropDownList ID="DropDownList2" runat="server" Height="30px" Width="109px"  ></asp:DropDownList>
            </td>
        </tr>      
         <tr>
            <td>

            </td>
            <td>

            </td>
        </tr>   
        <tr>
            <td>
                 <asp:Label ID="Label3" runat="server" Text="Comment: "></asp:Label>
            </td>           
            <td>
                <textarea id="TextArea1" cols="20" class="auto-style1"></textarea>
            </td>
        </tr>
         <tr>
            <td>

            </td>
            <td>

            </td>
        </tr>
        <tr>
            <td>
                 <asp:Label ID="Label4" runat="server" Text="Appraisal Amount: "></asp:Label>
            </td>           
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Width="169px" Height="30px"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" Text="Save" Height="30px" Width="101px" />
    <br />
    <br />
</asp:Content>

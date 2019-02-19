<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSupervisor.Master" AutoEventWireup="true" CodeBehind="CreateProject.aspx.cs" Inherits="EMS.CreateProject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="color:deeppink;">Edit Project</h1>
    <hr />

    <table style="padding:10px">
        <tr>
            <td style="width:100px;">Project Name</td>
            <td>
            <asp:textbox id="NameTextBox" runat="server" placeholder="Project name" /></td>
        </tr>
        <tr>
            <td style="width:100px;">Add Employee</td>
            <td>
            <asp:textbox id="Textbox3" runat="server" placeholder="Employee name" /></td>
        </tr>
        <tr><td /></tr>
        <tr>
            <td>Employees List:<br/></td>
           <td>
                <asp:Label ID ="EmployeesLabel" runat ="server">1.Pratik Joshi <a href="WebForm1.aspx" style="font-size:small" >Remove</a><br>2. Jay Joshi <a href="WebForm1.aspx" style="font-size:small" >Remove</a> <br> 3. Yash Shah  <a href="WebForm1.aspx" style="font-size:small" >Remove </a></asp:Label> 
          </td>
        </tr>
        <tr>
            <td style="width:100px;">Start Date</td>
            <td ><asp:Label ID ="startDateLabel" runat="server">10-01-2019</asp:Label>            </td>
        </tr>
        <tr>
            <td style="width:100px;">Due Date</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Date"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width:100px;">Project Details</td>
            <td>
            <asp:textbox id="Textbox1" runat="server" placeholder="Project Details" TextMode="MultiLine" Height="39px" /></td>
        </tr>
    </table>
    <hr/>
    <asp:Button ID="Add" runat="server" Text="Save" Width="78px" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

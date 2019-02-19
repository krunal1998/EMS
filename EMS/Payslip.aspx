<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Payslip.aspx.cs" Inherits="EMS.Payslip" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 52px;
        }
        .auto-style2 {
            width: 500px;
            height: 100px;
            margin-right: 0px;
        }
        .auto-style3 {
            width: 118px;
        }
        .auto-style4 {
            width: 116px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <h1 style="color:deeppink;">&nbsp;&nbsp;&nbsp;&nbsp; Payslip</h1>
    <hr />
     <table ID="Table1" runat="server" class="auto-style2" border="1">
        <tr>
            <td class="auto-style4">
                <asp:Label ID="Label1" runat="server" Text="Payment Date: "></asp:Label>
            </td>    
            <td class="auto-style3">
                
            </td>       
        </tr>
        <tr>
            <td class="auto-style4">
                 <asp:Label ID="Label2" runat="server" Text="Employee Name: "></asp:Label>
            </td>     
            <td class="auto-style3">
                
            </td>
        </tr>         
        <tr>
            <td class="auto-style4">
                 <asp:Label ID="Label3" runat="server" Text="Post: "></asp:Label>
            </td>           
            <td class="auto-style3">
               
            </td>
        </tr>
    </table>
    <table border="1">
        <tr>
            <td>
                 <b><asp:Label ID="Label4" runat="server" Text="Earnings"></asp:Label></b>
            </td>
             <td class="auto-style3">
                 
            </td>
             <td>
                 <b><asp:Label ID="Label10" runat="server" Text="Deductions"></asp:Label></b>
            </td>          
             <td class="auto-style3">
                 
                 &nbsp;</td>
        </tr>
        <tr>
            <td>
                 <asp:Label ID="Label5" runat="server" Text="Basic Pay:    "></asp:Label>
            </td>       
            <td class="auto-style3">
                
            </td>  
             <td>
                 <asp:Label ID="Label14" runat="server" Text="Employee PF:  "></asp:Label>
            </td>       
            <td class="auto-style1">
               
            </td>     
        </tr>
        <tr>
            <td>
                 <asp:Label ID="Label6" runat="server" Text=" TA:       "></asp:Label>
            </td>       
            <td class="auto-style3">
                
            </td>     
             <td>
                 <asp:Label ID="Label12" runat="server" Text=" Total Tax:       "></asp:Label>
            </td>       
            <td class="auto-style1">
                
            </td> 
        </tr>
         <tr>
            <td>
                 <asp:Label ID="Label13" runat="server" Text=" HRA:       "></asp:Label>
            </td>       
            <td class="auto-style3">
                
            </td>     
             <td>
                 <asp:Label ID="Label8" runat="server" Text="Absence: "></asp:Label>
            </td>       
            <td class="auto-style1">
                
            </td> 
        </tr>
         <tr>
            <td>
                 <asp:Label ID="Label7" runat="server" Text=" Other Allowances:       "></asp:Label>
            </td>       
            <td class="auto-style3">
                
            </td>     
             <td>
                 
            </td>       
            <td class="auto-style1">
                
            </td> 
        </tr>
          <tr>
            <td>
                 <b><asp:Label ID="Label15" runat="server" Text=" Total Earnings"></asp:Label></b>
            </td>
             <td class="auto-style3">
                 
            </td>
             <td>
                 <b><asp:Label ID="Label16" runat="server" Text="Total Deductions"></asp:Label></b>
            </td>          
             <td>
                 
            </td>
         </tr>
         <tr>
            <td>
                 <b><asp:Label ID="Label17" runat="server" Text="Net Salary"></asp:Label></b>
            </td>
             <td class="auto-style3">
                 
            </td>
         </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" Text="Print" Height="31px" Width="87px" />
    <br />
    <br />
</asp:Content>

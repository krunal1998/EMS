<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="GeneratePayslip.aspx.cs" Inherits="EMS.GeneratePayslip" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script>
        function doPrint()
        {
            var prtContent = document.getElementById('<%= Table2.ClientID %>');
            var prtContent1 = document.getElementById('<%= Table3.ClientID %>');
            prtContent.border = 1; //set no border here
            var WinPrint = window.open('', '', 'left=100,top=100,width=1000,height=1000,toolbar=0,scrollbars=1,status=0,resizable=1');
            WinPrint.document.write("<h1 style=\"text-align:center\" > Payment Slip </h1> <hr/>");
				
            
            WinPrint.document.write(prtContent.outerHTML);
            WinPrint.document.write(prtContent1.outerHTML);
            WinPrint.document.write("<br/><hr/><br/>");
            WinPrint.document.write(prtChart.outerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            //WinPrint.print();
           // WinPrint.close();
        }
</script>
    <style type="text/css">
         .CompletionList
        {
            background-color: #fff;
            margin-top: 0px;
            padding: 1px 0px 1px 0px;
            
        }
        .CompletionListItem
        {
            background-color: #3498db;
            margin: 0px;
            padding: 2px;
            color: #fff;
            border:1px solid black;
        }
        .CompletionListItemHighLight
        {   background-color: #34495e;
            margin: 0px;
            padding: 2px;
            color:#fff;
        }
        .auto-style3 {
            height: 33px;
            width: 160px;
        }
        .auto-style4 {
            height: 33px;
            width: 114px;
        }
        .auto-style5 {
            width: 309px;
        }
        .auto-style6 {
            height: 33px;
            width: 242px;
        }
        .auto-style7 {
            width: 242px;
        }
        .auto-style8 {
            width: 137px;
        }
        .auto-style9 {
            width: 692px;
        }
        .auto-style10 {
            height: 33px;
            width: 41px;
        }
        .auto-style11 {
            width: 150px;
        }
        .auto-style12 {
            width: 115px;
        }
        .auto-style13 {
            height: 33px;
            width: 115px;
        }
        .auto-style14 {
            height: 33px;
            width: 155px;
        }
        .auto-style15 {
            width: 155px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="color:deeppink;">View Payslip</h1>
    <hr />
    <table ID="Table1" runat="server">
        <tr>
            <td class="auto-style12">
                <asp:Label ID="Employee" runat="server" Text="Employee: "></asp:Label>
            </td>    
            <td class="auto-style15">
                <asp:TextBox ID="TextBox1" runat="server" Height="16px" Width="125px"></asp:TextBox>
                  <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Select name from list" ControlToValidate="TextBox1" OnServerValidate="CustomValidator1_ServerValidate" ValidationGroup="validationgroup1" ForeColor="Red"></asp:CustomValidator>
            </td>    
        </tr>
        <tr>
            <td class="auto-style13">

            </td>
            <td class="auto-style14">

            </td>
        </tr>
        <tr>
            <td class="auto-style12">
                <asp:Label ID="PaymentDate" runat="server" Text="Payment Period: "></asp:Label>
            </td>    
            <td class="auto-style15">
                <asp:DropDownList ID="MonthValue" runat="server" Height="38px" Width="121px">
                    <asp:ListItem Value="1" Text="1"></asp:ListItem>
                    <asp:ListItem Value="2" Text="2"></asp:ListItem>
                    <asp:ListItem Value="3" Text="3"></asp:ListItem>
                    <asp:ListItem Value="4" Text="4"></asp:ListItem>
                    <asp:ListItem Value="5" Text="5"></asp:ListItem>
                    <asp:ListItem Value="6" Text="6"></asp:ListItem>
                    <asp:ListItem Value="7" Text="7"></asp:ListItem>
                    <asp:ListItem Value="8" Text="8"></asp:ListItem>
                    <asp:ListItem Value="9" Text="9"></asp:ListItem>
                    <asp:ListItem Value="10" Text="10"></asp:ListItem>
                    <asp:ListItem Value="11" Text="11"></asp:ListItem>
                    <asp:ListItem Value="12" Text="12"></asp:ListItem>

                </asp:DropDownList>
            </td>  
             <td>
                <asp:DropDownList ID="YearValue" runat="server" Height="39px" Width="134px">
                        <asp:ListItem Value="2019" Text="2019"></asp:ListItem>
                    <asp:ListItem Value="2020" Text="2020"></asp:ListItem>
                    <asp:ListItem Value="2021" Text="2021"></asp:ListItem>
                    <asp:ListItem Value="2022" Text="2022"></asp:ListItem>
                    <asp:ListItem Value="2023" Text="2023"></asp:ListItem>
                </asp:DropDownList>
            </td>    
        </tr>
    </table>
     <cc1:AutoCompleteExtender ID="TextBox1_AutoCompleteExtender" runat="server" DelimiterCharacters="" 

            Enabled="True" ServiceMethod="GetListofEmployeeName" MinimumPrefixLength="1" EnableCaching="false" ServicePath="" FirstRowSelected="true" 
            CompletionListItemCssClass="CompletionListItem" CompletionListCssClass="CompletionList" CompletionListHighlightedItemCssClass="CompletionListItemHighLight"

            TargetControlID="TextBox1" >

        </cc1:AutoCompleteExtender>
    <asp:ScriptManager ID="ScriptManager1" runat="server">

    </asp:ScriptManager>
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="ViewPayslip" runat="server" Text="View" Height="33px" Width="145px" OnClick="ViewPayslip_Click" />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <table ID="Table2" runat="server" class="auto-style5" border="1" visible="false">
        <tr>
            <td class="auto-style4">
                <asp:Label ID="Label1" runat="server" Text="Payment Date: "></asp:Label>
            </td>    
            <td class="auto-style10">
                <asp:Label ID="PaymentDateValue" runat="server"></asp:Label>
            </td>       
        </tr>
        <tr>
            <td class="auto-style4">
                 <asp:Label ID="EmployeeName" runat="server" Text="Employee Name: "></asp:Label>
            </td>     
            <td class="auto-style10">
                <asp:Label ID="EmployeeNameValue" runat="server"></asp:Label>
            </td>
        </tr>         
        <tr>
            <td class="auto-style4">
                 <asp:Label ID="Post" runat="server" Text="Job Title: "></asp:Label>
            </td>           
            <td class="auto-style10">
               <asp:Label ID="JobTitleValue" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <table ID="Table3" runat="server" border="1" class="auto-style9" visible="false">
        <tr>
            <td class="auto-style8">
                 <b><asp:Label ID="Earnings" runat="server" Text="Earnings"></asp:Label></b>
            </td>
             <td class="auto-style3">
                 <asp:Label ID="EarningsValue" runat="server"></asp:Label>
            </td>
             <td class="auto-style11">
                 <b><asp:Label ID="Deductions" runat="server" Text="Deductions"></asp:Label></b>
            </td>          
             <td class="auto-style6">
                 <asp:Label ID="DeductionsValue" runat="server"></asp:Label>
                 &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8">
                 <asp:Label ID="BasicPay" runat="server" Text="Basic Pay:    "></asp:Label>
            </td>       
            <td class="auto-style3">
                <asp:Label ID="BasicPayValue" runat="server"></asp:Label>
            </td>  
             <td class="auto-style11">
                 <asp:Label ID="EmployeePF" runat="server" Text="Employee PF:  "></asp:Label>
            </td>       
            <td class="auto-style6">
               <asp:Label ID="EPFValue" runat="server"></asp:Label>
            </td>     
        </tr>
        <tr>
            <td class="auto-style8">
                 <asp:Label ID="TA" runat="server" Text=" TA:       "></asp:Label>
            </td>       
            <td class="auto-style3">
                <asp:Label ID="TAValue" runat="server"></asp:Label>
            </td>     
             <td class="auto-style11">
                 <asp:Label ID="TotalTax" runat="server" Text=" Total Tax:       "></asp:Label>
            </td>       
            <td class="auto-style6">
                <asp:Label ID="TaxValue" runat="server"></asp:Label>
            </td> 
        </tr>
         <tr>
            <td class="auto-style8">
                 <asp:Label ID="HRA" runat="server" Text=" HRA:       "></asp:Label>
            </td>       
            <td class="auto-style3">
                <asp:Label ID="HRAValue" runat="server"></asp:Label>
            </td>     
             <td class="auto-style11">
                 <asp:Label ID="Absence" runat="server" Text="Absence: "></asp:Label>
            </td>       
            <td class="auto-style6">
                <asp:Label ID="AbsenceValue" runat="server"></asp:Label>
            </td> 
        </tr>
         <tr>
            <td class="auto-style8">
                 <asp:Label ID="OtherAllowances" runat="server" Text=" Other Allowances:       "></asp:Label>
            </td>       
            <td class="auto-style3">
                <asp:Label ID="OtherAllowancesValue" runat="server"></asp:Label>
            </td>     
             <td class="auto-style11">
                 <asp:Label ID="Label14" runat="server"></asp:Label>
            </td>       
            <td class="auto-style6">
                <asp:Label ID="Label15" runat="server"></asp:Label>
            </td> 
        </tr>
          <tr>
            <td class="auto-style8">
                 <b><asp:Label ID="TotalEarnings" runat="server" Text=" Total Earnings"></asp:Label></b>
            </td>
             <td class="auto-style3">
                 <asp:Label ID="TotalEarningsValue" runat="server"></asp:Label>
            </td>
             <td class="auto-style11">
                 <b><asp:Label ID="TotalDeductions" runat="server" Text="Total Deductions"></asp:Label></b>
            </td>          
             <td class="auto-style7">
                 <asp:Label ID="TotalDeductionsValue" runat="server"></asp:Label>
            </td>
         </tr>
         <tr>
            <td class="auto-style8">
                 <b><asp:Label ID="NetSalary" runat="server" Text="Net Salary"></asp:Label></b>
            </td>
             <td class="auto-style3">
                 <asp:Label ID="NetSalaryValue" runat="server"></asp:Label>
            </td>
         </tr>
    </table>

   
      <br />
      <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Print" runat="server" Text="Print" Height="31px" Width="87px"  OnClientClick="doPrint()" Visible="false"/>
    <br />
    <br />
    <br />

</asp:Content>

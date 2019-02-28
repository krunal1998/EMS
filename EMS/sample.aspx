<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="sample.aspx.cs" Inherits="EMS.sample" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function doPrint()
        {
            var prtContent = document.getElementById('<%= GridView1.ClientID %>');
            var prtContent1 = document.getElementById('<%= Image1.ClientID %>');
            prtContent.border = 1; //set no border here
            var WinPrint = window.open('','','left=100,top=100,width=1000,height=1000,toolbar=0,scrollbars=1,status=0,resizable=1');
            WinPrint.document.write("<h1> Navkar </h1>");
            WinPrint.document.write(prtContent.outerHTML);
            WinPrint.document.write(prtContent1.outerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            //WinPrint.print();
           // WinPrint.close();
        }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Print" OnClientClick="doPrint()"/>
    <asp:Button ID="Button2" runat="server" Text="pdf" OnClick="Button2_Click"  />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Image ID="Image1" runat="server" src="Images/Navkar%20Enterprise%20Logo.png" Width="376px" />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>

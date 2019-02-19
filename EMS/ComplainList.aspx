<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ComplainList.aspx.cs" Inherits="EMS.ComplainList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 187px;
        }
        .auto-style2 {
            width: 388px;
            height: 170px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="color:deeppink;">Complain List</h1>
    <hr />
      <table ID="Table1" runat="server" class="auto-style2">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Complain Type: "></asp:Label>
            </td>    
            <td class="auto-style1">
                <asp:DropDownList ID="DropDownList1" runat="server" Height="29px" Width="109px">
                    <asp:ListItem Text="None" Value=""></asp:ListItem>
                     <asp:ListItem Text="Harassment" Value=""></asp:ListItem>
                    <asp:ListItem Text="Retaliation" Value=""></asp:ListItem>
                    <asp:ListItem Text="Discrimination" Value=""></asp:ListItem>
                    <asp:ListItem Text="Theft" Value=""></asp:ListItem>
                    <asp:ListItem Text="Bullying" Value=""></asp:ListItem>
                    <asp:ListItem Text="Leave Issues" Value=""></asp:ListItem>
                    <asp:ListItem Text="Others Issues" Value=""></asp:ListItem>

                </asp:DropDownList>
            </td>   
        </tr>
        <tr>
            <td>
                 <asp:Label ID="Label2" runat="server" Text="Complainants Name: "></asp:Label>
            </td>     
            <td class="auto-style1">
                <asp:DropDownList ID="DropDownList3" runat="server" Height="29px">
                    <asp:ListItem Text="None" Value=""></asp:ListItem>
                    <asp:ListItem Text="Pratik Chirag Joshi" Value="Pratik Chirag Joshi"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>         
        <tr>
            <td>
                 <asp:Label ID="Label3" runat="server" Text="Status: "></asp:Label>
            </td>           
            <td class="auto-style1">
                <asp:DropDownList ID="DropDownList2" runat="server" Height="28px" Width="102px">
                    <asp:ListItem Text="None" Value=""></asp:ListItem>
                     <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
                    <asp:ListItem Text="In Process" Value="In Process"></asp:ListItem>
                    <asp:ListItem Text="Solved" Value="Solved"></asp:ListItem>
                </asp:DropDownList>               
            </td>
        </tr>
    </table>
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" Text="Filter" OnClick="Button1_Click" Width="80px" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Height="104px" >
        <Columns>
            <asp:TemplateField>
        <ItemTemplate>
            <asp:CheckBox ID="Selector" runat="server" />
        </ItemTemplate>
    </asp:TemplateField>
            <asp:BoundField DataField="ComplainType" HeaderText="Complain Type" ItemStyle-Width="200px" />
            <asp:BoundField DataField="ComplainantsName" HeaderText="Complainants Name" ItemStyle-Width="200px" />
            <asp:BoundField DataField="ComplainDescription" HeaderText="Complain Description" ItemStyle-Width="200px" />
            <asp:BoundField DataField="ComplainStatus" HeaderText="Complain Status" ItemStyle-Width="200px" />
            <asp:BoundField DataField="Feedback" HeaderText="Feedback" ItemStyle-Width="200px" />
            <asp:CommandField ShowEditButton="true" ControlStyle-BorderStyle="Outset" />
        </Columns>
    </asp:GridView>
     <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="DeleteButton" runat="server" Text="Delete" Width="78px" />
     <br />
</asp:Content>

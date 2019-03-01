<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManageIndividualParameters.aspx.cs" Inherits="EMS.ManageIndividualParameters" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="color:deeppink;">Manage Parameters</h1>
        
    
    <hr />
    <br />
    <br />
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <h3>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Jobtitle: <asp:Label ID="jtlabel" runat="server"></asp:Label></h3> 
     <br />

    <hr />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowEditing="GridView1_RowEditing"  OnRowUpdating="GridView1_RowUpdating" 
        OnRowCancelingEdit="GridView1_RowCancelingEdit" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" DataKeyNames = "ParameterId">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="Selector" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ParameterId" ItemStyle-Width="200px"  ItemStyle-HorizontalAlign="Center" ReadOnly="true" Visible="false"/>
            <asp:BoundField DataField="Parameter" HeaderText="Parameter" ItemStyle-Width="200px"  ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="MinRating" HeaderText="Minimum Rating" ItemStyle-Width="200px"  ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="MaxRating" HeaderText="Maximum Rating" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center"/>
            <asp:CommandField  ShowEditButton="true" ControlStyle-BorderStyle="Outset" ItemStyle-Width="78px"  ControlStyle-ForeColor="#000000" ItemStyle-HorizontalAlign="Center" />
        </Columns>
       
    </asp:GridView>
    <asp:Table ID="addparametertable" runat="server" GridLines="Both" Visible="false">
        <asp:TableRow>
            <asp:TableCell Width="20px">

            </asp:TableCell>
            <asp:TableCell Width="200px" HorizontalAlign="Center">
                <asp:TextBox ID ="newparametertextbox" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell Width="200px" HorizontalAlign="Center">
                <asp:TextBox ID ="newminratingtextbox" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell Width="200px" HorizontalAlign="Center">
                <asp:TextBox ID ="newmaxratingtextbox" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell Width="78px" HorizontalAlign="Center">
                <asp:Button ID ="addbutton" runat="server" Text="Add"  OnClick="addbutton_Click"  />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    <br />
    <asp:Label ID ="deleteerrorlabel" runat="server" ForeColor="Red" Visible="false"></asp:Label>
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="DeleteButton" runat="server" Text="Delete" Width="78px" OnClick="DeleteButton_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    <asp:Button ID="AddNewParameterButton" runat="server" Text="Add New" Width="78px" OnClick="AddNewParameterButton_Click" />
    
    <br />
    <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

    <asp:Button ID ="donebutton" runat="server" Text="Done" Width="78px" OnClick="donebutton_Click"/>
</asp:Content>

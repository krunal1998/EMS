<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="EMS.WebForm1" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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

</style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>



    <asp:Chart ID="Chart1" runat="server" Width="414px" Height="396px" BackColor="Transparent"
            Palette="SemiTransparent"  >
        <Series>
                <asp:Series Name="Education" XValueMember="State" YValueMembers="Education" IsVisibleInLegend="true"
                    ChartType="Line" IsValueShownAsLabel="true" Enabled="false"  >
                </asp:Series>
                <asp:Series Name="Education12" XValueMember="State" YValueMembers="Education" IsVisibleInLegend="true"
                    ChartType="Pie" IsValueShownAsLabel="true" Enabled="true" ChartArea="ChartArea2" >
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1" BackColor="Azure" >
                    <AxisX LineColor="Red">
                        <MajorGrid LineColor="LightGray" />
                    </AxisX>
                    <AxisY LineColor="Yellow">
                        <MajorGrid LineColor="LightGray" />
                    </AxisY>
                    
                </asp:ChartArea>
                <asp:ChartArea Name="ChartArea2" BackColor="Azure"  >
                    <AxisX LineColor="Red">
                        <MajorGrid LineColor="LightGray" />
                    </AxisX>
                    <AxisY LineColor="Yellow">
                        <MajorGrid LineColor="LightGray" />
                    </AxisY>
                    
                </asp:ChartArea>
            </ChartAreas>
            <Legends>
                <asp:Legend>
                </asp:Legend>
            </Legends>
    </asp:Chart>

    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <hr />
    <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>

        <cc1:AutoCompleteExtender ID="TextBox1_AutoCompleteExtender" runat="server" DelimiterCharacters=""

            Enabled="True" ServiceMethod="GetListofCountries" MinimumPrefixLength="1" EnableCaching="false" ServicePath=""
            CompletionListItemCssClass="CompletionListItem" CompletionListCssClass="CompletionList" CompletionListHighlightedItemCssClass="CompletionListItemHighLight"

            TargetControlID="TextBox1">

        </cc1:AutoCompleteExtender>

    <asp:ScriptManager ID="ScriptManager1" runat="server">

    </asp:ScriptManager>

</asp:Content>

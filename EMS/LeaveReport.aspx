<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LeaveReport.aspx.cs" Inherits="EMS.LeaveReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
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
    <h1 style="color:deeppink;">Leave Report</h1>
    <hr />
    <br />
    <table>
        <tr>
            <td >From Date:&nbsp;&nbsp;<asp:TextBox ID="FromDateTextBox" runat="server" TextMode="Date"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
                 To Date:&nbsp;&nbsp;  <asp:TextBox ID="ToDateTextBox" runat="server" TextMode="Date"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="EnameTextBox" runat="server" placeholder="Employee Name"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="LeaveTypeTextBox" runat="server" placeholder="Leave Type"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="JobTitleTextBox" runat="server" placeholder="Job Title"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            
         </tr>   
    </table>

    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

    <asp:Button ID="View" runat="server" Text="View" Width="78px" />
    <br />
    
    <cc1:AutoCompleteExtender ID="TextBox1_AutoCompleteExtender" runat="server" DelimiterCharacters=""

            Enabled="True" ServiceMethod="GetListofEmployeeName" MinimumPrefixLength="1" EnableCaching="false" ServicePath=""
            CompletionListItemCssClass="CompletionListItem" CompletionListCssClass="CompletionList" CompletionListHighlightedItemCssClass="CompletionListItemHighLight"

            TargetControlID="EnameTextBox">

        </cc1:AutoCompleteExtender>&nbsp;&nbsp;
    <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" DelimiterCharacters=""

            Enabled="True" ServiceMethod="GetListofEmployeeName" MinimumPrefixLength="1" EnableCaching="false" ServicePath=""
            CompletionListItemCssClass="CompletionListItem" CompletionListCssClass="CompletionList" CompletionListHighlightedItemCssClass="CompletionListItemHighLight"

            TargetControlID="LeaveTypeTextBox">

        </cc1:AutoCompleteExtender>
    <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" DelimiterCharacters=""

            Enabled="True" ServiceMethod="GetListofEmployeeName" MinimumPrefixLength="1" EnableCaching="false" ServicePath=""
            CompletionListItemCssClass="CompletionListItem" CompletionListCssClass="CompletionList" CompletionListHighlightedItemCssClass="CompletionListItemHighLight"

            TargetControlID="JobTitleTextBox">

        </cc1:AutoCompleteExtender>
    <asp:ScriptManager ID="ScriptManager1" runat="server">

    </asp:ScriptManager>
    <br />
    <hr />
    <br />
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

    <br />
    <hr />
    <br />
    <asp:Chart ID="Chart1" runat="server" Width="700px" Height="396px" BackColor="Transparent"
            Palette="SemiTransparent" >
        <Series>
                <asp:Series Name="Education" XValueMember="State" YValueMembers="Education" IsVisibleInLegend="true"
                    ChartType="Line" IsValueShownAsLabel="true" Enabled="false"  >
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
                
            </ChartAreas>
            <Legends>
                <asp:Legend>
                </asp:Legend>
            </Legends>
    </asp:Chart>
    <asp:Chart ID="Chart2" runat="server" Width="414px" Height="396px" BackColor="Transparent"
            Palette="SemiTransparent">
        <Series>
            <asp:Series Name="Series1" XValueMember="State" YValueMembers="Education" IsVisibleInLegend="true"
                    ChartType="Pie" IsValueShownAsLabel="true" Enabled="true"  >

            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1" BackColor="Azure">
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
    

</asp:Content>

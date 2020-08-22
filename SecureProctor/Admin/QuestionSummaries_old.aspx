<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="QuestionSummaries_old.aspx.cs" Inherits="SecureProctor.Admin.QuestionSummaries_old" %>

<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=8.0.14.507, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminContent" runat="Server">

    <script src="Scripts/jquery-1.8.3.min.js"></script>

    <style>
        .ReportToolbar {
            height: 28px;
            border: 1px solid #4F4F4F;
            background-image: none;
        }

        select {
            padding: 1px 2px;
            margin-left: 15px;
            margin-top: -2px;
            color: #000;
            font-size: 12px;
            border: 1px solid #ccc;
            -moz-border-radius: 3px;
            -webkit-border-radius: 3px;
            border-radius: 3px;
            cursor: pointer;
        }

            select:hover {
                padding: 1px 2px;
                margin-left: 15px;
                margin-top: -2px;
                color: #000;
                font-size: 12px;
                border: 1px solid #ccc;
                -moz-border-radius: 3px;
                -webkit-border-radius: 3px;
                border-radius: 3px;
                cursor: pointer;
            }

        .ReportToolbar input, .ReportToolbar select, .ReportToolbar button {
            font-size: 12px;
            font-family: Verdana;
        }

        .ActiveLink:link {
            color: #000;
            text-decoration: underline;
        }

        .RadGrid_Metro .rgHeader {
            color: #fff !important;
            background: rgba(0, 0, 0, 0.25) !important;
        }

            .RadGrid_Metro .rgHeader a {
                color: #000 !important;
            }

        .RadGrid_Default .rgSelectedRow {
            border-bottom-color: #6C6C6C;
            word-wrap: break-word;
        }

        .RadGrid .item-style {
            padding-top: 0;
            padding-bottom: 0;
            height: 150px;
            vertical-align: middle;
            word-wrap: break-word;
        }
    </style>
    <script type="text/javascript">
         
    </script>
    <div class="container">
        <div class="container_inner">
             <div class="heading_menu">
                   <a href="AdminReports.aspx">Reports</a> <img src="../Images/arrowRight.png" width="18" /> Survey Graphs
                </div>
            <div class="login_new1">
               
                <div class="box-data">
                    <div class="box-data_inner_grid">
                        <div style="height: 25px; margin-top: 10px;">
                            <asp:LinkButton CssClass="FilterMenuItem FilterMenuActiveItem" ForeColor="#ffffff" ID="lnkQuestionSummaries" runat="server" Text="Survey Graphs"  />
                            <asp:LinkButton CssClass="FilterMenuItem " ID="lnkAll" runat="server" Text="Survey Details"  OnClick="lnkAll_Click" />
                            <asp:LinkButton CssClass="FilterMenuItem" ID="lnkIndividual" runat="server" Text="Individual Responses"  OnClick="lnkIndividual_Click" />



                        </div>
                        <div class="divtab">
                            <div style="margin: 0px auto; width: 310px; background: #fcfcfc; color: #000; border-radius: 3px;">
                                <table cellpadding="0" width="100%">
                                    <tr>
                                        <td width="30">

                                            <asp:LinkButton ID="btnleftarrow" runat="server" CssClass="time_left_arrow" OnClick="btnleftarrow_Click" Width="30"></asp:LinkButton>

                                            <td style="width: 30px;">

                                                <telerik:RadDatePicker AutoPostBack="true" DateInput-Display="false" OnSelectedDateChanged="txtFromDate_SelectedDateChanged"
                                                    DateInput-ReadOnly="true" ID="txtFromDate" runat="server" Skin="Web20" Width="30" Calendar-ShowRowHeaders="false">
                                                </telerik:RadDatePicker>
                                            </td>
                                            <td width="80" align="right">
                                                <asp:Label ID="lblfirstdate" runat="server" Text="" ForeColor="Black" Font-Size="14px"></asp:Label></td>
                                            <td width="20" align="center">--</td>
                                            <td width="80" align="left">
                                                <asp:Label ID="lblLastDate" runat="server" Text="" ForeColor="Black" Font-Size="14px"></asp:Label>
                                            </td>


                                            <td width="30">
                                                <%-- <asp:ImageButton ID="btnrightarrow" runat="server" CssClass="time_right_arrow" ImageUrl="#" OnClick="btnrightarrow_Click" />--%>
                                                <asp:LinkButton ID="btnrightarrow" runat="server" CssClass="time_right_arrow" OnClick="btnrightarrow_Click" Width="30"></asp:LinkButton>
                                                <%--  <img src="Images/arrow.png" />--%></td>
                                           
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="Summary">
                                <table width="95%">
                                <tr>
                   <td align="right"><strong><asp:Label ID="lblTotalExamsQsa" runat="server" Text="Tests for the week : "></asp:Label></strong></td>
                    <td align="left"><asp:Label ID="lblTotalExamsAns" runat="server" Text=" 32" ></asp:Label></td>
                    <td align="right"><strong><asp:Label ID="lblNoOfSurverysQsa" runat="server" Text="Number of students who took the survey : " ></asp:Label></strong></td>
                    <td align="left"><asp:Label ID="lblNoOfSurveysAns" runat="server" Text="323" ></asp:Label></td>
             </tr></table>
                            </div>
                        <div style="padding: 10px;">



                            <div class="box">
                                <div class="box-header">
                                    <div class="Question_heading">
                                        <asp:Label ID="lblDates" runat="server" Font-Bold="True"></asp:Label>
                                    </div>
                                </div>
                                <%--first graph question--%><%--How would you rate your proctor?--%>
                                <div style="padding: 10px; background: #fff; border: 1px solid #ccc; margin-bottom: 10px;">
                                    <div class="Question_heading">
                                        <asp:Label ID="lblQsa2" runat="server" Font-Bold="True"></asp:Label>
                                    </div>
                                    <div class="Answer">
                                        <asp:Label ID="lblAns2" runat="server" Text="Answered :"></asp:Label>
                                        <asp:Label ID="lblAnswerd2" runat="server"></asp:Label>
                                        <asp:Label ID="lblSki2" runat="server" Text="Skipped :"></asp:Label>
                                        <asp:Label ID="lblSkipped2" runat="server"></asp:Label>
                                    </div>
                                    <div>
                                        <div class="Answer" style="text-align: left">
                                            <asp:Label ID="Label1" runat="server" Text="WGU Responses"></asp:Label></div>
                                        <telerik:RadHtmlChart runat="server" ID="rptAnsweredCount" Style="cursor: pointer;" Font-Size="Small" EnableAjaxSkinRendering="True" Height="100px" EnableTheming="True">
                                            <%--OnClientSeriesHovered="OnClientSeriesClicked"--%>
                                            <PlotArea>
                                                <Series>

                                                    <telerik:BarSeries DataFieldY="Count" Stacked="true">
                                                        <TooltipsAppearance DataFormatString="{0}" Visible="false" />
                                                        <LabelsAppearance Visible="true" DataFormatString="{0}">
                                                        </LabelsAppearance>
                                                        <Appearance></Appearance>
                                                    </telerik:BarSeries>
                                                </Series>
                                                <XAxis DataLabelsField="ExamDate" MajorTickType="None" MinorTickType="Outside" >
                                                    <Items>
                                                    </Items>
                                                    <LabelsAppearance>
                                                        <TextStyle Color="Green" FontFamily="Arial" Italic="true" FontSize="20" />
                                                    </LabelsAppearance>
                                                    <TitleAppearance Text="" />
                                                    <MinorGridLines Visible="false" />
                                                    <MajorGridLines Visible="false" />
                                                </XAxis>
                                                <YAxis MaxValue="5" Step="1" >
                                                    <LabelsAppearance DataFormatString="{0}" />
                                                    <TitleAppearance Text="" />
                                                    <MinorGridLines Visible="false" />
                                                    <MajorGridLines Visible="true" />
                                                </YAxis>
                                            </PlotArea>
                                            <Legend>
                                                <Appearance Visible="false" />
                                            </Legend>
                                            <Appearance>
                                                <FillStyle BackgroundColor="White" />
                                            </Appearance>
                                        </telerik:RadHtmlChart>
                                        <telerik:RadGrid ID="rgvReponsePercentage" runat="server" AutoGenerateColumns="False"
                                            AllowSorting="True" GridLines="None" Skin="Metro" OnItemDataBound="rgvReponsePercentage_ItemDataBound">
                                            <%--<ClientSettings EnableAlternatingItems="false"></ClientSettings>--%>
                                            <MasterTableView AllowFilteringByColumn="false" PagerStyle-PageSizes="20,50,100,150,200" PageSize="50" TableLayout="Fixed">

                                                <Columns>
                                                    <telerik:GridBoundColumn DataField="Response" HeaderText=""
                                                        SortExpression="Response" UniqueName="Response" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="40%" Wrap="true" />
                                                        <HeaderStyle Font-Bold="true" Wrap="true" />
                                                    </telerik:GridBoundColumn>
                                                      <telerik:GridBoundColumn DataField="VerySatisfied" HeaderText="Very Satisfied"
                                                        SortExpression="VerySatisfied" UniqueName="VerySatisfied" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="40%" Wrap="true" />
                                                        <HeaderStyle Font-Bold="true" Wrap="true" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="Satisfied" HeaderText="Satisfied"
                                                        SortExpression="Satisfied" UniqueName="Satisfied" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="40%" Wrap="true" />
                                                        <HeaderStyle Font-Bold="true" Wrap="true" />
                                                    </telerik:GridBoundColumn>
                                                     <telerik:GridBoundColumn DataField="Neutral" HeaderText="Neutral"
                                                        SortExpression="Neutral" UniqueName="Neutral" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="40%" Wrap="true" />
                                                        <HeaderStyle Font-Bold="true" Wrap="true" />
                                                    </telerik:GridBoundColumn>                                                   
                                                    <telerik:GridBoundColumn DataField="Dissatisfied" HeaderText="Dissatisfied"
                                                        SortExpression="Dissatisfied" UniqueName="Dissatisfied" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="40%" Wrap="true" />
                                                        <HeaderStyle Font-Bold="true" Wrap="true" />
                                                    </telerik:GridBoundColumn>
                                                     <telerik:GridBoundColumn DataField="VeryDissatisfied" HeaderText="Very Dissatisfied" ItemStyle-Wrap="true" FooterStyle-Wrap="true" HeaderStyle-Wrap="true"
                                                        SortExpression="VeryDissatisfied" UniqueName="VeryDissatisfied" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="40%" Wrap="true" />
                                                        <HeaderStyle Font-Bold="true" Wrap="true" />
                                                    </telerik:GridBoundColumn>                                                  
                                                    
                                                  
                                                    <telerik:GridBoundColumn DataField="Total" HeaderText="Total"
                                                        SortExpression="Total" UniqueName="Total" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="40%" Wrap="true" />
                                                        <HeaderStyle Font-Bold="true" Wrap="true" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="WeightedAvg" HeaderText="Weighted Average"
                                                        SortExpression="WeightedAvg" UniqueName="WeightedAvg" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="40%" Wrap="true" />
                                                        <HeaderStyle Font-Bold="true" Wrap="true" />
                                                    </telerik:GridBoundColumn>
                                                </Columns>
                                            </MasterTableView>
                                            <%-- <PagerStyle PageSizeControlType="RadComboBox" AlwaysVisible="true"/>--%>
                                        </telerik:RadGrid>
                                    </div>
                                </div>

                                <%--second graph question--%><%--How would you rate your overall experience with Examity?--%>
                                <div style="padding: 10px; background: #fff; border: 1px solid #ccc; margin-bottom: 10px;">
                                    <div class="Question_heading">
                                        <asp:Label ID="lblQsa3" runat="server" Font-Bold="True"></asp:Label>
                                    </div>
                                    <div class="Answer">
                                        <asp:Label ID="lblAns3" runat="server" Text="Answered :"></asp:Label>
                                        <asp:Label ID="lblAnswerd3" runat="server"></asp:Label>
                                        <asp:Label ID="lblSki3" runat="server" Text="Skipped :"></asp:Label>
                                        <asp:Label ID="lblSkipped3" runat="server"></asp:Label>
                                    </div>
                                    <div>
                                        <div class="Answer" style="text-align: left">
                                            <asp:Label ID="Label2" runat="server" Text="WGU Responses"></asp:Label></div>
                                        <telerik:RadHtmlChart runat="server" ID="rptAnsweredCount1" Style="cursor: pointer;" EnableAjaxSkinRendering="True" Height="100px" EnableTheming="True">
                                            <%--OnClientSeriesHovered="OnClientSeriesClicked"--%>
                                            <PlotArea>
                                                <Series>

                                                    <telerik:BarSeries DataFieldY="Count" Stacked="true">
                                                        <TooltipsAppearance DataFormatString="{0}" Visible="false" />
                                                        <LabelsAppearance Visible="true" DataFormatString="{0}" />
                                                        <Appearance></Appearance>
                                                    </telerik:BarSeries>
                                                </Series>
                                                <XAxis DataLabelsField="ExamDate" MajorTickType="None" MinorTickType="Outside">
                                                    <Items>
                                                    </Items>
                                                    <TitleAppearance Text="" />
                                                    <MinorGridLines Visible="false" />
                                                    <MajorGridLines Visible="false" />
                                                </XAxis>
                                                <YAxis MaxValue="5" Step="1">
                                                    <LabelsAppearance DataFormatString="{0}" />
                                                    <TitleAppearance Text="" />
                                                    <MinorGridLines Visible="false" />
                                                    <MajorGridLines Visible="true" />
                                                </YAxis>
                                            </PlotArea>
                                            <Legend>
                                                <Appearance Visible="false" />
                                            </Legend>
                                            <Appearance>
                                                <FillStyle BackgroundColor="White" />
                                            </Appearance>
                                        </telerik:RadHtmlChart>
                                        <telerik:RadGrid ID="rgvReponsePercentage1" runat="server" AutoGenerateColumns="False"
                                            AllowSorting="true" GridLines="None" Skin="Metro">
                                            <%--<ClientSettings EnableAlternatingItems="false"></ClientSettings>--%>
                                            <MasterTableView AllowFilteringByColumn="false" PagerStyle-PageSizes="20,50,100,150,200" PageSize="50" TableLayout="Fixed" >

                                                <Columns>
                                                    <telerik:GridBoundColumn DataField="Response" HeaderText="" AllowSorting="false"
                                                        SortExpression="Response" UniqueName="Response" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="40%" Wrap="true"  />
                                                        <HeaderStyle Font-Bold="true" Wrap="true" />
                                                    </telerik:GridBoundColumn>
                                                     <telerik:GridBoundColumn DataField="VerySatisfied" HeaderText="Very Satisfied" AllowSorting="false" HeaderStyle-ForeColor="#000000"
                                                        SortExpression="VerySatisfied" UniqueName="VerySatisfied" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="40%" Wrap="true" />
                                                        <HeaderStyle Font-Bold="true" Wrap="true" />
                                                    </telerik:GridBoundColumn>
                                                      <telerik:GridBoundColumn DataField="Satisfied" HeaderText="Satisfied"
                                                        SortExpression="Satisfied" UniqueName="Satisfied" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="40%" Wrap="true" />
                                                        <HeaderStyle Font-Bold="true" Wrap="true" />
                                                    </telerik:GridBoundColumn>
                                                       <telerik:GridBoundColumn DataField="Neutral" HeaderText="Neutral"
                                                        SortExpression="Neutral" UniqueName="Neutral" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="40%" Wrap="true" />
                                                        <HeaderStyle Font-Bold="true" Wrap="true" />
                                                    </telerik:GridBoundColumn>
                                                     <telerik:GridBoundColumn DataField="Dissatisfied" HeaderText="Dissatisfied"
                                                        SortExpression="Dissatisfied" UniqueName="Dissatisfied" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="40%" Wrap="true" />
                                                        <HeaderStyle Font-Bold="true" Wrap="true" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="VeryDissatisfied" HeaderText="Very Dissatisfied" ItemStyle-Wrap="true" FooterStyle-Wrap="true" HeaderStyle-Wrap="true"
                                                        SortExpression="VeryDissatisfied" UniqueName="VeryDissatisfied" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="40%" Wrap="true" />
                                                        <HeaderStyle Font-Bold="true" Wrap="true" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="Total" HeaderText="Total"
                                                        SortExpression="Total" UniqueName="Total" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="40%" Wrap="true" />
                                                        <HeaderStyle Font-Bold="true" Wrap="true" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="WeightedAvg" HeaderText="Weighted Average"
                                                        SortExpression="WeightedAvg" UniqueName="WeightedAvg" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="40%" Wrap="true" />
                                                        <HeaderStyle Font-Bold="true" Wrap="true" ForeColor="Black" />
                                                    </telerik:GridBoundColumn>
                                                </Columns>
                                            </MasterTableView>
                                            <%-- <PagerStyle PageSizeControlType="RadComboBox" AlwaysVisible="true"/>--%>
                                        </telerik:RadGrid>
                                    </div>
                                </div>

                            </div>
                            <div class="box">
                                <div class="box-header">
                                    <div class="Question_heading">
                                        <asp:Label ID="lblGoliveDate" runat="server" Font-Bold="True"></asp:Label>
                                    </div>
                                </div>
                                <%--third graph question--%><%--How would you rate your proctor?--%>
                                <div style="padding: 10px; background: #fff; border: 1px solid #ccc; margin-bottom: 10px;">

                                    <div class="Question_heading">
                                        <asp:Label ID="lblYQsa2" runat="server" Font-Bold="True"></asp:Label>
                                    </div>
                                    <div class="Answer">
                                        <asp:Label ID="lblYAns2" runat="server" Text="Answered :"></asp:Label>
                                        <asp:Label ID="lblYAnswerd2" runat="server"></asp:Label>
                                        <asp:Label ID="lblYSki2" runat="server" Text="Skipped :"></asp:Label>
                                        <asp:Label ID="lblYSkipped2" runat="server"></asp:Label>
                                    </div>
                                    <div>
                                        <div class="Answer" style="text-align: left">
                                            <asp:Label ID="Label3" runat="server" Text="WGU Responses"></asp:Label></div>
                                        <telerik:RadHtmlChart runat="server" ID="rptAnsweredCount2" Style="cursor: pointer;" EnableAjaxSkinRendering="True" Height="100px" EnableTheming="True">
                                            <%--OnClientSeriesHovered="OnClientSeriesClicked"--%>
                                            <PlotArea>
                                                <Series>

                                                    <telerik:BarSeries DataFieldY="Count" Stacked="true">
                                                        <TooltipsAppearance DataFormatString="{0}" Visible="false" />
                                                        <LabelsAppearance Visible="true" DataFormatString="{0}" />
                                                        <Appearance></Appearance>
                                                    </telerik:BarSeries>
                                                </Series>
                                                <XAxis DataLabelsField="ExamDate" MajorTickType="None" MinorTickType="Outside">
                                                    <Items>
                                                    </Items>
                                                    <TitleAppearance Text="" />
                                                    <MinorGridLines Visible="false" />
                                                    <MajorGridLines Visible="false" />
                                                </XAxis>
                                                <YAxis MaxValue="5" Step="1">
                                                    <LabelsAppearance DataFormatString="{0}" />
                                                    <TitleAppearance Text="" />
                                                    <MinorGridLines Visible="false" />
                                                    <MajorGridLines Visible="true" />
                                                </YAxis>
                                            </PlotArea>
                                            <Legend>
                                                <Appearance Visible="false" />
                                            </Legend>
                                            <Appearance>
                                                <FillStyle BackgroundColor="White" />
                                            </Appearance>
                                        </telerik:RadHtmlChart>
                                        <telerik:RadGrid ID="rgvReponsePercentage2" runat="server" AutoGenerateColumns="False"
                                            AllowSorting="True" GridLines="None" Skin="Metro" OnItemDataBound="rgvReponsePercentage_ItemDataBound">
                                            <%--<ClientSettings EnableAlternatingItems="false"></ClientSettings>--%>
                                            <MasterTableView AllowFilteringByColumn="false" PagerStyle-PageSizes="20,50,100,150,200" PageSize="50" TableLayout="Fixed">

                                                <Columns>
                                                    <telerik:GridBoundColumn DataField="Response" HeaderText=""
                                                        SortExpression="Response" UniqueName="Response" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="40%" Wrap="true" />
                                                        <HeaderStyle Font-Bold="true" Wrap="true" />
                                                    </telerik:GridBoundColumn>
                                                      <telerik:GridBoundColumn DataField="VerySatisfied" HeaderText="Very Satisfied"
                                                        SortExpression="VerySatisfied" UniqueName="VerySatisfied" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="40%" Wrap="true" />
                                                        <HeaderStyle Font-Bold="true" Wrap="true" />
                                                    </telerik:GridBoundColumn>
                                                       <telerik:GridBoundColumn DataField="Satisfied" HeaderText="Satisfied"
                                                        SortExpression="Satisfied" UniqueName="Satisfied" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="40%" Wrap="true" />
                                                        <HeaderStyle Font-Bold="true" Wrap="true" />
                                                    </telerik:GridBoundColumn>
                                                     <telerik:GridBoundColumn DataField="Neutral" HeaderText="Neutral"
                                                        SortExpression="Neutral" UniqueName="Neutral" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="40%" Wrap="true" />
                                                        <HeaderStyle Font-Bold="true" Wrap="true" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="Dissatisfied" HeaderText="Dissatisfied"
                                                        SortExpression="Dissatisfied" UniqueName="Dissatisfied" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="40%" Wrap="true" />
                                                        <HeaderStyle Font-Bold="true" Wrap="true" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="VeryDissatisfied" HeaderText="Very Dissatisfied" ItemStyle-Wrap="true" FooterStyle-Wrap="true" HeaderStyle-Wrap="true"
                                                        SortExpression="VeryDissatisfied" UniqueName="VeryDissatisfied" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="40%" Wrap="true" />
                                                        <HeaderStyle Font-Bold="true" Wrap="true" />
                                                    </telerik:GridBoundColumn>
                                               
                                                   
                                                 
                                                  
                                                    <telerik:GridBoundColumn DataField="Total" HeaderText="Total"
                                                        SortExpression="Total" UniqueName="Total" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="40%" Wrap="true" />
                                                        <HeaderStyle Font-Bold="true" Wrap="true" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="WeightedAvg" HeaderText="Weighted Average"
                                                        SortExpression="WeightedAvg" UniqueName="WeightedAvg" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="40%" Wrap="true" />
                                                        <HeaderStyle Font-Bold="true" Wrap="true" />
                                                    </telerik:GridBoundColumn>
                                                </Columns>
                                            </MasterTableView>
                                            <%-- <PagerStyle PageSizeControlType="RadComboBox" AlwaysVisible="true"/>--%>
                                        </telerik:RadGrid>
                                    </div>
                                </div>

                                <%--fourth graph question--%><%--How would you rate your overall experience with Examity?--%>
                                <div style="padding: 10px; background: #fff; border: 1px solid #ccc; margin-bottom: 10px;">
                                    <div class="Question_heading">
                                        <asp:Label ID="lblYQsa3" runat="server" Font-Bold="True"></asp:Label>
                                    </div>
                                    <div class="Answer">
                                        <asp:Label ID="lblYAns3" runat="server" Text="Answered :"></asp:Label>
                                        <asp:Label ID="lblYAnswerd3" runat="server"></asp:Label>
                                        <asp:Label ID="lblYSki3" runat="server" Text="Skipped :"></asp:Label>
                                        <asp:Label ID="lblySkipped3" runat="server"></asp:Label>
                                    </div>
                                    <div>
                                        <div class="Answer" style="text-align: left">
                                            <asp:Label ID="Label4" runat="server" Text="WGU Responses"></asp:Label></div>
                                        <telerik:RadHtmlChart runat="server" ID="rptAnsweredCount3" Style="cursor: pointer;" EnableAjaxSkinRendering="True" Height="100px" EnableTheming="True"  >
                                            <%--OnClientSeriesHovered="OnClientSeriesClicked"--%>
                                            <PlotArea>
                                                <Series>

                                                    <telerik:BarSeries DataFieldY="Count" Stacked="true" >
                                                        <TooltipsAppearance DataFormatString="{0}" Visible="false" />
                                                        <LabelsAppearance Visible="true" DataFormatString="{0}" />
                                                        <Appearance></Appearance>
                                                    </telerik:BarSeries>
                                                </Series>
                                                <XAxis DataLabelsField="ExamDate" MajorTickType="None" MinorTickType="Outside" Reversed="false">
                                                    <Items>
                                                    </Items>
                                                    <TitleAppearance Text="" />
                                                    <MinorGridLines Visible="false" />
                                                    <MajorGridLines Visible="false" />
                                                </XAxis>
                                                <YAxis MaxValue="5" Step="1">
                                                    <LabelsAppearance DataFormatString="{0}" />
                                                    <TitleAppearance Text="" />
                                                    <MinorGridLines Visible="false" />
                                                    <MajorGridLines Visible="true" />
                                                </YAxis>
                                            </PlotArea>
                                            <Legend>
                                                <Appearance Visible="false" />
                                            </Legend>
                                            <Appearance>
                                                <FillStyle BackgroundColor="White" />
                                            </Appearance>
                                        </telerik:RadHtmlChart>
                                        <telerik:RadGrid ID="rgvReponsePercentage3" runat="server" AutoGenerateColumns="False"
                                            AllowSorting="True" GridLines="None" Skin="Metro">
                                            <%--<ClientSettings EnableAlternatingItems="false"></ClientSettings>--%>
                                            <MasterTableView AllowFilteringByColumn="false" PagerStyle-PageSizes="20,50,100,150,200" PageSize="50" TableLayout="Fixed">

                                                <Columns>
                                                    <telerik:GridBoundColumn DataField="Response" HeaderText=""
                                                        SortExpression="Response" UniqueName="Response" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="40%" Wrap="true" />
                                                        <HeaderStyle Font-Bold="true" Wrap="true" />
                                                    </telerik:GridBoundColumn>
                                                     <telerik:GridBoundColumn DataField="VerySatisfied" HeaderText="Very Satisfied"
                                                        SortExpression="VerySatisfied" UniqueName="VerySatisfied" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="40%" Wrap="true" />
                                                        <HeaderStyle Font-Bold="true" Wrap="true" />
                                                    </telerik:GridBoundColumn>
                                                       <telerik:GridBoundColumn DataField="Satisfied" HeaderText="Satisfied"
                                                        SortExpression="Satisfied" UniqueName="Satisfied" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="40%" Wrap="true" />
                                                        <HeaderStyle Font-Bold="true" Wrap="true" />
                                                    </telerik:GridBoundColumn>
                                                       <telerik:GridBoundColumn DataField="Neutral" HeaderText="Neutral"
                                                        SortExpression="Neutral" UniqueName="Neutral" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="40%" Wrap="true" />
                                                        <HeaderStyle Font-Bold="true" Wrap="true" />
                                                    </telerik:GridBoundColumn>
                                                      <telerik:GridBoundColumn DataField="Dissatisfied" HeaderText="Dissatisfied"
                                                        SortExpression="Dissatisfied" UniqueName="Dissatisfied" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="40%" Wrap="true" />
                                                        <HeaderStyle Font-Bold="true" Wrap="true" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="VeryDissatisfied" HeaderText="Very Dissatisfied" ItemStyle-Wrap="true" FooterStyle-Wrap="true" HeaderStyle-Wrap="true"
                                                        SortExpression="VeryDissatisfied" UniqueName="VeryDissatisfied" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="40%" Wrap="true" />
                                                        <HeaderStyle Font-Bold="true" Wrap="true" />
                                                    </telerik:GridBoundColumn>
                                                   
                                                    <telerik:GridBoundColumn DataField="Total" HeaderText="Total"
                                                        SortExpression="Total" UniqueName="Total" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="40%" Wrap="true" />
                                                        <HeaderStyle Font-Bold="true" Wrap="true" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="WeightedAvg" HeaderText="Weighted Average"
                                                        SortExpression="WeightedAvg" UniqueName="WeightedAvg" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="40%" Wrap="true" />
                                                        <HeaderStyle Font-Bold="true" Wrap="true" />
                                                    </telerik:GridBoundColumn>
                                                </Columns>
                                            </MasterTableView>
                                            <%-- <PagerStyle PageSizeControlType="RadComboBox" AlwaysVisible="true"/>--%>
                                        </telerik:RadGrid>
                                    </div>
                                </div>


                            </div>


                        </div>
                    </div>
                </div>
            </div>
        </div>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            <%--<AjaxSettings>--%>
            <%--<telerik:AjaxSetting AjaxControlID="btnSearch">
        </AjaxSettings>--%>
        </telerik:RadAjaxManager>
        </div>
</asp:Content>

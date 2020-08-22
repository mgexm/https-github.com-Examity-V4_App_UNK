<%@ Page Title="" Language="C#" MasterPageFile="~/Provider/Provider.Master" AutoEventWireup="true" CodeBehind="QuestionSummaries.aspx.cs" Inherits="SecureProctor.Provider.QuestionSummaries" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ExamProviderContent" runat="server">
     <div class="container">
        <div class="container_inner">
              <div class="heading_menu">
                    <a href="Reports.aspx">Reports</a> <img src="../Images/arrowRight.png" width="18" /> Survey Graph
                </div>
            <div class="login_new1">
                <div class="box">
                    <div class="box-header">
                        <div class="clear"></div>
                    </div>
                </div>
                <div class="box-data">
                    <div class="box-data_inner_grid">
                        <div style="height: 25px; margin-top: 10px;">
                           <asp:LinkButton CssClass="FilterMenuItem FilterMenuActiveItem" ForeColor="#ffffff" ID="lnkQuestionSummaries" runat="server" Text="Survey Graphs"  />
                            <asp:LinkButton CssClass="FilterMenuItem " ID="lnkAll" runat="server" Text="Survey Details"  OnClick="lnkAll_Click" />
                            <asp:LinkButton CssClass="FilterMenuItem" ID="lnkIndividual" runat="server" Text="Individual Responses"  OnClick="lnkIndividual_Click" />
                        </div>
                         <div style="position: relative; top: 5px; right: 5px;">
                            <div style="position: absolute; top: -30px; right: 5px;">
                                <asp:ImageButton ID="btnExport" runat="server" ImageUrl="~/Images/excel.png" OnClick="BtnExportToExcel_Click" AlternateText="Xlsx" Width="20" />
                            </div>
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
                          
                            <div class="clear"></div>
                       
                        <div style="margin: 10PX;">
                            <asp:PlaceHolder ID="PlaceSurveyQuestions" runat="server"></asp:PlaceHolder>
                        </div>
                          
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

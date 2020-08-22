<%@ Page Title="" Language="C#" MasterPageFile="~/Provider/Provider.Master" AutoEventWireup="true" CodeBehind="Surveydetails.aspx.cs" Inherits="SecureProctor.Provider.Surveydetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ExamProviderContent" runat="server">


    <div class="container">
        <div class="container_inner">
            <div class="heading_menu">
                    <a href="Reports.aspx">Reports</a> <img src="../Images/arrowRight.png" width="18" /> Survey Details
                </div>
            <div class="login_new1">
             
                <div class="box-data">
                    <div class="box-data_inner_grid">
                        <div style="height: 25px; margin-top: 10px;">
                             <asp:LinkButton CssClass="FilterMenuItem" ID="lnkQuestionSummary" runat="server" Text="Survey Graphs"  OnClick="lnkQuestionSummary_Click"  />
                            <asp:LinkButton CssClass="FilterMenuItem FilterMenuActiveItem" ForeColor="#ffffff" ID="lnkIndividual" runat="server" Text="Survey Details" />
                            <asp:LinkButton CssClass="FilterMenuItem " ID="lnkAll" runat="server" Text="Individual Responses"  OnClick="lnkAll_Click" />
                           
                        </div>
                        <div style="position: relative; top: 5px; right: 5px;">
                            <div style="position: absolute; top: -30px; right: 5px;">
                                <asp:ImageButton ID="btnExport" runat="server" ImageUrl="~/Images/excel.png" OnClick="btnExport_Click" AlternateText="Xlsx" Width="20" />
                            </div>
                        </div>
                        <div class="divtab">
                            
                          <div style="margin:0px auto; width:310px; background:#fcfcfc; color:#000; border-radius:3px;">
         <table cellpadding="0"  width="100%">
             
                <tr>
                    
                  

                    <td width="30">
                       
                        <asp:LinkButton ID="btnleftarrow" runat="server" CssClass="time_left_arrow" OnClick="btnleftarrow_Click" Width="30"></asp:LinkButton></td>
                    
                    <td style="width: 30px;">

                        <telerik:RadDatePicker AutoPostBack="true" DateInput-Display="false" OnSelectedDateChanged="txtFromDate_SelectedDateChanged"
                            DateInput-ReadOnly="true" ID="txtFromDate" runat="server" Skin="Web20" Width="30" Calendar-ShowRowHeaders="false">
                        </telerik:RadDatePicker>
                    </td>
                    <td width="80" align="right" >
                        <asp:Label ID="lblfirstdate" runat="server" Text="" ForeColor="Black" Font-Size="14px"></asp:Label></td>
                    <td width="20" align="center">--</td>
                    <td width="80" align="left">
                        <asp:Label ID="lblLastDate" runat="server" Text="" ForeColor="Black" Font-Size="14px"></asp:Label>
                    </td>


                    <td width="30">
                       <%-- <asp:ImageButton ID="btnrightarrow" runat="server" CssClass="time_right_arrow" ImageUrl="#" OnClick="btnrightarrow_Click" />--%>
                        <asp:LinkButton ID="btnrightarrow" runat="server" CssClass="time_right_arrow" OnClick="btnrightarrow_Click" Width="30" ></asp:LinkButton>
                      <%--  <img src="Images/arrow.png" />--%></td>
                   
                </tr>
            </table>
            </div>
                            <div class="clear"></div>
                        </div>
                        <div style="margin:5px;">
                            <div class="Summary">
                                <table width="95%">
                                <tr>
                   <td align="right"><strong><asp:Label ID="lblTotalExamsQsa" runat="server" Text="Tests for the week : "></asp:Label></strong></td>
                    <td align="left"><asp:Label ID="lblTotalExamsAns" runat="server" Text=" " ></asp:Label></td>
                    <td align="right"><strong><asp:Label ID="lblNoOfSurverysQsa" runat="server" Text="Number of students who took the survey : " ></asp:Label></strong></td>
                    <td align="left"><asp:Label ID="lblNoOfSurveysAns" runat="server" Text=" " ></asp:Label></td>
             </tr></table>
                            </div>
                             <asp:HiddenField ID="hdnClientId" runat="server" />
                            <telerik:RadGrid ID="gvResponses" runat="server"
                                AutoGenerateColumns="false" AllowPaging="false"
                                AllowSorting="false"
                                GridLines="Both" Skin="Metro" ShowHeader="false" ExportSettings-ExportOnlyData="true">
                                <MasterTableView AllowFilteringByColumn="false">
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="Name" UniqueName="Name">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="From" UniqueName="From">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Golive" UniqueName="Golive" Display="false">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </telerik:GridBoundColumn>
                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

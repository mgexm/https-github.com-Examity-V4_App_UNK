<%@ Page Title="" Language="C#" MasterPageFile="~/Provider/Provider.Master" AutoEventWireup="true" CodeBehind="AllResponsesReport.aspx.cs" Inherits="SecureProctor.Provider.AllResponsesReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ExamProviderContent" Runat="Server">

      

     <script type="text/javascript">

         function GridCreated(sender, args) {
             var scrollArea = sender.GridDataDiv;
             var dataHeight = sender.get_masterTableView().get_element().clientHeight; if (dataHeight < 300) {
                 scrollArea.style.height = dataHeight + 17 + "px";
             }
         }
    </script>
<div class="container">
<div class="container_inner">
    <div class="heading_menu">
                    <a href="Reports.aspx">Reports</a> <img src="../Images/arrowRight.png" width="18" /> Individual Responses
                </div>
<div class="login_new1">
<%--<div class="box">
<div class="box-header">

    <table width="100%">
        <tr>
            <td width="25px"><img src="images/SummaryReport1.png" ></td>
            <td>All Responses Report</td>
            <td align="right"><a href="IndividualResponsesReportsPage.aspx" class=" button_small1 button-blue"  >Individual Responces</a></td>
        </tr>
    </table>
     
<div class="clear"></div>
</div>
</div>--%>
<div class="box-data">
<div class="box-data_inner_grid">
      <div style="height:25px; margin-top:10px;">
           <asp:LinkButton CssClass="FilterMenuItem" ID="lnkQuestionSummary" runat="server"  Text="Survey Graphs"    OnClick="lnkQuestionSummary_Click" />
           <asp:LinkButton CssClass="FilterMenuItem" ID="lnkAll"  runat="server" Text="Survey Details"  OnClick="lnkAll_Click" />          
          <asp:LinkButton CssClass="FilterMenuItem FilterMenuActiveItem" ForeColor="#ffffff" ID="lnkIndividual" runat="server"  Text="Individual Responses"    />
           
           
                  
        </div>
    <div style="position:relative; top:5px; right:5px;">
         <div style="position:absolute; top:-30px; right:5px;">
         <asp:ImageButton ID="btnExport" runat="server" ImageUrl="~/Images/excel.png" OnClick="btnExport_Click" AlternateText="Xlsx" Width="20"/></div></div>
    <div class="divtab">
            <table width="100%">
                <tr>
                    <td> 
                        <ul class="Report_tab">
                          <%--  <li><asp:Label ID="Label2" runat="server" Text="Select Client(s) :" ></asp:Label></li>
                            <li> <telerik:RadComboBox ID="ddlClients" runat="server"   EmptyMessage="       --Select Client--       "
                            Font-Bold="true" LabelCssClass="SelectClient_text"  Visible="true" DropDownAutoWidth="Enabled">
                        </telerik:RadComboBox></li>--%>
                             <li>&nbsp;</li>
                            <li><asp:Label ID="lblFromDate" runat="server" Text="From :" ></asp:Label></li>
                            <li><telerik:RadDatePicker  DateInput-ReadOnly="true" ID="rdpFromDate" runat="server" Width="120" Skin="Web20">
                                <Calendar runat="server" ShowRowHeaders="false"></Calendar>
                                </telerik:RadDatePicker></li>
                            <li><asp:Label ID="lblToDate" runat="server" Text="To :" ></asp:Label></li>
                            <li><telerik:RadDatePicker  DateInput-ReadOnly="true" ID="rdpToDate" runat="server" Width="120" Skin="Web20">
                                <Calendar runat="server" ShowRowHeaders="false"></Calendar>
                                </telerik:RadDatePicker></li>
                            <li>&nbsp;</li>
                            <li><asp:Label ID="lblStudentName" runat="server" Text="Student Name :" ></asp:Label></li>
                            <li><telerik:RadTextBox ID="txtStudentName" runat="server" Width="90" ></telerik:RadTextBox></li>
                             <li>&nbsp;</li>
                            <li><asp:Label ID="lblExamID" runat="server" Text="Exam ID :"></asp:Label></li>
                            <li><telerik:RadTextBox ID="txtExamID" runat="server" Width="90" ></telerik:RadTextBox></li>
                             <li>&nbsp;</li>
                            <li><asp:Button ID="btnSearch" runat="server" CssClass="button_new_s orange" Text="Search" OnClick="btnSearch_Click"  /></li>
                            <li style="float:right;"></li>
                        </ul>       
                    </td>
                </tr>
            </table>

        </div>
   <div style="width:100%" >

           <telerik:RadGrid ID="gReport"  runat="server"  AutoGenerateColumns="true"
            OnNeedDataSource="gReport_NeedDataSource" GridLines="None" Skin="Metro" Width="100%" >
           <%-- <ExportSettings ExportOnlyData="true" Excel-Format="Html" />--%>
            <MasterTableView HorizontalAlign="Center" AllowSorting="true" AllowPaging="true" PageSize="20" ShowFooter="false" ShowHeader="true" EditMode="PopUp" GridLines="Both" >
                <NoRecordsTemplate>
                    <asp:Label ID="Label1" runat="server" Text="No records available" />
                </NoRecordsTemplate>           
                <Columns>

                </Columns>
                <HeaderStyle HorizontalAlign="Center" ForeColor="Black" Font-Bold="true" Width="250px" />
                <ItemStyle HorizontalAlign="Center" Width="250px" />
                <AlternatingItemStyle HorizontalAlign="Center" />
                <FooterStyle HorizontalAlign="Center"  />
            </MasterTableView>
           <ClientSettings> 
                <Scrolling AllowScroll="true" UseStaticHeaders="true" ScrollHeight="300px"   SaveScrollPosition="true"  FrozenColumnsCount="1" ></Scrolling> 
                <ClientEvents OnGridCreated="GridCreated" />
            </ClientSettings> 
        </telerik:RadGrid>        
</div>
    </div>
    </div>
    </div>
    </div></div>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            
            <telerik:AjaxSetting AjaxControlID="btnSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gReport"  />                    
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>

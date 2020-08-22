<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="LaunchTimeReportDetails.aspx.cs" Inherits="SecureProctor.Admin.LaunchTimeReportDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminContent" Runat="Server">
     <link rel="stylesheet" href="CSS/Controls.css" />
     <link href="../CSS/Controls.css" rel="stylesheet" />
      <link href="CSS/Examity_styles.css" rel="stylesheet" />
    <link href="css/Spilter.css" rel="stylesheet" type="text/css" />
   
    <script src="../Scripts/PageScripts.js"></script>
  
    <script type="text/javascript">
       
        function GridCreated(sender, args) {
            var scrollArea = sender.GridDataDiv;
            var dataHeight = sender.get_masterTableView().get_element().clientHeight; if (dataHeight < 600) {
                scrollArea.style.height = dataHeight + 17 + "px";
            }
        }
    </script>
    <script type="text/javascript">

        function Hide() {
            debugger
            if ($('#chkSendMail').attr('checked'))

               
            {
                $('#txtEmail').show();
                $('#spanMultipleEmails').show();
                $('#btnExport').hide();
                $('#btnSendMail').show();
            }
            else {
                $('#txtEmail').hide();
                $('#spanMultipleEmails').hide();
                $('#btnExport').show();
                $('#btnSendMail').hide();
            }


        }

    </script>
   
   

    
     <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" >
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnSearch">
                <UpdatedControls>
                  <%--  <telerik:AjaxUpdatedControl ControlID="rptExamsPerDayCount" LoadingPanelID="RadAjaxLoadingPanel1" />--%>
                                        
                </UpdatedControls>
            </telerik:AjaxSetting>
             <telerik:AjaxSetting AjaxControlID="txtFromDate">
                <UpdatedControls>                  
                    <telerik:AjaxUpdatedControl ControlID="txtFromDate" />
                    <telerik:AjaxUpdatedControl ControlID="lblfirstdate" />
                    <telerik:AjaxUpdatedControl ControlID="lblLastDate" />
                    <telerik:AjaxUpdatedControl ControlID="gvStatusDetails" />
                  
                   
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnrightarrow">
                <UpdatedControls>                  
                    <telerik:AjaxUpdatedControl ControlID="txtFromDate"  />
                    <telerik:AjaxUpdatedControl ControlID="lblfirstdate" />
                    <telerik:AjaxUpdatedControl ControlID="lblLastDate"  LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="gvStatusDetails" />
                   
                </UpdatedControls>
            </telerik:AjaxSetting>
             <telerik:AjaxSetting AjaxControlID="btnleftarrow">
                <UpdatedControls>                  
                    <telerik:AjaxUpdatedControl ControlID="txtFromDate" />
                    <telerik:AjaxUpdatedControl ControlID="lblfirstdate" />
                    <telerik:AjaxUpdatedControl ControlID="lblLastDate" LoadingPanelID="RadAjaxLoadingPanel1"/>
                   <telerik:AjaxUpdatedControl ControlID="gvStatusDetails" />
                   
                     
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnExportOptions">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="windowExportOptions" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>

    <telerik:RadWindow ID="windowExportOptions" runat="server" OnClientClose="$('#chkSendMail').removeAttr('checked')" IconUrl="~/Images/ExamityLock.png" Title="Export options" Width="500px" Height="255px">
        <ContentTemplate>
            <div class=" export_model">
                Export options :
                <asp:RadioButtonList RepeatDirection="Horizontal" RepeatLayout="Flow" ID="rdlExportOptions" runat="server">
                    <asp:ListItem Selected="True" Value="Excel"><img title="Excel" style="cursor:pointer;vertical-align:middle;padding:10px;" src="../Images/excel.png" alt="Excel" width="30"/></asp:ListItem>
                    
                </asp:RadioButtonList>
                <br />
                <br />
                <asp:CheckBox ID="chkSendMail" Style="cursor: pointer;" runat="server" Text="Send E-Mail" ClientIDMode="Static" onclick="Hide()" />
                <asp:TextBox placeholder="Enter e-mail ID" TextMode="MultiLine" ID="txtEmail" Width="200px" runat="server" CssClass="textBox medium" ClientIDMode="Static" Style="display: none;" ValidationGroup="SendMail" />
                <br />
                <span id="spanMultipleEmails" style="display: none;">(To specify multiple addresses, separate the addresses with commas.)</span><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ValidationGroup="SendMail" ErrorMessage="<br />Email cannot be empty!" Display="Dynamic" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="^[\W]*([\w+\-.%]+@[\w\-.]+\.[A-Za-z]{2,4}[\W]*,{1}[\W]*)*([\w+\-.%]+@[\w\-.]+\.[A-Za-z]{2,4})[\W]*$" runat="server" ControlToValidate="txtEmail" ValidationGroup="SendMail" Display="Dynamic" ErrorMessage="<br />Invalid Email Format!" />
                <br />
                <br />
                <asp:Button ID="btnExport" ClientIDMode="Static" runat="server" OnClick="btnExport_Click" Width="150px" CssClass="button_new orange" Text="Export" />
                <asp:Button ID="btnSendMail" ClientIDMode="Static" runat="server" OnClick="btnExport_Click" Width="150px" CssClass="button_new orange" Text="Send Mail" ValidationGroup="SendMail" Style="display: none;" />
            </div>
        </ContentTemplate>
    </telerik:RadWindow>

    <div class="page_header">

         <a href="AdminReports.aspx">Reports</a> <img src="../Images/arrowRight.png " width="18" /> Launch time
       
    </div>
     

    <div class="arrow-up"></div>
    <div style="background-color: white; border-radius: 3px; width: 97%; padding: 15px;">
        <asp:HiddenField ID="hidFromDate" runat="server" />
        <asp:HiddenField ID="hidToDate" runat="server" />
        <asp:HiddenField ID="HiddenField1" runat="server" />
         <div style="display: table;">
            <asp:LinkButton CssClass="FilterMenuItem" ID="lnkGraph" runat="server"  Text="Launch time graph" OnClick="lnkGraph_Click"   />
            <asp:LinkButton CssClass="FilterMenuItem FilterMenuActiveItem" ID="lnkDetails" runat="server" Text="Launch time details"/>  
         
        </div>

                <div class="divTab" style="margin-top:8px;">
            <div style="margin:0px auto; width:322px; background:#fcfcfc; color:#000; border-radius:3px;">
                <table cellpadding="5"  width="100%">
                <tr>
                    <td width="30">                     
                        <asp:LinkButton ID="btnleftarrow" runat="server" CssClass="time_left_arrow" OnClick="btnleftarrow_Click" Width="30"></asp:LinkButton>
                      </td>
                    <td style="width: 30px;">

                        <telerik:RadDatePicker AutoPostBack="true" DateInput-Display="false" OnSelectedDateChanged="txtFromDate_SelectedDateChanged"
                            DateInput-ReadOnly="true" ID="txtFromDate" runat="server" Skin="Web20" Width="30">
                        </telerik:RadDatePicker>
                    </td>
                    <td width="80" align="right" >
                        <asp:Label ID="lblfirstdate" runat="server" Text="" ForeColor="Black" Font-Size="14px"></asp:Label></td>
                    <td width="20" align="center">--</td>
                    <td width="80" align="left">
                        <asp:Label ID="lblLastDate" runat="server" Text="" ForeColor="Black" Font-Size="14px"></asp:Label>
                    </td>


                    <td width="30">                      
                        <asp:LinkButton ID="btnrightarrow" runat="server" CssClass="time_right_arrow" OnClick="btnrightarrow_Click" Width="30" ></asp:LinkButton>
                     </td>
                    <td>&nbsp;</td>
                     <td width="350" align="right">
                         
                       </td>
                     <td>
                        <asp:ImageButton ToolTip="Export report" ID="btnExportOptions" ImageUrl="~/Images/export.png" OnClick="btnExportOptions_Click" runat="server"  Style="outline: none" ImageAlign="AbsMiddle" Width="25px" />
                       </td>
                 
                </tr>
            </table>

            </div>
            
        </div>


      <telerik:RadGrid ID="gvStatusDetails" runat="server" AutoGenerateColumns="false" OnNeedDataSource="gvStatusDetails_NeedDataSource" GroupingSettings-CaseSensitive="False" Skin="Office2007">
            <MasterTableView HorizontalAlign="Center" AllowSorting="true" AllowPaging="true" PageSize="20" TableLayout="Auto" >
                <NoRecordsTemplate>
                    <asp:Label ID="Label1" runat="server" Text="No Exams scheduled" />
                </NoRecordsTemplate>
                <Columns>                   
                 
                    <telerik:GridBoundColumn HeaderText="Exam ID" DataField="ID" UniqueName="ID" SortExpression="ID"  >
                        <ItemStyle HorizontalAlign="Center" />
                    </telerik:GridBoundColumn>
                  
                    <telerik:GridBoundColumn HeaderText="Student Name" DataField="StudentName" UniqueName="StudentName"  SortExpression="StudentName" >
                        <ItemStyle HorizontalAlign="Center" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderText="Course Name" DataField="Coursename" UniqueName="Coursename" SortExpression="Coursename"  >
                        <ItemStyle HorizontalAlign="Center" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderText="Exam Name" DataField="Examname" UniqueName="Examname" SortExpression="Examname" >
                        <ItemStyle HorizontalAlign="Center" />
                    </telerik:GridBoundColumn>
                     <telerik:GridDateTimeColumn HeaderText="Authentication start time" DataField="Authenticationstarted"  UniqueName="Authenticationstarted" SortExpression="Authenticationstarted"  DataFormatString="{0:MM/dd/yyyy hh:mm:ss tt}">
                        <ItemStyle HorizontalAlign="Center" />
                    </telerik:GridDateTimeColumn>
                    <telerik:GridDateTimeColumn HeaderText="Exam start time" DataField="Authenticationended"  UniqueName="Authenticationended" SortExpression="Authenticationended" DataFormatString="{0:MM/dd/yyyy hh:mm:ss tt}">
                        <ItemStyle HorizontalAlign="Center" />
                    </telerik:GridDateTimeColumn>
                   <telerik:GridBoundColumn HeaderText="Launch time" DataField="Launchtime" UniqueName="Launchtime" SortExpression="Launchtime" >
                        <ItemStyle HorizontalAlign="Center" />
                    </telerik:GridBoundColumn>
                </Columns>
                <HeaderStyle HorizontalAlign="Center"/>
                <ItemStyle HorizontalAlign="Center" />
                <AlternatingItemStyle HorizontalAlign="Center" />

            </MasterTableView>

            <ClientSettings>
                <Scrolling AllowScroll="true" UseStaticHeaders="true" ScrollHeight="300px" SaveScrollPosition="true" FrozenColumnsCount="1"></Scrolling>
                <ClientEvents OnGridCreated="GridCreated" />
            </ClientSettings>
        </telerik:RadGrid>


    </div>

    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="" Transparency="30">
        <div  style="text-align: center; background-color: White; position: absolute;top: 50%;left: 50%; margin: -50px 0px 0px -50px;">
                  
                    <asp:Image ID="ImgLoader" runat="server" ImageUrl="~/Images/Loader.gif" Width="56"
                        Height="56" />
                </div>
    </telerik:RadAjaxLoadingPanel>
</asp:Content>



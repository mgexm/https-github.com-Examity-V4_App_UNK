<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="LaunchTimeReport.aspx.cs" Inherits="SecureProctor.Admin.LaunchTimeReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminContent" Runat="Server">
    
    <link href="../CSS/Controls.css" rel="stylesheet" />
    <script type="text/javascript" src="Scripts/jquery-1.10.2.js"></script>
    <link href="../Scripts/jquery-ui.css" rel="stylesheet" />
    <script type="text/javascript" src="Scripts/jquery1.10.4-ui.js"></script>
    <script src="../Scripts/PageScripts.js"></script>   
    <script src="../Scripts/jspdf.js"></script>
    <script src="../Scripts/jspdf.plugin.addimage.js"></script>
     <script type="text/javascript" src="https://canvg.googlecode.com/svn/trunk/rgbcolor.js"></script>
    <script type="text/javascript" src="https://canvg.googlecode.com/svn/trunk/canvg.js"></script>
    <script type="text/javascript" src="Scripts/FileSaver.js"></script>    

    <script src="../Scripts/FileSaver.js"></script>
      <link rel="shortcut icon" href="Images/ExamityLock.png" />
   
    
    <link href="../css/Spilter.css" rel="stylesheet" type="text/css" />
    <link href='https://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js" language="javascript" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/2.0.2/jquery.min.js"></script>


    <script type="text/javascript">
        function GenerateReport(width, height, mode) {
      
            if (mode == "email" && !validateEmail($('#<%=txtEmail.ClientID%>').val())) {
               if ($('#<%=txtEmail.ClientID%>').val() == "")
                    alert('Email address cannot be blank.');
                else
                    alert('Invalid email address.');

                return false;
            }

            canvg('canvas', '<?xml version="1.0" standalone="no" ?><!DOCTYPE svg PUBLIC "-//W3C//DTD SVG 20010904//EN" "http://www.w3.org/TR/2001/REC-SVG-20010904/DTD/svg10.dtd">' + $('#ctl00_Content2_rptLaunchTime').html().substring(27, $('#ctl00_Content2_rptLaunchTime').html().length - 167));
            var canvas = document.getElementById("canvas");
            var imgData = canvas.toDataURL("image/jpeg");
            var doc = new jsPDF('landscape');
            doc.setFontSize(20);

            var lblMsg = $('#<%=lblMsg.ClientID%>').html();
            lblMsg += $('#<%=lblMsgval.ClientID%>').html();

           doc.text(60, 20, lblMsg);



           doc.addImage(imgData, 'JPEG', 10, 40, width, height);
           if (mode == 'email') {

               var dataURL = doc.output('dataurlstring');

               debugger;

               AjaxHandler.SendEMailWithAttachment(dataURL, "launch time report");
           }
           else
               doc.save("launch time report");

           $find('<%=windowExportOptions.ClientID %>').close();
        }
    </script>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content2" Runat="Server">

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
                    <telerik:AjaxUpdatedControl ControlID="rptLaunchTime" />
                    <telerik:AjaxUpdatedControl ControlID="lblMsg" />
                    <telerik:AjaxUpdatedControl ControlID="lblMsgval" />
                   
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnrightarrow">
                <UpdatedControls>                  
                    <telerik:AjaxUpdatedControl ControlID="txtFromDate"  />
                    <telerik:AjaxUpdatedControl ControlID="lblfirstdate" />
                    <telerik:AjaxUpdatedControl ControlID="lblLastDate"  LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="gvStatusDetails" />
                    <telerik:AjaxUpdatedControl ControlID="rptLaunchTime" />
                      <telerik:AjaxUpdatedControl ControlID="lblMsg" />
                     <telerik:AjaxUpdatedControl ControlID="lblMsgval" />
                </UpdatedControls>
            </telerik:AjaxSetting>
             <telerik:AjaxSetting AjaxControlID="btnleftarrow">
                <UpdatedControls>                  
                    <telerik:AjaxUpdatedControl ControlID="txtFromDate" />
                    <telerik:AjaxUpdatedControl ControlID="lblfirstdate" />
                    <telerik:AjaxUpdatedControl ControlID="lblLastDate" LoadingPanelID="RadAjaxLoadingPanel1"/>
                   <telerik:AjaxUpdatedControl ControlID="gvStatusDetails" />
                    <telerik:AjaxUpdatedControl ControlID="rptLaunchTime" />
                      <telerik:AjaxUpdatedControl ControlID="lblMsg" />
                     <telerik:AjaxUpdatedControl ControlID="lblMsgval" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnExportOptions">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="windowExportOptions" />
                     <telerik:AjaxUpdatedControl ControlID="btnExport" />
                     <telerik:AjaxUpdatedControl ControlID="btnSendMail" />
                     <telerik:AjaxUpdatedControl ControlID="btnExaportAverage" />
                     <telerik:AjaxUpdatedControl ControlID="btnAverageSendMail" />
                    <telerik:AjaxUpdatedControl ControlID="rdlexcel" />
                     <telerik:AjaxUpdatedControl ControlID="rdlpdf" />
                </UpdatedControls>
            </telerik:AjaxSetting>
             <telerik:AjaxSetting AjaxControlID="btnAverageExportOptions">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="windowExportOptions" />
                     <telerik:AjaxUpdatedControl ControlID="btnExport" />
                     <telerik:AjaxUpdatedControl ControlID="btnSendMail" />
                     <telerik:AjaxUpdatedControl ControlID="btnExaportAverage" />
                     <telerik:AjaxUpdatedControl ControlID="btnAverageSendMail" />
                     <telerik:AjaxUpdatedControl ControlID="rdlexcel" />
                     <telerik:AjaxUpdatedControl ControlID="rdlpdf" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
      <div class="page_header">
           <a href="AdminReports.aspx">Reports</a> <img src="../Images/arrowRight.png " width="18" /> Launch time
     
    </div>
     <div class="arrow-up"></div>
    <div style="background-color: white; border-radius: 3px; width: 97%; padding: 15px;">
        <asp:HiddenField ID="hidFromDate" runat="server" />
        <asp:HiddenField ID="hidToDate" runat="server" />

        <div style="display: table;">
            <asp:LinkButton CssClass="FilterMenuItem FilterMenuActiveItem" ID="lnkGraph" runat="server"  Text="Launch time graph"   />
            <asp:LinkButton CssClass="FilterMenuItem" ID="lnkDetails" runat="server" Text="Launch time details " OnClick="lnkDetails_Click"/>  
         
        </div>

        <div class="divTab" style="margin-top:8px;">
            
            <table width="100%">
                <tr>
                    <td width="150px" style="text-align:center;"><asp:ImageButton ToolTip="Export Average Time" ID="btnAverageExportOptions" ImageUrl="~/Images/export.png" AlternateText="Exaport Graph"  runat="server"  OnClick="btnAverageExportOptions_Click"  Style="outline: none" ImageAlign="AbsMiddle" Width="25px" />
                        <br/>Export Average Time
</td>
                    <td width="400px" style="text-align:center;">
                         <div style="margin:0px auto; width:322px; background:#fcfcfc; color:#000; border-radius:3px; padding-right:20px;">

                <table cellpadding="5"  width="100%">
                <tr>
                     <td>
                       </td>
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
                    
                     
                    
                   
                    <td>
                   
                    </td>
                </tr>
            </table>

            </div>
                    </td>
                     <td  width="150px" style="text-align:center;">
                        <asp:ImageButton ToolTip="Export Graph" ID="btnExportOptions" ImageUrl="~/Images/export.png" AlternateText="Export Graph" OnClick="btnExportOptions_Click" runat="server"  Style="outline: none" ImageAlign="AbsMiddle" Width="25px" />
                      <br />Export Graph
                          </td>
                </tr>
            </table>
           
            
        </div>
        <div >
             <telerik:RadWindow ID="windowExportOptions" OnClientClose="$('#chkSendMail').removeAttr('checked')" runat="server" IconUrl="../Images/ExamityLock.png" Title="Export options" Width="500px" Height="300px">
                            <ContentTemplate>
                                <div class="export_model">
                                    Export options :
                <asp:RadioButtonList RepeatDirection="Horizontal" RepeatLayout="Flow" ID="rdlpdf" runat="server">
                    <asp:ListItem Value="PDF" Selected="True"><img title="PDF" style="cursor:pointer;vertical-align:middle;padding:10px;" src="../Images/pdf.png" alt="PDF" width="30"/></asp:ListItem>
                      </asp:RadioButtonList>
                 <asp:RadioButtonList RepeatDirection="Horizontal" RepeatLayout="Flow" ID="rdlexcel" runat="server">
                   <asp:ListItem Selected="True" Value="Excel"><img title="Excel" style="cursor:pointer;vertical-align:middle;padding:10px;" src="../Images/excel.png" alt="Excel" width="30"/></asp:ListItem>
                      </asp:RadioButtonList>
                                    <br />
                                    <br />
                                    <asp:CheckBox ID="chkSendMail" Style="cursor: pointer; display:none;" runat="server" Text="Send E-Mail" ClientIDMode="Static" onclick="if($('#chkSendMail').prop('checked')){$('#txtEmail').show();$('#spanMultipleEmails').show();$('#btnExport').hide();$('#btnSendMail').show();}else{$('#txtEmail').hide();$('#spanMultipleEmails').hide();$('#btnExport').show();$('#btnSendMail').hide();}" />
                                    <asp:TextBox placeholder="Enter e-mail ID" TextMode="MultiLine" ID="txtEmail" Width="200px" runat="server" CssClass="textBox medium" ClientIDMode="Static" Style="display: none;" ValidationGroup="SendMail" />
                                    <br />
                                    <span id="spanMultipleEmails" style="display: none;">(To specify multiple addresses, separate the addresses with commas.)</span><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ValidationGroup="SendMail" ErrorMessage="<br />Email cannot be empty!" Display="Dynamic" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="^[\W]*([\w+\-.%]+@[\w\-.]+\.[A-Za-z]{2,4}[\W]*,{1}[\W]*)*([\w+\-.%]+@[\w\-.]+\.[A-Za-z]{2,4})[\W]*$" runat="server" ControlToValidate="txtEmail" ValidationGroup="SendMail" Display="Dynamic" ErrorMessage="<br />Invalid Email Format!" />
                                    <br />
                                    <br />
                                    <asp:Button ID="btnExport" ClientIDMode="Static" runat="server" OnClientClick="GenerateReport(250,100,'save'); return false;" Width="150px" CssClass="button_new orange" Text="Export" />
                                    <asp:Button ID="btnSendMail" ClientIDMode="Static" runat="server" OnClientClick="GenerateReport(250,100,'email'); return false;" Width="150px" CssClass="button_new orange" Text="Send Mail" ValidationGroup="SendMail" Style="display: none;" />
                                    <asp:Button ID="btnExaportAverage" ClientIDMode="Static" runat="server"   Width="150px" CssClass="button_new orange" Text="Export" OnClick="btnExaportAverage_Click" />
                                    <asp:Button ID="btnAverageSendMail" ClientIDMode="Static" runat="server" OnClick="btnExaportAverage_Click"  Width="150px" CssClass="button_new orange" Text="Send Mail" ValidationGroup="SendMail" Style="display: none;" />
                                </div>
                            </ContentTemplate>
                        </telerik:RadWindow>
      <div>
          <div style="width:28%; float:left; margin-right:2%; margin-top:3%;">
              <telerik:RadGrid ID="gvStatusDetails" runat="server" GroupingSettings-CaseSensitive="False"  AutoGenerateColumns="false" Height="220" Skin="Office2007" >


                <MasterTableView HorizontalAlign="Center" ShowFooter="false" AllowPaging="true" PageSize="100" AllowSorting="true" TableLayout="Fixed">

                  
                  
                    <Columns>
                        <telerik:GridBoundColumn HeaderText="Date" DataField="ScheduleDate" UniqueName="ScheduleDate" SortExpression="ScheduleDate" HeaderStyle-Width="150px" DataFormatString="{0:dd-MMM}">
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Average Time" DataField="AverageLaunchtime"  UniqueName="UniversityPay" SortExpression="AverageTime" AllowFiltering="false" HeaderStyle-Width="100px" />
                        


                    </Columns>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    <FilterItemStyle HorizontalAlign="Center" />
                    <FooterStyle HorizontalAlign="Center" />
                    <AlternatingItemStyle HorizontalAlign="Center" />
                </MasterTableView>
                <ClientSettings>
                    <Scrolling AllowScroll="true" UseStaticHeaders="true" ScrollHeight="220px" SaveScrollPosition="true" FrozenColumnsCount="2"></Scrolling>
                   
                </ClientSettings>
            </telerik:RadGrid>
          </div>
          <div style="width:70%; float:left;margin-top:2%;">
              <div style="text-align:center; font-size:14px;" >
                 
              <div style="float:left; width:350px; margin-left:25%; "><asp:Label ID="lblMsg" runat="server" Font-Bold="true" ></asp:Label></div>
              <div style="float:left; padding-left:4px;"><asp:Label ID="lblMsgval" runat="server" Font-Bold="true" ForeColor="#cc0000" ></asp:Label></div>
                  <div class="clear"></div>
                  </div>
                <telerik:RadHtmlChart runat="server" ID="rptLaunchTime" Style="cursor: pointer;" ForeColor="White" EnableAjaxSkinRendering="True" Height="400px" Width="700px"  EnableTheming="True" >
            <PlotArea>
             <Appearance>
                              <FillStyle BackgroundColor="White"></FillStyle>
                         </Appearance>
            <Series>               

                 <telerik:ColumnSeries DataFieldY="AverageTime"   Name="Minutes" >                   
                      <Appearance>
                     <FillStyle BackgroundColor="#4181CC "></FillStyle>
                     </Appearance>
                    <TooltipsAppearance DataFormatString="AverageTime {0}" Visible="false" />
                    <LabelsAppearance Visible="true" Position="InsideEnd" />
                </telerik:ColumnSeries>
            </Series>
           
            <XAxis DataLabelsField="ScheduleDate" Reversed="false"  MajorTickType="Outside" MinorTickType="None">
                <LabelsAppearance RotationAngle="-75" DataFormatString="dd-MMM" ></LabelsAppearance>
                <TitleAppearance Text="Date" Position="Center" />
                <MinorGridLines Visible="false" />
                <MajorGridLines Visible="false" />
            </XAxis>
            <YAxis  Step="1.00" MinValue="0.00">
                <LabelsAppearance DataFormatString="{0}" />
            <TitleAppearance Text="Minutes"/>
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
              </div>
            
          </div>
          
          <div class="clear"></div>
      </div>     

        
        <canvas id="canvas" Height="700px" Width="600px" style="display: none;"></canvas>

       

        </div>
        <div class="clear"></div>      

        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="" Transparency="30" BackgroundPosition="Center" CssClass="shift_load">
           <div  style="text-align: center; background-color: White; position: absolute;top: 50%;left: 50%; margin: -50px 0px 0px -50px;">
                  
                    <asp:Image ID="ImgLoader" runat="server" ImageUrl="~/Images/Loader.gif" Width="56"
                        Height="56" />
                </div>
        </telerik:RadAjaxLoadingPanel>
  </asp:Content>

        



<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="ExamView.aspx.cs"
    Inherits="SecureProctor.Proctor.ExamView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="shortcut icon" href="../Images/secureproctor.ico" />
    <link href="../CSS/ApplicationStyleSheet.css" type="text/css" rel="Stylesheet" />
    <title>Examity :: Identity Validation</title>
    <link href="../CSS/Proctor_Styles.css" type="text/css" rel="Stylesheet" />
    <script language="javascript" type="text/javascript">
        function openwin(id) {
            alert(id);
            window.open(id, "");
        }
    </script>
    <link rel="stylesheet" href="../js/themes/base/jquery.ui.all.css" />
    <style type="text/css">
        .hidevalidate
        {
            visibility: hidden;
        }
        #wrapper
        {
            margin: 0 auto;
            position: relative;
            width: 250px;
            height: 200px;
        }
        
        #subscribers
        {
            position: relative;
            width: 100%;
            height: 100%;
            z-index: 1;
        }
        
        #myCamera
        {
            position: absolute;
            width: 80px;
            height: 60px;
            z-index: 10;
            bottom: 1px;
            left: 1px;
        }
        
        #subscribers object, #myCamera object
        {
            width: 100%;
            height: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajax:ToolkitScriptManager>
    <script type="text/javascript">
        function ValidateIdentity(status) {
            var transID = '<%= Request.QueryString["TransID"].ToString()%>';
            $.post('AjaxResponse.aspx', { Method: "StudentIdentity", TransID: transID, Status: status }, function (data) { alert('Student validated successfully'); });
        }


        function submitProctorResponse() {
            var transID = '<%= HttpUtility.UrlEncode(Request.QueryString["TransID"].ToString())%>';


            var radio = document.getElementsByName('<%= rdApprove.ClientID %>');
            var selectedvalue;
            for (var j = 0; j < radio.length; j++) {
                if (radio[j].checked) {
                    selectedvalue = radio[j].value;
                    break;
                }
            }
            $.post('AjaxResponse.aspx', { Method: "ProctorSubmitTransaction", TransID: transID, Selectedvalue: selectedvalue },
             function (data) {
                 if (data == "1") {
                     alert('Exam approved successfully.');
                     window.close();
                 }
                 else if (data == "2") {
                     alert('Exam has been already completed, please approve for auditor action');
                     window.close();
                 }
                 else if (data == "4") {
                     alert('Exam is incomplete');
                     window.close();
                 }
                 else if (data == "5") {
                     alert('Exam is still in progress');
                 }
             });
        }

        //         function CheckExamFile() {
        //             var transID = '<%= Request.QueryString["TransID"].ToString()%>';
        //             $.post('AjaxResponse.aspx', { Method: "ExamFile", TransID: transID },
        //             function (data) {
        //                 if (data == "2") {
        //                     alert('File doesnot exist.');
        //                 }
        //             });
        //         }


    </script>
    <div id="application_container">
        <div class="container_inner">
            <div class="login_new1">
                <table cellpadding="2" cellspacing="2" width="100%">
                    <tr>
                        <td colspan="3">
                            <%--<div>--%>
                            <table cellpadding="2" cellspacing="0" width="100%">
                                <tr>
                                    <td width="500" align="center" valign="middle" >
                                        <asp:LinkButton ID="lnk" runat="server" Text="Exam Session link"></asp:LinkButton>
                                    </td>
                                    <td width="450" align="right" valign="middle" >
                                        <asp:RadioButtonList ID="rdApprove" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="0">Approve</asp:ListItem>
                                            <asp:ListItem Value="1">Close exam on behalf of student</asp:ListItem>
                                            <asp:ListItem Value="2">Incomplete</asp:ListItem>
                                        </asp:RadioButtonList>
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                    <td width="100" align="right" valign="top">
                                        <input type="button" value="Submit" onclick="submitProctorResponse()">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="z-index: 999px; border: solid 1px #ccc; padding: 8px; box-shadow: rgba(0,0,0,0.1) 0px 0px 10px 5px /* spread */ inset;
                            width: 65%;">
                            <div id="hideDiv">
                                <div style="padding: 0px;">
                                    <asp:UpdatePanel ID="upExamView" runat="server">
                                        <ContentTemplate>
                                            <ajax:TabContainer ID="tbcExistingExamDetails" runat="server" Height="156" Width="100%"
                                                ActiveTabIndex="0" OnDemand="true" AutoPostBack="false" TabStripPlacement="Top"
                                                ScrollBars="Vertical" UseVerticalStripPlacement="false" VerticalStripWidth="100px"
                                                CssClass="ajax__myTab">
                                                <ajax:TabPanel ID="tbpNotes" runat="server">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblNotes" Text="Exam Notes" runat="server"></asp:Label></HeaderTemplate>
                                                    <ContentTemplate>
                                                        <table width="100%">
                                                            <tr>
                                                                <td>
                                                                    <telerik:RadGrid ID="gvStudentNotes" runat="server" OnNeedDataSource="gvStudentNotes_NeedDataSource"
                                                                        AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" Skin="<%$ Resources:SecureProctor,Telerik_Grid_Skin %>"
                                                                        CellSpacing="0" GridLines="None" PageSize="2" Width="99%">
                                                                        <GroupingSettings CaseSensitive="false" />
                                                                        <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD">
                                                                            <NoRecordsTemplate>
                                                                                No records to display.
                                                                            </NoRecordsTemplate>
                                                                            <Columns>
                                                                                <telerik:GridBoundColumn DataField="NoteID" HeaderText="<%$ Resources:SecureProctor,Common_NoteID %>"
                                                                                    SortExpression="NoteID" UniqueName="NoteID" HeaderStyle-HorizontalAlign="Center">
                                                                                    <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                                                    <HeaderStyle Font-Bold="true" />
                                                                                </telerik:GridBoundColumn>
                                                                                <telerik:GridBoundColumn DataField="NoteDesc" HeaderText="<%$ Resources:SecureProctor,Common_NoteDesc %>"
                                                                                    SortExpression="NoteDesc" UniqueName="NoteDesc" HeaderStyle-HorizontalAlign="Center">
                                                                                    <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                                                    <HeaderStyle Font-Bold="true" />
                                                                                </telerik:GridBoundColumn>
                                                                            </Columns>
                                                                            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                                                        </MasterTableView>
                                                                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                                                        <FilterMenu EnableImageSprites="False">
                                                                        </FilterMenu>
                                                                    </telerik:RadGrid>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </ajax:TabPanel>
                                                <ajax:TabPanel ID="TabPanel1" runat="server">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="Label1" Text="Exam Details" runat="server"></asp:Label></HeaderTemplate>
                                                    <ContentTemplate>
                                                        <table width="100%">
                                                            <tr>
                                                                <td width="200">
                                                                    <div align="center">
                                                                        <p>
                                                                            <strong>Student ID </strong>&nbsp;<img src="../Images/identity.png" id="imgValidate"
                                                                                border="0" onclick="ValidateIdentity(1);" style="cursor: pointer;" /></p>
                                                                        <asp:Image ID="img" runat="server" Width="160" />
                                                                        <br />
                                                                    </div>
                                                                </td>
                                                                <td valign="top">
                                                                    <table width="100%" cellpadding="2" cellspacing="0" style="font-size: 10px;">
                                                                        <tr class="gridviewAlternatestyle1">
                                                                            <td>
                                                                                &nbsp;&nbsp;&nbsp;<strong>Exam ID</strong>
                                                                            </td>
                                                                            <td>
                                                                                :
                                                                                <asp:Label ID="lblTransactionID" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                &nbsp;&nbsp;&nbsp;<strong>Course Name</strong>
                                                                            </td>
                                                                            <td>
                                                                                :
                                                                                <asp:Label ID="lblCourseName" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr class="gridviewRowstyle1">
                                                                            <td>
                                                                                &nbsp;&nbsp;&nbsp;<strong>Exam Name</strong>
                                                                            </td>
                                                                            <td>
                                                                                :
                                                                                <asp:Label ID="lblExamName" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                &nbsp;&nbsp;&nbsp;<strong>Exam Date</strong>
                                                                            </td>
                                                                            <td>
                                                                                :
                                                                                <asp:Label ID="lblDAte" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr class="gridviewAlternatestyle1">
                                                                            <td>
                                                                                &nbsp;&nbsp;&nbsp;<strong>Start Date</strong>
                                                                            </td>
                                                                            <td>
                                                                                :
                                                                                <asp:Label ID="lblSlot" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                &nbsp;&nbsp;&nbsp;<strong>End Date</strong>
                                                                            </td>
                                                                            <td>
                                                                                :
                                                                                <asp:Label ID="lblEndTime" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr class="gridviewRowstyle1">
                                                                            <td>
                                                                                &nbsp;&nbsp;&nbsp;<strong>Exam Duration</strong>
                                                                            </td>
                                                                            <td>
                                                                                :
                                                                                <%--<asp:Label ID="lblH" runat="server" Text="HH"></asp:Label>                                                                                
                                                                                <asp:Label ID="lblM" runat="server" Text="MM"></asp:Label>--%>
                                                                                <asp:Label ID="lblDuration" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                &nbsp;&nbsp;&nbsp;<strong>Instructor Name</strong>
                                                                            </td>
                                                                            <td>
                                                                                :
                                                                                <asp:Label ID="lblExamProviderName" runat="server"></asp:Label>&nbsp;&nbsp;[<asp:Label
                                                                                    ID="lblExamProviderEmailAddress" runat="server"></asp:Label>]
                                                                            </td>
                                                                        </tr>
                                                                        <tr class="gridviewAlternatestyle1">
                                                                            <td>
                                                                                &nbsp;&nbsp;&nbsp;<strong>Tools</strong>
                                                                            </td>
                                                                            <td>
                                                                                :
                                                                                <asp:Label ID="lblTools" runat="server" Text="<%$ Resources:ResMessages,Student_ExamDetConfirmNoTools %>"></asp:Label>
                                                                                <asp:Image ID="imgCalc" runat="server" Height="50px" ImageUrl="~/Images/ImgCalc.png" />
                                                                                &nbsp;&nbsp;
                                                                                <asp:Image ID="imgStickyNotes" runat="server" ImageUrl="~/Images/Imgstickynote.png"
                                                                                    Height="50px" />
                                                                            </td>
                                                                            <td>
                                                                                &nbsp;&nbsp;&nbsp;<strong>Special Accommodations</strong>
                                                                            </td>
                                                                            <td>
                                                                                :
                                                                                <asp:Label ID="lblSpecialNeeds" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr class="gridviewRowstyle1">
                                                                            <td>
                                                                                &nbsp;&nbsp;&nbsp;<strong>Phone #</strong>
                                                                            </td>
                                                                            <td>
                                                                                :
                                                                                <asp:Label ID="lblPhoneNumber" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td align="left">
                                                                                &nbsp;&nbsp;&nbsp;<strong>Comments</strong>
                                                                            </td>
                                                                            <td>
                                                                                :
                                                                                <asp:Label ID="lblComments" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr class="gridviewAlternatestyle1">
                                                                            <td>
                                                                                &nbsp;&nbsp;&nbsp;<strong>Exam Link</strong>
                                                                            </td>
                                                                            <td colspan="3">
                                                                                :
                                                                                <asp:Label ID="lblExamLink" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr class="gridviewRowstyle1">
                                                                            <td>
                                                                                &nbsp;&nbsp;&nbsp;<strong>Exam File</strong>
                                                                            </td>
                                                                            <td colspan="3">
                                                                                :
                                                                                <asp:LinkButton ID="lnkProviderFile" runat="server" ForeColor="Blue" Font-Underline="true"
                                                                                    OnClick="lnkFile_Click"></asp:LinkButton>
                                                                                <asp:Label ID="lblError" runat="server" Visible="false"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </ajax:TabPanel>
                                                <ajax:TabPanel ID="tbpComments" runat="server">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblHeaderComments" Text="Proctor Comments" runat="server"></asp:Label></HeaderTemplate>
                                                    <ContentTemplate>
                                                        <asp:UpdatePanel ID="upStudentView" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <table width="100%" cellpadding="0" cellspacing="2">
                                                                    <tr>
                                                                        <td align="center" colspan="2" width="50%" valign="top">
                                                                            <telerik:RadGrid ID="gvComments" runat="server" OnNeedDataSource="gvComments_NeedDataSource"
                                                                                AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" Skin="<%$ Resources:SecureProctor,Telerik_Grid_Skin %>"
                                                                                CellSpacing="0" GridLines="None" PageSize="2" Font-Size="9px">
                                                                                <GroupingSettings CaseSensitive="false" />
                                                                                <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD">
                                                                                    <Columns>
                                                                                        <telerik:GridTemplateColumn HeaderText="<%$ Resources:SecureProctor,Common_Flag %>"
                                                                                            HeaderStyle-HorizontalAlign="Center" DataField="FlagImage" SortExpression="FlagImage"
                                                                                            UniqueName="FlagImage" AllowFiltering="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Image ID="imgFlag" runat="server" ImageUrl='<%# Eval("FlagImage")%>' />
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                                                            <HeaderStyle Font-Bold="true" />
                                                                                        </telerik:GridTemplateColumn>
                                                                                        <telerik:GridBoundColumn DataField="Comments" HeaderText="<%$ Resources:SecureProctor,Common_Comments %>"
                                                                                            SortExpression="Comments" UniqueName="Comments" HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                                                            <HeaderStyle Font-Bold="true" />
                                                                                        </telerik:GridBoundColumn>
                                                                                              <telerik:GridBoundColumn DataField="CommentTime" HeaderText="<%$ Resources:SecureProctor,Common_CommentTime %>"
                                                    SortExpression="CommentTime" UniqueName="Comments" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                    <HeaderStyle Font-Bold="true" />
                                                </telerik:GridBoundColumn>

                                                                                        <telerik:GridBoundColumn DataField="AddedBy" HeaderText="<%$ Resources:SecureProctor,Common_AddedBy %>"
                                                                                            SortExpression="AddedBy" UniqueName="AddedBy" HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                                                            <HeaderStyle Font-Bold="true" />
                                                                                        </telerik:GridBoundColumn>
                                                                                        <telerik:GridBoundColumn DataField="AddedOn" HeaderText="<%$ Resources:SecureProctor,Common_AddedOn %>"
                                                                                            SortExpression="AddedOn" UniqueName="AddedOn" HeaderStyle-HorizontalAlign="Center">
                                                                                            <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                                                            <HeaderStyle Font-Bold="true" />
                                                                                        </telerik:GridBoundColumn>
                                                                                    </Columns>
                                                                                    <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                                                                </MasterTableView>
                                                                                <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                                                                <FilterMenu EnableImageSprites="False">
                                                                                </FilterMenu>
                                                                            </telerik:RadGrid>
                                                                        </td>
                                                                        <td valign="top" width="49%">
                                                                            <table align="center" width="100%" style="font-size: 10px;">
                                                                                <tr>
                                                                                    <td colspan="2">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2">
                                                                                        <telerik:RadComboBox ID="ddlAlerts" runat="server" Skin="Web20" Width="300" OnSelectedIndexChanged="ddlAlerts_SelectedIndexChanged"
                                                                                            AutoPostBack="true">
                                                                                        </telerik:RadComboBox>
                                                                                        <br />
                                                                                        <br />
                                                                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidatorddlAlerts" InitialValue="--Please select--"
                                                                                            Display="Dynamic" ControlToValidate="ddlAlerts" ValidationGroup="Add" ErrorMessage="Please select valid response" />
                                                                                        <telerik:RadTextBox ID="txtComments" runat="server" MaxLength="500" TextMode="MultiLine"
                                                                                            CssClass="td_input" Width="100%">
                                                                                        </telerik:RadTextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="<%$ Resources:ResMessages,Proctor_CommentsMandate %>"
                                                                                            ControlToValidate="txtComments" CssClass="hidevalidate" ForeColor="Red" ValidationGroup="Add"></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left" colspan="2">
                                                                                        <table width="100%" cellpadding="2" cellspacing="2">
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:RadioButton ID="rdAlert" Text="&nbsp;&nbsp;" runat="server" Checked="true" GroupName="flag" />
                                                                                                    <img src="../Images/ImgAlert.png" title="Alert">&nbsp;&nbsp;Alert</img>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:RadioButton ID="rdGreen" runat="server" Checked="true" GroupName="flag" Text="&nbsp;&nbsp;" />
                                                                                                    <img src="../Images/flag_g.png" title="Green" />&nbsp;&nbsp;No Violation&nbsp;&nbsp;
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:RadioButton ID="rdOrange" runat="server" GroupName="flag" Text="&nbsp;&nbsp;" />
                                                                                                    <img src="../Images/flag_y.png" title="Orange" />&nbsp;&nbsp;Possible Violation&nbsp;&nbsp;
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:RadioButton ID="rdRed" runat="server" GroupName="flag" Text="&nbsp;&nbsp;" />
                                                                                                    <img src="../Images/flag.png" title="Red" />&nbsp;&nbsp;Violation
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                        <telerik:RadButton ID="btnAddComments" runat="server" OnClick="btnAddComments_Click"
                                                                                            Skin="Web20" Text="<%$ Resources:SecureProctor,Common_Add %>" ValidationGroup="Add"
                                                                                            Width="80">
                                                                                        </telerik:RadButton>
                                                                                        &nbsp;&nbsp;&nbsp;
                                                                                        <telerik:RadButton ID="btnClear" runat="server" OnClick="btnClear_Click" Skin="Web20"
                                                                                            Text="<%$ Resources:SecureProctor,Common_Clear%>" Width="80">
                                                                                        </telerik:RadButton>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="btnAddComments" EventName="Click" />
                                                            </Triggers>
                                                        </asp:UpdatePanel>
                                                    </ContentTemplate>
                                                </ajax:TabPanel>
                                                <ajax:TabPanel ID="TabPanel2" runat="server">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="Label2" Text="Proctor Review" runat="server"></asp:Label></HeaderTemplate>
                                                    <ContentTemplate>
                                                        <asp:UpdatePanel ID="upimg" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <table width="100%">
                                                                    <tr class="gridviewAlternatestyle">
                                                                        <td align="left">
                                                                            <asp:CheckBox ID="chkcam" runat="server" Text="Cam" TextAlign="Right" />
                                                                        </td>
                                                                        <td align="right">
                                                                            Operating System
                                                                        </td>
                                                                        <td align="left">
                                                                            &nbsp;<telerik:RadComboBox ID="ddlOs" runat="server" Width="170" Skin="<%$ Resources:SecureProctor,Telerik_ComboBox_Skin %>">
                                                                                <Items>
                                                                                    <telerik:RadComboBoxItem Text="-- Select OS --" Value="0" />
                                                                                    <telerik:RadComboBoxItem Text="Windows XP" Value="1" />
                                                                                    <telerik:RadComboBoxItem Text="Windows Vista" Value="2" />
                                                                                    <telerik:RadComboBoxItem Text="Windows 7" Value="3" />
                                                                                    <telerik:RadComboBoxItem Text="Windows 8" Value="4" />
                                                                                    <telerik:RadComboBoxItem Text="Mac OS X" Value="5" />
                                                                                </Items>
                                                                            </telerik:RadComboBox>
                                                                        </td>
                                                                        <%--<td align="left">
                                                                                        
                                                                                    </td>--%>
                                                                    </tr>
                                                                    <tr class="gridviewRowstyle">
                                                                        <td align="left">
                                                                            <asp:CheckBox ID="chkaudio" runat="server" Text="Audio" TextAlign="Right" />
                                                                        </td>
                                                                        <td align="right">
                                                                            Browser
                                                                        </td>
                                                                        <td align="left">
                                                                            &nbsp;<telerik:RadComboBox ID="ddlBrowser" runat="server" Width="170" Skin="<%$ Resources:SecureProctor,Telerik_ComboBox_Skin %>">
                                                                                <Items>
                                                                                    <telerik:RadComboBoxItem Text="-- Select Browser --" Value="0" />
                                                                                    <telerik:RadComboBoxItem Text="IE 8" Value="1" />
                                                                                    <telerik:RadComboBoxItem Text="IE 9" Value="2" />
                                                                                    <telerik:RadComboBoxItem Text="IE 10" Value="3" />
                                                                                    <telerik:RadComboBoxItem Text="Firefox 20.0" Value="4" />
                                                                                    <telerik:RadComboBoxItem Text="Firefox 21.0" Value="5" />
                                                                                    <telerik:RadComboBoxItem Text="Chrome 20.0" Value="6" />
                                                                                    <telerik:RadComboBoxItem Text="Chrome 21.0" Value="7" />
                                                                                    <telerik:RadComboBoxItem Text="Safari 5.0" Value="8" />
                                                                                </Items>
                                                                            </telerik:RadComboBox>
                                                                        </td>
                                                                        <%--<td align="left">
                                                                                        
                                                                                    </td>--%>
                                                                    </tr>
                                                                    <tr class="gridviewAlternatestyle">
                                                                        <td align="left">
                                                                            <asp:CheckBox ID="chkdesktop" runat="server" Text="Desktop" TextAlign="Right" />
                                                                        </td>
                                                                        <td align="right" valign="top">
                                                                            Upload Image
                                                                        </td>
                                                                        <td align="left">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td align="left" style="width: 30%">
                                                                                        <telerik:RadAsyncUpload runat="server" ID="ScreenshotFileUpload" AllowedFileExtensions="jpg,jpeg,png,gif"
                                                                                            MaxFileSize="524288" Skin="Web20" MultipleFileSelection="Disabled" MaxFileInputsCount="1"
                                                                                            Localization-Select="Upload" Width="270px">
                                                                                        </telerik:RadAsyncUpload>
                                                                                    </td>
                                                                                    <td align="left" valign="top" style="width: 70%">
                                                                                        <asp:LinkButton ID="lnlFile" runat="server" OnClick="lnlFile_Click" Font-Underline="true"></asp:LinkButton><asp:ImageButton
                                                                                            ID="imgCancel" runat="server" ImageUrl="~/Images/cancel_icon.png" Visible="false"
                                                                                            OnClick="lnkCancel_Click" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="gridviewRowstyle">
                                                                        <td valign="top">
                                                                            <asp:CheckBox ID="chkvalidid" runat="server" Text="ID Valid" TextAlign="Right" />
                                                                        </td>
                                                                        <td align="right" valign="top">
                                                                            Additional Comments
                                                                        </td>
                                                                        <td align="left" valign="top">
                                                                            &nbsp;<telerik:RadTextBox ID="txtProctorComments" runat="server" TextMode="MultiLine"
                                                                                Skin="Web20" Width="380px">
                                                                            </telerik:RadTextBox>
                                                                        </td>
                                                                        <%--<td colspan="1" align="left">
                                                                                        
                                                                                    </td>--%>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4" align="center">
                                                                            <telerik:RadButton ID="btnSaveImage" runat="server" Skin="Web20" Text="Save" OnClick="btnSaveImage_Click">
                                                                            </telerik:RadButton>
                                                                            &nbsp;&nbsp;<asp:Label ID="lblfileupload" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="btnSaveImage" EventName="Click" />
                                                                <asp:AsyncPostBackTrigger ControlID="imgCancel" EventName="Click" />
                                                            </Triggers>
                                                        </asp:UpdatePanel>
                                                    </ContentTemplate>
                                                </ajax:TabPanel>
                                            </ajax:TabContainer>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
                <div class="clear">
                </div>
            </div>
        </div>
    </div>
    <div style="width: 184px; height: 46px; z-index: 99; position: fixed; left: 0px;
        top: 0px;">
    </div>
    </form>
</body>
</html>

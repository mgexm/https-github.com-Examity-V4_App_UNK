<%@ Page Title="" Language="C#" MasterPageFile="~/Proctor/Proctor1.Master" AutoEventWireup="true"
    CodeBehind="ProctorExamView.aspx.cs" Inherits="SecureProctor.Proctor.ProctorExamView" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register TagPrefix="uc" TagName="rules" Src="~/Rules.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ProctorContent" runat="server">

    <link rel="stylesheet" href="https://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    <script src="../js/jquery-1.9.1.js"></script>
    <script src="../js/jquery-ui.js"></script>
    <script src="../Scripts/clipboard.min.js"></script>
    <script type="text/javascript">
        var transID = '<%= HttpUtility.UrlEncode(Request.QueryString["TransID"].ToString())%>';

        function ValidateIdentity(status) {
            var txt;
            var r = confirm("Are you sure. You want to validate.");
            if (r == true) {
                var transID = '<%= Request.QueryString["TransID"].ToString()%>';
                $.post('AjaxResponse.aspx',
                    { Method: "StudentIdentity", TransID: transID, Status: status },
                    function (data) {
                        if (data == "1") {
                            alert('Student validated successfully');
                        }
                    });
            }
        }

        function Override(status) {
            var r = confirm("Confirm authentication override " + status + ' ® ' + "?");
            if (r == true) {
                return true;
            }
            else {
                return false;
            }
        }
        function confirmation() {
            if (confirm("Are you sure you want to complete the exam?"))
                return true;
            else return false;
        }
        function lOCKconfirmation() {
            if (confirm("Are you sure you want to enable examiLOCK?"))
                return true;
            else return false;
        }

        function submitProctorResponse() {

            var radio1 = document.getElementById('<%= rdApprove_0.ClientID %>');

            var radio3 = document.getElementById('<%= rdApprove_2.ClientID %>');

            var selectedvalue;


            if (radio1.checked)
                selectedvalue = 0;
                //else if (radio2.checked)
                //    selectedvalue = 1;
            else if (radio3.checked)
                selectedvalue = 2;




            $.post('AjaxResponse.aspx', { Method: "ProctorSubmitTransaction", TransID: transID, Selectedvalue: selectedvalue },
             function (data) {
                 if (data == "1") {

                     alert('Exam approved successfully.');

                     var url = 'ValidateStudentIdentity.aspx';
                     window.location.href = url;
                 }
                 else if (data == "2") {
                     alert('Exam has been already completed, please approve for auditor action');

                 }
                 else if (data == "4") {
                     alert('Exam is incomplete');

                     var url = 'ValidateStudentIdentity.aspx';
                     window.location.href = url;

                 }
                 else if (data == "5") {
                     alert('Exam is still in progress');
                 }
             });
        }

        var WebExMeetingUrl = "";
        function CreateWebExMeetingSession(method) {
            $("#WebExDialogBg").show();
            $("#WebExDialog").dialog({
                modal: true,
                width: 550
            });

            $.post('AjaxResponse.aspx', { Method: method, TransID: transID },
                function (data) {
                    if (data == "ERROR") {
                        $('#<%= lblInfo.ClientID%>').html("Error while creating the meeting request.<u><a  href='#' onclick='openMeeting();'>Click here</a></u>");
                        $("#WebExDialogBg").hide();
                        $($("#WebExDialog")).dialog("close");
                    }
                    else if (data == "INVALID") {
                        $('#<%= lblInfo.ClientID%>').html("Invalid Meeting Credentials <u><a  href='#' onclick='openMeeting();'>Click here</a></u>.Please try again.");
                        $("#WebExDialogBg").hide();
                        $($("#WebExDialog")).dialog("close");
                    }
                    else {
                        if (method == "ResetGotoMeetingSession") {
                            $('#<%= lnkStudentIDCheck.ClientID%>').css("display", "inline");
                            $('#<%= lblStudentCheck.ClientID%>').hide();
                        }

                        WebExMeetingUrl = data;
                        $('#startWebExLink').html("<a style='color:#275F95;font-weight:bold;text-decoration:underline;' href='#' onclick='startWebExMeeting();'>Start WebEx Meeting</a>");
                    }
                });
        }

        var gotoMeetingUrl = "";
        function CreateGotoMeetingSession(method) {
            $("#GTMDialogBg").show();
            $("#GTMDialog").dialog({
                modal: true,
                width: 550
            });

            $.post('AjaxResponse.aspx', { Method: method, TransID: transID },
                function (data) {
                    if (data == "ERROR") {
                        $('#<%= lblInfo.ClientID%>').html("Error while creating the meeting request.<u><a  href='#' onclick='openMeeting();'>Click here</a></u>");
                        $("#GTMDialogBg").hide();
                        $($("#GTMDialog")).dialog("close");
                    }
                    else if (data == "INVALID") {
                        $('#<%= lblInfo.ClientID%>').html("Invalid Meeting Credentials <u><a  href='#' onclick='openMeeting();'>Click here</a></u>.Please try again.");
                        $("#GTMDialogBg").hide();
                        $($("#GTMDialog")).dialog("close");
                    }
                    else {
                        if (method == "ResetGotoMeetingSession") {
                            $('#<%= lnkStudentIDCheck.ClientID%>').css("display", "inline");
                            $('#<%= lblStudentCheck.ClientID%>').hide();
                        }

                        gotoMeetingUrl = data;
                        $('#startGTMLink').html("<a style='color:#275F95;font-weight:bold;text-decoration:underline;' href='#' onclick='startGotoMeeting();'>Start GOTO Meeting</a>");
                    }
                });
        }

        function openMeeting() {


            window.open("GotoMeeting.aspx", "Session", "width=400,height=200,top=250,left=400,toolbars=no,scrollbars=yes,status=no,resizable=yes");
            $('#<%= lblInfo.ClientID%>').hide();

        }

        function startGotoMeeting() {
            $("#GTMDialogBg").hide();
            $($("#GTMDialog")).dialog("close");
            window.open(gotoMeetingUrl, '_blank', 'width=200,height=100');
        }

        function startWebExMeeting() {
            $("#WebExDialogBg").hide();
            $($("#WebExDialog")).dialog("close");
            window.open(WebExMeetingUrl, '_blank', 'width=200,height=100');
        }

        //Zoom meeting start
        var zoomMeetingUrl = "";
        function CreateZoomMeetingSession(method) {
            $("#ZoomDialogBg").show();
            $("#ZoomDialog").dialog({
                modal: true,
                width: 550
            });

            $.post('AjaxResponse.aspx', { Method: method, TransID: transID },
                function (data) {
                    if (data == "ERROR") {
                        $('#<%= lblInfo.ClientID%>').html("Error while creating the meeting request.<u><a  href='#' onclick='openMeeting();'>Click here</a></u>");
                        $("#ZoomDialogBg").hide();
                        $($("#ZoomDialog")).dialog("close");
                    }
                    else if (data == "INVALID") {
                        $('#<%= lblInfo.ClientID%>').html("Invalid Meeting Credentials <u><a  href='#' onclick='openMeeting();'>Click here</a></u>.Please try again.");
                        $("#ZoomDialogBg").hide();
                        $($("#ZoomDialog")).dialog("close");
                    }
                    else {
                        if (method == "ResetZoomMeetingSession") {
                            $('#<%= lnkStudentIDCheck.ClientID%>').css("display", "inline");
                            $('#<%= lblStudentCheck.ClientID%>').hide();
                        }

                        zoomMeetingUrl = data;
                        $('#startZoomLink').html("<a style='color:#275F95;font-weight:bold;text-decoration:underline;' href='#' onclick='startZoomMeeting();'>Start Zoom Meeting</a>");
                    }
                });
        }
        function startZoomMeeting() {
            $("#ZoomDialogBg").hide();
            $($("#ZoomDialog")).dialog("close");
            window.open(zoomMeetingUrl, '_blank', 'width=200,height=100');
        }

        //Zoom meeting end
        $(document).ready(function () {
            /*Copy the meeting id to clipboard*/
            new Clipboard('#btnCopySessionID', {
                text: function (trigger) {
                    return (document.getElementById('<%=lblExamSessionID.ClientID%>').innerText)
                }
            });

            new Clipboard('#imgCopyJoinURL', {
                text: function (trigger) {
                    return (document.getElementById('<%=lblExamSessionURL.ClientID%>').innerText)
                }
            });


        });


            //Examity Meeting Start

            var examityMeetingApiURL = '<%= System.Configuration.ConfigurationManager.AppSettings["ExamityMeetingService_URL"].ToString() %>';

        function startExamityMeeting(method) {
            var TransID = '<%= HttpUtility.UrlEncode(Request.QueryString["TransID"].ToString()) %>';
          var ClientID = '<%= System.Configuration.ConfigurationManager.AppSettings["ExamityMeeting_ClientID"].ToString() %>';
          var ProctorID = '<%= Session["UserID"].ToString() %>';

          $.post(examityMeetingApiURL, { Method: method, TransID: TransID, ClientID: ClientID, ProctorID: ProctorID },
                function (data) {
                    if (data == "Success") {

                        if (method == "ResetExamityMeetingSession") {
                            $('#<%= lnkStudentIDCheck.ClientID%>').css("display", "inline");
                            $('#<%= lblStudentCheck.ClientID%>').hide();
                        }
                        //  $('#startExamityLink').html("Examity Meeting is generated successfully.");

                        setTimeout(function () {
                            $("#ExamityMeetingBG").hide();
                            $($("#ExamityMeeting")).dialog("close");
                        }, 1000);
                    }
                    else {
                        $('#<%= lblInfo.ClientID%>').html("Error while creating the meeting request." + data);
                        setTimeout(function () {
                            $("#ExamityMeetingBG").hide();
                            $($("#ExamityMeeting")).dialog("close");
                        }, 1000);
                    }
                });
            }

            function CreateExamityMeetingSession(method) {
                $("#ExamityMeetingBG").show();
                $("#ExamityMeeting").dialog({
                    modal: true,
                    width: 550
                });
                var methodName = "startExamityMeeting(\'" + method + "\');return false;";

                $('#startExamityLink').html("<a style='color:#275F95;font-weight:bold;text-decoration:underline;' href='#' onclick=" + methodName + ">Start Examity Meeting</a>");

            }
            //Examity Meeting Start
    </script>
    <script type="text/javascript" src="../Scripts/jquery-timer.js"></script>
    <script type="text/javascript">

        var timer =
            $.timer(
                function checkExams() {
                    var transID = '<%= Request.QueryString["TransID"].ToString()%>';
                    $.post('AjaxResponse.aspx', { Method: "ExamStatus", TransID: transID }, function (data) {
                        //alert(data);
                        if (data == "13") {
                            $('#ctl00_ProctorContent_tbcExistingExamDetails_TabPanel1_tdStatus').attr('style', 'background-color:Red;');
                            $('#ctl00_ProctorContent_tbcExistingExamDetails_TabPanel1_lblStatus').text('Exam started');
                        }
                        else if (data == "2") {
                            $('#ctl00_ProctorContent_tbcExistingExamDetails_TabPanel1_tdStatus').attr('style', 'background-color:Orange;');
                            $('#ctl00_ProctorContent_tbcExistingExamDetails_TabPanel1_lblStatus').text('In progress');
                        }
                        else if (data == "3") {
                            $('#ctl00_ProctorContent_tbcExistingExamDetails_TabPanel1_tdStatus').attr('style', 'background-color:Green;');
                            $('#ctl00_ProctorContent_tbcExistingExamDetails_TabPanel1_lblStatus').text('Completed');
                        }
                        else if (data == "15") {
                            $('#ctl00_ProctorContent_tbcExistingExamDetails_TabPanel1_tdStatus').attr('style', 'background-color:Orange;');
                            $('#ctl00_ProctorContent_tbcExistingExamDetails_TabPanel1_lblStatus').text('Waiting for Proctor');
                        }
                        else if (data == "16") {
                            $('#ctl00_ProctorContent_tbcExistingExamDetails_TabPanel1_tdStatus').attr('style', 'background-color:Orange;');
                            $('#ctl00_ProctorContent_tbcExistingExamDetails_TabPanel1_lblStatus').text('Verification in progress');
                        }
                        else if (data == "1") {
                            $('#ctl00_ProctorContent_tbcExistingExamDetails_TabPanel1_tdStatus').attr('style', 'background-color:White;');
                            $('#ctl00_ProctorContent_tbcExistingExamDetails_TabPanel1_lblStatus').text("Exam Scheduled");
                        }
                        else if (data == "0") {
                            $('#ctl00_ProctorContent_tbcExistingExamDetails_TabPanel1_tdStatus').attr('style', 'background-color:Red;');
                            $('#ctl00_ProctorContent_tbcExistingExamDetails_TabPanel1_lblStatus').text("Exam Cancelled");
                        }


                        else {
                            $('#' + trID).attr('style', 'display:none');
                        }
                    });
                },
		1000,
		true
	);
        //timer.set({ time : 3000, autostart : true });
    </script>

    <script type="text/javascript">

        var timer =
            $.timer(
                function checkExams() {
                    var transID = '<%= Request.QueryString["TransID"].ToString()%>';
                    var examityMeetingJoinURL = '<%= System.Configuration.ConfigurationManager.AppSettings["ExamityMeeting_URL"].ToString() %>';
                    $.post('AjaxResponse.aspx', { Method: "GetMeetingID", TransID: transID }, function (data) {
                        if (data != '') {
                            var arr = data.split('~');

                            $('#ctl00_ProctorContent_tbcExistingExamDetails_TabPanel1_tdExamSessionID').attr('style', 'background-color:#fef65b;');
                            $('#ctl00_ProctorContent_tbcExistingExamDetails_TabPanel1_lblExamSessionID').text(arr[1]);
                            $('#ctl00_ProctorContent_tbcExistingExamDetails_TabPanel1_lblProctorName').text(arr[2]);
                            $('#ctl00_ProctorContent_tbcExistingExamDetails_TabPanel1_lblExamSessionURL').text('');
                            if (arr[0] == 'G') {
                                $('#ctl00_ProctorContent_tbcExistingExamDetails_TabPanel1_ImgMeetingType').attr("src", "../Images/ImgIconGotoMeeting.png")
                            }
                            else if (arr[0] == 'E') {
                                $('#ctl00_ProctorContent_tbcExistingExamDetails_TabPanel1_ImgMeetingType').attr("src", "../Images/ImgExamityMeeting.png");
                                $('#ctl00_ProctorContent_tbcExistingExamDetails_TabPanel1_lblExamSessionURL').text(examityMeetingJoinURL + arr[1]);
                            }

                            else if (arr[0] == 'Z') {
                                $('#ctl00_ProctorContent_tbcExistingExamDetails_TabPanel1_ImgMeetingType').attr("src", "../Images/ImgZoomMeeting.png")
                            }
                            else {
                                $('#ctl00_ProctorContent_tbcExistingExamDetails_TabPanel1_ImgMeetingType').attr("src", "../Images/ImgIconWebEx.png")
                            }

                        }
                    });


                    $.post('AjaxResponse.aspx', { Method: "GetBrowserInfo", TransID: transID }, function (data) {
                        if (data != '') {
                            $('#ctl00_ProctorContent_lblBrowser').text(data);
                            if (data == 'Chrome' || data == 'Firefox') {
                                $('#ctl00_ProctorContent_ImgBrowser').attr("src", "../Images/ImgMyProfileyes.png");
                                $('#ctl00_ProctorContent_lblBrowser').attr('style', 'color:Green;');
                            }
                            else {
                                $('#ctl00_ProctorContent_ImgBrowser').attr("src", "../Images/ImgMyProfileno.png");
                                $('#ctl00_ProctorContent_lblBrowser').attr('style', 'color:Red;');
                            }
                        }
                        else {
                            $('#ctl00_ProctorContent_lblBrowser').text('');
                            $('#ctl00_ProctorContent_ImgBrowser').attr("src", "../Images/Examilock_cancel.jpg");
                        }
                    });

                },
		1000,
		true
	);
        //timer.set({ time : 3000, autostart : true });
    </script>

    <script type="text/javascript">

        function showRecordingtime() {

            alert("Lms/Technical help time will be recorded");

        }
    </script>

    <script type="text/javascript">

        var timer =
            $.timer(
                function checkExams() {
                    var transID = '<%= Request.QueryString["TransID"].ToString()%>';
                    $.post('AjaxResponse.aspx', { Method: "ExamiKEYScore", TransID: transID }, function (data) {

                        if (data != '') {

                            //$('#ctl00_ProctorContent_tdexamikey').attr('style', 'background-color:Yellow;');

                            $('#ctl00_ProctorContent_tbcExistingExamDetails_tbpComments_lblKeyScore').text(data + '%');

                        }
                    });
                },
		1000,
		true
	);

    </script>
    <link rel="stylesheet" href="../js/themes/base/jquery.ui.all.css" />
    <style type="text/css">
        .ui-dialog-titlebar-close {
            visibility: hidden;
        }

        .hidevalidate {
            visibility: hidden;
        }

        #wrapper {
            margin: 0 auto;
            position: relative;
            width: 250px;
            height: 200px;
        }

        #subscribers {
            position: relative;
            width: 100%;
            height: 100%;
            z-index: 1;
        }

        #myCamera {
            position: absolute;
            width: 80px;
            height: 60px;
            z-index: 10;
            bottom: 1px;
            left: 1px;
        }

            #subscribers object, #myCamera object {
                width: 100%;
                height: 100%;
            }

        div.wfm-headers > table {
            border: 2px solid #fff;
            font-family: arial;
        }

            div.wfm-headers > table tr td {
                border: 0px solid #fff;
                background-color: #f5f5f5;
                padding: 5px 10px;
                font-size: 12px;
                vertical-align: top;
                text-align: left;
            }

        table.wfm-headers-innertbl tr td {
            padding: 5px 10px;
            text-align: left;
        }

        .wfm-headers-title {
            color: #f90;
            line-height: 30px;
            padding-left: 10px;
        }

        #UpdatePanel3 {
            text-align: left;
        }

        .splLblDisplay {
            padding: 5px 15px;
            text-align: center;
            display: inline-block;
            width: 25px!important;
            height: inherit!important;
        }

        .auto-style1 {
            width: 1%;
        }
    </style>
    <script type="text/javascript">

        function OpenEditComments(ID) {
            radopen("EditComments.aspx?CommentID=" + ID, "Edit Comments", 700, 470);
        }

        function closeWin() {
            var masterTable = $find("<%= gvComments.ClientID %>").get_masterTableView();
            masterTable.rebind();
        }

    </script>
    <AjaxControlToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </AjaxControlToolkit:ToolkitScriptManager>
    <div id="GTMDialogBg" style="display: none; background-color: gray; opacity: 0.5; position: fixed; top: 0px; left: 0px; width: 100%; height: 100%;">
    </div>
    <div id="GTMDialog" title="Examity GOTO Meeting Request" style="display: none; text-align: center;">
        Please wait.. Goto Meeting session is being generated.<br />
        <p id="startGTMLink">
            <img alt="Generating GOTO Meeting Session..." src="../Images/preloader_transparent.gif" />
        </p>
    </div>
    <div id="WebExDialogBg" style="display: none; background-color: gray; opacity: 0.5; position: fixed; top: 0px; left: 0px; width: 100%; height: 100%;">
    </div>
    <div id="WebExDialog" title="Examity WebEx Meeting Request" style="display: none; text-align: center;">
        Please wait.. WebEx Meeting session is being generated.<br />
        <p id="startWebExLink">
            <img alt="Generating WebEx Meeting Session..." src="../Images/preloader_transparent.gif" />
        </p>
    </div>
    <%--Zoom meetings start--%>
    <div id="ZoomDialogBg" style="display: none; background-color: gray; opacity: 0.5; position: fixed; top: 0px; left: 0px; width: 100%; height: 100%;">
    </div>
    <div id="ZoomDialog" title="Examity Zoom Meeting Request" style="display: none; text-align: center;">
        Please wait.. Zoom Meeting session is being generated.<br />
        <p id="startZoomLink">
            <img alt="Generating Zoom Meeting Session..." src="../Images/preloader_transparent.gif" />
        </p>
    </div>
    <%--Zoom meetings end--%>
    <%--Examity meetings start--%>
    <div id="ExamityMeetingBG" style="display: none; background-color: gray; opacity: 0.5; position: fixed; top: 0px; left: 0px; width: 100%; height: 100%;">
    </div>
    <div id="ExamityMeeting" title="Examity Meeting Request" style="display: none; text-align: center;">
        Please wait.. Examity Meeting session is being generated.<br />
        <p id="startExamityLink">
            <img alt="Generating Examity Meeting Session..." src="../Images/preloader_transparent.gif" />
        </p>
    </div>
    <%--Examity meetings end--%>


    <div class="app_container_inner">
        <div class="app_inner_content">
            <table width="100%">
                <tr>
                    <td>
                        <img src="../Images/ProctorView.png" />
                    </td>
                </tr>
                <tr>
                    <td width="100%" align="center" valign="top">
                        <div class="login_new1">

                            <table width="100%" cellpadding="5" cellspacing="5">
                                <tr>
                                    <td valign="middle" align="left" colspan="2">
                                        <asp:UpdatePanel ID="upProc" runat="server">
                                            <ContentTemplate>
                                                <table width="100%">
                                                    <tr>
                                                        <td valign="middle" align="right" width="600">
                                                            <asp:RadioButton ID="rdApprove_0" runat="server" Text="Approve" GroupName="test" />
                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rdApprove_2" runat="server" Text="Incomplete" GroupName="test" />
                                                        </td>
                                                        <td valign="middle" align="left">&nbsp;&nbsp;<input type="button" value="Submit" onclick="submitProctorResponse()" />
                                                        </td>
                                                        <td align="center"></td>
                                                        <td align="right">
                                                            <asp:LinkButton ID="ExamiLockLink" runat="server" Font-Bold="true" Font-Underline="true" OnClick="ExamiLockLink_Click" OnClientClick="return lOCKconfirmation();" Style="display: none;" Text="ExamiLOCK" Visible="false"></asp:LinkButton>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                          <%--      <asp:LinkButton ID="lnkLMSHelp" runat="server" Font-Bold="true" Font-Underline="true" OnClick="lnkLMSHelp_Click" OnClientClick="showRecordingtime();" Text="LMS Help" Visible="false"></asp:LinkButton>
                                                            &nbsp;&nbsp;
                                                                <asp:LinkButton ID="lnkTechnicalHelp" runat="server" Font-Bold="true" Font-Underline="true" OnClick="lnkTechnicalHelp_Click" OnClientClick="showRecordingtime();" Text="Technical Help" Visible="false"></asp:LinkButton>--%>
                                                            &nbsp;&nbsp; <%--Zoom Meetings start--%>
                                                                
                                                                
                                                                </a> <%--Zoom Meetings end--%>


                                                            <div style="display: none">
                                                                <a href="#" onclick="CreateWebExMeetingSession('CreateWebEx');" style="font-weight: bold; text-decoration: underline;">Start</a>&nbsp; <a href="#" onclick="CreateWebExMeetingSession('CreateWebEx');" style="font-weight: bold; text-decoration: underline;">
                                                                    <asp:Image ID="Image2" runat="server" Height="18" ImageAlign="AbsBottom" ImageUrl="~/Images/ImgWebEx.jpg" Width="18" />
                                                                </a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a href="#" onclick="CreateWebExMeetingSession('ResetWebEx');" style="font-weight: bold; text-decoration: underline;">Reset</a>&nbsp; <a href="#" onclick="CreateWebExMeetingSession('ResetWebEx');" style="font-weight: bold; text-decoration: underline;">
                                                                    <asp:Image ID="Image3" runat="server" Height="18" ImageAlign="AbsBottom" ImageUrl="~/Images/ImgWebEx.jpg" Width="18" />
                                                                </a>
                                                            </div>

                                                        </td>
                                                    </tr>
                                                </table>
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td valign="top" style="background-color: #e5e5e5; padding: 10px 20px" width="25%">
                                                            <div style="color: #ff6a00; padding: 5px"><b>Start Exam</b></div>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td width="50%" height="30">
                                                                        <a href="#" onclick="CreateGotoMeetingSession('CreateGotoMeetingSession');" style="text-decoration: underline;">Start</a>&nbsp;
                                                                            <a href="#" onclick="CreateGotoMeetingSession('CreateGotoMeetingSession');">
                                                                                <asp:Image ID="ImgGotoMeeting" runat="server" ImageUrl="~/Images/ImgGotoMeeting.png" Width="18" Height="18" ImageAlign="AbsBottom" /></a>
                                                                    </td>
                                                                    <td>
                                                                        <a href="#" onclick="CreateGotoMeetingSession('ResetGotoMeetingSession');" style="text-decoration: underline;">Reset</a>&nbsp;
                                                                            <a href="#" onclick="CreateGotoMeetingSession('ResetGotoMeetingSession');">
                                                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/ImgGotoMeeting.png" Width="18" Height="18" ImageAlign="AbsBottom" /></a></td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="50%">
                                                                        <a href="#" onclick="CreateZoomMeetingSession('CreateZoomMeetingSession');" style="text-decoration: underline;">Start</a>&nbsp; <a href="#" onclick="CreateZoomMeetingSession('CreateZoomMeetingSession');">
                                                                            <asp:Image ID="Image4" runat="server" AlternateText="Zoom meeting" Height="18" ImageAlign="AbsBottom" ImageUrl="~/Images/ImgZoomMeeting.png" ToolTip="Start" Width="18" />
                                                                    </td>
                                                                    <td height="30">
                                                                        <a href="#" onclick="CreateZoomMeetingSession('ResetZoomMeetingSession');" style="text-decoration: underline;">Reset</a>&nbsp; <a href="#" onclick="CreateZoomMeetingSession('ResetZoomMeetingSession');" style="font-weight: bold; text-decoration: underline;">
                                                                            <asp:Image ID="Image5" runat="server" AlternateText="Zoom meeting" Height="18" ImageAlign="AbsBottom" ImageUrl="~/Images/ImgZoomMeeting.png" ToolTip="Reset" Width="18" />
                                                                        </a>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="50%">
                                                                        <a href="#" onclick="CreateExamityMeetingSession('CreateOpenTokMeeting');" style="text-decoration: underline;">Start</a>&nbsp; <a href="#" onclick="CreateExamityMeetingSession('CreateOpenTokMeeting');">
                                                                            <asp:Image ID="Image6" runat="server" AlternateText="Examity meeting" Height="18" ImageAlign="AbsBottom" ImageUrl="~/Images/ImgExamityMeeting.png" ToolTip="Start" Width="18" />
                                                                    </td>
                                                                    <td height="30">
                                                                        <a href="#" onclick="CreateExamityMeetingSession('ResetOpenTokMeeting');" style="text-decoration: underline;">Reset</a>&nbsp; <a href="#" onclick="CreateExamityMeetingSession('ResetOpenTokMeeting');" style="font-weight: bold; text-decoration: underline;">
                                                                            <asp:Image ID="Image7" runat="server" AlternateText="Examity meeting" Height="18" ImageAlign="AbsBottom" ImageUrl="~/Images/ImgExamityMeeting.png" ToolTip="Reset" Width="18" />
                                                                        </a>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">Browser :&nbsp;&nbsp;
                                                                    <asp:Image ID="ImgBrowser" runat="server" Width="18px" Height="18px" ImageAlign="AbsBottom" ImageUrl="../Images/Examilock_cancel.jpg" />
                                                                        &nbsp;<asp:Label ID="lblBrowser" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>

                                                        </td>
                                                        <td class="auto-style1"></td>
                                                        <td valign="top" style="background-color: #e5e5e5; padding: 10px 20px;" width="38%">
                                                            <div style="color: #ff6a00; padding: 5px"><b>Control Panel</b></div>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td width="50%" valign="top">
                                                                        <span style="display: inline-block; line-height: 30px;">
                                                                            <asp:LinkButton ID="lnkAuthentication" runat="server" Font-Bold="true" Font-Size="12px" Font-Underline="true" OnClick="lnkAuthentication_Click" Text="Authentication started"></asp:LinkButton></span>
                                                                        <span style="font-size: 18px; font-weight: bold; color: red;">*</span>
                                                                        <br />
                                                                        <br />
                                                                        <asp:LinkButton ID="lnkStudentIDCheck" runat="server" Font-Bold="true" Font-Underline="true" OnClick="lnkStudentIDCheck_Click" OnClientClick="ValidateIdentity(1);" Style="display: none;" Text="Student Identity Verification"></asp:LinkButton>
                                                                        <asp:Label ID="lblStudentCheck" runat="server" Font-Bold="true" Style="display: none;" Text="Student Identity Verified"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                            <ContentTemplate>
                                                                                <table width="100%">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="lnkOverrideKNOW" runat="server" Text="Override examiKNOW" OnClick="lnkOverrideKNOW_Click" OnClientClick="return Override('examiKNOW');" Font-Underline="true"></asp:LinkButton>&nbsp;<sup style="font-size: 13px;">®</sup>&nbsp;&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td id="tdOverrideKEY" runat="server" visible="false" height="30">
                                                                                            <asp:LinkButton ID="lnkOverrideKEY" runat="server" Text="Override examiKEY" OnClick="lnkOverrideKEY_Click" OnClientClick="return Override('examiKEY');" Font-Underline="true"></asp:LinkButton>&nbsp;<sup style="font-size: 13px;">®</sup>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td height="30">
                                                                                            <asp:LinkButton ID="lnlExamend" runat="server" Text="Exam Completed" OnClick="lnlExamend_Click" OnClientClick="return confirmation();" Font-Underline="true"></asp:LinkButton>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>



                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>



                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td width="1%"></td>
                                                        <td valign="top" style="background-color: #e5e5e5; padding: 10px 20px" width="38%">
                                                            <div style="color: #ff6a00; padding: 5px"><b>Enable Settings</b></div>

                                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                <ContentTemplate>
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td height="30">
                                                                                <asp:LinkButton ID="lnkNext" runat="server" Text="Enable NEXT Button" Font-Underline="true" OnClick="lnkNext_Click"></asp:LinkButton>
                                                                            </td>
                                                                            <td>
                                                                                <asp:LinkButton ID="lnkStartExam" runat="server" Text="Enable Begin Exam Button" Font-Underline="true" OnClick="lnkStartExam_Click"></asp:LinkButton>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td height="30">
                                                                                <asp:LinkButton ID="lnkProceed" runat="server" Text="Enable Proceed Button" Font-Underline="true" OnClick="lnkProceed_Click"></asp:LinkButton>
                                                                            </td>
                                                                            <td>
                                                                                <asp:LinkButton ID="lnkSurvey" runat="server" Text="Enable Survey Link" OnClick="lnkSurvey_Click" Font-Underline="true"></asp:LinkButton>
                                                                            </td>
                                                                        </tr>
                                                                    </table>

                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>


                                                        </td>
                                                    </tr>
                                                </table>



                                                <caption>
                                                    <asp:Label ID="lblInfo" runat="server"></asp:Label>

                                                </caption>


                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>


                                <%--                        <div>
                            <table width="100%">
                                <tr valign="middle" align="right" width="600">
                                    <td width="10%"><asp:RadioButton ID="rdApprove_0" runat="server" Text="Approve" GroupName="test" /></td>
                                    <td width="10%"><asp:RadioButton ID="rdApprove_2" runat="server" Text="Incomplete" GroupName="test" /></td>
                                    <td width="10%"> <input type="button" value="Submit" onclick="submitProctorResponse()" /></td>
                                   <%-- <td align="right"> <asp:LinkButton ID="lnkLMSHelp" runat="server" Text="LMS Help" OnClick="lnkLMSHelp_Click" Font-Bold="true" Font-Underline="true" OnClientClick="showRecordingtime();" ></asp:LinkButton>&nbsp;&nbsp;
                                                        &nbsp;  |  &nbsp;  <asp:LinkButton ID="lnkTechnicalHelp" runat="server" Text="Technical Help" OnClick="lnkTechnicalHelp_Click" Font-Bold="true" Font-Underline="true" OnClientClick="showRecordingtime();"></asp:LinkButton>&nbsp;&nbsp;</td>--%>
                                <%--         </tr>
                            </table>
                        </div>--%>

                                <%--                        <div class="wfm-headers">
                            <table width="100%">
                                <tr>
                                    <td width="25%">
                                        <div class="wfm-headers-title">Start Exam</div>
                                        <asp:UpdatePanel ID="upProc" runat="server">
                                            <ContentTemplate>
                                                <table width="100%" class="wfm-headers-innertbl">
                                                    <tr>
                                                        <td><a href="#" style="font-weight: bold; text-decoration: underline;" onclick="CreateGotoMeetingSession('CreateGotoMeetingSession');">Start</a>&nbsp;
                                                            <a href="#" style="font-weight: bold; text-decoration: underline;" onclick="CreateGotoMeetingSession('CreateGotoMeetingSession');">
                                                                <asp:Image ID="ImgGotoMeeting" runat="server" ImageUrl="~/Images/ImgGotoMeeting.png" Width="18" Height="18" ImageAlign="AbsBottom" /></a>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                                        <td>
                                                            <a href="#" style="font-weight: bold; text-decoration: underline;" onclick="CreateGotoMeetingSession('ResetGotoMeetingSession');">Reset</a>&nbsp;
                                                            <a href="#" style="font-weight: bold; text-decoration: underline;" onclick="CreateGotoMeetingSession('ResetGotoMeetingSession');">
                                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/ImgGotoMeeting.png" Width="18" Height="18" ImageAlign="AbsBottom" /></a>
                                                        </td>

                                                        <td>
                                                          
                                                        </td>
                                                        <td>
                                                           
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:LinkButton ID="ExamiLockLink" runat="server" Text="ExamiLOCK" Font-Bold="true" Font-Underline="true" Visible="false" OnClick="ExamiLockLink_Click" OnClientClick="return lOCKconfirmation();" Style="display: none;"></asp:LinkButton>
                                                          
                                                           
                                                            <a href="#" style="font-weight: bold; text-decoration: underline;" onclick="CreateWebExMeetingSession('CreateWebEx');">Start</a>&nbsp;
                                                            <a href="#" style="font-weight: bold; text-decoration: underline;" onclick="CreateWebExMeetingSession('CreateWebEx');">
                                                                <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/ImgWebEx.jpg" Width="18" Height="18" ImageAlign="AbsBottom" /></a>
                                                           

                                                        </td>
                                                        <td><a href="#" style="font-weight: bold; text-decoration: underline;" onclick="CreateWebExMeetingSession('ResetWebEx');">Reset</a>&nbsp;
                                                            <a href="#" style="font-weight: bold; text-decoration: underline;" onclick="CreateWebExMeetingSession('ResetWebEx');">
                                                                <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/ImgWebEx.jpg" Width="18" Height="18" ImageAlign="AbsBottom" /></a>
                                                           
                                                        </td>
                                                    </tr>
                                                    <tr> 
                                                        <td>
                                                            <div >
                                                                <asp:Label ID="lblInfo" runat="server" ForeColor="Red"></asp:Label>

                                                            </div>

                                                        </td

                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td width="40%">
                                        <div class="wfm-headers-title">Control Panel</div>
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <table width="100%">
                                                    <tr>
                                                        <td>
                                                            <asp:LinkButton ID="lnkAuthentication" runat="server" Text="Authentication started" Font-Underline="true" OnClick="lnkAuthentication_Click"
                                                                Font-Size="14px" Font-Bold="true"></asp:LinkButton>
                                                            <span style="font-size: 18px; font-weight: bold; color: red;">*</span></td>
                                                        <td>
                                                            <asp:LinkButton ID="lnkOverrideKNOW" runat="server" Text="Override examiKNOW" OnClick="lnkOverrideKNOW_Click" Font-Bold="true" Font-Underline="true" OnClientClick="return Override('examiKNOW');"></asp:LinkButton>&nbsp;<sup style="font-size: 13px;">®</sup>&nbsp;&nbsp;

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>

                                                            <asp:LinkButton ID="lnkStudentIDCheck" runat="server" Text="Student Identity Verification" OnClientClick="ValidateIdentity(1);" OnClick="lnkStudentIDCheck_Click" Style="display: none;"
                                                                Font-Bold="true" Font-Underline="true"></asp:LinkButton>
                                                            <asp:Label ID="lblStudentCheck" runat="server" Text="Student Identity Verified" Font-Bold="true" ForeColor="Green" style="display:none" ></asp:Label>
                                                        </td>
                                                        <td id="tdOverrideKEY" runat="server" visible="false">
                                                            <asp:LinkButton ID="lnkOverrideKEY" runat="server" Text="Override examiKEY" OnClick="lnkOverrideKEY_Click" Font-Bold="true" Font-Underline="true" OnClientClick="return Override('examiKEY');"></asp:LinkButton>&nbsp;<sup style="font-size: 13px;">®</sup>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                        <td>
                                                            <asp:LinkButton ID="lnlExamend" runat="server" Text="Exam Completed" OnClick="lnlExamend_Click" Font-Bold="true" Font-Underline="true" OnClientClick="return confirmation();"></asp:LinkButton></td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                        <div class="wfm-headers-title">Enable Settings</div>
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <table width="100%">
                                                    <tr>
                                                        <td>
                                                            <asp:LinkButton ID="lnkNext" runat="server" Text="Enable NEXT Button" OnClick="lnkNext_Click" Font-Bold="true" Font-Underline="true"></asp:LinkButton></td>
                                                        <td>
                                                            <asp:LinkButton ID="lnkStartExam" runat="server" Text="Enable Begin Exam Button" OnClick="lnkStartExam_Click" Font-Bold="true" Font-Underline="true"></asp:LinkButton></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:LinkButton ID="lnkProceed" runat="server" Text="Enable Proceed Button" OnClick="lnkProceed_Click" Font-Bold="true" Font-Underline="true"></asp:LinkButton></td>
                                                        <td>
                                                            <asp:LinkButton ID="lnkSurvey" runat="server" Text="Enable Survey Link" OnClick="lnkSurvey_Click" Font-Bold="true" Font-Underline="true"></asp:LinkButton></td>
                                                    </tr>

                                                </table>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>


                            </table>
                        </div>--%>
                    </td>
                </tr>
                <tr>
                    <div class="login_new1">
                        <table width="100%" cellpadding="5" cellspacing="5">

                            <tr>
                                <td colspan="2" align="center">


                                    <div id="hideDiv">
                                        <div style="padding: 0px;">
                                            <asp:UpdatePanel ID="upExamView" runat="server">
                                                <ContentTemplate>
                                                    <ajax:TabContainer ID="tbcExistingExamDetails" runat="server" Height="450" Width="100%"
                                                        ActiveTabIndex="0" OnDemand="false" AutoPostBack="false" TabStripPlacement="Top"
                                                        ScrollBars="Vertical" UseVerticalStripPlacement="false" VerticalStripWidth="200px"
                                                        CssClass="ajax__myTab">
                                                        <ajax:TabPanel ID="TabPanel1" runat="server">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="Label1" Text="Exam Details" runat="server"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ContentTemplate>


                                                                <table width="100%" cellpadding="2" cellspacing="2" border="0" align="left">
                                                                    <tr>
                                                                        <td valign="top" style="text-align: left; border-right: 2px solid #fff; padding-left: 20px; background-color: #f1f1f1;">
                                                                            <table width="100%" border="0" cellpadding="4" cellspacing="2">
                                                                                <tr>
                                                                                    <td colspan="2" style="text-align: center;"><strong>Exam ID</strong> :<asp:Label ID="lblTransactionID" runat="server"></asp:Label>&nbsp;&nbsp;[<asp:Label ID="lblProctorName" runat="server"></asp:Label>]</td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" style="text-align: center;">

                                                                                        <div align="center">
                                                                                            <asp:Image ID="img" runat="server" Width="160px" Height="120px" />
                                                                                            <br />
                                                                                        </div>

                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td width="40%"><strong>Student Name</strong></td>
                                                                                    <td>:
                                                                                        <asp:Label ID="lblStudentName" runat="server"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td><strong>Course</strong></td>
                                                                                    <td>:
                                                                                        <asp:Label ID="lblCourseName" runat="server"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td><strong>Exam</strong></td>
                                                                                    <td>:
                                                                                        <asp:Label ID="lblExamName" runat="server"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td><strong>Duration</strong></td>
                                                                                    <td>:
                                                                                        <asp:Label ID="lblDuration" runat="server"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td><strong>Level</strong></td>
                                                                                    <td>:
                                                                                        <asp:Label ID="lblExamLevel" runat="server"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td><strong>Email</strong></td>
                                                                                    <td>:
                                                                                        <asp:Label ID="lblStudentEmail" runat="server"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td><strong>Phone</strong></td>
                                                                                    <td>:
                                                                                        <asp:Label ID="lblPhoneNumber" runat="server"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td><strong>Status</strong></td>
                                                                                    <td id="tdStatus" runat="server">:
                                                                                        <asp:Label ID="lblStatus" runat="server"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td><strong>Session ID</strong></td>
                                                                                    <td id="tdExamSessionID" runat="server">:
                                                                                          <asp:Image ID="ImgMeetingType" runat="server" Width="18px" Height="18px" ImageAlign="AbsBottom" ImageUrl="../Images/ImgIconBlank.png" />
                                                                                        <asp:Label ID="lblExamSessionID" runat="server"></asp:Label>

                                                                                        <input onclick="javasript: void (0); return false;" type="image" id="btnCopySessionID" src="../Images/copy.png" alt="Copy to clipboard" class="copyIcon" title="Copy sessionID to clipboard" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="vertical-align: top;">
                                                                                        <strong>Join URL</strong>
                                                                                    </td>
                                                                                    <td style="vertical-align: top;">:
                                                                                    <asp:Label ID="lblExamSessionURL" ForeColor="#3333ff" runat="server"></asp:Label>
                                                                                        <span>&nbsp; 
                                                                                           <input onclick="javasript: void (0); return false;" type="image"
                                                                                               id="imgCopyJoinURL" src="../Images/copy.png" alt="Copy to clipboard" style="position: relative;"
                                                                                               class="copyIcon" title="Copy Join URL to clipboard" /></span>
                                                                                    </td>
                                                                                </tr>

                                                                            </table>

                                                                        </td>
                                                                        <td valign="top" style="text-align: left; padding-left: 20px; background-color: #f1f1f1;">
                                                                            <table border="0" width="100%" cellpadding="4" cellspacing="2">
                                                                                <tr>
                                                                                    <td><strong>examiLOCK <sup style="font-size: 13px;">®</sup></strong></td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblexamiLOCK" runat="server" CssClass="splLblDisplay"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td><strong>Special Accommodations</strong></td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblSpecialNeeds" CssClass="splLblDisplay" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2"><strong>Comments on Special Accommodations </strong></td>


                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" id="tdcoments" runat="server" style="background-color: #999; padding: 10px 5px; width: 686px; height: 45px; color: #fff">
                                                                                        <asp:Label ID="lblComments" runat="server" ForeColor="Black"></asp:Label>

                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2"><strong>Files</strong></td>
                                                                                </tr>

                                                                                <tr>
                                                                                    <td colspan="2">
                                                                                        <telerik:RadGrid ID="gvUploadFiles" runat="server"
                                                                                            AutoGenerateColumns="False"
                                                                                            CellSpacing="0" GridLines="None" PageSize="5">
                                                                                            <GroupingSettings CaseSensitive="false" />
                                                                                            <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#ffffff" PageSize="5"
                                                                                                FilterItemStyle-HorizontalAlign="Center">
                                                                                                <NoRecordsTemplate>
                                                                                                    No records to display.
                                                                                                </NoRecordsTemplate>
                                                                                                <Columns>



                                                                                                    <telerik:GridTemplateColumn HeaderStyle-ForeColor="Black" HeaderStyle-BackColor="White" HeaderStyle-Width="0px"
                                                                                                        HeaderStyle-HorizontalAlign="left" DataField="OriginalFileName" SortExpression="OriginalFileName"
                                                                                                        UniqueName="OriginalFileName" FilterControlWidth="40px" HeaderText="Uploaded files">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:LinkButton ID="lnkOriginalFileName" runat="server" Text='<%# Eval("OriginalFileName")%>' CommandArgument='<%# Bind("StoredFileName")%>' CommandName="uploadFile" Font-Underline="true" OnClick="lnlFile_Click" />
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle HorizontalAlign="left" />
                                                                                                        <HeaderStyle Font-Bold="true" />
                                                                                                    </telerik:GridTemplateColumn>



                                                                                                </Columns>



                                                                                            </MasterTableView>


                                                                                        </telerik:RadGrid></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan=""><strong>URL</strong> </td>


                                                                                    <td colspan="2">:
                                                                                        <asp:Label ID="lblExamLink" runat="server"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td width="35%"><strong>Exam Username</strong></td>
                                                                                    <td>:
                                                                                        <asp:Label ID="lblExamUserName" runat="server"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td><strong>Exam password</strong></td>
                                                                                    <td>:
                                                                                        <asp:Label ID="lblExamPassword" runat="server"></asp:Label></td>
                                                                                </tr>

                                                                                <% if (isAllowAttemptsFeatured() == "1")
                                                                                   {
                                                                                %>
                                                                                <tr>
                                                                                    <td>
                                                                                        <strong>Maximum attempts</strong>
                                                                                    </td>
                                                                                    <td>:
                                                                                        <asp:Label ID="lblMaxAttempts" runat="server"></asp:Label></td>
                                                                                </tr>
                                                                                <%
                                                                                   }
                                                                                %>

                                                                                <tr>
                                                                                    <td><strong>Exam dates</strong></td>
                                                                                    <td>:
                                                                                        <asp:Label ID="lblSlot" runat="server"></asp:Label>-<asp:Label ID="lblEndTime" runat="server"></asp:Label>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td><strong>Instructor</strong></td>
                                                                                    <td>: 
                                                                                        <asp:Label ID="lblExamProviderName" runat="server"></asp:Label>
                                                                                        [<asp:Label ID="lblExamProviderEmailAddress" runat="server"></asp:Label>]
                                                                                    </td>
                                                                                </tr>



                                                                            </table>

                                                                        </td>
                                                                    </tr>
                                                                </table>

                                                            </ContentTemplate>
                                                        </ajax:TabPanel>
                                                        <ajax:TabPanel ID="tbpNotes" runat="server">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblNotes" Text="Exam Notes" runat="server"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ContentTemplate>
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td>


                                                                            <uc:rules ID="ucRules" runat="server" DisplayFrom="PROCTOR" />





                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </ajax:TabPanel>
                                                        <ajax:TabPanel ID="tbpComments" runat="server">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblHeaderComments" Text="Proctor Comments" runat="server"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ContentTemplate>
                                                                <asp:UpdatePanel ID="upStudentView" runat="server">
                                                                    <ContentTemplate>
                                                                        <table width="100%" cellpadding="0" cellspacing="2">
                                                                            <tr>
                                                                                <td>
                                                                                    <table width="100%">
                                                                                        <tr>
                                                                                            <td align="left" valign="top" width="18%"><strong>Exam Flag</strong></td>
                                                                                            <td valign="top">:</td>
                                                                                            <td align="left" valign="top">
                                                                                                <telerik:RadComboBox ID="ddlFlags" runat="server" Skin="Web20" Width="300" OnSelectedIndexChanged="ddlFlags_SelectedIndexChanged" AutoPostBack="true">
                                                                                                    <Items>
                                                                                                        <telerik:RadComboBoxItem Text="--Please select flag--" Value="-1" />
                                                                                                        <telerik:RadComboBoxItem Text="Alert" ImageUrl="../Images/ImgAlert.png" Value="4" />



                                                                                                        <telerik:RadComboBoxItem Text="No Violation" ImageUrl="../Images/flag_g.png" Value="1" />

                                                                                                        <telerik:RadComboBoxItem Text="Possible Violation" ImageUrl="../Images/flag_y.png" Value="2" />


                                                                                                        <telerik:RadComboBoxItem Text="Violation" ImageUrl="../Images/flag.png" Value="3" />
                                                                                                    </Items>
                                                                                                </telerik:RadComboBox>

                                                                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidatorddlFlags" InitialValue="--Please select flag--" Display="Dynamic"
                                                                                                    ControlToValidate="ddlFlags" ValidationGroup="Add" ErrorMessage="Please select exam flag" />



                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <table width="100%">
                                                                                        <tr>
                                                                                            <td align="left" valign="top" width="18%"><strong>Incident Time Stamp</strong></td>
                                                                                            <td valign="top">:</td>
                                                                                            <td align="left" valign="top">

                                                                                                <telerik:RadComboBox ID="ddlHours" runat="server" AppendDataBoundItems="True" Skin="<%$ Resources:AppConfigurations,Skin_Current %>"
                                                                                                    Width="90" Height="200">
                                                                                                </telerik:RadComboBox>

                                                                                                <telerik:RadComboBox ID="ddlMinutes" runat="server" AppendDataBoundItems="True" Skin="<%$ Resources:AppConfigurations,Skin_Current %>"
                                                                                                    Width="100" Height="200">
                                                                                                </telerik:RadComboBox>
                                                                                                <telerik:RadComboBox ID="ddlsec" runat="server" AppendDataBoundItems="True" Skin="<%$ Resources:AppConfigurations,Skin_Current %>"
                                                                                                    Width="100" Height="200">
                                                                                                </telerik:RadComboBox>

                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <table width="100%">
                                                                                        <tr>
                                                                                            <td align="left" valign="top" width="18%"><strong>Description</strong></td>
                                                                                            <td valign="top">:</td>
                                                                                            <td valign="top" align="left">
                                                                                                <telerik:RadComboBox ID="ddlAlerts" runat="server" Skin="Web20" Width="300" Filter="Contains" MarkFirstMatch="true" OnSelectedIndexChanged="ddlAlerts_SelectedIndexChanged" AutoPostBack="true">
                                                                                                    <%--   <Items>
                                                                                                         <telerik:RadComboBoxItem Text="--Please select Description--" Value="-1" />
                                                                                                    </Items>--%>
                                                                                                </telerik:RadComboBox>
                                                                                                <br />
                                                                                                <br />



                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                                        <tr>
                                                                                            <td align="left" valign="top" width="18%"><strong>Comments</strong></td>
                                                                                            <td valign="top" width="3%">:</td>
                                                                                            <td valign="top" align="left">
                                                                                                <telerik:RadTextBox ID="txtComments" runat="server" MaxLength="5000" TextMode="MultiLine"
                                                                                                    CssClass="td_input" Width="50%">
                                                                                                </telerik:RadTextBox>

                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="<%$ Resources:ResMessages,Proctor_CommentsMandate %>" Enabled="false"
                                                                                                    ControlToValidate="txtComments" CssClass="hidevalidate" ForeColor="Red" ValidationGroup="Add"></asp:RequiredFieldValidator>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="3"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center" valign="bottom" colspan="3" width="100%">
                                                                                    <telerik:RadButton ID="btnAddComments" runat="server" OnClick="btnAddComments_Click"
                                                                                        Skin="Web20" Text="<%$ Resources:SecureProctor,Common_Add %>" ValidationGroup="Add"
                                                                                        Width="80">
                                                                                    </telerik:RadButton>

                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center" colspan="3" width="100%" valign="top">
                                                                                    <telerik:RadGrid ID="gvComments" runat="server" OnNeedDataSource="gvComments_NeedDataSource"
                                                                                        AutoGenerateColumns="False" AllowSorting="True" Skin="<%$ Resources:SecureProctor,Telerik_Grid_Skin %>"
                                                                                        CellSpacing="0" GridLines="None" Font-Size="9px" OnDeleteCommand="gvComments_DeleteCommand">
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
                                                                                                <telerik:GridBoundColumn DataField="AlertText" HeaderText="Description"
                                                                                                    SortExpression="AlertText" UniqueName="AlertText" HeaderStyle-HorizontalAlign="Center">
                                                                                                    <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                                                                    <HeaderStyle Font-Bold="true" />
                                                                                                </telerik:GridBoundColumn>
                                                                                                <telerik:GridBoundColumn DataField="Comments" HeaderText="<%$ Resources:SecureProctor,Common_Comments %>"
                                                                                                    SortExpression="Comments" UniqueName="Comments" HeaderStyle-HorizontalAlign="Center">
                                                                                                    <ItemStyle HorizontalAlign="Center" Width="30%" />
                                                                                                    <HeaderStyle Font-Bold="true" />
                                                                                                </telerik:GridBoundColumn>
                                                                                                <telerik:GridBoundColumn DataField="CommentTime" HeaderText="<%$ Resources:SecureProctor,Common_CommentTime %>"
                                                                                                    SortExpression="CommentTime" UniqueName="Comments" HeaderStyle-HorizontalAlign="Center">
                                                                                                    <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                                                                    <HeaderStyle Font-Bold="true" />
                                                                                                </telerik:GridBoundColumn>

                                                                                                <telerik:GridBoundColumn DataField="AddedBy" HeaderText="<%$ Resources:SecureProctor,Common_AddedBy %>"
                                                                                                    SortExpression="AddedBy" UniqueName="AddedBy" HeaderStyle-HorizontalAlign="Center">
                                                                                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                                                    <HeaderStyle Font-Bold="true" />
                                                                                                </telerik:GridBoundColumn>
                                                                                                <telerik:GridBoundColumn DataField="AddedOn" HeaderText="<%$ Resources:SecureProctor,Common_AddedOn %>"
                                                                                                    SortExpression="AddedOn" UniqueName="AddedOn" HeaderStyle-HorizontalAlign="Center">
                                                                                                    <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                                                                    <HeaderStyle Font-Bold="true" />
                                                                                                </telerik:GridBoundColumn>
                                                                                                <telerik:GridTemplateColumn>
                                                                                                    <ItemTemplate>

                                                                                                        <%--<div style="width:50%;">
       <div style="float:left; width:50%;"> <asp:ImageButton ID="ImgEdit" runat="server" ImageUrl="~/Images/edit_s.gif" CommandName="EDIT" CommandArgument='<%# Eval("CommentID")%>'  Visible='<%# Convert.ToBoolean(Eval("EditStatus")) %>'/>
</div>--%>
                                                                                                        <div style="float: left; width: 45%;">
                                                                                                            <asp:ImageButton ID="ImgEdit" runat="server" ImageUrl="~/Images/edit_s.gif" CommandName="EDIT" CommandArgument='<%# Eval("CommentID")%>' OnClientClick='<%# Eval("CommentID", "OpenEditComments({0});return false;") %>' />
                                                                                                        </div>
                                                                                                        <div style="float: right; width: 50%;">
                                                                                                            <asp:ImageButton ID="ImgDelete" runat="server" ImageUrl="~/Images/delete_s.gif" CommandName="DELETE" CommandArgument='<%# Eval("CommentID")%>' />
                                                                                                        </div>
                                                                                                        <div class="clear"></div>
                                                                                                        </div>   
                                                                                 
                                                                                                    </ItemTemplate>
                                                                                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                                                    <HeaderStyle Width="5%" />
                                                                                                </telerik:GridTemplateColumn>
                                                                                            </Columns>

                                                                                            <EditFormSettings EditFormType="Template">
                                                                                                <FormTemplate>
                                                                                                    <table width="100%" cellpadding="5" cellspacing="5">
                                                                                                        <tr>
                                                                                                            <td align="right" style="width: 20%">
                                                                                                                <asp:Label ID="lblDesc" Text="Comments : " runat="server"></asp:Label>
                                                                                                            </td>
                                                                                                            <td align="left" style="width: 20%">
                                                                                                                <telerik:RadTextBox ID="txtRuleDescription" runat="server" Skin="Web20" Text='<%# Eval("Comments")%>' Width="250px">
                                                                                                                </telerik:RadTextBox>
                                                                                                            </td>
                                                                                                            <%--<td align="right"></td>--%>
                                                                                                            <td align="left" colspan="2">
                                                                                                                <asp:ImageButton ID="ImgRuleUpdate" runat="server" ImageUrl="~/Images/icon_update.png"
                                                                                                                    CommandName="Update" CommandArgument='<%# Eval("CommentID")%>' />&nbsp;&nbsp;&nbsp;
                                                                                <asp:ImageButton ID="ImgRuleCancel" runat="server" ImageUrl="~/Images/icon_cancel.png"
                                                                                    CommandName="Cancel" />
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </FormTemplate>
                                                                                            </EditFormSettings>
                                                                                            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>

                                                                                        </MasterTableView>

                                                                                        <FilterMenu EnableImageSprites="False">
                                                                                        </FilterMenu>
                                                                                    </telerik:RadGrid>
                                                                                    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="true"
                                                                                        Behaviors="Close" Skin="<%$ Resources:AppConfigurations,Skin_Current %>"
                                                                                        VisibleStatusbar="false" OnClientClose="closeWin">
                                                                                        <Windows>
                                                                                            <telerik:RadWindow ID="RadWindow1" runat="server" ShowContentDuringLoad="false" Width="400px"
                                                                                                Height="400px" Title="Telerik RadWindow" Behaviors="Default">
                                                                                            </telerik:RadWindow>
                                                                                        </Windows>
                                                                                    </telerik:RadWindowManager>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td valign="top" width="49%">&nbsp;
                                                                                </td>
                                                                            </tr>


                                                                        </table>

                                                                    </ContentTemplate>
                                                                    <Triggers>
                                                                        <asp:AsyncPostBackTrigger ControlID="btnAddComments" EventName="Click" />
                                                                    </Triggers>
                                                                </asp:UpdatePanel>

                                                                <div>
                                                                    <table width="100%">
                                                                        <tr id="trScore" runat="server" visible="false" style="display: none;">
                                                                            <td align="left">
                                                                                <asp:Label ID="lblKeyScoretext" runat="server" Text="<strong>examiKEY <sup>®</sup> : </strong>" Font-Size="16px"></asp:Label>
                                                                                &nbsp;&nbsp;<asp:Label ID="lblKeyScore" runat="server" Font-Size="16px" Font-Bold="true" ForeColor="#000099"></asp:Label>
                                                                            </td>

                                                                        </tr>
                                                                    </table>
                                                                </div>
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

                    </div>

                </tr>
            </table>
        </div>
    </div>
</asp:Content>

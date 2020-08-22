<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true" CodeBehind="ExamprocessNormal.aspx.cs" Inherits="SecureProctor.Student.ExamprocessNormal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StudentContent" runat="server">

    <div id="DivSppiner" style="text-align: center; background-color: White; position: absolute;top: 55%;left: 50%; margin: -50px 0px 0px -50px; display:none;">
  <asp:Label ID="lblLoader" runat="server" Text="Please wait..." Font-Size="Large" Font-Bold="true" ForeColor="Black"></asp:Label>
                    <br />
                    <br />
                    <br />
                    <asp:Image ID="ImgLoader" runat="server" ImageUrl="~/Images/Loader.gif" Width="36"
                        Height="36" />
</div>
    <style type="text/css">
        #wrapper {
            margin: 0 auto;
            position: relative;
            width: 280px;
            height: 400px;
        }

        #subscribers {
            position: relative;
            width: 280px;
            height: 180px;
            z-index: 1;
        }

        #myCamera {
            width: 280px;
            height: 180px;
            z-index: 10;
            bottom: 2px;
            left: 2px;
        }

            #subscribers object, #myCamera object {
                width: 280px;
                height: 180px;
            }

        .help_text_i {
            background: #e8f1f9;
            padding: 10px;
            -moz-border-radius: 5px 5px;
            -webkit-border-radius: 5px 5px;
            border-radius: 5px 5px;
        }

        .help_text_i_inner {
            border: #e4e4e4 1px solid;
            background: #f7fafd;
            padding: 10px;
            text-align: justify;
        }

        .steps {
            background: url(../Images/ImgSteps_new.png) no-repeat;
            width: 777px;
            height: 80px;
            text-align: left;
        }

        .steps1 {
            background: url(../Images/ImgSteps_new.png) no-repeat 0px -80px;
            width: 777px;
            height: 80px;
            position: relative;
            border-radius: 10px;
            text-align: left;
        }

        .steps2 {
            background: url(../Images/ImgSteps_new.png) no-repeat 0px -161px;
            width: 777px;
            height: 80px;
            text-align: left;
        }

        .steps3 {
            background: url(../Images/ImgSteps_new.png) no-repeat 0px -243px;
            width: 777px;
            height: 80px;
            position: relative;
            text-align: left;
        }

        .gridviewHeaderstyle {
            /*background: #5e83bb;*/
            font-size: 12px;
            line-height: 25px;
            border: #ccc 2px solid;
            color: #FFFFFF; /*   background: #868686;  Old browsers */ /* IE9 SVG, needs conditional override of 'filter' to 'none' */
            background: url(data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiA/Pgo8c3ZnIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgd2lkdGg9IjEwMCUiIGhlaWdodD0iMTAwJSIgdmlld0JveD0iMCAwIDEgMSIgcHJlc2VydmVBc3BlY3RSYXRpbz0ibm9uZSI+CiAgPGxpbmVhckdyYWRpZW50IGlkPSJncmFkLXVjZ2ctZ2VuZXJhdGVkIiBncmFkaWVudFVuaXRzPSJ1c2VyU3BhY2VPblVzZSIgeDE9IjAlIiB5MT0iMCUiIHgyPSIwJSIgeTI9IjEwMCUiPgogICAgPHN0b3Agb2Zmc2V0PSIwJSIgc3RvcC1jb2xvcj0iIzg2ODY4NiIgc3RvcC1vcGFjaXR5PSIxIi8+CiAgICA8c3RvcCBvZmZzZXQ9IjEwMCUiIHN0b3AtY29sb3I9IiMzYzNjM2MiIHN0b3Atb3BhY2l0eT0iMSIvPgogIDwvbGluZWFyR3JhZGllbnQ+CiAgPHJlY3QgeD0iMCIgeT0iMCIgd2lkdGg9IjEiIGhlaWdodD0iMSIgZmlsbD0idXJsKCNncmFkLXVjZ2ctZ2VuZXJhdGVkKSIgLz4KPC9zdmc+);
            background: -moz-linear-gradient(top, #868686 0%, #3c3c3c 100%); /* FF3.6+ */
            background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,#868686), color-stop(100%,#3c3c3c)); /* Chrome,Safari4+ */
            background: -webkit-linear-gradient(top, #868686 0%,#3c3c3c 100%); /* Chrome10+,Safari5.1+ */
            background: -o-linear-gradient(top, #868686 0%,#3c3c3c 100%); /* Opera 11.10+ */
            background: -ms-linear-gradient(top, #868686 0%,#3c3c3c 100%); /* IE10+ */
            background: linear-gradient(to bottom, #868686 0%,#3c3c3c 100%); /* W3C */
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#868686', endColorstr='#3c3c3c',GradientType=0 ); /* IE6-8 */
        }

            .gridviewHeaderstyle a {
                font-size: 12px;
                line-height: 25px;
                color: #FFFFFF;
            }

                .gridviewHeaderstyle a:link {
                    font-size: 12px;
                    line-height: 25px;
                    color: #FFFFFF;
                }

                .gridviewHeaderstyle a:hover {
                    font-size: 12px;
                    line-height: 25px;
                    color: Aqua;
                }

        .gridviewRowstyle {
            background: #fafafa;
            line-height: 25px;
        }

        .gridviewAlternatestyle {
            background: #f2f2f2;
            line-height: 25px;
        }

        .gridviewEmptyRowstyle {
            background: #5e83bb;
            font-size: 14px;
            line-height: 25px; /*border: #f3f3f3 1px solid;*/
            color: #FFFFFF;
        }

        .messages {
            color: #0070c0;
            font-size: 18px;
        }
    </style>
    <script src="../Scripts/jquery.js" type="text/javascript" charset="utf-8"></script>
    <script src="https://swww.tokbox.com/v1.1/js/TB.min.js"></script>
    <script type="text/javascript" language="javascript">
        var GOTOMeetingSessionID = 0;
        function browserValidate() {
            //  alert(GOTOMeetingSessionID);
            if (GOTOMeetingSessionID != 0) {
                if (GOTOMeetingSessionID.length == 9) {
                    var win = window.open("https://www1.gotomeeting.com/join/" + GOTOMeetingSessionID, '_blank', 'width=200,height=100');
                }
                else {
                    var win = window.open(GOTOMeetingSessionID, '_blank');
                }
            }
            return true;
        }
        function ValidateSec(e) {
            if ((e.which && e.which == 13) || (e.keyCode && e.keyCode == 13)) {
                StepFn('divStep2', 'divStep3', 'navigate', 'divAuthenticationFailed');
                return false;
            } else {
                return true;
            }
        }
    </script>
    <script type="text/javascript">
        function StepFn(srcId, ctrlId, action, Locked) {

            if (action == "clearForm") {
                if (srcId == "divStep2") {
                    document.getElementById('<%= txtAnswer1.ClientID %>').value = "";
                }
            }


            if (action == "navigate") {
                if (srcId == "divStep1") {
                    document.getElementById(srcId).style.display = "none";
                    document.getElementById(ctrlId).style.display = "block";

                    $.post('../AjaxHandler.aspx', { Method: "UpdateNextButtonTime", TransID: '<%= Request.QueryString["TransID"].ToString() %>' }, function (data) {
                        if (data == "true") {
                            document.getElementById(srcId).style.display = "none";
                            document.getElementById(ctrlId).style.display = "block";
                        }
                    });
                }
                else if (srcId == "divStep2") {
                    $('#DivSppiner').show();
                    if (document.getElementById('<%= txtAnswer1.ClientID %>').value != "") {
                        $.post('../AjaxHandler.aspx', { Method: "ValidateStep2", Answer: document.getElementById('<%= txtAnswer1.ClientID %>').value, Question: document.getElementById('<%= hfQid.ClientID %>').value, TransID: document.getElementById('<%= HfTransID.ClientID %>').value }, function (data) {
                            if (data == "true") {
                                document.getElementById(srcId).style.display = "none";
                                document.getElementById(ctrlId).style.display = "block";
                                $('#DivSppiner').hide();
                            }
                            else {

                                var arr = data.split('|');
                                var x = arr[0];

                                if (x == "nextQuestion") {

                                    $("#<%=hfQid.ClientID %>").val(arr[1]);
                                    $("#<%=lblQuestion1.ClientID %>").text(arr[2]);
                                    $('#<%= lblFailed.ClientID %>').html('');
                                    $('#<%= txtAnswer1.ClientID %>').val('');
                                    $('#DivSppiner').hide();
                                }

                                else if (x == "Locked") {

                                    document.getElementById(srcId).style.display = "none";
                                    document.getElementById(Locked).style.display = "block";
                                    $('#DivSppiner').hide();


                                }
                                else {
                                    $('#<%= lblFailed.ClientID %>').html(data);
                                    $('#<%= txtAnswer1.ClientID %>').val('');
                                    $('#DivSppiner').hide();
                                }
                        }
                        });
                }
                else {
                        $('#<%= lblFailed.ClientID %>').html("Security Answer cannot be blank.");
                        $('#DivSppiner').hide();
                    }
                }
                else if (srcId == "divStep3") {

                    $('#<%= lblSuccess.ClientID %>').html('');
                    var rdAditionalRule = document.getElementById('<%= gvAllowed.MasterTableView.ClientID %>').getElementsByTagName("input");

                    var rdSpecialRule = document.getElementById('<%= gvSpecialInstructions_Student.MasterTableView.ClientID %>').getElementsByTagName("input");



                    if (document.getElementById('<%= rbtyesorno1.ClientID %>_0').checked && document.getElementById('<%= rbtyesorno2.ClientID %>_0').checked && document.getElementById('<%= rbtyesorno3.ClientID %>_0').checked && document.getElementById('<%= rbtyesorno4.ClientID %>_0').checked && document.getElementById('<%= radio_standardrule.ClientID %>_0').checked) {

                        var AdditionalRule = false;
                        var SpecialRule = false;
                        /*To check i agree for adtional rules*/
                        if (rdAditionalRule.length > 0) {


                            for (i = 0; i < rdAditionalRule.length; i++) {

                                if (rdAditionalRule[i].checked == true) {
                                    AdditionalRule = true;

                                }
                                else {
                                    AdditionalRule = false;

                                }

                            }
                        }
                        else {

                            AdditionalRule = true;
                        }

                        /*End To check i agree for adtional rules*/

                        /*To check i agree for standard rules*/



                        if (rdSpecialRule.length > 0) {


                            for (i = 0; i < rdSpecialRule.length; i++) {

                                if (rdSpecialRule[i].checked == true) {
                                    SpecialRule = true;

                                }
                                else {
                                    SpecialRule = false;

                                }

                            }
                        }
                        else {

                            SpecialRule = true;

                        }




                        if (AdditionalRule == true && SpecialRule == true) {



                            $.post('../AjaxHandler.aspx', { Method: "ValidateStep3", TransID: '<%= Request.QueryString["TransID"].ToString() %>' }, function (data) {
                                if (data == "true") {
                                    document.getElementById(srcId).style.display = "none";
                                    document.getElementById(ctrlId).style.display = "block";
                                }
                            });
                        }

                        else {


                            $('#<%= lblSuccess.ClientID %>').html('<%= Resources.ResMessages.Student_Agreements %>');

                        }
                    }

                    else {


                        $('#<%= lblSuccess.ClientID %>').html('<%= Resources.ResMessages.Student_Agreements %>');


                    }

                }


    }
}
    </script>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    <script src="../js/jquery-1.9.1.js"></script>
    <script src="../js/jquery-1.8.1.min.js"></script>
    <script src="../js/jquery-ui.js"></script>
    <a id="hiddenLink" style="display: none;" href="#">examity</a>
    <iframe id="hiddenIframe" src="about:blank" style="display: none"></iframe>
    <script type="text/javascript">
        function showLockdownAlert() {
            $("#LDBDialogBg").show();
            $("#LDBDialog").dialog({
                modal: true,
                width: 695,              
            });
            $('#LDBDialog').bind('dialogclose', function (event) {
                $("#LDBDialogBg").hide();
                $(this).dialog("close");
            });
        }

    </script>
    <script>

        //Default State
        var isSupported = false;
        var appOpened = true;
        var isChrome = false;

        //Helper Methods
        function getProtocol() {
            return "examity";
        }

        function getUrl() {
            return getProtocol() + ":<%= GetLockTransID()%>";
        }

        function result() {
            if (isSupported) {
                if (isChrome && !appOpened) {
                    $("#LDBDialogBg").hide();
                    $('#LDBDialog').dialog("close");
                }
                $.post('../AjaxHandler.aspx', { Method: "setStatus", TransID: '<%= Request.QueryString["TransID"].ToString() %>' }, function (data) {

                });
            }
            else {
                showLockdownAlert();
                if (isChrome) {
                    isSupported = true;
                    appOpened = false;
                    setTimeout(function () {
                        result();
                    }, 20000);
                }
            }
        }

        var myVal = 1;
        //Handle IE
        function launchIE() {
            if (navigator.msLaunchUri) {
                isSupported = true;
                setTimeout(function () { result(); }, 1000);
                navigator.msLaunchUri(getUrl(),
                       function () { isSupported = true; }, //success
                       function () { isSupported = false; }  //failure 
                );
            }
            else {
                launchOther();
            }

        };

        //Handle Firefox
        function launchMozilla() {

            var url = getUrl(),
                iFrame = $('#hiddenIframe')[0];

            isSupported = false;

            //Set iframe.src and handle exception
            try {
                iFrame.contentWindow.location.href = url;
                isSupported = true;
                result();
            } catch (e) {
                //FireFox
                if (e.name == "NS_ERROR_UNKNOWN_PROTOCOL") {
                    isSupported = false;
                    result();
                }
            }
        }

        //Handle Chrome
        function launchChrome() {
            isChrome = true;
            var url = getUrl(),
                protcolEl = $('#btnBeginExam')[0];

            isSupported = false;


            protcolEl.focus();
            protcolEl.onblur = function () {
                isSupported = true;
                //console.log("Text Field onblur called");
            };

            //will trigger onblur
            location.href = url;

            //Note: timeout could vary as per the browser version, have a higher value
            setTimeout(function () {
                protcolEl.onblur = null;
                result();
            }, 3000);

        }


        function launchOther() {
            var myWin = window.open(getUrl(), "_self");
            setTimeout(function () {
                showLockdownAlert();
                setTimeout(function () {
                    if (appOpened) {
                        $.post('../AjaxHandler.aspx', { Method: "setStatus", TransID: '<%= Request.QueryString["TransID"].ToString() %>' }, function (data) {

                            });

                            $("#LDBDialogBg").hide();
                            $('#LDBDialog').dialog("close");
                        }
                }, 10000)
            }, 5000);
            }

            function BeginExam() {
                if ($.browser.mozilla) {
                    launchMozilla();
                } else if ($.browser.chrome) {
                    launchChrome();
                } else if ($.browser.msie) {
                    launchIE();
                } else {
                    launchOther();
                }
                //window.open('examity:<%= GetTransID()%>', '_self');
            }
    </script>
    <style type="text/css">
        .hide {
            display: none;
        }
         .ui-widget-header {
  border: 1px solid #4095d6;
  background: #4095d6 50% 50% repeat-x;
  color: #fff; text-align:center; font-size:16px;
  font-weight: bold;border-radius:0px; padding:5px 0px; line-height: 25px; 
}
    .ui-dialog .ui-dialog-content {
  position: relative;
  border: 0;
  padding:0px;
  background: none;
  overflow: auto; border-radius:0px;
}
.ui-widget-content {
  border: 1px solid #aaaaaa;
  background: #ffffff 50% 50% repeat-x;border-radius:0px; padding:0px;
  /* color: #222222; */
}
.ui-state-default, .ui-widget-content .ui-state-default, .ui-widget-header .ui-state-default {
    border: 2px solid #fff;
    background: transparent url("../Images/Examilock_cancel.png") repeat-x scroll 50% 50%;
    font-weight: normal;
    color: #fff;
}
.ui-icon, .ui-widget-content .ui-icon {
   background-image: url(../Images/Examilock_cancel.png); 
}

.ui-state-default .ui-icon {
   background-image: url(../Images/Examilock_cancel.png); 
}
.ui-widget-header .ui-icon {
  background-image:url(../Images/Examilock_cancel.png); 
}
    .ui-dialog .ui-dialog-titlebar-close {
    position: absolute;
    right: 0.3em;
    top: 50%;
    width: 25px;
    margin: -15px 5px 0px;
    padding: 1px;
    height: 25px;
}
    </style>
    <div id="LDBDialogBg" style="display: none; background-color: gray; opacity: 0.5; position: fixed; top: 0px; left: 0px; width: 100%; height: 100%;">
    </div>
    <div id="LDBDialog" title="examiLOCK® Installation Instructions" style="display: none;">
          <div>
                                    
                                            <table width="100%" cellpadding="4" cellspacing="0">
                                           
                                             <tr>
                                            <td style="color:#656565;text-align:center;font-size:16px; margin-bottom:5px; padding-top:5px;" colspan="2">
                                             To install examiLOCK<sup>&reg;</sup> on your computer, please follow the steps below.
                                               
                                            </td>
                                        </tr>
                                            <tr><td colspan="2">&nbsp;</td></tr>
                                            <tr><td colspan="2" >
                                             <table style="width:95%; margin:0px auto;" cellpadding="3">
                                                    <tr>
                                            <td><div class="examilock_circle"><div style="padding-top:2px;">1</div></div></td>
                                            <td><span class="examilock_headings">Download</span></td>
                                            </tr>
                                            <tr>
                                            <td>&nbsp;</td>
                                            <td class="examilock_CText">Click on examiLOCK<sup style="padding-left:2px;">&reg;</sup> to begin. &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="javascript:downloadApp();" style="color:#fff;" class="examilock_orange_buttom">examiLOCK<sup style="padding-left:2px;">&reg;</sup> </a></td>                
                                            </tr>
                                            <tr>
                                            <td><div class="examilock_circle"><div style="padding-top:2px;">2</div></div></td>
                                            <td><span class="examilock_headings">Install & Run</span></td>
                                            </tr>
                                            <tr>
                                            <td>&nbsp;</td>
                                            <td class="examilock_CText">Open the downloaded examiLOCK<sup style="padding-left:2px;">&reg;</sup> installation file.</td>
                                            </tr>
                                            <tr>
                                            <td><div class="examilock_circle"><div style="padding-top:2px;">3</div></div></td>
                                            <td><span class="examilock_headings">Close Window</span></td>
                                            </tr>
                                            <tr>
                                            <td>&nbsp;</td>
                                            <td class="examilock_CText">Once installation is complete, close this window to start your exam.</td>
                                            </tr>
                                                </table>

                                                </td></tr>
                                            
                                             <tr><td colspan="2">&nbsp;</td></tr>
                                            <tr>
                                            
                                            <td class="examilock_footer" colspan="2">
                                                <%--<a href="javascript:$('#zenbox_tab').click();" style="background-color: #7acae0;
                                                    border: none; border-radius: 15px; padding: 5px; padding-left: 10px; padding-right: 10px;
                                                    text-decoration: none; color: white; font-weight: bold; cursor: pointer;">Live Chat</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
                                                <a href="mailto:support@examity.com" style="color:#fff;"><u>Email Support</u></a> | Phone: 855-392-6489
                                            </td>
                                           
                                            </tr>
                                            </table>
                                                
                                          
        </div>
    </div>
     <script type="text/javascript">
         function downloadApp() {
             appOpened = false;
             if (navigator.appVersion.indexOf("Win") != -1) {
                 //$('#linkHolder').html('<a href="../ExamityLockDownBrowser_Win.zip" style="text-decoration: underline; color: blue;" target="_blank">Click here to download Examity LockDown Browser installation file.</a>');
                 window.open('https://prod.examity.com/commonfiles/examiLOCK.exe', '_self');
             }
             else if (navigator.appVersion.indexOf("Mac") != -1) {
                 //$('#linkHolder').html('<a href="../ExamityLockDownBrowser_Mac.zip" style="text-decoration: underline; color: blue;" target="_blank">Click here to download Examity LockDown Browser installation file.</a>');
                 window.open('https://prod.examity.com/commonfiles/examiLOCK.pkg', '_self');
             }
             else {
                 alert("Currently examiLOCK <sup>&reg;</sup> do not support current Operating System. Please contact our support.");
             }
         }
    </script>
    <table cellpadding="2" cellspacing="2" width="100%">
        <tr>
            <td>

                <asp:Image ID="imgHead" runat="server" ImageUrl="../Images/ImgStartExamHeader.png" AlternateText="Start Exam" title="Start Exam" TabIndex="11" />
            </td>
            <td width="1%" rowspan="2"></td>
            <%-- <td align="right">
                <img src="../Images/ImgHelp.png" alt="help" />
            </td>--%>
        </tr>
        <tr>
            <td width="100%" align="center" valign="top" colspan="3">
                <div class="login_new1">
                    <div class="chat_window">
                        <table cellpadding="2" cellspacing="2" width="100%">
                            <tr>
                                <td align="center" colspan="2" style="width: 100%; text-align: left; -moz-box-shadow: 0 0 20px #d9d9d9; -webkit-box-shadow: 0 0 20px #d9d9d9; box-shadow: 0 0 20px #d9d9d9; padding-top: 10px; background: #f8f8f8; height: 400px; border: 1px solid #e3e3e3; border-radius: 10px;"
                                    valign="top">
                                    <div style="border: none; width: 100%; height: auto; overflow: auto; margin: 0px auto;">
                                        <div id="divStep1">
                                            <div class="steps" style="width: 750px; margin: 0px auto;">
                                            </div>
                                            <table cellpadding="2" cellspacing="2" width="100%">
                                                <tr>
                                                    <td width="100%" align="center">
                                                        <div class="login_new_steps">
                                                            <table width="100%" cellpadding="2" cellspacing="4">
                                                                <tr>
                                                                    <td align="center">
                                                                        <div id="DIV1">
                                                                            <span style="font-size: 20px;">
                                                                                <asp:Label ID="lblText1" runat="server" Text="Welcome to the ID verification process." TabIndex="12"></asp:Label>
                                                                                                                                                            </span>
                                                                            <br />
                                                                            <br />
                                                                            <br />
                                                                            <br />
                                                                            <span style="font-size: 16px;"><asp:Label ID="lblText2" runat="server" Text="In a moment, you will see a “Proceed” button. Click to connect with a proctor, who will guide you." TabIndex="13"></asp:Label><br />
                                                                                <br />
                                                                                <asp:Label ID="lblText3" runat="server"  Text="Your exam timer will begin after this process is complete." TabIndex="14"></asp:Label></span>
                                                                        </div>
                                                                        <div id="DIV2" style="display: none;">
                                                                            <div id="divProceed">
                                                                                <span style="font-size: 20px;"><asp:Label ID="lblText4" runat="server"  Text="Click “Proceed” to connect with your proctor."
                                                                                    TabIndex="15"></asp:Label></span>
                                                                                <br />
                                                                                <br />
                                                                                <span style="font-size: 20px; color: Orange;"><asp:Label ID="lblText5" runat="server" Text="*Note that if you can’t connect, make
                                                                                    sure your popup blocker is disabled." TabIndex="16"></asp:Label> </span>
                                                                                <br />
                                                                                <br />
                                                                                
                                                                                <br />
                                                                                <asp:Button ID="btnProceed" runat="server" Text="Proceed" class="classname" OnClientClick="browserValidate();"
                                                                                    OnClick="btnProceed_Click" TabIndex="17"/>
                                                                                <br />
                                                                            </div>
                                                                        </div>
                                                                        <asp:Label ID="lblError" runat="server" ForeColor="Red" Font-Bold="true" Text="Please wait for the proctor to verify your identity before clicking Next."
                                                                            Visible="false" /><br />
                                                                        <br />
                                                                        <div id="DIV5" style="display: none;">
                                                                            <span style="font-size: 16px;"><asp:Label ID="lblText13" runat="server" Text="Click “Next” and answer your security questions.&nbsp&nbsp After,
                                                                                    
                                                                                 confirm the user agreement and begin your test!" TabIndex="18"></asp:Label> </span>
                                                                            <br />
                                                                            <br />
                                                                        </div>
                                                                        <input type="button" id="btnStep1Next" class="classname" value="Next" onclick="StepFn('divStep1', 'divStep2', 'navigate');"
                                                                            style="display: none;" tabindex="19"/>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <script type="text/javascript" src="../Scripts/jquery-timer.js"></script>
                                            <script type="text/javascript">
                                                var DIV5FOCUS = 0;
                                                var timer =
	$.timer(
        function getValidationStatus() {
            $.post('../Proctor/AjaxResponse.aspx', { Method: "GetStudentIdentity", TransID: '<%= Request.QueryString["TransID"].ToString() %>' }, function (data) {
                if (data == "True") {
                    $('#btnStep1Next').attr('style', 'display:block;');
                    $('#DIV5').attr('style', 'display:block;');
                    DIV5FOCUS = DIV5FOCUS + 1;
                    if (DIV5FOCUS == 1) {
                        $('#DIV5').focus();
                    }

                }
                else {
                    $('#btnStep1Next').attr('style', 'display:none;');
                    $('#DIV5').attr('style', 'display:none;');

                }
            });
        }, 1000, true);


                                                $.timer(
        function getValidationStatus() {
            $.post('../Proctor/AjaxResponse.aspx', { Method: "GetMeetingStatus", TransID: '<%= Request.QueryString["TransID"].ToString() %>' }, function (data) {
                if (data == "0") {
                    $('#DIV1').attr('style', 'display:block;');
                    $('#DIV2').attr('style', 'display:none;');

                }
                else {
                    $('#DIV2').attr('style', 'display:block;');
                    $('#DIV1').attr('style', 'display:none;');
                }
            });
        }, 1000, true);


        $.timer(
function getValidationStatus() {
    $.post('../Proctor/AjaxResponse.aspx', { Method: "GetProceedStatus", TransID: '<%= Request.QueryString["TransID"].ToString() %>' }, function (data) {
        if (data == "1") {
            $('#divProceed').attr('style', 'display:block;');
            $.post('../AjaxHandler.aspx', { Method: "GetSessionID", TransID: '<%= Request.QueryString["TransID"].ToString() %>' }, function (data) {
                GOTOMeetingSessionID = data;
            });
        }
        else {
            $('#divProceed').attr('style', 'display:none;');
        }
    });
}, 1000, true);



$.timer(
function getValidationStatus() {
    $.post('../Proctor/AjaxResponse.aspx', { Method: "StartExam", TransID: '<%= Request.QueryString["TransID"].ToString() %>' }, function (data) {
        if (data == "1") {
            $('#DivStartExam').attr('style', 'display:block;');
            $('#DivSurvey').attr('style', 'display:none;');
        }
        else {
            $('#DivStartExam').attr('style', 'display:none;');
            $('#DivSurvey').attr('style', 'display:block;');
        }
    });
}, 1000, true);
                                            </script>
                                        </div>
                                        <div id="divStep2" style="display: none;">
                                            <div>
                                                <asp:UpdatePanel ID="up" runat="server">
                                                    <ContentTemplate>
                                                        <div class="steps1" style="width: 777px; margin: 0px auto;">
                                                        </div>
                                                        <table cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <td width="100%" align="center">
                                                                    <div class="login_new_steps">
                                                                        <table width="600" cellpadding="2" cellspacing="4">
                                                                            <tr>
                                                                                <td align="center"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center">
                                                                                    <div onkeypress="return ValidateSec(event)">
                                                                                        <table width="100%" cellpadding="5" cellspacing="5">
                                                                                            <tr>
                                                                                                <td align="left" style="padding-left: 50px;">
                                                                                                    <strong><asp:Label ID="lblQHead" Text="Question :" runat="server" TabIndex="20" CssClass="Display"></asp:Label></strong>
                                                                                                    <asp:Label ID="lblQuestion1" runat="server" TabIndex="21"  CssClass="Display"></asp:Label>
                                                                                                    <asp:HiddenField ID="hfQid" runat="server" />
                                                                                                    <asp:HiddenField ID="HfTransID" runat="server" />

                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="padding-left: 50px;">
                                                                                                    <telerik:RadTextBox ID="txtAnswer1" runat="server" MaxLength="100" Width="270" TabIndex="22"  CssClass="Display">
                                                                                                    </telerik:RadTextBox>
                                                                                                     <br />
                                                                                                    <br></br>
                                                                                                    <asp:Label ID="msg" runat="server" CssClass="attempts" Text="You have three attempts to answer the above question."></asp:Label><br />
                                                                                                    <asp:Label ID="lblFailed" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                               <tr><td style="padding-left:50px;" class="Display"><b>Note that answers are not case-sensitive.</b></td></tr>
                                                                                            <tr>
                                                                                                <td style="padding-left: 50px;" >
                                                                                                    <input type="button" value="Submit" class="button_new blue" onclick="StepFn('divStep2', 'divStep3', 'navigate', 'divAuthenticationFailed');" tabindex="23" />
                                                                                                    &nbsp;&nbsp;
                                                                                                <input type="button" value="Clear" class="button_new orange" style="display: none;" onclick="StepFn('divStep2', '', 'clearForm', '');" />
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>&nbsp;</td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>&nbsp;</td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>&nbsp;</td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>



                                                                        </table>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                                   <div style="display: none;" id="divAuthenticationFailed">
                                            <div style="margin: 100px auto 0px auto; text-align: center;">
                                                <span style="font-size: 40px; color: #f84e4e;">Authentication error.</span><br />
                                                <br />
                                                <span style="font-size: 20px; color: #797979; margin-top: 20px;">Please schedule a new appointment. </span>

                                            </div>
                                        </div>
                                      <%--  <div style="display: none;" id="divAuthenticationFailed1">
                                            <div style="margin: 100px auto 0px auto; text-align: center;">
                                                <span style="font-size: 20px; color: #f84e4e;">Please Note:  Because you were unable to complete the authentication process, you will be required to pay all fees associated with scheduling a new exam appointment. Per university policy, payment will be required by credit card before your next exam appointment can be scheduled.</span><br />
                                                <br />
                                                <span style="font-size: 20px; color: #797979; margin-top: 20px;">Please schedule a new appointment. </span>

                                            </div>
                                        </div>--%>


                                        <div id="divStep3" style="display: none;">
                                            <div>
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                        <div class="steps2" style="width: 777px; margin: 0px auto;">
                                                        </div>
                                                        <table cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <td width="100%" align="center" valign="top">
                                                                    <div class="login_new_steps">
                                                                        <table width="100%" cellpadding="2" cellspacing="4">
                                                                            <tr>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblSuccess" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center">

                                                                                    <table width="95%" cellpadding="5" cellspacing="5">
                                                                                        <tr>
                                                                                            <td width="75%" style="text-align: justify;">
                                                                                                <strong>1.&nbsp&nbsp</strong>
                                                                                              You certify that you are not accepting or utilizing any external help to complete
                                                                                                the exam, and are the applicable exam taker who is responsible for any violation
                                                                                                of exam rules. You understand and acknowledge that all exam rules will be supplied
                                                                                                by the applicable university or test sanctioning body, and the company will have
                                                                                                no responsibility with respect thereto. You agree to participate in the disciplinary
                                                                                                process supported by the university or test sanctioning body should any such party
                                                                                                make such request of you in connection with any violation of exam rules.
                                                                                                <asp:Label ID="lblAgreement1" runat="server" Text=""></asp:Label>
                                                                                            </td>
                                                                                            <td width="20%" valign="middle">
                                                                                                <asp:RadioButtonList ID="rbtyesorno1" runat="server" RepeatDirection="Horizontal"
                                                                                                    AutoPostBack="false">
                                                                                                    <asp:ListItem Value="0">I agree</asp:ListItem>
                                                                                                    <asp:ListItem Value="1">Disagree</asp:ListItem>
                                                                                                </asp:RadioButtonList>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="text-align: justify;">
                                                                                                 <strong>2.&nbsp&nbsp</strong>
                                                                                                  You agree that you will be held accountable for any and all infractions associated
                                                                                                with identity misrepresentation and agree to participate in the disciplinary process
                                                                                                supported by the university or test sanctioning body should any such party make
                                                                                                any request of you.
                                                                                                <asp:Label ID="lblAgreement2" runat="server" Text=""></asp:Label>
                                                                                            </td>
                                                                                            <td valign="middle">
                                                                                                <asp:RadioButtonList ID="rbtyesorno2" runat="server" RepeatDirection="Horizontal"
                                                                                                    AutoPostBack="false">
                                                                                                    <asp:ListItem Value="0">I agree</asp:ListItem>
                                                                                                    <asp:ListItem Value="1">Disagree</asp:ListItem>
                                                                                                </asp:RadioButtonList>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="text-align: justify;">
                                                                                               <strong>3.&nbsp&nbsp</strong>
                                                                                              You understand that by using any of the features of the examity web site and services,
                                                                                                 you act at your own risk, and you represent and warrant that (a) 
                                                                                                you are the enrolled student who is authorized to take the applicable exam and (b) 
                                                                                                the identification you have provided is completely accurate and you fully understand 
                                                                                                that any falsification will be a violation of these terms of use and will be reported 
                                                                                                to the appropriate university or test sanctioning body.
                                                                                                <asp:Label ID="lblAgreement3" runat="server" Text=""></asp:Label>
                                                                                            </td>
                                                                                            <td valign="middle">
                                                                                                <asp:RadioButtonList ID="rbtyesorno3" runat="server" RepeatDirection="Horizontal"
                                                                                                    AutoPostBack="false">
                                                                                                    <asp:ListItem Value="0">I agree</asp:ListItem>
                                                                                                    <asp:ListItem Value="1">Disagree</asp:ListItem>
                                                                                                </asp:RadioButtonList>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="text-align: justify;">
                                                                                                <strong>4.&nbsp&nbsp</strong>
                                                                                          You acknowledge that your webcam and computer screen may be monitored and viewed,
                                                                                                recorded and audited to ensure the integrity of the exams. You agree that no one
                                                                                                other than you will appear on your webcam or computer screen. You understand acknowledge
                                                                                                that such data, along with your test answers, will be stored, retrieved, analyzed
                                                                                                and shared with the university or test sanctioning body, in our discretion, to ensure
                                                                                                the integrity of the exams.
                                                                                                <asp:Label ID="lblAgreement4" runat="server" Text=""></asp:Label>
                                                                                            </td>
                                                                                            <td valign="middle">
                                                                                                <asp:RadioButtonList ID="rbtyesorno4" runat="server" RepeatDirection="Horizontal"
                                                                                                    AutoPostBack="false">
                                                                                                    <asp:ListItem Value="0">I agree</asp:ListItem>
                                                                                                    <asp:ListItem Value="1">Disagree</asp:ListItem>
                                                                                                </asp:RadioButtonList>
                                                                                            </td>
                                                                                        </tr>

                                                                                        <tr class="gridviewRowstyle">
                                                                                            <td colspan="2">
                                                                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                                                                    <tr>
                                                                                                        <td width="80%">
                                                                                                            <telerik:RadGrid ID="gvStandard" runat="server"
                                                                                                                AutoGenerateColumns="False" Skin="<%$ Resources:AppConfigurations,Skin_Current %>"
                                                                                                                CellSpacing="0" GridLines="None">
                                                                                                                <GroupingSettings CaseSensitive="false" />
                                                                                                                <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD"
                                                                                                                    FilterItemStyle-HorizontalAlign="Center">
                                                                                                                    <NoRecordsTemplate>
                                                                                                                        No records to display.
                                                                                                                    </NoRecordsTemplate>
                                                                                                                    <Columns>

                                                                                                                        <telerik:GridBoundColumn DataField="RuleDesc" HeaderText="Standard Rules"
                                                                                                                            UniqueName="RuleDesc" HeaderStyle-HorizontalAlign="Left" AllowSorting="false">
                                                                                                                            <ItemStyle HorizontalAlign="Left" Width="100%" />
                                                                                                                            <HeaderStyle Font-Bold="true" />
                                                                                                                        </telerik:GridBoundColumn>
                                                                                                                    </Columns>

                                                                                                                </MasterTableView>

                                                                                                            </telerik:RadGrid>
                                                                                                        </td>
                                                                                                        <td width="20%" valign="top">
                                                                                                            <table width="100%" style="border-right: 1px solid #4e75b3; border-bottom: 1px solid #4e75b3; background: #fff;" cellpadding="0" cellspacing="0">
                                                                                                                <tr>
                                                                                                                    <td style="background: url(../Images/gridheader.jpg) repeat-x; height: 27px;"></td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td style="height: 216px;">
                                                                                                                        <asp:RadioButtonList ID="radio_standardrule" runat="server" RepeatDirection="Horizontal"
                                                                                                                            AutoPostBack="false">
                                                                                                                            <asp:ListItem Value="0">I agree</asp:ListItem>
                                                                                                                        </asp:RadioButtonList>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>

                                                                                                        </td>

                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>

                                                                                        </tr>
                                                                                        <tr class="gridviewRowstyle" id="trAllowed" runat="server">
                                                                                            <td colspan="2" width="100%">

                                                                                                <telerik:RadGrid ID="gvAllowed" runat="server"
                                                                                                    AutoGenerateColumns="False" Skin="<%$ Resources:AppConfigurations,Skin_Current %>"
                                                                                                    CellSpacing="0" GridLines="None" MasterTableView-DataKeyNames="RuleID">
                                                                                                    <GroupingSettings CaseSensitive="false" />
                                                                                                    <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD"
                                                                                                        FilterItemStyle-HorizontalAlign="Center">
                                                                                                        <NoRecordsTemplate>
                                                                                                            No records to display.
                                                                                                        </NoRecordsTemplate>
                                                                                                        <Columns>

                                                                                                            <telerik:GridBoundColumn DataField="RuleDesc" HeaderText="Additional Rules"
                                                                                                                UniqueName="RuleDesc" HeaderStyle-HorizontalAlign="Left" AllowSorting="false">
                                                                                                                <ItemStyle HorizontalAlign="Left" Width="80%" />
                                                                                                                <HeaderStyle Font-Bold="true" />
                                                                                                            </telerik:GridBoundColumn>

                                                                                                            <telerik:GridTemplateColumn DefaultInsertValue="" UniqueName="rbt_Additionalrules">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:RadioButton ID="rbt_Additionalrules" Text="I agree" AllowMultiRowSelection="true"
                                                                                                                        runat="server" />
                                                                                                                </ItemTemplate>
                                                                                                                <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                                                                            </telerik:GridTemplateColumn>
                                                                                                        </Columns>

                                                                                                    </MasterTableView>

                                                                                                </telerik:RadGrid>

                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr class="gridviewRowstyle" runat="server" id="trSpecialStudent">
                                                                                            <td colspan="2" style="padding-top: 5px; padding-bottom: 5px;" width="100%">

                                                                                                <telerik:RadGrid ID="gvSpecialInstructions_Student" runat="server"
                                                                                                    AutoGenerateColumns="False" Skin="<%$ Resources:AppConfigurations,Skin_Current %>"
                                                                                                    CellSpacing="0" GridLines="None" MasterTableView-DataKeyNames="RuleID">
                                                                                                    <GroupingSettings CaseSensitive="false" />
                                                                                                    <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD"
                                                                                                        FilterItemStyle-HorizontalAlign="Center">
                                                                                                        <NoRecordsTemplate>
                                                                                                            No records to display.
                                                                                                        </NoRecordsTemplate>
                                                                                                        <Columns>

                                                                                                            <telerik:GridBoundColumn DataField="RuleDesc" HeaderText="Special Instructions"
                                                                                                                UniqueName="RuleDesc" HeaderStyle-HorizontalAlign="Left" AllowSorting="false">
                                                                                                                <ItemStyle HorizontalAlign="Left" Width="80%" />
                                                                                                                <HeaderStyle Font-Bold="true" />
                                                                                                            </telerik:GridBoundColumn>


                                                                                                            <telerik:GridTemplateColumn DefaultInsertValue="" UniqueName="rbt_SpecialInstructions">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:RadioButton ID="rbt_SpecialInstructions" Text="I agree" AllowMultiRowSelection="true"
                                                                                                                        runat="server" />
                                                                                                                </ItemTemplate>
                                                                                                                <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                                                                            </telerik:GridTemplateColumn>


                                                                                                        </Columns>

                                                                                                    </MasterTableView>

                                                                                                </telerik:RadGrid>

                                                                                            </td>
                                                                                        </tr>

                                                                                        <tr>
                                                                                            <td align="center" colspan="2">
                                                                                                <input type="button" value="Submit" class="button_new blue" onclick="StepFn('divStep3', 'divStep4', 'navigate', '');" />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <div id="divStep4" style="display: none;">
                                            <script language="javascript" type="text/javascript">
                                                function NavigateToExamPage(ExamURl) {
                                                    var params = ['height=' + screen.height, 'width=' + screen.width, 'fullscreen=yes,menubar=0,toolbar=0,resizable=0'].join(',');
                                                    window.open(ExamURl, '', params);
                                                }

                                                function OpenSurveyLink() {
                                                    var params = ['height=' + screen.height, 'width=' + screen.width, 'fullscreen=yes,menubar=0,toolbar=0,resizable=0'].join(',');
                                                    window.open('https://www.surveymonkey.com/s/ExamityEKU', '');
                                                }
                                            </script>
                                            <script type="text/javascript">
                                                function closeExam() {
                                                    $.post('../AjaxHandler.aspx', { Method: "ValidateStep4", TransID: '<%= Request.QueryString["TransID"].ToString() %>' }, function (data) {
                                                        if (data == "true") {
                                                            stopRec('<%= GetTransID() %>');
                                                        }
                                                    });
                                                }
                                                function setStatus(action) {
                                                    if (action == 1)
                                                        BeginExam();
                                                    else {
                                                        $.post('../AjaxHandler.aspx', { Method: "setStatus", TransID: '<%= Request.QueryString["TransID"].ToString() %>' }, function (data) {

                                                        });
                                                    }
                                                }
                                            </script>
                                            <div class="steps3" style="width: 777px; margin: 0px auto;">
                                            </div>
                                            <table cellpadding="2" cellspacing="2" width="100%">
                                                <tr>
                                                    <td width="100%" valign="top" colspan="2">
                                                        <div class="login_new_steps">
                                                            <table width="100%" cellpadding="5" cellspacing="5">
                                                                <tr>
                                                                    <td>
                                                                        <table width="90%" cellpadding="5" cellspacing="5" align="center">
                                                                            <tr>
                                                                                <td align="center"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center">
                                                                                    <div style="font-size: 16px; font-weight: bold;">
                                                                                        <asp:Label ID="lblExamID" runat="server"></asp:Label>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center">
                                                                                    <div style="font-size: 16px; font-weight: bold;">
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center">
                                                                                    <div id="DivStartExam">
                                                                                        <%if (GetExamDetailsByTransID() == "True")
                                                                                          { %>
                                                                                        <input id="btnBeginExam" type="button" value="Begin Exam" onclick="setStatus(1);"
                                                                                            style="background: none; border: none; font-size: 20px; color: blue; font-weight: bold; cursor: pointer; text-decoration: underline;" />
                                                                                        <%}
                                                                                          else
                                                                                          { %>
                                                                                        <a href="<%= GetExamLink() %>" target="_blank" style="font-size: 18px; color: Blue; text-decoration: underline; font-weight: bold"
                                                                                            onclick="setStatus(0);">Begin Exam</a>
                                                                                        <%} %>
                                                                                    </div>
                                                                                   
                                                                                   <div>
                                                                                     
                                                                                                 <table width="100%">
                                                                                                <tr>
                                                                                                   <%-- <td align="right" width="30%">&nbsp;&nbsp;&nbsp; <strong>Uploaded files</strong>&nbsp;&nbsp;&nbsp;
                                                                                                    </td>--%>
                                                                                                    <td align="left" width="70%">

                                                                                                        <telerik:RadGrid ID="gvUploadFiles" runat="server"
                AutoGenerateColumns="False" 
                CellSpacing="0" GridLines="None"  PageSize="5" Visible="false">
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
                                                         
                                                                  <asp:LinkButton ID="lnkOriginalFileName" runat="server"  Text='<%# Eval("OriginalFileName")%>' CommandArgument='<%# Bind("StoredFileName")%>' CommandName="uploadFile" Font-Underline="true" OnClick="lnlFile_Click"/>
                                              
                                                        
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <HeaderStyle Font-Bold="true" HorizontalAlign="Center" />
                                                    </telerik:GridTemplateColumn>



                    </Columns>

                  

                </MasterTableView>
      

            </telerik:RadGrid>

                                                                                                  

                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                       
                                                                                         

                                                                                     </div>
                                                                                    

                                                                                    <div id="DivSurvey" style="display: none;">
                                                                                        <%--<a href="#">Examity Survey</a>--%>
                                                                                        <br />
                                                                                        <br />
                                                                                        <span style="font-size: 16px;">Have something to say about your Examity experience?
                                                                                            Answer our 3-question </span>
                                                                                         <a onclick="window.open('https://Prod.Examity.com/ExamitySurvey/Survey.aspx?ClientID=80ND5570sdM=&ExamID=<%= GetTransID()%>&Env=<%= ConfigurationManager.AppSettings["LockDownPrefix"] %>')" style="font-size: 16px; text-decoration: underline; color: Blue; cursor: pointer;">Survey</a>
                                                                                       <%-- <a onclick="window.open('https://www.surveymonkey.com/s/ExamityEKU')"
                                                                                                style="font-size: 16px; text-decoration: underline; color: Blue; cursor: pointer;">Survey</a>--%>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center" id="tdOutOfBrowser">&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="visibility: hidden;">
                                                                                <td align="center">
                                                                                    <div style="font-size: 18px;">
                                                                                        <asp:Label ID="lblInfor1" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="visibility: hidden;">
                                                                                <td align="center">
                                                                                    <div style="font-size: 18px;">
                                                                                        <asp:Label ID="lblInfor2" runat="server" Visible="false"></asp:Label>
                                                                                    </div>
                                                                                    <br />
                                                                                    <input type="button" value="Close Exam" onclick="closeExam();" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center"></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
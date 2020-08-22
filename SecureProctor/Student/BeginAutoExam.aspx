<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true" CodeBehind="BeginAutoExam.aspx.cs" Inherits="SecureProctor.Student.BeginAutoExam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StudentContent" runat="server">

    <script src="../js/jquery-1.8.1.min.js"></script>
    <a id="hiddenLink" style="display: none;" href="#">examity</a>
    <iframe id="hiddenIframe" src="about:blank" style="display: none"></iframe>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#submit_button').click(function () {
                if (!$("input[name='name']:checked").val()) {
                    alert('Nothing is checked!');
                    return false;
                }
                else {
                    alert('One of the radio buttons is checked!');
                }
            });
        });
        function examiFacedownloadApp() {
            appOpened = false;
            if (navigator.appVersion.indexOf("Win") != -1) {
                window.open('https://prod.examity.com/commonfiles/ExamityAutomatedProctoring.exe', '_self');
                $.post('../AjaxHandler.aspx', { Method: "setexamiFACEDownLoadStatus", TransID: '<%= Request.QueryString["TransID"].ToString() %>', Status: '2' }, function (data) {
                });
                $('#divdownload').attr('style', 'display:none;');
                $('#divlaunch').attr('style', 'display:block;');
            }
            else if (navigator.appVersion.indexOf("Mac") != -1) {
                if (navigator.userAgent.indexOf("Safari") >= 0) {
                    window.open('https://prod.examity.com/commonfiles/ExamityAutomatedProctoring.pkg', '_blank');
                }
                else {
                    window.open('https://prod.examity.com/commonfiles/ExamityAutomatedProctoring.pkg', '_self');
                }
                $.post('../AjaxHandler.aspx', { Method: "setexamiFACEDownLoadStatus", TransID: '<%= Request.QueryString["TransID"].ToString() %>', Status: '2' }, function (data) {
                });
                $('#divdownload').attr('style', 'display:none;');
                $('#divlaunch').attr('style', 'display:block;');
            }
            else {
                alert("Currently examiFACE <sup>&reg;</sup> do not support current Operating System. Please contact our support.");
            }
    }

    function examiFacehelp() {
        appOpened = false;
        if (navigator.appVersion.indexOf("Win") != -1) {
            window.open('https://prod.examity.com/commonfiles/AutoProctorHelp/Steps for Installing on Windows.pdf', 'blank');
        }
        else if (navigator.appVersion.indexOf("Mac") != -1) {
            window.open('https://prod.examity.com/commonfiles/AutoProctorHelp/Steps for Installing on MAC.pdf', 'blank');
        }
    }

    //Default State
    var isSupported = false;
    var appOpened = true;
    var isChrome = false;

    function getExamiFaceProtocol() {
        return "EXAMIFACE";
    }

    function getexamiFACEUrl() {
        return getExamiFaceProtocol() + ":<%= GetExamiFaceFaceTransID()%>";
    }

    function result() {
        if (isSupported) {
            if (isChrome && !appOpened) {
                // $("#LDBDialogBg").hide();
                // $('#LDBDialog').dialog("close");
            }

            //$.post('../AjaxHandler.aspx', { Method: "setStatus", TransID: '<%= Request.QueryString["TransID"].ToString() %>' }, function (data) {
            // });
        }
        else {
            if (isChrome) {
                isSupported = true;
                appOpened = false;
                setTimeout(function () {
                    Faceresult();
                }, 20000);
            }
        }
    }

    //Handle IE
    var myVal = 1;
    function launchIE() {
        if (navigator.msLaunchUri) {
            isSupported = true;
            setTimeout(function () { Faceresult(); }, 1000);
            navigator.msLaunchUri(getexamiFACEUrl(),
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

        var url = getexamiFACEUrl(),
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
            //alert(e.name)
        }

    }

    //Handle Chrome
    function launchChrome() {
        isChrome = true;
        var url = getexamiFACEUrl(),
            protcolEl = $('#btnexamiface')[0];

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
        var myWin = window.open(getexamiFACEUrl(), "_self");
        setTimeout(function () {
            // examiAlert();
            setTimeout(function () {
                if (appOpened) {
                    //$.post('../AjaxHandler.aspx', { Method: "setStatus", TransID: '<%= Request.QueryString["TransID"].ToString() %>' }, function (data) {

                    // });
                }
            }, 10000)
        }, 5000);
    }

    function BeginExamFACE() {
        var isIE11 = !!navigator.userAgent.match(/Trident.*rv\:11\./);
        if (isIE11) {
            launchIE();
        }
        else if ($.browser.mozilla) {
            launchMozilla();
        } else if ($.browser.chrome) {
            launchChrome();
        } else if ($.browser.msie) {
            launchIE();
        } else {
            launchOther();
        }
    }
    </script>

    <style type="text/css">

        ol {margin:0px;padding:0px;
        }
         .k {
            -webkit-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
            counter-reset: steps;
            overflow: hidden;
            list-style: none;
            padding: 0;
            margin: 0 0 1em 0;
        }

        .steps__item {
            counter-increment: steps;
            background: #f3f3f3;
            border-top: 1px solid #ccc;
            border-bottom: 1px solid #ccc;
            float: left;
            position: relative;
            white-space: nowrap;
        }

            .steps__item:first-child:nth-last-child(1), .steps__item:first-child:nth-last-child(1) ~ .steps__item {
                width: 100%;
            }

            .steps__item:first-child:nth-last-child(2), .steps__item:first-child:nth-last-child(2) ~ .steps__item {
                width: 50%;
            }

            .steps__item:first-child:nth-last-child(3), .steps__item:first-child:nth-last-child(3) ~ .steps__item {
                width: 33.33333%;
            }

            .steps__item:first-child:nth-last-child(4), .steps__item:first-child:nth-last-child(4) ~ .steps__item {
                width: 25%;
            }

            .steps__item:first-child:nth-last-child(5), .steps__item:first-child:nth-last-child(5) ~ .steps__item {
                width: 20%;
            }

            .steps__item:first-child:nth-last-child(6), .steps__item:first-child:nth-last-child(6) ~ .steps__item {
                width: 16.66667%;
            }

            .steps__item:first-child:nth-last-child(7), .steps__item:first-child:nth-last-child(7) ~ .steps__item {
                width: 14.28571%;
            }

            .steps__item:first-child:nth-last-child(8), .steps__item:first-child:nth-last-child(8) ~ .steps__item {
                width: 12.5%;
            }

            .steps__item:first-child:nth-last-child(9), .steps__item:first-child:nth-last-child(9) ~ .steps__item {
                width: 11.11111%;
            }

            .steps__item:first-child:nth-last-child(10), .steps__item:first-child:nth-last-child(10) ~ .steps__item {
                width: 10%;
            }

            .steps__item:after {
                width: 1.85616em;
                height: 1.85616em;
                position: absolute;
                top: 0.35355em;
                left: 100%;
                -webkit-transform: rotate(45deg);
                transform: rotate(45deg);
                content: '';
                z-index: 2;
                background: inherit;
                border-right: 1px solid #ccc;
                border-top: 1px solid #ccc;
                margin-left: -0.92808em;
            }

            .steps__item[disabled] {
                cursor: not-allowed;
            }

        @media (max-width: 767px) {
            .steps__item {
                width: 100% !important;
                border: 1px solid #ccc;
                border-bottom: none;
                padding: 1em 0;
            }

                .steps__item:after {
                    content: none;
                }
        }

        /**
 * Left border on first item
 */
        .steps__item--first {
            border-left: 1px solid #ccc;
        }

        /**
 * Right border on last item
 */
        .steps__item--last {
            border-right: 1px solid #ccc;
            /**
   * No left arrow on first item
   * No right arrow on last item
   */
        }

        @media (max-width: 767px) {
            .steps__item--last {
                border-bottom: 1px solid #ccc;
            }
        }

        .steps__item--last:after {
            content: none;
        }

        /**
 * Step link
 */
        /*a|span*/
        .steps__link {
            -webkit-transition: .25s ease-out;
            transition: .25s ease-out;
            color: #000;
            display: block;
            text-align: center;
            text-decoration: none;
            padding: 0.5em 0;
            font-weight: bold;
            /**
   * Counter
   */
            /**
   * Hover stuff
   */
        }

            .steps__link:before {
                width: 1.5em;
                height: 1.5em;
                display: inline-block;
                content: counter(steps);
                text-align: center;
                background: #BCBCBC;
                border-radius: 50%;
                color: white;
                margin: 0 1em;
                line-height: 1.5em;
            }

        :not([disabled]) > .steps__link:hover, :not([disabled]) > .steps__link:focus {
            color: #333;
        }

        @media (max-width: 767px) {
            .steps__link:before {
                float: left;
                margin-right: 0;
            }
        }

        /**
 * Active state
 */
        /*a*/
        .steps__item--active {
            background: #FFF;
            /*color:#f78d1d;*/
        }

            /**
 * Change link colors
 */
            .steps__item--done .steps__link,
            .steps__item--active .steps__link {
                color: #f78d1d;
            }

                .steps__item--done .steps__link:before,
                .steps__item--active .steps__link:before {
                    background: #f78d1d;
                }

        /**
 * Fallback for IE 8
 * Require Modernizr
 */
        /*html*/
        .no-csstransforms {
            /*li*/
        }

            .no-csstransforms .steps__item {
                border-right: 1px solid #ccc;
            }

                .no-csstransforms .steps__item:after {
                    content: none !important;
                }

        /**
 * Fallback for IE 7
 * Require Modernizr
 */
        /*html*/
        .no-generatedcontent .steps {
            list-style-position: inside;
            list-style-type: decimal;
        }

        .no-generatedcontent .steps__link:before {
            content: none;
        }
    </style>
    <style type="text/css">
        input[type=radio ]:not(old) {
            width: 28px;
            margin: 0;
            padding: 0;
            opacity: 0;
        }

            input[type=radio ]:not(old) + label {
                display: inline-block;
                margin-left: -28px;
                padding-left: 28px;
                background: url('../Images/radio.png') no-repeat 0 0;
                line-height: 24px;
            }


            input[type=radio]:not(old):checked + label {
                background-position: 0 -24px;
            }
    </style>

     <script type="text/javascript" language="javascript">
         
         function DispalyMsg() {
             $("#bpassword").hide();
             
             $("#divmsg").show();
         }
    </script>

    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <h1 style="padding: 10px; color: #666;">
                    <asp:Label ID="Label1" runat="server" Text="Begin Exam"></asp:Label>
                </h1>
            </td>
        </tr>
        <tr>
            <td>
                <div class="login_new1">
                    <div class="chat_window">
                        <table cellpadding="2" cellspacing="2" width="100%">
                            <tr>
                                <td align="center" class="AAStep_shadow" valign="top">
                                    <div class="AAStep_shadow_inner">
                                        <div class="AAstepsID5" style="width: 800px; margin: 0px auto;"></div>
                                        <table cellpadding="2" cellspacing="2" width="100%">
                                            <tr>
                                                <td width="100%" align="center">

                                                    <div class="login_new_steps" style="padding-top: 1px">
                                                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                                            <tr>
                                                                <td align="center">
                                                                    <div id="DivBeginExam1">
                                                                        <p style="font-size: 18px; color: #1b1b1b; background: #ffffff; padding: 4px;">
                                                                            Thank you for completing the authentication process.
                                                                        </p>
                                                                    </div>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center">
                                                                    <div id="DivStartExam">
                                                                        <div style="width: 100%; margin: 0 auto;">
                                                                            <ol class="k">
                                                                                <li class="steps__item  steps__item--active" id="download"><span class="steps__link">Download</span></li>
                                                                                <li class="steps__item" id="install"><span class="steps__link">Install</span></li>
                                                                                <li class="steps__item" id="launch"><span class="steps__link">Launch</span></li>
                                                                                <li class="steps__item" id="begin"><span class="steps__link">Begin</span></li>
                                                                            </ol>
                                                                            <div style="clear: both"></div>
                                                                            <div id="divhelp" style="display: none;">
                                                                                <div style="text-align: center; margin-top: 40px">
                                                                                    <a href="javascript:examiFacedownloadApp();" class="examiFACE_btn">Download</a><br />
                                                                                    <br />
                                                                                    <br />
                                                                                    <input id="rdinstled" type="radio" name="instaled" value="" onclick="setStatusExamiFace(5)" /><label for="rdinstled">Already installed</label>
                                                                                    <%-- <input type="radio" id="rdinstled" name="gender" onclick="setStatusExamiFace(5)"/>Software already installed--%>
                                                                                    <br />
                                                                                    <br />
                                                                                    <a href="javascript:examiFacehelp();" style="color: blue; text-decoration: underline;">Need Help?</a>
                                                                                </div>

                                                                            </div>
                                                                            <div style="clear: both"></div>
                                                                            <div id="divinstall" style="display: none;">
                                                                                <div style="text-align: center; margin-top: 10px">
                                                                                    <table width="90%" border="0" cellpadding="6" cellspacing="5" align="center">
                                                                                        <tr>
                                                                                            <td align="center" colspan="5">
                                                                                                <p style="font-size: 20px; color: #1b1b1b; background: #ffffff; padding: 2px;">Installation Instructions</p>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <script type="text/javascript">
                                                                                            if (navigator.appVersion.indexOf("Win") != -1) {
                                                                                                document.write("<tr><td style='background-color:#e5e5e5; text-align:center'><img src='../Images/wsetup1.png' width='380'>");
                                                                                                document.write("<ul style='text-align:left'>");
                                                                                                document.write("<li style='padding:5px;'>Open File Explorer on Toolbar.&nbsp;<img src='../Images/wfolder.png' width='35'></li>");
                                                                                                document.write("<li style='padding:5px;'>Click on Downloads folder.&nbsp;<img src='../Images/wdownload.png' width='65'></li>");
                                                                                                document.write("<li style='padding:5px;'>Locate ExamityAutomatedProctoring.exe. Double click and followed installation instructions.</li>");
                                                                                                document.write("</ul>");
                                                                                                document.write("</td>");
                                                                                                document.write("<td width='20%'>&nbsp;</td>");
                                                                                                document.write("<td style='background-color:#e5e5e5; text-align:center' width='30%'><img src='../Images/wsetup2.png' width='300'><p>");
                                                                                                document.write("<ul style='text-align:left'>");
                                                                                                document.write("<li>Click <b>“Yes”</b></li>");
                                                                                                document.write("</ul>");
                                                                                                document.write("</td>");
                                                                                                document.write("<td width='2%'>&nbsp;</td>");
                                                                                                document.write("<td style='background-color:#e5e5e5; text-align:center' width='30%'><img src='../Images/wsetup3.png' width='300'><p>");
                                                                                                document.write("<ul style='text-align:left'>");
                                                                                                document.write("<li>Click <b>“Next”</b></li>");
                                                                                                document.write("</ul>");
                                                                                                document.write("</td></tr>");
                                                                                            }
                                                                                            else if (navigator.appVersion.indexOf("Mac") != -1) {
                                                                                                document.write("<tr><td style='background-color:#e5e5e5; text-align:center'><img src='../Images/msetup1.png' width='500'>");
                                                                                                document.write("<ul style='text-align:left'>");
                                                                                                document.write("<li style='padding:5px;'>Open <b>Finder</b> app. &nbsp;<img src='../Images/mfinder.png' width='35'></li>");
                                                                                                document.write("<li style='padding:5px;'>Click on <b>Downloads</b> folder. &nbsp;<img src='../Images/mdownloads.png' width='65'></li>");
                                                                                                document.write("<li style='padding:5px;'>Locate ExamityAutomatedProctoring.pkg. Double click and followed installation instructions.</li>");
                                                                                                document.write("</ul>");
                                                                                                document.write("</td>");
                                                                                                document.write("<td width='2%' colspan='3'>&nbsp;</td>");
                                                                                                document.write("<td style='background-color:#e5e5e5; text-align:center' width='30%'><img src='../Images/msetup2.png' width='500'><p>");
                                                                                                document.write("<ul style='text-align:left'>");
                                                                                                document.write("<li>Click <b>“Continue”</b></li>");
                                                                                                document.write("</ul>");
                                                                                                document.write("</td></tr>");
                                                                                            }
                                                                                        </script>
                                                                                        <tr>
                                                                                            <td align="center" colspan="5">
																							<p style="padding: 2px;"><a href="javascript:setStatusExamiFace(2);" class="examiFACE_btn">Click when installation completed</a></p>
                                                                                                
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </div>
                                                                            </div>
                                                                            <div style="clear: both"></div>
                                                                            <div id="divlaunch" style="display: none;">
                                                                                <div>
                                                                                <p class="download_text">After installation, Launch AutomatedProctoring.</p>
                                                                                 </div>
                                                                                 <div style="clear: both"></div>
                                                                                <div class="ViewInstructions-mainblock">
                                                                                    <ul>
                                                                                        <li>
                                                                                            <div>
                                                                                                <img src="../Images/icon_1.png" border="0" /></div>
                                                                                            <br>
                                                                                            <div>You must be in a well-lit environment and your face must be clearly visible throughout the exam.</div>
                                                                                        </li>
                                                                                        <li>
                                                                                            <div>
                                                                                                <img src="../Images/icon_2.png" border="0" /></div>
                                                                                            <br>
                                                                                            <div>You must be alone in the room. Communicating with anyone else is prohibited.</div>
                                                                                        </li>
                                                                                        <li>
                                                                                            <div>
                                                                                                <img src="../Images/icon_3.png" border="0" /></div>
                                                                                            <br>
                                                                                            <div>You must remain in the center of the webcam frame throughout the exam.</div>
                                                                                        </li>
                                                                                        <li>
                                                                                            <div>
                                                                                                <img src="../Images/icon_4.png" border="0" /></div>
                                                                                            <br>
                                                                                            <div>Hats, sunglasses, hoods, or anything else that obscures the view of your face is prohibited.</div>
                                                                                        </li>
                                                                                        <li>
                                                                                            <div>
                                                                                                <img src="../Images/icon_5.png" border="0" /></div>
                                                                                            <br>
                                                                                            <div>You must close the application and allow the upload process to complete before closing or powering off your computer.</div>
                                                                                        </li>
                                                                                    </ul>
                                                                                </div>
                                                                                 <div style="clear: both"></div>
                                                                                <div style="text-align: center;">
                                                                                    <br />
                                                                                    <a id="btnexamiface" href="javascript:setStatusExamiFace(1);" class="examiFACE_btn">Agree and Launch Application</a>
                                                                                    <%-- <input id="btnexamiface" type="button" value="Launch" onclick="javascript:setStatusExamiFace(1);" class="examiFACE_btn" />--%>
                                                                                    <%--</a>--%>
                                                                                </div>
                                                                            </div>
                                                                            <div style="clear: both"></div>
                                                                            <div id="divbegin" style="display: none">
                                                                                <div id="examlink" style="display: none;">
                                                                                    <p class="download_text">Click on Begin Exam </p>

                                                                                     <br />
                                                                            <br />
                                                                             <div id="divpassword" runat="server" style="display:none;">
                                                                            <div id="bpassword">
                                                                                 <input id="btnpassword" type="button" value="Get Password" onclick="DispalyMsg();" class="examilock_orange_buttom" />
                                                                            </div>
                                                                             <div style="width:50%; padding:5px;display:none" id="divmsg">
                                                                           
                                                                            <asp:TextBox runat="server" ID="txtpassword" ReadOnly="true" style="font-size:16px; width:80%; padding:10px;color:#666" Text=""></asp:TextBox>
                                                                            <br />
                                                                            <br />
                                                                           
                                                                          
                                                                                   <ul>
                                                                                   <li  style="font-size:14px; color:black; text-align:left;line-height:24px">
                                                                                     <span > Copy paste the password in your LMS when prompted to enter password</span>
                                                                                   </li>
                                                                                  <%-- <li style="font-size:14px; color:red; text-align:left;line-height:24px">
                                                                                     <span > This should be entered in your LMS in order to take the test</span>
                                                                                   </li>--%>
                                                                                    <li style="font-size:14px;font-weight: bold; color:red; text-align:left;line-height:24px">
                                                                                     <span >Sharing this password with others is considered as a violation</span>
                                                                                   </li>
                                                                               </ul>
                                                                              
                                                                              <%-- <span style="font-size:14px; color:green;">Your Password has been generated. To begin your exam you must right click and paste it in the password field.Please click on Begin Exam button below to Contune.</span>--%>
                                                                           </div>
                                                                            <br />
                                                                                 </div>
                                                                                    <br />
                                                                                    <div style="text-align: center;">
                                                                                        <a href="<%= GetExamLink() %>" target="_blank" onclick="javascript:setStatusExamiFace(0);" class="examiFACE_btn">Begin Exam</a>
                                                                                    </div>
                                                                                </div>
                                                                                <div style="clear: both"></div>
                                                                                <div id="examlink1" style="display: none;">
                                                                                    <p class="download_text">Begin Exam link will appear once ExamityAutomatedProctoring application is launched. </p>
                                                                                    <p class="download_text">
                                                                                        AutomatedProctoring application did not launch successfully, please repeat the download and installation steps by clicking <a href="javascript:setStatusExamiFace1();" style="color: blue; text-decoration: none;">here</a>
                                                                                        .
                                                                                    </p>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td align="left" width="70%">
                                                                                <telerik:RadGrid ID="gvUploadFiles" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" PageSize="5" Visible="false">
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
                                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                                <HeaderStyle Font-Bold="true" HorizontalAlign="Center" />
                                                                                            </telerik:GridTemplateColumn>
                                                                                        </Columns>
                                                                                    </MasterTableView>
                                                                                </telerik:RadGrid>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr id="trSurvey" style="display: none">
                                                                <td align="center">

                                                                    <div id="DivSurvey">
                                                                             <div id="divpwd" style="width:50%; padding:5px; display:none;">
                                                                           <input id="txtspwd" name="txtspwd" type="text" autocomplete="off" readonly="readonly" autofocus="autofocus" tabindex="60" style="height: 25px; font-size: 16px; width: 80%" />&nbsp;                        
                                                                            <%--<asp:TextBox runat="server" ID="txtspwd" ReadOnly="true" style="font-size:16px; width:80%; padding:10px;color:#666" Text="testpassword"></asp:TextBox>--%>
                                                                            <br />
                                                                            <br />
                                                                           
                                                                          
                                                                                   <ul>
                                                                                   <li  style="font-size:14px; color:black; text-align:left;line-height:24px">
                                                                                     <span > Copy paste the password in your LMS when prompted to enter password</span>
                                                                                   </li>
                                                                                  <%-- <li style="font-size:14px; color:red; text-align:left;line-height:24px">
                                                                                     <span > This should be entered in your LMS in order to take the test</span>
                                                                                   </li>--%>
                                                                                    <li style="font-size:14px;font-weight: bold; color:red; text-align:left;line-height:24px">
                                                                                     <span >Sharing this password with others is considered as a violation</span>
                                                                                   </li>
                                                                               </ul>
                                                                              
                                                                              <%-- <span style="font-size:14px; color:green;">Your Password has been generated. To begin your exam you must right click and paste it in the password field.Please click on Begin Exam button below to Contune.</span>--%>
                                                                           </div>
                                                                           
                                                                                
                                                                        <br />
                                                                        <br />
                                                                        <span style="font-size: 16px;">Have something to say about your Examity experience?
                                                                                            Answer our 3-question </span><a onclick="window.open('<%= ConfigurationManager.AppSettings["SurveyLink"]%>&ExamID=<%= Request.QueryString["TransID"].ToString() %>')" style="font-size: 16px; text-decoration: underline; color: Blue; cursor: pointer;">Survey</a>

                                                                    </div>
                                                                </td>
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
                    </div>
                </div>
            </td>
        </tr>
    </table>

    <script type="text/javascript">

        function setStatusExamiFace1(action) {
            $.post('../AjaxHandler.aspx', { Method: "setexamiFACEDownLoadStatus1", TransID: '<%= Request.QueryString["TransID"].ToString() %>', Status: '1' },
                function (data) {
                });
        }

        function setStatusExamiFace(action) {

            if (action == 1) {
                BeginExamFACE();
                $.post('../AjaxHandler.aspx', { Method: "setexamiFACEDownLoadStatus", TransID: '<%= Request.QueryString["TransID"].ToString() %>', Status: '4' },
                    function (data) {
                        $('#divhelp').attr('style', 'display:none;');
                        $('#divinstall').attr('style', 'display:none;');
                        $('#divlaunch').attr('style', 'display:block;');
                        $('#divbegin').attr('style', 'display:none;');

                        $('#download').removeClass('steps__item--active');
                        $('#install').removeClass('steps__item--active');
                        $('#launch').addClass('steps__item--active');
                        $('#begin').removeClass('steps__item--active');

                        $('#adownload').removeAttr('href');
                        $('#ainstall').removeAttr('href');
                        $("#alaunch").removeAttr('href');
                        $('#abegin').removeAttr('href');
                        $('#DivBeginExam1').attr('style', 'display:none;');
                    });

            }
            else if (action == 2) {
                $.post('../AjaxHandler.aspx', { Method: "setexamiFACEDownLoadStatus", TransID: '<%= Request.QueryString["TransID"].ToString() %>', Status: '3' }, function (data) {

                    $('#divhelp').attr('style', 'display:none;');
                    $('#divinstall').attr('style', 'display:none;');
                    $('#divlaunch').attr('style', 'display:block;');
                    $('#divbegin').attr('style', 'display:none;');

                    $('#download').removeClass('steps__item--active');
                    $('#install').removeClass('steps__item--active');
                    $('#launch').removeClass('steps__item--active');
                    $('#begin').addClass('steps__item--active');

                    $('#adownload').removeAttr('href');
                    $('#ainstall').removeAttr('href');
                    $("#alaunch").removeAttr('href');
                    $('#abegin').removeAttr('href');
                    $('#DivBeginExam1').attr('style', 'display:none;');
                });

            }
            else if (action == 5) {
                $.post('../AjaxHandler.aspx', { Method: "setexamiFACEDownLoadStatus", TransID: '<%= Request.QueryString["TransID"].ToString() %>', Status: '5' }, function (data) {

                    $('#divhelp').attr('style', 'display:none;');
                    $('#divinstall').attr('style', 'display:none;');
                    $('#divlaunch').attr('style', 'display:block;');
                    $('#divbegin').attr('style', 'display:none;');

                    $('#download').removeClass('steps__item--active');
                    $('#install').removeClass('steps__item--active');
                    $('#launch').removeClass('steps__item--active');
                    $('#begin').addClass('steps__item--active');

                    $('#adownload').removeAttr('href');
                    $('#ainstall').removeAttr('href');
                    $("#alaunch").removeAttr('href');
                    $('#abegin').removeAttr('href');
                    $('#DivBeginExam1').attr('style', 'display:none;');
                });

            }
            else if (action == 0) {
                $.post('../AjaxHandler.aspx', { Method: "setexamiFACEStatus", TransID: '<%= Request.QueryString["TransID"].ToString() %>' }, function (data) {
                    $('#trSurvey').attr('style', 'display:block;');
                    $('#trSurvey').attr('style', 'align:center;');
                    var pwd = document.getElementById('<%= txtpassword.ClientID %>').value;
                    if (pwd != '') {
                        $('#divpwd').attr('style', 'display:block; width:50%; padding:5px;');
                        $("#txtspwd").val(pwd);
                    }
                    else
                        $('#divpwd').attr('style', 'display:none;');

                    $('#DivBeginExam1').attr('style', 'display:none;');
                });
            }
}
    </script>

    <script type="text/javascript" src="../Scripts/jquery-timer.js"></script>
    <script type="text/javascript">
        var DIV5FOCUS = 0;
        var timer =
        $.timer(function getValidationStatus() {
            $.post('../Proctor/AjaxResponse.aspx', { Method: "StartExam", TransID: '<%= Request.QueryString["TransID"].ToString() %>' }, function (data) {
                //alert(data);
                if (data == "1") {
                    /// Download enabling
                    $('#DivSurvey').attr('style', 'display:none;');
                    $('#download').addClass('steps__item--active');
                    $('#install').removeClass('steps__item--active');
                    $('#begin').removeClass('steps__item--active');
                    $('#launch').removeClass('steps__item--active');
                    $('#adownload').removeAttr('href');
                    $('#ainstall').removeAttr('href');
                    $('#abegin').removeAttr('href');
                    $("#alaunch").removeAttr('href');
                    $('#divhelp').attr('style', 'display:block;');
                    $('#divinstall').attr('style', 'display:none;');
                    $('#divlaunch').attr('style', 'display:none;');
                    $('#divbegin').attr('style', 'display:none;');
                    $('#DivBeginExam1').attr('style', 'display:block;');
                    $('#rdinstled').attr('checked', false);
                }
                else if (data == "2") {
                    /// install enabling
                    $('#DivSurvey').attr('style', 'display:none;');
                    $('#download').removeClass('steps__item--active');
                    $('#install').addClass('steps__item--active');
                    $('#begin').removeClass('steps__item--active');
                    $('#launch').removeClass('steps__item--active');
                    $('#adownload').removeAttr('href');
                    $('#ainstall').removeAttr('href');
                    $('#abegin').removeAttr('href');
                    $("#alaunch").removeAttr('href');
                    $('#divhelp').attr('style', 'display:none;');
                    $('#divinstall').attr('style', 'display:block;');
                    $('#divlaunch').attr('style', 'display:none;');
                    $('#divbegin').attr('style', 'display:none;');
                    $('#DivBeginExam1').attr('style', 'display:none;');
                }
                else if (data == "3") {
                    //launch enabling
                    $('#DivSurvey').attr('style', 'display:none;');
                    $('#download').removeClass('steps__item--active');
                    $('#install').removeClass('steps__item--active');
                    $('#begin').removeClass('steps__item--active');
                    $('#launch').addClass('steps__item--active');
                    $('#adownload').removeAttr('href');
                    $('#ainstall').removeAttr('href');
                    $('#abegin').removeAttr('href');
                    $("#alaunch").removeAttr('href');
                    $('#divhelp').attr('style', 'display:none;');
                    $('#divinstall').attr('style', 'display:none;');
                    $('#divlaunch').attr('style', 'display:block;');
                    $('#divbegin').attr('style', 'display:none;');
                    $('#DivBeginExam1').attr('style', 'display:none;');
                    $('#rdinstled').attr('checked', false);
                }
                else if (data == "4") {

                    $('#download').removeClass('steps__item--active');
                    $('#install').removeClass('steps__item--active');
                    $('#begin').addClass('steps__item--active');
                    $('#launch').removeClass('steps__item--active');

                    $('#adownload').removeAttr('href');
                    $('#ainstall').removeAttr('href');
                    $('#abegin').removeAttr('href');
                    $("#alaunch").removeAttr('href');

                    $('#divhelp').attr('style', 'display:none;');
                    $('#divinstall').attr('style', 'display:none;');
                    $('#divlaunch').attr('style', 'display:none;');
                    $('#divbegin').attr('style', 'display:block;');
                    $('#examlink1').attr('style', 'display:block;');
                    $('#examlink').attr('style', 'display:none;');
                    $('#DivBeginExam1').attr('style', 'display:none;');
                    $('#DivSurvey').attr('style', 'display:none;');
                    $('#trSurvey').attr('style', 'display:none;');
                }
                else if (data == "5") {
                    $('#download').removeClass('steps__item--active');
                    $('#install').removeClass('steps__item--active');
                    $('#begin').addClass('steps__item--active');
                    $('#launch').removeClass('steps__item--active');

                    $('#adownload').removeAttr('href');
                    $('#ainstall').removeAttr('href');
                    $('#abegin').removeAttr('href');
                    $("#alaunch").removeAttr('href');

                    $('#divhelp').attr('style', 'display:none;');
                    $('#divinstall').attr('style', 'display:none;');
                    $('#divlaunch').attr('style', 'display:none;');
                    $('#divbegin').attr('style', 'display:block;');
                    $('#examlink1').attr('style', 'display:none;');
                    $('#examlink').attr('style', 'display:block;');
                    $('#DivBeginExam1').attr('style', 'display:none;');
                }
                else {
                    $('#DivStartExam').attr('style', 'display:none;');
                    $('#trSurvey').attr('style', 'display:block;');
                    $('#trSurvey').attr('style', 'align:center;');
                    var pwd = document.getElementById('<%= txtpassword.ClientID %>').value;
                    if (pwd != '') {
                        $('#divpwd').attr('style', 'display:block; width:50%; padding:5px;');
                        var p = $('#txtspwd').val();
                        if (p == '') {
                            $("#txtspwd").val(pwd);
                        }
                    }
                    else
                        $('#divpwd').attr('style', 'display:none;');

                    $('#DivSurvey').attr('style', 'display:block;');
                    $('#DivBeginExam1').attr('style', 'display:none;');
                }
            });
        }, 1000, true);
    </script>
</asp:Content>

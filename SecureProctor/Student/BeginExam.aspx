<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true" CodeBehind="BeginExam.aspx.cs" Inherits="SecureProctor.Student.BeginExam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StudentContent" runat="server">
    <%--<script src="../js/jquery-1.9.1.js"></script>--%>
    <script src="../js/jquery-1.8.1.min.js"></script>
    <%--    <script src="../js/jquery-ui.js"></script>--%>
    <a id="hiddenLink" style="display: none;" href="#">examity</a>
    <iframe id="hiddenIframe" src="about:blank" style="display: none"></iframe>

    <script type="text/javascript">

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
                    //$("#LDBDialogBg").hide();
                    //$('#LDBDialog').dialog("close");
                }
                $.post('../AjaxHandler.aspx', { Method: "setStatus", TransID: '<%= Request.QueryString["TransID"].ToString() %>' }, function (data) {

                });
            }
            else {
                //examiAlert();
                if (isChrome) {
                    isSupported = true;
                    appOpened = false;
                    setTimeout(function () {
                        result();
                    }, 20000);
                }
            }
        }

        function Faceresult() {
            if (isSupported) {
                if (isChrome && !appOpened) {
                    // $("#LDBDialogBg").hide();
                    // $('#LDBDialog').dialog("close");
                }

            }
            else {
                // examiAlert();
                if (isChrome) {
                    isSupported = true;
                    appOpened = false;
                    setTimeout(function () {
                        Faceresult();
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
                examiAlert();
                setTimeout(function () {
                    if (appOpened) {
                        $.post('../AjaxHandler.aspx', { Method: "setStatus", TransID: '<%= Request.QueryString["TransID"].ToString() %>' }, function (data) {

                        });

                        // $("#LDBDialogBg").hide();
                        //$('#LDBDialog').dialog("close");
                    }
                }, 10000)
            }, 5000);
        }

        function BeginExam() {
            var isIE11 = !!navigator.userAgent.match(/Trident.*rv\:11\./);
            if (isIE11) {
                launchIE();
            }
            if ($.browser.mozilla) {
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

    <script type="text/javascript">
        function downloadApp() {
            appOpened = false;
            if (navigator.appVersion.indexOf("Win") != -1) {
                window.open('https://prod.examity.com/commonfiles/examiLOCK.exe', '_self');
            }
            else if (navigator.appVersion.indexOf("Mac") != -1) {
                window.open('https://prod.examity.com/commonfiles/examiLOCK.pkg', '_self');
            }
            else {
                alert("Currently examiLOCK <sup>&reg;</sup> do not support current Operating System. Please contact our support.");
            }
        }
        function DispalyMsg() {
            $("#bpassword").hide();

            $("#divmsg").show();
        }
    </script>

    <script type="text/javascript" language="javascript">


        $(document).ready(function () {
            document.getElementById('BeginExamWithAutoPassword').addEventListener('click', BeginExamWithAutoPassword);
        });       

        //Insert password extension code begins
        function BeginExamWithAutoPassword() {
            var examUrl = "<%= GetExamLink() %>";
            setStatus(0);           
             // we are sending a message to extension and open exam in new tab
                        
            var signalObj = { cname: "<%= ConfigurationManager.AppSettings["client"].ToString()%>" ,
                transID: "<%= Request.QueryString["TransID"].ToString()%>", token: "$tr30!0g73x@w!t73102"
                
            }
            signalObj = JSON.stringify(signalObj);

            var event = new CustomEvent(
                           "TransIDSignal",
                           {
                               detail: {
                                   message: signalObj,
                                   signal: "transid"
                               },
                               bubbles: true,
                               cancelable: true
                           }

                       );
            document.dispatchEvent(event);

            setTimeout(function () {
             
                window.open(examUrl);
            }, 1000);
        }
        //Insert password extension code ends
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
                                                    <div class="login_new_steps">
                                                        <table width="100%" cellpadding="2" cellspacing="4">
                                                            <tr>
                                                                <td align="center">
                                                                    <div id="DivBeginExam1">
                                                                        <p class="download_text_box">Thank you for completing the authentication process.</p>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center">
                                                                    <div id="DivStartExam" style="margin-top: 25px;">
                                                                        <div id="Div1">
                                                                            <%if (GetExamDetailsByTransID() == "True")
                                                                              { %>

                                                                            <table style="width: 90%; margin: 0px auto;" cellpadding="3">
                                                                                <tr>
                                                                                    <td>&nbsp;</td>
                                                                                    <td style="color: #656565; text-align: left; font-size: 18px; margin-bottom: 5px; padding-top: 5px;">To install examiLOCK<sup>&reg;</sup> on your computer, please follow the steps below.
                                               
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2">&nbsp;</td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <div class="examilock_circle">
                                                                                            <div style="padding-top: 4px;">1</div>
                                                                                        </div>
                                                                                    </td>
                                                                                    <td align="left"><span class="examilock_headings">Download & Install</span></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>&nbsp;</td>
                                                                                    <td class="examilock_CText" align="left">Click on examiLOCK<sup style="padding-left: 2px;">&reg;</sup> to install. &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="javascript:downloadApp();" style="color: #fff;" class="examilock_orange_buttom">examiLOCK<sup style="padding-left: 2px;">&reg;</sup> </a></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2">&nbsp;</td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left">
                                                                                        <div class="examilock_circle">
                                                                                            <div style="padding-top: 4px;">2</div>
                                                                                        </div>
                                                                                    </td>
                                                                                    <td align="left"><span class="examilock_headings">Begin Exam</span></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>&nbsp;</td>
                                                                                    <td class="examilock_CText" align="left">Once installation is complete, Click on Begin Exam to start your exam. &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                                                <input id="btnBeginExam" type="button" value="Begin Exam" onclick="setStatus(1);" class="examilock_orange_buttom" />
                                                                                    </td>
                                                                                </tr>

                                                                            </table>
                                                                            <%}
                                                                              else
                                                                              { %>

                                                                            <br />
                                                                            <br />
                                                                            <div id="divpassword" runat="server" style="display: none;">
                                                                                <div id="bpassword">
                                                                                    <input id="btnpassword" type="button" value="Get Password" onclick="DispalyMsg();" class="examilock_orange_buttom" />
                                                                                </div>
                                                                                <div style="width: 50%; padding: 5px; display: none" id="divmsg">
                                                                                    <%----%>
                                                                                    <asp:TextBox runat="server" ID="txtpassword" ReadOnly="true" Style="font-size: 16px; width: 80%; padding: 10px; color: #666" Text="testpassword"></asp:TextBox>
                                                                                    <br />
                                                                                    <br />


                                                                                    <ul>
                                                                                        <li style="font-size: 14px; color: black; text-align: left; line-height: 24px">
                                                                                            <span>Copy paste the password in your LMS when prompted to enter password</span>
                                                                                        </li>
                                                                                        <%-- <li style="font-size:14px; color:red; text-align:left;line-height:24px">
                                                                                     <span > This should be entered in your LMS in order to take the test</span>
                                                                                   </li>--%>
                                                                                        <li style="font-size: 14px; font-weight: bold; color: red; text-align: left; line-height: 24px">
                                                                                            <span>Sharing this password with others is considered as a violation</span>
                                                                                        </li>
                                                                                    </ul>

                                                                                    <%-- <span style="font-size:14px; color:green;">Your Password has been generated. To begin your exam you must right click and paste it in the password field.Please click on Begin Exam button below to Contune.</span>--%>
                                                                                </div>
                                                                            </div>
                                                                            <br />
                                                                            <input id="BeginExamWithAutoPassword" value="Begin Exam" class="examilock_orange_buttom" type="button" />
                                                                            <%-- <a href="<%= GetExamLink() %>" target="_blank" style="font-size: 18px; color: Blue; text-decoration: underline; font-weight: bold"
                                                                                onclick="setStatus(0);">Begin exam now</a>--%>

                                                                            <br />
                                                                            <br />
                                                                            <%} %>
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
                                                                        <%--<a href="#">Examity Survey</a>--%>
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
        function setStatus(action) {
            if (action == 1)
                BeginExam();
            else {
                $.post('../AjaxHandler.aspx', { Method: "setStatus", TransID: '<%= Request.QueryString["TransID"].ToString() %>' }, function (data) {
                });
            }
            $('#trSurvey').attr('style', 'display:block;');
            $('#trSurvey').attr('style', 'align:center;');
        }
    </script>

    <script type="text/javascript" src="../Scripts/jquery-timer.js"></script>
    <script type="text/javascript">
        var DIV5FOCUS = 0;
        var timer =
            $.timer(function getValidationStatus() {
                $.post('../Proctor/AjaxResponse.aspx', { Method: "StartExam", TransID: '<%= Request.QueryString["TransID"].ToString() %>' }, function (data) {
                    //if (data == "1") {
                    //    $('#DivStartExam').attr('style', 'display:block;');
                    //    $('#DivSurvey').attr('style', 'display:none;');
                    //    $('#divdownload').attr('style', 'display:block;');
                    //    $('#divlaunch').attr('style', 'display:none;');
                    //    $('#divbeginexam').attr('style', 'display:none;');

                    //    $('#download').addClass('active-step');
                    //    $('#ainstall').removeAttr('href');
                    //    $('#alaunch').removeAttr('href');
                    //    $('#abegin').removeAttr('href');

                    //}
                    //else if (data == "2") {
                    //    $('#DivStartExam').attr('style', 'display:block;');
                    //    $('#divdownload').attr('style', 'display:none;');
                    //    $('#divlaunch').attr('style', 'display:block;');
                    //    $('#divbeginexam').attr('style', 'display:none;');
                    //    $('#DivSurvey').attr('style', 'display:none;');



                    //}
                    //else if (data == "3") {
                    //    $('#DivStartExam').attr('style', 'display:block;');
                    //    $('#divbeginexam').attr('style', 'display:block;');
                    //    $('#divdownload').attr('style', 'display:none;');
                    //    $('#divlaunch').attr('style', 'display:none;');
                    //    $('#DivSurvey').attr('style', 'display:none;');


                    //}
                    //else {
                    //    $('#DivStartExam').attr('style', 'display:none;');
                    //    $('#trSurvey').attr('style', 'display:block;');
                    //    $('#trSurvey').attr('style', 'align:center;');
                    //    $('#DivSurvey').attr('style', 'display:block;');
                    //}

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

</asp:Content>


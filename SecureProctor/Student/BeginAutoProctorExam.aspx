<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true" CodeBehind="BeginAutoProctorExam.aspx.cs" Inherits="SecureProctor.Student.BeginAutoProctorExam" %>

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
    </script>
    <style type="text/css">
        ol {
            margin: 0px;
            padding: 0px;
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
                                                                        <%--<p style="font-size: 18px; color: #1b1b1b; background: #ffffff; padding: 4px;">
                                                                            Thank you for completing the authentication process.
                                                                        </p>--%>
                                                                    </div>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center">
                                                                    <div id="DivStartExam">
                                                                        <div style="width: 100%; margin: 0 auto;">
                                                                            <div style="visibility: hidden;">
                                                                                <ol class="k">
                                                                                    <li class="steps__item" id="launch"><span class="steps__link">Launch</span></li>
                                                                                    <li class="steps__item" id="begin"><span class="steps__link">Begin</span></li>
                                                                                </ol>
                                                                                <div style="clear: both"></div>
                                                                            </div>
                                                                            <div id="divlaunch" style="display: none;">
                                                                                <%-- <div>
                                                                                    <p class="download_text">Launch Automated Proctoring.</p>
                                                                                </div>--%>
                                                                                <div style="clear: both"></div>
                                                                                <div style="width: 100%; vertical-align: central;">
                                                                                    <div class="ViewInstructions-mainblock" style="margin-left: 15%; align-content: center;">
                                                                                        <ul>
                                                                                            <li>
                                                                                                <div>
                                                                                                    <img src="../Images/icon_1.png" border="0" />
                                                                                                </div>
                                                                                                <br>
                                                                                                <div>You must be in a well-lit environment and your face must be clearly visible throughout the exam.</div>
                                                                                            </li>
                                                                                            <li>
                                                                                                <div>
                                                                                                    <img src="../Images/icon_2.png" border="0" />
                                                                                                </div>
                                                                                                <br>
                                                                                                <div>You must be alone in the room. Communicating with anyone else is prohibited.</div>
                                                                                            </li>
                                                                                            <li>
                                                                                                <div>
                                                                                                    <img src="../Images/icon_3.png" border="0" />
                                                                                                </div>
                                                                                                <br>
                                                                                                <div>You must remain in the center of the webcam frame throughout the exam.</div>
                                                                                            </li>
                                                                                            <li>
                                                                                                <div>
                                                                                                    <img src="../Images/icon_4.png" border="0" />
                                                                                                </div>
                                                                                                <br>
                                                                                                <div>Hats, sunglasses, hoods, or anything else that obscures the view of your face is prohibited.</div>
                                                                                            </li>
                                                                                        </ul>
                                                                                    </div>
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
                                                                                    <%-- <p class="download_text">Click on Begin Exam </p>--%>
                                                                                    <div id="divpassword" runat="server" style="display: none;">
                                                                                        <div id="bpassword" style="display: none">
                                                                                            <input id="btnpassword" type="button" value="Get Password" onclick="DispalyMsg();" class="examilock_orange_buttom" />
                                                                                        </div>
                                                                                        <div style="width: 50%; padding: 5px; display: none" id="divmsg">

                                                                                            <asp:TextBox runat="server" ID="txtpassword" ReadOnly="true" Style="font-size: 16px; width: 80%; padding: 10px; color: #666" Text=""></asp:TextBox>
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
                                                                                        <br />
                                                                                    </div>
                                                                                    <br />
                                                                                    <div style="text-align: center;">
                                                                                        <%-- <a href="<%= GetExamLink() %>" target="_blank" onclick="javascript:setStatusExamiFace(0);" class="examiFACE_btn">Begin Exam</a>--%>
                                                                                        <br />
                                                                                        <p class="download_text">
                                                                                            Trouble launching application? Click <a href="javascript:setStatusExamiFace1();" style="color: blue; text-decoration: none;">here</a>
                                                                                            .
                                                                                        </p>
                                                                                    </div>
                                                                                </div>
                                                                                <div style="clear: both"></div>
                                                                                <div id="examlink1" style="display: none;">
                                                                                    <%-- <p class="download_text">Begin Exam link will appear once ExamityAutomatedProctoring application is launched. </p>--%>
                                                                                   <%-- <p class="download_text">
                                                                                        Trouble launching this application? Click <a href="javascript:setStatusExamiFace1();" style="color: blue; text-decoration: none;">here</a>
                                                                                        .
                                                                                    </p>--%>
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
                                                                        <div id="divpwd" style="width: 50%; padding: 5px; display: none;">
                                                                            <input id="txtspwd" name="txtspwd" type="text" autocomplete="off" readonly="readonly" autofocus="autofocus" tabindex="60" style="height: 25px; font-size: 16px; width: 80%" />&nbsp;                        
                                                                            <%--<asp:TextBox runat="server" ID="txtspwd" ReadOnly="true" style="font-size:16px; width:80%; padding:10px;color:#666" Text="testpassword"></asp:TextBox>--%>
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

                                                                             <span style="font-size:14px; color:green;">Your Password has been generated. To begin your exam you must right click and paste it in the password field.Please click on Begin Exam button below to Contune.</span>
                                                                        </div>


                                                                        <br />
                                                                        <br />
                                                                     <%--    <p class="download_text">
                                                                                        Trouble launching this application? Click <a href="javascript:setStatusExamiFace1();" style="color: blue; text-decoration: none;">here</a>
                                                                                        .
                                                                                    </p>--%>
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

    <asp:HiddenField runat="server" ID="hdnIsLockDown" />
    <asp:HiddenField runat="server" ID="hdnIsPasswordExists" />
    <asp:HiddenField runat="server" ID="hdnLmsDomain" />

    <script type="text/javascript">

        function setStatusExamiFace1(action) {
            $.post('../AjaxHandler.aspx', { Method: "setexamiFACEDownLoadStatus1", TransID: '<%= Request.QueryString["TransID"].ToString() %>', Status: '1' },
                function (data) {
                });
        }

        function setStatusExamiFace(action) {
            $.post('../AjaxHandler.aspx', { Method: "GetSessionID", TransID: '<%= Request.QueryString["TransID"].ToString() %>' }, function (data) {
                GOTOMeetingSessionID = data;

                if (action == 1) {
                    $.post('../AjaxHandler.aspx', { Method: "setexamiFACEDownLoadStatus", TransID: '<%= Request.QueryString["TransID"].ToString() %>', Status: '2' },
                                function (data) {
                                    $('#divlaunch').attr('style', 'display:block;');
                                    $('#divbegin').attr('style', 'display:none;');

                                    $('#launch').addClass('steps__item--active');
                                    $('#begin').removeClass('steps__item--active');

                                    $("#alaunch").removeAttr('href');
                                    $('#abegin').removeAttr('href');
                                    $('#DivBeginExam1').attr('style', 'display:none;');
                                });


                    if (GOTOMeetingSessionID != 0) {

                       

                        var sW = screen.availWidth;
                        var sH = screen.availHeight
                        window.open(GOTOMeetingSessionID, 'newwindow', 'width=' + sW + ',height=' + sH + '');
                    }
                }
                else if (action == 2) {
                    $.post('../AjaxHandler.aspx', { Method: "setexamiFACEDownLoadStatus", TransID: '<%= Request.QueryString["TransID"].ToString() %>', Status: '3' }, function (data) {

                        $('#divlaunch').attr('style', 'display:block;');
                        $('#divbegin').attr('style', 'display:none;');

                        $('#launch').removeClass('steps__item--active');
                        $('#begin').addClass('steps__item--active');

                        $("#alaunch").removeAttr('href');
                        $('#abegin').removeAttr('href');
                        $('#DivBeginExam1').attr('style', 'display:none;');
                    });

                }
                else if (action == 3) {
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
                        $('#examlink1').attr('style', 'display:block;');
                        $('#trSurvey').attr('style', 'align:center;');
                        var pwd = document.getElementById('<%= txtpassword.ClientID %>').value;
                        $('#divpwd').attr('style', 'display:none;');
                        $('#DivBeginExam1').attr('style', 'display:none;');
                    });

                    // we are sending a message to extension and open exam in new tab
                    var signalObj = {
                        cname: "<%= ConfigurationManager.AppSettings["client"].ToString()%>",
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
                }
            });
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
                    $('#begin').removeClass('steps__item--active');
                    $('#launch').addClass('steps__item--active');
                    $('#abegin').removeAttr('href');
                    $("#alaunch").removeAttr('href');
                    $('#divlaunch').attr('style', 'display:block;');
                    $('#divbegin').attr('style', 'display:none;');
                    $('#DivBeginExam1').attr('style', 'display:none;');
                    $('#rdinstled').attr('checked', false);
                }
                else if (data == "2") {
                    /// install enabling
                    $('#begin').addClass('steps__item--active');
                    $('#launch').removeClass('steps__item--active');

                    $('#abegin').removeAttr('href');
                    $("#alaunch").removeAttr('href');

                    $('#divlaunch').attr('style', 'display:none;');
                    $('#divbegin').attr('style', 'display:block;');
                    $('#examlink1').attr('style', 'display:block;');
                    $('#examlink').attr('style', 'display:none;');
                    $('#DivBeginExam1').attr('style', 'display:none;');
                    $('#DivSurvey').attr('style', 'display:none;');
                    $('#trSurvey').attr('style', 'display:none;');
                }
                else if (data == "3") {
                    $('#begin').addClass('steps__item--active');
                    $('#launch').removeClass('steps__item--active');

                    $('#abegin').removeAttr('href');
                    $("#alaunch").removeAttr('href');

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

                    //if (pwd != '') {
                    // $('#divpwd').attr('style', 'display:block; width:50%; padding:5px;');
                    //var p = $('#txtspwd').val();
                    //  if (p == '') {
                    //  $("#txtspwd").val(pwd);
                    //}
                    //  }
                    //else
                    // $('#divpwd').attr('style', 'display:none;');

                    $('#DivSurvey').attr('style', 'display:block;');
                    $('#DivBeginExam1').attr('style', 'display:none;');
                }
            });
        }, 1000, true);
    </script>
</asp:Content>

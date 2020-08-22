<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true" CodeBehind="ProctorExamProcess.aspx.cs" Inherits="SecureProctor.Student.ProctorExamProcess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StudentContent" runat="server">

    <div id="DivSppiner" style="text-align: center; background-color: White; position: absolute;top: 50%;left: 50%; margin: -50px 0px 0px -50px; display:none;">
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
            height: 68px;
            text-align: left;
        }

        .steps1 {
            background: url(../Images/ImgSteps_new.png) no-repeat 0px -70px;
            width: 777px;
            height: 68px;
            position: relative;
            border-radius: 10px;
            text-align: left;
        }

        .steps2 {
            background: url(../Images/ImgSteps_new.png) no-repeat 0px -141px;
            width: 777px;
            height: 68px;
            text-align: left;
        }

        .steps3 {
            background: url(../Images/ImgSteps_new.png) no-repeat 0px -211px;
            width: 777px;
            height: 68px;
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
      <link rel="stylesheet" href="https://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    <script src="../js/jquery-1.9.1.js"></script>
    <script src="../js/jquery-1.8.1.min.js"></script>
    <script src="../js/jquery-ui.js"></script>
      <script type="text/javascript" language="javascript">
      var GOTOMeetingSessionID = 0;
        function browserValidate() {
            //  alert(GOTOMeetingSessionID);
            if (GOTOMeetingSessionID != 0) {
                if (GOTOMeetingSessionID.length == 9) {
                    var win = window.open("https://www1.gotomeeting.com/join/" + GOTOMeetingSessionID, '_blank', 'width=500,height=250');
                }
                else {
                    var win = window.open(GOTOMeetingSessionID, '_blank');
                }
            }
            return true;
        }
          </script>

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

//$.timer(
//    function getValidationStatus() {
//        $.post('../Proctor/AjaxResponse.aspx', {
//            Method: "GetNextStatus", TransID:
//   '<= Request.QueryString["TransID"].ToString() %>'
//   }, function (data) {
//  if (data == "1") {
//$('#DIV2').attr('style', 'display:block;');
//$.post('../AjaxHandler.aspx', {
//    Method: "GetSessionID", TransID:
//        '<= Request.QueryString["TransID"].ToString() %>'
//            }, function (data) {
//                GOTOMeetingSessionID = data;
//            });
//        }
//        else {
//            $('#DIV2').attr('style', 'display:none;');
//        }
//    });
//}, 1000, true);

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
                                            

   <table cellpadding="2" cellspacing="2" width="100%">

       <tr>
            <td>

                <asp:Image ID="imgHead" runat="server" ImageUrl="../Images/ImgStartExamHeader.png" AlternateText="Start Exam" title="Start Exam" TabIndex="11" />
            </td>
            <td width="1%" rowspan="2"></td>
       
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
                                            <div  id="imgStep1" class="NewStep_eK1" style="width: 800px; margin: 0px auto;">
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
                                                                            <span style="font-size: 16px;"><asp:Label ID="lblText2" runat="server" Text="In a moment, you will see a “Proceed” button. Click to connect with a proctor, who will guide you." TabIndex="13"></asp:Label>
                                                                              
                                                                                </span>
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
                                                                       <div style="display: none;" id="btnStep1Next">
                                                                        <asp:Button ID="btnNext"  class="classname" OnClick="btnStep1Next_Click" runat="server" Text="Next"/>
                                                                           </div>
                                                                       <%-- <input type="button" id="btnStep1Next" class="classname" value="Next" onclick="StepFn('divStep1', 'divStep4', 'navigate', '');"
                                                                            style="display: none;" tabindex="19"/>--%>
                                                                          
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

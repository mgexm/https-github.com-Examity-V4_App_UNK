﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true" CodeBehind="CaptureImage.aspx.cs" Inherits="SecureProctor.Student.CaptureImage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StudentContent" runat="server">
<link href="../Webcam_Plugin/WebCamCapture.css" rel="stylesheet" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src='<%=ResolveUrl("~/Webcam_Plugin/jquery.webcam.js") %>' type="text/javascript"></script>
    <script src="../Scripts/CamScripts.js" type="text/javascript"></script>
    <%--<script src="https://code.jquery.com/jquery-3.3.1.min.js" integrity="sha256-FgpCb/KJQlLNfOu91ta32o/NMZxltwRo8QtmkMRdAu8=" crossorigin="anonymous"></script>--%>
    <script src="http://cdnjs.cloudflare.com/ajax/libs/p5.js/0.6.0/addons/p5.dom.js" type="text/javascript"></script>
    <script src="../SystemReadiness/ua-list-example.js" type="text/javascript"></script>
    <script src="../SystemReadiness/ua-parser.js" type="text/javascript"></script>
    <script type="text/javascript">
        var pageUrl = '<%=ResolveUrl("~/Student/CaptureImage.aspx") %>';
        var parser = new UAParser();
        var os = parser.getOS();
        var browser = parser.getBrowser();
        $(function () {

            var OSName = "Unknown OS";
            if (navigator.appVersion.indexOf("Win") != -1) OSName = "Windows";
            if (navigator.appVersion.indexOf("Mac") != -1) OSName = "MacOS";
            if (navigator.appVersion.indexOf("X11") != -1) OSName = "UNIX";
            if (navigator.appVersion.indexOf("Linux") != -1) OSName = "Linux";



            if (OSName != "MacOS") {

                if (IsHtml5Compliant() == "Yes") {
                    document.getElementById("WOSWF").style.display = "block";
                    document.getElementById("WSWF").style.display = "none";
                    document.getElementById("WOSWFCapture").style.display = "block";
                    document.getElementById("WSWFCapture").style.display = "none";
                    //alert("<Session["IsHmlCompliant"].ToString().Trim()%>");
                    var video = document.querySelector('#FCwebcam');

                    navigator.getUserMedia = (navigator.getUserMedia ||
                                       navigator.webkitGetUserMedia ||
                                       navigator.mozGetUserMedia ||
                                       navigator.msGetUserMedia);
                    if (navigator.getUserMedia) {
                        var handleSuccess = function (stream) {
                            video.srcObject = stream;
                        };

                        navigator.mediaDevices.getUserMedia({ audio: false, video: true })
                            .then(handleSuccess)
                    }
                    else {
                        alert('OOPS No browser Support');
                    }
                    var scale = 0.60;
                    // Trigger photo take video.videoWidth * scale, video.videoHeight * scale
                    document.querySelector("#btnFCCapture").addEventListener("click", function () {
                        var canvas = document.querySelector('#canvas');
                        var context = canvas.getContext('2d');
                        canvas.width = video.videoWidth * scale;
                        canvas.height = video.videoHeight * scale;
                        context.drawImage(video, 0, 0, canvas.width, canvas.height);
                        var str = canvas.toDataURL();
                        $("#<%= txtimgvalue.ClientID %>").val(str.replace("data:image/png;base64,", ""));
                        $("[id*=btnUpload]").attr('disabled', false);

                    });
                } else {
                    document.getElementById("WOSWF").style.display = "none";
                    document.getElementById("WSWF").style.display = "block";
                    document.getElementById("WOSWFCapture").style.display = "none";
                    document.getElementById("WSWFCapture").style.display = "block";

                    jQuery("#webcam").webcam({
                        width: 345,
                        height: 250,
                        mode: "save",
                        swffile: '<%=ResolveUrl("~/Webcam_Plugin/jscam.swf") %>',
                        debug: function (type, status) {
                            document.getElementById("camStatus").innerHTML = status + ' . . .';
                        },
                        onSave: function (data) {
                            $.ajax({
                                type: "POST",
                                url: pageUrl + "/GetCapturedImage",
                                data: '',
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                success: function (r) {
                                    $("[id*=imgCapture]").css("visibility", "visible");
                                    $("[id*=imgCapture]").attr("src", r.d);
                                    $("[id*=btnUpload]").attr('disabled', false);



                                },
                                failure: function (response) {
                                    alert(response.d);
                                }
                            });
                        },
                        onCapture: function () {
                            webcam.save(pageUrl);
                        }
                    });
                }
            }
            else {

                if (browser.name == 'Chrome' || browser.name == 'Firefox') {
                    document.getElementById("WOSWF").style.display = "block";
                    document.getElementById("WSWF").style.display = "none";
                    document.getElementById("WOSWFCapture").style.display = "block";
                    document.getElementById("WSWFCapture").style.display = "none";
                    var player = document.getElementById('FCwebcam');

                    var handleSuccess = function (stream) {
                        player.srcObject = stream;
                    };

                    navigator.mediaDevices.getUserMedia({ audio: false, video: true })
                        .then(handleSuccess)

                    var scale = 0.60;
                    // Trigger photo take video.videoWidth * scale, video.videoHeight * scale
                    document.querySelector("#btnFCCapture").addEventListener("click", function () {
                        var canvas = document.querySelector('#canvas');
                        var context = canvas.getContext('2d');
                        canvas.width = player.videoWidth * scale;
                        canvas.height = player.videoHeight * scale;
                        context.drawImage(player, 0, 0, canvas.width, canvas.height);
                        var str = canvas.toDataURL();
                        $("#<%= txtimgvalue.ClientID %>").val(str.replace("data:image/png;base64,", ""));
                        $("[id*=btnUpload]").attr('disabled', false);

                    });
                }
                else if (browser.name == 'Safari') {
                    if (parseFloat(browser.version) >= 10.1) {
                        document.getElementById("WOSWF").style.display = "block";
                        document.getElementById("WSWF").style.display = "none";
                        document.getElementById("WOSWFCapture").style.display = "block";
                        document.getElementById("WSWFCapture").style.display = "none";
                        var player = document.getElementById('FCwebcam');

                        var handleSuccess = function (stream) {
                            player.srcObject = stream;
                        };

                        navigator.mediaDevices.getUserMedia({ audio: false, video: true })
                            .then(handleSuccess)

                        var scale = 0.60;
                        // Trigger photo take video.videoWidth * scale, video.videoHeight * scale
                        document.querySelector("#btnFCCapture").addEventListener("click", function () {
                            var canvas = document.querySelector('#canvas');
                            var context = canvas.getContext('2d');
                            canvas.width = player.videoWidth * scale;
                            canvas.height = player.videoHeight * scale;
                            context.drawImage(player, 0, 0, canvas.width, canvas.height);
                            var str = canvas.toDataURL();
                            $("#<%= txtimgvalue.ClientID %>").val(str.replace("data:image/png;base64,", ""));
                            $("[id*=btnUpload]").attr('disabled', false);

                        });
                    }
                    else {
                        document.getElementById("WOSWF").style.display = "none";
                        document.getElementById("WSWF").style.display = "block";
                        document.getElementById("WOSWFCapture").style.display = "none";
                        document.getElementById("WSWFCapture").style.display = "block";

                        jQuery("#webcam").webcam({
                            width: 345,
                            height: 250,
                            mode: "save",
                            swffile: '<%=ResolveUrl("~/Webcam_Plugin/jscam.swf") %>',
                            debug: function (type, status) {
                                document.getElementById("camStatus").innerHTML = status + ' . . .';
                            },
                            onSave: function (data) {
                                $.ajax({
                                    type: "POST",
                                    url: pageUrl + "/GetCapturedImage",
                                    data: '',
                                    contentType: "application/json; charset=utf-8",
                                    dataType: "json",
                                    success: function (r) {
                                        $("[id*=imgCapture]").css("visibility", "visible");
                                        $("[id*=imgCapture]").attr("src", r.d);
                                        $("[id*=btnUpload]").attr('disabled', false);



                                    },
                                    failure: function (response) {
                                        alert(response.d);
                                    }
                                });
                            },
                            onCapture: function () {
                                webcam.save(pageUrl);
                            }
                        });
                    }
                }
                // if (parseFloat(os.version) > 10.12) {

        }
        });

    function Capture() {

        webcam.capture();

        return false;
    }
    </script>

    <script language="javascript" type="text/javascript">
        function help() {
            var masg = "If you cannot see the “Allow” link, follow these steps <ol><li>Right click on the white text box below Live camera</li><li>Click on “Global Settings”</li><li>Under flash player help menu, click on “Website Privacy settings panel”</li><li>In the websites list scroll to “prod.examity.com” and enable “Always Allow”</li><li>Return to the Examity tab on your browser and refresh the page</li></ol>";
            radalert(masg, 500, 250, "Examity®");
            return false;
        }
    </script>


    <telerik:RadWindowManager ID="RadWindowManager1" ir="rdM1" runat="server" Localization-Cancel="Cancel" Localization-OK="OK" EnableShadow="true" Skin="Metro"></telerik:RadWindowManager>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <h1 style="padding: 10px; color: #666;">
                    <asp:Label ID="Label1" runat="server" Text="Take picture"></asp:Label>
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

                                        <div class="AAstepsID1" style="width: 800px; margin: 0px auto;"></div>

                                        <table cellpadding="2" cellspacing="2" width="100%">
                                            <tr>
                                                <td width="100%" align="center">
                                                    <div class="login_new_steps">

                                                        <div style="text-align: left; margin-top: 5px; width: 860px; margin: 0px auto;">
                                                            <br />
                                                            <asp:Label ID="lblStep1" runat="server" Text="Step 1 : Click  <b>&#34;Allow&#34;</b> to turn on your camera. " ForeColor="Black" Font-Bold="false" class="Display14"></asp:Label>
                                                            <div style="display: none;">&nbsp;&nbsp;<asp:LinkButton ID="btnInstruction" runat="server" Text="Need Help?" OnClientClick="return help();" ForeColor="Blue" /></div>

                                                            <br />
                                                            <br />
                                                            <asp:Label ID="lblStep2" runat="server" Text="Step 2 : Click on <b>&#34;Take Picture&#34;</b> button to capture your face." ForeColor="Black" Font-Bold="false" class="Display14"></asp:Label>
                                                            <br />
                                                            <br />

                                                            <asp:Label ID="Label3" runat="server" Text="Step 3 : Click on <b>&#34;Save&#34;</b> option to save this picture or the <b>&#34;Take Picture&#34;</b> button to retake it." ForeColor="Black" Font-Bold="false" class="Display14"></asp:Label>
                                                        </div>
                                                         <div class="container_box">
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        <div class="campaign_box">
                                                                            <div class="box_header">Live Camera	</div>

                                                                            <div id="WOSWF" style="display: none">
                                                                                <div class="campaign_image">
                                                                                    <video id="FCwebcam" autoplay width="345" height="250"></video>
                                                                                </div>
                                                                                <div class="button_div">
                                                                                    <input type="button" value="Take picture" class="button4 orange" id="btnFCCapture" />
                                                                                    <br />

                                                                                </div>
                                                                            </div>


                                                                            <div id="WSWF" style="display: none">
                                                                                <div class="campaign_image" id="webcam"></div>
                                                                                <div class="button_div">
                                                                                    <asp:Button ID="btnCapture" Text="Take Picture" runat="server" CssClass="button4 orange" OnClientClick="return Capture();" /><br />
                                                                                    <label runat="server" id="camStatus"></label>
                                                                                </div>

                                                                            </div>
                                                                        </div>

                                                                    </td>
                                                                    <td>
                                                                        <div class="campaign_box">
                                                                            <div class="box_header">Captured Image</div>
                                                                            <div class="campaign_image">
                                                                                <%-- <%if (Session["IsHmlCompliant"].ToString().Trim() == "Yes")
                                                                                                  { %>--%>
                                                                                <div id="WOSWFCapture" style="display: none">
                                                                                    <canvas id="canvas" style="height: 250px; width: 345px;" />
                                                                                    <asp:HiddenField ID="txtimgvalue" runat="server" />
                                                                                </div>
                                                                                <%-- <%}
                                                                                                  else
                                                                                                  {%>--%>
                                                                                <div id="WSWFCapture" style="display: none">
                                                                                    <asp:Image ID="imgCapture" runat="server" Style="visibility: hidden; height: 250px; width: 345px;" />
                                                                                    <%--<%}%>--%>
                                                                                </div>
                                                                            </div>
                                                                            <div class="button_div1">
                                                                                <asp:UpdatePanel ID="UpdatePanel1" runat="Server" UpdateMode="Conditional">
                                                                                    <ContentTemplate>

                                                                                        <asp:Button runat="server" CssClass="button1 orange" ID="btnUpload" Text="Save" Enabled="false" OnClick="btnUpload_Click" />

                                                                                        <div style="position: relative; top: 25px; right: 295px; width: 500px;">

                                                                                            <asp:Label ID="lblError" runat="server" Visible="false"></asp:Label>
                                                                                            <br />
                                                                                            <br />
                                                                                            <asp:Button runat="server" CssClass="button1 orange" ID="btnProceed" Text="Next" Visible="false" OnClick="btnProceed_Click" />
                                                                                        </div>
                                                                                    </ContentTemplate>

                                                                                </asp:UpdatePanel>
                                                                                <div class="clear"></div>

                                                                            </div>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <div class="clear"></div>

                                                        </div>
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



</asp:Content>

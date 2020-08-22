<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComputerReadinessCheck.aspx.cs" Inherits="SecureProctor.ComputerReadinessCheck" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link href="css/Examity_styles_new.css" rel="stylesheet" type="text/css" />

    <link href="CSS/SystemReadinessNew.css" rel="stylesheet" />


    <script src="SystemReadiness/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="SystemReadiness/checkExistance.js" type="text/javascript"></script>
    <script src="SystemReadiness/detectBrowser.js" type="text/javascript"></script>
    <script src="SystemReadiness/spin.min.js" type="text/javascript"></script>
    <script src="SystemReadiness/swfobject.js" type="text/javascript"></script>
    <script src="http://speedof.me/api/api.js" type="text/javascript"></script>

    <%--<script src="SystemReadiness/api.js" type="text/javascript"></script>--%>
    <script type="text/javascript">

        SomApi.account = "SOM53fe676f6c48d";
        SomApi.domainName = "test.examity.com";

        SomApi.config.sustainTime = 8;
        SomApi.onTestCompleted = onTestCompleted;
        SomApi.onError = onError;
        SomApi.config.uploadTestEnabled = true;

        $(document).ready(function () {

            if (jQuery.browser.flash) {
                try {

                    SpinAll();

                    if (isFlashExists() != 'warning') {
                        var params = {};
                        params.allowscriptaccess = "always";
                        isFlashFound();
                        swfobject.embedSWF("SystemReadiness/CheckSystemReadyness.swf", "divCamHolder", "1", "1", "11.0.0", false, null, params, null);
                    }
                    else {
                        FlashVersionNotSupported();
                    }
                } catch (e) {
                    console.log(e.name + ':' + e.message);
                }
            }
            else {
                //******** If no flash detected **************//
                FlashNotFound();
                ShowFlashNotFoundAlert();
            }
        });

        function ShowFlashNotFoundAlert() {
            setTimeout(function () {
                alert(' Flash plug-in Disabled/Not Detected. Please Enable/Install latest Flash Plug-in from http://get.adobe.com/flashplayer/.');
            }, 0);
        }

        function isFlashExists() {

            var flashplayerObj = swfobject.getFlashPlayerVersion();
            var flashVersion = flashplayerObj.major + "." + flashplayerObj.minor;
            var status = IsflashVersionSupports(flashVersion);
            return status;
        }

        function spin(control) {
            //*********** Creates spinner and adds spinner to specifi ccontrol ************//          
            var opts = {
                lines: 10,
                length: 8,
                width: 3,
                radius: 8,
                //color: '#B0B0B0',
                color: '#000000',
                top: '65%',
                left: '70%'
            };
            var spinner = new Spinner(opts).spin(document.getElementById(control))
        }

        function IsflashVersionSupports(version) {
            //******Flash Version should be 11.0 or higher**********//
            if (version >= 11.0) return 'pass';
            else if (version < 11.0) return 'warning';
            else return 'fail';
        }

        function SpinAll() {
            //**********Spins all spinners***********//
            spin('FStatusIcon');
            spin('WCStatusIcon');
            spin('MStatusIcon');
            spin('BWStatusIcon');
            spin('BStatusIcon');
            spin('OSStatusIcon');

        }

        function isFlashFound() {

            //********** Detects Flash ***************//
            setTimeout(function () {

                var flashplayerObj = swfobject.getFlashPlayerVersion();
                var flashVersion = flashplayerObj.major + "." + flashplayerObj.minor;
                var status = IsflashVersionSupports(flashVersion);

                jQuery("#FStatusIcon").empty();

                if (status === 'pass') {
                    jQuery("#FStatusIcon").removeClass();
                    jQuery("#FStatusIcon").addClass('found');
                    jQuery("#FStatusIcon").text('Ready');
                    //jQuery("#FlashStatus").text("Supported");
                    jQuery("#lnkFlash").css("display", "none");

                    isOsSupports();
                    isBrowserSupports();
                    SomApi.startTest();
                }
                else if (status === 'fail') {

                    jQuery("#FStatusIcon").removeClass();
                    jQuery("#FStatusIcon").addClass('notfound');
                    jQuery("#FStatusIcon").text('Not Ready!');
                    //jQuery("#FlashStatus").text("Not Found");
                    jQuery("#lnkFlash").css("display", "block");

                }
                else if (status == 'warning') {
                    jQuery("#FStatusIcon").removeClass();
                    jQuery("#lnkFlash").css("display", "block");
                }
                else {
                    jQuery("#FStatusIcon").removeClass();
                    jQuery("#FStatusIcon").addClass('problem');
                    jQuery("#FStatusIcon").text('Not Ready!');
                    jQuery("#lnkFlash").css("display", "block");
                    //jQuery("#FlashStatus").text("Problem in detecting");

                }
            }, 2000);

        }

        function isCameraFound(result) {
            //*********** Camera Callback Function *****************//         
            setTimeout(function () {

                jQuery("#WCStatusIcon").empty();

                if (result == 'pass') {
                    jQuery("#WCStatusIcon").removeClass();
                    jQuery("#WCStatusIcon").addClass('found');
                    jQuery("#WCStatusIcon").text("Ready");
                    //jQuery("#WebCamStatus").text("Found");
                    jQuery("#divWebcam").css("display", "none");

                }
                else if (result == 'fail') {
                    jQuery("#WCStatusIcon").removeClass();
                    jQuery("#WCStatusIcon").addClass('notfound');
                    jQuery("#WCStatusIcon").text("Not Ready!");
                    jQuery("#divWebcam").css("display", "block");
                    //jQuery("#WebCamStatus").text("Not found");

                }
                else {
                    jQuery("#WCStatusIcon").removeClass();
                    jQuery("#WCStatusIcon").addClass('problem');
                    jQuery("#WCStatusIcon").text("Not Ready!");
                    jQuery("#divWebcam").css("display", "block");
                    //jQuery("#WebCamStatus").text("Problem in detecting");

                }
            }, 2000);
        }

        function isMicFound(result) {
            //************** Microphone CallBack Function *************//

            setTimeout(function () {

                jQuery("#MStatusIcon").empty();

                if (result == 'pass') {
                    jQuery("#MStatusIcon").removeClass();
                    jQuery("#MStatusIcon").addClass('found');
                    jQuery("#MStatusIcon").text('Ready');
                    jQuery("#divmic").css("display", "none");

                    //jQuery("#MicStatus").text("Found");

                }
                else if (result == 'fail') {
                    jQuery("#MStatusIcon").removeClass();
                    jQuery("#MStatusIcon").addClass('notfound');
                    jQuery("#MStatusIcon").text('Not Ready!');
                    jQuery("#divmic").css("display", "block");
                    //jQuery("#MicStatus").text("Not found");

                }
                else {
                    jQuery("#MStatusIcon").removeClass();
                    jQuery("#MStatusIcon").addClass('problem');
                    jQuery("#MStatusIcon").text('Not Ready!');
                    jQuery("#divmic").css("display", "block");
                    //jQuery("#MicStatus").text("Problem in detecting");

                }
            }, 3000);
        }

        function FlashVersionNotSupported() {
            jQuery("#FStatusIcon").empty();
            jQuery("#FStatusIcon").removeClass();
            jQuery("#FStatusIcon").addClass('prlblem');
            jQuery("#divWebcam").css("display", "block");
            //jQuery("#FlashStatus").text("Not Supported");

            jQuery("#WCStatusIcon").empty();
            jQuery("#WCStatusIcon").removeClass();
            jQuery("#WCStatusIcon").addClass('prlblem');

            //jQuery("#WebCamStatus").text("Please Update");

            jQuery("#MStatusIcon").empty();
            jQuery("#MStatusIcon").removeClass();
            jQuery("#MStatusIcon").addClass('prlblem');

            // jQuery("#MicStatus").text("Plesae Update");

            jQuery("#BWStatusIcon").empty();
            jQuery("#BWStatusIcon").removeClass();
            jQuery("#BWStatusIcon").addClass('prlblem');
            jQuery("#BWStatusIcon").text("Not Ready!");
            // jQuery("#SpeedTestStatus").text("Please Update");

            jQuery("#BStatusIcon").empty();
            jQuery("#BStatusIcon").removeClass();
            jQuery("#BStatusIcon").addClass('prlblem');
            jQuery("#BWStatusIcon").text("Not Ready!");
            //jQuery("#BrowserStatus").text("Please Update");

            jQuery("#OSStatusIcon").empty();
            jQuery("#OSStatusIcon").removeClass();
            jQuery("#OSStatusIcon").addClass('prlblem');
            jQuery("#BWStatusIcon").text("Not Ready!");
            // jQuery("#OSStatus").text("Please Update");
        }

        function FlashNotFound() {
            //jQuery("#FlashStatus").text("Not Found");
            jQuery("#FStatusIcon").addClass('notfound');
            jQuery("#WCStatusIcon").empty();
            jQuery("#WCStatusIcon").removeClass();
            jQuery("#WCStatusIcon").addClass('problem');
            //jQuery("#WebCamStatus").text("Problem");

            jQuery("#MStatusIcon").empty();
            jQuery("#MStatusIcon").removeClass();
            jQuery("#MStatusIcon").addClass('problem');
            //jQuery("#MicStatus").text("Problem");

            jQuery("#BWStatusIcon").empty();
            jQuery("#BWStatusIcon").removeClass();
            jQuery("#BWStatusIcon").addClass('problem');
            jQuery("#BWStatusIcon").text("Not Ready!");
            jQuery("#imgDown").hide();
            jQuery("#imgUp").hide();
            //jQuery("#SpeedTestStatus").text("Problem");

            isBrowserSupports();
            jQuery("#BStatusIcon").empty();
            jQuery("#BStatusIcon").removeClass();
            jQuery("#BStatusIcon").addClass('problem');

            isOsSupports();
            jQuery("#OSStatusIcon").empty();
            jQuery("#OSStatusIcon").removeClass();
            jQuery("#OSStatusIcon").addClass('problem');

        }

        //function onTestCompleted(testResult) {

        //    jQuery("#BWStatusIcon").empty();
        //    jQuery("#BWStatusIcon").hide()//addClass('status');
        //    //jQuery("#divDetecting").hide()

        //    jQuery("#SpeedTestStatus_down").text(testResult.download + " Mbps");
        //    jQuery("#SpeedTestStatus_up").text(testResult.upload + " Mbps");
        //    jQuery("#divResults").show()
        //    jQuery("#divIS").hide()

        //}

        function onTestCompleted(testResult) {

            jQuery("#BWStatusIcon").empty();
            jQuery("#BWStatusIcon").hide()//addClass('status');
            //jQuery("#divDetecting").hide()

            //jQuery("#SpeedTestStatus_down").text(testResult.download + " Mbps");
            //jQuery("#SpeedTestStatus_up").text(testResult.upload + " Mbps");
            if (testResult.upload > 3)
                jQuery("#SpeedTestStatus_down").text("Proceed. Speed is acceptable.");
            else if (testResult.upload <= 3 && testResult.upload >= 1)
                jQuery("#SpeedTestStatus_down").text("Proceed. Speed is borderline.");
            else if (testResult.upload < 1)
                jQuery("#SpeedTestStatus_down").text("Caution. Speed may not be sufficient.");

            jQuery("#divResults").show()
            jQuery("#divIS").hide()

        }
        function onError(error) {
            jQuery("#BWStatusIcon").empty();
            jQuery("#BWStatusIcon").addClass('problem');
            jQuery("#BWStatusIcon").text("Not Ready!");
            jQuery("#divResults").hide()
            jQuery("#divIS").show()
            //jQuery("#divDetecting").show()
            //jQuery("#SpeedTestStatus").text("Problem in Testing.");

        }

        function isBrowserSupports() {
            //************* Browser Detection *****************//
            setTimeout(function () {

                jQuery("#BStatusIcon").empty();

                if (jQuery.browser.name == 'msie' || jQuery.browser.name == 'firefox' || jQuery.browser.name == 'opera' || jQuery.browser.name == 'safari' || jQuery.browser.name == 'chrome') {
                    jQuery("#BStatusIcon").removeClass();
                    jQuery("#BStatusIcon").addClass('found');
                    jQuery("#BStatusIcon").text('Ready');
                    // jQuery("#BrowserStatus").text('Supported');
                    jQuery("#divBrowser").css("display", "none");
                    divBrowser
                    SomApi.startTest();
                }
                else {
                    jQuery("#BStatusIcon").removeClass();
                    jQuery("#BStatusIcon").addClass('notfound');
                    jQuery("#BStatusIcon").text('Not Ready!');
                    // jQuery("#BrowserStatus").text("Not Supported");
                    jQuery("#divBrowser").css("display", "block");
                }
            }, 500);
        }

        function isOsSupports() {
            //************* OS Detection Windows, Mac only *****************//
            setTimeout(function () {

                jQuery("#OSStatusIcon").empty();

                if (jQuery.os.name == 'win' || jQuery.os.name == 'mac') {
                    jQuery("#OSStatusIcon").removeClass();
                    jQuery("#OSStatusIcon").addClass('found');
                    jQuery("#OSStatusIcon").text('Ready');
                    jQuery("#divOs").css("display", "none");

                    jQuery("#OSStatus").text('Supported');
                    SomApi.startTest();
                }
                else {
                    jQuery("#OSStatusIcon").removeClass();
                    jQuery("#OSStatusIcon").addClass('notfound');
                    jQuery("#OSStatusIcon").text('Not Ready!');
                    jQuery("#OSStatus").text("Not Supported");
                    jQuery("#divOs").css("display", "block");
                }
            }, 300);
        }
        function OpenIS() {


            alert("Your internet speed is too low for use with Examity.  You can upgrade your internet speed or find a place with faster internet to take your test. If you are using wifi, your speed may increase if you connect to the internet via an ethernet cable. ");
            return false;

        }

        function OpenWC() {


            alert("No webcam is detected.  If you have one, ensure it is plugged in and enabled. If you don’t have one, you will need to buy or borrow one before you can take your test. ");
            return false;

        }
        function OpenMP() {


            alert("No microphone is detected. If you have one, ensure it is plugged in and enabled.  If you don’t have one, you will need to buy or borrow one before you can take your test. ");
            return false;

        }
        function OpenOS() {


            alert("Your computer must be running Windows or Mac OS in order to use Examity.");
            return false;

        }
        function OpenBrowser() {


            alert("You will need to download one of the following browsers in order to optimize your Examity experience.");
            return false;

        }

    </script>





</head>
<body>
    <form id="form1" runat="server">

        <div class="topbaar">
            <div class="top">
                <div class="Clientlogo">
                    Computer Requirements Check
                </div>
                <div class="Examitylogo">
                    <img src="images/logo.png" alt="Examity" />
                    <div class="curve">
                    </div>
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
        <div id="Sapplication_container">
            <div class="System_container">

                <div style="padding-top: 5px; padding-bottom: 40px;">
                    <div style="font-size: 20px; padding-top: 30px; padding-bottom: 30px; margin: 0px auto; width: 900px; color: #000; text-align: center;">Examity will ensure your computer is ready.</div>
                    <table style="border-color: #E4E3E3; width: 720px; margin: 0px auto; text-align: center;" cellpadding="2">

                        <tr id="SystemReadyness">
                            <td style="border-color: #E4E3E3; width: 150px; position: relative;">
                               <%-- <div id="Cam_Detect" class="camera_main">
                                </div>--%>
                                <div>
                                    <img src="Images/webcam1.png" /></div>
                                <div style="color: white; font-size: 16px">
                                    Webcam
                                </div>
                                <div id="WCStatusIcon" class="status">
                                </div>
                                <div style="display: none; font-size: 12px; color: black;" id="divWebcam">
                                    <asp:LinkButton ID="hlnkWebcam" runat="server" Text="Next Steps" OnClientClick="OpenWC(); return false;"></asp:LinkButton>
                                    <%-- <asp:HyperLink ID="hlnkWebcam" runat="server" NavigateUrl="~/SystemReadinessMSG.aspx" Text="Next Steps" Font-Underline="true"  Target="_blank" ForeColor="white" Font-Size="Small"></asp:HyperLink>--%>
                                </div>
                                <%--  <label id="WebCamStatus" style="font-size: medium; color: white; display:none;">
                                    detecting...</label>--%>
                            </td>
                            <td width="75">&nbsp;</td>
                            <td style="border-color: #E4E3E3; width: 250px; position: relative;">
                                <%--<div id="Mic_Detect" class="micro_main">
                                </div>--%>
                                <div>
                                    <img src="Images/microphone.png" /></div>
                                <div style="color: white; font-size: 16px">
                                    Microphone
                                </div>
                                <div id="MStatusIcon" class="status">
                                </div>
                                <div style="display: none; font-size: 12px; color: black;" id="divmic">
                                    <asp:LinkButton ID="hlnkMic" runat="server" Text="Next Steps" OnClientClick="OpenMP(); return false;"></asp:LinkButton>
                                    <%--<asp:HyperLink ID="hlnkMic" runat="server" NavigateUrl="~/SystemReadinessMSG.aspx" Text="Next Steps" Font-Underline="true"  Target="_blank" ForeColor="white" Font-Size="Small"></asp:HyperLink>--%>
                                </div>
                                <%--  <label id="MicStatus" style="font-size: medium; color: white;display:none;">
                                    detecting...</label>--%>
                            </td>
                            <td width="75">&nbsp;</td>
                            <td style="width: 180px; position: relative;">
                               <%-- <div id="Div2" class="os_main">
                                </div>--%>
                                <div>
                                    <img src="Images/Mac.png" /></div>
                                <div style="color: white; font-size: 16px;">
                                    Operating System
                                </div>
                                <div id="OSStatusIcon" class="status">
                                </div>
                                <div style="display: none; font-size: 12px; color: black;" id="divOs">
                                    <asp:LinkButton ID="hlnkos" runat="server" Text="Next Steps" OnClientClick="OpenOS(); return false;" Font-Size="Medium"></asp:LinkButton>
                                    <%-- <asp:HyperLink ID="hlnkos" runat="server" NavigateUrl="~/SystemReadinessMSG.aspx" Text="Next Steps" Font-Underline="true"  Target="_blank" ForeColor="white" Font-Size="Small"></asp:HyperLink>--%>
                                </div>
                                <%--  <div id="div5">
                                   <label id="OSStatus" style="font-size: medium; color: white;display:none;">
                                        detecting...</label>
                                </div>--%>
                            </td>

                        </tr>

                        <tr>
                            <td style="width: 180px; position: relative;">
                               <%-- <div id="Div1" class="browser_main">
                                </div>--%>
                                <div>
                                    <img src="Images/browsers.png" /></div>
                                <div style="color: white; font-size: 16px">
                                    Browsers
                                </div>
                                <div id="BStatusIcon" class="status">
                                </div>
                                <div style="display: none; font-size: 12px; color: black;" id="divBrowser">
                                    <asp:LinkButton ID="hlnkBrowser" runat="server" Text="Next Steps" OnClientClick="OpenBrowser(); return false;"></asp:LinkButton>
                                    <%-- <asp:HyperLink ID="hlnkBrowser" runat="server" NavigateUrl="~/SystemReadinessMSG.aspx" Text="Next Steps" Font-Underline="true"  Target="_blank" ForeColor="white" Font-Size="Small"></asp:HyperLink>--%>
                                </div>
                                <%--  <div id="div3">
                                    <label id="BrowserStatus" style="font-size: medium; color: white;display:none;">
                                        detecting...</label>
                                </div>--%>
                            </td>
                            <td width="75">&nbsp;</td>

                            <td style="width: 250px; position: relative;">
                                <%--<div id="Speed_Detect" class="internet_main">
                                </div>--%>
                                <div>
                                    <img src="Images/bandwidth.png" /></div>
                                <div style="color: white; font-size: 16px">
                                    Internet Speed
                                </div>
                                <div id="BWStatusIcon" class="status">
                                </div>
                                <div id="divResults" style="width:250px; text-align: center; margin: 0px auto; display: none">
                                    <table width="100%" style="font-size: 12px;">
                                        <tr>
                                            <td>
                                                <label id="SpeedTestStatus_down" style="font-size: 14px; color: black;">
                                            </td>
                                        </tr>
                                    </table>

                                    <div class="clear">
                                    </div>
                                </div>
                                <div style="display: none; font-size: 12px; color: black;" id="divIS">
                                    <asp:LinkButton ID="hknkIS" runat="server" Text="Next Steps" OnClientClick="OpenIS(); return false;"></asp:LinkButton>
                                    <%-- <asp:HyperLink ID="hknkIS" runat="server" NavigateUrl="~/SystemReadinessMSG.aspx" Text="Next Steps" Font-Underline="true"  Target="_blank" ForeColor="white" Font-Size="Small"></asp:HyperLink>--%>
                                </div>

                                <%-- <div id="divDetecting">
                                    <label id="SpeedTestStatus" style="font-size: medium; color: white;display:none;">
                                        detecting...</label>
                                </div>--%>
                            </td>


                            <td width="75">&nbsp;</td>
                            <td style="border-color: #E4E3E3; width: 180px; position: relative;">
                                <%--<div id="Flash_Detect" class="flash_main">
                                </div>--%>
                                <div>
                                    <img src="Images/flash.png" /></div>
                                <div style="color: white; font-size: 16px">
                                    Flash
                                </div>
                                <div id="FStatusIcon" class="status">
                                </div>
                                <div style="display: none; font-size: 12px; color: black;" id="lnkFlash">
                                    <asp:LinkButton ID="lnkPdf" runat="server" Text="Next Steps"></asp:LinkButton>
                                    <%-- <asp:HyperLink ID="lnkPdf" runat="server" NavigateUrl="~/SystemReadinessMSG.aspx" Text="Next Steps" Font-Underline="true"  ForeColor="white" Font-Size="Small"></asp:HyperLink>--%>
                                </div>
                                <%-- <label id="FlashStatus" style="font-size: medium; color: white;display:none;">
                                    detecting...</label>--%>
                                 
                            </td>


                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td id="Td1" colspan="5" runat="server">
                              <asp:Label ID="lblmessage" runat="server" Text="It may require up to 60 seconds to verify your internet speed." Font-Size="Medium"></asp:Label>
                         

                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="clear">
            </div>
        </div>
        <div id="footer">
            <div class="footer_inner">
              Copyright &copy; 2013 - <%: DateTime.Now.Year %>  <a target="_blank" href="http://examity.com/" style="color:white;">Examity&nbsp;<sup>&reg;</sup></a>&nbsp; All Rights Reserved.
            <div class="clear">
            </div>
            </div>
        </div>
        <div id="divCamHolder" style="width: 0px; height: 0px; visibility: hidden">
        </div>
        <div id="application_container" runat="server">
        </div>

    </form>
</body>
</html>
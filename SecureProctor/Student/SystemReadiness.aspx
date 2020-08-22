<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true" CodeBehind="SystemReadiness.aspx.cs" Inherits="SecureProctor.Student.SystemReadiness" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StudentContent" runat="server">

     <link href="../CSS/SystemReadinessNew.css" rel="stylesheet" />
    <script src="../SystemReadiness/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../SystemReadiness/checkExistance.js" type="text/javascript"></script>
    <script src="../SystemReadiness/detectBrowser.js" type="text/javascript"></script>
    <script src="../SystemReadiness/spin.min.js" type="text/javascript"></script>
    <script src="../SystemReadiness/swfobject.js" type="text/javascript"></script>
    <script src="../SystemReadiness/ua-parser.js" type="text/javascript"></script>
   <script src="../SystemReadiness/ua-list-example.js" type="text/javascript"></script>
    <script src="../Scripts/CamScripts.js" type="text/javascript"></script>

   
    <script src="../SystemReadiness/OSBrowserCheck.js" type="text/javascript"></script>
    <link href="../CSS/ApplicationStyleSheet.css" type="text/css" rel="Stylesheet" />

    <link href="../CSS/help.css" rel="stylesheet" type="text/css" />

    <link href="https://cdn.desk.com/assets/widget_embed_191.css" media="screen" rel="stylesheet" type="text/css" />
    <!--If you already have fancybox on the page this script tag should be omitted-->
    <script src="https://desk-customers.s3.amazonaws.com/shared/widget_embed_libraries_191.js" type="text/javascript"></script>

    <script src="../SystemReadiness/speedcheck.js" type="text/javascript"></script>


    <script type="text/javascript">

        var imagesrc = "https://test.examity.com/Systemcheck/images/download.jpg";


        var speedMbps = 0;
        var speedValue = []; var speedtest; var _speedvalue = 0;
        $(document).ready(function () {
            ///new code to check for internte speed
            spin('BWStatusIcon');

            speedtest = setInterval(function () {
                showResults();

                if (speedValue.length == 3) {
                    //console.log(Math.abs(speedValue[0]), Math.abs(speedValue[1]), Math.abs(speedValue[2]))
                    _speedvalue = (Math.abs(speedValue[0]) + Math.abs(speedValue[1]) + Math.abs(speedValue[2])) / 3;
                    //console.log(_speedvalue);
                    onTestCompleted(_speedvalue);
                }
            }, 1000);




            function showResults() {

                $('h3')._speedTest({
                    fileSize: 5000000, //size of the file in bytes 5616998
                    fileType: "image",//type of the file to be downloaded
                    fileUrl: imagesrc
                });

                var val = $('h3').text();
                console.log("val", val);
                speedValue.push($('h3').text());
                //$('h3').text('');
                if (speedValue.length == 3) {
                    clearInterval(speedtest);

                }
                $('h3').hide();


            }
        });




        var resultset = OSBrowserCheck();
        var arr = resultset.split('|');
        //calling os
        //console.log("isFlashEnabled ", navigator.plugins['Shockwave Flash'], navigator.mimeTypes['application/x-shockwave-flash']);


        if (IsHtml5Compliant() == "No") {
            jQuery("#flashorhtmlimg").empty();
            jQuery("#flashorhtmldiv").empty();
            jQuery("#flashorhtmlimg").attr('src', 'images/flash.png');
            jQuery("#flashorhtmldiv").text('Flash');
            //spin all loader images
            SpinAll();
            //getting os and browser versions 
            isOsSupports(arr[0], arr[1]);
            //calling browser
            isBrowserSupports(arr[2], arr[3]);

            try {
                //calling flash,webcam and microphone

                swfobject.embedSWF("SystemReadiness/CheckSystemReadyness.swf", "divCamHolder", "1", "1", "31.0.0", false, null, params, null);
                //console.log(swfobject.hasFlashPlayerVersion("1"));


                //var el = document.getElementById("divCamHolder");
                //swfobject.embedSWF("SystemReadiness/CheckSystemReadyness.swf", el, 300, 120, 31);
                //console.log(swfobject.hasFlashPlayerVersion("1"));
                //var el = document.getElementById("divCamHolder");
                //swfobject.embedSWF("SystemReadiness/CheckSystemReadyness.swf", el, "1", "1", "11.0.0", false, null, params, null);
                //console.log(jQuery.browser.flash);
                //checking browser has flash
                if (jQuery.browser.flash) {

                    //checking flash version support
                    if (isFlashExists() != 'warning') {
                        var params = {};
                        params.allowscriptaccess = "always";
                        ShowFlash();
                    }
                    else {
                        FlashVersionNotSupported();
                    }
                }

                else {
                    //******** If no flash detected **************//
                    FlashNotFound();
                    //console.log(swfobject);
                    ShowFlashNotFoundAlert();
                }

                try {

                    //SomApi.account = "SOM53daefe4b32d8";
                    //SomApi.domainName = "prod.examity.com";
                    //SomApi.config.sustainTime = 8;
                    //SomApi.onTestCompleted = onTestCompleted;
                    //SomApi.onError = onError;
                    //SomApi.config.uploadTestEnabled = true;
                    //SomApi.startTest();




                }
                catch (e) {

                    jQuery("#BWStatusIcon").empty();
                    jQuery("#BWStatusIcon").removeClass();
                    jQuery("#BWStatusIcon").addClass('prlblem');
                    jQuery("#BWStatusIcon").text("Not Ready!");

                }

            }



            catch (e) {
                FlashNotFound();

            }


        }
        else {
            var hasMicrophone = false;
            var hasSpeakers = false;
            var hasWebcam = false;

            var isMicrophoneAlreadyCaptured = false;
            var isWebcamAlreadyCaptured = false;

            spin('WCStatusIcon');
            spin('MStatusIcon');



            navigator.mediaDevices.enumerateDevices().then(function (devices) {
                devices.forEach(function (_device) {

                    var device = {};
                    for (var d in _device) {

                        device[d] = _device[d];
                        //alert(device[d]);
                    }

                    if (device.kind == 'audio' || device.kind == 'audioinput') {
                        device.kind = 'audioinput';
                    }

                    if (device.kind == 'video' || device.kind == 'videoinput') {
                        device.kind = 'videoinput';
                    }


                    if (device.kind === 'videoinput' && !isWebcamAlreadyCaptured) {
                        isWebcamAlreadyCaptured = true;
                    }

                    if (device.kind === 'audioinput' && !isMicrophoneAlreadyCaptured) {
                        isMicrophoneAlreadyCaptured = true;
                    }
                    //}

                    if (device.kind === 'audioinput') {
                        hasMicrophone = true;
                    }

                    if (device.kind === 'audiooutput') {
                        hasSpeakers = true;
                    }

                    if (device.kind === 'videoinput') {

                        console.log("device", device.kind);
                        hasWebcam = true;
                    }

                    // there is no 'videoouput' in the spec.

                    //MediaDevices.push(device);
                });
                if (!hasMicrophone) {
                    //alert("No Microphone available");
                    jQuery("#MStatusIcon").removeClass();
                    jQuery("#MStatusIcon").addClass('notfound');
                    jQuery("#MStatusIcon").text("Not Ready!");

                } else {
                    jQuery("#MStatusIcon").removeClass();
                    jQuery("#MStatusIcon").addClass('found');
                    jQuery("#MStatusIcon").text("Ready");
                }
                if (!hasWebcam) {
                    jQuery("#WCStatusIcon").removeClass();
                    jQuery("#WCStatusIcon").addClass('notfound');
                    jQuery("#WCStatusIcon").text("Not Ready!");

                } else {
                    console.log("found");
                    jQuery("#WCStatusIcon").removeClass();
                    jQuery("#WCStatusIcon").addClass('found');
                    jQuery("#WCStatusIcon").text("Ready");
                }
            });

            spin('OSStatusIcon');
            spin('BWStatusIcon');
            try {

                //SomApi.account = "SOM53daefe4b32d8";
                //SomApi.domainName = "prod.examity.com";
                //SomApi.config.sustainTime = 8;
                //SomApi.onTestCompleted = onTestCompleted;
                //SomApi.onError = onError;
                //SomApi.config.uploadTestEnabled = true;
                //SomApi.startTest();
                //download.onload = function () {
                //    endTime = (new Date()).getTime();
                //    showResults();

                //}
                //startTime = (new Date()).getTime();


            }
            catch (e) {

                jQuery("#BWStatusIcon").empty();
                jQuery("#BWStatusIcon").removeClass();
                jQuery("#BWStatusIcon").addClass('prlblem');
                jQuery("#BWStatusIcon").text("Not Ready!");

            }
            spin('BStatusIcon');
            //spin('Html5StatusIcon');
            isOsSupports(arr[0], arr[1]);
            //calling browser
            isBrowserSupports(arr[2], arr[3]);
            isHtml5Supports();
            //SomApi.startTest();
        }
        //function isFlashEnabled() {
        //    var flash = navigator.plugins.namedItem('Shockwave Flash');
        //    if (!flash) { return 0; }
        //    else { return 1; }
        //}


        function ShowFlashNotFoundAlert() {
            setTimeout(function () {
                alert(' Flash plug-in Disabled/Not Detected. Please Enable/Install latest Flash Plug-in from https://get.adobe.com/flashplayer/.');
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


        function isCameraFound(result) {
            //*********** Camera Callback Function *****************//         
            setTimeout(function () {
                //alert(result);
                jQuery("#WCStatusIcon").empty();

                if (result == 'pass') {
                    console.log("pass");
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

        }

        function FlashNotFound() {
            //jQuery("#FlashStatus").text("Not Found");
            jQuery("#FStatusIcon").empty();
            jQuery("#FStatusIcon").removeClass();
            jQuery("#FStatusIcon").addClass('prlblem');
            jQuery("#FStatusIcon").text("Not Ready!");

            jQuery("#WCStatusIcon").empty();
            jQuery("#WCStatusIcon").removeClass();
            jQuery("#WCStatusIcon").addClass('problem');
            jQuery("#WCStatusIcon").text("Not Ready!");

            jQuery("#MStatusIcon").empty();
            jQuery("#MStatusIcon").removeClass();
            jQuery("#MStatusIcon").addClass('problem');
            jQuery("#MStatusIcon").text("Not Ready!");


        }

        function onTestCompleted(speedResult) {

            var testResult = Math.abs(speedResult);
            jQuery("#BWStatusIcon").empty();
            jQuery("#BWStatusIcon").hide()//addClass('status');

            //if (testResult.upload > 3)
            //    jQuery("#SpeedTestStatus_down").text("Proceed. Speed is acceptable.");
            //else if (testResult.upload <= 3 && testResult.upload >= 1)
            //    jQuery("#SpeedTestStatus_down").text("Proceed. Speed is acceptable.");
            //else if (testResult.upload < 1)
            //    jQuery("#SpeedTestStatus_down").text("Speed is not acceptable. You may experience issues if you proceed");

            if (testResult > 4)
                jQuery("#SpeedTestStatus_down").text("Proceed. Speed is acceptable.");
            else if (testResult.upload <= 4 && testResult >= 1)
                jQuery("#SpeedTestStatus_down").text("Proceed. Speed is acceptable.");
            else if (testResult < 1)
                jQuery("#SpeedTestStatus_down").text("Speed is not acceptable. You may experience issues if you proceed");
            jQuery("#divResults").show()
            jQuery("#divIS").hide()
            jQuery("#divNextButton").show()

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

        function isBrowserSupports(browser, browserverstion) {
            //************* Browser Detection *****************//
            setTimeout(function () {

                var parser = new UAParser();
                var browser = parser.getBrowser();

                jQuery("#BStatusIcon").empty();

                if (browser.name == 'Edge' || browser.name == 'IE' || browser.name == 'Chrome' || browser.name == 'Firefox' || browser.name == 'Safari') {

                    if (browser.name == 'Edge') {
                        $("#imgBrowser").attr("src", "../Images/Edge.png");
                    }
                    else if (browser.name == 'IE') {
                        $("#imgBrowser").attr("src", "../Images/ie.png");
                    }
                    else if (browser.name == 'Chrome') {
                        $("#imgBrowser").attr("src", "../Images/chrome.png");
                    }
                    else if (browser.name == 'Firefox') {
                        $("#imgBrowser").attr("src", "../Images/firefox.png");
                    }
                    else if (browser.name == 'Safari') {
                        $("#imgBrowser").attr("src", "../Images/safari.png");
                    }

                    jQuery("#BStatusIcon").removeClass();
                    jQuery("#BStatusIcon").addClass('found');
                    jQuery("#BStatusIcon").html(browser.name + " " + browser.version + "<br>" + 'Ready');
                    // jQuery("#BrowserStatus").text('Supported');
                    jQuery("#divBrowser").css("display", "none");
                    //divBrowser
                    //SomApi.startTest(); 
                    //download.onload = function () {
                    //    endTime = (new Date()).getTime();
                    //    showResults();

                    //}
                    //startTime = (new Date()).getTime();
                }
                else {
                    jQuery("#BStatusIcon").removeClass();
                    jQuery("#BStatusIcon").addClass('notfound');
                    jQuery("#BStatusIcon").text('Not Ready!');
                    // jQuery("#BrowserStatus").text("Not Supported");
                    jQuery("#divBrowser").css("display", "block");
                }


                ////alert(browser);
                ////alert(browserverstion);
                //jQuery("#BStatusIcon").empty();

                //browserverstion = browserverstion.substr(0, 2);

                //if (browser == 'Microsoft Internet Explorer' && browserverstion >= 8) {
                //    ShowBrowser();
                //}
                //else if (browser == 'Firefox' && browserverstion >= 34) {
                //    ShowBrowser();
                //}
                //else if (browser == 'Chrome' && browserverstion >= 39) {
                //    ShowBrowser();
                //}
                //else if (browser == 'Safari' && browserverstion >= 6) {
                //    ShowBrowser();
                //}
                //else if (browser == 'Opera') {
                //    ShowBrowser();
                //}
                //else {
                //    HideBrowser();
                //}

            }, 500);
        }


        function ShowBrowser() {

            var parser = new UAParser();
            var browser = parser.getBrowser();
            jQuery("#BStatusIcon").removeClass();
            jQuery("#BStatusIcon").addClass('found');
            jQuery("#BStatusIcon").html(browser.name + " " + browser.version + '<br>' + 'Ready');
            // jQuery("#BrowserStatus").text('Supported');
            jQuery("#divBrowser").css("display", "none");
        }

        function HideBrowser() {
            jQuery("#BStatusIcon").removeClass();
            jQuery("#BStatusIcon").addClass('notfound');
            jQuery("#BStatusIcon").text('Not Ready!');
            // jQuery("#BrowserStatus").text("Not Supported");
            jQuery("#divBrowser").css("display", "block");

        }

        function ShowFlash() {
            jQuery("#flashorhtmldiv").empty();
            jQuery("#flashorhtmlimg").empty();
            jQuery("#FStatusIcon").removeClass();
            jQuery("#FStatusIcon").addClass('found');
            jQuery("#FStatusIcon").text('Ready');
            //jQuery("#FlashStatus").text("Supported");
            jQuery("#lnkFlash").css("display", "none");
            jQuery("#flashorhtmlimg").attr('src', '../images/flash.png');
            jQuery("#flashorhtmldiv").text('Flash');

        }
        function isOsSupports(ostype, osverstion) {
            //************* OS Detection Windows, Mac only *****************//
            setTimeout(function () {
                var parser = new UAParser();
                var os = parser.getOS();
                jQuery("#OSStatusIcon").empty();

                if (jQuery.os.name == 'win' || jQuery.os.name == 'mac') {

                    if (jQuery.os.name == 'win') {
                        $("#imgOs").attr("src", "../Images/windows.png");
                    }
                    else if (jQuery.os.name == 'mac') {
                        $("#imgOs").attr("src", "../Images/mac1.png");
                    }


                    jQuery("#OSStatusIcon").removeClass();
                    jQuery("#OSStatusIcon").addClass('found');
                    jQuery("#OSStatusIcon").html(os.name + " " + os.version + "<br>" + 'Ready');
                    jQuery("#divOs").css("display", "none");

                    jQuery("#OSStatus").text('Supported');
                    //SomApi.startTest();
                    //download.onload = function () {
                    //    endTime = (new Date()).getTime();
                    //    showResults();

                    //}
                    //startTime = (new Date()).getTime();
                }
                else {
                    jQuery("#OSStatusIcon").removeClass();
                    jQuery("#OSStatusIcon").addClass('notfound');
                    jQuery("#OSStatusIcon").text('Not Ready!');
                    jQuery("#OSStatus").text("Not Supported");
                    jQuery("#divOs").css("display", "block");
                }


                //if (ostype == 'Windows' && osverstion >= 7) {
                //    jQuery("#OSStatusIcon").removeClass();
                //    jQuery("#OSStatusIcon").addClass('found');
                //    jQuery("#OSStatusIcon").text('Ready');
                //    jQuery("#divOs").css("display", "none");

                //    jQuery("#OSStatus").text('Supported');


                //}
                //else if (ostype == 'Mac OS X' && osverstion.substring(0, 2) >= 10) {
                //    jQuery("#OSStatusIcon").removeClass();
                //    jQuery("#OSStatusIcon").addClass('found');
                //    jQuery("#OSStatusIcon").text('Ready');
                //    jQuery("#divOs").css("display", "none");

                //    jQuery("#OSStatus").text('Supported');
                //    // SomApi.startTest();
                //}
                //else {
                //    jQuery("#OSStatusIcon").removeClass();
                //    jQuery("#OSStatusIcon").addClass('notfound');
                //    jQuery("#OSStatusIcon").text('Not Ready!');
                //    jQuery("#OSStatus").text("Not Supported");
                //    jQuery("#divOs").css("display", "block");

                //}


            }, 300);
        }
        function isHtml5Supports() {
            //************* Browser Detection *****************//
            setTimeout(function () {


                jQuery("#Html5StatusIcon").empty();

                jQuery("#flashorhtmlimg").empty();
                jQuery("#flashorhtmldiv").empty();
                if (jQuery.browser.name == 'firefox' || jQuery.browser.name == 'opera' || jQuery.browser.name == 'chrome' || jQuery.browser.name == 'edge') {
                    jQuery("#FStatusIcon").removeClass();
                    jQuery("#FStatusIcon").addClass('found');
                    jQuery("#FStatusIcon").text('Ready');

                    jQuery("#flashorhtmlimg").attr('src', '../images/html5.png');


                }

            }, 500);
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
    <div class="login_new1" style="width: 90%; margin: 0px auto">
        <table width="100%" class="bordered">
            <tr>


                <td>

                    <asp:Image ID="imgHead" runat="server" ImageUrl="../Images/ImgProductLogo.png" AlternateText="Examity" title="Examity" />
                </td>
            </tr>



        </table>

    </div>
    <div class="login_new1" style="width: 90%; margin: 0px auto">
        <div id="Sapplication_container">
            <div class="System_container">

                <div style="padding-top: 5px; padding-bottom: 40px;">
                    <div style="font-size: 20px; padding-top: 30px; padding-bottom: 30px; margin: 0px auto; width: 900px; color: #000; text-align: center;">Examity will ensure your computer is ready. </div>
                    <table style="border-color: #E4E3E3; width: 720px; margin: 0px auto; text-align: center;" cellpadding="2">

                        <tr id="SystemReadyness">
                            <td style="border-color: #E4E3E3; width: 150px; position: relative;">
                                <%-- <div id="Cam_Detect" class="camera_main">
                                </div>--%>
                                <div>
                                    <img src="../Images/webcam1.png" />
                                </div>

                                <div style="color: black; font-size: 16px">
                                    Webcam
                                </div>
                                <div id="WCStatusIcon" class="status">
                                </div>
                                <div style="display: none; font-size: 14px; color: black;" id="divWebcam">
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
                                    <img src="../Images/microphone.png" />
                                </div>
                                <div style="color: black; font-size: 16px">
                                    Microphone
                                </div>
                                <div id="MStatusIcon" class="status">
                                </div>
                                <div style="display: none; font-size: 14px; color: black;" id="divmic">
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
                                    <img src="../Images/Mac.png" id="imgOs" width="80px" />
                                </div>
                                <div style="color: black; font-size: 16px;">
                                    Operating System
                                </div>
                                <div id="OSStatusIcon" class="status">
                                </div>
                                <div style="display: none; font-size: 14px; color: black;" id="divOs">
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
                                    <img src="../Images/browsers.png" id="imgBrowser" />
                                </div>
                                <div style="color: black; font-size: 16px">
                                    Browser
                                </div>
                                <div id="BStatusIcon" class="status">
                                </div>
                                <div style="display: none; font-size: 14px; color: black;" id="divBrowser">
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
                                    <img src="../Images/bandwidth.png" />
                                </div>
                                <div style="color: black; font-size: 16px">
                                    Internet Speed
                                </div>
                                <div id="BWStatusIcon" class="status">
                                </div>
                                <div id="divResults" style="width: 250px; text-align: center; margin: 0px auto; display: none">
                                    <table width="100%" style="font-size: 12px;">
                                        <tr>
                                            <td>
                                                <label id="SpeedTestStatus_down" style="font-size: 14px; color: black;" />
                                            </td>
                                        </tr>
                                    </table>

                                    <div class="clear">
                                    </div>
                                </div>
                                <div style="display: none; font-size: 14px; color: black;" id="divIS">
                                    <asp:LinkButton ID="hknkIS" runat="server" Text="Next Steps" OnClientClick="OpenIS(); return false;"></asp:LinkButton>
                                    <%-- <asp:HyperLink ID="hknkIS" runat="server" NavigateUrl="~/SystemReadinessMSG.aspx" Text="Next Steps" Font-Underline="true"  Target="_blank" ForeColor="white" Font-Size="Small"></asp:HyperLink>--%>
                                </div>

                                <%-- <div id="divDetecting">
                                    <label id="SpeedTestStatus" style="font-size: medium; color: white;display:none;">
                                        detecting...</label>
                                </div>--%>
                            </td>


                            <td width="75">&nbsp;<h3></h3>
                            </td>
                            <td style="border-color: #E4E3E3; width: 180px; position: relative; display: none;">
                                <%--<div id="Flash_Detect" class="flash_main">
                                </div>--%>

                                <div>
                                    <img id="flashorhtmlimg" />
                                </div>
                                <div style="color: black; font-size: 16px" id="flashorhtmldiv">
                                </div>
                                <div id="FStatusIcon" class="status">
                                </div>
                                <div style="display: none; font-size: 14px; color: black;" id="lnkFlash">
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
                            <td colspan="5">
                                <asp:Label ID="lblmessage" runat="server" Text="It may require up to 60 seconds to verify your internet speed." Font-Size="Medium"></asp:Label>


                            </td>
                        </tr>

                    </table>
                </div>
            </div>
            <div class="clear">
            </div>
        </div>
    </div>
    <div id="divNextButton" style="display:none">
        <table width="100%">
            <tr>
                <td align="center">
                    <asp:Button ID="btnNext" runat="server" CssClass="button1 orange" OnClick="btnNext_Click" Text="Next" />
                </td>
            </tr>
        </table>
    </div>

    <div id="divCamHolder" style="width: 0px; height: 0px; visibility: hidden">
    </div>

    
</asp:Content>

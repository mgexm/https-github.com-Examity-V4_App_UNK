<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateExamiKEY.aspx.cs" Inherits="SecureProctor.Student.UpdateExamiKEY" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href='https://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
    <link rel="shortcut icon" href="../Images/secureproctor.ico" />
    <link href="../CSS/ApplicationStyleSheet.css" type="text/css" rel="Stylesheet" />
    <link href="../CSS/help.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/jquery.js">
        </script>
  
       <script type="text/javascript">

         function check(data) {
            if (typeof (data.length) != 'undefined') {
                if (/^[\s]*$/.test(data.toString())) {
                    return true;
                }
            }
        }

        function validate(e) {
            var regexp1 = new RegExp("[^a-z]");
            $("#lblkeyMsg").css("color", "red");
			$("#lblkeyMsg").css( "fontSize", "15px" );
            if (e.keyCode == 13 || e.type == 'click') {

                if (check($('#firstname').val())) {
                    $("#lblkeyMsg").text("First Name required.");
                    $('#firstname').focus();
					$('#firstname').val('');
                    return false;
                }
                else if (regexp1.test($('#firstname').val())) {
                    $("#lblkeyMsg").text("CAPS and SPACES are not allowed.");
                    $('#firstname').focus();
					$('#firstname').val('');
                    return false;
                }
                else if (check($('#lastname').val())) {
                    $("#lblkeyMsg").text("Last Name required.");
                    $('#lastname').focus();
					$('#lastname').val('');
                    return false;
                }
                else if (regexp1.test($('#lastname').val())) {
                    $("#lblkeyMsg").text("CAPS and SPACES are not allowed.");
                    $('#lastname').focus();
					$('#lastname').val('');
                    return false;
                }
                else if (check($('#firstNameLastName').val())) {
                    $("#lblkeyMsg").text("First Name and Last Name required.");
                    $('#firstNameLastName').focus();
					$('#firstNameLastName').val('');
                    return false;
                }
                else if (regexp1.test($('#firstNameLastName').val())) {
                    $("#lblkeyMsg").text("CAPS and SPACES are not allowed.");
                    $('#firstNameLastName').focus();
					$('#firstNameLastName').val('');
                    return false;
                }
                else if (check($('#refirstNameLastName').val())) {
                    $("#lblkeyMsg").text("Re-enter First Name and Last Name.");
                    $('#refirstNameLastName').focus();
					$('#refirstNameLastName').val('');
                    return false;
                }
                else if (regexp1.test($('#refirstNameLastName').val())) {
                    $("#lblkeyMsg").text("CAPS and SPACES are not allowed.");
                    $('#refirstNameLastName').focus();
					$('#refirstNameLastName').val('');
                    return false;
                }
                else if ($('#firstNameLastName').val() != $('#refirstNameLastName').val()) {
                    $("#lblkeyMsg").text("Your First Name/Last Name do not match.");
                    $('#refirstNameLastName').focus();
					$('#refirstNameLastName').val('');
                    return false;
                }
                else {
                    $('#btnradSave').click();
                        return true;
                    }
			}
		}
		
		function isAlphapet() {
                var regexp1 = new RegExp("[^a-z]");
                $("#lblkeyMsg").css("color", "red");
				$("#lblkeyMsg").css( "fontSize", "15px" );

				if (regexp1.test($('#firstname').val())) {
                    $("#lblkeyMsg").text("CAPS and SPACES are not allowed.");
                    $('#firstname').focus();
                    $('#firstname').val('');
                    return false;
                }
                else if (regexp1.test($('#lastname').val())) {
                            $("#lblkeyMsg").text("CAPS and SPACES are not allowed.");
                            $('#lastname').focus();
                            $('#lastname').val('');
                            return false;
                }
                else if (regexp1.test($('#firstNameLastName').val())) {
                            $("#lblkeyMsg").text("CAPS and SPACES are not allowed.");
                            $('#firstNameLastName').focus();
                            $('#firstNameLastName').val('');
                            return false;
                }
                else if (regexp1.test($('#refirstNameLastName').val())) {
                            $("#lblkeyMsg").text("CAPS and SPACES are not allowed.");
                            $('#refirstNameLastName').focus();
                            $('#refirstNameLastName').val('');
                            return false;
                }
                        /*else if ($('#firstNameLastName').val() != $('#refirstNameLastName').val()) {
                            $("#lblkeyMsg").text("Your First Name/Last Name do not match.");
                            $('#refirstNameLastName').focus();
                            $('#refirstNameLastName').val('');
                            return false;
                        }*/
                else {
                    return true;
                }
            }


    </script>
</head>
<body>
    <form id="form1" runat="server">
          <div class="top"> 
<table cellpadding="0" cellspacing="0" width="100%" align="center">
<tr>
<td width="5%">&nbsp;</td>
<td valign="top" class="welcome_text_block" width="90%">
<table cellpadding="0" cellspacing="0" width="100%">
<tr>
<td class="logo" valign="top" width="300" height="28">&nbsp;</td>
<td width="451" style="text-align:left; color:#FFFFFF;" valign="top" align="left">&nbsp;</td>
<td width="3" style="text-align:left; color:#FFFFFF;" align="left">&nbsp;</td>
<td width="431" style="text-align:right; color:#FFFFFF;" valign="top" align="right">&nbsp;</td>
</tr>
<tr>
<td valign="midlle" colspan="2" align="left" >
   <img src="../Images/ImgClientlogo.png" alt="Client" border="0" />
</td>
<td style="text-align:right; color:#FFFFFF;" valign="top" align="right" colspan="2"> <a href="#"><img src="../Images/ImgProductLogo.png" alt="Examity" border="0" /></a></td>
</tr>
</table>
</td>
<td width="5%">&nbsp;</td>
</tr>
</table>
 
    </div>
        <div id="application_container">
        <div class="container">
           <div class="container_inner">
                    <div class="login_new1">
         <img src="../Images/examiKEY_heading.png" />
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
     <div class="login_new1">
       <div style="background:#e6e6e6; width:96%; margin:15px auto;">
           <div style="background:#e6e6e6; padding:5px 10px; color:#ff9900; font-size:14px; font-weight:bold; text-align:center;">
               <table width="100%" cellpadding="0" cellspacing="0">
                     <tr id="trheading" runat="server" >
<td align="left" style="background:#e6e6e6; padding:15px 10px; color:#ff9900; font-size:16px; font-weight:bold; text-align:center;">
<span>As an added measure of security, please type within the boxes below. Your "typing pattern" will help verify your identity in the future. 
</span>
                                        </td>
                                    </tr>
                   </table>
           </div>
           <div style="background:#fff; padding:10px 10px; margin:5px; ">
              <table width="100%" cellpadding="0" cellspacing="8" class="td_bg">
                 <tr id="trKeyStrokeEdit" runat="server">
                                        <td align="left">

                                            <table width="100%" cellpadding="0" cellspacing="8" class="td_bg">
                                                <tr>
                                                    <td width="40%" align="left">
                                                        <asp:Label ID="lblEditFname" runat="server" Text="Enter First Name" CssClass="Display"></asp:Label><br />
                                                        <asp:Label ID="nocaps" runat="server" Text="(NO CAPS)" CssClass="Display18" Font-Bold="true"></asp:Label>

                                                    </td>
                                                    <td>:
                                                    </td>
                                                    <td align="left">
                                                        <input id="firstname" name="firstname" type="text" autofocus="autofocus" autocomplete="off" style="height: 25px; font-size: 16px; width: 200px" onpaste="return false;" oncopy="return false;" onkeypress="return validate(event);" onblur="isAlphapet();"/>&nbsp;
                                                        <label for="john" style="font-size: 16px;">(example: john)</label>



                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lblEditLName" runat="server" Text="Enter Last Name" TabIndex="85" CssClass="Display"></asp:Label><br />
                                                        <asp:Label ID="lblLastnameNocaps" runat="server" Text="(NO CAPS)" CssClass="Display18" Font-Bold="true"></asp:Label>
                                                    </td>
                                                    <td>:
                                                    </td>
                                                    <td align="left">
                                                        <input id="lastname" name="lastname" type="text" autofocus="autofocus" autocomplete="off" style="height: 25px; font-size: 16px; width: 200px" onpaste="return false;" oncopy="return false;" onkeypress="return validate(event);" onblur="isAlphapet();"/>&nbsp;
                                                         <label for="john" style="font-size: 16px;">(example: smith)</label>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lblEditLastname" runat="server" Text="Enter First Name and Last Name" TabIndex="86" CssClass="Display"></asp:Label><br />
                                                        <asp:Label ID="lbleditnamenocaps" runat="server" Text="(NO CAPS, NO SPACES)" CssClass="Display18" Font-Bold="true"></asp:Label>
                                                    </td>
                                                    <td>:
                                                    </td>
                                                    <td align="left">
                                                        <input id="firstNameLastName" name="firstNameLastName" type="text" autofocus="autofocus" autocomplete="off" style="height: 25px; font-size: 16px; width: 200px" onpaste="return false;" oncopy="return false;" onkeypress="return validate(event);" onblur="isAlphapet();"/>&nbsp;
                                                          <label for="john" style="font-size: 16px;">(example: johnsmith)</label>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lblEditReenter" runat="server" Text="Re-enter First Name and Last Name" CssClass="Display"></asp:Label><br />
                                                        <asp:Label ID="Label14" runat="server" Text="(NO CAPS, NO SPACES)" CssClass="Display18" Font-Bold="true"></asp:Label>
                                                    </td>
                                                    <td>:
                                                    </td>
                                                    <td align="left">
                                                        <input id="refirstNameLastName" type="text" name="refirstNameLastName" autocomplete="off" autofocus="autofocus" style="height: 25px; font-size: 16px; width: 200px" onpaste="return false;" oncopy="return false;" onkeypress="return validate(event);" onblur="isAlphapet();"></input>&nbsp;                                                      
                                                          <label for="john" style="font-size: 16px;">(example: johnsmith)</label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td align="left">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <span class="Button_r SkinnedButton">

                                                                        <input id="btniputSave" name="Save" value="Save" type="button" runat="server" class="Decorated" onclick="validate(event);" />
                                                                    </span>

                                                                    <telerik:RadButton ID="btnradSave" runat="server" Text="<%$ Resources:SecureProctor,Common_Save %>"
                                                                        Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin %>"
                                                                        OnClick="btnradSave_Click" CausesValidation="true" Style="display: none;" UseSubmitBehavior="false">
                                                                    </telerik:RadButton>
                                                                </td>
                                                                
                                                            </tr>
                                                        </table>


                                                    </td>
                                                </tr>
                                            </table>


                                        </td>
                                    </tr>
                <tr><td align="center"><asp:Label ID="lblkeyMsg" runat="server" CssClass="customfont1"></asp:Label><br /><br />    
            <telerik:RadButton ID="imgOK" runat="server" Text="OK" Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin %>" Visible="false" OnClick="imgOK_Click">
                                                </telerik:RadButton>
            </td></tr>  
            </table>
           </div>
           <div style="height:1px;"></div>
           <div class="clear"></div>
       </div>
            
         </div>
           <telerik:RadCodeBlock ID="codeBlock" runat="server">
        <script src="https://prod.examity.com/commonfiles/StratKeyTrackerV1.js"></script>
        <script type="text/javascript">
            StratKeyTracker.SKTConfigure({ ctrlusername: "firstname", ctrlpassword: "firstNameLastName", ctrlConfirm: "refirstNameLastName" });
        </script>
    </telerik:RadCodeBlock>

</div></div>
   </div></div>
    <div id="footer">
               <div class="footer_inner">
            <div class="fut_left"style="width:400px;">
                        Copyright &copy; 2013 - <%: DateTime.Now.Year %>  <a target="_blank" href="http://examity.com/" style="color:white;">Examity&nbsp;<sup>&reg;</sup></a>&nbsp; All Rights Reserved.
            </div>
            <div id="supportpanels" style="float:right;width:360px;color:white;font-size:13px;">
                <div class="livechatpannel" style="float:left;width:70px;cursor:pointer">
                     <!--u>Live Chat</u>&nbsp;&nbsp;|-->
                </div>
                <div id="Emailsupport" style="float:left;width:100px;">
                    <a href="mailto:support@examity.com" style="color:white"><u>Email Support</u></a>&nbsp;|
                </div>
                <div id="phonesupport" style="float:left;width:180px">
                    Phone Support:
                    
                    855-EXAMITY
                </div>
                
                </div>

            <div class="clear">
            </div>
        </div>                
    </div>


     
    <!-- New code for Sales Force starts chat -->
<style type='text/css'>
.embeddedServiceHelpButton .helpButton .uiButton {
background-color: #f89520;
font-family: Arial, sans-serif;
}
.embeddedServiceHelpButton .helpButton .uiButton:focus {
 outline: 1px solid #f89520;
}
</style>
<script type='text/javascript' src='https://service.force.com/embeddedservice/5.0/esw.min.js'></script>
<script type='text/javascript'>
var initESW = function (gslbBaseURL) {
embedded_svc.settings.displayHelpButton = true; //Or false
embedded_svc.settings.language = 'en-US'; //For example, enter 'en' or 'en-US'
embedded_svc.settings.enabledFeatures = ['LiveAgent'];
embedded_svc.settings.entryFeature = 'LiveAgent';
embedded_svc.init(
'https://examity.my.salesforce.com',
'https://chats2.secure.force.com/liveAgentSetupFlow',
gslbBaseURL,
'00Di0000000HhYO',
'Agent_Chat',
{
 baseLiveAgentContentURL: 'https://c.la1-c2-ord.salesforceliveagent.com/content',
deploymentId: '5720H000000XZPJ',
buttonId: '5730H000000XZoy',
baseLiveAgentURL: 'https://d.la1-c2-ord.salesforceliveagent.com/chat',
eswLiveAgentDevName: 'Agent_Chat',
isOfflineSupportEnabled: true
}
);
};
if (!window.embedded_svc) {
var s = document.createElement('script');
s.setAttribute('src', 'https://examity.my.salesforce.com/embeddedservice/5.0/esw.min.js');
s.onload = function () {
initESW(null);
};
document.body.appendChild(s);
} else {
initESW('https://service.force.com');
}
</script>
<!-- New code for Sales Force chat -->
</form>
</body>
</html>

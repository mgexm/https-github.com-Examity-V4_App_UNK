<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SwitchRole.aspx.cs" Inherits="SecureProctor.SwitchRole" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Examity :: Login</title>
    <link rel="shortcut icon" href="Images/secureproctor.ico" />
    <link href="./CSS/ApplicationStyleSheet.css" type="text/css" rel="Stylesheet" />
   
    <link href="./CSS/help.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Scripts/jquery.js">
    </script>
   
</head>
<body>
    <%--<style type="text/css" media="screen, projection">
        @import url(//assets.zendesk.com/external/zenbox/v2.6/zenbox.css);
    </style>--%>
    <!--If you already have jquery on the page you don't need to insert this script tag-->
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js" type="text/javascript"></script>
<%--<link href="https://cdn.desk.com/assets/widget_embed_191.css" media="screen" rel="stylesheet" type="text/css" />--%>
<!--If you already have fancybox on the page this script tag should be omitted-->
<%--<script src="https://desk-customers.s3.amazonaws.com/shared/widget_embed_libraries_191.js" type="text/javascript"></script>--%>


    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <div class="top">
            <table cellpadding="0" cellspacing="0" width="100%" align="center">
<tr>
<td width="10%">&nbsp;</td>
<td valign="top" class="welcome_text_block" width="80%">
<table cellpadding="0" cellspacing="0" width="100%">
<tr>
<td class="logo" valign="top" width="300" height="28">&nbsp;</td>
<td width="451" style="text-align:left; color:#FFFFFF;" valign="top" align="left">&nbsp;</td>
<td width="3" style="text-align:left; color:#FFFFFF;" align="left">&nbsp;</td>
<td width="431" style="text-align:right; color:#FFFFFF;" valign="top" align="right">&nbsp;</td>
</tr>
<tr>
<td valign="midlle" colspan="2" align="left" >
   <img src="Images/ImgClientlogo.png" alt="Client" border="0" />
</td>
<td style="text-align:right; color:#FFFFFF;" valign="top" align="right" colspan="2"> <a href="#"><img src="Images/ImgProductLogo.png" alt="Examity" border="0" /></a></td>
</tr>
</table>
</td>
<td width="10%">&nbsp;</td>
</tr>
</table>



            
        </div>
        <div id="application_container_home">
            <div class="container">
                <div class="main_menu">
                    <ul>
                        <li>&nbsp; </li>

                    </ul>
                </div>
            </div>
            <div class="container_inner">
                <table width="40%" cellpadding="10" cellspacing="0" align="center" style="margin-top:40px; font-size:18px;">
                   <tr>
                   <td align="left" class="customfont1"><strong>Login as :</strong></td>
                   </tr>
                    <tr>
                        <td>
                            <div class="login_new">
                   <table cellpadding="2" width="100%">
                   <tr>
                   <td align="left" width="60%">
                   <asp:RadioButtonList ID="rdRoles" runat="server" CellSpacing="20" CellPadding="5" RepeatDirection="Vertical"></asp:RadioButtonList>
                   </td>
                  </tr>
                       <tr>
                    <td style="padding-left:50px;">
                    <telerik:RadButton ID="btnLogin" runat="server" Text="LOG IN" Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin %>"
                      OnClick="btnLogin_Click">
                    </telerik:RadButton>
                    </td>
                    </tr>
                    </table>
                    </div>
                        </td>
                    </tr>
                   
                   </table>
                <div class="clear">
                </div>
            </div>
        </div>
        <!-- content end -->
        <div id="footer">
            <div class="footer_inner" style="width: 80%">
                <div class="fut_left" style="width:400px;">
                  Copyright &copy; 2013 - <%: DateTime.Now.Year %>  <a target="_blank" href="http://examity.com/" style="color:white;">Examity&nbsp;<sup>&reg;</sup></a>&nbsp; All Rights Reserved.
                </div>
                <div id="supportpanels" style="float: right; color: white; font-size: 13px; text-align: right;">
                     <div class="ulCss" style="float: left;">
				<script>
				    /* new DESK.Widget({
				        version: 1,
				        ctaLabel: "Live Chat",
				        site: 'examity.desk.com',
				        port: '80',
				        type: 'chat',
				        displayMode: 0,  //0 for popup, 1 for lightbox
				        features: {
				            offerAlways: true,
				            offerAgentsOnline: false,
				            offerRoutingAgentsAvailable: false,
				            offerEmailIfChatUnavailable: false
				        },
				        fields: {
				            ticket: {
				                //desc: &#x27;&#x27;,
				                // labels_new: &#x27;&#x27;,
				                // priority: &#x27;&#x27;,
				                // subject: &#x27;&#x27;,
				                // custom_issue_type: &#x27;&#x27;,
				                // custom_customer_type: &#x27;&#x27;,
				                // custom_crm: &#x27;&#x27;
				            },
				            interaction: {
				                // email: &#x27;&#x27;,
				                // name: &#x27;&#x27;
				            },
				            chat: {
				                //subject: '' 
				            },
				            customer: {
				                // company: &#x27;&#x27;,
				                // desc: &#x27;&#x27;,
				                // first_name: &#x27;&#x27;,
				                // last_name: &#x27;&#x27;,
				                // locale_code: &#x27;&#x27;,
				                // title: &#x27;&#x27;,
				                // custom_contact_role: &#x27;&#x27;,
				                // custom_customer_type: &#x27;&#x27;
				            }
				        }
				    }).render();*/
                </script>
				</div>




                  <div class="livechatpannel" style="float: left; cursor: pointer">
                               <u class="ulCss">
                            </u>&nbsp;&nbsp;|
                      <%--  <!--u>Live Chat</u>&nbsp;&nbsp;|-->--%>
                           </div>
                    <div id="Emailsupport" style="float: left;">
                        &nbsp;&nbsp;<a href="mailto:support@examity.com" style="color: white"><u>Email Support</u></a>&nbsp;&nbsp;|&nbsp;&nbsp;
                    </div>
                    <div id="phonesupport" style="float: left;">
                        Phone Support: 855-EXAMITY
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
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SSOErrorPage.aspx.cs" Inherits="SecureProctor.Errors.SSOErrorPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Examity :: SSO Error page</title>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
    <link rel="shortcut icon" href="../Images/secureproctor.ico" />
    <link href="../CSS/ApplicationStyleSheet.css" type="text/css" rel="Stylesheet" />
    <link rel="shortcut icon" href="../Images/secureproctor.ico" />

    <link href="../CSS/help.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/jquery.js">
    </script>
      <!--If you already have jquery on the page you don't need to insert this script tag-->
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js" type="text/javascript"></script>
<%--<link href="https://cdn.desk.com/assets/widget_embed_191.css" media="screen" rel="stylesheet" type="text/css" />--%>
<!--If you already have fancybox on the page this script tag should be omitted-->
<%--<script src="https://desk-customers.s3.amazonaws.com/shared/widget_embed_libraries_191.js" type="text/javascript"></script>--%>

</head>
<body>
  
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
                                <td width="451" style="text-align: left; color: #FFFFFF;" valign="top" align="left">&nbsp;</td>
                                <td width="3" style="text-align: left; color: #FFFFFF;" align="left">&nbsp;</td>
                                <td width="431" style="text-align: right; color: #FFFFFF;" valign="top" align="right">&nbsp;</td>
                            </tr>
                            <tr>
                                <td valign="midlle"  align="left" colspan="2">
                              <%-- <img src="Images/ImgClientLogo.png" alt="Client" border="0"  />--%>
</td>
                             
                                <td style="text-align: right; color: #FFFFFF;" valign="top" align="right" colspan="2"><a href="#">
                                    <img src="../Images/ImgProductLogo.png" alt="Examity" border="0" /></a></td>
                            </tr>
                            <asp:Label ID="lblError" runat="server" visible=false></asp:Label>
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
                    <li>&nbsp;</li></ul>
            </div>
        </div>
        <div class="container_inner">

            <div class="login_new1">
                <asp:Panel ID="pnlLogin" runat="server">
                    <div style="margin:100px 0px;">
                    <div style="color:red; font-weight:bold; font-size:20px; text-align:center; margin-bottom:30px;">Login error!</div>
                   <div style="width:80%; margin:0px auto; border:1px solid #c1c1c1; background:#f5f5f5; padding:25px; font-size:18px; text-align:center; border-radius:20px;">
You have reached this page because your data has not been imported into Examity yet. <br/>
Please contact <a href="support@examity.com" style="color:#0094c5 ">support@examity.com</a> and cc <a href="developers@examity.com" style="color:#0094c5 ">developers@examity.com</a> for further assistance. </div>
                    </div>
                </asp:Panel>
            </div>
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
            <div id="supportpanels" style="float: right; width: 360px; color: white; font-size: 13px;">
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
                <div id="Emailsupport" style="float: left; width: 100px;">
                    <a href="mailto:support@examity.com" style="color: white"><u>Email Support</u></a>&nbsp;|
                </div>
                <div id="phonesupport" style="float: left; width: 180px">
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
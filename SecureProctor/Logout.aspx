﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="SecureProctor.Logout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Examity :: Login</title>
    <link rel="shortcut icon" href="../Images/secureproctor.ico" />
    <link href="./CSS/ApplicationStyleSheet.css" type="text/css" rel="Stylesheet" />
  
    <link href="./CSS/help.css" rel="stylesheet" type="text/css" />
    <link href='https://fonts.googleapis.com/css?family=Berkshire+Swash' rel='stylesheet' type='text/css' />
    <script type="text/javascript" src="Scripts/jquery.js">
        
    </script>
    <!--If you already have jquery on the page you don't need to insert this script tag-->
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js" type="text/javascript"></script>
<link href="https://cdn.desk.com/assets/widget_embed_191.css" media="screen" rel="stylesheet" type="text/css" />
<!--If you already have fancybox on the page this script tag should be omitted-->
<script src="https://desk-customers.s3.amazonaws.com/shared/widget_embed_libraries_191.js" type="text/javascript"></script>

    
</head>
<body>

    
    
    <form id="form1" runat="server">
        <%-- <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>--%>
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
                              <img src="Images/ImgClientlogo.png" alt="Client" border="0"  style="visibility:hidden;"/>
</td>
                             
                                <td style="text-align: right; color: #FFFFFF;" valign="top" align="right" colspan="2"><a href="#">
                                    <img src="Images/ImgProductLogo.png" alt="Examity" border="0" /></a></td>
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
                        <li style="display: none;"><span class="RadButton RadButton_Web20 rbSkinnedButton"
                            onclick="window.open('https://exnjit.zendesk.com/home','_blank');return false;">
                            <input class="rbDecorated" type="submit" value="HELP" /></span> </li>
                    </ul>
                </div>
            </div>
            <div class="container_inner">
                <table cellpadding="2" cellspacing="2" width="100%">

                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center">&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center">&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center">&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center" runat="server" visible="false" id="tdLogOut" class="Logout_text">



                            <asp:Label ID="lblLogout" runat="server" Text="<span class='Thankyou'></span>"></asp:Label>
                            <br />
                            <br />
                            <%--Please return to <u><a href="#" id="hLogout" runat="server" target="_blank" class="Logout_text"></a></u>and re-enter the Examity site through your final exam scheduler.--%>
                            <%--Please return to your Blackboard <u><a href="#" id="hLogout" runat="server" target="_blank" class="Logout_text"></a></u>.--%>
                            <asp:Label ID="hLogout" runat="server"  class="Logout_text"></asp:Label>
                        </td>
                        <td align="center" runat="server" visible="false" id="tdSession" class="Logout_text">
                            <asp:Label ID="lblSession" runat="server" Text="<span class='Thankyou'>Sorry, your session has expired.</span>" />
                            <br />
                            <br />
                            <%--Please return to  <a href="#" id="lnkSession" runat="server" target="_blank" class="Logout_text"></a>and re-enter the Examity site through your final exam scheduler.--%>
                            <%--Please return to your Blackboard <a href="#" id="lnkSession" runat="server" target="_blank" class="Logout_text"></a>.--%>
                            <asp:Label ID="lnkSession" runat="server"  class="Logout_text"></asp:Label>
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
                <div class="fut_left"style="width:400px;">
       Copyright &copy; 2013 - <%: DateTime.Now.Year %>  <a target="_blank" href="http://examity.com/" style="color:white;">Examity&nbsp;<sup>&reg;</sup></a>&nbsp; All Rights Reserved.
                </div>
                <div id="supportpanels" style="float: right; width: 360px; color: white; font-size: 13px;">
                    <div class="ulCss" style="float: left;">
				<script>
				    new DESK.Widget({
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
				    }).render();
                </script>
				</div>




                  <div class="livechatpannel" style="float: left; cursor: pointer">
                               <u class="ulCss">
                            </u>&nbsp;&nbsp;|
                      <%-- <u>Live Chat</u>&nbsp;&nbsp;|--%>
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
    </form>
</body>
</html>
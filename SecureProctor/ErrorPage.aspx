<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="SecureProctor.ErrorPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Examity :: SSO Error page</title>
    <link href='https://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
    <link rel="shortcut icon" href="../Images/secureproctor.ico" />
    <link href="CSS/ApplicationStyleSheet.css" type="text/css" rel="Stylesheet" />
    <link rel="shortcut icon" href="Images/secureproctor.ico" />
   
    <link href="CSS/help.css" rel="stylesheet" type="text/css" />
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
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <div class="top">
        <table cellpadding="0" cellspacing="0" width="90%" align="center">
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblError" runat="server" ForeColor="Red" Font-Size="Large" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="logo" valign="top" align="left" style="padding-left: 70px; padding-top: 15px;visibility:hidden">
                    <img src="Images/ImgClientlogo.png" alt="Client" border="0" />
                </td>
                <td valign="top" align="right" style="padding-right: 65px; padding-top: 30px;">
                    <a href="#"><img src="Images/ImgProductLogo.png" alt="Examity" border="0" /></a>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;
                </td>
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
                    <table cellpadding="2" cellspacing="2" width="100%" style="padding: 5px; font-size: 15px;">
                        <tr>
                            <td align="center">
                                <p>
                                    &nbsp;</p>
                                <img src="Images/error.png" />
                                <br />
                                <br />
                                <span style="color: #f00;"><strong>Unauthorized Access!!!</strong> </span>
                                <br />
                                <br />
                                <strong class="customfont2">Please Contact Administrator.</strong>
                                <br />
                                <p>
                                    &nbsp;</p>
                                <p>
                                    &nbsp;</p>
                                <p>
                                    &nbsp;</p>
                            </td>
                        </tr>
                    </table>
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

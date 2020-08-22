<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="SecureProctor.AdminLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Examity :: Login</title>
    <link rel="shortcut icon" href="Images/secureproctor.ico" />
    <link href="./CSS/ApplicationStyleSheet.css" type="text/css" rel="Stylesheet" />
    
    <link href="./CSS/help.css" rel="stylesheet" type="text/css" />
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
        <telerik:radscriptmanager id="RadScriptManager1" runat="server">
        </telerik:radscriptmanager>
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
                                <td valign="midlle" align="left" colspan="2">
                                    <img src="Images/ImgClientLogo.png" alt="Client" border="0" />
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
                </div>
            </div>
            <div class="container_inner">
                <table cellpadding="2" cellspacing="2" width="100%">
                    <tr>
                        <td width="70%">
                            <div class="login_new">
                                <fieldset>
                                    <legend>
                                        <img src="Images/ImgLogin.png" title="Login" /></legend>
                                    <asp:Panel ID="pnlLogin" runat="server" DefaultButton="btnLogin">
                                        <table cellpadding="2" cellspacing="2" width="100%" style="padding: 5px; font-size: 15px;">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblInvalid" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblUserName" runat="server" Text="User ID"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <telerik:radtextbox id="txtUserName" runat="server" cssclass="td_input" width="250"
                                                        skin="Web20" title="Please enter the valid user ID" tabindex="1" autocompletetype="None">
                                                    </telerik:radtextbox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter valid User ID."
                                                        ControlToValidate="txtUserName" ForeColor="Red" Font-Bold="true" Font-Size="X-Small"
                                                        Display="Dynamic" ValidationGroup="Add"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <telerik:RadTextBox ID="txtPassword" runat="server" CssClass="td_input" TextMode="Password"
                                                        Width="250" Skin="Web20" title="Please enter the valid Password" TabIndex="2">
                                                    </telerik:RadTextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter your password."
                                                        ControlToValidate="txtPassword" ForeColor="Red" Font-Bold="true" Font-Size="X-Small"
                                                        Display="Dynamic" ValidationGroup="Add">                                               
                                                    </asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <telerik:RadButton ID="btnLogin" runat="server" Text="LOG IN" Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin %>"
                                                        OnClick="btnLogin_Click" ValidationGroup="Add" TabIndex="3">
                                                    </telerik:RadButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </fieldset>
                            </div>
                        </td>
                        <td width="43%" rowspan="3" valign="top" class="help_text_i">
                            <div class="help_text_i_inner">
                                <p>
                                    <strong>Examity<sup>® </sup></strong>is the leading remote proctoring service worldwide. Our
                                end-to-end solution includes authentication, live monitoring, recording and auditing.
                                <br />
                                    <br />
                                    Test-takers enjoy a seamless experience anytime, anywhere with lots of flexibility.
                                </p>
                                <p>
                                    &nbsp;
                                </p>
                                <p>
                                    &nbsp;
                                </p>
                                <p>
                                    &nbsp;
                                </p>
                                <p>
                                    &nbsp;
                                </p>
                                <p>
                                    &nbsp;
                                </p>
                                <p>
                                    &nbsp;
                                </p>
                                <p>
                                    &nbsp;
                                </p>
                                <p>
                                    &nbsp;
                                </p>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td width="60%">
                            <div class="forgot">
                                <fieldset>
                                    <legend>
                                        <img src="Images/ImgFotGotPwd.png" alt="Forgot Password" title="Forgot Password" /></legend>
                                    <table cellpadding="2" cellspacing="2" width="100%" style="padding: 5px; font-size: 15px;">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblEmailAddressSuccess" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text="Enter Your User ID"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <telerik:RadTextBox ID="txtEmailID" runat="server" CssClass="td_input" Width="250"
                                                    Skin="Web20" title="Please enter valid user id to get the password." TabIndex="4">
                                                </telerik:RadTextBox>
                                                <asp:Label ID="lblInvalidEmailAddress" runat="server" Font-Bold="true" Font-Size="X-Small"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <telerik:RadButton ID="btnForgotPwd" runat="server" OnClick="btnForGotPassword_Click" TabIndex="5"
                                                    Text="GET PASSWORD" Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin %>" CausesValidation="false">
                                                </telerik:RadButton>
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
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
                    <div id="Emailsupport" style="float: left;">
                        &nbsp;&nbsp;<a href="mailto:support@examity.com" style="color: white"><u><asp:Label ID="Label2" Text="Email Support" runat="server" TabIndex="7"></asp:Label></u></a>&nbsp;&nbsp;|&nbsp;&nbsp;
                    </div>
                    <div id="phonesupport" style="float: left;">
                        <asp:Label ID="Label3" Text="Phone Support: 855-EXAMITY" runat="server" TabIndex="8"></asp:Label>
                    </div>
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
    </form>
</body>
</html>

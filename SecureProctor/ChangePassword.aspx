<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="SecureProctor.ChangePassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="CSS/ApplicationStyleSheet.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Scripts/Common.js"></script>
    <link rel="shortcut icon" href="Images/secureproctor.ico" />
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
        <%-- <script type="text/javascript">
            function WrongPwdAlert() {
                var password = $('#txtNewPassword').val();
                var result = PageMethods.PasswordExists(password, onSuccess);
            }

            function onSuccess(result) {
                if (result == 1) {
                    alert("Password already exists")
                    $('#txtNewPassword').focus();
                    return false;
                }
                else {
                    return true;
                }
            }

        </script>--%>
        <div class="top">
            <table cellpadding="0" cellspacing="0" width="100%" align="center">
                <tr>
                    <td width="5%">&nbsp;</td>
                    <td valign="top" class="welcome_text_block" width="90%">
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td class="logo" valign="top" width="300" height="28">&nbsp;</td>
                                <td width="451" style="text-align: left; color: #FFFFFF;" valign="top" align="left">&nbsp;</td>
                                <td width="3" style="text-align: left; color: #FFFFFF;" align="left">&nbsp;</td>
                                <td width="431" style="text-align: right; color: #FFFFFF;" valign="top" align="right">&nbsp;</td>
                            </tr>
                            <tr>
                                <td valign="midlle" colspan="2" align="left">
                                    <img src="Images/ImgClientlogo.png" alt="Client" border="0" />
                                </td>
                                <td style="text-align: right; color: #FFFFFF;" valign="top" align="right" colspan="2"><a href="#">
                                    <img src="Images/ImgProductLogo.png" alt="Examity" border="0" /></a></td>
                            </tr>
                        </table>
                    </td>
                    <td width="5%">&nbsp;</td>
                </tr>
            </table>

        </div>
        <!-- content start -->
        <div id="application_container">
            <div class="container">
                <%--<div class="main_menu">
<ul><li><a href="AdminLogin.aspx" class="main_menu_active">DASHBOARD</a></li>
                </ul>
            </div>--%>


                <table cellpadding="2" cellspacing="2" width="100%">
                    <tr>
                        <td>
                            <img src="Images/ChangePassword.png" alt="student registration" />
                        </td>
                        <td width="1%" rowspan="4"></td>
                        <%--<td>&nbsp;</td>--%>
                    </tr>


                    <tr>

                        <td width="100%" valign="top">
                            <div class="login_new1">
                                <table width="100%" cellpadding="2" cellspacing="2">
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="lblMessage" runat="server" CssClass="customfont1"></asp:Label><br />
                                            <br />

                                            <telerik:RadButton ID="imgOK" runat="server" Text="OK" Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin %>" Visible="false"
                                                OnClick="imgOK_Click">
                                            </telerik:RadButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table width="80%" id="tblContent" runat="server" align="center">

                                                <tr>
                                                    <td align="right" colspan="2" style="padding-right: 0px;">
                                                        <asp:Label ID="lblmandate" runat="server" Text="<%$ Resources:ResMessages,Reg_Mandatoryfields %>" ForeColor="Red"></asp:Label>

                                                    </td>
                                                </tr>
                                                <%--<tr>
<td align="right" colspan="2">
<asp:Label ID="lblMessage" runat="server"></asp:Label>

</td>

</tr>--%>
                                                <tr>
                                                    <td colspan="2">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="left" width="40%">
                                                        <asp:Label ID="lblCurrentPassword" runat="server" Text="Current Password" CssClass="customfont2_report"></asp:Label>
                                                    </td>
                                                    <td>: &nbsp;&nbsp;<telerik:RadTextBox ID="txtCurrentPassword" runat="server" TextMode="Password" CssClass="td_input"></telerik:RadTextBox>
                                                        <%--   <asp:Label   runat="server" Text="*" ForeColor="Red"></asp:Label>--%>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Save" runat="server" ErrorMessage="<%$ Resources:ResMessages,MyProfile_CurrPassword %>" ControlToValidate="txtCurrentPassword" ForeColor="Red" Font-Bold="true" Display="Dynamic">
                                                        </asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lblNewPassword" runat="server" Text="New Password" CssClass="customfont2_report"></asp:Label>
                                                    </td>
                                                    <td>: &nbsp;&nbsp;<telerik:RadTextBox ID="txtNewPassword" runat="server" TextMode="Password" CssClass="td_input">
                                                        <%--<ClientEvents OnBlur="WrongPwdAlert" />--%>
                                                    </telerik:RadTextBox>
                                                        <%--        <asp:Label  runat="server" Text="*" ForeColor="Red"></asp:Label>--%>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Save" runat="server" ErrorMessage="<%$ Resources:ResMessages,MyProfile_NewPassword %>" ControlToValidate="txtNewPassword" ForeColor="Red" Font-Bold="true" Display="Dynamic">
                                                        </asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator runat="server" ID="rexNumber" ControlToValidate="txtNewPassword" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9'@&#$,*;:!~%^()_+<>.\s]{8,20}$" ForeColor="Red" Font-Bold="true"
                                                            ValidationGroup="Save" ErrorMessage="Password must be at least 8 characters and not exceed 20 characters" />
                                                    </td>
                                                    </tr>
                                                    <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lblConfirmNewPassword" runat="server" Text="Confirm New Password" CssClass="customfont2_report"></asp:Label>
                                                    </td>
                                                    <td>: &nbsp;&nbsp;<telerik:RadTextBox ID="txtConfirmNewPassword" runat="server" TextMode="Password" CssClass="td_input"></telerik:RadTextBox>
                                                        <%-- <asp:Label ID="Label2"   runat="server" Text="*" ForeColor="Red"></asp:Label>--%>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="<%$ Resources:ResMessages,MyProfile_ConfirmNewPassword %>" ControlToValidate="txtConfirmNewPassword" ForeColor="Red" Font-Bold="true" Display="Dynamic" ValidationGroup="Save">
                                                        </asp:RequiredFieldValidator>
                                                        <asp:CompareValidator ID="compval" ControlToValidate="txtConfirmNewPassword" ControlToCompare="txtNewPassword" ForeColor="red" Type="String" EnableClientScript="true" Text="<%$ Resources:ResMessages,Myprofile_PasswordMatch %>" runat="server" Display="Dynamic" Font-Bold="true" ValidationGroup="Save" />
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td colspan="2">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td align="left">
                                                        <%-- <asp:ImageButton ID="btnSave" runat="server"  OnClick="btnSave_Click" ImageUrl="~/Images/save.png"/>  --%>
                                                        <%--<asp:ImageButton ID="btnReset" runat="server"  ImageUrl="~/Images/reset.png" OnClick="btnReset_Click" CausesValidation="false"/>--%>
   &nbsp; &nbsp;&nbsp;
                                                        <telerik:RadButton ID="btnSave" runat="server" Text="Save" Skin="Glow" OnClick="btnSave_Click" ValidationGroup="Save">
                                                        </telerik:RadButton>
                                                    </td>
                                                </tr>

                                                <%--  <tr>
    <td>
    
   please Click here to <a href="Login.aspx" style="text-decoration:underline">Login</a>
    
    </td>

    
    
    
    </tr>--%>
                                                <tr>
                                                    <td colspan="2">
                                                        <p>&nbsp;</p>
                                                        <p>&nbsp;</p>
                                                        <p>&nbsp;</p>
                                                        <br />
                                                    </td>
                                                </tr>

                                            </table>
                                        </td>
                                    </tr>
                                </table>

                            </div>
                        </td>
                        <%--<td width="25%" rowspan="2" valign="top" class="help_text_i">
<div class="help_text_i_inner">
  <p><strong>EDUCATION</strong><br />
      <br />
    The next generation delivery of proctoring solutions will have a huge impact in Education provider space to enable them being competitive<br />
    Education industry regulations are a key factor in enabling the	Remote Proctoring solution.</p>
  <p>&nbsp;</p>
  <p>&nbsp;</p>
  <p><strong>CERTIFICATION</strong></p>
  <p>Numerous certification programs are working at enabling the remote test process to match student needs for convenience and flexibility.</p>
  <p>
    Secure Proctor has executed education solutions for more than 15 years and has been recognized by industry as a pioneer. </p>
  <p>We have brought the same expertise to build the Secure Proctor solution.</p>
</div>
</td>--%>
                    </tr>
                </table>
            </div>

        </div>
        <!-- content end -->
        <div id="footer">
            <div class="footer_inner">
                <div class="fut_left" style="width: 400px;">
                    Copyright &copy; 2013 - <%: DateTime.Now.Year %>  <a target="_blank" href="http://examity.com/" style="color: white;">Examity&nbsp;<sup>&reg;</sup></a>&nbsp; All Rights Reserved.
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
                        Phone Support:
                    
                    855-EXAMITY
                    </div>

                </div>

                <div class="clear">
                </div>
            </div>
        </div>
    </form>
</body>
</html>

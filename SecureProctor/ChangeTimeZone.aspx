<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeTimeZone.aspx.cs" Inherits="SecureProctor.ChangeTimeZone" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Examity :: Change Time zone</title>
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
                                <td valign="midlle" colspan="2" align="left">&nbsp;</td>
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
            <div class="container" style="padding:10px 0px;">
                <img src="Images/ChangeTimeZone.png" />
            </div>

             <div class="container_inner">
                 <div class="login_new" style="margin:30px auto;"> 
                       <p>&nbsp;</p>  <p>&nbsp;</p>  <p>&nbsp;</p>
                     <%--<table id="tblMsg" runat="server">
                          <tr>
                             <td>
<asp:Label ID="lblMsg" runat="server" CssClass="customfont1"></asp:Label>

                             </td>
                              <td>
                                <telerik:RadButton ID="imgOK" runat="server" Text="OK" Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin %>" Visible="false"
                                                    OnClick="imgOK_Click">
                                                </telerik:RadButton>

                              </td>
                         </tr>

                     </table>--%>
                     <table id="trTimeZone" runat="server">
                       
                         <tr>
                             <td width="30%" align="right">
<asp:Label ID="lblTimeZone" runat="server" Text="Time Zone" CssClass="customfont2_report"></asp:Label>

                             </td>
<td align="left" width="25%">

     <telerik:RadComboBox ID="ddlTimeZone" runat="server" Width="320" AppendDataBoundItems="true" OnItemDataBound="ddlTimeZone_ItemDataBound" Height="250" DropDownAutoWidth="Enabled" Filter="Contains" MarkFirstMatch="true"
                                                        Skin="<%$ Resources:SecureProctor,Telerik_ComboBox_Skin %>">
                                                        <Items>
                                                            <telerik:RadComboBoxItem Value="-1" />
                                                        </Items>
                                                    </telerik:RadComboBox>
                                                   
                                                            </td>
                               <td colspan="2" align="left" width="40%">
                                            <telerik:RadButton ID="btnSubmit" runat="server" Text="SUBMIT" Skin="Web20" Width="80"
                                                OnClick="btnSaveTimeZone_Click" ValidationGroup="submit">
                                            </telerik:RadButton>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator15" InitialValue="--Select Time Zone--"
                                                        Display="Dynamic" ControlToValidate="ddlTimeZone" ValidationGroup="submit" ErrorMessage="Please select Time Zone" />

                                        </td>

                         </tr>


                     </table>

                      <p>&nbsp;</p>  <p>&nbsp;</p>  <p>&nbsp;</p>


                     </div>
            </div>

             
         </div>

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

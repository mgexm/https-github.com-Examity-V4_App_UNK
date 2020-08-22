<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Detect.aspx.cs" Inherits="SecureProctor.Detect" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Examity :: Login</title>
    <link rel="shortcut icon" href="Images/secureproctor.ico" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-top: 180px">
            <table cellpadding="10" cellspacing="0" align="center" style="border: solid 2px #2a8fdd">

                <tr>
                    <td>
                        <table style="width: 100%;">
                            <tr>
                                <td style="text-align: center; font-size: 18px; margin-bottom: 5px; padding-top: 5px; font-weight: 700;">Unsupported browser detected.
                                </td>
                            </tr>

                            <tr>
                                <td align="center">
                                    <img src="Images/alert.png" border="0" width="150px">
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <table style="width: 100%; margin: 0px auto;" cellpadding="3">
                            <tr>
                                <td>
                                    <div style="padding-top: 4px; font-size: 20px;"><b>.</b></div>
                                </td>
                                <td style="text-align: left; font-size: 18px; margin-bottom: 5px; padding-top: 5px;">Install latest browser version.</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <div style="padding-left:14px;padding-bottom:8px;">
                                        For Chrome browser
                                        <img style="vertical-align: middle;" src="Images/chrome.png" width="25px"> <a style="color: #ff6a00;text-decoration:none;" href="https://www.google.com/intl/en/chrome/browser/#eula" target="_blank">Click here</a>
                                    </div>                                    
                                    <div style="padding-left:14px;padding-bottom:8px;">
                                        For Firefox browser&nbsp;
                                        <img style="vertical-align: middle" src="Images/firefox.png" width="25px">
                                        <a style="color: #ff6a00;text-decoration:none;" href="https://www.mozilla.org/en-US/firefox/new/" target="_blank">Click here</a>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div style="padding-top: 4px; font-size: 20px;"><b>.</b></div>
                                </td>
                                <td style="text-align: left; font-size: 18px; margin-bottom: 5px; padding-top: 5px;">Open Chrome or Firefox and log back into your LMS to access Examity.</td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

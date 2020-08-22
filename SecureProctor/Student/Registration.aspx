<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="SecureProctor.Student.Registration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <script type="text/javascript" src="https://assets.zendesk.com/external/zenbox/v2.6/zenbox.js"></script>
<link href="../CSS/help.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <style type="text/css" media="screen, projection">
  @import url(//assets.zendesk.com/external/zenbox/v2.6/zenbox.css);
</style>
<script type="text/javascript">
    if (typeof (Zenbox) !== "undefined") {
        Zenbox.init({
            dropboxID: "20201008",
            url: "https://exnjit.zendesk.com",
            tabTooltip: "Help",
            tabImageURL: "https://assets.zendesk.com/external/zenbox/images/tab_help.png",
            tabColor: "black",
            tabPosition: "Left"
        });
    }
</script>
    <title>Examity</title>
    <link href="../CSS/ApplicationStyleSheet.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="../Images/secureproctor.ico" />
    <script language="JavaScript" type="text/javascript">
        // Declaring required variables
        var digits = "0123456789";
        // non-digit characters which are allowed in phone numbers
        var phoneNumberDelimiters = "()- ";
        // characters which are allowed in international phone numbers
        // (a leading + is OK)
        var validWorldPhoneChars = phoneNumberDelimiters + "+";
        // Minimum no of digits in an international phone no. 
        var minDigitsInIPhoneNumber = 10;
        // Maximum no of digits in an america phone no.
        var maxDigitsInIPhoneNumber = 13;
        var AreaCode = new Array(205, 251, 659, 256, 334, 907, 403, 780, 264, 268, 520, 928, 480, 602, 623, 501, 479, 870, 242, 246, 441, 250, 604, 778, 284, 341, 442, 628, 657, 669, 747, 752, 764, 951, 209, 559, 408, 831, 510, 213, 310, 424, 323, 562, 707, 369, 627, 530, 714, 949, 626, 909, 916, 760, 619, 858, 935, 818, 415, 925, 661, 805, 650, 600, 809, 345, 670, 211, 720, 970, 303, 719, 203, 475, 860, 959, 302, 411, 202, 767, 911, 239, 386, 689, 754, 941, 954, 561, 407, 727, 352, 904, 850, 786, 863, 305, 321, 813, 470, 478, 770, 678, 404, 706, 912, 229, 710, 473, 671, 808, 208, 312, 773, 630, 847, 708, 815, 224, 331, 464, 872, 217, 618, 309, 260, 317, 219, 765, 812, 563, 641, 515, 319, 712, 876, 620, 785, 913, 316, 270, 859, 606, 502, 225, 337, 985, 504, 318, 318, 204, 227, 240, 443, 667, 410, 301, 339, 351, 774, 781, 857, 978, 508, 617, 413, 231, 269, 989, 734, 517, 313, 810, 248, 278, 586, 679, 947, 906, 616, 320, 612, 763, 952, 218, 507, 651, 228, 601, 557, 573, 636, 660, 975, 314, 816, 417, 664, 406, 402, 308, 775, 702, 506, 603, 551, 848, 862, 732, 908, 201, 973, 609, 856, 505, 575, 585, 845, 917, 516, 212, 646, 315, 518, 347, 718, 607, 914, 631, 716, 709, 252, 336, 828, 910, 980, 984, 919, 704, 701, 283, 380, 567, 216, 614, 937, 330, 234, 440, 419, 740, 513, 580, 918, 405, 905, 289, 647, 705, 807, 613, 519, 416, 503, 541, 971, 445, 610, 835, 878, 484, 717, 570, 412, 215, 267, 814, 724, 902, 787, 939, 438, 450, 819, 418, 514, 401, 306, 803, 843, 864, 605, 869, 758, 784, 731, 865, 931, 423, 615, 901, 325, 361, 430, 432, 469, 682, 737, 979, 214, 972, 254, 940, 713, 281, 832, 956, 817, 806, 903, 210, 830, 409, 936, 512, 915, 868, 649, 340, 385, 435, 801, 802, 276, 434, 540, 571, 757, 703, 804, 509, 206, 425, 253, 360, 564, 304, 262, 920, 414, 715, 608, 307, 867)

        function isInteger(s) {
            var i;
            for (i = 0; i < s.length; i++) {
                // Check that current character is number.
                var c = s.charAt(i);
                if (((c < "0") || (c > "9"))) return false;
            }
            // All characters are numbers.
            return true;
        }

        function stripCharsInBag(s, bag) {
            var i;
            var returnString = "";
            // Search through string's characters one by one.
            // If character is not in bag, append to returnString.
            for (i = 0; i < s.length; i++) {
                // Check that current character isn't whitespace.
                var c = s.charAt(i);
                if (bag.indexOf(c) == -1) returnString += c;
            }
            return returnString;
        }
        function trim(s) {
            var i;
            var returnString = "";
            // Search through string's characters one by one.
            // If character is not a whitespace, append to returnString.
            for (i = 0; i < s.length; i++) {
                // Check that current character isn't whitespace.
                var c = s.charAt(i);
                if (c != " ") returnString += c;
            }
            return returnString;
        }
        function checkInternationalPhone(strPhone) {
            strPhone = trim(strPhone)
            if (strPhone.indexOf("00") == 0) strPhone = strPhone.substring(2)
            if (strPhone.indexOf("+") > 1) return false
            if (strPhone.indexOf("+") == 0) strPhone = strPhone.substring(1)
            if (strPhone.indexOf("(") == -1 && strPhone.indexOf(")") != -1) return false
            if (strPhone.indexOf("(") != -1 && strPhone.indexOf(")") == -1) return false
            s = stripCharsInBag(strPhone, validWorldPhoneChars);
            if (strPhone.length > 10) { var CCode = s.substring(0, s.length - 10); }
            else { CCode = ""; }
            if (strPhone.length > 7) { var NPA = s.substring(s.length - 10, s.length - 7); }
            else { NPA = "" }
            var NEC = s.substring(s.length - 7, s.length - 4)
            if (CCode != "" && CCode != null) {
                if (CCode != "1" && CCode != "011" && CCode != "001") return false
            }
            if (NPA != "") {
                if (checkAreaCode(NPA) == false) {
                    return false
                }
            }
            else { return false }
            return (isInteger(s) && s.length >= minDigitsInIPhoneNumber && s.length <= maxDigitsInIPhoneNumber);
        }
        //Checking area code is vaid or not
        function checkAreaCode(val) {
            var res = false;
            for (var i = 0; i < AreaCode.length; i++) {
                if (AreaCode[i] == val) res = true;
            }
            return res
        }
        function ValidatePrefForm() {
            var Phone = document.getElementById("txtPrefferedPhoneNumber");
            if ((Phone.value == null) || (Phone.value == "")) {
                alert("Please Enter Your Phone Number")
                Phone.focus()
                return false
            }
            if (checkInternationalPhone(Phone.value) == false) {
                alert("Please Enter a Valid US Phone Number")
                Phone.value = ""
                Phone.focus()
                return false
            }
            //	else {
            //		alert("The Phone Number is a Valid US Phone Number")
            //		Phone.value=""
            //		Phone.focus()
            //		return false
            //		}
            return true
        }

        function ValidateForm() {
            var Phone = document.getElementById("txtPhoneNumber");
            if ((Phone.value == null) || (Phone.value == "")) {
                alert("Please Enter Your Phone Number")
                Phone.focus()
                return false
            }
            if (checkInternationalPhone(Phone.value) == false) {
                alert("Please Enter a Valid US Phone Number")
                Phone.value = ""
                Phone.focus()
                return false
            }
            //	else {
            //		alert("The Phone Number is a Valid US Phone Number")
            //		Phone.value=""
            //		Phone.focus()
            //		return false
            //		}
            return true
        }

    </script>
    
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <div>
        <div class="top">
            <table cellpadding="0" cellspacing="0" width="80%" align="center">
                <tr>
                    <td class="logo" valign="middle" align="left">
                                    <img src="../Images/ImgClientlogo.png" alt="Client" border="0" />
                    </td>
                    <td valign="top">
                        <table cellpadding="2" cellspacing="2" width="100%">
                            <tr>
                                <td style="text-align: left; color: #FFFFFF;">
                                </td>
                            </tr>
                            <tr>
                                <td valign="middle" align="right" style="padding-top: 10px;">
                                    <a href="#">
                                        <img src="../Images/ImgProductLogo.png" alt="Examity" border="0" /></a>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
      
        <!-- content start -->
        <div id="application_container_home">
            <div class="container">
                <div class="main_menu">
                    <ul style="padding: 10px;">
                        <li>
                            <%--<telerik:RadButton ID="btnHome" runat="server" Text="HOME" Skin="Windows7" CausesValidation="false" OnClick="../login.aspx">
                    </telerik:RadButton>--%>
                            <a href="../AdminLogin.aspx" class="main_menu_active">HOME</a> </li>
                    </ul>
                </div>
                <div class="container_inner">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td>
                                <img src="../Images/ImgStudentRegistration.png" alt="student registration" />
                            </td>
                            <td width="1%" rowspan="4">
                            </td>
                           <%-- <td>
                                <img src="../Images/ImgHelp.png" alt="Help" />
                            </td>--%>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="70%">
                                <div class="login_new">
                                    <table cellpadding="3" cellspacing="4" width="100%">
                                        <tr>
                                            <td align="right" colspan="3">
                                                <asp:Label ID="Label3" runat="server" Text="<%$ Resources:ResMessages,Reg_Mandatoryfields %>"
                                                    Font-Size="Small" ForeColor="Red"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="200">
                                                <asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label>
                                            </td>
                                            <td width="5">
                                                :
                                            </td>
                                            <td width="700">
                                                <telerik:RadTextBox ID="txtFirstName" runat="server" CssClass="td_input" MaxLength="100" AutoCompleteType="None">
                                                </telerik:RadTextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="<%$ Resources:ResMessages,Reg_FirstName %>"
                                                    ControlToValidate="txtFirstName" ForeColor="Red">
                                                </asp:RequiredFieldValidator>
                                               <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="only characters allowed" ControlToValidate="txtFirstName" ValidationExpression="^[a-z]*$"></asp:RegularExpressionValidator>--%>
                                                <%-- <telerik:RadMaskedTextBox ID="FilteredTextBoxExtender1"
                                                runat="server"  FilterType="Custom" TargetControlID="txtFirstName" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ">
                                            </telerik:RadMaskedTextBox>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label>
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="txtLastName" runat="server" CssClass="td_input" MaxLength="100" AutoCompleteType="None">
                                                </telerik:RadTextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="<%$ Resources:ResMessages,Reg_LastName %>"
                                                    ControlToValidate="txtLastName" ForeColor="Red">
                                                </asp:RequiredFieldValidator>
                                                <%-- <telerik:RadAjaxManager ID="FilteredTextBoxExtender2"
                                                runat="server" FilterType="Custom" TargetControlID="txtLastName" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ">
                                            </telerik:RadAjaxManager>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblUserName" runat="server" Text="User Name"></asp:Label>
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="txtUserName" runat="server" CssClass="td_input" MaxLength="100" AutoCompleteType="None">
                                                </telerik:RadTextBox>
                                                (ex: username@company.com)
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="<%$ Resources:ResMessages,Reg_UserName %>"
                                                    ControlToValidate="txtUserName" ForeColor="Red" Display="Dynamic">
                                                </asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic"
                                                    ForeColor="Red" runat="server" ControlToValidate="txtUserName" ErrorMessage="<%$ Resources:ResMessages,Reg_ValidUserName %>"
                                                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                                </asp:RegularExpressionValidator>
                                                <%-- <telerik:RadAjaxManager ID="FilteredTextBoxExtender7"
                                                runat="server" FilterType="Custom" TargetControlID="txtUserName" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890@_.">
                                            </telerik:RadAjaxManager>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblGender" runat="server" Text="Gender"></asp:Label>
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <%-- <asp:DropDownList ID="ddlGender" runat="server" AppendDataBoundItems="True">
                                                <asp:ListItem Value="-1">Select</asp:ListItem>
                                            </asp:DropDownList>--%>
                                                <telerik:RadComboBox ID="ddlGender" runat="server" AppendDataBoundItems="true" AutoCompleteType="None"  Skin="<%$ Resources:SecureProctor,Telerik_ComboBox_Skin %>"> 
                                                </telerik:RadComboBox>
                                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please select Gender"
                                                ControlToValidate="ddlGender" InitialValue="-1" ForeColor="Red"></asp:RequiredFieldValidator--%>
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator18" InitialValue="Select"
                                                    Display="Dynamic" ControlToValidate="ddlGender" ForeColor="Red" ErrorMessage="<%$ Resources:ResMessages,Reg_GenderSel %>" />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>
                                                <asp:Label ID="lblPhotoIdentification" runat="server" Text="Photo Identification"></asp:Label>
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <asp:FileUpload ID="IdentificationFileUpload" runat="server" /> 
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="<%$ Resources:ResMessages,Reg_Uploadfile %>"
                                                    ControlToValidate="IdentificationFileUpload" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>
                                                <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="td_input" AutoCompleteType="None">
                                                </telerik:RadTextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="<%$ Resources:ResMessages,Reg_PasswordEnter %>"
                                                    ControlToValidate="txtPassword" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password "></asp:Label>
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="td_input" AutoCompleteType="None">
                                                </telerik:RadTextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="<%$ Resources:ResMessages,Reg_ConfirmPassword %>"
                                                    ControlToValidate="txtConfirmPassword" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                                <asp:CompareValidator ID="compval" ControlToValidate="txtConfirmPassword" ControlToCompare="txtPassword"
                                                    ForeColor="red" Type="String" EnableClientScript="true" Text="<%$ Resources:ResMessages,Reg_PasswordMatch %>"
                                                    runat="server" Display="Dynamic" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number"></asp:Label>
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <telerik:RadMaskedTextBox ID="txtPhoneNumber" runat="server" Mask="###-###-####">
                                                </telerik:RadMaskedTextBox>&nbsp;(ex:202-000-0000)
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="<%$ Resources:ResMessages,Reg_EnterPhone %>"
                                                    ControlToValidate="txtPhoneNumber" ForeColor="Red" Display="Dynamic" />
                                                <asp:RegularExpressionValidator ID="phn" runat="server" ControlToValidate="txtPhoneNumber"
                                                    ErrorMessage="Please enter valid Phone Number" Display="Dynamic" ForeColor="Red"
                                                    ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblPrefferedPhoneNumber" runat="server" Text="Preferred Phone number"></asp:Label>
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <telerik:RadMaskedTextBox ID="txtPrefferedPhoneNumber" runat="server" Mask="###-###-####">
                                                </telerik:RadMaskedTextBox>&nbsp;(ex:202-000-0000)
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="<%$ Resources:ResMessages,Reg_EnterPrefPhone %>"
                                                    ControlToValidate="txtPrefferedPhoneNumber" ForeColor="Red" Display="Dynamic" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPrefferedPhoneNumber"
                                                    ErrorMessage="Please enter valid Preffered Phone Number" Display="Dynamic" ForeColor="Red"
                                                    ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text="Time Zone"></asp:Label>
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <%--<asp:DropDownList ID="ddlTimeZone" runat="server" AppendDataBoundItems="True">
                                                <asp:ListItem Value="-1">Select</asp:ListItem>
                                            </asp:DropDownList>--%>
                                                <telerik:RadComboBox ID="ddlTimeZone" runat="server" AppendDataBoundItems="true" Width="200"
                                                    Skin="<%$ Resources:SecureProctor,Telerik_ComboBox_Skin %>">
                                                </telerik:RadComboBox>
                                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="Please select Time Zone"
                                                ControlToValidate="ddlTimeZone" InitialValue="-1" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator17" InitialValue="Select"
                                                    Display="Dynamic" ControlToValidate="ddlTimeZone" ErrorMessage="<%$ Resources:ResMessages,Reg_TimeZoneSel %>" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <asp:UpdatePanel ID="up1" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <table cellpadding="2" cellspacing="4" width="100%">
                                                            <tr>
                                                                <td width="220">
                                                                    <asp:Label ID="lblSecurityQuestion1" runat="server" Text="Security Question #1"></asp:Label>
                                                                </td>
                                                                <td width="5">
                                                                    :
                                                                </td>
                                                                <td width="700">

                                                                    <telerik:RadComboBox ID="ddlSecurityQuestion1" runat="server" AppendDataBoundItems="true"
                                                                        AutoPostBack="true" OnSelectedIndexChanged="ddlSecurityQuestion1_IndexChanged"
                                                                        Width="270" Skin="<%$ Resources:SecureProctor,Telerik_ComboBox_Skin %>" CausesValidation="false">
                                                                    </telerik:RadComboBox>
                                                                          <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" InitialValue="-- Select Security question --"
                                                                        Display="Dynamic" ControlToValidate="ddlSecurityQuestion1"  ErrorMessage="<%$ Resources:ResMessages,Reg_SecQuestionEnter %>" />

                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblAnswer1" runat="server" Text="Answer"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <telerik:RadTextBox ID="txtAnswer1" runat="server" CssClass="td_input" MaxLength="100" Width="270" AutoCompleteType="None">
                                                                    </telerik:RadTextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="<%$ Resources:ResMessages,Reg_SecAnswerEnter %>"
                                                                        ControlToValidate="txtAnswer1" ForeColor="Red">
                                                                    </asp:RequiredFieldValidator><%--<ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender4"
                                                runat="server" FilterType="Custom" TargetControlID="txtAnswer1" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890~!@#$%^&*()_+=`-'" >
                                            </ajax:FilteredTextBoxExtender>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblSecurityQuestion2" runat="server" Text="Security Question #2"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <%--<asp:DropDownList ID="ddlSecurityQuestion2" runat="server" AppendDataBoundItems="True" AutoPostBack="true"
                                                CssClass="td_input" OnSelectedIndexChanged="ddlSecurityQuestion2_IndexChanged">
                                                <asp:ListItem Value="-1">Select</asp:ListItem>
                                            </asp:DropDownList>--%>
                                                                    <telerik:RadComboBox ID="ddlSecurityQuestion2" runat="server" AppendDataBoundItems="true"
                                                                        AutoPostBack="true" OnSelectedIndexChanged="ddlSecurityQuestion2_IndexChanged"
                                                                        Width="270" Skin="<%$ Resources:SecureProctor,Telerik_ComboBox_Skin %>" CausesValidation="false">
                                                                    </telerik:RadComboBox>
                                                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please select Security Question"
                                                ControlToValidate="ddlSecurityQuestion2" InitialValue="-1" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                                    <%--<asp:Label ID="lblQuestion2" runat="server" Font-Bold="true" ForeColor="Red" Display="Dynamic"></asp:Label>--%>
                                                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5" InitialValue="-- Select Security question --"
                                                                        Display="Dynamic" ControlToValidate="ddlSecurityQuestion2" ErrorMessage="<%$ Resources:ResMessages,Reg_SecQuestionEnter %>" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblAnswer2" runat="server" Text="Answer"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <telerik:RadTextBox ID="txtAnswer2" runat="server" CssClass="td_input" MaxLength="100" Width="270" AutoCompleteType="None">
                                                                    </telerik:RadTextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="<%$ Resources:ResMessages,Reg_SecAnswerEnter %>"
                                                                        ControlToValidate="txtAnswer2" ForeColor="Red">
                                                                    </asp:RequiredFieldValidator><%--<ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender5"
                                                runat="server" FilterType="Custom" TargetControlID="txtAnswer2" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890~!@#$%^&*()_+=`-'">
                                            </ajax:FilteredTextBoxExtender>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblSecurityQuestion3" runat="server" Text="Security Question #3"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <%--<asp:DropDownList ID="ddlSecurityQuestion3" runat="server" AppendDataBoundItems="True"
                                                CssClass="td_input" OnSelectedIndexChanged="ddlSecurityQuestion3_IndexChanged">
                                                <asp:ListItem Value="-1">Select</asp:ListItem>
                                            </asp:DropDownList>--%>
                                                                    <telerik:RadComboBox ID="ddlSecurityQuestion3" runat="server" AppendDataBoundItems="true"
                                                                        AutoPostBack="true" OnSelectedIndexChanged="ddlSecurityQuestion3_IndexChanged"
                                                                        Width="270" Skin="<%$ Resources:SecureProctor,Telerik_ComboBox_Skin %>" CausesValidation="false">
                                                                    </telerik:RadComboBox>
                                                                    <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Please select Security Question"
                                                ControlToValidate="ddlSecurityQuestion3" InitialValue="-1" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                                    <%--<asp:Label ID="lblQuestion3" runat="server" Font-Bold="true" ForeColor="Red" Display="Dynamic"></asp:Label>--%>
                                                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator6" InitialValue="-- Select Security question --"
                                                                        Display="Dynamic" ControlToValidate="ddlSecurityQuestion3" ErrorMessage="<%$ Resources:ResMessages,Reg_SecQuestionEnter %>" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblAnswer3" runat="server" Text="Answer"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <telerik:RadTextBox ID="txtAnswer3" runat="server" CssClass="td_input" MaxLength="100" Width="270" AutoCompleteType="None">
                                                                    </telerik:RadTextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="<%$ Resources:ResMessages,Reg_SecAnswerEnter %>"
                                                                        ControlToValidate="txtAnswer3" ForeColor="Red" >
                                                                    </asp:RequiredFieldValidator><%--<ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender6"
                                                runat="server" FilterType="Custom" TargetControlID="txtAnswer3" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890~!@#$%^&*()_+=`-'">
                                            </ajax:FilteredTextBoxExtender>--%>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>

                                                   </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                        <td colspan="2">
                                        &nbsp;
                                        </td>
                                            <td align="left">
                                                <%-- <asp:ImageButton ID="btnRegistration" runat="server" ImageUrl="~/Images/submit.png"
                                                OnClick="btnRegistration_Click" />--%>
                                                <telerik:RadButton ID="btnRegistration" runat="server" Text="SUBMIT" Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin %>"
                                                    OnClick="btnRegistration_Click" AutoPostBack="true">
                                                </telerik:RadButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                            <td width="29%" rowspan="2" valign="top" class="help_text_i">
                                <div class="help_text_i_inner">
                                    <p>
                                        <strong>Before Your Register :</strong>
                                        <ul>
                                            <li>You will be notified by your school once you are enrolled.</li>
                                            <li>Check with your school and ensure your enrollment is completed.</li>
                                        </ul>
                                    </p>
                                    <p>
                                        <strong>During Registration :</strong>
                                        <ul>
                                            <li>Enter all information required for Registration</li>
                                            <li>Your email address will be your user ID</li>
                                            <li>You will set your preferred secure password and security questions</li>
                                            <li>Once you register successfully, you will be notified via email by Examity</li>
                                        </ul>
                                    </p>
                                    <p>
                                        <strong>After Registration :</strong>
                                        <ul>
                                            <li>You can login to Examity using your ID (email address) and password</li>
                                            <li>You can schedule/re-schedule and/or cancel exams in the system</li>
                                            <li>You can take exams that you scheduled.</li>
                                            <li>You can check status of exams for proctoring results.</li>
                                            <li>The actual grades/exam results will be provided by your school</li>
                                        </ul>
                                    </p>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <div class="clear">
                    </div>
                </div>
            </div>
        </div>
        <!-- content end -->
        <div id="footer">
            <div class="footer_inner">
            <div class="fut_left">
                Copyright © 2013 Examity. All Rights Reserved.
            </div>
            <div id="supportpanels" style="float:right;width:360px;color:white;font-size:13px;">
                <div class="livechatpannel" style="float:left;width:70px;cursor:pointer">
                    <u>Live Chat</u>&nbsp;|
                </div>
                <div id="Emailsupport" style="float:left;width:100px;">
                    <a href="mailto:support@exnjit.zendesk.com" style="color:white"><u>Email Support</u></a>&nbsp;|
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
    </div>
    </form>
</body>
</html>

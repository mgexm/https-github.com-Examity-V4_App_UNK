<%@ Page Title="" Language="C#" MasterPageFile="~/Provider/Provider.Master" AutoEventWireup="true"
    CodeBehind="EditUserDetails.aspx.cs" Inherits="SecureProctor.Provider.EditUserDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ExamProviderContent" runat="server">
    <%--<script language="JavaScript" type="text/javascript">
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

    function ValidateForm() {
        var Phone = document.getElementById('ctl00_ExamProviderContent_txtPhoneNumber');
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

    </script>--%>
    <table cellpadding="2" width="100%">
        <tr>
            <td>
                <img src="../Images/ImgEditViewStudent.png" alt="Edit view student" />
            </td>
        </tr>
        <tr>
            <td>
                <div class="login_new1">
                    <table cellpadding="3" cellspacing="4" width="100%" border="0">
                        <tr class="gridviewAlternatestyle">
                            <td align="left" width="40%">
                                &nbsp;&nbsp;&nbsp; <strong>Student First Name</strong>&nbsp;&nbsp;&nbsp;
                            </td>
                            <td align="left" width="60%">
                                <asp:TextBox ID="lblstudentfirstname" runat="server" MaxLength="100"></asp:TextBox>
                                <asp:Label ID="lblSFirstName" runat="server" Visible="false"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="<%$Resources:ResMessages,Provider_UserFirstName%>"
                                    ControlToValidate="lblstudentfirstname" ForeColor="Red" Display="Dynamic" ValidationGroup="Edit">
                                </asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr class="gridviewRowstyle">
                            <td align="left">
                                &nbsp;&nbsp;&nbsp; <strong>Student Last Name</strong>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="lblStudentLastName" runat="server" MaxLength="100"></asp:TextBox>
                                <asp:Label ID="lblSLastName" runat="server" Visible="false"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="<%$Resources:ResMessages,Provider_UserLastName%>"
                                    ControlToValidate="lblStudentLastName" ForeColor="Red" Display="Dynamic" ValidationGroup="Edit">
                                </asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr class="gridviewAlternatestyle">
                            <td align="left">
                                &nbsp;&nbsp;&nbsp; <strong>Email Address</strong>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="lblEmailID" runat="server" Width="30%" MaxLength="100"></asp:TextBox>
                                <asp:Label ID="lblEmailAddress" runat="server" Visible="false"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="<%$Resources:ResMessages,Provider_Useremailid%>"
                                    ControlToValidate="lblEmailID" ForeColor="Red" Display="Dynamic" ValidationGroup="Edit">
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic"
                                    ForeColor="Red" runat="server" ControlToValidate="lblEmailID" ErrorMessage="<%$Resources:ResMessages,Provider_UserValidemail%>"
                                    ValidationGroup="Edit" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                </asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr class="gridviewRowstyle">
                            <td align="left">
                                &nbsp;&nbsp;&nbsp; <strong>Phone Number</strong>
                            </td>
                            <td align="left">
                                <telerik:RadMaskedTextBox ID="txtPhoneNumber" runat="server" Mask="###-###-####">
                                </telerik:RadMaskedTextBox>
                                <asp:Label ID="lblformat" runat="server" Text="(ex:202-000-0000)"></asp:Label>
                                <asp:Label ID="lblMobileNumber" runat="server" Visible="false"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="<%$Resources:ResMessages,Provider_UserPhone%>"
                                    ControlToValidate="txtPhoneNumber" ForeColor="Red" Display="Dynamic" ValidationGroup="Edit">
                                </asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr class="gridviewAlternatestyle">
                            <td align="left">
                                &nbsp;&nbsp;&nbsp; <strong>Time Zone</strong>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblTimeZone" runat="server" Visible="false"></asp:Label>
                                <asp:DropDownList ID="ddlTimeZone" runat="server" AppendDataBoundItems="true" Width="380px">
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr class="gridviewRowstyle">
                            <td align="left">
                                &nbsp;&nbsp;&nbsp; <strong>Special accommodations</strong>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblSpecialNeeds" runat="server" Visible="false"></asp:Label>
                                <asp:DropDownList ID="ddlSpecialNeeds" runat="server" 
                                    AppendDataBoundItems="true" 
                                    onselectedindexchanged="ddlSpecialNeeds_SelectedIndexChanged" AutoPostBack="true">
                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr class="gridviewAlternatestyle" runat="server" id="trcomments" visible="false">
                            <td align="left">
                                &nbsp;&nbsp;&nbsp; <strong>Comments</strong>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblcomments" runat="server" Visible="false"></asp:Label>
                                <textarea id="txtcomments" runat="server" style="width: 250px;"></textarea>
                            </td>
                        </tr>
                        <tr class="gridviewRowstyle" id="trUpdate" runat="server">
                            <td colspan="2" align="center">
                                <telerik:RadButton ID="imgUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click"
                                    Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin %>" ValidationGroup="Edit" />
                                <telerik:RadButton ID="imgCancel" runat="server" Text="Back" OnClick="btnBack_Click"
                                    Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin %>" CausesValidation="false" />
                            </td>
                        </tr>
                        <tr id="imgSuccess" runat="server">
                            <td valign="middle" align="right">
                                <img src="../Images/ImgSuccessAlert.png" alt="Success" />&nbsp;&nbsp;
                            </td>
                            <td valign="middle" align="left">
                                &nbsp;&nbsp;<asp:Label ID="lblMsg" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>

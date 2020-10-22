<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true"
    CodeBehind="MyProfile.aspx.cs" Inherits="SecureProctor.Student.MyProfile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StudentContent" runat="server" ClientIDMode="Static" EnableViewState="true">

    <script type="text/javascript">

        function check(data) {
            if (typeof (data.length) != 'undefined') {
                if (/^[\s]*$/.test(data.toString())) {
                    return true;
                }
            }
        }

        function validate(e) {
            var regexp1 = new RegExp("[^a-z]");
            $("#lblkeyMsg").css("color", "red");
			$("#lblkeyMsg").css( "fontSize", "15px" );
            if (e.keyCode == 13 || e.type == 'click') {

                if (check($('#firstname').val())) {
                    $("#lblkeyMsg").text("First Name required.");
                    $('#firstname').focus();
					$('#firstname').val('');
                    return false;
                }
                else if (regexp1.test($('#firstname').val())) {
                    $("#lblkeyMsg").text("CAPS and SPACES are not allowed.");
                    $('#firstname').focus();
					$('#firstname').val('');
                    return false;
                }
                else if (check($('#lastname').val())) {
                    $("#lblkeyMsg").text("Last Name required.");
                    $('#lastname').focus();
					$('#lastname').val('');
                    return false;
                }
                else if (regexp1.test($('#lastname').val())) {
                    $("#lblkeyMsg").text("CAPS and SPACES are not allowed.");
                    $('#lastname').focus();
					$('#lastname').val('');
                    return false;
                }
                else if (check($('#firstNameLastName').val())) {                    
                    $("#lblkeyMsg").text("First Name and Last Name required.");
                    $('#firstNameLastName').focus();
					$('#firstNameLastName').val('');
                    return false;
                }
                else if (regexp1.test($('#firstNameLastName').val())) {
                    $("#lblkeyMsg").text("CAPS and SPACES are not allowed.");
                    $('#firstNameLastName').focus();
					$('#firstNameLastName').val('');
                    return false;
                }
                else if (check($('#refirstNameLastName').val())) {
                    $("#lblkeyMsg").text("Re-enter First Name and Last Name.");
                    $('#refirstNameLastName').focus();
					$('#refirstNameLastName').val('');
                    return false;
                }
                else if (regexp1.test($('#refirstNameLastName').val())) {
                    $("#lblkeyMsg").text("CAPS and SPACES are not allowed.");
                    $('#refirstNameLastName').focus();
					$('#refirstNameLastName').val('');
                    return false;
                }
                else if ($('#firstNameLastName').val() != $('#refirstNameLastName').val()) {
                    $("#lblkeyMsg").text("Your First Name/Last Name do not match.");
                    $('#refirstNameLastName').focus();
					$('#refirstNameLastName').val('');
                    return false;
                }
                else {
                    $(<%=btnradSave.ClientID%>).click();
                        return true;
                    }
            }
        }
		
		function isAlphapet() {
                var regexp1 = new RegExp("[^a-z]");
				$("#lblkeyMsg").css( "fontSize", "15px" );
                $("#lblkeyMsg").css("color", "red");
				if (regexp1.test($('#firstname').val())) {
                    $("#lblkeyMsg").text("CAPS and SPACES are not allowed.");
                    $('#firstname').focus();
                    $('#firstname').val('');
                    return false;
                }
                else if (regexp1.test($('#lastname').val())) {
                            $("#lblkeyMsg").text("CAPS and SPACES are not allowed.");
                            $('#lastname').focus();
                            $('#lastname').val('');
                            return false;
                }						
                else if (regexp1.test($('#firstNameLastName').val())) {
                            $("#lblkeyMsg").text("CAPS and SPACES are not allowed.");
                            $('#firstNameLastName').focus();
                            $('#firstNameLastName').val('');
                            return false;
                }						
                else if (regexp1.test($('#refirstNameLastName').val())) {
                            $("#lblkeyMsg").text("CAPS and SPACES are not allowed.");
                            $('#refirstNameLastName').focus();
                            $('#refirstNameLastName').val('');
                            return false;
                }
						
                       /* else if ($('#firstNameLastName').val() != $('#refirstNameLastName').val()) {
                            $("#lblkeyMsg").text("Your First Name/Last Name do not match.");
                            $('#refirstNameLastName').focus();
                            $('#refirstNameLastName').val('');							
                            return false;
                        }*/
                else {
                    return true;
                }
            }


function cancel() {
    //$('input[type=text].removeAttr("required")');
    $(<%=btnradCancel.ClientID%>).click();
}

        function setUploadButtonState() {
            fileSize = $("#IdentificationFileUpload")[0].files[0].size //size in kb
            // fileSize = fileSize / 1048576; //size in mb             
            if (fileSize <= 5242880) {
                // if (fileSize <= 200000) {              
                document.getElementById('<%=lblIdentificationImage.ClientID%>').style.display = 'none';
                return true;
            }
            else {
                document.getElementById('<%=lblIdentificationImage.ClientID%>').style.display = 'block';
                args.set_cancel(true);
                return false;
            }
        }


function OpenBrowse() {
    if (window.event.keyCode == 13)
        document.getElementById('<%=IdentificationFileUpload.ClientID%>').click();
}


function mousedown() {
    return false;
}
function mouseup(e) {
    if (e != null && e.type == "mouseup") {
        if (e.which == 2 || e.which == 3) {
            return false;
        }
    }
}
function contextMenu() {
    return false;
}

if (document.layers) {
    document.captureEvents(Event.MOUSEDOWN);
    document.onmousedown = mousedown;
}
else {
    document.onmouseup = mouseup;
}
document.oncontextmenu = contextMenu;

    </script>


    <table cellpadding="2" cellspacing="2" width="100%">
        <tr>
            <td>
                <img src="../Images/ImgProfile.png" />
            </td>
            <td width="1%" rowspan="3"></td>
        </tr>
        <tr>
            <td width="67%" valign="top">
                <div class="login_new1">
                    <table width="100%" cellpadding="2" cellspacing="4">
                        <tr>
                            <td>
                                <asp:UpdatePanel ID="upInfo" runat="server">
                                    <ContentTemplate>
                                        <asp:Panel ID="pnlInfo" runat="server">
                                            <table width="100%" cellpadding="0" cellspacing="8" class="td_bg">
                                                <tr align="left" class="messages">
                                                    <td>
                                                        <asp:Label ID="lblHeader1" runat="server" Text="Welcome to Examity. To get started, please:" TabIndex="11"></asp:Label>
                                                        <ol>
                                                            <li>
                                                                <asp:Label ID="lblHeader2" runat="server" Text="Check that your system has the necessary software." TabIndex="12"></asp:Label></li>
                                                            <li>
                                                                <asp:Label ID="lblHeader3" runat="server" Text="Verify your user information." TabIndex="13"></asp:Label></li>
                                                            <li>
                                                                <asp:Label ID="lblHeader4" runat="server" TabIndex="14" Text="Please upload a picture of your photo ID."></asp:Label></li>
                                                            <li>
                                                                <asp:Label ID="lblHeader5" runat="server" TabIndex="15" Text="Set up your security questions."></asp:Label></li>
                                                            <li>
                                                                 <asp:Label ID="lblHeader" runat="server"  Text="Setup your keystroke biometrics."></asp:Label></li>
                                                            </li>
                                                            <li>
                                                                <asp:Label ID="lblHeader6" runat="server" TabIndex="16" Text="Please click the save button if you make changes to your information."></asp:Label></li>
                                                        </ol>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="100%" cellpadding="0" cellspacing="8" class="td_bg">
                                    <tr class="td_header">
                                        <td colspan="4" align="left">
                                            <table width="100%" cellpadding="0" cellspacing="0" class="td_bg">
                                                <tr class="td_header">
                                                    <td colspan="4" align="left">
                                                        <table width="100%">
                                                            <tr>
                                                                <td align="left" class="boreder_home_pro">
                                                                    <asp:Image ID="Image8" runat="server" ImageUrl="~/Images/Imgsystem_requirements.png" AlternateText="Exam Requirements" TabIndex="17" />
                                                                </td>
                                                                <td align="right" class="boreder_home_pro">
                                                                    <asp:HyperLink ID="hlkSystemReadyness" Target="_blank" NavigateUrl="https://Prod.examity.com/systemcheck/check.aspx" runat="server" Text="Computer Requirements Check" Font-Underline="true" ForeColor="Blue" Font-Size="Medium"></asp:HyperLink>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="2">
                                                                    <div style="padding: 10px; width: 100%">
                                                                        <table cellpadding="2" cellspacing="2" width="100%">
                                                                            <tr>
                                                                                <td align="left" width="100%">
                                                                                    <asp:UpdatePanel ID="pnl" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <table width="100%" cellpadding="4">
                                                                                                <tr>
                                                                                                    <td width="25%" align="center">
                                                                                                        <asp:Image ID="ImgTimeZoneValidation" runat="server" TabIndex="18" />
                                                                                                        <asp:Label ID="lblTimeZoneValidation" runat="server"></asp:Label>
                                                                                                    </td>

                                                                                                    <td width="20%" align="left">
                                                                                                        <asp:Image ID="ImgPhotoIDValidation" runat="server" TabIndex="19" />
                                                                                                        <asp:Label ID="lblPhotoIDValidation" runat="server"></asp:Label>
                                                                                                    </td>

                                                                                                    <td width="20%" align="left">
                                                                                                        <asp:Image ID="ImgSecurityValidation" runat="server" TabIndex="20" />
                                                                                                        <asp:Label ID="lblSecurityValidation" runat="server"></asp:Label>
                                                                                                    </td>
                                                                                                    <td align="left" width="35%">
                                                                                                        <asp:Image ID="ImgKeyValidation" runat="server" TabIndex="21" />
                                                                                                        <asp:Label ID="lblKeyValidation" runat="server"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <asp:UpdatePanel ID="up2" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="8" class="td_bg">
                                            <tr class="td_header">
                                                <td colspan="4" align="left">
                                                    <table width="100%">
                                                        <tr>
                                                            <td align="left" class="boreder_home_pro">
                                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/ImgDemografic.png" AlternateText="Account Information" TabIndex="24" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" align="left">
                                                    <asp:Label ID="lblsucc" runat="server" Font-Bold="true" TabIndex="56"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="trDemographicView" runat="server">
                                                <td colspan="4" align="left">
                                                    <table width="100%" cellpadding="0" cellspacing="8" class="td_bg">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label1" Text="First Name" runat="server" Font-Bold="true" TabIndex="25" title="Your First Name"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblFirstName" runat="server" TabIndex="26"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label2" Text="Last Name" runat="server" Font-Bold="true" TabIndex="27" title="Your Last Name"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblLastName" runat="server" TabIndex="28"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label3" Text="Email" runat="server" Font-Bold="true" TabIndex="29" title="Your Email Address"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblEmail" runat="server" Width="100%" TabIndex="30"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label12" Text="Phone Number" runat="server" Font-Bold="true" TabIndex="31" title="Your Phone Number"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblphone" runat="server" TabIndex="32"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label5" Text="Time Zone" runat="server" Font-Bold="true" ValidationGroup="Save" TabIndex="33" title="Your current time zone"></asp:Label>
                                                            </td>
                                                            <td align="left" colspan="4">
                                                                <asp:Label ID="lblTimeZone" runat="server" TabIndex="34"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="4">
                                                                <telerik:RadButton ID="RadButton1" runat="server" Text="<%$ Resources:SecureProctor,Common_Edit %>"
                                                                    Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin %>" OnClick="btnEditTimeZone_Click"
                                                                    CausesValidation="false" AutoPostBack="true" title="Edit your Account information" TabIndex="35" UseSubmitBehavior="false">
                                                                </telerik:RadButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="trDemographicEdit" runat="server">
                                                <td colspan="4" align="left">
                                                    <table width="100%" cellpadding="0" cellspacing="8" class="td_bg">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblFirstNameEdit" Text="First Name" runat="server" Font-Bold="true" TabIndex="36" title="Your First Name" ></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <telerik:RadTextBox ID="txtFirstName" runat="server" TabIndex="37" title="Please enter your first name"  >
                                                                </telerik:RadTextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="<%$ Resources:ResMessages,Reg_FirstName %>"
                                                                    ControlToValidate="txtFirstName" ForeColor="Red" ValidationGroup="Edit" TabIndex="38" Enabled="false">
                                                                </asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label16" Text="Last Name" runat="server" Font-Bold="true" TabIndex="39" title="Your Last Name"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <telerik:RadTextBox ID="txtLastName" runat="server" TabIndex="40" title="Please enter your last name">
                                                                </telerik:RadTextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="<%$ Resources:ResMessages,Reg_LastName %>"
                                                                    ControlToValidate="txtLastName" ForeColor="Red" ValidationGroup="Edit" TabIndex="41">
                                                                </asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label18" Text="Email" runat="server" Font-Bold="true" TabIndex="42" title="Your Email Address"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <telerik:RadTextBox ID="txtEmail" runat="server" Width="75%" TabIndex="43" title="Please enter your email address">
                                                                </telerik:RadTextBox>


                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label20" Text="Phone Number" runat="server" Font-Bold="true" TabIndex="46" title="Your Phone Number"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                +<telerik:RadTextBox ID="txtCountryCode" runat="server" Width="11%" TabIndex="43" Text="">
                                                                </telerik:RadTextBox>

                                                                <telerik:RadMaskedTextBox ID="txtPhoneNumber" runat="server" Mask="###-###-#########" TabIndex="48" title="Please enter your phone number">
                                                                </telerik:RadMaskedTextBox>
                                                                <asp:Label ID="lblformat" runat="server" Text="(ex:+91-(202)-000-0000)" TabIndex="47"></asp:Label>
                                                                <asp:Label ID="lblMobileNumber" runat="server" Visible="false"></asp:Label>


                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" Display="Dynamic"
                                                                    ErrorMessage="<%$ Resources:ResMessages,Provider_Useremailid %>" ControlToValidate="txtEmail"
                                                                    ForeColor="Red" ValidationGroup="Edit" TabIndex="44">
                                                                </asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic"
                                                                    ValidationGroup="Edit" ForeColor="Red" runat="server" ControlToValidate="txtEmail" TabIndex="45"
                                                                    ErrorMessage="<%$ Resources:ResMessages,Provider_UserValidemail %>" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                                                </asp:RegularExpressionValidator>
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="<%$Resources:ResMessages,Provider_UserPhone%>"
                                                                    ControlToValidate="txtPhoneNumber" ForeColor="Red" Display="Dynamic" ValidationGroup="Edit" TabIndex="49">
                                                                </asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="phoneValidate" runat="server" ErrorMessage="Invalid Phone Number"
                                                                    ControlToValidate="txtPhoneNumber" ForeColor="Red" Display="Dynamic" ValidationGroup="Edit"
                                                                    ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4,10}" TabIndex="50"></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label24" Text="Time Zone" runat="server" Font-Bold="true" ValidationGroup="Save" TabIndex="51" title="Your current time zone"></asp:Label>
                                                            </td>
                                                            <td align="left" colspan="3">
                                                                <telerik:RadComboBox ID="ddlTimeZone" runat="server" Width="320" AppendDataBoundItems="true" Height="200" TabIndex="52" ChangeTextOnKeyBoardNavigation="true"
                                                                    Skin="<%$ Resources:SecureProctor,Telerik_ComboBox_Skin %>" DropDownAutoWidth="Enabled" OnItemDataBound="ddlTimeZone_ItemDataBound" title="Please select your timezone, Press Alt + down arrow to expand the items" Filter="Contains" MarkFirstMatch="true">
                                                                    <Items>
                                                                        <telerik:RadComboBoxItem Value="-1" />
                                                                    </Items>
                                                                </telerik:RadComboBox>
                                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator15" InitialValue="--Select Time Zone--"
                                                                    Display="Dynamic" ControlToValidate="ddlTimeZone" ValidationGroup="Edit" ErrorMessage="Please select Time Zone" TabIndex="53" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="4">
                                                                <telerik:RadButton ID="RadButton2" runat="server" Text="<%$ Resources:SecureProctor,Common_Save %>"
                                                                    Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin %>" OnClick="btnSaveTimeZone_Click"
                                                                    ValidationGroup="Edit" AutoPostBack="true" title="Update your Account information" TabIndex="54">
                                                                </telerik:RadButton>
                                                                <telerik:RadButton ID="RadButton3" runat="server" Text="<%$ Resources:SecureProctor,Grid_Header_Cancel %>"
                                                                    Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin %>" OnClick="btnCancelTimeZone_Click"
                                                                    CausesValidation="false" AutoPostBack="true" title="Cancel changes" TabIndex="55">
                                                                </telerik:RadButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="RadButton2" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="RadButton1" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="RadButton3" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="100%" cellpadding="0" cellspacing="8" class="td_bg">
                                    <tr class="td_header">
                                        <td align="left" colspan="4">
                                            <table width="100%">
                                                <tr>
                                                    <td align="left" class="boreder_home_pro">
                                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/examiCHECK.png" AlternateText="Photo Identity" TabIndex="57" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="40%" align="left">
                                            <asp:Image runat="server" ID="img" />
                                        </td>
                                        <td valign="top" align="left">
                                            <asp:Label ID="lblUpload" runat="server" Font-Bold="true" TabIndex="64"></asp:Label><br />
                                            <br />
                                            <li style="vertical-align: text-top; padding-bottom: 5px;">
                                                <asp:Label ID="lblHeader7" runat="server" Text="Take a picture of your photo ID using a smartphone, camera or webcam." TabIndex="58"></asp:Label></li>
                                            <li style="vertical-align: text-top; padding-bottom: 5px;">
                                                <asp:Label ID="lblHeader8" runat="server" Text="Save the image of the picture to your PC." TabIndex="59"></asp:Label></li>
                                            <li style="vertical-align: text-top; padding-bottom: 10px;">
                                                <asp:Label ID="lblHeader9" runat="server" Text="Upload the image from your PC to Examity." TabIndex="60"></asp:Label></li>
                                            <br />
                                            <asp:FileUpload ID="IdentificationFileUpload" runat="server" title="Click here to select your Photo Identity" TabIndex="61" />
                                            <br />
                                            <br />
                                            <telerik:RadButton ID="btnSaveImage" runat="server" Text="<%$ Resources:SecureProctor,Common_Upload %>"
                                                Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin %>" OnClick="btnSaveImage_Click"
                                                ValidationGroup="Upload" title="Click here to Upload your Photo Identity" TabIndex="62" UseSubmitBehavior="false">
                                            </telerik:RadButton>
                                            <asp:Label ID="lblIdentificationImage" runat="server" Text="File must be less than 5 mb" style="display:none;" ForeColor="Red"></asp:Label>
                                            <asp:CustomValidator ID="customValidatorUpload" runat="server" ErrorMessage="" ControlToValidate="IdentificationFileUpload" ClientValidationFunction="setUploadButtonState();" ValidationGroup="Upload" />


                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="<%$ Resources:ResMessages,Reg_Uploadfile %>"
                                                ControlToValidate="IdentificationFileUpload" ForeColor="Red" Display="Dynamic"
                                                ValidationGroup="Upload" CausesValidation="false" TabIndex="63"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:UpdatePanel ID="up1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="8" class="td_bg">
                                            <tr class="td_header">
                                                <td colspan="4" align="left">
                                                    <table width="100%">
                                                        <tr>
                                                            <td align="left" class="boreder_home_pro">
                                                                <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/examiKNOW.png" AlternateText="Security Questions" TabIndex="65" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="trexamiKNOWmsg" runat="server" visible="false">
                                                <td colspan="4">
                                                    <span class="messages">You cannot view this information at this time.</span>
                                                </td>
                                            </tr>
                                            <tr id="trexamiKNOW" runat="server">
                                                <td colspan="4">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <span class="messages">This information will be used for future verification. Please select questions that you can accurately remember.</span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" colspan="4">
                                                                <asp:Label ID="lblSecUpdated" runat="server" Font-Bold="true" TabIndex="92"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr id="trSecurityQuestionsView" runat="server">
                                                            <td align="left" colspan="4">
                                                                <table width="100%" cellpadding="0" cellspacing="8" class="td_bg">
                                                                    <tr>
                                                                        <td width="25%" align="left">
                                                                            <asp:Label ID="Label6" runat="server" Text="Security Question #1" Font-Bold="true" TabIndex="66"></asp:Label>
                                                                        </td>
                                                                        <td>:
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblSecurityQuestion1" runat="server" TabIndex="67"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            <asp:Label ID="Label7" runat="server" Text="Answer" Font-Bold="true" TabIndex="68"></asp:Label>
                                                                        </td>
                                                                        <td>:
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblAnswer1" runat="server" TabIndex="69"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            <asp:Label ID="Label8" runat="server" Text="Security Question #2" Font-Bold="true" TabIndex="70"></asp:Label>
                                                                        </td>
                                                                        <td>:
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblSecurityQuestion2" runat="server" TabIndex="71"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            <asp:Label ID="Label9" runat="server" Text="Answer" Font-Bold="true" TabIndex="72"></asp:Label>
                                                                        </td>
                                                                        <td>:
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblAnswer2" runat="server" TabIndex="73"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            <asp:Label ID="Label10" runat="server" Text="Security Question #3" Font-Bold="true" TabIndex="74"></asp:Label>
                                                                        </td>
                                                                        <td>:
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblSecurityQuestion3" runat="server" TabIndex="75"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            <asp:Label ID="Label11" runat="server" Text="Answer" Font-Bold="true" TabIndex="76"></asp:Label>
                                                                        </td>
                                                                        <td>:
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblAnswer3" runat="server" TabIndex="77"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" colspan="3">
                                                                            <telerik:RadButton ID="btnEdit" runat="server" Text="<%$ Resources:SecureProctor,Common_Edit %>"
                                                                                Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin %>" OnClick="btnEdit_Click"
                                                                                CausesValidation="false" title="Edit Security Questinons" TabIndex="78" UseSubmitBehavior="false">
                                                                            </telerik:RadButton>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr id="trSecurityQuestionsEdit" runat="server">
                                                            <td align="left" colspan="4">
                                                                <table width="100%" cellpadding="0" cellspacing="8" class="td_bg">
                                                                    <tr>
                                                                        <td width="25%" align="left">
                                                                            <asp:Label ID="Label4" runat="server" Text="Security Question #1" Font-Bold="true" TabIndex="79"></asp:Label>
                                                                        </td>
                                                                        <td>:
                                                                        </td>
                                                                        <td align="left">
                                                                            <telerik:RadComboBox ID="ddlSecurityQuestion1" runat="server" Width="270" ChangeTextOnKeyBoardNavigation="true"
                                                                                Skin="<%$ Resources:SecureProctor,Telerik_ComboBox_Skin %>" AppendDataBoundItems="true" TabIndex="80" title="Please select the valid Security Question. Press Alt + down arrow to expand the items">
                                                                            </telerik:RadComboBox>
                                                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" InitialValue="--Select Security question--"
                                                                                Display="Dynamic" ControlToValidate="ddlSecurityQuestion1" ValidationGroup="Edit"
                                                                                ErrorMessage="<%$ Resources:ResMessages,Reg_SecQuestionEnter %>" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            <asp:Label ID="Label17" runat="server" Text="Answer" Font-Bold="true" TabIndex="81"></asp:Label>
                                                                        </td>
                                                                        <td>:
                                                                        </td>
                                                                        <td align="left">
                                                                            <telerik:RadTextBox ID="txtAnswer1" runat="server" CssClass="td_input"
                                                                                AutoCompleteType="None" Width="270" TabIndex="82" title="Please enter the valid Security Answer">
                                                                            </telerik:RadTextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="<%$ Resources:ResMessages,Reg_SecAnswerEnter %>"
                                                                                ControlToValidate="txtAnswer1" ForeColor="Red" Font-Bold="true" Display="Dynamic"
                                                                                ValidationGroup="Edit">
                                                                            </asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            <asp:Label ID="Label21" runat="server" Text="Security Question #2" Font-Bold="true" TabIndex="83"></asp:Label>
                                                                        </td>
                                                                        <td>:
                                                                        </td>
                                                                        <td align="left">
                                                                            <telerik:RadComboBox ID="ddlSecurityQuestion2" runat="server" Width="270" ChangeTextOnKeyBoardNavigation="true"
                                                                                Skin="<%$ Resources:SecureProctor,Telerik_ComboBox_Skin %>" AppendDataBoundItems="true" TabIndex="84" title="Please select the valid Security Question. Press Alt + down arrow to expand the items">
                                                                            </telerik:RadComboBox>
                                                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" InitialValue="--Select Security question--"
                                                                                Display="Dynamic" ControlToValidate="ddlSecurityQuestion1" ValidationGroup="Edit"
                                                                                ErrorMessage="<%$ Resources:ResMessages,Reg_SecQuestionEnter %>" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            <asp:Label ID="Label23" runat="server" Text="Answer" Font-Bold="true" TabIndex="85"></asp:Label>
                                                                        </td>
                                                                        <td>:
                                                                        </td>
                                                                        <td align="left">
                                                                            <telerik:RadTextBox ID="txtAnswer2" runat="server" CssClass="td_input" title="Please enter the valid Security Answer"
                                                                                AutoCompleteType="None" Width="270" TabIndex="86">
                                                                            </telerik:RadTextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="<%$ Resources:ResMessages,Reg_SecAnswerEnter %>"
                                                                                ControlToValidate="txtAnswer2" ForeColor="Red" Font-Bold="true" Display="Dynamic"
                                                                                ValidationGroup="Edit">
                                                                            </asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            <asp:Label ID="Label26" runat="server" Text="Security Question #3" Font-Bold="true" TabIndex="87"></asp:Label>
                                                                        </td>
                                                                        <td>:
                                                                        </td>
                                                                        <td align="left">
                                                                            <telerik:RadComboBox ID="ddlSecurityQuestion3" runat="server" Width="270" ChangeTextOnKeyBoardNavigation="true"
                                                                                Skin="<%$ Resources:SecureProctor,Telerik_ComboBox_Skin %>" AppendDataBoundItems="true" TabIndex="88" title="Please select the valid Security Question. Press Alt + down arrow to expand the items">
                                                                            </telerik:RadComboBox>
                                                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" InitialValue="--Select Security question--"
                                                                                Display="Dynamic" ControlToValidate="ddlSecurityQuestion1" ValidationGroup="Edit"
                                                                                ErrorMessage="<%$ Resources:ResMessages,Reg_SecQuestionEnter %>" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            <asp:Label ID="Label28" runat="server" Text="Answer" Font-Bold="true" TabIndex="89"></asp:Label>
                                                                        </td>
                                                                        <td>:
                                                                        </td>
                                                                        <td align="left">
                                                                            <telerik:RadTextBox ID="txtAnswer3" runat="server" CssClass="td_input" title="Please enter the valid Security Answer"
                                                                                AutoCompleteType="None" Width="270" TabIndex="90">
                                                                            </telerik:RadTextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="<%$ Resources:ResMessages,Reg_SecAnswerEnter %>"
                                                                                ControlToValidate="txtAnswer3" ForeColor="Red" Font-Bold="true" Display="Dynamic"
                                                                                ValidationGroup="Edit">
                                                                            </asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" colspan="3">
                                                                            <telerik:RadButton ID="btnSave" runat="server" Text="<%$ Resources:SecureProctor,Common_Save %>"
                                                                                Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin %>" OnClick="btnSave_Click"
                                                                                ValidationGroup="Edit" CausesValidation="true" title="Update Security Questinons" TabIndex="91">
                                                                            </telerik:RadButton>
                                                                            <telerik:RadButton ID="btnCancel" runat="server" Text="<%$ Resources:SecureProctor,Grid_Header_Cancel %>"
                                                                                Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin %>" OnClick="btnCancel_Click"
                                                                                CausesValidation="false" title="Cancel Changes" TabIndex="92">
                                                                            </telerik:RadButton>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>


                                        </table>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnEdit" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>

                        <tr id="trExamikey" runat="server">
                            <td>
                                <table width="100%" cellpadding="0" cellspacing="8" class="td_bg">
                                    <tr class="td_header">
                                        <td align="left">
                                            <table width="100%">
                                                <tr>
                                                    <td align="left" class="boreder_home_pro">
                                                        <asp:Image ID="Image5" runat="server" ImageUrl="~/Images/Examikey.png" TabIndex="65" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <span class="messages">This information will be used for future verification. Please type as you normally would.</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="lblkeyMsg" runat="server" Font-Bold="true"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr id="trKeyStrokeView" runat="server">
                                        <td align="left">
                                            <table width="100%" cellpadding="0" cellspacing="8" class="td_bg">
                                                <tr>
                                                    <td width="30%" align="left">
                                                        <asp:Label ID="lblKeyFirstname" runat="server" Text="First Name" Font-Bold="true" TabIndex="66" CssClass="Display"></asp:Label>
                                                    </td>
                                                    <td width="1%">:
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblKeyFirstNamevalue" runat="server" CssClass="Display"></asp:Label>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lblKeyFirstandLastname" runat="server" Text="First Name and Last Name" Font-Bold="true" CssClass="Display"></asp:Label>
                                                    </td>
                                                    <td>:
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblKeyFirstandLastNameValue" runat="server" CssClass="Display"></asp:Label>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td align="left" colspan="2">
                                                        <telerik:RadButton ID="rbtnKeyEdit" runat="server" Text="<%$ Resources:SecureProctor,Common_Edit %>"
                                                            Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin %>" OnClick="rbtnKeyEdit_Click"
                                                            CausesValidation="false" UseSubmitBehavior="false">
                                                        </telerik:RadButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr id="trKeyStrokeEdit" runat="server">
                                        <td align="left">

                                            <table width="100%" cellpadding="0" cellspacing="8" class="td_bg">
                                                <tr>
                                                    <td width="40%" align="left">
                                                        <asp:Label ID="lblEditFname" runat="server" Text="Enter First Name" CssClass="Display"></asp:Label><br />
                                                        <asp:Label ID="nocaps" runat="server" Text="(NO CAPS)" CssClass="Display18" Font-Bold="true"></asp:Label>

                                                    </td>
                                                    <td>:
                                                    </td>
                                                    <td align="left">
                                                        <input id="firstname" name="firstname" type="text" autofocus="autofocus" autocomplete="off" style="height: 25px; font-size: 16px; width: 200px" onpaste="return false;" oncopy="return false;" onkeypress="return validate(event);" onblur="isAlphapet();"/>&nbsp;
                                                        <label for="john" style="font-size: 16px;">(example: john)</label>



                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lblEditLName" runat="server" Text="Enter Last Name" TabIndex="85" CssClass="Display"></asp:Label><br />
                                                        <asp:Label ID="lblLastnameNocaps" runat="server" Text="(NO CAPS)" CssClass="Display18" Font-Bold="true"></asp:Label>
                                                    </td>
                                                    <td>:
                                                    </td>
                                                    <td align="left">
                                                        <input id="lastname" name="lastname" type="text" autofocus="autofocus" autocomplete="off" style="height: 25px; font-size: 16px; width: 200px" onpaste="return false;" oncopy="return false;" onkeypress="return validate(event);" onblur="isAlphapet();"/>&nbsp;
                                                         <label for="john" style="font-size: 16px;">(example: smith)</label>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lblEditLastname" runat="server" Text="Enter First Name and Last Name" TabIndex="86" CssClass="Display"></asp:Label><br />
                                                        <asp:Label ID="lbleditnamenocaps" runat="server" Text="(NO CAPS, NO SPACES)" CssClass="Display18" Font-Bold="true"></asp:Label>
                                                    </td>
                                                    <td>:
                                                    </td>
                                                    <td align="left">
                                                        <input id="firstNameLastName" name="firstNameLastName" type="text" autofocus="autofocus" autocomplete="off" style="height: 25px; font-size: 16px; width: 200px" onpaste="return false;" oncopy="return false;" onkeypress="return validate(event);" onblur="isAlphapet();"/>&nbsp;
                                                          <label for="john" style="font-size: 16px;">(example: johnsmith)</label>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lblEditReenter" runat="server" Text="Re-enter First Name and Last Name" CssClass="Display"></asp:Label><br />
                                                        <asp:Label ID="Label14" runat="server" Text="(NO CAPS, NO SPACES)" CssClass="Display18" Font-Bold="true"></asp:Label>
                                                    </td>
                                                    <td>:
                                                    </td>
                                                    <td align="left">
                                                        <input id="refirstNameLastName" type="text" name="refirstNameLastName" autocomplete="off" autofocus="autofocus" style="height: 25px; font-size: 16px; width: 200px" onpaste="return false;" oncopy="return false;" onkeypress="return validate(event);" onblur="isAlphapet();"></input>&nbsp;                                                      
                                                          <label for="john" style="font-size: 16px;">(example: johnsmith)</label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td align="left">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <span class="Button_r SkinnedButton">

                                                                        <input id="btniputSave" name="Save" value="Save" type="button" runat="server" class="Decorated" onclick="validate(event);" />
                                                                    </span>

                                                                    <telerik:RadButton ID="btnradSave" runat="server" Text="<%$ Resources:SecureProctor,Common_Save %>"
                                                                        Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin %>"
                                                                        OnClick="btnradSave_Click" CausesValidation="true" Style="display: none;" UseSubmitBehavior="false">
                                                                    </telerik:RadButton>
                                                                </td>
                                                                <td>
                                                                    <span class="Button_r SkinnedButton">
                                                                        <input id="bCancel" name="Cancel" type="button" runat="server" class="Decorated" value="Cancel" onclick="cancel()" />
                                                                    </span>

                                                                    <telerik:RadButton ID="btnradCancel" runat="server" Text="<%$ Resources:SecureProctor,Grid_Header_Cancel %>"
                                                                        Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin %>" Style="display: none;"
                                                                        OnClick="btnradCancel_Click"
                                                                        CausesValidation="false" UseSubmitBehavior="false">
                                                                    </telerik:RadButton>
                                                                </td>
                                                            </tr>
                                                        </table>


                                                    </td>
                                                </tr>
                                            </table>


                                        </td>
                                    </tr>

                                    <tr>
                                        <td>&nbsp;
                                        </td>
                                    </tr>


                                </table>
                            </td>
                        </tr>

                        <tr>
                            <td align="left">
                                <asp:Label ID="Label13" runat="server" CssClass="messages" Text="Please make sure you save your information before continuing."></asp:Label>
                            </td>
                        </tr>

                        <tr id="trChangePassword" runat="server">
                            <td>
                                <asp:Panel ID="pwd" runat="server" DefaultButton="btnSubmit">
                                    <table width="100%" cellpadding="0" cellspacing="8" class="td_bg">
                                        <tr class="td_header">
                                            <td colspan="4" align="left">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td align="left" class="boreder_home_pro">
                                                            <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/ImgChangePassword.png" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:Label ID="lblUpdated" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="3" width="25%">
                                                <asp:Label ID="lblCurrentPassword" runat="server" Text="Current Password" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="txtCurrentPassword" runat="server" CssClass="td_input" TextMode="Password"
                                                    Width="250" ValidationGroup="submit">
                                                </telerik:RadTextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="<%$ Resources:ResMessages,MyProfile_CurrPassword %>"
                                                    ControlToValidate="txtCurrentPassword" ForeColor="Red" Font-Bold="true" Display="Dynamic"
                                                    ValidationGroup="submit">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="3" width="25%">
                                                <asp:Label ID="lblNewPassword" runat="server" Text="New Password" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="txtNewPassword" runat="server" CssClass="td_input" TextMode="Password"
                                                    Width="250" ValidationGroup="submit">
                                                </telerik:RadTextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="<%$ Resources:ResMessages,MyProfile_NewPassword %>"
                                                    ControlToValidate="txtNewPassword" ForeColor="Red" Font-Bold="true" Display="Dynamic"
                                                    ValidationGroup="submit">
                                                </asp:RequiredFieldValidator>
                                                <asp:CompareValidator ID="compnew" ControlToValidate="txtNewPassword" ControlToCompare="txtCurrentPassword"
                                                    ForeColor="red" Type="String" Operator="NotEqual" EnableClientScript="true" Text="New password cannot be the same as your current password."
                                                    runat="server" Display="Dynamic" Font-Bold="true" SetFocusOnError="true" ValidationGroup="submit" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="3" width="25%">
                                                <asp:Label ID="lblConfirmNewPassword" runat="server" Text="Confirm New Password"
                                                    Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="txtConfirmNewPassword" runat="server" CssClass="td_input"
                                                    TextMode="Password" Width="250" ValidationGroup="submit">
                                                </telerik:RadTextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="<%$ Resources:ResMessages,MyProfile_ConfirmNewPassword %>"
                                                    ControlToValidate="txtConfirmNewPassword" ForeColor="Red" Font-Bold="true" Display="Dynamic"
                                                    ValidationGroup="submit">

                                                </asp:RequiredFieldValidator>
                                                <asp:CompareValidator ID="compval" ControlToValidate="txtConfirmNewPassword" ControlToCompare="txtNewPassword"
                                                    ForeColor="red" Type="String" EnableClientScript="true" Text="<%$ Resources:ResMessages,Myprofile_PasswordMatch %>"
                                                    runat="server" Display="Dynamic" Font-Bold="true" ValidationGroup="submit" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;
                                            </td>
                                            <td colspan="2">&nbsp;
                                            </td>
                                            <td>
                                                <telerik:RadButton ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="<%$ Resources:SecureProctor,Common_Submit%>"
                                                    ValidationGroup="submit" CssClass="imghover" Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin %>">
                                                </telerik:RadButton>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                    <table cellpadding="2" cellspacing="2" width="100%">

                        <asp:UpdatePanel ID="UPMSG" runat="server">
                            <ContentTemplate>
                             </ContentTemplate>
                        </asp:UpdatePanel>

                          <tr>

                                    <td align="left" runat="server" id="tdScheduleMsg">

                                        <asp:Label ID="Label19" runat="server" CssClass="messages" Text="Once you have completed the above steps, you can <a href= 'ScheduleAnExam.aspx'><u><font color ='blue'>Schedule an Exam</font></u></a> "></asp:Label>


                                    </td>
                                </tr>
                    </table>
                </div>
            </td>
            <td width="27%" rowspan="3" valign="top" class="help_text_i">

                <div class="help_text_i_inner1" style="text-align:center;" runat="server" id="DivExamiBADGE" visible="false">
                    <h4 style="font-size:14px; color:#3f7db0; font-weight:normal;">Your examiBADGE<sup style="font-size:13px;">®</sup> status</h4>  
                    <div runat="server" id="divBadge" style="width:150px; margin:0px auto;" ></div>
                    <p style="color:#ff9900;">
                       <asp:Label ID="lblExamsleft" runat="server"  Font-Bold="true"></asp:Label>
                    </p>
                    <div style="text-align:left; background:url(../Images/Badge_shadow.png) no-repeat center; width:298px; height:176px; margin:0px auto;">
                      <div style="padding:20px 25px; font-size:14px;">
                        <div style="margin-bottom:20px; margin-top:10px;">Test with integrity and get recognized!</div>
                        <div style="margin-bottom:20px;">Show your pride by displaying your examiBADGE<sup>®</sup>  for academic honesty!</div>
                        <div style="margin-bottom:20px;">Market your achievement everywhere! </div>
                       </div>
                    </div>
                </div>

                  <div class="help_text_i_inner" runat="server" id="divInfo" visible="false">
                    <h4>From this page you can :</h4>
                    <ul>
                        <%-- <li>Make sure computer is ready.</li><br />--%>
                        <li>Edit account information.</li>
                        <br />
                        <li>Upload government issued photo ID<br />
                            Scan or take picture of ID.<br />
                            Load ID onto computer.<br />
                            Click “Choose File” button and click “Upload” button. </li>
                        <br />
                        <li>Select 3 questions and answers. We will use these questions to help verify identity
                            prior to exam.<br />
                            <strong>NOTE:</strong><br />
                            Select questions and answers you will remember.<br />
                            You will be unable to start an exam without the correct answers. </li>
                        <br />
                    </ul>
                    <p>
                        &nbsp;
                    </p>
                    <p>
                        &nbsp;
                    </p>
                </div>
            </td>
        </tr>

    </table>

    <telerik:RadCodeBlock ID="codeBlock" runat="server">
        <script src="https://prod.examity.com/commonfiles/StratKeyTrackerV1.js"></script>
        <script type="text/javascript">
            StratKeyTracker.SKTConfigure({ ctrlusername: "firstname", ctrlpassword: "firstNameLastName", ctrlConfirm: "refirstNameLastName" });
        </script>
    </telerik:RadCodeBlock>
</asp:Content>

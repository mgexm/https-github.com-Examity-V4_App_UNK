<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true" CodeBehind="ScheduleAnExam.aspx.cs" Inherits="SecureProctor.Student.ScheduleAnExam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StudentContent" runat="server">

    <script src="../Scripts/JavaScript2.js" type="text/javascript"></script>
    <script src="../Scripts/JavaScript1.js" type="text/javascript"></script>
    <link href="../CSS/StyleSheet1.css" rel="stylesheet" type="text/css" media="screen" />

    <style type="text/css">
        #dhtmltooltip {
            position: absolute;
            width: 150px;
            border: 2px solid #4081BF;
            border-radius: 5px;
            padding: 5px;
            background-color: lightyellow;
            visibility: hidden;
            z-index: 75;
            /*Remove below line to remove shadow. Below line should always appear last within this CSS*/
            filter: progid:DXImageTransform.Microsoft.Shadow(color=gray,direction=135);
        }
    </style>

    <style type="text/css">
        .RadScheduler_Web20 .rsNonWorkHour, .RadScheduler_Web20 .rsSunCol, .RadScheduler_Web20 .rsSatCol {
            background-color: white;
        }

        .RadCalendar_Web20 .rcMain .rcWeekend a {
            color: #000;
        }
    </style>
    <div id="dhtmltooltip"></div>
    <script type="text/javascript" language="javascript">
        var offsetxpoint = -10 //Customize x offset of tooltip
        var offsetypoint = 20 //Customize y offset of tooltip
        var ie = document.all
        var ns6 = document.getElementById && !document.all
        var enabletip = false
        if (ie || ns6)
            var tipobj = document.all ? document.all["dhtmltooltip"] : document.getElementById ? document.getElementById("dhtmltooltip") : ""

        function ietruebody() {
            return (document.compatMode && document.compatMode != "BackCompat") ? document.documentElement : document.body
        }

        function ddrivetip(thetext) {
            thecolor = "#F1F1F1";
            thewidth = "350";
            if (ns6 || ie) {
                if (typeof thewidth != "undefined") tipobj.style.width = thewidth + "px"
                if (typeof thecolor != "undefined" && thecolor != "") tipobj.style.backgroundColor = thecolor
                tipobj.innerHTML = thetext
                enabletip = true
                return false
            }
        }

        function positiontip(e) {
            if (enabletip) {
                var curX = (ns6) ? e.pageX : event.clientX + ietruebody().scrollLeft;
                var curY = (ns6) ? e.pageY : event.clientY + ietruebody().scrollTop;
                //Find out how close the mouse is to the corner of the window
                var rightedge = ie && !window.opera ? ietruebody().clientWidth - event.clientX - offsetxpoint : window.innerWidth - e.clientX - offsetxpoint - 20
                var bottomedge = ie && !window.opera ? ietruebody().clientHeight - event.clientY - offsetypoint : window.innerHeight - e.clientY - offsetypoint - 20

                var leftedge = (offsetxpoint < 0) ? offsetxpoint * (-1) : -1000

                //if the horizontal distance isn't enough to accomodate the width of the context menu
                if (rightedge < tipobj.offsetWidth)
                    //move the horizontal position of the menu to the left by it's width
                    tipobj.style.left = ie ? ietruebody().scrollLeft + event.clientX - tipobj.offsetWidth + "px" : window.pageXOffset + e.clientX - tipobj.offsetWidth + "px"
                else if (curX < leftedge)
                    tipobj.style.left = "5px"
                else
                    //position the horizontal position of the menu where the mouse is positioned
                    tipobj.style.left = curX + offsetxpoint + "px"

                //same concept with the vertical position
                if (bottomedge < tipobj.offsetHeight)
                    tipobj.style.top = ie ? ietruebody().scrollTop + event.clientY - tipobj.offsetHeight - offsetypoint + "px" : window.pageYOffset + e.clientY - tipobj.offsetHeight - offsetypoint + "px"
                else
                    tipobj.style.top = curY + offsetypoint + "px"
                tipobj.style.visibility = "visible"
            }
        }

        function hideddrivetip() {
            if (ns6 || ie) {
                enabletip = false
                tipobj.style.visibility = "hidden"
                tipobj.style.left = "-1000px"
                tipobj.style.backgroundColor = ''
                tipobj.style.width = ''
            }
        }
        document.onmousemove = positiontip
    </script>
    <script language="javascript" type="text/javascript">
        function ShowAlert(msg) {
            alert(msg);
        }
        var buttonObj;
        var confirmValue = false;
        function Conformdelete(btn) {
            if (!confirmValue) {
                buttonObj = btn;
                radconfirm('Are you sure you want to cancel this appointment ?', confirmCallBackFn, 380, 100, null, "Exam cancel confirmation"); return false;
            }
        }
        function confirmCallBackFn(arg) {
            if (arg) {
                confirmValue = true;
                buttonObj.click();
                confirmValue = false;
            }
        }
        var buttonSchedule;
        var buttonconfirmValue = false;
        function ConfirmSchedule(btn) {
            if (!buttonconfirmValue) {
                buttonSchedule = btn;
                var type = '';
                if (buttonSchedule.value == "Schedule")
                    type = "schedule";

                else if (buttonSchedule.value == "Reschedule")
                    type = "reschedule";

                else if (buttonSchedule.value == "Reschedule Exam")
                    type = "reschedule";
                else
                    type = "schedule";

                radconfirm('Are you sure you want to' + '  ' + type + ' ' + ' this appointment?', ScheduleconfirmCallBackFn, 400, 150, null, "Exam" + " " + type + " " + " confirmation");
                return false;
            }
        }

        function ScheduleconfirmCallBackFn(arg) {
            if (arg) {
                buttonconfirmValue = true;
                buttonSchedule.click();
                buttonconfirmValue = false;
            }
        }


    </script>
    <asp:HiddenField ID="hdExamID" runat="server" />
    <div class="app_container_inner">
        <div class="app_inner_content">

            <telerik:RadWindowManager ID="RadWindowManager1" ir="rdM1" runat="server" Localization-Cancel="No" Localization-OK="Yes" EnableShadow="true" Skin="Metro"></telerik:RadWindowManager>

            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpScheduling">
                <ProgressTemplate>
                    <div style="text-align: center; background-color: White; position: absolute;top: 50%;left: 50%; margin: -50px 0px 0px -50px;">
                        <asp:Image ID="ImgLoader" runat="server" ImageUrl="~/Images/loading.gif" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:UpdatePanel ID="UpScheduling" runat="server">
                <ContentTemplate>
                    <asp:HiddenField ID="hdTransactionID" runat="server" />
                    <asp:HiddenField ID="hdExamDate" runat="server" />
                    <asp:HiddenField ID="hd_1200AM" runat="server" />
                    <asp:HiddenField ID="hd_1230AM" runat="server" />
                    <asp:HiddenField ID="hd_0100AM" runat="server" />
                    <asp:HiddenField ID="hd_0130AM" runat="server" />
                    <asp:HiddenField ID="hd_0200AM" runat="server" />
                    <asp:HiddenField ID="hd_0230AM" runat="server" />
                    <asp:HiddenField ID="hd_0300AM" runat="server" />
                    <asp:HiddenField ID="hd_0330AM" runat="server" />
                    <asp:HiddenField ID="hd_0400AM" runat="server" />
                    <asp:HiddenField ID="hd_0430AM" runat="server" />
                    <asp:HiddenField ID="hd_0500AM" runat="server" />
                    <asp:HiddenField ID="hd_0530AM" runat="server" />
                    <asp:HiddenField ID="hd_0600AM" runat="server" />
                    <asp:HiddenField ID="hd_0630AM" runat="server" />
                    <asp:HiddenField ID="hd_0700AM" runat="server" />
                    <asp:HiddenField ID="hd_0730AM" runat="server" />
                    <asp:HiddenField ID="hd_0800AM" runat="server" />
                    <asp:HiddenField ID="hd_0830AM" runat="server" />
                    <asp:HiddenField ID="hd_0900AM" runat="server" />
                    <asp:HiddenField ID="hd_0930AM" runat="server" />
                    <asp:HiddenField ID="hd_1000AM" runat="server" />
                    <asp:HiddenField ID="hd_1030AM" runat="server" />
                    <asp:HiddenField ID="hd_1100AM" runat="server" />
                    <asp:HiddenField ID="hd_1130AM" runat="server" />
                    <asp:HiddenField ID="hd_1200PM" runat="server" />
                    <asp:HiddenField ID="hd_1230PM" runat="server" />
                    <asp:HiddenField ID="hd_0100PM" runat="server" />
                    <asp:HiddenField ID="hd_0130PM" runat="server" />
                    <asp:HiddenField ID="hd_0200PM" runat="server" />
                    <asp:HiddenField ID="hd_0230PM" runat="server" />
                    <asp:HiddenField ID="hd_0300PM" runat="server" />
                    <asp:HiddenField ID="hd_0330PM" runat="server" />
                    <asp:HiddenField ID="hd_0400PM" runat="server" />
                    <asp:HiddenField ID="hd_0430PM" runat="server" />
                    <asp:HiddenField ID="hd_0500PM" runat="server" />
                    <asp:HiddenField ID="hd_0530PM" runat="server" />
                    <asp:HiddenField ID="hd_0600PM" runat="server" />
                    <asp:HiddenField ID="hd_0630PM" runat="server" />
                    <asp:HiddenField ID="hd_0700PM" runat="server" />
                    <asp:HiddenField ID="hd_0730PM" runat="server" />
                    <asp:HiddenField ID="hd_0800PM" runat="server" />
                    <asp:HiddenField ID="hd_0830PM" runat="server" />
                    <asp:HiddenField ID="hd_0900PM" runat="server" />
                    <asp:HiddenField ID="hd_0930PM" runat="server" />
                    <asp:HiddenField ID="hd_1000PM" runat="server" />
                    <asp:HiddenField ID="hd_1030PM" runat="server" />
                    <asp:HiddenField ID="hd_1100PM" runat="server" />
                    <asp:HiddenField ID="hd_1130PM" runat="server" />

                    <table cellpadding="2" cellspacing="0" width="100%" border="0">
                        <tr>
                            <td align="left">
                                <asp:Image ID="imgHead" runat="server" ImageUrl="../Images/ImgScheduleExam1.png" AlternateText="Schedule/Reschedule Exam" title="Schedule/Reschedule Exam" />
                            </td>
                        </tr>

                        <tr id="trProfileMsg" runat="server">
                            <td align="center">
                                <asp:Label ID="lblMyprofile" runat="server" CssClass="messages"></asp:Label>

                            </td>
                        </tr>
                        <tr runat="server" id="tblContent">
                            <td>
                                <table cellpadding="2" cellspacing="0" width="100%" border="0">
                                    <tr>
                                        <td>
                                            <table cellpadding="0" cellspacing="6">
                                                <tr>
                                                    <td width="20px;">&nbsp;</td>
                                                    <td width="12px;">
                                                        <div style="width: 13px; height: 13px; border: 1px solid #ccc; background: #fff;"></div>
                                                    </td>
                                                    <td align="left" width="30">Available</td>
                                                    <td width="5px;">&nbsp;</td>
                                                    <td width="12px;">
                                                        <div style="width: 13px; height: 13px; border: 1px solid #ccc; background: #CCCCCC;"></div>
                                                    </td>
                                                    <td align="left" width="30">Unavailable</td>
                                                    <td width="5px;">&nbsp;</td>
                                                    <td width="12px;">
                                                        <div style="width: 13px; height: 13px; border: 1px solid #ccc; background: #00ff21;"></div>
                                                    </td>
                                                    <td align="left" width="30">Scheduled</td>
                                                </tr>

                                            </table>
                                        </td>
                                    </tr>
                                    <tr id="trOndemand" runat="server" visible="false">
                                        <td align="right" valign="top" class="messages" colspan="3">
                                            <asp:Label ID="lblOndemand" runat="server" Text="On-demand scheduling "></asp:Label>&nbsp;&nbsp;
                                 <telerik:RadButton ID="btnOnDemand" runat="server" ButtonType="ToggleButton" ToggleType="CheckBox"
                                     AutoPostBack="true" ForeColor="Black" Checked="true" Skin="Web20" Width="77" Height="19" title="Please click here to Enable/Disable the On-Demand setting" OnClick="btnOnDemand_Click">
                                     <ToggleStates>
                                         <telerik:RadButtonToggleState Value="ON" ImageUrl="../Images/ImgOn.png" HoveredImageUrl="../Images/ImgOn.png"
                                             Text="ON" Width="77" Height="19"></telerik:RadButtonToggleState>
                                         <telerik:RadButtonToggleState Value="OFF" ImageUrl="../Images/ImgOff.png" HoveredImageUrl="../Images/ImgOff.png"
                                             Text="OFF" Selected="true" Width="77" Height="19"></telerik:RadButtonToggleState>
                                     </ToggleStates>
                                 </telerik:RadButton>
                                            <br />
                                            <div style="padding-top: 5px;">
                                                <asp:Label ID="lblOndemandAlert" runat="server" ForeColor="Blue" Font-Size="10" Text="Use the on-demand scheduling option to take test within 24 hours. "></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table cellpadding="6" cellspacing="2" width="100%" border="0" style="border: 1px solid #ccc;">
                                                <tr>
                                                    <td valign="top">
                                                        <div><strong class="messages">To</strong> <strong class="messages_Black">SCHEDULE </strong><strong class="messages">an Exam: </strong></div>
                                                        <ul class="messagesDetails">
                                                            <li>Select Instructor, Course and Exam.</li>
                                                            <li>Select Date and Time.</li>
                                                            <li>Click "Schedule."</li>

                                                        </ul>
                                                    </td>

                                                    <td style="border-right: 1px solid #ccc; border-left: 1px solid #ccc;" valign="top">
                                                        <div><strong class="messages">To</strong><strong class="messages_Black"> RESCHEDULE </strong><strong class="messages">an Exam: </strong></div>
                                                        <ul class="messagesDetails">
                                                            <li>Click "Reschedule Exam." </li>
                                                            <li>Select new Date and Time.</li>
                                                            <li>Click "Reschedule."</li>
                                                        </ul>
                                                    </td>
                                                    <td valign="top">
                                                        <div><strong class="messages">To</strong> <strong class="messages_Black">CANCEL </strong><strong class="messages">an Exam: </strong></div>
                                                        <ul class="messagesDetails">
                                                            <li>Click "Cancel Appointment."</li>
                                                            <li>Yes in pop-up message.</li>
                                                        </ul>
                                                    </td>

                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">&nbsp;</td>
                                    </tr>
                                    <tr>

                                        <td colspan="3">
                                            <table width="100%" cellpadding="0" cellspacing="0" border="1" style="border-color: #f1f1f1;">
                                                <tr class="table_header_Grid" style="background: url(../Images/blueshade.png) repeat-x; line-height: 20px;">
                                                    <td width="20%" align="center">
                                                        Instructor Name
                                                    </td>
                                                    <td width="20%" align="center">
                                                        Course Name
                                                    </td>
                                                    <td width="20%" align="center">
                                                        Exam Name
                                                    </td>
                                                    <td width="10%" align="center">
                                                        Exam Duration
                                                    </td>
                                                    <td width="30%" align="center">
                                                        Exam can be scheduled between
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td valign="bottom" align="center" style="padding: 5px;">
                                                        <asp:Label ID="lblInstructor" runat="server"></asp:Label>
                                                        <telerik:RadComboBox runat="server" ID="drpInstructor" AppendDataBoundItems="true" OnSelectedIndexChanged="drpInstructor_SelectedIndexChanged" AutoPostBack="true"
                                                            DropDownAutoWidth="Enabled" Skin="Web20">
                                                        </telerik:RadComboBox>
                                                        <br />
                                                        <asp:RequiredFieldValidator ID="RfInstructor" runat="server" Display="Dynamic"
                                                            ControlToValidate="drpInstructor" InitialValue="--Select Instructor--" ErrorMessage="Select Instructor"
                                                            ValidationGroup="Val"> </asp:RequiredFieldValidator>
                                                    </td>
                                                    <td valign="bottom" align="center" style="padding: 5px;">
                                                        <asp:Label ID="lblCourse" runat="server"></asp:Label>
                                                        <telerik:RadComboBox runat="server" ID="drpCourse" AppendDataBoundItems="true" OnSelectedIndexChanged="drpCourse_SelectedIndexChanged" AutoPostBack="true"
                                                            DropDownAutoWidth="Enabled" Skin="Web20">
                                                        </telerik:RadComboBox>
                                                        <br />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" Display="Dynamic"
                                                            ControlToValidate="drpCourse" InitialValue="--Select course--" ErrorMessage="Select Course name"
                                                            ValidationGroup="Val"> </asp:RequiredFieldValidator>
                                                    </td>
                                                    <td valign="bottom" align="center" style="padding: 5px;">
                                                        <asp:Label ID="lblExam" runat="server"></asp:Label>
                                                        <telerik:RadComboBox runat="server" ID="drpExam" AutoPostBack="true"
                                                            AppendDataBoundItems="true" DropDownAutoWidth="Enabled" Skin="Web20" OnSelectedIndexChanged="drpExam_SelectedIndexChanged">
                                                        </telerik:RadComboBox>
                                                        <br />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                                                            ControlToValidate="drpExam" InitialValue="--Select exam--" ErrorMessage="Select Exam name"
                                                            ValidationGroup="Val"> </asp:RequiredFieldValidator>
                                                    </td>
                                                    <td valign="bottom" align="center" style="padding: 5px;">
                                                        <asp:Label ID="lblExamDuration" runat="server"></asp:Label>
                                                    </td>
                                                    <td valign="bottom" align="center" style="padding: 5px;">
                                                        <asp:Literal ID="lblStartDate" runat="server"></asp:Literal>
                                                        <asp:Label ID="lblEndDate" runat="server"></asp:Label>
                                                    </td>

                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr id="trMessage" runat="server">
                                        <td colspan="3" align="center">
                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td align="center" style="padding: 10px;">
                                                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">&nbsp;</td>
                                    </tr>
                                    <tr id="trNonProctor" runat="server" visible="false">
                                        <td align="center" colspan="3" style="padding: 10px;">
                                            <%-- <asp:Label ID="lblTakeTestMsg" runat="server" Text="You will be authenticated, without a live proctor." Font-Size="Small"></asp:Label><br /><br />--%>
                                            <asp:Button ID="btnTakeTest" runat="server" OnClick="btnTakeTest_Click" Text="Schedule" class="button_new orange" OnClientClick="return ConfirmSchedule(this);" />
                                        </td>
                                    </tr>

                                    <tr id="trNonProctorReschedule" runat="server" visible="false">
                                        <td align="center" colspan="3" style="padding: 10px;">
                                           
                                            <asp:Button ID="btnNonProctorReschedule" runat="server" OnClick="btnNonProctorReschedule_Click" Text="Reschedule Exam" class="button_new orange" OnClientClick="return ConfirmSchedule(this);" />
                                            &nbsp;&nbsp;
                                <asp:Button ID="btnNonProctorCancel" runat="server" OnClick="btnNonProctorCancel_Click" Text="Cancel Appointment" class="button_new orange" OnClientClick="return Conformdelete(this);" />
                                        </td>
                                    </tr>


                                    <tr id="trWithProctor" runat="server" visible="false">
                                        <td>
                                            <table>
                                                <tr>
                                                    <td align="right" valign="top" width="400px">
                                                        <telerik:RadCalendar runat="server" ID="calSchedular" Skin="Web20" EnableMultiSelect="false"
                                                            PresentationType="Interactive" DayNameFormat="FirstTwoLetters" EnableNavigation="true"
                                                            FirstDayOfWeek="Sunday" ShowFastNavigationButtons="true" ShowRowHeaders="false"
                                                            EnableKeyboardNavigation="true"
                                                            AutoPostBack="true" OnSelectionChanged="calSchedular_SelectedIndexChanged">
                                                        </telerik:RadCalendar>
                                                    </td>
                                                    <td width="50px">
                                                        &nbsp;
                                                    </td>
                                                    <td align="left" valign="top">
                                                        <table class="cal-table" style="width: 600px;" cellpadding="0">
                                                            <caption class="cal-caption">
                                                                Select Time
                                                            </caption>
                                                            <tbody class="cal-body">
                                                                <tr>
                                                                    <td>
                                                                        <div id="div_1200AM" runat="server">
                                                                            12:00 AM
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div id="div_1230AM" runat="server">
                                                                            12:30 AM
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div id="div_0100AM" runat="server">
                                                                            01:00 AM
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div id="div_0130AM" runat="server">
                                                                            01:30 AM
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div id="div_0200AM" runat="server">
                                                                            02:00 AM
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div id="div_0230AM" runat="server">
                                                                            02:30 AM
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div id="div_0300AM" runat="server">
                                                                            03:00 AM
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div id="div_0330AM" runat="server">
                                                                            03:30 AM
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <div id="div_0400AM" runat="server">
                                                                            04:00 AM
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div id="div_0430AM" runat="server">
                                                                            04:30 AM
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div id="div_0500AM" runat="server">
                                                                            05:00 AM
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div id="div_0530AM" runat="server">
                                                                            05:30 AM
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div id="div_0600AM" runat="server">
                                                                            06:00 AM
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div id="div_0630AM" runat="server">
                                                                            06:30 AM
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div id="div_0700AM" runat="server">
                                                                            07:00 AM
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div id="div_0730AM" runat="server">
                                                                            07:30 AM
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <div id="div_0800AM" runat="server">
                                                                            08:00 AM
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div id="div_0830AM" runat="server">
                                                                            08:30 AM
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div id="div_0900AM" runat="server">
                                                                            09:00 AM
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div id="div_0930AM" runat="server">
                                                                            09:30 AM
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div id="div_1000AM" runat="server">
                                                                            10:00 AM
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div id="div_1030AM" runat="server">
                                                                            10:30 AM
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div id="div_1100AM" runat="server">
                                                                            11:00 AM
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div id="div_1130AM" runat="server">
                                                                            11:30 AM
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <div id="div_1200PM" runat="server">
                                                                            12:00 PM
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div id="div_1230PM" runat="server">
                                                                            12:30 PM
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div id="div_0100PM" runat="server">
                                                                            01:00 PM
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div id="div_0130PM" runat="server">
                                                                            01:30 PM
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div id="div_0200PM" runat="server">
                                                                            02:00 PM
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div id="div_0230PM" runat="server">
                                                                            02:30 PM
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div id="div_0300PM" runat="server">
                                                                            03:00 PM
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div id="div_0330PM" runat="server">
                                                                            03:30 PM
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <div id="div_0400PM" runat="server">
                                                                            04:00 PM
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div id="div_0430PM" runat="server">
                                                                            04:30 PM
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div id="div_0500PM" runat="server">
                                                                            05:00 PM
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div id="div_0530PM" runat="server">
                                                                            05:30 PM
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div id="div_0600PM" runat="server">
                                                                            06:00 PM
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div id="div_0630PM" runat="server">
                                                                            06:30 PM
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div id="div_0700PM" runat="server">
                                                                            07:00 PM
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div id="div_0730PM" runat="server">
                                                                            07:30 PM
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <div id="div_0800PM" runat="server">
                                                                            08:00 PM
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div id="div_0830PM" runat="server">
                                                                            08:30 PM
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div id="div_0900PM" runat="server">
                                                                            09:00 PM
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div id="div_0930PM" runat="server">
                                                                            09:30 PM
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div id="div_1000PM" runat="server">
                                                                            10:00 PM
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div id="div_1030PM" runat="server">
                                                                            10:30 PM
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div id="div_1100PM" runat="server">
                                                                            11:00 PM
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div id="div_1130PM" runat="server">
                                                                            11:30 PM
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        &nbsp;
                                                    </td>
                                                    <td align="center">
                                                        <asp:Button ID="btnSchedule" runat="server" OnClick="btnSchedule_Click" Text="Schedule" class="button_new orange" OnClientClick="return ConfirmSchedule(this);" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>

                                    </tr>
                                    <tr id="trRescheduleOrCancel" runat="server" visible="false">
                                        <td align="center">
                                            <table>
                                                <%--<tr id="trRescheduleMsg" runat="server" visibale="false">
                                      <td>
                                          <asp:Label ID="lblRescheduleMsg" runat="server" Font-Size="Small"></asp:Label>
                                      </td>
                                  </tr>--%>
                                                <tr>
                                                    <td align="center" colspan="3" style="padding: 10px;">
                                                        <asp:Button ID="btnReschedule" runat="server" OnClick="btnReschedule_Click" Text="Reschedule Exam" class="button_new orange" />
                                                        &nbsp;&nbsp;
                                <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel Appointment" class="button_new orange" OnClientClick="return Conformdelete(this);" />

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
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

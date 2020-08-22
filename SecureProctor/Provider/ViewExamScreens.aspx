<%@ Page Title="" Language="C#" MasterPageFile="~/Provider/Provider.Master" AutoEventWireup="true"
    CodeBehind="ViewExamScreens.aspx.cs" Inherits="SecureProctor.Provider.ViewExamScreens" %>

<%@ Register TagPrefix="uc" TagName="rules" Src="~/Rules.ascx" %>
<%@ Register TagPrefix="uc" TagName="uploadfiles" Src="~/GetStudentUploadFiles.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ExamProviderContent" runat="server">
    <script src="../js/jquery-1.9.1.js"></script>
    <script src="https://prod.examity.com/commonfiles/video.js"></script>
    <link href="https://prod.examity.com/commonfiles/video-js.css" rel="stylesheet" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
    <style type="text/css">
        a img {
            border: 0;
        }

        #largeImage {
            position: absolute;
            padding: 8px;
            background-color: #e3e3e3;
            border: 1px solid #bfbfbf;
            width: 500px;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(
            function () {
                var transid = '<%= Request.QueryString["TransID"].ToString() %>'
                 var clientname = '<%= ConfigurationManager.AppSettings["clientname"] %>'
                 var requesturl = '<%= ConfigurationManager.AppSettings["RackServiceURL"] %>'
                 var VideoURL = requesturl + 'transId=' + transid + '&containerName=' + clientname
                 $.ajax({
                     type: "GET",
                     url: VideoURL,
                     datatype: 'json',
                     success: function (data) {
                         $("#myvideo1").attr('src', data.cdnURLQResult);
                         if (data.cdnURLQResult != 'NA')
                             $("#Examvideo").load();
                         else
                             $('#vimg').attr('src', 'https://prod.examity.com/commonfiles/examitynovideo.png');
                     },
                     error: function (a, b, c) {
                         alert(a.statusText);
                     }
                 });
             });
        function moveToIncident(timeStamp) {

            var myvideo = document.getElementById('Examvideo');

            if (myvideo) {
                var timeArr = timeStamp.split(':');

                var hours = Number(timeArr[0]) * 60 * 60;
                var min = Number(timeArr[1]) * 60;
                var sec = Number(timeArr[2]);

                var seek = hours + min + sec;
                myvideo.currentTime = seek;

                $('#examity').hide();
                $('#Examvideo').removeAttr("style");

                myvideo.play();
            }
            return false;
        }

    </script>
    <script type="text/javascript">
    <!--
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
    //-->

    function Mouseover() {
        $(function () {
            var offsetX = 20;
            var offsetY = 10;
            $('a.hover').hover(function (e) {
                var src = $(this).attr('href');
                var href = src.replace("~", '..');
                // alert(href);
                $('<img id="largeImage" src="' + href + '" alt="image" />')
                    .css({ 'top': e.pageY + offsetY, 'left': e.pageX + offsetX })
                    .appendTo('body');
            }, function () {
                $('#largeImage').remove();
            });
            $('a.hover').mousemove(function (e) {
                $('#largeImage').css({ 'top': e.pageY + offsetY, 'left': e.pageX + offsetX });
            });
            $('a.hover').click(function (e) {
                e.preventDefault();
            });
        });
    }
    </script>

    <script type="text/javascript">
        var OSName = "Unknown OS";
        if (navigator.appVersion.indexOf("Win") != -1) OSName = "Windows";
        if (navigator.appVersion.indexOf("Mac") != -1) OSName = "MacOS";
        if (navigator.appVersion.indexOf("X11") != -1) OSName = "UNIX";
        if (navigator.appVersion.indexOf("Linux") != -1) OSName = "Linux";
    </script>
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>


            <td>
                <telerik:RadGrid ID="gvexamdetails" runat="server" OnNeedDataSource="gvexamdetails_NeedDataSource"
                    AutoGenerateColumns="False" Skin="<%$ Resources:SecureProctor,Telerik_Grid_Skin %>"
                    CellSpacing="0" GridLines="None">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn DataField="TransID" HeaderText="Exam ID"
                                UniqueName="TransID" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle Font-Bold="true" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Name" HeaderText="Student Name"
                                UniqueName="Name" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle Font-Bold="true" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CourseName" HeaderText="Course Name"
                                UniqueName="CourseName" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle Font-Bold="true" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ExamName" HeaderText="Exam Name"
                                UniqueName="ExamName" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle Font-Bold="true" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ExamDate" HeaderText="Exam Date"
                                UniqueName="ExamDate" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle Font-Bold="true" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TimeDuration" HeaderText="Exam Time"
                                UniqueName="TimeDuration" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle Font-Bold="true" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="StatusName" HeaderText="Status"
                                UniqueName="StatusName" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle Font-Bold="true" />
                            </telerik:GridBoundColumn>


                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="100%" align="center">
                    <tr>
                        <td valign="top" align="center" width="34%">
                            <asp:Label ID="lblProfileImage" runat="server" Text="Profile Image" Font-Size="Medium"></asp:Label>
                            <br />
                            <br />
                            <asp:Image ID="img" runat="server" Width="320" ImageAlign="Right" ImageUrl="~/Images/noimage.jpg" />
                        </td>
                        <td align="left" id="trNonProctorImages" runat="server" width="66%" valign="top">
                            <table>
                                <tr>
                                    <td align="center" valign="top">
                                        <asp:Label ID="lblCapturedImage" runat="server" Text="Photo" Font-Size="Medium"></asp:Label>
                                        <br />
                                        <br />
                                        <img id="imgPLExamPic" runat="server" src="~/Images/noimage.jpg" />
                                        <br />
                                        <br />

                                        <asp:Label ID="lblPic1TimeStamp" runat="server"></asp:Label>
                                    </td>
                                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                    <td align="center" valign="top">
                                        <asp:Label ID="lblPhotoID" runat="server" Text="Photo ID" Font-Size="Medium"></asp:Label>
                                        <br />
                                        <br />
                                        <img id="imgPLExamPic1" runat="server" src="~/Images/noimage.jpg" />
                                        <br />
                                        <br />

                                        <asp:Label ID="lblPic2TimeStamp" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>

            </td>

        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td colspan="2">
                            <uc:rules ID="ucRules" runat="server" DisplayFrom="PROCTOR" />

                        </td>
                    </tr>
                </table>
            </td>
        </tr>

        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td colspan="2">


                            <uc:uploadfiles ID="ucUploadFiles" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>



        <tr>
            <td>
                <table width="100%" cellpadding="1" cellspacing="1">
                    <%--<tr>
                     
                        <td width="100%" align="center">
                            <asp:Image ID="pro_Image2" runat="server" ImageUrl="~/Images/desktopview.png" />
                        </td>
                    </tr>--%>
                    <tr>

                        <td align="center" id="tdDesktop" runat="server" width="100%" style="display: none;"></td>
                    </tr>
                    <tr id="trVideoPlayer" runat="server">
                        <td align="center" width="100%">
                            <div id="examity" style="cursor: pointer;">
                                <img src="https://prod.examity.com/commonfiles/examity_videobg.png" id="vimg">
                            </div>
                            <video id="Examvideo" controls="controls" class="video-js vjs-default-skin"
                                width='800' height='500' poster="https://prod.examity.com/commonfiles/examity.png" style="display: none">
                                                <source id="myvideo1" type='video/mp4'>
                                            </video>
                            <script>
                                $("#examity").click(function () {
                                    $('#examity').hide();
                                    $('#Examvideo').removeAttr("style");
                                    var strSrc = $('#myvideo1').attr('src');
                                    if (strSrc != 'NA') {
                                        $('#Examvideo').get(0).play();
                                    }
                                    else {
                                        $('#Examvideo').hide();
                                        $('#vimg').attr('src', 'https://prod.examity.com/commonfiles/examitynovideo.png');
                                        $('#examity').show();
                                    }
                                });
                            </script>
                        </td>
                    </tr>
                    <tr id="fullScreenHint">
                        <td align="center">
                            <%--<strong>Note </strong>: Double Click on media player to enlarge--%>
                        </td>

                    </tr>
                    <tr valign="top" id="trExamLevel" runat="server">
                        <td align="middle" valign="middle">



                            <strong><%=Resources.ResMessages.Common_FairExamLevel %></strong> &nbsp;:&nbsp; 
                <asp:Label ID="lblExamLevel" runat="server"></asp:Label>


                        </td>

                    </tr>
                    <tr>
                        <td align="center">
                            <br />
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td align="middle" valign="middle">
                            <asp:Label ID="lblKeyScoretext" runat="server" Text="<strong>examiKEY <sup>®</sup> : </strong>"></asp:Label>


                            <asp:Label ID="lblKeyScore" runat="server" Font-Bold="true" ForeColor="#000099"></asp:Label>
                        </td>
                    </tr>
                    <tr id="Tr1">
                        <td align="center">&nbsp;
                        </td>

                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="upComments" runat="server" UpdateMode="Conditional">

                    <ContentTemplate>
                        <script type="text/javascript"> Sys.Application.add_load(Mouseover); </script>
                        <table width="100%" cellpadding="1" cellspacing="1">
                            <tr>
                                <td align="center">
                                    <telerik:RadGrid ID="gvComments" runat="server" OnNeedDataSource="gvComments_NeedDataSource"
                                        AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" Skin="<%$ Resources:SecureProctor,Telerik_Grid_Skin %>"
                                        CellSpacing="0" GridLines="None">
                                        <GroupingSettings CaseSensitive="false" />
                                        <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD">
                                            <Columns>
                                                <telerik:GridTemplateColumn HeaderText="<%$ Resources:SecureProctor,Common_Flag %>"
                                                    HeaderStyle-HorizontalAlign="Center" DataField="FlagImage" SortExpression="FlagImage"
                                                    UniqueName="FlagImage">
                                                    <ItemTemplate>
                                                        <asp:Image ID="imgFlag" runat="server" ImageUrl='<%# Eval("FlagImage")%>' />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                    <HeaderStyle Font-Bold="true" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn DataField="AlertText" HeaderText="Description"
                                                    SortExpression="AlertText" UniqueName="AlertText" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                    <HeaderStyle Font-Bold="true" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Comments" HeaderText="<%$ Resources:SecureProctor,Common_Comments %>"
                                                    SortExpression="Comments" UniqueName="Comments" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" Width="40%" />
                                                    <HeaderStyle Font-Bold="true" />
                                                </telerik:GridBoundColumn>

                                                <telerik:GridTemplateColumn HeaderText="Captured Image"
                                                    HeaderStyle-HorizontalAlign="Center" DataField="isvisable"
                                                    UniqueName="imgAlert" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <a href='<%# Eval("AlterImage")%>' class="hover">
                                                            <asp:Image ID="imgAlert" runat="server" Width="50px" ImageUrl='<%# Eval("AlterImage")%>' Visible='<%# Convert.ToBoolean(Eval("isvisable")) %>' />
                                                        </a>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                    <HeaderStyle Font-Bold="true" />
                                                </telerik:GridTemplateColumn>

                                                <%--  <telerik:GridBoundColumn DataField="CommentTime" HeaderText="<%$ Resources:SecureProctor,Common_CommentTime %>"
                                                    SortExpression="CommentTime" UniqueName="Comments" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                    <HeaderStyle Font-Bold="true" />
                                                </telerik:GridBoundColumn>--%>

                                                <telerik:GridTemplateColumn HeaderText="<%$ Resources:SecureProctor,Common_CommentTime %>" DataField="CommentTime" UniqueName="Comments"
                                                    SortExpression="CommentTime" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                    <HeaderStyle Font-Bold="true" />
                                                    <ItemTemplate>
                                                     <u>   <a href='#' onclick="return moveToIncident('<%# Eval("CommentTime")%>')"><%# Eval("CommentTime")%></a></u>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>


                                                <telerik:GridBoundColumn DataField="AddedBy" HeaderText="<%$ Resources:SecureProctor,Common_AddedBy %>"
                                                    SortExpression="AddedBy" UniqueName="AddedBy" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                    <HeaderStyle Font-Bold="true" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="AddedOn" HeaderText="<%$ Resources:SecureProctor,Common_AddedOn %>"
                                                    SortExpression="AddedOn" UniqueName="AddedOn" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                    <HeaderStyle Font-Bold="true" />
                                                </telerik:GridBoundColumn>
                                                <%-- <telerik:GridTemplateColumn>
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgEdit" runat="server" ImageUrl="~/Images/edit_s.gif" CommandName="EDIT" CommandArgument='<%# Eval("CommentID")%>'  Visible='<%# Convert.ToBoolean(Eval("EditStatus")) %>'/>&nbsp;&nbsp;
                                                                            <asp:ImageButton ID="ImgDelete" runat="server" ImageUrl="~/Images/delete_s.gif" CommandName="DELETE" CommandArgument='<%# Eval("CommentID")%>' />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                        <HeaderStyle Width="10%" />
                                                                    </telerik:GridTemplateColumn>--%>
                                            </Columns>
                                            <%-- <EditFormSettings EditFormType="Template">
                                                                    <FormTemplate>
                                                                        <table width="100%" cellpadding="5" cellspacing="5">
                                                                            <tr>
                                                                                <td align="right" style="width:20%">
                                                                                    <asp:Label ID="lblDesc" Text="Comments : " runat="server"></asp:Label>
                                                                                </td>
                                                                                <td align="left" style="width:20%">
                                                                                    <telerik:RadTextBox ID="txtRuleDescription" runat="server" Skin="Web20" Text='<%# Eval("Comments")%>' Width="250px">
                                                                                    </telerik:RadTextBox>
                                                                                </td>--%>
                                            <%--<td align="right"></td>--%>
                                            <%--  <td align="left" colspan="2">
                                                                                    <asp:ImageButton ID="ImgRuleUpdate" runat="server" ImageUrl="~/Images/icon_update.png"
                                                                                        CommandName="Update" CommandArgument='<%# Eval("CommentID")%>' />&nbsp;&nbsp;&nbsp;
                                                                                <asp:ImageButton ID="ImgRuleCancel" runat="server" ImageUrl="~/Images/icon_cancel.png"
                                                                                    CommandName="Cancel" />
                                                                                </td>--%>
                                            <%--      </tr>
                                                                            <tr>
                                                                                
                                                                            </tr>
                                                                        </table>
                                                                    </FormTemplate>
                                                                </EditFormSettings>--%>
                                            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                        </MasterTableView>
                                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                        <FilterMenu EnableImageSprites="False">
                                        </FilterMenu>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                            <tr>

                                <td>
                                    <div align="center">
                                        <telerik:RadButton ID="btnBack" runat="server" Text="Back" Skin="Web20" Width="60"
                                            OnClick="btnBack_Click">
                                        </telerik:RadButton>
                                </td>
                            </tr>
                            <%--<tr>
                                <td valign="middle">
                                    <table width="100%" >
                                        <tr>
                                            <td>
                                                <table width="100%">
                                                 <tr>
                                                        <td width="8%"><strong>Exam Flag</strong></td>
                                                        <td>:</td>
                                                        <td align="left" ><telerik:RadComboBox ID="ddlFlags" runat="server" Skin="Web20" Width="300" 
                                                    OnSelectedIndexChanged="ddlFlags_SelectedIndexChanged" AutoPostBack="true">
                                                    <Items>
                                                        <telerik:RadComboBoxItem Text="--Please select flag--"/>
                                                        <telerik:RadComboBoxItem Text="Alert" ImageUrl="../Images/ImgAlert.png" Value="4"/>
                                                      
                                                     

                                                          <telerik:RadComboBoxItem Text="No Violation" ImageUrl="../Images/flag_g.png" Value="1"/>

                                                           <telerik:RadComboBoxItem Text="Possible Violation" ImageUrl="../Images/flag_y.png" Value="2" />

                                                        <telerik:RadComboBoxItem Text="Violation" ImageUrl="../Images/flag.png" Value="3" />
                                                    </Items>
                                                </telerik:RadComboBox>
                                                <br />
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" InitialValue="--Please select--" Display="Dynamic" 
                                                    ControlToValidate="ddlFlags" ValidationGroup="submit" ErrorMessage="Please select valid response" />
                                                 </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table width="100%">
                                                    <tr>
                                                <td align="left" valign="top"  width="8%"><strong>Description</strong></td>
                                                <td valign="top">:</td>
                                                <td valign="top" align="left" >
                                                <telerik:RadComboBox ID="ddlAlerts" runat="server" Skin="Web20" Width="300" OnSelectedIndexChanged="ddlAlerts_SelectedIndexChanged"
                                                    AutoPostBack="true">
                                                </telerik:RadComboBox>
                                                <br /><br />
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidatorddlAlerts" InitialValue="--Please select--"
                                                    Display="Dynamic" ControlToValidate="ddlAlerts" ValidationGroup="submit" ErrorMessage="Please select valid response" />
                                                <telerik:RadTextBox ID="txtComments" runat="server" MaxLength="300" TextMode="MultiLine" Rows="5"
                                                    Width="100%">
                                                </telerik:RadTextBox>
                                                <br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Please add comments"
                                                    ControlToValidate="txtComments" ForeColor="Red" Enabled="false">
                                                </asp:RequiredFieldValidator>
                                                &nbsp;&nbsp;&nbsp;&nbsp;<br />
                                                <div align="center"><telerik:RadButton ID="btnBack" runat="server" Text="Back" Skin="Web20" Width="60"
                                                OnClick="btnBack_Click">
                                                </telerik:RadButton>
                                                <telerik:RadButton ID="btnAddComments" runat="server" Text="<%$ Resources:SecureProctor,Common_Add %>"
                                                    Skin="Web20" Width="60" OnClick="btnAddComments_Click" ValidationGroup="submit">
                                                </telerik:RadButton>
                                                <telerik:RadButton ID="btnClear" runat="server" Text="<%$ Resources:SecureProctor,Common_Clear%>"
                                                    Skin="Web20" Width="60" OnClick="btnClear_Click">
                                                </telerik:RadButton>
                                                    </div>
                                            </td>
                                                    </tr>
                                                </table>
                                            </td>
                                     </tr>
                                    </table>
                                </td>
                            </tr>--%>
                            <tr>
                                <td align="center">
                                    <div style="height: 100px;">
                                        &nbsp;
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                    <%--<Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnAddComments" EventName="Click" />
                    </Triggers>--%>
                </asp:UpdatePanel>
            </td>
        </tr>

    </table>

    <script type="text/javascript">
        if (OSName == "Windows") {
            document.getElementById("mpWebcamWindows").style.display = "block";
            document.getElementById("mpDesktopWindows").style.display = "block";
            document.getElementById("mpVoiceWindows").style.display = "block";
        }
        else if (OSName == "MacOS") {
            document.getElementById("fullScreenHint").style.display = "none";
            document.getElementById("mpWebcamMac").style.display = "block";
            document.getElementById("mpDesktopMac").style.display = "block";
            document.getElementById("mpVoiceMac").style.display = "block";
        }
    </script>
</asp:Content>

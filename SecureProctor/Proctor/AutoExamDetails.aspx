<%@ Page Title="" Language="C#" MasterPageFile="~/Proctor/Proctor.Master" AutoEventWireup="true" CodeBehind="AutoExamDetails.aspx.cs" Inherits="SecureProctor.Proctor.AutoExamDetails" %>

<%@ Register TagPrefix="uc" TagName="rules" Src="~/Rules.ascx" %>

<%@ Register TagPrefix="uc" TagName="uploadfiles" Src="~/GetStudentUploadFiles.ascx" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ProctorContent" runat="server">
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
		border: 1px solid #bfbfbf; width:500px; 
	}
</style> 
     <script type = "text/javascript">
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

    </script>
    <script type="text/javascript">

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

        function OpenEditComments(ID) {
            radopen("EditComments.aspx?CommentID=" + ID, "Edit Comments", 700, 400);
        }

        function closeWin() {
            var masterTable = $find("<%= gvComments.ClientID %>").get_masterTableView();
            masterTable.rebind();
        }

        </script>

    

     <script type = "text/javascript">
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
</script> 
    <style type="text/css">
        #overlay {
            position: fixed;
            z-index: 99;
            top: 0px;
            left: 0px; /*background-color: #FFFFFF;*/
            width: 100%;
            height: 100%;
            filter: Alpha(Opacity=80);
            opacity: 0.80;
            -moz-opacity: 0.80;
        }


        #theprogress {
            /*background-color: #D3BB9C;*/
            width: 110px;
            height: 24px;
            text-align: center;
            filter: Alpha(Opacity=100);
            opacity: 1;
            -moz-opacity: 1;
        }

        #modalprogress {
            position: absolute;
            top: 50%;
            left: 50%;
            margin: -11px 0 0 -55px; /*color: white;*/
        }

        body > #modalprogress {
            position: fixed;
        }


        .rbDecorated .rbText {
            text-align: left !important;
        }
    </style>
    <script type="text/javascript">

        var OSName = "Unknown OS";
        if (navigator.appVersion.indexOf("Win") != -1) OSName = "Windows";
        if (navigator.appVersion.indexOf("Mac") != -1) OSName = "MacOS";
        if (navigator.appVersion.indexOf("X11") != -1) OSName = "UNIX";
        if (navigator.appVersion.indexOf("Linux") != -1) OSName = "Linux";

        //                    function SetProgressPosition(e) {
        //                        var posx = 0;
        //                        var posy = 0;
        //                        if (!e) var e = window.event;
        //                        if (e.pageX || e.pageY) {
        //                            posx = e.pageX;
        //                            posy = e.pageY;
        //                        }
        //                        else if (e.clientX || e.clientY) {
        //                            posx = e.clientX + document.documentElement.scrollLeft;
        //                            posy = e.clientY + document.documentElement.scrollTop;
        //                        }
        //                        document.getElementById('divProgress').style.left = posx - 8 + "px";
        //                        document.getElementById('divProgress').style.top = posy - 8 + "px";
        //                    }        

        //                        if (window.innerWidth) {
        //                            dfs.left = (window.innerWidth - df.offsetWidth) / 2;
        //                            dfs.top = (window.innerHeight - df.offsetHeight) / 2;
        //                        }
        //                        else {
        //                            dfs.left = (document.body.offsetWidth - df.offsetWidth) / 2;
        //                            dfs.top = (document.body.offsetHeight - df.offsetHeight) / 2;
        //                        }
        //                    }

    </script>
    <%--<ajax:toolkitscriptmanager id="ToolkitScriptManagerNew" runat="server">
    </ajax:toolkitscriptmanager>--%>
    <table cellpadding="2" width="100%">
        <tr>
            <td>
                <img src="../Images/processedER.png" alt="validate " />
            </td>
        </tr>
        <tr>
            <td>
                <div class="login_new1">
                    <table width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="center" valign="top" colspan="4">
                                <table width="100%" cellpadding="1" cellspacing="1">
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
                                </table>
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
                            <asp:Image ID="img" runat="server" Width="320" ImageAlign="Right" ImageUrl="~/Images/noimage.jpg"/>
                        </td>
                        <td align="left" id="trNonProctorImages" runat="server" width="66%" valign="top">
                            <table>
                                <tr>
                                    <td align="center" valign="top">
                                        <asp:Label ID="lblCapturedImage" runat="server" Text="Photo" Font-Size="Medium"></asp:Label>
                                        <br />
                                        <br />
                                        <img id="imgPLExamPic" runat="server"  src="~/Images/noimage.jpg"/>
                                        <br />
                                        <br />
                                        <asp:Label ID="lblPic1TimeStamp" runat="server"></asp:Label>
                                    </td>
                                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                    <td align="center" valign="top">
                                        <asp:Label ID="lblPhotoID" runat="server" Text="Photo ID" Font-Size="Medium"></asp:Label>
                                        <br />
                                        <br />
                                        <img id="imgPLExamPic1" runat="server"  src="~/Images/noimage.jpg"/>
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
                            <td colspan="4">
                                <table width="100%">
                                    <tr>
                                        <td>

                                            <uc:rules id="ucRules" runat="server" displayfrom="PROCTOR" />

                                            <uc:uploadfiles id="ucUploadFiles" runat="server"/>




                                            <%--<telerik:RadGrid ID="gvStudentNotes" runat="server" OnNeedDataSource="gvStudentNotes_NeedDataSource"
                                                AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" Skin="<%$ Resources:SecureProctor,Telerik_Grid_Skin %>"
                                                CellSpacing="0" GridLines="None">
                                                <GroupingSettings CaseSensitive="false" />
                                                <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD">
                                                    <NoRecordsTemplate>
                                                        No records to display.
                                                    </NoRecordsTemplate>
                                                    <Columns>
                                                        <%--<telerik:GridBoundColumn DataField="NoteID" HeaderText="<%$ Resources:SecureProctor,Common_NoteID %>"
                                                            SortExpression="NoteID" UniqueName="NoteID" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridBoundColumn>--%>
                                            <%-- <telerik:GridBoundColumn DataField="NoteDesc" HeaderText="<%$ Resources:SecureProctor,Common_NoteDesc %>"
                                                            SortExpression="NoteDesc" UniqueName="NoteDesc" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridBoundColumn>
                                                    </Columns>
                                                    <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                                </MasterTableView>
                                                <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                                <FilterMenu EnableImageSprites="False">
                                                </FilterMenu>
                                            </telerik:RadGrid>--%>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        
                        <tr>
                            <td colspan="4">
                                <table width="100%" cellpadding="1" cellspacing="1">
                                 
          
                   <tr>

                                        <td align="center" id="tdDesktop" runat="server" width="100%" style="display: none;"></td>
                                    </tr>
                                    <tr id="trVideoPlayer" runat="server">
                                        <td align="center" width="100%">
                                            <div id="examity" style="cursor: pointer;">
                                                <img src="https://prod.examity.com/commonfiles/examity_videobg.png" id="vimg"></div>
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

                                    <tr  valign="top" id="trExamLevel" runat="server">
                                        <td align="middle" valign="middle">
                                            <%--<asp:CheckBox ID="chk" runat="server" />&nbsp;&nbsp;
                                        <img src="../Images/flag.png" />&nbsp;Flag a Violation--%>


                                            <strong><%=Resources.ResMessages.Common_FairExamLevel %></strong> &nbsp;:&nbsp; 
                                            <asp:Label ID="lblExamLevel" runat="server"></asp:Label>


                                        </td>
                                        <td>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <br />
                                        </td>
                                    </tr>
                                    <tr >
                                        <td align="center" valign="middle">
                                            <asp:Label ID="lblKeyScoretext" runat="server" Text="<strong>examiKEY <sup>®</sup> : </strong>" ></asp:Label>


                                            <asp:Label ID="lblKeyScore" runat="server" Font-Bold="true" ForeColor="#000099"></asp:Label>
                                        </td>
                                    </tr>
                                     
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                        </tr>
                       
                        
                        <tr style="display: none;">
                            <td>&nbsp;
                            </td>
                        </tr>
                        
                      
                        <tr>
                            <td>
                                <asp:UpdatePanel ID="upComments" runat="server">
                                  
                                    <ContentTemplate>
                                          <script type="text/javascript"> Sys.Application.add_load(Mouseover); </script>
                                        <table width="100%" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="center">
                                                    <telerik:RadGrid ID="gvComments" runat="server" OnNeedDataSource="gvComments_NeedDataSource"
                                                        AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" Skin="<%$ Resources:SecureProctor,Telerik_Grid_Skin %>"
                                                        CellSpacing="0" GridLines="None" EnableViewState="true" OnDeleteCommand="gvComments_DeleteCommand" OnItemDataBound="gvComments_ItemDataBound" OnEditCommand="gvComments_EditCommand" OnUpdateCommand="gvComments_UpdateCommand">
                                                        <GroupingSettings CaseSensitive="false" />
                                                        <MasterTableView FilterItemStyle-BackColor="#DCEDFD">
                                                            <Columns>
                                                                <telerik:GridTemplateColumn HeaderText="<%$ Resources:SecureProctor,Common_Flag %>"
                                                                    HeaderStyle-HorizontalAlign="Center" DataField="FlagImage" SortExpression="FlagImage"
                                                                    UniqueName="FlagImage" AllowFiltering="false">
                                                                    <ItemTemplate>
                                                                        <asp:Image ID="imgFlag" runat="server" ImageUrl='<%# Eval("FlagImage")%>' />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                                    <HeaderStyle Font-Bold="true" />
                                                                </telerik:GridTemplateColumn>
                                                                <telerik:GridBoundColumn DataField="Comments" HeaderText="<%$ Resources:SecureProctor,Common_Comments %>"
                                                                    SortExpression="Comments" UniqueName="Comments" HeaderStyle-HorizontalAlign="Center">
                                                                    <ItemStyle HorizontalAlign="Center" Width="35%" />
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

                                                                <telerik:GridBoundColumn DataField="CommentTime" HeaderText="<%$ Resources:SecureProctor,Common_CommentTime %>"
                                                                    SortExpression="CommentTime" UniqueName="Comments" HeaderStyle-HorizontalAlign="Center">
                                                                    <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                                    <HeaderStyle Font-Bold="true" />
                                                                </telerik:GridBoundColumn>

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
                                                                <telerik:GridTemplateColumn>
                                                                    <ItemTemplate>
                                                                        <div style="width: 100%;">
                                                                            <div style="float: left; width: 45%;">
                                                                                <asp:ImageButton ID="ImgEdit" runat="server" ImageUrl="~/Images/edit_s.gif" CommandName="EDIT" CommandArgument='<%# Eval("CommentID")%>' OnClientClick='<%# Eval("CommentID", "OpenEditComments({0});return false;") %>' />
                                                                            </div>
                                                                            <div style="float: left; width: 10%;">&nbsp;&nbsp;</div>
                                                                            <div style="float: right; width: 45%;">
                                                                                <asp:ImageButton ID="ImgDelete" runat="server" ImageUrl="~/Images/delete_s.gif" CommandName="DELETE" CommandArgument='<%# Eval("CommentID")%>' />
                                                                            </div>
                                                                            <div class="clear"></div>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                    <HeaderStyle Width="5%" />
                                                                </telerik:GridTemplateColumn>
                                                            </Columns>
                                                            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                                        </MasterTableView>
                                                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                                        <FilterMenu EnableImageSprites="False">
                                                        </FilterMenu>
                                                    </telerik:RadGrid>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" valign="middle">

                                                    <table width="100%" align="center">
                                                        <tr>
                                                            <%--<td width="10%">&nbsp;</td>--%>
                                                            <%--<td width="25%" align="left">--%>

                                                            <td width="15%"><strong>Exam Flag</strong></td>
                                                            <td>:</td>
                                                            <td align="left">
                                                                <telerik:RadComboBox ID="ddlFlags" runat="server" Skin="Web20" Width="300"
                                                                    OnSelectedIndexChanged="ddlFlags_SelectedIndexChanged" AutoPostBack="true">
                                                                    <Items>
                                                                        <telerik:RadComboBoxItem Text="--Please select flag--" />
                                                                        <telerik:RadComboBoxItem Text="Alert" ImageUrl="../Images/ImgAlert.png" Value="4" />


                                                                        <telerik:RadComboBoxItem Text="No Violation" ImageUrl="../Images/flag_g.png" Value="1" />


                                                                        <telerik:RadComboBoxItem Text="Possible Violation" ImageUrl="../Images/flag_y.png" Value="2" />

                                                                        <telerik:RadComboBoxItem Text="Violation" ImageUrl="../Images/flag.png" Value="3" />
                                                                    </Items>
                                                                </telerik:RadComboBox>

                                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidatorddlFlags" InitialValue="--Please select flag--" Display="Dynamic"
                                                                    ControlToValidate="ddlFlags" ValidationGroup="Add" ErrorMessage="Please select exam flag" />

                                                            </td>
                                                        </tr>

                                                        <tr>

                                                            <td align="left" valign="top"><strong>Incident Time Stamp</strong></td>
                                                            <td valign="top">:</td>
                                                            <td align="left" valign="top">

                                                                <telerik:RadComboBox ID="ddlHours" runat="server" AppendDataBoundItems="True" Skin="<%$ Resources:AppConfigurations,Skin_Current %>"
                                                                    Width="80" Height="200">
                                                                </telerik:RadComboBox>

                                                                <telerik:RadComboBox ID="ddlMinutes" runat="server" AppendDataBoundItems="True" Skin="<%$ Resources:AppConfigurations,Skin_Current %>"
                                                                    Width="80" Height="200">
                                                                </telerik:RadComboBox>
                                                                <telerik:RadComboBox ID="ddlsec" runat="server" AppendDataBoundItems="True" Skin="<%$ Resources:AppConfigurations,Skin_Current %>"
                                                                    Width="80" Height="200">
                                                                </telerik:RadComboBox>

                                                            </td>

                                                        </tr>






                                                        <tr>
                                                            <td align="left" valign="top"><strong>Description</strong></td>
                                                            <td valign="top">:</td>
                                                            <td align="left" valign="top">
                                                                <telerik:RadComboBox ID="ddlAlerts" runat="server" Skin="Web20" Width="300" OnSelectedIndexChanged="ddlAlerts_SelectedIndexChanged" Filter="Contains" MarkFirstMatch="true"
                                                                    AutoPostBack="true">
                                                                </telerik:RadComboBox>
                                                                <br />
                                                                <br />
                                                                <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidatorddlAlerts" InitialValue="--Please select flag--"
                                                    Display="Dynamic" ControlToValidate="ddlAlerts" ValidationGroup="Add" ErrorMessage="Please select valid response" />--%>
                                                                <telerik:RadTextBox ID="txtComments" runat="server" MaxLength="300" TextMode="MultiLine" Rows="5"
                                                                    Width="70%">
                                                                </telerik:RadTextBox>

                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Please add comments"
                                                                    ControlToValidate="txtComments" ForeColor="Red" Enabled="false" ValidationGroup="Add">
                                                                </asp:RequiredFieldValidator>

                                                                &nbsp;&nbsp;&nbsp;&nbsp;<br />
                                                                <br />
                                                                <div align="left">
                                                                    <telerik:RadButton ID="btnBack" runat="server" Text="Back" Skin="Web20" Width="60"
                                                                        OnClick="btnBack_Click" Visible="false">
                                                                    </telerik:RadButton>
                                                                    <telerik:RadButton ID="btnAddComments" runat="server" Text="<%$ Resources:SecureProctor,Common_Add %>"
                                                                        Skin="Web20" Width="80" OnClick="btnAddComments_Click" ValidationGroup="Add">
                                                                    </telerik:RadButton>
                                                                    <telerik:RadButton ID="btnClear" runat="server" Text="<%$ Resources:SecureProctor,Common_Clear%>"
                                                                        Skin="Web20" Width="80" OnClick="btnClear_Click" Visible="false">
                                                                    </telerik:RadButton>
                                                                    <telerik:RadButton ID="btnApprove" runat="server" Text="<%$ Resources:SecureProctor,Common_Approve%>"
                                                                        Skin="Web20" Width="8%" OnClick="btnApprove_Click">
                                                                    </telerik:RadButton>
                                                                    <%-- &nbsp;&nbsp;&nbsp;--%>

                                                                    <div style="display: none;">
                                                                        <%--<telerik:RadButton ID="btnReject" runat="server" Text="<%$ Resources:SecureProctor,Common_Reject%>"
                                                                            Skin="Web20" Width="8%" OnClick="btnReject_Click">
                                                                        </telerik:RadButton>--%>
                                                                    </div>
                                                                </div>
                                                            </td>

                                                        </tr>
                                                    </table>




                                                </td>
                                        </table>
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
        <tr>
            <td align="center">
                <br />
            </td>
        </tr>
    </table>

    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="true"
                                Behaviors="Close" Skin="<%$ Resources:AppConfigurations,Skin_Current %>" OnClientClose="closeWin"
                                VisibleStatusbar="false">
                                <Windows>
                                    <telerik:RadWindow ID="RadWindow1" runat="server" ShowContentDuringLoad="false" Width="400px"
                                        Height="400px" Title="Telerik RadWindow" Behaviors="Default">
                                    </telerik:RadWindow>
                                </Windows>
                            </telerik:RadWindowManager>
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="upComments">
        <ProgressTemplate>

            <div id="overlay">
                <div id="modalprogress">
                    <div id="theprogress">
                        <img alt="indicator" src="../Images/preloader_transparent.gif" />
                        Processing...
                    </div>
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>


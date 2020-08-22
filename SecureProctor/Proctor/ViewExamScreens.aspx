<%@ Page Title="" Language="C#" MasterPageFile="~/Proctor/Proctor.Master" AutoEventWireup="true"
    CodeBehind="ViewExamScreens.aspx.cs" Inherits="SecureProctor.Proctor.ViewExamScreens" %>

<%@ Register TagPrefix="uc" TagName="rules" Src="~/Rules.ascx" %>

<%@ Register TagPrefix="uc" TagName="uploadfiles" Src="~/GetStudentUploadFiles.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProctorContent" runat="server">
      <script src="../js/jquery-1.9.1.js"></script>
    <script src="https://prod.examity.com/commonfiles/video.js"></script>
    <link href="https://prod.examity.com/commonfiles/video-js.css" rel="stylesheet" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
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
    function OpenEditComments(ID) {
        radopen("EditComments.aspx?CommentID=" + ID, "Edit Comments", 700, 400);
    }
    function closeWin() {
        var masterTable = $find("<%= gvComments.ClientID %>").get_masterTableView();
        masterTable.rebind();
    }
</script> 

    <script type="text/javascript">
        var OSName = "Unknown OS";
        if (navigator.appVersion.indexOf("Win") != -1) OSName = "Windows";
        if (navigator.appVersion.indexOf("Mac") != -1) OSName = "MacOS";
        if (navigator.appVersion.indexOf("X11") != -1) OSName = "UNIX";
        if (navigator.appVersion.indexOf("Linux") != -1) OSName = "Linux";
    </script>
  <%--  <asp:UpdatePanel ID="upMain" runat="server">
        <ContentTemplate>--%>
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
            <td >
                 
                   <table width="100%" align="center" runat="server" id="tbAutoProctor">
                       <tr>
                           <td></td>
                       </tr>
                    <tr>
                        <td valign="top" align="center" width="34%" >
                          <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                                            <ContentTemplate>--%>
                             <asp:LinkButton ID="lnkscdule" runat="server" Text="Enable schedule status" Font-Bold ="true" Font-Underline="true"  ForeColor="Blue" OnClick="lnkscdule_Click"></asp:LinkButton>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:LinkButton ID="lnkdownload" runat="server" Text="Enable download"  Font-Bold="true" Font-Underline="true" ForeColor="Blue" OnClick="lnkdownload_Click"  ></asp:LinkButton>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                           <asp:LinkButton ID="lnklaunch" runat="server" Text="Enable launch"  Font-Bold="true" Font-Underline="true" ForeColor="Blue" OnClick="lnklaunch_Click" ></asp:LinkButton>
                             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                         <%-- <asp:LinkButton ID="lnkbeginexam" runat="server" Text="Enable begin exam" Font-Bold="true" Font-Underline="true" ForeColor="Blue" OnClick="lnkbeginexam_Click" Visibl="false"></asp:LinkButton>--%>
                                                
                                               
                                           <%--  </ContentTemplate>
                                        </asp:UpdatePanel>--%>
                        </td>
                    </tr>
                </table>
                   
                            </td>
            </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td>

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
                </table>
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
                 <tr id="trExamiKEY" runat="server" visible="true">
                    <td align="middle" valign="middle">
                <asp:Label ID="lblKeyScoretext" runat="server" Text="<strong>examiKEY <sup>®</sup> : </strong>" ></asp:Label>
            
            
                <asp:Label ID="lblKeyScore" runat="server"  Font-Bold="true" ForeColor="#000099"></asp:Label>
            </td>
                </tr>
                <tr>
            <td align="center">
                <br />
            </td>
        </tr>

                 <tr>
                            <td>
                                <asp:UpdatePanel ID="upComments" runat="server">
                                    <ContentTemplate>
                                        <table width="100%" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="center">
                                                   <telerik:RadGrid ID="gvComments" runat="server" OnNeedDataSource="gvComments_NeedDataSource" AllowMultiRowSelection="true" MasterTableView-DataKeyNames="CommentID"
                                                        AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" Skin="<%$ Resources:SecureProctor,Telerik_Grid_Skin %>"
                                                        CellSpacing="0" GridLines="None" EnableViewState="true" OnDeleteCommand="gvComments_DeleteCommand" OnEditCommand="gvComments_EditCommand" OnUpdateCommand="gvComments_UpdateCommand">
                                                        <GroupingSettings CaseSensitive="false" />
                                                        <MasterTableView FilterItemStyle-BackColor="#DCEDFD">
                                                            <Columns>
                                                                <telerik:GridClientSelectColumn UniqueName="ClientSelectColumn1">
                                                                </telerik:GridClientSelectColumn>
                                                                <telerik:GridTemplateColumn HeaderText="<%$ Resources:SecureProctor,Common_Flag %>"
                                                                    HeaderStyle-HorizontalAlign="Center" DataField="FlagImage" SortExpression="FlagImage"
                                                                    UniqueName="FlagImage" AllowFiltering="false">
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
                                                                    <ItemStyle HorizontalAlign="Center" Width="35%" />
                                                                    <HeaderStyle Font-Bold="true" />
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="CommentTime" HeaderText="<%$ Resources:SecureProctor,Common_CommentTime %>"
                                                                    SortExpression="CommentTime" UniqueName="CommentsTime" HeaderStyle-HorizontalAlign="Center">
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
                                                        <ClientSettings>
                                                            <Selecting AllowRowSelect="true"></Selecting>
                                                        </ClientSettings>
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
                                                                 <div align="center">
                                                                    <telerik:radbutton id="btnBack" runat="server" text="Back" skin="Web20" width="60"
                                                                        onclick="btnBack_Click">
                                            </telerik:radbutton>
                                                                    <telerik:radbutton id="btnAddComments" runat="server" text="<%$ Resources:SecureProctor,Common_Add %>"
                                                                        skin="Web20" width="60" onclick="btnAddComments_Click" validationgroup="Add">
                                            </telerik:radbutton>
                                                                    <telerik:radbutton id="btnClear" runat="server" text="<%$ Resources:SecureProctor,Common_Clear%>"
                                                                        skin="Web20" width="60" onclick="btnClear_Click">
                                            </telerik:radbutton>
                                                                   
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
     <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="true"
        Behaviors="Close" Skin="<%$ Resources:AppConfigurations,Skin_Current %>" OnClientClose="closeWin"
        VisibleStatusbar="false">
        <Windows>
            <telerik:RadWindow ID="RadWindow1" runat="server" ShowContentDuringLoad="false" Width="400px"
                Height="400px" Title="Telerik RadWindow" Behaviors="Default">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>




</asp:Content>

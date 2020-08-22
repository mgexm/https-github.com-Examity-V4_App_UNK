<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewExam.aspx.cs" Inherits="SecureProctor.Provider.ViewExam" %>

<%@ Register TagPrefix="uc" TagName="rules" Src="~/Rules.ascx" %>
<%@ Register TagPrefix="uc" TagName="uploadfiles" Src="~/GetExamUploadedFiles.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../CSS/Common.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="../Images/secureproctor.ico" />
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
        </telerik:RadStyleSheetManager>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <table cellpadding="5" cellspacing="5" width="100%">
            <tr>
                <td>
                    <div class="heading customfont1">
                        <%=Resources.AppControls.Provider_ViewExam_Label_ViewExam%>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="login_new1">
                        <table cellpadding="0" cellspacing="2" width="100%" border="0">
                            <tr class="gridviewRowstyle">
                                <td width="45%" class="PopupLable">
                                    <strong>
                                        <%= Resources.AppControls.Provider_ViewExam_Label_CourseName %></strong>
                                </td>
                                <td width="55%" align="left">:
                                    <asp:Label ID="lblCourseName" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="gridviewAlternatestyle">
                                <td class="PopupLable">
                                    <strong>
                                        <%= Resources.AppControls.Provider_ViewExam_Label_ExamName %></strong>
                                </td>
                                <td align="left">:
                                    <asp:Label ID="lblExamName" runat="server"></asp:Label>
                                </td>
                            </tr>



                            <tr class="gridviewRowstyle">
                                <td class="PopupLable">
                                    <strong>
                                        <%= Resources.AppControls.Provider_ViewExam_Label_ExamSecurityLevel %></strong>
                                </td>
                                <td align="left">:
                                    <asp:Label ID="lblExamSecurityLevel" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="gridviewAlternatestyle">
                                <td class="PopupLable">
                                    <strong>
                                        <%= Resources.AppControls.Provider_ViewExam_Label_DurationOfExam %></strong>
                                </td>
                                <td align="left" valign="bottom">:
                                    <asp:Label ID="lblHours" runat="server" Text="<%$ Resources:AppControls,Provider_ViewExam_Label_HH %>"></asp:Label>&nbsp;
                                <asp:Label ID="lblHoursValue" runat="server"></asp:Label>
                                    &nbsp;&nbsp;:&nbsp;&nbsp;<asp:Label ID="lblMinutes" runat="server" Text="<%$ Resources:AppControls,Provider_ViewExam_Label_MM %>"></asp:Label>&nbsp;
                                <asp:Label ID="lblMinutesValue" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <%--<tr class="gridviewRowstyle">
                            <td class="PopupLable">
                                <strong>
                                    <%= Resources.AppControls.Provider_ViewExam_Label_BufferTime %></strong>:
                            </td>
                            <td align="left" valign="bottom">
                                <asp:Label ID="Label5" runat="server" Text="<%$ Resources:AppControls,Provider_ViewExam_Label_MM %>"></asp:Label>&nbsp;
                                <asp:Label ID="lblBufferTimeValue" runat="server"></asp:Label>
                            </td>
                        </tr>--%>
                            <tr class="gridviewAlternatestyle">
                                <td class="PopupLable">
                                    <strong>
                                        <%= Resources.AppControls.Provider_ViewExam_Label_ExamLinkToAccess %></strong>
                                </td>
                                <td align="left">:
                                    <asp:Label ID="lblExamLink" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="gridviewRowstyle">
                                <td class="PopupLable">
                                    <strong>
                                        <%= Resources.AppControls.Provider_ViewExam_Label_ExamStartDate %></strong>
                                </td>
                                <td align="left">:
                                    <asp:Label ID="lblExamStartDate" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="gridviewAlternatestyle">
                                <td class="PopupLable">
                                    <strong>
                                        <%= Resources.AppControls.Provider_ViewExam_Label_ExamEndDate %></strong>
                                </td>
                                <td align="left">:
                                    <asp:Label ID="lblExamEndDate" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <%--       <tr class="gridviewRowstyle">
                            <td class="PopupLable">
                                <strong>
                                    <%= Resources.AppControls.Provider_ViewExam_Label_ExamTools %></strong>
                            </td>
                            <td align="left">
                                <asp:Image ID="imgCalc" runat="server" ImageUrl="~/Images/ImgCalc.png" Height="50" />
                                <asp:CheckBox ID="chkCalc" runat="server" Text="<%$ Resources:AppControls,Provider_ViewExam_Label_Calculator %>"
                                    Enabled="false" />&nbsp;&nbsp;
                                <asp:Image ID="imgStickyNotes" runat="server" ImageUrl="~/Images/Imgstickynote.png"
                                    Height="50" />
                                <asp:CheckBox ID="chkStickynotes" runat="server" Text="<%$ Resources:AppControls,Provider_ViewExam_Label_Stickynotes %>"
                                    Enabled="false" />
                            </td>
                        </tr>--%>
                            <tr class="gridviewAlternatestyle">

                            <td class="PopupLable">

                                <strong>
                                    <asp:Label ID="lblUpload" runat="server" Text="Uploaded files"
                                        Font-Bold="true"></asp:Label>

                                </strong>
                            </td>
                            <%--<td align="left"   >
                                <asp:LinkButton ID="lnkUploadFile" runat="server" OnClick="lnkUploadFile_Click"></asp:LinkButton>
                                :
                                <asp:Label ID="lblUploadValue" runat="server"></asp:Label>
                                
                                 

                            </td>--%>
                            <td>
                                <uc:uploadfiles ID="ucUploadFiles" runat="server" />
                            </td>
                        </tr>
                              <tr class="gridviewAlternatestyle">
                                <td class="PopupLable">
                                    <strong>Exam UserName</strong>
                                </td>
                                <td align="left">:
                                    <asp:Label ID="lblExamUserName" runat="server"></asp:Label>
                                </td>
                            </tr>

                            <tr class="gridviewAlternatestyle">
                                <td class="PopupLable">
                                    <strong>Exam Password</strong>
                                </td>
                                <td align="left">:
                                    <asp:Label ID="lblExamPassword" runat="server"></asp:Label>
                                </td>
                            </tr>

                            <tr class="gridviewRowstyle">
                                <td class="PopupLable">
                                    <strong><%= Resources.AppControls.Provider_AddExam_Label_BufferTime %></strong>
                                </td>
                                <td align="left" valign="bottom">:
                                    <asp:Label ID="lblSpecialNeeds" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <%if (isLockDownBrowserFeatured() == "True")
                              { %>
                            <tr class="gridviewRowstyle">
                                <td class="PopupLable">
                                    <strong><%= Resources.AppControls.Provider_AddExam_Label_LockDownBrowser %></strong>
                                </td>
                                <td align="left" valign="bottom">:
                                    <asp:Label ID="lblLockdownBrowser" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <%} %>
                          
                             <tr class="gridviewRowstyle" id="trStudentUpload" runat="server">
                                <td class="PopupLable">
                                    <strong><%= Resources.AppControls.Provider_AddExam_Label_StudentUploadFile %></strong>
                                </td>
                               

                                    <td>
                               
                            
                                    <asp:Label ID="lblStudentUploadFile" runat="server"></asp:Label>
                                </td>
                            </tr>

                             <%if (isExamLevelFee() == "True")
                                          { %>
                                        <tr class="gridviewAlternatestyle">
                                            <td class="PopupLable">
                                                <strong>
                                                    <asp:Label ID="Label12" Text="Exam Fee Paid By"
                                                        runat="server"></asp:Label></strong>
                                            </td>
                                            <td align="left">
                                                :<asp:Label ID="lblExamFeePaidByConfirm" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr class="gridviewAlternatestyle">
                                            <td class="PopupLable">
                                                <strong>
                                                    <asp:Label ID="Label13" Text="On-demand Fee Paid By"
                                                        runat="server"></asp:Label></strong>
                                            </td>
                                            <td align="left">
                                                 :<asp:Label ID="lblondemandFeePaidByConfirm" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <%} %>
                            <tr class="gridviewAlternatestyle">
                            <td class="PopupLable">
                                <strong>
                                     <asp:Label ID="lblreusespecl" Text="<%$ Resources:AppControls,Admin_AddExam_Label_Reusespecialinstructions %>"
                                                        runat="server"></asp:Label></strong>
                            </td>
                            <td align="left">:<asp:Label ID="lblNoSpRules" runat="server"></asp:Label>
                            </td>
                        </tr>



                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <table width="100%">
                        <tr>
                            <td width="100%">
                                <uc:rules ID="ucRules" runat="server" DisplayFrom="PROCTOR" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>

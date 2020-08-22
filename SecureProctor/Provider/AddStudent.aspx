<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="SecureProctor.Provider.AddStudent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../CSS/Common.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function close() {
            window.close();
        }       
    </script>
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
                    <%=Resources.AppControls.Provider_AddStudent_Label_AddStudent%>
                </div>
            </td>
        </tr>
        <tr id="trMessage" runat="server">
            <td align="center" colspan="2">
                <table width="100%" cellpadding="0" cellspacing="2">
                    <tr>
                        <td align="center">
                            <table cellpadding="0" cellspacing="0" id="tdInfo" runat="server">
                                <tr>
                                    <td align="right" style="padding-right: 10px;">
                                        <asp:Image ID="ImgInfo" runat="server" Width="22" Height="22" />
                                    </td>
                                    <td align="left" valign="middle">
                                        <asp:Label ID="lblInfo" runat="server" CssClass="lblInfo"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="trEnrollStudent" runat="server">
            <td>
<div class="login_new1">
                    <table cellpadding="0" cellspacing="2" width="100%" border="0">
                        <tr>
<td class="PopupLable"  width="30%">
                             &nbsp;            
                            </td>
                            <td align="right">
    <asp:LinkButton ID="lnkNewStudent" runat="server" Text="Add New Student"
                            ToolTip="Click here to add new student that is not in students dropdown" Font-Bold="true" Font-Underline="true"
                            OnClick="lnkNewStudent_Click"></asp:LinkButton>

                            </td>
                        </tr>
                        <tr class="gridviewAlternatestyle">
                            <td class="PopupLable" width="30%">
                                <strong>Students</strong>
                            </td>
                            <td align="left" width="70%">
                                 <telerik:RadComboBox ID="rcbStudents" runat="server" Width="200" Height="140" Filter="Contains" MarkFirstMatch="true"
                    EmptyMessage="Select Student" DataTextField="StudentName" DataValueField="UserID">
                                     </telerik:RadComboBox>

                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please select a student"
                                    ControlToValidate="rcbStudents" ForeColor="Red" Font-Bold="true" Font-Size="X-Small"
                                    Display="Dynamic" ValidationGroup="Save1"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr class="gridviewRowstyle">
                            <td class="PopupLable">
                               <strong>Courses</strong>
                            </td>
                            <td align="left">
                                         <telerik:RadComboBox ID="rcbCourses" runat="server" Width="200" Height="140" Filter="Contains" MarkFirstMatch="true"
                    EmptyMessage="Select a course" DataTextField="CourseName" DataValueField="CourseID">
                                     </telerik:RadComboBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please select a course" 
                                    ControlToValidate="rcbCourses" ForeColor="Red" Font-Bold="true" Font-Size="X-Small"
                                    Display="Dynamic" ValidationGroup="Save1"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="30%">
                                &nbsp;

                            </td>
                             <td class="PopupButtons" align="center">
                                <telerik:RadButton ID="btnStudentSave" runat="server" Text="<%$ Resources:AppControls,Provider_AddStudent_Button_Save %>"
                                    Skin="<%$ Resources:AppConfigurations,Skin_Current %>" OnClick="btnStudentSave_Click"
                                    ValidationGroup="Save1">
                                </telerik:RadButton>
                                <telerik:RadButton ID="btnStudentCancel" runat="server" Text="<%$ Resources:AppControls,Provider_AddStudent_Button_Cancel %>"
                                    Skin="<%$ Resources:AppConfigurations,Skin_Current %>" CausesValidation="false"
                                    OnClientClicked="close">
                                </telerik:RadButton>
                            </td>
                        </tr>
                        
                        
                        
                        
                    </table>
                </div>




            </td>

        </tr>
        <tr id="trEnrollStudentConfirmation" runat="server">
            <td>
                <div class="login_new1">
                    <table cellpadding="0" cellspacing="2" width="100%" border="0">
                        <tr class="gridviewAlternatestyle">
                            <td class="PopupLable" width="30%">
                                <strong>Student</strong>
                            </td>
                            <td align="left" width="70%">
                                <asp:Label ID="lblStudentName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="gridviewRowstyle">
                            <td class="PopupLable">
                               <strong>Course</strong>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblCourseName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        
                    </table>
                </div>
            </td>
        </tr>
        <tr id="trAddStudent" runat="server">
            <td>
                <div class="login_new1">
                    <table cellpadding="0" cellspacing="2" width="100%" border="0">
                        <tr>
<td class="PopupLable"  width="30%">
                             &nbsp;            
                            </td>
                            <td align="right">
    <asp:LinkButton ID="lnkAdd" runat="server" Text="Add Student"
                            ToolTip="Click here to add new student" Font-Bold="true" Font-Underline="true"
                            OnClick="lnkAdd_Click"></asp:LinkButton>

                            </td>
                        </tr>
                        <tr class="gridviewAlternatestyle">
                            <td class="PopupLable" width="30%">
                                <strong><%= Resources.AppControls.Provider_AddStudent_Label_FirstName%></strong>
                            </td>
                            <td align="left" width="70%">
                                <asp:TextBox ID="txtFirstName" runat="server" Width="300" MaxLength="50"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="<%$ Resources:AppMessages,Provider_AddStudent_Error_FirstName%>"
                                    ControlToValidate="txtFirstName" ForeColor="Red" Font-Bold="true" Font-Size="X-Small"
                                    Display="Dynamic" ValidationGroup="Save"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr class="gridviewRowstyle">
                            <td class="PopupLable">
                               <strong><%= Resources.AppControls.Provider_AddStudent_Label_LastName%></strong>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtLastName" runat="server" Width="300" MaxLength="50"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="<%$ Resources:AppMessages,Provider_AddStudent_Error_LastName%>"
                                    ControlToValidate="txtLastName" ForeColor="Red" Font-Bold="true" Font-Size="X-Small"
                                    Display="Dynamic" ValidationGroup="Save"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                          <tr class="gridviewAlternatestyle">
                            <td align="left">
                                &nbsp;&nbsp;&nbsp;<strong><%= Resources.AppControls.Admin_AddStudent_Label_UserID%></strong>&nbsp;&nbsp;
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtUserID" runat="server" Width="300" MaxLength="50"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="<%$ Resources:AppMessages,Admin_AddStudent_Error_UserID%>"
                                    ControlToValidate="txtUserID" ForeColor="Red" Font-Bold="true" Font-Size="X-Small"
                                    Display="Dynamic" ValidationGroup="Save"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr class="gridviewAlternatestyle">
                            <td class="PopupLable">
                                <strong><%= Resources.AppControls.Provider_AddStudent_Label_EmailAddress%></strong>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtEmailAddress" runat="server" Width="300" MaxLength="50"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="<%$ Resources:AppMessages,Provider_AddStudent_Error_EmailAddress%>"
                                    ControlToValidate="txtEmailAddress" ForeColor="Red" Font-Bold="true" Font-Size="X-Small"
                                    Display="Dynamic" ValidationGroup="Save"></asp:RequiredFieldValidator>
                            </td>
                        </tr>

                        <tr>
                              <td class="PopupLable">
                               <strong>Courses</strong>
                            </td>
                             <td align="left">
                                         <telerik:RadComboBox ID="rcbNewCourses" runat="server" Width="200" Height="140" Filter="Contains" MarkFirstMatch="true"
                    EmptyMessage="Select a course" DataTextField="CourseName" DataValueField="CourseID">
                                     </telerik:RadComboBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please select a course" 
                                    ControlToValidate="rcbNewCourses" ForeColor="Red" Font-Bold="true" Font-Size="X-Small"
                                    Display="Dynamic" ValidationGroup="Save"></asp:RequiredFieldValidator>
                            </td>

                        </tr>



                        <tr class="gridviewRowstyle">
                            <td class="PopupLable">
                                <strong><%= Resources.AppControls.Provider_AddStudent_Label_SpecialNeeds%></strong>
                            </td>
                            <td align="left">
                                <asp:CheckBox ID="ChkSpecialNeeds" runat="server" Text="" />
                            </td>
                        </tr>
                        <tr id="Tr1" class="gridviewAlternatestyle" runat="server">
                            <td class="PopupLable">
                                <strong><%= Resources.AppControls.Provider_AddStudent_Label_Comments%></strong>
                            </td>
                            <td align="left">
                                <textarea id="txtcomments" runat="server" style="width: 250px;"></textarea>
                            </td>
                        </tr>
                        <tr class="gridviewRowstyle">
                            <td align="left">
                            </td>
                            <td class="PopupButtons">
                                <telerik:RadButton ID="btnAdd" runat="server" Text="<%$ Resources:AppControls,Provider_AddStudent_Button_Save %>"
                                    Skin="<%$ Resources:AppConfigurations,Skin_Current %>" OnClick="btnAdd_Click"
                                    ValidationGroup="Save">
                                </telerik:RadButton>
                                <telerik:RadButton ID="btnCancel" runat="server" Text="<%$ Resources:AppControls,Provider_AddStudent_Button_Cancel %>"
                                    Skin="<%$ Resources:AppConfigurations,Skin_Current %>" CausesValidation="false"
                                    OnClientClicked="close">
                                </telerik:RadButton>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr id="trAddStudentConfirm" runat="server">
            <td>
                <div class="login_new1">
                    <table cellpadding="0" cellspacing="2" width="100%" border="0">
                        <tr class="gridviewAlternatestyle">
                            <td class="PopupLable" width="30%">
                                <strong><%= Resources.AppControls.Provider_AddStudent_Label_FirstName%></strong>
                            </td>
                            <td align="left" width="70%">
                                <asp:Label ID="lblFirstName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="gridviewRowstyle">
                            <td class="PopupLable">
                               <strong><%= Resources.AppControls.Provider_AddStudent_Label_LastName%></strong>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblLastName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        
                        <tr class="gridviewAlternatestyle">
                            <td align="left">
                                &nbsp;&nbsp;&nbsp;<strong><%= Resources.AppControls.Admin_AddStudent_Label_UserID%></strong>&nbsp;&nbsp;
                            </td>
                            <td align="left">
                                <asp:Label ID="lblUserName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="gridviewAlternatestyle">
                            <td class="PopupLable">
                                <strong><%= Resources.AppControls.Provider_AddStudent_Label_EmailAddress%></strong>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblEmailAddress" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="gridviewRowstyle">
                            <td class="PopupLable">
                               <strong>Course</strong>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblNewCourse" runat="server"></asp:Label>
                            </td>
                        </tr>




                        <tr class="gridviewRowstyle">
                            <td class="PopupLable">
                               <strong><%= Resources.AppControls.Provider_AddStudent_Label_SpecialNeeds%></strong>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblSpecialNeeds" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr id="Tr2" class="gridviewAlternatestyle" runat="server">
                            <td class="PopupLable">
                                <strong><%= Resources.AppControls.Provider_AddStudent_Label_Comments%></strong>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblComments" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>

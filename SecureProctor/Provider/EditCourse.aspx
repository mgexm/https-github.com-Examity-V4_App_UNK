<%--<%@ Page Title="" Language="C#" MasterPageFile="~/Provider/Provider.Master" AutoEventWireup="true" CodeBehind="EditCourse.aspx.cs" Inherits="SecureProctor.Provider.EditCourse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ExamProviderContent" runat="server">

<table cellpadding="2" width="100%">
        <tr>
            <td>
                <img src="../Images/ImgCourseDetails.png" alt="Edit Course Details" />
            </td>
        </tr>
        <tr>
            <td>
                <div class="login_new1">
                    <table cellpadding="3" cellspacing="4" width="100%" border="0">
                        <tr class="gridviewAlternatestyle">
                            <td align="left" width="40%">
                                &nbsp;&nbsp;&nbsp; <strong>Course ID</strong>&nbsp;&nbsp;&nbsp;
                            </td>
                            <td align="left" width="60%">
                                <asp:TextBox ID="TxtCourseID" runat="server"></asp:TextBox>
                                <asp:Label ID="lblCourseID" runat="server" Visible="false"></asp:Label>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="<%$Resources:SecureProctor,Grid_Header_CourseID%>"
                                    ControlToValidate="TxtCourseID" ForeColor="Red" Display="Dynamic" ValidationGroup="Edit">
                                </asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr class="gridviewRowstyle">
                            <td align="left">
                                &nbsp;&nbsp;&nbsp; <strong>Course Name</strong>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtCourseName" runat="server" MaxLength="100"></asp:TextBox>
 <asp:Label ID="lblCourseName" runat="server" Visible="false"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="<%$Resources:SecureProctor,Grid_Header_CourseName%>"
                                    ControlToValidate="txtCourseName" ForeColor="Red" Display="Dynamic" ValidationGroup="Edit">
                                </asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr class="gridviewAlternatestyle">
                            <td align="left">
                                &nbsp;&nbsp;&nbsp; <strong>Created Date</strong>
                            </td>
                            <td align="left">
                                 <asp:Label ID="lblCreatedDate" runat="server"></asp:Label>
                               
                            </td>
                        </tr>
                        <tr class="gridviewRowstyle">
                            <td align="left">
                                &nbsp;&nbsp;&nbsp; <strong>Modified Date</strong>
                            </td>
                            <td align="left">

                                <asp:Label ID="lblModifiedDate" runat="server"></asp:Label>
                           
                            </td>
                        </tr>
                        <tr class="gridviewAlternatestyle">
                        
                            <td align="left">


                            </td>

                            <td align="left" valign="middle">
                                                         <telerik:RadButton ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click"
                                    Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin %>" ValidationGroup="Edit" />
                                <telerik:RadButton ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click"
                                    Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin %>" CausesValidation="false"/>
                            <img id="imgSuccess" runat="server" src="../Images/ImgSuccessAlert.png" alt="Success" valign="middle"/>&nbsp;&nbsp;
                                            
                            <asp:Label id="lblSuccess" runat="server"></asp:Label>
                            
                            </td>
                          
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>




</asp:Content>--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditCourse.aspx.cs" Inherits="SecureProctor.Provider.EditCourse" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="shortcut icon" href="../Images/secureproctor.ico" />
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
                    <%= Resources.AppControls.Provider_EditCourse_Label_EditCourse%></div>
            </td>
        </tr>
        <tr>
            <td>
                <div class="login_new1">
                    <table cellpadding="0" cellspacing="2" width="100%" border="0">
                        <tr id="trMessage" runat="server">
                            <td align="center" colspan="2">
                                <table width="100%" cellpadding="2" cellspacing="2">
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
                        <tr id="trEdit" runat="server">
                            <td align="center" colspan="2">
                                <table width="100%" cellpadding="0" cellspacing="2">
                                    <tr class="gridviewAlternatestyle">
                                        <td class="PopupLable" width="30%">
                                            <strong>
                                                <%= Resources.AppControls.Provider_EditCourse_Label_CourseID %></strong>
                                        </td>
                                        <td align="left" width="70%">
                                            <asp:TextBox ID="TxtCourseID" runat="server" Width="150" MaxLength="50"></asp:TextBox>
                                            </br>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="<%$ Resources:AppMessages,Provider_EditCourse_Error_CourseID %>"
                                                ControlToValidate="TxtCourseID" ForeColor="Red" Display="Dynamic" ValidationGroup="Edit"
                                                Font-Bold="true" Font-Size="X-Small">
                                            </asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr class="gridviewRowstyle">
                                        <td class="PopupLable" width="30%">
                                            <strong>
                                                <%= Resources.AppControls.Provider_EditCourse_Label_CourseName %></strong>
                                        </td>
                                        <td align="left" width="70%">
                                            <asp:TextBox ID="txtCourseName" runat="server" Width="300" MaxLength="100"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="<%$ Resources:AppMessages,Provider_EditCourse_Error_CourseName %>"
                                                ControlToValidate="txtCourseName" ForeColor="Red" Display="Dynamic" ValidationGroup="Edit"
                                                Font-Bold="true" Font-Size="X-Small">
                                            </asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr class="gridviewAlternatestyle">
                                        <td class="PopupLable" width="30%">
                                            <strong>
                                                <%= Resources.AppControls.Provider_EditCourse_Label_Status %></strong>
                                        </td>
                                        <td align="left" width="70%">
                                            <telerik:RadComboBox ID="ddlStatus" runat="server" Skin="<%$ Resources:AppConfigurations,Skin_Current %>">
                                                <Items>
                                                    <telerik:RadComboBoxItem Text="Active" Value="1" />
                                                    <telerik:RadComboBoxItem Text="Inactive" Value="0" />
                                                </Items>
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                    <tr class="gridviewRowstyle">
                                        <td class="PopupLable" width="30%">
                                            <strong>
                                                <%= Resources.AppControls.Provider_EditCourse_Label_CreatedDate %></strong>
                                        </td>
                                        <td align="left" width="70%">
                                            <asp:Label ID="lblCreatedDate" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="gridviewAlternatestyle">
                                        <td class="PopupLable" width="30%">
                                            <strong>
                                                <%= Resources.AppControls.Provider_EditCourse_Label_ModifiedDate %></strong>
                                        </td>
                                        <td align="left" width="70%">
                                            <asp:Label ID="lblModifiedDate" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="gridviewRowstyle">
                                        <td align="left" width="30%">
                                        </td>
                                        <td class="PopupButtons">
                                            <telerik:RadButton ID="btnUpdate" runat="server" Text="<%$ Resources:AppControls,Provider_EditCourse_Button_Update %>"
                                                OnClick="btnUpdate_Click" Skin="<%$ Resources:AppConfigurations,Skin_Current %>"
                                                ValidationGroup="Edit" />
                                            <telerik:RadButton ID="btnBack" runat="server" Text="<%$ Resources:AppControls,Provider_EditCourse_Button_Cancel %>"
                                                Skin="<%$ Resources:AppConfigurations,Skin_Current %>" CausesValidation="false"
                                                OnClientClicked="close" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr id="trView" runat="server">
                            <td align="center" colspan="2">
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <tr class="gridviewAlternatestyle">
                                        <td class="PopupLable" width="30%">
                                            <strong>
                                                <%= Resources.AppControls.Provider_EditCourse_Label_CourseID %></strong>
                                        </td>
                                        <td align="left" width="70%">
                                            <asp:Label ID="lblCourseID" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="gridviewRowstyle">
                                        <td class="PopupLable">
                                            <strong>
                                                <%= Resources.AppControls.Provider_EditCourse_Label_CourseName %></strong>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblCourse" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="gridviewAlternatestyle">
                                        <td class="PopupLable">
                                            <strong>
                                                <%= Resources.AppControls.Provider_EditCourse_Label_Status %></strong>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblStatus" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="gridviewRowstyle">
                                        <td class="PopupLable">
                                            <strong>
                                                <%= Resources.AppControls.Provider_EditCourse_Label_CreatedDate %></strong>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblCreatedDate1" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="gridviewAlternatestyle">
                                        <td class="PopupLable">
                                            <strong>
                                                <%= Resources.AppControls.Provider_EditCourse_Label_ModifiedDate %></strong>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblModifiedDate1" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
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



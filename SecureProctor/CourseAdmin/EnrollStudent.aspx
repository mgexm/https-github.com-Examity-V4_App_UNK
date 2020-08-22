<%@ Page Title="" Language="C#" MasterPageFile="~/CourseAdmin/CourseAdmin.Master" AutoEventWireup="true" CodeBehind="EnrollStudent.aspx.cs" Inherits="SecureProctor.CourseAdmin.EnrollStudent" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ExamProviderContent" runat="server">
    <script type="text/javascript">
        function inprogress() {

            alert("In Progress");
            return false;

        }

    </script>
    <table cellpadding="2" cellspacing="2" width="100%">
        <tr>
            <td>
                <img src="../Images/ImgEnrollStudentExam.png" alt="Home" />
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:LinkButton ID="lblAddStudentlink" runat="server" Text="Add/View Student" ToolTip="Click here to View and Add Student"
                    Font-Bold="true" Font-Underline="true" OnClick="lblAddStudentlink_Click"></asp:LinkButton>&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td width="100%" align="center" valign="top">
                <div class="login_new1">
                    <table width="100%" cellpadding="2" cellspacing="4">
                        <tr>
                            <td>
                                <table width="100%" cellpadding="0" cellspacing="0" class="td_bg">
                                    <tr class="td_header">
                                        <td colspan="4" align="left">
                                            <table width="100%">
                                                <tr>
                                                    <td align="left" class="boreder_home_pro">
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/ImgEnrollStudent.png" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblSuccess" runat="server" Font-Bold="true"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                <tr class="gridviewRowstyle">
                                                    <td width="10%">&nbsp;
                                                    </td>
                                                    <td width="15%" align="left" style="height: 35px;">
                                                        <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblFirstName" Text="Student Name : "
                                                            runat="server"></asp:Label></strong>
                                                    </td>
                                                    <td width="75%" align="left" style="height: 35px;">
                                                        <telerik:RadComboBox ID="ddlStudents" runat="server" AppendDataBoundItems="True"
                                                            Skin="Web20" DropDownAutoWidth="Enabled">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                </tr>
                                                <tr class="gridviewAlternatestyle" style="height: 35px;">
                                                    <td width="10%">&nbsp;
                                                    </td>
                                                    <td width="15%" align="left">
                                                        <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblLastName" Text="Course Name : "
                                                            runat="server"></asp:Label>
                                                        </strong>
                                                    </td>
                                                    <td width="75%" align="left">
                                                        <telerik:RadComboBox ID="ddlCourse" runat="server" AppendDataBoundItems="True" Skin="Web20"
                                                            Width="250" DropDownAutoWidth="Enabled">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                </tr>
                                                <tr class="gridviewRowstyle" style="height: 35px;">
                                                    <td width="10%">&nbsp;
                                                    </td>
                                                    <td width="15%" align="left">&nbsp;
                                                    </td>
                                                    <td width="75%" align="left">
                                                        <telerik:RadButton ID="btnEnroll" runat="server" Text="Enroll" Skin="Web20" Width="8%"
                                                            OnClick="btnEnroll_Click">
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
                            <td>
                                <table width="100%" cellpadding="0" cellspacing="0" class="td_bg">
                                    <tr class="td_header">
                                        <td align="left" colspan="4">
                                            <table width="100%">
                                                <tr>
                                                    <td align="left" class="boreder_home_pro">
                                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/ImgViewEnrollments.png" />
                                                    </td>
                                                    <%--<td align="right"><asp:Image ID="Image5" runat="server" ImageUrl="~/Images/edit.png" /> &nbsp;&nbsp;&nbsp;</td>--%>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr id="trGridPages" runat="server">
                                        <td colspan="5"></td>
                                    </tr>
                                    <tr>
                                        <td colspan="5">
                                            <telerik:RadGrid ID="gvExamStatus" runat="server" OnNeedDataSource="gvExamStatus_NeedDataSource"
                                                AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" Skin="<%$ Resources:SecureProctor,Telerik_Grid_Skin %>"
                                                CellSpacing="0" GridLines="None" OnItemCommand="gvExamStatus_ItemCommand">
                                                <GroupingSettings CaseSensitive="false" />
                                                <MasterTableView AllowFilteringByColumn="true" FilterItemStyle-BackColor="#DCEDFD">
                                                    <Columns>
                                                        <%--<telerik:GridBoundColumn DataField="StudentName" HeaderText="<%$ Resources:SecureProctor,Grid_Header_StudentName %>"
                                                            SortExpression="StudentName" UniqueName="StudentName" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridBoundColumn>--%>
                                                        <telerik:GridBoundColumn DataField="FirstName" HeaderText="<%$ Resources:SecureProctor,Grid_Header_StudentFirstName %>"
                                                            SortExpression="FirstName" UniqueName="FirstName" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="LastName" HeaderText="<%$ Resources:SecureProctor,Grid_Header_StudentLastName %>"
                                                            SortExpression="LastName" UniqueName="LastName" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="CourseName" HeaderText="<%$ Resources:SecureProctor,Grid_Header_CourseName %>"
                                                            SortExpression="CourseName" UniqueName="CourseName" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="GenderName" HeaderText="Gender" SortExpression="GenderName"
                                                            UniqueName="GenderName" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" Width="8%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EmailAddress" HeaderText="<%$ Resources:SecureProctor,Grid_Header_EmailAddress %>"
                                                            SortExpression="EmailAddress" UniqueName="EmailAddress" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="Status" HeaderText="<%$ Resources:SecureProctor,Grid_Header_EnrollmentStatus %>"
                                                            SortExpression="Status" UniqueName="Status" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EnrollDate" HeaderText="<%$ Resources:SecureProctor,Grid_Header_EnrollmentDate %>"
                                                            SortExpression="EnrollDate" UniqueName="EnrollDate" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn HeaderText="Actions" HeaderStyle-HorizontalAlign="Center"
                                                            AllowFiltering="false">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="lblEdit" runat="server" Text="Edit" ImageUrl="~/Images/edit_s.png"
                                                                    OnClick="lblStudentNameEdit_Click" CommandArgument='<%#Eval("EnrollmentID") %>'></asp:ImageButton>&nbsp;&nbsp;
                                                                <asp:ImageButton ID="lblDelete" runat="server" Text="Delete" ImageUrl="~/Images/delete_s.png"
                                                                    OnClick="lblStudentNameDelete_Click" CommandArgument='<%#Eval("EnrollmentID") %>'></asp:ImageButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                            <HeaderStyle Font-Bold="true" />
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
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>

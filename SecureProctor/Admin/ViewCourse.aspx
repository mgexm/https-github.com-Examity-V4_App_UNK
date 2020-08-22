<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="ViewCourse.aspx.cs" Inherits="SecureProctor.Admin.ViewCourse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminContent" runat="server">
    <table cellpadding="2" cellspacing="2" width="100%">
        <tr>
            <td>
                <img src="../Images/ImgCourseDetails.png" alt="Home" />
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:LinkButton ID="lblExamDetailslink" runat="server" Text="Exam Details" ToolTip="Click here to Exam Details"
                    Font-Bold="true" Font-Underline="true" OnClick="lblExamDetailslink_Click"></asp:LinkButton>&nbsp;&nbsp;
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
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/ImgCreateNewCourse.png" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <asp:Label ID="lblSuccess" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label></tr>
                                    <tr class="gridviewAlternatestyle">
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td align="left">
                                            <strong>
                                                <asp:Label ID="Label1" Text="Instructor Name" runat="server"></asp:Label></strong>
                                        </td>
                                        <td align="left">
                                            <telerik:RadComboBox ID="ddlprovider" runat="server" DropDownAutoWidth="Enabled" AppendDataBoundItems="true"
                                                Skin="<%$ Resources:SecureProctor,Telerik_ComboBox_Skin %>">
                                            </telerik:RadComboBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="--Select Instructor--"
                                                ErrorMessage="Please select instructor name" ControlToValidate="ddlprovider" ForeColor="Red"
                                                ValidationGroup="submit"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr class="gridviewRowstyle">
                                        <td width="10%">
                                            &nbsp;
                                        </td>
                                        <td width="20%" align="left">
                                            <strong>
                                                <asp:Label ID="lblCourse" runat="server" Text="Course ID"></asp:Label></strong>
                                        </td>
                                        <td width="70%" align="left">
                                            <telerik:RadTextBox ID="txtCourseID" runat="server" Width="250" MaxLength="100" Skin="Web20">
                                            </telerik:RadTextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter course ID"
                                                ControlToValidate="txtCourseID" ForeColor="Red" ValidationGroup="submit"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr class="gridviewAlternatestyle">
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td align="left">
                                            <strong>
                                                <asp:Label ID="lblCourseName" Text="Course Name" runat="server"></asp:Label></strong>
                                        </td>
                                        <td align="left">
                                            <telerik:RadTextBox ID="txtCourseName" runat="server" Width="250" MaxLength="100"
                                                Skin="Web20">
                                            </telerik:RadTextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter course name"
                                                ControlToValidate="txtCourseName" ForeColor="Red" ValidationGroup="submit"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr class="gridviewRowstyle" style="padding-top: 10px;">
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td align="left">
                                            <telerik:RadButton ID="BtnSaveCourse" runat="server" Skin="Web20" Text="Save" CausesValidation="true"
                                                ValidationGroup="submit" onclick="BtnSaveCourse_Click">
                                            </telerik:RadButton>
                                            <telerik:RadButton ID="BtnClear" runat="server" Skin="Web20" Text="Clear" onclick="BtnClear_Click" CausesValidation="true">
                                            </telerik:RadButton>
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
                                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/ImgViewCourse.png" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <telerik:RadGrid ID="gvCourseStatus" runat="server" OnNeedDataSource="gvCourseStatus_NeedDataSource"
                                    AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" Skin="<%$ Resources:SecureProctor,Telerik_Grid_Skin %>"
                                    CellSpacing="0" GridLines="None" OnItemCommand="gvCourseStatus_ItemCommand" EnableLinqExpressions="false">
                                    <GroupingSettings CaseSensitive="false" />
                                    <MasterTableView AllowFilteringByColumn="true" FilterItemStyle-BackColor="#DCEDFD">
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="Course_ID" HeaderText="Course ID" SortExpression="Course_ID"
                                                UniqueName="Course_ID" HeaderStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Center" Width="25%" />
                                                <HeaderStyle Font-Bold="true" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CourseName" HeaderText="Course Name" SortExpression="CourseName"
                                                UniqueName="CourseName" HeaderStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Center" Width="25%" />
                                                <HeaderStyle Font-Bold="true" />
                                            </telerik:GridBoundColumn>
                                            <%--<telerik:GridBoundColumn DataField="ExamProviderID" HeaderText="Provider ID" SortExpression="ExamProviderID"
                                                            UniqueName="ExamProviderID" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" Width="25%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridBoundColumn>--%>
                                            <%--<telerik:GridBoundColumn DataField="ProviderName" HeaderText="Instructor Name" SortExpression="ProviderName"
                                                UniqueName="ProviderName" HeaderStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Center" Width="25%" />
                                                <HeaderStyle Font-Bold="true" />
                                            </telerik:GridBoundColumn>--%>
                                            <telerik:GridBoundColumn DataField="ProviderFirstName" HeaderText="Instructor First Name" SortExpression="ProviderFirstName"
                                                UniqueName="ProviderFirstName" HeaderStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Center" Width="25%" />
                                                <HeaderStyle Font-Bold="true" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="ProviderLastName" HeaderText="Instructor Last Name" SortExpression="ProviderLastName"
                                                UniqueName="ProviderLastName" HeaderStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Center" Width="25%" />
                                                <HeaderStyle Font-Bold="true" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn HeaderText="Action" HeaderStyle-HorizontalAlign="Center"
                                                AllowFiltering="false">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgExamEdit" runat="server" ImageUrl="~/Images/edit_s.png" CommandName="EditCourse"
                                                        CommandArgument='<%# Eval("CourseID") + "," + Eval("ExamProviderID") %>' ToolTip="Edit" />&nbsp;&nbsp;
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="18%" />
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
                </div>
            </td>
        </tr>
    </table>
</asp:Content>

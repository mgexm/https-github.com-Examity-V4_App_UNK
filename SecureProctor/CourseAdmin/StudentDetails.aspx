<%@ Page Title="" Language="C#" MasterPageFile="~/CourseAdmin/CourseAdmin.Master" AutoEventWireup="true" CodeBehind="StudentDetails.aspx.cs" Inherits="SecureProctor.CourseAdmin.StudentDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ExamProviderContent" runat="server">
        <script language="javascript" type="text/javascript">
            function OpenAddStudnet() {
                radopen("AddStudent.aspx", "Add New Student", 600, 450);
            }
            function OpenEditStudent(ID) {
                radopen("EditStudent.aspx?StudentID=" + ID, "Edit Student", 600, 350);
            }
            function openViewStudent(ID) {
                radopen("ViewStudent.aspx?StudentID=" + ID, "View Student", 900, 650);
            }
            function openDeleteStudent(ID) {
                radopen("DeleteStudent.aspx?StudentID=" + ID, "Delete Student", 600, 400);
            }
            function openAddEnrollment(ID) {
                radopen("AddEnrollment.aspx?StudentID=" + ID, "Add Enrollment", 500, 330);
            }
            function openDeleteEnrollment(ID) {
                radopen("DeleteEnrollment.aspx?EnrollmentID=" + ID, "Delete Enrollment", 600, 350);
            }
            function openEditEnrollment(ID) {
                radopen("EditEnrollment.aspx?EnrollmentID=" + ID, "Edit Enrollment", 600, 350);
            }
            function closeWin() {
                var masterTable = $find("<%= gvStudents.ClientID %>").get_masterTableView();
            masterTable.rebind();
        }
    </script>
    <table width="100%" cellpadding="2" cellspacing="2">
        <tr>
            <td>
                <table width="100%" cellpadding="5" cellspacing="5">
                    <tr id="trSearchCriteria1" runat="server" >
                        <td align="left">
                            <strong>Student FirstName&nbsp;:&nbsp;</strong>
                            <asp:TextBox ID="txtfirstname" runat="server"></asp:TextBox>
                            &nbsp;&nbsp; <strong>Student LastName&nbsp;:&nbsp;</strong>
                            <asp:TextBox ID="txtlastname" runat="server"></asp:TextBox>
                               &nbsp;&nbsp; <strong>Student EmailAddress&nbsp;:&nbsp;</strong>
                              <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
                            &nbsp;&nbsp;
                                            <telerik:RadButton ID="btnsearch" runat="server" Text="Search" OnClick="btnsearch_Click"
                                                Skin="Web20" />
                            &nbsp;&nbsp;
                                            
                        </td>
                    </tr>
                  
                    </table>
            </td>
        </tr>
        <tr id="trExportButtons" runat="server">
            <td>
                
                
            </td>
        </tr>
         <asp:HiddenField ID="hdExpandValue" runat="server" />
        <tr id="trGridView" runat="server">
            <td>
                  <telerik:RadGrid ID="gvStudents" runat="server" OnNeedDataSource="gvStudents_NeedDataSource"
                            AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" Skin="<%$ Resources:AppConfigurations,Skin_Current %>"
                            CellSpacing="0" GridLines="None" AllowFilteringByColumn="false" OnItemCommand="gvStudents_ItemCommand" OnPreRender="gvStudents_PreRender">
                            <GroupingSettings CaseSensitive="false" />
                            <MasterTableView AllowFilteringByColumn="true" FilterItemStyle-BackColor="#DCEDFD"
                                FilterItemStyle-HorizontalAlign="Center" CommandItemDisplay="Top" DataKeyNames="StudentID"
                                EditMode="PopUp">
                                <CommandItemStyle HorizontalAlign="Left" Height="30" />
                                <CommandItemTemplate>
                                    <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="vertical-align: bottom;" align="center" width="3%">
                                                <asp:ImageButton ID="imgplus" runat="server" ImageUrl="~/Images/ImgGridAdd.png" OnClientClick="OpenAddStudnet(); return false;" />&nbsp;&nbsp;
                                            </td>
                                            <td style="vertical-align: top;" align="left" width="98%">
                                                <asp:LinkButton ID="lnkAddStudent" runat="server" Text="<%$ Resources:AppControls,Provider_Students_GridHeader_AddStudent %>"
                                                    OnClientClick="OpenAddStudnet(); return false;"></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                </CommandItemTemplate>
                                <Columns>

                                    <telerik:GridBoundColumn DataField="FirstName" HeaderText="<%$ Resources:AppControls,Provider_Students_GridHeader_StudentFirstName %>"
                                        SortExpression="FirstName" UniqueName="FirstName" HeaderStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="Center" Width="17%" />
                                        <HeaderStyle Font-Bold="true" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="LastName" HeaderText="<%$ Resources:AppControls,Provider_Students_GridHeader_StudentLastName %>"
                                        SortExpression="LastName" UniqueName="LastName" HeaderStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="Center" Width="17%" />
                                        <HeaderStyle Font-Bold="true" />
                                    </telerik:GridBoundColumn>

                                    <telerik:GridBoundColumn DataField="EmailAddress" HeaderText="<%$ Resources:AppControls,Provider_Students_GridHeader_EmailAddress %>"
                                        SortExpression="EmailAddress" UniqueName="EmailAddress" HeaderStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="Center" Width="25%" />
                                        <HeaderStyle Font-Bold="true" />
                                    </telerik:GridBoundColumn>


                                     <telerik:GridBoundColumn DataField="LMSName" HeaderText="<%$ Resources:AppControls,LMS %>"
                                                                                    SortExpression="LMSName" UniqueName="LMSName" HeaderStyle-HorizontalAlign="Center">
                                                                                    <ItemStyle HorizontalAlign="Center" Width="25" />
                                                                                    <HeaderStyle Font-Bold="true" />
                                                                            </telerik:GridBoundColumn>



                                    <telerik:GridTemplateColumn HeaderText="Profile Update"
                                        HeaderStyle-HorizontalAlign="Center" SortExpression="VerificationStatus" AllowFiltering="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblVerificationStatus" runat="server" Text='<%# Eval("VerificationStatus")%>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="3%" />
                                        <HeaderStyle Font-Bold="true" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="<%$ Resources:AppControls,Provider_Students_GridHeader_Status %>"
                                        HeaderStyle-HorizontalAlign="Center" SortExpression="Status" DataField="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status")%>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="7%" />
                                        <HeaderStyle Font-Bold="true" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="<%$ Resources:AppControls,Provider_Students_GridHeader_SpecialNeeds %>"
                                        HeaderStyle-HorizontalAlign="Center" SortExpression="SpecialNeeds" AllowFiltering="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSpecialNeeds" runat="server" Text='<%# Eval("SpecialNeeds")%>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <HeaderStyle Font-Bold="true" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="<%$ Resources:AppControls,Provider_Students_GridHeader_Actions %>"
                                        HeaderStyle-HorizontalAlign="Center" AllowFiltering="false">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="BtnViewStudent" runat="server" ImageUrl="~/Images/View_s.png"
                                                CommandArgument='<%#Eval("StudentID") %>' CommandName="View" ToolTip="View Student Details"
                                                Width="16" Height="16"></asp:ImageButton>&nbsp;&nbsp;
                                                <asp:ImageButton ID="BtnEditStudent" runat="server" Text="Edit" ImageUrl="~/Images/edit_s.gif"
                                                    CommandName="Edit" CommandArgument='<%#Eval("StudentID") %>' ToolTip="Edit Student"
                                                    OnClientClick='<%# Eval("StudentID", "OpenEditStudent({0});return false;") %>'></asp:ImageButton>&nbsp;&nbsp;
                                                <asp:ImageButton ID="BtnDeleteStudent" runat="server" Text="Delete" ImageUrl="~/Images/delete_s.gif"
                                                    CommandName="Delete" CommandArgument='<%#Eval("StudentID") %>' ToolTip="Delete Student"
                                                    OnClientClick='<%# Eval("StudentID", "openDeleteStudent({0});return false;") %>' />
                                            &nbsp;&nbsp;
                                               <asp:ImageButton ID="BtnAddEnrollStudent" runat="server" Text="Enroll" ImageUrl="~/Images/add_s.gif"
                                                   CommandName="Enroll" CommandArgument='<%#Eval("StudentID") %>' ToolTip="Enroll Student"
                                                   OnClientClick='<%# Eval("StudentID", "openAddEnrollment({0});return false;") %>'
                                                   Visible='<%# Convert.ToBoolean(Eval("ActiveStatus")) %>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="18%" />
                                        <HeaderStyle Font-Bold="true" />
                                    </telerik:GridTemplateColumn>
                                </Columns>
                                <NestedViewTemplate>
                                    <table width="100%" cellpadding="0" cellspacing="0" style="background-color: #E0F0FD; border-color: Black;"
                                        border="1">
                                        <tr>
                                            <td align="center">
                                                <table width="95%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td align="left" valign="middle" style="padding-top: 15px; padding-bottom: 15px;">
                                                            <telerik:RadGrid ID="gvEnrollments" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="10"
                                                                AllowSorting="True" Skin="<%$ Resources:AppConfigurations,Skin_Current %>" CellSpacing="0"
                                                                GridLines="None">
                                                                <GroupingSettings CaseSensitive="false" />
                                                                <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD"
                                                                    FilterItemStyle-HorizontalAlign="Center">
                                                                    <Columns>
                                                                        <telerik:GridBoundColumn DataField="CourseName" HeaderText="<%$ Resources:AppControls,Provider_Students_GridHeader_CourseName %>"
                                                                            SortExpression="CourseName" UniqueName="CourseName" HeaderStyle-HorizontalAlign="Center">
                                                                            <ItemStyle HorizontalAlign="Center" Width="30%" />
                                                                            <HeaderStyle Font-Bold="true" />
                                                                        </telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="ProviderName" HeaderText="Instructor Name"
                                                                            SortExpression="ProviderName" UniqueName="ProviderName" HeaderStyle-HorizontalAlign="Center">
                                                                            <ItemStyle HorizontalAlign="Center" Width="25%" />
                                                                            <HeaderStyle Font-Bold="true" />
                                                                        </telerik:GridBoundColumn>


                                                                         <telerik:GridBoundColumn DataField="LMSName" HeaderText="<%$ Resources:AppControls,LMS %>"
                                                                                    SortExpression="LMSName" UniqueName="LMSName" HeaderStyle-HorizontalAlign="Center">
                                                                                    <ItemStyle HorizontalAlign="Center" Width="25" />
                                                                                    <HeaderStyle Font-Bold="true" />
                                                                            </telerik:GridBoundColumn>



                                                                        <telerik:GridBoundColumn DataField="Status" HeaderText="<%$ Resources:AppControls,Provider_Students_GridHeader_EnrollmentStatus %>"
                                                                            SortExpression="Status" UniqueName="Status" HeaderStyle-HorizontalAlign="Center">
                                                                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                            <HeaderStyle Font-Bold="true" />
                                                                        </telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="EnrollDate" HeaderText="<%$ Resources:AppControls,Provider_Students_GridHeader_EnrollmentDate %>"
                                                                            SortExpression="EnrollDate" UniqueName="EnrollDate" HeaderStyle-HorizontalAlign="Center">
                                                                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                                            <HeaderStyle Font-Bold="true" />
                                                                        </telerik:GridBoundColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="<%$ Resources:AppControls,Provider_Students_GridHeader_Action %>"
                                                                            HeaderStyle-HorizontalAlign="Center" AllowFiltering="false">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="BtnEdit" runat="server" Text="Edit" ImageUrl="~/Images/edit_s.gif" ToolTip="Edit Enrollment"
                                                                                    CommandArgument='<%#Eval("EnrollmentID") %>' OnClientClick='<%# Eval("EnrollmentID", "openEditEnrollment({0});return false;") %>'></asp:ImageButton>&nbsp;&nbsp;
                                                                                    <asp:ImageButton ID="BtnDelete" runat="server" Text="Delete" ImageUrl="~/Images/delete_s.gif" ToolTip="Delete Enrollment"
                                                                                        CommandArgument='<%#Eval("EnrollmentID") %>' OnClientClick='<%# Eval("EnrollmentID", "openDeleteEnrollment({0});return false;") %>'></asp:ImageButton>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="15%" />
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
                                </NestedViewTemplate>
                                <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                            </MasterTableView>
                            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                            <FilterMenu EnableImageSprites="False">
                            </FilterMenu>
                        </telerik:RadGrid>
                             <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="true"
                                Behaviors="Close" OnClientClose="closeWin" Skin="<%$ Resources:AppConfigurations,Skin_Current %>"  
                                VisibleStatusbar="false">
                                <Windows>
                                    <telerik:RadWindow ID="RadWindow1" runat="server" ShowContentDuringLoad="false" Width="400px"
                                        Height="400px" Title="Telerik RadWindow" Behaviors="Default">
                                    </telerik:RadWindow>
                                </Windows>
                            </telerik:RadWindowManager>
            </td>
        </tr>
    </table>
</asp:Content>

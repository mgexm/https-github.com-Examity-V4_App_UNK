<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master"  AutoEventWireup="true" CodeBehind="CourseStudents.aspx.cs" Inherits="SecureProctor.Admin.CourseStudents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminContent" runat="server">

 <script language="javascript" type="text/javascript">
     function OpenEditCourse(ID) {
         radopen("EditCourse.aspx?CourseID=" + ID, "Edit Course", 500, 350);
     }
     function OpenDeleteCourse(ID) {
         radopen("DeleteCourse.aspx?CourseID=" + ID, "Delete Exam", 500, 300);

     }
     function OpenAddStudnet() {
         radopen("AddStudent.aspx", "Add New Student", 700, 400);
     }
     function OpenEditStudent(ID) {
         radopen("EditStudent.aspx?StudentID=" + ID, "Edit Student", 600, 350);
     }
     function openViewStudent(ID) {
         radopen("ViewStudent.aspx?StudentID=" + ID, "View Student", 900, 650);
     }
     function openDeleteStudent(ID) {
         radopen("DeleteStudent.aspx?StudentID=" + ID, "Delete Student", 600, 500);
     }
     function openAddEnrollment(Courseid, providerId) {        
         radopen("EnrollStudent.aspx?Courseid=" + Courseid + "&ProviderId=" + providerId, "Add Enrollment", 550, 400);
     }
     function openDeleteEnrollment(ID) {
         radopen("DeleteEnrollment.aspx?EnrollmentID=" + ID, "Delete Enrollment", 600, 350);
     }
     function openEditEnrollment(ID) {
         radopen("EditEnrollment.aspx?EnrollmentID=" + ID, "Edit Enrollment", 600, 350);
     }
     function OpenAddInstructor() {


         radopen("AddInstructor.aspx", "Add New Instructor", 600, 300);
     }
     function closeWin() {
         var masterTable = $find("<%= gvStudents.ClientID %>").get_masterTableView();
         masterTable.rebind();
     }
     function openResetStudent(ID) {

         radopen("Reset.aspx?StudentID=" + ID, "Reset Student", 600, 350);

     }
    </script>
    <asp:UpdatePanel ID="upExams" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hdExpandValue" runat="server" />
            <table cellpadding="2" cellspacing="2" width="100%">
                <tr>
                  <td>
                        <table width="100%">
                       <td>
                        <div class="heading customfont1">
                            <img src="../Images/ImgStudents.png" />
                           <%-- <%= Resources.AppHelpContent.Admin_Home_Students_Head  %>--%>
                        </div>
                           </td>
                    <%--<td>
                           <table width="100%">  

                          <tr>
                          <td align="right">
                          <img id="imgView" src="../Images/View_s.png" alt="View Student Details">&nbsp; View Student Details
                          
                          <img id="imgEdit" src="../Images/edit_s.gif" alt="Edit Student Details">&nbsp; Edit Student Details 
                          
                             <img id="imgDelete" src="../Images/delete_s.gif" alt="Delete Student Details">&nbsp;Delete Student Details 

                          <img id="imgEnroll" src="../Images/Add_s.gif"  alt="Enroll Student">&nbsp; Enroll Student    
                          </td>
                          </tr>
                      
                        </table>

                          </td>--%>

                          <td>
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td width="60%">
                                            &nbsp;
                                        </td>
                                  
                                        <td valign="top" align="left" width="20%">
                                            <img src="../Images/View_s.png" />
                                            &nbsp; View Details
                                           
                                       </td>
                                        <td align="left"  valign="top" width="20%">
                                            
                                            <img src="../Images/edit_s.gif" />
                                            &nbsp;Edit Details
                                            </td>
                                        </tr>
                                    <tr>
                                        <td width="60%">
                                            &nbsp;
                                        </td>
                                    <td valign="top" align="left" width="20%">
                                             <img src="../Images/delete_s.gif" />
                                            &nbsp;Delete Details
                                        </td>
                                    <td align="left"  valign="top" width="20%">
                                         <img src="../Images/Add_s.gif" />
                                            &nbsp;Enroll Student
                                            
                                            </td>

                                            </tr>
                                  
                                </table>
                            </td>

                        </table>


                    </td>
                </tr>
                <tr>
                    <td width="100%" align="center" valign="top">
                        <div class="login_new1">
                            <telerik:RadGrid ID="gvStudents" runat="server" OnNeedDataSource="gvStudents_NeedDataSource"
                                AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" Skin="<%$ Resources:AppConfigurations,Skin_Current %>"
                                CellSpacing="0" GridLines="None" AllowFilteringByColumn="false" OnItemCommand="gvStudents_ItemCommand" OnPreRender="gvStudents_PreRender">
                                <GroupingSettings CaseSensitive="false" />
                                <MasterTableView AllowFilteringByColumn="true" FilterItemStyle-BackColor="#DCEDFD"
                                    FilterItemStyle-HorizontalAlign="Center" CommandItemDisplay="Top" DataKeyNames="CourseID"
                                    EditMode="PopUp">
                                    <CommandItemStyle HorizontalAlign="Left" Height="30" />
                                    <CommandItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="vertical-align: bottom;" align="center" width="3%">
                                                    <asp:ImageButton ID="imgplus" runat="server" ImageUrl="~/Images/ImgGridAdd.png" OnClientClick="OpenAddStudnet(); return false;" />&nbsp;&nbsp;
                                                </td>
                                                <td style="vertical-align: top;" align="left" width="10%">
                                                    <asp:LinkButton ID="lnkAddStudent" runat="server" Text="<%$ Resources:AppControls,Admin_Students_GridHeader_AddStudent %>"
                                                        OnClientClick="OpenAddStudnet(); return false;"></asp:LinkButton>
                                                </td>
                                                  
                                                <td style="vertical-align: bottom;" align="center" width="3%">
                                                    <asp:ImageButton ID="imgplus1" runat="server" ImageUrl="~/Images/ImgGridAdd.png" OnClientClick="OpenAddInstructor(); return false;" />&nbsp;&nbsp;
                                                </td>
                                                <td style="vertical-align: top;" align="left" width="10%">
                                                    <asp:LinkButton ID="lnkAddInstructor" runat="server" Text="<%$ Resources:AppControls,Admin_Students_GridHeader_AddInstructor %>"
                                                        OnClientClick="OpenAddInstructor(); return false;"></asp:LinkButton>
                                                </td>
                                                <td style="vertical-align: bottom;" align="center" width="3%">
                                                    <asp:ImageButton ID="Imgserachstudent" runat="server" ImageUrl="~/Images/View_s.png" OnClick="linkserachstudent_Click"  />&nbsp;&nbsp;
                                                </td>
                                                <td style="vertical-align: top;" align="left" width="10%">
                                                    <asp:LinkButton ID="linkserachstudent" runat="server" Text="<%$ Resources:AppControls,Admin_Students_GridHeader_SearchStudent %>" OnClick="linkserachstudent_Click"
                                                       ></asp:LinkButton>
                                                </td>

                                                 <td width="74%">&nbsp;</td>
                                            </tr>
                                        </table>
                                    </CommandItemTemplate>
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="Course_ID" HeaderText="<%$ Resources:AppControls,Provider_CourseDetails_GridHeader_CourseID %>"
                                            SortExpression="Course_ID" UniqueName="Course_ID" HeaderStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                                            <HeaderStyle Font-Bold="true" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="CourseName" HeaderText="<%$ Resources:AppControls,Provider_CourseDetails_GridHeader_CourseName %>"
                                            SortExpression="CourseName" UniqueName="CourseName" HeaderStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" Width="20%" />
                                            <HeaderStyle Font-Bold="true" />
                                        </telerik:GridBoundColumn>
                                       <%-- <telerik:GridBoundColumn DataField="ProviderName" HeaderText="<%$ Resources:AppControls,Provider_CourseDetails_GridHeader_ProviderName %>"
                                            SortExpression="ProviderName" UniqueName="ProviderName" HeaderStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" Width="25%" />
                                            <HeaderStyle Font-Bold="true" />                                            
                                        </telerik:GridBoundColumn>--%>
                                         <telerik:GridTemplateColumn HeaderText="<%$ Resources:AppControls,Provider_CourseDetails_GridHeader_ProviderName %>" DataField="ProviderName"
                                             HeaderStyle-Font-Bold="true" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" AllowFiltering="true" ItemStyle-VerticalAlign="Top" SortExpression="ProviderName" UniqueName="ProviderName">
                                        <ItemTemplate>
                                             <asp:Label ID="lblProctor" runat="server" Text='<%#Eval("ProviderName") %>' />
                                            <asp:HiddenField ID="hdnProvider" runat="server" Value='<%#Eval("ProviderID")%>' />
                                         </ItemTemplate>
                                         </telerik:GridTemplateColumn>
                                         <telerik:GridBoundColumn DataField="LMSName" HeaderText="<%$ Resources:AppControls,LMS %>"
                                                                                    SortExpression="LMSName" UniqueName="LMSName" HeaderStyle-HorizontalAlign="Center">
                                                                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                                    <HeaderStyle Font-Bold="true" />
                                                                            </telerik:GridBoundColumn>

                                        <telerik:GridBoundColumn DataField="status" HeaderText="<%$ Resources:AppControls,Provider_CourseDetails_GridHeader_Status %>"
                                            SortExpression="status" UniqueName="status" HeaderStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" Width="13%" />
                                            <HeaderStyle Font-Bold="true" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="CreatedDate" HeaderText="<%$ Resources:AppControls,Provider_CourseDetails_GridHeader_CreatedDate %>"
                                            SortExpression="CreatedDate" UniqueName="CreatedDate" HeaderStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" Width="8%" />
                                            <HeaderStyle Font-Bold="true" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn HeaderText="<%$ Resources:AppControls,Provider_CourseDetails_GridHeader_Action %>"
                                            HeaderStyle-HorizontalAlign="Center" AllowFiltering="false" ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:ImageButton ID="BtnEditExam" runat="server" ImageUrl="~/Images/edit_s.gif" CommandName="Edit" Visible='<%# Convert.ToBoolean(Eval("ActiveStatus")) %>'
                                                    CommandArgument='<%# Eval("CourseID")%>' ToolTip="Edit Course" OnClientClick='<%# Eval("CourseID", "OpenEditCourse({0});return false;") %>' />&nbsp;&nbsp;
                                                
                                                <asp:ImageButton ID="BtnDeleteCourse" runat="server" ImageUrl="~/Images/delete_s.gif" 
                                                    CommandName="Delete" CommandArgument='<%# Eval("CourseID")%>' ToolTip="Delete Course" Visible='<%# Convert.ToBoolean(Eval("ActiveStatus")) %>'
                                                    OnClientClick='<%# Eval("CourseID", "OpenDeleteCourse({0});return false;") %>' />&nbsp;&nbsp;
                                                 
                                               <asp:ImageButton ID="BtnAddStudent" runat="server" ImageUrl="~/Images/add_s.gif"  
                                                    CommandArgument='<%# Eval("CourseID")%>' ToolTip="Enroll Student"  OnClientClick='<%# String.Format("openAddEnrollment({0},{1});return false;",Eval("CourseID"), Eval("ProviderID"))%>'
                                                    Visible='<%# Convert.ToBoolean(Eval("ActiveStatus")) %>' />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="14%" />
                                            <HeaderStyle Font-Bold="true" />
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                    <NestedViewTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0" style="background-color: #E0F0FD;
                                            border-color: Black;" border="1">
                                            <tr>
                                                <td align="center">
                                                    <table width="95%" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="left" valign="middle" style="padding-top: 15px; padding-bottom: 15px;">
                                                                <telerik:RadGrid ID="gvEnrollments" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="10"
                                                                    AllowSorting="True" Skin="<%$ Resources:AppConfigurations,Skin_Current %>" CellSpacing="0"
                                                                    GridLines="None">
                                                                    <GroupingSettings CaseSensitive="false" />
                                                                    <MasterTableView AllowFilteringByColumn="true" FilterItemStyle-BackColor="#DCEDFD"
                                                                        FilterItemStyle-HorizontalAlign="Center">
                                                                          <Columns>
                                                                             <telerik:GridBoundColumn DataField="FirstName" HeaderText="<%$ Resources:AppControls,Admin_Students_GridHeader_StudentFirstName %>"
                                                                                SortExpression="FirstName" UniqueName="FirstName" HeaderStyle-HorizontalAlign="Center">
                                                                                <ItemStyle HorizontalAlign="Center" Width="17%" />
                                                                                <HeaderStyle Font-Bold="true" />
                                                                            </telerik:GridBoundColumn>
                                                                             <telerik:GridBoundColumn DataField="LastName" HeaderText="<%$ Resources:AppControls,Admin_Students_GridHeader_StudentLastName %>"
                                                                                SortExpression="LastName" UniqueName="LastName" HeaderStyle-HorizontalAlign="Center">
                                                                                <ItemStyle HorizontalAlign="Center" Width="17%" />
                                                                                <HeaderStyle Font-Bold="true" />
                                                                            </telerik:GridBoundColumn>
                                                                            <telerik:GridBoundColumn DataField="EmailAddress" HeaderText="<%$ Resources:AppControls,Admin_Students_GridHeader_EmailAddress %>"
                                                                                SortExpression="EmailAddress" UniqueName="EmailAddress" HeaderStyle-HorizontalAlign="Center">
                                                                                <ItemStyle HorizontalAlign="Center" Width="35%" />
                                                                                <HeaderStyle Font-Bold="true" />
                                                                            </telerik:GridBoundColumn>
                                                                              <telerik:GridBoundColumn DataField="LMSName" HeaderText="<%$ Resources:AppControls,LMS %>"
                                                                                SortExpression="LMSName" UniqueName="LMSName" HeaderStyle-HorizontalAlign="Center">
                                                                                <ItemStyle HorizontalAlign="Center" Width="25" />
                                                                                <HeaderStyle Font-Bold="true" />
                                                                            </telerik:GridBoundColumn>
                                                                            <telerik:GridTemplateColumn HeaderText="Profile Update"
                                                                                HeaderStyle-HorizontalAlign="Center" SortExpression="VerificationStatus" DataField="VerificationStatus">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblVerificationStatus" runat="server" Text='<%# Eval("VerificationStatus")%>' />
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                                                <HeaderStyle Font-Bold="true" />
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn HeaderText="<%$ Resources:AppControls,Admin_Students_GridHeader_Status %>"
                                                                                HeaderStyle-HorizontalAlign="Center" SortExpression="Status" DataField="Status">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status")%>' />
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Center" Width="7%" />
                                                                                <HeaderStyle Font-Bold="true" />
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn HeaderText="<%$ Resources:AppControls,Admin_Students_GridHeader_SpecialNeeds %>"
                                                                                HeaderStyle-HorizontalAlign="Center" SortExpression="SpecialNeeds" DataField="SpecialNeeds">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblSpecialNeeds" runat="server" Text='<%# Eval("SpecialNeeds")%>' />
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                                                <HeaderStyle Font-Bold="true" />
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn HeaderText="<%$ Resources:AppControls,Admin_Students_GridHeader_Actions %>"
                                                                                HeaderStyle-HorizontalAlign="Center" AllowFiltering="false">
                                                                                <ItemTemplate>

                                                                                    <a id="A1" href='<%#GetUrl(Eval("StudentID").ToString())%>' runat="server" target="_blank" >
                                                                                    <asp:Image ID="BtnViewStudent" runat="server" ImageUrl="~/Images/View_s.png" AlternateText="view"  Width ="16" Height="16">
                                                                                    </asp:Image></a>&nbsp;&nbsp;

                                                                                    <%--<asp:ImageButton ID="BtnEditStudent" runat="server" Text="Edit" ImageUrl="~/Images/edit_s.gif"
                                                                                        CommandName="Edit" CommandArgument='<%#Eval("StudentID") %>' ToolTip="Edit Student"
                                                                                        OnClientClick='<%# Eval("StudentID", "OpenEditStudent({0});return false;") %>' Visible='<%#Convert.ToBoolean(Eval("ActiveStatus")) %>'>
                                                                                    </asp:ImageButton>--%>
                                                                                    <asp:ImageButton ID="BtnDeleteStudent" runat="server" Text="Delete" ImageUrl="~/Images/delete_s.gif"
                                                                                        CommandName="Delete" CommandArgument='<%#Eval("EnrollmentID") %>' ToolTip="Delete Enrollment"
                                                                                        OnClientClick='<%# Eval("EnrollmentID", "openDeleteEnrollment({0});return false;") %>' Visible='<%#Convert.ToBoolean(Eval("ActiveStatus")) %>'/>
                                                                                    &nbsp;&nbsp;
                                                                                  <%--  <asp:ImageButton ID="BtnAddEnrollStudent" runat="server" Text="Enroll" ImageUrl="~/Images/add_s.gif"
                                                                                        CommandName="Enroll" CommandArgument='<%#Eval("StudentID") %>' ToolTip="Enroll Student"
                                                                                        OnClientClick='<%# Eval("StudentID", "openAddEnrollment({0});return false;") %>'
                                                                                        Visible='<%# Convert.ToBoolean(Eval("ActiveStatus")) %>' />--%>                                                                                   
                                                                                   <%-- <asp:ImageButton ID="BtnReset" runat="server" Text="Reset" ImageUrl="~/Images/ImgReset.png"
                                                                                        CommandName="Reset" CommandArgument='<%# Eval("StudentID")%>' ToolTip="Reset"
                                                                                        OnClientClick='<%# Eval("StudentID", "openResetStudent({0});return false;") %>' />--%>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Center" Width="23%" />
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
                                Behaviors="Close" Skin="<%$ Resources:AppConfigurations,Skin_Current %>" OnClientClose="closeWin"
                                VisibleStatusbar="false">
                                <Windows>
                                    <telerik:RadWindow ID="RadWindow1" runat="server" ShowContentDuringLoad="false" Width="400px"
                                        Height="400px" Title="Telerik RadWindow" Behaviors="Default">
                                    </telerik:RadWindow>
                                </Windows>
                            </telerik:RadWindowManager>
                        </div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>

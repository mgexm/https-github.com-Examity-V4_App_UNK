<%@ Page Title="" Language="C#" MasterPageFile="~/Provider/Provider.Master" AutoEventWireup="true"
    CodeBehind="CourseDetails.aspx.cs" Inherits="SecureProctor.Provider.CourseDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ExamProviderContent" runat="server">
    <script language="javascript" type="text/javascript">
        function OpenAddCourse() {
            radopen("AddCourse.aspx", "Add New Course", 500, 280);
        }
        function OpenEditCourse(ID) {
            radopen("EditCourse.aspx?CourseID=" + ID, "Edit Course", 500, 350);
        }
        function openAddExam(ID) {
            radopen("AddExam.aspx?CourseID=" + ID, "Add Exam", 900, 650);
        }
        function openViewExam(ID) {
            radopen("ViewExam.aspx?ExamID=" + ID, "View Exam", 900, 550);
        }

        function openEditExam(ID) {
            var values = ID.split(',');
            var ExamId = values[0];
            var CourseId = values[1];
            radopen("EditExam.aspx?ExamID=" + ExamId + "&CourseID=" + CourseId, "Edit Exam", 900, 650);
            // radopen("EditExam.aspx?ExamID=" + ID, "Edit Exam", 900, 650);
        }


        function openDeleteExam(ID) {
            radopen("DeleteExam.aspx?ExamID=" + ID, "Delete Exam", 500, 300);
        }
        function OpenDeleteCourse(ID) {
         radopen("DeleteCourse.aspx?CourseID=" + ID, "Delete Exam", 500, 300);
           
        }
        function closeWin() {
            var masterTable = $find("<%= gvCourseDetails.ClientID %>").get_masterTableView();
            masterTable.rebind();

        }
    </script>
    <asp:UpdatePanel ID="upCourses" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hdExpandValue" runat="server" />
            <table cellpadding="2" cellspacing="2" width="100%">
                <tr>
                    <td>
                        <table width="100%">
                            <tr>
                       <td>
                        <div class="heading customfont1">
                           <img src="../Images/ImgCoursesExams.png" />
                    </td>
                    <%--<td align="right">

                        <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td width="74%">
                                            &nbsp;
                                        </td>
                                  
                                        <td valign="top" align="left" width="13%">
                                            <img src="../Images/View_s.png" />
                                            &nbsp; View
                                           
                                       </td>
                                        <td align="left"  valign="top" width="13%">
                                            
                                           <img id="imgAdd" src="../Images/edit_s.gif">
                                            &nbsp; Edit Course
                                            </td>
                                        </tr>
                                    <tr>
                                        <td width="74%">
                                            &nbsp;
                                        </td>
                                    <td valign="top" align="left">
                                           <img id="img1" src="../Images/delete_s.gif">
                                            &nbsp;  Delete Course
                                        </td>
                                    <td align="left"  valign="top">
                                         <img id="img2" src="../Images/Add_s.gif">
                                            &nbsp; Add Exam
                                            
                                            </td>

                                            </tr>
                                  
                                </table>
                  
                        
                    </td>--%>

                     <td align="right">
                      <img id="imgAdd" src="../Images/edit_s.gif">&nbsp;Edit Course &nbsp;
                        <img id="img1" src="../Images/delete_s.gif">&nbsp; Delete Course &nbsp;
                        <img id="img2" src="../Images/Add_s.gif">&nbsp;Add Exam &nbsp;
                        
                    </td>
                            
                                </tr>

                        </table>


                    </td>
                  
                </tr>
                <tr>
                    <td width="100%" align="center" valign="top">
                        <div class="login_new1">
                            <telerik:RadGrid ID="gvCourseDetails" runat="server" OnNeedDataSource="gvCourseDetails_NeedDataSource"
                                AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" Skin="<%$ Resources:AppConfigurations,Skin_Current %>"
                                CellSpacing="0" GridLines="None" AllowFilteringByColumn="false" OnItemCommand="gvCourseDetails_ItemCommand" OnPreRender="gvCourseDetails_PreRender">
                                <GroupingSettings CaseSensitive="false" />
                               
                                <MasterTableView AllowFilteringByColumn="true" FilterItemStyle-BackColor="#DCEDFD"
                                    FilterItemStyle-HorizontalAlign="Center" CommandItemDisplay="Top" DataKeyNames="CourseID"
                                    EditMode="PopUp">
                                    <CommandItemStyle HorizontalAlign="Left" Height="30" />
                                    <CommandItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="vertical-align: bottom;" align="center" width="3%">
                                                    <asp:ImageButton ID="imgplus" runat="server" ImageUrl="~/Images/ImgGridAdd.png" OnClientClick="OpenAddCourse(); return false;" />&nbsp;&nbsp;
                                                </td>
                                                <td style="vertical-align: top;" align="left" width="98%">
                                                    <asp:LinkButton ID="lnkAddCourse" runat="server" Text="<%$ Resources:AppControls,Provider_CourseDetails_GridHeader_AddCourse %>"
                                                        OnClientClick="OpenAddCourse(); return false;"></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </CommandItemTemplate>
                                    
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="Course_ID" HeaderText="<%$ Resources:AppControls,Provider_CourseDetails_GridHeader_CourseID %>"
                                            SortExpression="Course_ID" UniqueName="Course_ID" HeaderStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" Width="20%" />
                                            <HeaderStyle Font-Bold="true" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="CourseName" HeaderText="<%$ Resources:AppControls,Provider_CourseDetails_GridHeader_CourseName %>"
                                            SortExpression="CourseName" UniqueName="CourseName" HeaderStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" Width="40%" />
                                            <HeaderStyle Font-Bold="true" />
                                            
                                        </telerik:GridBoundColumn>
                                          <telerik:GridBoundColumn DataField="LMSName" HeaderText="<%$ Resources:AppControls,LMS %>"
                                                                                    SortExpression="LMSName" UniqueName="LMSName" HeaderStyle-HorizontalAlign="Center">
                                                                                    <ItemStyle HorizontalAlign="Center" Width="25" />
                                                                                    <HeaderStyle Font-Bold="true" />
                                                                            </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="status" HeaderText="<%$ Resources:AppControls,Provider_CourseDetails_GridHeader_Status %>"
                                            SortExpression="status" UniqueName="status" HeaderStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" Width="13%" />
                                            <HeaderStyle Font-Bold="true" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="CreatedDate" HeaderText="<%$ Resources:AppControls,Provider_CourseDetails_GridHeader_CreatedDate %>"
                                            SortExpression="CreatedDate" UniqueName="CreatedDate" HeaderStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" Width="13%" />
                                            <HeaderStyle Font-Bold="true" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn HeaderText="<%$ Resources:AppControls,Provider_CourseDetails_GridHeader_Action %>"
                                            HeaderStyle-HorizontalAlign="Center" AllowFiltering="false" ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:ImageButton ID="BtnEditExam" runat="server" ImageUrl="~/Images/edit_s.gif" CommandName="Edit"
                                                    CommandArgument='<%# Eval("CourseID")%>' ToolTip="Edit Course" OnClientClick='<%# Eval("CourseID", "OpenEditCourse({0});return false;") %>' />&nbsp;&nbsp;
                                                <asp:ImageButton ID="BtnDeleteCourse" runat="server" ImageUrl="~/Images/delete_s.gif"
                                                    CommandName="Delete" CommandArgument='<%# Eval("CourseID")%>' ToolTip="Delete Course"
                                                    OnClientClick='<%# Eval("CourseID", "OpenDeleteCourse({0});return false;") %>' />&nbsp;&nbsp;
                                                <asp:ImageButton ID="BtnAddExam" runat="server" ImageUrl="~/Images/add_s.gif" CommandName="Edit"
                                                    CommandArgument='<%# Eval("CourseID")%>' ToolTip="Add Exam" OnClientClick='<%# Eval("CourseID", "openAddExam({0});return false;") %>'
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
                                                                <telerik:RadGrid ID="gvExamDetails" runat="server" AutoGenerateColumns="False" AllowSorting="True" PageSize="10"
                                                                    Skin="<%$ Resources:AppConfigurations,Skin_Current %>" CellSpacing="0" GridLines="None"
                                                                    AllowFilteringByColumn="false">
                                                                    <GroupingSettings CaseSensitive="false" />
                                                                    <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD"
                                                                        FilterItemStyle-HorizontalAlign="Center">
                                                                        <Columns>
                                                                            <telerik:GridBoundColumn DataField="ExamName" HeaderText="<%$ Resources:AppControls,Provider_CourseDetails_GridHeader_ExamName %>"
                                                                                SortExpression="ExamName" UniqueName="ExamName" HeaderStyle-HorizontalAlign="Center">
                                                                                <ItemStyle HorizontalAlign="Center" Width="25%" />
                                                                                <HeaderStyle Font-Bold="true" />
                                                                            </telerik:GridBoundColumn>
                                                                                <telerik:GridBoundColumn DataField="LMSName" HeaderText="<%$ Resources:AppControls,LMS %>"
                                                                                    SortExpression="LMSName" UniqueName="LMSName" HeaderStyle-HorizontalAlign="Center">
                                                                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                                    <HeaderStyle Font-Bold="true" />
                                                                            </telerik:GridBoundColumn>
                                                                            <telerik:GridBoundColumn DataField="ExamDuration" HeaderText="<%$ Resources:AppControls,Provider_CourseDetails_GridHeader_Duration %>"
                                                                                SortExpression="ExamDuration" UniqueName="ExamDuration" HeaderStyle-HorizontalAlign="Center">
                                                                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                                                <HeaderStyle Font-Bold="true" />
                                                                            </telerik:GridBoundColumn>
                                                                            <telerik:GridBoundColumn DataField="Status" HeaderText="<%$ Resources:AppControls,Provider_CourseDetails_GridHeader_Status %>"
                                                                                SortExpression="Status" UniqueName="Status" HeaderStyle-HorizontalAlign="Center"
                                                                                AllowFiltering="false">
                                                                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                                <HeaderStyle Font-Bold="true" />
                                                                            </telerik:GridBoundColumn>
                                                                            <telerik:GridBoundColumn DataField="ExamStartDate" HeaderText="<%$ Resources:AppControls,Provider_AddExam_Label_ExamStartDateAndTime %>"
                                                                                SortExpression="ExamStartDate" UniqueName="ExamStartDate" HeaderStyle-HorizontalAlign="Center">
                                                                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                                                <HeaderStyle Font-Bold="true" />
                                                                            </telerik:GridBoundColumn>
                                                                       
                                                                            <telerik:GridBoundColumn DataField="ExamEndDate" HeaderText="<%$ Resources:AppControls,Provider_AddExam_Label_ExamEndDateAndTime %>"
                                                                                SortExpression="ExamEndDate" UniqueName="ExamEndDate" HeaderStyle-HorizontalAlign="Center">
                                                                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                                                <HeaderStyle Font-Bold="true" />
                                                                            </telerik:GridBoundColumn>
                                                                           
                                                                            <telerik:GridTemplateColumn HeaderText="<%$ Resources:AppControls,Provider_CourseDetails_GridHeader_Action %>"
                                                                                HeaderStyle-HorizontalAlign="Center" AllowFiltering="false">
                                                                                <ItemTemplate>
                                                                                    <asp:ImageButton ID="imgExamView" runat="server" ImageUrl="~/Images/View_s.png" ToolTip="View"
                                                                                        OnClientClick='<%# Eval("ExamID", "openViewExam({0});return false;") %>' Height="16"
                                                                                        Width="16" />&nbsp;&nbsp;
                                                                                    <%--<asp:ImageButton ID="imgExamEdit" runat="server" ImageUrl="~/Images/edit_s.gif" ToolTip="Edit"
                                                                                        OnClientClick='<%# Eval("ExamID", "openEditExam({0});return false;") %>' Visible='<%# Convert.ToBoolean(Eval("CourseStatus")) %>' />--%>

                                                                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/edit_s.gif" CommandArgument='<%# Eval("CourseID")%>' 
                                                                                                        OnClientClick='<%# string.Format("javascript: openEditExam(\"{0},{1}\"); return false;", Eval("ExamID"),Eval("CourseID")) %>' 
                                                                                                        ToolTip="Edit" Visible='<%# Convert.ToBoolean(Eval("CourseStatus")) %>' />


                                                                                    &nbsp;&nbsp;
                                                                                    <asp:ImageButton ID="imgExamDelete" runat="server" ImageUrl="~/Images/delete_s.gif"
                                                                                        ToolTip="Delete" OnClientClick='<%# Eval("ExamID", "openDeleteExam({0});return false;") %>'
                                                                                        Visible='<%# Convert.ToBoolean(Eval("CourseStatus")) %>' />
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                                                <HeaderStyle Font-Bold="true" />
                                                                            </telerik:GridTemplateColumn>
                                                                        </Columns>
                                                                    </MasterTableView>
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

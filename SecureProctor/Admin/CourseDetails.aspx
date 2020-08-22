<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="CourseDetails.aspx.cs" Inherits="SecureProctor.Admin.CourseDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminContent" runat="server">

    <style type="text/css">
        .DeletedText {
            color: red;
        }
    </style>


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


        function AssignPrimaryInstructor(ID) {
            radopen("AssignPrimaryInstructor.aspx?CourseID=" + ID, "Assign primary instructors", 550, 400);
        }
        function openViewExam(ID) {
            radopen("ViewExam.aspx?ExamID=" + ID, "View Exam", 900, 550);
        }
        function openEditExam(ID) {

            var values = ID.split(',');
            var ExamId = values[0];
            var CourseId = values[1];

            radopen("EditExam.aspx?ExamID=" + ExamId + "&CourseID=" + CourseId, "Edit Exam", 900, 650);
        }
        function openDeleteExam(ID) {
            radopen("DeleteExam.aspx?ExamID=" + ID, "Delete Exam", 500, 300);
        }
        function OpenDeleteCourse(ID) {
            radopen("DeleteCourse.aspx?CourseID=" + ID, "Delete Exam", 500, 300);

        }
        function OpenAddInstructor() {


            radopen("AddInstructor.aspx", "Add New Instructor", 600, 300);
        }
        function OpenEditDetails(ID) {
            radopen("PrimaryIns.aspx?ProviderID=" + ID, "Is primary instructor", 400, 300);
        }
        //function OpenEditDetails(ID, ProviderID) {

        //    radopen("PrimaryIns.aspx?CourseID=" + ID + "&ProviderName=" + ProviderID + "&PageType=Edit", "Is Primary instructor", 400, 200);
        //}

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
                                    <div class="heading customfont1">
<%--                                        <%= Resources.AppHelpContent.Provider_Home_CoursesAndExams_Head%>--%>
                                        <img src="../Images/ImgCoursesExams.png" />
                                    </div>
                                </td>
                                <td align="right">
                                    <img id="imgAdd" src="../Images/edit_s.gif">&nbsp;Edit Course </img>&nbsp;
                                    <img id="img1" src="../Images/delete_s.gif">&nbsp; Delete Course </img>&nbsp;
                                    <img id="img3" src="../Images/p.png">&nbsp; Assign primary faculty </img>&nbsp;
                                    <img id="img2" src="../Images/Add_s.gif">&nbsp;Add Exam &nbsp; </img></td>
                            </tr>


                <tr>
                    <td colspan="2">
                         <div class="search">
                             <table width="100%" cellpadding="2" cellspacing="2">
                    <tr id="trSearchCriteria1" runat="server" >
                        <td align="right" width="75%">
                            <strong>Course ID&nbsp;:&nbsp;</strong>
                            <asp:TextBox ID="txtCourseID" runat="server"></asp:TextBox>
                            &nbsp;&nbsp; <strong>Course Name&nbsp;:&nbsp;</strong>
                            <asp:TextBox ID="txtcoursename" runat="server"></asp:TextBox>
                               &nbsp;&nbsp; <strong>Instructor Name&nbsp;:&nbsp;</strong>
                              <asp:TextBox ID="txtinstructorname" runat="server"></asp:TextBox>
                            &nbsp;&nbsp;
                            </td>
                            <td align="left">
 <telerik:RadButton ID="btnsearch" runat="server" Text="Search" OnClick="btnsearch_Click"
                                                Skin="Web20" />
                            </td>
                                           
                                          
                        
                    </tr>
                  
                    </table>
                         </div>
                   

                    </td>
                </tr>
                <tr>
                    <td width="100%" align="center" valign="top" colspan="2">
                        <div class="login_new1">
                            <telerik:RadGrid ID="gvCourseDetails" runat="server" OnNeedDataSource="gvCourseDetails_NeedDataSource"
                                AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" Skin="<%$ Resources:AppConfigurations,Skin_Current %>"
                                CellSpacing="0" GridLines="None" AllowFilteringByColumn="false" OnItemCommand="gvCourseDetails_ItemCommand" OnPreRender="gvCourseDetails_PreRender">
                                <GroupingSettings CaseSensitive="false" />
                                <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD"
                                    FilterItemStyle-HorizontalAlign="Center" CommandItemDisplay="Top" DataKeyNames="CourseID"
                                    EditMode="PopUp">
                                    <CommandItemStyle HorizontalAlign="Left" Height="30" />
                                    <CommandItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="vertical-align: bottom;" align="center" width="3%">
                                                    <asp:ImageButton ID="imgplus" runat="server" ImageUrl="~/Images/ImgGridAdd.png" OnClientClick="OpenAddCourse(); return false;" />&nbsp;&nbsp;
                                                </td>
                                                <td style="vertical-align: top;" align="left" width="9%">
                                                    <asp:LinkButton ID="lnkAddCourse" runat="server" Text="<%$ Resources:AppControls,Provider_CourseDetails_GridHeader_AddCourse %>"
                                                        OnClientClick="OpenAddCourse(); return false;"></asp:LinkButton>
                                                </td>
                                                <td>&nbsp;&nbsp;</td>
                                                <td style="vertical-align: bottom;" align="center" width="3%">
                                                    <asp:ImageButton ID="imgplus1" runat="server" ImageUrl="~/Images/ImgGridAdd.png" OnClientClick="OpenAddInstructor(); return false;" />&nbsp;&nbsp;
                                                </td>
                                                <td style="vertical-align: top;" align="left" width="85%">
                                                    <asp:LinkButton ID="lnkAddInstructor" runat="server" Text="<%$ Resources:AppControls,Admin_Students_GridHeader_AddInstructor %>"
                                                        OnClientClick="OpenAddInstructor(); return false;"></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </CommandItemTemplate>
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="Course_ID" HeaderText="<%$ Resources:AppControls,Provider_CourseDetails_GridHeader_CourseID %>"
                                            SortExpression="Course_ID" UniqueName="Course_ID" HeaderStyle-HorizontalAlign="Center" AllowFiltering="false">
                                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                                            <HeaderStyle Font-Bold="true" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="CourseName" HeaderText="<%$ Resources:AppControls,Provider_CourseDetails_GridHeader_CourseName %>"
                                            SortExpression="CourseName" UniqueName="CourseName" HeaderStyle-HorizontalAlign="Center" AllowFiltering="false">
                                            <ItemStyle HorizontalAlign="Center" Width="25%" />
                                            <HeaderStyle Font-Bold="true" />
                                        </telerik:GridBoundColumn>

                                        <telerik:GridBoundColumn DataField="ProviderID" Visible="false" AllowFiltering="false">
                                            <ItemStyle HorizontalAlign="Center" Width="25%" />
                                            <HeaderStyle Font-Bold="true" />
                                        </telerik:GridBoundColumn>

                                         <telerik:GridBoundColumn DataField="ProviderName" HeaderText="<%$ Resources:AppControls,Provider_CourseDetails_GridHeader_ProviderName %>" HeaderStyle-HorizontalAlign="Center" AllowFiltering="false">
                                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                                            <HeaderStyle Font-Bold="true" />
                                        </telerik:GridBoundColumn>

                                             <%--<telerik:GridTemplateColumn DataField="ProviderStatus" HeaderText="Instructor status" SortExpression="ProviderStatus" UniqueName="ProviderStatus" HeaderStyle-HorizontalAlign="Center" AllowFiltering="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProviderStatus" runat="server" Text='<%# Eval("ProviderStatus") %>' ForeColor='<%# System.Drawing.ColorTranslator.FromHtml(Convert.ToString(Eval("ProviderForeColor"))) %>' />

                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="6%" />
                                            <HeaderStyle Font-Bold="true" Width="6%" />
                                        </telerik:GridTemplateColumn>--%>


<%--                                           <telerik:GridBoundColumn DataField="ProviderStatus" HeaderText="Instructor status" HeaderStyle-HorizontalAlign="Center" AllowFiltering="false" >
                                            <ItemStyle HorizontalAlign="Center" Width="6%" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml(Convert.ToString(Eval("ProviderForeColor"))) %>'/>
                                            <HeaderStyle Font-Bold="true" />
                                        </telerik:GridBoundColumn>--%>

<%--                                        <telerik:GridTemplateColumn DataField="ProviderName" HeaderText="<%$ Resources:AppControls,Provider_CourseDetails_GridHeader_ProviderName %>" SortExpression="ProviderName" UniqueName="ProviderName" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server"
                                                    Text='<%# Eval("ProviderName")%>'
                                                    CommandName="Edits" ToolTip="Primary instructor?"
                                                    OnClientClick='<%# Eval("ProviderID", "OpenEditDetails({0});return false;") %>'
                                                    Font-Underline="true"></asp:LinkButton>

                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="6%" />
                                            <HeaderStyle Font-Bold="true" Width="6%" />
                                        </telerik:GridTemplateColumn>--%>


                                        <telerik:GridBoundColumn DataField="LMSName" HeaderText="<%$ Resources:AppControls,LMS %>"
                                            SortExpression="LMSName" UniqueName="LMSName" HeaderStyle-HorizontalAlign="Center" AllowFiltering="false">
                                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                                            <HeaderStyle Font-Bold="true" />
                                        </telerik:GridBoundColumn>

                                        <%-- <telerik:GridBoundColumn DataField="status" HeaderText="<%$ Resources:AppControls,Provider_CourseDetails_GridHeader_Status %>"
                                             SortExpression="status" UniqueName="status" HeaderStyle-HorizontalAlign="Center"
                                            <ItemStyle HorizontalAlign="Center" Width="13%" />
                                            <HeaderStyle Font-Bold="true" />
                                        </telerik:GridBoundColumn>--%>

                                        <telerik:GridTemplateColumn DataField="status" HeaderText="<%$ Resources:AppControls,Provider_CourseDetails_GridHeader_Status %>" SortExpression="status" UniqueName="status" HeaderStyle-HorizontalAlign="Center" AllowFiltering="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblstatus" runat="server" Text='<%# Eval("status") %>' ForeColor='<%# System.Drawing.ColorTranslator.FromHtml(Convert.ToString(Eval("ForeColor"))) %>' />

                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="6%" />
                                            <HeaderStyle Font-Bold="true" Width="6%" />
                                        </telerik:GridTemplateColumn>

                                        <telerik:GridBoundColumn DataField="ExamFlag" HeaderText="Exams scheduled" HeaderStyle-HorizontalAlign="Center"  AllowFiltering="false"  SortExpression="ExamFlag" UniqueName="ExamFlag">
                                            <ItemStyle HorizontalAlign="Center" Width="6%" />
                                            <HeaderStyle Font-Bold="true" />
                                        </telerik:GridBoundColumn>

                                        <telerik:GridBoundColumn DataField="CreatedDate" HeaderText="<%$ Resources:AppControls,Provider_CourseDetails_GridHeader_CreatedDate %>"
                                            SortExpression="CreatedDate" UniqueName="CreatedDate" HeaderStyle-HorizontalAlign="Center" AllowFiltering="false">
                                            <ItemStyle HorizontalAlign="Center" Width="8%" />
                                            <HeaderStyle Font-Bold="true" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn HeaderText="<%$ Resources:AppControls,Provider_CourseDetails_GridHeader_Action %>"
                                            HeaderStyle-HorizontalAlign="Center" AllowFiltering="false" ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:ImageButton ID="BtnEditExam" runat="server" ImageUrl="~/Images/edit_s.gif" CommandName="Edit" Visible='<%# Convert.ToBoolean(Eval("ActiveStatus")) %>'
                                                    CommandArgument='<%# Eval("CourseID")%>' ToolTip="Edit Course" OnClientClick='<%# Eval("CourseID", "OpenEditCourse({0});return false;") %>' />&nbsp;&nbsp;
                                                <asp:ImageButton ID="BtnDeleteCourse" runat="server" ImageUrl="~/Images/delete_s.gif" Visible='<%# Convert.ToBoolean(Eval("ActiveStatus")) %>'
                                                    CommandName="Delete" CommandArgument='<%# Eval("CourseID")%>' ToolTip="Delete Course"
                                                    OnClientClick='<%# Eval("CourseID", "OpenDeleteCourse({0});return false;") %>' />&nbsp;&nbsp;
                                                 <asp:ImageButton ID="btnAssignPrimaryInstructor" runat="server" ImageUrl="~/Images/p.png" CommandName="Edit" 
                                                    CommandArgument='<%# Eval("CourseID")%>' ToolTip="Assign primary instructor" OnClientClick='<%# Eval("CourseID", "AssignPrimaryInstructor({0});return false;") %>'  Visible='<%# Convert.ToBoolean(Eval("ActiveStatus")) %>'/>&nbsp;&nbsp;
                                                <asp:ImageButton ID="BtnAddExam" runat="server" ImageUrl="~/Images/add_s.gif" CommandName="Edit"
                                                    CommandArgument='<%# Eval("CourseID")%>' ToolTip="Add Exam" OnClientClick='<%# Eval("CourseID", "openAddExam({0});return false;") %>'
                                                    Visible='<%# Convert.ToBoolean(Eval("ActiveStatus")) %>' />&nbsp;&nbsp;
                                                
                                                  

                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="14%" />
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
                                                                <telerik:RadGrid ID="gvExamDetails" runat="server" AutoGenerateColumns="False" AllowSorting="True"
                                                                    Skin="<%$ Resources:AppConfigurations,Skin_Current %>" CellSpacing="0" GridLines="None"
                                                                    AllowFilteringByColumn="false" AllowPaging="true" PageSize="10">
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
                                                                            <%--<telerik:GridBoundColumn DataField="Status" HeaderText="<%$ Resources:AppControls,Provider_CourseDetails_GridHeader_Status %>"
                                                                                SortExpression="Status" UniqueName="Status" HeaderStyle-HorizontalAlign="Center"
                                                                                AllowFiltering="false">
                                                                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                                <HeaderStyle Font-Bold="true" />
                                                                            </telerik:GridBoundColumn>--%>
                                                                            <telerik:GridTemplateColumn DataField="status" HeaderText="<%$ Resources:AppControls,Provider_CourseDetails_GridHeader_Status %>" SortExpression="status" UniqueName="status" HeaderStyle-HorizontalAlign="Center">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblstatus" runat="server" Text='<%# Eval("status") %>' ForeColor='<%# System.Drawing.ColorTranslator.FromHtml(Convert.ToString(Eval("ForeColor"))) %>' />
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Center" Width="6%" />
                                                                                <HeaderStyle Font-Bold="true" Width="6%" />
                                                                            </telerik:GridTemplateColumn>
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

                                                                            <telerik:GridBoundColumn DataField="ExamsScheduled" HeaderText="Exams Scheduled" HeaderStyle-HorizontalAlign="Center" >
                                            <ItemStyle HorizontalAlign="Center" Width="6%" />
                                            <HeaderStyle Font-Bold="true" />
                                        </telerik:GridBoundColumn>
                                                                            <telerik:GridTemplateColumn HeaderText="<%$ Resources:AppControls,Provider_CourseDetails_GridHeader_Action %>"
                                                                                HeaderStyle-HorizontalAlign="Center" AllowFiltering="false">
                                                                                <ItemTemplate>
                                                                                    <asp:ImageButton ID="imgExamView" runat="server" ImageUrl="~/Images/View_s.png" ToolTip="View"
                                                                                        OnClientClick='<%# Eval("ExamID", "openViewExam({0});return false;") %>' Height="16"
                                                                                        Width="16" />&nbsp;&nbsp;
<%--                                                                                    <asp:ImageButton ID="imgExamEdit" runat="server" ImageUrl="~/Images/edit_s.gif" ToolTip="Edit"
                                                                                        OnClientClick='<%# Eval("ExamID", "openEditExam({0});return false;") %>' Visible='<%# Convert.ToBoolean(Eval("ActiveStatus")) %>' />
                                                                                    &nbsp;&nbsp;--%>
                                                                                     <asp:ImageButton ID="imgExamEdit" runat="server" ImageUrl="~/Images/edit_s.gif" CommandArgument='<%# Eval("CourseID")%>' 
                                                                                                        OnClientClick='<%# string.Format("javascript: openEditExam(\"{0},{1}\"); return false;", Eval("ExamID"),Eval("CourseID")) %>' 
                                                                                                        ToolTip="Edit" Visible='<%# Convert.ToBoolean(Eval("ActiveStatus")) %>' />
                                                                                                    &nbsp;&nbsp;
                                                                                    <asp:ImageButton ID="imgExamDelete" runat="server" ImageUrl="~/Images/delete_s.gif"
                                                                                        ToolTip="Delete" OnClientClick='<%# Eval("ExamID", "openDeleteExam({0});return false;") %>'
                                                                                        Visible='<%# Convert.ToBoolean(Eval("ActiveStatus")) %>' />
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

<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true"
    CodeBehind="MyExams.aspx.cs" Inherits="SecureProctor.Student.MyExams" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StudentContent" runat="server">
    <script language="javascript" type="text/javascript">
        function OpenSudentUpload(ID) {

            radopen("StudentUploadFile.aspx?TransID=" + ID, "Upload student files", 600, 550);
        }
        function closeWin() {
            var masterTable = $find("<%= gvStudentHome.ClientID %>").get_masterTableView();
            masterTable.rebind();

        }
    </script>
    <div class="app_container_inner">
        <div class="app_inner_content">
            <table cellpadding="2" cellspacing="2" width="100%">
                <tr>
                    <td>
                        <asp:Image ID="imgHead" runat="server" ImageUrl="../Images/Reschedule_cancel.png" AlternateText="My Exams" title="My Exams" TabIndex="11" />
                    </td>
                    <td width="1%" rowspan="3"></td>
                    <%--  <td>
                        <img src="../Images/ImgHelp.png" alt="Help" />
                    </td>--%>
                </tr>
                <tr>
                    <td width="70%" align="center" valign="top">
                        <div class="login_new1">
                            <telerik:RadGrid ID="gvStudentHome" runat="server" OnNeedDataSource="gvStudentHome_NeedDataSource" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" CellSpacing="0" MasterTableView-DataKeyNames="TransID"
                                GridLines="None" Skin="<%$ Resources:SecureProctor,Telerik_Grid_Skin %>" OnItemCommand="gvStudentHome_ItemCommand" OnItemDataBound="gvStudentHome_ItemDataBound">
                                <GroupingSettings CaseSensitive="false" />
                                <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD">
                                    <Columns>
                                        <telerik:GridTemplateColumn HeaderText="<%$ Resources:SecureProctor,Grid_Header_ExamID %>"
                                            SortExpression="TransID" UniqueName="TransID" HeaderStyle-HorizontalAlign="Center"
                                            DataField="TransID">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkTransID" runat="server" Text='<%# Bind("TransID")%>' CommandArgument='<%#Bind("TransID")%>'
                                                    Font-Underline="true" CommandName="ExamID" CssClass="GridLink" title="Click here to view the exam details"></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                                            <HeaderStyle Font-Bold="true" />
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="<%$ Resources:SecureProctor,Grid_Header_CourseName %>"
                                            SortExpression="CourseName" UniqueName="CourseName" HeaderStyle-HorizontalAlign="Center"
                                            DataField="CourseName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGridCourseName" runat="server" Text='<%# Bind("CourseName")%>' ToolTip='<%# Bind("CourseToolTip")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="20%" />
                                            <HeaderStyle Font-Bold="true" />
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="<%$ Resources:SecureProctor,Grid_Header_ExamName %>"
                                            SortExpression="ExamName" UniqueName="ExamName" HeaderStyle-HorizontalAlign="Center"
                                            DataField="ExamName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGridExamName" runat="server" Text='<%# Bind("ExamName")%>' ToolTip='<%# Bind("ExamToolTip")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="20%" />
                                            <HeaderStyle Font-Bold="true" />
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="ExamDate" HeaderText="<%$ Resources:SecureProctor,Grid_Header_ExamDate %>"
                                            SortExpression="ExamDate" UniqueName="ExamDate" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0:MM/dd/yyyy}">
                                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                                            <HeaderStyle Font-Bold="true" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="SlotStartTime" HeaderText="<%$ Resources:SecureProctor,Grid_Header_StartTime %>"
                                            SortExpression="SlotStartTime" UniqueName="SlotStartTime" HeaderStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                                            <HeaderStyle Font-Bold="true" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn DataField="StatusName" HeaderText="<%$ Resources:SecureProctor,Grid_Header_Status %>"
                                            SortExpression="StatusName" UniqueName="StatusName" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatusName" runat="server" Text='<%# Bind("StatusName")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="17%" />
                                            <HeaderStyle Font-Bold="true" />
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn Visible="false">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblStudentHeader" runat="server" Text="Upload file"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgUpload" runat="server" ImageUrl="~/Images/upload.png" OnClientClick='<%# Eval("TransID", "OpenSudentUpload({0});return false;") %>' CommandArgument='<%#Bind("ExamStudentUploadFile") %>' />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="20%" />
                                            <HeaderStyle />
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="<%$ Resources:SecureProctor,Grid_Header_ReschduleORCancel %>"
                                            HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkReschdule" runat="server" Text="<%$ Resources:SecureProctor,Grid_Header_ReschduleORCancelRowDesc %>"
                                                    CommandArgument='<%#Bind("ExamDate")%>' Font-Underline="true" CommandName="Reschdule"
                                                    Visible='<%# Convert.ToBoolean(Eval("VisibleStatus")) %>' CssClass="GridLink" title="Click here to reschedule or cancel the exam appointment"></asp:LinkButton>
                                                <asp:Label ID="lblReschdule" runat="server" Visible='<%# !Convert.ToBoolean(Eval("VisibleStatus")) %>' Text="<%$ Resources:SecureProctor,Grid_Header_ReschduleORCancelRowDesc %>"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                                            <HeaderStyle Font-Bold="true" />
                                        </telerik:GridTemplateColumn>
                                     
                                    </Columns>
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
            <div class="clear">
            </div>
        </div>
    </div>
</asp:Content>


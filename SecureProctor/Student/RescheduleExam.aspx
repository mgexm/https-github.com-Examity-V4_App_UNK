<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true"
    CodeBehind="RescheduleExam.aspx.cs" Inherits="SecureProctor.Student.RescheduleExam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StudentContent" runat="server">
    <div class="app_container_inner">
        <div class="app_inner_content">
            <table cellpadding="2" cellspacing="2" width="100%">
                <tr>
                    <td valign="top">
                        <img src="../Images/ImgReschedule.png" alt="reschedule" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td width="1%" rowspan="2">
                    </td>
                   <%-- <td>
                        <img src="../Images/ImgHelp.png" alt="Help" />
                    </td>--%>
                </tr>
                <tr>
                    <td width="70%" align="center" valign="top">
                        <div class="login_new1">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td>
                                        <telerik:RadGrid ID="gvReschedule" runat="server" OnNeedDataSource="gvReschedule_NeedDataSource"
                                            AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" Skin="<%$ Resources:SecureProctor,Telerik_Grid_Skin %>"
                                            CellSpacing="0" GridLines="None" OnItemCommand="gvReschedule_ItemCommand" EnableLinqExpressions="false">
                                            <GroupingSettings CaseSensitive="false" />
                                            <MasterTableView AllowFilteringByColumn="true" FilterItemStyle-BackColor="#DCEDFD">
                                                <Columns>
                                                     <telerik:GridBoundColumn DataField="TransID" HeaderText="<%$ Resources:SecureProctor,Grid_Header_TransactionID %>"
                                                        SortExpression="TransID" UniqueName="TransID" HeaderStyle-HorizontalAlign="Center" DataType="System.Int32">
                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                        <HeaderStyle Font-Bold="true" />
                                                    </telerik:GridBoundColumn>                                                    
                                                    <%--<telerik:GridMaskedColumn DataField="TransID" HeaderText="<%$ Resources:SecureProctor,Grid_Header_TransactionID %>"
                                                        SortExpression="TransID" UniqueName="TransID" FilterControlWidth="50px" AutoPostBackOnFilter="false"
                                                        CurrentFilterFunction="Contains" FilterDelay="2000" ShowFilterIcon="false" Mask="######">
                                                    </telerik:GridMaskedColumn>--%>
                                                    <telerik:GridBoundColumn DataField="CourseName" HeaderText="<%$ Resources:SecureProctor,Grid_Header_CourseName %>"
                                                        SortExpression="CourseName" UniqueName="CourseName" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                        <HeaderStyle Font-Bold="true" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="ExamName" HeaderText="<%$ Resources:SecureProctor,Grid_Header_ExamName %>"
                                                        SortExpression="ExamName" UniqueName="ExamName" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                        <HeaderStyle Font-Bold="true" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="ProviderName" HeaderText="<%$ Resources:SecureProctor,Grid_Header_ProviderName %>"
                                                        SortExpression="ProviderName" UniqueName="ProviderName" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                        <HeaderStyle Font-Bold="true" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="Date" HeaderText="<%$ Resources:SecureProctor,Grid_Header_ExamDate %>"
                                                        SortExpression="Date" UniqueName="ExamDate" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                        <HeaderStyle Font-Bold="true" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="Time" HeaderText="<%$ Resources:SecureProctor,Grid_Header_StartTime %>"
                                                        SortExpression="Time" UniqueName="SlotStartTime" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                        <HeaderStyle Font-Bold="true" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridTemplateColumn HeaderText="<%$ Resources:SecureProctor,Grid_Header_Reschedule %>"
                                                        HeaderStyle-HorizontalAlign="Center" AllowFiltering="false">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkReschedule" runat="server" Text="Reschedule" CommandArgument='<%#Bind("TransID")%>'
                                                                Font-Underline="true" CommandName="ReSchedule"></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                        <HeaderStyle Font-Bold="true" />
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="<%$ Resources:SecureProctor,Grid_Header_Cancel %>"
                                                        HeaderStyle-HorizontalAlign="Center" AllowFiltering="false">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkCancel" runat="server" Text="Cancel" Font-Underline="true"
                                                                CommandArgument='<%#Bind("TransID")%>' CommandName="Canel"></asp:LinkButton>
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
                                    </td>
                                </tr>
                                <div class="clear">
                                </div>
                            </table>
                        </div>
                    </td>
                    <td width="25%" rowspan="2" valign="top">
                        <div class="help_text_i">
                            <div class="help_text_i_inner">
                                <strong>How do I schedule for an exam?</strong>
                                <ul>
                                    <li>Select Course and Select Exam to view available times</li>
                                    <li>Right click on available time to schedule an exam</li>
                                    <li>If a slot is grayed out, its not a system issue. It just means that slot is full</li>
                                    <li>Select a preferred date (grayed dates mean they can't be selected)</li>
                                    <li>Select the time that suits you best.</li>
                                </ul>
                                <strong>What happens after I schedule?</strong>
                                <ul>
                                    <li>You will get an email confirming your schedule</li>
                                    <li>In the email, you will have instructions what to do before and during the exam</li>
                                </ul>
                                <strong>How do Reschedule/cancel?</strong>
                                <ul>
                                    <li>You can Reschedule at any time slot that best suits you</li>
                                    <li>You can Reschedule for an exam 24 hours before the previous scheduled time slot</li>
                                    <li>If a slot is grayed out, it's not a system issue. It just means that slot is full</li>
                                </ul>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
            <div class="clear">
            </div>
        </div>
    </div>
</asp:Content>

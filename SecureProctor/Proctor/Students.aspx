<%@ Page Title="" Language="C#" MasterPageFile="~/Proctor/Proctor.Master" AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="SecureProctor.Proctor.Students" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ProctorContent" runat="server">

  
    <asp:UpdatePanel ID="upExams" runat="server">
        <ContentTemplate>
            <table cellpadding="2" cellspacing="2" width="100%">
                <tr>
                  <td>
                        <table width="100%">
                            <tr>
                                <td>
                                    <div class="heading customfont1">
                                        <img src="../Images/ImgStudent_lookup.png" />
                                    </div>
                                </td>
                            </tr>
             


                        </table>


                    </td>
                </tr>
                <tr>
                    <td align="right">
                     <asp:LinkButton ID="lnkStudentLookup" runat="server" Text="Student/ExamLookup" Font-Size="Medium"
                            ToolTip="Click here for student details" Font-Bold="true" Font-Underline="true" ForeColor="Black"
                            OnClick="lnkStudentLookup_Click"></asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;

                    </td>

                </tr>
                  <tr><td>&nbsp;&nbsp;</td></tr>
                <tr>
                    <td width="100%" align="center" valign="top">
                        <div class="login_new1">
                            <telerik:RadGrid ID="gvStudents" runat="server" OnNeedDataSource="gvStudents_NeedDataSource"
                                AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" Skin="<%$ Resources:AppConfigurations,Skin_Current %>"
                                CellSpacing="0" GridLines="None" AllowFilteringByColumn="false" OnItemCommand="gvStudents_ItemCommand">
                                <GroupingSettings CaseSensitive="false" />
                                <MasterTableView AllowFilteringByColumn="true" FilterItemStyle-BackColor="#DCEDFD"
                                    FilterItemStyle-HorizontalAlign="Center" CommandItemDisplay="Top" DataKeyNames="StudentID"
                                    EditMode="PopUp">
                                  
                                    <CommandItemTemplate>
                                       
                                    </CommandItemTemplate>
                                    <Columns>

                                          <telerik:GridBoundColumn DataField="UserName" HeaderText="User Name"
                                            SortExpression="UserName" UniqueName="UserName" HeaderStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" Width="27%" />
                                            <HeaderStyle Font-Bold="true" />
                                        </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="FirstName" HeaderText="<%$ Resources:AppControls,Admin_Students_GridHeader_StudentFirstName %>"
                                            SortExpression="FirstName" UniqueName="FirstName" HeaderStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" Width="27%" />
                                            <HeaderStyle Font-Bold="true" />
                                        </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="LastName" HeaderText="<%$ Resources:AppControls,Admin_Students_GridHeader_StudentLastName %>"
                                            SortExpression="LastName" UniqueName="LastName" HeaderStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" Width="27%" />
                                            <HeaderStyle Font-Bold="true" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="EmailAddress" HeaderText="<%$ Resources:AppControls,Admin_Students_GridHeader_EmailAddress %>"
                                            SortExpression="EmailAddress" UniqueName="EmailAddress" HeaderStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" Width="35%" />
                                            <HeaderStyle Font-Bold="true" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn HeaderText="Profile Update"
                                            HeaderStyle-HorizontalAlign="Center" SortExpression="VerificationStatus" AllowFiltering="false">
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
                                            HeaderStyle-HorizontalAlign="Center" SortExpression="SpecialNeeds" AllowFiltering="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSpecialNeeds" runat="server" Text='<%# Eval("SpecialNeeds")%>' />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                            <HeaderStyle Font-Bold="true" />
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="<%$ Resources:AppControls,Admin_Students_GridHeader_Actions %>"
                                            HeaderStyle-HorizontalAlign="Center" AllowFiltering="false" Visible="false">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="BtnViewStudent" runat="server" ImageUrl="~/Images/View_s.png"
                                                    CommandArgument='<%#Eval("StudentID") %>' CommandName="View" ToolTip="View Student Details"
                                                    Width="16" Height="16"></asp:ImageButton>&nbsp;&nbsp;
                                          
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="23%" />
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
                                                                <telerik:RadGrid ID="gvEnrollments" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                                                    AllowSorting="True" Skin="<%$ Resources:AppConfigurations,Skin_Current %>" CellSpacing="0"
                                                                    GridLines="None">
                                                                    <GroupingSettings CaseSensitive="false" />
                                                                    <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD"
                                                                        FilterItemStyle-HorizontalAlign="Center">
                                                                        <Columns>
                                                                            <telerik:GridBoundColumn DataField="CourseName" HeaderText="<%$ Resources:AppControls,Admin_Students_GridHeader_CourseName %>"
                                                                                SortExpression="CourseName" UniqueName="CourseName" HeaderStyle-HorizontalAlign="Center">
                                                                                <ItemStyle HorizontalAlign="Center" Width="35%" />
                                                                                <HeaderStyle Font-Bold="true" />
                                                                            </telerik:GridBoundColumn>
                                                                            <telerik:GridBoundColumn DataField="ProviderName" HeaderText="<%$ Resources:AppControls,Admin_Students_GridHeader_ProviderName %>"
                                                                                SortExpression="ProviderName" UniqueName="ProviderName" HeaderStyle-HorizontalAlign="Center">
                                                                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                                                <HeaderStyle Font-Bold="true" />
                                                                            </telerik:GridBoundColumn>
                                                                            <telerik:GridBoundColumn DataField="Status" HeaderText="<%$ Resources:AppControls,Admin_Students_GridHeader_EnrollmentStatus %>"
                                                                                SortExpression="Status" UniqueName="Status" HeaderStyle-HorizontalAlign="Center">
                                                                                <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                                                <HeaderStyle Font-Bold="true" />
                                                                            </telerik:GridBoundColumn>
                                                                            <telerik:GridBoundColumn DataField="EnrollDate" HeaderText="<%$ Resources:AppControls,Admin_Students_GridHeader_EnrollmentDate %>"
                                                                                SortExpression="EnrollDate" UniqueName="EnrollDate" HeaderStyle-HorizontalAlign="Center">
                                                                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                                                <HeaderStyle Font-Bold="true" />
                                                                            </telerik:GridBoundColumn>
                                                                            
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

<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="AdminViewUserDetails.aspx.cs" Inherits="SecureProctor.Admin.AdminViewUserDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminContent" runat="server">
    <div class="app_container_inner">
        <div class="app_inner_content">
            <asp:UpdatePanel ID="ViewUserDetail" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table cellpadding="0" width="100%">
                        <tr>
                            <td>
                                <img src="../Images/Imgstudent_details.png" alt="validate " />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="login_new1">
                                    <table cellpadding="2" cellspacing="2" width="100%">
                                        <tr valign="top">
                                            <td>
                                                <table cellpadding="0" cellspacing="0" width="100%" border="0" style="vertical-align: middle;"
                                                    align="center">
                                                    <tr>
                                                        <td style="width: 50%;" valign="top">
                                                            <table width="100%" cellpadding="2" cellspacing="0">
                                                                <tr>
                                                                    <td align="center" valign="top" style="background: #f6f6f6; line-height: 30px;">
                                                                        <asp:Label ID="lblstudentfirstname" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;
                                                                        [
                                                                        <asp:Label ID="lblEmail" runat="server"></asp:Label>
                                                                        ]
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center">
                                                                        <asp:Image ID="imgstudent" runat="server" Width="292" Height="183" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td style="width: 50%;" align="right" valign="top">
                                                            <table width="100%" cellpadding="2" cellspacing="0">
                                                                <tr>
                                                                    <td>
                                                                        <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                                                            <tr class="gridviewHeaderstyle">
                                                                                <td align="left" colspan="4" style="line-height: 35px;">
                                                                                    &nbsp;&nbsp;&nbsp;<strong>Student Profile</strong>
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="gridviewAlternatestyle">
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td align="left">
                                                                                    <strong>Phone Number</strong>&nbsp;&nbsp;&nbsp;
                                                                                </td>
                                                                                <td align="left">
                                                                                    :
                                                                                    <asp:Label ID="lblPhoneNumber" runat="server"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="gridviewRowstyle">
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td align="left">
                                                                                    <strong>Time Zone</strong>&nbsp;&nbsp;&nbsp;
                                                                                </td>
                                                                                <td align="left">
                                                                                    :
                                                                                    <asp:Label ID="lblTimeZone" runat="server"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="gridviewAlternatestyle">
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td align="left">
                                                                                    <strong>Special Accommodations</strong>&nbsp;&nbsp;&nbsp;
                                                                                </td>
                                                                                <td align="left">
                                                                                    :
                                                                                    <asp:Label ID="lblSpecialNeeds" runat="server"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="gridviewRowstyle">
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td align="left">
                                                                                    <strong>Comments</strong>&nbsp;&nbsp;&nbsp;
                                                                                </td>
                                                                                <td align="left">
                                                                                    :
                                                                                    <asp:Label ID="lblComments" runat="server"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                        </table>
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
                                                <telerik:RadGrid ID="gvStudentExamStatus" runat="server" OnNeedDataSource="gvStudentExamStatus_NeedDataSource"
                                                    AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" CellSpacing="0" EnableLinqExpressions="false"
                                                    GridLines="None" Skin="<%$ Resources:SecureProctor,Telerik_Grid_Skin %>" OnItemDataBound="gvStudentExamStatus_ItemDataBound" OnSortCommand="gvStudentExamStatus_SortCommand"
                                                    OnItemCommand="gvStudentExamStatus_ItemCommand">
                                                    <GroupingSettings CaseSensitive="false" />
                                                    <MasterTableView AllowFilteringByColumn="true" FilterItemStyle-BackColor="#DCEDFD" AllowNaturalSort="false">
                                                        <Columns>
                                                            <telerik:GridBoundColumn DataField="TransID" HeaderText="<%$ Resources:SecureProctor,Grid_Header_TransactionID %>"
                                                                SortExpression="TransID" UniqueName="TransID" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <HeaderStyle Font-Bold="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="CourseName" HeaderText="<%$ Resources:SecureProctor,Grid_Header_CourseName %>"
                                                                SortExpression="CourseName" UniqueName="CourseName" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <HeaderStyle Font-Bold="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="ExamName" HeaderText="<%$ Resources:SecureProctor,Grid_Header_ExamName %>"
                                                                SortExpression="ExamName" UniqueName="ExamName" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <HeaderStyle Font-Bold="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="ExamDate" HeaderText="<%$ Resources:SecureProctor,Grid_Header_ExamDate %>"
                                                                SortExpression="ExamDate" UniqueName="ExamDate" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <HeaderStyle Font-Bold="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridTemplateColumn HeaderText="<%$ Resources:SecureProctor,Grid_Header_ExamSecurityLevel %>"
                                                                SortExpression="SecurityDescription" DataField="SecurityDescription" HeaderStyle-HorizontalAlign="Center" FilterControlWidth="46px">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSecurity" runat="server" Text='<%# Eval("SecurityDescription")  %>' ToolTip='<%# Eval("SecurityToolTip")  %>' />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                                <HeaderStyle Font-Bold="true" />
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="<%$ Resources:SecureProctor,Grid_Header_ExamStatus %>"
                                                                HeaderStyle-HorizontalAlign="Center" SortExpression="Status" DataField="Status">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblExamStatus" runat="server" Text='<%# Eval("Status")%>' />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <HeaderStyle Font-Bold="true" />
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridBoundColumn DataField="Alert" HeaderText="<img src='../Images/ImgAlert.png' alt='my image' />"
                                                                SortExpression="Alert" UniqueName="Alert" HeaderStyle-HorizontalAlign="Center" AllowFiltering="false" >
                                                                <ItemStyle HorizontalAlign="Center"/>
                                                                <HeaderStyle Font-Bold="true" />
                                                            </telerik:GridBoundColumn>
                                                           
                                                          

                                                             <telerik:GridBoundColumn DataField="Green" HeaderText="<img src='../Images/flag_g.png' alt='my image' />"
                                                                SortExpression="Green" UniqueName="Green" HeaderStyle-HorizontalAlign="Center"
                                                                AllowFiltering="false">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <HeaderStyle Font-Bold="true" />
                                                            </telerik:GridBoundColumn>

                                                              <telerik:GridBoundColumn DataField="Orange" HeaderText="<img src='../Images/flag_y.png' alt='my image' />"
                                                                SortExpression="Orange" UniqueName="Orange" HeaderStyle-HorizontalAlign="Center"
                                                                AllowFiltering="false">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <HeaderStyle Font-Bold="true" />
                                                            </telerik:GridBoundColumn>



                                                            <telerik:GridBoundColumn DataField="Red" HeaderText="<img src='../Images/flag.png' alt='my image' />"
                                                                SortExpression="Red" UniqueName="Red" HeaderStyle-HorizontalAlign="Center" AllowFiltering="false">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <HeaderStyle Font-Bold="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridTemplateColumn HeaderText="<%$ Resources:SecureProctor,Grid_Header_View %>"
                                                                HeaderStyle-HorizontalAlign="Center" AllowFiltering="false">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkView" runat="server" Text="<%$ Resources:SecureProctor,Grid_Header_View %>"
                                                                        CommandArgument='<%# Eval("TransID")%>' Font-Underline="true" ForeColor="Blue"
                                                                        Visible="false" CommandName="view"></asp:LinkButton>
                                                                    <asp:Label ID="lblView" runat="server" Text='View' Visible="false" />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
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
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

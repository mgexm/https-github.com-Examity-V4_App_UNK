<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Auditor/Auditor.Master"
    CodeBehind="ViewStudentDetails.aspx.cs" Inherits="SecureProctor.Auditor.ViewStudentDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AuditorContent" runat="server">
    <div class="app_container_inner">
        <div class="app_inner_content">
            <table cellpadding="2" width="100%">
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
                                        <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                            <tr>
                                                <td style="width: 50%;" valign="top">
                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                        <tr style="background: #f6f6f6; line-height: 30px;">
                                                            <td align="center" valign="top">
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
                                                <td style="width: 50%;" valign="top">
                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                        <tr class="gridviewHeaderstyle">
                                                            <td align="left" colspan="4" style="line-height: 35px;">
                                                                &nbsp;&nbsp;&nbsp;<strong>Student Profile</strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <table cellpadding="0" cellspacing="0" width="100%" border="0">
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
                                                                            <strong>Special accommodations</strong>&nbsp;&nbsp;&nbsp;
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
                                <%--<tr id="trGridPages" runat="server">
                                    <td colspan="7">
                                        <table cellpadding="0" cellspacing="0" width="100%">
                                            <tr class="subHeadfont">
                                                <td width="2%">
                                                    &nbsp;
                                                </td>
                                                <td align="left" width="66%">
                                                </td>
                                                <td align="right" width="30%">
                                                    Page Size :&nbsp;<asp:DropDownList ID="ddlpagesize" runat="server" AutoPostBack="True"
                                                        OnSelectedIndexChanged="ddlpagesize_SelectedIndexChanged" SkinID="ddl">
                                                        <asp:ListItem>10</asp:ListItem>
                                                        <asp:ListItem>25</asp:ListItem>
                                                        <asp:ListItem>50</asp:ListItem>
                                                    </asp:DropDownList>
                                                    &nbsp;
                                                    <asp:ImageButton ID="ImgFirstPage" CommandName="FirstPage" ImageUrl="~/Images/btnPageFirst.gif"
                                                        runat="server" OnClick="ImgPaging_Click" />&nbsp;
                                                    <asp:ImageButton ID="ImgPreviousPage" CommandName="PreviousPage" ImageUrl="~/Images/btnPagePrevious.gif"
                                                        runat="server" OnClick="ImgPaging_Click" />&nbsp;&nbsp; Page&nbsp;:
                                                    <asp:DropDownList ID="ddlCurrentPage" runat="server" OnSelectedIndexChanged="ddlCurrentPage_SelectedIndexChanged"
                                                        AutoPostBack="True">
                                                    </asp:DropDownList>
                                                    &nbsp;/&nbsp;<asp:Label ID="lblTotalPages" runat="server" Text=""></asp:Label>&nbsp;&nbsp;
                                                    <asp:ImageButton ID="ImgNextPage" CommandName="NextPage" ImageUrl="~/Images/btnPageNext.gif"
                                                        runat="server" OnClick="ImgPaging_Click" />&nbsp;
                                                    <asp:ImageButton ID="ImgLastPage" CommandName="LastPage" ImageUrl="~/Images/btnPageLast.gif"
                                                        runat="server" OnClick="ImgPaging_Click" />
                                                </td>
                                                <td width="2%">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td colspan="7">
                                        <%--<asp:GridView ID="gvExamStatus" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                            CellPadding="3" GridLines="Both" AllowSorting="true" PagerSettings-Visible="false"
                                            OnRowCommand="gvExamStatus_RowCommand" OnSorting="gvExamStatus_Sorting" Width="100%">
                                            <HeaderStyle CssClass="gridviewHeaderstyle" />
                                            <RowStyle CssClass="gridviewRowstyle" />
                                            <AlternatingRowStyle CssClass="gridviewAlternatestyle" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="ID" SortExpression="TransID">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTransID" runat="server" Text='<%# Eval("TransID")%>' />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Course Name" SortExpression="CourseName">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCourseName" runat="server" Text='<%# Eval("CourseName")%>' />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Exam Name" SortExpression="ExamName">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblExamName" runat="server" Text='<%# Eval("ExamName")%>' />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Exam Status" SortExpression="Status">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblExamStatus" runat="server" Text='<%# Eval("Status")%>' />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<img src='../Images/flag_g.png' alt='my image' />"
                                                    SortExpression="Green">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGreen" runat="server" Text='<%# Eval("Green")%>' />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<img src='../Images/flag_y.png' alt='my image' />"
                                                    SortExpression="Orange">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOrange" runat="server" Text='<%# Eval("Orange")%>' />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<img src='../Images/flag.png' alt='my image' />" SortExpression="Red">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRed" runat="server" Text='<%# Eval("Red")%>' />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="View">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkView" runat="server" Text="View" CommandArgument='<%# Eval("TransID")%>'
                                                            Font-Underline="true" ForeColor="Blue" CommandName="ViewVideo"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="8%" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>--%>
                                        <div class="login_new1">
                                            <telerik:RadGrid ID="gvExamStatus" runat="server" OnNeedDataSource="gvExamStatus_NeedDataSource"
                                                AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" Skin="<%$ Resources:SecureProctor,Telerik_Grid_Skin %>"
                                                CellSpacing="0" GridLines="None" OnItemCommand="gvExamStatus_ItemCommand" OnItemDataBound="gvExamStatus_ItemDataBound" OnSortCommand="gvExamStatus_SortCommand">
                                                 <GroupingSettings CaseSensitive="false" />
                                                <MasterTableView AllowFilteringByColumn="true" FilterItemStyle-BackColor="#DCEDFD" AllowNaturalSort="false">
                                                    <Columns>
                                                        <telerik:GridTemplateColumn HeaderText="<%$ Resources:SecureProctor,Grid_Header_TransactionID %>"
                                                            HeaderStyle-HorizontalAlign="Center" DataField="TransID" SortExpression="TransID"
                                                            UniqueName="TransID" FilterControlWidth="40px">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblExamID" runat="server" Text='<%# Eval("TransID")%>' />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridBoundColumn DataField="CourseName" HeaderText="<%$ Resources:SecureProctor,Grid_Header_CourseName %>"
                                                            SortExpression="CourseName" UniqueName="CourseName" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" Width="25%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="ExamName" HeaderText="<%$ Resources:SecureProctor,Grid_Header_ExamName %>"
                                                            SortExpression="ExamName" UniqueName="ExamName" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridBoundColumn>

                                                        <%--<telerik:GridBoundColumn DataField="ProviderName" HeaderText="<%$ Resources:SecureProctor,Grid_Header_ProviderName %>"
                                                            SortExpression="ProviderName" UniqueName="ProviderName" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridBoundColumn>--%>
                                                        <telerik:GridBoundColumn DataField="ProviderFirstName" HeaderText="<%$ Resources:SecureProctor,Grid_Header_ProviderFirstName %>"
                                                            SortExpression="ProviderFirstName" UniqueName="ProviderFirstName" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="ProviderLastName" HeaderText="<%$ Resources:SecureProctor,Grid_Header_ProviderLastName %>"
                                                            SortExpression="ProviderLastName" UniqueName="ProviderLastName" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" Width="20%" />
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
                                                        <%-- <telerik:GridBoundColumn DataField="Status" HeaderText="<%$ Resources:SecureProctor,Grid_Header_Status %>"
                                                            SortExpression="Status" UniqueName="Status" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridBoundColumn>--%>
                                                        <telerik:GridTemplateColumn HeaderText="<%$ Resources:SecureProctor,Grid_Header_ExamStatus %>"
                                                            HeaderStyle-HorizontalAlign="Center" SortExpression="Status" DataField="Status">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblExamStatus" runat="server" Text='<%# Eval("Status")%>' />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridBoundColumn DataField="Alert" HeaderText="<img src='../Images/ImgAlert.png' alt='my image' />"
                                                            SortExpression="Alert" UniqueName="Alert" HeaderStyle-HorizontalAlign="Center" AllowFiltering="false">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridBoundColumn>
                                                      
                                                       

                                                          <telerik:GridBoundColumn DataField="Green" HeaderText="<img src='../Images/flag_g.png' alt='my image' />"
                                                            SortExpression="Green" UniqueName="Green" HeaderStyle-HorizontalAlign="Center" AllowFiltering="false">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridBoundColumn>


                                                         <telerik:GridBoundColumn DataField="Orange" HeaderText="<img src='../Images/flag_y.png' alt='my image' />"
                                                            SortExpression="Orange" UniqueName="Orange" HeaderStyle-HorizontalAlign="Center" AllowFiltering="false">
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
                                                                <asp:LinkButton ID="lnkView" runat="server" Text="View" CommandArgument='<%# Eval("TransID")%>'
                                                                    Font-Underline="true" ForeColor="Blue" CommandName="ViewVideo" Visible="false"></asp:LinkButton>
                                                                <asp:Label ID="lblView" runat="server" Text='View' Visible="false" />


                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridTemplateColumn>
                                                    </Columns>
                                                    <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                                </MasterTableView>
                                                <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                                <FilterMenu EnableImageSprites="False">
                                                </FilterMenu>
                                            </telerik:RadGrid>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

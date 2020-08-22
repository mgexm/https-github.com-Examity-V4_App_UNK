<%@ Page Title="" Language="C#" MasterPageFile="~/Auditor/Auditor.Master" AutoEventWireup="true" CodeBehind="StudentLookup.aspx.cs" Inherits="SecureProctor.Auditor.StudentLookup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AuditorContent" runat="server">
<div class="app_container_inner">
                <div class="app_inner_content">
                    <table width="100%">
                        <tr>
                            <td>
                                <img src="../Images/ImgStudent_lookup.png" alt="home" />
                            </td>
                            <td valign="middle" align="right">                                
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div class="login_new1">
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr id="trGridPages" runat="server">
                                            <td colspan="5">
                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="2%">
                                                            &nbsp;
                                                        </td>
                                                        <%--<td align="left" width="60%">
                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    
                                                                    <td align="right" width="14%">
                                                                        <strong>
                                                                            <asp:Label ID="lblSelectCourse" runat="server" Text="Student Name :"></asp:Label>
                                                                        </strong>&nbsp;&nbsp;
                                                                    </td>
                                                                    <td align="left" width="16%">
                                                                        <asp:TextBox ID="txtStudentName" runat="server" Width="100%" MaxLength="100"></asp:TextBox>
                                                                    </td>
                                                                    <td align="right" width="14%">
                                                                        <strong>
                                                                            <asp:Label ID="lblSelectExam" runat="server" Text="Email Adddress :"></asp:Label>
                                                                        </strong>&nbsp;&nbsp;
                                                                    </td>
                                                                    <td align="left" width="16%">
                                                                        <asp:TextBox ID="txtEmailAddress" runat="server" Width="100%" MaxLength="100"></asp:TextBox>
                                                                    </td>
                                                                    <td align="right" width="5%">
                                                                        <asp:ImageButton ID="btnSearch" runat="server" alt="Search" ImageUrl="~/Images/ImgSearch.png" OnClick="btnSearch_Click"
                                                                            />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>--%>
                                                        <td align="right" width="34%">
                                                            <%--Page Size :&nbsp;<asp:DropDownList ID="ddlpagesize" runat="server" AutoPostBack="True"
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
                                                                runat="server" OnClick="ImgPaging_Click" />--%>
                                                        </td>
                                                        <td width="2%">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5">
                                                <telerik:RadGrid ID="gvStudentLookUp" runat="server" OnNeedDataSource="gvStudentLookUp_NeedDataSource"
                                            AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" Skin="<%$ Resources:SecureProctor,Telerik_Grid_Skin %>"
                                            CellSpacing="0" GridLines="None">
                                             <GroupingSettings CaseSensitive="false" />
                                            <MasterTableView AllowFilteringByColumn="true" FilterItemStyle-BackColor="#DCEDFD">
                                                <Columns>
                                                    <telerik:GridTemplateColumn HeaderText="<%$ Resources:SecureProctor,Grid_Header_StudentFirstName %>"
                                                        HeaderStyle-HorizontalAlign="Center" DataField="FirstName" SortExpression="FirstName"
                                                        UniqueName="FirstName">
                                                        <ItemTemplate>
                                                            <%--<asp:LinkButton ID="lblFirstName" runat="server" Text='<%# Eval("FirstName")%>'
                                                                OnClick="lblStudentName_Click" CommandArgument='<%#Eval("UserID") %>' Font-Underline="true"></asp:LinkButton>--%>
                                                       <asp:HyperLink ID="btnStudentFirstName" runat="server" Text='<%# Eval("FirstName")%>'
                                                                        CommandArgument='<%# Eval("UserID")%>' Font-Underline="true"   NavigateUrl='<%#GetStudentUrl(Eval("UserID").ToString())%>' Target="_blank" >
                                                                    </asp:HyperLink>
                                                              </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                        <HeaderStyle Font-Bold="true" />
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="<%$ Resources:SecureProctor,Grid_Header_StudentLastName %>"
                                                        HeaderStyle-HorizontalAlign="Center" DataField="LastName" SortExpression="LastName"
                                                        UniqueName="LastName">
                                                        <ItemTemplate>
                                                           <%-- <asp:LinkButton ID="lblLastName" runat="server" Text='<%# Eval("LastName")%>'
                                                                OnClick="lblStudentName_Click" CommandArgument='<%#Eval("UserID") %>' Font-Underline="true"></asp:LinkButton>--%>
                                                        <asp:HyperLink ID="btnStudentLastName" runat="server" Text='<%# Eval("LastName")%>'
                                                                        CommandArgument='<%# Eval("UserID")%>' Font-Underline="true"   NavigateUrl='<%#GetStudentUrl(Eval("UserID").ToString())%>' Target="_blank" >
                                                                    </asp:HyperLink>
                                                             </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                        <HeaderStyle Font-Bold="true" />
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridBoundColumn DataField="EmailAddress" HeaderText="<%$ Resources:SecureProctor,Grid_Header_EmailAddress %>"
                                                        SortExpression="EmailAddress" UniqueName="EmailAddress" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="20%" />
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
                                </div>
                            </td>
                        </tr>
                    </table>
                    <div class="clear">
                    </div>
                </div>
            </div>
</asp:Content>

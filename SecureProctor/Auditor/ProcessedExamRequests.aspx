<%@ Page Title="" Language="C#" MasterPageFile="~/Auditor/Auditor.Master" AutoEventWireup="true"
    CodeBehind="ProcessedExamRequests.aspx.cs" Inherits="SecureProctor.Auditor.ProcessedExamRequests" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AuditorContent" runat="server">
     <Style type="text/css">
         .itemNameColumn span
{
    display: block;
    width: 500px; 
  
    word-wrap: break-word; 
  
}
     </Style>
    <div class="app_container_inner">
        <div class="app_inner_content">
            <table width="100%">
                <tr>
                    <td align="left" width="75%" valign="top">
                        <img src="../Images/processedER.png" alt="processed exam requests" />
                       <%-- <table width="100%" style="margin-top:25px;">
                                   
                                     <tr>

                                         
                                         <td align="left" width="80%"  valign="middle">
                                <asp:Label ID="Label2"  runat="server" Text="Exams scheduled during:" Font-Bold="true"></asp:Label>

                                &nbsp;&nbsp;&nbsp;
                                
                                <telerik:RadComboBox ID="ddlShowExams" runat="server" DropDownAutoWidth="Enabled"
                                                                    AppendDataBoundItems="true" Skin="<%$ Resources:SecureProctor,Telerik_ComboBox_Skin %>">
                                <Items>

                                    <telerik:RadComboBoxItem Text="Past 30 days" Value="-30" />
                                    <telerik:RadComboBoxItem Text="Past 60 days" Value="-60" />
                                    <telerik:RadComboBoxItem Text="Past 90 days" Value="-90" />
                                     
                                    <telerik:RadComboBoxItem Text="2013" Value="2013" />
                                    <telerik:RadComboBoxItem Text="2014" Value="2014" />

                                </Items>

                                                                </telerik:RadComboBox>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                              <telerik:RadButton ID="RadButton1" runat="server" Text="Search" OnClick ="btnSearch_Click"
                                   Skin="<%$ Resources:AppConfigurations,Skin_Current %>" />

                            </td>
                                       

                                     </tr>

                                </table>--%>


                    </td>
                      <td width="25%" valign="middle">
                                <table cellpadding="0" cellspacing="7" width="100%">
                                   <tr>
                                   <td valign="middle"><img src="../Images/ImgAlert.png" /></td>
                                   <td valign="middle" align="left">Alert</td>
                                    <td valign="middle"><img src="../Images/flag_g.png" /></td>
                                    <td valign="middle" align="left">No Violation</td>
                                       </tr><tr>
                                    <td valign="middle"><img src="../Images/flag_y.png" /></td>
                                   <td valign="middle" align="left">Possible Violation</td>
                                   
                                    <td valign="middle"  ><img src="../Images/flag.png" /></td>
                                    <td valign="middle" align="left">Violation</td>
                                    </tr>
                                  
                                </table>
                            </td>
                </tr>
                <tr>
                    <td align="right" colspan="2">
                        <asp:LinkButton ID="lblinboxlink" runat="server" Text="Go to Inbox" 
                            ToolTip="Go to Inbox" Font-Bold="true" Font-Underline="true"  ForeColor="Black"
                            onclick="lblinboxlink_Click"></asp:LinkButton>&nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div class="login_new1">
                            <table cellpadding="0" cellspacing="0" width="100%">
                               <%-- <tr id="trGridPages" runat="server">
                                    <td colspan="5">
                                        <table cellpadding="0" cellspacing="0" width="100%">
                                             <tr>
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
                                    <td>
                                        <telerik:RadGrid ID="gvProcessedExamRequest" runat="server" 
                                            AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" Skin="<%$ Resources:SecureProctor,Telerik_Grid_Skin %>"
                                            CellSpacing="0" GridLines="None" OnItemCommand="gvProcessedExamRequest_ItemCommand" EnableLinqExpressions="false" OnNeedDataSource="gvProcessedExamRequest_NeedDataSource" OnSortCommand="gvProcessedExamRequest_SortCommand">
                                             <GroupingSettings CaseSensitive="false" />
                                            <MasterTableView AllowFilteringByColumn="true" FilterItemStyle-BackColor="#DCEDFD" AllowNaturalSort="false">
                                                <Columns>
                                                    <telerik:GridTemplateColumn HeaderText="<%$ Resources:SecureProctor,Grid_Header_TransactionID %>"
                                                        HeaderStyle-HorizontalAlign="Center" DataField="TransID" SortExpression="TransID"
                                                        UniqueName="TransID" DataType="System.Int32" FilterControlWidth="50%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblExamID" runat="server" Text='<%# Eval("TransID")%>' />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="2%" />
                                                        <HeaderStyle Font-Bold="true" />
                                                    </telerik:GridTemplateColumn>
                                               
                                                    <telerik:GridTemplateColumn HeaderText="<%$ Resources:SecureProctor,Grid_Header_StudentFirstName %>"
                                                        HeaderStyle-HorizontalAlign="Center" DataField="FirstName" SortExpression="FirstName" FilterControlWidth="50%"
                                                        UniqueName="FirstName">
                                                        <ItemTemplate>
                                                           <%-- <asp:LinkButton ID="btnStudentFirstName" runat="server" Text='<%# Eval("FirstName")%>'
                                                                OnClick="lblStudentName_Click" CommandArgument='<%#Eval("UserID") %>' Font-Underline="true"></asp:LinkButton>--%>
                                                        <asp:HyperLink ID="btnStudentFirstName" runat="server" Text='<%# Eval("FirstName")%>'
                                                                        CommandArgument='<%# Eval("UserID")%>' Font-Underline="true"   NavigateUrl='<%#GetStudentUrl(Eval("UserID").ToString())%>' Target="_blank" >
                                                                    </asp:HyperLink>
                                                             </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                        <HeaderStyle Font-Bold="true" />
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="<%$ Resources:SecureProctor,Grid_Header_StudentLastName %>"
                                                        HeaderStyle-HorizontalAlign="Center" DataField="LastName" SortExpression="LastName" FilterControlWidth="50%"
                                                        UniqueName="LastName">
                                                        <ItemTemplate>
                                                           <%-- <asp:LinkButton ID="btnStudentLastName" runat="server" Text='<%# Eval("LastName")%>'
                                                                OnClick="lblStudentName_Click" CommandArgument='<%#Eval("UserID") %>' Font-Underline="true"></asp:LinkButton>--%>
                                                       <asp:HyperLink ID="btnStudentLastName" runat="server" Text='<%# Eval("LastName")%>'
                                                                        CommandArgument='<%# Eval("UserID")%>' Font-Underline="true"   NavigateUrl='<%#GetStudentUrl(Eval("UserID").ToString())%>' Target="_blank" >
                                                                    </asp:HyperLink>
                                                             </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                        <HeaderStyle Font-Bold="true" />
                                                    </telerik:GridTemplateColumn>
                                                     <telerik:GridBoundColumn DataField="CourseName" HeaderText="<%$ Resources:SecureProctor,Grid_Header_CourseName %>"
                                                        SortExpression="CourseName" UniqueName="CourseName" ItemStyle-CssClass="itemNameColumn" HeaderStyle-HorizontalAlign="Center" FilterControlWidth="60%">
                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                        <HeaderStyle Font-Bold="true" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="ExamName" HeaderText="<%$ Resources:SecureProctor,Grid_Header_ExamName %>"
                                                        SortExpression="ExamName" UniqueName="ExamName" ItemStyle-CssClass="itemNameColumn" HeaderStyle-HorizontalAlign="Center" FilterControlWidth="60%">
                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                        <HeaderStyle Font-Bold="true" />
                                                    </telerik:GridBoundColumn>
                                                  <telerik:GridBoundColumn DataField="ExamDate" HeaderText="<%$ Resources:SecureProctor,Grid_Header_ExamDate %>"
                                                        SortExpression="ExamDate" UniqueName="ExamDate" HeaderStyle-HorizontalAlign="Center" FilterControlWidth="60%">
                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                        <HeaderStyle Font-Bold="true" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="ProviderFirstName" HeaderText="<%$ Resources:SecureProctor,Grid_Header_ProviderFirstName %>"
                                                        SortExpression="ProviderFirstName" UniqueName="ProviderFirstName" HeaderStyle-HorizontalAlign="Center" FilterControlWidth="60%">
                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                        <HeaderStyle Font-Bold="true" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="ProviderLastName" HeaderText="<%$ Resources:SecureProctor,Grid_Header_ProviderLastName %>"
                                                        SortExpression="ProviderLastName" UniqueName="ProviderLastName" HeaderStyle-HorizontalAlign="Center" FilterControlWidth="60%">
                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                        <HeaderStyle Font-Bold="true" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridTemplateColumn HeaderText="<%$ Resources:SecureProctor,Grid_Header_ExamSecurityLevel %>"
                                                        SortExpression="SecurityDescription" DataField="SecurityDescription" HeaderStyle-HorizontalAlign="Center" FilterControlWidth="60%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSecurity" runat="server" Text='<%# Eval("SecurityDescription")  %>' ToolTip='<%# Eval("SecurityToolTip")  %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                        <HeaderStyle Font-Bold="true" />
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridBoundColumn DataField="Status" HeaderText="<%$ Resources:SecureProctor,Grid_Header_Status %>"
                                                        SortExpression="Status" UniqueName="Status" HeaderStyle-HorizontalAlign="Center" FilterControlWidth="40px">
                                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                        <HeaderStyle Font-Bold="true" />
                                                    </telerik:GridBoundColumn>
                                                  
                                                    <telerik:GridBoundColumn DataField="Alert" HeaderText="<img src='../Images/ImgAlert.png' alt='my image' />"
                                                        SortExpression="Alert" UniqueName="Alert" HeaderStyle-HorizontalAlign="Center" AllowFiltering="false">
                                                        <ItemStyle HorizontalAlign="Center" Width="3%"/>
                                                        <HeaderStyle Font-Bold="true" />
                                                    </telerik:GridBoundColumn>
                                                   
                                                 
                                                     <telerik:GridBoundColumn DataField="Green" HeaderText="<img src='../Images/flag_g.png' alt='my image' />"
                                                        SortExpression="Green" UniqueName="Green" HeaderStyle-HorizontalAlign="Center" AllowFiltering="false">
                                                        <ItemStyle HorizontalAlign="Center" Width="3%"/>
                                                        <HeaderStyle Font-Bold="true" />
                                                    </telerik:GridBoundColumn>

                                                       <telerik:GridBoundColumn DataField="Orange" HeaderText="<img src='../Images/flag_y.png' alt='my image' />"
                                                        SortExpression="Orange" UniqueName="Orange" HeaderStyle-HorizontalAlign="Center" AllowFiltering="false">
                                                        <ItemStyle HorizontalAlign="Center" Width="3%"/>
                                                        <HeaderStyle Font-Bold="true" />
                                                    </telerik:GridBoundColumn>


                                                    <telerik:GridBoundColumn DataField="Red" HeaderText="<img src='../Images/flag.png' alt='my image' />"
                                                        SortExpression="Red" UniqueName="Red" HeaderStyle-HorizontalAlign="Center" AllowFiltering="false">
                                                        <ItemStyle HorizontalAlign="Center" Width="3%"/>
                                                        <HeaderStyle Font-Bold="true" />
                                                    </telerik:GridBoundColumn>
                                                    <%--<telerik:GridTemplateColumn HeaderText="Orange" HeaderStyle-HorizontalAlign="Center">
                                                            <HeaderTemplate>
                                                                <img src='../Images/flag_y.png' alt='my image' /></HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblOrange" runat="server" Text='<%# Eval("Orange")%>' />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn HeaderText="Red" HeaderStyle-HorizontalAlign="Center">
                                                            <HeaderTemplate>
                                                                <img src='../Images/flag.png' alt='my image' /></HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRed" runat="server" Text='<%# Eval("Red")%>' />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridTemplateColumn>--%>
                                                    <telerik:GridTemplateColumn HeaderText="View" HeaderStyle-HorizontalAlign="Center" AllowFiltering="false">
                                                        <ItemTemplate>
                                                           <%-- <asp:LinkButton ID="lnkView" runat="server" Text="View" CommandArgument='<%# Eval("TransID")%>'
                                                                Font-Underline="true" ForeColor="Blue" CommandName="ViewVideo"></asp:LinkButton>--%>
                                                                 <asp:HyperLink ID="lnkView" runat="server" Text="View"
                                                                        CommandArgument='<%# Eval("TransID")%>' Font-Underline="true"  ForeColor="Blue" NavigateUrl='<%#GetUrl(Eval("TransID").ToString())%>' Target="_blank"
                                                                       ></asp:HyperLink>  
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="3%" />
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
            <div class="clear">
            </div>
        </div>
    </div>
</asp:Content>

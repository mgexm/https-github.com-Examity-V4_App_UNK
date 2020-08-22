<%@ Page Title="" Language="C#" MasterPageFile="~/Auditor/Auditor.Master" AutoEventWireup="true"
    CodeBehind="Inbox.aspx.cs" Inherits="SecureProctor.Auditor.Inbox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AuditorContent" runat="server">
     <Style type="text/css">
         .itemNameColumn span
{
    display: block;
    width: 500px; 
  
    word-wrap: break-word; 
  
}
     </Style>
    <style type="text/css">
        #overlay {
            position: fixed;
            z-index: 99;
            top: 0px;
            left: 0px; /*background-color: #FFFFFF;*/
            width: 100%;
            height: 100%;
            filter: Alpha(Opacity=80);
            opacity: 0.80;
            -moz-opacity: 0.80;
        }


        #theprogress {
            /*background-color: #D3BB9C;*/
            width: 110px;
            height: 24px;
            text-align: center;
            filter: Alpha(Opacity=100);
            opacity: 1;
            -moz-opacity: 1;
        }

        #modalprogress {
            position: absolute;
            top: 50%;
            left: 50%;
            margin: -11px 0 0 -55px; /*color: white;*/
        }

        body > #modalprogress {
            position: fixed;
        }
    </style>
    <div class="app_container_inner">
        <div class="app_inner_content">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <table width="100%">
                            <tr>
                                <td align="left" width="75%" valign="top">
                                    <img src="../Images/ImgInbox_DB1.png" alt="inbox" />
                                </td>
                              
                                 <td width="25%" valign="middle">
                                <table cellpadding="0" cellspacing="7" width="100%">
                                   <tr>
                                   <td valign="middle"><img src="../Images/ImgAlert.png" /></td>
                                   <td valign="middle" align="left">&nbsp; Alert</td>
                                    <td valign="middle"><img src="../Images/flag_g.png" /></td>
                                    <td valign="middle" align="left">&nbsp; No Violation</td>
                                    </tr>
                                    <tr>
                                        <td valign="middle"><img src="../Images/flag_y.png" /></td>
                                   <td valign="middle" align="left">&nbsp; Possible Violation</td>
                                   
                                    <td valign="middle" align="left" ><img src="../Images/flag.png" /></td>
                                    <td valign="middle">&nbsp; Violation</td>
                                    </tr>
                                  
                                </table>
                            </td>
                </tr>
                </table>
                </td>
                </tr>
                <tr>
                    <td align="right" colspan="2">
                        <asp:LinkButton ID="lblprocessedexamlink" runat="server" Text="Processed Exams" ForeColor="Black"
                            ToolTip="Click here to Processed Exams" Font-Bold="true" Font-Underline="true"
                            OnClick="lblprocessedexamlink_Click"></asp:LinkButton>&nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div class="login_new1">
                            <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblSuccess" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>
                                    </td>
                                </tr>
                                <%--<tr id="trGridPages" runat="server">
                                     <td>
                                        <table cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td width="2%">&nbsp;
                                                </td>
                                                <td align="left" width="66%"></td>
                                                <td align="right" width="30%">
                                                   Page Size :&nbsp;<asp:DropDownList ID="ddlpagesize" runat="server" AutoPostBack="True"
                                                                OnSelectedIndexChanged="ddlpagesize_SelectedIndexChanged" SkinID="ddl">
                                                                <asp:ListItem>10</asp:ListItem>
                                                                <asp:ListItem>25</asp:ListItem>
                                                                <asp:ListItem>50</asp:ListItem>
                                                            </asp:DropDownList>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
                                                <td width="2%">&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td>
                                        <div class="login_new1">
                                            <telerik:radgrid id="gvAuditorInbox" runat="server" onneeddatasource="gvAuditorInbox_NeedDataSource"
                                                autogeneratecolumns="False" allowpaging="True" allowsorting="True" skin="<%$ Resources:SecureProctor,Telerik_Grid_Skin %>"
                                                cellspacing="0" gridlines="None" onitemcommand="gvAuditorInbox_ItemCommand" enablelinqexpressions="false"  OnSortCommand="gvAuditorInbox_SortCommand">
                                                <GroupingSettings CaseSensitive="false" />
                                                <MasterTableView AllowFilteringByColumn="true" FilterItemStyle-BackColor="#DCEDFD" AllowNaturalSort="false">
                                                    <NoRecordsTemplate>
                                                        No records to display.
                                                    </NoRecordsTemplate>
                                                    <Columns>
                                                        <telerik:GridTemplateColumn HeaderText="<%$ Resources:SecureProctor,Grid_Header_Select %>"
                                                            HeaderStyle-HorizontalAlign="Center" AllowFiltering="false">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkSelect" runat="server" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="1%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridTemplateColumn>
                                                        <%--<telerik:GridBoundColumn DataField="TransID" HeaderText="<%$ Resources:SecureProctor,Grid_Header_TransactionID %>"
                                                            SortExpression="TransID" UniqueName="TransID" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridBoundColumn>--%>
                                                        <telerik:GridTemplateColumn HeaderText="<%$ Resources:SecureProctor,Grid_Header_TransactionID %>"
                                                            HeaderStyle-HorizontalAlign="Center" DataField="TransID" SortExpression="TransID" UniqueName="TransID" FilterControlWidth="60%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblExamID" runat="server" Text='<%# Eval("TransID")%>' />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="2%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridTemplateColumn>
                                                        <%--<telerik:GridBoundColumn DataField="StudentName" HeaderText="<%$ Resources:SecureProctor,Grid_Header_StudentName %>"
                                                            SortExpression="StudentName" UniqueName="StudentName" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridBoundColumn>--%>
                                                        <%--<telerik:GridTemplateColumn HeaderText="<%$ Resources:SecureProctor,Grid_Header_StudentName %>"
                                                            HeaderStyle-HorizontalAlign="Center" DataField="StudentName" SortExpression="StudentName"
                                                            UniqueName="StudentName">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lblStudentName" runat="server" Text='<%# Eval("StudentName")%>'
                                                                    OnClick="lblStudentName_Click" CommandArgument='<%#Eval("UserID") %>' Font-Underline="true"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridTemplateColumn>--%>
                                                        <telerik:GridTemplateColumn HeaderText="<%$ Resources:SecureProctor,Grid_Header_StudentFirstName %>"
                                                            HeaderStyle-HorizontalAlign="Center" DataField="FirstName" SortExpression="FirstName"
                                                            UniqueName="FirstName" FilterControlWidth="60px">
                                                            <ItemTemplate>
                                                                <%--<asp:LinkButton ID="btnStudentFirstName" runat="server" Text='<%# Eval("FirstName")%>'
                                                                    OnClick="lblStudentName_Click" CommandArgument='<%#Eval("UserID") %>' Font-Underline="true"></asp:LinkButton>--%>
                                                          <asp:HyperLink ID="btnStudentFirstName" runat="server" Text='<%# Eval("FirstName")%>'
                                                                        CommandArgument='<%# Eval("UserID")%>' Font-Underline="true"   NavigateUrl='<%#GetStudentUrl(Eval("UserID").ToString())%>' Target="_blank" >
                                                                    </asp:HyperLink>
                                                                   </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn HeaderText="<%$ Resources:SecureProctor,Grid_Header_StudentLastName %>"
                                                            HeaderStyle-HorizontalAlign="Center" DataField="LastName" SortExpression="LastName"
                                                            UniqueName="LastName" FilterControlWidth="60px">
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
                                                            SortExpression="CourseName" UniqueName="CourseName" ItemStyle-CssClass="itemNameColumn" HeaderStyle-HorizontalAlign="Center" FilterControlWidth="70%">
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
                                                        <%--<telerik:GridBoundColumn DataField="ProviderName" HeaderText="<%$ Resources:SecureProctor,Grid_Header_ProviderName %>"
                                                            SortExpression="ProviderName" UniqueName="ProviderName" HeaderStyle-HorizontalAlign="Center" FilterControlWidth="60px">
                                                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridBoundColumn>--%>
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
                                                        <%--<telerik:GridBoundColumn DataField="SecurityDescription" HeaderText="Exam security level"
                                                            SortExpression="SecurityDescription" UniqueName="SecurityDescription" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridBoundColumn>--%>
                                                        <telerik:GridTemplateColumn HeaderText="<%$ Resources:SecureProctor,Grid_Header_ExamSecurityLevel %>"
                                                        SortExpression="SecurityDescription" DataField="SecurityDescription" HeaderStyle-HorizontalAlign="Center" FilterControlWidth="60%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSecurity" runat="server" Text='<%# Eval("SecurityDescription")  %>' ToolTip='<%# Eval("SecurityToolTip")  %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                        <HeaderStyle Font-Bold="true" />
                                                    </telerik:GridTemplateColumn>
                                                        <%--<telerik:GridBoundColumn DataField="SlotStartTime" HeaderText="<%$ Resources:SecureProctor,Grid_Header_StartTime %>"
                                                            SortExpression="SlotStartTime" UniqueName="SlotStartTime" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="StatusName" HeaderText="<%$ Resources:SecureProctor,Grid_Header_Status %>"
                                                            SortExpression="StatusName" UniqueName="StatusName" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridBoundColumn>--%>
                                                        <%--<telerik:GridBoundColumn DataField="Green" HeaderText="Green"
                                                            SortExpression="Green" UniqueName="Green" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridBoundColumn>--%>
                                                        <%--<telerik:GridBoundColumn DataField="Orange" HeaderText="Orange"
                                                            SortExpression="Orange" UniqueName="Orange" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="Red" HeaderText="Red"
                                                            SortExpression="Red" UniqueName="Red" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridBoundColumn>--%>
                                                        <telerik:GridBoundColumn DataField="Alert" HeaderText="<img src='../Images/ImgAlert.png' alt='my image' />"
                                                            SortExpression="Alert" UniqueName="Alert" HeaderStyle-HorizontalAlign="Center" AllowFiltering="false">
                                                            <ItemStyle HorizontalAlign="Center" Width="3%"/>
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridBoundColumn>

                                                           <telerik:GridBoundColumn DataField="Green" HeaderText="<img src='../Images/flag_g.png' alt='my image' />"
                                                            SortExpression="Green" UniqueName="Green" HeaderStyle-HorizontalAlign="Center"
                                                            AllowFiltering="false">
                                                            <ItemStyle HorizontalAlign="Center" Width="3%" />
                                                            <HeaderStyle Font-Bold="true" /> 
                                                        </telerik:GridBoundColumn>

                                                       
                                                        <telerik:GridBoundColumn DataField="Orange" HeaderText="<img src='../Images/flag_y.png' alt='my image' />"
                                                            SortExpression="Orange" UniqueName="Orange" HeaderStyle-HorizontalAlign="Center"
                                                            AllowFiltering="false">
                                                            <ItemStyle HorizontalAlign="Center" Width="3%"/>
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridBoundColumn>

                                                      


                                                        <telerik:GridBoundColumn DataField="Red" HeaderText="<img src='../Images/flag.png' alt='my image' />"
                                                            SortExpression="Red" UniqueName="Red" HeaderStyle-HorizontalAlign="Center" AllowFiltering="false">
                                                            <ItemStyle HorizontalAlign="Center" Width="3%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridBoundColumn>



                                                        <telerik:GridTemplateColumn HeaderText="<%$ Resources:SecureProctor,Grid_Header_View %>"
                                                            HeaderStyle-HorizontalAlign="Center" AllowFiltering="false">
                                                            <ItemTemplate>
                                                               <%-- <asp:LinkButton ID="lnkView" runat="server" Text="View" CommandArgument='<%# Eval("TransID")%>'
                                                                    Font-Underline="true" ForeColor="Blue" CommandName="ViewVideo"></asp:LinkButton>     --%>                                                           
                                                             <asp:HyperLink ID="lnkView" runat="server" Text="View"  
                                                                        CommandArgument='<%# Eval("TransID")%>' Font-Underline="true"  ForeColor="Blue" NavigateUrl='<%#GetUrl(Eval("TransID").ToString())%>' Target="_blank"
                                                                        Visible='<%# Convert.ToBoolean(Eval("VideoStatus"))%>' ></asp:HyperLink>    
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
                                            </telerik:radgrid>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5" align="center">
                                        <%--<br />--%>
                                        <telerik:radbutton id="btnApprove" runat="server" text="APPROVE" skin="Web20" width="80"
                                            onclick="btnApprove_Click">
                                        </telerik:radbutton>
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

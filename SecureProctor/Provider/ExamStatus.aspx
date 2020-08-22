<%@ Page Title="" Language="C#" MasterPageFile="~/Provider/Provider.Master" AutoEventWireup="true"
    CodeBehind="ExamStatus.aspx.cs" Inherits="SecureProctor.Provider.ExamStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ExamProviderContent" runat="server">
    <Style type="text/css">
         .itemNameColumn span
{
    display: block;
    width: 500px; 
  
    word-wrap: break-word; 
  
}
     </Style>

  <%--  <asp:UpdatePanel ID="UpExamStatus" runat="server">
        <ContentTemplate>--%>
            <div class="app_container_inner">
                <div class="app_inner_content">
                    <table width="100%">
                        <tr>
                            <td width="75%" valign="top">
                                <img src="../Images/ImgExamStatus1.png" alt="examdetails" />

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
                                     <telerik:RadComboBoxItem Text="Future 30 days" Value="30" />
                                    <telerik:RadComboBoxItem Text="Future 60 days" Value="60" />
                                    <telerik:RadComboBoxItem Text="Future 90 days" Value="90" />
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
                        <tr>
                            <td colspan="3" width="100%">
                                <div class="login_new1">
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td width="100%">
                                                <telerik:RadGrid ID="gvExamStatus" runat="server" 
                                                    AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" CellSpacing="0"
                                                    GridLines="None" Skin="<%$ Resources:SecureProctor,Telerik_Grid_Skin %>" OnItemCommand="gvExamStatus_ItemCommand"
                                                    OnItemDataBound="gvExamStatus_ItemDataBound" Width="100%" EnableLinqExpressions="false" OnNeedDataSource="gvExamStatus_NeedDataSource" OnSortCommand="gvExamStatus_SortCommand">
                                                    <GroupingSettings CaseSensitive="false" />
                                                    <MasterTableView AllowFilteringByColumn="true" FilterItemStyle-BackColor="#DCEDFD" PageSize="50" AllowNaturalSort="false">
                                                        <Columns>
                                                            <telerik:GridBoundColumn DataField="TransID" HeaderText="<%$ Resources:SecureProctor,Grid_Header_TransactionID %>"
                                                                SortExpression="TransID" UniqueName="TransID" HeaderStyle-HorizontalAlign="Center" DataType="System.Int32" FilterControlWidth="60%">
                                                                <ItemStyle HorizontalAlign="Center" Width="2%"/>
                                                                <HeaderStyle Font-Bold="true" />
                                                            </telerik:GridBoundColumn><%--<telerik:GridMaskedColumn DataField="TransID" HeaderText="<%$ Resources:SecureProctor,Grid_Header_TransactionID %>"
                                                                SortExpression="TransID" UniqueName="TransID" FilterControlWidth="50px" AutoPostBackOnFilter="false"
                                                                CurrentFilterFunction="EqualTo" FilterDelay="2000" ShowFilterIcon="false" Mask="######" AllowFiltering="true">
                                                            </telerik:GridMaskedColumn>--%>
                                                            <%--<telerik:GridTemplateColumn HeaderText="<%$ Resources:SecureProctor,Grid_Header_StudentName %>"
                                                                HeaderStyle-HorizontalAlign="Center" SortExpression="StudentName" DataField="StudentName">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="btnStudentName" runat="server" Text='<%# Eval("StudentName")%>'
                                                                        OnClick="btnStudentName_Click" CommandArgument='<%#Eval("UserID") %>' Font-Underline="true"></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                                <HeaderStyle Font-Bold="true" />
                                                            </telerik:GridTemplateColumn>--%>
                                                            <telerik:GridTemplateColumn HeaderText="<%$ Resources:SecureProctor,Grid_Header_StudentFirstName %>"
                                                                HeaderStyle-HorizontalAlign="Center" DataField="FirstName" SortExpression="FirstName"
                                                                UniqueName="FirstName">
                                                                <ItemTemplate>
                                                                   <%-- <asp:LinkButton ID="btnStudentFirstName" runat="server" Text='<%# Eval("FirstName")%>'
                                                                        OnClick="btnStudentName_Click" CommandArgument='<%#Eval("UserID") %>' Font-Underline="true"></asp:LinkButton>--%>
                                                             <asp:HyperLink ID="btnStudentFirstName" runat="server" Text='<%# Eval("FirstName")%>'
                                                                        CommandArgument='<%# Eval("UserID")%>' Font-Underline="true"   NavigateUrl='<%#GetStudentUrl(Eval("UserID").ToString())%>' Target="_blank" >
                                                                    </asp:HyperLink>
                                                                        </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                                <HeaderStyle Font-Bold="true" />
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="<%$ Resources:SecureProctor,Grid_Header_StudentLastName %>"
                                                                HeaderStyle-HorizontalAlign="Center" DataField="LastName" SortExpression="LastName"
                                                                UniqueName="LastName">
                                                                <ItemTemplate>
                                                                   <%-- <asp:LinkButton ID="btnStudentLastName" runat="server" Text='<%# Eval("LastName")%>'
                                                                        OnClick="btnStudentName_Click" CommandArgument='<%#Eval("UserID") %>' Font-Underline="true"></asp:LinkButton>--%>
                                                               <asp:HyperLink ID="btnStudentLastName" runat="server" Text='<%# Eval("LastName")%>'
                                                                        CommandArgument='<%# Eval("UserID")%>' Font-Underline="true"   NavigateUrl='<%#GetStudentUrl(Eval("UserID").ToString())%>' Target="_blank" >
                                                                    </asp:HyperLink>
                                                                      </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                                <HeaderStyle Font-Bold="true" />
                                                            </telerik:GridTemplateColumn>
                                                           <telerik:GridBoundColumn DataField="CourseName" HeaderText="<%$ Resources:SecureProctor,Grid_Header_CourseName %>"
                                                                SortExpression="CourseName" UniqueName="CourseName" HeaderStyle-HorizontalAlign="Center" FilterControlWidth="70%" ItemStyle-CssClass="itemNameColumn">
                                                                <ItemStyle HorizontalAlign="Center" Width="15%"/>
                                                                <HeaderStyle Font-Bold="true" />
                                                            </telerik:GridBoundColumn>
                                                              <telerik:GridBoundColumn DataField="ExamName" HeaderText="<%$ Resources:SecureProctor,Grid_Header_ExamName %>"
                                                                SortExpression="ExamName" UniqueName="ExamName" HeaderStyle-HorizontalAlign="Center" FilterControlWidth="70%" ItemStyle-CssClass="itemNameColumn">
                                                                <ItemStyle HorizontalAlign="Center" Width="15%"/>
                                                                <HeaderStyle Font-Bold="true" />
                                                            </telerik:GridBoundColumn>

                                                            <telerik:GridBoundColumn DataField="ScheduleTime" HeaderText="<%$ Resources:SecureProctor,Grid_Header_ScheduleTime %>"
                                                                SortExpression="ScheduleTime" UniqueName="ScheduleTime" HeaderStyle-HorizontalAlign="Center" FilterControlWidth="60%">
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
                                                            <telerik:GridTemplateColumn HeaderText="<%$ Resources:SecureProctor,Grid_Header_ExamStatus %>"
                                                                HeaderStyle-HorizontalAlign="Center" SortExpression="Status" DataField="Status">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblExamStatus" runat="server" Text='<%# Eval("Status")%>' />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                                <HeaderStyle Font-Bold="true" />
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridBoundColumn DataField="Alert" HeaderText="<img src='../Images/ImgAlert.png' alt='my image' />"
                                                                SortExpression="Alert" UniqueName="Alert" HeaderStyle-HorizontalAlign="Center" AllowFiltering="false" >
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
                                                                <ItemStyle HorizontalAlign="Center" Width="3%" />
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
                                                                   <%-- <asp:LinkButton ID="lnkView" runat="server" Text="<%$ Resources:SecureProctor,Grid_Header_View %>"
                                                                        CommandArgument='<%# Eval("TransID")%>' Font-Underline="true" ForeColor="Blue"
                                                                        Visible="false" CommandName="view"></asp:LinkButton>--%>
                                                                   <asp:HyperLink ID="lnkView" runat="server" Text="<%$ Resources:SecureProctor,Grid_Header_View %>"
                                                                        CommandArgument='<%# Eval("TransID")%>' Font-Underline="true"  ForeColor="Blue" NavigateUrl='<%#GetUrl(Eval("TransID").ToString())%>' Target="_blank"
                                                                        Visible="false" ></asp:HyperLink>
                                                                    <asp:Label ID="lblView" runat="server" Text='View' Visible="false" />
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
       <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>

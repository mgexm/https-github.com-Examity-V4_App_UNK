<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminInstructor.aspx.cs" Inherits="SecureProctor.Admin.AdminInstructor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminContent" runat="server">
    <script language="javascript" type="text/javascript">
        function OpenAddInstructor() {
         

            radopen("AddInstructor.aspx", "Add New Instructor", 700, 400);
        }

        function closeWin() {
            var masterTable = $find("<%= gvInstructor.ClientID %>").get_masterTableView();
              masterTable.rebind();

          }


        </script>


     <asp:UpdatePanel ID="upExams" runat="server">
        <ContentTemplate>
            <table cellpadding="2" cellspacing="2" width="100%">
                <tr>
                  <td>
                        <table width="100%">
                       <td>
                        <div class="heading customfont1">Instructors
                           </div>
                           </td>
                 
                        </table>


                    </td>
                </tr>
                <tr>
                    <td width="100%" align="center" valign="top">
                        <div class="login_new1">
                            <telerik:RadGrid ID="gvInstructor" runat="server" 
                                AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" Skin="<%$ Resources:AppConfigurations,Skin_Current %>"
                                CellSpacing="0" GridLines="None" AllowFilteringByColumn="false" OnNeedDataSource="gvInstructor_NeedDataSource">
                                <GroupingSettings CaseSensitive="false" />
                                <MasterTableView AllowFilteringByColumn="true" FilterItemStyle-BackColor="#DCEDFD"
                                    FilterItemStyle-HorizontalAlign="Center" CommandItemDisplay="Top" DataKeyNames="InstructorID"
                                    EditMode="PopUp">
                                    <CommandItemStyle HorizontalAlign="Left" Height="30" />
                                    <CommandItemTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="vertical-align: bottom;" align="center" width="3%">
                                                    <asp:ImageButton ID="imgplus" runat="server" ImageUrl="~/Images/ImgGridAdd.png" OnClientClick="OpenAddInstructor(); return false;" />&nbsp;&nbsp;
                                                </td>
                                                <td style="vertical-align: top;" align="left" width="98%">
                                                    <asp:LinkButton ID="lnkAddInstructor" runat="server" Text="<%$ Resources:AppControls,Admin_Students_GridHeader_AddInstructor %>"
                                                        OnClientClick="OpenAddInstructor(); return false;"></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </CommandItemTemplate>
                                    <Columns>
                                         <telerik:GridBoundColumn DataField="FirstName" HeaderText="<%$ Resources:AppControls,Admin_Instructor_GridHeader_InstructorFirstName %>"
                                            SortExpression="FirstName" UniqueName="FirstName" HeaderStyle-HorizontalAlign="Center" FilterControlWidth="80px">
                                            <ItemStyle HorizontalAlign="Center" Width="17%" />
                                            <HeaderStyle Font-Bold="true" />
                                        </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="LastName" HeaderText="<%$ Resources:AppControls,Admin_Instructor_GridHeader_InstructorLastName %>"
                                            SortExpression="LastName" UniqueName="LastName" HeaderStyle-HorizontalAlign="Center" FilterControlWidth="80px">
                                            <ItemStyle HorizontalAlign="Center" Width="17%" />
                                            <HeaderStyle Font-Bold="true" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="EmailAddress" HeaderText="<%$ Resources:AppControls,Admin_Students_GridHeader_EmailAddress %>"
                                            SortExpression="EmailAddress" UniqueName="EmailAddress" HeaderStyle-HorizontalAlign="Center" FilterControlWidth="80px">
                                            <ItemStyle HorizontalAlign="Center" Width="20%" />
                                            <HeaderStyle Font-Bold="true" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn HeaderText="<%$ Resources:AppControls,Admin_Students_GridHeader_Status %>"
                                            HeaderStyle-HorizontalAlign="Center" SortExpression="Status" DataField="Status" FilterControlWidth="40px" AllowFiltering="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status")%>' />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="7%" />
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
        </ContentTemplate>
    </asp:UpdatePanel>



</asp:Content>

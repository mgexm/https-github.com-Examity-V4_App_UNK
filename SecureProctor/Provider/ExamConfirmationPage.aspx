<%@ Page Title="" Language="C#" MasterPageFile="~/Provider/Provider.Master" AutoEventWireup="true"
    CodeBehind="ExamConfirmationPage.aspx.cs" Inherits="SecureProctor.Provider.ExamConfirmationPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ExamProviderContent" runat="server">
    <div class="app_container_inner">
        <div class="app_inner_content">
            <table cellpadding="2" cellspacing="2" width="100%">
                <tr>
                    <td>
                        <img src="../Images/Imgexamdetails1.png" alt="exam details" />
                    </td>
                </tr>
                <tr valign="top">
                    <td width="100%">
                        <div class="login_new1">
                            <table width="100%" cellpadding="0" cellspacing="0" style="font-family: Arial; font-size: 12px;">
                                <tr style="font-size: 14px; line-height: 25px; color: #FFFFFF;" class="subHeadfont">
                                    <td align="center" valign="middle">
                                        <asp:Label ID="lblHead" runat="server" Text="New Exam Details"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table cellpadding="3" cellspacing="4" width="100%" border="0">
                                            <tr class="gridviewRowstyle">
                                                <td align="left" width="20%">
                                                    &nbsp;&nbsp;&nbsp; <strong>Course Name</strong>
                                                </td>
                                                <td align="left" width="20%">
                                                    <asp:Label ID="lblCourseName" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="gridviewAlternatestyle">
                                                <td align="left">&nbsp;&nbsp;&nbsp; <strong>Exam Name</strong>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblExamName" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="gridviewRowstyle">
                                                <td align="left">&nbsp;&nbsp;&nbsp; <strong>
                                                    <asp:Label ID="lblSecurityLevel" Text="<%$ Resources:AppControls,Admin_ViewExam_Label_ExamSecurityLevel %>"
                                                        runat="server"></asp:Label></strong>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblExamsecurity" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="gridviewAlternatestyle">
                                                <td align="left">
                                                    &nbsp;&nbsp;&nbsp; <strong>Duration</strong>
                                                </td>
                                                <td align="left">
                                                    <%-- <asp:Label ID="lblDuration" runat="server"></asp:Label>--%>
                                                    <asp:Label ID="lblH" runat="server" Text="Hours"></asp:Label>
                                                    <asp:Label ID="lblHours" runat="server"></asp:Label>
                                                    <asp:Label ID="lbl" Text=":" runat="server"></asp:Label>
                                                      <asp:Label ID="lblM" runat="server" Text="Minutes"></asp:Label>
                                                    <asp:Label ID="lblMinutes" runat="server"></asp:Label>&nbsp;&nbsp;
                                                   <%-- <asp:Label ID="lblhr" runat="server" Text="(HH"></asp:Label>:<asp:Label ID="lblMM"
                                                        runat="server" Text="MM)"></asp:Label>--%>
                                                </td>
                                            </tr>
                                            <tr class="gridviewRowstyle">
                                                <td align="left">
                                                    &nbsp;&nbsp;&nbsp; <strong>Extended time for special accommodations students </strong>
                                                </td>
                                                <td align="left">
                                                <asp:Label ID="Label5" runat="server" Text="Minutes"></asp:Label>
                                                    <asp:Label ID="lblBufferTime" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="gridviewAlternatestyle">
                                                <td align="left">
                                                    &nbsp;&nbsp;&nbsp; <strong>Link to access Exam</strong>
                                                </td>
                                                <td align="left" class="LineBreak">
                                                    <asp:Label ID="lbllink" runat="server"></asp:Label> 
                                                </td>
                                            </tr>
                                            <tr class="gridviewRowstyle">
                                                <td align="left">
                                                    &nbsp;&nbsp;&nbsp; <strong>Exam Start Date</strong>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblStartDate" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="gridviewAlternatestyle">
                                                <td align="left">
                                                    &nbsp;&nbsp;&nbsp; <strong>Exam End Date</strong>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblEndDate" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                      <tr class="gridviewRowstyle">
                                                <td align="left">
                                                    &nbsp;&nbsp;&nbsp; <strong>Uploaded File</strong>
                                                </td>
                                                <td align="left">
                                                    <asp:LinkButton ID="lnlFile" runat="server" OnClick="lnlFile_Click" Font-Underline="true"></asp:LinkButton>
                                                    <asp:Label ID="lblFile" runat="server" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                        <%--    <tr class="gridviewAlternatestyle">
                                                <td align="left" valign="top">
                                                    &nbsp;&nbsp;&nbsp; <strong>Exam Tools</strong>
                                                </td>
                                                <td align="left">
                                                    <asp:Image ID="imgCalc" runat="server" ImageUrl="~/Images/ImgCalc.png" Height="50" />
                                                    &nbsp;&nbsp;
                                                    <asp:Image ID="imgStickyNotes" runat="server" ImageUrl="~/Images/Imgstickynote.png"
                                                        Height="50" />
                                                         <asp:Label ID="lblError" runat="server" Visible="false"></asp:Label>
                                                </td>
                                            </tr>--%>
                                                  <tr class="gridviewAlternatestyle">
                                                <td colspan="2">
                                                    <telerik:RadGrid ID="gvExamTools" runat="server" OnNeedDataSource="gvExamTools_NeedDataSource"
                                                        AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" Skin="<%$ Resources:SecureProctor,Telerik_Grid_Skin %>"
                                                        CellSpacing="0" GridLines="None" AllowFilteringByColumn="false" >
                                                         <GroupingSettings CaseSensitive="false" />
                                                        <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD">
                                                            <Columns>
                                                             <%--   <telerik:GridBoundColumn DataField="ToolID" HeaderText="#" SortExpression="ToolID"
                                                                    UniqueName="ToolID" HeaderStyle-HorizontalAlign="Center">
                                                                    <ItemStyle HorizontalAlign="Center" Width="25%" />
                                                                    <HeaderStyle Font-Bold="true" />
                                                                </telerik:GridBoundColumn>--%>
                                                                <telerik:GridBoundColumn DataField="ToolName" HeaderText="Exam Tools" SortExpression="ToolName"
                                                                    UniqueName="ToolName" HeaderStyle-HorizontalAlign="Center">
                                                                    <ItemStyle HorizontalAlign="Center" Width="75%" />
                                                                    <HeaderStyle Font-Bold="true" />
                                                                </telerik:GridBoundColumn>                                                               
                                                            </Columns>
                                                        </MasterTableView>
                                                    </telerik:RadGrid>
                                                </td>
                                            </tr>
                                            <tr class="gridviewRowstyle">
                                                <td colspan="2">
                                                    <telerik:RadGrid ID="gvNotes" runat="server" OnNeedDataSource="gvNotes_NeedDataSource"
                                                        AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" Skin="<%$ Resources:SecureProctor,Telerik_Grid_Skin %>"
                                                        CellSpacing="0" GridLines="None" >
                                                         <GroupingSettings CaseSensitive="false" />
                                                        <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD">
                                                            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                                                            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                                                            </RowIndicatorColumn>
                                                            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                                                            </ExpandCollapseColumn>
                                                            <Columns>
                                                                <telerik:GridBoundColumn DataField="Head" HeaderText="#" SortExpression="Head"
                                                                    UniqueName="Head" HeaderStyle-HorizontalAlign="Center">
                                                                    <ItemStyle HorizontalAlign="Center" Width="25%" />
                                                                    <HeaderStyle Font-Bold="true" />
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="Text" HeaderText="Notes for Proctors and Auditors"
                                                                    SortExpression="Text" UniqueName="Text" HeaderStyle-HorizontalAlign="Center">
                                                                    <ItemStyle HorizontalAlign="Center" Width="75%" />
                                                                    <HeaderStyle Font-Bold="true" />
                                                                </telerik:GridBoundColumn>
                                                            </Columns>
                                                        </MasterTableView>
                                                    </telerik:RadGrid>
                                                </td>
                                            </tr>
                                            <tr class="gridviewAlternatestyle">
                                                <td colspan="2">
                                                    <telerik:RadGrid ID="gvRules" runat="server" OnNeedDataSource="gvRules_NeedDataSource"
                                                        AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" Skin="<%$ Resources:SecureProctor,Telerik_Grid_Skin %>"
                                                        CellSpacing="0" GridLines="None" AllowFilteringByColumn="false" >
                                                         <GroupingSettings CaseSensitive="false" />
                                                        <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD">
                                                            <Columns>
                                                                <telerik:GridBoundColumn DataField="Head" HeaderText="#" SortExpression="Head"
                                                                    UniqueName="Head" HeaderStyle-HorizontalAlign="Center">
                                                                    <ItemStyle HorizontalAlign="Center" Width="25%" />
                                                                    <HeaderStyle Font-Bold="true" />
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="Text" HeaderText="Rules for Student" SortExpression="Text"
                                                                    UniqueName="Text" HeaderStyle-HorizontalAlign="Center">
                                                                    <ItemStyle HorizontalAlign="Center" Width="75%" />
                                                                    <HeaderStyle Font-Bold="true" />
                                                                </telerik:GridBoundColumn>                                                               
                                                            </Columns>
                                                        </MasterTableView>
                                                    </telerik:RadGrid>
                                                </td>
                                            </tr>
                                       
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr valign="top" id="trButtons" runat="server">
                                    <td align="center">
                                      <%--  <telerik:RadButton ID="btnBack" runat="server" Text="Back" Skin="Web20" OnClick="btnBack_Click" Visible="false">
                                        </telerik:RadButton>--%>
                                        &nbsp;&nbsp;
                                        <telerik:RadButton ID="btnProceed" runat="server" Text="Proceed" Skin="Web20" OnClick="btnProceed_Click">
                                        </telerik:RadButton>
                                        &nbsp;&nbsp;
                                        <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel" Skin="Web20" OnClick="btnCancel_Click">
                                        </telerik:RadButton>
                                    </td>
                                </tr>
                                <tr valign="top" id="trMessage" runat="server">
                                    <td align="center" valign="top">
                                        <table width="100%" cellpadding="1" cellspacing="1" border="0">
                                            <tr>
                                            <td valign="middle" align="center">
                                             <telerik:RadButton ID="btnBack" runat="server" Text="Back" Skin="Web20" OnClick="btnBack_Click">
                                        </telerik:RadButton>

                                        </td>
                                        </tr>
                                      <%--  <tr>

                                               <td valign="middle" align="center" width="100%">
                                                    <img src="../Images/ImgSuccessAlert.png" alt="Success" />&nbsp;&nbsp;
                                                
                                                    &nbsp;&nbsp;New exam details have been saved successfully.
                                                </td> 

                                            </tr>--%>
                                             <tr id="trSuccess" runat="server">
                                            
                                            <td valign="middle" align="center" colspan="2">
                                            
                                            <asp:Label ID="lblMsg" runat="server" Font-Bold="true"></asp:Label>
                                            
                                            </td>
                                            
                                            </tr>
                                        </table>
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

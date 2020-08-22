<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true" CodeBehind="PLConfirmation.aspx.cs" Inherits="SecureProctor.Student.PLConfirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StudentContent" runat="server">
 
        <div class="container_inner">
            <table cellpadding="2" cellspacing="2" width="100%">
                 <tr id="trSuccess" runat="server">
                                    <td align="center" style="padding-bottom: 20px;">
                                        <asp:Label ID="lblInfo" runat="server"></asp:Label>
                                    </td>
                                </tr>
                <tr runat="server" id="trautoconnect" visible="false">
                    <td align="center">
                        <asp:HyperLink ID="hlkSystemReadyness" Target="_self" runat="server" Text="Click here to Continue" Font-Underline="true" ForeColor="Blue" Font-Size="Medium" NavigateUrl="~/Student/StartAnExam.aspx" ></asp:HyperLink>
                    </td>
                </tr> 
<tr id="trSuccessInfo" runat="server">
                                    <td>
                                        <table cellpadding="3" cellspacing="4" width="100%" border="0" style="font-family: Arial; font-size: 12px; color: #000;">
                                            <tr class="gridviewAlternatestyle">
                                                <td align="left">&nbsp;&nbsp;&nbsp; <strong>Exam ID</strong>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblTransID" runat="server"></asp:Label>
                                                </td>
                                                <td align="left">&nbsp;&nbsp;&nbsp; <strong>Student Name</strong>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblStudentName" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="gridviewRowstyle">
                                                <td align="left">&nbsp;&nbsp;&nbsp; <strong>Course Name</strong>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblCourseName" runat="server"></asp:Label>
                                                </td>
                                                <td align="left">&nbsp;&nbsp;&nbsp; <strong>Exam Name</strong>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblExamName" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="gridviewAlternatestyle">
                                                <td align="left">&nbsp;&nbsp;&nbsp; <strong>Exam Date</strong>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblDAte" runat="server"></asp:Label>
                                                </td>
                                                <td align="left">&nbsp;&nbsp;&nbsp; <strong>Exam Time</strong>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblTime" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="gridviewRowstyle">
                                                <td align="left">&nbsp;&nbsp;&nbsp; <strong>Status</strong>&nbsp;&nbsp;&nbsp;
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblStatus" runat="server"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr class="gridviewAlternatestyle" style="display:none;">
                                                <td align="left">&nbsp;&nbsp;&nbsp; <strong>Uploaded file</strong>&nbsp;&nbsp;&nbsp;
                                                </td>
                                                <td align="left" colspan="4">
                                                    <asp:LinkButton ID="lnlFile" runat="server" OnClick="lnlFile_Click" Font-Underline="true"></asp:LinkButton>
                                                    <asp:Label ID="lblFile" runat="server" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="gridviewRowstyle">
                                                <td colspan="4" style="padding-top: 5px; padding-bottom: 5px;" width="100%">


                                                    <telerik:RadGrid ID="gvStandard" runat="server"
                                                        AutoGenerateColumns="False" Skin="<%$ Resources:AppConfigurations,Skin_Current %>"
                                                        CellSpacing="0" GridLines="None">
                                                        <GroupingSettings CaseSensitive="false" />
                                                        <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD"
                                                            FilterItemStyle-HorizontalAlign="Center">
                                                            <NoRecordsTemplate>
                                                                No records to display.
                                                            </NoRecordsTemplate>
                                                            <Columns>

                                                                <telerik:GridBoundColumn DataField="RuleDesc" HeaderText="Standard Rules"
                                                                    UniqueName="RuleDesc" HeaderStyle-HorizontalAlign="Left" AllowSorting="false">
                                                                    <ItemStyle HorizontalAlign="Left" Width="100%" />
                                                                    <HeaderStyle Font-Bold="true" />
                                                                </telerik:GridBoundColumn>
                                                            </Columns>

                                                        </MasterTableView>

                                                    </telerik:RadGrid>

                                                </td>
                                            </tr>
                                            <tr class="gridviewRowstyle">
                                                <td colspan="4" style="padding-top: 5px; padding-bottom: 5px;"  width="100%">

                                                    <telerik:RadGrid ID="gvAllowed" runat="server"
                                                        AutoGenerateColumns="False" Skin="<%$ Resources:AppConfigurations,Skin_Current %>"
                                                        CellSpacing="0" GridLines="None" MasterTableView-DataKeyNames="RuleID">
                                                        <GroupingSettings CaseSensitive="false" />
                                                        <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD"
                                                            FilterItemStyle-HorizontalAlign="Center">
                                                            <NoRecordsTemplate>
                                                                No records to display.
                                                            </NoRecordsTemplate>
                                                            <Columns>

                                                                <telerik:GridBoundColumn DataField="RuleDesc" HeaderText="Additional Rules"
                                                                    UniqueName="RuleDesc" HeaderStyle-HorizontalAlign="Left" AllowSorting="false">
                                                                    <ItemStyle HorizontalAlign="Left" Width="100%" />
                                                                    <HeaderStyle Font-Bold="true" />
                                                                </telerik:GridBoundColumn>


                                                            </Columns>

                                                        </MasterTableView>

                                                    </telerik:RadGrid>

                                                </td>
                                            </tr>
                                            <tr class="gridviewRowstyle" runat="server" id="trSpecialStudent" visible="true">
                                                <td colspan="4" style="padding-top: 5px; padding-bottom: 5px;"  width="100%">

                                                    <telerik:RadGrid ID="gvSpecialInstructions_Student" runat="server"
                                                        AutoGenerateColumns="False" Skin="<%$ Resources:AppConfigurations,Skin_Current %>"
                                                        CellSpacing="0" GridLines="None" MasterTableView-DataKeyNames="RuleID">
                                                        <GroupingSettings CaseSensitive="false" />
                                                        <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD"
                                                            FilterItemStyle-HorizontalAlign="Center">
                                                            <NoRecordsTemplate>
                                                                No records to display.
                                                            </NoRecordsTemplate>
                                                            <Columns>

                                                                <telerik:GridBoundColumn DataField="RuleDesc" HeaderText="Special Instructions"
                                                                    UniqueName="RuleDesc" HeaderStyle-HorizontalAlign="Left" AllowSorting="false">
                                                                    <ItemStyle HorizontalAlign="Left" Width="100%" />
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

                
                </table>
            </div>


</asp:Content>


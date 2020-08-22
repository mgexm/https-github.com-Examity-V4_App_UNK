<%@ Page Title="" Language="C#" MasterPageFile="~/CourseAdmin/CourseAdmin.Master" AutoEventWireup="true" CodeBehind="ViewExamDetails.aspx.cs" Inherits="SecureProctor.CourseAdmin.ViewExamDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ExamProviderContent" runat="server">
    <div class="TabbedPanelsContent">
        <table width="100%">
            <tr>
                <td>
                    <img src="../Images/Imgexamdetails1.png" alt="examdetails" />
                </td>
            </tr>
            <tr>
                <td>
                    <div class="login_new1">
                        <table cellpadding="5" cellspacing="1" width="100%" border="0">
                            <tr class="gridviewRowstyle">
                                <td colspan="2" style="font-size: 14px; color: #fff" class="subHeadfont" align="center">
                                    <asp:Label ID="lblHead" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="gridviewAlternatestyle">
                                <td width="50%">
                                    <strong>
                                        <asp:Label ID="lblCourse" runat="server" Text="Course Name"></asp:Label></strong>
                                </td>
                                <td width="50%">
                                    <%--<telerik:RadTextBox ID="txtCourse" runat="server" Width="250" MaxLength="50" Skin="Web20"
                                        ValidationGroup="save">
                                    </telerik:RadTextBox>--%>
                                    <asp:Label ID="lblCourseName" runat="server"></asp:Label>
                                    <%-- <asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator2" runat="server" ErrorMessage="<%$ Resources:ResMessages,Provider_ExamDetCourse %>"
                                        ControlToValidate="txtCourse" ForeColor="Red" ValidationGroup="save" />--%>
                                </td>
                            </tr>
                            <tr class="gridviewRowstyle">
                                <td>
                                    <strong>
                                        <asp:Label ID="lblExam" Text="Exam Name" runat="server"></asp:Label></strong>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txtExam" runat="server" Width="250" MaxLength="50" Skin="Web20">
                                    </telerik:RadTextBox>
                                    <asp:Label ID="lblExamName" runat="server"></asp:Label><asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator3" runat="server" ErrorMessage="<%$ Resources:ResMessages,Provider_ExamDetExam %>"
                                        ControlToValidate="txtExam" ForeColor="Red" ValidationGroup="save" />
                                </td>
                            </tr>
                            <tr class="gridviewRowstyle">
                                <td>
                                    <strong>
                                        <asp:Label ID="Label6" Text="<%$ Resources:AppControls,Admin_ViewExam_Label_ExamSecurityLevel %>" runat="server"></asp:Label></strong>
                                </td>
                                <td>
                                    <asp:Label ID="lblExamSecurity" runat="server"></asp:Label>
                                    <telerik:RadComboBox ID="ddlExamSecurity" runat="server" AppendDataBoundItems="True"
                                        Skin="Web20" Width="250" DropDownAutoWidth="Enabled">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr class="gridviewAlternatestyle">
                                <td>
                                    <strong>
                                        <asp:Label ID="lblExamhrs" Text="Duration of the Exam (hrs)" runat="server"></asp:Label></strong>
                                </td>
                                <td>
                                    <asp:Label ID="lblhr" runat="server" Text="Hours"></asp:Label>
                                    <telerik:RadComboBox ID="ddlHours" runat="server" AppendDataBoundItems="True" Skin="Web20"
                                        Width="50">
                                    </telerik:RadComboBox>
                                    <asp:Label ID="lblHours" runat="server"></asp:Label>
                                    <asp:Label ID="lbl" Text=":" runat="server"></asp:Label>
                                    <asp:Label ID="lblMM" runat="server" Text="Minutes"></asp:Label>
                                    <telerik:RadComboBox ID="ddlMinutes" runat="server" AppendDataBoundItems="True" Skin="Web20"
                                        Width="50">
                                    </telerik:RadComboBox>
                                    <asp:Label ID="lblMinutes" runat="server"></asp:Label>
                                    <asp:CompareValidator ID="cv" runat="server" ValidationGroup="save" InitialValue="00"
                                        ControlToValidate="ddlHours" ControlToCompare="ddlMinutes" Operator="NotEqual"
                                        Text="Please select exam duration(hrs)" Type="String" />
                                </td>
                            </tr>
                            <tr class="gridviewRowstyle">
                                <td>
                                    <strong>
                                        <asp:Label ID="lblBuffer" Text="Extended time for special accommodations students" runat="server"></asp:Label></strong>
                                </td>
                                <td>
                                    <asp:Label ID="lblBM" runat="server" Text="Minutes"></asp:Label>
                                    <telerik:RadComboBox ID="ddlBufferTime" runat="server" AppendDataBoundItems="True"
                                        Skin="Web20" Width="50">
                                    </telerik:RadComboBox>
                                    <asp:Label ID="lblBufferTime" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="gridviewAlternatestyle">
                                <td>
                                    <strong>
                                        <asp:Label ID="Label1" Text="Link to access Exam" runat="server"></asp:Label></strong>
                                </td>
                                <td>
                                    <asp:Label ID="lblAccessExam" runat="server"></asp:Label>
                                    <textarea id="txtAccessExam" runat="server" width="350" maxlength="2000" rows='1'
                                        cols='40' skin="Web20" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="InValid Url"
                                        ControlToValidate="txtAccessExam" ForeColor="Red" ValidationGroup="save" />
                                </td>
                            </tr>
                            <tr class="gridviewRowstyle">
                                <td>
                                    <strong>
                                        <asp:Label ID="Label2" Text="Exam Start Date" runat="server"></asp:Label></strong>
                                </td>
                                <td>
                                    <asp:Label ID="lblStartDate" runat="server"></asp:Label>
                                    <telerik:RadDatePicker ID="txtStartDate" runat="server" Skin="Web20">
                                        <Calendar ID="Calendar1" runat="server" EnableKeyboardNavigation="true" Skin="Web20">
                                        </Calendar>
                                        <DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelWidth="40%">
                                        </DateInput>
                                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                    </telerik:RadDatePicker>
                                    <asp:RequiredFieldValidator runat="server" ID="RFV1" ControlToValidate="txtStartDate"
                                        ErrorMessage="Please select Exam start date" ValidationGroup="save"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr class="gridviewAlternatestyle">
                                <td>
                                    <strong>
                                        <asp:Label ID="Label3" Text="Exam End Date" runat="server"></asp:Label></strong>
                                </td>
                                <td>
                                    <asp:Label ID="lblEndDate" runat="server"></asp:Label>
                                    <telerik:RadDatePicker ID="txtEndDate" runat="server" Skin="Web20">
                                        <Calendar ID="Calendar2" runat="server" EnableKeyboardNavigation="true" Skin="Web20">
                                        </Calendar>
                                        <DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelWidth="40%">
                                        </DateInput>
                                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                    </telerik:RadDatePicker>
                                    <asp:RequiredFieldValidator runat="server" ID="RF4" ControlToValidate="txtEndDate"
                                        ErrorMessage="Please select Exam End date" ValidationGroup="save" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="cvtxtStartDate" runat="server" ControlToCompare="txtEndDate"
                                        CultureInvariantValues="true" Operator="LessThanEqual" Display="Dynamic" ControlToValidate="txtStartDate"
                                        ErrorMessage="End Date Must be Greater than Start Date" Type="Date" SetFocusOnError="true"
                                        ForeColor="Red" ValidationGroup="save" />
                                </td>
                            </tr>
                            <tr class="gridviewRowstyle">
                                <td align="left" valign="top">
                                    <strong>Exam File</strong>
                                </td>
                                <td align="left">
                                    <asp:FileUpload ID="upFile" runat="server" EnableViewState="true" Visible="false" />
                                    <asp:LinkButton ID="lnlFile" runat="server" ForeColor="Blue" Font-Underline="true"
                                        OnClick="lnlFile_Click"></asp:LinkButton>
                                    <asp:ImageButton ID="imgCancel" runat="server" ImageUrl="~/Images/cancel_icon.png"
                                        Visible="false" OnClick="lnkCancel_Click" />
                                    <asp:Label ID="lblFile" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblError" runat="server" Visible="false"></asp:Label>
                                </td>
                            </tr>
                            <tr class="gridviewAlternatestyle" runat="server" id="trExamTools" visible="false">
                                <td align="left" valign="top">
                                    <strong>Exam Tools</strong>
                                </td>
                                <td align="left">
                                    <%--  <asp:Label ID="lblTools" runat="server" Text="No Tools available"></asp:Label>
                                    <asp:Image ID="imgCalc" runat="server" ImageUrl="~/Images/ImgCalc.png" Height="50" />
                                    <asp:CheckBox ID="chkCalc" runat="server" Text="Calculator" />&nbsp;&nbsp;
                                    <asp:Image ID="imgStickyNotes" runat="server" ImageUrl="~/Images/Imgstickynote.png"
                                        Height="50" />
                                    <asp:CheckBox ID="chkStickynotes" runat="server" Text="Scrap paper" />--%>

                                    <telerik:RadListBox runat="server" ID="RadListBoxSource" Height="150px" Width="200px"
                                        AllowTransfer="true" TransferToID="RadListBoxDestination">
                                    </telerik:RadListBox>
                                    <telerik:RadListBox runat="server" ID="RadListBoxDestination" Height="150px" Width="200px">
                                    </telerik:RadListBox>
                                </td>
                            </tr>
                            <tr class="gridviewAlternatestyle" runat="server" id="trExamToolsGrid" visible="false">

                                <td colspan="2">

                                    <telerik:RadGrid ID="gvTools" runat="server"
                                        AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" Skin="<%$ Resources:SecureProctor,Telerik_Grid_Skin %>"
                                        CellSpacing="0" GridLines="None">
                                        <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD">
                                            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                                            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                                            </RowIndicatorColumn>
                                            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                                            </ExpandCollapseColumn>

                                            <NoRecordsTemplate>
                                                No records to display.
                                            </NoRecordsTemplate>
                                            <Columns>

                                                <telerik:GridBoundColumn DataField="ToolName" HeaderText="Tools"
                                                    SortExpression="ToolName" UniqueName="ToolName" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" Width="50%" />
                                                    <HeaderStyle Font-Bold="true" />
                                                </telerik:GridBoundColumn>

                                            </Columns>

                                            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                            <FilterItemStyle BackColor="#DCEDFD"></FilterItemStyle>
                                        </MasterTableView>
                                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                        <FilterMenu EnableImageSprites="False">
                                        </FilterMenu>
                                    </telerik:RadGrid>

                                </td>
                            </tr>
                            <tr class="gridviewRowstyle" id="trUpdateNotes" runat="server">
                                <td align="left" valign="top">
                                    <strong>
                                        <asp:Label ID="Label4" Text="Notes for Proctors and Auditors" runat="server"></asp:Label></strong>
                                </td>
                                <td align="left" valign="top">
                                    <telerik:RadTextBox ID="txtNotes" runat="server" TextMode="MultiLine" Width="70%"
                                        MaxLength="5000" Skin="Web20">
                                    </telerik:RadTextBox>
                                    <telerik:RadButton ID="btnAddNotes" runat="server" Text="Add" Skin="Web20" OnClick="btnAddNotes_Click"
                                        ValidationGroup="AddNotes">
                                    </telerik:RadButton>
                                    &nbsp;&nbsp;
                                    <telerik:RadButton ID="btnClearNotes" runat="server" Text="Clear" Skin="Web20" OnClick="btnClearNotes_Click">
                                    </telerik:RadButton>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="<%$ Resources:ResMessages,Provider_Notes %>"
                                        ControlToValidate="txtNotes" ForeColor="Red" ValidationGroup="AddNotes">
                                    </asp:RequiredFieldValidator>
                                    <br />
                                </td>
                            </tr>
                            <tr class="gridviewAlternatestyle">
                                <td colspan="2">
                                    <telerik:RadGrid ID="gvNotes" runat="server" OnNeedDataSource="gvNotes_NeedDataSource"
                                        AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" Skin="<%$ Resources:SecureProctor,Telerik_Grid_Skin %>"
                                        CellSpacing="0" GridLines="None" OnUpdateCommand="gvNotes_UpdateCommand" OnDeleteCommand="gvNotes_DeleteCommand">
                                        <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD">
                                            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                                            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                                            </RowIndicatorColumn>
                                            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                                            </ExpandCollapseColumn>
                                            <NoRecordsTemplate>
                                                No records to display.
                                            </NoRecordsTemplate>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="NoteID" HeaderText="#" SortExpression="NoteID"
                                                    UniqueName="NoteID" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" Width="25%" />
                                                    <HeaderStyle Font-Bold="true" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="NoteDesc" HeaderText="Notes for Proctors and Auditors"
                                                    SortExpression="NoteDesc" UniqueName="NoteDesc" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" Width="50%" />
                                                    <HeaderStyle Font-Bold="true" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn HeaderText="Action" HeaderStyle-HorizontalAlign="Center"
                                                    UniqueName="Action">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgNoteEdit" runat="server" ImageUrl="~/Images/edit_s.png" CommandName="Edit"
                                                            CommandArgument='<%# Eval("ID")%>' ToolTip="Edit" />&nbsp;&nbsp;
                                                        <asp:ImageButton ID="imgNoteDelete" runat="server" ImageUrl="~/Images/delete_s.png"
                                                            CommandName="Delete" CommandArgument='<%# Eval("ID")%>' ToolTip="Delete" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="25%" />
                                                    <HeaderStyle Font-Bold="true" />
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <EditFormSettings EditFormType="Template">
                                                <FormTemplate>
                                                    <table width="100%" cellpadding="5" cellspacing="5">
                                                        <tr>
                                                            <td align="right" style="padding-right: 5px;">
                                                                <asp:Label ID="lblDesc" Text="Notes for Proctors and Auditors : " runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" style="padding-left: 5px;">
                                                                <telerik:RadTextBox ID="txtNotesDescription" runat="server" Skin="Web20" Text='<%# Eval("NoteDesc")%>'>
                                                                </telerik:RadTextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right"></td>
                                                            <td align="left">
                                                                <asp:ImageButton ID="ImgNoteUpdate" runat="server" ImageUrl="~/Images/icon_update.png"
                                                                    CommandName="Update" CommandArgument='<%# Eval("ID")%>' />&nbsp;&nbsp;&nbsp;
                                                                <asp:ImageButton ID="ImgNotesCancel" runat="server" ImageUrl="~/Images/icon_cancel.png"
                                                                    CommandName="Cancel" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </FormTemplate>
                                            </EditFormSettings>
                                            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                            <FilterItemStyle BackColor="#DCEDFD"></FilterItemStyle>
                                        </MasterTableView>
                                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                        <FilterMenu EnableImageSprites="False">
                                        </FilterMenu>
                                    </telerik:RadGrid>
                                    <%--<asp:GridView ID="gvNotes" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                        GridLines="Both" PagerSettings-Visible="false" Width="100%" OnRowCancelingEdit="gvNotes_RowCancelingEdit"
                                        OnRowEditing="gvNotes_RowEditing" OnRowUpdating="gvNotes_RowUpdating" DataKeyNames="ID"
                                        OnRowDeleting="gvNotes_RowDeleting" OnRowDataBound="gvNotes_RowDataBound">
                                        <HeaderStyle CssClass="gridviewHeaderstyle" />
                                        <RowStyle CssClass="gridviewRowstyle" />
                                        <AlternatingRowStyle CssClass="gridviewAlternatestyle" />
                                        <EmptyDataTemplate>
                                            No Notes available
                                        </EmptyDataTemplate>
                                        <Columns>
                                            <asp:TemplateField HeaderText="Note">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNotesHead" runat="server" Text='<%# Eval("NoteID")%>' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Notes for Proctors and Auditors">
                                                <ItemTemplate>
                                                    &nbsp;&nbsp;&nbsp;<asp:Label ID="lblNotes" runat="server" Text='<%# Eval("NoteDesc")%>' />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtGridNotes" runat="server" Text='<%# Eval("NoteDesc")%>'
                                                        Width="95%"></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="70%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/Images/edit_s.png" CommandName="Edit"
                                                        CommandArgument='<%# Eval("ID")%>' ToolTip="Edit" />&nbsp;&nbsp;
                                                    <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/Images/delete_s.png" CommandName="Delete"
                                                        CommandArgument='<%# Eval("ID")%>' ToolTip="Delete" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:ImageButton ID="imgUpdate" runat="server" ImageUrl="~/Images/icon_update.png"
                                                        CommandName="Update" CommandArgument='<%# Eval("ID")%>' ToolTip="Update" />&nbsp;&nbsp;
                                                    <asp:ImageButton ID="imgCancel" runat="server" ImageUrl="~/Images/icon_cancel.png"
                                                        CommandName="Cancel" CommandArgument='<%# Eval("ID")%>' ToolTip="Cancel" />&nbsp;&nbsp;
                                                    <asp:ImageButton ID="imgDelete1" runat="server" ImageUrl="~/Images/delete_s.png"
                                                        CommandName="Delete" CommandArgument='<%# Eval("ID")%>' ToolTip="Delete" />
                                                </EditItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>--%>
                                </td>
                            </tr>
                            <tr class="gridviewRowstyle" id="trUpdateRules" runat="server">
                                <td align="left" valign="top">
                                    <strong>
                                        <asp:Label ID="Label5" Text="Rules for Student" runat="server"></asp:Label></strong>
                                </td>
                                <td align="left" valign="top">
                                    <telerik:RadTextBox ID="txtRules" runat="server" TextMode="MultiLine" Width="70%"
                                        MaxLength="5000" Skin="Web20">
                                    </telerik:RadTextBox>
                                    <telerik:RadButton ID="btnAddRules" runat="server" Text="Add" Skin="Web20" OnClick="btnAddRules_Click"
                                        ValidationGroup="AddRules">
                                    </telerik:RadButton>
                                    &nbsp;&nbsp;
                                    <telerik:RadButton ID="btnClearRules" runat="server" Text="Clear" Skin="Web20" OnClick="btnClearRules_Click">
                                    </telerik:RadButton>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="<%$ Resources:ResMessages,Provider_Rules %>"
                                        ControlToValidate="txtRules" ForeColor="Red" ValidationGroup="AddRules">
                                    </asp:RequiredFieldValidator>
                                    <br />
                                </td>
                            </tr>
                            <tr class="gridviewAlternatestyle">
                                <td colspan="2">
                                    <%--<asp:GridView ID="gvRules" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                        GridLines="Both" PagerSettings-Visible="false" Width="100%" OnRowDataBound="gvRules_RowDataBound"
                                        OnRowCancelingEdit="gvRules_RowCancelingEdit" OnRowDeleting="gvRules_RowDeleting"
                                        OnRowEditing="gvRules_RowEditing" OnRowUpdating="gvRules_RowUpdating" DataKeyNames="ID">
                                        <HeaderStyle CssClass="gridviewHeaderstyle" />
                                        <RowStyle CssClass="gridviewRowstyle" />
                                        <AlternatingRowStyle CssClass="gridviewAlternatestyle" />
                                        <EmptyDataTemplate>
                                            No Rules available
                                        </EmptyDataTemplate>
                                        <Columns>
                                            <asp:TemplateField HeaderText="Rule">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNotesHead" runat="server" Text='<%# Eval("RuleID")%>' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Rules for Student">
                                                <ItemTemplate>
                                                    &nbsp;&nbsp;&nbsp;<asp:Label ID="lblRule" runat="server" Text='<%# Eval("RuleDesc")%>' />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtGridRules" runat="server" Text='<%# Eval("RuleDesc")%>'
                                                        Width="95%"></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="70%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/Images/edit_s.png" CommandName="Edit"
                                                        CommandArgument='<%# Eval("ID")%>' ToolTip="Edit" />&nbsp;&nbsp;
                                                    <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/Images/delete_s.png" CommandName="Delete"
                                                        CommandArgument='<%# Eval("ID")%>' ToolTip="Delete" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:ImageButton ID="imgUpdate" runat="server" ImageUrl="~/Images/icon_update.png"
                                                        CommandName="Update" CommandArgument='<%# Eval("ID")%>' ToolTip="Update" />&nbsp;&nbsp;
                                                    <asp:ImageButton ID="imgCancel" runat="server" ImageUrl="~/Images/icon_cancel.png"
                                                        CommandName="Cancel" CommandArgument='<%# Eval("ID")%>' ToolTip="Cancel" />&nbsp;&nbsp;
                                                    <asp:ImageButton ID="imgDelete1" runat="server" ImageUrl="~/Images/delete_s.png"
                                                        CommandName="Delete" CommandArgument='<%# Eval("ID")%>' ToolTip="Delete" />
                                                </EditItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>--%>
                                    <telerik:RadGrid ID="gvRules" runat="server" OnNeedDataSource="gvRules_NeedDataSource"
                                        AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" Skin="<%$ Resources:SecureProctor,Telerik_Grid_Skin %>"
                                        CellSpacing="0" GridLines="None" AllowFilteringByColumn="false" OnDeleteCommand="gvRules_DeleteCommand"
                                        OnUpdateCommand="gvRules_UpdateCommand">
                                        <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="RuleID" HeaderText="#" SortExpression="RuleID"
                                                    UniqueName="RuleID" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" Width="25%" />
                                                    <HeaderStyle Font-Bold="true" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="RuleDesc" HeaderText="Rules for Student" SortExpression="RuleDesc"
                                                    UniqueName="RuleDesc" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" Width="50%" />
                                                    <HeaderStyle Font-Bold="true" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn HeaderText="Action" HeaderStyle-HorizontalAlign="Center"
                                                    UniqueName="Action">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgRuleEdit" runat="server" ImageUrl="~/Images/edit_s.png" CommandName="Edit"
                                                            CommandArgument='<%# Eval("ID")%>' ToolTip="Edit" />&nbsp;&nbsp;
                                                        <asp:ImageButton ID="imgRuleDelete" runat="server" ImageUrl="~/Images/delete_s.png"
                                                            CommandName="Delete" CommandArgument='<%# Eval("ID")%>' ToolTip="Delete" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="25%" />
                                                    <HeaderStyle Font-Bold="true" />
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <EditFormSettings EditFormType="Template">
                                                <FormTemplate>
                                                    <table width="100%" cellpadding="5" cellspacing="5">
                                                        <tr>
                                                            <td align="right" style="padding-right: 5px;">
                                                                <asp:Label ID="lblDesc" Text="Rules for Student : " runat="server"></asp:Label>
                                                            </td>
                                                            <td align="left" style="padding-left: 5px;">
                                                                <telerik:RadTextBox ID="txtRuleDescription" runat="server" Skin="Web20" Text='<%# Eval("RuleDesc")%>'>
                                                                </telerik:RadTextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right"></td>
                                                            <td align="left">
                                                                <asp:ImageButton ID="ImgRuleUpdate" runat="server" ImageUrl="~/Images/icon_update.png"
                                                                    CommandName="Update" CommandArgument='<%# Eval("ID")%>' />&nbsp;&nbsp;&nbsp;
                                                                <asp:ImageButton ID="ImgRuleCancel" runat="server" ImageUrl="~/Images/icon_cancel.png"
                                                                    CommandName="Cancel" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </FormTemplate>
                                            </EditFormSettings>
                                            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                        </MasterTableView>
                                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                        <FilterMenu EnableImageSprites="False">
                                        </FilterMenu>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                            <tr class="table_td_first" id="trEditButton" runat="server" visible="false">
                                <td>&nbsp;
                                </td>
                                <td>
                                    <telerik:RadButton ID="btnSave" runat="server" Skin="Web20" Text="Update" OnClick="btnSave_Click1"
                                        CausesValidation="true" ValidationGroup="save">
                                    </telerik:RadButton>
                                    &nbsp;&nbsp;
                                    <telerik:RadButton ID="btnCancel" runat="server" Skin="Web20" Text="Cancel" OnClick="btnCancel_Click1">
                                    </telerik:RadButton>
                                </td>
                            </tr>
                            <tr class="table_td_first" id="trViewButton" runat="server" visible="false">
                                <td>&nbsp;
                                </td>
                                <td>
                                    <telerik:RadButton ID="btnBack" runat="server" Skin="Web20" Text="Back" OnClick="btnBack_Click">
                                    </telerik:RadButton>
                                </td>
                            </tr>
                            <tr class="table_td_first" id="trDeleteButton" runat="server" visible="false">
                                <td>&nbsp;
                                </td>
                                <td>
                                    <telerik:RadButton ID="btnConfirm" runat="server" Skin="Web20" Text="Confirm" OnClick="btnConfirm_Click">
                                    </telerik:RadButton>
                                    &nbsp;&nbsp;
                                    <telerik:RadButton ID="btnDeleteCancel" runat="server" Skin="Web20" Text="Cancel"
                                        OnClick="btnCancel_Click1">
                                    </telerik:RadButton>
                                </td>
                            </tr>
                            <tr valign="top" id="trMessage" runat="server">
                                <td align="center" valign="top" colspan="2">
                                    <table width="100%" cellpadding="1" cellspacing="1" border="0">
                                        <tr>
                                            <td valign="middle" align="right" width="50%">
                                                <%--<img src="../Images/ImgSuccessAlert.png" alt="Success" />&nbsp;&nbsp;--%>
                                            </td>
                                            <td valign="middle" align="left" width="50%">
                                                <asp:Label ID="lblMessage" runat="server"></asp:Label>
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
</asp:Content>

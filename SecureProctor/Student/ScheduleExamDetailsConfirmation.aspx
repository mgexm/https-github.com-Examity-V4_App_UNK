<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true"
    CodeBehind="ScheduleExamDetailsConfirmation.aspx.cs" Inherits="SecureProctor.Student.ScheduleExamDetailsConfirmation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StudentContent" runat="server">
    <script type="text/javascript">
        function printDiv(divName) {
            var DocumentContainer = document.getElementById(divName);
            var html = '<html><head>' +
            //                '<link href="../CSS/ApplicationStyleSheet.css" rel="stylesheet" type="text/css" />' +
                '</head><body style="background:#ffffff;">' +
               DocumentContainer.innerHTML +
               '</body></html>';
            var WindowObject = window.open("", "PrintWindow", "width=900,height=200,top=250,left=150,toolbars=no,scrollbars=yes,status=no,resizable=yes");
            WindowObject.document.writeln(html);
            WindowObject.document.close();
            WindowObject.focus();
            WindowObject.print();
            WindowObject.close();
            document.getElementById(divName).style.display = 'block';
        }
    </script>
    <style type="text/css">
        .module1
        {
            background-color: #dff3ff;
            border: 1px solid #c6e1f2;
        }
    </style>
    <%--<telerik:RadScriptManager runat="server" ID="RadScriptManager1" />--%>
    <%--<telerik:RadSkinManager ID="QsfSkinManager" runat="server" ShowChooser="true" />
    <telerik:RadFormDecorator ID="QsfFromDecorator" runat="server" DecoratedControls="All"
        EnableRoundedCorners="false" />
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Panel1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Panel1" LoadingPanelID="RadAjaxLoadingPanel1">
                    </telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>--%>
    <asp:UpdatePanel ID="UpScheduleExam" runat="server">
        <ContentTemplate>
            <div class="app_container_inner">
                <div class="app_inner_content">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td>
                               <%-- <img id="img" src="~/Images/ImgScheduleExam1.png" alt="student registration" runat="server" />--%>
                                <img id="img" src="~/Images/ImgScheduleExam1.png" alt="student registration" runat="server" />
                            </td>
                            <td width="1%" rowspan="4">
                            </td>
                           <%-- <td>
                                <img src="../Images/ImgHelp.png" alt="help" />
                            </td>--%>
                        </tr>
                        <tr valign="top">
                            <td width="70%">
                                <div class="login_new">
                                    <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                        <tr>
                                            <td align="right" style="height: 40px; vertical-align: middle; color: Black;">
                                                <img src="../Images/ImgPrinter.png" alt="print" />
                                                <asp:LinkButton ID="lnkPrint" Text="Print" runat="server" ForeColor="Black" Font-Bold="true"
                                                    OnClientClick="printDiv('divstr')"></asp:LinkButton>&nbsp;&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr style="font-size: 14px; line-height: 25px; color: #FFFFFF;" class="subHeadfont">
                                                        <td align="center" valign="middle">
                                                            <asp:Label ID="lblHead" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table cellpadding="3" cellspacing="4" width="100%" border="0" style="font-family: Arial;
                                                                font-size: 12px; color: #000;">
                                                                <tr class="gridviewAlternatestyle">
                                                                    <td align="left" width="20%">
                                                                        &nbsp;&nbsp;&nbsp; <strong>ID</strong>
                                                                    </td>
                                                                    <td align="left" width="20%">
                                                                        <asp:Label ID="lblTransactionID" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="gridviewRowstyle">
                                                                    <td align="left">
                                                                        &nbsp;&nbsp;&nbsp; <strong>Student Name</strong>
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblStudentName" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="gridviewAlternatestyle">
                                                                    <td align="left">
                                                                        &nbsp;&nbsp;&nbsp; <strong>Course Name</strong>
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblCourseName" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="gridviewRowstyle">
                                                                    <td align="left">
                                                                        &nbsp;&nbsp;&nbsp; <strong>Exam Name</strong>
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblExamName" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="gridviewAlternatestyle">
                                                                    <td align="left">
                                                                        &nbsp;&nbsp;&nbsp; <strong>Exam Date</strong>
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblDAte" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="gridviewRowstyle">
                                                                    <td align="left">
                                                                        &nbsp;&nbsp;&nbsp; <strong>Exam Time</strong>
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblSlot" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="gridviewAlternatestyle">
                                                                    <td align="left">
                                                                        &nbsp;&nbsp;&nbsp; <strong>Exam Tools</strong>
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblTools" runat="server" Text="No Tools available"></asp:Label>
                                                                        <asp:Image ID="imgCalc" runat="server" Height="50" ImageUrl="~/Images/ImgCalc.png" />
                                                                        &nbsp;&nbsp;
                                                                        <asp:Image ID="imgStickyNotes" runat="server" ImageUrl="~/Images/Imgstickynote.png"
                                                                            Height="50" />
                                                                    </td>
                                                                </tr>
                                                                <tr class="gridviewAlternatestyle">
                                                                    <td colspan="2">
                                                                        <%-- <asp:GridView ID="gvStudentRules" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                                                    Width="100%">
                                                                    <HeaderStyle CssClass="gridviewHeaderstyle" />
                                                                    <RowStyle CssClass="gridviewRowstyle" />
                                                                    <AlternatingRowStyle CssClass="gridviewAlternatestyle" />
                                                                    <EmptyDataRowStyle CssClass="gridviewEmptyRowstyle" />
                                                                    <EmptyDataTemplate>
                                                                        <center>
                                                                            <asp:Label ID="lblNoRows" runat="server" Text="No Rules Available." Font-Size="12px" /></center>
                                                                    </EmptyDataTemplate>
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Rule ID">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblRuleID" runat="server" Text='<%# Eval("RuleID")%>' />
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Rule Description">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblRuleDescription" runat="server" Text='<%# Eval("RuleDesc")%>' />
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>--%>
                                                                        <telerik:RadGrid ID="gvStudentRules" runat="server" OnNeedDataSource="gvStudentRules_NeedDataSource"
                                                                            AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" Skin="<%$ Resources:SecureProctor,Telerik_Grid_Skin %>"
                                                                            CellSpacing="0" GridLines="None">
                                                                            <GroupingSettings CaseSensitive="false" />
                                                                            <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD"
                                                                                EnableNoRecordsTemplate="true" ShowHeadersWhenNoRecords="True">
                                                                                <NoRecordsTemplate>
                                                                                    No records to display.
                                                                                </NoRecordsTemplate>
                                                                                <Columns>
                                                                                    <telerik:GridBoundColumn DataField="RuleID" HeaderText="Rule ID" SortExpression="RuleID"
                                                                                        UniqueName="RuleID" HeaderStyle-HorizontalAlign="Center">
                                                                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                                                        <HeaderStyle Font-Bold="true" />
                                                                                    </telerik:GridBoundColumn>
                                                                                    <telerik:GridBoundColumn DataField="RuleDesc" HeaderText="Rule Description" SortExpression="RuleDesc"
                                                                                        UniqueName="RuleDesc" HeaderStyle-HorizontalAlign="Center">
                                                                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
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
                                                <%-- <fieldset class="module1">
                                            <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center" Height="275px" Style="padding-top: 15px;
                                                padding-left: 15px">--%>
                                                <telerik:RadButton ID="btnConfirm" runat="server" Text="Confirm" Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin %>"
                                                    Width="80" OnClick="btnConfirm_Click">
                                                </telerik:RadButton>
                                                &nbsp;&nbsp;
                                                <telerik:RadButton ID="btnCancel" runat="server" Text="Back" Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin %>"
                                                    Width="80" OnClick="btnCancel_Click">
                                                </telerik:RadButton>
                                                <%--</asp:Panel>
                                            <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
                                            </telerik:RadAjaxLoadingPanel>
                                        </fieldset>--%>
                                            </td>
                                        </tr>
                                        <tr valign="top" id="trMessage" runat="server">
                                            <td align="center" valign="top">
                                                <table width="100%" cellpadding="1" cellspacing="1" border="0">
                                                    <tr>
                                                        <td valign="middle" align="right" width="20%">
                                                            <img src="../Images/ImgSuccessAlert.png" alt="Success" />&nbsp;&nbsp;
                                                        </td>
                                                        <td valign="middle" align="left" width="80%">
                                                            &nbsp;&nbsp;<asp:Label ID="lblMsg" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                            <td width="25%" rowspan="2" valign="top" class="help_text_i">
                                <div class="help_text_i_inner">
                                    <p>
                                        <strong>How do I schedule for an exam ?</strong>
                                        <ul>
                                            <li>You can schedule at any timeslot that best suits you</li>
                                            <li>Right click on available time to schedule an exam</li>
                                            <li>If a slot is grayed out, its not a system issue. It just means that slot is full</li>
                                            <li>Select a preferred date (grayed dates mean they can't be selected)</li>
                                            <li>Select the time that suits you best.</li>
                                        </ul>
                                        <p>
                                        </p>
                                        <p>
                                            <strong>What happens after I schedule ?</strong>
                                            <ul>
                                                <li>You will get an email confirming your schedule</li>
                                                <li>In the email, you will have instructions what to do before and during the exam</li>
                                            </ul>
                                            <p>
                                            </p>
                                            <p>
                                                <strong>How do re-schedule/cancel ?</strong>
                                                <ul>
                                                    <li>You can re-schedule at any time slot that best suits you</li>
                                                    <li>You can re-schedule for an exam 24 hours before the previous scheduled time slot</li>
                                                    <li>If a slot is grayed out, its not a system issue. It just means that slot is full</li>
                                                </ul>
                                                <p>
                                                </p>
                                                <p>
                                                </p>
                                                <p>
                                                </p>
                                                <p>
                                                </p>
                                                <p>
                                                </p>
                                                <p>
                                                </p>
                                                <p>
                                                </p>
                                                <p>
                                                </p>
                                                <p>
                                                </p>
                                                <p>
                                                </p>
                                                <p>
                                                </p>
                                                <p>
                                                </p>
                                                <p>
                                                </p>
                                                <p>
                                                </p>
                                                <p>
                                                </p>
                                                <p>
                                                </p>
                                                <p>
                                                </p>
                                                <p>
                                                </p>
                                                <p>
                                                </p>
                                                <p>
                                                </p>
                                                <p>
                                                </p>
                                                <p>
                                                </p>
                                                <p>
                                                </p>
                                                <p>
                                                </p>
                                                <p>
                                                </p>
                                                <p>
                                                </p>
                                                <p>
                                                </p>
                                                <p>
                                                </p>
                                                <p>
                                                </p>
                                                <p>
                                                </p>
                                                <p>
                                                </p>
                                                <p>
                                                </p>
                                                <p>
                                                </p>
                                                <p>
                                                </p>
                                            </p>
                                        </p>
                                    </p>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <div class="clear">
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpScheduleExam">
        <ProgressTemplate>
            <%--<div class="overlay" id="divProgress">
            <img src="../Images/preloader_transparent.gif" style="position: absolute; left: 50%;
                    top: 40%; margin-top: -30px; margin-left: -30px; width: 50px" />Processing...
            </div>--%>
            <div class="overlay" id="divProgress">
                <div id="modalprogress">
                    <div id="theprogress">
                        <table>
                            <tr>
                                <td align="center">
                                    <img alt="indicator" src="../Images/preloader_transparent.gif" title="Processing..."
                                        style="position: absolute; left: 40%; top: 50%; margin-top: -30px; margin-left: -30px;
                                        width: 50px" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

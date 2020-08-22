<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExamDetails.aspx.cs" Inherits="SecureProctor.Proctor.ExamDetails" %>
<%@ Register TagPrefix="uc" TagName="rules" Src="~/Rules.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../CSS/ApplicationStyleSheet.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <div>
        <table width="100%" cellpadding="2" cellspacing="0">
            <tr class="gridviewRowstyle">
                <td colspan="4">
                    <img src="../Images/ImgExamdetails1.png" alt="ExamDetails" />
                </td>
            </tr>
            <tr class="gridviewAlternatestyle">
                <%--<td>
                    &nbsp;&nbsp;&nbsp;<strong>Exam ID</strong>
                </td>
                <td>
                    :
                    <asp:Label ID="lblExamID" runat="server"></asp:Label>
                </td>--%>
                <td>
                    &nbsp;&nbsp;&nbsp;<strong>Course Name</strong>
                </td>
                <td>
                    :
                    <asp:Label ID="lblCourseName" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;<strong>Exam Name</strong>
                </td>
                <td>
                    :
                    <asp:Label ID="lblExamName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr class="gridviewRowstyle">
                <td>
                    &nbsp;&nbsp;&nbsp;<strong>Exam Start Date and Time</strong>
                </td>
                <td>
                    :
                    <asp:Label ID="lblSlot" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;<strong>Exam End Date and Time</strong>
                </td>
                <td>
                    :
                    <asp:Label ID="lblEndTime" runat="server"></asp:Label>
                </td>
            </tr>
            <tr class="gridviewAlternatestyle">
                <td>
                    &nbsp;&nbsp;&nbsp;<strong>Exam Date</strong>
                </td>
                <td>
                    :
                    <asp:Label ID="lblDAte" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;<strong>Exam Duration</strong>
                </td>
                <td>
                    :
                    <asp:Label ID="lblDuration" runat="server"></asp:Label>
                </td>
            </tr>
            <tr class="gridviewRowstyle">
                <td>
                    &nbsp;&nbsp;&nbsp;<strong>Exam File</strong>
                </td>
                <td>
                    :
                    <asp:LinkButton ID="lnkProviderFile" runat="server" ForeColor="Blue" Font-Underline="true"
                        OnClick="lnkFile_Click"></asp:LinkButton>
                    <asp:Label ID="lblError" runat="server" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr class="gridviewAlternatestyle">
                <td>
                    &nbsp;&nbsp;&nbsp;<strong>Exam URL</strong>
                </td>
                <td colspan="3">
                    :
                    <asp:Label ID="lblURL" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <%--<telerik:RadGrid ID="gvStudentNotes" runat="server" OnNeedDataSource="gvStudentNotes_NeedDataSource"
                        AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" Skin="<%$ Resources:SecureProctor,Telerik_Grid_Skin %>"
                        CellSpacing="0" GridLines="None" PageSize="5" Width="100%">
                        <GroupingSettings CaseSensitive="false" />
                        <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD">
                            <NoRecordsTemplate>
                                No records to display.
                            </NoRecordsTemplate>
                            <Columns>
                        
                                <telerik:GridBoundColumn DataField="NoteDesc" HeaderText="<%$ Resources:SecureProctor,Common_NoteDesc %>"
                                    SortExpression="NoteDesc" UniqueName="NoteDesc" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" Width="20%" />
                                    <HeaderStyle Font-Bold="true" />
                                </telerik:GridBoundColumn>
                            </Columns>
                            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                        </MasterTableView>
                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                    </telerik:RadGrid>--%>

                    <uc:rules ID="ucRules" runat="server" DisplayFrom="PROCTOR"/>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

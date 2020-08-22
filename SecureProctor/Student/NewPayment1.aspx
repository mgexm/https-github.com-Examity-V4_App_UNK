<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewPayment1.aspx.cs" Inherits="SecureProctor.Student.NewPayment1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../CSS/ApplicationStyleSheet.css" type="text/css" rel="Stylesheet" />
    <script src="https://code.jquery.com/jquery-1.11.0.min.js"></script>
 
</head>
<body>
    
    <form id="form1" runat="server" defaultfocus="testimage">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <div class="container_inner">
            <table cellpadding="2" cellspacing="2" width="100%">
                <tr>
                    <td width="70%">
                        <div class="login_new">
                            <table cellpadding="2" cellspacing="0" width="100%" style="padding: 5px; font-size: 15px;">
                                <tr>
                                    <td>
                                        
                                        <div id="NewStep1" class="NewStep1" style="width: 777px; margin: 0px auto;" tabindex="11"></div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <table cellpadding="2" cellspacing="0" width="100%" style="font-size:12px;">

                                            <tr class="gridviewAlternatestyle">
                                                <td align="left">
                                                    <table id="tblLeftPaidValues" runat="server" cellpadding="0" cellspacing="0" width="100%">
                                                       <%-- <tr>
                                                            <td align="left" class="gridviewAlternatestyle">&nbsp;&nbsp;&nbsp; <strong>Exam Fee :</strong>
                                                            </td>
                                                        </tr>--%>
                                                       <tr id="trLeft1" runat="server" class="gridviewAlternatestyle">
                                                            <td tabindex="12">&nbsp;&nbsp;&nbsp;&nbsp;1st hour proctoring</td>
                                                        </tr>
                                                        <tr id="trLeft2" runat="server" visible="false" class="gridviewRowstyle">
                                                            <td tabindex="13">&nbsp;&nbsp;&nbsp;&nbsp;2nd hour proctoring</td>
                                                        </tr>
                                                        <tr id="trLeft3" runat="server" visible="false" class="gridviewAlternatestyle">
                                                            <td tabindex="14">&nbsp;&nbsp;&nbsp;&nbsp;3rd hour proctoring</td>
                                                        </tr>
                                                        <tr id="trLeft4" runat="server" visible="false" class="gridviewRowstyle">
                                                            <td tabindex="15">&nbsp;&nbsp;&nbsp;&nbsp;4th hour proctoring</td>
                                                        </tr>
                                                        <tr id="trLeft5" runat="server" visible="false" class="gridviewAlternatestyle">
                                                            <td tabindex="16">&nbsp;&nbsp;&nbsp;&nbsp;5th hour proctoring</td>
                                                        </tr>
                                                        <tr id="trLeft6" runat="server" visible="false" class="gridviewRowstyle">
                                                            <td tabindex="17">&nbsp;&nbsp;&nbsp;&nbsp;6th hour proctoring</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td align="left">
                                                    <table id="tblRightPaidValues" runat="server" cellpadding="0" cellspacing="0" width="100%" >
                                                        <tr class="gridviewAlternatestyle" id="Examfee" runat="server" visible="false">
                                                            <td align="left">$<asp:Label ID="lblExamFee" runat="server" Font-Bold="true"  TabIndex="18"></asp:Label></td>
                                                        </tr>
                                                        <tr id="trRight1" runat="server" class="gridviewAlternatestyle">
                                                            <td><asp:Label ID="lblFirstHourFee" runat="server" tabindex="19"></asp:Label></td>
                                                        </tr>
                                                        <tr id="trRight2" runat="server" visible="false" class="gridviewRowstyle">
                                                            <td>$&nbsp;&nbsp;&nbsp;<asp:Label ID="Right2" runat="server" tabindex="20"></asp:Label></td>
                                                        </tr>
                                                        <tr id="trRight3" runat="server" visible="false" class="gridviewAlternatestyle">
                                                            <td>$&nbsp;&nbsp;&nbsp;<asp:Label ID="Right3" runat="server" tabindex="21"></asp:Label></td>
                                                        </tr>
                                                        <tr id="trRight4" runat="server" visible="false" class="gridviewRowstyle">
                                                            <td>$&nbsp;&nbsp;&nbsp;<asp:Label ID="Right4" runat="server" tabindex="22"></asp:Label></td>
                                                        </tr>
                                                        <tr id="trRight5" runat="server" visible="false" class="gridviewAlternatestyle">
                                                            <td>$&nbsp;&nbsp;&nbsp;<asp:Label ID="Right5" runat="server" tabindex="23"></asp:Label></td>
                                                        </tr>
                                                        <tr id="trRight6" runat="server" visible="false" class="gridviewRowstyle">
                                                            <td>$&nbsp;&nbsp;&nbsp;<asp:Label ID="Right6" runat="server" tabindex="24"></asp:Label></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr class="gridviewRowstyle">
                                                <td align="left" width="20%">&nbsp;&nbsp;&nbsp;
                                                  
                                                       <asp:Label ID="Label3" runat="server" Text="On-demand" TabIndex="25"></asp:Label>
                                                </td>
                                                <td align="left" width="20%">
                                                    <asp:Label ID="lblOndemandFee" runat="server" tabindex="26"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="gridviewAlternatestyle">
                                                <td align="left" width="20%">&nbsp;&nbsp;&nbsp;
                                                     <strong>
                                                         <asp:Label ID="Label1" runat="server" Text="Total :" tabindex="27"></asp:Label></strong>
                                                </td>
                                                <td align="left" width="20%">
                                                <strong> <asp:Label ID="lblAmount" runat="server" tabindex="28"></asp:Label> </strong>
                                                </td>
                                            </tr>
                                            <tr class="gridviewRowstyle">
                                                <td align="left" >&nbsp;&nbsp;&nbsp; <strong tabindex="29">Student Name</strong>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblStudentName" runat="server" tabindex="30"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="gridviewAlternatestyle">
                                                <td align="left" >&nbsp;&nbsp;&nbsp; <strong tabindex="31">Course Name</strong>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblCourseName" runat="server" tabindex="32"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="gridviewRowstyle">
                                                <td align="left">&nbsp;&nbsp;&nbsp; <strong tabindex="33">Exam Name</strong>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblExamName" runat="server" tabindex="34"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="gridviewAlternatestyle">
                                                <td align="left">&nbsp;&nbsp;&nbsp; <strong tabindex="35">Exam Date</strong>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblDAte" runat="server" tabindex="36"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="gridviewRowstyle">
                                                <td align="left">&nbsp;&nbsp;&nbsp; <strong tabindex="37">Exam Time</strong>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblTime" runat="server" tabindex="38"></asp:Label>
                                                </td>
                                            </tr>
                                            <%-- <tr class="gridviewAlternatestyle">
                                                <td colspan="2">
                                                    <%-- <telerik:RadGrid ID="gvStudentRules" runat="server" OnNeedDataSource="gvStudentRules_NeedDataSource"
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
                                                    </telerik:RadGrid>--%>
                                            <%-- </td>
                                            </tr>--%>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <telerik:RadButton ID="btnBack" runat="server" Text="Back" Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin %>"
                                            OnClick="btnBack_Click">
                                        </telerik:RadButton>
                                        &nbsp;
                                         <telerik:RadButton ID="btnNext" runat="server" Text="Next" Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin %>"  OnClick="btnNext_Click">                                     
                                        </telerik:RadButton>

                                         
                                        </telerik:RadButton>
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
    </form>
    <script type="text/javascript">

        $(document).ready(function () {
            document.getElementById('NewStep1').focus();
        });
        
    </script>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Confirmation.aspx.cs" Inherits="SecureProctor.Student.Confirmation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../CSS/ApplicationStyleSheet.css" type="text/css" rel="Stylesheet" />
    <style type="text/css">
        .container {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <%
            try
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString["PStatusID"] != null)
                    {
                        string strOrderStatus = string.Empty;

                        switch (Request.QueryString["PStatusID"].ToString())
                        {
                            case "000000000":
                                PaymentStatus_Declined.Visible = true;
                                strOrderStatus = "Declined";
                                break;
                            case "111111111":
                                PaymentStatus_Pending.Visible = true;
                                strOrderStatus = "Pending";
                                break;
                            case "222222222":
                                PaymentStatus_Requested.Visible = true;
                                strOrderStatus = "Requested";
                                break;
                            case "333333333":
                                PaymentStatus_Test.Visible = true;
                                strOrderStatus = "Test";
                                break;
                            case "444444444":
                                PaymentStatus_Fraud_Flag.Visible = true;
                                strOrderStatus = "Fraud";
                                break;
                            case "555555555":
                                PaymentStatus_Status_Unknown.Visible = true;
                                strOrderStatus = "Unknown";
                                break;
                        }

                        if (Request.QueryString["PStatusID"].ToString() == "SUCCESS")
                        {
                            strOrderStatus = "Success";
                        }

                        System.Data.SqlClient.SqlParameter[] objSqlParam = new System.Data.SqlClient.SqlParameter[5];
                        objSqlParam[0] = new System.Data.SqlClient.SqlParameter("@I_UserID", System.Data.SqlDbType.Int);
                        if (HttpContext.Current.Session["UserID"] != null)
                            objSqlParam[0].Value = Convert.ToInt32(HttpContext.Current.Session["UserID"].ToString());
                        else
                            objSqlParam[0].Value = 0;
                        objSqlParam[1] = new System.Data.SqlClient.SqlParameter("@V_OrderStatus", System.Data.SqlDbType.VarChar, 100);
                        objSqlParam[1].Value = strOrderStatus;
                        objSqlParam[2] = new System.Data.SqlClient.SqlParameter("@V_OrderID", System.Data.SqlDbType.VarChar, 100);
                        if (Request.QueryString["pid"] != null)
                        {
                            if (Request.QueryString["pid"].ToString().Length > 0)
                                objSqlParam[2].Value = Request.QueryString["pid"].ToString();
                            else
                                objSqlParam[2].Value = Request.QueryString["PStatusID"].ToString();
                        }
                        else
                            objSqlParam[2].Value = Request.QueryString["PStatusID"].ToString();
                        objSqlParam[3] = new System.Data.SqlClient.SqlParameter("@V_OrderURL", System.Data.SqlDbType.NVarChar, 4000);
                        objSqlParam[3].Value = Request.QueryString.ToString();
                        objSqlParam[4] = new System.Data.SqlClient.SqlParameter("@V_TrackingID", System.Data.SqlDbType.VarChar, 100);
                        if (Request.QueryString["tid"] != null)
                            objSqlParam[4].Value = Request.QueryString["tid"].ToString();
                        else
                            objSqlParam[4].Value = "";

                        DAL.SQLHelper.ExecuteNonQuery(DAL.DConConfig.ConnectionString, System.Data.CommandType.StoredProcedure, "USP_Common_LogPaymentGatewayDetails", objSqlParam);
                    }
                }
            }
            catch
            {
            }         
        %>


        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <div class="container_inner">
            <table cellpadding="2" cellspacing="2" width="100%">
                <tr>
                    <td width="70%">
                        <div class="login_new">
                            <table cellpadding="2" cellspacing="2" width="100%" style="padding: 5px; font-size: 15px;">
                                <tr>
                                    <%-- <td>
                                        <div class="NewStep3" style="width: 777px; margin: 0px auto;"></div>
                                    </td>--%>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr id="trSuccess" runat="server">
                                    <td align="center" style="padding-bottom: 20px;">
                                        <asp:Label ID="lblInfo" runat="server"></asp:Label>
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
                                            <tr class="gridviewAlternatestyle" style="display: none;">
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
                                                <td colspan="4" style="padding-top: 5px; padding-bottom: 5px;" width="100%">

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
                                                <td colspan="4" style="padding-top: 5px; padding-bottom: 5px;" width="100%">

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
                                <tr id="trError" runat="server">
                                    <td align="center">
                                        <div style="padding-bottom: 20px;" align="center">
                                            <%--Your credit card payment was not processed. Use a different card and schedule an Exam <span style="color:#3333FF;"><strong>OR</strong></span> contact credit card customer support @ <span style="color:#3333FF;"><strong>1-800-406-4966</strong></span>.--%>

                                            <div id="PaymentStatus_Declined" runat="server" visible="false">
                                                The information you submitted did not go through processing. Please verify your credit card details for accuracy, and initiate the scheduling process again. Please contact support@examity.com for assistance.
                                            </div>
                                            <div id="PaymentStatus_Pending" runat="server" visible="false">
                                                Payment is Pending.
                                            </div>
                                            <div id="PaymentStatus_Requested" runat="server" visible="false">
                                                Payment is Requested.
                                            </div>
                                            <div id="PaymentStatus_Test" runat="server" visible="false">
                                                Payment is Test.
                                            </div>
                                            <div id="PaymentStatus_Fraud_Flag" runat="server" visible="false">
                                                The information you submitted did not go through processing. Please contact support@examity.com for assistance.
                                            </div>
                                            <div id="PaymentStatus_Status_Unknown" runat="server" visible="false">
                                                Payment is Unknown.
                                            </div>



                                        </div>
                                    </td>
                                </tr>
                                <%-- <tr id="trPLExam" runat="server" visible="false" >
                                    <td align="center" style="padding-bottom: 20px;">Payment process is complete, please click on Next button.</td>
                                </tr>--%>
                                <tr id="trSuccessButtons" runat="server">
                                    <td style="padding-top: 10px;" align="center">
                                        <telerik:RadButton ID="btnLogin" runat="server" Text="OK" Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin %>"
                                            OnClick="btnLogin_Click">
                                        </telerik:RadButton>
                                    </td>
                                </tr>

                                <%-- <tr id="trbeginexam" runat="server" visible="false">
                                    <td style="padding-top: 10px;" align="center">
                                        <telerik:RadButton ID="btnbeginexam" runat="server" Text="Next" Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin %>"
                                             OnClick="btnbeginexam_Click">
                                        </telerik:RadButton>
                                    </td>
                                </tr>--%>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

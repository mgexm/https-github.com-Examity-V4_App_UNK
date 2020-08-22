<%@ Page Title="" Language="C#" MasterPageFile="~/Proctor/Proctor.Master" AutoEventWireup="true" CodeBehind="ProctorConfirmation.aspx.cs" Inherits="SecureProctor.Proctor.ProctorConfirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ProctorContent" runat="server">

<div class="app_container_inner">
        <div class="app_inner_content">
            <table cellpadding="2" cellspacing="2" width="100%">
            <tr>
            <td colspan="3">
                <img src="../Images/examstatus_new.png" />
            </td>
        </tr>
                <tr valign="top">
                    <td width="70%">
                        <div class="login_new">
                            <table width="100%" cellpadding="0" cellspacing="0" style="font-family: Arial; font-size: 12px;">
                                <tr style="font-size: 14px; line-height: 25px; color: #FFFFFF; vertical-align: middle;"
                                    class="subHeadfont">
                                    <td align="center" valign="bottom">
                                      
                                        <asp:Label ID="lblHead" runat="server" Style="vertical-align: middle;"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table cellpadding="3" cellspacing="4" width="100%" border="0" style="font-family: Arial;
                                            font-size: 12px;">
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
                                                   &nbsp;&nbsp;&nbsp;<strong> Student Name</strong>
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
                                                   &nbsp;&nbsp;&nbsp;<strong> Exam Date</strong>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblDAte" runat="server"></asp:Label>
                                                </td>
                                                
                                            </tr>
                                            <tr class="gridviewRowstyle">
                                             
                                                <td align="left">
                                                  &nbsp;&nbsp;&nbsp;<strong> Exam Time </strong>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblSlot" runat="server"></asp:Label>
                                                </td>
                                               
                                            </tr>
                                            
                                                        <tr>
                                                        <td colspan="4" align="center">

                                                         <telerik:RadButton ID="btnConfirm" runat="server" Text="<%$ Resources:SecureProctor,Common_Confirm %>" Skin="Web20" Width="80"
                                                             onclick="btnConfirm_Click">
                                                        </telerik:RadButton>
                                                            <telerik:RadButton ID="btnBack" runat="server" Text="<%$ Resources:SecureProctor,Common_Back %>" Skin="Web20" Width="80"
                                                              onclick="btnBack_Click">
                                                        </telerik:RadButton>

                                                        
                                                        </td>
                                                        
                                                        </tr>

                                                        <tr>
                            <td align="center" colspan="4">
                             <img src="../Images/ImgSuccessAlert.png" width="30" height="30" alt="Success" style="vertical-align: middle;" id="imgtick" runat="server"/>
                            <asp:Label ID="lblSuccess" runat="server"></asp:Label>
                            
                            </td>
                            
                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>

                           
                        </div>
                    </td>
                    <td width="1%" rowspan="2">
                        &nbsp;
                    </td>
                    <td width="25%" rowspan="2" valign="top" class="help_text_i">
                        <div class="help_text_i_inner">
                            <p>
                                <strong>EDUCATION</strong><br />
                                <br />
                                The next generation delivery of proctoring solutions will have a huge impact in
                                Education provider space to enable them being competitive<br />
                                Education industry regulations are a key factor in enabling the Remote Proctoring
                                solution.</p>
                            <p>
                                &nbsp;</p>
                            <p>
                                &nbsp;</p>
                            <p>
                                <strong>CERTIFICATION</strong></p>
                            <p>
                                Numerous certification programs are working at enabling the remote test process
                                to match student needs for convenience and flexibility.</p>
                            <p>
                                Examity has executed education solutions for more than 15 years and has been
                                recognized by industry as a pioneer.
                            </p>
                            <p>
                                We have brought the same expertise to build the Examity solution.</p>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

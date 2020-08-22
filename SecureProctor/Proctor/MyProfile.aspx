<%@ Page Title="" Language="C#" MasterPageFile="~/Proctor/Proctor.Master" AutoEventWireup="true"
    CodeBehind="MyProfile.aspx.cs" Inherits="SecureProctor.Proctor.MyProfile" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ProctorContent" runat="server">
    <table cellpadding="2" cellspacing="2" width="100%">
        <tr>
            <td>
                <img src="../Images/ImgProfile.png" />
            </td>
            <td width="1%" rowspan="3">
            </td>
            <%--<td>
                <img src="../Images/imghelp.png" alt="help" />
            </td>--%>
        </tr>
        <tr>
            <td width="70%" align="center" valign="top">
                <div class="login_new1">
                    <table width="100%" cellpadding="2" cellspacing="4">
                        <%--<tr>
                            <td>
                            <asp:UpdatePanel ID="upDemoInfo" runat="server" UpdateMode="Always">
                            <ContentTemplate>
                            <table width="100%" cellpadding="0" cellspacing="8" class="td_bg">
                                    <tr class="td_header">
                                        <td colspan="4" align="left">
                                            <table width="100%">
                                                <tr>
                                                    <td align="left" class="boreder_home_pro">
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Imgdemografic.png" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="20%">
                                            <asp:Label ID="lblFname" Text="First Name" runat="server" Font-Bold="true"></asp:Label>
                                        </td>
                                        <td align="left" width="20%">
                                            <asp:Label ID="lblFirstName" runat="server"></asp:Label>
                                        </td>
                                        <td width="20%">
                                            <asp:Label ID="lblLName" Text="Last Name" runat="server" Font-Bold="true"></asp:Label>
                                        </td>
                                        <td align="left" width="20%">
                                            <asp:Label ID="lblLastName" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblMail" Text="Email" runat="server" Font-Bold="true"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblEmail" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblGen" Text="Gender" runat="server" Font-Bold="true"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblGender" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblTZone" Text="Time Zone" runat="server" Font-Bold="true"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblTimeZone" runat="server"></asp:Label>
                                           <telerik:RadComboBox ID="ddlTimeZone" runat="server" Width="100" AppendDataBoundItems="true" 
                                             Skin="<%$ Resources:SecureProctor,Telerik_ComboBox_Skin %>"></telerik:RadComboBox>

                                                                                 </td>
                                        <td>
                                            <asp:Label ID="lblsucc" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
                                        </td>
                                        <td id="tdEditTimeZon" runat="server" align="right">
                                            <telerik:RadButton ID="IbtnEdit" runat="server" Text="<%$ Resources:SecureProctor,Common_Edit %>"
                                                Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin %>" OnClick="btnEditTimeZone_Click">
                                            </telerik:RadButton>
                                        </td>
                                        <td id="tdSaveTimeZone" runat="server" align="right">
                                          <telerik:RadButton ID="IbtnSave" runat="server" Text="<%$ Resources:SecureProctor,Common_Save %>"
                                                Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin %>" OnClick="btnSaveTimeZone_Click">
                                            </telerik:RadButton>

                                            <telerik:RadButton ID="IbtnCancel" runat="server" Text="<%$ Resources:SecureProctor,Common_Cancel %>"
                                                Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin %>" OnClick="btnCancelTimeZone_Click">
                                            </telerik:RadButton>
                                                                                          
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                            <Triggers>
                            <asp:AsyncPostBackTrigger  ControlID="IbtnSave" EventName="Click"/>
                            </Triggers>
                            </asp:UpdatePanel>
                                
                            </td>
                        </tr>--%>

                        <tr>
                            <td>
                               <%-- <asp:UpdatePanel ID="upDemoInfo" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>--%>
                                        <table width="100%" cellpadding="0" cellspacing="8" class="td_bg">
                                        
                                            <tr class="td_header">
                                                <td colspan="4" align="left">
                                                    <table width="100%">
                                                        <tr>
                                                       
                                                            <td align="left" class="boreder_home_pro">
                                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/ImgDemografic.png" />
                                                            </td>
                                                           <%-- <td>
                                                    <asp:Label ID="lblsucc" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
                                                </td>--%>
                                                             <td id="tdEditTimeZon" runat="server" align="right" class="boreder_home_pro">
                                                        <%--<asp:ImageButton ID="btnEdit" runat="server" OnClick="btnEdit_Click" ImageUrl="~/Images/Imgedit.png" CausesValidation="false" />--%>
                                                        <telerik:RadButton ID="RadButton1" runat="server" Text="<%$ Resources:SecureProctor,Common_Edit %>"
                                                        Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin %>" OnClick="btnEditTimeZone_Click" CausesValidation="false"  
                                                        AutoPostBack="true">
                                                    </telerik:RadButton>
                                                    </td>
                                                    <td id="tdSaveTimeZone" runat="server" align="right" class="boreder_home_pro">
                                                        <%-- <asp:ImageButton ID="btnSave" runat="server" OnClick="btnSave_Click" ImageUrl="~/Images/Imgsave_icon.png"
                                                                    ValidationGroup="Edit" />
                                                                <asp:ImageButton ID="btnCancel" runat="server" OnClick="btnCancel_Click" ImageUrl="~/Images/Imgcancel_icon.png" CausesValidation="false"
                                                                    />--%>
                                                       <telerik:RadButton ID="RadButton2" runat="server" Text="<%$ Resources:SecureProctor,Common_Save %>"
                                                        Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin %>" OnClick="btnSaveTimeZone_Click" ValidationGroup="Edit"
                                                        AutoPostBack="true">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="RadButton3" runat="server" Text="<%$ Resources:SecureProctor,Grid_Header_Cancel %>"
                                                        Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin %>" OnClick="btnCancelTimeZone_Click" CausesValidation="false"
                                                        AutoPostBack="true">
                                                    </telerik:RadButton>
                                                    </td>
                                                            <%--<td align="right"><asp:Image ID="Image9" runat="server" ImageUrl="~/Images/edit.png" /> &nbsp;&nbsp;&nbsp;</td>--%>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <asp:Label ID="lblsucc" runat="server" Font-Bold="true" ForeColor="Green"></asp:Label>
                                                </td>
                                            </tr>
                                          <tr>
                                        <td>
                                            <asp:Label ID="Label1" Text="First Name" runat="server" Font-Bold="true"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblFirstName" runat="server"></asp:Label>
                                            <telerik:RadTextBox ID="txtFirstName" runat="server" Visible="false">
                                            </telerik:RadTextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="<%$ Resources:ResMessages,Reg_FirstName %>"
                                                ControlToValidate="txtFirstName" ForeColor="Red" ValidationGroup="Edit">
                                            </asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label2" Text="Last Name" runat="server" Font-Bold="true"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblLastName" runat="server"></asp:Label>
                                            <telerik:RadTextBox ID="txtLastName" runat="server" Visible="false">
                                            </telerik:RadTextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="<%$ Resources:ResMessages,Reg_LastName %>"
                                                ControlToValidate="txtLastName" ForeColor="Red" ValidationGroup="Edit">
                                            </asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label3" Text="Email" runat="server" Font-Bold="true"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblEmail" runat="server" Width="100%"></asp:Label>
                                            <telerik:RadTextBox ID="txtEmail" runat="server" Visible="false" Width="320">
                                            </telerik:RadTextBox>


                                        </td>
                                        <%--  <td>
                                            <asp:Label ID="Label4" Text="Gender" runat="server" Font-Bold="true"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblGender" runat="server"></asp:Label>
                                            <telerik:RadComboBox ID="ddlGender" runat="server" Width="100" AppendDataBoundItems="true"
                                                Visible="false" Skin="<%$ Resources:SecureProctor,Telerik_ComboBox_Skin %>">
                                            </telerik:RadComboBox>
                                        </td>--%>
                                        <%--    </tr>
                                    <tr>--%>
                                        <td>
                                            <asp:Label ID="Label5" Text="Time Zone" runat="server" Font-Bold="true" ValidationGroup="Edit"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblTimeZone" runat="server"></asp:Label>

                                            <telerik:RadComboBox ID="ddlTimeZone" runat="server" Width="320" AppendDataBoundItems="true"
                                                Visible="false" Skin="<%$ Resources:SecureProctor,Telerik_ComboBox_Skin %>" OnItemDataBound="ddlTimeZone_ItemDataBound">
                                                <Items>
                                                    <telerik:RadComboBoxItem Value="-1" />
                                                </Items>
                                            </telerik:RadComboBox>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" Display="Dynamic"
                                                ErrorMessage="<%$ Resources:ResMessages,Provider_Useremailid %>" ControlToValidate="txtEmail"
                                                ForeColor="Red" ValidationGroup="Edit">
                                            </asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic"
                                                ValidationGroup="Edit" ForeColor="Red" runat="server" ControlToValidate="txtEmail"
                                                ErrorMessage="<%$ Resources:ResMessages,Provider_UserValidemail %>" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                            </asp:RegularExpressionValidator>

                                        </td>
                                        <td>&nbsp;

                                        </td>
                                        <td>

                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator15" InitialValue="--Select Time Zone--"
                                                Display="Dynamic" ControlToValidate="ddlTimeZone" ValidationGroup="Edit" ErrorMessage="Please select Time Zone" />

                                        </td>

                                    </tr>
                                    <tr>

                                        <td colspan="4" align="left">
                                            <asp:Label ID="Label4" runat="server" Font-Bold="true" ForeColor="Green"></asp:Label>
                                        </td>

                                    </tr>
                                        </table>
                                   <%-- </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ImageButton2" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>--%>
                            </td>
                        </tr>
                        <tr>
                            <td>

                              <asp:UpdatePanel ID="upChangePwd" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <table width="100%" cellpadding="0" cellspacing="8" class="td_bg">
                                    <tr class="td_header">
                                        <td colspan="4" align="left">
                                            <table width="100%">
                                                <tr>
                                                    <td align="left" class="boreder_home_pro">
                                                        <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/ImgChangePassword.png" />
                                                    </td>
                                                    </tr>
                                            </table>
                                        </td>
                                    </tr>
                                  <tr>
                                  <td colspan="4">
                                   <asp:Label ID="lblUpdated" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>
                                  </td>
                                  </tr>
                                    <tr>
                                        <td align="left" colspan="3" width="25%">
                                            <asp:Label ID="lblCurrentPassword" runat="server" Text="Current Password" Font-Bold="true"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCurrentPassword" runat="server" TextMode="Password" CssClass="td_input" BorderColor="#B8B8B8"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="<%$ Resources:ResMessages,MyProfile_CurrPassword %>"
                                                ControlToValidate="txtCurrentPassword" ForeColor="Red" Font-Bold="true" Display="Dynamic"
                                                ValidationGroup="submit">
                                            </asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="3" width="25%">
                                            <asp:Label ID="lblNewPassword" runat="server" Text="New Password" Font-Bold="true"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" CssClass="td_input" BorderColor="#B8B8B8"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="<%$ Resources:ResMessages,MyProfile_NewPassword %>"
                                                ControlToValidate="txtNewPassword" ForeColor="Red" Font-Bold="true" Display="Dynamic"
                                                ValidationGroup="submit">
                                            </asp:RequiredFieldValidator>
                                            <asp:CompareValidator ID="compnew" ControlToValidate="txtNewPassword" ControlToCompare="txtCurrentPassword"
                                                ForeColor="red" Type="String" Operator="NotEqual" EnableClientScript="true" Text="New password cannot be the same as your current password."
                                                runat="server" Display="Dynamic" Font-Bold="true" SetFocusOnError="true" ValidationGroup="submit" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="3" width="25%">
                                            <asp:Label ID="lblConfirmNewPassword" runat="server" Text="Confirm New Password"
                                                Font-Bold="true"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtConfirmNewPassword" runat="server" TextMode="Password" CssClass="td_input" BorderColor="#B8B8B8"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="<%$ Resources:ResMessages,MyProfile_ConfirmNewPassword %>"
                                                ControlToValidate="txtConfirmNewPassword" ForeColor="Red" Font-Bold="true" Display="Dynamic"
                                                ValidationGroup="submit">

                                            </asp:RequiredFieldValidator>
                                            <asp:CompareValidator ID="compval" ControlToValidate="txtConfirmNewPassword" ControlToCompare="txtNewPassword"
                                                ForeColor="red" Type="String" EnableClientScript="true" Text="<%$ Resources:ResMessages,Myprofile_PasswordMatch %>"
                                                runat="server" Display="Dynamic" Font-Bold="true" ValidationGroup="submit" />
                                        </td>
                                    </tr>
                                    <tr>
                                      <td width="25%"  colspan="3">
                                      &nbsp;
                                      </td>
                                    
                                        <td>
                                            <telerik:RadButton ID="btnSubmit" runat="server" Text="<%$ Resources:SecureProctor,Common_Submit %>"
                                                Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin %>" OnClick="btnSubmit_Click"
                                                ValidationGroup="submit">
                                            </telerik:RadButton> 
                                        

                                        </td>
                                      
                                      
                                    </tr>
                                </table>
                                  </ContentTemplate>
                                  <Triggers>
                            <asp:AsyncPostBackTrigger  ControlID="btnSubmit" EventName="Click"/>
                            </Triggers>
                               </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
          <%--  <td width="25%" rowspan="3" valign="top" class="help_text_i">
                <div class="help_text_i_inner">
                    <ul>
                        <li>Proctor can change the password by providing old and new password.</li><br />
                    </ul>
                    <strong>Note :</strong> All the changes/updates made in this page will reflect in
                    your original records.
                    <p>
                        &nbsp;</p>
                    <p>
                        &nbsp;</p>
                    <p>
                        &nbsp;</p>
                    <p>
                        &nbsp;</p>
                    <p>
                        &nbsp;</p>
                    <p>
                        &nbsp;</p>
                    <p>
                        &nbsp;</p>
                </div>
            </td>--%>
        </tr>
    </table>
</asp:Content>

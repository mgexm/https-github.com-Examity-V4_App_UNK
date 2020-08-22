<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ViewStudentDetails.aspx.cs" Inherits="SecureProctor.Admin.ViewStudentDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminContent" runat="server">
<div class="TabbedPanelsContent">
        <table width="100%">
            <tr>
                <td>
                    <img src="../Images/ImgViewStudent1.png" alt="examdetails" />
                </td>
            </tr>
            <tr>
                <td>
                    <div class="login_new1">
                        <table cellpadding="5" cellspacing="1" width="100%" border="0">
                            <tr class="gridviewRowstyle">
                                <%--<td colspan="2" style="font-size: 14px; color: #fff" class="subHeadfont" align="center">
                                    <asp:Label ID="lblHead" runat="server"></asp:Label>
                                </td>--%>
                            </tr>
                            <tr class="gridviewAlternatestyle">
                                <td width="50%">
                                    <strong>
                                        <asp:Label  runat="server" Text="Student First Name"></asp:Label></strong>
                                </td>
                                <td width="50%">
                                    <telerik:RadTextBox ID="txtFirstName" runat="server" Width="250" MaxLength="50" Skin="Web20"
                                        ValidationGroup="save">
                                    </telerik:RadTextBox>
                                  
                                    <asp:Label ID="lblFirstName" runat="server"></asp:Label>
                                    <asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter student first name"
                                        ControlToValidate="txtFirstName" ForeColor="Red" ValidationGroup="save" />
                                </td>
                            </tr>
                            <tr class="gridviewRowstyle">
                                <td>
                                    <strong>
                                        <asp:Label  Text="Student Last Name" runat="server"></asp:Label></strong>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txtStudentLastName" runat="server" Width="250" MaxLength="50" Skin="Web20">
                                    </telerik:RadTextBox>
                                    <asp:Label ID="lblLastName" runat="server"></asp:Label><asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter student last name"
                                        ControlToValidate="txtStudentLastName" ForeColor="Red" ValidationGroup="save" />
                                </td>
                            </tr>

                              <tr class="gridviewAlternatestyle">
                                <td>
                                    <strong>
                                        <asp:Label ID="Label6" Text="Email Address" runat="server"></asp:Label></strong>
                                </td>
                                <td>
                                    <asp:Label ID="lblEmailAddress" runat="server"></asp:Label>
                                    <telerik:RadTextBox ID="txtEmailAddress" runat="server" Width="250" MaxLength="50"
                                        Skin="Web20">
                                    </telerik:RadTextBox>
                                    <asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please enter email address"
                                        ControlToValidate="txtEmailAddress" ForeColor="Red" ValidationGroup="save" Display="Dynamic"/>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" ValidationGroup="save"
                                                    ForeColor="Red" runat="server" ControlToValidate="txtEmailAddress" ErrorMessage="Invalid email address"
                                                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                </td>
                              </tr>
                            <tr class="gridviewRowstyle">
                                <td>
                                    <strong>
                                        <asp:Label ID="Label7" Text="Phone Number" runat="server"></asp:Label></strong>
                                </td>
                                <td>
                                    <asp:Label ID="lblPhoneNumber" runat="server"></asp:Label>
                                    <telerik:RadMaskedTextBox ID="txtPhoneNumber" runat="server" Mask="###-###-####"
                                        Width="250" Skin="Web20">
                                    </telerik:RadMaskedTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter phone number"
                                        ControlToValidate="txtPhoneNumber" ForeColor="Red" ValidationGroup="save" />
                                </td>
                            </tr>
                            <tr class="gridviewAlternatestyle">
                                <td>
                                    <strong>
                                        <asp:Label Text="Time Zone" runat="server"></asp:Label></strong>
                                </td>
                                <td>
                                  
                                   <telerik:RadComboBox ID="ddlTimeZone" runat="server" AppendDataBoundItems="True" Skin="Web20" Width="380">
                                      
                                    </telerik:RadComboBox>
                                    <%--<asp:DropDownList ID="ddlTimeZone" runat="server" AppendDataBoundItems="true">
                                </asp:DropDownList>--%>
                                    <asp:Label ID="lblTimeZone" runat="server"></asp:Label>
                                  
                                
                                   
                                    
                                </td>
                            </tr>

                              <tr class="gridviewRowstyle">
                                <td>
                                    <strong>
                                        <asp:Label ID="Label1" Text="Special accommodations" runat="server"></asp:Label></strong>
                                </td>
                                <td>
                                <asp:Label ID="lblSpecialNeeds" runat="server"></asp:Label>
                                 <telerik:RadComboBox ID="ddlSpecialNeeds" runat="server" onselectedindexchanged="ddlSpecialNeeds_SelectedIndexChanged"  AppendDataBoundItems="True" Skin="Web20" AutoPostBack="true"
                                        Width="50">
                                         <Items>
                                        <telerik:RadComboBoxItem Text="Yes" Value="1" />
                                        <telerik:RadComboBoxItem Text="No" Value="0" />
                                    </Items>
                                    </telerik:RadComboBox>

                                    <%-- <asp:DropDownList ID="ddlSpecialNeeds" runat="server" AppendDataBoundItems="true">
                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:DropDownList>--%>
                                </td>
                            </tr>
                            <tr class="gridviewRowstyle" runat="server" id="trcomments">
                                <td>
                                    <strong>
                                        <asp:Label  Text="Comments" runat="server"></asp:Label></strong>
                                </td>
                                <td>
                                <asp:Label ID="lblComments" runat="server"></asp:Label>
                                 <textarea id="txtcomments" runat="server" style="width: 250px;"></textarea>

                                    <%-- <asp:DropDownList ID="ddlSpecialNeeds" runat="server" AppendDataBoundItems="true">
                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:DropDownList>--%>
                                </td>
                            </tr>
                            
              
                            
                          
                           
                            <tr class="table_td_first" id="trEditButton" runat="server" visible="false">
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <telerik:RadButton ID="btnSave" runat="server" Skin="Web20" Text="Update" OnClick="btnSave_Click1" CausesValidation="true" ValidationGroup="save">
                                    </telerik:RadButton>
                                    &nbsp;&nbsp;
                                    <telerik:RadButton ID="btnCancel" runat="server" Skin="Web20" Text="Cancel" OnClick="btnCancel_Click1">
                                    </telerik:RadButton>
                                </td>
                            </tr>
                            <tr class="table_td_first" id="trViewButton" runat="server" visible="false">
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <telerik:RadButton ID="btnBack" runat="server" Skin="Web20" Text="Back" OnClick="btnBack_Click">
                                    </telerik:RadButton>
                                </td>
                            </tr>
                            <tr class="table_td_first" id="trDeleteButton" runat="server" visible="false">
                                <td>
                                    &nbsp;
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
                                                <img src="../Images/ImgSuccessAlert.png" alt="Success" />&nbsp;&nbsp;
                                            </td>
                                            <td valign="middle" align="left" width="50%">
                                                &nbsp;&nbsp;<asp:Label ID="lblMessage" runat="server"></asp:Label>
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

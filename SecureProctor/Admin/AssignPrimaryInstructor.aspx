<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssignPrimaryInstructor.aspx.cs" Inherits="SecureProctor.Admin.AssignPrimaryInstructor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="shortcut icon" href="../Images/secureproctor.ico" />
    <title></title>
    <link href="../CSS/Common.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        function close() {

            window.close();

        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
    </telerik:RadStyleSheetManager>
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <table cellpadding="2" width="100%">
        <tr>
            <td>
                

                     <div class="heading customfont1">
                    Update primary instructors</div>
            </td>
        </tr>
        <tr id="trMessage" runat="server">
                        <td align="center" colspan="2">
                            <table width="100%" cellpadding="2" cellspacing="2">
                                <tr>
                                    <td align="center">
                                        <table cellpadding="0" cellspacing="0" id="tdInfo" runat="server">
                                            <tr>
                                                <td align="right" style="padding-right: 10px;">
                                                    <asp:Image ID="ImgInfo" runat="server" Width="22" Height="22" />
                                                </td>
                                                <td align="left" valign="middle">
                                                    <asp:Label ID="lblInfo" runat="server" CssClass="lblInfo"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
        <tr id="trAddEnrollment" runat="server">
            <td>
            <div class="login_new1">
                <table cellpadding="0" cellspacing="2" width="100%" border="0">

                    <tr class="gridviewRowstyle">
                        <td class="PopupLable" width="30%">
                            <strong>Course name</strong>
                        </td>
                        <td align="left" width="70%">

                            <asp:Label ID="lblCourseName" runat="server"></asp:Label>
                           
                        </td>
                    </tr>
                    
                    <tr class="gridviewRowstyle">
                        <td class="PopupLable" width="30%">
                            <strong>Instructor names</strong>
                        </td>
                        <td align="left" width="70%">
                            <telerik:RadComboBox ID="rcbInstructor" runat="server" CheckBoxes="true" AppendDataBoundItems="True" Skin="<%$ Resources:AppConfigurations,Skin_Current %>" DropDownAutoWidth="Enabled" Filter="Contains" MarkFirstMatch="true"
                               EnableCheckAllItemsCheckBox="true" EmptyMessage="     --Select Instrcutor--       " LabelCssClass="SelectClient_text" Localization-AllItemsCheckedString="All Instructors selected">
                             </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="--Select Instructor--"
                                                ErrorMessage="Please select instructor name" ControlToValidate="rcbInstructor" ForeColor="Red"  Display="Dynamic"
                                        ValidationGroup="Save"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    
                    <tr class="gridviewAlternatestyle" id="trUpdate" runat="server">
                        <td align="left">
                        </td>
                        <td class="PopupButtons" valign="middle">
                            <telerik:RadButton ID="btnAdd" runat="server" Text="<%$ Resources:AppControls,Admin_AddEnrollment_Button_Save %>"
                                Skin="<%$ Resources:AppConfigurations,Skin_Current %>" ValidationGroup="Save" OnClick="btnAdd_Click">
                            </telerik:RadButton>
                            <telerik:RadButton ID="btnCancel" runat="server" Text="<%$ Resources:AppControls,Admin_AddEnrollment_Button_Cancel %>"
                                Skin="<%$ Resources:AppConfigurations,Skin_Current %>" CausesValidation="false" OnClientClicked="close">
                            </telerik:RadButton>
                        </td>
                    </tr>
                </table>
            </div>
                </td>
        </tr>
        <tr id="trAddEnrollmentConfirmation" runat="server">
            <td>
            <div class="login_new1">
                <table cellpadding="0" cellspacing="2" width="100%" border="0">
                    
                    <tr class="gridviewRowstyle">
                        <td class="PopupLable" width="30%">
                            <strong>Course Name</strong>
                        </td>
                        <td align="left" width="70%">
                            <asp:Label ID="lblCoursenameConfirmation" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr class="gridviewAlternatestyle">
                        <td class="PopupLable">
                          <strong>Primary instructors</strong>
                        </td>
                        <td align="left">
                            <telerik:RadGrid ID="gvInstructors" runat="server"
                AutoGenerateColumns="False" 
                CellSpacing="0" GridLines="None"  PageSize="5"  >
                <GroupingSettings CaseSensitive="false" />
                <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#ffffff" PageSize="5"
                    FilterItemStyle-HorizontalAlign="Center"  BorderWidth="0">
                    <NoRecordsTemplate>
                        No records to display.
                    </NoRecordsTemplate>
                    <Columns>

                      
              <telerik:GridBoundColumn DataField="InstructorName" HeaderText="Instructor names"
                                            HeaderStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" Width="8%" />
                                            <HeaderStyle Font-Bold="true" />
                                        </telerik:GridBoundColumn>



                    </Columns>

                  

                </MasterTableView>
      

            </telerik:RadGrid>
                        </td>
                    </tr>
                    
                    
                </table>
            </div>
                </td>
        </tr>

    </table>
    </form>
</body>

</html>
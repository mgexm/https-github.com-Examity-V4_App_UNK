<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true" CodeBehind="StudentAgreements.aspx.cs" Inherits="SecureProctor.Student.StudentAgreements" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StudentContent" runat="server">

    <script type="text/javascript">
        function StepFn() {
            $('#<%= lblSuccess.ClientID %>').html('');
            var rdAditionalRule = document.getElementById('<%= gvAllowed.MasterTableView.ClientID %>').getElementsByTagName("input");
            var rdSpecialRule = document.getElementById('<%= gvSpecialInstructions_Student.MasterTableView.ClientID %>').getElementsByTagName("input");
            if (document.getElementById('<%= rbtyesorno1.ClientID %>_0').checked && document.getElementById('<%= rbtyesorno2.ClientID %>_0').checked && document.getElementById('<%= rbtyesorno3.ClientID %>_0').checked && document.getElementById('<%= rbtyesorno4.ClientID %>_0').checked && document.getElementById('<%= radio_standardrule.ClientID %>_0').checked) {

                var AdditionalRule = false;
                var SpecialRule = false;
                /*To check i agree for adtional rules*/
                if (rdAditionalRule.length > 0) {
                    for (i = 0; i < rdAditionalRule.length; i++) {
                        if (rdAditionalRule[i].checked == true) {
                            AdditionalRule = true;
                        }
                        else {
                            AdditionalRule = false;
                        }
                    }
                }
                else {
                    AdditionalRule = true;
                }

                /*End To check i agree for adtional rules*/

                /*To check i agree for standard rules*/
                if (rdSpecialRule.length > 0) {
                    for (i = 0; i < rdSpecialRule.length; i++) {
                        if (rdSpecialRule[i].checked == true) {
                            SpecialRule = true;
                        }
                        else {
                            SpecialRule = false;
                        }
                    }
                }
                else {
                    SpecialRule = true;
                }

                if (AdditionalRule == true && SpecialRule == true) {
                    return true;
                }
                else {
                    $('#<%= lblSuccess.ClientID %>').html('<%= Resources.ResMessages.Student_Agreements %>');
                    return false;
                }
            }
            else {
                $('#<%= lblSuccess.ClientID %>').html('<%= Resources.ResMessages.Student_Agreements %>');
                return false;
            }
        }


    </script>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <h1 style="padding: 10px; color: #666;">User Agreements</h1>
            </td>
        </tr>
        <tr>
            <td>
                <div class="login_new1">
                    <div class="chat_window">
                        <table cellpadding="2" cellspacing="2" width="100%">
                            <tr>
                                <td align="center" class="AAStep_shadow" valign="top">
                                    <div class="AAStep_shadow_inner">
                                        <div class="NewStep_eK4" style="width: 800px; margin: 0px auto; display: none;" id="WithKEYStep4" runat="server"></div>
                                        <div class="steps2" style="width: 777px; height: 80px; margin: 0px auto; display: none;" id="WithoutKEYStep3" runat="server"></div>
                                        <table cellpadding="2" cellspacing="2" width="100%">
                                            <tr>
                                                <td width="100%" align="center">
                                                    <div class="login_new_steps">
                                                        <table width="100%" cellpadding="2" cellspacing="4">
                                                            <tr>
                                                                <td align="center">
                                                                    <asp:Label ID="lblSuccess" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center">
                                                                    <table width="95%" cellpadding="4" cellspacing="5">
                                                                        <tr>
                                                                            <td width="75%" style="text-align: justify;">
                                                                                <strong>1.&nbsp&nbsp</strong>
                                                                                You certify that you are not accepting or utilizing any external help to complete
                                                                                                the exam, and are the applicable exam taker who is responsible for any violation
                                                                                                of exam rules. You understand and acknowledge that all exam rules will be supplied
                                                                                                by the applicable university or test sanctioning body, and the company will have
                                                                                                no responsibility with respect thereto. You agree to participate in the disciplinary
                                                                                                process supported by the university or test sanctioning body should any such party
                                                                                                make such request of you in connection with any violation of exam rules.
                                                                                                <asp:Label ID="lblAgreement1" runat="server" Text=""></asp:Label>
                                                                            </td>
                                                                            <td width="20%" valign="middle">
                                                                                <asp:RadioButtonList ID="rbtyesorno1" runat="server" RepeatDirection="Horizontal"
                                                                                    AutoPostBack="false">
                                                                                    <asp:ListItem Value="0">I agree</asp:ListItem>
                                                                                    <asp:ListItem Value="1">Disagree</asp:ListItem>
                                                                                </asp:RadioButtonList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: justify;">
                                                                                <strong>2.&nbsp&nbsp</strong>
                                                                                You agree that you will be held accountable for any and all infractions associated
                                                                                                with identity misrepresentation and agree to participate in the disciplinary process
                                                                                                supported by the university or test sanctioning body should any such party make
                                                                                                any request of you.
                                                                                                <asp:Label ID="lblAgreement2" runat="server" Text=""></asp:Label>
                                                                            </td>
                                                                            <td valign="middle">
                                                                                <asp:RadioButtonList ID="rbtyesorno2" runat="server" RepeatDirection="Horizontal"
                                                                                    AutoPostBack="false">
                                                                                    <asp:ListItem Value="0">I agree</asp:ListItem>
                                                                                    <asp:ListItem Value="1">Disagree</asp:ListItem>
                                                                                </asp:RadioButtonList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: justify;">
                                                                                <strong>3.&nbsp&nbsp</strong>
                                                                                You understand that by using any of the features of the examity web site and services,
                                                                                                 you act at your own risk, and you represent and warrant that (a) 
                                                                                                you are the enrolled student who is authorized to take the applicable exam and (b) 
                                                                                                the identification you have provided is completely accurate and you fully understand 
                                                                                                that any falsification will be a violation of these terms of use and will be reported 
                                                                                                to the appropriate university or test sanctioning body.
                                                                                                <asp:Label ID="lblAgreement3" runat="server" Text=""></asp:Label>
                                                                            </td>
                                                                            <td valign="middle">
                                                                                <asp:RadioButtonList ID="rbtyesorno3" runat="server" RepeatDirection="Horizontal"
                                                                                    AutoPostBack="false">
                                                                                    <asp:ListItem Value="0">I agree</asp:ListItem>
                                                                                    <asp:ListItem Value="1">Disagree</asp:ListItem>
                                                                                </asp:RadioButtonList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: justify;">
                                                                                <strong>4.&nbsp&nbsp</strong>
                                                                                You acknowledge that your webcam and computer screen may be monitored and viewed,
                                                                                                recorded and audited to ensure the integrity of the exams. You agree that no one
                                                                                                other than you will appear on your webcam or computer screen. You understand acknowledge
                                                                                                that such data, along with your test answers, will be stored, retrieved, analyzed
                                                                                                and shared with the university or test sanctioning body, in our discretion, to ensure
                                                                                                the integrity of the exams.
                                                                                                <asp:Label ID="lblAgreement4" runat="server" Text=""></asp:Label>
                                                                            </td>
                                                                            <td valign="middle">
                                                                                <asp:RadioButtonList ID="rbtyesorno4" runat="server" RepeatDirection="Horizontal"
                                                                                    AutoPostBack="false">
                                                                                    <asp:ListItem Value="0">I agree</asp:ListItem>
                                                                                    <asp:ListItem Value="1">Disagree</asp:ListItem>
                                                                                </asp:RadioButtonList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr class="gridviewRowstyle">
                                                                            <td colspan="2">
                                                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                                                    <tr>
                                                                                        <td width="80%">
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
                                                                                        <td width="20%" valign="top">
                                                                                            <table width="100%" style="border-right: 1px solid #4e75b3; border-bottom: 1px solid #4e75b3; background: #fff;" cellpadding="0" cellspacing="0">
                                                                                                <tr>
                                                                                                    <td style="background: url(../Images/gridheader.jpg) repeat-x; height: 27px;"></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="height: 216px;">
                                                                                                        <asp:RadioButtonList ID="radio_standardrule" runat="server" RepeatDirection="Horizontal"
                                                                                                            AutoPostBack="false">
                                                                                                            <asp:ListItem Value="0">I agree</asp:ListItem>
                                                                                                        </asp:RadioButtonList>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr class="gridviewRowstyle" id="trAllowed" runat="server">
                                                                            <td colspan="2" width="100%">
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
                                                                                                <ItemStyle HorizontalAlign="Left" Width="80%" />
                                                                                                <HeaderStyle Font-Bold="true" />
                                                                                            </telerik:GridBoundColumn>

                                                                                            <telerik:GridTemplateColumn DefaultInsertValue="" UniqueName="rbt_Additionalrules">
                                                                                                <ItemTemplate>
                                                                                                    <asp:RadioButton ID="rbt_Additionalrules" Text="I agree" AllowMultiRowSelection="true"
                                                                                                        runat="server" />
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                                                            </telerik:GridTemplateColumn>
                                                                                        </Columns>
                                                                                    </MasterTableView>
                                                                                </telerik:RadGrid>
                                                                            </td>
                                                                        </tr>
                                                                        <tr class="gridviewRowstyle" runat="server" id="trSpecialStudent">
                                                                            <td colspan="2" style="padding-top: 5px; padding-bottom: 5px;" width="100%">
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
                                                                                                <ItemStyle HorizontalAlign="Left" Width="80%" />
                                                                                                <HeaderStyle Font-Bold="true" />
                                                                                            </telerik:GridBoundColumn>
                                                                                            <telerik:GridTemplateColumn DefaultInsertValue="" UniqueName="rbt_SpecialInstructions">
                                                                                                <ItemTemplate>
                                                                                                    <asp:RadioButton ID="rbt_SpecialInstructions" Text="I agree" AllowMultiRowSelection="true"
                                                                                                        runat="server" />
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                                                            </telerik:GridTemplateColumn>
                                                                                        </Columns>
                                                                                    </MasterTableView>
                                                                                </telerik:RadGrid>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center" colspan="2">
                                                                                <asp:Button ID="btnSubmit" runat="server" Text="Next" CssClass="button_new orange" OnClick="btnSubmit_Click" OnClientClick="return StepFn();" />
                                                                                <%-- <input type="button" value="Submit" class="button_new blue" onclick="StepFn('divStep3', 'divStep4', 'navigate', '');" />--%>
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
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>

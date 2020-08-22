<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Rules.ascx.cs" Inherits="SecureProctor.Rules" EnableViewState="false" %>


<table cellpadding="0" cellspacing="2" width="100%" border="0">
    <tr class="gridviewRowstyle">
        <td colspan="2" style="padding-top: 5px; padding-bottom: 5px;">


            <telerik:RadGrid ID="gvStandard" runat="server"
                AutoGenerateColumns="False" Skin="<%$ Resources:AppConfigurations,Skin_Current %>"
                CellSpacing="0" GridLines="None" ClientSettings-DataBinding-EnableCaching="true" ViewStateMode="Disabled">
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
        <td colspan="2" style="padding-top: 5px; padding-bottom: 5px;">

            <telerik:RadGrid ID="gvAllowed" runat="server"
                AutoGenerateColumns="False" Skin="<%$ Resources:AppConfigurations,Skin_Current %>"
                CellSpacing="0" GridLines="None" MasterTableView-DataKeyNames="RuleID"  ClientSettings-DataBinding-EnableCaching="true" ViewStateMode="Disabled">
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
    <tr class="gridviewRowstyle" runat="server" id="trSpecialStudent" visible="false">
        <td colspan="2" style="padding-top: 5px; padding-bottom: 5px;">

            <telerik:RadGrid ID="gvSpecialInstructions_Student" runat="server"
                AutoGenerateColumns="False" Skin="<%$ Resources:AppConfigurations,Skin_Current %>"
                CellSpacing="0" GridLines="None" MasterTableView-DataKeyNames="RuleID"  ClientSettings-DataBinding-EnableCaching="true" ViewStateMode="Disabled">
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

    <tr class="gridviewRowstyle" runat="server" id="trSpecialProctor" visible="false">
                                <td colspan="2" style="padding-top: 5px; padding-bottom: 5px;">
                                    <telerik:RadGrid ID="gvSpecialInstructions_Proctor" runat="server"
                                        AutoGenerateColumns="False" Skin="<%$ Resources:AppConfigurations,Skin_Current %>"
                                        CellSpacing="0" GridLines="None"  ClientSettings-DataBinding-EnableCaching="true" ViewStateMode="Disabled">
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
                                                <telerik:GridTemplateColumn >
                                                    <HeaderTemplate >
                                                         <asp:Label ID="lblProctorHeader" runat="server" Text="Proctor"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Image ID="ImgProctor" runat="server" ImageUrl='<%# Eval("Proctor")%>'  />&nbsp;&nbsp;
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                    <HeaderStyle Width="10%" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn>
                                                     <HeaderTemplate >
                                                         <asp:Label ID="lblStudentHeader" runat="server" Text="Student"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Image ID="ImgStudent" runat="server" ImageUrl='<%# Eval("Student")%>' />&nbsp;&nbsp;
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                    <HeaderStyle Width="10%" />
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </td>
                            </tr>

</table>

<%@ Page Title="" Language="C#" MasterPageFile="~/Proctor/Proctor.Master" AutoEventWireup="true" CodeBehind="BlockedDates.aspx.cs" Inherits="SecureProctor.Proctor.BlockedDates" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ProctorContent" runat="server">
     <div class="app_container_inner">
        <div class="app_inner_content">
            <asp:UpdatePanel ID="upDates" runat="server">
                <ContentTemplate>
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="100%" cellpadding="2" cellspacing="2" border="0">
                                    <tr>
                                        <td align="left" colspan="2">
                                            <div class="heading customfont1">Add Holiday dates</div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="10%">Select Date :           
                                        </td>
                                        <td align="left" width="90%">
                                            <telerik:RadDatePicker ID="CalendarExtender1" runat="server" Skin="<%$ Resources:AppConfigurations,Skin_Current %>">
                                                <DateInput DisplayDateFormat="MM/dd/yyyy" DateFormat="MM/dd/yyyy" LabelWidth="40%">
                                                </DateInput>
                                            </telerik:RadDatePicker>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">Add Day :  
                                        </td>
                                        <td align="left">
                                            <asp:CheckBox ID="chkAllDay" runat="server" AutoPostBack="true" OnCheckedChanged="chkAllDay_CheckedChanged" Text=""/>
                                        </td>
                                    </tr>
                                    <tr id="trTime" runat="server">
                                        <td align="right">Select Time : </td>
                                        <td align="left">
                                            <telerik:RadTimePicker ID="RadTimePicker1" runat="server" Skin="<%$ Resources:AppConfigurations,Skin_Current %>">
                                                <TimeView ID="TimeView1" StartTime="00:00:00" EndTime="23:59:59" BorderWidth="1px" runat="server" Interval="00:30:00" Columns="6">
                                                    <HeaderTemplate>
                                                        <div style="text-align: center; font-size: 9pt;">
                                                            <b>Select the time</b>
                                                        </div>
                                                    </HeaderTemplate>
                                                </TimeView>
                                            </telerik:RadTimePicker>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>
                                            <telerik:RadButton ID="btnAddDate" runat="server" Text="Add" Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin %>"
                                                OnClick="btnAddDate_Click" Width="75">
                                            </telerik:RadButton>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <div class="heading customfont1">View Holiday Dates</div>
                            </td>
                        </tr>
                        <tr>
                            <td width="100%" align="center" valign="top">
                                <div class="login_new1">
                                    <telerik:RadGrid ID="gvSlots" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" CellSpacing="0"
                                        GridLines="None" Skin="<%$ Resources:SecureProctor,Telerik_Grid_Skin %>" OnNeedDataSource="gvSlots_NeedDataSource" OnItemCommand="gvSlots_ItemCommand">
                                        <GroupingSettings CaseSensitive="false" />
                                        <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="Slot" HeaderText="Blocked Dates"
                                                    SortExpression="Slot" UniqueName="Slot" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" Width="40%" />
                                                    <HeaderStyle Font-Bold="true" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="AddedBy" HeaderText="Added By"
                                                    SortExpression="AddedBy" UniqueName="AddedBy" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" Width="30%" />
                                                    <HeaderStyle Font-Bold="true" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn HeaderText="IsBlockedFromJob"
                                                    HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                    <asp:Label runat="server" ID ="lblIsBlockedFromJob" Text='<%#Eval("IsBlockedFromJob")%>' Font-Bold="true" 
                                                        BackColor='<%#((Eval("IsBlockedFromJob").ToString()=="True")?System.Drawing.ColorTranslator.FromHtml("#F3F781"):System.Drawing.ColorTranslator.FromHtml("#FFFFFF")) %> ' ></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                    <HeaderStyle Font-Bold="true" />
                                                </telerik:GridTemplateColumn>  

                                                <telerik:GridBoundColumn DataField="AddedOn" HeaderText="Added On"
                                                    SortExpression="AddedOn" UniqueName="AddedOn" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                    <HeaderStyle Font-Bold="true" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn HeaderText="Action"
                                                    HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/Images/delete_s.gif" CommandArgument='<%#Bind("ID")%>' CommandName="DeleteSlot" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                    <HeaderStyle Font-Bold="true" />
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                        </MasterTableView>
                                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                        <FilterMenu EnableImageSprites="False">
                                        </FilterMenu>
                                    </telerik:RadGrid>
                                </div>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="clear">
            </div>
        </div>
    </div>
</asp:Content>

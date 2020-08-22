<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GetStudentUploadFiles.ascx.cs" Inherits="SecureProctor.GetStudentUploadFiles" %>
<table cellpadding="0" cellspacing="2" width="100%" border="0">
    <tr class="gridviewRowstyle">
        <td colspan="2" style="padding-top: 5px; padding-bottom: 5px;">

  <telerik:RadGrid ID="gvUploadFiles" runat="server"
                AutoGenerateColumns="False" Skin="<%$ Resources:AppConfigurations,Skin_Current %>" OnNeedDataSource="gvUploadFiles_NeedDataSource"
                CellSpacing="0" GridLines="None" AllowPaging="true" PageSize="5" >
                <GroupingSettings CaseSensitive="false" />
                <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD" PageSize="5"
                    FilterItemStyle-HorizontalAlign="Center">
                    <NoRecordsTemplate>
                        No records to display.
                    </NoRecordsTemplate>
                    <Columns>

                      

                        <telerik:GridTemplateColumn HeaderText="Student Uploaded Files"
                                                        HeaderStyle-HorizontalAlign="left" DataField="OriginalFileName" SortExpression="OriginalFileName"
                                                        UniqueName="OriginalFileName" FilterControlWidth="40px">
                                                        <ItemTemplate>
                                                          <asp:LinkButton ID="lnkOriginalFileName" runat="server"  Text='<%# Eval("OriginalFileName")%>' CommandArgument='<%# Bind("StoredFileName")%>' CommandName="uploadFile" Font-Underline="true" OnClick="lnlFile_Click"/>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="left" Width="2%" />
                                                        <HeaderStyle Font-Bold="true" />
                                                    </telerik:GridTemplateColumn>



                    </Columns>

                  

                </MasterTableView>
      

            </telerik:RadGrid>




            </td>

        </tr>
    </table>

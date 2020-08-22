<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GetExamUploadedFiles.ascx.cs" Inherits="SecureProctor.GetExamUploadedFiles" %>
<table cellpadding="0" cellspacing="2" width="35%" border="0" style="grid-cell: none">
    <tr class="gridviewRowstyle">
        <td colspan="2" style="padding-top: 4px; padding-bottom: 5px;">
       
  <telerik:RadGrid ID="gvUploadFiles" runat="server"
                AutoGenerateColumns="False"  OnNeedDataSource="gvUploadFiles_NeedDataSource"
                CellSpacing="0" GridLines="None"  PageSize="5"  >
                <GroupingSettings CaseSensitive="false" />
                <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#ffffff" PageSize="5"
                    FilterItemStyle-HorizontalAlign="Center"  BorderWidth="0">
                    <NoRecordsTemplate>
                        No records to display.
                    </NoRecordsTemplate>
                    <Columns>

                      

                        <telerik:GridTemplateColumn HeaderStyle-ForeColor="Black" HeaderStyle-BackColor="White" HeaderStyle-Width="0px"
                                                        HeaderStyle-HorizontalAlign="left" DataField="OriginalFileName" SortExpression="OriginalFileName"
                                                        UniqueName="OriginalFileName" FilterControlWidth="40px" HeaderText="Uploaded files">
                                                        <ItemTemplate>
                                                          <asp:LinkButton ID="lnkOriginalFileName" runat="server"  Text='<%# Eval("OriginalFileName")%>' CommandArgument='<%# Bind("StoredFileName")%>' CommandName="uploadFile" Font-Underline="true" OnClick="lnlFile_Click"/>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="left" />
                                                        <HeaderStyle Font-Bold="true" />
                                                    </telerik:GridTemplateColumn>



                    </Columns>

                  

                </MasterTableView>
      

            </telerik:RadGrid>




            </td>

        </tr>
    </table>
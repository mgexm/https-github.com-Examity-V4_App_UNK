<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentUploadFile.aspx.cs" Inherits="SecureProctor.Student.StudentUploadFile"  EnableEventValidation="true"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../CSS/Common.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>

    <form id="form1" runat="server">

        <telerik:RadStyleSheetManager ID="RadStyleSheetManager" runat="server">
        </telerik:RadStyleSheetManager>
        <telerik:RadScriptManager ID="RadScriptManager" runat="server">
        </telerik:RadScriptManager>

        <div>
            <table width="100%" cellpadding="0" cellspacing="2">
                <tr>
                    <td colspan="2">
                        <div class="heading customfont1">
                            Upload Files
                        </div>
                    </td>
                </tr>
                <asp:UpdatePanel ID="up2" runat="server">
                    <ContentTemplate>
                        <tr id="trMessage" runat="server" visible="false">
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
                    </ContentTemplate>

                </asp:UpdatePanel>
                
                 <tr id="trFileTypes" runat="server">
                    <td colspan="2">&nbsp;

                <strong>File types:</strong> &nbsp;&nbsp;jpg, jpeg, png, gif, doc, docx, xlsx, xls, txt, pdf
                        <br /> <br /> 
         
                &nbsp;<strong>Allowed file size:</strong>&nbsp;&nbsp;25 MB.
                         <br />        <br /> 
                &nbsp;<strong>Multiple files can be uploaded by selecting all files at a time and click on Upload.</strong>
          
           
    
                    </td>
                    
                </tr>
                <tr id="trrad" runat="server">
                    <td width="50%" align="left"></td>
                    <td class="PopupButtons" align="center">

                        <telerik:RadAsyncUpload runat="server"  ID="StudentUpload" MultipleFileSelection="Automatic" OnFileUploaded="RadAsyncUpload1_FileUploaded" AllowedFileExtensions="jpg,jpeg,png,gif,doc,docx,xlsx,xls,txt,pdf" MaxUploadSize="25000000">
                        </telerik:RadAsyncUpload>

                    </td>
                </tr>
              
                <tr id="trsaveUpload" runat="server">
                    <td width="50%">&nbsp;

                    </td>
                    <td class="PopupButtons" align="center">
                        <telerik:RadButton runat="server" ID="BtnSubmit" Text="Upload" Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin %>"></telerik:RadButton> &nbsp;&nbsp;File(s) once submitted cannot be changed.
                    </td>
                </tr>
                <tr class="gridviewRowstyle">
        <td colspan="2">


            <telerik:RadGrid ID="gvUploadFiles" runat="server" OnNeedDataSource="gvUploadFiles_NeedDataSource" Width="95%"
                AutoGenerateColumns="False" Skin="<%$ Resources:AppConfigurations,Skin_Current %>"  OnItemCommand="gvUploadFiles_ItemCommand" AllowPaging="true" AllowSorting="true"
                CellSpacing="0" GridLines="None" >
                <GroupingSettings CaseSensitive="false" />
                <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD"
                    FilterItemStyle-HorizontalAlign="Center" PageSize="5">
                    <NoRecordsTemplate>
                        No records to display.
                    </NoRecordsTemplate>
                    <Columns>

                        <telerik:GridTemplateColumn HeaderText="Student Uploaded Files" 
                                                        HeaderStyle-HorizontalAlign="left" DataField="OriginalFileName" SortExpression="OriginalFileName" 
                                                        UniqueName="OriginalFileName" FilterControlWidth="40px">
                                                        <ItemTemplate>
                                                            <div style="width:30%;float:left;"> 
 <asp:LinkButton ID="lnkOriginalFileName" runat="server"  Text='<%# Eval("OriginalFileName")%>' CommandArgument='<%# Bind("StoredFileName")%>' CommandName="uploadFile" Font-Underline="true" />
                                                               
                                                            </div>
                                                         <div style="width:70%;float:left; visibility:hidden">
                                                                <asp:ImageButton ID="imgCancel" runat="server" ImageUrl="~/Images/Imgcancel_icon.png" CommandArgument='<%# Bind("StoredFileName")%>' CommandName="Delete" />
                                                         </div>
                                                        
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

          




        </div>
    </form>
</body>
</html>

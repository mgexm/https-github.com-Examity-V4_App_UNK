<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true" CodeBehind="ExamTools.aspx.cs" Inherits="SecureProctor.Student.ExamTools" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StudentContent" runat="server">
    <table cellpadding="2" cellspacing="2" width="100%">
        <tr>
            <td>
                
                <asp:Image ID="imgHead" runat="server" ImageUrl="../Images/ImgExamTools.png" AlternateText="Exam Tools" title="Exam Tools" TabIndex="11" /></td>
            </td>
        </tr>
        <tr>
            <td width="100%" align="center" valign="top">
                <div class="login_new1">
                    <table width="100%" cellpadding="2" cellspacing="4" align="left">
                        <tr>
                            <td width="25%" class="img_bg_home" align="center">
                               
                                 <asp:ImageButton ImageUrl="../Images/uploadfiles.png" runat="server" OnClick="ImgUpload_Click" TabIndex="12"/>

                            </td>
                            <td  width="25%">&nbsp;</td>
                            <td width="25%">&nbsp;</td>
                            <td width="25%">&nbsp;</td>
                           
                               
                               
                          
                        </tr>
                     
                    </table>
                    <div class="clear">
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>

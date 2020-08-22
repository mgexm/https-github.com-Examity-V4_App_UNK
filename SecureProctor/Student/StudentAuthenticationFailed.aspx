<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true" CodeBehind="StudentAuthenticationFailed.aspx.cs" Inherits="SecureProctor.Student.StudentAuthenticationFailed" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StudentContent" runat="server">

       <script type="text/javascript" src="../Scripts/jquery-timer.js"></script>
     <script type="text/javascript">
         var timer =
        $.timer(
            function getValidationStatus() {

                $.post('../Proctor/AjaxResponse.aspx', { Method: "GetExamiKNOWStatus", TransID: '<%= Request.QueryString["TransID"].ToString() %>', From: '<%= Request.QueryString["From"].ToString() %>' }, function (data) {
                    if (data == "1") {

                        document.getElementById('divNext').style.display = "block";
                       // document.getElementById('divError').style.display = "none";



                    }
                    else {
                        document.getElementById('divNext').style.display = "none";
                       // document.getElementById('divError').style.display = "block";


                    }
                });
            }, 1000, true);
         </script>

  <div id="divData">

<table cellpadding="0" cellspacing="0" width="100%">
<tr><td>
<h1 style="padding:10px; color: #666;">
 <asp:Label ID="lblHead" runat="server" Text="Authentication"></asp:Label>
</h1>
</td>
</tr>

    <tr><td>
         <div class="login_new1">   
<div class="chat_window">
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <div style="margin: 100px auto 0px auto; text-align: center;" id="divError">
                                                <span style="font-size: 40px; color: #f84e4e;">Authentication error.</span><br />
                                                <br />
                                               

                                            </div>
    <div style="display:none;text-align:center" id="divNext" >
        <asp:Button runat="server" ID="btnnext"  Text="Next"  CssClass="button1 orange" OnClick="btnnext_Click"/>

    </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </div>
             </div>
</td></tr>
    </table>
       <div class="clear">
        </div>
        </div>
</asp:Content>

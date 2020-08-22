<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true" CodeBehind="ExamiKEY.aspx.cs" Inherits="SecureProctor.Student.ExamiKEY" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StudentContent" runat="server">
    <div id="DivSppiner" style="text-align: center; background-color: White; position: absolute; top: 50%; left: 50%; margin: -50px 0px 0px -50px; display: none;">
       
        
        <asp:Image ID="ImgLoader" runat="server" ImageUrl="~/Images/Loader.gif" Width="56"
            Height="56" />
    </div>


    <script type="text/javascript">


		 function check(data) {
            if (typeof (data.length) != 'undefined') {
                if (/^[\s]*$/.test(data.toString())) {
                    return true;
                }
            }
        }
		
		
        function StepFn(e) {
           
            var regexp1 = new RegExp("[^a-z]");

            if (e.keyCode == 13 || e.type == 'click') {
                if (check($('#firstname').val())) {
                    $('#<%= lblKeyerror.ClientID %>').html("First Name required.");
					$('#DivSppiner').hide();
                     $('#firstname').focus();
					 $('#firstname').val('');
                     return false;
                 }
                 else if (regexp1.test($('#firstname').val())) {
                     $('#<%= lblKeyerror.ClientID %>').html("CAPS and SPACES are not allowed.");
					 $('#DivSppiner').hide();
					 $('#firstname').focus();
					 $('#firstname').val('');
                   return false;
               }
               else if (check($('#lastname').val())) {
                   $('#<%= lblKeyerror.ClientID %>').html("Last Name required.");
				   $('#DivSppiner').hide();
                   $('#lastname').focus();
				   $('#lastname').val('');
                   return false;
               }
               else if (regexp1.test($('#lastname').val())) {
                   $('#<%= lblKeyerror.ClientID %>').html("CAPS and SPACES are not allowed.");
				   $('#DivSppiner').hide();
                   $('#lastname').focus();
				   $('#lastname').val('');
                   return false;
               }
               else if (check($('#firstNameLastName').val())) {
                   $('#<%= lblKeyerror.ClientID %>').html("First Name and Last Name required.");
				   $('#DivSppiner').hide();
                   $('#firstNameLastName').focus();
				   $('#firstNameLastName').val('');
                   return false;
               }
               else if (regexp1.test($('#firstNameLastName').val())) {
                   $('#<%= lblKeyerror.ClientID %>').html("CAPS and SPACES are not allowed.");
                   $('#firstNameLastName').focus();
				   $('#firstNameLastName').val('');
				   $('#DivSppiner').hide();
                   return false;
               }
               else {
			   $('#DivSppiner').show();
                   var firstname = $('#firstname').val();
                   var firstNameLastName = $('#firstNameLastName').val();
                   var lastname = $('#lastname').val();

                   var fname = firstname + "," + $('#_firstname').val();
                   var flname = firstNameLastName + "," + $('#_firstNameLastName').val();

                   $.post('../AjaxHandler.aspx', { Method: "KeyStroke", firstname: fname, firstNameLastName: flname, TransID: '<%= Request.QueryString["TransID"].ToString() %>' }, function (data) {


                       var arrdata = data.split('|');
                       var z = arrdata[0];
                       var message = arrdata[1];
                       //var z = "true";
                       //var message = "Pass";
                       if (z == "true") {

                           if (message != '') {

                               if (message == "Pass") {

                                   $('#DivSppiner').hide();

                                   document.getElementById('<%=btnNext.ClientID%>').click();
                                document.getElementById('divData').style.display = "none";


                            }
                            else if (message == "Failed") {
                                $('#<%= lblKeyerror.ClientID %>').html(arrdata[2]);
                            $('#firstname').focus();
                            $('#firstname').val('');
                            $('#firstNameLastName').val('');
                            $('#lastname').val('');
                            $('#DivSppiner').hide();

                            document.getElementById('divData').style.display = "block";
                        }
                        else if (message == 'Locked') {
                            $('#firstname').val('');
                            $('#firstNameLastName').val('');
                            $('#lastname').val('');
                            $('#DivSppiner').hide();
                            document.getElementById('<%=btnNext.ClientID%>').click();
                            document.getElementById('divData').style.display = "none";
                        }
                    }

                }
                else {
                       $('#<%= lblKeyerror.ClientID %>').html('Error in validating examiKEY. Please try again.');
                        $('#firstname').val('');
                        $('#firstNameLastName').val('');
                        $('#lastname').val('');
                        $('#DivSppiner').hide();
                        $('#firstname').focus();
                    }
               });
               }
            }
        }
		
		function isAlphapet() {
                var regexp1 = new RegExp("[^a-z]");              
				if (regexp1.test($('#firstname').val())) {
                    $('#<%= lblKeyerror.ClientID %>').html("CAPS and SPACES are not allowed.");
                    $('#firstname').focus();
                    $('#firstname').val('');
                    return false;
                }
                else if (regexp1.test($('#lastname').val())) {
                            $('#<%= lblKeyerror.ClientID %>').html("CAPS and SPACES are not allowed.");
                            $('#lastname').focus();
                            $('#lastname').val('');
                            return false;
                }
                else if (regexp1.test($('#firstNameLastName').val())) {
                            $('#<%= lblKeyerror.ClientID %>').html("CAPS and SPACES are not allowed.");
                            $('#firstNameLastName').focus();
                            $('#firstNameLastName').val('');
                            return false;
                }                        
                else {
                    return true;
				}
        }

    </script>

    <div id="divData">

        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <h1 style="padding: 10px; color: #666;">
                        <asp:Label ID="lblHead" runat="server" Text="Type your name"></asp:Label>
                    </h1>
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
                                            <div class="AAstepsID3" style="width: 800px; margin: 0px auto;"></div>
                                            <table cellpadding="2" cellspacing="2" width="100%">
                                                <tr>
                                                    <td width="100%" align="center">
                                                        <div class="login_new_steps">

                                                            <table width="100%" cellpadding="2" cellspacing="4">
                                                                <tr>
                                                                    <td colspan="3"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="50%" align="right">
                                                                        <asp:Label ID="lblEditFname" runat="server" Text="Enter First Name" CssClass="Display"></asp:Label><br />
                                                                        <asp:Label ID="nocaps" runat="server" Text="(NO CAPS)" CssClass="Display18" Font-Bold="true"></asp:Label>
                                                                    </td>
                                                                    <td>:
                                                                    </td>
                                                                    <td align="left">
                                                                        <input id="firstname" name="firstname" type="text" autocomplete="off" autofocus="autofocus" tabindex="60" onpaste="return false;" oncopy="return false;" style="height: 25px; font-size: 16px; width: 200px" onkeypress="return StepFn(event);" onblur="isAlphapet();"/>&nbsp;                        
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td width="50%" align="right">
                                                                        <asp:Label ID="lblEditLName" runat="server" Text="Enter Last Name" TabIndex="85" CssClass="Display"></asp:Label><br />
                                                                        <asp:Label ID="lblLastnameNocaps" runat="server" Text="(NO CAPS)" CssClass="Display18" Font-Bold="true"></asp:Label>

                                                                    </td>
                                                                    <td>:
                                                                    </td>
                                                                    <td align="left">
                                                                        <input id="lastname" name="lastname" type="text" autofocus="autofocus" autocomplete="off" tabindex="61" style="height: 25px; font-size: 16px; width: 200px" onpaste="return false;" oncopy="return false;" onkeypress="return StepFn(event);" onblur="isAlphapet();"/>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" width="35%">
                                                                        <asp:Label ID="lblEditLastname" runat="server" Text="Enter First Name and Last Name" CssClass="Display"></asp:Label><br />
                                                                        <asp:Label ID="lbleditnamenocaps" runat="server" Text="(NO CAPS, NO SPACES)" CssClass="Display18" Font-Bold="true"></asp:Label>
                                                                    </td>
                                                                    <td>:
                                                                    </td>
                                                                    <td align="left">
                                                                        <input id="firstNameLastName" name="firstNameLastName" type="text" autofocus="autofocus" autocomplete="off" tabindex="61" style="height: 25px; font-size: 16px; width: 200px" onpaste="return false;" oncopy="return false;" onkeypress="return StepFn(event);" onblur="isAlphapet();"/>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>&nbsp;
                                                                    </td>
                                                                    <td>&nbsp;</td>
                                                                    <td align="left">
                                                                        <table width="100%">
                                                                            <tr>
                                                                                <td>
                                                                                    <input type="button" value="Submit" class="button1 orange" onclick="StepFn(event);" autofocus="autofocus" id="submitenter" />
                                                                                </td>
                                                                            </tr>

                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblKeyerror" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                                                                    <div style="display: none">
                                                                                        <asp:Button ID="btnNext" runat="server" OnClick="btnNext_Click" UseSubmitBehavior="false" />
                                                                                    </div>
                                                                                </td>
                                                                            </tr>

                                                                        </table>

                                                                    </td>

                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <p>&nbsp;</p>
                                                                        <p>&nbsp;</p>
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
        <div class="clear">
        </div>
    </div>
    <%--<div id="divSuccess" style="display:none">
         <div style="margin: 100px auto 0px auto; text-align: center;">
                                                <span style="font-size: 40px; color: green">Authentication completed.</span><br />
                                                <br />
                                           

                                            </div>

    </div>

       <div style="display: none;" id="divAuthenticationFailed">
                                            <div style="margin: 100px auto 0px auto; text-align: center;">
                                                <span style="font-size: 40px; color: #f84e4e;">Authentication failed.</span><br />
                                                <br />
                                           

                                            </div>
                                        </div>--%>

    <script src="https://prod.examity.com/commonfiles/StratKeyTrackerV1.js"></script>
    <script type="text/javascript">
        StratKeyTracker.SKTConfigure({ ctrlusername: "firstname", ctrlpassword: "firstNameLastName" });
    </script>

</asp:Content>

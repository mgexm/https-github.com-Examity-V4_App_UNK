<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fPaynow.aspx.cs" Inherits="SecureProctor.Student.fPaynow" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        function postdata() {
            myform.submit();
        }
    </script>
</head>
<body onload="postdata()">
    <form id="myform" action="<%=fActionPage.ToString() %>" method="post">
        <input name="x_login" value="<%= xlogin.ToString() %>" type="hidden" />
        <input name="x_amount" value="<%= Amount.ToString() %>" type="hidden" />
        <input name="x_fp_sequence" value="<%= SequenceNumber.ToString() %>" type="hidden" />
        <input name='x_fp_timestamp' value='<%= Timestamp.ToString()  %>' type='hidden' />
        <input name='x_fp_hash' value='<%=Hashcode %>' type='hidden' />
        <input name='x_first_name' value="<%= strFirstName %>" type='hidden' />  
        <input name='x_last_name' value="<%= strLastName %>" type='hidden' />
        <input name="x_show_form" value="PAYMENT_FORM" type="hidden" />
        <input value="Confirm" type="submit" style="display: none" />
    </form>
</body>
</html>
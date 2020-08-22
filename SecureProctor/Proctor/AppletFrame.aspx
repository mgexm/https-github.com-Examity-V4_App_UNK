<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppletFrame.aspx.cs" Inherits="SecureProctor.Proctor.AppletFrame" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Scripts/deployJava.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <applet code="com.strateology.secureproctor.DesktopView" width="1366" height="768">
            <param name="centerimage" value="true" />
            <param name="boxborder" value="false" />
            <param name="paramOutsideJNLPFile" id="paramOutsideJNLPFile" value='<%= Request.QueryString["id"].ToString() %>' />
            <param name="jnlp_href" value="ProctorTool/launch.jnlp" />
        </applet>
    </div>
    </form>
</body>
</html>

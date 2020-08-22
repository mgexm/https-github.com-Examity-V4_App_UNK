<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DisplayVideo.aspx.cs" Inherits="SecureProctor.Auditor.DisplayVideo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body style="margin:0px">
    <form id="form1" runat="server">
    
        <div id="playerdiv">
            <object width="580" height="440">
                <param name="movie" value="https://fpdownload.adobe.com/strobe/FlashMediaPlayback.swf">
                </param>
                <param name="flashvars" value="src=<%=videosource %>&poster=https%3A%2F%2Ftest.secureproctor.com%2Fnjit%2Fimages%2FImgProductLogo.png">
                </param>
                <param name="allowFullScreen" value="true"></param>
                <param name="allowscriptaccess" value="always"></param>
                <embed src="https://fpdownload.adobe.com/strobe/FlashMediaPlayback.swf" type="application/x-shockwave-flash"
                    allowscriptaccess="always" allowfullscreen="true" width="580" height="440" flashvars="src=<%=videosource %>&poster=https%3A%2F%2Ftest.secureproctor.com%2Fnjit%2Fimages%2FImgProductLogo.png"></embed></object>
        </div>
    
    </form>
</body>
</html>

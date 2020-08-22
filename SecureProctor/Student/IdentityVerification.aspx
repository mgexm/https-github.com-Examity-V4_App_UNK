<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true"
    CodeBehind="IdentityVerification.aspx.cs" Inherits="SecureProctor.Student.IdentityVerification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StudentContent" runat="server">
    <script src="http://java.com/js/deployJava.js" language="javascript" type="text/javascript"></script>
    <script src="http://static.opentok.com/v1.1/js/TB.min.js" type="text/javascript"
        charset="utf-8"></script>
    <script type="text/javascript" charset="utf-8">
        var apiKey = "28465112"; // Replace with your API key. See https://dashboard.tokbox.com/projects
        var sessionId = "<%=SessionID%>"; // Replace with your own session ID. See https://dashboard.tokbox.com/projects
        var token = "<%=TokenID%>"; // Replace with a generated token. See https://dashboard.tokbox.com/projects
        var ChatUsers = new Array();
        var studentname = "";
        var proctorstream = "";
        var streams;


        var session;
        var publisher;
        var subscribers = {};
        var VIDEO_WIDTH = 320;
        var VIDEO_HEIGHT = 240;

        TB.addEventListener("exception", exceptionHandler);

        // Un-comment the following to set automatic logging:
        // TB.setLogLevel(TB.DEBUG);

        if (TB.checkSystemRequirements() != TB.HAS_REQUIREMENTS) {
            alert("You don't have the minimum requirements to run this application."
				  + "Please upgrade to the latest version of Flash.");
        } else {
            //TB.setLogLevel(5);
            session = TB.initSession(sessionId); // Initialize session

            // Add event listeners to the session
            session.addEventListener('sessionConnected', sessionConnectedHandler);
            session.addEventListener('sessionDisconnected', sessionDisconnectedHandler);
            session.addEventListener('connectionCreated', connectionCreatedHandler);
            session.addEventListener('connectionDestroyed', connectionDestroyedHandler);
            session.addEventListener('streamCreated', streamCreatedHandler);
            session.addEventListener('streamDestroyed', streamDestroyedHandler);
        }

        //--------------------------------------
        //  LINK CLICK HANDLERS
        //--------------------------------------

        /*
        If testing the app from the desktop, be sure to check the Flash Player Global Security setting
        to allow the page from communicating with SWF content loaded from the web. For more information,
        see http://www.tokbox.com/opentok/docs/js//tutorials/helloworld.html#localTest
        */
        function connect() {

            session.connect(apiKey, token);

        }

        function disconnect() {
            session.disconnect();
            hide('disconnectLink');
            hide('publishLink');
            hide('unpublishLink');
        }

        // Called when user wants to start publishing to the session
        function startPublishing() {
            if (!publisher) {
                var parentDiv = document.getElementById("myCamera");
                var publisherDiv = document.createElement('div'); // Create a div for the publisher to replace
                publisherDiv.setAttribute('id', 'opentok_publisher');
                parentDiv.appendChild(publisherDiv);
                //var publisherProps = { width: VIDEO_WIDTH, height: VIDEO_HEIGHT,name:"Student", rememberDeviceAccess: true };
                var publisherProps = { width: VIDEO_WIDTH, height: VIDEO_HEIGHT, name: "Student", rememberDeviceAccess: true };
                publisher = TB.initPublisher(apiKey, publisherDiv.id, publisherProps);  // Pass the replacement div id and properties
                session.publish(publisher);
                show('unpublishLink');
                hide('publishLink');
            }
        }

        function stopPublishing() {
            if (publisher) {
                session.unpublish(publisher);

            }
            //session.unpublish();
            publisher = null;
            show('publishLink');
            hide('unpublishLink');
        }

        //--------------------------------------
        //  OPENTOK EVENT HANDLERS
        //--------------------------------------

        function sessionConnectedHandler(event) {
            // Subscribe to all streams currently in the Session
            for (var i = 0; i < event.streams.length; i++) {
                addStream(event.streams[i]);
            }
            startPublishing();
            show('disconnectLink');
            show('publishLink');
            hide('connectLink');
        }

        function streamCreatedHandler(event) {
            // Subscribe to the newly created streams
            for (var i = 0; i < event.streams.length; i++) {
                addStream(event.streams[i]);
            }
        }

        function streamDestroyedHandler(event) {
            // This signals that a stream was destroyed. Any Subscribers will automatically be removed.
            // This default behaviour can be prevented using event.preventDefault()
        }

        function sessionDisconnectedHandler(event) {
            // This signals that the user was disconnected from the Session. Any subscribers and publishers
            // will automatically be removed. This default behaviour can be prevented using event.preventDefault()
            publisher = null;

            show('connectLink');
            hide('disconnectLink');
            hide('publishLink');
            hide('unpublishLink');
        }

        function connectionDestroyedHandler(event) {
            // This signals that connections were destroyed
        }

        function connectionCreatedHandler(event) {
            // This signals new connections have been created.
        }

        /*
        If you un-comment the call to TB.setLogLevel(), above, OpenTok automatically displays exception event messages.
        */
        function exceptionHandler(event) {
            alert("Exception: " + event.code + "::" + event.message);
        }

        //--------------------------------------
        //  HELPER METHODS
        //--------------------------------------

        function addStream(stream) {
            // Check if this is the stream that I am publishing, and if so do not publish.
            if (stream.connection.connectionId == session.connection.connectionId) {
                return;
            }
            var subscriberDiv = document.createElement('div'); // Create a div for the subscriber to replace
            subscriberDiv.setAttribute('id', stream.streamId); // Give the replacement div the id of the stream as its id.
            document.getElementById("subscribers").appendChild(subscriberDiv);
            var subscriberProps = { width: VIDEO_WIDTH, height: VIDEO_HEIGHT };
            subscribers[stream.streamId] = session.subscribe(stream, subscriberDiv.id, subscriberProps);

        }

        function show(id) {
            document.getElementById(id).style.display = 'block';
        }

        function hide(id) {
            document.getElementById(id).style.display = 'none';
        }

    </script>
    <table cellpadding="2" cellspacing="2" width="100%">
        <tr>
            <td>
                <img src="../Images/ImgStartExamHeader.png" alt="" />
            </td>
            <td width="1%" rowspan="3">
            </td>
            <%--<td>
                <img src="../Images/ImgHelp.png" alt="help" />
            </td>--%>
        </tr>
        <tr>
            <td width="70%" align="center" valign="top">
                <div class="login_new1">
                    <table width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="left">
                                <a href="MyExams.aspx">
                                    <asp:Image ID="Image8" runat="server" ImageUrl="~/Images/ImgIdentityVerification.png" /></a>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Label ID="lblmessage" runat="server" Text="Please wait. Your proctor will arrive shortly to verify your identity."
                                    Font-Bold="true" ForeColor="Red" Font-Size="Medium"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="boreder_home">
                                <div style="padding: 10px;">
                                    <div>
                                        <div class="form-horizontal" style="width: 550px; margin-top: 10px;">
                                            <%--Student Name: <input type="text" name="txtStudentName" id="txtStudentName" />
<br />--%>
                                            <%--<div style="text-align:center;width:90%;padding:2%;">
<input type="button" class="btn btn-primary" value="Connect" id ="Button1" onClick="javascript: EnterChat()" />
<input type="button" class="btn btn-primary" value="Disconnect" id ="Button2" onClick="javascript: HideProctor()" />--%>
                                        </div>
                                        <div id="opentok_console">
                                        </div>
                                        <div style="border-radius: 10px; border: solid 1px #ccc; padding: 10px; width: 97%;">
                                            <fieldset>
                                                <legend>Hello Student!</legend>
                                                <div id="myCamera" class="publisherContainer" style="float: left; padding-right: 10px;">
                                                </div>
                                                <div id="subscribers">
                                                </div>
                                            </fieldset>
                                        </div>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                <div id="continue" style="bottom: 100%; top: 75px; z-index: 1000;">
                                    <asp:Label ID="lblError" runat="server" ForeColor="Red" Font-Bold="true" Text="Please wait for the proctor to verify your identity before clicking Next."
                                        Visible="false" /><br />
                                    <telerik:RadButton ID="btnContinue" runat="server" Text="<%$ Resources:SecureProctor,Telerik_Student_Next%>"
                                        CssClass="imghover" Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin%>"
                                        OnClick="btnContinue_Click">
                                    </telerik:RadButton>
                                    
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td width="25%" rowspan="3" valign="top" class="help_text_i">
                <div class="help_text_i_inner">
                    <strong>Hello, this an identification step please follow simple steps to verify your
                        identity. </strong>
                    <ul>
                        <li>Step 1: Select "ALLOW" and click "CLOSE" in the Adobe flash plug in below. </li>
                        <li>Step 2: You will see the proctor. </li>
                        <li>Step 3: Follow proctors instruction. </li>
                        <li>Step 4: Click "NEXT" once the proctor approves your identity</li>
                    </ul>
                    <p>
                        &nbsp;</p>
                    <p>
                        &nbsp;</p>
                    <p>
                        &nbsp;</p>
                    <p>
                        &nbsp;</p>
                </div>
            </td>
        </tr>
    </table>
    <script type="text/javascript" charset="utf-8">
        connect();
	    
    </script>
</asp:Content>

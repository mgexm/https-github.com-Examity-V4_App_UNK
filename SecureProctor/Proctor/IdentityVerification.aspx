<%@ Page Title="" Language="C#" MasterPageFile="~/Proctor/Proctor.Master" AutoEventWireup="true"
    CodeBehind="IdentityVerification.aspx.cs" Inherits="SecureProctor.Proctor.StudentIdentityVerification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProctorContent" runat="server">
    <style type="text/css">
        #wrapper
        {
            margin: 0 auto;
            position: relative;
            width: 400px;
            height: 300px;
        }
        
        #subscribers
        {
            position: relative;
            width: 100%;
            height: 100%;
            z-index: 1;
        }
        
        #myCamera
        {
            position: absolute;
            width: 80px;
            height: 60px;
            z-index: 10;
            bottom: 10px;
            left: 10px;
        }
        
        #subscribers object, #myCamera object
        {
            width: 100%;
            height: 100%;
        }
    </style>
    <script src="http://static.opentok.com/v1.1/js/TB.min.js" type="text/javascript"
        charset="utf-8"></script>
    <script type="text/javascript" charset="utf-8">
        var apiKey = "28465112"; // Replace with your API key. See https://dashboard.tokbox.com/projects
        var sessionId = "<%=SessionID%>"; // Replace with your own session ID. See https://dashboard.tokbox.com/projects
        var token = "<%=TokenID%>"; // Replace with a generated token. See https://dashboard.tokbox.com/projects
        var ChatUsers = new Array();
        var studentname = "";
        var streamname = "";

        function ChatUser(name, id) {
            this.name = name;
            this.id = id;
        }

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
                var publisherProps = { width: VIDEO_WIDTH, height: VIDEO_HEIGHT, name: "Proctor", rememberDeviceAccess: true };
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
                //var user = new ChatUser(event.streams[i].name, event.streams[i].connection.connectionId);
                //ChatUsers.push(user);
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
    <div class="app_container_inner">
        <div class="app_inner_content">
            <table width="100%">
                <tr>
                    <td>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/ImgValidateProctor1.png" />
                    </td>
                    <td>
                        <asp:Label ID="lblError" runat="server" Font-Bold="true" ForeColor="Red" Visible="false" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div class="login_new1">
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td valign="top">
                                        <div id="container">
                                            <div class="form-horizontal">
                                                <div id="opentok_console">
                                                </div>
                                                <div id="links">
                                                    <%--<input type="button" value="Connect" id ="connectLink" onClick="javascript: connect()" />
       	<input type="button" value="Leave" id ="disconnectLink" onClick="javascript: disconnect()" />
       	<input type="button" value="Start Publishing" id ="publishLink" onClick="javascript: startPublishing()" />
       	<input type="button" value="Stop Publishing" id ="unpublishLink" onClick="javascript: stopPublishing()" />--%>
                                                </div>
                                                <fieldset style="margin: auto; width: 50%;">
                                                    <legend>Hello Proctor</legend>
                                                    <div id="wrapper">
                                                        <div id="myCamera" class="publisherContainer">
                                                        </div>
                                                        <div id="subscribers">
                                                        </div>
                                                    </div>
                                                </fieldset>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" align="center">
                                        <asp:CheckBox ID="chkValidateIdentity" runat="server" Text="Validate Identity" /><br />
                                        <telerik:RadButton ID="btnContinue" runat="server" Text="<%$ Resources:SecureProctor,Telerik_Student_Next%>"
                                            CssClass="imghover" Skin="<%$ Resources:SecureProctor,Telerik_Button_Skin%>"
                                            OnClick="btnContinue_Click">
                                        </telerik:RadButton>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
            <div class="clear">
            </div>
        </div>
    </div>
    <script type="text/javascript" charset="utf-8">
        connect();
        //show('connectLink');
    </script>
</asp:Content>

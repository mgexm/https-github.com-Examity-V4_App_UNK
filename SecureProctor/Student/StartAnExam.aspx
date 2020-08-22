<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true"
    CodeBehind="StartAnExam.aspx.cs" Inherits="SecureProctor.Student.StartAnExam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StudentContent" runat="server">

    <div class="app_container_inner">
        <div class="app_inner_content">
            <table cellpadding="2" cellspacing="2" width="100%">
                <tr>
                    <td>
                        <asp:Image ID="imgHead" runat="server" ImageUrl="../Images/ImgStartExamHeader.png" AlternateText="Start Exam" title="Start Exam" TabIndex="11" />
                    </td>
                    <td width="1%" rowspan="3"></td>
                </tr>
                <tr>
                    <td width="100%" align="center" valign="top">
                        <div class="login_new1">
                            <table cellpadding="4">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblMsg" Visible="false" Text="You do not have any exams scheduled.Schedule an exam and it will show up here."
                                            runat="server" CssClass="messages" TabIndex="12"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="Label1" runat="server" CssClass="messages1" Text="Please turn OFF pop-up blocker on your browser before you start exam." TabIndex="14"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="display: none">
                                    <td align="center">
                                        <asp:HyperLink ID="hlkSystemReadyness" Target="_blank" NavigateUrl="http://prod.examity.com/systemcheck/ComputerReadinessCheck1.aspx" runat="server" Text="Computer Requirements Check" Font-Underline="true" ForeColor="Blue" Font-Size="Medium"></asp:HyperLink>
                                    </td>
                                </tr>

                            </table>
                            <fieldset class="stepsblock" id="step1ID" runat="server" >
                                <legend>Step 1</legend>
                                <%--<label id="lblExamityExtensionMessage" style="display: none" class="lbl-extension">To proceed with the exam, Please add <a class="btn-main btn-extension" id="installExtension" href="javascript:void(0);">Examity</a> extension to your browser. </label>--%>
                                  <div id="divExamityExtensionChromeValidationMessage" style="display:none">
                                    <label class="lbl-extension" style="color:red;float:left;line-height:24px;font-weight:bold;">To proceed, relaunch Examity using Google Chrome or Mozilla Firefox</label>&nbsp;
                                  <%--  <img src="../Images/chrome.png" style="height:26px;width:26px;" />--%>
                                </div>
                                    <label id="lblExamityExtensionMessage" style="display: none" class="lbl-extension">To proceed with the exam, Please click <a  id="installExtension" href="javascript:void(0);" style="color:#4279c4"><u>here</u></a> to add Examity extension to your browser. </label>
									 
                                <div id="divExamityExtensionInstalledMessage" style="display: none;">
                                    <label id="lblExamityExtensionInstalledMessage" class="lbl-extension">Examity extension is already installed. Please proceed to step 2 and click on </label>
                                    <span class="runImg">
                                        <img style="width: 20px; margin-left: 5px" alt="" src="../Images/ImgStart.png" /></span>
                                </div>
                            </fieldset>
                            <fieldset class="stepsblock" id="step2ID" >
                                <legend id="step2Legend" runat="server">Step 2</legend>

                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr style='display:none;'>
                                        <td align="center">
                                            <asp:Label ID="lblExamSecurity" runat="server" Font-Bold="true" CssClass="messages1" Text="Students need to scan their room environment with their webcam before beginning the exam." Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <telerik:RadGrid ID="gvStartExam" runat="server" OnNeedDataSource="gvStartExam_NeedDataSource" OnItemDataBound="gvStartExam_ItemDataBound"
                                                AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" Skin="<%$ Resources:SecureProctor,Telerik_Grid_Skin %>"
                                                CellSpacing="0" GridLines="None" OnItemCommand="gvStartExam_ItemCommand">
                                                <GroupingSettings CaseSensitive="false" />
                                                <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD">
                                                    <NoRecordsTemplate>
                                                        No records to display.
                                                    </NoRecordsTemplate>
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="TransID" HeaderText="Exam ID" SortExpression="TransID"
                                                            UniqueName="TransID" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="CourseName" HeaderText="Course Name" SortExpression="CourseName"
                                                            UniqueName="CourseName" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="ExamName" HeaderText="Exam Name" SortExpression="ExamName"
                                                            UniqueName="ExamName" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="Date" HeaderText="Exam Date" SortExpression="Date"
                                                            UniqueName="Date" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="Time" HeaderText="Exam Time" SortExpression="Time"
                                                            UniqueName="Time" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="Examsecurity" Visible="false" HeaderText="sample header" UniqueName="Examsecurity">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="IsexamiFACE" Visible="false" HeaderText="Is examiFACE" UniqueName="IsexamiFACE">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="examikey" Visible="false" HeaderText="Is examikey" UniqueName="Isexamikey">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn HeaderText="Connect to Proctoring" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="lnkAction"
                                                                    
                                                                    runat="server" CommandArgument='<%#Eval("TransID")+","+ Eval("Examsecurity")+","+ Eval("IsexamiFACE")%>' Font-Underline="true" CommandName="StartExam"
                                                                    ImageUrl="~/Images/ImgStart.png" title="Click here to start the exam session"></asp:ImageButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn HeaderText="Connect to Proctor" HeaderStyle-HorizontalAlign="Center" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="lnkStartExam"
                                                                    runat="server" CommandArgument='<%#Bind("TransID")%>' Font-Underline="true" CommandName="StartExam"
                                                                    OnClientClick="return handleGridStartExam();"
                                                                    ImageUrl="~/Images/ImgStart.png" title="Click here to start the exam session"></asp:ImageButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </telerik:GridTemplateColumn>
                                                    </Columns>
                                                    <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                                </MasterTableView>
                                                <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                                <FilterMenu EnableImageSprites="False">
                                                </FilterMenu>
                                            </telerik:RadGrid>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td runat="server" id="tderror" visible="false" align="center">
                                            <asp:Label runat="server" ID="lblError"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </div>
                    </td>
                </tr>
            </table>
            <div class="clear">
            </div>
        </div>
    </div>
    <style>
        .runImg {
            display: inline-block;
            float: right;
            position: absolute;
        }

        fieldset.stepsblock {
            text-align: left;
            padding: 20px;
            border: 1px solid #4372A1;
            margin-bottom: 20px;
        }

            fieldset.stepsblock legend {
                font-weight: bold;
            }

        .blockerMessage {
            color: black;
            font-size: 14px;
            font-weight: bold;
        }

        .btn-extension {
            color: #fff;
            background-color: #FBB040;
        }

        #installExtension {
            color: black;
        }

        .btn-main {
            display: inline-block;
            padding: 6px 12px;
            margin-bottom: 0;
            font-size: 14px;
            font-weight: normal;
            line-height: 1.42857143;
            text-align: center;
            white-space: nowrap;
            vertical-align: middle;
            -ms-touch-action: manipulation;
            cursor: pointer;
            -webkit-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
            background-image: none;
            border: 1px solid transparent;
            border-radius: 4px;
        }


            .btn-main:hover {
                display: inline-block;
                padding: 6px 12px;
                margin-bottom: 0;
                font-size: 14px;
                font-weight: normal;
                line-height: 1.42857143;
                text-align: center;
                white-space: nowrap;
                vertical-align: middle;
                -ms-touch-action: manipulation;
                cursor: pointer;
                -webkit-user-select: none;
                -moz-user-select: none;
                -ms-user-select: none;
                user-select: none;
                background-image: none;
                border: 1px solid #FBB040;
                border-radius: 4px;
                background-color: #F7931E;
            }

        .lbl-extension {
            color: black;
            font-size: 14px;
            font-weight: 400;
        }

        .lbl-extension-green {
            color: green;
            font-size: 14px;
            font-weight: 400;
        }


        .hideFieldSet {
            border: none;
        }
    </style>
    <script src="../Scripts/browser-detect.umd.js"></script>
    <script src="https://prod.examity.com/commonfiles/examitymeetingfirefoxextensionurl.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {


            setTimeout(function () {

                //Issue:https://github.com/Examity/ExamityRTCV3.7/issues/77
                //This variable is loaded from commonfiles/examitymeetingfirefoxextensionurl.js
                var firefoxExtensionURL = window.firefoxExtensionURL || '';

                var chromeExtensionID = window.chromeExtensionID;

                var chromeExtensionURL = window.chromeExtensionBaseURL + chromeExtensionID;

                showHideSteps();

                var browserDetails = browserDetect();
                if (RowCount() > 0 &&( browserDetails.name != 'chrome' && browserDetails.name != 'firefox' ) ){
                    document.getElementById('lblExamityExtensionMessage').style.display = 'none';
                    document.getElementById('divExamityExtensionInstalledMessage').style.display = 'none';
                    document.getElementById('divExamityExtensionChromeValidationMessage').style.display = '';
                }


                else if (RowCount() > 0 && (browserDetails.name == 'chrome' || browserDetails.name == 'firefox')) {

                    if (!document.getElementById('is-examityscreenshare-installed')) {

                        //show install button
                        showInstallButton();

                        //Install extension
                        document.getElementById("installExtension").addEventListener('click', function () {
                            switch (browserDetails.name) {
                                case "chrome":
                                    InstallWindow = window.open(chromeExtensionURL,
                             '_blank', 'location=yes,height=628,width=1000,scrollbars=yes,status=yes');

                                    var chromeInstallerTimer = setInterval(function () {
                                        try {
                                            chrome.runtime.sendMessage(chromeExtensionID, '', function () {
                                                if (chrome.runtime.lastError) {
                                                    console.log('Extension is not installed.');
                                                } else {
                                                    clearInterval(chromeInstallerTimer);
                                                    document.getElementById('lblExamityExtensionMessage').style.display = 'none';
                                                    document.getElementById('divExamityExtensionInstalledMessage').style.display = '';
                                                }
                                            });
                                        } catch (e) {
                                            console.log('Extension is not installed.');
                                        }
                                    }, 1000);

                                    break;
                                case "firefox":
                                    window.open(firefoxExtensionURL, '_self');

                                    var isExtensionInstalledTimer = setInterval(function () {
                                        if (document.getElementById('is-examityscreenshare-installed')) {
                                            clearInterval(isExtensionInstalledTimer);
                                            document.getElementById('lblExamityExtensionMessage').style.display = 'none';
                                            document.getElementById('divExamityExtensionInstalledMessage').style.display = '';
                                        }
                                    }, 500);
                                    break;
                                default:
                                    alert("Examity extension is not available for this browser.");
                                    break;
                            }
                        });
                    }
                    else {
                        document.getElementById('lblExamityExtensionMessage').style.display = 'none';
                        document.getElementById('divExamityExtensionInstalledMessage').style.display = '';
                    }
                }
            }, 1200);
        });
        function showInstallButton() {
            var browserDetails = browserDetect();
            switch (browserDetails.name) {
                case "chrome":
                case "firefox":
                    document.getElementById('lblExamityExtensionMessage').style.display = '';
                    break;
                default:
                    document.getElementById('lblExamityExtensionMessage').style.display = '';
                    break;
            }
        }
        function RowCount() {

            var grid = $find("<%=gvStartExam.ClientID %>");
            if (grid) {
                var MasterTable = grid.get_masterTableView();
                var Rows = MasterTable.get_dataItems();
                return Rows.length;
            } else { return 0; }
        }

        function handleGridStartExam(e) {

            if (browserDetect().name == 'firefox' || browserDetect().name == 'chrome') {
                if (!document.getElementById('is-examityscreenshare-installed')) {
                    {
                        alert("Please install 'Examity' extension to proceed with the exam."); return false;
                    }
                } else { return true; }
            } else { alert("Please use Google Chrome or Mozilla Firefox to proceed with your exam."); return false; }
        }


        function showHideSteps() {

            var browserDetails = browserDetect();

            //show steps only if browser is chrome/firefox.  as extension is available only for these browsers by now.
            switch (browserDetails.name) {
                case "chrome":
                case "firefox":
                    if (RowCount() == 0) {
                        //document.getElementById('<%=step1ID.ClientID%>').style.display = 'none';
                        document.getElementById('step2ID').style.display = 'none';
                    } else {
                        //document.getElementById('<%=step1ID.ClientID%>').style.display = '';
                        document.getElementById('step2ID').style.display = '';
                    }
                    break;
                default:
                    //document.getElementById('<%=step1ID.ClientID%>').style.display = '';
                    document.getElementById('step2ID').style.display = '';
                    break;
            }

        }
    </script>
    

    <%--Examity extension ends--%>
</asp:Content>

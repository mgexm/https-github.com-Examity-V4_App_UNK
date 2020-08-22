<%@ Page Title="" Language="C#" MasterPageFile="~/Provider/Provider.Master" AutoEventWireup="true" CodeBehind="AppointmentDetails.aspx.cs" Inherits="SecureProctor.Provider.AppointmentDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ExamProviderContent" runat="server">
    
         <div class="heading_menu"><a href="Reports.aspx">Reports </a> <img src="../Images/arrowRight.png " width="18" /> <asp:Label ID="lblAppHeader" runat="server" Text=""></asp:Label>
         </div>
      <%--   <div class="note">
        <p>This report provides the summary of Scheduled/Unscheduled appointments. </p>
    </div>--%>
 <div class="export_div">
             <div class="export_div_divmail">       
                 <asp:ImageButton ID="btnExportOptions" runat="server" ImageUrl="~/Images/email.png" CssClass="ImageButtons"  ToolTip="Email" Width="22" OnClick="btnExportOptions_Click" ValidationGroup="Reports" /> 
                 
                    &nbsp;&nbsp;    <asp:ImageButton ID="BtnExportToExcel" runat="server" ImageUrl="~/Images/xls.png" CssClass="ImageButtons"  ToolTip="Export to XLS" Width="22" Height="22" OnClick="BtnExportToExcel_Click" ValidationGroup="Reports" />                                      
</div>
         </div>
    <telerik:RadWindow ID="windowExportOptions"  runat="server" IconUrl="../Images/ExamityLock.png" Title="Send Email" Width="500px" Height="300px">
                            <ContentTemplate>
                                <div class="export_model">
                               
                                  <strong>Enter Email Address </strong><br /><br />
                                    <asp:TextBox placeholder="Enter e-mail ID" TextMode="MultiLine" ID="txtEmail" Width="200px" runat="server" CssClass="textBox medium" ClientIDMode="Static" ValidationGroup="SendMail" />
                                    <br />
                                    <span id="spanMultipleEmails">(To specify multiple addresses, separate the addresses with commas.)</span><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ValidationGroup="SendMail" ErrorMessage="<br />Email cannot be empty!" Display="Dynamic" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="^[\W]*([\w+\-.%]+@[\w\-.]+\.[A-Za-z]{2,4}[\W]*,{1}[\W]*)*([\w+\-.%]+@[\w\-.]+\.[A-Za-z]{2,4})[\W]*$" runat="server" ControlToValidate="txtEmail" ValidationGroup="SendMail" Display="Dynamic" ErrorMessage="<br />Invalid Email Format!" />
                                    <br />
                                    <br />
                                  
                                   
                                    <asp:Button ID="btnSendMail" ClientIDMode="Static" runat="server"  Width="150px" CssClass="button_new orange" Text="Send Mail" ValidationGroup="SendMail"  OnClick="btnSendMail_Click"/>

                                     </br>
                                    <asp:Label ID="lblResult" runat="server"></asp:Label>
                                </div>
                            </ContentTemplate>
                        </telerik:RadWindow>
     <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td width="100%">
                                                <telerik:RadGrid ID="gvExamStatus" runat="server" 
                                                    AutoGenerateColumns="False" AllowPaging="True" AllowSorting="False" CellSpacing="0"
                                                    GridLines="None" Skin="<%$ Resources:SecureProctor,Telerik_Grid_Skin %>" 
                                                     Width="100%" EnableLinqExpressions="false" >
                                                     <GroupingSettings CaseSensitive="false" />
                                                    <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD" PageSize="50" AllowNaturalSort="false">
                                                        <Columns>
                                                            <telerik:GridBoundColumn DataField="TransID"  HeaderText="Exam ID"
                                                                 HeaderStyle-HorizontalAlign="Center" FilterControlWidth="70%">
                                                                <ItemStyle HorizontalAlign="Center" Width="10%"/>
                                                                <HeaderStyle Font-Bold="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="coursename"  HeaderText="Course Name"
                                                                 HeaderStyle-HorizontalAlign="Center" FilterControlWidth="70%">
                                                                <ItemStyle HorizontalAlign="Center" Width="10%"/>
                                                                <HeaderStyle Font-Bold="true" />
                                                            </telerik:GridBoundColumn>                                                             
                                                             <telerik:GridBoundColumn DataField="Instructor name"  HeaderText="Instructor Name"
                                                                 HeaderStyle-HorizontalAlign="Center" FilterControlWidth="70%">
                                                                <ItemStyle HorizontalAlign="Center" Width="10%"/>
                                                                <HeaderStyle Font-Bold="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="ExamName"  HeaderText="Exam Name"
                                                                 HeaderStyle-HorizontalAlign="Center" FilterControlWidth="70%">
                                                                <ItemStyle HorizontalAlign="Center" Width="10%"/>
                                                                <HeaderStyle Font-Bold="true" />
                                                            </telerik:GridBoundColumn>
                                                             <telerik:GridBoundColumn DataField="FirstName" HeaderText="Student First Name"
                                                                HeaderStyle-HorizontalAlign="Center" FilterControlWidth="70%" ItemStyle-CssClass="itemNameColumn">
                                                                <ItemStyle HorizontalAlign="Center" Width="15%"/>
                                                                <HeaderStyle Font-Bold="true" />
                                                            </telerik:GridBoundColumn>
                                                           <telerik:GridBoundColumn DataField="LastName"  HeaderText="Student Last Name"
                                                                HeaderStyle-HorizontalAlign="Center" FilterControlWidth="70%" ItemStyle-CssClass="itemNameColumn">
                                                                <ItemStyle HorizontalAlign="Center" Width="15%"/>
                                                                <HeaderStyle Font-Bold="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="EmailAddress" HeaderText="Email Address"
                                                                HeaderStyle-HorizontalAlign="Center" FilterControlWidth="70%">
                                                                <ItemStyle HorizontalAlign="Center" Width="15%"/>
                                                                <HeaderStyle Font-Bold="true" />
                                                            </telerik:GridBoundColumn>                                                            
                                                            <telerik:GridBoundColumn DataField="ExamDate"  HeaderText="Exam Appointment" DataFormatString="{0:MM/dd/yyyy HH:MM tt}"
                                                                HeaderStyle-HorizontalAlign="Center" AllowFiltering="false" FilterControlWidth="70%" >
                                                                <ItemStyle HorizontalAlign="Center" Width="5%"/>
                                                                <HeaderStyle Font-Bold="true" />
                                                            </telerik:GridBoundColumn>
                                                             <telerik:GridBoundColumn DataField="Status" HeaderText="Status"
                                                                HeaderStyle-HorizontalAlign="Center" AllowFiltering="false" >
                                                                <ItemStyle HorizontalAlign="Center" Width="5%"/>
                                                                <HeaderStyle Font-Bold="true" />
                                                            </telerik:GridBoundColumn>
                                                        </Columns>
                                                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                                        
                                                    </MasterTableView>
                                                    
                                                    <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                                    <FilterMenu EnableImageSprites="False">
                                                    </FilterMenu>
                                                </telerik:RadGrid>
                                            </td>
                                        </tr>
                                    </table>
     <table cellpadding="0" cellspacing="0" width="100%">
       
                                        <tr>
                                            <td width="100%">
                                               <telerik:RadGrid ID="rgvUnScheduledAppointments" runat="server" 
                                                    AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" CellSpacing="0"
                                                    GridLines="None" Skin="<%$ Resources:SecureProctor,Telerik_Grid_Skin %>" 
                                                     Width="100%" EnableLinqExpressions="false" >
                                                     <GroupingSettings CaseSensitive="false" />
                                                    <MasterTableView AllowFilteringByColumn="false" FilterItemStyle-BackColor="#DCEDFD" PageSize="50" AllowNaturalSort="false">
                                                        <Columns>
                                                           
                                                             
                                                            <telerik:GridBoundColumn DataField="CourseName"  HeaderText="Course Name"
                                                                 HeaderStyle-HorizontalAlign="Center" FilterControlWidth="70%">
                                                                <ItemStyle HorizontalAlign="Center" Width="10%"/>
                                                                <HeaderStyle Font-Bold="true" />
                                                            </telerik:GridBoundColumn>                                                             
                                                             <telerik:GridBoundColumn DataField="InstructorName"  HeaderText="Instructor Name"
                                                                 HeaderStyle-HorizontalAlign="Center" FilterControlWidth="70%">
                                                                <ItemStyle HorizontalAlign="Center" Width="10%"/>
                                                                <HeaderStyle Font-Bold="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="ExamName"  HeaderText="Exam Name"
                                                                 HeaderStyle-HorizontalAlign="Center" FilterControlWidth="70%">
                                                                <ItemStyle HorizontalAlign="Center" Width="10%"/>
                                                                <HeaderStyle Font-Bold="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="FirstName" HeaderText="Student First Name"
                                                                HeaderStyle-HorizontalAlign="Center" FilterControlWidth="70%" ItemStyle-CssClass="itemNameColumn">
                                                                <ItemStyle HorizontalAlign="Center" Width="15%"/>
                                                                <HeaderStyle Font-Bold="true" />
                                                            </telerik:GridBoundColumn>
                                                           <telerik:GridBoundColumn DataField="LastName"  HeaderText="Student Last Name"
                                                                HeaderStyle-HorizontalAlign="Center" FilterControlWidth="70%" ItemStyle-CssClass="itemNameColumn">
                                                                <ItemStyle HorizontalAlign="Center" Width="15%"/>
                                                                <HeaderStyle Font-Bold="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="EmailAddress" HeaderText="Email Address"
                                                                HeaderStyle-HorizontalAlign="Center" FilterControlWidth="70%">
                                                                <ItemStyle HorizontalAlign="Center" Width="15%"/>
                                                                <HeaderStyle Font-Bold="true" />
                                                            </telerik:GridBoundColumn>                                                            
                                                           
                                                        </Columns>
                                                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                                        
                                                    </MasterTableView>
                                                    
                                                    <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                                    <FilterMenu EnableImageSprites="False">
                                                    </FilterMenu>
                                                </telerik:RadGrid>
                                                </td>
                                            </tr>
                                         
                                                </table>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/CourseAdmin/CourseAdmin.Master" AutoEventWireup="true" CodeBehind="AppointmentDetails.aspx.cs" Inherits="SecureProctor.CourseAdmin.AppointmentDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ExamProviderContent" runat="server">
 <div class="heading customfont1"
         <asp:Label ID="lblAppHeader" runat="server" Text=""></asp:Label>
                  </div>
    <table width="100%">
        <tr>
        <td align="right">
            <asp:ImageButton ID="BtnExportToExcel" runat="server" ImageUrl="~/Images/xls.jpeg" CssClass="ImageButtons"  ToolTip="Export to XLS" Width="22" Height="22" OnClick="BtnExportToExcel_Click" />                                      
        </td></tr>
    </table>
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
                                                            <telerik:GridBoundColumn DataField="ExamDate"  HeaderText="Exam Appointment" DataFormatString="{0:MM/dd/yyyy HH:mm tt}"
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


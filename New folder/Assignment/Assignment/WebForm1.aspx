<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Assignment.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Assignment</title>
    <link rel="icon" type="text/css" href="image/assign.png" />
    <link rel="stylesheet" href="Style.css" " type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div id="div1"> 
            
            <div id="div11"> <h1>Registration Form</h1> </div>               
            
    <div id="div12">
        <table  align="center">        
            <tr>
               <td><asp:Label ID="lblEmpName" runat="server" Text="EmpName"></asp:Label></td>
                <td><asp:TextBox ID="txtEmpName" runat="server"></asp:TextBox> </td>
            </tr>
            <tr>
                <td> <asp:Label ID="lblUserName" runat="server" Text="UserName"></asp:Label></td>
                <td><asp:TextBox ID="txtUserName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblPassword" runat="server" Text="Password" ></asp:Label></td>
                <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox> </td>
            </tr>
            <tr>
                <td><asp:Label ID="ConfirmPassword" runat="server" Text="ConfirmPassword" ></asp:Label></td>
                <td><asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox> </td>
                <td><asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtConfirmPassword" ControlToCompare="txtPassword" ErrorMessage="Password and Confirm Password must be same" ForeColor="#FF3300"></asp:CompareValidator></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblGender" runat="server" Text="Gender"></asp:Label></td>
                <td><asp:RadioButton ID="rbMale" runat="server" Text="Male" GroupName="unique"/> 
                    &nbsp; 
                    <asp:RadioButton ID="rbFeMale" runat="server" Text="Female" GroupName="unique"/> 
                </td>
                
            </tr>
            <tr>
               <td><asp:Label ID="lblPhoneNumber" runat="server" Text="PhoneNumber" ></asp:Label></td>
                <td><asp:TextBox ID="txtPhoneNumber" runat="server" ></asp:TextBox> </td>
            </tr>
             <tr>
                <td><asp:Label ID="EmailId" runat="server" Text="EmailId" ></asp:Label></td>
                <td><asp:TextBox ID="txtEmailId" runat="server" ></asp:TextBox> </td>
            </tr>
            <tr>
               <td><asp:Label ID="ddlDesignation" runat="server" Text="Designation" ></asp:Label></td>
              <td> <asp:DropDownList ID="ddlDesignation1" runat="server">
                  <asp:ListItem>Select</asp:ListItem>
                  <asp:ListItem>Sr.Engineer</asp:ListItem>
                  <asp:ListItem>Jr.Engineer</asp:ListItem>
                  <asp:ListItem>Software Trainee</asp:ListItem></asp:DropDownList></td> 
                
            </tr>
            <tr>
                <td><asp:Label ID="lblempid" runat="server" Text="Empid" ></asp:Label></td>
                <td><asp:TextBox ID="txtlblempid" runat="server" ></asp:TextBox> </td>
            </tr
          
            <tr>
                <td colspan="2"> <br />   <br />  
            
                     &nbsp;  &nbsp;<asp:Button ID="btnsave" runat="server" Text="save" OnClick="btnsave_Click" CssClass="btncolor" Height="27px" Width="58px" />
                        &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btncolor" />
                      &nbsp;   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="btnDisplay" runat="server" Text="Display" OnClick="btnDisplay_Click" CssClass="btncolor" />
                </td>
            </tr>
        </table>
    
    </div> </div>

        <div>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnRowDeleting="GridView2_RowDeleting" OnRowEditing="GridView2_RowEditing" OnRowUpdating="GridView2_RowUpdating" OnRowCancelingEdit="GridView2_RowCancelingEdit">
                <Columns>
                    <asp:TemplateField HeaderText="EmpName">
                        <EditItemTemplate>
                        <asp:TextBox ID="txtemp" runat="server"  Text='<%# Eval("EmpName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblemp" runat="server" Text='<%# Eval("EmpName") %>'></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="UserName">
                        <EditItemTemplate>
                        <asp:TextBox ID="txtusername" runat="server" Text='<%# Eval("UserName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("UserName") %>'></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Gender">
                           <EditItemTemplate>
                        <asp:TextBox ID="txtgender" runat="server" Text='<%# Eval("Gender") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("Gender") %>'></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PhoneNumber">
                        <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("PhoneNumber") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("PhoneNumber") %>'></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Emailid">
                            <EditItemTemplate>
                        <asp:TextBox ID="txtemailid" runat="server" Text='<%# Eval("Emailid") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("Emailid") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                   
                    <asp:TemplateField HeaderText="Desigantion">
                        <EditItemTemplate>
                        <asp:TextBox ID="txtdesignation" runat="server" Text='<%# Eval("Designation") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("Designation") %>'></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Empid">
                        <EditItemTemplate>
                        <asp:TextBox ID="txtempid" runat="server" style="margin-bottom: 0px" ReadOnly="true"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblempid" runat="server" Text='<%# Eval("Empid") %>'></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField HeaderText="Operations" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" />
                </Columns>
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                <RowStyle BackColor="White" ForeColor="#003399" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                <SortedDescendingHeaderStyle BackColor="#002876" />
            </asp:GridView>
        </div>

        
    </form>
</body>
</html>

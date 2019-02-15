<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterForCourses.aspx.cs" Inherits="StudentWebApp.RegisterForCourses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 80%;
        }
        .auto-style2 {
            width: 30%;
            height: 50px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2" style="text-align:right">
                        <asp:Label ID="Label1" runat="server" Text="Semester"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="ddSemester" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddSemester_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" style="text-align:right">
                        <asp:Label ID="Label2" runat="server" Text="Course Number"></asp:Label>
                    </td>
                    <td class="auto-style2" >
                        <asp:DropDownList ID="ddCourse" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" style="text-align:right">
                        <asp:Label ID="Label3" runat="server" Text="Student ID"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtStudentID" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblStatus" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

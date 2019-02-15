<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StartMenu.aspx.cs" Inherits="StudentWebApp.StartMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 50%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td>
                        <asp:Button ID="btnCourses" runat="server" OnClick="btnCourses_Click" Text="Show Courses Offered" Width="215px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnEnrollment" runat="server" OnClick="btnEnrollment_Click" Text="Show Course Enrollment" Width="215px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnRegistration" runat="server" OnClick="btnRegistration_Click" Text="Course Registration" Width="215px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnInstructors" runat="server" OnClick="btnInstructors_Click" Text="Show Instructors" Width="214px" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

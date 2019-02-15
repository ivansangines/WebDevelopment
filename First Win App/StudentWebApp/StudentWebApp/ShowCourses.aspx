<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowCourses.aspx.cs" Inherits="StudentWebApp.CourseEnrollment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
      
        .auto-style2 {
            width:10%;
            vertical-align:top;
        }
        .auto-style3 {
            width:80%;
            
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2" >Semester</td>
                    <td class="auto-style2" >Courses Offered</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:DropDownList ID="DropDownSemesters" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownSemesters_SelectedIndexChanged" >
                        </asp:DropDownList>
                    </td>
                    <td  class="auto-style3" rowspan="2">
                        <asp:GridView ID="dgCourses" runat="server">
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblStatus" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseEnrollment.aspx.cs" Inherits="StudentWebApp.CourseEnrollment1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            
        }
        .auto-style2 {
            text-align:center;
            width: 20%;
            
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label1" runat="server" Text="Semester"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2" style="height:75px; vertical-align:top">
                        <asp:DropDownList ID="semesterOptions" runat="server" AutoPostBack="true" OnSelectedIndexChanged="semesterOptions_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td rowspan="2">
                        <asp:GridView ID="gv1" runat="server">
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label2" runat="server" Text="Course Selected"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:DropDownList ID="coursesList" AutoPostBack="true" runat="server" OnSelectedIndexChanged="coursesList_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="lblStatus" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

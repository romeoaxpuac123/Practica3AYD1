<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Practica3.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>REGISTRO TU BANCO S.A.</title>
</head>
    <style type="text/css">
body {
 background-image: url(banco1.jpg);
	  background-position: center center;	  
	  background-repeat: no-repeat;
	background-attachment: fixed;
	background-size: cover;
}

#mail {
	width: 100%;
	position: fixed;
}
</style>
        <center><img src="texto1.png"></center>
    <form id="form1" runat="server">
        <div>
            <center>
             <table>
        <tr>
            <td>
               Nombre Completo
            </td>
            <td>
                <asp:TextBox ID="txtName" 
                runat="server" 
                required="true"></asp:TextBox>
            </td>
        </tr> <tr>
            <td>
                Usuario
            </td>
            <td>
                <asp:TextBox ID="txtUs" 
                runat="server" 
                required="true"></asp:TextBox>
            </td>
        </tr>
                 
                 
                 <tr>
            <td>
               Email 
            </td>
            <td>
                <asp:TextBox ID="txtEmail" 
                runat="server" required="true" 
                type="Email"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
               Password 
            </td>
            <td>
             <asp:TextBox ID="txtPassword" 
             runat="server" required="true" 
             type="Password"></asp:TextBox>
            </td>
        </tr> 
        
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnSubmit" 
                runat="server" Text="Registrar" OnClick="btnSubmit_Click" />
            </td>
        </tr>
</table>
            </center>
        </div>
    </form>
    <center>
        <br />
        <br />
        <br />
        <img src="registro1.gif"></center>
</body>
</html>

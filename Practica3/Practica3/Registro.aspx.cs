using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace Practica3
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            char[] Validos = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K'
            ,'L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z' };

            char[] Validos2 = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k'
            ,'l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};

            char[] Validos3 = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            int v1 = 0;
            int v2 = 0;

            int v3 = 0;
            int v4 = 0;

            string name = txtName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string usuario = txtUs.Text;

            Boolean datos = false;

            ///Verificando Contraseña Valida
            if (password.Length != 8)
            {
                //Response.Write("<script>window.alert('Contraseña no cumple con el largo de 8');</script>");
                MessageBox.Show("La Contraseña No cumple con el largo solicitado de 8");
                //txtName.Text = "";
                //txtEmail.Text = "";
                txtPassword.Text = "";
                //txtUs.Text = "";
            }
            else
            {
                ///Aca se muestra si la contraseña es de 8 caracteres y se verifica si es alfa numerica
                v1 = 0;
                v2 = 0;

                for (int i = 0; i < Validos.Length; i++)
                {
                    if (password.Contains(Validos[i]))
                    {
                        v1 = v1 + 1;
                    }

                }

                for (int i = 0; i < Validos2.Length; i++)
                {
                    if (password.Contains(Validos2[i]))
                    {
                        v1 = v1 + 1;
                    }

                }

                for (int i = 0; i < Validos3.Length; i++)
                {
                    if (password.Contains(Validos3[i]))
                    {
                        v2 = v2 + 1;
                    }                                                       

                }

                if (v1 > 0 && v2 > 0)
                {
                    //La contraseña si es alfanumerica y se revisa si el nombre es alfanumerico
                    if (usuario.Length > 12) {
                        MessageBox.Show("El tamanaño de Usario sobrepasa los 12 Caracteres permitidos");
                        //txtName.Text = "";
                        //txtEmail.Text = "";
                        //txtPassword.Text = "";
                        txtUs.Text = "";
                    }
                    else
                    {
                        //Analizamos si el nombre es alfanumerico

                        v3 = 0;
                        v4 = 0;

                        for (int i = 0; i < Validos.Length; i++)
                        {
                            if (usuario.Contains(Validos[i]))
                            {
                                v3 = v3 + 1;
                            }

                        }

                        for (int i = 0; i < Validos2.Length; i++)
                        {
                            if (usuario.Contains(Validos2[i]))
                            {
                                v3 = v3 + 1;
                            }

                        }

                        for (int i = 0; i < Validos3.Length; i++)
                        {
                            if (usuario.Contains(Validos3[i]))
                            {
                                v4 = v4 + 1;
                            }

                        }

                        if (v3 > 0 && v4 > 0)
                        {
                            datos = true;

                        }
                        else {
                            MessageBox.Show("El nombre de usuario no es alfanumerica");
                            //txtName.Text = "";
                            //txtEmail.Text = "";
                            //txtPassword.Text = "";
                            txtUs.Text = "";

                        }

                    }

                }
                else {
                    //La contraseña No es alfanumerica y se revisa si el nombre es alfanumerico
                    MessageBox.Show("La Contraseña no es alfanumerica");
                    //txtName.Text = "";
                    //txtEmail.Text = "";
                    txtPassword.Text = "";
                    //txtUs.Text = "";

                }
                


            }


            ///enviando datos a la base de datos
            ///
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
            con.Open();
            SqlCommand com = new SqlCommand(); // Create a object of SqlCommand class
            com.Connection = con; //Pass the connection object to Command
            com.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            com.CommandText = "VerificarUsuario"; //Stored Procedure Name
            com.Parameters.Add("@usuarioR", SqlDbType.NVarChar).Value = txtUs.Text;
            com.ExecuteNonQuery();
            String nombre = "vacio";
            SqlDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    nombre =  reader.GetString(2);
                    break;
                }
            }

            //MessageBox.Show("El Usuario" + nombre);


            if (datos == true)
            {
                if (nombre == "vacio")
                {

                    SqlConnection con2 = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
                    con2.Open();

                    SqlCommand com2 = new SqlCommand(); // Create a object of SqlCommand class
                    com2.Connection = con2; //Pass the connection object to Command
                    com2.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
                    com2.CommandText = "spInsertUser"; //Stored Procedure Name

                    com2.Parameters.Add("@nombre_usuario", SqlDbType.NVarChar).Value = name;
                    com2.Parameters.Add("@correoelectronico", SqlDbType.NVarChar).Value = email;
                    com2.Parameters.Add("@passwordU", SqlDbType.NVarChar).Value = password;
                    com2.Parameters.Add("@usuario", SqlDbType.NVarChar).Value = txtUs.Text;
                    com2.Parameters.Add("@codigo_usuario", SqlDbType.NVarChar).Value = txtUs.Text;
                    com2.ExecuteNonQuery();
                    MessageBox.Show("El Usuario " + txtUs.Text + " Ha sido Registrado con exito");
                    con2.Close();
                 }
                else
                {
                    MessageBox.Show("El Usuario " + nombre + " Ha sido Registrado con Anterioridad");
                    
                    //txtName.Text = "";
                    //txtEmail.Text = "";
                    //txtPassword.Text = "";
                    txtUs.Text = "";
                }

            }

            if (datos == true)
            {
                if (nombre == "vacio")
                {

                    SqlConnection conx = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
                    conx.Open();
                    SqlCommand comx = new SqlCommand(); // Create a object of SqlCommand class
                    comx.Connection = conx; //Pass the connection object to Command
                    comx.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
                    comx.CommandText = "VerificarCodigoUs"; //Stored Procedure Name
                    comx.Parameters.Add("@usuarioR", SqlDbType.NVarChar).Value = txtUs.Text;
                    comx.ExecuteNonQuery();
                    int nombrex = 0;
                    SqlDataReader readerx = comx.ExecuteReader();
                    if (readerx.HasRows)
                    {
                        while (readerx.Read())
                        {
                            nombrex = readerx.GetInt32(0);
                            break;
                        }
                    }
                    MessageBox.Show("Su Codigo de Usuario Es " + nombrex + " Gracias.");

                }
            }
        

        }



    }
}

/*
 
     try
                    {
                        SqlConnection con2 = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
                        con.Open();

                        SqlCommand com2 = new SqlCommand(); // Create a object of SqlCommand class
                        com2.Connection = con2; //Pass the connection object to Command
                        com2.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
                        com2.CommandText = "spInsertUser"; //Stored Procedure Name

                        com2.Parameters.Add("@nombre_usuario", SqlDbType.NVarChar).Value = name;
                        com2.Parameters.Add("@correoelectronico", SqlDbType.NVarChar).Value = email;
                        com2.Parameters.Add("@passwordU", SqlDbType.NVarChar).Value = password;
                        com2.Parameters.Add("@usuario", SqlDbType.NVarChar).Value = txtUs.Text;
                        com2.Parameters.Add("@codigo_usuario", SqlDbType.NVarChar).Value = txtUs.Text;
                        com2.ExecuteNonQuery();
                        MessageBox.Show("El Usuario" + txtUs.Text + "Ha sido Registrado con exito");


                    }
                    catch (Exception ex)
                    {

                    }
     
     */

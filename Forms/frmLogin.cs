
using MySql.Data.MySqlClient;
using puntoVenta;
using System;
using System.Windows.Forms;

namespace Punto.Forms
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //primero se revisa que en usuario y contraseña no este vacio, y si lo esta entonces le muestra este mensaje 
            if (string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Por favor, ingrese su usuario y contraseña", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //usar variables limpias en ves de controles
            string usuario = txtUser.Text.Trim();
            string contrasena = txtPassword.Text.Trim();

            //se conecta a la base de datos
            Conexion acceso = new Conexion();
            MySqlConnection conexionData = acceso.getConection();

            //se verifica que la conexion se realice correctamente 
            if (conexionData == null)
            {
                MessageBox.Show("No se pudo conectar a la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                //se crean las consultas parametrizadas
                string consulta = "SELECT password, nombre_completo FROM usuarios WHERE BINARY username= @usuario";

                // ejecutar la consulta
                MySqlCommand comando = new MySqlCommand(consulta, conexionData);
                comando.Parameters.AddWithValue("@usuario", usuario);
                MySqlDataReader reader = comando.ExecuteReader();

                // verificar que la consulta trajo resultados
                if (reader.Read())
                {
                    string passwordBD = reader["password"].ToString();
                    string nombrePersona = reader["nombre_completo"].ToString();

                    // si la contraseña que ingresaron coincide con la de la base de datos
                    if (contrasena == passwordBD)
                    {
                        // Cerrar los lectores y conexiones 
                        reader.Close();
                        conexionData.Close();

                        MessageBox.Show("¡Bienvenido al sistema!\nAcceso concedido a: " + nombrePersona, "Acceso Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        frmProductos pantallaProductos = new frmProductos();
                        pantallaProductos.Show();
                        this.Hide();
                    }
                    else
                    {
                        // pero si la contraseña no coincide entonces
                        reader.Close();
                        conexionData.Close();
                        MessageBox.Show("Usuario o contraseña incorrectos intente de nuevo", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPassword.Clear();
                        txtPassword.Focus();
                    }
                }
                else
                {
                    // Si el usuario no siquiera existe
                    reader.Close();
                    conexionData.Close();
                    MessageBox.Show("Usuario o contraseña incorrectos. Intente de nuevo.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                //si el servidor cae
                MessageBox.Show("Error crítico de comunicación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        
    }
}




            

        



    

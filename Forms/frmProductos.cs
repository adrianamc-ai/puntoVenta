using MySql.Data.MySqlClient;
using puntoVenta;
using System;
using System.Data;
using System.Windows.Forms;

namespace Punto.Forms
{
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();
        }

         //al cargar el formulario llena el DataGridView 
        private void frmProductos_Load_1(object sender, EventArgs e)
        {
            CargarGridProductos();
            // la etiqueta no muestra nada al arrancar
            lblId.Text = "";
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            string valorBusqueda = txtBusqueda.Text.Trim();

            try
            {
                Conexion acceso = new Conexion();
                MySqlConnection conexionData = acceso.getConection();

                // Buscador sincronizado apuntando a 'codigo' o 'descripcion'
                string consulta = "SELECT producto_id AS ID, codigo AS Código, descripcion AS Descripción, precio AS Precio, stock AS Stock, categoria AS Categoría " + "FROM productos " + "WHERE codigo LIKE @busqueda OR descripcion LIKE @busqueda";

                MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexionData);
                adaptador.SelectCommand.Parameters.AddWithValue("@busqueda", "%" + valorBusqueda + "%");

                DataTable tablaVirtual = new DataTable();
                adaptador.Fill(tablaVirtual);

                dgvProductos.DataSource = tablaVirtual;

                conexionData.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar la búsqueda: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Conecta a la base de datos y muestra la tabla
        private void CargarGridProductos()
        {
            try
            {
                // Conectar con la base de datos
                Conexion acceso = new Conexion();
                MySqlConnection conexionData = acceso.getConection();

                // Se consulta
                string consulta = "SELECT producto_id AS ID, codigo AS Código, descripcion AS Descripción, precio AS Precio, stock AS Stock, categoria AS Categoría FROM productos";

                MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexionData);
                DataTable tablaVirtual = new DataTable();

                adaptador.Fill(tablaVirtual);
                dgvProductos.DataSource = tablaVirtual;

                conexionData.Close();
            }


            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
         //Al dar clic en el Grid los datos se pasan a los controles de texto
        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];

                // en lblId se guarda el ID seleccionado
                lblId.Text = fila.Cells["ID"].Value.ToString();
                txtCodigo.Text = fila.Cells["Código"].Value.ToString();
                txtNombre.Text = fila.Cells["Descripción"].Value.ToString(); 
                txtPrecio.Text = fila.Cells["Precio"].Value.ToString();
                txtStock.Text = fila.Cells["Stock"].Value.ToString();
                cmbCategorias.Text = fila.Cells["Categoría"].Value.ToString();
            }
        }

        
        //El botón Guardar valida e inserta los parametros
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            // Asignar textos a las variables
            string codigo = txtCodigo.Text.Trim();
            string descripcion = txtNombre.Text.Trim();
            string categoria = cmbCategorias.Text;

            // Validar que los campos no estén vacíos
            if (string.IsNullOrEmpty(codigo) || string.IsNullOrEmpty(descripcion) || string.IsNullOrEmpty(categoria))
            {
                MessageBox.Show("Llene todos los campos antes de guardar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validacion numerica
            decimal precioValidado;
            if (!decimal.TryParse(txtPrecio.Text, out precioValidado) || precioValidado < 0)
            {
                MessageBox.Show("Ingrese un precio numérico válido", "Error de Tipo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int stockValidado;
            if (!int.TryParse(txtStock.Text, out stockValidado) || stockValidado < 0)
            {
                MessageBox.Show("Ingrese un stock entero válido", "Error de Tipo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Conexion acceso = new Conexion();
                MySqlConnection conexionData = acceso.getConection();

                string consulta = "INSERT INTO productos (codigo, descripcion, precio, stock, categoria) VALUES (@codigo, @descripcion, @precio, @stock, @categoria)";

                MySqlCommand comando = new MySqlCommand(consulta, conexionData);
                comando.Parameters.AddWithValue("@codigo", codigo);
                comando.Parameters.AddWithValue("@descripcion", descripcion);
                comando.Parameters.AddWithValue("@precio", precioValidado);
                comando.Parameters.AddWithValue("@stock", stockValidado);
                comando.Parameters.AddWithValue("@categoria", categoria);

                int filasAfectadas = comando.ExecuteNonQuery();
                conexionData.Close();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("¡Producto registrado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGridProductos();
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error crítico al insertar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
         //Modifica el registro usando WHERE con el id en lblId.
        
        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Validamos que exista un ID seleccionado en lblId
            if (string.IsNullOrEmpty(lblId.Text))
            {
                MessageBox.Show("Seleccione primero un producto de la tabla para editar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string codigo = txtCodigo.Text.Trim();
            string descripcion = txtNombre.Text.Trim();
            string categoria = cmbCategorias.Text;

            if (string.IsNullOrEmpty(codigo) || string.IsNullOrEmpty(descripcion) || string.IsNullOrEmpty(categoria))
            {
                MessageBox.Show("Llene todos los campos antes de actualizar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal precioValidado;
            if (!decimal.TryParse(txtPrecio.Text, out precioValidado) || precioValidado < 0)
            {
                MessageBox.Show("Ingrese un precio numérico válido", "Error de Tipo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int stockValidado;
            if (!int.TryParse(txtStock.Text, out stockValidado) || stockValidado < 0)
            {
                MessageBox.Show("Ingrese un stock entero válido", "Error de Tipo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Conexion acceso = new Conexion();
                MySqlConnection conexionData = acceso.getConection();

                // Modificarla columna descripcion usando el lblId en el WHERE
                string consulta = "UPDATE productos SET codigo = @codigo, descripcion = @descripcion, precio = @precio, stock = @stock, categoria = @categoria WHERE producto_id = @id";

                MySqlCommand comando = new MySqlCommand(consulta, conexionData);
                comando.Parameters.AddWithValue("@codigo", codigo);
                comando.Parameters.AddWithValue("@descripcion", descripcion);
                comando.Parameters.AddWithValue("@precio", precioValidado);
                comando.Parameters.AddWithValue("@stock", stockValidado);
                comando.Parameters.AddWithValue("@categoria", categoria);
                comando.Parameters.AddWithValue("@id", lblId.Text);

                int filasAfectadas = comando.ExecuteNonQuery();
                conexionData.Close();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("¡Producto actualizado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGridProductos();
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error crítico al actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblId.Text))
            {
                MessageBox.Show("Seleccione primero el producto que desea eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultadoConfirmacion = MessageBox.Show("¿Está completamente seguro de que desea eliminar permanentemente este producto?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultadoConfirmacion == DialogResult.Yes)
            {
                try
                {
                    Conexion acceso = new Conexion();
                    MySqlConnection conexionData = acceso.getConection();

                    string consulta = "DELETE FROM productos WHERE producto_id = @id";

                    MySqlCommand comando = new MySqlCommand(consulta, conexionData);
                    comando.Parameters.AddWithValue("@id", lblId.Text);

                    int filasAfectadas = comando.ExecuteNonQuery();
                    conexionData.Close();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("El producto ha sido eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarGridProductos();
                        LimpiarCampos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error crítico al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LimpiarCampos()
        {
            lblId.Text = "";
            txtCodigo.Clear();
            txtNombre.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            cmbCategorias.SelectedIndex = -1;
            txtCodigo.Focus();
        }  
    }
}
namespace Punto.Forms
{
    partial class frmProductos
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.ComboBox cmbCategorias;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox gbBusqueda;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.GroupBox gbBotones;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.lblId = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.cmbCategorias = new System.Windows.Forms.ComboBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gbBusqueda = new System.Windows.Forms.GroupBox();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.gbBotones = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.gbBusqueda.SuspendLayout();
            this.gbDatos.SuspendLayout();
            this.gbBotones.SuspendLayout();
            this.SuspendLayout();

            this.gbBusqueda.Text = "Buscar producto";
            this.gbBusqueda.Location = new System.Drawing.Point(12, 12);
            this.gbBusqueda.Size = new System.Drawing.Size(860, 60);

            this.txtBusqueda.Location = new System.Drawing.Point(15, 25);
            this.txtBusqueda.Size = new System.Drawing.Size(400, 22);
            this.gbBusqueda.Controls.Add(this.txtBusqueda);

            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductos.Location = new System.Drawing.Point(12, 80);
            this.dgvProductos.Size = new System.Drawing.Size(860, 220);
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.RowHeadersVisible = false;

            this.gbDatos.Text = "Datos del producto";
            this.gbDatos.Location = new System.Drawing.Point(12, 310);
            this.gbDatos.Size = new System.Drawing.Size(860, 140);

            this.lblId.Text = "0";
            this.lblId.Visible = false;
            this.lblId.Location = new System.Drawing.Point(15, 20);

            this.label1.Text = "Código:";
            this.label1.Location = new System.Drawing.Point(15, 25);
            this.label1.Size = new System.Drawing.Size(80, 20);

            this.txtCodigo.Location = new System.Drawing.Point(15, 48);
            this.txtCodigo.Size = new System.Drawing.Size(130, 22);

            this.label2.Text = "Nombre:";
            this.label2.Location = new System.Drawing.Point(160, 25);
            this.label2.Size = new System.Drawing.Size(80, 20);

            this.txtNombre.Location = new System.Drawing.Point(160, 48);
            this.txtNombre.Size = new System.Drawing.Size(230, 22);

            this.label3.Text = "Precio:";
            this.label3.Location = new System.Drawing.Point(405, 25);
            this.label3.Size = new System.Drawing.Size(80, 20);

            this.txtPrecio.Location = new System.Drawing.Point(405, 48);
            this.txtPrecio.Size = new System.Drawing.Size(100, 22);

            this.label4.Text = "Stock:";
            this.label4.Location = new System.Drawing.Point(520, 25);
            this.label4.Size = new System.Drawing.Size(80, 20);

            this.txtStock.Location = new System.Drawing.Point(520, 48);
            this.txtStock.Size = new System.Drawing.Size(80, 22);

            this.label5.Text = "Categoría:";
            this.label5.Location = new System.Drawing.Point(615, 25);
            this.label5.Size = new System.Drawing.Size(80, 20);

            this.cmbCategorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategorias.Location = new System.Drawing.Point(615, 48);
            this.cmbCategorias.Size = new System.Drawing.Size(150, 22);

            this.gbDatos.Controls.Add(this.lblId);
            this.gbDatos.Controls.Add(this.label1);
            this.gbDatos.Controls.Add(this.txtCodigo);
            this.gbDatos.Controls.Add(this.label2);
            this.gbDatos.Controls.Add(this.txtNombre);
            this.gbDatos.Controls.Add(this.label3);
            this.gbDatos.Controls.Add(this.txtPrecio);
            this.gbDatos.Controls.Add(this.label4);
            this.gbDatos.Controls.Add(this.txtStock);
            this.gbDatos.Controls.Add(this.label5);
            this.gbDatos.Controls.Add(this.cmbCategorias);

            this.gbBotones.Text = "Acciones";
            this.gbBotones.Location = new System.Drawing.Point(12, 460);
            this.gbBotones.Size = new System.Drawing.Size(860, 65);

            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.Location = new System.Drawing.Point(15, 25);
            this.btnNuevo.Size = new System.Drawing.Size(100, 30);
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(79, 70, 229);
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;

            this.btnEditar.Text = "Editar";
            this.btnEditar.Location = new System.Drawing.Point(130, 25);
            this.btnEditar.Size = new System.Drawing.Size(100, 30);
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(245, 158, 11);
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;

            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Location = new System.Drawing.Point(245, 25);
            this.btnEliminar.Size = new System.Drawing.Size(100, 30);
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;

            this.gbBotones.Controls.Add(this.btnNuevo);
            this.gbBotones.Controls.Add(this.btnEditar);
            this.gbBotones.Controls.Add(this.btnEliminar);

            this.ClientSize = new System.Drawing.Size(884, 540);
            this.Controls.Add(this.gbBusqueda);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.gbBotones);
            this.Text = "Gestión de Productos";

            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.gbBusqueda.ResumeLayout(false);
            this.gbBusqueda.PerformLayout();
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            this.gbBotones.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}

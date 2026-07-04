using System;
using System.Windows.Forms;

namespace Punto.Forms
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void AbrirFormulario(Type tipoFormulario)
        {
            foreach (Form hijo in this.MdiChildren)
            {
                if (hijo.GetType() == tipoFormulario)
                {
                    hijo.BringToFront();
                    return;
                }
            }

            Form form = (Form)Activator.CreateInstance(tipoFormulario);
            form.MdiParent = this;
            form.Show();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(typeof(frmProductos));
        }
    }
}

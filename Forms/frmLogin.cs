using System.Windows.Forms;

namespace Punto.Forms
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, System.EventArgs e)
        {
            frmPrincipal principal= new frmPrincipal();
            this.Hide();
            principal.Show();
        }
    }
}

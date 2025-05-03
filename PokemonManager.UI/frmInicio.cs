using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokemonManager.UI
{
    public partial class frmInicio : Form
    {
        private Form formActivo;

        public frmInicio()
        {
            InitializeComponent();
        }

        private void frmInicio_Load(object sender, EventArgs e)
        {
            AbrirFormulario(new frmListarPokemons());
        }

        private void AbrirFormulario(Form formHijo)
        {
            if(formActivo != null)
            {
                formActivo.Close();
            }
            formActivo = formHijo;
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(formHijo);
            panelChildForm.Tag = formHijo;
            formHijo.BringToFront();
            formHijo.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmAltaPokemon());
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmListarPokemons());
        }

    }
}

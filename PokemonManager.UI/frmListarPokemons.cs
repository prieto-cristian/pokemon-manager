using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PokemonManager.dominio;
using PokemonManager.negocio;

namespace PokemonManager.UI
{
    public partial class frmListarPokemons : Form
    {
        public frmListarPokemons()
        {
            InitializeComponent();
        }

        private void frmListarPokemons_Load(object sender, EventArgs e)
        {
            ListarPokemon();
        }

        private void ListarPokemon() {
            PokemonNegocio negocio = new PokemonNegocio();
            List<Pokemon> listaPokemons = negocio.ListarPokemons();
            dgvPokemons.DataSource = listaPokemons;
            dgvPokemons.Columns["UrlImagen"].Visible = false;
        }
    }
}

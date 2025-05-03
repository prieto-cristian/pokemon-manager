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
            CargarImagen(listaPokemons[0].UrlImagen);
        }

        private void CargarImagen(string url)
        {
            try
            {
                pbxPokemon.Load(url);
            }
            catch(Exception ex)
            {
                pbxPokemon.Load("https://img.freepik.com/vector-premium/vector-icono-imagen-predeterminado-pagina-imagen-faltante-diseno-sitio-web-o-aplicacion-movil-no-hay-foto-disponible_87543-11093.jpg");
            }
        }

        private void dgvPokemons_SelectionChanged(object sender, EventArgs e)
        {
            Pokemon pokemonSeleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;
            CargarImagen(pokemonSeleccionado.UrlImagen);
        }
    }
}

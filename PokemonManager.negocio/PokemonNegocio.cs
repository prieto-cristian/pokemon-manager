using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonManager.dominio;

namespace PokemonManager.negocio
{
    public class PokemonNegocio
    {
        public List<Pokemon> ListarPokemons()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Pokemon> listaPokemons = new List<Pokemon>();
            string consultaSql = "SELECT P.Id, P.Nombre, P.Numero, P.Activo, P.Descripcion, P.UrlImagen, T.Id IdTipo, T.Descripcion Tipo, D.Id IdDebilidad, D.Descripcion Debilidad FROM POKEMONS P, ELEMENTOS T, ELEMENTOS D WHERE P.IdTipo = T.Id AND P.IdDebilidad = D.Id";

            try
            {
                datos.SetearConsulta(consultaSql);
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Numero = (int)datos.Lector["Numero"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.EstaActivo = (bool)datos.Lector["Activo"];
                    aux.UrlImagen = (string)datos.Lector["UrlImagen"];
                    aux.Id = (int)datos.Lector["Id"];

                    Elemento tipo = new Elemento();
                    tipo.Id = (int)datos.Lector["IdTipo"];
                    tipo.Descripcion = (string)datos.Lector["Tipo"];

                    Elemento debilidad = new Elemento();
                    debilidad.Descripcion = (string)datos.Lector["Debilidad"];
                    debilidad.Id = (int)datos.Lector["IdDebilidad"];

                    aux.Tipo = tipo;
                    aux.Debilidad = debilidad;

                    listaPokemons.Add(aux);
                }
                return listaPokemons;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}

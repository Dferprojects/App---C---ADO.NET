using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Poke_ADONET
{
    public class PokemonDB
    {
        public List<Pokemon> listar()
        {
            List<Pokemon> lista = new List<Pokemon>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server = WIN-BLKA3L6BAAL;database = POKEDEX_DB;integrated security = true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT p.Numero, p.Nombre, p.Descripcion, p.UrlImagen, e.Descripcion AS Tipo, d.Descripcion AS Debilidad FROM POKEMONS p INNER JOIN ELEMENTOS e ON p.IdTipo=e.Id INNER JOIN ELEMENTOS d ON d.Id=p.IdDebilidad";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while(lector.Read()) { 
                    Pokemon aux = new Pokemon();
                    aux.Numero = lector.GetInt32(0);
                    aux.Nombre = (string)lector["Nombre"]; 
                    aux.Descripcion = (string)lector["Descripcion"];
                    aux.urlImagen = (string)lector["urlImagen"];
                    aux.Tipo = new Elemento();
                    aux.Tipo.Descripcion = (string)lector["Tipo"];
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Descripcion = (string)lector["Debilidad"];

                    lista.Add(aux);
                }
                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

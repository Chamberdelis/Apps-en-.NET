using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AppyConexionaBD
{
    internal class DiscosConexion
    {
        public List<Disco> Listadiscos()
        {
            List<Disco> lista = new List<Disco>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=DISCOS_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select d.Titulo as Titulo, d.FechaLanzamiento as Fecha,d.CantidadCanciones as Canciones, d.UrlImagenTapa as Tapa , e.Descripcion as Estilo, t.Descripcion as Edicion from DISCOS d, ESTILOS e, TIPOSEDICION t where d.IdEstilo = e.Id and d.IdTipoEdicion = t.Id";
                comando.Connection = conexion;

                conexion.Open();

                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Disco aux = new Disco();

                    aux.Titulo = (string)lector["Titulo"];
                    aux.Fecha = (DateTime)lector["Fecha"];
                    aux.Canciones = (int)lector["Canciones"];
                    aux.Imagen = (string)lector["Tapa"];
                    aux.Estilo = new Estilos();
                    aux.Estilo.Descripcion = (string)lector["Estilo"];
                    aux.Edicion = new Ediciones();
                    aux.Edicion.Descripcion = (string)lector["Edicion"];

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

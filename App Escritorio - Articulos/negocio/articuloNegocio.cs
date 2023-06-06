using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace negocio
{
    public class articuloNegocio
    {
        public List<Articulo> listaArticulo()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("Select a.Id, a.Codigo, a.Nombre, a.Descripcion,m.Descripcion as Marca,c.Descripcion as Categoria, a.ImagenUrl as Imagen, a.IdMarca, a.IdCategoria, a.Precio FROM ARTICULOS a, CATEGORIAS c, MARCAS m where a.IdMarca = m.Id and a.IdCategoria = c.Id\r\n");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];

                    if (!(datos.Lector["Descripcion"] is DBNull))
                    {
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                    }

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    if (!(datos.Lector["Imagen"] is DBNull))
                    {
                        aux.Imagen = (string)datos.Lector["Imagen"];
                    }
                    if (!(datos.Lector["Precio"] is DBNull))
                    {
                        aux.Precio = (decimal)datos.Lector["Precio"];
                    }

                    lista.Add(aux);


                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void agregar (Articulo nuevo)
        {
            AccesoDatos datos= new AccesoDatos();
            try
            {
                datos.SetearConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion,IdMarca,IdCategoria,ImagenUrl, Precio) values (@Codigo,@Nombre,@Descripcion,@IdMarca,@IdCategoria,@Imagen,@Precio)");
                datos.setearParametros("@Codigo" , nuevo.Codigo);
                datos.setearParametros("@Nombre" , nuevo.Nombre);
                datos.setearParametros("@Descripcion" , nuevo.Descripcion);
                datos.setearParametros("@IdMarca" , nuevo.Marca.Id);
                datos.setearParametros("@IdCategoria" , nuevo.Categoria.Id);
                datos.setearParametros("@Imagen" , nuevo.Imagen);
                datos.setearParametros("@Precio" , nuevo.Precio);
                datos.EjecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void modificar (Articulo modificar)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("update ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, ImagenUrl = @Imagen, Precio = @Precio where Id = @Id ");
                datos.setearParametros("@Codigo", modificar.Codigo);
                datos.setearParametros("@Nombre", modificar.Nombre);
                datos.setearParametros("@Descripcion", modificar.Descripcion);
                datos.setearParametros("@IdMarca", modificar.Marca.Id);
                datos.setearParametros("@IdCategoria", modificar.Categoria.Id);
                datos.setearParametros("@Imagen", modificar.Imagen);
                datos.setearParametros("@Precio", modificar.Precio);
                datos.setearParametros("@Id", modificar.Id);

                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void eliminar (int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("delete from ARTICULOS where Id = @Id");
                datos.setearParametros("Id", id);

                datos.EjecutarAccion();

                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public List<Articulo> filtroAvanzado (string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = ("Select a.Id, a.Codigo, a.Nombre, a.Descripcion,m.Descripcion as Marca,c.Descripcion as Categoria, a.ImagenUrl as Imagen, a.IdMarca, a.IdCategoria, a.Precio FROM ARTICULOS a, CATEGORIAS c, MARCAS m where a.IdMarca = m.Id and a.IdCategoria = c.Id AND ");

                if (campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "a.Precio >" + filtro;
                            break;
                        case "Menor a":
                            consulta += "a.Precio <" + filtro;
                            break;
                        default:
                            consulta += "a.Precio =" + filtro;
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "a.Nombre like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "a.Nombre like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "a.Nombre like '%" + filtro + "%'";
                            break;
                    }
                }

                datos.SetearConsulta(consulta);
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];

                    if (!(datos.Lector["Descripcion"] is DBNull))
                    {
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                    }

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    if (!(datos.Lector["Imagen"] is DBNull))
                    {
                        aux.Imagen = (string)datos.Lector["Imagen"];
                    }
                    if (!(datos.Lector["Precio"] is DBNull))
                    {
                        aux.Precio = (decimal)datos.Lector["Precio"];
                    }

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        

        



    }
}

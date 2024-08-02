using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Producto
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result(); 
            try
            {
                using (DL.AOrtegaProgramacionNCapasContext context = new DL.AOrtegaProgramacionNCapasContext())
                {
                    var query = context.Productos.FromSqlRaw($"ProductoGetAll").ToList();
                    if (query != null )
                    {
                        result.Objects = new List<object>();
                        foreach (var fila in query)
                        {
                            ML.Producto producto = new ML.Producto();
                            producto.IdProducto = fila.IdProducto;
                            producto.Nombre = fila.Nombre;
                            producto.Descripcion = fila.Descripcion;
                            producto.Precio = fila.Precio.Value;
                            producto.Imagen = fila.Imagen;
                            producto.SubCategoria = new ML.SubCategoria();
                            producto.SubCategoria.IdSubCategoria = fila.IdSubCategoria.Value;
                           
                            producto.SubCategoria.Nombre = fila.Nombre;
                            producto.SubCategoria.Categoria = new ML.Categoria();
                            
                            producto.SubCategoria.Categoria.IdCategoria = fila.IdCategoria.Value;

                            result.Objects.Add(producto);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false; 
                    }
                }

            }catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }



        public static ML.Result GetById(int IdProducto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AOrtegaProgramacionNCapasContext context = new DL.AOrtegaProgramacionNCapasContext())
                {
                    var query = context.Productos.FromSqlRaw($"ProductoGetById '{IdProducto}'").AsEnumerable().FirstOrDefault();
                    if (query != null)
                    {
                        ML.Producto producto = new ML.Producto();
                        producto.IdProducto = query.IdProducto;
                        producto.Nombre = query.Nombre;
                        producto.Descripcion = query.Descripcion;
                        producto.Precio = query.Precio.Value;
                        producto.Imagen = query.Imagen;
                        //producto.SubCategoria = new ML.SubCategoria();
                        //producto.SubCategoria.IdSubCategoria = query.IdSubCategoria.Value;
                        //producto.SubCategoria.Categoria = new ML.Categoria();
                        //producto.SubCategoria.Categoria.IdCategoria = query.IdSubCategoriaNavigation.IdCategoria.Value;
                        ////producto.SubCategoria.Categoria = categoria;
                        producto.SubCategoria = new ML.SubCategoria();
                        producto.SubCategoria.IdSubCategoria = query.IdSubCategoria.Value;
                        producto.SubCategoria.Categoria = new ML.Categoria();
                        producto.SubCategoria.Categoria.IdCategoria = query.IdCategoria.Value;
                        producto.SubCategoria.Categoria.Nombre = query.Categoria;
                       
                        //producto.SubCategoria.Categoria = categoria;
                 
                        result.Object = producto;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }


        public static ML.Result Add(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AOrtegaProgramacionNCapasContext context = new DL.AOrtegaProgramacionNCapasContext())
                {
                    var RowsAffected = context.Database.ExecuteSqlRaw($"ProductoAdd '{producto.Nombre}', '{producto.Descripcion}', {producto.Precio}, @Imagen, {producto.SubCategoria.IdSubCategoria}", new Microsoft.Data.SqlClient.SqlParameter("@Imagen", producto.Imagen));
                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }


        public static ML.Result Update(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AOrtegaProgramacionNCapasContext context = new DL.AOrtegaProgramacionNCapasContext())
                {
                    var RowsAffected = context.Database.ExecuteSqlRaw($"ProductoUpdate {producto.IdProducto},'{producto.Nombre}', '{producto.Descripcion}', {producto.Precio} ,@Imagen, {producto.SubCategoria.IdSubCategoria}", new Microsoft.Data.SqlClient.SqlParameter("@Imagen", producto.Imagen));
                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }



        public static ML.Result Delete(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AOrtegaProgramacionNCapasContext context = new DL.AOrtegaProgramacionNCapasContext())
                {
                    var RowsAffected = context.Database.ExecuteSqlRaw($"ProductoDelete '{producto.IdProducto}'");
                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}

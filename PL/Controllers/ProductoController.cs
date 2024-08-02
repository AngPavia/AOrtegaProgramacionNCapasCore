using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class ProductoController : Controller
    {
        public IActionResult GetAll()
        {
            ML.Producto producto = new ML.Producto();   
            ML.Result result = BL.Producto.GetAll();
            if (result.Correct)
            {
                producto.Productos = result.Objects;
                return View(producto);
            }
            else
            {

            }
            return View();
        }


        [HttpGet]
        public IActionResult Form(int IdProducto)
        {
            ML.Result listaCategoria = BL.Categoria.GetAll();
            ML.Producto producto = new ML.Producto();
            producto.SubCategoria = new ML.SubCategoria();
            producto.SubCategoria.Categoria = new ML.Categoria();
            producto.SubCategoria.Categoria.Categorias = listaCategoria.Objects;




            if (IdProducto > 0)
            {

                ML.Result result = BL.Producto.GetById(IdProducto);
                if (result.Correct)
                {
                    producto = (ML.Producto)result.Object;
                    //producto.SubCategoria.Categoria = new ML.Categoria();
                    producto.SubCategoria.Categoria.Categorias = listaCategoria.Objects;
                    ML.Result listaSubcategoria = BL.SubCategoria.GetByIdCategoria(producto.SubCategoria.Categoria.IdCategoria);
                    producto.SubCategoria.SubCategorias = listaSubcategoria.Objects;
                    return View(producto);
                }
                else
                {
                    ViewBag.Mensaje = "No se encontró";
                }
            }


            //getall de categoria
            return View(producto);
        }



        [HttpPost]
        public IActionResult Form(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            IFormFile file = Request.Form.Files["file"];

            if (file != null)
            {
                producto.Imagen = ConvertToBytes(file);

            }



            if (producto.IdProducto > 0)
            {
                result = BL.Producto.Update(producto);
            }
            else
            {

                result = BL.Producto.Add(producto);
            }
            if (result.Correct == true)
            {
                ViewBag.Mensaje = "Se insertó el registro correctamente";
            }
            else
            {
                ViewBag.Mensaje = "No se insertó el registro" + result.ErrorMessage;
            }
            return PartialView("Modal");
        }


        public IActionResult Delete(int IdProducto)
        {
            ML.Result result = new ML.Result();
            ML.Producto producto = new ML.Producto();
            producto.IdProducto = IdProducto;
            result = BL.Producto.Delete(producto);
            if (result.Correct == true)
            {
                ViewBag.Mensaje = "Se borró exitosamente";
            }
            else
            {
                ViewBag.Mensaje = "No se borró el registro " + result.ErrorMessage;
            }
            return PartialView("Modal");
        }


        //public byte[] ConvertToBytes(IFormFile archivo)
        //{
        //    byte[] data = null;
        //    System.IO.BinaryReader reader = new System.IO.BinaryReader(archivo.OpenReadStream());
        //    data = reader.ReadBytes((int)archivo.Length);
        //    return data;
        //}

        public byte[] ConvertToBytes(IFormFile archivo)
        {
            using (var ms = new MemoryStream())
            {
                archivo.CopyTo(ms);
                var fileBytes = ms.ToArray();
                string s = Convert.ToBase64String(fileBytes);

                return fileBytes;
            }
        }



        public JsonResult GetSubCategoriaByIdCategoria(byte IdCategoria)
        {
            ML.Result result = BL.SubCategoria.GetByIdCategoria(IdCategoria);
            return Json(result);
        }



    }
}

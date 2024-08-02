using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class ProductoAjaxController : Controller
    {

        [HttpGet]
        public JsonResult GetAllTable()
        {
            ML.Producto producto = new ML.Producto();
            ML.Result result = BL.Producto.GetAll();
            if (result.Correct)
            {
                producto.Productos = result.Objects;

            }

            return Json(result);
        }
      
        public IActionResult GetAll()
        {

            ML.Producto producto = new ML.Producto();

            ML.Result result = BL.Producto.GetAll();
            producto.Productos = result.Objects;
            ML.Result listaCategoria = BL.Categoria.GetAll();

            producto.SubCategoria = new ML.SubCategoria();
            producto.SubCategoria.Categoria = new ML.Categoria();
            producto.SubCategoria.Categoria.Categorias = listaCategoria.Objects;

            ML.Result listaSubcategoria = BL.SubCategoria.GetByIdCategoria(producto.SubCategoria.Categoria.IdCategoria);
            producto.SubCategoria.SubCategorias = listaSubcategoria.Objects;
            return View(producto);
        }
        [HttpPost]
        public JsonResult Add([FromBody]ML.Producto producto)
        {
            ML.Result result = BL.Producto.Add(producto);
            return Json(result);
        }

        [HttpPost]
        public JsonResult Update([FromBody] ML.Producto producto)
        {
            ML.Result result = BL.Producto.Update(producto);
            return Json(result);
        }

        [HttpGet]
        public IActionResult Form()
        {
            return View(new ML.Producto());
        }

        [HttpGet]
        public JsonResult GetById(int IdProducto)
        {
            ML.Result result = BL.Producto.GetById(IdProducto);

            return Json(result);
        }
        public JsonResult GetSubCategoriaByIdCategoria(byte IdCategoria)
        {
            ML.Result result = BL.SubCategoria.GetByIdCategoria(IdCategoria);
            return Json(result);
        }
        [HttpGet]
        public JsonResult Delete(ML.Producto producto)
        {
            ML.Result result = BL.Producto.Delete(producto);

            return Json(result);
        }



    }
}

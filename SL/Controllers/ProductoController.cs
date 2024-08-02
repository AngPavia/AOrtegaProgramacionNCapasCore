using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Web.Http;
using System.Net.Http;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using DL;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using Microsoft.AspNetCore.Cors;

namespace SL.Controllers
{
    public class ProductoController : Controller
    {
        

        [HttpGet]
        [Route("api/Producto/GetAll")]
             

        public IActionResult GetAll()
            {

                ML.Producto producto = new ML.Producto();
                
                ML.Result result = BL.Producto.GetAll();

                if (result.Correct)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound(result);
                }
            }


        [HttpPost]
        [Route("api/Producto/Add")]
        public IActionResult Add([FromBody] ML.Producto producto)
        {
            ML.Result result = BL.Producto.Add(producto);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }


        [HttpPost]
        [Route("api/Producto/Update")]
        public IActionResult Update([FromBody] ML.Producto producto)
        {
            ML.Result result = BL.Producto.Update(producto);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }


        [HttpGet]
        [Route("api/Producto/GetById/{IdProducto}")]
        public IActionResult GetById(int IdProducto)
        {
            ML.Result result = BL.Producto.GetById(IdProducto);

            if (result.Correct)
            {
                return Ok(result);
            }
            else 
            {
                return NotFound(result);
            }

        }


        [HttpGet]
        [Route("api/Producto/Delete/{IdProducto}")]
        
        public IActionResult Delete(ML.Producto producto)
        {
            ML.Result result = BL.Producto.Delete(producto);

            if (result.Correct)
            {
                return Ok(result);
            }
            else 
            {

                return NotFound(result);
            }

        }

    }
}

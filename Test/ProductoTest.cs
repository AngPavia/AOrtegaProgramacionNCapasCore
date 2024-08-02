using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using ML;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class ProductoTest
    {
        private Mock<BL.Categoria> _mockCategoriaBL;
        private Mock<BL.Producto> _mockProductoBL;
        private Mock<BL.SubCategoria> _mockSubCategoriaBL;
        

        [TestMethod]
        public void ProductoResultado()
        {
            // Arrange
            // Crear una instancia de Producto 
            ML.Producto producto = new ML.Producto();
            ML.Result result = BL.Producto.GetAll();

            //los datos son los correctos
            Assert.IsNotNull(result.Objects, "El resultado de GetAll() no debe ser nulo.");
            Assert.IsTrue(result.Objects.Any(), "El resultado de GetAll() debería contener datos.");

            producto.Productos = result.Objects;

            // Act
            PL.Controllers.ProductoController productoController = new PL.Controllers.ProductoController();
            var resultPrueba = productoController.GetAll() as ViewResult;

            Assert.IsNotNull(resultPrueba, "La vista devuelta por GetAll() no debe ser nula.");

            // el modelo que se pasa a la vista
            var model = resultPrueba.Model as ML.Producto;
            Assert.IsNotNull(model, "El modelo devuelto por la vista no debe ser nulo.");

            Assert.AreEqual(producto.Productos.Count, model.Productos.Count, "El número de productos en el modelo no coincide.");

        }
        [TestMethod]
        public void ProductoDelete()
        {
            ML.Producto producto = new ML.Producto();
            ML.Result result = BL.Producto.Delete(producto);


            int testIdProducto = 1;

            var mockResult = new ML.Result
            {
                Correct = true
            };
            var mockProductoBL = new Mock<BL.Producto>();

          

            // Act
            PL.Controllers.ProductoController productoController = new PL.Controllers.ProductoController();
           // result = productoController.Delete(testIdProducto) as ViewResult;


            // Assert
            //Assert.IsNotNull(resultPrueba);
            //Assert.AreEqual("Modal", resultPrueba.ViewName);
            Assert.AreEqual("Se borró exitosamente", productoController.ViewBag.Mensaje);
        }

        public ProductoTest()
        {
            _mockProductoBL = new Mock<BL.Producto>();
        }


        [TestMethod]
        public void ProductoAdd()
        {
            var producto = new ML.Producto
            {
                Nombre = "Producto Test",
                Descripcion = "Descripción",
                Precio = 100,
                SubCategoria = new ML.SubCategoria { IdSubCategoria = 1 }
            };

            //PL.Controllers.ProductoController productoController = new PL.Controllers.ProductoController();
            var productoController = new PL.Controllers.ProductoController(_mockProductoBL.Object);


            _mockProductoBL.Setup(m => m.Add(producto)).Returns(new Result { Correct = true });

        }


    }
}

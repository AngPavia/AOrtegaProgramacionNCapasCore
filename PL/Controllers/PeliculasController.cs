using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;

namespace PL.Controllers
{
    public class PeliculasController : Controller
    {
        public ActionResult Index(int? page)
        {
            ML.Pelicula movie = new ML.Pelicula();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.themoviedb.org/3/");
                page = page == null ? 1 : page;
                string url = "movie/popular?api_key=ab36432811f7477a8e3a88935217481e&language=es-ES&page=" + page;
                var responseTask = client.GetAsync(url);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    dynamic resultJSON = JObject.Parse(readTask.Result);
                    readTask.Wait();
                    movie.Movies = new List<object>();
                    foreach (var resultItem in resultJSON.results)
                    {
                        ML.Pelicula movieItem = new ML.Pelicula();
                        movieItem.IdMovie = resultItem.id;
                        movieItem.Descripcion = resultItem.overview;
                        movieItem.Nombre = resultItem.title;
                        movieItem.Imagen = "https://www.themoviedb.org/t/p/w600_and_h900_bestv2" + resultItem.poster_path;
                        movie.Movies.Add(movieItem);
                    }
                }
            }
            ViewBag.page = page;
            return View(movie);
        }
    }
}

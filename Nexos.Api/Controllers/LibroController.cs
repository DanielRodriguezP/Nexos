using Nexos.Negocio.Libro;
using Nexos.Transversal;
using Nexos.Transversal.Request;
using System.Collections.Generic;
using System.Web.Http;

namespace Nexos.Api.Controllers
{
    public class LibroController : ApiController
    {
        [HttpGet]
        public IEnumerable<LibroResponse> ListarLibros()
        {
            LibroNegocio Libro = new LibroNegocio();
            var listado = Libro.ListarLibros();
            return listado;
        }
        [HttpPost]
        public bool GuardarLibro([FromBody] LibroRequest request)
        {
            LibroNegocio Libro = new LibroNegocio();
            var listado = Libro.GuardarLibro(request);
            if (listado > 0)
                return true;
            else
                return false;

        }
    }
}
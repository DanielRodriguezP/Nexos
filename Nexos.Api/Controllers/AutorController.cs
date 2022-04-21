using Nexos.Negocio.Autor;
using Nexos.Transversal.Request;
using Nexos.Transversal.Response;
using System.Collections.Generic;
using System.Web.Http;

namespace Nexos.Api.Controllers
{
    public class AutorController : ApiController
    {
        [HttpGet]
        public IEnumerable<AutorResponse> ListarAutor()
        {
            AutorNegocio Autor = new AutorNegocio();
            var listado = Autor.ListarAutor();
            return listado;
        }
        [HttpPost]
        public bool GuardarAutor(AutorRequest request)
        {

            AutorNegocio Autor = new AutorNegocio();
            var listado = Autor.GuardarAutor(request);
            if (listado > 0)
                return true;
            else
                return false;
        }

        [HttpGet]
        [Route("api/Autor/LlenarComboboxAutor")]
        public IEnumerable<AutorResponse> LlenarComboboxAutor()
        {
            AutorNegocio Autor = new AutorNegocio();
            var listado = Autor.LlenarComboboxAutor();
            return listado;
        }
    }
}
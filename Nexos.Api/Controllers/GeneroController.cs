using Nexos.Negocio.Genero;
using Nexos.Transversal.Response;
using System.Collections.Generic;
using System.Web.Http;

namespace Nexos.Api.Controllers
{
    public class GeneroController : ApiController
    {
        [HttpPost]
        public IEnumerable<GeneroResponse> LlenarComboboxGenero()
        {
            GeneroNegocio Genero = new GeneroNegocio();
            var listado = Genero.LlenarComboboxGenero();
            return listado;
        }
    }
}

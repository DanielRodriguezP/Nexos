using Nexos.Negocio.Ciudad;
using Nexos.Transversal.Response;
using System.Collections.Generic;
using System.Web.Http;

namespace Nexos.Api.Controllers
{
    public class CiudadController : ApiController
    {

        [HttpGet]
        public IEnumerable<CiudadResponse> LlenarComboboxCiudad()
        {
            CiudadNegocio Ciudad = new CiudadNegocio();
            //return ciudadInterface.LlenarComboboxCiudad();
            var listado = Ciudad.LlenarComboboxCiudad();
            return listado;
        }
    }
}
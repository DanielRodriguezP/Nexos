using Nexos.Datos.Ciudad;
using Nexos.Transversal.Response;
using System;
using System.Collections.Generic;

namespace Nexos.Negocio.Ciudad
{
    public class CiudadNegocio
    {
        public List<CiudadResponse> LlenarComboboxCiudad()
        {
            try
            {
                return new CiudadDatos().LlenarComboboxCiudad();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

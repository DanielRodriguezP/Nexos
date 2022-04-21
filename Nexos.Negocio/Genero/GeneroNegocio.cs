using Nexos.Datos.Genero;
using Nexos.Transversal.Response;
using System;
using System.Collections.Generic;

namespace Nexos.Negocio.Genero
{
    public class GeneroNegocio
    {
        public List<GeneroResponse> LlenarComboboxGenero()
        {
            try
            {
                return new GeneroDatos().LlenarComboboxGenero();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

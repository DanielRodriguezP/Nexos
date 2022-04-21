using Nexos.Datos.Libro;
using Nexos.Transversal;
using Nexos.Transversal.Request;
using System;
using System.Collections.Generic;

namespace Nexos.Negocio.Libro
{
    public class LibroNegocio
    {
        public List<LibroResponse> ListarLibros()
        {
            try
            {
                return new LibroDatos().ListarLibros();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int GuardarLibro(LibroRequest libro)
        {
            try
            {
                return new LibroDatos().GuardarLibro(libro);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}

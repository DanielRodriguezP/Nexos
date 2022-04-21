using Nexos.Datos.Autor;
using Nexos.Transversal.Request;
using Nexos.Transversal.Response;
using System;
using System.Collections.Generic;

namespace Nexos.Negocio.Autor
{
    public class AutorNegocio
    {
        public List<AutorResponse> ListarAutor()
        {
            try
            {
                return new AutorDatos().ListarAutores();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int GuardarAutor(AutorRequest autor)
        {
            try
            {
                return new AutorDatos().GuardarAutor(autor);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<AutorResponse> LlenarComboboxAutor()
        {
            try
            {
                return new AutorDatos().LlenarComboboxAutor();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

using CapaDatos;
using Nexos.Transversal.Request;
using Nexos.Transversal.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Nexos.Datos.Autor
{
    public class AutorDatos
    {
        public List<AutorResponse> ListarAutores()
        {
            List<AutorResponse> listaAutor = new List<AutorResponse>();
            AccesoDatos gestorBD = new AccesoDatos();
            using (DataSet datos = gestorBD.EjecutarDataSet("SP_ListarAutores"))
            {
                if (datos != null && datos.Tables[0].Rows.Count > 0)
                {
                    var resultado = (from Autor in datos.Tables[0].AsEnumerable()
                                     select new AutorResponse
                                     {
                                         Id = Autor.Field<int>("Id"),
                                         NombreCompleto = Autor.Field<string>("NombreCompleto"),
                                         FechaNacimiento = Autor.Field<DateTime>("FechaNacimiento"),
                                         Ciudad = Autor.Field<string>("Ciudad"),
                                         Correo = Autor.Field<string>("Correo"),
                                     }).ToList();
                    if (resultado != null && resultado.Count > 0)
                    {
                        listaAutor = resultado;
                    }
                }
            }
            return listaAutor;
        }

        public int GuardarAutor(AutorRequest autor)
        {
            AccesoDatos datos = new AccesoDatos();
            datos.AgregarParametro("@NombreCompleto", autor.NombreCompleto);
            datos.AgregarParametro("@FechaNacimiento", autor.FechaNacimiento);
            datos.AgregarParametro("@CiudadId", autor.CiudadId);
            datos.AgregarParametro("@Correo", autor.Correo);
            return datos.Ejecutar("SP_InsertarAutor");
        }

        public List<AutorResponse> LlenarComboboxAutor()
        {
            List<AutorResponse> listaAutor = new List<AutorResponse>();
            AccesoDatos gestorBD = new AccesoDatos();
            using (DataSet datos = gestorBD.EjecutarDataSet("SP_ListarAutor"))
            {
                if (datos != null && datos.Tables[0].Rows.Count > 0)
                {
                    var resultado = (from Autor in datos.Tables[0].AsEnumerable()
                                     select new AutorResponse
                                     {
                                         Id = Autor.Field<int>("Id"),
                                         NombreCompleto = Autor.Field<string>("NombreCompleto"),
                                     }).ToList();
                    if (resultado != null && resultado.Count > 0)
                    {
                        listaAutor = resultado;
                    }
                }
            }
            return listaAutor;
        }
    }
}

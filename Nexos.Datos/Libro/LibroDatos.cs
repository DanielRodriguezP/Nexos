
using CapaDatos;
using Nexos.Transversal;
using Nexos.Transversal.Request;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Nexos.Datos.Libro
{
    public class LibroDatos
    {
        public List<LibroResponse> ListarLibros()
        {
            List<LibroResponse> listaLibros = new List<LibroResponse>();
            AccesoDatos gestorBD = new AccesoDatos();
            using (DataSet datos = gestorBD.EjecutarDataSet("SP_ListarLibros"))
            {
                if (datos != null && datos.Tables[0].Rows.Count > 0)
                {
                    var resultado = (from Libros in datos.Tables[0].AsEnumerable()
                                     select new LibroResponse
                                     {
                                         Id = Libros.Field<int>("Id"),
                                         Titulo = Libros.Field<string>("Titulo"),
                                         Ano = Libros.Field<int>("Año"),
                                         NumeroPagina = Libros.Field<int>("NumPag"),
                                         NombreCompleto = Libros.Field<string>("NombreCompleto"),
                                         Genero = Libros.Field<string>("Genero"),
                                     }).ToList();
                    if (resultado != null && resultado.Count > 0)
                    {
                        listaLibros = resultado;
                    }
                }
            }
            return listaLibros;
        }

        public int GuardarLibro(LibroRequest libro)
        {
            AccesoDatos datos = new AccesoDatos();
            datos.AgregarParametro("@Titulo", libro.Titulo);
            datos.AgregarParametro("@Año", libro.Ano);
            datos.AgregarParametro("@Genero", libro.GeneroId);
            datos.AgregarParametro("@NumPag", libro.NumeroPagina);
            datos.AgregarParametro("@AutorId", libro.AutorId);
            return datos.Ejecutar("SP_InsertarLibro");
        }
    }
}

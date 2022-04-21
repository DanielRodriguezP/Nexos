using CapaDatos;
using Nexos.Transversal.Response;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Nexos.Datos.Genero
{
    public class GeneroDatos
    {
        public List<GeneroResponse> LlenarComboboxGenero()
        {
            List<GeneroResponse> listarCiudad = new List<GeneroResponse>();
            AccesoDatos gestorBD = new AccesoDatos();
            using (DataSet datos = gestorBD.EjecutarDataSet("SP_ListarGenero"))
            {
                if (datos != null && datos.Tables[0].Rows.Count > 0)
                {
                    var resultado = (from Genero in datos.Tables[0].AsEnumerable()
                                     select new GeneroResponse
                                     {
                                         Id = Genero.Field<int>("Id"),
                                         Nombre = Genero.Field<string>("Nombre"),
                                     }).ToList();
                    if (resultado != null && resultado.Count > 0)
                    {
                        listarCiudad = resultado;
                    }
                }
            }
            return listarCiudad;
        }
    }
}

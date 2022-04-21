using CapaDatos;
using Nexos.Transversal.Response;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Nexos.Datos.Ciudad
{
    public class CiudadDatos
    {
        public List<CiudadResponse> LlenarComboboxCiudad()
        {
            List<CiudadResponse> listarCiudad = new List<CiudadResponse>();
            AccesoDatos gestorBD = new AccesoDatos();
            using (DataSet datos = gestorBD.EjecutarDataSet("SP_ListarCiudad"))
            {
                if (datos != null && datos.Tables[0].Rows.Count > 0)
                {
                    var resultado = (from Autor in datos.Tables[0].AsEnumerable()
                                     select new CiudadResponse
                                     {
                                         Id = Autor.Field<int>("Id"),
                                         Nombre = Autor.Field<string>("Nombre"),
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

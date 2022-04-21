using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class AccesoDatos
    {
        private Database baseDatos = new Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(GetObtenerCadenaConexion());
        private IList<DbParameter> Parametros = new List<DbParameter>();

        public int Ejecutar(string procedimiento)
        {
            try
            {
                DbCommand comando = PrepararComando(procedimiento) as DbCommand;
                if (Parametros.Count > 0)
                {
                    foreach (DbParameter param in Parametros)
                    {
                        comando.Parameters.Add(new SqlParameter(param.ParameterName, param.Value));
                    }
                }
                return baseDatos.ExecuteNonQuery(comando);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public DataTable EjecutarWithDataTable(string procedimiento)
        {
            try
            {
                DbCommand comando = PrepararComando(procedimiento) as DbCommand;
                if (Parametros.Count > 0)
                {
                    foreach (DbParameter param in Parametros)
                    {
                        comando.Parameters.Add(new SqlParameter(param.ParameterName, param.Value));
                    }
                }
                DataTable resultado = baseDatos.ExecuteDataSet(comando).Tables[0];
                return resultado;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public DataSet EjecutarDataSet(string procedimiento)
        {
            try
            {
                DbCommand comando = PrepararComando(procedimiento) as DbCommand;
                if (Parametros.Count > 0)
                {
                    foreach (DbParameter param in Parametros)
                    {
                        comando.Parameters.Add(new SqlParameter(param.ParameterName, param.Value));
                    }
                }
                DataSet resultado = baseDatos.ExecuteDataSet(comando);
                return resultado;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void AgregarParametro(string nombre, DbType tipo, object valor, ParameterDirection direccion)
        {
            DbParameter dbParameter = new SqlParameter();
            dbParameter.ParameterName = nombre;
            dbParameter.DbType = tipo;
            dbParameter.Value = valor;
            dbParameter.Direction = direccion;

            Parametros.Add(dbParameter);
        }

        public void AgregarParametro(string nombre, DbType tipo, object valor)
        {
            DbParameter dbParameter = new SqlParameter();
            dbParameter.ParameterName = nombre;
            dbParameter.DbType = tipo;
            dbParameter.Value = valor;

            Parametros.Add(dbParameter);
        }
        public void AgregarParametro(string nombre, object valor)
        {
            DbParameter dbParameter = new SqlParameter();
            dbParameter.ParameterName = nombre;
            dbParameter.Value = valor;

            Parametros.Add(dbParameter);
        }

        private IDbCommand PrepararComando(string procedimiento)
        {
            DbCommand comando = baseDatos.GetStoredProcCommand(procedimiento);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandTimeout = 10000;
            return comando;
        }

        private static string GetObtenerCadenaConexion()
        {
            return "Data Source = GENESYS-NB-165; Initial Catalog = Nexos; Integrated Security = True";
            //return "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Nexos;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }
    }
}

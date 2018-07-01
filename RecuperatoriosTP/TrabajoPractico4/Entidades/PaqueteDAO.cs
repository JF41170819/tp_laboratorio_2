using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlConnection _conexion;
        private static SqlCommand _comando;

        static PaqueteDAO()
        {
            _conexion = new SqlConnection(Properties.Settings.Default.Conexion);
        }

        public static bool Insertar(Paquete p)
        {
            bool retornador = true;

            try
            {
                _conexion.Open();
                _comando = new SqlCommand("INSERT INTO [correo-sp-2017].[dbo].[Paquetes] (direccionEntrega, trackingID, alumno) VALUES ('" + p.DireccionEntrega + "','" + p.TrackingID + "','Juan Manuel Figueiras')", _conexion);
                _comando.ExecuteNonQuery();
            }
            catch (Exception excepcion)
            {
                retornador = false;
                throw excepcion;
            }
            finally
            {
                if (!(_conexion.State != ConnectionState.Open))
                {
                    _conexion.Close();
                }
            }

            return retornador;
        }
    }
}

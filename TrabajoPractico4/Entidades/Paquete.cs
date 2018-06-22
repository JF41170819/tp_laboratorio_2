using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        //Declaro el delegado.
        public delegate void DelegadoEstado(object sender, EventArgs e);

        private EEstado estado;
        private string direccionEntrega;
        private string trackingID;

        //Declaro el evento (con el mismo tipo del delegado).
        public event DelegadoEstado InformaEstado;

        public EEstado Estado { get { return this.estado; } set { this.estado = value; } }
        public string DireccionEntrega { get { return this.direccionEntrega; } set { this.direccionEntrega = value;} }
        public string TrackingID { get { return this.trackingID; } set { this.trackingID = value;} }

        public void MockCicloDeVida()
        {
            do
            {
                Thread.Sleep(10000);
                this.Estado += 1;
                this.InformaEstado(this, new EventArgs());
            }
            while (this.Estado != EEstado.Entregado);

            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch (Exception)
            {

            }
        }
        
        public override string ToString()
        {
 	        return this.MostrarDatos(this);
        }

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete p1 = (Paquete)elemento;

            string retornador = "-- Elemento : -- : ";

            retornador += string.Format(" {0} Para {1}", p1.TrackingID, p1.DireccionEntrega);

            return retornador;
        }


        public Paquete(string direccionEntrega, string trackingID)
        {
            this.TrackingID = trackingID;
            this.DireccionEntrega = direccionEntrega;
        }

        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return (p1.TrackingID == p2.TrackingID);
        }

        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        public enum EEstado
        {
            Entregado,
            EnViaje,
            Ingresado   
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

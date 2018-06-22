using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Paquete> paquetes;
        private List<Thread> mockPaquetes;

        public List<Paquete> Paquetes
        { 
            get{ return this.paquetes; } 
            set{ this.paquetes = value; } 
        }

        public Correo()
        {
            this.paquetes = new List<Paquete>();
            this.mockPaquetes = new List<Thread>();
        }

        public void FinEntregas()
        {
            foreach (Thread thread in this.mockPaquetes)
            {
                if (thread.IsAlive)
                {
                    thread.Abort();
                    //break;
                }
            }
        }

        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            string retornador= "-- Datos: --\n";

            List<Paquete> plista = ((Correo)elementos).paquetes;

            foreach (Paquete p1 in plista)
            {
                retornador += string.Format("-- {0} para {1} -- {2} --\n", p1.TrackingID, p1.DireccionEntrega, p1.Estado.ToString() );
            }

            return retornador;
        }

        public static Correo operator +(Correo c, Paquete p)
        {
            foreach(Paquete p1 in c.paquetes)
            {
                if(p1 == p)
                {
                    throw new TrackingIdRepetidoException("¡El TrackingID de este paquete ya se encuentra en la lista!");
                    //break;
                }
            }

            c.paquetes.Add(p);
            //Creo el thread.
            Thread th = new Thread(new ThreadStart(p.MockCicloDeVida));
            //Lo inicio.
            th.Start();
            c.mockPaquetes.Add(th);
            return c;
        }

    }
}

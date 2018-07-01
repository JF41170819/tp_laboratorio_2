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
        private List<Paquete> _paquetes;
        private List<Thread> _mockPaquetes;

        public List<Paquete> Paquetes
        {
            get { return this._paquetes; }
            set { this._paquetes = value; } 
        }

        public Correo()
        {
            this._paquetes = new List<Paquete>();
            this._mockPaquetes = new List<Thread>();
        }

        public void FinEntregas()
        {
            foreach (Thread thread in this._mockPaquetes)
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
            string retornador = "-- Datos: --\n";

            if (elementos is Correo)
            {

                List<Paquete> plista = ((Correo)elementos)._paquetes;

                foreach (Paquete p1 in plista)
                {
                    retornador += string.Format(" -- {0} Para: {1} -- Estado: {2} --\n", p1.TrackingID, p1.DireccionEntrega, p1.Estado.ToString());
                }

            }

            return retornador;
        }

        public static Correo operator +(Correo c, Paquete p)
        {
            bool exito = true;

            foreach (Paquete p1 in c._paquetes)
            {
                if(p1 == p)
                {
                    exito = false;

                    throw new TrackingIdRepetidoException("¡El TrackingID de este paquete ya se encuentra en la lista! ( " + p.TrackingID + " ) ");

                    //break;
                }
            }

            if (exito == true)
            {

                //Añado el paquete
                c._paquetes.Add(p);

                //Creo el thread.
                Thread th = new Thread(new ThreadStart(p.MockCicloDeVida));
                
                //Lo inicio.
                th.Start();

                //Añado el thread
                c._mockPaquetes.Add(th);
            }

            return c;
        }

    }
}

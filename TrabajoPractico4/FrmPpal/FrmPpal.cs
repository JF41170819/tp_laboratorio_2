using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace FrmPpal
{
    public partial class FrmPpal : Form
    {
        private Correo correo; 

        public FrmPpal()
        {
            InitializeComponent();
            this.correo = new Correo();
            //this.paquete = new Paquete("Test","Test");
        }

        private void FrmPpal_Load(object sender, EventArgs e)
        {

        }

        private void ActualizarEstados()
        {
            this.lstEstadoEntregado.Items.Clear();
            this.lstEstadoIngresado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();

            foreach (Paquete p1 in this.correo.Paquetes)
            {
                switch (p1.Estado)
                {
                    case Paquete.EEstado.EnViaje:
                        this.lstEstadoEnViaje.Items.Add(p1);
                        break;

                    case Paquete.EEstado.Ingresado:
                        this.lstEstadoIngresado.Items.Add(p1);
                        break;

                    case Paquete.EEstado.Entregado:
                        this.lstEstadoEntregado.Items.Add(p1);
                        break;
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete p1 = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text);

            p1.InformaEstado += new Paquete.DelegadoEstado(this.paq_InformaEstado);

            try
            {
                this.correo += p1;
            }
            catch (TrackingIdRepetidoException e1)
            {
                MessageBox.Show(e1.Message, "¡Tracking ID Repetido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            this.ActualizarEstados();
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            if (sender != null && e != null)
            {
                this.MostrarInformacion<List<Paquete>>(this.correo);
            }
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)this.lstEstadoEntregado.SelectedItem);
        }

        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (base.InvokeRequired)
            {
                Paquete.DelegadoEstado method = new Paquete.DelegadoEstado(this.paq_InformaEstado);
                base.Invoke(method, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (!(object.ReferenceEquals(elemento, null)))
            {
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
                this.rtbMostrar.Text.Guardar("salida.txt");
            }
        }

        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }
    }
}

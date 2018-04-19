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

namespace MiCalculadora
{
    public partial class LaCalculadora : Form
    {

        public LaCalculadora()
        {
            InitializeComponent();
        }

        private void LaCalculadora_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Botón que se encarga de cerrar el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = new DialogResult();
            respuesta = MessageBox.Show("¿Está seguro de que deseas salir?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (respuesta == DialogResult.Yes)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Botón que se encarga de convertir de decimal a binario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text == "" || lblResultado.Text == "Valor inválido")
            {
                MessageBox.Show("Error, resultado no válido para realizar la conversión!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                lblResultado.Text = Numero.DecimalBinario(double.Parse(lblResultado.Text));
            }
        }

        /// <summary>
        /// Botón que se encarga de convertir de binario a decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text == "" || lblResultado.Text == "Valor inválido")
            {
                MessageBox.Show("Error, resultado no válido para realizar la conversión!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
            }
        }

        /// <summary>
        /// Botón que se encarga de limpiar el resultado, los textboxs y el combobox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Boón encargado de realizar las operaciones y mostrarlas en el label de resultado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado = 0;

            Numero numero1 = new Numero(txtNumero1.Text);
            Numero numero2 = new Numero(txtNumero2.Text);

            if(txtNumero1.Text.ToString() == "" || txtNumero2.Text.ToString() == "")
            {
                MessageBox.Show("Error, ingrese ambos números antes de realizar una operación", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else if ( double.Parse(txtNumero2.Text) == 0 && cmbOperador.Text == "/")
            {
                MessageBox.Show("Error, no se puede dividir por 0!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else if ((!(txtNumero1.Text.All(Char.IsDigit)) && !(txtNumero1.Text.Contains(",") || txtNumero1.Text.Contains("."))) || (!(txtNumero2.Text.All(Char.IsDigit)) && !(txtNumero2.Text.Contains(",") || txtNumero2.Text.Contains("."))))
            {
                MessageBox.Show("Error, ingrese un número válido!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                resultado = Entidades.Calculadora.Operar(numero1, numero2, cmbOperador.Text);

                lblResultado.Text = resultado.ToString();
            }

        }

        /// <summary>
        /// Funcion que se encarga de limpiar los textboxs, el label de resultado y el combobox del operador.
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            lblResultado.Text = "";
            cmbOperador.Text = "";
        }

    }
}

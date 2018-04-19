using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        //Constructores

        /// <summary>
        /// Constructor por defecto sin parámetros.
        /// </summary>
        public Numero():this(0)
        {
        }

        /// <summary>
        /// Constructor con un parámetro de tipo double.
        /// </summary>
        /// <param name="numero">Número de tipo double</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Constructor con un parámetro de tipo string.
        /// </summary>
        /// <param name="strNumero">Número de tipo string</param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        /// <summary>
        /// Propiedad de solo escritura (set).
        /// </summary>
        public string SetNumero 
        {
            set { this.numero = ValidarNumero(value); }
        }


        /// <summary>
        /// Está funcion separa lo que está antes y después de la coma.
        /// </summary>
        /// <param name="cadena">Cadena númerica</param>
        /// <param name="antesodespues">Valor que indica si se retornara lo que está antes o después de la cadena (Si es 0 lo que esta antes y si es otro número lo que está después).</param>
        /// <returns>Retorna un string con lo que está antes o después de la coma.</returns>
        public static string AntesDespues(string cadena, int antesodespues)
        {
            string retorno = "";

            int flag = 0;
            string antesdelacoma = "";
            string despuesdelacoma = "";

            if (cadena.Contains(",") || cadena.Contains("."))
            {
                for (int i = 0; i < cadena.Length; i++)
                {
                    if (cadena[i].ToString() == "," || cadena[i].ToString() == ".")
                    {
                        flag = 1;
                    }
                    else
                    {
                        if (flag == 1)
                            despuesdelacoma += cadena[i];
                        else
                            antesdelacoma += cadena[i];
                    }
                }
            }
            else
            {
                antesdelacoma = cadena;
            }

            if(antesodespues == 0)
                retorno = antesdelacoma;
            else
                retorno = despuesdelacoma;

            return retorno;
        }

        /// <summary>
        /// Convierte un número binario a decimal. 
        /// </summary>
        /// <param name="binario">Número binario de tipo string.</param>
        /// <returns>Retorna un número decimal de tipo string o "Valor inválido", si el valor ingresado no es valido para la conversión</returns>
        public static string BinarioDecimal(string binario)
        {
            string retorno = "";
            string antes;
            string despues;

            if (binario.Contains("2") || binario.Contains("3") || binario.Contains("4") || binario.Contains("5") || binario.Contains("6") || binario.Contains("7") || binario.Contains("8") || binario.Contains("9"))
            {
                retorno = "Valor inválido";
            }
            else if (binario.Contains(",") || binario.Contains(".") && (binario.Contains("0") || binario.Contains("1") ))
            {
                antes = AntesDespues(binario, 0);
                despues = AntesDespues(binario, 1);

                //Convierto lo que esta antes de la coma
                antes = Convert.ToInt64(antes, 2).ToString();

                //Convierto lo que esta después de la coma
                int potencia = -1;
                double acumulador = 0;
                for (int i = 0; i < despues.Length; i++)
                {
                    acumulador += (int.Parse(despues[i].ToString())) * Math.Pow(2, potencia);
                    potencia--;
                }

                //Suma de ambas conversiones
                retorno = (double.Parse(antes) + acumulador).ToString();

            }
            else if( (binario.Contains("0") || binario.Contains("1") ) )
            {
                retorno = Convert.ToInt64(binario, 2).ToString();
            }

            return retorno;
        }

        /// <summary>
        /// Convierte un número decimal a binario.
        /// </summary>
        /// <param name="numero">Número decimal de tipo double.</param>
        /// <returns>Retorna un número binario de tipo string o "Valor inválido", si el valor ingresado no es valido para la conversión.</returns>
        public static string DecimalBinario(double numero)
        {
            string retorno = "";
            string antes;
            string despues;
            if (numero.ToString().Contains(",") || numero.ToString().Contains("."))
            {
                antes = AntesDespues(numero.ToString(), 0);
                despues = "0," + AntesDespues(numero.ToString(), 1);

                antes = Convert.ToString(long.Parse(antes), 2);


                //Despues
                string binario = "";
                double temporal = double.Parse(despues);
                List<double> listatemp = new List<double>();

                while(!(listatemp.Contains(temporal)))
                {
                    listatemp.Add(temporal);

                    temporal = temporal * 2;

                    binario += AntesDespues(temporal.ToString(), 0); //Guardo un 0 o 1

                    temporal = double.Parse("0," + AntesDespues(temporal.ToString(), 1));

                }

                retorno = antes + "," + binario;
            }
            else
            {
                retorno = Convert.ToString((long)numero, 2);
            }

            return retorno;
        }

        /// <summary>
        /// Operador -, resta dos objetos de tipo número (según su atributo número).
        /// </summary>
        /// <param name="n1">Objeto número 1.</param>
        /// <param name="n2">Objeto número 2.</param>
        /// <returns>Retorna el resultado de la operación.</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            double retorno = n1.numero - n2.numero;
            return retorno;
        }

        /// <summary>
        /// Operador *, multiplica dos objetos de tipo número (según su atributo número).
        /// </summary>
        /// <param name="n1">Objeto número 1.</param>
        /// <param name="n2">Objeto número 2.</param>
        /// <returns>Retorna el resultado de la operación.</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            double retorno = n1.numero * n2.numero;
            return retorno;
        }

        /// <summary>
        /// Operador /, divide dos objetos de tipo número (según su atributo número).
        /// </summary>
        /// <param name="n1">Objeto número 1.</param>
        /// <param name="n2">Objeto número 2.</param>
        /// <returns>Retorna el resultado de la operación.</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double retorno = n1.numero / n2.numero;
            return retorno;
        }

        /// <summary>
        /// Operador +, suma dos objetos de tipo número (según su atributo número).
        /// </summary>
        /// <param name="n1">Objeto número 1.</param>
        /// <param name="n2">Objeto número 2.</param>
        /// <returns>Retorna el resultado de la operación.</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            double retorno = n1.numero + n2.numero;
            return retorno;
        }

        /// <summary>
        /// Valida que el valor recibido sea numérico y lo convierte de string a double.
        /// </summary>
        /// <param name="strNumero">Número de tipo string</param>
        /// <returns>El número convertido a double o 0 si no se pudo realizar la conversión.</returns>
        private double ValidarNumero(string strNumero)
        {
            double retorno;

            if (!(double.TryParse(strNumero, out retorno)))
            {
                retorno = 0;
            }

            return retorno;
        }

    }
}

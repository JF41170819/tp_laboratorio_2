using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Realiza una operación según corresponda y retorna el resultado.
        /// </summary>
        /// <param name="num1">Objeto número que se pasa por parámetro.</param>
        /// <param name="num2">Objeto número que se pasa por parámetro.</param>
        /// <param name="operador">El operador según la operación que corresponda.</param>
        /// <returns>Retorna un resultado según la operación de tipo double.</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            string operacion = Calculadora.ValidarOperador(operador);

            double resultado = 0;

            switch (operacion)
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
            }

            return resultado;
        }

        /// <summary>
        /// Válida que el operador sea correcto.
        /// </summary>
        /// <param name="operador">El operador según la operación que corresponda.</param>
        /// <returns>Retorna un operador de tipo string, si el operador ingresado es inválido retorna por defecto el operador "+".</returns>
        private static string ValidarOperador(string operador)
        {
            string retorno = operador;

            if ( (operador == null) || (operador != "+" && operador != "-" && operador != "/" && operador != "*") )
            {
                retorno = "+";
            }

            return retorno;
        }
    }
}

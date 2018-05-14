using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Dulce : Producto
    {
        /// Propiedad con un override de la propiedad base de solo lectura (Los dulces tienen 80 calorías).
        protected override short CantidadCalorias
        {
            get
            {
                return 80;
            }
        }

        /// <summary>
        /// Constructor parametrizado que utiliza al constructor de la clase base.
        /// </summary>
        /// <param name="marca">Marca del dulce.</param>
        /// <param name="codigo">Código del dulce.</param>
        /// <param name="color">Color del empaque.</param>
        public Dulce(EMarca marca, string codigo, ConsoleColor color):base(codigo, marca, color)
        {
        }

        /// <summary>
        /// Override del metodo Mostrar(), de la clase base. Concatena los datos del Dulce
        /// </summary>
        /// <returns>Retorna la concatenación de datos del Dulce.</returns>
        public sealed override string Mostrar()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("DULCE");
            builder.AppendLine(base.Mostrar());
            builder.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            builder.AppendLine("");
            builder.AppendLine("---------------------");
            return builder.ToString();
        }
    }
}

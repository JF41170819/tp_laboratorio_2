using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Entidades
{
    public class Leche : Producto
    {
        /// Enumerado.
        public enum ETipo 
        { 
            Entera,
            Descremada
        }

        /// Atributo privado.
        private ETipo _tipo;


        /// Propiedad con un override de la propiedad base de solo lectura (Las leches tienen 20 calorías).
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }

        /// <summary>
        /// Constructor parametrizado 1, que utiliza al constructor base de la clase producto.
        /// </summary>
        /// <param name="marca">Marca de la Leche.</param>
        /// <param name="codigo">Código de la Leche.</param>
        /// <param name="color">Color del empaque de la Leche.</param>
        public Leche(EMarca marca, string codigo, ConsoleColor color): base(codigo, marca, color)
        {
            this._tipo = ETipo.Entera;
        }

        /// <summary>
        /// Constructor parametrizado 2, que utiliza al constructor base de la clase producto.
        /// </summary>
        /// <param name="marca">Marca de la Leche.</param>
        /// <param name="codigo">Código de la Leche.</param>
        /// <param name="color">Color del empaque de la Leche.</param>
        /// <param name="tipo">Tipo de Leche.</param>
        public Leche(EMarca marca, string codigo, ConsoleColor color, ETipo tipo): base(codigo, marca, color)
        {
            this._tipo = tipo;
        }


        /// <summary>
        /// Override del metodo Mostrar() de la clase base, se encarga de concatenar los datos de la Leche en un solo string.
        /// </summary>
        /// <returns>Retorna un string con los datos concatenados de la Leche.</returns>
        public sealed override string Mostrar()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("LECHE");
            builder.AppendLine(base.Mostrar());
            builder.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            builder.AppendLine(" TIPO : " + this._tipo);
            builder.AppendLine("");
            builder.AppendLine("---------------------");
            return builder.ToString();
        }
    }
}

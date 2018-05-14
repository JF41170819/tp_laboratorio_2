using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Snacks : Producto
    {
        /// Propiedad con un override de la propiedad base de solo lectura (Los Snacks tienen 104 calorías).
        protected override short CantidadCalorias
        {
            get
            {
                return 104;
            }
        }

        /// <summary>
        /// Constructor parametrizado, que utiliza al constructor base de la clase producto.
        /// </summary>
        /// <param name="marca">Marca del Snack.</param>
        /// <param name="codigo">Código del Snack.</param>
        /// <param name="color">Color del empaque del Snack.</param>
        public Snacks(EMarca marca, string codigo, ConsoleColor color):base(codigo, marca, color)
        {
        }

        public sealed override string Mostrar()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("SNACKS");
            builder.AppendLine(base.Mostrar());
            builder.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            builder.AppendLine("");
            builder.AppendLine("---------------------");
            return builder.ToString();
        }

    }
}

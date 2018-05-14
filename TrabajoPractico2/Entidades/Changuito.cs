using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public sealed class Changuito
    {
        /// Enumerado.
        public enum ETipo
        {
            Dulce,
            Snacks,
            Leche,
            Todos
        }

        /// Atributos privados.
        private List<Producto> _productos;
        private int _espacioDisponible;
        

        /// <summary>
        /// Constructor 1.
        /// </summary>
        private Changuito()
        {
            this._productos = new List<Producto>();
        }

        /// <summary>
        /// Constructor 2.
        /// </summary>
        /// <param name="espacioDisponible">Espacio disponible.</param>
        public Changuito(int espacioDisponible):this()
        {
            this._espacioDisponible = espacioDisponible;
        }

        /// <summary>
        /// Override del metodo ToString().
        /// </summary>
        /// <returns>Retorna todos los datos de todos los productos concatenados en un solo string.</returns>
        public override string ToString()
        {
            return this.Mostrar(this, ETipo.Todos);
        }

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias).
        /// SOLO del tipo requerido.
        /// </summary>
        /// <param name="concecionaria">Elemento a exponer.</param>
        /// <param name="tipoDeChanguito">Tipos de ítems de la lista a mostrar.</param>
        /// <returns>Retorna los datos de los elementos concatenados en un solo string.</returns>
        public string Mostrar(Changuito concecionaria, ETipo tipoDeChanguito)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", concecionaria._productos.Count, concecionaria._espacioDisponible);
            builder.AppendLine("");

            foreach (Producto producto in concecionaria._productos)
            {
                switch (tipoDeChanguito)
                {
                    case ETipo.Dulce:
                        if (producto is Dulce)
                        {
                            builder.AppendLine(producto.Mostrar());
                        }
                        break;

                    case ETipo.Leche:
                        if (producto is Leche)
                        {
                            builder.AppendLine(producto.Mostrar());
                        }
                        break;

                    case ETipo.Snacks:
                        if (producto is Snacks)
                        {
                            builder.AppendLine(producto.Mostrar());
                        }
                        break;

                    default:
                        builder.AppendLine(producto.Mostrar());
                        break;
                }
            }

            return builder.ToString();
        }

        /// <summary>
        /// Agregará un elemento a la lista.
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento.</param>
        /// <param name="p">Objeto a agregar.</param>
        /// <returns>Retorna un objeto de tipo Changuito, el cual puede incluir o no el elemento que se quiso agregar dependiendo del espacio disponible que haya.</returns>
        public static Changuito operator +(Changuito c, Producto p)
        {
            if (c._productos.Count < c._espacioDisponible)
            {
                foreach (Producto producto in c._productos)
                {
                    if (producto == p)
                    {
                        return c;
                    }
                }

                c._productos.Add(p);
            }

            return c;
        }

        /// <summary>
        /// Quitará un elemento de la lista.
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento.</param>
        /// <param name="p">Objeto a quitar.</param>
        /// <returns>Retorna un objeto de tipo Changuito con el elemento eliminado de la lista, dependiendo si lo encontro o no.</returns>
        public static Changuito operator -(Changuito c, Producto p)
        {
            foreach (Producto producto in c._productos)
            {
                if (producto == p)
                {
                    c._productos.Remove(producto);
                    break;
                }
            }

            return c;
        }

    }
}

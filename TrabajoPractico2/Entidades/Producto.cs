using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Producto
    {
        /// Enumerado.
        public enum EMarca
        {
            Serenisima,
            Campagnola, 
            Arcor,
            Ilolay,
            Sancor,
            Pepsico
        }

        /// Atributos.
        private EMarca _marca;
        private string _codigoDeBarras;
        private ConsoleColor _colorPrimarioEmpaque;

        /// Firma de propiedad de solo lectura.
        protected abstract short CantidadCalorias { get; }


        /// <summary>
        /// Constructor parametrizado.
        /// </summary>
        /// <param name="codigoDeBarras">Código de barras del producto.</param>
        /// <param name="marca">Marca del producto.</param>
        /// <param name="color">Color del empaque.</param>
        public Producto(string codigoDeBarras, EMarca marca, ConsoleColor color)
        {
            this._codigoDeBarras = codigoDeBarras;
            this._marca = marca;
            this._colorPrimarioEmpaque = color;
        }
        
        /// <summary>
        /// Metodo que parsea el this mediante el uso del operador string.
        /// </summary>
        /// <returns>Retorna un string con los datos de los productos concatenados.</returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }

        /// <summary>
        /// Concatena los datos del producto.
        /// </summary>
        /// <param name="p">Objeto de tipo producto.</param>
        /// <returns>Retorna un string con los datos concatenados del producto.</returns>
        public static explicit operator string(Producto p)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("CODIGO DE BARRAS: {0}\r\n", p._codigoDeBarras);
            builder.AppendFormat("MARCA          : {0}\r\n", p._marca.ToString());
            builder.AppendFormat("COLOR EMPAQUE  : {0}\r\n", p._colorPrimarioEmpaque.ToString());
            builder.AppendLine("---------------------");
            return builder.ToString();

        }

        /// <summary>
        /// Operador que sirve para verificar si dos productos son iguales.
        /// </summary>
        /// <param name="v1">Producto 1.</param>
        /// <param name="v2">Producto 2.</param>
        /// <returns>Retorna un valor booleano que puede ser true o false dependiendo de si los productos son iguales o no.</returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            bool retorno = false;

            if (v1._codigoDeBarras == v2._codigoDeBarras)
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Operador que sirve para verificar si dos productos son distintos.
        /// </summary>
        /// <param name="v1">Producto 1.</param>
        /// <param name="v2">Producto 2.</param>
        /// <returns>Retorna un valor booleano que puede ser true o false dependiendo de si los productos son distintos o no.</returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            return !(v1._codigoDeBarras == v2._codigoDeBarras);
        }


        /// Sobrecargo el metodo Equals y el GetHashCode para que el compilador no tire ningún tipo de Advertencia. 
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

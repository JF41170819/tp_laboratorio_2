using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        public static bool Guardar(this string texto, string archivo)
        {
            bool retornador = true;

            try
            {
                StreamWriter writefile = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + Path.DirectorySeparatorChar + archivo, true); //Encoding true por defecto.
                //Escribo el archivo.
                writefile.WriteLine(texto);
                //Cierro el archivo.
                writefile.Close();
            }
            catch (Exception)
            {
                retornador = false;
            }

            return retornador;
        }
    }
}

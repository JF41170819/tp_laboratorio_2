using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace Unitario
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PruebaListaPaquetesInstanciada()
        {
            Correo c = new Correo();

            if (c.Paquetes == null)
            {
                Assert.Fail("ERROR!!!!");
            }
        }

        [TestMethod]
        public void MismoTrackingID()
        {
            Correo c2 = new Correo();
            Paquete p1 = new Paquete("asdaasd", "888");
            Paquete p2 = new Paquete("agfdgdf", "888");

            try
            {
                c2 += p2;
                c2 += p1;
            }
            catch (TrackingIdRepetidoException excepcion)
            {
                //AssertFailedException;
                Assert.Fail("Error {0}", excepcion.Message);
            }
        }
    }
}

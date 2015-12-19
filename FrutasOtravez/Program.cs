using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace FrutasOtravez
{
    class Program
    {
        static void Main(string[] args)
        {
            //Crear 3 instancias de Manzanas.
            Manzana unaManzana = new Manzana(5.5f, ConsoleColor.Red, 10D);
            Manzana dosManzana = new Manzana(5.5f, ConsoleColor.Red, 10D);
            Manzana tresManzana = new Manzana(5.5f, ConsoleColor.Red, 10D);

            //Creo 3 objetos de tipo platano.
            Platano unPlatano = new Platano(2.5f, ConsoleColor.Yellow, 12D);
            Platano dosPlatano = new Platano(2.5f, ConsoleColor.Yellow, 12D);
            Platano tresPlatano = new Platano(2.5f, ConsoleColor.Yellow, 12D);

            //Creo un objeto Cajon.
            Cajon miCajon = new Cajon(6);

            try
            {
                //Agrego todas la frutas a la caja.
                miCajon = miCajon + unaManzana;
                miCajon = miCajon + dosManzana;
                miCajon = miCajon + tresManzana;

                miCajon = miCajon + unPlatano;
                miCajon = miCajon + dosPlatano;
                miCajon = miCajon + tresPlatano;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //Muestro el cajon
                Console.WriteLine(miCajon);
            }


            foreach (Fruta item in miCajon.Frutas)
            {
                miCajon.Frutas.Sort(Fruta.OrdenarPorPesoAsc);
            }

            //Muestro el cajon.
            Console.WriteLine(miCajon);

            foreach (Fruta item in miCajon.Frutas)
            {
                miCajon.Frutas.Sort(Fruta.OrdenarPorPesoDesc);
            }

            Console.WriteLine(miCajon);


            Console.WriteLine("PRECIO EN MANZANAS:");
            //MUESTRO EL TOTAL DE MANZANAS.
            Console.WriteLine(miCajon.PrecioDeManzana);

            Console.WriteLine("PRECIO EN PLATANO:");
            //MUESTRO EL TOTAL DE BANANAS.
            Console.WriteLine(miCajon.PrecioDePlatanos);

            Console.WriteLine("PRECIO TOTAL FRUTAS:");
            //MUESTRO EL TOTAL DE TODO.
            Console.WriteLine(miCajon.PrecioDeTodo);

            Console.ReadKey();

            unaManzana.RutaArchivo = @"C:\\manzana.xml";

            Serializar(unaManzana);
           


        }

        // recibe como parametro un objeto de tipo ISerialible y retorna
        // true si puede serializar; false , caso contrario. Reutilizar codigo
        // (solo una linea de codigo).
        private static bool Serializar(ISerializable obj)
        {
           return obj.SerializarXML();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace FrutasOtravez
{
    [Serializable]
    class Manzana:Fruta,ISerializable
    {
        public double _precio;
        private string _ruta;
        

        public override bool TieneCarozo
        {
            get { return true; }
        }

        public string Tipo 
        { 
            get { return "Manzana"; } 
        }

        protected override string FrutaToString()
        {
            return base.FrutaToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Tipo: " + Tipo);
            sb.AppendLine("Precio: " + _precio);
            sb.AppendLine("Carozo: " + TieneCarozo);
           

            return sb.ToString() + FrutaToString();
        }

        //CONTRUCTOR NO TOMA NINGUN PARAMETRO
        public Manzana()
        { }

        public Manzana(float peso, ConsoleColor color, double precio):base(peso,color)
        {
            this._precio = precio;
        }


       /* 
        * Implementación de las Propieadades y Métodos ISerializable...  
        *
        */ 

        public string RutaArchivo
        {
            get
            {
                return this._ruta;
            }
            set
            {
                this._ruta = value;
            }
        }

        public bool SerializarXML()
        {
            try
            {
                using (XmlTextWriter escritor = new XmlTextWriter(this.RutaArchivo,Encoding.UTF8))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(Manzana));
                    serializador.Serialize(escritor, this);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return true;
        }


    }
}

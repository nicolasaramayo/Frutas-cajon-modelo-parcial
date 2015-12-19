using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;


namespace FrutasOtravez
{
    [Serializable]
    public enum EtipoFruta
    {
        Manzana,
        Platano,
        Todo
    }

    class Cajon:ISerializable
    {

        private int _capacidad;
        private List<Fruta> _frutas;
        private string _ruta;

        public List<Fruta> Frutas 
        { 
            get { return this._frutas; } 
        }

        public double PrecioDeManzana 
        { 
            get {return ObtenerTotal(EtipoFruta.Manzana); } 
        }

        public double PrecioDePlatanos 
        { 
            get {return ObtenerTotal(EtipoFruta.Platano); } 
        }

        public double PrecioDeTodo 
        { 
            get{ return ObtenerTotal(EtipoFruta.Todo); }
        }

        public Cajon()
        {
            this._frutas = new List<Fruta>();
        }

        public Cajon(int capacidad):this()
        {
            this._capacidad = capacidad;
        }

        
        private double ObtenerTotal(EtipoFruta tipo) 
        {
            double aux = 0D;

            switch (tipo)
            {
                case EtipoFruta.Manzana:
                    foreach (Fruta item in _frutas)
                    {
                        if (item is Manzana)
                            aux += ((Manzana)item)._precio;                        
                    }

                    return aux;

                case EtipoFruta.Platano:
                    foreach (Fruta item in _frutas)
                    {
                        if (item is Platano)
                            aux += ((Platano)item)._precio;
                    }

                    return aux;
                case EtipoFruta.Todo:
                    foreach (Fruta item in _frutas)
                    {
                        if (item is Platano)
                            aux += ((Platano)item)._precio;
                    }

                    foreach (Fruta item in _frutas)
                    {
                        if (item is Manzana)
                            aux += ((Manzana)item)._precio;
                    }

                    return aux;

                default:
                    return -1;
            }
        }

        public static Cajon operator +(Cajon c, Fruta f)
        {
            if (c._frutas.Count < c._capacidad)
                c._frutas.Add(f);

            return c;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***********CAJON**********");
            sb.AppendLine("Capacidad: " + _capacidad);

            foreach (Fruta item in _frutas)
            {
                if (item is Manzana)
                {
                    sb.AppendLine(((Manzana)item).ToString());
                }

                if (item is Platano)
                {
                    sb.AppendLine(((Platano)item).ToString());
                }
            }

            return sb.ToString();

        }



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
                using (XmlTextWriter escritor = new XmlTextWriter(RutaArchivo,Encoding.UTF8))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(List<Fruta>));
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

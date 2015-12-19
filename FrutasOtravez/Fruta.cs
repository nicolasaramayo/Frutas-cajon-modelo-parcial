using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrutasOtravez
{
    abstract class Fruta
    {
        protected ConsoleColor _color;
        protected float _peso;

        abstract public bool TieneCarozo { get; }

        public Fruta()
        { }

        public Fruta(float peso, ConsoleColor color)
        {
            this._color = color;
            this._peso = peso;
        }

        protected virtual string FrutaToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Color: " + _color);
            sb.AppendLine("Peso: " + _peso);

            return sb.ToString();
        }

        public static int OrdenarPorPesoAsc(Fruta f1, Fruta f2)
        {
            return f1._peso.CompareTo(f2._peso);
        }

        public static int OrdenarPorPesoDesc(Fruta f1, Fruta f2)
        {
           return f2._peso.CompareTo(f1._peso);
        }

    
    }
}

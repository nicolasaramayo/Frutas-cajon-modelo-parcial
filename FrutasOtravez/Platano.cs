using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrutasOtravez
{
    class Platano:Fruta
    {
        public double _precio;

        public override bool TieneCarozo
        {
            get { return false; }
        }

        public string Tipo
        {
            get { return "Platano"; }
        }

        protected override string FrutaToString()
        {
            return base.FrutaToString();
        }

        public Platano(float peso, ConsoleColor color, double precio)
            : base(peso,color)
        {
            this._precio = precio;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Tipo: " + Tipo);
            sb.AppendLine("Precio: " + _precio);
            sb.AppendLine("Carozo: " + TieneCarozo);
            

            return sb.ToString() + FrutaToString();
        }

    }
}

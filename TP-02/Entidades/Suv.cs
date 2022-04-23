using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Suv : Vehiculo
    {
        public Suv(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }
        /// <summary>
        /// SUV son 'Grande'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return Vehiculo.ETamanio.Grande;
            }
        }

        // private override ETamanio Tamanio { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SUV");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"TAMAÑO : {Tamanio}");
            sb.AppendLine("");
            sb.AppendLine("---------------------");
            return sb.ToString();
        }
    }
}

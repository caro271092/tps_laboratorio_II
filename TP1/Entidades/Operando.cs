using System;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        public Operando()
        {
            this.numero = 0;
        }
        private string Numero
        {
            set { this.numero = ValidarOperando(value); }
        }
        public Operando(string strNumero) { Numero = strNumero; }
        public Operando(double numero) : this(numero.ToString()) { }
        
        /// <summary>
        /// Valida que el string recibido se pueda convertir a double para realizar una operación matemática luego
        /// </summary>
        /// <param name="strNumero">Numero en formato string a validar y convertir</param>
        /// <returns>Operando validado en tipo double o 0 si no se pudo convertir el tipo</returns>
        private static double ValidarOperando(string strNumero)
        {
            foreach (char caracter in strNumero)
            {
                if ((caracter.Equals('.')))
                {
                   strNumero = strNumero.Replace(".",",");
                }
            }
            if (double.TryParse(strNumero, out double numero))
            {
                return numero;
            }
            return 0;
        }

        /// <summary>
        /// Convierte un número decimal a binario, trabajando con el valor absoluto, en caso de ser posible
        /// </summary>
        /// <param name="numero">Valor a convertir</param>
        /// <returns>Valor binario o "Valor inválido" si no se pudo realizar</returns>
        public static string DecimalBinario(double numero)
        {
            int numeroInt;
            string resultado = "Valor inválido";

            if (numero > 0)
            {
                numeroInt = (int)numero;
                resultado = "";
                while (numeroInt > 0)
                {
                    resultado = (numeroInt % 2) + resultado;
                    numeroInt = numeroInt / 2;
                }
            }
            else if (numero == 0)
            {
                resultado = "0";
            }
            else
            {
                resultado = "Valor inválido";
            }
            return resultado;
        }

        /// <summary>
        /// Convierte un número decimal a binario, trabajando con el valor absoluto, en caso de ser posible, recibiendo el número a convertir como cadena
        /// </summary>
        /// <param name="numero">Valor a convertir tipo string</param>
        /// <returns>Valor binario o "Valor inválido" si no se pudo realizar</returns>
        public static string DecimalBinario(string numero)
        {
            string retorno = "Valor inválido";
            double doubleAux;
            if (double.TryParse(numero, out doubleAux))
            {
                retorno = DecimalBinario(doubleAux);
            }
            return retorno;
        }

        /// <summary>
        /// Valida que la cadena de caracteres recibida esté compuesta SOLAMENTE por caracteres '0' o '1'
        /// </summary>
        /// <param name="binario">Cadena a validar</param>
        /// <returns>False si no cumple, True si es cadena de 0 y 1</returns>
        private static bool EsBinario(string binario)
        {
            bool retorno = true;

            foreach (char caracter in binario)
            {
                if (!((caracter.Equals('1')) || (caracter.Equals('0'))))
                {
                    retorno = false;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Convierte un número binario a decimal en caso de recibir un binario
        /// </summary>
        /// <param name="binario">Numero a convertir</param>
        /// <returns>Valor decimal o "No es binario" si no se pudo realizar la conversión</returns>
        public static string BinarioDecimal(string binario)
        {
            double decimalAux;

            if (EsBinario(binario))
            {
                decimalAux = Convert.ToInt32(binario, 2);
                return decimalAux.ToString();
            }
            else 
            {
                return "No es binario"; 
            }
        }
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }
        public static double operator /(Operando n1, Operando n2)
        {
            if (n2.numero == 0)
            {
                return double.MinValue;
            }
            else
            {
                return n1.numero / n2.numero;
            }
        }
    }
}

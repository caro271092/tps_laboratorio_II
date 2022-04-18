using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida que el char recibido sea un operador y lo retorna
        /// </summary>
        /// <param name="operador">char a validar como operador</param>
        /// <returns>Operador validado</returns>
        private static char ValidarOperador(char operador)
        {
            if ((operador =='+') || (operador == '-') || (operador == '/')||(operador == '*'))
            {
                return operador;
            }
            else
            {
                return '+'; 
            }
        }

        /// <summary>
        /// Realiza la operación matemática correspondiente y retorna el resultado
        /// </summary>
        /// <param name="num1">Primer operando de la operación matemática a realizar</param>
        /// <param name="num2">Segundo operando de la operación matemática a realizar</param>
        /// <param name="operador">Operador matemático</param>
        /// <returns>Resultado de la operación</returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            char operadorValidado = ValidarOperador(operador);
            double resultado = 0;
            switch (operadorValidado)
            {
                case '+':
                    resultado = num1 + num2;
                    break;
                case '-':
                    resultado = num1 - num2;    
                    break;
                case '/':
                        resultado = num1 / num2;
                    break;
                case '*':
                    resultado = num1 * num2;
                    break;
            }
            return resultado;
        }
    }
}

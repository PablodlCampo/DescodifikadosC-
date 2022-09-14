using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProyectoConsola.Clases
{
    public class Calculadora
    {
        public void Calcular()
        {
            List<char> operaciones = new List<char>() { '+', '-', '*', '/', '=' };

            Console.WriteLine("Calculadora Ejecutandose ...");

            string numeroCadena = string.Empty;
            decimal? numeroOperar = null;
            bool ejecutarCalculadora = true;
            char operacionActual = char.MinValue;

            while (ejecutarCalculadora)
            {
                char caracter = Console.ReadKey().KeyChar;

                bool esNumero = decimal.TryParse(caracter.ToString(), out decimal numero);

                if (esNumero)//a) numero
                {
                    numeroCadena += caracter.ToString();
                }
                else if(operaciones.Contains(caracter)) //b) operaciones
                {
                    if (operacionActual == char.MinValue) // no existe operacion pendiente
                    {
                        operacionActual = caracter;

                        if (!string.IsNullOrEmpty(numeroCadena))
                        {
                            numeroOperar = decimal.Parse(numeroCadena, CultureInfo.CreateSpecificCulture("en-GB"));
                        }
                    }
                    else if (operacionActual != char.MinValue && numeroOperar != null)
                    {
                        if (!string.IsNullOrEmpty(numeroCadena))
                        {
                            switch (operacionActual)
                            {
                                case '+':
                                    numeroOperar = numeroOperar + decimal.Parse(numeroCadena, CultureInfo.CreateSpecificCulture("en-GB"));
                                    break;
                                case '-':
                                    numeroOperar = numeroOperar - decimal.Parse(numeroCadena, CultureInfo.CreateSpecificCulture("en-GB"));
                                    break;
                                case '*':
                                    numeroOperar = numeroOperar * decimal.Parse(numeroCadena, CultureInfo.CreateSpecificCulture("en-GB"));
                                    break;
                                case '/':
                                    numeroOperar = numeroOperar / decimal.Parse(numeroCadena, CultureInfo.CreateSpecificCulture("en-GB"));
                                    break;
                                default:
                                    break;
                            }
                        }

                        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");

                        Console.WriteLine(numeroOperar.ToString());
                        Console.Write(numeroOperar.ToString());

                        operacionActual = char.MinValue;
                    }

                    numeroCadena = string.Empty;

                }
                else // c) otros caracteres
                {
                    if (caracter == '¡')
                    {
                        break;
                    }
                    else if (caracter == '.' && !numeroCadena.Contains('.'))
                    {
                        numeroCadena += caracter;
                    }
                }
            }
        }

    }
}

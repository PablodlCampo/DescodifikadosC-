using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoConsola.Clases
{
    public class Calculadora
    {

        public void Calcular()
        {
            Console.WriteLine("Calculadora ejecutandose.... \r\n");
            List<char> opsList = new List<char>() { '+', '-', '/', '*', '=' };
            decimal? valorInicial = null;
            bool ejecutarCalculadora = true;
            string numUno = string.Empty;
            char operacionActual = char.MinValue;

            while (ejecutarCalculadora)
            {
                var caracter = Console.ReadKey().KeyChar;

                //bool parsed = Int32.TryParse(caracter.ToString(), out int number);
                bool parsed = decimal.TryParse(caracter.ToString(), out decimal number);

                if (parsed) // a) numero
                {
                    numUno += number.ToString();
                }
                else if (opsList.Contains(caracter)) // b) operación.
                {
                    if (operacionActual == char.MinValue) // si no existe ninguna operacion pendiente
                    {
                        //guarda la operacion
                        operacionActual = caracter;

                        //se guarda el valor inicial
                        valorInicial = decimal.Parse(numUno, CultureInfo.InvariantCulture);
                    }
                    else if (operacionActual != char.MinValue && valorInicial != null)//si ya se ha operado y el valor inicial ya existe 
                    {

                        if(!string.IsNullOrEmpty(numUno))
                        {
                            //esto implica que ya existen operaciones anteriores y por tanto sobre el valor inicial debemos operar con el último número introducido
                            switch (operacionActual)
                            {
                                case '+':
                                    valorInicial = valorInicial + decimal.Parse(numUno, CultureInfo.InvariantCulture);
                                    break;
                                case '-':
                                    valorInicial = valorInicial - decimal.Parse(numUno, CultureInfo.InvariantCulture);
                                    break;
                                case '*':
                                    valorInicial = valorInicial * decimal.Parse(numUno, CultureInfo.InvariantCulture);
                                    break;
                                case '/':
                                    valorInicial = valorInicial / decimal.Parse(numUno, CultureInfo.InvariantCulture);
                                    break;
                                default:
                                    //error
                                    break;
                            }
                        }

                        if (caracter == '=') 
                        {
                            Console.Write("");
                            Console.WriteLine(valorInicial.ToString());
                            Console.Write(valorInicial.ToString());
                        }
                        else
                        {
                            //la operación actual pasa a ser la introducida tras operar(esta sera la operacion que ejecutemos despues
                            operacionActual = caracter;
                        }

                    }

                    numUno = string.Empty;
                }
                else// c) caracteres no númericos
                {
                    if (caracter == '¡')
                    {
                        ejecutarCalculadora = false;
                        break;
                    }
                    else if(caracter == '.')
                    {
                        numUno += caracter;
                    }
                }

            }
        }

        public void CalcularPRO()
        {
            int currentValue = 0;
            List<char> opsList = new List<char>() { '+', '-', '/', '*' };
            Console.WriteLine("Calculadora ejecutandose.... \r\n");

            while (true)
            {
                Console.WriteLine("Introduce operaciones.... \r\n");
                var texto = Console.ReadLine();

                List<int> numerosOperacion = new List<int>();
                List<char> operaciones = new List<char>();

                string numUno = string.Empty;

                for (int i = 0; i < texto.Length; i++)
                {

                    bool parsed = Int32.TryParse(texto[i].ToString(), out int number);

                    if (parsed)
                    {
                        numUno += number.ToString();
                    }
                    else if (opsList.Contains(texto[i]))
                    {
                        if (numUno.Length > 0)
                        {
                            numerosOperacion.Add(Int32.Parse(numUno));
                            numUno = string.Empty;
                            operaciones.Add(texto[i]);
                        }
                        else if (opsList.Contains(texto.ElementAtOrDefault(i - 1)))
                        {
                            //dos operaciones seguidas no
                        }
                        else
                        {
                            operaciones.Add(texto[i]);
                        }

                    }
                    else//faltaria programar los decimales
                    {
                        //caracter que no es operacion ni numero -> error
                    }
                }

                numerosOperacion.Add(Int32.Parse(numUno));// se añade el último numero


                if (numerosOperacion.Count < 2 && currentValue == 0)
                {
                    //error, hacen falta mas números en la primera operación
                }


                if (operaciones.Count > 0)
                {
                    bool primeraOp = true;
                    for (int i = 0; i < operaciones.Count; i++)
                    {

                        if (numerosOperacion.Count == 1)
                        {
                            switch (operaciones[i])
                            {
                                case '+':
                                    currentValue = currentValue + numerosOperacion[i];
                                    break;
                                case '-':
                                    currentValue = currentValue - numerosOperacion[i];
                                    break;
                                case '*':
                                    currentValue = currentValue * numerosOperacion[i];
                                    break;
                                case '/':
                                    currentValue = currentValue / numerosOperacion[i];
                                    break;
                                default:
                                    //error
                                    break;
                            }
                        }
                        else if (numerosOperacion.Count > 1 && primeraOp)
                        {
                            switch (operaciones[i])
                            {
                                case '+':
                                    currentValue = numerosOperacion[i] + numerosOperacion[i + 1];
                                    break;
                                case '-':
                                    currentValue = numerosOperacion[i] - numerosOperacion[i + 1];
                                    break;
                                case '*':
                                    currentValue = numerosOperacion[i] * numerosOperacion[i + 1];
                                    break;
                                case '/':
                                    currentValue = numerosOperacion[i] / numerosOperacion[i + 1];
                                    break;
                                default:
                                    //error
                                    break;
                            }

                            primeraOp = false;

                        }
                        else
                        {
                            switch (operaciones[i])
                            {
                                case '+':
                                    currentValue = currentValue + numerosOperacion[i + 1];
                                    break;
                                case '-':
                                    currentValue = currentValue - numerosOperacion[i + 1];
                                    break;
                                case '*':
                                    currentValue = currentValue * numerosOperacion[i + 1];
                                    break;
                                case '/':
                                    currentValue = currentValue / numerosOperacion[i + 1];
                                    break;
                                default:
                                    //error
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    //no hay operaciones  -> error
                }


                Console.WriteLine(currentValue);
            }
        }
        public static int Sumar(int numUno, int numDos)
        {
            return numUno + numDos;
        }

        public static int Restar(int numUno, int numDos)
        {
            return numDos - numUno;
        }

        public static int Multiplicar(int numUno, int numDos)
        {
            return numDos * numUno;
        }

        public static int Dividir(int numUno, int numDos)
        {
            return numDos / numUno;
        }
    }
}

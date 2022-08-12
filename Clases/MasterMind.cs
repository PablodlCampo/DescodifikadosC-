using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoConsola.Clases
{
    public class MasterMind
    {

        public void Ejecutar()
        {
            //string fraseOculta = CrearFraseAleatoria();
            char[] fraseOculta = CrearFraseOculta();

            //Console.WriteLine(fraseOculta[0].ToString() + fraseOculta[1].ToString() + fraseOculta[2].ToString() + fraseOculta[3].ToString());


            int rondasRestantes = 15;
            bool hasGanado = false;

            while (rondasRestantes > 0)
            {
                Console.WriteLine("Introduce una frase de 4 letras");

                string fraseIntroducida = Console.ReadLine().ToLowerInvariant();

                if (fraseIntroducida.Length == 4)
                {
                    //0- Asignar frase exterior al modelo con el que trabajar(es importante mantener una variable inmutable ya que fraseModelo se va a modificar cada vuelta)
                    char[] fraseModelo = (char[])fraseOculta.Clone();
                    char[] fraseIntroducidaArray = fraseIntroducida.ToCharArray();

                    int numContains = 0;
                    int numPos = 0;


                    //1- Comprobacion de posición coincidente
                    for (int i = 0; i < fraseModelo.Length; i++)
                    {
                        if (fraseModelo[i] == fraseIntroducidaArray[i])
                        {
                            char letra = fraseIntroducidaArray[i];
                            //Se borran los valores coincidenteus en los dos arrays para que no influyan en el paso 2
                            fraseIntroducidaArray[i] = Char.MinValue;
                            fraseModelo[i] = Char.MinValue;
                            numPos++;
                        }
                    }

                    //2- Comprobacion de contains
                    foreach (var caracter in fraseIntroducidaArray)
                    {
                        var exist = fraseModelo.FirstOrDefault(m => m.Equals(caracter));


                        if (exist != 0)
                        {
                            //Se borra el valor que coincide en el modelo para evitar que se 
                            //exist = Char.MinValue; esto no funciona

                            var index = Array.IndexOf(fraseModelo, exist);

                            fraseModelo[index] = Char.MinValue;
                            numContains++;
                        }
                    }

                    //3- Restamos una ronda
                    rondasRestantes--;

                    //Comprobar victoria

                    if (numPos == 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("ENHORABUENA HAS GANADO. La combinacion era: " + fraseOculta[0].ToString() + fraseOculta[1].ToString() + fraseOculta[2].ToString() + fraseOculta[3].ToString());
                        hasGanado = true;
                        break;
                    }

                    //4- Mostrar respuesta
                    MostrarRespuesta(rondasRestantes, numContains, numPos);
                }
                else
                {
                    Console.WriteLine("Número de carácteres incorrecto");
                    Console.WriteLine("\n\r");
                }

            }

            if (!hasGanado)
            {
                Console.WriteLine("Se te han acabado las oportunidades. La combinacion era: " + fraseOculta[0].ToString() + fraseOculta[1].ToString() + fraseOculta[2].ToString() + fraseOculta[3].ToString());
            }
        }

        private static void MostrarRespuesta(int rondasRestantes, int numContains, int numPos)
        {
            for (int i = 0; i < numPos; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(".");
            }

            for (int i = 0; i < numContains; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(".");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n\r");

            Console.WriteLine("Rondas restantes: " + rondasRestantes);
            Console.WriteLine("\n\r");
        }

        public static char[] CrearFraseOculta()
        {
            char[] respuesta = new char[4];

            char[] abecedario = new[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'ñ', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

            int posicionLetraUno = new Random().Next(0, 26);
            int posicionLetraDos = new Random().Next(0, 26);
            int posicionLetraTres = new Random().Next(0, 26);
            int posicionLetraCuatro = new Random().Next(0, 26);

            respuesta[0] = abecedario[posicionLetraUno];
            respuesta[1] = abecedario[posicionLetraDos];
            respuesta[2] = abecedario[posicionLetraTres];
            respuesta[3] = abecedario[posicionLetraCuatro];

            return respuesta;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoConsola.Clases
{
    public class Kaprekar
    {
        public void Calcular()
        {
            Console.WriteLine("Introduce un número de 4 dígitos");
            string numeroString = Console.ReadLine();


            if (numeroString.Length != 4)
            {
                Console.WriteLine("Este número no tiene 4 dígitos");
            }
            else
            {
                Int32.TryParse(numeroString, out int numeroExterior);

                if (numeroExterior != 0)
                {
                    int[] digitos = new int[4];

                    digitos = DescomponerNum(numeroString);

                    if (NumeroCorrecto(digitos[0], digitos[1], digitos[2], digitos[3]))
                    {
                        var ordenados = (int[])OrdenarNum(digitos, false).Clone();
                        var ordenadosDos = (int[])OrdenarNum(digitos, true).Clone();

                        Console.WriteLine(ordenados[0].ToString() + ordenados[1].ToString() + ordenados[2].ToString() + ordenados[3].ToString());
                        Console.WriteLine(ordenadosDos[0].ToString() + ordenadosDos[1].ToString() + ordenadosDos[2].ToString() + ordenadosDos[3].ToString());
                    }
                }
            }
        }

        public static int[] OrdenarNum(int[] digitos, bool desc)
        {
            int temp;

            if (desc)
            {
                for (int i = 0; i < digitos.Length - 1; i++)
                {
                    for (int x = i + 1; x < digitos.Length; x++)
                    {
                        if (digitos[i] < digitos[x])
                        {
                            temp = digitos[i];
                            digitos[i] = digitos[x];
                            digitos[x] = temp;
                        }
                    }
                }
            }
            else
            {

                //8912
                for (int i = digitos.Length - 1; i >= 0; i--)
                {
                    for (int x = i - 1; x >= 0; x--)
                    {
                        if (digitos[x] > digitos[i])
                        {
                            temp = digitos[x];
                            digitos[x] = digitos[i];
                            digitos[i] = temp;
                        }
                    }
                }
            }

            return digitos;
        }

        public static int[] DescomponerNum(string numeroString)
        {
            int[] digitos = new int[4];

            //Descomposición matemática
            //miles = numeroExterior / 1000;
            //centenas = (numeroExterior / 100) % 10;
            //decenas = (numeroExterior % 100) / 10;
            //unidades = (numeroExterior % 100) % 10;

            //descomposicion string
            digitos[0] = Int32.Parse(numeroString[0].ToString());
            digitos[1] = Int32.Parse(numeroString[1].ToString());
            digitos[2] = Int32.Parse(numeroString[2].ToString());
            digitos[3] = Int32.Parse(numeroString[3].ToString());

            return digitos;

        }

        public static bool NumeroCorrecto(int miles, int centenas, int decenas, int unidades)
        {
            bool reponse = true;

            if (miles == centenas && miles == decenas)
            {
                return false;
            }

            if (miles == centenas && miles == unidades)
            {
                return false;
            }

            if (miles == decenas && miles == unidades)
            {
                return false;
            }

            if (centenas == decenas && centenas == unidades)
            {
                return false;
            }

            return reponse;
        }


    }
}

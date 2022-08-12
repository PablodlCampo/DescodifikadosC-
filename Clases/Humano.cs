using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoConsola.Clases
{
    public class Humano
    {
        public Humano(int Altura, int Edad, string Nombre)
        {
            this.Altura = Altura;
            this.Edad = Edad;
            this.Nombre = Nombre;
        }

        public Humano()
        {
            this.Altura = 175;
            this.Edad = 20;
            this.Nombre = "Humano";
        }

        //cm
        private int Altura { get; set; }

        //años
        private int Edad { get; set; }

        private string Nombre { get; set; }


        public int GetAltura()
        {
            return this.Altura;
        }

        public string GetNombre()
        {
            return this.Nombre;
        }

        public int GetAños()
        {
            return this.Edad;
        }


        public void CumplirAños()
        {
            this.Edad++;

            if (this.Edad <= 18)
            {
                Crecer();
            }

            Console.WriteLine(string.Format("{0} a cumplido {1} años", this.Nombre, this.Edad));
        }

        public void Crecer()
        {
            this.Altura = this.Altura + 2;
        }

        public void CambiarNombre(string nuevoNombre)
        {
            this.Nombre = nuevoNombre;
        }
    }
}

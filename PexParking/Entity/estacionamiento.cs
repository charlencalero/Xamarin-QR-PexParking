using System;
namespace PexParking.Entity
{
    public class estacionamiento
    {
        public estacionamiento()
        {
        }

        public estacionamiento(string codigo, string numero, string pasillo, string nivel, string imagen)
        {
            this.codigo = codigo;
            this.numero = numero;
            this.pasillo = pasillo;
            this.nivel = nivel;
            this.imagen = imagen;
        }

        public string codigo { get; set; }
        public string numero { get; set; }
        public string pasillo { get; set; }
        public string nivel { get; set; }
        public string imagen { get; set; }

    }
}

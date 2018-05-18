using System;
namespace PexParking.Entity
{
    public class parkeo
    {
        public parkeo()
        {
        }

        public parkeo(string piso, string ubicacion, string placa, string celular, string horalectura, string horaalerta,string codigo,string pasillo,string imagen)
        {
            this.piso = piso;
            this.ubicacion = ubicacion;
            this.placa = placa;
            this.celular = celular;
            this.horalectura = horalectura;
            this.horaalerta = horaalerta;
            this.codigo = codigo;
            this.pasillo = pasillo;
            this.imagen = imagen;
        }

        public string codigo { get; set; }
        public string piso { get; set; }
        public string ubicacion {get;set; }
        public string placa { get; set; }
        public string celular {get;set; }
        public string horalectura { get; set; }
        public string horaalerta { get; set; }
        public string pasillo { get; set; }
        public string imagen { get; set; }

    }
}

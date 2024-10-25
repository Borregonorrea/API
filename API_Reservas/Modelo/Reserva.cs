namespace API_Reservas.Modelo
{
    public class Reserva
    {
        public int ID { get; set; }
        public string cliente { get; set; }
        public DateTime fecha_reserva { get; set; }
        public int numero_personas { get; set; }
        public string estado { get; set; } // Confirmada, Pendiente, Cancelada

        public Reserva(int iD, string cliente, DateTime fecha_reserva, int numero_personas, string estado)
        {
            ID = iD;
            this.cliente = cliente;
            this.fecha_reserva = fecha_reserva;
            this.numero_personas = numero_personas;
            this.estado = estado;
        }

        public bool ValidarEstado()
        {
            string[] estados_validos = { "Confirmada", "Pendiente", "Cancelada" };
            return Array.Exists(estados_validos, estado => estado == this.estado);

        }

        public bool ValidarNumeroPersonas()
        {
            return numero_personas > 0 && numero_personas <= 20;
        }


    }
}

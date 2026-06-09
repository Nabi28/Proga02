using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs
{
    public class BloqueoMesaDto
    {
        public int MesaId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Motivo { get; set; } = string.Empty;
    }
}

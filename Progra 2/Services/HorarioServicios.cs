using DATA;
using Entities;
using Services.Interfaces;

namespace Services
{
    public class HorarioServicios : IHorario
    {
        private readonly RestauranteDbContext _RestauranteDbContext;
        public HorarioServicios(RestauranteDbContext resturanteDbContext)
        {
            _RestauranteDbContext = resturanteDbContext;
        }

        public List<Horario> GetAllHorario()
        {
            return _RestauranteDbContext.Horarios.ToList();
        }

        public Horario GetHorarioById(int id)
        {
            var result = _RestauranteDbContext.Horarios.Find(id);
            if (result == null)
                throw new Exception("Horario no encontrado");
            return result;
        }


        public string ValidarHorario(DateTime fecha, int horarioId)
        {
            var horario = _RestauranteDbContext.Horarios.Find(horarioId);
            if (horario == null) return "Horario no encontrado";

            // Mapear día en inglés a español
            var diasEspanol = new Dictionary<DayOfWeek, string>
    {
        { DayOfWeek.Monday, "Lunes" },
        { DayOfWeek.Tuesday, "Martes" },
        { DayOfWeek.Wednesday, "Miércoles" },
        { DayOfWeek.Thursday, "Jueves" },
        { DayOfWeek.Friday, "Viernes" },
        { DayOfWeek.Saturday, "Sábado" },
        { DayOfWeek.Sunday, "Domingo" }
    };

            var diaSemana = diasEspanol[fecha.DayOfWeek];

            // Verificar si el día está dentro del rango del horario
            bool diaValido = false;

            if (horario.DiaSemana == "Lunes a Viernes")
            {
                diaValido = fecha.DayOfWeek >= DayOfWeek.Monday && fecha.DayOfWeek <= DayOfWeek.Friday;
            }
            else if (horario.DiaSemana == "Lunes a Domingo")
            {
                diaValido = true; // todos los días
            }
            else if (horario.DiaSemana == "Lunes a Sábado")
            {
                diaValido = fecha.DayOfWeek != DayOfWeek.Sunday;
            }
            else
            {
                // Día específico (ej: "Sábado")
                diaValido = horario.DiaSemana == diaSemana;
            }

            if (!diaValido) return "El horario no es válido para el día seleccionado";

            var horaActual = TimeOnly.FromDateTime(fecha);
            if (horaActual < horario.HoraInicio || horaActual > horario.HoraFin)
            {
                return "El horario no es válido para la hora seleccionada";
            }

            return "Horario válido";

        }
    }
}

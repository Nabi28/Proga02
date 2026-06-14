using Entities;
namespace Services.Interfaces
{
    public interface IHorario
    {

        public List<Horario> GetAllHorario();
        public Horario GetHorarioById(int id);
        public string ValidarHorario(DateTime fecha, int horarioId);
    }
}

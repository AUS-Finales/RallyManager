using System;
using System.Collections.Generic;
using System.Text;

using RallyManager.Domain.Enums;

namespace RallyManager.Domain.Participacion;

public class ParticipacionTramo
{
    public int Id { get; set; }
    public int PruebaEspecialId { get; set; }
    public int InscripcionId { get; set; }
    public TimeSpan? HoraSalida { get; set; }
    public TimeSpan? HoraLlegada { get; set; }
    public TimeSpan? TiempoEmpleado { get; set; }
    public EstadoParticipacion Estado { get; set; }
}

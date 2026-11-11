using System;
using System.Collections.Generic;
using System.Text;

using RallyManager.Domain.Enums;

namespace RallyManager.Domain.Participacion;

public class Penalizacion
{
    public int Id { get; set; }
    public int ParticipacionTramoId { get; set; }
    public string Motivo { get; set; } = string.Empty;
    public TimeSpan TiempoPenalizacion { get; set; }
    public EstadoPenalizacion Estado { get; set; }
    public int PropuestoPorUsuarioId { get; set; }
    public int? AprobadoPorUsuarioId { get; set; }
    public DateTime FechaPropuesta { get; set; }
    public DateTime? FechaResolucion { get; set; }
}

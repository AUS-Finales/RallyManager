using System;
using System.Collections.Generic;
using System.Text;

using RallyManager.Domain.Enums;

namespace RallyManager.Domain.Participacion;

public class Inscripcion
{
    public int Id { get; set; }
    public int CarreraId { get; set; }
    public int TripulacionId { get; set; }
    public int CategoriaId { get; set; }
    public DateTime FechaInscripcion { get; set; }
    public EstadoInscripcion Estado { get; set; }
    public bool AproboVerificacionTecnica { get; set; }
}

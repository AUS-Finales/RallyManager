using System;
using System.Collections.Generic;
using System.Text;

namespace RallyManager.Domain.Campeonato;

public class Carrera
{
    public int Id { get; set; }
    public int CampeonatoId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public string Localidad { get; set; } = string.Empty;
}

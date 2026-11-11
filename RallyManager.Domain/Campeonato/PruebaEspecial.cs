using System;
using System.Collections.Generic;
using System.Text;

namespace RallyManager.Domain.Campeonato;

public class PruebaEspecial
{
    public int Id { get; set; }
    public int EtapaId { get; set; }
    public int Numero { get; set; }
    public decimal DistanciaKm { get; set; }
    public TimeSpan HoraInicioProgramada { get; set; }
}

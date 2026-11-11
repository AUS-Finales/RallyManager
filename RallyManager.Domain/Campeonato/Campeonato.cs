using System;
using System.Collections.Generic;
using System.Text;

namespace RallyManager.Domain.Campeonato;

public class Campeonato
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public int Temporada { get; set; }
    public string Provincia { get; set; } = string.Empty;
    public string Pais { get; set; } = string.Empty;
}
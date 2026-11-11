using System;
using System.Collections.Generic;
using System.Text;

namespace RallyManager.Domain.Campeonato;

public class Etapa
{
    public int Id { get; set; }
    public int CarreraId { get; set; }
    public int Numero { get; set; }
    public DateTime Fecha { get; set; }
}
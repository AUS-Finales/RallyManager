using System;
using System.Collections.Generic;
using System.Text;

using RallyManager.Domain.Enums;

namespace RallyManager.Domain.Operacion;

public class Incidencia
{
    public int Id { get; set; }
    public int ParticipacionTramoId { get; set; }
    public int UsuarioReportaId { get; set; }
    public TipoIncidencia Tipo { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public decimal Latitud { get; set; }
    public decimal Longitud { get; set; }
    public DateTime FechaHora { get; set; }
    public EstadoIncidencia Estado { get; set; }
}

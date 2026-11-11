using System;
using System.Collections.Generic;
using System.Text;

namespace RallyManager.Domain.Participacion;

public class Tripulacion
{
    public int Id { get; set; }
    public int VehiculoId { get; set; }
    public string NombrePiloto { get; set; } = string.Empty;
    public string DocumentoPiloto { get; set; } = string.Empty;
    public string SexoPiloto { get; set; } = string.Empty;
    public string TipoSanguineoPiloto { get; set; } = string.Empty;
    public string NombreNavegante { get; set; } = string.Empty;
    public string DocumentoNavegante { get; set; } = string.Empty;
    public string SexoNavegante { get; set; } = string.Empty;
    public string TipoSanguineoNavegante { get; set; } = string.Empty;
}

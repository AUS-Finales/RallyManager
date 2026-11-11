using System;
using System.Collections.Generic;
using System.Text;

namespace RallyManager.Domain.Catalogo;

public class Vehiculo
{
    public int Id { get; set; }
    public string Marca { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public string Patente { get; set; } = string.Empty;
}

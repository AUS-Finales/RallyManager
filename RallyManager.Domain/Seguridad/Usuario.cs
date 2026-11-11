using System;
using System.Collections.Generic;
using System.Text;

using RallyManager.Domain.Enums;

namespace RallyManager.Domain.Seguridad;

public class Usuario
{
    public int Id { get; set; }
    public int? TripulacionId { get; set; }
    public string NombreUsuario { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public RolUsuario Rol { get; set; }
    public bool Activo { get; set; }
}

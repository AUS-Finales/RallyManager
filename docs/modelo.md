# Modelo de RallyManager

Documento de referencia del modelo de dominio. Se divide en dos partes:

1. **DER de persistencia**: tablas que se guardan en la base de datos.
2. **Cadena de cálculo**: datos derivados que NO se persisten y se calculan en la capa Application.

## 1. DER de persistencia

Solo entidades persistidas, con sus claves foráneas reales.

```mermaid
erDiagram
    CAMPEONATO {
        int Id PK
        string Nombre
        int Temporada
        string Provincia
        string Pais
    }
    CARRERA {
        int Id PK
        int CampeonatoId FK
        string Nombre
        date FechaInicio
        date FechaFin
        string Localidad
    }
    ETAPA {
        int Id PK
        int CarreraId FK
        int Numero
        date Fecha
    }
    PRUEBA_ESPECIAL {
        int Id PK
        int EtapaId FK
        int Numero
        decimal DistanciaKm
        time HoraInicioProgramada
    }
    CATEGORIA {
        int Id PK
        string Nombre
        string Descripcion
    }
    VEHICULO {
        int Id PK
        string Marca
        string Modelo
        string Patente
    }
    TRIPULACION {
        int Id PK
        int VehiculoId FK
        string NombrePiloto
        string DocumentoPiloto
        string SexoPiloto
        string TipoSanguineoPiloto
        string NombreNavegante
        string DocumentoNavegante
        string SexoNavegante
        string TipoSanguineoNavegante
    }
    INSCRIPCION {
        int Id PK
        int CarreraId FK
        int TripulacionId FK
        int CategoriaId FK
        datetime FechaInscripcion
        string Estado
        bool AproboVerificacionTecnica
    }
    PARTICIPACION_TRAMO {
        int Id PK
        int PruebaEspecialId FK
        int InscripcionId FK
        time HoraSalida
        time HoraLlegada
        time TiempoEmpleado
        string Estado
    }
    PENALIZACION {
        int Id PK
        int ParticipacionTramoId FK
        string Motivo
        time TiempoPenalizacion
        string Estado
        int PropuestoPorUsuarioId FK
        int AprobadoPorUsuarioId FK
        datetime FechaPropuesta
        datetime FechaResolucion
    }
    USUARIO {
        int Id PK
        int TripulacionId FK
        string NombreUsuario
        string PasswordHash
        string Rol
        bool Activo
    }
    INCIDENCIA {
        int Id PK
        int ParticipacionTramoId FK
        int UsuarioReportaId FK
        string Tipo
        string Descripcion
        decimal Latitud
        decimal Longitud
        datetime FechaHora
        string Estado
    }

    CAMPEONATO ||--o{ CARRERA : "contiene"
    CARRERA ||--o{ ETAPA : "contiene"
    ETAPA ||--o{ PRUEBA_ESPECIAL : "contiene"
    CARRERA ||--o{ INSCRIPCION : "recibe"
    TRIPULACION ||--o{ INSCRIPCION : "se inscribe"
    CATEGORIA ||--o{ INSCRIPCION : "clasifica"
    VEHICULO ||--|| TRIPULACION : "es usado por"
    INSCRIPCION ||--o{ PARTICIPACION_TRAMO : "participa en"
    PRUEBA_ESPECIAL ||--o{ PARTICIPACION_TRAMO : "registra tiempos"
    PARTICIPACION_TRAMO ||--o{ PENALIZACION : "recibe"
    USUARIO }o--o| TRIPULACION : "pertenece a"
    USUARIO ||--o{ PENALIZACION : "propone"
    USUARIO ||--o{ PENALIZACION : "aprueba"
    USUARIO ||--o{ INCIDENCIA : "reporta"
    PARTICIPACION_TRAMO ||--o{ INCIDENCIA : "genera"
```

## 2. Cadena de calculo (datos derivados)

Las entidades de esta cadena **no se persisten**. Se calculan en la capa Application a partir de los datos persistidos.

- `TiempoFinal`: suma de `TiempoEmpleado` + penalizaciones **aprobadas**, por inscripción y carrera.
- `PosicionCategoria`: orden de `TiempoFinal` dentro de la categoría, por carrera.
- `Puntaje`: puntos por participación, tramos completados, bonus y posición, por inscripción y carrera.
- `ClasificacionCampeonato`: suma de `Puntaje` de todas las carreras, por inscripción y categoría.

```mermaid
flowchart TD
    PT["ParticipacionTramo<br/>TiempoEmpleado por tramo"]
    PEN["Penalizacion<br/>solo Estado = Aprobada"]
    INS["Inscripcion<br/>CategoriaId y Estado"]
    TOT["Total de tramos<br/>de la carrera"]

    TF["TiempoFinal<br/>= suma TiempoEmpleado<br/>+ suma TiempoPenalizacion aprobadas"]
    ORD["Ordenar por TiempoFinal<br/>dentro de la categoria"]
    POS["PosicionCategoria<br/>1ro, 2do, 3ro..."]
    PTS["Puntaje<br/>+2 presentacion<br/>+1 por tramo completado<br/>+3 si completo todos<br/>+15/10/7 segun PosicionCategoria"]
    CC["ClasificacionCampeonato<br/>= suma de Puntaje<br/>de todas las carreras<br/>por inscripcion y categoria"]

    PT -->|"suma tiempos"| TF
    PEN -->|"suma penalizaciones aprobadas"| TF
    TF --> ORD
    ORD --> POS
    POS -->|"define puntos de posicion"| PTS
    INS -->|"presentacion"| PTS
    PT -->|"tramos completados"| PTS
    TOT -->|"bonus si completo todos"| PTS
    PTS -->|"acumula"| CC
```

## 3. Reglas de puntaje

| Concepto | Puntos |
|---|---|
| Presentacion a la carrera | 2 |
| Por tramo completado | 1 |
| Bonus por completar todos los tramos | 3 |
| 1er puesto de categoria | 15 |
| 2do puesto de categoria | 10 |
| 3er puesto de categoria | 7 |

Criterios:
- Un abandono suma presentacion y los tramos completados, pero no el bonus.
- Los puntos de posicion solo se otorgan a quien completo al menos un tramo.
- La tabla de puntos es configurable (capa Application), no esta hardcodeada en las entidades.
# ReservationHappiness API

Sistema de gestión de reservaciones desarrollado con ASP.NET Core 6.0 siguiendo la arquitectura Clean Architecture y patrones CQRS.

## Autor

**MSc. Salvador Cuevas**

## Descripción

ReservationHappiness API es una aplicación backend robusta para la gestión de reservaciones de restaurantes. El sistema permite crear, consultar, actualizar y eliminar reservaciones, proporcionando una API RESTful completa.

## Arquitectura

El proyecto está estructurado en las siguientes capas:

### Capas de la Aplicación

- **Banreservas.ReservationHapiness.API**: Capa de presentación que expone los endpoints REST
- **Banreservas.ReservationHapiness.Application**: Lógica de aplicación con CQRS (Commands y Queries)
- **Banreservas.ReservationHapiness.Domain**: Entidades del dominio y lógica de negocio
- **Banreservas.ReservationHapiness.Infrastructure**: Servicios de infraestructura (Email, etc.)
- **Banreservas.ReservationHapiness.Persistence**: Acceso a datos con Entity Framework Core
- **Banreservas.ReservationHapiness.Common**: Utilidades compartidas

### Proyectos de Pruebas

- **Banreservas.ReservationHapiness.Application.UnitTests**: Pruebas unitarias de la capa de aplicación
- **Banreservas.ReservationHapiness.API.IntegrationTests**: Pruebas de integración
- **Banreservas.ReservationHapiness.Persistence.IntegrationTests**: Pruebas de la capa de persistencia

## Tecnologías Utilizadas

- **.NET 6.0**
- **ASP.NET Core Web API**
- **Entity Framework Core** - ORM para acceso a datos
- **MediatR** - Implementación de patrón Mediator para CQRS
- **AutoMapper** - Mapeo de objetos
- **FluentValidation** - Validación de comandos y queries
- **Serilog** - Logging estructurado
- **Swagger/OpenAPI** - Documentación de API
- **xUnit** - Framework de pruebas unitarias
- **Moq** - Framework de mocking para pruebas

## Características Principales

### Gestión de Reservaciones

- **Crear Reservación**: Permite crear nuevas reservaciones con información del cliente
- **Consultar Reservaciones**: Obtener lista completa de reservaciones o por ID
- **Actualizar Reservación**: Modificar detalles de reservaciones existentes
- **Eliminar Reservación**: Eliminar reservaciones del sistema
- **Estados de Reservación**: Pending, Confirmed, Cancelled, Completed, NoShow

### Modelo de Datos - Reservación

```csharp
public class Reservation
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public string CustomerEmail { get; set; }
    public string? CustomerPhone { get; set; }
    public DateTime ReservationDate { get; set; }
    public TimeSpan ReservationTime { get; set; }
    public int NumberOfGuests { get; set; }
    public string? SpecialRequests { get; set; }
    public ReservationStatus Status { get; set; }
}
```

## Configuración

### Requisitos Previos

- .NET 6.0 SDK o superior
- SQL Server (LocalDB o instancia completa)
- Visual Studio 2022 / Visual Studio Code / Rider

### Configuración de Base de Datos

Actualizar el connection string en `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "ReservationHappinessConnectionString": "Server=(localdb)\\mssqllocaldb;Database=ReservationHappiness;Trusted_Connection=True;"
  }
}
```

### Migraciones

Ejecutar las migraciones de Entity Framework Core:

```bash
cd Banreservas.ReservationHapiness.Persistence
dotnet ef migrations add InitialCreate --startup-project ../Banreservas.ReservationHapiness.API
dotnet ef database update --startup-project ../Banreservas.ReservationHapiness.API
```

## Ejecución

### Iniciar la API

```bash
cd Banreservas.ReservationHapiness.API
dotnet run
```

La API estará disponible en:
- HTTPS: `https://localhost:5001`
- HTTP: `http://localhost:5000`

### Documentación Swagger

Acceder a la documentación interactiva de la API:
- `https://localhost:5001/swagger`

## Endpoints Principales

### Reservaciones

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| GET | `/api/Reservations` | Obtener todas las reservaciones |
| GET | `/api/Reservations/{id}` | Obtener reservación por ID |
| POST | `/api/Reservations` | Crear nueva reservación |
| PUT | `/api/Reservations/{id}` | Actualizar reservación |
| DELETE | `/api/Reservations/{id}` | Eliminar reservación |

### Ejemplo de Request - Crear Reservación

```json
{
  "customerName": "Juan Pérez",
  "customerEmail": "juan.perez@example.com",
  "customerPhone": "809-555-1234",
  "reservationDate": "2025-10-15",
  "reservationTime": "19:30:00",
  "numberOfGuests": 4,
  "specialRequests": "Mesa cerca de la ventana"
}
```

## Pruebas

### Ejecutar Pruebas Unitarias

```bash
dotnet test Banreservas.ReservationHapiness.Application.UnitTests
```

### Ejecutar Pruebas de Integración

```bash
dotnet test Banreservas.ReservationHapiness.API.IntegrationTests
dotnet test Banreservas.ReservationHapiness.Persistence.IntegrationTests
```

### Ejecutar Todas las Pruebas

```bash
dotnet test
```

## Cobertura de Pruebas

El proyecto incluye pruebas unitarias completas para:

- **Commands**: CreateReservation, UpdateReservation, DeleteReservation
- **Queries**: GetAllReservations, GetReservationById
- **Repositories**: Mock de repositorios para pruebas aisladas
- **Validadores**: Validación de comandos con FluentValidation

## Estructura de Directorios

```
Back/
├── Banreservas.ReservationHapiness.API/
│   ├── Controllers/
│   │   └── ReservationsController.cs
│   ├── Middleware/
│   └── Program.cs
├── Banreservas.ReservationHapiness.Application/
│   ├── Features/
│   │   └── Reservations/
│   │       ├── Commands/
│   │       ├── Queries/
│   │       ├── DTOs/
│   │       └── Mappings/
│   └── Interfaces/
├── Banreservas.ReservationHapiness.Domain/
│   ├── Entities/
│   │   └── Reservation.cs
│   └── Common/
├── Banreservas.ReservationHapiness.Infrastructure/
├── Banreservas.ReservationHapiness.Persistence/
│   ├── Repositories/
│   ├── Configurations/
│   └── ReservationHapinessDbContext.cs
└── Tests/
    ├── Application.UnitTests/
    ├── API.IntegrationTests/
    └── Persistence.IntegrationTests/
```

## Patrones y Prácticas Implementadas

- **Clean Architecture**: Separación de responsabilidades en capas
- **CQRS**: Separación de comandos y consultas
- **Repository Pattern**: Abstracción de acceso a datos
- **Mediator Pattern**: Desacoplamiento de componentes con MediatR
- **Dependency Injection**: Inversión de control
- **Unit of Work**: Gestión de transacciones
- **DTO Pattern**: Transferencia de datos entre capas
- **Validation**: Validación centralizada con FluentValidation

## Manejo de Errores

La API incluye middleware personalizado para manejo de excepciones:
- **ValidationException**: 400 Bad Request
- **NotFoundException**: 404 Not Found
- **Exception**: 500 Internal Server Error

## Logging

Sistema de logging estructurado con Serilog que registra:
- Requests HTTP
- Excepciones
- Operaciones de base de datos
- Eventos de aplicación

## CORS

La API está configurada con CORS abierto para desarrollo. En producción, se recomienda configurar orígenes específicos.

## Seguridad

> **Nota**: Las funcionalidades de autenticación y autorización fueron removidas de esta versión. Para uso en producción, se recomienda implementar:
> - Autenticación JWT
> - Autorización basada en roles
> - Rate limiting
> - HTTPS obligatorio

## Contribuciones

Este proyecto fue desarrollado como parte de una prueba técnica.

## Licencia

Todos los derechos reservados © 2025 MSc. Salvador Cuevas

## Contacto

Para consultas o soporte, contactar al autor: **MSc. Salvador Cuevas**

---

**Versión**: 1.0.0
**Última Actualización**: Octubre 2025
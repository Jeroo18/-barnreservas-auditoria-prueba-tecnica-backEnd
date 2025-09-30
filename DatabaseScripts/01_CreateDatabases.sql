-- =====================================================
-- Script de Creación de Base de Datos
-- Sistema de Reservas de Restaurante - Banreservas
-- =====================================================

-- Crear base de datos principal
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'ReservationHappinessDB')
BEGIN
    CREATE DATABASE ReservationHappinessDB;
    PRINT 'Base de datos ReservationHappinessDB creada exitosamente'
END
ELSE
BEGIN
    PRINT 'La base de datos ReservationHappinessDB ya existe'
END
GO

-- Crear base de datos de identidad
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'ReservationHappinessIdentityDB')
BEGIN
    CREATE DATABASE ReservationHappinessIdentityDB;
    PRINT 'Base de datos ReservationHappinessIdentityDB creada exitosamente'
END
ELSE
BEGIN
    PRINT 'La base de datos ReservationHappinessIdentityDB ya existe'
END
GO

-- Usar base de datos principal
USE ReservationHappinessDB;
GO

-- Crear tabla de Reservas
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reservations]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Reservations] (
        [Id] INT IDENTITY(1,1) PRIMARY KEY,
        [CustomerName] NVARCHAR(100) NOT NULL,
        [CustomerEmail] NVARCHAR(100) NOT NULL,
        [CustomerPhone] NVARCHAR(20) NULL,
        [ReservationDate] DATETIME2 NOT NULL,
        [ReservationTime] TIME NOT NULL,
        [NumberOfGuests] INT NOT NULL,
        [SpecialRequests] NVARCHAR(500) NULL,
        [Status] INT NOT NULL DEFAULT 0, -- 0=Pending, 1=Confirmed, 2=Cancelled, 3=Completed, 4=NoShow
        [CreatedBy] NVARCHAR(100) NULL,
        [CreatedDate] DATETIME2 NOT NULL DEFAULT GETDATE(),
        [LastModifiedBy] NVARCHAR(100) NULL,
        [LastModifiedDate] DATETIME2 NULL,
        CONSTRAINT [CK_Reservations_NumberOfGuests] CHECK ([NumberOfGuests] >= 1 AND [NumberOfGuests] <= 20),
        CONSTRAINT [CK_Reservations_Status] CHECK ([Status] >= 0 AND [Status] <= 4)
    );

    PRINT 'Tabla Reservations creada exitosamente'

    -- Crear índices para mejorar el rendimiento
    CREATE INDEX [IX_Reservations_ReservationDate] ON [dbo].[Reservations]([ReservationDate]);
    CREATE INDEX [IX_Reservations_CustomerEmail] ON [dbo].[Reservations]([CustomerEmail]);
    CREATE INDEX [IX_Reservations_Status] ON [dbo].[Reservations]([Status]);

    PRINT 'Índices creados exitosamente'
END
ELSE
BEGIN
    PRINT 'La tabla Reservations ya existe'
END
GO

-- Insertar datos de ejemplo (opcional)
IF NOT EXISTS (SELECT * FROM [dbo].[Reservations])
BEGIN
    INSERT INTO [dbo].[Reservations]
        ([CustomerName], [CustomerEmail], [CustomerPhone], [ReservationDate], [ReservationTime], [NumberOfGuests], [SpecialRequests], [Status], [CreatedDate])
    VALUES
        ('Juan Pérez', 'juan.perez@email.com', '809-555-0001', '2025-02-15', '19:00:00', 4, 'Mesa cerca de la ventana', 0, GETDATE()),
        ('María García', 'maria.garcia@email.com', '809-555-0002', '2025-02-15', '20:00:00', 2, 'Aniversario - Decoración especial', 1, GETDATE()),
        ('Carlos Rodríguez', 'carlos.rodriguez@email.com', '809-555-0003', '2025-02-16', '18:30:00', 6, 'Sillas para niños', 0, GETDATE()),
        ('Ana Martínez', 'ana.martinez@email.com', '809-555-0004', '2025-02-16', '21:00:00', 2, NULL, 1, GETDATE()),
        ('Luis Fernández', 'luis.fernandez@email.com', '809-555-0005', '2025-02-17', '19:30:00', 8, 'Cena de empresa', 0, GETDATE());

    PRINT 'Datos de ejemplo insertados: 5 reservas'
END
GO

PRINT '=====================================================';
PRINT 'Script completado exitosamente';
PRINT 'Base de datos: ReservationHappinessDB';
PRINT 'Tablas creadas: Reservations';
PRINT '=====================================================';
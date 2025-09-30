-- =====================================================
-- Script de Creación de Tablas de Identidad
-- Sistema de Reservas de Restaurante - Banreservas
-- =====================================================

USE ReservationHappinessIdentityDB;
GO

-- Ejecutar este script DESPUÉS de ejecutar las migraciones de Identity
-- O bien, las migraciones de Entity Framework Identity crearán estas tablas automáticamente

-- Usuario por defecto será creado mediante el seed en el código
-- Email: admin@banreservas.com
-- Password: Admin@123456

PRINT '=====================================================';
PRINT 'Las tablas de Identity se crean automáticamente';
PRINT 'mediante Entity Framework Core Migrations';
PRINT '';
PRINT 'Para crear las migraciones, ejecutar desde la carpeta API:';
PRINT 'dotnet ef migrations add InitialIdentity --project ../Banreservas.ReservationHapiness.Identity --context ReservationHappinessIdentityDbContext';
PRINT 'dotnet ef database update --project ../Banreservas.ReservationHapiness.Identity --context ReservationHappinessIdentityDbContext';
PRINT '=====================================================';
-- Marcar la migración como aplicada sin ejecutarla
USE ReservationHappinessDB;
GO

-- Insertar en el historial de migraciones
IF NOT EXISTS (SELECT * FROM __EFMigrationsHistory WHERE MigrationId = '20250930191814_InitialReservationMigration')
BEGIN
    INSERT INTO __EFMigrationsHistory (MigrationId, ProductVersion)
    VALUES ('20250930191814_InitialReservationMigration', '6.0.10');
    PRINT 'Migración marcada como aplicada';
END
ELSE
BEGIN
    PRINT 'La migración ya está aplicada';
END
GO
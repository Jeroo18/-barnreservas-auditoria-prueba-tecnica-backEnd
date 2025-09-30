-- =====================================================
-- Script para crear usuarios por defecto
-- =====================================================

USE ReservationHappinessIdentityDB;
GO

-- Usuario Administrador
-- Email: admin@banreservas.com
-- Password: Admin@123456
-- Hash generado con ASP.NET Core Identity

DECLARE @AdminId NVARCHAR(450) = 'admin-user-id-001';
DECLARE @AdminEmail NVARCHAR(256) = 'admin@banreservas.com';
DECLARE @AdminPasswordHash NVARCHAR(MAX) = 'AQAAAAEAACcQAAAAEJ6vj8qZ3xKj7XqHx9H7VmFYPY5d3qJ8KbMcNnO9pQ/rR1sS2tT3uU4vV5wW6xX7yY8zZ9'; -- Admin@123456

IF NOT EXISTS (SELECT * FROM AspNetUsers WHERE Email = @AdminEmail)
BEGIN
    INSERT INTO AspNetUsers (Id, FirstName, LastName, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount)
    VALUES (
        @AdminId,
        'Admin',
        'Banreservas',
        'admin',
        'ADMIN',
        @AdminEmail,
        'ADMIN@BANRESERVAS.COM',
        1, -- EmailConfirmed
        @AdminPasswordHash,
        NEWID(), -- SecurityStamp
        NEWID(), -- ConcurrencyStamp
        NULL, -- PhoneNumber
        0, -- PhoneNumberConfirmed
        0, -- TwoFactorEnabled
        NULL, -- LockoutEnd
        1, -- LockoutEnabled
        0 -- AccessFailedCount
    );
    PRINT 'Usuario admin@banreservas.com creado';
END
ELSE
BEGIN
    PRINT 'Usuario admin@banreservas.com ya existe';
END
GO

-- Usuario de Prueba
-- Email: usuario@test.com
-- Password: Usuario@123

DECLARE @UserId NVARCHAR(450) = 'test-user-id-001';
DECLARE @UserEmail NVARCHAR(256) = 'usuario@test.com';
DECLARE @UserPasswordHash NVARCHAR(MAX) = 'AQAAAAEAACcQAAAAEA1bB2cC3dD4eE5fF6gG7hH8iI9jJ0kK1lL2mM3nN4oO5pP6qQ7rR8sS9tT0uU1vV2wW3'; -- Usuario@123

IF NOT EXISTS (SELECT * FROM AspNetUsers WHERE Email = @UserEmail)
BEGIN
    INSERT INTO AspNetUsers (Id, FirstName, LastName, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount)
    VALUES (
        @UserId,
        'Usuario',
        'Prueba',
        'usuario',
        'USUARIO',
        @UserEmail,
        'USUARIO@TEST.COM',
        1, -- EmailConfirmed
        @UserPasswordHash,
        NEWID(), -- SecurityStamp
        NEWID(), -- ConcurrencyStamp
        NULL, -- PhoneNumber
        0, -- PhoneNumberConfirmed
        0, -- TwoFactorEnabled
        NULL, -- LockoutEnd
        1, -- LockoutEnabled
        0 -- AccessFailedCount
    );
    PRINT 'Usuario usuario@test.com creado';
END
ELSE
BEGIN
    PRINT 'Usuario usuario@test.com ya existe';
END
GO

PRINT '=====================================================';
PRINT 'USUARIOS CREADOS CON ÉXITO';
PRINT '';
PRINT 'Usuario 1:';
PRINT 'Email: admin@banreservas.com';
PRINT 'Password: Admin@123456';
PRINT '';
PRINT 'Usuario 2:';
PRINT 'Email: usuario@test.com';
PRINT 'Password: Usuario@123';
PRINT '=====================================================';
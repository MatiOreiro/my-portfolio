use DeviceService;

-- CONSULTAS

-- A - Para todos los productos existentes, mostrar código y descripción, cantidad de
--		reparaciones con control de calidad realizado, cantidad sin control realizado y
--		cantidad de reparaciones cuyo valor fue superior a $100.

SELECT 
    p.IdProd,
    p.DscProd,
    COUNT(DISTINCT u.NumSerie) AS TotalUnidades,
    COUNT(DISTINCT r.NumSerie) AS TotalReparadas,
    COUNT(DISTINCT CASE WHEN r.IdEmpQA IS NULL THEN r.NumSerie END) AS SinControlCalidad,
    COUNT(DISTINCT CASE WHEN r.CostoRepara > 100 THEN r.NumSerie END) AS ReparacionesMayores100
FROM Producto p
LEFT JOIN Unidad u ON p.IdProd = u.IdProd
LEFT JOIN Repara r ON u.NumSerie = r.NumSerie AND u.IdProd = r.IdProd
GROUP BY p.IdProd, p.DscProd
ORDER BY p.IdProd;


-- B - Muestra los datos del Empleado con mayor cantidad de reparaciones realizadas.

SELECT e.*
FROM Empleado e
JOIN (
    SELECT TOP 1 IdEmp
    FROM Repara
    GROUP BY IdEmp
    ORDER BY COUNT(*) DESC
) r ON e.IdEmp = r.IdEmp;

-- C - Muestra datos del producto y costo total de reparaciones por producto,
--		mostrando solo los productos con un costo total superior a $200.

SELECT
 p.IdProd,
 p.Dscprod,
 p.StkProd,
 p.CostoProd,
 SUM(r.CostoRepara) AS CostoTotalReparaciones
FROM Producto p
JOIN Repara r ON p.IdProd = r.IdProd
GROUP BY p.IdProd, p.Dscprod, p.StkProd, p.CostoProd
HAVING SUM(r.CostoRepara) > 200
ORDER BY CostoTotalReparaciones DESC;

-- D - Datos del producto más reparado.

SELECT p.IdProd, p.Dscprod, p.StkProd, p.CostoProd
FROM Producto p
JOIN (
 SELECT TOP 1 IdProd, COUNT(*) AS CantReparaciones
 FROM Repara
 GROUP BY IdProd
 ORDER BY COUNT(*) DESC
) AS rmax ON p.IdProd = rmax.IdProd;

-- E - Escribe una consulta que muestre información detallada de los empleados.
SELECT 
    E.IdEmp,
    E.NomEmp,
    E.FchNacEmp,
    E.SueldoEmp,
    
    -- Clasificación salarial
    CASE 
        WHEN E.SueldoEmp < 30000 THEN 'Bajo'
        WHEN E.SueldoEmp BETWEEN 30000 AND 60000 THEN 'Medio'
        ELSE 'Alto'
    END AS NivelSalarial,
    
    -- Tipo de empleado legible
    CASE 
        WHEN E.TipoEmp = 'T' THEN 'Tiempo Completo'
        ELSE 'Contratado'
    END + ' - ' + 
    CASE 
        WHEN E.SueldoEmp < 30000 THEN 'Junior'
        WHEN E.SueldoEmp BETWEEN 30000 AND 60000 THEN 'Experimentado'
        ELSE 'Senior'
    END AS Categoria,
    
    -- Cantidad de reparaciones realizadas
    COUNT(R.IdRepara) AS CantReparaciones

FROM 
    Empleado E
LEFT JOIN 
    Repara R ON E.IdEmp = R.IdEmp

GROUP BY 
    E.IdEmp, E.NomEmp, E.FchNacEmp, E.SueldoEmp, E.TipoEmp

ORDER BY 
    E.SueldoEmp DESC,
    COUNT(R.IdRepara) DESC;

-- F - Muestra el costo total de reparaciones por empleado y un resumen general.

SELECT 
    ISNULL(E.NomEmp, 'TOTAL GENERAL') AS NombreEmpleado,
    SUM(R.CostoRepara) AS CostoTotalReparaciones
FROM 
    Repara R
LEFT JOIN 
    Empleado E ON R.IdEmp = E.IdEmp
GROUP BY 
    ROLLUP(E.NomEmp);

-- G - Muestra los datos de los Empleados Técnicos que repararon todos los productos.

SELECT E.*
FROM Empleado E
WHERE E.TipoEmp = 'T'
  AND NOT EXISTS (
        SELECT 1
        FROM Producto P
        WHERE NOT EXISTS (
            SELECT 1
            FROM Repara R
            WHERE R.IdEmp = E.IdEmp
              AND R.IdProd = P.IdProd
        )
    );

-- T-SQL

-- A - sp_RegistrarReparacion
CREATE PROCEDURE sp_RegistrarReparacion
    @NumSerie CHAR(10),
    @IdProd INT,
    @IdEmp INT,
    @CostoRepara MONEY
AS
BEGIN
    SET NOCOUNT ON;

    -- Validación 1: La unidad debe existir
    IF NOT EXISTS (
        SELECT 1
        FROM Unidad
        WHERE NumSerie = @NumSerie AND IdProd = @IdProd
    )
    BEGIN
        PRINT 'Error: La unidad especificada no existe.';
        RETURN;
    END

    -- Validación 2: El empleado debe existir
    IF NOT EXISTS (
        SELECT 1
        FROM Empleado
        WHERE IdEmp = @IdEmp
    )
    BEGIN
        PRINT 'Error: El empleado especificado no existe.';
        RETURN;
    END

    -- Validación 3: No puede haber una reparación duplicada por el mismo empleado en la misma unidad el mismo día
    IF EXISTS (
        SELECT 1
        FROM Repara
        WHERE NumSerie = @NumSerie
          AND IdProd = @IdProd
          AND IdEmp = @IdEmp
          AND CONVERT(DATE, FchRepara) = CONVERT(DATE, GETDATE())
    )
    BEGIN
        PRINT 'Error: Ya existe una reparación registrada hoy para esta unidad por este empleado.';
        RETURN;
    END

    -- Validación 4: El costo no puede ser negativo
    IF @CostoRepara < 0
    BEGIN
        PRINT 'Error: El costo de la reparación no puede ser negativo.';
        RETURN;
    END

    -- Inserción si todo es válido
    INSERT INTO Repara (NumSerie, IdProd, IdEmp, FchRepara, CostoRepara, StsRepara)
    VALUES (@NumSerie, @IdProd, @IdEmp, GETDATE(), @CostoRepara, 'Iniciado');

    PRINT 'Reparación registrada exitosamente.';
END;

-- prueba OK
EXEC sp_RegistrarReparacion 
    @NumSerie = '002',
    @IdProd = 3,
    @IdEmp = 2,
    @CostoRepara = 80;

-- prueba PRODUCTO INEXISTENTE
EXEC sp_RegistrarReparacion 
    @NumSerie = '999',
    @IdProd = 99,
    @IdEmp = 1,
    @CostoRepara = 50;

-- prueba EMPLEADO INEXISTENTE
EXEC sp_RegistrarReparacion 
    @NumSerie = '001',
    @IdProd = 1,
    @IdEmp = 999,
    @CostoRepara = 30;

-- prueba REPARACION DUPLICADA
-- Primero la inserción válida
EXEC sp_RegistrarReparacion 
    @NumSerie = '001',
    @IdProd = 1,
    @IdEmp = 1,
    @CostoRepara = 50;

-- Luego, vuelve a intentarlo el mismo día
EXEC sp_RegistrarReparacion 
    @NumSerie = '001',
    @IdProd = 1,
    @IdEmp = 1,
    @CostoRepara = 60;

-- prueba COSTO NEGATIVO
EXEC sp_RegistrarReparacion 
    @NumSerie = '003',
    @IdProd = 3,
    @IdEmp = 2,
    @CostoRepara = -50;


-- B - fn_CalcularTiempoReparacion

CREATE FUNCTION fn_CalcularTiempoReparacion
(
    @NumSerie CHAR(10),
    @IdProd INT
)
RETURNS INT
AS
BEGIN
    DECLARE @DiasReparacion INT

    SELECT @DiasReparacion = COUNT(DISTINCT CAST(FchRepara AS DATE))
    FROM Repara
    WHERE NumSerie = @NumSerie AND IdProd = @IdProd

    RETURN @DiasReparacion
END

-- prueba UNIDAD CON REPARACIONES
SELECT dbo.fn_CalcularTiempoReparacion('001', 1) AS DiasReparacion;

-- prueba UNIDAD SIN REPARACIONES
SELECT dbo.fn_CalcularTiempoReparacion('003', 1) AS DiasReparacion;


-- TRIGGERS

-- A - trg_ControlEstadoReparacion
-- tabla HistoricoReparacion
CREATE TABLE HistoricoReparacion (
    IdHist INT IDENTITY PRIMARY KEY,
    IdRepara INT NOT NULL,
    NumSerie CHAR(10) NOT NULL,
    IdProd INT NOT NULL,
    EstadoAnterior VARCHAR(20) NOT NULL,
    EstadoNuevo VARCHAR(20) NOT NULL,
    FchCambio DATETIME DEFAULT GETDATE()
);
GO

-- trigger
CREATE TRIGGER trg_ControlEstadoReparacion
ON Repara
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO HistoricoReparacion(IdRepara, NumSerie, IdProd, EstadoAnterior, EstadoNuevo)
    SELECT
        i.IdRepara,
        i.NumSerie,
        i.IdProd,
        d.StsRepara AS EstadoAnterior,
        i.StsRepara AS EstadoNuevo
    FROM inserted i
    JOIN deleted d ON i.IdRepara = d.IdRepara
    WHERE i.StsRepara IN ('Terminado', 'Cancelado') 
      AND i.StsRepara <> d.StsRepara;  -- Solo si hubo cambio real
END
GO

-- prueba CAMBIO INICIADO -> TERMINADO
-- Ver estado antes
SELECT IdRepara, StsRepara FROM Repara WHERE IdRepara = 7;

-- Cambiar estado a 'Terminado'
UPDATE Repara SET StsRepara = 'Terminado' WHERE IdRepara = 7;

-- Verificar el histórico
SELECT * FROM HistoricoReparacion WHERE IdRepara = 7;

-- prueba NO HAY CAMBIO DE ESTADO
-- Revisamos el estado actual
SELECT IdRepara, StsRepara FROM Repara WHERE IdRepara = 8;

-- Volvemos a setear el mismo estado
UPDATE Repara SET StsRepara = StsRepara WHERE IdRepara = 8;

-- No debería haber inserción
SELECT * FROM HistoricoReparacion WHERE IdRepara = 8;

-- B - trg_PrevenirEliminacionReparaciones
-- tabla HistoricoEliminacionReparaciones
CREATE TABLE HistoricoEliminacionReparaciones (
    IdHist INT IDENTITY PRIMARY KEY,
    IdRepara INT NOT NULL,
    NumSerie CHAR(10) NOT NULL,
    IdProd INT NOT NULL,
    StsRepara VARCHAR(20) NOT NULL,
    FchEliminacion DATETIME DEFAULT GETDATE()
);
GO

-- trigger
CREATE TRIGGER trg_PrevenirEliminacionReparaciones
ON Repara
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- Si hay alguna reparación que esté 'Terminado' o 'En testing', se bloquea todo
    IF EXISTS (
        SELECT 1
        FROM deleted
        WHERE StsRepara IN ('Terminado', 'En testing')
    )
    BEGIN
        RAISERROR('No se pueden eliminar reparaciones en estado "Terminado" o "En testing".', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    -- Registrar las eliminaciones permitidas en el histórico
    INSERT INTO HistoricoEliminacionReparaciones(IdRepara, NumSerie, IdProd, StsRepara)
    SELECT IdRepara, NumSerie, IdProd, StsRepara
    FROM deleted;

    -- Realizar la eliminación
    DELETE FROM Repara
    WHERE IdRepara IN (SELECT IdRepara FROM deleted);
END
GO

-- precarga para probar
-- Repara 14: estado permitido
UPDATE Repara SET StsRepara = 'Iniciado' WHERE IdRepara = 14;

-- Repara 15: estado prohibido
UPDATE Repara SET StsRepara = 'Terminado' WHERE IdRepara = 15;

-- prueba CASO PERMITIDO
DELETE FROM Repara WHERE IdRepara = 14;

-- Ver auditoría
SELECT * FROM HistoricoEliminacionReparaciones WHERE IdRepara = 14;


-- prueba CASO PROHIBIDO
DELETE FROM Repara WHERE IdRepara = 15;
-- Debería lanzar:
-- No se pueden eliminar reparaciones en estado "Terminado" o "En testing".

-- VISTAS
-- 6. vw_ReparacionesActivas
CREATE VIEW vw_ReparacionesActivas AS
SELECT
    R.IdRepara,
    R.NumSerie,
    R.IdProd,
    P.DscProd,
    E.NomEmp,
    R.FchRepara,
    R.StsRepara
FROM Repara R
JOIN Producto P ON R.IdProd = P.IdProd
JOIN Empleado E ON R.IdEmp = E.IdEmp
WHERE R.StsRepara IN ('Iniciado', 'En testing');
GO

-- prueba
SELECT * FROM vw_ReparacionesActivas;

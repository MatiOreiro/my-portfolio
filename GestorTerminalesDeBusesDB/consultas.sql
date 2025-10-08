use obligatorio

-- Consulta 1
SELECT 
    T.nombreT, 
    T.apellidoT, 
    COUNT(P.idP) AS cantidad_pasajes
FROM 
    Turista T
JOIN 
    Pasaje P ON T.idT = P.idT
GROUP BY 
    T.idT, T.nombreT, T.apellidoT
HAVING 
    COUNT(P.idP) = (
        SELECT MAX(cantidad_pasajes)
        FROM (
            SELECT COUNT(*) AS cantidad_pasajes
            FROM Pasaje
            GROUP BY idT
        ) AS subconsulta
    );

-- Consulta 2
SELECT *
FROM Bus B
WHERE 
    B.capAsientosBus > 35
    AND B.idDT NOT IN (
        SELECT D.idDT
        FROM DestinoTuristico D
        WHERE D.FechaDT = DATEADD(DAY, 1, CAST(GETDATE() AS DATE))
    );

-- Consulta 3
SELECT T.*
FROM Turista T
JOIN Pasaje P ON T.idT = P.idT
GROUP BY T.idT, T.nombreT, T.apellidoT, T.correoT, T.contraseñaT, T.tipoDocT, T.numeroDocT, T.fechaNacT
HAVING COUNT(P.idP) > 5;

-- Consulta 4
SELECT distinct
    P.idT AS idPasajero, 
    T.nombreT, 
    T.apellidoT, 
    A.NroFilaAs AS fila, 
    A.LetraAs AS asiento
FROM 
    Pasaje P
JOIN 
    Turista T ON P.idT = T.idT
JOIN 
    Asiento A ON P.NroFilaAs = A.NroFilaAs AND P.LetraAs = A.LetraAs
WHERE 
    P.idDT = 255;

-- Consulta 5
      SELECT 
    P.idDT AS idviaje, 
    P.fechaP,                    -- Incluimos la fecha para agrupar correctamente
    COUNT(*) AS cantidad_pasajes -- Contamos las filas de pasajes
FROM 
    Pasaje P
JOIN 
    Turista T ON P.idT = T.idT
WHERE 
    T.correoT = 'soyturista@gmail.com'     -- Filtramos por el correo del turista
    AND YEAR(P.fechaP) = 2017             -- Filtramos por el año actual
    AND MONTH(P.fechaP) = 9              -- Filtramos por el mes de Septiembre
GROUP BY 
    P.idDT,                               -- Agrupamos por destino
    P.fechaP                              -- Agrupamos también por fecha
ORDER BY 
    P.idDT ASC,                           -- Ordenamos por idviaje
    P.fechaP ASC;                         -- Ordenamos por fecha

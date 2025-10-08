use DeviceService;

-- Empleados
INSERT INTO Empleado(NomEmp, FchNacEmp, SueldoEmp, TipoEmp) values ('Matías Oreiro', '2000-12-11', 60000, 'T');
INSERT INTO Empleado(NomEmp, FchNacEmp, SueldoEmp, TipoEmp) values ('Sebastian Hohl', '2000-12-11', 65000, 'T');
INSERT INTO Empleado(NomEmp, FchNacEmp, SueldoEmp, TipoEmp) values ('Mariano Sendic', '1976-06-15', 92000, 'C');
INSERT INTO Empleado(NomEmp, FchNacEmp, SueldoEmp, TipoEmp) values ('Juan Perez', '1994-02-28', 45000, 'C');
INSERT INTO Empleado(NomEmp, FchNacEmp, SueldoEmp, TipoEmp) values ('Maria Rodriguez', '2003-04-01', 30000, 'T');
INSERT INTO Empleado(NomEmp, FchNacEmp, SueldoEmp, TipoEmp) values ('Pepe Gomez', '1999-07-21', 30000, 'T');
INSERT INTO Empleado(NomEmp, FchNacEmp, SueldoEmp, TipoEmp) values ('Santiago Gimenez', '2001-11-30', 21000, 'T');


-- Productos
INSERT INTO Producto values ('Teléfono Celular', 60, 499.99);
INSERT INTO Producto values ('Notebook', 26, 899.99);
INSERT INTO Producto values ('Parlante', 150, 69.99);
INSERT INTO Producto values ('Televisor', 7, 2000);
INSERT INTO Producto values ('Computadora Gamer', 3, 1250);

--Unidades

-- Teléfono Celular 
INSERT INTO Unidad (NumSerie, IdProd, FchFab, FchVto) VALUES ('001', 1, '2023-11-10', '2025-11-10');
INSERT INTO Unidad (NumSerie, IdProd, FchFab, FchVto) VALUES ('002', 1, '2023-05-21', '2025-05-21');
INSERT INTO Unidad (NumSerie, IdProd, FchFab, FchVto) VALUES ('003', 1, '2023-09-20', '2025-09-20');

-- Notebook 
INSERT INTO Unidad (NumSerie, IdProd, FchFab, FchVto) VALUES ('001', 2, '2023-08-23', '2026-08-23');
INSERT INTO Unidad (NumSerie, IdProd, FchFab, FchVto) VALUES ('002', 2, '2023-01-30', '2026-01-30');
INSERT INTO Unidad (NumSerie, IdProd, FchFab, FchVto) VALUES ('003', 2, '2023-02-15', '2026-02-15');

-- Parlante
INSERT INTO Unidad (NumSerie, IdProd, FchFab, FchVto) VALUES ('001', 3, '2024-03-01', '2026-03-01');
INSERT INTO Unidad (NumSerie, IdProd, FchFab, FchVto) VALUES ('002', 3, '2024-07-09', '2026-07-09');
INSERT INTO Unidad (NumSerie, IdProd, FchFab, FchVto) VALUES ('003', 3, '2024-04-12', '2026-04-12');

-- Televisor
INSERT INTO Unidad (NumSerie, IdProd, FchFab, FchVto) VALUES ('001', 4, '2022-12-11', '2025-12-11');
INSERT INTO Unidad (NumSerie, IdProd, FchFab, FchVto) VALUES ('002', 4, '2022-11-30', '2025-11-30');
INSERT INTO Unidad (NumSerie, IdProd, FchFab, FchVto) VALUES ('003', 4, '2022-09-13', '2025-09-13');

-- Computadora Gamer
INSERT INTO Unidad (NumSerie, IdProd, FchFab, FchVto) VALUES ('001', 5, '2025-02-10', '2028-02-10');
INSERT INTO Unidad (NumSerie, IdProd, FchFab, FchVto) VALUES ('002', 5, '2025-05-12', '2028-05-12');
INSERT INTO Unidad (NumSerie, IdProd, FchFab, FchVto) VALUES ('003', 5, '2025-01-29', '2028-01-29');



-- Repara
INSERT INTO Repara(NumSerie, IdProd, IdEmp, FchRepara, CostoRepara, IdEmpQA) VALUES ('001', 1, 1, '2025-05-02', 25, 3);
INSERT INTO Repara(NumSerie, IdProd, IdEmp, FchRepara, CostoRepara, IdEmpQA) VALUES ('002', 1, 2, '2025-03-12', 45, 3);
INSERT INTO Repara(NumSerie, IdProd, IdEmp, FchRepara, CostoRepara, IdEmpQA) VALUES ('003', 2, 5, '20240430', 80, 4);
INSERT INTO Repara(NumSerie, IdProd, IdEmp, FchRepara, CostoRepara, IdEmpQA) VALUES ('002', 4, 1, '2025-02-08', 250, 4);
INSERT INTO Repara(NumSerie, IdProd, IdEmp, FchRepara, CostoRepara, IdEmpQA) VALUES ('001', 3, 2, '20241221', 7, 3);
INSERT INTO Repara(NumSerie, IdProd, IdEmp, FchRepara, CostoRepara, IdEmpQA) VALUES ('003', 5, 1, '20241019', 160, 4);
INSERT INTO Repara(NumSerie, IdProd, IdEmp, FchRepara, CostoRepara, IdEmpQA) VALUES ('001', 2, 1, '20250615', 100, 3);
INSERT INTO Repara(NumSerie, IdProd, IdEmp, FchRepara, CostoRepara, IdEmpQA) VALUES ('002', 3, 1, '20250616', 50, 3);


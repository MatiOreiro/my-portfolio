use obligatorio

-- Carga de datos de turistas
insert into Turista (idT, nombreT, apellidoT, correoT, contraseñaT, tipoDocT, numeroDocT, fechaNacT) values (1, 'Matías', 'Oreiro', 'moreiro@gmail.com', '12345678', 'CI', 12345678, '11-12-2000')
insert into Turista (idT, nombreT, apellidoT, correoT, contraseñaT, tipoDocT, numeroDocT, fechaNacT) values (2, 'Sebastián', 'Hohl', 'shohl@gmail.com', '87654321', 'CI', 87654321, '20-06-2000')
insert into Turista (idT, nombreT, apellidoT, correoT, contraseñaT, tipoDocT, numeroDocT, fechaNacT) values(3, 'Javier', 'Rodríguez', 'soyturista@gmail.com', 'JaviPass789', 'DNI', 87654321, '1992-12-10')
insert into Turista (idT, nombreT, apellidoT, correoT, contraseñaT, tipoDocT, numeroDocT, fechaNacT) values(4, 'Ana', 'López', 'ana.lopez@gmail.com', 'LopezAna001', 'CI', 26654321, '1995-03-25')
insert into Turista (idT, nombreT, apellidoT, correoT, contraseñaT, tipoDocT, numeroDocT, fechaNacT) values(5, 'Lucía', 'Martínez', 'lucia.martinez@gmail.com', 'LucyPass!23', 'DNI', 23456789, '1988-11-02')
insert into Turista (idT, nombreT, apellidoT, correoT, contraseñaT, tipoDocT, numeroDocT, fechaNacT) values(6, 'Pedro', 'Hernández', 'pedro.hernandez@gmail.com', 'PedroH4567', 'DNI', 58765432, '1993-07-18')
insert into Turista (idT, nombreT, apellidoT, correoT, contraseñaT, tipoDocT, numeroDocT, fechaNacT) values(7, 'Sofía', 'Torres', 'sofia.torres@gmail.com', 'TorresPass2024', 'CI', 34567890, '1997-01-12')
insert into Turista (idT, nombreT, apellidoT, correoT, contraseñaT, tipoDocT, numeroDocT, fechaNacT) values(8, 'Miguel', 'Ramírez', 'miguel.ramirez@gmail.com', 'MigueL99$', 'CI', 23456784, '2000-04-30')
insert into Turista (idT, nombreT, apellidoT, correoT, contraseñaT, tipoDocT, numeroDocT, fechaNacT) values(9, 'Laura', 'Fernández', 'laura.fernandez@gmail.com', 'LauraPass123', 'DNI', 56789012, '1994-06-15')
insert into Turista (idT, nombreT, apellidoT, correoT, contraseñaT, tipoDocT, numeroDocT, fechaNacT) values(10, 'Andrés', 'Suárez', 'andres.suarez@gmail.com', 'Andres*987', 'DNI', 63456789, '1987-09-27')

-- Carga de datos de Telefonos

insert into Telefono (idT, telT) values (1, 093745511)
insert into Telefono (idT, telT) values (2, 094135712)
insert into Telefono (idT, telT) values (3, 096375713)
insert into Telefono (idT, telT) values (4, 097585719)
insert into Telefono (idT, telT) values (4, 094869329)
insert into Telefono (idT, telT) values (5, 098595713)
insert into Telefono (idT, telT) values (6, 093575714)
insert into Telefono (idT, telT) values (7, 095565716)
insert into Telefono (idT, telT) values (8, 097987719)
insert into Telefono (idT, telT) values (8, 094525716)
insert into Telefono (idT, telT) values (9, 092515711)
insert into Telefono (idT, telT) values (10, 093345812)


-- Carga de datos de NoRegistrado

insert into NoRegistrado (idT, funcionarioT) values (7, 'Juan')
insert into NoRegistrado (idT, funcionarioT) values (8, 'Ramon')
insert into NoRegistrado (idT, funcionarioT) values (10, 'Jose')

-- Carga de datos de Mercosur

insert into Mercosur (idT, beneficiosM) values (1, '10% de descuento en restaurantes')
insert into Mercosur (idT, beneficiosM) values (5, '20% de descuento en excursiones')
insert into Mercosur (idT, beneficiosM) values (7, '15% de descuento en tienda de ropa')
insert into Mercosur (idT, beneficiosM) values (9, 'Seguro de viaje gratuito')



-- Carga de datos de Acompañantes

insert into Acompañante (idAc, idT, nombreAc, apellidoAc, correoAc, tipoDocAc, numeroDocAc,fechaNacAc,funcionarioAc) values (1, 2, 'Carlos', 'Sanchez', 'Csanchez@gmail.com', 'CI' ,34049843, '10-06-1999', 'Alberto')
insert into Acompañante (idAc, idT, nombreAc, apellidoAc, correoAc, tipoDocAc, numeroDocAc,fechaNacAc,funcionarioAc) values (2, 2, 'Ana', 'Sanchez', 'Aperez@gmail.com', 'CI' ,44039441, '17-08-1993', 'Alberto')
insert into Acompañante (idAc, idT, nombreAc, apellidoAc, correoAc, tipoDocAc, numeroDocAc,fechaNacAc,funcionarioAc) values (3, 7, 'Jose', 'Diaz', 'Jdiaz@gmail.com', 'CI' ,23039444, '11-02-1981', 'Matias')
insert into Acompañante (idAc, idT, nombreAc, apellidoAc, correoAc, tipoDocAc, numeroDocAc,fechaNacAc,funcionarioAc) values (4, 9, 'Rocio', 'Quiroz', 'Rquiroz@gmail.com', 'CI' ,53534345, '20-08-1998', 'Lara')
insert into Acompañante (idAc, idT, nombreAc, apellidoAc, correoAc, tipoDocAc, numeroDocAc,fechaNacAc,funcionarioAc) values (5, 10, 'Bruno', 'Ortigoza', 'Bortigoza@gmail.com', 'CI' ,57585343, '26-09-2007', 'Sebastian')

select * from Acompañante

-- Carga de datos de Telefono Acompañante

insert into TelefonoAc (idAc, telAc) values (1, 093939863)
insert into TelefonoAc (idAc, telAc) values (2, 094728791)
insert into TelefonoAc (idAc, telAc) values (3, 096516569)
insert into TelefonoAc (idAc, telAc) values (4, 097154356)
insert into TelefonoAc (idAc, telAc) values (5, 099372467)
insert into TelefonoAc (idAc, telAc) values (5, 094688767)
insert into TelefonoAc (idAc, telAc) values (5, 098145364)


-- Carga de datos de Departamento

insert into Departamento (idDepto, nombreDepto) values (1, 'Salto')
insert into Departamento (idDepto, nombreDepto) values (2, 'Montevideo')
insert into Departamento (idDepto, nombreDepto) values (3, 'Paysandu')
insert into Departamento (idDepto, nombreDepto) values (4, 'Artigas')
insert into Departamento (idDepto, nombreDepto) values (5, 'Fray Bentos')
insert into Departamento (idDepto, nombreDepto) values (6, 'Canelones')


-- Carga de datos de Terminales

insert into Terminal (idTer, idDepto, nombreTer) values (1, 2, 'Tres Cruces')
insert into Terminal (idTer, idDepto, nombreTer) values (2, 3, 'Terminal Paysandú')
insert into Terminal (idTer, idDepto, nombreTer) values (3, 4, 'Terminal Artigas')
insert into Terminal (idTer, idDepto, nombreTer) values (4, 6, 'Terminal Canelones')
insert into Terminal (idTer, idDepto, nombreTer) values (5, 5, 'Terminal Fray Bentos')
insert into Terminal (idTer, idDepto, nombreTer) values (6, 1, 'Terminal Salto')


-- Carga de datos de Orientacion Terminales

insert into OrientacionTerminales (idTerOrigen, idTerDestino) values (1, 6)
insert into OrientacionTerminales (idTerOrigen, idTerDestino) values (2, 5)
insert into OrientacionTerminales (idTerOrigen, idTerDestino) values (3, 4)
insert into OrientacionTerminales (idTerOrigen, idTerDestino) values (4, 3)
insert into OrientacionTerminales (idTerOrigen, idTerDestino) values (5, 2)
insert into OrientacionTerminales (idTerOrigen, idTerDestino) values (6, 1)


-- Carga de datos de Destino Turistico

insert into DestinoTuristico (idDT, idTerDestino, idTerOrigen, infoGralDT, DuracionAproxDT, FechaDT, HoraDT, ImporteViajeDT) values (1,1,6, 'Montevideo - Salto', 220 ,'2025-10-10', '09:30:00', 1200 )
insert into DestinoTuristico (idDT, idTerDestino, idTerOrigen, infoGralDT, DuracionAproxDT, FechaDT, HoraDT, ImporteViajeDT) values (2,6,1, 'Salto - Montevideo', 240 ,'2024-05-22', '11:30:00', 1100 )
insert into DestinoTuristico (idDT, idTerDestino, idTerOrigen, infoGralDT, DuracionAproxDT, FechaDT, HoraDT, ImporteViajeDT) values (3,3,4, 'Artigas - Canelones', 360 ,'2025-01-01', '10:50:00', 1050 )
insert into DestinoTuristico (idDT, idTerDestino, idTerOrigen, infoGralDT, DuracionAproxDT, FechaDT, HoraDT, ImporteViajeDT) values (4,5,2, 'Fray Bentos - Paysandú', 115 ,'2024-11-12', '21:30:00', 610 )
insert into DestinoTuristico (idDT, idTerDestino, idTerOrigen, infoGralDT, DuracionAproxDT, FechaDT, HoraDT, ImporteViajeDT) values (255,5,2, 'Fray Bentos - Paysandú', 115 ,'2024-11-12', '21:30:00', 610 )


-- Carga de datos de Bus

insert into Bus (idBus, idDT, MarcaBus, TipoBus, capAsientosBus) values (1,1,'Mercedes', 'Doble piso', 40)
insert into Bus (idBus, idDT, MarcaBus, TipoBus, capAsientosBus) values (2,2,'Volvo', 'MicroBus', 20)
insert into Bus (idBus, idDT, MarcaBus, TipoBus, capAsientosBus) values (3,3,'Mercedes', 'MicroBus', 15)
insert into Bus (idBus, idDT, MarcaBus, TipoBus, capAsientosBus) values (4,4,'Marcopolo', 'Comfort', 30)


--Carga de datos de Asiento

insert into Asiento (NroFilaAs, LetraAs, idBus) values (5, 'A', 1)
insert into Asiento (NroFilaAs, LetraAs, idBus) values (2, 'A', 1)
insert into Asiento (NroFilaAs, LetraAs, idBus) values (3, 'B', 1)
insert into Asiento (NroFilaAs, LetraAs, idBus) values (5, 'B', 1)
insert into Asiento (NroFilaAs, LetraAs, idBus) values (3, 'C', 2)
insert into Asiento (NroFilaAs, LetraAs, idBus) values (4, 'C', 2)
insert into Asiento (NroFilaAs, LetraAs, idBus) values (4, 'D', 2)
insert into Asiento (NroFilaAs, LetraAs, idBus) values (5, 'D', 3)
insert into Asiento (NroFilaAs, LetraAs, idBus) values (5, 'E', 3)
insert into Asiento (NroFilaAs, LetraAs, idBus) values (6, 'E', 3)
insert into Asiento (NroFilaAs, LetraAs, idBus) values (6, 'F', 4)


--Carga de datos de Pasaje 

insert into Pasaje (idP, idT, idBus, NroFilaAs,LetraAs, idDT, estadoP, fechaP) values (1,1,1,2, 'A', 1, 'Disponible', '2024-06-20')
insert into Pasaje (idP, idT, idBus, NroFilaAs,LetraAs, idDT, estadoP, fechaP) values (2,1,1,5, 'B', 1, 'Disponible', '2024-11-11')
insert into Pasaje (idP, idT, idBus, NroFilaAs,LetraAs, idDT, estadoP, fechaP) values (3,3,2,3, 'C', 2, 'Usado', '2023-12-22')
insert into Pasaje (idP, idT, idBus, NroFilaAs,LetraAs, idDT, estadoP, fechaP) values (4,4,2,4, 'C', 2, 'Usado', '2024-02-12')
insert into Pasaje (idP, idT, idBus, NroFilaAs,LetraAs, idDT, estadoP, fechaP) values (5,6,3,6, 'E', 3, 'Disponible', '2024-08-14')
insert into Pasaje (idP, idT, idBus, NroFilaAs,LetraAs, idDT, estadoP, fechaP) values (6,7,4,6, 'F', 4, 'Usado', '2024-11-01')
insert into Pasaje (idP, idT, idBus, NroFilaAs,LetraAs, idDT, estadoP, fechaP) values (7,3,4,6, 'F', 4, 'Usado', '2017-09-01')
insert into Pasaje (idP, idT, idBus, NroFilaAs,LetraAs, idDT, estadoP, fechaP) values (8,1,1,2, 'A', 1, 'Disponible', '2024-06-20')
insert into Pasaje (idP, idT, idBus, NroFilaAs,LetraAs, idDT, estadoP, fechaP) values (9,1,1,2, 'A', 1, 'Disponible', '2024-06-20')
insert into Pasaje (idP, idT, idBus, NroFilaAs,LetraAs, idDT, estadoP, fechaP) values (10,1,1,2, 'A', 1, 'Disponible', '2024-06-20')
insert into Pasaje (idP, idT, idBus, NroFilaAs,LetraAs, idDT, estadoP, fechaP) values (11,1,1,2, 'A', 1, 'Disponible', '2024-06-20')
insert into Pasaje (idP, idT, idBus, NroFilaAs,LetraAs, idDT, estadoP, fechaP) values (12,3,1,2, 'A', 255, 'Disponible', '2024-06-20')




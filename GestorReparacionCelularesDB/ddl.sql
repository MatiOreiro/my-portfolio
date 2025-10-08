CREATE DATABASE DeviceService
GO
USE DeviceService
GO
CREATE TABLE Empleado(IdEmp int identity not null,
                      NomEmp varchar(30) not null,
					  FchNacEmp date not null,
					  SueldoEmp money,
					  TipoEmp char(1) not null,
					  constraint pk_Empleado primary key(IdEmp),
					  constraint ck_TipoEmp check(TipoEmp in ('T','C')))
GO
CREATE TABLE Producto(IdProd int identity not null,
                      DscProd varchar(30) not null,
					  StkProd int,
					  CostoProd money,
					  constraint pk_Producto primary key(IdProd))
GO
CREATE TABLE Unidad(NumSerie character(10) not null,
                    IdProd int not null,
					FchFab date,
					FchVto date,
					constraint pk_Unidad primary key(NumSerie,IdProd),
					constraint fk_ProdUnidad foreign key(IdProd) references Producto(IdProd))
GO
CREATE TABLE Repara(IdRepara int identity not null,
                    NumSerie character(10) not null,
					IdProd int not null,
					IdEmp int not null,
					FchRepara datetime not null,
					CostoRepara money,
					StsRepara varchar(20) default 'Iniciado',
					IdEmpQA int,
					constraint pk_Repara primary key(IdRepara),
					constraint uk_Repara unique(NumSerie,IdProd,IdEmp,FchRepara),
					constraint ck_StsRepara check(StsRepara in ('Iniciado','En testing','Terminado','Cancelado')),
					constraint fk_UnidadRepara foreign key(NumSerie,IdProd) references Unidad(NumSerie,IdProd),
					constraint fk_EmpRepara foreign key(IdEmp) references Empleado(IdEmp),
					constraint fk_EmpQA foreign key(IdEmpQA) references Empleado(IdEmp))
GO

CREATE INDEX IDX_EmpleadoRepara ON Repara(IdEmp);
CREATE INDEX IDX_ProductoRepara ON Repara(NumSerie, IdProd);
CREATE INDEX IDX_EmpleadoControlRepara ON Repara(IdEmpQA);

create database obligatorio
use obligatorio

create table Turista (
idT int not null primary key,
nombreT varchar(10), 
apellidoT varchar(20), 
correoT varchar(25) unique,
contraseñaT varchar(20), 
tipoDocT varchar(20), 
numeroDocT int not null, 
fechaNacT Date,
)

create table Telefono (
idT int not null foreign key references Turista(idT), 
telT int not null primary key
)

create table NoRegistrado (
idT int not null foreign key references Turista(idT), 
funcionarioT varchar(10)
)

create table Mercosur (
idT int not null foreign key references Turista(idT), 
beneficiosM varchar(100)
)

create table Acompañante (
idAc int not null primary key, 
idT int not null foreign key references Turista(idT), 
nombreAc varchar(10), 
apellidoAc varchar(20), 
correoAc varchar(25) unique,
tipoDocAc varchar(20), 
numeroDocAc int not null, 
fechaNacAc Date, 
funcionarioAc varchar(10)
)

create table TelefonoAc (
idAc int not null foreign key references Acompañante(idAc), 
telAc int not null primary key
)

create table Departamento (
idDepto int not null primary key, 
nombreDepto varchar(20)
)

create table Terminal (
idTer int not null primary key, 
idDepto int foreign key references Departamento(idDepto), 
nombreTer varchar(20)
)

create table OrientacionTerminales (
idTerOrigen int foreign key references Terminal(idTer), 
idTerDestino int foreign key references Terminal(idTer),
primary key(idTerOrigen, idTerDestino)
)

create table DestinoTuristico (
idDT int not null primary key, 
idTerOrigen int not null, 
idTerDestino int not null, 
infoGralDT varchar(100), 
DuracionAproxDT int not null, 
FechaDT Date, 
HoraDT Time, 
ImporteViajeDT int not null,
foreign key (idTerOrigen, idTerDestino) references OrientacionTerminales(idTerOrigen, idTerDestino)
)

create table Bus (
idBus int not null primary key, 
idDT int not null foreign key references DestinoTuristico(idDT), 
MarcaBus varchar(20), 
TipoBus varchar(20), 
capAsientosBus int not null
)

create table Asiento (
NroFilaAs int not null, 
LetraAs varchar(1), 
idBus int not null foreign key references Bus(idBus),
primary key(idBus, NroFilaAs, LetraAs)
)

create table Pasaje (
idP int not null primary key, 
idT int not null, 
idBus int not null,
NroFilaAs int not null, 
LetraAs varchar(1), 
idDT int not null , 
estadoP varchar(10), 
fechaP Date,
foreign key (idT) references Turista(idT),
foreign key (idDT) references DestinoTuristico(idDT),
foreign key (idBus, NroFilaAs, LetraAs) references Asiento(idBus, NroFilaAs, LetraAs)
)

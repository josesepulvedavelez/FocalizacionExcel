
create table FocDepartamento
(
	DepartamentoId int primary key,
	Departamento varchar(100)
);

create table FocMunicipio
(
	MunicipioId int,
	Municipio varchar(100),
	DepartamentoId int foreign key references FocDepartamento(DepartamentoId)
);

create table FocEse
(
	EseId int,
	Ese varchar(100),
	MunicipioId int foreign key references FocMunicipio(MunicipioId)
);

create table FocUsuario
(
	UsuarioId int identity(1, 1) primary key,
	Usuario varchar(20) unique,
	Contrasena varchar(10),
	Nivel varchar(20)	
);

create table FocResolucion
(
	ResolucionId int primary key,
	Resolucion varchar(50)
);

create table Focalizacion
(
	FocalizacionId int identity(1, 1) primary key,
	FechaContacto date,
	TipoDoc varchar(15),
	NumeroId varchar(20),
	Nombre1 varchar(50),
	Nombre2 varchar(50),
	Apellido1 varchar(50),
	Apellido2 varchar(50),
	FechaNacimiento date,
	Direccion varchar(max),
	TelefonosContacto varchar(50),
	TelefonoEfectivo bit,
	Aceptacion_o_no_atencion bit,
	Atencion__la_que_accede varchar(50),
	Razon_no_aceptacion varchar(50),
	Incluido_ruv_o_sentencias varchar(50),
	verificacion_estado_aseguramiento varchar(50),
	Eps varchar(100),
	Condicion_discapacidad bit,
	Pertenencia_etnica varchar(50),
	Sexo varchar(20),
	Observaciones varchar(max),
	EseId int foreign key references FocEse(EseId),
	UsuarioId int foreign key references FocUsuario(UsuarioId),
	ResolucionId int foreign key references FocResolucion(ResolucionId),
	FechaLog datetime default getdate()
);

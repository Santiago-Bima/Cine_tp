create database cine_tp
use cine_tp

create table provincias(
	id_provincia int identity(1,1) not null,
	provincia varchar(100)
	constraint pk_provincias primary key (id_provincia))

create table ciudades(
	id_ciudad int identity(1,1) not null,
	ciudad varchar(100),
	id_provincia int
	constraint pk_ciudades primary key (id_ciudad),
	constraint fk_id_provincia foreign key (id_provincia)
	references provincias (id_provincia))

create table barrios(
	id_barrio int identity(1,1) not null,
	barrio varchar(100),
	id_ciudad int
	constraint pk_barrios primary key (id_barrio),
	constraint fk_id_ciudad foreign key (id_ciudad)
	references ciudades (id_ciudad))

create table formatos(
	--2d subtitulada, 3d doblada, 2d idioma original sin subs, etc
	id_formato int identity(1,1) not null,
	formato varchar(100)
	constraint pk_formato primary key (id_formato))

create table generos(
	id_genero int identity(1,1) not null,
	genero varchar(100)
	constraint pk_generos primary key (id_genero))

create table idiomas(
	id_idioma int identity(1,1) not null,
	idioma varchar(100)
	constraint pk_idiomas primary key (id_idioma))


create table butacas(
	id_butaca int identity(1,1) not null,
	numero int
	constraint pk_butacas primary key (id_butaca))



create table peliculas(
	id_pelicula int identity(1,1) not null,
	titulo varchar(100),
	descripcion text,
	director varchar(200),
	duracion int,
	id_genero int,
	origen varchar(100),
	id_idioma int
	constraint pk_peliculas primary key (id_pelicula),
	constraint fk_generos_peliculas foreign key (id_genero)
	references generos (id_genero),
	constraint fk_idiomas_peliculas foreign key (id_idioma)
	references idiomas (id_idioma))

create table salas(
	id_sala int identity(1,1) not null,
	sala varchar(100)
	constraint pk_salas primary key (id_sala))

create table funciones(
	id_funcion int identity(1,1) not null,
	hora varchar(10),
	fecha date,
	precio money,
	id_pelicula int,
	id_sala int,
	id_formato int,
	constraint pk_funciones primary key (id_funcion),
	constraint fk_peliculas_funciones foreign key (id_pelicula)
		references peliculas (id_pelicula),
	constraint fk_salas_funciones foreign key (id_sala)
		references salas (id_sala),
	constraint fk_formatos_funciones foreign key (id_formato)
		references formatos (id_formato),
	)

create table formas_pago(
	id_forma_pago int identity(1,1) not null,
	forma_pago varchar(100)
	constraint pk_formas_pago primary key (id_forma_pago))

create table clientes(
	id_cliente int identity(1,1) not null,
	nombre varchar(100),
	apellido varchar(100),
	dni int,
	telefono varchar(100),
	[e-mail] varchar(100),
	id_barrio int,
	direccion varchar(200)
	constraint pk_clientes primary key (id_cliente),
	constraint fk_barrios_clientes foreign key (id_barrio)
	references barrios (id_barrio))


create table facturas(
	nro_factura int identity(1,1) not null,
	id_cliente int,
	id_forma_pago int,
	fecha datetime,
	descuento float,
	total money,
	bajas bit
	constraint pk_facturas primary key (nro_factura),
	constraint fk_clientes_facturas foreign key (id_cliente)
	references clientes (id_cliente),
	constraint fk_formas_pago_facturas foreign key (id_forma_pago)
	references formas_pago (id_forma_pago))
	
create table detalle_facturas(
	id_detalle int identity(1,1) not null,
	nro_factura int,
	precio_ticket float,
	id_funcion int,
	id_butaca int,
	constraint pk_detalle_facturas primary key (id_detalle),
	constraint fk_facturas_detalles foreign key (nro_factura)
	references facturas (nro_factura),
	constraint fk_funciones_tickets foreign key (id_funcion) 
		references funciones (id_funcion),
	constraint fk_butacas_funciones foreign key (id_butaca)
		references butacas (id_butaca))

create table reservadas(
	id_reserva int identity(1,1),
	id_butaca int,
	id_funcion int
	constraint pk_reservas primary key (id_reserva),
	constraint fk_butacas foreign key (id_butaca)
		references butacas (id_butaca),
	constraint fk_funciones foreign key (id_funcion) 
		references funciones (id_funcion)
)





-- SP Detalles

create proc Crear_Ticket
	@nro_factura int,
	@precio money,
	@id_funcion int,
	@id_butaca int
as
begin
	insert into detalle_facturas(nro_factura, precio_ticket, id_funcion, id_butaca) values (@nro_factura, @precio,@id_funcion,@id_butaca)
	insert into reservadas (id_butaca, id_funcion) values (@id_butaca, @id_funcion)
end




-- SP Maestro

create proc consultar_altafacturas
as
	Select nro_factura, apellido + ' ' + nombre Cliente , forma_pago, CONVERT(varchar,fecha,3) as [DD/MM/YY], descuento, total, bajas
    from facturas f join clientes c on c.id_cliente = f.id_cliente
	join formas_pago fp on fp.id_forma_pago = f.id_forma_pago
	order by bajas
select * from peliculas
create proc Insertar_Factura
	@id_cliente int,
	@id_forma_pago int,
	@fecha datetime,
	@descuento decimal(10,2),
	@total money,
	@nro_factura int OUTPUT
as
begin
	insert into facturas(id_cliente,id_forma_pago,fecha,descuento,total, bajas) values(@id_cliente, @id_forma_pago,FORMAT(@fecha,'dd/MM/yy'),@descuento,@total, 0x00)
	SET @nro_factura = SCOPE_IDENTITY();
end

create proc [dbo].baja_factura
	@nro_factura int
as
begin
	update facturas set bajas = 0x01
	where nro_factura = @nro_factura
end

create proc Alta_factura
	@nro_factura int
as
	update facturas set bajas = 0x00
	where nro_factura = @nro_factura

create proc consultar_proxFactura
@id int output
as
	select @id=max(id_funcion) + 1 from funciones




-- SP Combos

create proc Combo_Peliculas
as
	select * from peliculas

create proc Combo_Salas
as
	select * from salas

create proc combo_formaspago
as
select * from formas_pago

create proc combo_idiomas
as
select * from idiomas

create proc Combo_Clientes
as
	select id_cliente, apellido + ' ' + nombre cliente , dni, telefono, [e-mail], id_barrio, direccion from Clientes

create proc combo_formatos
as
select * from formatos

create proc combo_generos
as
select * from generos

create proc combo_butacas
@id_funcion int
as
	select id_butaca butaca from butacas b
	where id_butaca  not in (select r.id_butaca from reservadas r where r.id_funcion = 50 )


-- SP ABM Funciones 
create proc Consultar_idioma
@id_pelicula int
as
	select i.id_idioma, idioma
	from peliculas p join idiomas i on i.id_idioma = p.id_idioma
	where p.id_pelicula = @id_pelicula

create proc Consultar_Funciones
as
	select f.id_funcion idFuncion,titulo Titulo
	from funciones f join peliculas p on f.id_pelicula = p.id_pelicula
	order by Titulo


create proc Consultar_Funcion
@id_funcion int
as
	select f.id_funcion id,titulo Titulo, hora Hora, fecha Fecha,i.id_idioma idIdioma, idioma Idioma,fr.id_formato idFormato, formato Formato, precio Precio, s.id_sala idSala, sala
	from funciones f join peliculas p on f.id_pelicula = p.id_pelicula
	join formatos fr on fr.id_formato = f.id_formato
	join idiomas i on i.id_idioma = p.id_idioma
	join salas s on s.id_sala = f.id_sala
	where f.id_funcion = @id_funcion


create proc [dbo].[Reportes_funciones]
@genero varchar(100)
as
select titulo Titulo, idioma Idioma, CONVERT(varchar,fu.fecha,3) as [DD/MM/YY], hora Hora, idioma Idioma, formato Formato,genero Genero, count(distinct fa.nro_factura) 'Cantidad de entradas vendidas' from funciones fu join peliculas p on p.id_pelicula = fu.id_pelicula
join idiomas i on i.id_idioma = p.id_idioma
join formatos fr on fr.id_formato = fu.id_formato
join detalle_facturas d on d.id_funcion = fu.id_funcion
join facturas fa on fa.nro_factura = d.nro_factura
join generos g on g.id_genero = p.id_genero
where g.id_genero = @genero
group by titulo, idioma, CONVERT(varchar,fu.fecha,3), hora, idioma, formato, genero

create proc Reportes_Facturas
@año1 int,
@año2 int
as
select distinct(fu.id_funcion) 'ID de funcion', titulo Pelicula,idioma Idioma, genero Genero, formato Formato, CONVERT(varchar,fa.fecha,3) as [DD/MM/YY],sum(total) 'Total vendido' from facturas fa join detalle_facturas d on d.nro_factura = fa.nro_factura
join funciones fu on fu.id_funcion = d.id_funcion
join peliculas p on p.id_pelicula = fu.id_pelicula
join idiomas i on i.id_idioma = p.id_idioma
join generos g on g.id_genero = p.id_genero
join formatos fr on fr.id_formato = fu.id_formato
where year(fa.fecha) between @año1 and @año2
group by  fu.id_funcion ,titulo,idioma,genero,formato,CONVERT(varchar,fa.fecha,3)


create proc Consultar_Lista_Funciones
as
select id_funcion, hora, CONVERT(varchar,fecha,3) as [DD/MM/YY], p.id_pelicula, titulo,s.id_sala, sala, f.id_formato, formato, idioma, precio
from funciones f join peliculas p on p.id_pelicula=f.id_pelicula
join salas s on s.id_sala=f.id_sala
join formatos fo on fo.id_formato=f.id_formato
join idiomas i on p.id_idioma = i.id_idioma

create proc [dbo].[Actualizar_Funciones]
	@id_funcion int,
	@fecha datetime,
	@precio money,
	@id_pelicula int,
	@id_sala int,
	@id_formato int,
	@hora varchar(10)
as
	update funciones set fecha = FORMAT(@fecha,'dd/MM/yy'), precio = @precio, id_pelicula = @id_pelicula, id_sala = @id_sala, id_formato = @id_formato, hora = @hora
	where id_funcion = @id_funcion

create proc [dbo].[Eliminar_Funciones]
	@id int
as
	delete from funciones where id_funcion = @id

create proc [dbo].[Insertar_Funciones]
	@fecha datetime,
	@precio money,
	@id_pelicula int,
	@id_sala int,
	@id_formato int,
	@hora varchar(10)
as
	insert into funciones(fecha, precio, id_pelicula, id_sala, id_formato, hora) values(FORMAT(@fecha,'dd/MM/yy'), @precio,@id_pelicula,@id_sala,@id_formato, @hora)
select * from funciones

	







--Inserts de las provincias
insert into provincias values('Cordoba')

--Insert de las ciudades
insert into ciudades values('Cordoba',1)
insert into ciudades values('Rio Cuarto',1)
insert into ciudades values('Villa Maria',1)
insert into ciudades values('San Francisco',1)
insert into ciudades values('Rio Tercero',1)

--Insert Barrios de cordoba
insert into barrios values('Alberdi',1)
insert into barrios values('Nueva Cordoba',1)
insert into barrios values('Güemes',1)
insert into barrios values('Centro',1)
insert into barrios values('Alta Cordoba',1)
insert into barrios values('Las Quintas',2)
insert into barrios values('San Justo',3)

--Formas de pago
insert into formas_pago values('Tarjeta de credito')
insert into formas_pago values('Tarjeta de debito')
insert into formas_pago values('Efectivo')

--Butacas
insert into butacas values(1)
insert into butacas values(2)
insert into butacas values(3)
insert into butacas values(4)
insert into butacas values(5)
insert into butacas values(6)
insert into butacas values(7)
insert into butacas values(8)
insert into butacas values(9)
insert into butacas values(10)
insert into butacas values(11)
insert into butacas values(12)
insert into butacas values(13)
insert into butacas values(14)
insert into butacas values(15)
insert into butacas values(16)
insert into butacas values(17)
insert into butacas values(18)
insert into butacas values(19)
insert into butacas values(20)
insert into butacas values(21)
insert into butacas values(22)
insert into butacas values(23)
insert into butacas values(24)


--Clientes
insert into clientes values('Jonas','Pastor',39174219,3571320879,'114039@tecnicatura.frc.utn.edu.ar',2,'Calle falsa 1')
insert into clientes values('Jorge','Perez',22555789,351456389,'Jorgeperez@gmail.com',1,'Calle falsa 2')
insert into clientes values('Marta','Torres',7555789,351447831,'MartaTorres@gmail.com',4,'Calle Falsa 3')
insert into clientes values('Agustina','Zabala',36541230,351487326,'AgustinaZabala@gmail.com',2,'Buenos Aires 56')
insert into clientes values('Claudia','Aguirre',44222154,351478932,'ClaudiaAguirre@gmail.com',3,'Pueyrredon 150')
insert into clientes values('Mario','Fernandez',22373564,354214573,'MarioFernandez@hotmail.com',4,'Calle falsa 25')
insert into clientes values('Lucas','Pereyra',38252321,354231050,'LucasPereyra@gmail.com',2,'Ituzaingo 900')
insert into clientes values('Sofia','Maldonado',41653214,3571485926,'SofiaMaldona@live.com',5,'San Martin 589')
insert into clientes values('Maximiliano','Gomez',15789652,3571325476,'MaximilianoGomez@hotmail.com',5,'San Martin 125')
insert into clientes values('Exequiel','Ortiz',30441225,354895231,'ExequielOrtiz@gmail.com',1,'Calle falsa 256')
insert into clientes values('Juan','Gonzalez',16165482,354812854,'JuanGonzalez@gmail.com',6,'Calle falsa 466')
insert into clientes values('Martina','Herrera',44286495,351269853,'MartinaHerrera@gmail.com',7,'Calle falsa 271')

insert into clientes values('Pablo','Gomez',16165482,354812854,'PabloGomez@gmail.com',6,'Calle falsa 466')
insert into clientes values('Juan','Gomez',44286495,351269853,'JuanGomez@gmail.com',7,'Calle falsa 271')
insert into clientes values('Carola','Gonzalez',16165482,354812854,'CarolaGonzalez@gmail.com',6,'Calle falsa 466')
insert into clientes values('Martina','Maldonado',44286495,351269853,'MartinaMaldonadi@gmail.com',7,'Calle falsa 271')


--Idiomas
insert into idiomas values('Español')
insert into idiomas values('Ingles con sutitulos')

--Generos
insert into generos values('Comedia')
insert into generos values('Terror')
insert into generos values('Accion')
insert into generos values('Suspenso')
insert into generos values('Comedia romantica')
insert into generos values('Animacion')
insert into generos values('Drama')

--Formatos
insert into formatos values('2D')
insert into formatos values('3D')

--Salas 
insert into salas values('1a')
insert into salas values('1b')
insert into salas values('2a')
insert into salas values('2b')
insert into salas values('3a')
insert into salas values('3b')

--Peliculas
insert into peliculas values('Avatar','Descipcion','James Cameron',162,3,'Estados Unidos',1)
insert into peliculas values('Avatar','Descipcion','James Cameron',162,3,'Estados Unidos',2)
insert into peliculas values('Argentina, 1985','Descripcion','Santiago Mitre',140,7,'Argentina',1)
insert into peliculas values('La Huerfana el origen','Descripcion','William Brent Bell',109,2,'Estados Unidos',2)
insert into peliculas values('La Huerfana el origen','Descripcion','William Brent Bell',109,2,'Estados Unidos',1)
insert into peliculas values('Pinocho','Descipcion','Robert Zemeckis',105,6,'Estados Unidos',1)
insert into peliculas values('Pinocho','Descipcion','Robert Zemeckis',105,6,'Estados Unidos',2)
insert into peliculas values('Solaris','Descipcion','Robert Zemeckis',162,6,'Argentina',1)
insert into peliculas values('Avatar 3','Descipcion','Robert Zemeckis',150,6,'Estados Unidos',2)
insert into peliculas values('Titanic','Descipcion','James Cameron',140,2,'Estados Unidos',2)
insert into peliculas values('Titanic','Descipcion','James Cameron',145,4,'Argentina',1)
insert into peliculas values('Terminator','Descipcion','Robert Zemeckis',160,6,'Estados Unidos',2)

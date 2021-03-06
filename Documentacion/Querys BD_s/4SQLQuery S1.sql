CREATE DATABASE SITIO1

USE SITIO1

CREATE TABLE ALUMNOS1 
(
	claveAlumno BIGINT PRIMARY KEY NOT NULL,	
	tiempo VARCHAR (8) NOT NULL,
	estado VARCHAR (5) NOT NULL,
)

CREATE TABLE ASISTENCIAS1
(
	idAsistencia BIGINT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	claveAlumno BIGINT NOT NULL,
	idMaquina BIGINT NOT NULL,
	idUsuario BIGINT NOT NULL,
	fecha DATE NOT NULL,
	horaEntrada TIME NOT NULL,
	horaSalida TIME NOT NULL,
	revision CHAR,
	comentarios VARCHAR(500),
)

CREATE TABLE MAQUINAS1
(
	idMaquina BIGINT PRIMARY KEY NOT NULL,
	laboratorio VARCHAR (10) NOT NULL,
	estado VARCHAR(15) NOT NULL,
	coordenadaX BIGINT NOT NULL,
	coordenadaY BIGINT NOT NULL,		
)

CREATE TABLE REPNOFUNCIONA1
(
	idRNF BIGINT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	reporto VARCHAR(50),
	idUsuario BIGINT NOT NULL,
	fecha DATE NOT NULL,
	hora TIME NOT NULL,
	idMaquina BIGINT NOT NULL,
	descripcion VARCHAR(500) NOT NULL,	
)

CREATE TABLE USUARIOS1
(
	idUsuario BIGINT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	nombre VARCHAR(50) NOT NULL, 
	contrasena VARCHAR(30) NOT NULL,
	tipo VARCHAR(30) NOT NULL,
)
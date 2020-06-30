CREATE DATABASE SITIOCENTRAL

USE SITIOCENTRAL

CREATE TABLE FRAGMENTOS
(
	id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	nombre VARCHAR(50) NOT NULL,
	tabla VARCHAR(50) NOT NULL,
	tipo VARCHAR(50),
	sitio INT NOT NULL,
	condicion VARCHAR(300),	
)

CREATE TABLE ATRIBUTOS
(
	id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	idFragmento INT NOT NULL,
	nombre VARCHAR(50) NOT NULL,
)
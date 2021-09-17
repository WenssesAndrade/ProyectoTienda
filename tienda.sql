create database tienda;
use tienda;

create table producto(
idproducto int primary key,
nombre varchar(100),
descripcion varchar(100),
precio int 
);

select * from producto;
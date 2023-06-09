CREATE TABLE Usuario (
Id INT IDENTITY(1,1) PRIMARY KEY,
Nombre VARCHAR(50) NOT NULL,
Correo VARCHAR(50) NOT NULL,
Contrasena VARCHAR(50) NOT NULL
);

CREATE TABLE TipoProducto (
Id INT IDENTITY(1,1) PRIMARY KEY,
Nombre VARCHAR(50) NOT NULL
);

CREATE TABLE Producto (
Id INT IDENTITY(1,1) PRIMARY KEY,
Nombre VARCHAR(50) NOT NULL,
Stock INT NOT NULL,
Precio DECIMAL(10, 2) NOT NULL,
TipoProductoId INT,
FOREIGN KEY (TipoProductoId) REFERENCES TipoProducto(id)
);

CREATE TABLE Cliente (
Id INT IDENTITY(1,1) PRIMARY KEY,
Nombre VARCHAR(50) NOT NULL,
Direccion VARCHAR(100) NOT NULL,
Telefono VARCHAR(20) NOT NULL
);

CREATE TABLE VentaEncabezado (
Id INT IDENTITY(1,1) PRIMARY KEY,
Fecha DATETIME NOT NULL,
Total DECIMAL(10, 2) NOT NULL,
UsuarioId INT,
ClienteId INT,
FOREIGN KEY (UsuarioId) REFERENCES Usuario(Id),
FOREIGN KEY (ClienteId) REFERENCES Cliente(Id)
);

CREATE TABLE VentaDetalle (
Id INT IDENTITY(1,1) PRIMARY KEY,
VentaEncabezadoId INT,
ProductoId INT,
Cantidad INT NOT NULL,
PrecioUnitario DECIMAL(10, 2) NOT NULL,
Subtotal DECIMAL(10, 2) NOT NULL,
FOREIGN KEY (VentaEncabezadoId) REFERENCES VentaEncabezado(Id),
FOREIGN KEY (ProductoId) REFERENCES Producto(Id)
);


select *from tipoProducto;
select *from producto;
select *from VentaEncabezado;
select *from VentaDetalle;
select *from Cliente;


select p.Id, p.Nombre, p.Stock, p.Precio, tp.Id as TipoProductoId, tp.Nombre
from Producto p, TipoProducto tp
where p.Id = tp.Id;

insert into usuario (nombre, correo, contrasena) values ('Alejandro Rodriguez', 'alejandro@mail.com', '123');
insert into TipoProducto (Nombre) values ('Higiene');
insert into producto (nombre, stock, precio, tipoProductoId) values ('Shampoo Head&Shoulders', '20', '28.50', 1);

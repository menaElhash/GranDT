-- ===================================
-- INSERTS DE DATOS INICIALES
-- Usando Stored Procedures de Altas
-- ===================================

USE Gran_DT;
DELIMITER //

-- ===================================
-- 1. INSERTAR ROLES
-- ===================================
SET @idRol1 = 0;
SET @idRol2 = 0;
SET @idRol3 = 0;
CALL altaRol('Usuario', @idRol1);              -- id_rol = 1
CALL altaRol('Administrador', @idRol2);        -- id_rol = 2
CALL altaRol('Manager', @idRol3);              -- id_rol = 3
//

-- ===================================
-- 2. INSERTAR TIPOS DE JUGADOR
-- ===================================
SET @idTipo1 = 0;
SET @idTipo2 = 0;
SET @idTipo3 = 0;
SET @idTipo4 = 0;
CALL altaTipo('Arquero', @idTipo1);            -- id_tipo = 1
CALL altaTipo('Defensor', @idTipo2);           -- id_tipo = 2
CALL altaTipo('Centrocampista', @idTipo3);     -- id_tipo = 3
CALL altaTipo('Delantero', @idTipo4);          -- id_tipo = 4
//

-- ===================================
-- 3. INSERTAR EQUIPOS
-- ===================================
SET @idEquipo1 = 0;
SET @idEquipo2 = 0;
SET @idEquipo3 = 0;
SET @idEquipo4 = 0;
SET @idEquipo5 = 0;
SET @idEquipo6 = 0;
SET @idEquipo7 = 0;
SET @idEquipo8 = 0;
SET @idEquipo9 = 0;
SET @idEquipo10 = 0;
CALL altaEquipo('Boca Juniors', @idEquipo1);                -- id_equipo = 1
CALL altaEquipo('River Plate', @idEquipo2);                 -- id_equipo = 2
CALL altaEquipo('San Lorenzo', @idEquipo3);                 -- id_equipo = 3
CALL altaEquipo('Independiente', @idEquipo4);               -- id_equipo = 4
CALL altaEquipo('Racing Club', @idEquipo5);                 -- id_equipo = 5
CALL altaEquipo('Vélez Sársfield', @idEquipo6);             -- id_equipo = 6
CALL altaEquipo('Argentinos Juniors', @idEquipo7);          -- id_equipo = 7
CALL altaEquipo('Estudiantes de La Plata', @idEquipo8);     -- id_equipo = 8
CALL altaEquipo('Olimpo', @idEquipo9);                      -- id_equipo = 9
CALL altaEquipo('Lanús', @idEquipo10);                      -- id_equipo = 10
//

-- ===================================
-- 4. INSERTAR JUGADORES (Para Tests)
-- ===================================
SET @idJugador1 = 0;
SET @idJugador2 = 0;
SET @idJugador3 = 0;
SET @idJugador4 = 0;
SET @idJugador5 = 0;
SET @idJugador6 = 0;
SET @idJugador7 = 0;
SET @idJugador8 = 0;

-- Arqueros (id_tipo = 1)
CALL altaJugador('Juan', 'Musso', 'JM', '1992-03-11', 5000000, 1, 1, @idJugador1);
CALL altaJugador('Franco', 'Armani', 'FA', '1986-10-16', 3000000, 1, 2, @idJugador2);

-- Defensores (id_tipo = 2)
CALL altaJugador('Carlos', 'Izquierdoz', 'CIZ', '1986-01-01', 4000000, 2, 1, @idJugador3);
CALL altaJugador('Gabriel', 'Mercado', 'GM', '1987-03-18', 3500000, 2, 2, @idJugador4);

-- Centrocampistas (id_tipo = 3)
CALL altaJugador('Cristian', 'Benavente', 'CB', '1994-04-21', 2500000, 3, 5, @idJugador5);
CALL altaJugador('Nicolás', 'Fernández', 'NF', '1995-06-15', 2200000, 3, 3, @idJugador6);

-- Delanteros (id_tipo = 4)
CALL altaJugador('Sebastián', 'Villa', 'SV', '1996-07-31', 6000000, 4, 1, @idJugador7);
CALL altaJugador('Rafael', 'Borré', 'RB', '1997-06-17', 5500000, 4, 2, @idJugador8);
//

-- ===================================
-- 5. INSERTAR USUARIOS (Para Tests)
-- ===================================
SET @idUsuario1 = 0;
SET @idUsuario2 = 0;
SET @idUsuario3 = 0;
SET @idUsuario4 = 0;

-- Usuarios regulares
CALL altaUsuario(
    'Juan', 'Pérez', 'juan.perez@test.com', '1990-01-15', 
    'A1B2C3D4E5F67890A1B2C3D4E5F67890A1B2C3D4E5F67890A1B2C3D4E5F67890', 1, @idUsuario1
);

CALL altaUsuario(
    'María', 'García', 'maria.garcia@test.com', '1992-05-22', 
    'B1B2C3D4E5F67890A1B2C3D4E5F67890A1B2C3D4E5F67890A1B2C3D4E5F67890', 1, @idUsuario2
);

CALL altaUsuario(
    'Carlos', 'López', 'carlos.lopez@test.com', '1988-12-10', 
    'C1B2C3D4E5F67890A1B2C3D4E5F67890A1B2C3D4E5F67890A1B2C3D4E5F67890', 2, @idUsuario3
);

CALL altaUsuario(
    'Ana', 'Martínez', 'ana.martinez@test.com', '1995-03-30', 
    'D1B2C3D4E5F67890A1B2C3D4E5F67890A1B2C3D4E5F67890A1B2C3D4E5F67890', 1, @idUsuario4
);
//

-- ===================================
-- 6. INSERTAR PLANTILLAS (Para Tests)
-- ===================================
SET @idPlantilla1 = 0;
SET @idPlantilla2 = 0;
SET @idPlantilla3 = 0;
SET @idPlantilla4 = 0;

CALL altaPlantilla(10000000, 1, 1, '2025-01-01', @idPlantilla1);
CALL altaPlantilla(8500000, 1, 2, '2025-01-02', @idPlantilla2);
CALL altaPlantilla(12000000, 2, 1, '2025-01-03', @idPlantilla3);
CALL altaPlantilla(7500000, 4, 2, '2025-01-04', @idPlantilla4);
//

-- ===================================
-- 7. INSERTAR PLANTILLA JUGADORES (Para Tests)
-- ===================================
-- Plantilla 1 (id_plantilla = 1, id_usuario = 1)
CALL altaPlantillaJugador(1, 1, 1);  -- Musso - Titular
CALL altaPlantillaJugador(3, 1, 1);  -- Izquierdoz - Titular
CALL altaPlantillaJugador(5, 1, 1);  -- Benavente - Titular
CALL altaPlantillaJugador(7, 1, 1);  -- Villa - Titular

-- Plantilla 2 (id_plantilla = 2, id_usuario = 1)
CALL altaPlantillaJugador(2, 2, 1);  -- Armani - Titular
CALL altaPlantillaJugador(4, 2, 0);  -- Mercado - Suplente
CALL altaPlantillaJugador(6, 2, 0);  -- Fernández - Suplente
CALL altaPlantillaJugador(8, 2, 1);  -- Borré - Titular

-- Plantilla 3 (id_plantilla = 3, id_usuario = 2)
CALL altaPlantillaJugador(1, 3, 1);  -- Musso - Titular
CALL altaPlantillaJugador(5, 3, 1);  -- Benavente - Titular
CALL altaPlantillaJugador(7, 3, 1);  -- Villa - Titular

-- Plantilla 4 (id_plantilla = 4, id_usuario = 4)
CALL altaPlantillaJugador(2, 4, 1);  -- Armani - Titular
CALL altaPlantillaJugador(8, 4, 1);  -- Borré - Titular
//

-- ===================================
-- 8. INSERTAR PUNTUACIONES (Para Tests)
-- ===================================
SET @idPuntuacion1 = 0;
SET @idPuntuacion2 = 0;
SET @idPuntuacion3 = 0;
SET @idPuntuacion4 = 0;
SET @idPuntuacion5 = 0;
SET @idPuntuacion6 = 0;
SET @idPuntuacion7 = 0;
SET @idPuntuacion8 = 0;
SET @idPuntuacion9 = 0;
SET @idPuntuacion10 = 0;
SET @idPuntuacion11 = 0;
SET @idPuntuacion12 = 0;
SET @idPuntuacion13 = 0;
SET @idPuntuacion14 = 0;

-- Puntuaciones para Musso (id_jugador = 1)
CALL altaPuntuacion(1, 8.5, '2025-01-08', @idPuntuacion1);  -- Fecha 1
CALL altaPuntuacion(1, 7.0, '2025-01-15', @idPuntuacion2);  -- Fecha 2
CALL altaPuntuacion(1, 9.0, '2025-01-22', @idPuntuacion3);  -- Fecha 3

-- Puntuaciones para Izquierdoz (id_jugador = 3)
CALL altaPuntuacion(3, 7.5, '2025-01-08', @idPuntuacion4);  -- Fecha 1
CALL altaPuntuacion(3, 8.0, '2025-01-15', @idPuntuacion5);  -- Fecha 2

-- Puntuaciones para Villa (id_jugador = 7)
CALL altaPuntuacion(7, 8.0, '2025-01-08', @idPuntuacion6);  -- Fecha 1
CALL altaPuntuacion(7, 9.5, '2025-01-15', @idPuntuacion7);  -- Fecha 2
CALL altaPuntuacion(7, 7.5, '2025-01-22', @idPuntuacion8);  -- Fecha 3

-- Puntuaciones para Armani (id_jugador = 2)
CALL altaPuntuacion(2, 6.5, '2025-01-08', @idPuntuacion9);  -- Fecha 1
CALL altaPuntuacion(2, 7.5, '2025-01-15', @idPuntuacion10); -- Fecha 2

-- Puntuaciones para Benavente (id_jugador = 5)
CALL altaPuntuacion(5, 6.0, '2025-01-08', @idPuntuacion11); -- Fecha 1
CALL altaPuntuacion(5, 7.0, '2025-01-15', @idPuntuacion12); -- Fecha 2
CALL altaPuntuacion(5, 8.0, '2025-01-22', @idPuntuacion13); -- Fecha 3

-- Puntuaciones para Borré (id_jugador = 8)
CALL altaPuntuacion(8, 9.0, '2025-01-08', @idPuntuacion14); -- Fecha 1
-- ===================================
-- 9. INSERTAR 50 JUGADORES ADICIONALES
-- ===================================
-- Se asume que las variables @idJugadorX ya han sido declaradas.
-- Los nuevos IDs de jugador comenzarán a partir del 9.

-- Arqueros (id_tipo = 1)
CALL altaJugador('Gerónimo', 'Rulli', 'GR', '1992-05-20', 4800000, 1, 3, @idJugador9);
CALL altaJugador('Esteban', 'Andrada', 'EA', '1991-01-26', 3200000, 1, 4, @idJugador10);
CALL altaJugador('Guido', 'Herrera', 'GH', '1992-02-29', 2800000, 1, 5, @idJugador11);
CALL altaJugador('Agustín', 'Rossi', 'AR', '1995-08-21', 3000000, 1, 6, @idJugador12);
CALL altaJugador('Marcos', 'Díaz', 'MDZ', '1986-02-05', 1500000, 1, 7, @idJugador13);
CALL altaJugador('Fernando', 'Muslera', 'FM', '1986-06-16', 4000000, 1, 8, @idJugador14);
CALL altaJugador('Juan', 'Mussi', 'JMS', '1994-09-11', 1200000, 1, 9, @idJugador15);

-- Defensores (id_tipo = 2)
CALL altaJugador('Gonzalo', 'Montiel', 'GMNT', '1997-01-01', 5100000, 2, 2, @idJugador16);
CALL altaJugador('Lisandro', 'López', 'LL', '1989-08-25', 3800000, 2, 1, @idJugador17);
CALL altaJugador('Javier', 'Pinola', 'JP', '1983-02-24', 1800000, 2, 2, @idJugador18);
CALL altaJugador('Fabricio', 'Bustos', 'FB', '1996-04-29', 3000000, 2, 4, @idJugador19);
CALL altaJugador('Emanuel', 'Mas', 'EM', '1989-01-15', 2500000, 2, 5, @idJugador20);
CALL altaJugador('Lucas', 'Martínez', 'LMTZ', '1996-05-10', 4500000, 2, 6, @idJugador21);
CALL altaJugador('Leandro', 'González', 'LGZ', '1991-05-20', 1600000, 2, 7, @idJugador22);
CALL altaJugador('Marcos', 'Rojo', 'MRJ', '1990-03-20', 3100000, 2, 8, @idJugador23);
CALL altaJugador('Walter', 'Kannemann', 'WK', '1991-03-14', 4200000, 2, 3, @idJugador24);
CALL altaJugador('Juan', 'Foyth', 'JF', '1998-01-12', 6500000, 2, 10, @idJugador25);
CALL altaJugador('Ramiro', 'Funes Mori', 'RFM', '1991-05-05', 2900000, 2, 2, @idJugador26);
CALL altaJugador('Leonardo', 'Jara', 'LJ', '1991-05-25', 2000000, 2, 1, @idJugador27);
CALL altaJugador('Guillermo', 'Soto', 'GS', '1994-07-28', 1900000, 2, 3, @idJugador28);
CALL altaJugador('Lautaro', 'Giannetti', 'LGI', '1993-11-13', 3300000, 2, 6, @idJugador29);

-- Centrocampistas (id_tipo = 3)
CALL altaJugador('Exequiel', 'Palacios', 'EP', '1998-10-05', 5500000, 3, 2, @idJugador30);
CALL altaJugador('Nacho', 'Fernández', 'NFZ', '1990-01-12', 4300000, 3, 2, @idJugador31);
CALL altaJugador('Guido', 'Rodríguez', 'GRD', '1994-04-12', 6200000, 3, 7, @idJugador32);
CALL altaJugador('Enzo', 'Pérez', 'EPZ', '1986-02-22', 2500000, 3, 2, @idJugador33);
CALL altaJugador('Edwin', 'Cardona', 'EC', '1992-12-08', 3000000, 3, 1, @idJugador34);
CALL altaJugador('Ricardo', 'Centurión', 'RC', '1993-01-19', 2100000, 3, 5, @idJugador35);
CALL altaJugador('Maximiliano', 'Meza', 'MM', '1992-12-15', 3800000, 3, 4, @idJugador36);
CALL altaJugador('Santiago', 'Cáceres', 'SC', '1999-05-18', 2600000, 3, 6, @idJugador37);
CALL altaJugador('Fausto', 'Vera', 'FV', '2000-03-26', 1700000, 3, 7, @idJugador38);
CALL altaJugador('Alexis', 'Mac Allister', 'AMA', '1998-12-24', 4700000, 3, 8, @idJugador39);
CALL altaJugador('Rodrigo', 'De Paul', 'RDP', '1994-05-24', 5900000, 3, 10, @idJugador40);
CALL altaJugador('Iván', 'Marcone', 'IM', '1990-06-04', 2400000, 3, 1, @idJugador41);
CALL altaJugador('Christian', 'Cueva', 'CCV', '1991-11-23', 1900000, 3, 3, @idJugador42);
CALL altaJugador('Lucas', 'Zelarayán', 'LZ', '1992-06-20', 3500000, 3, 9, @idJugador43);
CALL altaJugador('Mauro', 'Zárate', 'MZ', '1987-03-18', 1500000, 3, 6, @idJugador44);
CALL altaJugador('Damián', 'Musto', 'DM', '1987-05-31', 1100000, 3, 4, @idJugador45);

-- Delanteros (id_tipo = 4)
CALL altaJugador('Lautaro', 'Martínez', 'LMTZ', '1997-08-22', 7000000, 4, 5, @idJugador46);
CALL altaJugador('Darío', 'Benedetto', 'DB', '1990-05-13', 4900000, 4, 1, @idJugador47);
CALL altaJugador('Mauro', 'Icardi', 'MI', '1993-02-19', 8500000, 4, 3, @idJugador48);
CALL altaJugador('Sergio', 'Agüero', 'SA', '1988-06-02', 6000000, 4, 7, @idJugador49);
CALL altaJugador('Lucas', 'Pratto', 'LP', '1988-06-04', 2800000, 4, 2, @idJugador50);
CALL altaJugador('Wanchope', 'Ábila', 'WA', '1989-10-06', 2200000, 4, 1, @idJugador51);
CALL altaJugador('José', 'López', 'JL', '2000-12-06', 1800000, 4, 10, @idJugador52);
CALL altaJugador('Ramón', 'Ábila', 'RBA', '1991-09-06', 1500000, 4, 8, @idJugador53);
CALL altaJugador('Cristian', 'Tarragona', 'CT', '1991-03-09', 1200000, 4, 9, @idJugador54);
CALL altaJugador('Julián', 'Álvarez', 'JAZ', '2000-01-31', 6800000, 4, 2, @idJugador55);
CALL altaJugador('Adam', 'Bari', 'AB', '1995-12-05', 1000000, 4, 4, @idJugador56);
CALL altaJugador('Nicolás', 'Blandi', 'NB', '1990-01-13', 2000000, 4, 3, @idJugador57);
CALL altaJugador('Carlos', 'Tevez', 'CTZ', '1984-02-05', 1500000, 4, 1, @idJugador58);
CALL altaJugador('Lisandro', 'López', 'LL2', '1983-03-02', 1000000, 4, 5, @idJugador59);
CALL altaJugador('Mateo', 'Retegui', 'MR', '1999-04-29', 3000000, 4, 6, @idJugador60);
CALL altaJugador('Michael', 'Santos', 'MS', '1993-03-13', 1700000, 4, 7, @idJugador61);
CALL altaJugador('Alejandro', 'Gómez', 'AG', '1988-02-15', 4500000, 4, 10, @idJugador62);
CALL altaJugador('Angel', 'Romero', 'ARV', '1992-07-04', 2300000, 4, 3, @idJugador63);
CALL altaJugador('Juan', 'Cazares', 'JCR', '1992-04-03', 1600000, 4, 4, @idJugador64);

-- Fin de inserciones adicionales
//

DELIMITER ;

-- ===================================
-- VERIFICACIÓN DE DATOS INSERTADOS
-- ===================================
SELECT 'Roles insertados:' AS Verificacion;
SELECT * FROM Gran_DT.Rol;

SELECT 'Tipos de Jugador insertados:' AS Verificacion;
SELECT * FROM Gran_DT.TipoJugador;

SELECT 'Equipos insertados:' AS Verificacion;
SELECT * FROM Gran_DT.Equipo;

SELECT 'Jugadores insertados:' AS Verificacion;
SELECT * FROM Gran_DT.Jugador;

SELECT 'Usuarios insertados:' AS Verificacion;
SELECT id_usuario, nombre, apellido, email FROM Gran_DT.Usuario;

SELECT 'Plantillas insertadas:' AS Verificacion;
SELECT * FROM Gran_DT.Plantilla;

SELECT 'Plantilla-Jugadores insertados:' AS Verificacion;
SELECT * FROM Gran_DT.PlantillaJugador;

SELECT 'Puntuaciones insertadas:' AS Verificacion;
SELECT * FROM Gran_DT.Puntuacion;

-- ===================================
-- VERIFICACIÓN DE DATOS INSERTADOS
-- ===================================
SELECT 'Roles insertados:' AS Verificacion;
SELECT * FROM Gran_DT.Rol;

SELECT 'Tipos de Jugador insertados:' AS Verificacion;
SELECT * FROM Gran_DT.TipoJugador;

SELECT 'Equipos insertados:' AS Verificacion;
SELECT * FROM Gran_DT.Equipo;

SELECT 'Jugadores insertados:' AS Verificacion;
SELECT * FROM Gran_DT.Jugador;

SELECT 'Usuarios insertados:' AS Verificacion;
SELECT id_usuario, nombre, apellido, email FROM Gran_DT.Usuario;

SELECT 'Plantillas insertadas:' AS Verificacion;
SELECT * FROM Gran_DT.Plantilla;

SELECT 'Plantilla-Jugadores insertados:' AS Verificacion;
SELECT * FROM Gran_DT.PlantillaJugador;

SELECT 'Puntuaciones insertadas:' AS Verificacion;
SELECT * FROM Gran_DT.Puntuacion;

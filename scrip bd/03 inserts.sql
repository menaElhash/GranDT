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

CALL altaPlantilla(10000000, 1, '2025-01-01', @idPlantilla1);
CALL altaPlantilla(8500000, 1, '2025-01-02', @idPlantilla2);
CALL altaPlantilla(12000000, 2, '2025-01-03', @idPlantilla3);
CALL altaPlantilla(7500000, 4, '2025-01-04', @idPlantilla4);
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

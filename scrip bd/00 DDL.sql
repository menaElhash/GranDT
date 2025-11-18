DROP SCHEMA IF EXISTS Gran_DT;
-- -----------------------------------------------------
-- Schema Gran_DT
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `Gran_DT`;
USE `Gran_DT`;

-- -----------------------------------------------------
-- Table `Gran_DT`.`Equipo`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Gran_DT`.`Equipo` (
  `id_equipo` INT NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id_equipo`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Gran_DT`.`TipoJugador`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Gran_DT`.`TipoJugador` (
  `id_tipo` INT NOT NULL AUTO_INCREMENT,
  `descripcion` VARCHAR(45) NULL,
  PRIMARY KEY (`id_tipo`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Gran_DT`.`Jugador`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Gran_DT`.`Jugador` (
  `id_jugador` INT NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(45) NOT NULL,
  `apellido` VARCHAR(45) NOT NULL,
  `apodo` VARCHAR(45) NULL,
  `fecha_nacimiento` DATE NOT NULL,
  `cotizacion` DECIMAL(10,2) NOT NULL,
  `id_tipo` INT NULL,
  `id_equipo` INT NOT NULL,
  PRIMARY KEY (`id_jugador`),
  INDEX `fk_Jugador_Equipo_idx` (`id_equipo` ASC) VISIBLE,
  INDEX `fk_Jugador_TipoJugador1_idx` (`id_tipo` ASC) VISIBLE,
  CONSTRAINT `fk_Jugador_Equipo`
    FOREIGN KEY (`id_equipo`)
    REFERENCES `Gran_DT`.`Equipo` (`id_equipo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Jugador_TipoJugador1`
    FOREIGN KEY (`id_tipo`)
    REFERENCES `Gran_DT`.`TipoJugador` (`id_tipo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Gran_DT`.`Rol`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Gran_DT`.`Rol` (
  `id_rol` INT NOT NULL AUTO_INCREMENT,
  `descrpcion` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id_rol`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Gran_DT`.`Usuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Gran_DT`.`Usuario` (
  `id_usuario` INT NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(45) NOT NULL,
  `apellido` VARCHAR(45) NOT NULL,
  `email` VARCHAR(100) NOT NULL UNIQUE, -- Añadido UNIQUE para el email
  `fecha_nacimiento` DATE NOT NULL,
  `password` CHAR(64) NOT NULL,
  `id_rol` INT NULL,
  PRIMARY KEY (`id_usuario`),
  INDEX `fk_Usuario_Rol1_idx` (`id_rol` ASC) VISIBLE,
  CONSTRAINT `fk_Usuario_Rol1`
    FOREIGN KEY (`id_rol`)
    REFERENCES `Gran_DT`.`Rol` (`id_rol`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Gran_DT`.`Plantilla`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Gran_DT`.`Plantilla` (
  `id_plantilla` INT NOT NULL AUTO_INCREMENT,
  `id_usuario` INT NOT NULL,
  `id_equipo` INT NOT NULL,
  `presupuesto_max` DECIMAL(10,2) NOT NULL,
  `fecha_creacion` DATE NOT NULL,
  PRIMARY KEY (`id_plantilla`),
  INDEX `fk_Plantilla_Usuario1_idx` (`id_usuario` ASC) VISIBLE,
  INDEX `fk_Plantilla_Equipo1_idx` (`id_equipo` ASC) VISIBLE,
  CONSTRAINT `fk_Plantilla_Usuario1` -- CLAVE FORANEA CORREGIDA
    FOREIGN KEY (`id_usuario`)
    REFERENCES `Gran_DT`.`Usuario` (`id_usuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Plantilla_Equipo1`
    FOREIGN KEY (`id_equipo`)
    REFERENCES `Gran_DT`.`Equipo` (`id_equipo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Gran_DT`.`PlantillaJugador`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Gran_DT`.`PlantillaJugador` (
  `id_plantilla` INT NOT NULL,
  `id_jugador` INT NOT NULL,
  `es_titular` TINYINT NOT NULL,
  PRIMARY KEY (`id_plantilla`, `id_jugador`),
  INDEX `fk_PlantillaJugador_Jugador1_idx` (`id_jugador` ASC) VISIBLE,
  CONSTRAINT `fk_PlantillaJugador_Jugador1`
    FOREIGN KEY (`id_jugador`)
    REFERENCES `Gran_DT`.`Jugador` (`id_jugador`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_PlantillaJugador_Plantilla1` -- Añadida FK a Plantilla
    FOREIGN KEY (`id_plantilla`)
    REFERENCES `Gran_DT`.`Plantilla` (`id_plantilla`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Gran_DT`.`Puntuacion`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Gran_DT`.`Puntuacion` (
  `id_puntucion` INT NOT NULL AUTO_INCREMENT,
  `id_jugador` INT NOT NULL,
  `nota` DECIMAL(3,1) NOT NULL, -- Corregido para incluir 1 decimal
  `fecha_numero` DATE NOT NULL,
  PRIMARY KEY (`id_puntucion`), -- Se quita id_jugador de la PK para que sea un registro único
  INDEX `fk_Puntuacion_Jugador1_idx` (`id_jugador` ASC) VISIBLE,
  CONSTRAINT `fk_Puntuacion_Jugador1`
    FOREIGN KEY (`id_jugador`)
    REFERENCES `Gran_DT`.`Jugador` (`id_jugador`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema FireDump
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema FireDump
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `FireDump` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `FireDump` ;

-- -----------------------------------------------------
-- Table `FireDump`.`mysql_servers`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `FireDump`.`mysql_servers` (
  `id` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `name` VARCHAR(80) NOT NULL COMMENT '',
  `port` INT NOT NULL COMMENT '',
  `host` TEXT NOT NULL COMMENT '',
  `username` VARCHAR(45) NOT NULL COMMENT '',
  `password` VARCHAR(45) NOT NULL COMMENT '',
  PRIMARY KEY (`id`)  COMMENT '')
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `FireDump`.`schedules`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `FireDump`.`schedules` (
  `id` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `server_id` INT NOT NULL COMMENT '',
  `name` VARCHAR(45) NOT NULL COMMENT '',
  `date` DATETIME NULL COMMENT '',
  `activated` TINYINT(1) NOT NULL COMMENT '',
  `hours` INT NOT NULL COMMENT '',
  PRIMARY KEY (`id`)  COMMENT '',
  INDEX `server_id_key_idx` (`server_id` ASC)  COMMENT '',
  CONSTRAINT `server_id_key`
    FOREIGN KEY (`server_id`)
    REFERENCES `FireDump`.`mysql_servers` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `FireDump`.`logs`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `FireDump`.`logs` (
  `id` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `schedule_id` INT NULL COMMENT '',
  `type` INT NOT NULL COMMENT '',
  `message` TEXT NULL COMMENT '',
  `date` DATETIME NULL COMMENT '',
  `success` TINYINT(1) NULL COMMENT '',
  PRIMARY KEY (`id`)  COMMENT '',
  INDEX `schedule_id_key_idx` (`schedule_id` ASC)  COMMENT '',
  CONSTRAINT `schedule_id_key`
    FOREIGN KEY (`schedule_id`)
    REFERENCES `FireDump`.`schedules` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `FireDump`.`userinfo`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `FireDump`.`userinfo` (
  `id` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `schedule_id` INT NULL COMMENT '',
  `successemail` VARCHAR(45) NULL COMMENT '',
  `failemail` VARCHAR(45) NULL COMMENT '',
  PRIMARY KEY (`id`)  COMMENT '',
  INDEX `shedule_id_key_2_idx` (`schedule_id` ASC)  COMMENT '',
  CONSTRAINT `shedule_id_key_2`
    FOREIGN KEY (`schedule_id`)
    REFERENCES `FireDump`.`schedules` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `FireDump`.`backup_locations`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `FireDump`.`backup_locations` (
  `id` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `name` VARCHAR(45) NULL COMMENT '',
  `username` VARCHAR(45) NULL COMMENT '',
  `password` VARCHAR(45) NULL COMMENT '',
  `path` TEXT NULL COMMENT '',
  PRIMARY KEY (`id`)  COMMENT '')
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `FireDump`.`schedule_save_locations`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `FireDump`.`schedule_save_locations` (
  `id` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `schedule_id` INT NULL COMMENT '',
  `service_type` INT NULL COMMENT '',
  `backup_location_id` INT NULL COMMENT '',
  PRIMARY KEY (`id`)  COMMENT '',
  INDEX `schedule_id_key4_idx` (`schedule_id` ASC)  COMMENT '',
  INDEX `backup_location_id_key_idx` (`backup_location_id` ASC)  COMMENT '',
  CONSTRAINT `schedule_id_key4`
    FOREIGN KEY (`schedule_id`)
    REFERENCES `FireDump`.`schedules` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `backup_location_id_key`
    FOREIGN KEY (`backup_location_id`)
    REFERENCES `FireDump`.`backup_locations` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

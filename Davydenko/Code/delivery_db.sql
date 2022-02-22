/* SQL Manager Lite for MySQL                              5.9.0.55065 */
/* ------------------------------------------------------------------- */
/* Host     : localhost                                                */
/* Port     : 3306                                                     */
/* Database : delivery_db                                              */


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES 'utf8mb4' */;

SET FOREIGN_KEY_CHECKS=0;

DROP DATABASE IF EXISTS `delivery_db`;

CREATE DATABASE `delivery_db`
    CHARACTER SET 'utf8'
    COLLATE 'utf8_general_ci';

USE `delivery_db`;

/* Удаление объектов БД */

DROP TRIGGER IF EXISTS `ordered_after_del_tr2`;
DROP TRIGGER IF EXISTS `ordered_after_del_tr1`;
DROP TRIGGER IF EXISTS `ordered_after_ins_tr1`;
DROP TRIGGER IF EXISTS `client_after_del`;
DROP VIEW IF EXISTS `view2`;
DROP VIEW IF EXISTS `view1`;
DROP TABLE IF EXISTS `ordered_item`;
DROP TABLE IF EXISTS `item`;
DROP TABLE IF EXISTS `component_item`;
DROP TABLE IF EXISTS `component`;
DROP TABLE IF EXISTS `client`;
DROP TABLE IF EXISTS `ordered`;
DROP TABLE IF EXISTS `operator`;
DROP TABLE IF EXISTS `delivery`;

/* Структура для таблицы `delivery`:  */

CREATE TABLE `delivery` (
  `id_del` BIGINT NOT NULL AUTO_INCREMENT,
  `transport` CHAR(15) COLLATE utf8_general_ci DEFAULT NULL,
  PRIMARY KEY USING BTREE (`id_del`)
) ENGINE=InnoDB
AUTO_INCREMENT=4 ROW_FORMAT=DYNAMIC CHARACTER SET 'utf8' COLLATE 'utf8_general_ci';

/* Структура для таблицы `operator`:  */

CREATE TABLE `operator` (
  `id_op` INTEGER NOT NULL AUTO_INCREMENT,
  `name_op` CHAR(15) COLLATE utf8_general_ci NOT NULL,
  `busy` TINYINT(1) DEFAULT 0,
  PRIMARY KEY USING BTREE (`id_op`)
) ENGINE=InnoDB
AUTO_INCREMENT=4 ROW_FORMAT=DYNAMIC CHARACTER SET 'utf8' COLLATE 'utf8_general_ci';

/* Структура для таблицы `ordered`:  */

CREATE TABLE `ordered` (
  `id_order` INTEGER NOT NULL AUTO_INCREMENT,
  `comment` CHAR(100) COLLATE utf8_general_ci DEFAULT NULL,
  `id_op` INTEGER DEFAULT NULL,
  `id_del` BIGINT DEFAULT NULL,
  PRIMARY KEY USING BTREE (`id_order`),
  KEY `IX_serves` USING BTREE (`id_op`),
  KEY `IX_deliver` USING BTREE (`id_del`),
  CONSTRAINT `deliver` FOREIGN KEY (`id_del`) REFERENCES `delivery` (`id_del`) ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT `serves` FOREIGN KEY (`id_op`) REFERENCES `operator` (`id_op`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB
AUTO_INCREMENT=8 ROW_FORMAT=DYNAMIC CHARACTER SET 'utf8' COLLATE 'utf8_general_ci';

/* Структура для таблицы `client`:  */

CREATE TABLE `client` (
  `id_client` INTEGER NOT NULL AUTO_INCREMENT,
  `fio` CHAR(50) COLLATE utf8_general_ci NOT NULL,
  `address` CHAR(50) COLLATE utf8_general_ci NOT NULL,
  `ph_number` CHAR(15) COLLATE utf8_general_ci NOT NULL,
  `id_order` INTEGER DEFAULT NULL,
  PRIMARY KEY USING BTREE (`id_client`),
  KEY `IX_created` USING BTREE (`id_order`),
  CONSTRAINT `fixed` FOREIGN KEY (`id_order`) REFERENCES `ordered` (`id_order`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB
AUTO_INCREMENT=4 ROW_FORMAT=DYNAMIC CHARACTER SET 'utf8' COLLATE 'utf8_general_ci';

/* Структура для таблицы `component`:  */

CREATE TABLE `component` (
  `id_comp` INTEGER NOT NULL AUTO_INCREMENT,
  `name_com` CHAR(30) COLLATE utf8_general_ci NOT NULL,
  `available` TINYINT(1) NOT NULL DEFAULT 1,
  PRIMARY KEY USING BTREE (`id_comp`)
) ENGINE=InnoDB
AUTO_INCREMENT=10 ROW_FORMAT=DYNAMIC CHARACTER SET 'utf8' COLLATE 'utf8_general_ci';

/* Структура для таблицы `component_item`:  */

CREATE TABLE `component_item` (
  `id_comp` INTEGER NOT NULL,
  `id_item` INTEGER NOT NULL
) ENGINE=InnoDB
ROW_FORMAT=DYNAMIC CHARACTER SET 'utf8' COLLATE 'utf8_general_ci';

/* Структура для таблицы `item`:  */

CREATE TABLE `item` (
  `id_item` INTEGER NOT NULL AUTO_INCREMENT,
  `name_item` CHAR(30) COLLATE utf8_general_ci NOT NULL,
  `price` INTEGER NOT NULL,
  `description` CHAR(100) COLLATE utf8_general_ci DEFAULT NULL,
  PRIMARY KEY USING BTREE (`id_item`)
) ENGINE=InnoDB
AUTO_INCREMENT=7 ROW_FORMAT=DYNAMIC CHARACTER SET 'utf8' COLLATE 'utf8_general_ci';

/* Структура для таблицы `ordered_item`:  */

CREATE TABLE `ordered_item` (
  `id_order` INTEGER NOT NULL,
  `id_item` INTEGER NOT NULL
) ENGINE=InnoDB
ROW_FORMAT=DYNAMIC CHARACTER SET 'utf8' COLLATE 'utf8_general_ci';

/* Определение для представления `view1`:  */

CREATE ALGORITHM=UNDEFINED DEFINER='root'@'localhost' SQL SECURITY DEFINER VIEW `view1`
AS
select
  `client`.`fio` AS `ФИО`,
  `client`.`ph_number` AS `Номер телефона`,
  `client`.`address` AS `Адрес`,
  `client`.`id_order` AS `Номер заказа`,
  `ordered`.`comment` AS `Комментарий`
from
  (`client`
  join `ordered`)
where
  (`client`.`id_order` = `ordered`.`id_order`);

/* Определение для представления `view2`:  */

CREATE ALGORITHM=UNDEFINED DEFINER='root'@'localhost' SQL SECURITY DEFINER VIEW `view2`
AS
select
  `ordered`.`id_order` AS `Номер заказа`,
  `item`.`name_item` AS `Позиция`,
  `item`.`id_item` AS `Номер позиции`
from
  ((`ordered`
  join `item`)
  join `ordered_item`)
where
  ((`ordered`.`id_order` = `ordered_item`.`id_order`) and
  (`ordered_item`.`id_item` = `item`.`id_item`));

/* Data for the `delivery` table  (LIMIT 0,500) */

INSERT INTO `delivery` (`id_del`, `transport`) VALUES
  (1,'car'),
  (2,'cycle'),
  (3,'none');
COMMIT;

/* Data for the `operator` table  (LIMIT 0,500) */

INSERT INTO `operator` (`id_op`, `name_op`, `busy`) VALUES
  (1,'Ekaterina',0),
  (2,'Margarete',0),
  (3,'Stas',0),
  (4,'Orcadiy',0),
  (5,'Ivan',0);
COMMIT;

/* Data for the `client` table  (LIMIT 0,500) */

INSERT INTO `client` (`id_client`, `fio`, `address`, `ph_number`, `id_order`) VALUES
  (1,'Давыденко Антон','Лазурная 36, 10','(983) 606-7248',NULL),
  (2,'Карбышева','Гоголя д1 кв 10','(800) 000-0001',NULL),
  (4,'Толстой Л. Н.','Пушкина 10 д 36','(221) 123-3218',NULL),
  (5,'Александров Е.В','Комсомольская дом 12 кв 23','(882) 269-1232',NULL);
COMMIT;

/* Data for the `component` table  (LIMIT 0,500) */

INSERT INTO `component` (`id_comp`, `name_com`, `available`) VALUES
  (1,'Sausege',1),
  (2,'Sause',0),
  (3,'Another Sause',1),
  (4,'Pinapple',1),
  (5,'Pickled cucumber',1),
  (6,'Tomato',1),
  (7,'Bacon',1),
  (8,'Pepper',1),
  (9,'Cheese',1),
  (10,'Another_Cheese',1);
COMMIT;

/* Data for the `component_item` table  (LIMIT 0,500) */

INSERT INTO `component_item` (`id_comp`, `id_item`) VALUES
  (1,2),
  (2,2),
  (10,2),
  (9,3),
  (9,1),
  (1,3),
  (2,3),
  (4,3),
  (5,3),
  (6,3),
  (7,3),
  (8,3),
  (7,4),
  (9,4),
  (8,4),
  (7,4),
  (5,5),
  (4,5),
  (6,5),
  (1,6),
  (10,6),
  (7,6);
COMMIT;

/* Data for the `item` table  (LIMIT 0,500) */

INSERT INTO `item` (`id_item`, `name_item`, `price`, `description`) VALUES
  (1,'Standart Cheese',100,'Standart Cheese pizza'),
  (2,'Standart Sausage',150,'Standart Sausage pizza'),
  (3,'Mix',500,'Mixed pizza'),
  (4,'Alternate Sausage',150,'Sauage pizza with another sause'),
  (5,'Vegetable',50,'Pizza without meat'),
  (6,'With bacon',200,'Standart pizza with bacon');
COMMIT;

/* Definition for the `client_after_del` trigger : */

DELIMITER $$

CREATE DEFINER = 'root'@'localhost' TRIGGER `client_after_del` AFTER DELETE ON `client`
  FOR EACH ROW
begin
delete from `ordered` WHERE `ordered`.`id_order` = OLD.id_order;
end$$

DELIMITER ;

/* Definition for the `ordered_after_ins_tr1` trigger : */

DELIMITER $$

CREATE DEFINER = 'root'@'localhost' TRIGGER `ordered_after_ins_tr1` AFTER INSERT ON `ordered`
  FOR EACH ROW
BEGIN
update operator set `operator`.`busy` = 1 where `operator`.`id_op` = NEW.id_op;
END$$

DELIMITER ;

/* Definition for the `ordered_after_del_tr1` trigger : */

DELIMITER $$

CREATE DEFINER = 'root'@'localhost' TRIGGER `ordered_after_del_tr1` AFTER DELETE ON `ordered`
  FOR EACH ROW
BEGIN
delete from `ordered_item` WHERE `ordered_item`.`id_order` = OLD.id_order;
END$$

DELIMITER ;

/* Definition for the `ordered_after_del_tr2` trigger : */

DELIMITER $$

CREATE DEFINER = 'root'@'localhost' TRIGGER `ordered_after_del_tr2` AFTER DELETE ON `ordered`
  FOR EACH ROW
BEGIN
update operator set `operator`.`busy` = 0 where `operator`.`id_op` = OLD.id_op;
END$$

DELIMITER ;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

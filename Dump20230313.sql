-- MySQL dump 10.13  Distrib 8.0.30, for Win64 (x86_64)
--
-- Host: localhost    Database: theaternyreck
-- ------------------------------------------------------
-- Server version	8.0.30

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `contract`
--

DROP TABLE IF EXISTS `contract`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `contract` (
  `ContractId` int NOT NULL AUTO_INCREMENT,
  `ContractActorId` int DEFAULT NULL,
  `ContractDirectorId` int DEFAULT NULL,
  `ContractShowId` int DEFAULT NULL,
  `ContractStatusId` int DEFAULT NULL,
  `ContractFee` int DEFAULT NULL,
  PRIMARY KEY (`ContractId`),
  KEY `ContractActorId` (`ContractActorId`),
  KEY `ContractDirectorId` (`ContractDirectorId`),
  KEY `ContractShowId` (`ContractShowId`),
  KEY `ContractStatusId` (`ContractStatusId`),
  CONSTRAINT `contract_ibfk_1` FOREIGN KEY (`ContractActorId`) REFERENCES `users` (`UserId`),
  CONSTRAINT `contract_ibfk_2` FOREIGN KEY (`ContractDirectorId`) REFERENCES `users` (`UserId`),
  CONSTRAINT `contract_ibfk_3` FOREIGN KEY (`ContractShowId`) REFERENCES `shows` (`ShowId`),
  CONSTRAINT `contract_ibfk_4` FOREIGN KEY (`ContractStatusId`) REFERENCES `contractstatus` (`ContractStatusId`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contract`
--

LOCK TABLES `contract` WRITE;
/*!40000 ALTER TABLE `contract` DISABLE KEYS */;
INSERT INTO `contract` VALUES (6,3,2,1,2,5000),(7,4,2,2,1,7000),(8,5,2,3,2,10000),(9,3,2,2,2,6000),(10,4,2,4,3,8000);
/*!40000 ALTER TABLE `contract` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `contractstatus`
--

DROP TABLE IF EXISTS `contractstatus`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `contractstatus` (
  `ContractStatusId` int NOT NULL AUTO_INCREMENT,
  `ContractStatusName` varchar(150) DEFAULT NULL,
  PRIMARY KEY (`ContractStatusId`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contractstatus`
--

LOCK TABLES `contractstatus` WRITE;
/*!40000 ALTER TABLE `contractstatus` DISABLE KEYS */;
INSERT INTO `contractstatus` VALUES (1,'Новый'),(2,'В ожидании подписания'),(3,'Действующий');
/*!40000 ALTER TABLE `contractstatus` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rewards`
--

DROP TABLE IF EXISTS `rewards`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rewards` (
  `RewardsId` int NOT NULL AUTO_INCREMENT,
  `RewardUserId` int DEFAULT NULL,
  `RewardName` varchar(150) DEFAULT NULL,
  PRIMARY KEY (`RewardsId`),
  KEY `RewardUserId` (`RewardUserId`),
  CONSTRAINT `rewards_ibfk_1` FOREIGN KEY (`RewardUserId`) REFERENCES `users` (`UserId`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rewards`
--

LOCK TABLES `rewards` WRITE;
/*!40000 ALTER TABLE `rewards` DISABLE KEYS */;
INSERT INTO `rewards` VALUES (1,4,'Лучший актер 2020'),(2,5,'Лучший актер 2021'),(3,4,'Награда за вклад в театр'),(4,3,'Лучшая мужская роль'),(5,5,'Лучшая женская роль');
/*!40000 ALTER TABLE `rewards` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roleuser`
--

DROP TABLE IF EXISTS `roleuser`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roleuser` (
  `RoleUserId` int NOT NULL AUTO_INCREMENT,
  `RoleUserName` varchar(150) DEFAULT NULL,
  PRIMARY KEY (`RoleUserId`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roleuser`
--

LOCK TABLES `roleuser` WRITE;
/*!40000 ALTER TABLE `roleuser` DISABLE KEYS */;
INSERT INTO `roleuser` VALUES (1,'Администратор'),(2,'Директор'),(3,'Актер');
/*!40000 ALTER TABLE `roleuser` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `shows`
--

DROP TABLE IF EXISTS `shows`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `shows` (
  `ShowId` int NOT NULL AUTO_INCREMENT,
  `ShowName` varchar(150) DEFAULT NULL,
  `ShowBudget` int DEFAULT NULL,
  `ShowDescription` varchar(250) DEFAULT NULL,
  `ShowData` datetime DEFAULT NULL,
  PRIMARY KEY (`ShowId`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `shows`
--

LOCK TABLES `shows` WRITE;
/*!40000 ALTER TABLE `shows` DISABLE KEYS */;
INSERT INTO `shows` VALUES (1,'Гамлет',500000,'Классическая трагедия Шекспира','2023-04-01 19:00:00'),(2,'Вишневый сад',700000,'Драма Чехова о прощании со старым миром','2023-05-10 18:30:00'),(3,'Одержимость',400000,'Танцевальный спектакль','2023-06-15 20:00:00'),(4,'Мастер и Маргарита',800000,'Мистическая драма по произведению Булгакова','2023-07-20 19:30:00'),(5,'Дон Жуан',600000,'Опера Моцарта','2023-08-25 18:00:00'),(6,'adssaddasf',123213,'132231123','2023-03-17 00:00:00');
/*!40000 ALTER TABLE `shows` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `UserId` int NOT NULL AUTO_INCREMENT,
  `UserRoleId` int DEFAULT NULL,
  `UserLogin` varchar(150) DEFAULT NULL,
  `UserPassword` varchar(150) DEFAULT NULL,
  `UserName` varchar(150) DEFAULT NULL,
  `UserSurname` varchar(150) DEFAULT NULL,
  `UserPatronimyc` varchar(150) DEFAULT NULL,
  PRIMARY KEY (`UserId`),
  KEY `UserRoleId` (`UserRoleId`),
  CONSTRAINT `users_ibfk_1` FOREIGN KEY (`UserRoleId`) REFERENCES `roleuser` (`RoleUserId`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,1,'admin','123','Иван','Иванов','Иванович'),(2,2,'director','password','Лехич','Петров','Петрович'),(3,3,'actor2','qwerty','Сидор','Сидоров','Сидорович'),(4,3,'actor1','secret','Андрей','Андреев','Андреевич'),(5,3,'actor2','test','Елена','Еленова','Еленовна'),(6,3,'qwe','qewewq','eqw','qewqwe','eqwqwe');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-03-13  1:41:51

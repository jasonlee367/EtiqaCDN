CREATE TABLE `aspnetusers` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `mail` varchar(256) NOT NULL,
  `EmailConfirmed` tinyint(1) DEFAULT NULL,
  `PasswordHash` longtext,
  `SecurityStamp` longtext,
  `PhoneNumber` longtext,
  `PhoneNumberConfirmed` tinyint(1) DEFAULT NULL,
  `TwoFactorEnabled` tinyint(1) DEFAULT NULL,
  `LockoutEndDateUtc` datetime DEFAULT NULL,
  `LockoutEnabled` tinyint(1) DEFAULT NULL,
  `AccessFailedCount` int DEFAULT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `DisplayName` varchar(256) DEFAULT NULL,
  `AccountType` varchar(256) DEFAULT NULL,
  `LoginStatus` int DEFAULT NULL,
  `PlainPassword` varchar(255) DEFAULT NULL,
  `ProfilePicture` varchar(1000) DEFAULT NULL,
  `UserType` int DEFAULT NULL,
  `Point` int DEFAULT NULL,
  `ExtID` varchar(500) DEFAULT NULL,
  `ExtSource` varchar(500) DEFAULT NULL,
  `IsPurchaser` bit(1) DEFAULT NULL,
  `IsProfileLinked` bit(1) DEFAULT NULL,
  `IsOnboardingCompleted` bit(1) DEFAULT NULL,
  `OnboardingStep` tinyint DEFAULT NULL,
  `IsIntroduced` bit(1) DEFAULT NULL,
  `ConcurrencyStamp` longtext,
  `CreatedAt` datetime DEFAULT NULL,
  `ModifiedAt` datetime DEFAULT NULL,
  `DeletedAt` datetime DEFAULT NULL,
  `CreatedById` varchar(255) DEFAULT NULL,
  `IsFirstTimeLogin` bit(1) DEFAULT NULL,
  `IsMigrated` bit(1) DEFAULT NULL,
  `LockoutEnd` datetime DEFAULT NULL,
  `ModifiedById` varchar(255) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `RoleId` varchar(255) DEFAULT NULL,
  `ImportBatch` varchar(45) DEFAULT NULL,
  `IsFirstTimeViewParking` bit(1) DEFAULT NULL,
  `IsFirstTimeViewFoodDelivery` bit(1) DEFAULT NULL,
  PRIMARY KEY (`Id`,`mail`(255)),
  UNIQUE KEY `mail_UNIQUE` (`mail`(255))
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


CREATE TABLE `users` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `username` longtext NOT NULL,
  `AspuserId` varchar(128) DEFAULT NULL,
  `hobby` longtext,
  `IC_Passport` longtext,
  `Nationality` longtext,
  `Race` longtext,
  `Gender` longtext,
  `DOB` longtext,
  `Email` longtext,
  `PhoneNumber` longtext,
  `Skillsets` longtext,
  `Address1` longtext,
  `Address2` longtext,
  `Postcode` longtext,
  `City` longtext,
  `State` longtext,
  `Country` longtext,
  `DateCreated` datetime(6) DEFAULT NULL,
  `CreatedBy` longtext,
  `DateModified` datetime(6) DEFAULT NULL,
  `ModifiedBy` longtext,
  `DateRemoved` datetime(6) DEFAULT NULL,
  `RemovedBy` longtext,
  `Removed` tinyint(1) DEFAULT NULL,
  `HealthcareId` int DEFAULT NULL,
  `IDType` tinyint DEFAULT NULL,
  `IsTemp` tinyint DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=51 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


DELIMITER $$
CREATE DEFINER=`jasonljq`@`localhost` PROCEDURE `SP_AddUserInfoById`(IN ptName longtext,IN pthobby longtext
,IN ptIc_Passport longtext,IN ptNationality longtext,IN ptRace longtext,IN ptGender longtext,IN ptDob longtext
,IN ptEmail longtext,IN ptContactNo longtext,IN ptSkillsets longtext,IN ptAddress1 longtext,IN ptAddress2 longtext
,IN ptPostcode longtext,IN ptCity longtext,IN ptState longtext,IN ptCountry longtext, OUT count int)
BEGIN
Insert into Users (username, hobby, IC_Passport,
Nationality,Race,Gender,DOB,Email,
PhoneNumber,Skillsets,Address1,Address2,
Postcode,City,State,Country,DateCreated,DateModified) values (ptName, pthobby, ptIc_Passport,
ptNationality,ptRace,ptGender,ptDob,ptEmail,
ptContactNo,ptSkillsets,ptAddress1,ptAddress2,
ptPostcode,ptCity,ptState,ptCountry,now(),now());
SELECT ROW_COUNT() into count;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`jasonljq`@`localhost` PROCEDURE `SP_DeleteUserInfoById`(IN userId int, OUT count int)
BEGIN
DELETE FROM Users WHERE Id = userId ;
SELECT ROW_COUNT() into count;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`jasonljq`@`localhost` PROCEDURE `SP_QueryAspUserInfoById`(IN email longtext,IN password longtext)
BEGIN
SELECT * FROM aspnetusers WHERE mail = email and PlainPassword=password ;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`jasonljq`@`localhost` PROCEDURE `SP_QueryUserInfoById`(IN userId int)
BEGIN
SELECT * FROM Users WHERE Id = userId ;
END$$
DELIMITER ;


DELIMITER $$
CREATE DEFINER=`jasonljq`@`localhost` PROCEDURE `SP_UpdateUserInfoById`(IN ptName longtext,IN pthobby longtext
,IN ptIc_Passport longtext,IN ptNationality longtext,IN ptRace longtext,IN ptGender longtext,IN ptDob longtext
,IN ptEmail longtext,IN ptPhoneNumber longtext,IN ptSkillsets longtext,IN ptAddress1 longtext,IN ptAddress2 longtext
,IN ptPostcode longtext,IN ptCity longtext,IN ptState longtext,IN ptCountry longtext,IN ptId int, OUT count int)
BEGIN
update Users set username=ptName, hobby=pthobby, IC_Passport=ptIc_Passport,
Nationality=ptNationality,Race=ptRace,Gender=ptGender,DOB=ptDob,Email=ptEmail,
PhoneNumber=ptPhoneNumber,Skillsets=ptSkillsets,Address1=ptAddress1,Address2=ptAddress2,
Postcode=ptPostcode,City=ptCity,State=ptState,Country=ptCountry WHERE Id=ptId;
SELECT ROW_COUNT() into count;
END$$
DELIMITER ;


INSERT INTO `etiqacdn`.`aspnetusers`
(`mail`,
`EmailConfirmed`,
`PasswordHash`,
`SecurityStamp`,
`PhoneNumber`,
`PhoneNumberConfirmed`,
`TwoFactorEnabled`,
`LockoutEndDateUtc`,
`LockoutEnabled`,
`AccessFailedCount`,
`UserName`,
`DisplayName`,
`AccountType`,
`LoginStatus`,
`PlainPassword`,
`ProfilePicture`,
`UserType`,
`Point`,
`ExtID`,
`ExtSource`,
`IsPurchaser`,
`IsProfileLinked`,
`IsOnboardingCompleted`,
`IsIntroduced`,
`ConcurrencyStamp`,
`CreatedAt`,
`ModifiedAt`,
`DeletedAt`,
`CreatedById`,
`IsFirstTimeLogin`,
`IsMigrated`,
`LockoutEnd`,
`ModifiedById`,
`NormalizedUserName`,
`NormalizedEmail`,
`RoleId`,
`ImportBatch`,
`IsFirstTimeViewParking`,
`IsFirstTimeViewFoodDelivery`)
VALUES
('jason@yahoo.com',0,
'',
'',
'',
0,
0,
'2024-01-01',
0,
0,
'w1',
'',
'',
'1',
'34567',
'',
1,
1,
'',
'',
'',
'',
'',
'',
'',
'2024-01-01',
'2024-01-01',
'2024-01-01',
'',
'',
'',
'2024-01-01',
'',
'',
'',
'',
'',
'',
'');

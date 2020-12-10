CREATE TABLE `Users` (
	`ID`	INTEGER NOT NULL,
	`Username`	TEXT NOT NULL,
	`Password`	TEXT NOT NULL,
	`Role`	INTEGER NOT NULL,
	`FirstName`	TEXT NOT NULL,
	`LastName`	TEXT NOT NULL,
	CONSTRAINT `PK_Users` PRIMARY KEY(`ID`)
);

CREATE TABLE `TimePunches` (
	`ID`	INTEGER NOT NULL,
	`UserID`	bigint NOT NULL,
	`Date`	text NOT NULL,
	`PunchIn`	text NOT NULL,
	`LunchStart`	text,
	`LunchEnd`	text,
	`PunchOut`	text,
	`isOpen`	bigint NOT NULL,
	CONSTRAINT `sqlite_master_PK_TimePunches` PRIMARY KEY(`ID`),
	FOREIGN KEY(`UserID`) REFERENCES `Users`(`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
);

CREATE TABLE `Settings` (
	`ID`	INTEGER PRIMARY KEY AUTOINCREMENT,
	`minimumLunchMins`	int NOT NULL,
	`payPeriodStartDate`	text NOT NULL,
	`payPeriodDays`	int NOT NULL
);
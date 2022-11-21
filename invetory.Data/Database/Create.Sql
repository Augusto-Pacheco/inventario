CREATE TABLE `MaterialReport` (
  `RepoId` INT NOT NULL AUTO_INCREMENT,
  `Details_DetailId` INT NOT NULL,
  `responsable` VARCHAR(45) NOT NULL,
  `TransactionDate` DATE NOT NULL,
  PRIMARY KEY (`RepoId`),
  INDEX `fk_MaterialReport_Details1_idx` (`Details_DetailId` ASC) VISIBLE,
  CONSTRAINT `fk_MaterialReport_Details1` FOREIGN KEY (`Details_DetailId`) REFERENCES `inventory`.`Details` (`DetailId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE = InnoDB DEFAULT CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci;

CREATE TABLE `Material` (
  `MaterialId` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NULL DEFAULT NULL,
  `qty` INT NOT NULL,
  `providerId` INT NOT NULL,
  PRIMARY KEY (`MaterialId`),
  INDEX `fk_Material_Provider_idx` (`providerId` ASC) VISIBLE,
  CONSTRAINT `fk_Material_Provider` FOREIGN KEY (`providerId`) REFERENCES `inventory`.`Provider` (`ProviderId`)
) ENGINE = InnoDB DEFAULT CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci;

CREATE TABLE `Provider` (
  `ProviderId` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NULL,
  PRIMARY KEY (`ProviderId`)
) ENGINE = InnoDB;

CREATE TABLE `Details` (
  `DetailId` INT NOT NULL AUTO_INCREMENT,
  `MaterialId` INT NOT NULL,
  `reason` TEXT NOT NULL,
  `incoming` INT NOT NULL,
  `out` INT NOT NULL,
  `total` INT NOT NULL,
  PRIMARY KEY (`DetailId`),
  INDEX `fk_Details_material1_idx` (`MaterialId` ASC) VISIBLE,
  CONSTRAINT `fk_Details_material1` FOREIGN KEY (`MaterialId`) REFERENCES `inventory`.`Material` (`MaterialId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE = InnoDB;

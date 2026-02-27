-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema lfs_db
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema lfs_db
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `lfs_db` ;
USE `lfs_db` ;

-- -----------------------------------------------------
-- Table `lfs_db`.`account_group`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`account_group` (
  `id` TINYINT UNSIGNED NOT NULL AUTO_INCREMENT,
  `account_group_code` VARCHAR(1) CHARACTER SET 'utf8' NOT NULL,
  `account_group_name` VARCHAR(15) CHARACTER SET 'utf8' NOT NULL,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `code_UNIQUE` (`account_group_code` ASC) VISIBLE,
  UNIQUE INDEX `name_UNIQUE` (`account_group_name` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 6
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `lfs_db`.`funds`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`funds` (
  `id` TINYINT UNSIGNED NOT NULL AUTO_INCREMENT,
  `fund_code` VARCHAR(5) NOT NULL,
  `fund_name` VARCHAR(45) NOT NULL,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `fund_name_UNIQUE` (`fund_name` ASC) VISIBLE,
  UNIQUE INDEX `fund_code_UNIQUE` (`fund_code` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`roles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`roles` (
  `id` TINYINT UNSIGNED NOT NULL AUTO_INCREMENT,
  `role_name` VARCHAR(99) NOT NULL,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `role_name_UNIQUE` (`role_name` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 14
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`users`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`users` (
  `id` TINYINT UNSIGNED NOT NULL AUTO_INCREMENT,
  `roles_id` TINYINT UNSIGNED NULL,
  `prefix` VARCHAR(45) NULL DEFAULT '',
  `first_name` VARCHAR(45) NOT NULL,
  `mid_initial` VARCHAR(1) NOT NULL,
  `last_name` VARCHAR(45) NOT NULL,
  `suffix` VARCHAR(45) NULL DEFAULT '',
  `username` VARCHAR(45) NOT NULL,
  `password` VARCHAR(60) NOT NULL,
  `is_super` TINYINT NOT NULL DEFAULT 0,
  `is_deleted` TINYINT NOT NULL DEFAULT 0,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `username_UNIQUE` (`username` ASC) VISIBLE,
  INDEX `fk_users_roles1_idx` (`roles_id` ASC) VISIBLE,
  CONSTRAINT `fk_users_roles1`
    FOREIGN KEY (`roles_id`)
    REFERENCES `lfs_db`.`roles` (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 12
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`journals`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`journals` (
  `id` TINYINT UNSIGNED NOT NULL AUTO_INCREMENT,
  `journal_name` VARCHAR(99) NOT NULL,
  `is_special` BIT(1) NOT NULL,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `name_UNIQUE` (`journal_name` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 7
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`jev`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`jev` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `funds_id` TINYINT UNSIGNED NOT NULL,
  `journals_id` TINYINT UNSIGNED NOT NULL,
  `transaction_no` VARCHAR(45) NOT NULL,
  `jev_no` VARCHAR(20) NULL,
  `date_entry` DATE NOT NULL,
  `ref_no` VARCHAR(99) NULL DEFAULT NULL,
  `payee` VARCHAR(99) NOT NULL,
  `explanation` VARCHAR(250) NULL DEFAULT NULL,
  `status` ENUM('draft', 'pending', 'approved', 'disapproved', 'cancelled') NOT NULL DEFAULT 'draft',
  `is_approved` TINYINT NOT NULL DEFAULT 0,
  `is_disapproved` TINYINT NOT NULL DEFAULT 0,
  `is_cancelled` TINYINT NOT NULL DEFAULT 0,
  `is_edited` TINYINT NOT NULL DEFAULT 0,
  `remarks` VARCHAR(250) NULL DEFAULT NULL,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `created_by` TINYINT UNSIGNED NOT NULL,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `updated_by` TINYINT UNSIGNED NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_journal_voucher_funds1_idx` (`funds_id` ASC) VISIBLE,
  INDEX `fk_journal_voucher_users1_idx` (`created_by` ASC) VISIBLE,
  INDEX `fk_journal_voucher_users2_idx` (`updated_by` ASC) VISIBLE,
  INDEX `fk_journal_entry_voucher_journals1_idx` (`journals_id` ASC) VISIBLE,
  CONSTRAINT `fk_jev_funds1`
    FOREIGN KEY (`funds_id`)
    REFERENCES `lfs_db`.`funds` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_jev_users1`
    FOREIGN KEY (`created_by`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_jev_users2`
    FOREIGN KEY (`updated_by`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_journal_entry_voucher_journals1`
    FOREIGN KEY (`journals_id`)
    REFERENCES `lfs_db`.`journals` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3
ROW_FORMAT = DEFAULT;


-- -----------------------------------------------------
-- Table `lfs_db`.`ada_disbursement_journal`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`ada_disbursement_journal` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `jev_id` INT UNSIGNED NOT NULL,
  `ada_no` VARCHAR(30) NULL DEFAULT NULL,
  `dv_no` VARCHAR(30) NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_ada_disbursement_journal_jev1_idx` (`jev_id` ASC) VISIBLE,
  CONSTRAINT `fk_ada_disbursement_journal_jev1`
    FOREIGN KEY (`jev_id`)
    REFERENCES `lfs_db`.`jev` (`id`)
    ON DELETE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`allotment_release`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`allotment_release` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `aro_no` VARCHAR(99) NOT NULL,
  `purpose` VARCHAR(200) NOT NULL,
  `date_issued` DATE NOT NULL,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 73
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`allotment_classes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`allotment_classes` (
  `id` TINYINT UNSIGNED NOT NULL AUTO_INCREMENT,
  `allotment_code` VARCHAR(5) NOT NULL,
  `allotment_name` VARCHAR(50) NOT NULL,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `code_UNIQUE` (`allotment_code` ASC) VISIBLE,
  UNIQUE INDEX `name_UNIQUE` (`allotment_name` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 5
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`functional_classifications`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`functional_classifications` (
  `id` TINYINT UNSIGNED NOT NULL AUTO_INCREMENT,
  `sector_code` VARCHAR(4) NOT NULL,
  `sector_name` VARCHAR(99) NOT NULL,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `sector_code_UNIQUE` (`sector_code` ASC) INVISIBLE,
  UNIQUE INDEX `sector_name_UNIQUE` (`sector_name` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 9
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`functional_classification_services`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`functional_classification_services` (
  `id` SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
  `functional_classifications_id` TINYINT UNSIGNED NOT NULL,
  `service_name` VARCHAR(99) NOT NULL,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  INDEX `fk_functional_classification_services_functional_classifica_idx` (`functional_classifications_id` ASC) VISIBLE,
  CONSTRAINT `fk_functional_classification_services_functional_classificati1`
    FOREIGN KEY (`functional_classifications_id`)
    REFERENCES `lfs_db`.`functional_classifications` (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 39
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`function_program_project`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`function_program_project` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `functional_classification_services_id` SMALLINT UNSIGNED NOT NULL,
  `fpp_code` VARCHAR(45) NOT NULL,
  `fpp_name` VARCHAR(150) NOT NULL,
  `is_special` TINYINT NOT NULL,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `code_UNIQUE` (`fpp_code` ASC) VISIBLE,
  INDEX `fk_function_program_project_functional_classification_servi_idx` (`functional_classification_services_id` ASC) VISIBLE,
  CONSTRAINT `fk_function_program_project_functional_classification_services1`
    FOREIGN KEY (`functional_classification_services_id`)
    REFERENCES `lfs_db`.`functional_classification_services` (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 23
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`major_account_group`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`major_account_group` (
  `id` SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
  `account_group_id` TINYINT UNSIGNED NOT NULL,
  `maj_acc_group_code` VARCHAR(2) NOT NULL,
  `maj_acc_group_name` VARCHAR(99) NOT NULL,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  INDEX `fk_major_account_group_account_group_idx` (`account_group_id` ASC) VISIBLE,
  CONSTRAINT `fk_major_account_group_account_group`
    FOREIGN KEY (`account_group_id`)
    REFERENCES `lfs_db`.`account_group` (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 33
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`sub_major_account_group`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`sub_major_account_group` (
  `id` SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
  `major_account_group_id` SMALLINT UNSIGNED NOT NULL,
  `sub_maj_acc_group_code` VARCHAR(2) NOT NULL,
  `sub_maj_acc_group_name` VARCHAR(99) NOT NULL,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  INDEX `fk_sub_major_account_group_major_account_group1_idx` (`major_account_group_id` ASC) VISIBLE,
  CONSTRAINT `fk_sub_major_account_group_major_account_group1`
    FOREIGN KEY (`major_account_group_id`)
    REFERENCES `lfs_db`.`major_account_group` (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 97
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`general_ledger_accounts`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`general_ledger_accounts` (
  `id` SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
  `sub_major_account_group_id` SMALLINT UNSIGNED NOT NULL,
  `ledger_code` VARCHAR(3) NOT NULL,
  `ledger_name` VARCHAR(99) NOT NULL,
  `is_contra_account` TINYINT NOT NULL,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  INDEX `fk_general_ledger_accounts_sub_major_account_group1_idx` (`sub_major_account_group_id` ASC) VISIBLE,
  CONSTRAINT `fk_general_ledger_accounts_sub_major_account_group1`
    FOREIGN KEY (`sub_major_account_group_id`)
    REFERENCES `lfs_db`.`sub_major_account_group` (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 600
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`others_fpp`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`others_fpp` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `function_program_project_id` INT UNSIGNED NOT NULL,
  `others_fpp_code` VARCHAR(45) NOT NULL,
  `name` VARCHAR(150) NOT NULL,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `name_UNIQUE` (`name` ASC) VISIBLE,
  INDEX `fk_others_fpp_function_program_project1_idx` (`function_program_project_id` ASC) VISIBLE,
  CONSTRAINT `fk_others_fpp_function_program_project1`
    FOREIGN KEY (`function_program_project_id`)
    REFERENCES `lfs_db`.`function_program_project` (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 7
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`budget_appropriations`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`budget_appropriations` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `funds_id` TINYINT UNSIGNED NOT NULL,
  `function_program_project_id` INT UNSIGNED NOT NULL,
  `others_fpp_id` INT UNSIGNED NULL DEFAULT NULL,
  `allotment_classes_id` TINYINT UNSIGNED NOT NULL,
  `general_ledger_accounts_id` SMALLINT UNSIGNED NOT NULL,
  `date_entry` DATE NOT NULL,
  `year` YEAR NOT NULL,
  `amount` DECIMAL(15,2) NOT NULL,
  `continuing` TINYINT NOT NULL DEFAULT '0',
  `remarks` VARCHAR(99) NOT NULL,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  INDEX `fk_appropriations_function_program_project1_idx` (`function_program_project_id` ASC) VISIBLE,
  INDEX `fk_appropriations_others_fpp1_idx` (`others_fpp_id` ASC) VISIBLE,
  INDEX `fk_appropriations_general_ledger_accounts1_idx` (`general_ledger_accounts_id` ASC) VISIBLE,
  INDEX `fk_appropriations_allotment_classes1_idx` (`allotment_classes_id` ASC) VISIBLE,
  INDEX `fk_budget_appropriations_funds1_idx` (`funds_id` ASC) VISIBLE,
  CONSTRAINT `fk_appropriations_allotment_classes1`
    FOREIGN KEY (`allotment_classes_id`)
    REFERENCES `lfs_db`.`allotment_classes` (`id`),
  CONSTRAINT `fk_appropriations_function_program_project1`
    FOREIGN KEY (`function_program_project_id`)
    REFERENCES `lfs_db`.`function_program_project` (`id`),
  CONSTRAINT `fk_appropriations_general_ledger_accounts1`
    FOREIGN KEY (`general_ledger_accounts_id`)
    REFERENCES `lfs_db`.`general_ledger_accounts` (`id`),
  CONSTRAINT `fk_appropriations_others_fpp1`
    FOREIGN KEY (`others_fpp_id`)
    REFERENCES `lfs_db`.`others_fpp` (`id`),
  CONSTRAINT `fk_budget_appropriations_funds1`
    FOREIGN KEY (`funds_id`)
    REFERENCES `lfs_db`.`funds` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
AUTO_INCREMENT = 195
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`allotment_account`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`allotment_account` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `budget_appropriations_id` INT UNSIGNED NOT NULL,
  `allotment_release_id` INT UNSIGNED NOT NULL,
  `amount` DECIMAL(15,2) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_allotment_release_account_budget_appropriations1_idx` (`budget_appropriations_id` ASC) VISIBLE,
  INDEX `fk_allotment_account_allotment_release1_idx` (`allotment_release_id` ASC) VISIBLE,
  CONSTRAINT `fk_allotment_account_allotment_release1`
    FOREIGN KEY (`allotment_release_id`)
    REFERENCES `lfs_db`.`allotment_release` (`id`),
  CONSTRAINT `fk_allotment_account_budget_appropriations1`
    FOREIGN KEY (`budget_appropriations_id`)
    REFERENCES `lfs_db`.`budget_appropriations` (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 30
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`banks`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`banks` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `bank_code` VARCHAR(45) NULL,
  `bank_name` VARCHAR(99) NOT NULL,
  `bank_branch` VARCHAR(45) NULL,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`subsidiary_ledger_accounts`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`subsidiary_ledger_accounts` (
  `id` SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
  `funds_id` TINYINT UNSIGNED NOT NULL,
  `general_ledger_accounts_id` SMALLINT UNSIGNED NOT NULL,
  `sub_code` VARCHAR(20) NOT NULL,
  `sub_name` VARCHAR(99) NOT NULL,
  `address` VARCHAR(99) NOT NULL,
  `contact_person` VARCHAR(99) NULL,
  `contact` VARCHAR(99) NULL,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  INDEX `fk_subsidiary_ledger_accounts_general_ledger_accounts1_idx` (`general_ledger_accounts_id` ASC) VISIBLE,
  INDEX `fk_subsidiary_ledger_accounts_funds1_idx` (`funds_id` ASC) VISIBLE,
  CONSTRAINT `fk_subsidiary_ledger_accounts_general_ledger_accounts1`
    FOREIGN KEY (`general_ledger_accounts_id`)
    REFERENCES `lfs_db`.`general_ledger_accounts` (`id`),
  CONSTRAINT `fk_subsidiary_ledger_accounts_funds1`
    FOREIGN KEY (`funds_id`)
    REFERENCES `lfs_db`.`funds` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
AUTO_INCREMENT = 7
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`beginning_balances`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`beginning_balances` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `funds_id` TINYINT UNSIGNED NOT NULL,
  `general_ledger_accounts_id` SMALLINT UNSIGNED NOT NULL,
  `subsidiary_ledger_accounts_id` SMALLINT UNSIGNED NULL DEFAULT NULL,
  `date_entry` DATE NOT NULL,
  `is_debit` TINYINT NOT NULL,
  `amount` DECIMAL(15,2) NOT NULL,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  INDEX `fk_beginning_balances_general_ledger_accounts1_idx` (`general_ledger_accounts_id` ASC) VISIBLE,
  INDEX `fk_beginning_balances_subsidiary_ledger_accounts1_idx` (`subsidiary_ledger_accounts_id` ASC) VISIBLE,
  INDEX `fk_beginning_balances_funds1_idx` (`funds_id` ASC) VISIBLE,
  CONSTRAINT `fk_beginning_balances_general_ledger_accounts1`
    FOREIGN KEY (`general_ledger_accounts_id`)
    REFERENCES `lfs_db`.`general_ledger_accounts` (`id`),
  CONSTRAINT `fk_beginning_balances_subsidiary_ledger_accounts1`
    FOREIGN KEY (`subsidiary_ledger_accounts_id`)
    REFERENCES `lfs_db`.`subsidiary_ledger_accounts` (`id`),
  CONSTRAINT `fk_beginning_balances_funds1`
    FOREIGN KEY (`funds_id`)
    REFERENCES `lfs_db`.`funds` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`disbursing_officers`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`disbursing_officers` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `users_id` TINYINT UNSIGNED NULL,
  `prefix` VARCHAR(45) NULL DEFAULT '',
  `first_name` VARCHAR(45) NOT NULL,
  `mid_initial` VARCHAR(1) NOT NULL,
  `last_name` VARCHAR(45) NOT NULL,
  `suffix` VARCHAR(45) NULL DEFAULT NULL,
  `job_title` VARCHAR(99) NULL DEFAULT NULL,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  INDEX `fk_disbursing_officers_users1_idx` (`users_id` ASC) INVISIBLE,
  CONSTRAINT `fk_disbursing_officers_users1`
    FOREIGN KEY (`users_id`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
AUTO_INCREMENT = 19
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`cash_disbursement_journal`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`cash_disbursement_journal` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `jev_id` INT UNSIGNED NOT NULL,
  `disbursing_officers_id` INT NOT NULL,
  `dv_no` VARCHAR(45) NULL DEFAULT NULL,
  `date_paid` DATE NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_cash_disbursement_journal_disbursing_officers1_idx` (`disbursing_officers_id` ASC) VISIBLE,
  INDEX `fk_cash_disbursement_journal_jev1_idx` (`jev_id` ASC) VISIBLE,
  CONSTRAINT `fk_cash_disbursement_journal_disbursing_officers1`
    FOREIGN KEY (`disbursing_officers_id`)
    REFERENCES `lfs_db`.`disbursing_officers` (`id`),
  CONSTRAINT `fk_cash_disbursement_journal_jev1`
    FOREIGN KEY (`jev_id`)
    REFERENCES `lfs_db`.`jev` (`id`)
    ON DELETE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`collecting_officers`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`collecting_officers` (
  `id` TINYINT UNSIGNED NOT NULL AUTO_INCREMENT,
  `users_id` TINYINT UNSIGNED NOT NULL,
  `prefix` VARCHAR(10) NULL,
  `first_name` VARCHAR(45) NOT NULL,
  `mid_initial` VARCHAR(3) NOT NULL,
  `last_name` VARCHAR(45) NOT NULL,
  `suffix` VARCHAR(10) NULL,
  `job_title` VARCHAR(99) NULL DEFAULT NULL,
  `is_deleted` TINYINT NOT NULL DEFAULT 0,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  INDEX `fk_collecting_officers_users1_idx` (`users_id` ASC) VISIBLE,
  CONSTRAINT `fk_collecting_officers_users1`
    FOREIGN KEY (`users_id`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`cash_receipts_journal`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`cash_receipts_journal` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `jev_id` INT UNSIGNED NOT NULL,
  `collecting_officers_id` TINYINT UNSIGNED NOT NULL,
  `rcd_no` VARCHAR(30) NULL DEFAULT NULL,
  `or_no` VARCHAR(30) NULL DEFAULT NULL,
  `or_date` DATE NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_cash_receipts_journal_collecting_officers1_idx` (`collecting_officers_id` ASC) VISIBLE,
  INDEX `fk_cash_receipts_journal_jev1_idx` (`jev_id` ASC) VISIBLE,
  CONSTRAINT `fk_cash_receipts_journal_jev1`
    FOREIGN KEY (`jev_id`)
    REFERENCES `lfs_db`.`jev` (`id`)
    ON DELETE CASCADE,
  CONSTRAINT `fk_cash_receipts_journal_collecting_officers1`
    FOREIGN KEY (`collecting_officers_id`)
    REFERENCES `lfs_db`.`collecting_officers` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`check_disbursements_journal`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`check_disbursements_journal` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `jev_id` INT UNSIGNED NOT NULL,
  `check_date` DATE NOT NULL,
  `check_no` VARCHAR(30) NULL DEFAULT NULL,
  `dv_no` VARCHAR(45) NULL DEFAULT NULL,
  `rci_no` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_check_disbursements_journal_jev1_idx` (`jev_id` ASC) VISIBLE,
  CONSTRAINT `fk_check_disbursements_journal_jev1`
    FOREIGN KEY (`jev_id`)
    REFERENCES `lfs_db`.`jev` (`id`)
    ON DELETE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`general_journal`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`general_journal` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `jev_id` INT UNSIGNED NOT NULL,
  `dv_no` VARCHAR(45) NULL DEFAULT NULL,
  `check_no` VARCHAR(45) NULL DEFAULT NULL,
  `or_no` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_general_journal_jev1_idx` (`jev_id` ASC) VISIBLE,
  CONSTRAINT `fk_general_journal_jev1`
    FOREIGN KEY (`jev_id`)
    REFERENCES `lfs_db`.`jev` (`id`)
    ON DELETE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`jev_accounts`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`jev_accounts` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `jev_id` INT UNSIGNED NOT NULL,
  `function_program_project_id` INT UNSIGNED NULL DEFAULT NULL,
  `general_ledger_accounts_id` SMALLINT UNSIGNED NOT NULL,
  `subsidiary_ledger_accounts_id` SMALLINT UNSIGNED NULL DEFAULT NULL,
  `obligation_no` VARCHAR(15) NOT NULL,
  `is_deposit` TINYINT NULL DEFAULT NULL,
  `is_debit` TINYINT NOT NULL,
  `amount` DECIMAL(15,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`id`),
  INDEX `fk_journal_voucher_account_function_program_project1_idx` (`function_program_project_id` ASC) VISIBLE,
  INDEX `fk_journal_voucher_account_subsidiary_ledger_accounts1_idx` (`subsidiary_ledger_accounts_id` ASC) VISIBLE,
  INDEX `fk_general_journal_general_ledger_accounts1_idx` (`general_ledger_accounts_id` ASC) VISIBLE,
  INDEX `fk_jev_accounts_jev1_idx` (`jev_id` ASC) VISIBLE,
  CONSTRAINT `fk_general_journal_general_ledger_accounts1`
    FOREIGN KEY (`general_ledger_accounts_id`)
    REFERENCES `lfs_db`.`general_ledger_accounts` (`id`),
  CONSTRAINT `fk_jev_accounts_jev1`
    FOREIGN KEY (`jev_id`)
    REFERENCES `lfs_db`.`jev` (`id`)
    ON DELETE CASCADE,
  CONSTRAINT `fk_journal_voucher_account_function_program_project1`
    FOREIGN KEY (`function_program_project_id`)
    REFERENCES `lfs_db`.`function_program_project` (`id`),
  CONSTRAINT `fk_journal_voucher_account_subsidiary_ledger_accounts1`
    FOREIGN KEY (`subsidiary_ledger_accounts_id`)
    REFERENCES `lfs_db`.`subsidiary_ledger_accounts` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`obligation_request`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`obligation_request` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `function_program_project_id` INT UNSIGNED NOT NULL,
  `allotment_classes_id` TINYINT UNSIGNED NOT NULL,
  `funds_id` TINYINT UNSIGNED NOT NULL,
  `transaction_no` VARCHAR(45) NOT NULL,
  `obligation_no` VARCHAR(15) NULL,
  `payee` VARCHAR(99) NOT NULL,
  `explanation` VARCHAR(99) NOT NULL,
  `reference_no` VARCHAR(45) NOT NULL,
  `date_requested` DATE NOT NULL,
  `status` ENUM('draft', 'pending', 'approved', 'disapproved', 'cancelled') NOT NULL DEFAULT 'draft',
  `remarks` VARCHAR(99) NULL,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `created_by` TINYINT UNSIGNED NOT NULL,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `updated_by` TINYINT UNSIGNED NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_obligation_request_users1_idx` (`created_by` ASC) VISIBLE,
  INDEX `fk_obligation_request_users2_idx` (`updated_by` ASC) VISIBLE,
  UNIQUE INDEX `obligation_no_UNIQUE` (`obligation_no` ASC) VISIBLE,
  INDEX `fk_obligation_request_function_program_project1_idx` (`function_program_project_id` ASC) VISIBLE,
  INDEX `fk_obligation_request_allotment_classes1_idx` (`allotment_classes_id` ASC) VISIBLE,
  INDEX `fk_obligation_request_funds1_idx` (`funds_id` ASC) INVISIBLE,
  UNIQUE INDEX `transaction_no_UNIQUE` (`transaction_no` ASC) VISIBLE,
  CONSTRAINT `fk_obligation_request_users1`
    FOREIGN KEY (`created_by`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_obligation_request_users2`
    FOREIGN KEY (`updated_by`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_obligation_request_function_program_project1`
    FOREIGN KEY (`function_program_project_id`)
    REFERENCES `lfs_db`.`function_program_project` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_obligation_request_allotment_classes1`
    FOREIGN KEY (`allotment_classes_id`)
    REFERENCES `lfs_db`.`allotment_classes` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_obligation_request_funds1`
    FOREIGN KEY (`funds_id`)
    REFERENCES `lfs_db`.`funds` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
AUTO_INCREMENT = 21
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`obligation_account`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`obligation_account` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `obligation_request_id` INT UNSIGNED NOT NULL,
  `allotment_account_id` INT NOT NULL,
  `amount` DECIMAL(15,2) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_obligation_account_obligation_request1_idx` (`obligation_request_id` ASC) VISIBLE,
  INDEX `fk_obligation_account_allotment_account1_idx` (`allotment_account_id` ASC) VISIBLE,
  CONSTRAINT `fk_obligation_account_obligation_request1`
    FOREIGN KEY (`obligation_request_id`)
    REFERENCES `lfs_db`.`obligation_request` (`id`),
  CONSTRAINT `fk_obligation_account_allotment_account1`
    FOREIGN KEY (`allotment_account_id`)
    REFERENCES `lfs_db`.`allotment_account` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
AUTO_INCREMENT = 35
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`permissions`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`permissions` (
  `id` TINYINT UNSIGNED NOT NULL AUTO_INCREMENT,
  `permission_name` VARCHAR(99) NOT NULL,
  `permission_office` VARCHAR(30) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `permission_name_UNIQUE` (`permission_name` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 39
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`documents`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`documents` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(99) NOT NULL,
  `office` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`document_references`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`document_references` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `documents_id` INT(11) NOT NULL,
  `name` VARCHAR(99) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_reference_documents1_idx` (`documents_id` ASC) VISIBLE,
  CONSTRAINT `fk_reference_documents1`
    FOREIGN KEY (`documents_id`)
    REFERENCES `lfs_db`.`documents` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`role_has_permissions`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`role_has_permissions` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `roles_id` TINYINT UNSIGNED NOT NULL,
  `permissions_id` TINYINT UNSIGNED NOT NULL,
  INDEX `fk_role_has_permissions_roles1_idx` (`roles_id` ASC) VISIBLE,
  INDEX `fk_role_has_permissions_permissions1_idx` (`permissions_id` ASC) VISIBLE,
  PRIMARY KEY (`id`),
  CONSTRAINT `fk_role_has_permissions_permissions1`
    FOREIGN KEY (`permissions_id`)
    REFERENCES `lfs_db`.`permissions` (`id`),
  CONSTRAINT `fk_role_has_permissions_roles1`
    FOREIGN KEY (`roles_id`)
    REFERENCES `lfs_db`.`roles` (`id`)
    ON DELETE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`signatories`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`signatories` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `prefix` VARCHAR(4) NULL DEFAULT NULL,
  `first_name` VARCHAR(45) NOT NULL,
  `middle_initial` VARCHAR(1) NOT NULL,
  `last_name` VARCHAR(45) NOT NULL,
  `suffix` VARCHAR(45) NULL DEFAULT NULL,
  `title` VARCHAR(45) NOT NULL,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`signatories_has_document_references`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`signatories_has_document_references` (
  `id` TINYINT NOT NULL AUTO_INCREMENT,
  `signatories_id` INT(11) NOT NULL,
  `document_references_id` INT(11) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_signatories_has_references_signatories1_idx` (`signatories_id` ASC) VISIBLE,
  INDEX `fk_signatories_has_document_references_document_references1_idx` (`document_references_id` ASC) VISIBLE,
  CONSTRAINT `fk_signatories_has_document_references_document_references1`
    FOREIGN KEY (`document_references_id`)
    REFERENCES `lfs_db`.`document_references` (`id`),
  CONSTRAINT `fk_signatories_has_references_signatories1`
    FOREIGN KEY (`signatories_id`)
    REFERENCES `lfs_db`.`signatories` (`id`)
    ON DELETE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`supplemental_appropriations`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`supplemental_appropriations` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `budget_appropriations_id` INT UNSIGNED NOT NULL,
  `date_entry` DATE NOT NULL,
  `amount` DECIMAL(15,2) NOT NULL,
  `remarks` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_supplemental_appropriations_budget_appropriations1_idx` (`budget_appropriations_id` ASC) VISIBLE,
  CONSTRAINT `fk_supplemental_appropriations_budget_appropriations1`
    FOREIGN KEY (`budget_appropriations_id`)
    REFERENCES `lfs_db`.`budget_appropriations` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`amortization`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`amortization` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `bank_name` VARCHAR(99) NOT NULL,
  `amortization_term` VARCHAR(45) NOT NULL,
  `interest` DECIMAL(15,2) NOT NULL DEFAULT 0,
  `amount_released` DECIMAL(15,2) NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`amortization_sched`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`amortization_sched` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `amortization_id` INT(11) NOT NULL,
  `date` DATE NOT NULL,
  `principal_amount` DECIMAL(15,2) NOT NULL DEFAULT '0.00',
  `interest_amount` DECIMAL(15,2) NOT NULL DEFAULT '0.00',
  `grt_amount` DECIMAL(15,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`id`),
  INDEX `fk_ammortization_sched_amortization1_idx` (`amortization_id` ASC) VISIBLE,
  CONSTRAINT `fk_ammortization_sched_amortization1`
    FOREIGN KEY (`amortization_id`)
    REFERENCES `lfs_db`.`amortization` (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 10
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`journals_default_accounts`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`journals_default_accounts` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `journals_id` TINYINT UNSIGNED NOT NULL,
  `funds_id` TINYINT UNSIGNED NOT NULL,
  `general_ledger_accounts_id` SMALLINT UNSIGNED NOT NULL,
  `is_debit` TINYINT NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`),
  INDEX `fk_journals_default_accounts_journals1_idx` (`journals_id` ASC) VISIBLE,
  INDEX `fk_journals_default_accounts_general_ledger_accounts1_idx` (`general_ledger_accounts_id` ASC) VISIBLE,
  INDEX `fk_journals_default_accounts_funds1_idx` (`funds_id` ASC) VISIBLE,
  CONSTRAINT `fk_journals_default_accounts_general_ledger_accounts1`
    FOREIGN KEY (`general_ledger_accounts_id`)
    REFERENCES `lfs_db`.`general_ledger_accounts` (`id`),
  CONSTRAINT `fk_journals_default_accounts_journals1`
    FOREIGN KEY (`journals_id`)
    REFERENCES `lfs_db`.`journals` (`id`),
  CONSTRAINT `fk_journals_default_accounts_funds1`
    FOREIGN KEY (`funds_id`)
    REFERENCES `lfs_db`.`funds` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`bank_accounts`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`bank_accounts` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `banks_id` INT NOT NULL,
  `account_no` VARCHAR(99) NOT NULL,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  INDEX `fk_bank_accounts_banks1_idx` (`banks_id` ASC) VISIBLE,
  CONSTRAINT `fk_bank_accounts_banks1`
    FOREIGN KEY (`banks_id`)
    REFERENCES `lfs_db`.`banks` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`bank_deposits`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`bank_deposits` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `bank_accounts_id` INT NOT NULL,
  `funds_id` TINYINT UNSIGNED NOT NULL,
  `reference` VARCHAR(99) CHARACTER SET 'utf8' NOT NULL,
  `date` DATE NULL DEFAULT NULL,
  `amount` DECIMAL(15,2) NOT NULL,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `created_by` TINYINT UNSIGNED NOT NULL,
  `updated_at` TIMESTAMP NULL ON UPDATE CURRENT_TIMESTAMP,
  `updated_by` TINYINT UNSIGNED NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_bank_deposits_users1_idx` (`created_by` ASC) VISIBLE,
  INDEX `fk_bank_deposits_users2_idx` (`updated_by` ASC) VISIBLE,
  INDEX `fk_bank_deposits_funds1_idx` (`funds_id` ASC) VISIBLE,
  INDEX `fk_bank_deposits_bank_accounts1_idx` (`bank_accounts_id` ASC) VISIBLE,
  CONSTRAINT `fk_bank_deposits_bank_accounts1`
    FOREIGN KEY (`bank_accounts_id`)
    REFERENCES `lfs_db`.`bank_accounts` (`id`),
  CONSTRAINT `fk_bank_deposits_users1`
    FOREIGN KEY (`created_by`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_bank_deposits_users2`
    FOREIGN KEY (`updated_by`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_bank_deposits_funds1`
    FOREIGN KEY (`funds_id`)
    REFERENCES `lfs_db`.`funds` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`accountable_forms`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`accountable_forms` (
  `id` TINYINT NOT NULL AUTO_INCREMENT,
  `acc_form_no` VARCHAR(10) NOT NULL,
  `acc_form_desc` VARCHAR(99) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `acc_form_no_UNIQUE` (`acc_form_no` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 12
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`job_orders`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`job_orders` (
  `id` TINYINT NOT NULL AUTO_INCREMENT,
  `users_id` TINYINT UNSIGNED NOT NULL,
  `prefix` VARCHAR(10) NULL,
  `first_name` VARCHAR(45) NOT NULL,
  `mid_initial` VARCHAR(1) NOT NULL,
  `last_name` VARCHAR(45) NOT NULL,
  `suffix` VARCHAR(10) NULL,
  `job_title` VARCHAR(99) NULL,
  `is_deleted` TINYINT NOT NULL DEFAULT 0,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  INDEX `fk_job_orders_users1_idx` (`users_id` ASC) VISIBLE,
  CONSTRAINT `fk_job_orders_users1`
    FOREIGN KEY (`users_id`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`payment_collections`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`payment_collections` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `collecting_officers_id` TINYINT UNSIGNED NOT NULL,
  `job_orders_id` TINYINT NULL,
  `funds_id` TINYINT UNSIGNED NULL DEFAULT NULL,
  `accountable_forms_id` TINYINT NOT NULL,
  `payee` VARCHAR(200) NULL DEFAULT NULL,
  `receipt_no` INT NULL DEFAULT NULL,
  `payment_date` DATETIME NOT NULL,
  `amount` DECIMAL(10,2) NOT NULL,
  `is_cancelled` TINYINT NOT NULL DEFAULT 0,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `created_by` TINYINT UNSIGNED NOT NULL,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `updated_by` TINYINT UNSIGNED NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_payment_collections_accountable_forms1_idx` (`accountable_forms_id` ASC) VISIBLE,
  INDEX `fk_payment_collections_collecting_officers1_idx` (`collecting_officers_id` ASC) VISIBLE,
  INDEX `fk_payment_collections_users1_idx` (`created_by` ASC) VISIBLE,
  INDEX `fk_payment_collections_users2_idx` (`updated_by` ASC) INVISIBLE,
  INDEX `fk_payment_collections_job_orders1_idx` (`job_orders_id` ASC) VISIBLE,
  INDEX `fk_payment_collections_funds1_idx` (`funds_id` ASC) VISIBLE,
  CONSTRAINT `fk_payment_collections_accountable_forms1`
    FOREIGN KEY (`accountable_forms_id`)
    REFERENCES `lfs_db`.`accountable_forms` (`id`),
  CONSTRAINT `fk_payment_collections_collecting_officers1`
    FOREIGN KEY (`collecting_officers_id`)
    REFERENCES `lfs_db`.`collecting_officers` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_payment_collections_users1`
    FOREIGN KEY (`created_by`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_payment_collections_users2`
    FOREIGN KEY (`updated_by`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_payment_collections_job_orders1`
    FOREIGN KEY (`job_orders_id`)
    REFERENCES `lfs_db`.`job_orders` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_payment_collections_funds1`
    FOREIGN KEY (`funds_id`)
    REFERENCES `lfs_db`.`funds` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
AUTO_INCREMENT = 445
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`cheques`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`cheques` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `bank_accounts_id` INT NOT NULL,
  `cheque_no` VARCHAR(99) NOT NULL,
  `cheque_date` DATETIME NOT NULL,
  `amount` DECIMAL(15,2) NOT NULL,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  INDEX `fk_cheques_bank_accounts1_idx` (`bank_accounts_id` ASC) VISIBLE,
  CONSTRAINT `fk_cheques_bank_accounts1`
    FOREIGN KEY (`bank_accounts_id`)
    REFERENCES `lfs_db`.`bank_accounts` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`rci`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`rci` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `cheques_id` INT NOT NULL,
  `funds_id` TINYINT UNSIGNED NOT NULL,
  `function_program_project_id` INT UNSIGNED NOT NULL,
  `dv_no` VARCHAR(20) NOT NULL,
  `payee` VARCHAR(150) NOT NULL,
  `nature_of_payment` VARCHAR(150) NOT NULL,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  INDEX `fk_RCI_funds1_idx` (`funds_id` ASC) VISIBLE,
  INDEX `fk_RCI_function_program_project1_idx` (`function_program_project_id` ASC) VISIBLE,
  INDEX `fk_rci_cheques1_idx` (`cheques_id` ASC) VISIBLE,
  CONSTRAINT `fk_rci_cheques1`
    FOREIGN KEY (`cheques_id`)
    REFERENCES `lfs_db`.`cheques` (`id`),
  CONSTRAINT `fk_RCI_function_program_project1`
    FOREIGN KEY (`function_program_project_id`)
    REFERENCES `lfs_db`.`function_program_project` (`id`),
  CONSTRAINT `fk_rci_funds1`
    FOREIGN KEY (`funds_id`)
    REFERENCES `lfs_db`.`funds` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
AUTO_INCREMENT = 22
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`rci_deductions`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`rci_deductions` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `rci_id` INT NOT NULL,
  `description` VARCHAR(45) NOT NULL,
  `amount` DECIMAL(15,3) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_rci_deductions_rci1` (`rci_id` ASC) VISIBLE,
  CONSTRAINT `fk_rci_deductions_rci1`
    FOREIGN KEY (`rci_id`)
    REFERENCES `lfs_db`.`rci` (`id`)
    ON DELETE CASCADE
    ON UPDATE RESTRICT)
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`rci_obligations`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`rci_obligations` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `rci_id` INT NULL DEFAULT NULL,
  `obligation_no` VARCHAR(45) NULL DEFAULT NULL,
  `date_entry` DATE NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_rci_obligations_rci1` (`rci_id` ASC) VISIBLE,
  CONSTRAINT `fk_rci_obligations_rci1`
    FOREIGN KEY (`rci_id`)
    REFERENCES `lfs_db`.`rci` (`id`)
    ON DELETE CASCADE
    ON UPDATE RESTRICT)
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`receipts`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`receipts` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `users_id` TINYINT UNSIGNED NOT NULL,
  `accountable_forms_id` TINYINT NOT NULL,
  `receipt_number_from` INT NOT NULL,
  `receipt_number_to` INT NOT NULL,
  `received_date` DATE NOT NULL,
  `quantity` INT NOT NULL,
  `remarks` VARCHAR(500) NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_receipts_users2_idx` (`users_id` ASC) VISIBLE,
  INDEX `fk_receipts_accountable_forms1_idx` (`accountable_forms_id` ASC) VISIBLE,
  CONSTRAINT `fk_receipts_accountable_forms1`
    FOREIGN KEY (`accountable_forms_id`)
    REFERENCES `lfs_db`.`accountable_forms` (`id`),
  CONSTRAINT `fk_receipts_users1`
    FOREIGN KEY (`users_id`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
AUTO_INCREMENT = 120
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`receipts_issued`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`receipts_issued` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `collecting_officers_id` TINYINT UNSIGNED NOT NULL,
  `job_orders_id` TINYINT NULL,
  `receipts_id` INT NOT NULL,
  `date_issued` DATE NOT NULL,
  `quantity` INT NOT NULL,
  `receipt_issued_from` INT NOT NULL,
  `receipt_issued_to` INT NOT NULL,
  `last_issued` INT NULL DEFAULT NULL,
  `is_returned` TINYINT(1) NOT NULL DEFAULT '0',
  `returned_date` DATE NULL DEFAULT NULL,
  `issued_by` TINYINT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_receipts_issued_collecting_officers1_idx` (`collecting_officers_id` ASC) VISIBLE,
  INDEX `fk_receipts_issued_receipts1_idx` (`receipts_id` ASC) VISIBLE,
  INDEX `fk_receipts_issued_users1_idx` (`issued_by` ASC) VISIBLE,
  INDEX `fk_receipts_issued_job_orders1_idx` (`job_orders_id` ASC) VISIBLE,
  CONSTRAINT `fk_receipts_issued_receipts1`
    FOREIGN KEY (`receipts_id`)
    REFERENCES `lfs_db`.`receipts` (`id`),
  CONSTRAINT `fk_receipts_issued_collecting_officers1`
    FOREIGN KEY (`collecting_officers_id`)
    REFERENCES `lfs_db`.`collecting_officers` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_receipts_issued_job_orders1`
    FOREIGN KEY (`job_orders_id`)
    REFERENCES `lfs_db`.`job_orders` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_receipts_issued_users1`
    FOREIGN KEY (`issued_by`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
AUTO_INCREMENT = 158
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`augmentations`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`augmentations` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `budget_appropriations_id` INT UNSIGNED NOT NULL,
  `amount` DECIMAL(15,2) NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`),
  INDEX `fk_augmentations_budget_appropriations1_idx` (`budget_appropriations_id` ASC) VISIBLE,
  CONSTRAINT `fk_augmentations_budget_appropriations1`
    FOREIGN KEY (`budget_appropriations_id`)
    REFERENCES `lfs_db`.`budget_appropriations` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`budget_appropriation_has_augmentations`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`budget_appropriation_has_augmentations` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `augmentations_id` INT NOT NULL,
  `budget_appropriations_id` INT UNSIGNED NOT NULL,
  `date_entry` DATE NOT NULL,
  `remarks` VARCHAR(99) NULL,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  INDEX `fk_budget_appropriation_has_augmentation_budget_appropriati_idx` (`budget_appropriations_id` ASC) VISIBLE,
  INDEX `fk_budget_appropriation_has_augmentations_augmentations1_idx` (`augmentations_id` ASC) VISIBLE,
  CONSTRAINT `fk_budget_appropriation_has_augmentation_budget_appropriations1`
    FOREIGN KEY (`budget_appropriations_id`)
    REFERENCES `lfs_db`.`budget_appropriations` (`id`),
  CONSTRAINT `fk_budget_appropriation_has_augmentations_augmentations1`
    FOREIGN KEY (`augmentations_id`)
    REFERENCES `lfs_db`.`augmentations` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`face_values`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`face_values` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `accountable_forms_id` TINYINT NOT NULL,
  `date_effective` DATETIME NOT NULL,
  `amount` DECIMAL(10,2) NOT NULL DEFAULT '0.00',
  `is_default` TINYINT NOT NULL DEFAULT '0',
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` TIMESTAMP NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  INDEX `fk_face_values_accountable_forms1_idx` (`accountable_forms_id` ASC) VISIBLE,
  CONSTRAINT `fk_face_values_accountable_forms1`
    FOREIGN KEY (`accountable_forms_id`)
    REFERENCES `lfs_db`.`accountable_forms` (`id`)
    ON DELETE CASCADE
    ON UPDATE RESTRICT)
ENGINE = InnoDB
AUTO_INCREMENT = 17
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`collecting_officers_has_job_orders`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`collecting_officers_has_job_orders` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `collecting_officers_id` TINYINT UNSIGNED NOT NULL,
  `job_orders_id` TINYINT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_collecting_officers_has_job_orders_collecting_officers1_idx` (`collecting_officers_id` ASC) VISIBLE,
  INDEX `fk_collecting_officers_has_job_orders_job_orders1_idx` (`job_orders_id` ASC) VISIBLE,
  CONSTRAINT `fk_collecting_officers_has_job_orders_collecting_officers1`
    FOREIGN KEY (`collecting_officers_id`)
    REFERENCES `lfs_db`.`collecting_officers` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_collecting_officers_has_job_orders_job_orders1`
    FOREIGN KEY (`job_orders_id`)
    REFERENCES `lfs_db`.`job_orders` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`rpt_discounts`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`rpt_discounts` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `month` INT NOT NULL,
  `description` VARCHAR(99) NULL,
  `rate` DECIMAL(15,2) NOT NULL,
  `is_advance` TINYINT NULL DEFAULT 0,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`rpt_penalties`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`rpt_penalties` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `description` VARCHAR(45) NULL,
  `frequency` VARCHAR(45) NOT NULL,
  `rate` DECIMAL(15,2) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `description_UNIQUE` (`description` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`rpt_tax_rates`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`rpt_tax_rates` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `code` VARCHAR(45) NOT NULL,
  `description` VARCHAR(45) NOT NULL,
  `rate` DECIMAL(15,2) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `description_UNIQUE` (`description` ASC) VISIBLE,
  UNIQUE INDEX `code_UNIQUE` (`code` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`taxpayer_type`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`taxpayer_type` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `code` VARCHAR(45) NOT NULL,
  `taxpayer_type` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`registry`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`registry` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `first_name` VARCHAR(250) NOT NULL,
  `middle_name` VARCHAR(45) NULL,
  `last_name` VARCHAR(45) NOT NULL,
  `sex` VARCHAR(45) NOT NULL,
  `birth_date` DATE NOT NULL,
  `nationality` VARCHAR(99) NOT NULL,
  `municipality` VARCHAR(99) NOT NULL,
  `province` VARCHAR(99) NOT NULL,
  `country` VARCHAR(99) NOT NULL,
  `contact_info` VARCHAR(45) NULL,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `created_by` TINYINT UNSIGNED NOT NULL,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `updated_by` TINYINT UNSIGNED NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_registry_users1_idx` (`created_by` ASC) VISIBLE,
  INDEX `fk_registry_users2_idx` (`updated_by` ASC) VISIBLE,
  CONSTRAINT `fk_registry_users1`
    FOREIGN KEY (`created_by`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_registry_users2`
    FOREIGN KEY (`updated_by`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`taxpayers`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`taxpayers` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `representative_registry_id` INT NULL,
  `taxpayer_type_id` INT NOT NULL,
  `tin` VARCHAR(99) NULL,
  `name` VARCHAR(250) NOT NULL,
  `address` VARCHAR(200) NULL,
  `municipality` VARCHAR(99) NULL,
  `province` VARCHAR(99) NULL,
  `contact_info` VARCHAR(45) NULL,
  `is_active` TINYINT NOT NULL DEFAULT 0,
  `created_by` TINYINT UNSIGNED NOT NULL,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_by` TINYINT UNSIGNED NULL,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  INDEX `fk_taxpayers_taxpayer_type1_idx` (`taxpayer_type_id` ASC) VISIBLE,
  INDEX `fk_taxpayers_users1_idx` (`created_by` ASC) VISIBLE,
  INDEX `fk_taxpayers_users2_idx` (`updated_by` ASC) VISIBLE,
  INDEX `fk_taxpayers_registry1_idx` (`representative_registry_id` ASC) VISIBLE,
  CONSTRAINT `fk_taxpayers_taxpayer_type1`
    FOREIGN KEY (`taxpayer_type_id`)
    REFERENCES `lfs_db`.`taxpayer_type` (`id`),
  CONSTRAINT `fk_taxpayers_registry1`
    FOREIGN KEY (`representative_registry_id`)
    REFERENCES `lfs_db`.`registry` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_taxpayers_users1`
    FOREIGN KEY (`created_by`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_taxpayers_users2`
    FOREIGN KEY (`updated_by`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`rpt_assessment_posts`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`rpt_assessment_posts` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `real_taxpayers_id` INT(11) NOT NULL,
  `property_identifier` VARCHAR(45) NOT NULL DEFAULT '',
  `complete_arp_no` VARCHAR(99) NOT NULL,
  `property_pin` VARCHAR(45) NULL,
  `taxpayer_tin` VARCHAR(45) NULL,
  `taxpayer_name` VARCHAR(250) NOT NULL,
  `taxpayer_contact_info` VARCHAR(99) NULL,
  `taxpayer_address` VARCHAR(200) NULL,
  `street` VARCHAR(99) NULL,
  `barangay_name` VARCHAR(99) NOT NULL,
  `municipality_name` VARCHAR(99) NOT NULL,
  `province_name` VARCHAR(99) NOT NULL,
  `property_kind` VARCHAR(45) NOT NULL,
  `effectivity_quarterly` INT NOT NULL,
  `effectivity_year` INT NOT NULL,
  `other_improvements` DECIMAL(15,2) NOT NULL DEFAULT 0,
  `assessed_value` DECIMAL(15,2) NOT NULL,
  `area` DECIMAL(15,2) NOT NULL DEFAULT 0,
  `lot_no` VARCHAR(99) NULL,
  `classification_code` VARCHAR(45) NOT NULL,
  `classification_name` VARCHAR(99) NOT NULL,
  `actual_use_code` VARCHAR(45) NOT NULL,
  `actual_use_name` VARCHAR(99) NOT NULL,
  `gr_year` INT NOT NULL,
  `is_taxable` TINYINT NOT NULL,
  `is_cancelled` TINYINT NOT NULL,
  `penalty_rate` DECIMAL(15,2) NOT NULL DEFAULT 0,
  `penalty_frequency` VARCHAR(45) NOT NULL,
  `basic_rate` DECIMAL(15,2) NOT NULL DEFAULT 0,
  `sef_rate` DECIMAL(15,2) NOT NULL DEFAULT 0,
  `year` INT NOT NULL,
  `posted_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `posted_by` TINYINT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_assessment_posts_users1_idx` (`posted_by` ASC) VISIBLE,
  INDEX `fk_rpt_assessment_posts_taxpayers1_idx` (`real_taxpayers_id` ASC) VISIBLE,
  CONSTRAINT `fk_rpt_assessment_posts_taxpayers1`
    FOREIGN KEY (`real_taxpayers_id`)
    REFERENCES `lfs_db`.`taxpayers` (`id`),
  CONSTRAINT `fk_rpt_assessment_posts_users1`
    FOREIGN KEY (`posted_by`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`rpt_payments`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`rpt_payments` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `payment_collections_id` INT NOT NULL,
  `posted_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `posted_by` TINYINT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_rpt_payment_posts_payment_collections1_idx` (`payment_collections_id` ASC) VISIBLE,
  INDEX `fk_rpt_payments_users1_idx` (`posted_by` ASC) VISIBLE,
  CONSTRAINT `fk_rpt_payments_payment_collections1`
    FOREIGN KEY (`payment_collections_id`)
    REFERENCES `lfs_db`.`payment_collections` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_rpt_payments_users1`
    FOREIGN KEY (`posted_by`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`rpt_tax_dues`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`rpt_tax_dues` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `rpt_assessment_posts_id` INT NOT NULL,
  `rpt_payments_id` INT NOT NULL,
  `discount_rate` DECIMAL(15,2) NOT NULL DEFAULT 0,
  `is_advance` TINYINT NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`),
  INDEX `fk_rpt_tax_dues_rpt_assessment_posts1_idx` (`rpt_assessment_posts_id` ASC) VISIBLE,
  INDEX `fk_rpt_tax_dues_rpt_payments1_idx` (`rpt_payments_id` ASC) VISIBLE,
  CONSTRAINT `fk_rpt_tax_dues_rpt_assessment_posts1`
    FOREIGN KEY (`rpt_assessment_posts_id`)
    REFERENCES `lfs_db`.`rpt_assessment_posts` (`id`),
  CONSTRAINT `fk_rpt_tax_dues_rpt_payments1`
    FOREIGN KEY (`rpt_payments_id`)
    REFERENCES `lfs_db`.`rpt_payments` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`actual_use_codes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`actual_use_codes` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `code` VARCHAR(45) NOT NULL,
  `name` VARCHAR(99) NOT NULL,
  `is_government` TINYINT NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`provinces`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`provinces` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `code` VARCHAR(45) NOT NULL,
  `name` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`municipalities`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`municipalities` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `provinces_id` INT NOT NULL,
  `code` VARCHAR(45) NOT NULL,
  `name` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_municipalities_provinces1_idx` (`provinces_id` ASC) VISIBLE,
  CONSTRAINT `fk_municipalities_provinces1`
    FOREIGN KEY (`provinces_id`)
    REFERENCES `lfs_db`.`provinces` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`barangays`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`barangays` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `code` VARCHAR(45) NOT NULL,
  `name` VARCHAR(99) NOT NULL,
  `municipalities_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_barangays_municipalities1_idx` (`municipalities_id` ASC) VISIBLE,
  CONSTRAINT `fk_barangays_municipalities1`
    FOREIGN KEY (`municipalities_id`)
    REFERENCES `lfs_db`.`municipalities` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`classification_codes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`classification_codes` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `code` VARCHAR(45) NOT NULL,
  `name` VARCHAR(99) NOT NULL,
  `is_special` TINYINT NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`real_properties`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`real_properties` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `taxpayers_id` INT NOT NULL,
  `barangays_id` INT NOT NULL,
  `classification_codes_id` INT NOT NULL,
  `actual_use_codes_id` INT NOT NULL,
  `street` VARCHAR(99) NULL,
  `complete_arp_no` VARCHAR(99) NOT NULL,
  `property_pin` VARCHAR(45) NULL,
  `property_kind` VARCHAR(45) NOT NULL,
  `effectivity_quarter` INT NOT NULL,
  `effectivity_year` INT NOT NULL,
  `other_improvements` DECIMAL(15,2) NOT NULL DEFAULT 0,
  `assessed_value` DECIMAL(15,2) NOT NULL DEFAULT 0,
  `area` DECIMAL(15,2) NOT NULL DEFAULT 0,
  `lot_no` VARCHAR(45) NULL,
  `gr_year` INT NOT NULL,
  `is_taxable` TINYINT NOT NULL DEFAULT 0,
  `is_cancelled` TINYINT NULL DEFAULT 0,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `created_by` TINYINT UNSIGNED NOT NULL,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `updated_by` TINYINT UNSIGNED NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_real_properties_taxpayers1_idx` (`taxpayers_id` ASC) VISIBLE,
  INDEX `fk_real_properties_barangays1_idx` (`barangays_id` ASC) VISIBLE,
  INDEX `fk_real_properties_classification_codes1_idx` (`classification_codes_id` ASC) VISIBLE,
  INDEX `fk_real_properties_actual_use_codes1_idx` (`actual_use_codes_id` ASC) VISIBLE,
  INDEX `fk_real_properties_users1_idx` (`created_by` ASC) VISIBLE,
  INDEX `fk_real_properties_users2_idx` (`updated_by` ASC) VISIBLE,
  CONSTRAINT `fk_real_properties_actual_use_codes1`
    FOREIGN KEY (`actual_use_codes_id`)
    REFERENCES `lfs_db`.`actual_use_codes` (`id`),
  CONSTRAINT `fk_real_properties_barangays1`
    FOREIGN KEY (`barangays_id`)
    REFERENCES `lfs_db`.`barangays` (`id`),
  CONSTRAINT `fk_real_properties_classification_codes1`
    FOREIGN KEY (`classification_codes_id`)
    REFERENCES `lfs_db`.`classification_codes` (`id`),
  CONSTRAINT `fk_real_properties_taxpayers1`
    FOREIGN KEY (`taxpayers_id`)
    REFERENCES `lfs_db`.`taxpayers` (`id`),
  CONSTRAINT `fk_real_properties_users1`
    FOREIGN KEY (`created_by`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_real_properties_users2`
    FOREIGN KEY (`updated_by`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`realignments`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`realignments` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `budget_appropriations_id` INT UNSIGNED NOT NULL,
  `amount` DECIMAL(15,2) NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`),
  INDEX `fk_realignments_budget_appropriations1_idx` (`budget_appropriations_id` ASC) VISIBLE,
  CONSTRAINT `fk_realignments_budget_appropriations1`
    FOREIGN KEY (`budget_appropriations_id`)
    REFERENCES `lfs_db`.`budget_appropriations` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`budget_appropriation_has_realignments`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`budget_appropriation_has_realignments` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `budget_appropriations_id` INT UNSIGNED NOT NULL,
  `realignments_id` INT NOT NULL,
  `date_entry` TIMESTAMP NOT NULL,
  `remarks` VARCHAR(99) NULL,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  INDEX `fk_budget_appropriation_has_realignments_budget_appropriati_idx` (`budget_appropriations_id` ASC) VISIBLE,
  INDEX `fk_budget_appropriation_has_realignments_realignments1_idx` (`realignments_id` ASC) VISIBLE,
  CONSTRAINT `fk_budget_appropriation_has_realignments_budget_appropriations1`
    FOREIGN KEY (`budget_appropriations_id`)
    REFERENCES `lfs_db`.`budget_appropriations` (`id`),
  CONSTRAINT `fk_budget_appropriation_has_realignments_realignments1`
    FOREIGN KEY (`realignments_id`)
    REFERENCES `lfs_db`.`realignments` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`business_categories`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`business_categories` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `code` VARCHAR(45) NULL,
  `ordinance_ref_no` VARCHAR(45) NULL,
  `description` VARCHAR(99) NOT NULL,
  `is_line_of_business` TINYINT NULL,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`business_type`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`business_type` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`business`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`business` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `business_categories_id` INT NOT NULL,
  `barangays_id` INT NOT NULL,
  `business_type_id` INT NOT NULL,
  `main_branch` INT NULL,
  `business_plate_no` VARCHAR(99) NULL,
  `business_name` VARCHAR(99) NOT NULL,
  `bir_tin` VARCHAR(99) NULL,
  `business_address` VARCHAR(99) NULL,
  `business_barangay` VARCHAR(99) NOT NULL,
  `contact_info` VARCHAR(99) NULL,
  `application_date` DATE NOT NULL,
  `year` INT NOT NULL,
  `owner_name` VARCHAR(45) NOT NULL,
  `owner_tin` VARCHAR(45) NULL,
  `owner_type` VARCHAR(45) NOT NULL,
  `owner_contact_info` VARCHAR(45) NULL,
  `owner_barangay` VARCHAR(45) NOT NULL,
  `owner_municipality` VARCHAR(45) NOT NULL,
  `owner_province` VARCHAR(45) NOT NULL,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `created_by` TINYINT UNSIGNED NOT NULL,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `updated_by` TINYINT UNSIGNED NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_businesses_business_type1_idx` (`business_type_id` ASC) VISIBLE,
  INDEX `fk_businesses_barangays1_idx` (`barangays_id` ASC) VISIBLE,
  INDEX `fk_businesses_business_categories1_idx` (`business_categories_id` ASC) VISIBLE,
  INDEX `fk_business_users1_idx` (`created_by` ASC) VISIBLE,
  INDEX `fk_business_users2_idx` (`updated_by` ASC) VISIBLE,
  INDEX `fk_business_business1_idx` (`main_branch` ASC) VISIBLE,
  CONSTRAINT `fk_business_business1`
    FOREIGN KEY (`main_branch`)
    REFERENCES `lfs_db`.`business` (`id`),
  CONSTRAINT `fk_businesses_barangays1`
    FOREIGN KEY (`barangays_id`)
    REFERENCES `lfs_db`.`barangays` (`id`),
  CONSTRAINT `fk_businesses_business_categories1`
    FOREIGN KEY (`business_categories_id`)
    REFERENCES `lfs_db`.`business_categories` (`id`)
    ON DELETE RESTRICT,
  CONSTRAINT `fk_businesses_business_type1`
    FOREIGN KEY (`business_type_id`)
    REFERENCES `lfs_db`.`business_type` (`id`),
  CONSTRAINT `fk_business_users1`
    FOREIGN KEY (`created_by`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_business_users2`
    FOREIGN KEY (`updated_by`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`business_add_on_charges`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`business_add_on_charges` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `code` VARCHAR(45) NULL,
  `description` VARCHAR(99) NOT NULL,
  `is_applied_each_business` TINYINT NOT NULL DEFAULT 0,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `created_by` TINYINT UNSIGNED NOT NULL,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `updated_by` TINYINT UNSIGNED NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `description_UNIQUE` (`description` ASC) VISIBLE,
  INDEX `fk_business_add_on_charges_users1_idx` (`created_by` ASC) VISIBLE,
  INDEX `fk_business_add_on_charges_users2_idx` (`updated_by` ASC) VISIBLE,
  CONSTRAINT `fk_business_add_on_charges_users1`
    FOREIGN KEY (`created_by`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_business_add_on_charges_users2`
    FOREIGN KEY (`updated_by`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`business_categories_has_add_on_charges`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`business_categories_has_add_on_charges` (
  `business_categories_id` INT NOT NULL,
  `business_add_on_charges_id` INT NOT NULL,
  INDEX `fk_business_add_on_charges_has_lob_business_add_on_charges1_idx` (`business_add_on_charges_id` ASC) VISIBLE,
  INDEX `fk_business_add_on_charges_has_lob_business_categories1_idx` (`business_categories_id` ASC) VISIBLE,
  CONSTRAINT `fk_business_add_on_charges_has_lob_business_add_on_charges1`
    FOREIGN KEY (`business_add_on_charges_id`)
    REFERENCES `lfs_db`.`business_add_on_charges` (`id`)
    ON DELETE RESTRICT,
  CONSTRAINT `fk_business_add_on_charges_has_lob_business_categories1`
    FOREIGN KEY (`business_categories_id`)
    REFERENCES `lfs_db`.`business_categories` (`id`)
    ON DELETE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`bank_deposits_has_cheques`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`bank_deposits_has_cheques` (
  `bank_deposits_id` INT NOT NULL,
  `cheques_id` INT NOT NULL,
  INDEX `fk_bank_deposits_has_cheques_bank_deposits1_idx` (`bank_deposits_id` ASC) VISIBLE,
  INDEX `fk_bank_deposits_has_cheques_cheques1_idx` (`cheques_id` ASC) VISIBLE,
  CONSTRAINT `fk_bank_deposits_has_cheques_cheques1`
    FOREIGN KEY (`cheques_id`)
    REFERENCES `lfs_db`.`cheques` (`id`),
  CONSTRAINT `fk_bank_deposits_has_cheques_bank_deposits1`
    FOREIGN KEY (`bank_deposits_id`)
    REFERENCES `lfs_db`.`bank_deposits` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`payment_collection_has_cheques`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`payment_collection_has_cheques` (
  `payment_collections_id` INT NOT NULL,
  `cheques_id` INT NOT NULL,
  INDEX `fk_payment_collection_has_cheques_payment_collections1_idx` (`payment_collections_id` ASC) VISIBLE,
  INDEX `fk_payment_collection_has_cheques_cheques1_idx` (`cheques_id` ASC) VISIBLE,
  CONSTRAINT `fk_payment_collection_has_cheques_cheques1`
    FOREIGN KEY (`cheques_id`)
    REFERENCES `lfs_db`.`cheques` (`id`),
  CONSTRAINT `fk_payment_collection_has_cheques_payment_collections1`
    FOREIGN KEY (`payment_collections_id`)
    REFERENCES `lfs_db`.`payment_collections` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`released_cheques`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`released_cheques` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `rci_id` INT NOT NULL,
  `date_released` DATETIME NOT NULL,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  INDEX `fk_table1_rci1_idx` (`rci_id` ASC) VISIBLE,
  CONSTRAINT `fk_table1_rci1`
    FOREIGN KEY (`rci_id`)
    REFERENCES `lfs_db`.`rci` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`tax_type`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`tax_type` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `parent` INT NULL,
  `funds_id` TINYINT UNSIGNED NULL,
  `code` VARCHAR(45) NOT NULL,
  `description` VARCHAR(99) NULL,
  `coa_account_code` VARCHAR(99) NULL,
  `blgf_account_code` VARCHAR(99) NULL,
  `is_deleted` TINYINT NOT NULL DEFAULT 0,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  INDEX `fk_taxtype_funds1_idx` (`funds_id` ASC) VISIBLE,
  INDEX `fk_taxtype_taxtype1_idx` (`parent` ASC) VISIBLE,
  CONSTRAINT `fk_taxtype_taxtype1`
    FOREIGN KEY (`parent`)
    REFERENCES `lfs_db`.`tax_type` (`id`),
  CONSTRAINT `fk_tax_type_funds1`
    FOREIGN KEY (`funds_id`)
    REFERENCES `lfs_db`.`funds` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`other_payment_rates`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`other_payment_rates` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `tax_type_id` INT NOT NULL,
  `description` VARCHAR(200) NOT NULL,
  `amount` DECIMAL(12,1) NULL,
  `starting_year` INT NULL,
  `is_rate_editable` TINYINT NOT NULL DEFAULT 0,
  `created_by` TINYINT UNSIGNED NOT NULL,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_by` TINYINT UNSIGNED NULL,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  INDEX `fk_other_payment_rates_tax_type1_idx` (`tax_type_id` ASC) VISIBLE,
  INDEX `fk_other_payment_rates_users1_idx` (`created_by` ASC) VISIBLE,
  INDEX `fk_other_payment_rates_users2_idx` (`updated_by` ASC) VISIBLE,
  CONSTRAINT `fk_other_payment_rates_tax_type1`
    FOREIGN KEY (`tax_type_id`)
    REFERENCES `lfs_db`.`tax_type` (`id`),
  CONSTRAINT `fk_other_payment_rates_users1`
    FOREIGN KEY (`created_by`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_other_payment_rates_users2`
    FOREIGN KEY (`updated_by`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`payment_fees_charges`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`payment_fees_charges` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `payment_collections_id` INT NOT NULL,
  `other_payment_rates_id` INT NOT NULL,
  `unit` INT NOT NULL DEFAULT 0,
  `sub_total` DECIMAL(12,2) NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`),
  INDEX `fk_other_payment_charges_other_payment_rates1_idx` (`other_payment_rates_id` ASC) VISIBLE,
  INDEX `fk_other_payment_charges_payment_collections1_idx` (`payment_collections_id` ASC) VISIBLE,
  CONSTRAINT `fk_other_payment_charges_other_payment_rates1`
    FOREIGN KEY (`other_payment_rates_id`)
    REFERENCES `lfs_db`.`other_payment_rates` (`id`),
  CONSTRAINT `fk_payment_fees_charges_payment_collections1`
    FOREIGN KEY (`payment_collections_id`)
    REFERENCES `lfs_db`.`payment_collections` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`cash_tickets`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`cash_tickets` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `description` VARCHAR(200) NOT NULL,
  `quantity` INT(11) NOT NULL,
  `received_date` DATETIME NOT NULL,
  `remarks` TEXT NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`cash_tickets_issued`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`cash_tickets_issued` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `cash_tickets_id` INT(11) NOT NULL,
  `collecting_officers_id` TINYINT(3) UNSIGNED NOT NULL,
  `job_orders_id` TINYINT(4) NULL DEFAULT NULL,
  `date_issued` DATE NOT NULL,
  `quantity` INT(11) NOT NULL,
  `is_returned` TINYINT(4) NOT NULL DEFAULT '0',
  `issued_by` TINYINT(3) UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_cash_tickets_issued_cash_tickets1_idx` (`cash_tickets_id` ASC) VISIBLE,
  INDEX `fk_cash_tickets_issued_users1_idx` (`issued_by` ASC) VISIBLE,
  INDEX `fk_cash_tickets_issued_collecting_officers1_idx` (`collecting_officers_id` ASC) VISIBLE,
  INDEX `fk_cash_tickets_issued_job_orders1_idx` (`job_orders_id` ASC) VISIBLE,
  CONSTRAINT `fk_cash_tickets_issued_cash_tickets1`
    FOREIGN KEY (`cash_tickets_id`)
    REFERENCES `lfs_db`.`cash_tickets` (`id`),
  CONSTRAINT `fk_cash_tickets_issued_collecting_officers1`
    FOREIGN KEY (`collecting_officers_id`)
    REFERENCES `lfs_db`.`collecting_officers` (`id`),
  CONSTRAINT `fk_cash_tickets_issued_job_orders1`
    FOREIGN KEY (`job_orders_id`)
    REFERENCES `lfs_db`.`job_orders` (`id`),
  CONSTRAINT `fk_cash_tickets_issued_users1`
    FOREIGN KEY (`issued_by`)
    REFERENCES `lfs_db`.`users` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`cattle_ownership`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`cattle_ownership` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `payment_collections_id` INT NOT NULL,
  `taxpayers_id` INT(11) NOT NULL,
  `cattle_name` VARCHAR(99) NOT NULL,
  `cattle_sex` VARCHAR(45) NOT NULL,
  `cattle_age` INT NULL DEFAULT 0,
  `cattle_years` INT NULL DEFAULT 0,
  `description` VARCHAR(99) NULL,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `created_by` TINYINT UNSIGNED NOT NULL,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `updated_by` TINYINT UNSIGNED NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_other_payment_cattle_ownership_users1_idx` (`created_by` ASC) VISIBLE,
  INDEX `fk_other_payment_cattle_ownership_users2_idx` (`updated_by` ASC) VISIBLE,
  INDEX `fk_cattle_ownership_payment_collections1_idx` (`payment_collections_id` ASC) VISIBLE,
  INDEX `fk_cattle_ownership_taxpayers1_idx` (`taxpayers_id` ASC) VISIBLE,
  CONSTRAINT `fk_cattle_ownership_taxpayers1`
    FOREIGN KEY (`taxpayers_id`)
    REFERENCES `lfs_db`.`taxpayers` (`id`),
  CONSTRAINT `fk_cattle_ownership_payment_collections1`
    FOREIGN KEY (`payment_collections_id`)
    REFERENCES `lfs_db`.`payment_collections` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_cattle_ownership_users1`
    FOREIGN KEY (`created_by`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_cattle_ownership_users2`
    FOREIGN KEY (`updated_by`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`marriage_license`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`marriage_license` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `payment_collections_id` INT NOT NULL,
  `registry_no` VARCHAR(45) NOT NULL,
  `marriage_license_no` VARCHAR(45) NOT NULL,
  `date_issued` DATETIME NOT NULL,
  `date_published` DATETIME NOT NULL,
  `groom_registry_id` INT NOT NULL,
  `groom_age` INT NOT NULL,
  `groom_months` INT NOT NULL,
  `groom_religion` VARCHAR(99) NOT NULL,
  `groom_residence` VARCHAR(200) NULL,
  `bride_registry_id` INT NOT NULL,
  `bride_age` INT NOT NULL,
  `bride_months` INT NOT NULL,
  `bride_religion` VARCHAR(99) NOT NULL,
  `bride_residence` VARCHAR(200) NULL,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `created_by` TINYINT UNSIGNED NOT NULL,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `updated_by` TINYINT UNSIGNED NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_marriage_license_users1_idx` (`created_by` ASC) VISIBLE,
  INDEX `fk_marriage_license_users2_idx` (`updated_by` ASC) VISIBLE,
  INDEX `fk_marriage_license_payment_collections1_idx` (`payment_collections_id` ASC) VISIBLE,
  INDEX `fk_marriage_license_registry1_idx` (`groom_registry_id` ASC) VISIBLE,
  INDEX `fk_marriage_license_registry2_idx` (`bride_registry_id` ASC) VISIBLE,
  CONSTRAINT `fk_marriage_license_registry1`
    FOREIGN KEY (`groom_registry_id`)
    REFERENCES `lfs_db`.`registry` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_marriage_license_registry2`
    FOREIGN KEY (`bride_registry_id`)
    REFERENCES `lfs_db`.`registry` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_marriage_license_payment_collections1`
    FOREIGN KEY (`payment_collections_id`)
    REFERENCES `lfs_db`.`payment_collections` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_marriage_license_users1`
    FOREIGN KEY (`created_by`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_marriage_license_users2`
    FOREIGN KEY (`updated_by`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`burial_permit`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`burial_permit` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `payment_collections_id` INT NOT NULL,
  `remains_registry_id` INT NOT NULL,
  `permission` VARCHAR(45) NULL,
  `remains_age` INT NULL,
  `death_date` DATE NOT NULL,
  `cause_of_death` VARCHAR(200) NOT NULL,
  `cemetery` VARCHAR(99) NOT NULL,
  `disinterment` VARCHAR(99) NULL,
  `is_infectious` TINYINT NOT NULL DEFAULT 0,
  `is_embalmed` TINYINT NOT NULL DEFAULT 0,
  `disposition` VARCHAR(99) NULL,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `created_by` TINYINT UNSIGNED NOT NULL,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `updated_by` TINYINT UNSIGNED NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_burial_permit_users1_idx` (`created_by` ASC) VISIBLE,
  INDEX `fk_burial_permit_users2_idx` (`updated_by` ASC) VISIBLE,
  INDEX `fk_burial_permit_payment_collections1_idx` (`payment_collections_id` ASC) VISIBLE,
  INDEX `fk_burial_permit_registry1_idx` (`remains_registry_id` ASC) VISIBLE,
  CONSTRAINT `fk_burial_permit_registry1`
    FOREIGN KEY (`remains_registry_id`)
    REFERENCES `lfs_db`.`registry` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_burial_permit_payment_collections1`
    FOREIGN KEY (`payment_collections_id`)
    REFERENCES `lfs_db`.`payment_collections` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_burial_permit_users1`
    FOREIGN KEY (`created_by`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_burial_permit_users2`
    FOREIGN KEY (`updated_by`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`prev_cattle_ownership`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`prev_cattle_ownership` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `cattle_ownership_id` INT NOT NULL,
  `previous_cattle_ownership_id` INT NOT NULL,
  `cattle_price` DECIMAL(12,2) NOT NULL DEFAULT 0,
  `transfer_date` DATE NOT NULL,
  `SAMPLE` VARCHAR(45) NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_cattle_transfer_history_cattle_ownership1_idx` (`previous_cattle_ownership_id` ASC) VISIBLE,
  INDEX `fk_prev_cattle_ownership_cattle_ownership2_idx` (`cattle_ownership_id` ASC) VISIBLE,
  CONSTRAINT `fk_cattle_transfer_history_cattle_ownership1`
    FOREIGN KEY (`previous_cattle_ownership_id`)
    REFERENCES `lfs_db`.`cattle_ownership` (`id`),
  CONSTRAINT `fk_prev_cattle_ownership_cattle_ownership2`
    FOREIGN KEY (`cattle_ownership_id`)
    REFERENCES `lfs_db`.`cattle_ownership` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`rpt_previous_assessment`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`rpt_previous_assessment` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `real_properties_id` INT NOT NULL,
  `taxpayers_id` INT NOT NULL,
  `complete_arp_no` VARCHAR(45) NOT NULL,
  `pin` VARCHAR(45) NULL,
  `assessed_value` DECIMAL(12,2) NOT NULL,
  `date_of_entry` VARCHAR(45) NOT NULL,
  `effectivity_quarter` VARCHAR(45) NOT NULL,
  `effectivity_year` VARCHAR(45) NOT NULL,
  `gr_year` VARCHAR(45) NOT NULL,
  `is_taxable` TINYINT NOT NULL,
  `is_cancelled` TINYINT NOT NULL,
  `recording_person` VARCHAR(45) NULL,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `created_by` TINYINT UNSIGNED NOT NULL,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `updated_by` TINYINT UNSIGNED NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_rpt_previous_assessment_real_properties1_idx` (`real_properties_id` ASC) VISIBLE,
  INDEX `fk_rpt_previous_assessment_users1_idx` (`created_by` ASC) VISIBLE,
  INDEX `fk_rpt_previous_assessment_taxpayers1_idx` (`taxpayers_id` ASC) VISIBLE,
  INDEX `fk_rpt_previous_assessment_users2_idx` (`updated_by` ASC) VISIBLE,
  CONSTRAINT `fk_rpt_previous_assessment_real_properties1`
    FOREIGN KEY (`real_properties_id`)
    REFERENCES `lfs_db`.`real_properties` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_rpt_previous_assessment_users1`
    FOREIGN KEY (`created_by`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_rpt_previous_assessment_taxpayers1`
    FOREIGN KEY (`taxpayers_id`)
    REFERENCES `lfs_db`.`taxpayers` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_rpt_previous_assessment_users2`
    FOREIGN KEY (`updated_by`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `lfs_db`.`community_tax_certificate`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`community_tax_certificate` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `payment_collections_id` INT(11) NOT NULL,
  `year` INT(11) NOT NULL,
  `place_of_issued` VARCHAR(45) NOT NULL,
  `date_issued` DATETIME NOT NULL,
  `first_name` VARCHAR(45) NOT NULL,
  `middle_name` VARCHAR(45) NULL DEFAULT NULL,
  `last_name` VARCHAR(45) NOT NULL,
  `sex` TINYINT(4) NOT NULL,
  `citizenship` VARCHAR(45) NULL DEFAULT NULL,
  `address` TEXT NULL DEFAULT NULL,
  `tin` VARCHAR(45) NULL DEFAULT NULL,
  `icr_no` VARCHAR(45) NULL DEFAULT NULL,
  `place_of_birth` TEXT NULL DEFAULT NULL,
  `height` DECIMAL(5,2) NULL DEFAULT NULL,
  `weight` DECIMAL(5,2) NULL DEFAULT NULL,
  `civil_status` VARCHAR(45) NOT NULL,
  `date_of_birth` DATETIME NULL DEFAULT NULL,
  `profession_occupation_business` TEXT NULL DEFAULT NULL,
  `basic_community_tax` DECIMAL(9,2) NULL DEFAULT NULL,
  `additional_community_tax` DECIMAL(9,2) NULL DEFAULT NULL,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `created_by` TINYINT(3) UNSIGNED NOT NULL,
  `updated_at` TIMESTAMP NULL DEFAULT NULL,
  `updated_by` TINYINT(3) UNSIGNED NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_community_tax_certificate_payment_collections1_idx` (`payment_collections_id` ASC) VISIBLE,
  CONSTRAINT `fk_community_tax_certificate_payment_collections1`
    FOREIGN KEY (`payment_collections_id`)
    REFERENCES `lfs_db`.`payment_collections` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
AUTO_INCREMENT = 11
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `lfs_db`.`delinquent_notice`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`delinquent_notice` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `real_properties_id` INT NOT NULL,
  `notice_type` VARCHAR(45) NOT NULL,
  `notice_date` DATETIME NOT NULL,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `created_by` TINYINT UNSIGNED NOT NULL,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `updated_by` TINYINT UNSIGNED NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_delinquent_notice_real_properties1_idx` (`real_properties_id` ASC) VISIBLE,
  INDEX `fk_delinquent_notice_users1_idx` (`created_by` ASC) VISIBLE,
  INDEX `fk_delinquent_notice_users2_idx` (`updated_by` ASC) VISIBLE,
  CONSTRAINT `fk_delinquent_notice_real_properties1`
    FOREIGN KEY (`real_properties_id`)
    REFERENCES `lfs_db`.`real_properties` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_delinquent_notice_users1`
    FOREIGN KEY (`created_by`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_delinquent_notice_users2`
    FOREIGN KEY (`updated_by`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `lfs_db`.`rpt_levy`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`rpt_levy` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `real_properties_id` INT NOT NULL,
  `date_issued` DATETIME NOT NULL,
  `is_cancelled` TINYINT NOT NULL DEFAULT 0,
  `created_at` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `created_by` TINYINT UNSIGNED NOT NULL,
  `updated_at` DATETIME NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `updated_by` TINYINT UNSIGNED NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_warrant_of_levy_users1_idx` (`created_by` ASC) VISIBLE,
  INDEX `fk_warrant_of_levy_users2_idx` (`updated_by` ASC) VISIBLE,
  INDEX `fk_rpt_levy_real_properties1_idx` (`real_properties_id` ASC) VISIBLE,
  CONSTRAINT `fk_warrant_of_levy_users1`
    FOREIGN KEY (`created_by`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_warrant_of_levy_users2`
    FOREIGN KEY (`updated_by`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_rpt_levy_real_properties1`
    FOREIGN KEY (`real_properties_id`)
    REFERENCES `lfs_db`.`real_properties` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `lfs_db`.`auction`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`auction` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `start_date` DATETIME NOT NULL,
  `end_date` DATETIME NULL,
  `location` VARCHAR(200) NOT NULL,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `created_by` TINYINT UNSIGNED NOT NULL,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `updated_by` TINYINT UNSIGNED NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_rpt_auction_users1_idx` (`created_by` ASC) VISIBLE,
  INDEX `fk_rpt_auction_users2_idx` (`updated_by` ASC) VISIBLE,
  CONSTRAINT `fk_rpt_auction_users1`
    FOREIGN KEY (`created_by`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_rpt_auction_users2`
    FOREIGN KEY (`updated_by`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `lfs_db`.`bidders`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`bidders` (
  `id` TINYINT NOT NULL AUTO_INCREMENT,
  `taxpayers_id` INT NOT NULL,
  `auction_id` INT NOT NULL,
  `payment_collections_id` INT NOT NULL,
  `bidder_no` VARCHAR(45) NOT NULL,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `created_by` TINYINT UNSIGNED NOT NULL,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `updated_by` TINYINT UNSIGNED NULL,
  INDEX `fk_bidders_taxpayers1_idx` (`taxpayers_id` ASC) VISIBLE,
  PRIMARY KEY (`id`),
  INDEX `fk_bidders_users1_idx` (`created_by` ASC) VISIBLE,
  INDEX `fk_bidders_users2_idx` (`updated_by` ASC) VISIBLE,
  INDEX `fk_bidders_auction1_idx` (`auction_id` ASC) VISIBLE,
  INDEX `fk_bidders_payment_collections1_idx` (`payment_collections_id` ASC) VISIBLE,
  CONSTRAINT `fk_bidders_taxpayers1`
    FOREIGN KEY (`taxpayers_id`)
    REFERENCES `lfs_db`.`taxpayers` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_bidders_users1`
    FOREIGN KEY (`created_by`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_bidders_users2`
    FOREIGN KEY (`updated_by`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_bidders_auction1`
    FOREIGN KEY (`auction_id`)
    REFERENCES `lfs_db`.`auction` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_bidders_payment_collections1`
    FOREIGN KEY (`payment_collections_id`)
    REFERENCES `lfs_db`.`payment_collections` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `lfs_db`.`bidders_waiver`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`bidders_waiver` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `bidders_id` TINYINT NOT NULL,
  `auction_id` INT NOT NULL,
  `notary_lgu` VARCHAR(45) NOT NULL,
  `notary_name` VARCHAR(45) NOT NULL,
  `ctc_no` VARCHAR(45) NOT NULL,
  `date_issued` DATETIME NOT NULL,
  `place_issued` VARCHAR(100) NOT NULL,
  `witness_date` DATETIME NOT NULL,
  `seal_date` DATETIME NOT NULL,
  `doc_no` VARCHAR(45) NULL,
  `page_no` VARCHAR(45) NULL,
  `book_no` VARCHAR(45) NULL,
  `series_of` VARCHAR(45) NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_bidders_waiver_bidders1_idx` (`bidders_id` ASC) VISIBLE,
  INDEX `fk_bidders_waiver_auction1_idx` (`auction_id` ASC) VISIBLE,
  CONSTRAINT `fk_bidders_waiver_bidders1`
    FOREIGN KEY (`bidders_id`)
    REFERENCES `lfs_db`.`bidders` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_bidders_waiver_auction1`
    FOREIGN KEY (`auction_id`)
    REFERENCES `lfs_db`.`auction` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `lfs_db`.`rpt_auction`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`rpt_auction` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `real_properties_id` INT NOT NULL,
  `auction_id` INT NOT NULL,
  `created_at` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `created_by` TINYINT UNSIGNED NOT NULL,
  `updated_at` DATETIME NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `updated_by` TINYINT UNSIGNED NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_auction_notice_rpt_auction1_idx` (`auction_id` ASC) VISIBLE,
  INDEX `fk_auction_notice_users1_idx` (`created_by` ASC) VISIBLE,
  INDEX `fk_auction_notice_users2_idx` (`updated_by` ASC) VISIBLE,
  INDEX `fk_auction_notice_real_properties1_idx` (`real_properties_id` ASC) VISIBLE,
  CONSTRAINT `fk_auction_notice_rpt_auction1`
    FOREIGN KEY (`auction_id`)
    REFERENCES `lfs_db`.`auction` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_auction_notice_users1`
    FOREIGN KEY (`created_by`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_auction_notice_users2`
    FOREIGN KEY (`updated_by`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_auction_notice_real_properties1`
    FOREIGN KEY (`real_properties_id`)
    REFERENCES `lfs_db`.`real_properties` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `lfs_db`.`bid`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`bid` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `rpt_auction_id` INT NOT NULL,
  `bidders_id` TINYINT NOT NULL,
  `ordinance_no` VARCHAR(45) NOT NULL,
  `date` DATETIME NOT NULL,
  `bid_amount` DECIMAL(12,2) NOT NULL DEFAULT 0,
  `created_at` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `created_by` TINYINT UNSIGNED NOT NULL,
  `updated_at` DATETIME NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `updated_by` TINYINT UNSIGNED NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_bid_rpt_auction1_idx` (`rpt_auction_id` ASC) VISIBLE,
  INDEX `fk_bid_bidders1_idx` (`bidders_id` ASC) VISIBLE,
  INDEX `fk_bid_users1_idx` (`created_by` ASC) VISIBLE,
  INDEX `fk_bid_users2_idx` (`updated_by` ASC) VISIBLE,
  CONSTRAINT `fk_bid_rpt_auction1`
    FOREIGN KEY (`rpt_auction_id`)
    REFERENCES `lfs_db`.`rpt_auction` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_bid_bidders1`
    FOREIGN KEY (`bidders_id`)
    REFERENCES `lfs_db`.`bidders` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_bid_users1`
    FOREIGN KEY (`created_by`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_bid_users2`
    FOREIGN KEY (`updated_by`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `lfs_db`.`rcd`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`rcd` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `funds_id` TINYINT UNSIGNED NULL,
  `report_no` VARCHAR(45) NOT NULL,
  `date` DATETIME NOT NULL,
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `created_by` TINYINT UNSIGNED NOT NULL,
  `updated_at` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  INDEX `fk_rcd_funds1_idx` (`funds_id` ASC) VISIBLE,
  INDEX `fk_rcd_users2_idx` (`created_by` ASC) VISIBLE,
  CONSTRAINT `fk_rcd_funds1`
    FOREIGN KEY (`funds_id`)
    REFERENCES `lfs_db`.`funds` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_rcd_users2`
    FOREIGN KEY (`created_by`)
    REFERENCES `lfs_db`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `lfs_db`.`rcd_collections`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`rcd_collections` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `rcd_id` INT NOT NULL,
  `payment_collections_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_rcd_collections_rcd1_idx` (`rcd_id` ASC) VISIBLE,
  INDEX `fk_rcd_collections_payment_collections1_idx` (`payment_collections_id` ASC) VISIBLE,
  CONSTRAINT `fk_rcd_collections_rcd1`
    FOREIGN KEY (`rcd_id`)
    REFERENCES `lfs_db`.`rcd` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_rcd_collections_payment_collections1`
    FOREIGN KEY (`payment_collections_id`)
    REFERENCES `lfs_db`.`payment_collections` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `lfs_db`.`rcd_deposits`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`rcd_deposits` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `rcd_id` INT NOT NULL,
  `bank_deposits_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_rcd_deposits_rcd1_idx` (`rcd_id` ASC) VISIBLE,
  INDEX `fk_rcd_deposits_bank_deposits1_idx` (`bank_deposits_id` ASC) VISIBLE,
  CONSTRAINT `fk_rcd_deposits_rcd1`
    FOREIGN KEY (`rcd_id`)
    REFERENCES `lfs_db`.`rcd` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_rcd_deposits_bank_deposits1`
    FOREIGN KEY (`bank_deposits_id`)
    REFERENCES `lfs_db`.`bank_deposits` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;

USE `lfs_db` ;

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_accountable_forms`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_accountable_forms` (`id` INT, `acc_form_no` INT, `acc_form_desc` INT, `amount` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_allotment_release`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_allotment_release` (`allotment_release_id` INT, `allotment_account_id` INT, `aro_no` INT, `full_aro_no` INT, `purpose` INT, `date_issued` INT, `allotment_release_created_at` INT, `allotment_release_updated_at` INT, `budget_appropriations_id` INT, `funds_id` INT, `fund_code` INT, `fund_name` INT, `function_program_project_id` INT, `fpp_code` INT, `fpp_name` INT, `is_special` INT, `others_fpp_id` INT, `others_fpp_code` INT, `others_fpp_name` INT, `allotment_classes_id` INT, `allotment_code` INT, `allotment_name` INT, `general_ledger_accounts_id` INT, `account_code` INT, `ledger_name` INT, `date_entry` INT, `year` INT, `continuing` INT, `remarks` INT, `amount` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_beginning_balances`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_beginning_balances` (`beginning_balances_id` INT, `funds_id` INT, `fund_code` INT, `fund_name` INT, `general_ledger_accounts_id` INT, `general_ledger_accounts_code` INT, `general_ledger_accounts_name` INT, `sub_maj_acc_group_id` INT, `sub_maj_acc_group_code` INT, `sub_maj_acc_group_name` INT, `maj_acc_group_id` INT, `maj_acc_group_code` INT, `maj_acc_group_name` INT, `account_group_id` INT, `account_group_code` INT, `account_group_name` INT, `subsidiary_ledger_accounts_id` INT, `subsidiary_ledger_accounts_code` INT, `subsidiary_ledger_accounts_name` INT, `date_entry` INT, `is_debit` INT, `amount` INT, `created_at` INT, `updated_at` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_budget_appropriations`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_budget_appropriations` (`id` INT, `funds_id` INT, `fund_code` INT, `fund_name` INT, `fpp_id` INT, `fpp_code` INT, `fpp_name` INT, `fpp_is_special` INT, `functional_classification_service_id` INT, `functional_classification_service_name` INT, `functional_classification_id` INT, `functional_classification_sector_code` INT, `functional_classification_sector_name` INT, `others_fpp_id` INT, `others_fpp_code` INT, `others_fpp_name` INT, `allotment_class_id` INT, `allotment_class_code` INT, `allotment_class_name` INT, `general_ledger_accounts_id` INT, `general_ledger_accounts_code` INT, `general_ledger_accounts_name` INT, `account_code` INT, `date_entry` INT, `year` INT, `amount` INT, `continuing` INT, `remarks` INT, `created_at` INT, `updated_at` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_cash_disbursement_journal`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_cash_disbursement_journal` (`id` INT, `funds_id` INT, `journals_id` INT, `jev_no` INT, `date_entry` INT, `ref_no` INT, `payee` INT, `explanation` INT, `is_approved` INT, `created_at` INT, `created_by` INT, `updated_at` INT, `updated_by` INT, `cash_disbursements_journal_id` INT, `jev_id` INT, `disbursing_officers_id` INT, `dv_no` INT, `date_paid` INT, `first_name` INT, `mid_initial` INT, `last_name` INT, `full_name` INT, `job_title` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_cash_receipts_journal`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_cash_receipts_journal` (`id` INT, `funds_id` INT, `journals_id` INT, `jev_no` INT, `date_entry` INT, `ref_no` INT, `payee` INT, `explanation` INT, `is_approved` INT, `created_at` INT, `created_by` INT, `updated_at` INT, `updated_by` INT, `cash_receipts_journal_id` INT, `jev_id` INT, `collecting_officers_id` INT, `rcd_no` INT, `or_no` INT, `or_date` INT, `first_name` INT, `mid_initial` INT, `last_name` INT, `full_name` INT, `job_title` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_check_disbursement_journal`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_check_disbursement_journal` (`id` INT, `funds_id` INT, `journals_id` INT, `jev_no` INT, `date_entry` INT, `ref_no` INT, `payee` INT, `explanation` INT, `is_approved` INT, `created_at` INT, `created_by` INT, `updated_at` INT, `updated_by` INT, `check_disbursement_journal_id` INT, `jev_id` INT, `check_date` INT, `check_no` INT, `dv_no` INT, `rci_no` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_general_journal`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_general_journal` (`id` INT, `funds_id` INT, `journals_id` INT, `jev_no` INT, `date_entry` INT, `ref_no` INT, `payee` INT, `explanation` INT, `is_approved` INT, `created_at` INT, `created_by` INT, `updated_at` INT, `updated_by` INT, `general_journal_id` INT, `jev_id` INT, `dv_no` INT, `check_no` INT, `or_no` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_general_ledger_accounts`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_general_ledger_accounts` (`account_group_id` INT, `account_group_code` INT, `account_group_name` INT, `major_account_group_id` INT, `maj_acc_group_code` INT, `maj_acc_group_name` INT, `sub_maj_acc_group_code` INT, `sub_maj_acc_group_name` INT, `sub_major_account_group_id` INT, `general_ledger_accounts_id` INT, `account_code` INT, `ledger_code` INT, `ledger_name` INT, `is_contra_account` INT, `created_at` INT, `updated_at` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_jev`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_jev` (`id` INT, `funds_id` INT, `fund_code` INT, `fund_name` INT, `journals_id` INT, `journal_name` INT, `is_special` INT, `transaction_no` INT, `jev_no` INT, `full_jev_no` INT, `date_entry` INT, `ref_no` INT, `payee` INT, `explanation` INT, `remarks` INT, `status` INT, `is_edited` INT, `created_at` INT, `created_by` INT, `created_by_name` INT, `updated_at` INT, `updated_by` INT, `updated_by_name` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_jev_accounts`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_jev_accounts` (`id` INT, `jev_id` INT, `funds_id` INT, `fund_code` INT, `fund_name` INT, `journals_id` INT, `journal_name` INT, `is_special` INT, `jev_no` INT, `full_jev_no` INT, `date_entry` INT, `explanation` INT, `is_approved` INT, `is_disapproved` INT, `is_cancelled` INT, `fpp_id` INT, `fpp_code` INT, `fpp_name` INT, `general_ledger_accounts_id` INT, `account_code` INT, `general_ledger_accounts_code` INT, `general_ledger_accounts_name` INT, `general_ledger_accounts_is_contra_account` INT, `sub_maj_acc_group_id` INT, `sub_maj_acc_group_code` INT, `sub_maj_acc_group_name` INT, `maj_acc_group_id` INT, `maj_acc_group_code` INT, `maj_acc_group_name` INT, `account_group_id` INT, `account_group_code` INT, `account_group_name` INT, `subsidiary_ledger_accounts_id` INT, `subsidiary_ledger_accounts_code` INT, `subsidiary_ledger_accounts_name` INT, `obligation_no` INT, `is_deposit` INT, `is_debit` INT, `amount` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_journals_default_accounts`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_journals_default_accounts` (`id` INT, `journals_id` INT, `funds_id` INT, `general_ledger_accounts_id` INT, `account_code` INT, `general_ledger_accounts_code` INT, `general_ledger_accounts_name` INT, `is_debit` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_major_account_group`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_major_account_group` (`account_group_id` INT, `account_group_code` INT, `account_group_name` INT, `maj_acc_group_id` INT, `maj_acc_group_code` INT, `maj_acc_group_name` INT, `created_at` INT, `updated_at` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_obligation_request`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_obligation_request` (`obligation_request_id` INT, `fpp_id` INT, `fpp_code` INT, `fpp_name` INT, `funds_id` INT, `fund_code` INT, `fund_name` INT, `allotment_class_id` INT, `allotment_class_code` INT, `allotment_class_name` INT, `transaction_no` INT, `obligation_no` INT, `payee` INT, `explanation` INT, `reference_no` INT, `date_requested` INT, `status` INT, `remarks` INT, `created_at` INT, `created_by_id` INT, `created_by_first_name` INT, `created_by_middle_name` INT, `created_by_last_name` INT, `created_by_prefix` INT, `created_by_suffix` INT, `updated_at` INT, `updated_by_id` INT, `updated_by_first_name` INT, `updated_by_middle_name` INT, `updated_by_last_name` INT, `updated_by_prefix` INT, `updated_by_suffix` INT, `obligation_account_id` INT, `others_fpp_id` INT, `others_fpp_code` INT, `others_fpp_name` INT, `budget_appropriations_id` INT, `general_ledger_accounts_id` INT, `account_code` INT, `ledger_name` INT, `is_contra_account` INT, `allotment_release_id` INT, `aro_no` INT, `allotment_account_id` INT, `allotment_account_amount` INT, `year` INT, `continuing` INT, `amount` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_role_has_permissions`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_role_has_permissions` (`roles_id` INT, `permissions_id` INT, `role_name` INT, `permission_name` INT, `permission_office` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_signatories_has_document_references`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_signatories_has_document_references` (`signatories_id` INT, `signatories_prefix` INT, `signatories_first_name` INT, `signatories_middle_initial` INT, `signatories_last_name` INT, `signatories_suffix` INT, `signatories_title` INT, `signatories_created_at` INT, `signatories_updated_at` INT, `document_references_id` INT, `document_references_name` INT, `documents_id` INT, `documents_name` INT, `office` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_sub_major_account_group`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_sub_major_account_group` (`account_group_id` INT, `account_group_code` INT, `account_group_name` INT, `major_account_group_id` INT, `maj_acc_group_code` INT, `maj_acc_group_name` INT, `sub_maj_acc_group_id` INT, `sub_maj_acc_group_code` INT, `sub_maj_acc_group_name` INT, `created_at` INT, `updated_at` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_supplemental_appropriations`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_supplemental_appropriations` (`supplemental_appropriations_id` INT, `budget_appropriations_id` INT, `funds_id` INT, `fund_code` INT, `fund_name` INT, `function_program_project_id` INT, `fpp_code` INT, `fpp_name` INT, `others_fpp_id` INT, `others_fpp_code` INT, `others_fpp_name` INT, `allotment_classes_id` INT, `allotment_code` INT, `allotment_name` INT, `date_entry` INT, `appropriation_year` INT, `amount` INT, `continuing` INT, `remarks` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_users`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_users` (`id` INT, `roles_id` INT, `prefix` INT, `first_name` INT, `mid_initial` INT, `last_name` INT, `suffix` INT, `username` INT, `password` INT, `role_name` INT, `is_deleted` INT, `created_at` INT, `updated_at` INT, `is_super` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_document_references`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_document_references` (`document_references_id` INT, `document_references_name` INT, `documents_id` INT, `documents_name` INT, `office` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_function_classification_services`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_function_classification_services` (`id` INT, `service_name` INT, `functional_classifications_id` INT, `functional_classifications_sector_code` INT, `functional_classifications_sector_name` INT, `created_at` INT, `updated_at` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_function_program_project`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_function_program_project` (`id` INT, `fpp_code` INT, `fpp_name` INT, `functional_classification_services_id` INT, `service_name` INT, `is_special` INT, `created_at` INT, `updated_at` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_collecting_officers_has_job_orders`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_collecting_officers_has_job_orders` (`collecting_officers_id` INT, `collecting_officers_prefix` INT, `collecting_officers_firstname` INT, `collecting_officers_mid_initial` INT, `collecting_officers_last_name` INT, `collecting_officers_suffix` INT, `collecting_officers_job_title` INT, `collecting_officers_is_deleted` INT, `job_orders_id` INT, `job_orders_user_id` INT, `job_orders_prefix` INT, `job_orders_first_name` INT, `job_orders_mid_initial` INT, `job_orders_last_name` INT, `job_orders_suffix` INT, `job_orders_job_title` INT, `job_orders_is_deleted` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_bank_deposits`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_bank_deposits` (`id` INT, `bank_accounts_id` INT, `account_no` INT, `banks_id` INT, `bank_code` INT, `bank_name` INT, `funds_id` INT, `fund_code` INT, `fund_name` INT, `reference` INT, `date` INT, `amount` INT, `created_at` INT, `created_by` INT, `updated_at` INT, `updated_by` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_receipts`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_receipts` (`id` INT, `receipt_number_from` INT, `receipt_number_to` INT, `received_date` INT, `quantity` INT, `remarks` INT, `user_id` INT, `user` INT, `accountable_forms_id` INT, `acc_form_no` INT, `acc_form_desc` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_receipts_issued`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_receipts_issued` (`id` INT, `receipts_id` INT, `receipts_quantity` INT, `accountable_form_id` INT, `acc_form_no` INT, `acc_form_desc` INT, `accountable_forms` INT, `collecting_officer_id` INT, `collecting_officers_prefix` INT, `collecting_officers_first_name` INT, `collecting_officers_mid_initial` INT, `collecting_officers_last_name` INT, `collecting_officers_suffix` INT, `collecting_officers_job_title` INT, `co_users_id` INT, `job_orders_id` INT, `job_orders_prefix` INT, `job_orders_first_name` INT, `job_orders_mid_initial` INT, `job_orders_last_name` INT, `job_orders_suffix` INT, `job_orders_job_title` INT, `date_issued` INT, `receipt_issued_from` INT, `receipt_issued_to` INT, `last_issued` INT, `quantity` INT, `is_returned` INT, `returned_date` INT, `issued_by` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_rci`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_rci` (`id` INT, `cheques_id` INT, `cheque_no` INT, `cheque_date` INT, `amount` INT, `bank_accounts_id` INT, `bank_account_no` INT, `bank_id` INT, `bank_name` INT, `fund_id` INT, `fund_code` INT, `fund_name` INT, `dv_no` INT, `payee` INT, `nature_of_payment` INT, `obligation_no` INT, `date_entry` INT, `fpp_id` INT, `fpp_code` INT, `fpp_name` INT, `total_deductions` INT, `created_at` INT, `updated_at` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_payment_collections`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_payment_collections` (`id` INT, `co_id` INT, `co_first_name` INT, `co_mid_initial` INT, `co_last_name` INT, `co_prefix` INT, `co_suffix` INT, `co_job_title` INT, `jo_id` INT, `jo_first_name` INT, `jo_mid_initial` INT, `jo_last_name` INT, `jo_prefix` INT, `jo_suffix` INT, `jo_job_title` INT, `funds_id` INT, `acc_form_id` INT, `acc_form_no` INT, `acc_form_desc` INT, `payee` INT, `receipt_no` INT, `payment_date` INT, `amount` INT, `is_cancelled` INT, `created_at` INT, `created_by` INT, `updated_at` INT, `updated_by` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_rpt_payments`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_rpt_payments` (`rpt_payments_id` INT, `rpt_assessment_posts_id` INT, `taxpayer_tin` INT, `taxpayer_name` INT, `taxpayer_contact_info` INT, `taxpayer_address` INT, `rpt_payments_posted_at` INT, `rpt_payments_posted_by` INT, `payment_collections_id` INT, `payment_collections_collecting_officers_id` INT, `payment_collections_job_orders_id` INT, `payment_collections_funds_id` INT, `payment_collections_accountable_forms_id` INT, `payment_collections_payee` INT, `payment_collections_receipt_no` INT, `payment_collections_payment_date` INT, `payment_collections_amount` INT, `payment_collections_is_cancelled` INT, `payment_collections_created_at` INT, `payment_collections_created_by` INT, `payment_collections_updated_at` INT, `payment_collections_updated_by` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_rpt_tax_dues`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_rpt_tax_dues` (`rpt_tax_dues_id` INT, `rpt_assessment_posts_id` INT, `property_identifier` INT, `complete_arp_no` INT, `property_pin` INT, `taxpayer_tin` INT, `taxpayer_name` INT, `taxpayer_contact_info` INT, `taxpayer_address` INT, `barangay_name` INT, `municipality_name` INT, `province_name` INT, `property_kind` INT, `effectivity_quarterly` INT, `effectivity_year` INT, `assessed_value` INT, `is_taxable` INT, `is_cancelled` INT, `penalty_rate` INT, `penalty_frequency` INT, `basic_rate` INT, `sef_rate` INT, `year` INT, `posted_at` INT, `posted_by` INT, `rpt_payments_id` INT, `rpt_payments_posted_at` INT, `rpt_payments_posted_by` INT, `discount_rate` INT, `is_advance` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_rpt_property_assessments`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_rpt_property_assessments` (`rpt_assessment_posts_id` INT, `real_taxpayers_id` INT, `property_identifier` INT, `complete_arp_no` INT, `property_pin` INT, `taxpayer_tin` INT, `taxpayer_name` INT, `taxpayer_contact_info` INT, `taxpayer_address` INT, `street` INT, `barangay_name` INT, `municipality_name` INT, `province_name` INT, `property_kind` INT, `effectivity_quarterly` INT, `effectivity_year` INT, `other_improvements` INT, `assessed_value` INT, `area` INT, `lot_no` INT, `classification_code` INT, `classification_name` INT, `actual_use_code` INT, `actual_use_name` INT, `gr_year` INT, `is_taxable` INT, `is_cancelled` INT, `tax_dues_id` INT, `discount_rate` INT, `is_advance` INT, `penalty_rate` INT, `penalty_frequency` INT, `basic_rate` INT, `sef_rate` INT, `year` INT, `posted_at` INT, `posted_by` INT, `rpt_payments_id` INT, `rpt_payments_posted_at` INT, `rpt_payments_posted_by` INT, `payment_collections_id` INT, `payment_collections_collecting_officers_id` INT, `payment_collections_job_orders_id` INT, `payment_collections_funds_id` INT, `payment_collections_accountable_forms_id` INT, `payment_collections_payee` INT, `payment_collections_receipt_no` INT, `payment_collections_payment_date` INT, `payment_collections_amount` INT, `payment_collections_is_cancelled` INT, `payment_collections_created_at` INT, `payment_collections_created_by` INT, `payment_collections_updated_at` INT, `payment_collections_updated_by` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_taxpayers`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_taxpayers` (`taxpayers_id` INT, `representative_registry_id` INT, `representative_name` INT, `taxpayers_tin` INT, `taxpayers_name` INT, `taxpayers_address` INT, `taxpayers_municipality` INT, `taxpayers_province` INT, `taxpayer_type_id` INT, `taxpayer_type_code` INT, `taxpayer_type` INT, `taxpayers_contact_info` INT, `is_active` INT, `created_at` INT, `updated_at` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_barangays`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_barangays` (`barangays_id` INT, `barangays_code` INT, `barangays_name` INT, `municipalities_id` INT, `municipalities_code` INT, `municipalities_name` INT, `provinces_id` INT, `provinces_code` INT, `provinces_name` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_municipalities`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_municipalities` (`municipalities_id` INT, `municipalities_code` INT, `municipalities_name` INT, `provinces_id` INT, `provinces_code` INT, `provinces_name` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_business_categories_has_add_on_charges`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_business_categories_has_add_on_charges` (`business_categories_id` INT, `business_categories_code` INT, `business_categories_description` INT, `business_categories_is_line_of_business` INT, `business_categories_ordinance_ref_no` INT, `business_add_on_charges_id` INT, `business_add_on_charges_code` INT, `business_add_on_charges_description` INT, `business_add_on_charges_is_applied_to_each_business` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_bank_accounts`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_bank_accounts` (`id` INT, `account_no` INT, `banks_id` INT, `bank_code` INT, `bank_name` INT, `bank_branch` INT, `created_at` INT, `updated_at` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_released_cheques`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_released_cheques` (`rci_id` INT, `cheques_id` INT, `bank_accounts_id` INT, `cheque_no` INT, `cheque_date` INT, `cheque_amount` INT, `funds_id` INT, `fund_code` INT, `fund_name` INT, `function_program_project_id` INT, `dv_no` INT, `payee` INT, `nature_of_payment` INT, `released_cheques_id` INT, `date_released` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_subsidiary_ledger_accounts`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_subsidiary_ledger_accounts` (`subsidiary_ledger_accounts_id` INT, `funds_id` INT, `fund_code` INT, `fund_name` INT, `general_ledger_accounts_id` INT, `ledger_code` INT, `ledger_name` INT, `sub_code` INT, `sub_name` INT, `address` INT, `contact_person` INT, `contact` INT, `created_at` INT, `updated_at` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_real_properties`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_real_properties` (`real_property_id` INT, `street` INT, `complete_arp_no` INT, `property_pin` INT, `property_kind` INT, `effectivity_quarter` INT, `effectivity_year` INT, `other_improvements` INT, `assessed_value` INT, `area` INT, `lot_no` INT, `gr_year` INT, `is_taxable` INT, `is_cancelled` INT, `real_property_created_at` INT, `real_property_updated_at` INT, `taxpayers_id` INT, `taxpayer_tin` INT, `taxpayer_name` INT, `taxpayer_address` INT, `taxpayer_municipality` INT, `taxpayer_province` INT, `taxpayer_contact_info` INT, `taxpayer_is_active` INT, `taxpayer_type_id` INT, `taxpayer_type_code` INT, `taxpayer_type_name` INT, `representative_id` INT, `representative_name` INT, `classification_codes_id` INT, `classification_code` INT, `classification_name` INT, `classification_is_special` INT, `actual_use_codes_id` INT, `actual_use_code` INT, `actual_use_name` INT, `actual_use_is_government` INT, `barangays_id` INT, `barangay_code` INT, `barangay_name` INT, `municipality_id` INT, `municipality_code` INT, `municipality_name` INT, `province_id` INT, `province_code` INT, `province_name` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_rcd`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_rcd` (`id` INT, `report_no` INT, `date` INT, `fund_id` INT, `fund_code` INT, `fund_name` INT, `created_by_id` INT, `prefix` INT, `first_name` INT, `mid_initial` INT, `last_name` INT, `suffix` INT, `created_at` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_delinquent_notice`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_delinquent_notice` (`delinquent_notice_id` INT, `notice_type` INT, `notice_date` INT, `real_properties_id` INT, `complete_arp_no` INT, `property_kind` INT, `taxpayers_id` INT, `assessed_value` INT, `barangay_name` INT, `municipalities_name` INT, `provinces_name` INT, `taxpayers_name` INT, `created_at` INT, `created_by` INT, `updated_at` INT, `updated_by` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_rpt_levy`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_rpt_levy` (`rpt_levy_id` INT, `real_properties_id` INT, `complete_arp_no` INT, `property_kind` INT, `assessed_value` INT, `barangay_name` INT, `municipalities_name` INT, `provinces_name` INT, `taxpayers_name` INT, `date_issued` INT, `created_at` INT, `created_by` INT, `updated_at` INT, `updated_by` INT, `is_cancelled` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_rpt_auction`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_rpt_auction` (`auction_id` INT, `start_date` INT, `end_date` INT, `location` INT, `rpt_auction_id` INT, `real_properties_id` INT, `street` INT, `complete_arp_no` INT, `property_pin` INT, `property_kind` INT, `assessed_value` INT, `taxpayers_id` INT, `taxpayer_tin` INT, `taxpayer_name` INT, `taxpayer_address` INT, `taxpayer_municipality` INT, `taxpayer_province` INT, `taxpayer_contact_info` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_bidders`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_bidders` (`id` INT, `taxpayers_id` INT, `auction_id` INT, `payment_collections_id` INT, `bidder_no` INT, `rpt_auction_id` INT, `representative_registry_id` INT, `taxpayer_type_id` INT, `tin` INT, `name` INT, `address` INT, `municipality` INT, `province` INT, `contact_info` INT, `collecting_officers_id` INT, `accountable_forms_id` INT, `payee` INT, `receipt_no` INT, `payment_date` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_bid`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_bid` (`id` INT, `rpt_auction_id` INT, `ordinance_no` INT, `date` INT, `complete_arp_no` INT, `assessed_value` INT, `bidders_id` INT, `bid_amount` INT, `payment_collections_id` INT, `receipt_no` INT, `taxpayers_id` INT, `bidder_no` INT, `name` INT, `address` INT, `municipality` INT, `province` INT, `contact_info` INT, `real_properties_id` INT, `auction_id` INT, `start_date` INT, `end_date` INT, `location` INT);

-- -----------------------------------------------------
-- Placeholder table for view `lfs_db`.`view_cash_tickets_issued`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `lfs_db`.`view_cash_tickets_issued` (`id` INT, `cash_tickets_id` INT, `cash_tickets_desc` INT, `cash_tickets_quantity` INT, `co_id` INT, `co_prefix` INT, `co_first_name` INT, `co_mid_initial` INT, `co_last_name` INT, `co_suffix` INT, `co_job_title` INT, `co_users_id` INT, `jo_id` INT, `jo_prefix` INT, `jo_first_name` INT, `jo_mid_initial` INT, `jo_last_name` INT, `jo_suffix` INT, `jo_job_title` INT, `date_issued` INT, `quantity` INT, `issued_by` INT);

-- -----------------------------------------------------
-- View `lfs_db`.`view_accountable_forms`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_accountable_forms`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `view_accountable_forms` AS
    SELECT 
        `a`.`id` AS `id`,
        `a`.`acc_form_no` AS `acc_form_no`,
        `a`.`acc_form_desc` AS `acc_form_desc`,
        `f`.`amount` AS `amount`
    FROM
        (`accountable_forms` `a`
        LEFT JOIN `face_values` `f` ON ((`a`.`id` = `f`.`accountable_forms_id`)))
    ORDER BY `a`.`acc_form_no`;

-- -----------------------------------------------------
-- View `lfs_db`.`view_allotment_release`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_allotment_release`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `view_allotment_release` AS
    SELECT 
        `allotment_release`.`id` AS `allotment_release_id`,
        `allotment_account`.`id` AS `allotment_account_id`,
        `allotment_release`.`aro_no` AS `aro_no`,
        CONCAT(`allotment_release`.`aro_no`,
                '-',
                YEAR(`allotment_release`.`date_issued`)) AS `full_aro_no`,
        `allotment_release`.`purpose` AS `purpose`,
        `allotment_release`.`date_issued` AS `date_issued`,
        `allotment_release`.`created_at` AS `allotment_release_created_at`,
        `allotment_release`.`updated_at` AS `allotment_release_updated_at`,
        `budget_appropriations`.`id` AS `budget_appropriations_id`,
        `funds`.`id` AS `funds_id`,
        `funds`.`fund_code` AS `fund_code`,
        `funds`.`fund_name` AS `fund_name`,
        `function_program_project`.`id` AS `function_program_project_id`,
        `function_program_project`.`fpp_code` AS `fpp_code`,
        `function_program_project`.`fpp_name` AS `fpp_name`,
        `function_program_project`.`is_special` AS `is_special`,
        `others_fpp`.`id` AS `others_fpp_id`,
        `others_fpp`.`others_fpp_code` AS `others_fpp_code`,
        `others_fpp`.`name` AS `others_fpp_name`,
        `allotment_classes`.`id` AS `allotment_classes_id`,
        `allotment_classes`.`allotment_code` AS `allotment_code`,
        `allotment_classes`.`allotment_name` AS `allotment_name`,
        `general_ledger_accounts`.`id` AS `general_ledger_accounts_id`,
        CONCAT(`account_group`.`account_group_code`,
                '-',
                `major_account_group`.`maj_acc_group_code`,
                '-',
                `sub_major_account_group`.`sub_maj_acc_group_code`,
                '-',
                `general_ledger_accounts`.`ledger_code`) AS `account_code`,
        `general_ledger_accounts`.`ledger_name` AS `ledger_name`,
        `budget_appropriations`.`date_entry` AS `date_entry`,
        `budget_appropriations`.`year` AS `year`,
        `budget_appropriations`.`continuing` AS `continuing`,
        `budget_appropriations`.`remarks` AS `remarks`,
        `allotment_account`.`amount` AS `amount`
    FROM
        ((((((((((`allotment_release`
        JOIN `allotment_account` ON ((`allotment_account`.`allotment_release_id` = `allotment_release`.`id`)))
        JOIN `budget_appropriations` ON ((`budget_appropriations`.`id` = `allotment_account`.`budget_appropriations_id`)))
        JOIN `funds` ON ((`funds`.`id` = `budget_appropriations`.`funds_id`)))
        JOIN `function_program_project` ON ((`function_program_project`.`id` = `budget_appropriations`.`function_program_project_id`)))
        LEFT JOIN `others_fpp` ON ((`others_fpp`.`id` <=> `budget_appropriations`.`others_fpp_id`)))
        JOIN `allotment_classes` ON ((`allotment_classes`.`id` = `budget_appropriations`.`allotment_classes_id`)))
        JOIN `general_ledger_accounts` ON ((`general_ledger_accounts`.`id` = `budget_appropriations`.`general_ledger_accounts_id`)))
        JOIN `sub_major_account_group` ON ((`sub_major_account_group`.`id` = `general_ledger_accounts`.`sub_major_account_group_id`)))
        JOIN `major_account_group` ON ((`major_account_group`.`id` = `sub_major_account_group`.`major_account_group_id`)))
        JOIN `account_group` ON ((`account_group`.`id` = `major_account_group`.`account_group_id`)));

-- -----------------------------------------------------
-- View `lfs_db`.`view_beginning_balances`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_beginning_balances`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `view_beginning_balances` AS
    SELECT 
        `a`.`id` AS `beginning_balances_id`,
        `a`.`funds_id` AS `funds_id`,
        `b`.`fund_code` AS `fund_code`,
        `b`.`fund_name` AS `fund_name`,
        `a`.`general_ledger_accounts_id` AS `general_ledger_accounts_id`,
        `c`.`ledger_code` AS `general_ledger_accounts_code`,
        `c`.`ledger_name` AS `general_ledger_accounts_name`,
        `d`.`id` AS `sub_maj_acc_group_id`,
        `d`.`sub_maj_acc_group_code` AS `sub_maj_acc_group_code`,
        `d`.`sub_maj_acc_group_name` AS `sub_maj_acc_group_name`,
        `e`.`id` AS `maj_acc_group_id`,
        `e`.`maj_acc_group_code` AS `maj_acc_group_code`,
        `e`.`maj_acc_group_name` AS `maj_acc_group_name`,
        `f`.`id` AS `account_group_id`,
        `f`.`account_group_code` AS `account_group_code`,
        `f`.`account_group_name` AS `account_group_name`,
        `a`.`subsidiary_ledger_accounts_id` AS `subsidiary_ledger_accounts_id`,
        `g`.`sub_code` AS `subsidiary_ledger_accounts_code`,
        `g`.`sub_name` AS `subsidiary_ledger_accounts_name`,
        `a`.`date_entry` AS `date_entry`,
        `a`.`is_debit` AS `is_debit`,
        `a`.`amount` AS `amount`,
        `a`.`created_at` AS `created_at`,
        `a`.`updated_at` AS `updated_at`
    FROM
        ((((((`beginning_balances` `a`
        JOIN `funds` `b` ON ((`b`.`id` = `a`.`funds_id`)))
        JOIN `general_ledger_accounts` `c` ON ((`c`.`id` = `a`.`general_ledger_accounts_id`)))
        JOIN `sub_major_account_group` `d` ON ((`d`.`id` = `c`.`sub_major_account_group_id`)))
        JOIN `major_account_group` `e` ON ((`e`.`id` = `d`.`major_account_group_id`)))
        JOIN `account_group` `f` ON ((`f`.`id` = `e`.`account_group_id`)))
        LEFT JOIN `subsidiary_ledger_accounts` `g` ON ((`g`.`id` = `a`.`subsidiary_ledger_accounts_id`)));

-- -----------------------------------------------------
-- View `lfs_db`.`view_budget_appropriations`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_budget_appropriations`;
USE `lfs_db`;
CREATE  OR REPLACE 
	ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `view_budget_appropriations` AS
    SELECT 
        `a`.`id` AS `id`,
        `b`.`id` AS `funds_id`,
        `b`.`fund_code` AS `fund_code`,
        `b`.`fund_name` AS `fund_name`,
        `c`.`id` AS `fpp_id`,
        `c`.`fpp_code` AS `fpp_code`,
        `c`.`fpp_name` AS `fpp_name`,
        `c`.`is_special` AS `fpp_is_special`,
        `j`.`id` AS `functional_classification_service_id`,
        `j`.`service_name` AS `functional_classification_service_name`,
        `k`.`id` AS `functional_classification_id`,
        `k`.`sector_code` AS `functional_classification_sector_code`,
        `k`.`sector_name` AS `functional_classification_sector_name`,
        `d`.`id` AS `others_fpp_id`,
        `d`.`others_fpp_code` AS `others_fpp_code`,
        `d`.`name` AS `others_fpp_name`,
        `e`.`id` AS `allotment_class_id`,
        `e`.`allotment_code` AS `allotment_class_code`,
        `e`.`allotment_name` AS `allotment_class_name`,
        `f`.`id` AS `general_ledger_accounts_id`,
        `f`.`ledger_code` AS `general_ledger_accounts_code`,
        `f`.`ledger_name` AS `general_ledger_accounts_name`,
        CONCAT(`i`.`account_group_code`,
                '-',
                `h`.`maj_acc_group_code`,
                '-',
                `g`.`sub_maj_acc_group_code`,
                '-',
                `f`.`ledger_code`) AS `account_code`,
        `a`.`date_entry` AS `date_entry`,
        `a`.`year` AS `year`,
        `a`.`amount` AS `amount`,
        `a`.`continuing` AS `continuing`,
        `a`.`remarks` AS `remarks`,
        `a`.`created_at` AS `created_at`,
        `a`.`updated_at` AS `updated_at`
    FROM
        ((((((((((`budget_appropriations` `a`
        JOIN `funds` `b` ON ((`a`.`funds_id` = `b`.`id`)))
        JOIN `function_program_project` `c` ON ((`a`.`function_program_project_id` = `c`.`id`)))
        LEFT JOIN `others_fpp` `d` ON ((`a`.`others_fpp_id` <=> `d`.`id`)))
        JOIN `allotment_classes` `e` ON ((`a`.`allotment_classes_id` = `e`.`id`)))
        JOIN `general_ledger_accounts` `f` ON ((`f`.`id` = `a`.`general_ledger_accounts_id`)))
        JOIN `sub_major_account_group` `g` ON ((`g`.`id` = `f`.`sub_major_account_group_id`)))
        JOIN `major_account_group` `h` ON ((`h`.`id` = `g`.`major_account_group_id`)))
        JOIN `account_group` `i` ON ((`i`.`id` = `h`.`account_group_id`)))
        JOIN `functional_classification_services` `j` ON ((`c`.`functional_classification_services_id` = `j`.`id`)))
        JOIN `functional_classifications` `k` ON ((`j`.`functional_classifications_id` = `k`.`id`)));

-- -----------------------------------------------------
-- View `lfs_db`.`view_cash_disbursement_journal`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_cash_disbursement_journal`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `view_cash_disbursement_journal` AS
    SELECT 
        `c`.`id` AS `id`,
        `c`.`funds_id` AS `funds_id`,
        `c`.`journals_id` AS `journals_id`,
        `c`.`jev_no` AS `jev_no`,
        `c`.`date_entry` AS `date_entry`,
        `c`.`ref_no` AS `ref_no`,
        `c`.`payee` AS `payee`,
        `c`.`explanation` AS `explanation`,
        `c`.`is_approved` AS `is_approved`,
        `c`.`created_at` AS `created_at`,
        `c`.`created_by` AS `created_by`,
        `c`.`updated_at` AS `updated_at`,
        `c`.`updated_by` AS `updated_by`,
        `a`.`id` AS `cash_disbursements_journal_id`,
        `a`.`jev_id` AS `jev_id`,
        `a`.`disbursing_officers_id` AS `disbursing_officers_id`,
        `a`.`dv_no` AS `dv_no`,
        `a`.`date_paid` AS `date_paid`,
        `b`.`first_name` AS `first_name`,
        `b`.`mid_initial` AS `mid_initial`,
        `b`.`last_name` AS `last_name`,
        CONCAT(`b`.`first_name`,
                ' ',
                `b`.`mid_initial`,
                ' ',
                `b`.`last_name`) AS `full_name`,
        `b`.`job_title` AS `job_title`
    FROM
        ((`cash_disbursement_journal` `a`
        JOIN `disbursing_officers` `b` ON ((`a`.`disbursing_officers_id` = `b`.`id`)))
        JOIN `jev` `c` ON ((`a`.`jev_id` = `c`.`id`)));

-- -----------------------------------------------------
-- View `lfs_db`.`view_cash_receipts_journal`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_cash_receipts_journal`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `view_cash_receipts_journal` AS
    SELECT 
        `c`.`id` AS `id`,
        `c`.`funds_id` AS `funds_id`,
        `c`.`journals_id` AS `journals_id`,
        `c`.`jev_no` AS `jev_no`,
        `c`.`date_entry` AS `date_entry`,
        `c`.`ref_no` AS `ref_no`,
        `c`.`payee` AS `payee`,
        `c`.`explanation` AS `explanation`,
        `c`.`is_approved` AS `is_approved`,
        `c`.`created_at` AS `created_at`,
        `c`.`created_by` AS `created_by`,
        `c`.`updated_at` AS `updated_at`,
        `c`.`updated_by` AS `updated_by`,
        `a`.`id` AS `cash_receipts_journal_id`,
        `a`.`jev_id` AS `jev_id`,
        `a`.`collecting_officers_id` AS `collecting_officers_id`,
        `a`.`rcd_no` AS `rcd_no`,
        `a`.`or_no` AS `or_no`,
        `a`.`or_date` AS `or_date`,
        `b`.`first_name` AS `first_name`,
        `b`.`mid_initial` AS `mid_initial`,
        `b`.`last_name` AS `last_name`,
        CONCAT(`b`.`first_name`,
                ' ',
                `b`.`mid_initial`,
                ' ',
                `b`.`last_name`) AS `full_name`,
        `b`.`job_title` AS `job_title`
    FROM
        ((`cash_receipts_journal` `a`
        JOIN `collecting_officers` `b` ON ((`a`.`collecting_officers_id` = `b`.`id`)))
        JOIN `jev` `c` ON ((`a`.`jev_id` = `c`.`id`)));

-- -----------------------------------------------------
-- View `lfs_db`.`view_check_disbursement_journal`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_check_disbursement_journal`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `view_check_disbursement_journal` AS
    SELECT 
        `a`.`id` AS `id`,
        `a`.`funds_id` AS `funds_id`,
        `a`.`journals_id` AS `journals_id`,
        `a`.`jev_no` AS `jev_no`,
        `a`.`date_entry` AS `date_entry`,
        `a`.`ref_no` AS `ref_no`,
        `a`.`payee` AS `payee`,
        `a`.`explanation` AS `explanation`,
        `a`.`is_approved` AS `is_approved`,
        `a`.`created_at` AS `created_at`,
        `a`.`created_by` AS `created_by`,
        `a`.`updated_at` AS `updated_at`,
        `a`.`updated_by` AS `updated_by`,
        `b`.`id` AS `check_disbursement_journal_id`,
        `b`.`jev_id` AS `jev_id`,
        `b`.`check_date` AS `check_date`,
        `b`.`check_no` AS `check_no`,
        `b`.`dv_no` AS `dv_no`,
        `b`.`rci_no` AS `rci_no`
    FROM
        (`jev` `a`
        JOIN `check_disbursements_journal` `b` ON ((`a`.`id` = `b`.`jev_id`)));

-- -----------------------------------------------------
-- View `lfs_db`.`view_general_journal`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_general_journal`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `view_general_journal` AS
    SELECT 
        `b`.`id` AS `id`,
        `b`.`funds_id` AS `funds_id`,
        `b`.`journals_id` AS `journals_id`,
        `b`.`jev_no` AS `jev_no`,
        `b`.`date_entry` AS `date_entry`,
        `b`.`ref_no` AS `ref_no`,
        `b`.`payee` AS `payee`,
        `b`.`explanation` AS `explanation`,
        `b`.`is_approved` AS `is_approved`,
        `b`.`created_at` AS `created_at`,
        `b`.`created_by` AS `created_by`,
        `b`.`updated_at` AS `updated_at`,
        `b`.`updated_by` AS `updated_by`,
        `a`.`id` AS `general_journal_id`,
        `a`.`jev_id` AS `jev_id`,
        `a`.`dv_no` AS `dv_no`,
        `a`.`check_no` AS `check_no`,
        `a`.`or_no` AS `or_no`
    FROM
        (`general_journal` `a`
        JOIN `jev` `b` ON ((`a`.`jev_id` = `b`.`id`)));

-- -----------------------------------------------------
-- View `lfs_db`.`view_general_ledger_accounts`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_general_ledger_accounts`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `view_general_ledger_accounts` AS
    SELECT 
        `b`.`account_group_id` AS `account_group_id`,
        `a`.`account_group_code` AS `account_group_code`,
        `a`.`account_group_name` AS `account_group_name`,
        `c`.`major_account_group_id` AS `major_account_group_id`,
        `b`.`maj_acc_group_code` AS `maj_acc_group_code`,
        `b`.`maj_acc_group_name` AS `maj_acc_group_name`,
        `c`.`sub_maj_acc_group_code` AS `sub_maj_acc_group_code`,
        `c`.`sub_maj_acc_group_name` AS `sub_maj_acc_group_name`,
        `d`.`sub_major_account_group_id` AS `sub_major_account_group_id`,
        `d`.`id` AS `general_ledger_accounts_id`,
        CONCAT(`a`.`account_group_code`,
                '-',
                `b`.`maj_acc_group_code`,
                '-',
                `c`.`sub_maj_acc_group_code`,
                '-',
                `d`.`ledger_code`) AS `account_code`,
        `d`.`ledger_code` AS `ledger_code`,
        `d`.`ledger_name` AS `ledger_name`,
        `d`.`is_contra_account` AS `is_contra_account`,
        `d`.`created_at` AS `created_at`,
        `d`.`updated_at` AS `updated_at`
    FROM
        (((`account_group` `a`
        JOIN `major_account_group` `b` ON ((`a`.`id` = `b`.`account_group_id`)))
        JOIN `sub_major_account_group` `c` ON ((`b`.`id` = `c`.`major_account_group_id`)))
        JOIN `general_ledger_accounts` `d` ON ((`c`.`id` = `d`.`sub_major_account_group_id`)));

-- -----------------------------------------------------
-- View `lfs_db`.`view_jev`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_jev`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `lfs_db`.`view_jev` AS
    SELECT 
        `a`.`id` AS `id`,
        `a`.`funds_id` AS `funds_id`,
        `b`.`fund_code` AS `fund_code`,
        `b`.`fund_name` AS `fund_name`,
        `a`.`journals_id` AS `journals_id`,
        `c`.`journal_name` AS `journal_name`,
        `c`.`is_special` AS `is_special`,
		`a`.`transaction_no` AS `transaction_no`,
        `a`.`jev_no` AS `jev_no`,
        IF((`a`.`jev_no` <> ''),
            CONCAT_WS('-',
                    `b`.`fund_code`,
                    YEAR(`a`.`date_entry`),
                    CONVERT( DATE_FORMAT(`a`.`date_entry`, '%m') USING UTF8MB3),
                    `a`.`jev_no`),
            NULL) AS `full_jev_no`,
        `a`.`date_entry` AS `date_entry`,
        `a`.`ref_no` AS `ref_no`,
        `a`.`payee` AS `payee`,
        `a`.`explanation` AS `explanation`,
        `a`.`remarks` AS `remarks`,
		`a`.`status` AS `status`,
        `a`.`is_edited` AS `is_edited`,
        `a`.`created_at` AS `created_at`,
        `a`.`created_by` AS `created_by`,
        CONCAT(`d`.`first_name`,
                ' ',
                `d`.`mid_initial`,
                ' ',
                `d`.`last_name`) AS `created_by_name`,
        `a`.`updated_at` AS `updated_at`,
        `a`.`updated_by` AS `updated_by`,
        CONCAT(`e`.`first_name`,
                ' ',
                `e`.`mid_initial`,
                ' ',
                `e`.`last_name`) AS `updated_by_name`
    FROM
        ((((`lfs_db`.`jev` `a`
        JOIN `lfs_db`.`funds` `b` ON ((`a`.`funds_id` = `b`.`id`)))
        JOIN `lfs_db`.`journals` `c` ON ((`a`.`journals_id` = `c`.`id`)))
        JOIN `lfs_db`.`users` `d` ON ((`a`.`created_by` = `d`.`id`)))
        LEFT JOIN `lfs_db`.`users` `e` ON ((`a`.`updated_by` = `e`.`id`)));

-- -----------------------------------------------------
-- View `lfs_db`.`view_jev_accounts`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_jev_accounts`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `view_jev_accounts` AS
    SELECT 
        `jev_accounts`.`id` AS `id`,
        `jev_accounts`.`jev_id` AS `jev_id`,
        `jev`.`funds_id` AS `funds_id`,
        `funds`.`fund_code` AS `fund_code`,
        `funds`.`fund_name` AS `fund_name`,
        `jev`.`journals_id` AS `journals_id`,
        `journals`.`journal_name` AS `journal_name`,
        `journals`.`is_special` AS `is_special`,
        `jev`.`jev_no` AS `jev_no`,
        IF((`jev`.`jev_no` <> ''),
            CONCAT_WS('-',
                    `funds`.`fund_code`,
                    YEAR(`jev`.`date_entry`),
                    CONVERT( DATE_FORMAT(`jev`.`date_entry`, '%m') USING UTF8MB3),
                    `jev`.`jev_no`),
            NULL) AS `full_jev_no`,
        `jev`.`date_entry` AS `date_entry`,
        `jev`.`explanation` AS `explanation`,
        `jev`.`is_approved` AS `is_approved`,
        `jev`.`is_disapproved` AS `is_disapproved`,
        `jev`.`is_cancelled` AS `is_cancelled`,
        `jev_accounts`.`function_program_project_id` AS `fpp_id`,
        `function_program_project`.`fpp_code` AS `fpp_code`,
        `function_program_project`.`fpp_name` AS `fpp_name`,
        `jev_accounts`.`general_ledger_accounts_id` AS `general_ledger_accounts_id`,
        CONCAT(`account_group`.`account_group_code`,
                '-',
                `major_account_group`.`maj_acc_group_code`,
                '-',
                `sub_major_account_group`.`sub_maj_acc_group_code`,
                '-',
                `general_ledger_accounts`.`ledger_code`) AS `account_code`,
        `general_ledger_accounts`.`ledger_code` AS `general_ledger_accounts_code`,
        `general_ledger_accounts`.`ledger_name` AS `general_ledger_accounts_name`,
        `general_ledger_accounts`.`is_contra_account` AS `general_ledger_accounts_is_contra_account`,
        `sub_major_account_group`.`id` AS `sub_maj_acc_group_id`,
        `sub_major_account_group`.`sub_maj_acc_group_code` AS `sub_maj_acc_group_code`,
        `sub_major_account_group`.`sub_maj_acc_group_name` AS `sub_maj_acc_group_name`,
        `major_account_group`.`id` AS `maj_acc_group_id`,
        `major_account_group`.`maj_acc_group_code` AS `maj_acc_group_code`,
        `major_account_group`.`maj_acc_group_name` AS `maj_acc_group_name`,
        `account_group`.`id` AS `account_group_id`,
        `account_group`.`account_group_code` AS `account_group_code`,
        `account_group`.`account_group_name` AS `account_group_name`,
        `jev_accounts`.`subsidiary_ledger_accounts_id` AS `subsidiary_ledger_accounts_id`,
        `subsidiary_ledger_accounts`.`sub_code` AS `subsidiary_ledger_accounts_code`,
        `subsidiary_ledger_accounts`.`sub_name` AS `subsidiary_ledger_accounts_name`,
        `jev_accounts`.`obligation_no` AS `obligation_no`,
        `jev_accounts`.`is_deposit` AS `is_deposit`,
        `jev_accounts`.`is_debit` AS `is_debit`,
        `jev_accounts`.`amount` AS `amount`
    FROM
        (((((((((`jev_accounts`
        LEFT JOIN `function_program_project` ON ((`jev_accounts`.`function_program_project_id` = `function_program_project`.`id`)))
        JOIN `general_ledger_accounts` ON ((`general_ledger_accounts`.`id` = `jev_accounts`.`general_ledger_accounts_id`)))
        JOIN `sub_major_account_group` ON ((`sub_major_account_group`.`id` = `general_ledger_accounts`.`sub_major_account_group_id`)))
        JOIN `major_account_group` ON ((`major_account_group`.`id` = `sub_major_account_group`.`major_account_group_id`)))
        JOIN `account_group` ON ((`account_group`.`id` = `major_account_group`.`account_group_id`)))
        LEFT JOIN `subsidiary_ledger_accounts` ON ((`subsidiary_ledger_accounts`.`id` = `jev_accounts`.`subsidiary_ledger_accounts_id`)))
        JOIN `jev` ON ((`jev`.`id` = `jev_accounts`.`jev_id`)))
        JOIN `funds` ON ((`funds`.`id` = `jev`.`funds_id`)))
        JOIN `journals` ON ((`journals`.`id` = `jev`.`journals_id`)));

-- -----------------------------------------------------
-- View `lfs_db`.`view_journals_default_accounts`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_journals_default_accounts`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `view_journals_default_accounts` AS
    SELECT 
        `a`.`id` AS `id`,
        `a`.`journals_id` AS `journals_id`,
        `a`.`funds_id` AS `funds_id`,
        `a`.`general_ledger_accounts_id` AS `general_ledger_accounts_id`,
        CONCAT(`f`.`account_group_code`,
                '-',
                `e`.`maj_acc_group_code`,
                '-',
                `d`.`sub_maj_acc_group_code`,
                '-',
                `c`.`ledger_code`) AS `account_code`,
        `c`.`ledger_code` AS `general_ledger_accounts_code`,
        `c`.`ledger_name` AS `general_ledger_accounts_name`,
        `a`.`is_debit` AS `is_debit`
    FROM
        (((((`journals_default_accounts` `a`
        JOIN `journals` `b` ON ((`b`.`id` = `a`.`journals_id`)))
        JOIN `general_ledger_accounts` `c` ON ((`c`.`id` = `a`.`general_ledger_accounts_id`)))
        JOIN `sub_major_account_group` `d` ON ((`d`.`id` = `c`.`sub_major_account_group_id`)))
        JOIN `major_account_group` `e` ON ((`e`.`id` = `d`.`major_account_group_id`)))
        JOIN `account_group` `f` ON ((`f`.`id` = `e`.`account_group_id`)));

-- -----------------------------------------------------
-- View `lfs_db`.`view_major_account_group`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_major_account_group`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `view_major_account_group` AS
    SELECT 
        `b`.`account_group_id` AS `account_group_id`,
        `a`.`account_group_code` AS `account_group_code`,
        `a`.`account_group_name` AS `account_group_name`,
        `b`.`id` AS `maj_acc_group_id`,
        `b`.`maj_acc_group_code` AS `maj_acc_group_code`,
        `b`.`maj_acc_group_name` AS `maj_acc_group_name`,
        `b`.`created_at` AS `created_at`,
        `b`.`updated_at` AS `updated_at`
    FROM
        (`account_group` `a`
        JOIN `major_account_group` `b` ON ((`a`.`id` = `b`.`account_group_id`)));

-- -----------------------------------------------------
-- View `lfs_db`.`view_obligation_request`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_obligation_request`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `view_obligation_request` AS
    SELECT 
        `obligation_request`.`id` AS `obligation_request_id`,
        `function_program_project`.`id` AS `fpp_id`,
        `function_program_project`.`fpp_code` AS `fpp_code`,
        `function_program_project`.`fpp_name` AS `fpp_name`,
        `funds`.`id` AS `funds_id`,
        `funds`.`fund_code` AS `fund_code`,
        `funds`.`fund_name` AS `fund_name`,
        `allotment_classes`.`id` AS `allotment_class_id`,
        `allotment_classes`.`allotment_code` AS `allotment_class_code`,
        `allotment_classes`.`allotment_name` AS `allotment_class_name`,
        `obligation_request`.`transaction_no` AS `transaction_no`,
        `obligation_request`.`obligation_no` AS `obligation_no`,
        `obligation_request`.`payee` AS `payee`,
        `obligation_request`.`explanation` AS `explanation`,
        `obligation_request`.`reference_no` AS `reference_no`,
        `obligation_request`.`date_requested` AS `date_requested`,
		`obligation_request`.`status` AS `status`,
        `obligation_request`.`remarks` AS `remarks`,
        `obligation_request`.`created_at` AS `created_at`,
        `obligation_request`.`created_by` AS `created_by_id`,
        `created_by`.`first_name` AS `created_by_first_name`,
        `created_by`.`mid_initial` AS `created_by_middle_name`,
        `created_by`.`last_name` AS `created_by_last_name`,
        `created_by`.`prefix` AS `created_by_prefix`,
        `created_by`.`suffix` AS `created_by_suffix`,
        `obligation_request`.`updated_at` AS `updated_at`,
        `obligation_request`.`updated_by` AS `updated_by_id`,
        `updated_by`.`first_name` AS `updated_by_first_name`,
        `updated_by`.`mid_initial` AS `updated_by_middle_name`,
        `updated_by`.`last_name` AS `updated_by_last_name`,
        `updated_by`.`prefix` AS `updated_by_prefix`,
        `updated_by`.`suffix` AS `updated_by_suffix`,
        `obligation_account`.`id` AS `obligation_account_id`,
        `others_fpp`.`id` AS `others_fpp_id`,
        `others_fpp`.`others_fpp_code` AS `others_fpp_code`,
        `others_fpp`.`name` AS `others_fpp_name`,
        `budget_appropriations`.`id` AS `budget_appropriations_id`,
        `general_ledger_accounts`.`id` AS `general_ledger_accounts_id`,
        CONCAT(`account_group`.`account_group_code`,
                '-',
                `major_account_group`.`maj_acc_group_code`,
                '-',
                `sub_major_account_group`.`sub_maj_acc_group_code`,
                '-',
                `general_ledger_accounts`.`ledger_code`) AS `account_code`,
        `general_ledger_accounts`.`ledger_name` AS `ledger_name`,
        `general_ledger_accounts`.`is_contra_account` AS `is_contra_account`,
        `allotment_release`.`id` AS `allotment_release_id`,
        `allotment_release`.`aro_no` AS `aro_no`,
        `allotment_account`.`id` AS `allotment_account_id`,
        `allotment_account`.`amount` AS `allotment_account_amount`,
        `budget_appropriations`.`year` AS `year`,
        `budget_appropriations`.`continuing` AS `continuing`,
        `obligation_account`.`amount` AS `amount`
    FROM
        ((((((((((((((`obligation_request`
        JOIN `funds` ON ((`funds`.`id` = `obligation_request`.`funds_id`)))
        JOIN `function_program_project` ON ((`function_program_project`.`id` = `obligation_request`.`function_program_project_id`)))
        JOIN `allotment_classes` ON ((`allotment_classes`.`id` = `obligation_request`.`allotment_classes_id`)))
        JOIN `obligation_account` ON ((`obligation_account`.`obligation_request_id` = `obligation_request`.`id`)))
        JOIN `allotment_account` ON ((`allotment_account`.`id` = `obligation_account`.`allotment_account_id`)))
        JOIN `allotment_release` ON ((`allotment_release`.`id` = `allotment_account`.`allotment_release_id`)))
        JOIN `budget_appropriations` ON ((`budget_appropriations`.`id` = `allotment_account`.`budget_appropriations_id`)))
        JOIN `general_ledger_accounts` ON ((`general_ledger_accounts`.`id` = `budget_appropriations`.`general_ledger_accounts_id`)))
        LEFT JOIN `others_fpp` ON ((`others_fpp`.`id` <=> `budget_appropriations`.`others_fpp_id`)))
        JOIN `sub_major_account_group` ON ((`sub_major_account_group`.`id` = `general_ledger_accounts`.`sub_major_account_group_id`)))
        JOIN `major_account_group` ON ((`major_account_group`.`id` = `sub_major_account_group`.`major_account_group_id`)))
        JOIN `account_group` ON ((`account_group`.`id` = `major_account_group`.`account_group_id`)))
        JOIN `users` `created_by` ON ((`created_by`.`id` = `obligation_request`.`created_by`)))
        LEFT JOIN `users` `updated_by` ON ((`updated_by`.`id` = `obligation_request`.`updated_by`)));

-- -----------------------------------------------------
-- View `lfs_db`.`view_role_has_permissions`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_role_has_permissions`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `view_role_has_permissions` AS
    SELECT 
        `rp`.`roles_id` AS `roles_id`,
        `rp`.`permissions_id` AS `permissions_id`,
        `r`.`role_name` AS `role_name`,
        `p`.`permission_name` AS `permission_name`,
        `p`.`permission_office` AS `permission_office`
    FROM
        ((`role_has_permissions` `rp`
        JOIN `roles` `r` ON (`rp`.`roles_id` = `r`.`id`))
        JOIN `permissions` `p` ON (`rp`.`permissions_id` = `p`.`id`));

-- -----------------------------------------------------
-- View `lfs_db`.`view_signatories_has_document_references`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_signatories_has_document_references`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `view_signatories_has_document_references` AS
    SELECT 
        `signatories_has_document_references`.`signatories_id` AS `signatories_id`,
        `signatories`.`prefix` AS `signatories_prefix`,
        `signatories`.`first_name` AS `signatories_first_name`,
        `signatories`.`middle_initial` AS `signatories_middle_initial`,
        `signatories`.`last_name` AS `signatories_last_name`,
        `signatories`.`suffix` AS `signatories_suffix`,
        `signatories`.`title` AS `signatories_title`,
        `signatories`.`created_at` AS `signatories_created_at`,
        `signatories`.`updated_at` AS `signatories_updated_at`,
        `signatories_has_document_references`.`document_references_id` AS `document_references_id`,
        `document_references`.`name` AS `document_references_name`,
        `documents`.`id` AS `documents_id`,
        `documents`.`name` AS `documents_name`,
        `documents`.`office` AS `office`
    FROM
        (((`signatories_has_document_references`
        JOIN `document_references` ON ((`document_references`.`id` = `signatories_has_document_references`.`document_references_id`)))
        JOIN `signatories` ON ((`signatories`.`id` = `signatories_has_document_references`.`signatories_id`)))
        JOIN `documents` ON ((`documents`.`id` = `document_references`.`documents_id`)));

-- -----------------------------------------------------
-- View `lfs_db`.`view_sub_major_account_group`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_sub_major_account_group`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `view_sub_major_account_group` AS
    SELECT 
        `b`.`account_group_id` AS `account_group_id`,
        `a`.`account_group_code` AS `account_group_code`,
        `a`.`account_group_name` AS `account_group_name`,
        `c`.`major_account_group_id` AS `major_account_group_id`,
        `b`.`maj_acc_group_code` AS `maj_acc_group_code`,
        `b`.`maj_acc_group_name` AS `maj_acc_group_name`,
        `c`.`id` AS `sub_maj_acc_group_id`,
        `c`.`sub_maj_acc_group_code` AS `sub_maj_acc_group_code`,
        `c`.`sub_maj_acc_group_name` AS `sub_maj_acc_group_name`,
        `c`.`created_at` AS `created_at`,
        `c`.`updated_at` AS `updated_at`
    FROM
        ((`account_group` `a`
        JOIN `major_account_group` `b` ON ((`a`.`id` = `b`.`account_group_id`)))
        JOIN `sub_major_account_group` `c` ON ((`b`.`id` = `c`.`major_account_group_id`)));

-- -----------------------------------------------------
-- View `lfs_db`.`view_supplemental_appropriations`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_supplemental_appropriations`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `view_supplemental_appropriations` AS
    SELECT 
        `a`.`id` AS `supplemental_appropriations_id`,
        `a`.`budget_appropriations_id` AS `budget_appropriations_id`,
        `b`.`funds_id` AS `funds_id`,
        `c`.`fund_code` AS `fund_code`,
        `c`.`fund_name` AS `fund_name`,
        `b`.`function_program_project_id` AS `function_program_project_id`,
        `d`.`fpp_code` AS `fpp_code`,
        `d`.`fpp_name` AS `fpp_name`,
        `b`.`others_fpp_id` AS `others_fpp_id`,
        `e`.`others_fpp_code` AS `others_fpp_code`,
        `e`.`name` AS `others_fpp_name`,
        `b`.`allotment_classes_id` AS `allotment_classes_id`,
        `f`.`allotment_code` AS `allotment_code`,
        `f`.`allotment_name` AS `allotment_name`,
        `a`.`date_entry` AS `date_entry`,
        `b`.`year` AS `appropriation_year`,
        `a`.`amount` AS `amount`,
        `b`.`continuing` AS `continuing`,
        `a`.`remarks` AS `remarks`
    FROM
        (((((`supplemental_appropriations` `a`
        JOIN `budget_appropriations` `b` ON ((`b`.`id` = `a`.`budget_appropriations_id`)))
        JOIN `funds` `c` ON ((`c`.`id` = `b`.`funds_id`)))
        JOIN `function_program_project` `d` ON ((`d`.`id` = `b`.`function_program_project_id`)))
        LEFT JOIN `others_fpp` `e` ON ((`e`.`id` <=> `b`.`others_fpp_id`)))
        JOIN `allotment_classes` `f` ON ((`f`.`id` = `b`.`allotment_classes_id`)));

-- -----------------------------------------------------
-- View `lfs_db`.`view_users`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_users`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `view_users` AS
    SELECT 
        `u`.`id` AS `id`,
        `u`.`roles_id` AS `roles_id`,
        `u`.`prefix` AS `prefix`,
        `u`.`first_name` AS `first_name`,
        `u`.`mid_initial` AS `mid_initial`,
        `u`.`last_name` AS `last_name`,
        `u`.`suffix` AS `suffix`,
        `u`.`username` AS `username`,
        `u`.`password` AS `password`,
        `r`.`role_name` AS `role_name`,
        `u`.`is_deleted` AS `is_deleted`,
        `u`.`created_at` AS `created_at`,
        `u`.`updated_at` AS `updated_at`,
        `u`.`is_super` AS `is_super`
    FROM
        (`users` `u`
        LEFT JOIN `roles` `r` ON ((`u`.`roles_id` = `r`.`id`)))
    ORDER BY `u`.`id`;

-- -----------------------------------------------------
-- View `lfs_db`.`view_document_references`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_document_references`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `view_document_references` AS
    SELECT 
        `a`.`id` AS `document_references_id`,
        `a`.`name` AS `document_references_name`,
        `a`.`documents_id` AS `documents_id`,
        `documents`.`name` AS `documents_name`,
        `documents`.`office` AS `office`
    FROM
        (`document_references` `a`
        JOIN `documents` ON ((`documents`.`id` = `a`.`documents_id`)));

-- -----------------------------------------------------
-- View `lfs_db`.`view_function_classification_services`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_function_classification_services`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `view_function_classification_services` AS
    SELECT 
        `functional_classification_services`.`id` AS `id`,
        `functional_classification_services`.`service_name` AS `service_name`,
        `functional_classification_services`.`functional_classifications_id` AS `functional_classifications_id`,
        `functional_classifications`.`sector_code` AS `functional_classifications_sector_code`,
        `functional_classifications`.`sector_name` AS `functional_classifications_sector_name`,
        `functional_classification_services`.`created_at` AS `created_at`,
        `functional_classification_services`.`updated_at` AS `updated_at`
    FROM
        (`functional_classification_services`
        JOIN `functional_classifications` ON ((`functional_classifications`.`id` = `functional_classification_services`.`functional_classifications_id`)));

-- -----------------------------------------------------
-- View `lfs_db`.`view_function_program_project`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_function_program_project`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `view_function_program_project` AS
    SELECT 
        `function_program_project`.`id` AS `id`,
        `function_program_project`.`fpp_code` AS `fpp_code`,
        `function_program_project`.`fpp_name` AS `fpp_name`,
        `function_program_project`.`functional_classification_services_id` AS `functional_classification_services_id`,
        `functional_classification_services`.`service_name` AS `service_name`,
        `function_program_project`.`is_special` AS `is_special`,
        `function_program_project`.`created_at` AS `created_at`,
        `function_program_project`.`updated_at` AS `updated_at`
    FROM
        (`function_program_project`
        JOIN `functional_classification_services` ON ((`functional_classification_services`.`id` = `function_program_project`.`functional_classification_services_id`)));

-- -----------------------------------------------------
-- View `lfs_db`.`view_collecting_officers_has_job_orders`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_collecting_officers_has_job_orders`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `view_collecting_officers_has_job_orders` AS
    SELECT 
        `collecting_officers_has_job_orders`.`collecting_officers_id` AS `collecting_officers_id`,
        `collecting_officers`.`prefix` AS `collecting_officers_prefix`,
        `collecting_officers`.`first_name` AS `collecting_officers_firstname`,
        `collecting_officers`.`mid_initial` AS `collecting_officers_mid_initial`,
        `collecting_officers`.`last_name` AS `collecting_officers_last_name`,
        `collecting_officers`.`suffix` AS `collecting_officers_suffix`,
        `collecting_officers`.`job_title` AS `collecting_officers_job_title`,
        `collecting_officers`.`is_deleted` AS `collecting_officers_is_deleted`,
        `collecting_officers_has_job_orders`.`job_orders_id` AS `job_orders_id`,
        `job_orders`.`users_id` AS `job_orders_user_id`,
        `job_orders`.`prefix` AS `job_orders_prefix`,
        `job_orders`.`first_name` AS `job_orders_first_name`,
        `job_orders`.`mid_initial` AS `job_orders_mid_initial`,
        `job_orders`.`last_name` AS `job_orders_last_name`,
        `job_orders`.`suffix` AS `job_orders_suffix`,
        `job_orders`.`job_title` AS `job_orders_job_title`,
        `job_orders`.`is_deleted` AS `job_orders_is_deleted`
    FROM
        ((`collecting_officers_has_job_orders`
        JOIN `collecting_officers` ON ((`collecting_officers`.`id` = `collecting_officers_has_job_orders`.`collecting_officers_id`)))
        JOIN `job_orders` ON ((`job_orders`.`id` = `collecting_officers_has_job_orders`.`job_orders_id`)));

-- -----------------------------------------------------
-- View `lfs_db`.`view_bank_deposits`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_bank_deposits`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `view_bank_deposits` AS
    SELECT 
        `bank_deposits`.`id` AS `id`,
        `bank_accounts`.`id` AS `bank_accounts_id`,
        `bank_accounts`.`account_no` AS `account_no`,
        `banks`.`id` AS `banks_id`,
        `banks`.`bank_code` AS `bank_code`,
        `banks`.`bank_name` AS `bank_name`,
        `funds`.`id` AS `funds_id`,
        `funds`.`fund_code` AS `fund_code`,
        `funds`.`fund_name` AS `fund_name`,
        `bank_deposits`.`reference` AS `reference`,
        `bank_deposits`.`date` AS `date`,
        `bank_deposits`.`amount` AS `amount`,
        `bank_deposits`.`created_at` AS `created_at`,
        `bank_deposits`.`created_by` AS `created_by`,
        `bank_deposits`.`updated_at` AS `updated_at`,
        `bank_deposits`.`updated_by` AS `updated_by`
    FROM
        (((`bank_deposits`
        JOIN `bank_accounts` ON ((`bank_accounts`.`id` = `bank_deposits`.`bank_accounts_id`)))
        JOIN `banks` ON ((`bank_accounts`.`banks_id` = `banks`.`id`)))
        JOIN `funds` ON ((`bank_deposits`.`funds_id` = `funds`.`id`)));

-- -----------------------------------------------------
-- View `lfs_db`.`view_receipts`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_receipts`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `view_receipts` AS
    SELECT 
        `receipts`.`id` AS `id`,
        `receipts`.`receipt_number_from` AS `receipt_number_from`,
        `receipts`.`receipt_number_to` AS `receipt_number_to`,
        `receipts`.`received_date` AS `received_date`,
        `receipts`.`quantity` AS `quantity`,
        `receipts`.`remarks` AS `remarks`,
        `users`.`id` AS `user_id`,
        CONCAT(`users`.`first_name`,
                ' ',
                `users`.`mid_initial`,
                ' ',
                `users`.`last_name`) AS `user`,
        `accountable_forms`.`id` AS `accountable_forms_id`,
        `accountable_forms`.`acc_form_no` AS `acc_form_no`,
        `accountable_forms`.`acc_form_desc` AS `acc_form_desc`
    FROM
        ((`receipts`
        JOIN `accountable_forms` ON ((`accountable_forms`.`id` = `receipts`.`accountable_forms_id`)))
        JOIN `users` ON ((`users`.`id` = `receipts`.`users_id`)));

-- -----------------------------------------------------
-- View `lfs_db`.`view_receipts_issued`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_receipts_issued`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `view_receipts_issued` AS
    SELECT 
        `receipts_issued`.`id` AS `id`,
        `receipts`.`id` AS `receipts_id`,
        `receipts`.`quantity` AS `receipts_quantity`,
        `accountable_forms`.`id` AS `accountable_form_id`,
        `accountable_forms`.`acc_form_no` AS `acc_form_no`,
        `accountable_forms`.`acc_form_desc` AS `acc_form_desc`,
        CONCAT(`accountable_forms`.`acc_form_no`,
                ' - ',
                `accountable_forms`.`acc_form_desc`) AS `accountable_forms`,
        `collecting_officers`.`id` AS `collecting_officer_id`,
        `collecting_officers`.`prefix` AS `collecting_officers_prefix`,
        `collecting_officers`.`first_name` AS `collecting_officers_first_name`,
        `collecting_officers`.`mid_initial` AS `collecting_officers_mid_initial`,
        `collecting_officers`.`last_name` AS `collecting_officers_last_name`,
        `collecting_officers`.`suffix` AS `collecting_officers_suffix`,
        `collecting_officers`.`job_title` AS `collecting_officers_job_title`,
        `collecting_officers`.`users_id` AS `co_users_id`,
        `job_orders`.`id` AS `job_orders_id`,
        `job_orders`.`prefix` AS `job_orders_prefix`,
        `job_orders`.`first_name` AS `job_orders_first_name`,
        `job_orders`.`mid_initial` AS `job_orders_mid_initial`,
        `job_orders`.`last_name` AS `job_orders_last_name`,
        `job_orders`.`suffix` AS `job_orders_suffix`,
        `job_orders`.`job_title` AS `job_orders_job_title`,
        `receipts_issued`.`date_issued` AS `date_issued`,
        `receipts_issued`.`receipt_issued_from` AS `receipt_issued_from`,
        `receipts_issued`.`receipt_issued_to` AS `receipt_issued_to`,
        `receipts_issued`.`last_issued` AS `last_issued`,
        `receipts_issued`.`quantity` AS `quantity`,
        `receipts_issued`.`is_returned` AS `is_returned`,
        `receipts_issued`.`returned_date` AS `returned_date`,
        CONCAT(`users`.`first_name`,
                ' ',
                `users`.`mid_initial`,
                ' ',
                `users`.`last_name`) AS `issued_by`
    FROM
        (((((`receipts_issued`
        JOIN `receipts` ON ((`receipts_issued`.`receipts_id` = `receipts`.`id`)))
        JOIN `accountable_forms` ON ((`receipts`.`accountable_forms_id` = `accountable_forms`.`id`)))
        JOIN `collecting_officers` ON ((`receipts_issued`.`collecting_officers_id` = `collecting_officers`.`id`)))
        LEFT JOIN `job_orders` ON ((`job_orders`.`id` = `receipts_issued`.`job_orders_id`)))
        JOIN `users` ON ((`users`.`id` = `receipts_issued`.`issued_by`)));

-- -----------------------------------------------------
-- View `lfs_db`.`view_rci`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_rci`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `view_rci` AS
    SELECT 
        `rci`.`id` AS `id`,
        `cheques`.`id` AS `cheques_id`,
        `cheques`.`cheque_no` AS `cheque_no`,
        `cheques`.`cheque_date` AS `cheque_date`,
        `cheques`.`amount` AS `amount`,
        `bank_accounts`.`id` AS `bank_accounts_id`,
        `bank_accounts`.`account_no` AS `bank_account_no`,
        `banks`.`id` AS `bank_id`,
        `banks`.`bank_name` AS `bank_name`,
        `funds`.`id` AS `fund_id`,
        `funds`.`fund_code` AS `fund_code`,
        `funds`.`fund_name` AS `fund_name`,
        `rci`.`dv_no` AS `dv_no`,
        `rci`.`payee` AS `payee`,
        `rci`.`nature_of_payment` AS `nature_of_payment`,
        GROUP_CONCAT(`rci_obligations`.`obligation_no`
            SEPARATOR ' / ') AS `obligation_no`,
        `rci_obligations`.`date_entry` AS `date_entry`,
        `function_program_project`.`id` AS `fpp_id`,
        `function_program_project`.`fpp_code` AS `fpp_code`,
        `function_program_project`.`fpp_name` AS `fpp_name`,
        SUM(`rci_deductions`.`amount`) AS `total_deductions`,
        `rci`.`created_at` AS `created_at`,
        `rci`.`updated_at` AS `updated_at`
    FROM
        (((((((`rci`
        JOIN `cheques` ON ((`cheques`.`id` = `rci`.`cheques_id`)))
        JOIN `bank_accounts` ON ((`bank_accounts`.`id` = `cheques`.`bank_accounts_id`)))
        JOIN `banks` ON ((`banks`.`id` = `bank_accounts`.`banks_id`)))
        JOIN `funds` ON ((`funds`.`id` = `rci`.`funds_id`)))
        JOIN `function_program_project` ON ((`function_program_project`.`id` = `rci`.`function_program_project_id`)))
        LEFT JOIN `rci_obligations` ON ((`rci_obligations`.`rci_id` = `rci`.`id`)))
        LEFT JOIN `rci_deductions` ON ((`rci_deductions`.`rci_id` = `rci`.`id`)))
    GROUP BY `rci`.`id`;

-- -----------------------------------------------------
-- View `lfs_db`.`view_payment_collections`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_payment_collections`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `view_payment_collections` AS
    SELECT 
        `payment_collections`.`id` AS `id`,
        `payment_collections`.`collecting_officers_id` AS `co_id`,
        `collecting_officers`.`first_name` AS `co_first_name`,
        `collecting_officers`.`mid_initial` AS `co_mid_initial`,
        `collecting_officers`.`last_name` AS `co_last_name`,
        `collecting_officers`.`prefix` AS `co_prefix`,
        `collecting_officers`.`suffix` AS `co_suffix`,
        `collecting_officers`.`job_title` AS `co_job_title`,
        `payment_collections`.`job_orders_id` AS `jo_id`,
        `job_orders`.`first_name` AS `jo_first_name`,
        `job_orders`.`mid_initial` AS `jo_mid_initial`,
        `job_orders`.`last_name` AS `jo_last_name`,
        `job_orders`.`prefix` AS `jo_prefix`,
        `job_orders`.`suffix` AS `jo_suffix`,
        `job_orders`.`job_title` AS `jo_job_title`,
        `payment_collections`.`funds_id` AS `funds_id`,
        `payment_collections`.`accountable_forms_id` AS `acc_form_id`,
        `accountable_forms`.`acc_form_no` AS `acc_form_no`,
        `accountable_forms`.`acc_form_desc` AS `acc_form_desc`,
        `payment_collections`.`payee` AS `payee`,
        `payment_collections`.`receipt_no` AS `receipt_no`,
        `payment_collections`.`payment_date` AS `payment_date`,
        `payment_collections`.`amount` AS `amount`,
        `payment_collections`.`is_cancelled` AS `is_cancelled`,
        `payment_collections`.`created_at` AS `created_at`,
        `payment_collections`.`created_by` AS `created_by`,
        `payment_collections`.`updated_at` AS `updated_at`,
        `payment_collections`.`updated_by` AS `updated_by`
    FROM
        (((`payment_collections`
        JOIN `accountable_forms` ON ((`accountable_forms`.`id` = `payment_collections`.`accountable_forms_id`)))
        JOIN `collecting_officers` ON ((`collecting_officers`.`id` = `payment_collections`.`collecting_officers_id`)))
        LEFT JOIN `job_orders` ON ((`job_orders`.`id` = `payment_collections`.`job_orders_id`)));

-- -----------------------------------------------------
-- View `lfs_db`.`view_rpt_payments`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_rpt_payments`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `view_rpt_payments` AS
    SELECT 
        `rpt_payments`.`id` AS `rpt_payments_id`,
		`rpt_assessment_posts`.`id` AS `rpt_assessment_posts_id`,
        `rpt_assessment_posts`.`taxpayer_tin` AS `taxpayer_tin`,
        `rpt_assessment_posts`.`taxpayer_name` AS `taxpayer_name`,
        `rpt_assessment_posts`.`taxpayer_contact_info` AS `taxpayer_contact_info`,
        `rpt_assessment_posts`.`taxpayer_address` AS `taxpayer_address`,
        `rpt_payments`.`posted_at` AS `rpt_payments_posted_at`,
        `rpt_payments`.`posted_by` AS `rpt_payments_posted_by`,
        `rpt_payments`.`payment_collections_id` AS `payment_collections_id`,
        `payment_collections`.`collecting_officers_id` AS `payment_collections_collecting_officers_id`,
        `payment_collections`.`job_orders_id` AS `payment_collections_job_orders_id`,
        `payment_collections`.`funds_id` AS `payment_collections_funds_id`,
        `payment_collections`.`accountable_forms_id` AS `payment_collections_accountable_forms_id`,
        `payment_collections`.`payee` AS `payment_collections_payee`,
        `payment_collections`.`receipt_no` AS `payment_collections_receipt_no`,
        `payment_collections`.`payment_date` AS `payment_collections_payment_date`,
        `payment_collections`.`amount` AS `payment_collections_amount`,
        `payment_collections`.`is_cancelled` AS `payment_collections_is_cancelled`,
        `payment_collections`.`created_at` AS `payment_collections_created_at`,
        `payment_collections`.`created_by` AS `payment_collections_created_by`,
        `payment_collections`.`updated_at` AS `payment_collections_updated_at`,
        `payment_collections`.`updated_by` AS `payment_collections_updated_by`
    FROM
        (((`rpt_payments`
        JOIN `payment_collections` ON ((`payment_collections`.`id` = `rpt_payments`.`payment_collections_id`)))
        JOIN `rpt_tax_dues` ON ((`rpt_tax_dues`.`rpt_payments_id` = `rpt_payments`.`id`)))
        JOIN `rpt_assessment_posts` ON ((`rpt_assessment_posts`.`id` = `rpt_tax_dues`.`rpt_assessment_posts_id`)))
    GROUP BY `rpt_payments`.`id`;

-- -----------------------------------------------------
-- View `lfs_db`.`view_rpt_tax_dues`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_rpt_tax_dues`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `view_rpt_tax_dues` AS
    SELECT 
        `rpt_tax_dues`.`id` AS `rpt_tax_dues_id`,
        `rpt_tax_dues`.`rpt_assessment_posts_id` AS `rpt_assessment_posts_id`,
        `rpt_assessment_posts`.`property_identifier` AS `property_identifier`,
        `rpt_assessment_posts`.`complete_arp_no` AS `complete_arp_no`,
        `rpt_assessment_posts`.`property_pin` AS `property_pin`,
        `rpt_assessment_posts`.`taxpayer_tin` AS `taxpayer_tin`,
        `rpt_assessment_posts`.`taxpayer_name` AS `taxpayer_name`,
        `rpt_assessment_posts`.`taxpayer_contact_info` AS `taxpayer_contact_info`,
        `rpt_assessment_posts`.`taxpayer_address` AS `taxpayer_address`,
        `rpt_assessment_posts`.`barangay_name` AS `barangay_name`,
        `rpt_assessment_posts`.`municipality_name` AS `municipality_name`,
        `rpt_assessment_posts`.`province_name` AS `province_name`,
        `rpt_assessment_posts`.`property_kind` AS `property_kind`,
        `rpt_assessment_posts`.`effectivity_quarterly` AS `effectivity_quarterly`,
        `rpt_assessment_posts`.`effectivity_year` AS `effectivity_year`,
        `rpt_assessment_posts`.`assessed_value` AS `assessed_value`,
        `rpt_assessment_posts`.`is_taxable` AS `is_taxable`,
        `rpt_assessment_posts`.`is_cancelled` AS `is_cancelled`,
        `rpt_assessment_posts`.`penalty_rate` AS `penalty_rate`,
        `rpt_assessment_posts`.`penalty_frequency` AS `penalty_frequency`,
        `rpt_assessment_posts`.`basic_rate` AS `basic_rate`,
        `rpt_assessment_posts`.`sef_rate` AS `sef_rate`,
        `rpt_assessment_posts`.`year` AS `year`,
        `rpt_assessment_posts`.`posted_at` AS `posted_at`,
        `rpt_assessment_posts`.`posted_by` AS `posted_by`,
        `rpt_tax_dues`.`rpt_payments_id` AS `rpt_payments_id`,
        `rpt_payments`.`posted_at` AS `rpt_payments_posted_at`,
        `rpt_payments`.`posted_by` AS `rpt_payments_posted_by`,
        `rpt_tax_dues`.`discount_rate` AS `discount_rate`,
        `rpt_tax_dues`.`is_advance` AS `is_advance`
    FROM
        ((`rpt_tax_dues`
        JOIN `rpt_assessment_posts` ON ((`rpt_assessment_posts`.`id` = `rpt_tax_dues`.`rpt_assessment_posts_id`)))
        JOIN `rpt_payments` ON ((`rpt_payments`.`id` = `rpt_tax_dues`.`rpt_payments_id`)));

-- -----------------------------------------------------
-- View `lfs_db`.`view_rpt_property_assessments`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_rpt_property_assessments`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `view_rpt_property_assessments` AS
    SELECT 
        `rpt_assessment_posts`.`id` AS `rpt_assessment_posts_id`,
        `rpt_assessment_posts`.`real_taxpayers_id` AS `real_taxpayers_id`,
        `rpt_assessment_posts`.`property_identifier` AS `property_identifier`,
        `rpt_assessment_posts`.`complete_arp_no` AS `complete_arp_no`,
        `rpt_assessment_posts`.`property_pin` AS `property_pin`,
        `rpt_assessment_posts`.`taxpayer_tin` AS `taxpayer_tin`,
        `rpt_assessment_posts`.`taxpayer_name` AS `taxpayer_name`,
        `rpt_assessment_posts`.`taxpayer_contact_info` AS `taxpayer_contact_info`,
        `rpt_assessment_posts`.`taxpayer_address` AS `taxpayer_address`,
        `rpt_assessment_posts`.`street` AS `street`,
        `rpt_assessment_posts`.`barangay_name` AS `barangay_name`,
        `rpt_assessment_posts`.`municipality_name` AS `municipality_name`,
        `rpt_assessment_posts`.`province_name` AS `province_name`,
        `rpt_assessment_posts`.`property_kind` AS `property_kind`,
        `rpt_assessment_posts`.`effectivity_quarterly` AS `effectivity_quarterly`,
        `rpt_assessment_posts`.`effectivity_year` AS `effectivity_year`,
        `rpt_assessment_posts`.`other_improvements` AS `other_improvements`,
        `rpt_assessment_posts`.`assessed_value` AS `assessed_value`,
        `rpt_assessment_posts`.`area` AS `area`,
        `rpt_assessment_posts`.`lot_no` AS `lot_no`,
        `rpt_assessment_posts`.`classification_code` AS `classification_code`,
        `rpt_assessment_posts`.`classification_name` AS `classification_name`,
        `rpt_assessment_posts`.`actual_use_code` AS `actual_use_code`,
        `rpt_assessment_posts`.`actual_use_name` AS `actual_use_name`,
        `rpt_assessment_posts`.`gr_year` AS `gr_year`,
        `rpt_assessment_posts`.`is_taxable` AS `is_taxable`,
        `rpt_assessment_posts`.`is_cancelled` AS `is_cancelled`,
        `rpt_tax_dues`.`id` AS `tax_dues_id`,
        COALESCE(`rpt_tax_dues`.`discount_rate`,
                0) AS `discount_rate`,
        `rpt_tax_dues`.`is_advance` AS `is_advance`,
        `rpt_assessment_posts`.`penalty_rate` AS `penalty_rate`,
        `rpt_assessment_posts`.`penalty_frequency` AS `penalty_frequency`,
        `rpt_assessment_posts`.`basic_rate` AS `basic_rate`,
        `rpt_assessment_posts`.`sef_rate` AS `sef_rate`,
        `rpt_assessment_posts`.`year` AS `year`,
        `rpt_assessment_posts`.`posted_at` AS `posted_at`,
        `rpt_assessment_posts`.`posted_by` AS `posted_by`,
        `rpt_payments`.`id` AS `rpt_payments_id`,
        `rpt_payments`.`posted_at` AS `rpt_payments_posted_at`,
        `rpt_payments`.`posted_by` AS `rpt_payments_posted_by`,
        `rpt_payments`.`payment_collections_id` AS `payment_collections_id`,
        `payment_collections`.`collecting_officers_id` AS `payment_collections_collecting_officers_id`,
        `payment_collections`.`job_orders_id` AS `payment_collections_job_orders_id`,
        `payment_collections`.`funds_id` AS `payment_collections_funds_id`,
        `payment_collections`.`accountable_forms_id` AS `payment_collections_accountable_forms_id`,
        `payment_collections`.`payee` AS `payment_collections_payee`,
        `payment_collections`.`receipt_no` AS `payment_collections_receipt_no`,
        `payment_collections`.`payment_date` AS `payment_collections_payment_date`,
        COALESCE(`payment_collections`.`amount`,
                0) AS `payment_collections_amount`,
        `payment_collections`.`is_cancelled` AS `payment_collections_is_cancelled`,
        `payment_collections`.`created_at` AS `payment_collections_created_at`,
        `payment_collections`.`created_by` AS `payment_collections_created_by`,
        `payment_collections`.`updated_at` AS `payment_collections_updated_at`,
        `payment_collections`.`updated_by` AS `payment_collections_updated_by`
    FROM
        (((`rpt_assessment_posts`
        LEFT JOIN `rpt_tax_dues` ON ((`rpt_tax_dues`.`rpt_assessment_posts_id` = `rpt_assessment_posts`.`id`)))
        LEFT JOIN `rpt_payments` ON ((`rpt_payments`.`id` = `rpt_tax_dues`.`rpt_payments_id`)))
        LEFT JOIN `payment_collections` ON ((`payment_collections`.`id` = `rpt_payments`.`payment_collections_id`)));

-- -----------------------------------------------------
-- View `lfs_db`.`view_taxpayers`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_taxpayers`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `view_taxpayers` AS
    SELECT 
        `taxpayers`.`id` AS `taxpayers_id`,
        `taxpayers`.`representative_registry_id` AS `representative_registry_id`,
        CONCAT(`registry`.`first_name`,
                ' ',
                SUBSTR(`registry`.`middle_name`, 1, 2),
                '. ',
                `registry`.`last_name`) AS `representative_name`,
        `taxpayers`.`tin` AS `taxpayers_tin`,
        `taxpayers`.`name` AS `taxpayers_name`,
        `taxpayers`.`address` AS `taxpayers_address`,
        `taxpayers`.`municipality` AS `taxpayers_municipality`,
        `taxpayers`.`province` AS `taxpayers_province`,
        `taxpayers`.`taxpayer_type_id` AS `taxpayer_type_id`,
        `taxpayer_type`.`code` AS `taxpayer_type_code`,
        `taxpayer_type`.`taxpayer_type` AS `taxpayer_type`,
        `taxpayers`.`contact_info` AS `taxpayers_contact_info`,
        `taxpayers`.`is_active` AS `is_active`,
        `taxpayers`.`created_at` AS `created_at`,
        `taxpayers`.`updated_at` AS `updated_at`
    FROM
        ((`taxpayers`
        JOIN `taxpayer_type` ON ((`taxpayer_type`.`id` = `taxpayers`.`taxpayer_type_id`)))
        LEFT JOIN `registry` ON ((`registry`.`id` = `taxpayers`.`representative_registry_id`)));

-- -----------------------------------------------------
-- View `lfs_db`.`view_barangays`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_barangays`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `view_barangays` AS
    SELECT 
        `barangays`.`id` AS `barangays_id`,
        `barangays`.`code` AS `barangays_code`,
        `barangays`.`name` AS `barangays_name`,
        `municipalities`.`id` AS `municipalities_id`,
        `municipalities`.`code` AS `municipalities_code`,
        `municipalities`.`name` AS `municipalities_name`,
        `provinces`.`id` AS `provinces_id`,
        `provinces`.`code` AS `provinces_code`,
        `provinces`.`name` AS `provinces_name`
    FROM
        ((`barangays`
        JOIN `municipalities` ON ((`municipalities`.`id` = `barangays`.`municipalities_id`)))
        JOIN `provinces` ON ((`provinces`.`id` = `municipalities`.`provinces_id`)));

-- -----------------------------------------------------
-- View `lfs_db`.`view_municipalities`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_municipalities`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `view_municipalities` AS
    SELECT 
        `municipalities`.`id` AS `municipalities_id`,
        `municipalities`.`code` AS `municipalities_code`,
        `municipalities`.`name` AS `municipalities_name`,
        `provinces`.`id` AS `provinces_id`,
        `provinces`.`code` AS `provinces_code`,
        `provinces`.`name` AS `provinces_name`
    FROM
        (`municipalities`
        JOIN `provinces` ON ((`provinces`.`id` = `municipalities`.`provinces_id`)));

-- -----------------------------------------------------
-- View `lfs_db`.`view_business_categories_has_add_on_charges`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_business_categories_has_add_on_charges`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `view_business_categories_has_add_on_charges` AS
    SELECT 
        `business_categories_has_add_on_charges`.`business_categories_id` AS `business_categories_id`,
        `business_categories`.`code` AS `business_categories_code`,
        `business_categories`.`description` AS `business_categories_description`,
        `business_categories`.`is_line_of_business` AS `business_categories_is_line_of_business`,
        `business_categories`.`ordinance_ref_no` AS `business_categories_ordinance_ref_no`,
        `business_categories_has_add_on_charges`.`business_add_on_charges_id` AS `business_add_on_charges_id`,
        `business_add_on_charges`.`code` AS `business_add_on_charges_code`,
        `business_add_on_charges`.`description` AS `business_add_on_charges_description`,
        `business_add_on_charges`.`is_applied_each_business` AS `business_add_on_charges_is_applied_to_each_business`
    FROM
        ((`business_categories_has_add_on_charges`
        JOIN `business_categories` ON ((`business_categories`.`id` = `business_categories_has_add_on_charges`.`business_categories_id`)))
        JOIN `business_add_on_charges` ON ((`business_add_on_charges`.`id` = `business_categories_has_add_on_charges`.`business_add_on_charges_id`)));

-- -----------------------------------------------------
-- View `lfs_db`.`view_bank_accounts`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_bank_accounts`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `view_bank_accounts` AS
    SELECT 
        `bank_accounts`.`id` AS `id`,
        `bank_accounts`.`account_no` AS `account_no`,
        `bank_accounts`.`banks_id` AS `banks_id`,
        `banks`.`bank_code` AS `bank_code`,
        `banks`.`bank_name` AS `bank_name`,
        `banks`.`bank_branch` AS `bank_branch`,
        `bank_accounts`.`created_at` AS `created_at`,
        `bank_accounts`.`updated_at` AS `updated_at`
    FROM
        (`bank_accounts`
        JOIN `banks` ON ((`banks`.`id` = `bank_accounts`.`banks_id`)));

-- -----------------------------------------------------
-- View `lfs_db`.`view_released_cheques`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_released_cheques`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `view_released_cheques` AS
    SELECT 
        `rci`.`id` AS `rci_id`,
        `rci`.`cheques_id` AS `cheques_id`,
        `cheques`.`bank_accounts_id` AS `bank_accounts_id`,
        `cheques`.`cheque_no` AS `cheque_no`,
        `cheques`.`cheque_date` AS `cheque_date`,
        `cheques`.`amount` AS `cheque_amount`,
        `rci`.`funds_id` AS `funds_id`,
        `funds`.`fund_code` AS `fund_code`,
        `funds`.`fund_name` AS `fund_name`,
        `rci`.`function_program_project_id` AS `function_program_project_id`,
        `rci`.`dv_no` AS `dv_no`,
        `rci`.`payee` AS `payee`,
        `rci`.`nature_of_payment` AS `nature_of_payment`,
        `released_cheques`.`id` AS `released_cheques_id`,
        `released_cheques`.`date_released` AS `date_released`
    FROM
        (((`rci`
        JOIN `cheques` ON ((`cheques`.`id` = `rci`.`cheques_id`)))
        JOIN `funds` ON ((`funds`.`id` = `rci`.`funds_id`)))
        LEFT JOIN `released_cheques` ON ((`released_cheques`.`rci_id` = `rci`.`id`)));

-- -----------------------------------------------------
-- View `lfs_db`.`view_subsidiary_ledger_accounts`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_subsidiary_ledger_accounts`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `view_subsidiary_ledger_accounts` AS
    SELECT 	
        `subsidiary_ledger_accounts`.`id` AS `subsidiary_ledger_accounts_id`,
        `subsidiary_ledger_accounts`.`funds_id` AS `funds_id`,
        `funds`.`fund_code` AS `fund_code`,
        `funds`.`fund_name` AS `fund_name`,
        `subsidiary_ledger_accounts`.`general_ledger_accounts_id` AS `general_ledger_accounts_id`,
        `general_ledger_accounts`.`ledger_code` AS `ledger_code`,
        `general_ledger_accounts`.`ledger_name` AS `ledger_name`,
        `subsidiary_ledger_accounts`.`sub_code` AS `sub_code`,
        `subsidiary_ledger_accounts`.`sub_name` AS `sub_name`,
        `subsidiary_ledger_accounts`.`address` AS `address`,
        `subsidiary_ledger_accounts`.`contact_person` AS `contact_person`,
        `subsidiary_ledger_accounts`.`contact` AS `contact`,
        `subsidiary_ledger_accounts`.`created_at` AS `created_at`,
        `subsidiary_ledger_accounts`.`updated_at` AS `updated_at`
    FROM
        ((`subsidiary_ledger_accounts`
        JOIN `funds` ON ((`funds`.`id` = `subsidiary_ledger_accounts`.`funds_id`)))
        JOIN `general_ledger_accounts` ON ((`general_ledger_accounts`.`id` = `subsidiary_ledger_accounts`.`general_ledger_accounts_id`)));

-- -----------------------------------------------------
-- View `lfs_db`.`view_real_properties`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_real_properties`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `view_real_properties` AS
    SELECT 
        `real_properties`.`id` AS `real_property_id`,
        `real_properties`.`street` AS `street`,
        `real_properties`.`complete_arp_no` AS `complete_arp_no`,
        `real_properties`.`property_pin` AS `property_pin`,
        `real_properties`.`property_kind` AS `property_kind`,
        `real_properties`.`effectivity_quarter` AS `effectivity_quarter`,
        `real_properties`.`effectivity_year` AS `effectivity_year`,
        `real_properties`.`other_improvements` AS `other_improvements`,
        `real_properties`.`assessed_value` AS `assessed_value`,
        `real_properties`.`area` AS `area`,
        `real_properties`.`lot_no` AS `lot_no`,
        `real_properties`.`gr_year` AS `gr_year`,
        `real_properties`.`is_taxable` AS `is_taxable`,
        `real_properties`.`is_cancelled` AS `is_cancelled`,
        `real_properties`.`created_at` AS `real_property_created_at`,
        `real_properties`.`updated_at` AS `real_property_updated_at`,
        `real_properties`.`taxpayers_id` AS `taxpayers_id`,
        `taxpayers`.`tin` AS `taxpayer_tin`,
        `taxpayers`.`name` AS `taxpayer_name`,
        `taxpayers`.`address` AS `taxpayer_address`,
        `taxpayers`.`municipality` AS `taxpayer_municipality`,
        `taxpayers`.`province` AS `taxpayer_province`,
        `taxpayers`.`contact_info` AS `taxpayer_contact_info`,
        `taxpayers`.`is_active` AS `taxpayer_is_active`,
        `taxpayer_type`.`id` AS `taxpayer_type_id`,
        `taxpayer_type`.`code` AS `taxpayer_type_code`,
        `taxpayer_type`.`taxpayer_type` AS `taxpayer_type_name`,
        `taxpayers`.`representative_registry_id` AS `representative_id`,
        CONCAT_WS(' ',
                `registry`.`first_name`,
                LEFT(`registry`.`middle_name`,
                    1),
                `registry`.`last_name`) AS `representative_name`,
        `real_properties`.`classification_codes_id` AS `classification_codes_id`,
        `classification_codes`.`code` AS `classification_code`,
        `classification_codes`.`name` AS `classification_name`,
        `classification_codes`.`is_special` AS `classification_is_special`,
        `real_properties`.`actual_use_codes_id` AS `actual_use_codes_id`,
        `actual_use_codes`.`code` AS `actual_use_code`,
        `actual_use_codes`.`name` AS `actual_use_name`,
        `actual_use_codes`.`is_government` AS `actual_use_is_government`,
        `real_properties`.`barangays_id` AS `barangays_id`,
        `barangays`.`code` AS `barangay_code`,
        `barangays`.`name` AS `barangay_name`,
        `municipalities`.`id` AS `municipality_id`,
        `municipalities`.`code` AS `municipality_code`,
        `municipalities`.`name` AS `municipality_name`,
        `provinces`.`id` AS `province_id`,
        `provinces`.`code` AS `province_code`,
        `provinces`.`name` AS `province_name`
    FROM
        ((((((((`real_properties`
        JOIN `taxpayers` ON ((`real_properties`.`taxpayers_id` = `taxpayers`.`id`)))
        LEFT JOIN `registry` ON ((`taxpayers`.`representative_registry_id` = `registry`.`id`)))
        JOIN `classification_codes` ON ((`real_properties`.`classification_codes_id` = `classification_codes`.`id`)))
        JOIN `actual_use_codes` ON ((`real_properties`.`actual_use_codes_id` = `actual_use_codes`.`id`)))
        JOIN `barangays` ON ((`real_properties`.`barangays_id` = `barangays`.`id`)))
        JOIN `municipalities` ON ((`barangays`.`municipalities_id` = `municipalities`.`id`)))
        JOIN `provinces` ON ((`municipalities`.`provinces_id` = `provinces`.`id`)))
        JOIN `taxpayer_type` ON ((`taxpayers`.`taxpayer_type_id` = `taxpayer_type`.`id`)));

-- -----------------------------------------------------
-- View `lfs_db`.`view_rcd`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_rcd`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `view_rcd` AS
    SELECT 
        `rcd`.`id` AS `id`,
        `rcd`.`report_no` AS `report_no`,
        `rcd`.`date` AS `date`,
        `funds`.`id` AS `fund_id`,
        `funds`.`fund_code` AS `fund_code`,
        `funds`.`fund_name` AS `fund_name`,
        `users`.`id` AS `created_by_id`,
        `users`.`prefix` AS `prefix`,
        `users`.`first_name` AS `first_name`,
        `users`.`mid_initial` AS `mid_initial`,
        `users`.`last_name` AS `last_name`,
        `users`.`suffix` AS `suffix`,
        `rcd`.`created_at` AS `created_at`
    FROM
        ((`rcd`
        LEFT JOIN `funds` ON ((`funds`.`id` = `rcd`.`funds_id`)))
        JOIN `users` ON ((`users`.`id` = `rcd`.`created_by`)));

-- -----------------------------------------------------
-- View `lfs_db`.`view_delinquent_notice`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_delinquent_notice`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `view_delinquent_notice` AS
    SELECT 
        `delinquent_notice`.`id` AS `delinquent_notice_id`,
        `delinquent_notice`.`notice_type` AS `notice_type`,
        `delinquent_notice`.`notice_date` AS `notice_date`,
        `delinquent_notice`.`real_properties_id` AS `real_properties_id`,
        `real_properties`.`complete_arp_no` AS `complete_arp_no`,
        `real_properties`.`property_kind` AS `property_kind`,
        `real_properties`.`taxpayers_id` AS `taxpayers_id`,
        `real_properties`.`assessed_value` AS `assessed_value`,
        `barangays`.`name` AS `barangay_name`,
        `municipalities`.`name` AS `municipalities_name`,
        `provinces`.`name` AS `provinces_name`,
        `taxpayers`.`name` AS `taxpayers_name`,
        `delinquent_notice`.`created_at` AS `created_at`,
        `delinquent_notice`.`created_by` AS `created_by`,
        `delinquent_notice`.`updated_at` AS `updated_at`,
        `delinquent_notice`.`updated_by` AS `updated_by`
    FROM
        (((((`delinquent_notice`
        JOIN `real_properties` ON ((`real_properties`.`id` = `delinquent_notice`.`real_properties_id`)))
        JOIN `taxpayers` ON ((`taxpayers`.`id` = `real_properties`.`taxpayers_id`)))
        JOIN `barangays` ON ((`barangays`.`id` = `real_properties`.`barangays_id`)))
        JOIN `municipalities` ON ((`municipalities`.`id` = `barangays`.`municipalities_id`)))
        JOIN `provinces` ON ((`provinces`.`id` = `municipalities`.`provinces_id`)));

-- -----------------------------------------------------
-- View `lfs_db`.`view_rpt_levy`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_rpt_levy`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `view_rpt_levy` AS
    SELECT 
        `rpt_levy`.`id` AS `rpt_levy_id`,
        `rpt_levy`.`real_properties_id` AS `real_properties_id`,
        `real_properties`.`complete_arp_no` AS `complete_arp_no`,
        `real_properties`.`property_kind` AS `property_kind`,
        `real_properties`.`assessed_value` AS `assessed_value`,
        `barangays`.`name` AS `barangay_name`,
        `municipalities`.`name` AS `municipalities_name`,
        `provinces`.`name` AS `provinces_name`,
        `taxpayers`.`name` AS `taxpayers_name`,
        `rpt_levy`.`date_issued` AS `date_issued`,
        `rpt_levy`.`created_at` AS `created_at`,
        `rpt_levy`.`created_by` AS `created_by`,
        `rpt_levy`.`updated_at` AS `updated_at`,
        `rpt_levy`.`updated_by` AS `updated_by`,
        `rpt_levy`.`is_cancelled` AS `is_cancelled`
    FROM
        (((((`rpt_levy`
        JOIN `real_properties` ON ((`real_properties`.`id` = `rpt_levy`.`real_properties_id`)))
        JOIN `taxpayers` ON ((`taxpayers`.`id` = `real_properties`.`taxpayers_id`)))
        JOIN `barangays` ON ((`barangays`.`id` = `real_properties`.`barangays_id`)))
        JOIN `municipalities` ON ((`municipalities`.`id` = `barangays`.`municipalities_id`)))
        JOIN `provinces` ON ((`provinces`.`id` = `municipalities`.`provinces_id`)));

-- -----------------------------------------------------
-- View `lfs_db`.`view_rpt_auction`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_rpt_auction`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `view_rpt_auction` AS
    SELECT 
        `auction`.`id` AS `auction_id`,
        `auction`.`start_date` AS `start_date`,
        `auction`.`end_date` AS `end_date`,
        `auction`.`location` AS `location`,
        `rpt_auction`.`id` AS `rpt_auction_id`,
        `real_properties`.`id` AS `real_properties_id`,
        `real_properties`.`street` AS `street`,
        `real_properties`.`complete_arp_no` AS `complete_arp_no`,
        `real_properties`.`property_pin` AS `property_pin`,
        `real_properties`.`property_kind` AS `property_kind`,
        `real_properties`.`assessed_value` AS `assessed_value`,
        `taxpayers`.`id` AS `taxpayers_id`,
        `taxpayers`.`tin` AS `taxpayer_tin`,
        `taxpayers`.`name` AS `taxpayer_name`,
        `taxpayers`.`address` AS `taxpayer_address`,
        `taxpayers`.`municipality` AS `taxpayer_municipality`,
        `taxpayers`.`province` AS `taxpayer_province`,
        `taxpayers`.`contact_info` AS `taxpayer_contact_info`
    FROM
        (((`auction`
        JOIN `rpt_auction` ON ((`auction`.`id` = `rpt_auction`.`auction_id`)))
        JOIN `real_properties` ON ((`real_properties`.`id` = `rpt_auction`.`real_properties_id`)))
        JOIN `taxpayers` ON ((`real_properties`.`taxpayers_id` = `taxpayers`.`id`)));

-- -----------------------------------------------------
-- View `lfs_db`.`view_bidders`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_bidders`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER	
VIEW `view_bidders` AS
    SELECT 
        `bidders`.`id` AS `id`,
        `bidders`.`taxpayers_id` AS `taxpayers_id`,
        `bidders`.`auction_id` AS `auction_id`,
        `bidders`.`payment_collections_id` AS `payment_collections_id`,
        `bidders`.`bidder_no` AS `bidder_no`,
        `bid`.`rpt_auction_id` AS `rpt_auction_id`,
        `taxpayers`.`representative_registry_id` AS `representative_registry_id`,
        `taxpayers`.`taxpayer_type_id` AS `taxpayer_type_id`,
        `taxpayers`.`tin` AS `tin`,
        `taxpayers`.`name` AS `name`,
        `taxpayers`.`address` AS `address`,
        `taxpayers`.`municipality` AS `municipality`,
        `taxpayers`.`province` AS `province`,
        `taxpayers`.`contact_info` AS `contact_info`,
        `payment_collections`.`collecting_officers_id` AS `collecting_officers_id`,
        `payment_collections`.`accountable_forms_id` AS `accountable_forms_id`,
        `payment_collections`.`payee` AS `payee`,
        `payment_collections`.`receipt_no` AS `receipt_no`,
        `payment_collections`.`payment_date` AS `payment_date`
    FROM
        (((((`bidders`
        JOIN `taxpayers` ON ((`taxpayers`.`id` = `bidders`.`taxpayers_id`)))
        JOIN `taxpayer_type` ON ((`taxpayer_type`.`id` = `taxpayers`.`taxpayer_type_id`)))
        JOIN `payment_collections` ON ((`payment_collections`.`id` = `bidders`.`payment_collections_id`)))
        JOIN `bid` ON ((`bid`.`bidders_id` = `bidders`.`id`)))
        JOIN `rpt_auction` ON ((`rpt_auction`.`id` = `bid`.`rpt_auction_id`)));

-- -----------------------------------------------------
-- View `lfs_db`.`view_bid`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_bid`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `view_bid` AS
    SELECT 
        `bid`.`id` AS `id`,
        `bid`.`rpt_auction_id` AS `rpt_auction_id`,
        `bid`.`ordinance_no` AS `ordinance_no`,
        `bid`.`date` AS `date`,
        `real_properties`.`complete_arp_no` AS `complete_arp_no`,
        `real_properties`.`assessed_value` AS `assessed_value`,
        `bidders`.`id` AS `bidders_id`,
        `bid`.`bid_amount` AS `bid_amount`,
        `payment_collections`.`id` AS `payment_collections_id`,
        `payment_collections`.`receipt_no` AS `receipt_no`,
        `bidders`.`taxpayers_id` AS `taxpayers_id`,
        `bidders`.`bidder_no` AS `bidder_no`,
        `taxpayers`.`name` AS `name`,
        `taxpayers`.`address` AS `address`,
        `taxpayers`.`municipality` AS `municipality`,
        `taxpayers`.`province` AS `province`,
        `taxpayers`.`contact_info` AS `contact_info`,
        `rpt_auction`.`real_properties_id` AS `real_properties_id`,
        `auction`.`id` AS `auction_id`,
        `auction`.`start_date` AS `start_date`,
        `auction`.`end_date` AS `end_date`,
        `auction`.`location` AS `location`
    FROM
        ((((((`bid`
        JOIN `rpt_auction` ON ((`bid`.`rpt_auction_id` = `rpt_auction`.`id`)))
        JOIN `bidders` ON ((`bid`.`bidders_id` = `bidders`.`id`)))
        JOIN `auction` ON ((`auction`.`id` = `rpt_auction`.`auction_id`)))
        JOIN `taxpayers` ON ((`taxpayers`.`id` = `bidders`.`taxpayers_id`)))
        JOIN `payment_collections` ON ((`payment_collections`.`id` = `bidders`.`payment_collections_id`)))
        JOIN `real_properties` ON ((`real_properties`.`id` = `rpt_auction`.`real_properties_id`)));

-- -----------------------------------------------------
-- View `lfs_db`.`view_cash_tickets_issued`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `lfs_db`.`view_cash_tickets_issued`;
USE `lfs_db`;
CREATE  OR REPLACE 
    ALGORITHM = UNDEFINED 
    DEFINER = `acc_user`@`%` 
    SQL SECURITY DEFINER
VIEW `lfs_db`.`view_cash_tickets_issued` AS
    SELECT 
        `lfs_db`.`cash_tickets_issued`.`id` AS `id`,
        `lfs_db`.`cash_tickets`.`id` AS `cash_tickets_id`,
        `lfs_db`.`cash_tickets`.`description` AS `cash_tickets_desc`,
        `lfs_db`.`cash_tickets`.`quantity` AS `cash_tickets_quantity`,
        `lfs_db`.`collecting_officers`.`id` AS `co_id`,
        `lfs_db`.`collecting_officers`.`prefix` AS `co_prefix`,
        `lfs_db`.`collecting_officers`.`first_name` AS `co_first_name`,
        `lfs_db`.`collecting_officers`.`mid_initial` AS `co_mid_initial`,
        `lfs_db`.`collecting_officers`.`last_name` AS `co_last_name`,
        `lfs_db`.`collecting_officers`.`suffix` AS `co_suffix`,
        `lfs_db`.`collecting_officers`.`job_title` AS `co_job_title`,
        `lfs_db`.`collecting_officers`.`users_id` AS `co_users_id`,
        `lfs_db`.`job_orders`.`id` AS `jo_id`,
        `lfs_db`.`job_orders`.`prefix` AS `jo_prefix`,
        `lfs_db`.`job_orders`.`first_name` AS `jo_first_name`,
        `lfs_db`.`job_orders`.`mid_initial` AS `jo_mid_initial`,
        `lfs_db`.`job_orders`.`last_name` AS `jo_last_name`,
        `lfs_db`.`job_orders`.`suffix` AS `jo_suffix`,
        `lfs_db`.`job_orders`.`job_title` AS `jo_job_title`,
        `lfs_db`.`cash_tickets_issued`.`date_issued` AS `date_issued`,
        `lfs_db`.`cash_tickets_issued`.`quantity` AS `quantity`,
        CONCAT(`lfs_db`.`users`.`first_name`,
                ' ',
                `lfs_db`.`users`.`mid_initial`,
                ' ',
                `lfs_db`.`users`.`last_name`) AS `issued_by`
    FROM
        ((((`lfs_db`.`cash_tickets_issued`
        JOIN `lfs_db`.`cash_tickets` ON ((`lfs_db`.`cash_tickets_issued`.`cash_tickets_id` = `lfs_db`.`cash_tickets`.`id`)))
        JOIN `lfs_db`.`collecting_officers` ON ((`lfs_db`.`cash_tickets_issued`.`collecting_officers_id` = `lfs_db`.`collecting_officers`.`id`)))
        LEFT JOIN `lfs_db`.`job_orders` ON ((`lfs_db`.`job_orders`.`id` = `lfs_db`.`cash_tickets_issued`.`job_orders_id`)))
        JOIN `lfs_db`.`users` ON ((`lfs_db`.`users`.`id` = `lfs_db`.`cash_tickets_issued`.`issued_by`)));

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

-- -----------------------------------------------------
-- Data for table `lfs_db`.`account_group`
-- -----------------------------------------------------
START TRANSACTION;
USE `lfs_db`;
INSERT INTO `lfs_db`.`account_group` (`id`, `account_group_code`, `account_group_name`, `created_at`, `updated_at`) VALUES (1, '1', 'Assets', DEFAULT, NULL);
INSERT INTO `lfs_db`.`account_group` (`id`, `account_group_code`, `account_group_name`, `created_at`, `updated_at`) VALUES (2, '2', 'Liabilities', DEFAULT, NULL);
INSERT INTO `lfs_db`.`account_group` (`id`, `account_group_code`, `account_group_name`, `created_at`, `updated_at`) VALUES (3, '3', 'Equity', DEFAULT, NULL);
INSERT INTO `lfs_db`.`account_group` (`id`, `account_group_code`, `account_group_name`, `created_at`, `updated_at`) VALUES (4, '4', 'Income', DEFAULT, NULL);
INSERT INTO `lfs_db`.`account_group` (`id`, `account_group_code`, `account_group_name`, `created_at`, `updated_at`) VALUES (5, '5', 'Expenses', DEFAULT, NULL);

COMMIT;


-- -----------------------------------------------------
-- Data for table `lfs_db`.`funds`
-- -----------------------------------------------------
START TRANSACTION;
USE `lfs_db`;
INSERT INTO `lfs_db`.`funds` (`id`, `fund_code`, `fund_name`, `created_at`, `updated_at`) VALUES (1, '100', 'General Fund', DEFAULT, NULL);
INSERT INTO `lfs_db`.`funds` (`id`, `fund_code`, `fund_name`, `created_at`, `updated_at`) VALUES (2, '200', 'Special Education Fund', DEFAULT, NULL);
INSERT INTO `lfs_db`.`funds` (`id`, `fund_code`, `fund_name`, `created_at`, `updated_at`) VALUES (3, '300', 'Trust Fund', DEFAULT, NULL);

COMMIT;


-- -----------------------------------------------------
-- Data for table `lfs_db`.`roles`
-- -----------------------------------------------------
START TRANSACTION;
USE `lfs_db`;
INSERT INTO `lfs_db`.`roles` (`id`, `role_name`, `created_at`, `updated_at`) VALUES (1, 'System Administrator', DEFAULT, NULL);

COMMIT;


-- -----------------------------------------------------
-- Data for table `lfs_db`.`users`
-- -----------------------------------------------------
START TRANSACTION;
USE `lfs_db`;
INSERT INTO `lfs_db`.`users` (`id`, `roles_id`, `prefix`, `first_name`, `mid_initial`, `last_name`, `suffix`, `username`, `password`, `is_super`, `is_deleted`, `created_at`, `updated_at`) VALUES (1, 1, NULL, 'John', 'A', 'Doe', NULL, 'john', '78d8045d684abd2eece923758f3cd781489df3a48e1278982466017f', DEFAULT, 0, DEFAULT, NULL);

COMMIT;


-- -----------------------------------------------------
-- Data for table `lfs_db`.`journals`
-- -----------------------------------------------------
START TRANSACTION;
USE `lfs_db`;
INSERT INTO `lfs_db`.`journals` (`id`, `journal_name`, `is_special`, `created_at`, `updated_at`) VALUES (1, 'General Journal', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`journals` (`id`, `journal_name`, `is_special`, `created_at`, `updated_at`) VALUES (2, 'Cash Receipts Journal', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`journals` (`id`, `journal_name`, `is_special`, `created_at`, `updated_at`) VALUES (3, 'Procurement Received Journal', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`journals` (`id`, `journal_name`, `is_special`, `created_at`, `updated_at`) VALUES (4, 'Cash Disbursements Journal', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`journals` (`id`, `journal_name`, `is_special`, `created_at`, `updated_at`) VALUES (5, 'Check Disbursements Journal', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`journals` (`id`, `journal_name`, `is_special`, `created_at`, `updated_at`) VALUES (6, 'Authority to Debit Account Disbursement Journal', 0, DEFAULT, NULL);

COMMIT;


-- -----------------------------------------------------
-- Data for table `lfs_db`.`allotment_classes`
-- -----------------------------------------------------
START TRANSACTION;
USE `lfs_db`;
INSERT INTO `lfs_db`.`allotment_classes` (`id`, `allotment_code`, `allotment_name`, `created_at`, `updated_at`) VALUES (1, 'PS', 'Personnel Services', DEFAULT, NULL);
INSERT INTO `lfs_db`.`allotment_classes` (`id`, `allotment_code`, `allotment_name`, `created_at`, `updated_at`) VALUES (2, 'MOOE', 'Maintenance and Other Operating Expenses', DEFAULT, NULL);
INSERT INTO `lfs_db`.`allotment_classes` (`id`, `allotment_code`, `allotment_name`, `created_at`, `updated_at`) VALUES (3, 'FinEx', 'Financial Expenses', DEFAULT, NULL);
INSERT INTO `lfs_db`.`allotment_classes` (`id`, `allotment_code`, `allotment_name`, `created_at`, `updated_at`) VALUES (4, 'CO', 'Capital Outlay', DEFAULT, NULL);

COMMIT;


-- -----------------------------------------------------
-- Data for table `lfs_db`.`functional_classifications`
-- -----------------------------------------------------
START TRANSACTION;
USE `lfs_db`;
INSERT INTO `lfs_db`.`functional_classifications` (`id`, `sector_code`, `sector_name`, `created_at`, `updated_at`) VALUES (1, '1000', 'General Public Services', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classifications` (`id`, `sector_code`, `sector_name`, `created_at`, `updated_at`) VALUES (2, '3000', 'Education, Culture,  Sports and Manpower Services', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classifications` (`id`, `sector_code`, `sector_name`, `created_at`, `updated_at`) VALUES (3, '4000', 'Health Services', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classifications` (`id`, `sector_code`, `sector_name`, `created_at`, `updated_at`) VALUES (4, '5000', 'Labor and Employment', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classifications` (`id`, `sector_code`, `sector_name`, `created_at`, `updated_at`) VALUES (5, '6000', 'Housing and Community Development', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classifications` (`id`, `sector_code`, `sector_name`, `created_at`, `updated_at`) VALUES (6, '7000', 'Social Welfare Services', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classifications` (`id`, `sector_code`, `sector_name`, `created_at`, `updated_at`) VALUES (7, '8000', 'Economic Services', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classifications` (`id`, `sector_code`, `sector_name`, `created_at`, `updated_at`) VALUES (8, '9000', 'Other Purposes', DEFAULT, NULL);

COMMIT;


-- -----------------------------------------------------
-- Data for table `lfs_db`.`functional_classification_services`
-- -----------------------------------------------------
START TRANSACTION;
USE `lfs_db`;
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (1, 1, 'Executive Services', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (2, 1, 'Legislative Services', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (3, 1, 'Administrative Services (Administrator)', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (4, 1, 'Planning and Development Coordination', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (7, 1, 'Civil Registry (Civil Registrar)', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (8, 1, 'General Services (General Services Office)', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (9, 1, 'Budgeting Services (Budget Officer)', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (10, 1, 'Accounting Services (Accountant)', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (12, 1, 'Assessment of Real Property (Assessor)', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (13, 1, 'Auditing Services (Auditor)', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (14, 1, 'Information Services', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (17, 1, 'Administration of Justice (Lower Court)', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (18, 1, 'Land Registration Services (Register of Deeds)', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (19, 1, 'Mining Claim Registration Services (Mining Recorder)', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (20, 1, 'Police Services', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (21, 1, 'Fire Protection Services', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (22, 1, 'Local Disaster Risk Reduction and Management Office', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (23, 1, 'Miscellaneous General Public Services', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (24, 2, 'School Supervision (Superintendent of Schools)', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (25, 2, 'Public Education', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (27, 2, 'Manpower Development', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (28, 2, 'Maintenance of Sports Centers, Athletic Fields, Playgrounds', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (29, 2, 'Operation of Cultural/Conference/Convention Center', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (30, 2, 'Other Education, Sports and Manpower Development Services', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (31, 2, 'Local Development Fund', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (32, 3, 'Health Services (Health Officer)', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (33, 3, 'Hospital', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (34, 3, 'Chest Clinic', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (35, 3, 'Local Development Fund', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (36, 3, 'Miscellaneous Health Services', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (37, 4, 'Miscellaneous, Labor and Employment', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (39, 5, 'Housing Projects', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (40, 5, 'Sanitary Services', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (41, 5, 'Street Lighting', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (42, 5, 'Community Development', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (43, 5, 'Community Development', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (44, 5, 'Miscellaneous Housing and Community Development', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (48, 6, 'Social Welfare Services (Social Welfare & Development Officer)', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (49, 6, 'Family Planning Services (Population Officer)', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (50, 6, 'Local Development Fund', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (51, 6, 'Miscellaneous, Other Social Services', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (52, 7, 'Agricultural Services', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (53, 7, 'Veterinary Services (Veterinarian)', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (54, 7, 'Natural Resources Services (Environment & Natural Resources', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (55, 7, 'Architectural Services (Architect)', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (56, 7, 'Engineering Services', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (57, 7, 'Cooperative Services (Cooperative Officer)', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (58, 7, 'Operation of Waterworks System', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (59, 7, 'Operation of Electric Light and Power System', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (60, 7, 'Operation of Telephone System', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (61, 7, 'Operation of Toll Roads, Bridges and Ferries', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (62, 7, 'Operation of Markets', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (64, 7, 'Operation of Slaughterhouse', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (65, 7, 'Operation of Transportation System', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (66, 7, 'Weather and Meteorological Services', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (67, 7, 'Operation of Cemeteries', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (68, 7, 'Economic Development Programs', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (69, 7, 'Local Development Fund', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (70, 7, 'Energy Development Project', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (71, 7, 'Livelihood Projects', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (72, 7, 'Miscellaneous Economic Services', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (73, 8, 'Local Development Projects - Public Debt', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (74, 8, 'Public Debt', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (75, 8, 'Retirement and Other Benefits', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (76, 8, 'Disaster Risk Reduction and Management', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (77, 8, 'Miscellaneous Other Purposes', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (78, 5, 'Local Development Fund', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (79, 2, 'Education Subsidiary Services', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (80, 1, 'Prosecution Services', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (81, 1, 'Legal Services (Attorney/Legal Officer)', DEFAULT, NULL);
INSERT INTO `lfs_db`.`functional_classification_services` (`id`, `functional_classifications_id`, `service_name`, `created_at`, `updated_at`) VALUES (82, 1, 'Treasury Services (Treasurer)', DEFAULT, NULL);

COMMIT;


-- -----------------------------------------------------
-- Data for table `lfs_db`.`function_program_project`
-- -----------------------------------------------------
START TRANSACTION;
USE `lfs_db`;
INSERT INTO `lfs_db`.`function_program_project` (`id`, `functional_classification_services_id`, `fpp_code`, `fpp_name`, `is_special`, `created_at`, `updated_at`) VALUES (1, 1, '1011', 'Mayor\'s Office', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`function_program_project` (`id`, `functional_classification_services_id`, `fpp_code`, `fpp_name`, `is_special`, `created_at`, `updated_at`) VALUES (2, 1, '1016', 'Vice Mayor\'s Office', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`function_program_project` (`id`, `functional_classification_services_id`, `fpp_code`, `fpp_name`, `is_special`, `created_at`, `updated_at`) VALUES (4, 2, '1022', 'SB Secretary', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`function_program_project` (`id`, `functional_classification_services_id`, `fpp_code`, `fpp_name`, `is_special`, `created_at`, `updated_at`) VALUES (5, 2, '1021', 'SB Legislative', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`function_program_project` (`id`, `functional_classification_services_id`, `fpp_code`, `fpp_name`, `is_special`, `created_at`, `updated_at`) VALUES (6, 3, '1032', 'Human Resource Management Office', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`function_program_project` (`id`, `functional_classification_services_id`, `fpp_code`, `fpp_name`, `is_special`, `created_at`, `updated_at`) VALUES (7, 4, '1041', 'MPDC', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`function_program_project` (`id`, `functional_classification_services_id`, `fpp_code`, `fpp_name`, `is_special`, `created_at`, `updated_at`) VALUES (8, 7, '1051', 'Civil Registrar', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`function_program_project` (`id`, `functional_classification_services_id`, `fpp_code`, `fpp_name`, `is_special`, `created_at`, `updated_at`) VALUES (9, 9, '1071', 'Budget Office', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`function_program_project` (`id`, `functional_classification_services_id`, `fpp_code`, `fpp_name`, `is_special`, `created_at`, `updated_at`) VALUES (10, 10, '1081', 'Accountant\'s Office', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`function_program_project` (`id`, `functional_classification_services_id`, `fpp_code`, `fpp_name`, `is_special`, `created_at`, `updated_at`) VALUES (12, 12, '1101', 'Assessor\'s Office', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`function_program_project` (`id`, `functional_classification_services_id`, `fpp_code`, `fpp_name`, `is_special`, `created_at`, `updated_at`) VALUES (13, 30, '3392', 'Sports Development/Physical Fitnes', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`function_program_project` (`id`, `functional_classification_services_id`, `fpp_code`, `fpp_name`, `is_special`, `created_at`, `updated_at`) VALUES (14, 23, '1999', 'Others', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`function_program_project` (`id`, `functional_classification_services_id`, `fpp_code`, `fpp_name`, `is_special`, `created_at`, `updated_at`) VALUES (23, 13, '1111', 'Auditor\'s Office', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`function_program_project` (`id`, `functional_classification_services_id`, `fpp_code`, `fpp_name`, `is_special`, `created_at`, `updated_at`) VALUES (24, 17, '1158', 'Mun. Trial Court Office', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`function_program_project` (`id`, `functional_classification_services_id`, `fpp_code`, `fpp_name`, `is_special`, `created_at`, `updated_at`) VALUES (25, 20, '1181', 'PNP Office', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`function_program_project` (`id`, `functional_classification_services_id`, `fpp_code`, `fpp_name`, `is_special`, `created_at`, `updated_at`) VALUES (26, 21, '1191', 'BFP Office', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`function_program_project` (`id`, `functional_classification_services_id`, `fpp_code`, `fpp_name`, `is_special`, `created_at`, `updated_at`) VALUES (29, 32, '4411', 'Municipal Health Office', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`function_program_project` (`id`, `functional_classification_services_id`, `fpp_code`, `fpp_name`, `is_special`, `created_at`, `updated_at`) VALUES (30, 32, '4412', 'Nutrition Office', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`function_program_project` (`id`, `functional_classification_services_id`, `fpp_code`, `fpp_name`, `is_special`, `created_at`, `updated_at`) VALUES (31, 42, '6541', 'Aid to DILG Office', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`function_program_project` (`id`, `functional_classification_services_id`, `fpp_code`, `fpp_name`, `is_special`, `created_at`, `updated_at`) VALUES (32, 48, '7611', 'Social Welfare & Development Office', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`function_program_project` (`id`, `functional_classification_services_id`, `fpp_code`, `fpp_name`, `is_special`, `created_at`, `updated_at`) VALUES (34, 52, '8711', 'Agriculturist\'s Office', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`function_program_project` (`id`, `functional_classification_services_id`, `fpp_code`, `fpp_name`, `is_special`, `created_at`, `updated_at`) VALUES (35, 56, '8751', 'Engineer\'s Office', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`function_program_project` (`id`, `functional_classification_services_id`, `fpp_code`, `fpp_name`, `is_special`, `created_at`, `updated_at`) VALUES (36, 56, '8754', 'Other Business Operation', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`function_program_project` (`id`, `functional_classification_services_id`, `fpp_code`, `fpp_name`, `is_special`, `created_at`, `updated_at`) VALUES (37, 82, '1091', 'Treasurer\'s Office', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`function_program_project` (`id`, `functional_classification_services_id`, `fpp_code`, `fpp_name`, `is_special`, `created_at`, `updated_at`) VALUES (38, 74, '9921', 'Loan Amortization - Domestic', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`function_program_project` (`id`, `functional_classification_services_id`, `fpp_code`, `fpp_name`, `is_special`, `created_at`, `updated_at`) VALUES (39, 74, '9923', 'Interest Payments - Domestic', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`function_program_project` (`id`, `functional_classification_services_id`, `fpp_code`, `fpp_name`, `is_special`, `created_at`, `updated_at`) VALUES (42, 77, '9995', 'Aid to Barangays', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`function_program_project` (`id`, `functional_classification_services_id`, `fpp_code`, `fpp_name`, `is_special`, `created_at`, `updated_at`) VALUES (45, 77, '9999', 'Others', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`function_program_project` (`id`, `functional_classification_services_id`, `fpp_code`, `fpp_name`, `is_special`, `created_at`, `updated_at`) VALUES (46, 76, '9940', 'Local Disaster Risk Reduction and Management Fund', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`function_program_project` (`id`, `functional_classification_services_id`, `fpp_code`, `fpp_name`, `is_special`, `created_at`, `updated_at`) VALUES (47, 69, '8919', 'Other Economic Services Projects', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`function_program_project` (`id`, `functional_classification_services_id`, `fpp_code`, `fpp_name`, `is_special`, `created_at`, `updated_at`) VALUES (48, 35, '4918', 'Purchase, Construction and Improvement of Government Facilities - Health', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`function_program_project` (`id`, `functional_classification_services_id`, `fpp_code`, `fpp_name`, `is_special`, `created_at`, `updated_at`) VALUES (49, 69, '8918', 'Purchase, Construction and Improvement of Government Facilities - Economic Services', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`function_program_project` (`id`, `functional_classification_services_id`, `fpp_code`, `fpp_name`, `is_special`, `created_at`, `updated_at`) VALUES (50, 62, '8811', 'Operation of Markets', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`function_program_project` (`id`, `functional_classification_services_id`, `fpp_code`, `fpp_name`, `is_special`, `created_at`, `updated_at`) VALUES (51, 64, '8812', 'Operation of Slaughterhouse', 0, DEFAULT, NULL);

COMMIT;


-- -----------------------------------------------------
-- Data for table `lfs_db`.`major_account_group`
-- -----------------------------------------------------
START TRANSACTION;
USE `lfs_db`;
INSERT INTO `lfs_db`.`major_account_group` (`id`, `account_group_id`, `maj_acc_group_code`, `maj_acc_group_name`, `created_at`, `updated_at`) VALUES (1, 1, '01', 'Cash', DEFAULT, NULL);
INSERT INTO `lfs_db`.`major_account_group` (`id`, `account_group_id`, `maj_acc_group_code`, `maj_acc_group_name`, `created_at`, `updated_at`) VALUES (2, 1, '02', 'Investments', DEFAULT, NULL);
INSERT INTO `lfs_db`.`major_account_group` (`id`, `account_group_id`, `maj_acc_group_code`, `maj_acc_group_name`, `created_at`, `updated_at`) VALUES (3, 1, '03', 'Receivables', DEFAULT, NULL);
INSERT INTO `lfs_db`.`major_account_group` (`id`, `account_group_id`, `maj_acc_group_code`, `maj_acc_group_name`, `created_at`, `updated_at`) VALUES (4, 1, '04', 'Inventories', DEFAULT, NULL);
INSERT INTO `lfs_db`.`major_account_group` (`id`, `account_group_id`, `maj_acc_group_code`, `maj_acc_group_name`, `created_at`, `updated_at`) VALUES (5, 1, '05', 'Prepayments', DEFAULT, NULL);
INSERT INTO `lfs_db`.`major_account_group` (`id`, `account_group_id`, `maj_acc_group_code`, `maj_acc_group_name`, `created_at`, `updated_at`) VALUES (6, 1, '06', 'Investment Property', DEFAULT, NULL);
INSERT INTO `lfs_db`.`major_account_group` (`id`, `account_group_id`, `maj_acc_group_code`, `maj_acc_group_name`, `created_at`, `updated_at`) VALUES (7, 1, '07', 'Property, Plant and Equipment', DEFAULT, NULL);
INSERT INTO `lfs_db`.`major_account_group` (`id`, `account_group_id`, `maj_acc_group_code`, `maj_acc_group_name`, `created_at`, `updated_at`) VALUES (8, 1, '08', 'Biological Assets', DEFAULT, NULL);
INSERT INTO `lfs_db`.`major_account_group` (`id`, `account_group_id`, `maj_acc_group_code`, `maj_acc_group_name`, `created_at`, `updated_at`) VALUES (9, 1, '09', 'Intangible Assets', DEFAULT, NULL);
INSERT INTO `lfs_db`.`major_account_group` (`id`, `account_group_id`, `maj_acc_group_code`, `maj_acc_group_name`, `created_at`, `updated_at`) VALUES (10, 2, '01', 'Financial Liabilities', DEFAULT, NULL);
INSERT INTO `lfs_db`.`major_account_group` (`id`, `account_group_id`, `maj_acc_group_code`, `maj_acc_group_name`, `created_at`, `updated_at`) VALUES (11, 2, '02', 'Inter-Agency Payables', DEFAULT, NULL);
INSERT INTO `lfs_db`.`major_account_group` (`id`, `account_group_id`, `maj_acc_group_code`, `maj_acc_group_name`, `created_at`, `updated_at`) VALUES (12, 2, '03', 'Intra-Agency Payables', DEFAULT, NULL);
INSERT INTO `lfs_db`.`major_account_group` (`id`, `account_group_id`, `maj_acc_group_code`, `maj_acc_group_name`, `created_at`, `updated_at`) VALUES (13, 2, '04', 'Trust Liabilities', DEFAULT, NULL);
INSERT INTO `lfs_db`.`major_account_group` (`id`, `account_group_id`, `maj_acc_group_code`, `maj_acc_group_name`, `created_at`, `updated_at`) VALUES (14, 2, '05', 'Deferred Credits/Unearned Income', DEFAULT, NULL);
INSERT INTO `lfs_db`.`major_account_group` (`id`, `account_group_id`, `maj_acc_group_code`, `maj_acc_group_name`, `created_at`, `updated_at`) VALUES (15, 2, '06', 'Provisions', DEFAULT, NULL);
INSERT INTO `lfs_db`.`major_account_group` (`id`, `account_group_id`, `maj_acc_group_code`, `maj_acc_group_name`, `created_at`, `updated_at`) VALUES (16, 2, '99', 'Other Payables', DEFAULT, NULL);
INSERT INTO `lfs_db`.`major_account_group` (`id`, `account_group_id`, `maj_acc_group_code`, `maj_acc_group_name`, `created_at`, `updated_at`) VALUES (17, 3, '01', 'Government Equity', DEFAULT, NULL);
INSERT INTO `lfs_db`.`major_account_group` (`id`, `account_group_id`, `maj_acc_group_code`, `maj_acc_group_name`, `created_at`, `updated_at`) VALUES (18, 3, '02', 'Intermediate Accounts', DEFAULT, NULL);
INSERT INTO `lfs_db`.`major_account_group` (`id`, `account_group_id`, `maj_acc_group_code`, `maj_acc_group_name`, `created_at`, `updated_at`) VALUES (19, 3, '03', 'Equity in Joint Venture', DEFAULT, NULL);
INSERT INTO `lfs_db`.`major_account_group` (`id`, `account_group_id`, `maj_acc_group_code`, `maj_acc_group_name`, `created_at`, `updated_at`) VALUES (20, 3, '04', 'Unrealized Gain/(Loss)', DEFAULT, NULL);
INSERT INTO `lfs_db`.`major_account_group` (`id`, `account_group_id`, `maj_acc_group_code`, `maj_acc_group_name`, `created_at`, `updated_at`) VALUES (21, 3, '05', 'Budgetary Accounts', DEFAULT, NULL);
INSERT INTO `lfs_db`.`major_account_group` (`id`, `account_group_id`, `maj_acc_group_code`, `maj_acc_group_name`, `created_at`, `updated_at`) VALUES (22, 4, '01', 'Tax Revenue', DEFAULT, NULL);
INSERT INTO `lfs_db`.`major_account_group` (`id`, `account_group_id`, `maj_acc_group_code`, `maj_acc_group_name`, `created_at`, `updated_at`) VALUES (23, 4, '02', 'Service and Business Income', DEFAULT, NULL);
INSERT INTO `lfs_db`.`major_account_group` (`id`, `account_group_id`, `maj_acc_group_code`, `maj_acc_group_name`, `created_at`, `updated_at`) VALUES (24, 4, '03', 'Transfers and Subsidy', DEFAULT, NULL);
INSERT INTO `lfs_db`.`major_account_group` (`id`, `account_group_id`, `maj_acc_group_code`, `maj_acc_group_name`, `created_at`, `updated_at`) VALUES (25, 4, '04', 'Shares, Grants and Donations', DEFAULT, NULL);
INSERT INTO `lfs_db`.`major_account_group` (`id`, `account_group_id`, `maj_acc_group_code`, `maj_acc_group_name`, `created_at`, `updated_at`) VALUES (26, 4, '05', 'Gains', DEFAULT, NULL);
INSERT INTO `lfs_db`.`major_account_group` (`id`, `account_group_id`, `maj_acc_group_code`, `maj_acc_group_name`, `created_at`, `updated_at`) VALUES (27, 4, '06', 'Miscellaneous Income', DEFAULT, NULL);
INSERT INTO `lfs_db`.`major_account_group` (`id`, `account_group_id`, `maj_acc_group_code`, `maj_acc_group_name`, `created_at`, `updated_at`) VALUES (28, 5, '01', 'Personnel Services', DEFAULT, NULL);
INSERT INTO `lfs_db`.`major_account_group` (`id`, `account_group_id`, `maj_acc_group_code`, `maj_acc_group_name`, `created_at`, `updated_at`) VALUES (29, 5, '02', 'Maintenance and Other Operating Expenses', DEFAULT, NULL);
INSERT INTO `lfs_db`.`major_account_group` (`id`, `account_group_id`, `maj_acc_group_code`, `maj_acc_group_name`, `created_at`, `updated_at`) VALUES (30, 5, '03', 'Financial Expenses', DEFAULT, NULL);
INSERT INTO `lfs_db`.`major_account_group` (`id`, `account_group_id`, `maj_acc_group_code`, `maj_acc_group_name`, `created_at`, `updated_at`) VALUES (31, 5, '04', 'Direct Costs', DEFAULT, NULL);
INSERT INTO `lfs_db`.`major_account_group` (`id`, `account_group_id`, `maj_acc_group_code`, `maj_acc_group_name`, `created_at`, `updated_at`) VALUES (32, 5, '05', 'Non-Cash Expenses', DEFAULT, NULL);

COMMIT;


-- -----------------------------------------------------
-- Data for table `lfs_db`.`sub_major_account_group`
-- -----------------------------------------------------
START TRANSACTION;
USE `lfs_db`;
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (1, 1, '01', 'Cash on Hand', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (2, 1, '02', 'Cash in Bank - Local Currency', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (3, 1, '03', 'Cash in Bank - Foreign Currency', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (4, 2, '01', 'Investments in Time Deposits', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (5, 2, '02', 'Financial Assets at Fair Value Through Surplus or Deficit', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (6, 2, '03', 'Financial Assets - Held to Maturity', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (7, 2, '04', 'Financial Assets - Available for Sale', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (8, 2, '05', 'Financial Assets - Others', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (9, 2, '06', 'Investments in Joint Venture', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (10, 2, '07', 'Sinking Fund', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (11, 3, '01', 'Loans and Receivable Accounts', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (12, 3, '02', 'Lease Receivables', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (13, 3, '03', 'Inter-Agency Receivables', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (14, 3, '04', 'Intra-Agency Receivables', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (15, 3, '05', 'Advances', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (16, 3, '06', 'Other Receivables', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (17, 4, '01', 'Inventory Held for Sale', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (18, 4, '02', 'Inventory Held for Distribution', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (19, 4, '03', 'Inventory Held for Manufacturing', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (20, 4, '04', 'Inventory Held for Consumption', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (21, 5, '01', 'Prepayments', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (22, 6, '01', 'Land and Buildings', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (23, 7, '01', 'Land', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (24, 7, '02', 'Land Improvements', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (25, 7, '03', 'Infrastructure Assets', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (26, 7, '04', 'Buildings and Other Structures', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (27, 7, '05', 'Machinery and Equipment', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (28, 7, '06', 'Transportation Equipment', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (29, 7, '07', 'Furniture, Fixtures and Books', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (30, 7, '08', 'Leased Assets', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (31, 7, '09', 'Leased Assets Improvements', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (32, 7, '10', 'Construction in Progress', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (33, 7, '11', 'Service Concession Assets', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (34, 7, '99', 'Other Property, Plant and Equipment', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (35, 8, '01', 'Bearer Biological Assets', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (36, 9, '01', 'Intangible Assets', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (37, 9, '02', 'Service Concession Assets - Intangible Assets', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (38, 10, '01', 'Payables', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (39, 10, '02', 'Bills/Bonds/Loans Payable', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (40, 11, '01', 'Inter-Agency Payables', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (41, 12, '01', 'Intra-Agency Payables', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (42, 13, '01', 'Trust Liabilities', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (43, 14, '01', 'Deferred Credits', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (44, 15, '01', 'Provisions', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (45, 16, '99', 'Other Payables', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (46, 17, '01', 'Government Equity', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (47, 18, '01', 'Intermediate Accounts', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (48, 19, '01', 'Equity in Joint Venture', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (49, 20, '01', 'Unrealized Gain/(Loss)', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (50, 21, '01', 'Budgetary Balance', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (51, 21, '02', 'Estimates/Appropriations/Allotments', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (52, 21, '03', 'Obligations', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (53, 21, '04', 'Reversions', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (54, 22, '01', 'Tax Revenue - Individual and Corporation', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (55, 22, '02', 'Tax Revenue - Property', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (56, 22, '03', 'Tax Revenue - Goods and Services', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (57, 22, '04', 'Tax Revenue - Others', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (58, 22, '05', 'Tax Revenue - Fines and Penalties', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (59, 22, '06', 'Share from National Taxes', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (60, 23, '01', 'Service Income', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (61, 23, '02', 'Business Income', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (62, 24, '01', 'Subsidy', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (63, 24, '02', 'Transfers', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (64, 25, '01', 'Share', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (65, 25, '02', 'Grants and Donations', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (66, 26, '01', 'Gains', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (67, 27, '01', 'Miscellaneous Income', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (68, 28, '01', 'Salaries and Wages', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (69, 28, '02', 'Other Compensation', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (70, 28, '03', 'Personnel Benefit Contributions', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (71, 28, '04', 'Other Personnel Benefits', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (72, 29, '01', 'Traveling Expenses', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (73, 29, '02', 'Training and Scholarship Expenses', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (74, 29, '03', 'Supplies and Materials Expenses', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (75, 29, '04', 'Utility Expenses', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (76, 29, '05', 'Communication Expenses', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (77, 29, '06', 'Awards/Rewards and Prizes', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (78, 29, '07', 'Survey, Research, Exploration and Development Expenses', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (79, 29, '08', 'Demolition/Relocation and Desilting/Dredging Expenses', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (80, 29, '09', 'Generation, Transmission and Distribution Expenses', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (81, 29, '10', 'Confidential, Intelligence and Extraordinary Expenses', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (82, 29, '11', 'Professional Services', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (83, 29, '12', 'General Services', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (84, 29, '13', 'Repairs and Maintenance', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (85, 29, '14', 'Financial Assistance/Subsidy', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (86, 29, '15', 'Transfers', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (87, 29, '16', 'Taxes, Insurance Premiums and Other Fees', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (88, 29, '99', 'Other Maintenance and Operating Expenses', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (89, 30, '01', 'Financial Expenses', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (90, 31, '01', 'Cost of Goods Manufactured', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (91, 31, '02', 'Cost of Sales', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (92, 32, '01', 'Depreciation', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (93, 32, '02', 'Amortization', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (94, 32, '03', 'Impairment Loss', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (95, 32, '04', 'Losses', '2021-07-05 23:26:15', NULL);
INSERT INTO `lfs_db`.`sub_major_account_group` (`id`, `major_account_group_id`, `sub_maj_acc_group_code`, `sub_maj_acc_group_name`, `created_at`, `updated_at`) VALUES (96, 32, '05', 'Grants', '2021-07-05 23:26:15', NULL);

COMMIT;


-- -----------------------------------------------------
-- Data for table `lfs_db`.`general_ledger_accounts`
-- -----------------------------------------------------
START TRANSACTION;
USE `lfs_db`;
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (1, 1, '010', 'Cash Local Treasury', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (2, 1, '020', 'Petty Cash', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (3, 2, '010', 'Cash in Bank - Local Currency, Current Account', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (4, 2, '020', 'Cash in Bank - Local Currency, Savings Account', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (5, 3, '010', 'Cash in Bank - Foreign Currency, Current Account', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (6, 3, '020', 'Cash in Bank - Foreign Currency, Savings Account', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (7, 4, '010', 'Cash in Bank - Local Currency, Time Deposits', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (8, 4, '020', 'Cash in Bank - Foreign Currency, Time Deposits', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (9, 4, '030', 'Treasury Bills', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (10, 5, '010', 'Financial Assets Held for Trading', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (11, 5, '020', 'Financial Assets Designated at Fair Value Through Surplus or\nDeficit', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (12, 6, '010', 'Investments in Treasury Bills - Local', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (13, 6, '011', 'Allowance for Impairment - Investments in Treasury Bills - Local', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (14, 6, '020', 'Investments in Bonds-Local', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (15, 6, '021', 'Allowance for Impairment - Investments in Bonds - Local', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (16, 7, '010', 'Investments in Stocks', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (17, 7, '020', 'Investments in Bonds', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (18, 8, '010', 'Deposits on Letters of Credit', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (19, 8, '011', 'Allowance for Impairment - Deposits in Letters of Credit', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (20, 8, '020', 'Guaranty Deposits', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (21, 8, '021', 'Allowance for Impairment - Guaranty Deposits', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (22, 8, '990', 'Other Investments', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (23, 8, '991', 'Allowance for Impairment - Other Investments', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (24, 9, '010', 'Investments in Joint Venture', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (25, 9, '011', 'Allowance for Impairment - Investments in Joint Venture', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (26, 10, '010', 'Sinking Fund', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (27, 11, '010', 'Accounts Receivable', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (28, 11, '011', 'Allowance for Impairment - Accounts Receivable', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (29, 11, '020', 'Real Property Tax Receivable', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (30, 11, '021', 'Allowance for Impairment - RPT Receivable', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (31, 11, '030', 'Special Education Tax Receivable', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (32, 11, '031', 'Allowance for Impairment - SET Receivable', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (33, 11, '040', 'Notes Receivable', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (34, 11, '041', 'Allowance for Impairment - Notes Receivable', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (35, 11, '050', 'Loans Receivable - Government-Owned and/or Controlled Corporations', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (36, 11, '051', 'Allowance for Impairment - Loans Receivable - Government-Owned\nand/or Controlled Corporations', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (37, 11, '060', 'Loans Receivable - Local Government Units', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (38, 11, '061', 'Allowance for Impairment - Loans Receivable - Local Government\nUnits', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (39, 11, '070', 'Interests Receivable', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (40, 11, '071', 'Allowance for Impairment - Interests Receivable', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (41, 11, '080', 'Dividends Receivable', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (42, 11, '081', 'Allowance for Impairment - Dividends Receivable', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (43, 11, '990', 'Loans Receivable - Others', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (44, 11, '991', 'Allowance for Impairment - Loans Receivable - Others', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (45, 12, '010', 'Operating Lease Receivable', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (46, 12, '011', 'Allowance for Impairment - Operating Lease Receivable', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (47, 12, '020', 'Finance Lease Receivable', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (48, 12, '021', 'Allowance for Impairment - Finance Lease Receivable', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (49, 13, '010', 'Due from National Government Agencies', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (50, 13, '011', 'Allowance for Impairment - Due from National Government Agencies', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (51, 13, '020', 'Due from Government-Owned and/or Controlled Corporations', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (52, 13, '021', 'Allowance for Impairment - Due from GOCCs', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (53, 13, '030', 'Due from Local Government Units', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (54, 13, '031', 'Allowance for Impairment - Due from LGUs', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (55, 13, '040', 'Due from Joint Venture', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (56, 13, '041', 'Allowance for Impairment - Due from Joint Venture', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (57, 14, '050', 'Due from Other Funds', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (58, 14, '060', 'Due from Special Accounts', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (59, 14, '070', 'Due from Local Economic Enterprise', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (60, 15, '010', 'Advances for Operating Expenses', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (61, 15, '020', 'Advances for Payroll', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (62, 15, '030', 'Advances to Special Disbursing Officer', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (63, 15, '040', 'Advances to Officers and Employees', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (64, 16, '010', 'Receivables - Disallowances/Charges', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (65, 16, '011', 'Allowance for Impairment - Receivables- Disallowances/Charges', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (66, 16, '020', 'Due from Officers and Employees', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (67, 16, '021', 'Allowance for Impairment - Due from Officers and Employees', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (68, 16, '030', 'Due from Non-Government Organizations/People\'s Organizations', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (69, 16, '031', 'Allowance for Impairment - Due from Non-Government Organizations People\'s Organizations', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (70, 16, '990', 'Other Receivables', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (71, 16, '991', 'Allowance for Impairment - Other Receivables', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (72, 17, '010', 'Merchandise Inventory', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (73, 18, '010', 'Food Supplies for Distribution', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (74, 18, '020', 'Welfare Goods for Distribution', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (75, 18, '030', 'Drugs and Medicines for Distribution', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (76, 18, '040', 'Medical, Dental and Laboratory Supplies for Distribution', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (77, 18, '050', 'Agricultural and Marine Supplies for Distribution', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (78, 18, '060', 'Agricultural Produce for Distribution', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (79, 18, '070', 'Textbooks and Instructional Materials for Distribution', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (80, 18, '080', 'Construction Materials for Distribution', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (81, 18, '090', 'Property and Equipment for Distribution', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (82, 18, '990', 'Other Supplies and Materials for Distribution', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (83, 19, '010', 'Raw Materials Inventory', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (84, 19, '020', 'Work-in-Process Inventory', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (85, 19, '030', 'Finished Goods Inventory', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (86, 20, '010', 'Office Supplies Inventory', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (87, 20, '020', 'Accountable Forms, Plates and Stickers', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (88, 20, '030', 'Non-Accountable Forms Inventory', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (89, 20, '040', 'Animal/Zoological Supplies Inventory', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (90, 20, '050', 'Food Supplies Inventory', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (91, 20, '060', 'Drugs and Medicines Inventory', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (92, 20, '070', 'Medical, Dental and Laboratory Supplies Inventory', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (93, 20, '080', 'Fuel, Oil and Lubricants Inventory', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (94, 20, '090', 'Agricultural and Marine Supplies Inventory', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (95, 20, '100', 'Textbooks and Instructional Materials Inventory', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (96, 20, '110', 'Military, Police and Traffic Supplies Inventory', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (97, 20, '120', 'Chemical and Filtering Supplies Inventory', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (98, 20, '130', 'Construction Materials Inventory', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (99, 20, '990', 'Other Supplies and Materials Inventory', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (100, 21, '010', 'Advances to Contractors', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (101, 21, '020', 'Prepaid Rent', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (102, 21, '030', 'Prepaid Registration', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (103, 21, '040', 'Prepaid Interest', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (104, 21, '050', 'Prepaid Insurance', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (105, 21, '990', 'Other Prepayments', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (106, 22, '010', 'Investment Property, Land', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (107, 22, '011', 'Accumulated Impairment Losses - Investment Property, Land', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (108, 22, '020', 'Investment Property, Buildings', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (109, 22, '021', 'Accumulated Depreciation - Investment Property, Buildings', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (110, 22, '022', 'Accumulated Impairment Losses - Investment Property, Buildings', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (111, 22, '030', 'Construction in Progress - Investment Property, Buildings', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (112, 23, '010', 'Land', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (113, 23, '011', 'Accumulated Impairment Losses - Land', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (114, 24, '010', 'Land Improvements, Aquaculture Structures', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (115, 24, '011', 'Accumulated Depreciation - Land Improvements, Aquaculture Structures', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (116, 24, '012', 'Accumulated Impairment Losses - Land Improvements, Aquaculture Structures', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (117, 24, '990', 'Other Land Improvements', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (118, 24, '991', 'Accumulated Depreciation - Other Land Improvements', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (119, 24, '992', 'Accumulated Impairment Losses - Other Land Improvements', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (120, 25, '010', 'Road Networks', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (121, 25, '011', 'Accumulated Depreciation - Road Networks', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (122, 25, '012', 'Accumulated Impairment Losses - Road Networks', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (123, 25, '020', 'Flood Control Systems', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (124, 25, '021', 'Accumulated Depreciation - Flood Control Systems', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (125, 25, '022', 'Accumulated Impairment Losses - Flood Control Systems', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (126, 25, '030', 'Sewer Systems', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (127, 25, '031', 'Accumulated Depreciation - Sewer Systems', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (128, 25, '032', 'Accumulated Impairment Losses - Sewer Systems', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (129, 25, '040', 'Water Supply Systems', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (130, 25, '041', 'Accumulated Depreciation - Water Supply Systems', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (131, 25, '042', 'Accumulated Impairment Losses - Water Supply Systems', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (132, 25, '050', 'Power Supply Systems', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (133, 25, '051', 'Accumulated Depreciation - Power Supply Systems', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (134, 25, '052', 'Accumulated Impairment Losses - Power Supply Systems', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (135, 25, '060', 'Communication Networks', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (136, 25, '061', 'Accumulated Depreciation - Communication Networks', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (137, 25, '062', 'Accumulated Impairment Losses - Communication Networks', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (138, 25, '070', 'Seaport Systems', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (139, 25, '071', 'Accumulated Depreciation - Seaport Systems', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (140, 25, '072', 'Accumulated Impairment Losses - Seaport Systems', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (141, 25, '080', 'Airport Systems', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (142, 25, '081', 'Accumulated Depreciation - Airport Systems', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (143, 25, '082', 'Accumulated Impairment Losses - Airport Systems', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (144, 25, '090', 'Parks, Plazas and Monuments', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (145, 25, '091', 'Accumulated Depreciation - Parks, Plazas and Monuments', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (146, 25, '092', 'Accumulated Impairment Losses - Parks, Plazas and Monuments', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (147, 25, '990', 'Other Infrastructure Assets', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (148, 25, '991', 'Accumulated Depreciation - Other Infrastructure Assets', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (149, 25, '992', 'Accumulated Impairment Losses - Other Infrastructure Assets', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (150, 26, '010', 'Buildings', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (151, 26, '011', 'Accumulated Depreciation - Buildings', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (152, 26, '012', 'Accumulated Impairment Losses - Buildings', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (153, 26, '020', 'School Buildings', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (154, 26, '021', 'Accumulated Depreciation - School Buildings', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (155, 26, '022', 'Accumulated Impairment Losses - School Buildings', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (156, 26, '030', 'Hospitals and Health Centers', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (157, 26, '031', 'Accumulated Depreciation - Hospitals and Health Centers', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (158, 26, '032', 'Accumulated Impairment Losses - Hospitals and Health Centers', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (159, 26, '040', 'Markets', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (160, 26, '041', 'Accumulated Depreciation - Markets', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (161, 26, '042', 'Accumulated Impairment Losses - Markets', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (162, 26, '050', 'Slaughterhouses', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (163, 26, '051', 'Accumulated Depreciation - Slaughterhouses', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (164, 26, '052', 'Accumulated Impairment Losses- Slaughterhouses', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (165, 26, '060', 'Hostels and Dormitories', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (166, 26, '061', 'Accumulated Depreciation - Hostels and Dormitories', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (167, 26, '062', 'Accumulated Impairment Losses - Hostels and Dormitories', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (168, 26, '990', 'Other Structures', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (169, 26, '991', 'Accumulated Depreciation - Other Structures', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (170, 26, '992', 'Accumulated Impairment Losses - Other Structures', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (171, 27, '010', 'Machinery', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (172, 27, '011', 'Accumulated Depreciation - Machinery', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (173, 27, '012', 'Accumulated Impairment Losses - Machinery', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (174, 27, '020', 'Office Equipment', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (175, 27, '021', 'Accumulated Depreciation - Office Equipment', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (176, 27, '022', 'Accumulated Impairment Losses - Office Equipment', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (177, 27, '030', 'Information and Communication Technology Equipment', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (178, 27, '031', 'Accumulated Depreciation - Information and Communication Technology Equipment', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (179, 27, '032', 'Accumulated Impairment Losses - Information and Communication Technology Equipment', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (180, 27, '040', 'Agricultural and Forestry Equipment', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (181, 27, '041', 'Accumulated Depreciation - Agricultural and Forestry Equipment', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (182, 27, '042', 'Accumulated Impairment Losses - Agricultural and Forestry Equipment', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (183, 27, '050', 'Marine and Fishery Equipment', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (184, 27, '051', 'Accumulated Depreciation - Marine and Fishery Equipment', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (185, 27, '052', 'Accumulated Impairment Losses - Marine and Fishery Equipment', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (186, 27, '060', 'Airport Equipment', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (187, 27, '061', 'Accumulated Depreciation - Airport Equipment', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (188, 27, '062', 'Accumulated Impairment Losses - Airport Equipment', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (189, 27, '070', 'Communication Equipment', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (190, 27, '071', 'Accumulated Depreciation - Communication Equipment', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (191, 27, '072', 'Accumulated Impairment Losses - Communication Equipment', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (192, 27, '080', 'Construction and Heavy Equipment', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (193, 27, '081', 'Accumulated Depreciation - Construction and Heavy Equipment', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (194, 27, '082', 'Accumulated Impairment Losses - Construction and Heavy Equipment', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (195, 27, '090', 'Disaster Response and Rescue Equipment', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (196, 27, '091', 'Accumulated Depreciation - Disaster Response and Rescue Equipment', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (197, 27, '092', 'Accumulated Impairment Losses - Disaster Response and Rescue Equipment', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (198, 27, '100', 'Military, Police and Security Equipment', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (199, 27, '101', 'Accumulated Depreciation - Military, Police and Security Equipment', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (200, 27, '102', 'Accumulated Impairment Losses - Military, Police and Security Equipment', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (201, 27, '110', 'Medical Equipment', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (202, 27, '111', 'Accumulated Depreciation - Medical Equipment', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (203, 27, '112', 'Accumulated Impairment Losses - Medical Equipment', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (204, 27, '120', 'Printing Equipment', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (205, 27, '121', 'Accumulated Depreciation - Printing Equipment', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (206, 27, '122', 'Accumulated Impairment Losses - Printing Equipment', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (207, 27, '130', 'Sports Equipment', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (208, 27, '131', 'Accumulated Depreciation - Sports Equipment', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (209, 27, '132', 'Accumulated Impairment Losses - Sports Equipment', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (210, 27, '140', 'Technical and Scientific Equipment', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (211, 27, '141', 'Accumulated Depreciation - Technical and Scientific Equipment', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (212, 27, '142', 'Accumulated Impairment Losses - Technical and Scientific Equipment', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (213, 27, '990', 'Other Machinery and Equipment', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (214, 27, '991', 'Accumulated Depreciation - Other Machinery and Equipment', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (215, 27, '992', 'Accumulated Impairment Losses - Other Machinery and Equipment', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (216, 28, '010', 'Motor Vehicles', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (217, 28, '011', 'Accumulated Depreciation - Motor Vehicles', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (218, 28, '012', 'Accumulated Impairment Losses - Motor Vehicles', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (219, 28, '020', 'Trains', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (220, 28, '021', 'Accumulated Depreciation - Trains', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (221, 28, '022', 'Accumulated Impairment Losses - Trains', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (222, 28, '030', 'Aircrafts and Aircrafts Ground Equipment', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (223, 28, '031', 'Accumulated Depreciation - Aircrafts and Aircrafts Ground Equipment', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (224, 28, '032', 'Accumulated Impairment Losses - Aircrafts and Aircrafts Ground Equipment', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (225, 28, '040', 'Watercrafts', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (226, 28, '041', 'Accumulated Depreciation - Watercrafts', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (227, 28, '042', 'Accumulated Impairment Losses - Watercrafts', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (228, 28, '990', 'Other Transportation Equipment', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (229, 28, '991', 'Accumulated Depreciation - Other Transportation Equipment', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (230, 28, '992', 'Accumulated Impairment Losses - Other Transportation Equipment', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (231, 29, '010', 'Furniture and Fixtures', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (232, 29, '011', 'Accumulated Depreciation - Furniture and Fixtures', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (233, 29, '012', 'Accumulated Impairment Losses - Furniture and Fixtures', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (234, 29, '020', 'Books', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (235, 29, '021', 'Accumulated Depreciation - Books', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (236, 29, '022', 'Accumulated Impairment Losses - Books', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (237, 30, '010', 'Leased Assets, Land', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (238, 30, '011', 'Accumulated Impairment Losses - Leased Assets, Land', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (239, 30, '020', 'Leased Assets, Buildings and Other Structures', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (240, 30, '021', 'Accumulated Depreciation - Leased Assets, Buildings and Other Structures', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (241, 30, '022', 'Accumulated Impairment Losses - Leased Assets, Buildings and Other Structures', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (242, 30, '030', 'Leased Assets, Machinery and Equipment', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (243, 30, '031', 'Accumulated Depreciation - Leased Assets, Machinery and Equipment', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (244, 30, '032', 'Accumulated Impairment Losses - Leased Assets, Machinery and Equipment', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (245, 30, '040', 'Leased Assets, Transportation Equipment', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (246, 30, '041', 'Accumulated Depreciation - Leased Assets, Transportation Equipment', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (247, 30, '042', 'Accumulated Impairment Losses - Leased Assets, Transportation Equipment', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (248, 30, '990', 'Other Leased Assets', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (249, 30, '991', 'Accumulated Depreciation - Other Leased Assets', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (250, 30, '992', 'Accumulated Impairment Losses - Other Leased Assets', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (251, 31, '010', 'Leased Assets Improvements, Land', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (252, 31, '011', 'Accumulated Depreciation - Leased Assets Improvements, Land', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (253, 31, '012', 'Accumulated Impairment Losses - Leased Assets Improvements, Land', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (254, 31, '020', 'Leased Assets Improvements, Buildings', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (255, 31, '021', 'Accumulated Depreciation - Leased Assets Improvements, Buildings', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (256, 31, '022', 'Accumulated Impairment Losses - Leased Assets Improvements, Buildings', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (257, 31, '990', 'Other Leased Assets Improvements', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (258, 31, '991', 'Accumulated Depreciation - Other Leased Assets Improvements', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (259, 31, '992', 'Accumulated Impairment Losses - Other Leased Assets Improvements', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (260, 32, '010', 'Construction in Progress - Land Improvements', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (261, 32, '020', 'Construction in Progress - Infrastructure Assets', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (262, 32, '030', 'Construction in Progress - Buildings and Other Structures', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (263, 32, '040', 'Construction in Progress - Leased Assets', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (264, 32, '050', 'Construction in Progress - Leased Assets Improvements', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (265, 33, '010', 'Service Concession Assets', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (266, 33, '011', 'Accumulated Depreciation - Service Concession Assets', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (267, 33, '012', 'Accumulated Impairment Losses - Service Concession Assets', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (268, 34, '010', 'Work/Zoo Animals', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (269, 34, '011', 'Accumulated Depreciation - Work/Zoo Animals', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (270, 34, '012', 'Accumulated Impairment Losses - Work/Zoo Animals', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (271, 34, '990', 'Other Property, Plant and Equipment', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (272, 34, '991', 'Accumulated Depreciation - Other Property, Plant and Equipment', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (273, 34, '992', 'Accumulated Impairment Losses - Other Property, Plant and Equipment', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (274, 35, '010', 'Breeding Stocks', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (275, 35, '020', 'Plants and Trees', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (276, 35, '030', 'Aquaculture', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (277, 35, '990', 'Other Bearer Biological Assets', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (278, 36, '010', 'Patents/Copyrights', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (279, 36, '011', 'Accumulated Amortization - Patents/Copyrights', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (280, 36, '012', 'Accumulated Impairment Losses - Patents/Copyrights', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (281, 36, '020', 'Computer Software', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (282, 36, '021', 'Accumulated Amortization - Computer Software', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (283, 36, '022', 'Accumulated Impairment Losses - Computer Software', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (284, 36, '990', 'Other Intangible Assets', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (285, 36, '991', 'Accumulated Amortization - Other Intangible Assets', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (286, 36, '992', 'Accumulated Impairment Losses - Other Intangible Assets', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (287, 37, '010', 'Service Concession Assets - Intangible Assets', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (288, 38, '010', 'Accounts Payable', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (289, 38, '020', 'Due to Officers and Employees', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (290, 38, '040', 'Notes Payable', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (291, 38, '050', 'Interest Payable', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (292, 38, '060', 'Operating Lease Payable', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (293, 38, '070', 'Finance Lease Payable', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (294, 38, '080', 'Awards and Rewards Payable', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (295, 38, '090', 'Service Concession Arrangement Payable', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (296, 38, '100', 'Pension Benefits Payable', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (297, 38, '110', 'Leave Benefits Payable', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (298, 38, '120', 'Retirement Gratuity Payable', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (299, 39, '020', 'Bonds Payable - Domestic', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (300, 39, '021', 'Discount on Bonds Payable - Domestic', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (301, 39, '022', 'Premium on Bonds Payable - Domestic', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (302, 39, '040', 'Loans Payable - Domestic', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (303, 39, '050', 'Loans Payable - Foreign', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (304, 40, '010', 'Due to BIR', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (305, 40, '020', 'Due to GSIS', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (306, 40, '030', 'Due to Pag-IBIG', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (307, 40, '040', 'Due to PhilHealth', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (308, 40, '050', 'Due to NGAs', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (309, 40, '060', 'Due to GOCCs', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (310, 40, '070', 'Due to LGUs', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (311, 40, '080', 'Due to Joint Venture', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (312, 41, '010', 'Due to Other Funds', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (313, 41, '020', 'Due to Special Accounts', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (314, 41, '030', 'Due to Local Economic Enterprises', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (315, 42, '010', 'Trust Liabilities', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (316, 42, '020', 'Trust Liabilities - Disaster Risk Reduction and Management Fund', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (317, 42, '030', 'Bail Bonds Payable', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (318, 42, '040', 'Guaranty/Security Deposits Payable', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (319, 42, '050', 'Customers\' Deposits Payable', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (320, 43, '010', 'Deferred Real Property Tax', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (321, 43, '011', 'Discount on Advance Payment of Real Property Tax', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (322, 43, '020', 'Deferred Special Education Tax', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (323, 43, '021', 'Discount on Advance Payment of Special Education Tax', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (324, 43, '030', 'Deferred Finance Lease Revenue', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (325, 43, '040', 'Deferred Service Concession Revenue', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (326, 43, '050', 'Unearned Revenue - Investment Property', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (327, 43, '990', 'Other Deferred Credits', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (328, 44, '040', 'Termination Benefits', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (329, 44, '990', 'Other Provisions', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (330, 45, '990', 'Other Payables', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (331, 46, '010', 'Government Equity', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (332, 46, '020', 'Prior Period Adjustment', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (333, 47, '010', 'Income and Expense Summary', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (334, 48, '010', 'Equity in Joint Venture', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (335, 49, '010', 'Unrealized Gain/(Loss) from Changes in the Fair Value of Financial Assets', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (336, 50, '010', 'Fund Balance', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (337, 50, '020', 'Unappropriated Surplus', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (338, 50, '030', 'Continuing Allotment', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (339, 50, '040', 'Continuing Appropriations', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (340, 50, '050', 'Commitments', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (341, 51, '010', 'Estimates of Income, Revenues and Receipts', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (342, 51, '020', 'Estimates-Internal Sources', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (343, 51, '030', 'Estimates-External Sources', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (344, 51, '040', 'Realized Income Revenues and Receipts', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (345, 51, '050', 'Appropriations - Annual Budget', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (346, 51, '060', 'Appropriations - Supplemental Budget', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (347, 51, '070', 'Legislative Appropriations', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (348, 51, '080', 'Released Current Allotments', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (349, 51, '090', 'Current Allotment', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (350, 51, '100', 'Released Continuing Allotment', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (351, 52, '010', 'Current Allotments - Obligated', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (352, 52, '020', 'Obligations-Current Allotment', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (353, 52, '030', 'Continuing Allotments - Obligated', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (354, 52, '040', 'Obligations-Continuing Allotmen', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (355, 52, '050', 'Current Allotments - Obligations Consummated', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (356, 52, '060', 'Continuing Allotments - Obligations Consummated', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (357, 52, '070', 'Consummated Obligations', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (358, 53, '010', 'Reversion of Unallotted CY Appropriations', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (359, 53, '020', 'Reversion of Unobligated CY Allotments', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (360, 53, '030', 'Reversion of Unutilized Continuing Appropriations and Allotments', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (361, 54, '020', 'Professional Tax', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (362, 54, '050', 'Community Tax', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (363, 55, '040', 'Real Property Tax- Basic', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (364, 55, '041', 'Discount on Real Property Tax- Basic', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (365, 55, '050', 'Special Education Tax', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (366, 55, '051', 'Discount on Special Education Tax', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (367, 55, '060', 'Special Levy on Idle Lands', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (368, 55, '070', 'Special Levy on Lands Benefited by Public Works Projects', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (369, 55, '080', 'Real Property Transfer Tax', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (370, 56, '030', 'Business Tax', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (371, 56, '040', 'Tax on Sand, Gravel and Other Quarry Products', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (372, 56, '050', 'Tax on Delivery Trucks and Vans', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (373, 56, '060', 'Amusement Tax', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (374, 56, '070', 'Franchise Tax', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (375, 56, '080', 'Printing and Publication Tax', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (376, 57, '990', 'Other Taxes', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (377, 58, '010', 'Tax Revenue - Fines and Penalties - Taxes on Individual and Corporation', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (378, 58, '020', 'Tax Revenue - Fines and Penalties - Property Taxes', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (379, 58, '030', 'Tax Revenue - Fines and Penalties - Taxes on Goods and Services', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (380, 58, '040', 'Tax Revenue - Fines and Penalties - Other Taxes', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (381, 59, '010', 'Share from Internal Revenue Collections (IRA)', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (382, 59, '020', 'Share from Expanded Value Added Tax', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (383, 59, '030', 'Share from National Wealth', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (384, 59, '040', 'Share from Tobacco Excise Tax (RA 7171 and 8240)', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (385, 59, '050', 'Share from Economic Zones', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (386, 60, '010', 'Permit Fees', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (387, 60, '020', 'Registration Fees', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (388, 60, '030', 'Registration Plates, Tags and Stickers Fees', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (389, 60, '040', 'Clearance and Certification Fees', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (390, 60, '070', 'Supervision and Regulation Enforcement Fees', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (391, 60, '100', 'Inspection Fees', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (392, 60, '110', 'Verification and Authentication Fees', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (393, 60, '130', 'Processing Fees', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (394, 60, '140', 'Occupation Fees', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (395, 60, '150', 'Fishery Rentals, Fees and Charges', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (396, 60, '160', 'Fees for Sealing and Licensing of Weights and Measures', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (397, 60, '980', 'Fines and Penalties - Service Income', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (398, 60, '990', 'Other Service Income', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (399, 61, '010', 'School Fees', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (400, 61, '020', 'Affiliation Fees', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (401, 61, '040', 'Seminar/Training Fees', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (402, 61, '050', 'Rent Income', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (403, 61, '060', 'Communication Network Fees', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (404, 61, '070', 'Transportation System Fees', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (405, 61, '080', 'Road Network Fees', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (406, 61, '090', 'Waterworks System Fees', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (407, 61, '100', 'Power Supply System Fees', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (408, 61, '110', 'Seaport System Fees', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (409, 61, '120', 'Parking Fees', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (410, 61, '130', 'Receipts from Operation of Hostels/Dormitories and Other Like Facilities', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (411, 61, '140', 'Receipts from Market Operations', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (412, 61, '150', 'Receipts from Slaughterhouse Operations', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (413, 61, '160', 'Receipts from Cemetery Operations', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (414, 61, '170', 'Receipts from Printing and Publication', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (415, 61, '180', 'Sales Revenue', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (416, 61, '181', 'Sales Discounts', 1, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (417, 61, '190', 'Garbage Fees', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (418, 61, '200', 'Hospital Fees', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (419, 61, '210', 'Dividend Income', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (420, 61, '220', 'Interest Income', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (421, 61, '230', 'Service Concession Revenue', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (422, 61, '240', 'Other Service Concession Revenue', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (423, 61, '250', 'Finance Lease Revenue', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (424, 61, '260', 'Share in the Profit of Joint Venture', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (425, 61, '980', 'Fines and Penalties - Business Income', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (426, 61, '990', 'Other Business Income', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (427, 62, '010', 'Subsidy from National Government', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (428, 62, '020', 'Subsidy from Other Local Government Units', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (429, 62, '030', 'Subsidy from Government-Owned and/or Controlled Corporations', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (430, 62, '040', 'Subsidy from Other Funds', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (431, 62, '050', 'Subsidy from General Fund Proper/Other Special Accounts', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (432, 62, '060', 'Subsidy from Other Local Economic Enterprise/Public Utility', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (433, 63, '010', 'Transfers from General Fund of LGU Counterpart/Equity Share', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (434, 63, '020', 'Transfers from General Fund of Unspent DRRMF', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (435, 63, '030', 'Transfers from National Government', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (436, 63, '040', 'Transfers from Other Local Government Units', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (437, 63, '050', 'Transfers from Government-Owned and/or Controlled Corporations', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (438, 64, '010', 'Share from PAGCOR', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (439, 64, '020', 'Share from PCSO', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (440, 65, '010', 'Grants and Donations in Cash', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (441, 65, '020', 'Grants and Donations in Kind', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (442, 65, '030', 'Grants from Concessionary loans', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (443, 66, '010', 'Gain from Changes in Fair Value of Financial Instruments', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (444, 66, '020', 'Gain on Foreign Exchange (FOREX)', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (445, 66, '030', 'Gain on Sale of Investments', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (446, 66, '040', 'Gain on Sale of Investment Property', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (447, 66, '050', 'Gain on Sale of Property, Plant and Equipment', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (448, 66, '060', 'Gain on Initial Recognition of Biological Assets', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (449, 66, '070', 'Gain on Sale of Biological Assets', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (450, 66, '080', 'Gain from Changes in Fair Value Less Cost to Sell of Biological Assets Due to Physical Change', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (451, 66, '090', 'Gain from Changes in Fair Value Less Cost to Sell of Biological Assets Due to Price Change', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (452, 66, '100', 'Gain from Initial Recognition of Agricultural Produce', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (453, 66, '110', 'Gain on Sale of Intangible Assets', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (454, 66, '120', 'Reversal of Impairment Losses', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (455, 66, '990', 'Other Gains', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (456, 67, '110', 'Miscellaneous Income', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (457, 68, '010', 'Salaries and Wages - Regular', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (458, 68, '020', 'Salaries and Wages - Casual/Contractual', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (459, 69, '010', 'Personnel Economic Relief Allowance (PERA)', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (460, 69, '020', 'Representation Allowance (RA)', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (461, 69, '030', 'Transportation Allowance (TA)', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (462, 69, '040', 'Clothing/Uniform Allowance', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (463, 69, '050', 'Subsistence Allowance', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (464, 69, '060', 'Laundry Allowance', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (465, 69, '070', 'Quarters Allowance', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (466, 69, '080', 'Productivity Incentive Allowance', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (467, 69, '090', 'Overseas Allowance', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (468, 69, '100', 'Honoraria', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (469, 69, '110', 'Hazard Pay', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (470, 69, '120', 'Longevity Pay', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (471, 69, '130', 'Overtime and Night Pay', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (472, 69, '140', 'Year End Bonus', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (473, 69, '150', 'Cash Gift', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (474, 69, '990', 'Other Bonuses and Allowances', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (475, 70, '010', 'Retirement and Life Insurance Premiums', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (476, 70, '020', 'Pag-IBIG Contributions', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (477, 70, '030', 'PhilHealth Contributions', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (478, 70, '040', 'Employees Compensation Insurance Premiums', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (479, 70, '050', 'Provident/Welfare Fund Contributions', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (480, 71, '010', 'Pension Benefits', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (481, 71, '020', 'Retirement Gratuity', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (482, 71, '030', 'Terminal Leave Benefits', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (483, 71, '990', 'Other Personnel Benefits', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (484, 72, '010', 'Traveling Expenses - Local', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (485, 72, '020', 'Traveling Expenses - Foreign', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (486, 73, '010', 'Training Expenses', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (487, 73, '020', 'Scholarship Grants/Expenses', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (488, 74, '010', 'Office Supplies Expenses', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (489, 74, '020', 'Accountable Forms Expenses', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (490, 74, '030', 'Non-Accountable Forms Expenses', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (491, 74, '040', 'Animal/Zoological Supplies Expenses', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (492, 74, '050', 'Food Supplies Expenses', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (493, 74, '060', 'Welfare Goods Expenses', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (494, 74, '070', 'Drugs and Medicines Expenses', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (495, 74, '080', 'Medical, Dental and Laboratory Supplies Expenses', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (496, 74, '090', 'Fuel, Oil and Lubricants Expenses', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (497, 74, '100', 'Agricultural and Marine Supplies Expenses', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (498, 74, '110', 'Textbooks and Instructional Materials Expenses', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (499, 74, '120', 'Military, Police and Traffic Supplies Expenses', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (500, 74, '130', 'Chemical and Filtering Supplies Expenses', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (501, 74, '990', 'Other Supplies and Materials Expenses', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (502, 75, '010', 'Water Expenses', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (503, 75, '020', 'Electricity Expenses', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (504, 76, '010', 'Postage and Courier Services', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (505, 76, '020', 'Telephone Expenses', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (506, 76, '030', 'Internet Subscription Expenses', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (507, 76, '040', 'Cable, Satellite, Telegraph and Radio Expenses', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (508, 77, '010', 'Awards/Rewards Expenses', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (509, 77, '020', 'Prizes', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (510, 78, '010', 'Survey Expenses', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (511, 78, '020', 'Research, Exploration and Development Expenses', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (512, 79, '010', 'Demolition and Relocation Expenses', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (513, 79, '020', 'Desilting and Dredging Expenses', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (514, 80, '010', 'Generation, Transmission and Distribution Expenses', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (515, 81, '010', 'Confidential Expenses', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (516, 81, '020', 'ntelligence Expenses', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (517, 81, '030', 'Extraordinary and Miscellaneous Expenses', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (518, 82, '110', 'Legal Services', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (519, 82, '020', 'Auditing Services', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (520, 82, '030', 'Consultancy Services', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (521, 82, '990', 'Other Professional Services', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (522, 83, '010', 'Environment/Sanitary Services', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (523, 83, '020', 'Janitorial Services', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (524, 83, '030', 'Security Services', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (525, 83, '990', 'Other General Services', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (526, 84, '010', 'Repairs and Maintenance - Investment Property', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (527, 84, '020', 'Repairs and Maintenance - Land Improvements', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (528, 84, '030', 'Repairs and Maintenance - Infrastructure Assets', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (529, 84, '040', 'Repairs and Maintenance - Buildings and Other Structures', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (530, 84, '050', 'Repairs and Maintenance - Machinery and Equipment', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (531, 84, '060', 'Repairs and Maintenance - Transportation Equipment', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (532, 84, '070', 'Repairs and Maintenance - Furniture and Fixtures', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (533, 84, '080', 'Repairs and Maintenance - Leased Assets', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (534, 84, '090', 'Repairs and Maintenance - Leased Assets Improvements', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (535, 84, '990', 'Repairs and Maintenance - Other Property, Plant and Equipment', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (536, 85, '020', 'Subsidy to National Government Agencies', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (537, 85, '030', 'Subsidy to Other Local Government Units', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (538, 85, '060', 'Subsidy to Other Funds', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (539, 85, '070', 'Subsidy to General Fund Proper/Special Accounts', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (540, 85, '080', 'Subsidy to Local Economic Enterprises/Public Utilities', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (541, 85, '990', 'Subsidies - Others', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (542, 86, '010', 'Transfers of Unspent Current Year DRRM Funds to the Trust Fund', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (543, 86, '020', 'Transfers for Project Equity Share /LGU Counterpart', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (544, 87, '010', 'Taxes, Duties and Licenses', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (545, 87, '020', 'Fidelity Bond Premiums', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (546, 87, '030', 'Insurance Expenses', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (547, 88, '010', 'Advertising Expenses', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (548, 88, '020', 'Printing and Publication Expenses', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (549, 88, '030', 'Representation Expenses', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (550, 88, '040', 'Transportation and Delivery Expenses', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (551, 88, '050', 'Rent Expenses', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (552, 88, '060', 'Membership Dues and Contributions to Organizations', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (553, 88, '070', 'Subscription Expenses', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (554, 88, '080', 'Donations', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (555, 88, '990', 'Other Maintenance and Operating Expenses', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (556, 89, '010', 'Management Supervision/Trusteeship Fees', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (557, 89, '020', 'Interest Expenses', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (558, 89, '030', 'Guarantee Fees', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (559, 89, '040', 'Bank Charges', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (560, 89, '050', 'Commitment Fees', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (561, 89, '990', 'Other Financial Charges', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (562, 90, '010', 'Direct Materials', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (563, 90, '020', 'Direct Labor', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (564, 90, '030', 'Manufacturing Overhead', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (565, 91, '010', 'Cost of Sales', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (566, 92, '010', 'Depreciation - Investment Property', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (567, 92, '020', 'Depreciation - Land Improvements', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (568, 92, '030', 'Depreciation - Infrastructure Assets', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (569, 92, '040', 'Depreciation - Buildings and Other Structures', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (570, 92, '050', 'Depreciation - Machinery and Equipment', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (571, 92, '060', 'Depreciation - Transportation Equipment', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (572, 92, '070', 'Depreciation - Furniture, Fixtures and Books', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (573, 92, '080', 'Depreciation - Leased Assets', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (574, 92, '090', 'Depreciation - Leased Assets Improvements', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (575, 92, '100', 'Depreciation -Service Concession Assets', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (576, 92, '990', 'Depreciation - Other Property, Plant and Equipment', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (577, 93, '010', 'Amortization - Intangible Assets', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (578, 94, '010', 'Impairment Loss - Financial Assets Held to Maturity', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (579, 94, '020', 'Impairment Loss - Loans and Receivables', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (580, 94, '030', 'Impairment Loss - Lease Receivables', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (581, 94, '040', 'Impairment Loss - Investments in GOCCs', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (582, 94, '050', 'Impairment Loss - Investments in Joint Venture', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (583, 94, '060', 'Impairment Loss - Other Receivables', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (584, 94, '070', 'Impairment Loss - Investment Property', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (585, 94, '080', 'Impairment Loss - Property, Plant and Equipment', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (586, 94, '090', 'Impairment Loss - Intangible Assets', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (587, 95, '010', 'Loss on Foreign Exchange (FOREX)', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (588, 95, '020', 'Loss on Sale of Investments', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (589, 95, '030', 'Loss on Sale of Investment Property', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (590, 95, '040', 'Loss on Sale of Property, Plant and Equipment', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (591, 95, '050', 'Loss on Sale of Biological Assets', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (592, 95, '060', 'Loss on Sale of Intangible Assets', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (593, 95, '070', 'Loss on Sale of Assets', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (594, 95, '080', 'Loss on Initial Recognition of Biological Assets', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (595, 95, '090', 'Loss of Assets', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (596, 95, '100', 'Loss on Guaranty', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (597, 95, '110', 'Loss from Changes in Fair Value of Financial Instruments', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (598, 95, '990', 'Other Losses', 0, DEFAULT, NULL);
INSERT INTO `lfs_db`.`general_ledger_accounts` (`id`, `sub_major_account_group_id`, `ledger_code`, `ledger_name`, `is_contra_account`, `created_at`, `updated_at`) VALUES (599, 96, '010', 'Grants for Concessionary Loans', 0, DEFAULT, NULL);

COMMIT;


-- -----------------------------------------------------
-- Data for table `lfs_db`.`permissions`
-- -----------------------------------------------------
START TRANSACTION;
USE `lfs_db`;
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (1, 'Manage > Allotment Classes', 'SysAdmin');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (2, 'Manage > Chart of Accounts', 'All');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (3, 'Manage > Function/Program/Project', 'All');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (4, 'Manage > Funds', 'SysAdmin');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (5, 'Manage > Users', 'All');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (6, 'Manage > Roles', 'All');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (7, 'Manage > Subsidiary Ledger Account', 'All');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (8, 'Dashboard > Budget', 'All');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (9, 'Dashboard > Accounting ', 'All');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (10, 'Dashboard > Treasury ', 'All');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (11, 'Manage > Allotment Releases', 'Budget, Accounting');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (12, 'Manage > Budget Appropriations', 'Budget, Accounting');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (13, 'Transaction > Obligation Request', 'Budget, Accounting');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (14, 'Report > SAAOB', 'Budget, Accounting');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (15, 'Report > SAAOBB', 'Budget, Accounting');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (16, 'Manage > Journals', 'Accounting');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (17, 'Transaction > JEV', 'Accounting');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (18, 'Report > General Journal', 'Accounting');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (19, 'Report > Cash Receipts Journal', 'Accounting');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (20, 'Report > Procurement Received Journal', 'Accounting');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (21, 'Report > Cash Disbursements Journal', 'Accounting');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (22, 'Report > Check Disbursements Journal', 'Accounting');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (23, 'Report > Authority to Debit Account Disbursements Journal', 'Accounting');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (24, 'Report > General Ledger', 'Accounting');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (25, 'Report > Subsidiary Ledger', 'Accounting');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (26, 'Transaction > JEV Approved', 'Accounting');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (27, 'Report > JEVs', 'Accounting');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (28, 'Report > Pre Trial Balance', 'Accounting');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (29, 'Report > Post Trial Balance', 'Accounting');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (30, 'Report > Statement of Financial Position', 'Accounting');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (31, 'Report > Statement of Financial Performance', 'Accounting');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (32, 'Report > Statement of Changes in Net Assets Equity', 'Accounting');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (33, 'Report > Statement of Cash Flows', 'Accounting');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (34, 'Report > Statement of Comparisons of Budget and Actual Amounts', 'Accounting');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (35, 'Transaction > JEV Approval', 'Accounting');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (36, 'Manage > Collecting Officer', 'Accounting, Treasury');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (37, 'Manage > Banks', 'Accounting, Treasury');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (38, 'Manage > Disbursing Officer', 'Accounting, Treasury');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (39, 'Transaction > Issue Check', 'Treasury');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (40, 'Transaction > Payments', 'Treasury');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (41, 'Manage > Accountable Forms', 'Treasury');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (42, 'Transaction > Bank Deposits', 'Treasury');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (43, 'Manage > Receipts', 'Treasury');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (44, 'Transaction > Issue Receipt', 'Treasury');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (45, 'Transaction > Generate RCD', 'Treasury');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (46, 'Report > Report of Checks Issued', 'Treasury');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (47, 'Report > Report of Collections and Deposits', 'Treasury');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (48, 'Report > Abstract of General Collections', 'Treasury');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (49, 'Report > Bank Cashbook', 'Treasury');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (50, 'Report > Consolidated Receipts', 'Treasury');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (51, 'Report > Daily Cash Position', 'Treasury');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (52, 'Manage > Amortization', 'Accounting');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (53, 'Transaction > Edit Approved JEV', 'Accounting');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (54, 'Manage > Signatories', 'All');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (55, 'Transaction > Obligation Request Approval', 'Budget, Accounting');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (56, 'Transaction > Obligation Request Approved', 'Budget, Accounting');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (57, 'Transaction > RCD Approval', 'Treasury');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (58, 'Manage > Returned Receipts', 'Treasury');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (59, 'Report > Collector\'s RCD', 'Treasury');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (60, 'Report > Transaction Log', 'Accounting');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (61, 'Manage > Taxpayers', 'Treasury');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (62, 'Report > Real Property Tax Account Register (RPTAR)', 'Treasury');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (63, 'Report > Consolidated Real Property Tax Dues', 'Treasury');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (64, 'Report > List of Delinquent Accounts', 'Treasury');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (65, 'Report > Tax Due Bill', 'Treasury');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (66, 'Transaction > Assessment Posting', 'Treasury');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (67, 'Manage > Database Synchronization', 'All');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (68, 'Manage > Business Categories', 'Treasury');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (69, 'Manage > Business Add-on Charges', 'Treasury');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (70, 'Manage > Barangays', 'Treasury');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (71, 'Manage > Bank Accounts', 'Treasury');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (72, 'Report > Summary Subsidiary Ledger', 'Accounting');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (73, 'Report > Schedule of Released Cheques', 'Treasury');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (74, 'Report > Schedule of Unreleased Cheques', 'Treasury');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (75, 'Manage > Tax Types', 'Treasury');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (76, 'Manage > Other Payment Rates', 'Treasury');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (77, 'Transaction > Release / Unreleased Checks', 'Treasury');
INSERT INTO `lfs_db`.`permissions` (`id`, `permission_name`, `permission_office`) VALUES (78, 'Manage > Real Properties', 'Treasury');

COMMIT;


-- -----------------------------------------------------
-- Data for table `lfs_db`.`documents`
-- -----------------------------------------------------
START TRANSACTION;
USE `lfs_db`;
INSERT INTO `lfs_db`.`documents` (`id`, `name`, `office`) VALUES (1, 'Journal Entry Voucher', 'Accounting');
INSERT INTO `lfs_db`.`documents` (`id`, `name`, `office`) VALUES (2, 'General Journal', 'Accounting');
INSERT INTO `lfs_db`.`documents` (`id`, `name`, `office`) VALUES (3, 'Cash Receipts Journal', 'Accounting');
INSERT INTO `lfs_db`.`documents` (`id`, `name`, `office`) VALUES (4, 'Procurement Received Journal', 'Accounting');
INSERT INTO `lfs_db`.`documents` (`id`, `name`, `office`) VALUES (5, 'Cash Disbursements Journal', 'Accounting');
INSERT INTO `lfs_db`.`documents` (`id`, `name`, `office`) VALUES (6, 'Check Disbursements Journal', 'Accounting');
INSERT INTO `lfs_db`.`documents` (`id`, `name`, `office`) VALUES (7, 'ADA Disbursements Journal', 'Accounting');
INSERT INTO `lfs_db`.`documents` (`id`, `name`, `office`) VALUES (8, 'Pre Trial Balance', 'Accounting');
INSERT INTO `lfs_db`.`documents` (`id`, `name`, `office`) VALUES (9, 'Post Trial Balance', 'Accounting');
INSERT INTO `lfs_db`.`documents` (`id`, `name`, `office`) VALUES (10, 'Statement of Financial Position', 'Accounting');
INSERT INTO `lfs_db`.`documents` (`id`, `name`, `office`) VALUES (11, 'Statement of Financial Performance', 'Accounting');
INSERT INTO `lfs_db`.`documents` (`id`, `name`, `office`) VALUES (12, 'Statement of Changes in Assets/Equity', 'Accounting');
INSERT INTO `lfs_db`.`documents` (`id`, `name`, `office`) VALUES (13, 'Statement of Cash Flows', 'Accounting');
INSERT INTO `lfs_db`.`documents` (`id`, `name`, `office`) VALUES (14, 'Statement of Comparisons of Budget and Actual Amounts', 'Accounting');
INSERT INTO `lfs_db`.`documents` (`id`, `name`, `office`) VALUES (15, 'SAAOB ', 'Budget, Accounting');
INSERT INTO `lfs_db`.`documents` (`id`, `name`, `office`) VALUES (16, 'SAAOBB', 'Budget, Accounting');
INSERT INTO `lfs_db`.`documents` (`id`, `name`, `office`) VALUES (17, 'Report of Check Issued', 'Treasury');
INSERT INTO `lfs_db`.`documents` (`id`, `name`, `office`) VALUES (18, 'Report of Collections and Deposits', 'Treasury');
INSERT INTO `lfs_db`.`documents` (`id`, `name`, `office`) VALUES (19, 'Report of General Collections ', 'Treasury');
INSERT INTO `lfs_db`.`documents` (`id`, `name`, `office`) VALUES (20, 'Consolidated Report of Accountability for Accountable Forms', 'Treasury');
INSERT INTO `lfs_db`.`documents` (`id`, `name`, `office`) VALUES (21, 'Daily Cash Position Report', 'Treasury');
INSERT INTO `lfs_db`.`documents` (`id`, `name`, `office`) VALUES (22, 'Real Property Tax Due Bill', 'Treasury');
INSERT INTO `lfs_db`.`documents` (`id`, `name`, `office`) VALUES (23, 'Schedule of Released Checks', 'Treasury');
INSERT INTO `lfs_db`.`documents` (`id`, `name`, `office`) VALUES (24, 'Schedule of Unreleased Checks', 'Treasury');

COMMIT;


-- -----------------------------------------------------
-- Data for table `lfs_db`.`document_references`
-- -----------------------------------------------------
START TRANSACTION;
USE `lfs_db`;
INSERT INTO `lfs_db`.`document_references` (`id`, `documents_id`, `name`) VALUES (1, 1, 'Certified Correct');
INSERT INTO `lfs_db`.`document_references` (`id`, `documents_id`, `name`) VALUES (2, 2, 'Certified Correct');
INSERT INTO `lfs_db`.`document_references` (`id`, `documents_id`, `name`) VALUES (3, 3, 'Certified Correct');
INSERT INTO `lfs_db`.`document_references` (`id`, `documents_id`, `name`) VALUES (4, 4, 'Certified Correct');
INSERT INTO `lfs_db`.`document_references` (`id`, `documents_id`, `name`) VALUES (5, 5, 'Certified Correct');
INSERT INTO `lfs_db`.`document_references` (`id`, `documents_id`, `name`) VALUES (6, 6, 'Certified Correct');
INSERT INTO `lfs_db`.`document_references` (`id`, `documents_id`, `name`) VALUES (7, 7, 'Certified Correct');
INSERT INTO `lfs_db`.`document_references` (`id`, `documents_id`, `name`) VALUES (8, 8, 'Certified Correct');
INSERT INTO `lfs_db`.`document_references` (`id`, `documents_id`, `name`) VALUES (9, 9, 'Certified Correct');
INSERT INTO `lfs_db`.`document_references` (`id`, `documents_id`, `name`) VALUES (10, 11, 'Certified Correct');
INSERT INTO `lfs_db`.`document_references` (`id`, `documents_id`, `name`) VALUES (11, 12, 'Certified Correct');
INSERT INTO `lfs_db`.`document_references` (`id`, `documents_id`, `name`) VALUES (12, 15, 'Certified Correct');
INSERT INTO `lfs_db`.`document_references` (`id`, `documents_id`, `name`) VALUES (13, 16, 'Certified Correct');
INSERT INTO `lfs_db`.`document_references` (`id`, `documents_id`, `name`) VALUES (14, 17, 'Department Head');
INSERT INTO `lfs_db`.`document_references` (`id`, `documents_id`, `name`) VALUES (15, 17, 'Administrative Officer');
INSERT INTO `lfs_db`.`document_references` (`id`, `documents_id`, `name`) VALUES (16, 18, 'Verification and Acknowledgement');
INSERT INTO `lfs_db`.`document_references` (`id`, `documents_id`, `name`) VALUES (17, 19, 'Certified Correct');
INSERT INTO `lfs_db`.`document_references` (`id`, `documents_id`, `name`) VALUES (18, 20, 'Treasurer');
INSERT INTO `lfs_db`.`document_references` (`id`, `documents_id`, `name`) VALUES (19, 20, 'Certified Correct');
INSERT INTO `lfs_db`.`document_references` (`id`, `documents_id`, `name`) VALUES (20, 21, 'Prepared by');
INSERT INTO `lfs_db`.`document_references` (`id`, `documents_id`, `name`) VALUES (21, 21, 'Certified Correct');
INSERT INTO `lfs_db`.`document_references` (`id`, `documents_id`, `name`) VALUES (22, 21, 'Noted');
INSERT INTO `lfs_db`.`document_references` (`id`, `documents_id`, `name`) VALUES (23, 13, 'Certified Correct');
INSERT INTO `lfs_db`.`document_references` (`id`, `documents_id`, `name`) VALUES (26, 22, 'Checked By');
INSERT INTO `lfs_db`.`document_references` (`id`, `documents_id`, `name`) VALUES (27, 22, 'Certified Correct');
INSERT INTO `lfs_db`.`document_references` (`id`, `documents_id`, `name`) VALUES (28, 23, 'Certified Correct');
INSERT INTO `lfs_db`.`document_references` (`id`, `documents_id`, `name`) VALUES (29, 23, 'Received By');
INSERT INTO `lfs_db`.`document_references` (`id`, `documents_id`, `name`) VALUES (30, 24, 'Certified Correct');
INSERT INTO `lfs_db`.`document_references` (`id`, `documents_id`, `name`) VALUES (31, 24, 'Received By');

COMMIT;


-- -----------------------------------------------------
-- Data for table `lfs_db`.`role_has_permissions`
-- -----------------------------------------------------
START TRANSACTION;
USE `lfs_db`;
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (1, 1, 1);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (2, 1, 2);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (3, 1, 3);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (4, 1, 4);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (5, 1, 5);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (6, 1, 6);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (7, 1, 7);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (8, 1, 8);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (9, 1, 9);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (10, 1, 10);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (11, 1, 11);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (12, 1, 12);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (13, 1, 13);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (14, 1, 14);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (15, 1, 15);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (16, 1, 16);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (17, 1, 17);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (18, 1, 18);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (19, 1, 19);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (20, 1, 20);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (21, 1, 21);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (22, 1, 22);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (23, 1, 23);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (24, 1, 24);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (25, 1, 25);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (26, 1, 26);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (27, 1, 27);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (28, 1, 28);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (29, 1, 29);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (30, 1, 30);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (31, 1, 31);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (32, 1, 32);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (33, 1, 33);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (34, 1, 34);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (35, 1, 35);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (36, 1, 36);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (37, 1, 37);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (38, 1, 38);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (39, 1, 39);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (40, 1, 40);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (41, 1, 41);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (42, 1, 42);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (43, 1, 43);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (44, 1, 44);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (45, 1, 45);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (46, 1, 46);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (47, 1, 47);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (48, 1, 48);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (49, 1, 49);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (50, 1, 50);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (51, 1, 51);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (52, 1, 52);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (53, 1, 53);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (54, 1, 54);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (55, 1, 55);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (56, 1, 56);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (57, 1, 57);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (58, 1, 58);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (59, 1, 59);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (60, 1, 60);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (61, 1, 61);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (62, 1, 62);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (63, 1, 63);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (64, 1, 64);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (65, 1, 65);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (66, 1, 66);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (67, 1, 67);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (68, 1, 68);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (69, 1, 69);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (70, 1, 70);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (71, 1, 71);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (72, 1, 72);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (73, 1, 73);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (74, 1, 74);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (75, 1, 75);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (76, 1, 76);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (77, 1, 77);
INSERT INTO `lfs_db`.`role_has_permissions` (`id`, `roles_id`, `permissions_id`) VALUES (78, 1, 78);

COMMIT;


-- -----------------------------------------------------
-- Data for table `lfs_db`.`signatories`
-- -----------------------------------------------------
START TRANSACTION;
USE `lfs_db`;
INSERT INTO `lfs_db`.`signatories` (`id`, `prefix`, `first_name`, `middle_initial`, `last_name`, `suffix`, `title`, `created_at`, `updated_at`) VALUES (2, NULL, 'Ensign', 'S', 'Uba', NULL, 'Acting Municipal Treasurer', '2022-01-12 15:15:15', NULL);
INSERT INTO `lfs_db`.`signatories` (`id`, `prefix`, `first_name`, `middle_initial`, `last_name`, `suffix`, `title`, `created_at`, `updated_at`) VALUES (3, NULL, 'Dionesia', 'B', 'Lagas', NULL, 'Municipal Mayor', '2022-01-12 15:16:17', NULL);
INSERT INTO `lfs_db`.`signatories` (`id`, `prefix`, `first_name`, `middle_initial`, `last_name`, `suffix`, `title`, `created_at`, `updated_at`) VALUES (4, NULL, 'Mary Magdalyn', 'R', 'Burgos', 'CPA', 'Municipal Accountant', '2022-01-12 16:04:19', NULL);

COMMIT;


-- -----------------------------------------------------
-- Data for table `lfs_db`.`signatories_has_document_references`
-- -----------------------------------------------------
START TRANSACTION;
USE `lfs_db`;
INSERT INTO `lfs_db`.`signatories_has_document_references` (`id`, `signatories_id`, `document_references_id`) VALUES (DEFAULT, 4, 1);
INSERT INTO `lfs_db`.`signatories_has_document_references` (`id`, `signatories_id`, `document_references_id`) VALUES (DEFAULT, 4, 2);
INSERT INTO `lfs_db`.`signatories_has_document_references` (`id`, `signatories_id`, `document_references_id`) VALUES (DEFAULT, 4, 3);
INSERT INTO `lfs_db`.`signatories_has_document_references` (`id`, `signatories_id`, `document_references_id`) VALUES (DEFAULT, 4, 4);
INSERT INTO `lfs_db`.`signatories_has_document_references` (`id`, `signatories_id`, `document_references_id`) VALUES (DEFAULT, 4, 5);
INSERT INTO `lfs_db`.`signatories_has_document_references` (`id`, `signatories_id`, `document_references_id`) VALUES (DEFAULT, 4, 6);
INSERT INTO `lfs_db`.`signatories_has_document_references` (`id`, `signatories_id`, `document_references_id`) VALUES (DEFAULT, 4, 7);
INSERT INTO `lfs_db`.`signatories_has_document_references` (`id`, `signatories_id`, `document_references_id`) VALUES (DEFAULT, 4, 8);
INSERT INTO `lfs_db`.`signatories_has_document_references` (`id`, `signatories_id`, `document_references_id`) VALUES (DEFAULT, 4, 9);
INSERT INTO `lfs_db`.`signatories_has_document_references` (`id`, `signatories_id`, `document_references_id`) VALUES (DEFAULT, 4, 10);
INSERT INTO `lfs_db`.`signatories_has_document_references` (`id`, `signatories_id`, `document_references_id`) VALUES (DEFAULT, 4, 11);
INSERT INTO `lfs_db`.`signatories_has_document_references` (`id`, `signatories_id`, `document_references_id`) VALUES (DEFAULT, 4, 12);
INSERT INTO `lfs_db`.`signatories_has_document_references` (`id`, `signatories_id`, `document_references_id`) VALUES (DEFAULT, 4, 13);
INSERT INTO `lfs_db`.`signatories_has_document_references` (`id`, `signatories_id`, `document_references_id`) VALUES (DEFAULT, 3, 22);
INSERT INTO `lfs_db`.`signatories_has_document_references` (`id`, `signatories_id`, `document_references_id`) VALUES (DEFAULT, 2, 14);
INSERT INTO `lfs_db`.`signatories_has_document_references` (`id`, `signatories_id`, `document_references_id`) VALUES (DEFAULT, 2, 16);
INSERT INTO `lfs_db`.`signatories_has_document_references` (`id`, `signatories_id`, `document_references_id`) VALUES (DEFAULT, 2, 17);
INSERT INTO `lfs_db`.`signatories_has_document_references` (`id`, `signatories_id`, `document_references_id`) VALUES (DEFAULT, 2, 18);
INSERT INTO `lfs_db`.`signatories_has_document_references` (`id`, `signatories_id`, `document_references_id`) VALUES (DEFAULT, 2, 19);
INSERT INTO `lfs_db`.`signatories_has_document_references` (`id`, `signatories_id`, `document_references_id`) VALUES (DEFAULT, 2, 20);
INSERT INTO `lfs_db`.`signatories_has_document_references` (`id`, `signatories_id`, `document_references_id`) VALUES (DEFAULT, 2, 21);

COMMIT;


-- -----------------------------------------------------
-- Data for table `lfs_db`.`journals_default_accounts`
-- -----------------------------------------------------
START TRANSACTION;
USE `lfs_db`;
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (39, 4, 1, 60, 0);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (40, 4, 1, 61, 0);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (41, 4, 1, 304, 0);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (58, 2, 1, 363, 0);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (59, 2, 1, 370, 0);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (60, 2, 1, 374, 0);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (62, 2, 1, 3, 1);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (63, 2, 1, 4, 1);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (64, 2, 1, 7, 1);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (65, 2, 2, 365, 0);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (66, 2, 2, 310, 0);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (67, 2, 2, 327, 0);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (68, 2, 2, 3, 1);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (69, 2, 2, 4, 1);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (70, 2, 2, 7, 1);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (71, 2, 3, 308, 0);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (72, 2, 3, 310, 0);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (73, 2, 3, 330, 0);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (74, 2, 3, 3, 1);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (75, 2, 3, 4, 1);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (76, 2, 3, 7, 1);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (77, 4, 2, 60, 0);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (78, 4, 2, 61, 0);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (79, 4, 2, 304, 0);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (81, 4, 3, 60, 0);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (82, 4, 3, 61, 0);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (83, 4, 3, 304, 0);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (86, 5, 1, 4, 0);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (87, 5, 1, 304, 0);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (88, 5, 1, 318, 0);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (90, 5, 2, 4, 0);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (91, 5, 2, 304, 0);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (92, 5, 2, 318, 0);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (93, 5, 2, 61, 1);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (94, 5, 2, 310, 1);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (95, 5, 2, 488, 1);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (96, 5, 3, 4, 0);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (97, 5, 3, 304, 0);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (98, 5, 3, 318, 0);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (117, 4, 1, 460, 1);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (118, 4, 1, 461, 1);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (119, 4, 1, 555, 1);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (122, 5, 1, 484, 1);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (123, 5, 1, 501, 1);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (124, 5, 1, 554, 1);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (125, 4, 2, 488, 1);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (126, 4, 2, 501, 1);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (127, 4, 2, 555, 1);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (128, 4, 3, 484, 1);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (129, 4, 3, 488, 1);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (130, 4, 3, 555, 1);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (131, 5, 3, 488, 1);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (132, 5, 3, 495, 1);
INSERT INTO `lfs_db`.`journals_default_accounts` (`id`, `journals_id`, `funds_id`, `general_ledger_accounts_id`, `is_debit`) VALUES (133, 5, 3, 555, 1);

COMMIT;


-- -----------------------------------------------------
-- Data for table `lfs_db`.`accountable_forms`
-- -----------------------------------------------------
START TRANSACTION;
USE `lfs_db`;
INSERT INTO `lfs_db`.`accountable_forms` (`id`, `acc_form_no`, `acc_form_desc`) VALUES (1, '51', 'Official Receipt with RP Seal (Carbonless)');
INSERT INTO `lfs_db`.`accountable_forms` (`id`, `acc_form_no`, `acc_form_desc`) VALUES (2, '52', 'Certificate of Record of Transfer of Large Cattle');
INSERT INTO `lfs_db`.`accountable_forms` (`id`, `acc_form_no`, `acc_form_desc`) VALUES (3, '53', 'Certificate of Ownership of Large Cattle');
INSERT INTO `lfs_db`.`accountable_forms` (`id`, `acc_form_no`, `acc_form_desc`) VALUES (4, '54', 'Marriage License');
INSERT INTO `lfs_db`.`accountable_forms` (`id`, `acc_form_no`, `acc_form_desc`) VALUES (5, '55-C', 'Cash Tickets (denomination)');
INSERT INTO `lfs_db`.`accountable_forms` (`id`, `acc_form_no`, `acc_form_desc`) VALUES (6, '55-D', 'Cash Tickets (denomination)');
INSERT INTO `lfs_db`.`accountable_forms` (`id`, `acc_form_no`, `acc_form_desc`) VALUES (7, '55-E', 'Cash Tickets (denomination)');
INSERT INTO `lfs_db`.`accountable_forms` (`id`, `acc_form_no`, `acc_form_desc`) VALUES (8, '55-F', 'Cash Tickets (denomination)');
INSERT INTO `lfs_db`.`accountable_forms` (`id`, `acc_form_no`, `acc_form_desc`) VALUES (9, '56', 'Real Property Tax Receipts');
INSERT INTO `lfs_db`.`accountable_forms` (`id`, `acc_form_no`, `acc_form_desc`) VALUES (10, '57	', 'Slaughter Permit and Fee Receipts');
INSERT INTO `lfs_db`.`accountable_forms` (`id`, `acc_form_no`, `acc_form_desc`) VALUES (11, '58', 'City/Municipal Burial Permit and Fee Receipt');
INSERT INTO `lfs_db`.`accountable_forms` (`id`, `acc_form_no`, `acc_form_desc`) VALUES (12, '15', 'Community Tax Certificate (CTC)');

COMMIT;


-- -----------------------------------------------------
-- Data for table `lfs_db`.`rpt_discounts`
-- -----------------------------------------------------
START TRANSACTION;
USE `lfs_db`;
INSERT INTO `lfs_db`.`rpt_discounts` (`id`, `month`, `description`, `rate`, `is_advance`) VALUES (1, 10, 'Annual Advance Payment Discount', 0.20, 1);
INSERT INTO `lfs_db`.`rpt_discounts` (`id`, `month`, `description`, `rate`, `is_advance`) VALUES (2, 1, '1st Month Payment Discount', 0.10, 0);
INSERT INTO `lfs_db`.`rpt_discounts` (`id`, `month`, `description`, `rate`, `is_advance`) VALUES (3, 2, '2nd Month Payment Discount', 0.10, 0);
INSERT INTO `lfs_db`.`rpt_discounts` (`id`, `month`, `description`, `rate`, `is_advance`) VALUES (4, 3, '3rd Month Payment Discount', 0.10, 0);

COMMIT;


-- -----------------------------------------------------
-- Data for table `lfs_db`.`rpt_penalties`
-- -----------------------------------------------------
START TRANSACTION;
USE `lfs_db`;
INSERT INTO `lfs_db`.`rpt_penalties` (`id`, `description`, `frequency`, `rate`) VALUES (9, 'RPT monthly penalty', 'Monthly', 0.02);

COMMIT;


-- -----------------------------------------------------
-- Data for table `lfs_db`.`rpt_tax_rates`
-- -----------------------------------------------------
START TRANSACTION;
USE `lfs_db`;
INSERT INTO `lfs_db`.`rpt_tax_rates` (`id`, `code`, `description`, `rate`) VALUES (2, 'SEF', 'Special Educational Fund', 0.01);
INSERT INTO `lfs_db`.`rpt_tax_rates` (`id`, `code`, `description`, `rate`) VALUES (3, 'BSC', 'Basic', 0.01);

COMMIT;


-- -----------------------------------------------------
-- Data for table `lfs_db`.`taxpayer_type`
-- -----------------------------------------------------
START TRANSACTION;
USE `lfs_db`;
INSERT INTO `lfs_db`.`taxpayer_type` (`id`, `code`, `taxpayer_type`) VALUES (1, 'ASSO', 'Association');
INSERT INTO `lfs_db`.`taxpayer_type` (`id`, `code`, `taxpayer_type`) VALUES (2, 'CHAR', 'Charitable');
INSERT INTO `lfs_db`.`taxpayer_type` (`id`, `code`, `taxpayer_type`) VALUES (3, 'COOP', 'Cooperative');
INSERT INTO `lfs_db`.`taxpayer_type` (`id`, `code`, `taxpayer_type`) VALUES (4, 'CORP', 'Corporation');
INSERT INTO `lfs_db`.`taxpayer_type` (`id`, `code`, `taxpayer_type`) VALUES (5, 'EDUC', 'Educational');
INSERT INTO `lfs_db`.`taxpayer_type` (`id`, `code`, `taxpayer_type`) VALUES (6, 'GOVT', 'Government');
INSERT INTO `lfs_db`.`taxpayer_type` (`id`, `code`, `taxpayer_type`) VALUES (7, 'INDV', 'Individual');
INSERT INTO `lfs_db`.`taxpayer_type` (`id`, `code`, `taxpayer_type`) VALUES (8, 'MULT', 'Multiple Owners');
INSERT INTO `lfs_db`.`taxpayer_type` (`id`, `code`, `taxpayer_type`) VALUES (9, 'PART', 'Partnership');
INSERT INTO `lfs_db`.`taxpayer_type` (`id`, `code`, `taxpayer_type`) VALUES (10, 'RELI', 'Religious');

COMMIT;


-- -----------------------------------------------------
-- Data for table `lfs_db`.`actual_use_codes`
-- -----------------------------------------------------
START TRANSACTION;
USE `lfs_db`;
INSERT INTO `lfs_db`.`actual_use_codes` (`id`, `code`, `name`, `is_government`) VALUES (1, 'AR', 'Residential', 0);
INSERT INTO `lfs_db`.`actual_use_codes` (`id`, `code`, `name`, `is_government`) VALUES (2, 'AC', 'Commercial', 0);
INSERT INTO `lfs_db`.`actual_use_codes` (`id`, `code`, `name`, `is_government`) VALUES (3, 'AI', 'Industrial', 0);
INSERT INTO `lfs_db`.`actual_use_codes` (`id`, `code`, `name`, `is_government`) VALUES (4, 'AA', 'Agricultural', 0);
INSERT INTO `lfs_db`.`actual_use_codes` (`id`, `code`, `name`, `is_government`) VALUES (5, 'AM', 'Mineral', 0);
INSERT INTO `lfs_db`.`actual_use_codes` (`id`, `code`, `name`, `is_government`) VALUES (6, 'ATF', 'Timberland/Forest', 0);
INSERT INTO `lfs_db`.`actual_use_codes` (`id`, `code`, `name`, `is_government`) VALUES (7, 'ASH', 'Hospital', 0);
INSERT INTO `lfs_db`.`actual_use_codes` (`id`, `code`, `name`, `is_government`) VALUES (8, 'ASC', 'Cultural', 0);
INSERT INTO `lfs_db`.`actual_use_codes` (`id`, `code`, `name`, `is_government`) VALUES (9, 'ASS', 'Scientific', 0);
INSERT INTO `lfs_db`.`actual_use_codes` (`id`, `code`, `name`, `is_government`) VALUES (10, 'ASLWD', 'Local Water District', 0);
INSERT INTO `lfs_db`.`actual_use_codes` (`id`, `code`, `name`, `is_government`) VALUES (11, 'ACH', 'Charitable', 0);
INSERT INTO `lfs_db`.`actual_use_codes` (`id`, `code`, `name`, `is_government`) VALUES (12, 'ARE', 'Religious', 0);
INSERT INTO `lfs_db`.`actual_use_codes` (`id`, `code`, `name`, `is_government`) VALUES (13, 'ARC', 'Recreational', 0);
INSERT INTO `lfs_db`.`actual_use_codes` (`id`, `code`, `name`, `is_government`) VALUES (14, 'AED', 'Educational', 0);
INSERT INTO `lfs_db`.`actual_use_codes` (`id`, `code`, `name`, `is_government`) VALUES (15, 'ACT', 'Cemetery', 0);
INSERT INTO `lfs_db`.`actual_use_codes` (`id`, `code`, `name`, `is_government`) VALUES (16, 'ARK', 'Park', 0);
INSERT INTO `lfs_db`.`actual_use_codes` (`id`, `code`, `name`, `is_government`) VALUES (17, 'ANG', 'National', 1);
INSERT INTO `lfs_db`.`actual_use_codes` (`id`, `code`, `name`, `is_government`) VALUES (18, 'APG', 'Provincial', 1);
INSERT INTO `lfs_db`.`actual_use_codes` (`id`, `code`, `name`, `is_government`) VALUES (19, 'ACG', 'City', 1);
INSERT INTO `lfs_db`.`actual_use_codes` (`id`, `code`, `name`, `is_government`) VALUES (20, 'AMG', 'Municipality', 1);
INSERT INTO `lfs_db`.`actual_use_codes` (`id`, `code`, `name`, `is_government`) VALUES (21, 'ABG', 'Barangay', 1);
INSERT INTO `lfs_db`.`actual_use_codes` (`id`, `code`, `name`, `is_government`) VALUES (22, 'AGOCC', 'Corporation', 1);
INSERT INTO `lfs_db`.`actual_use_codes` (`id`, `code`, `name`, `is_government`) VALUES (23, 'AIM', 'Agricultural (Imprvts)', 0);
INSERT INTO `lfs_db`.`actual_use_codes` (`id`, `code`, `name`, `is_government`) VALUES (24, 'GOV', 'Government', 1);
INSERT INTO `lfs_db`.`actual_use_codes` (`id`, `code`, `name`, `is_government`) VALUES (25, 'GOVR', 'Government (Res)', 0);

COMMIT;


-- -----------------------------------------------------
-- Data for table `lfs_db`.`provinces`
-- -----------------------------------------------------
START TRANSACTION;
USE `lfs_db`;
INSERT INTO `lfs_db`.`provinces` (`id`, `code`, `name`) VALUES (1, '001', 'Zamboanga Sibugay');

COMMIT;


-- -----------------------------------------------------
-- Data for table `lfs_db`.`municipalities`
-- -----------------------------------------------------
START TRANSACTION;
USE `lfs_db`;
INSERT INTO `lfs_db`.`municipalities` (`id`, `provinces_id`, `code`, `name`) VALUES (1, 1, '002', 'Buug');

COMMIT;


-- -----------------------------------------------------
-- Data for table `lfs_db`.`classification_codes`
-- -----------------------------------------------------
START TRANSACTION;
USE `lfs_db`;
INSERT INTO `lfs_db`.`classification_codes` (`id`, `code`, `name`, `is_special`) VALUES (1, 'R', 'Residential', 0);
INSERT INTO `lfs_db`.`classification_codes` (`id`, `code`, `name`, `is_special`) VALUES (2, 'A', 'Agricultural', 0);
INSERT INTO `lfs_db`.`classification_codes` (`id`, `code`, `name`, `is_special`) VALUES (3, 'C', 'Commercial', 0);
INSERT INTO `lfs_db`.`classification_codes` (`id`, `code`, `name`, `is_special`) VALUES (4, 'I', 'Industrial', 0);
INSERT INTO `lfs_db`.`classification_codes` (`id`, `code`, `name`, `is_special`) VALUES (5, 'M', 'Mineral', 0);
INSERT INTO `lfs_db`.`classification_codes` (`id`, `code`, `name`, `is_special`) VALUES (6, 'T', 'Timberland/Forest', 0);
INSERT INTO `lfs_db`.`classification_codes` (`id`, `code`, `name`, `is_special`) VALUES (7, 'SH', 'Hospital', 1);
INSERT INTO `lfs_db`.`classification_codes` (`id`, `code`, `name`, `is_special`) VALUES (8, 'SC', 'Cultural', 1);
INSERT INTO `lfs_db`.`classification_codes` (`id`, `code`, `name`, `is_special`) VALUES (9, 'SS', 'Scientific', 1);
INSERT INTO `lfs_db`.`classification_codes` (`id`, `code`, `name`, `is_special`) VALUES (10, 'SW', 'Local Water District', 1);
INSERT INTO `lfs_db`.`classification_codes` (`id`, `code`, `name`, `is_special`) VALUES (11, 'SG', 'Corporation engaged in Generation/Distribution of Electric Power', 1);
INSERT INTO `lfs_db`.`classification_codes` (`id`, `code`, `name`, `is_special`) VALUES (12, 'GOV', 'Government', 0);

COMMIT;


-- -----------------------------------------------------
-- Data for table `lfs_db`.`business_type`
-- -----------------------------------------------------
START TRANSACTION;
USE `lfs_db`;
INSERT INTO `lfs_db`.`business_type` (`id`, `name`, `created_at`, `updated_at`) VALUES (1, 'Single Proprietorship', DEFAULT, NULL);
INSERT INTO `lfs_db`.`business_type` (`id`, `name`, `created_at`, `updated_at`) VALUES (2, 'Partnership', DEFAULT, NULL);
INSERT INTO `lfs_db`.`business_type` (`id`, `name`, `created_at`, `updated_at`) VALUES (3, 'Corporation', DEFAULT, NULL);
INSERT INTO `lfs_db`.`business_type` (`id`, `name`, `created_at`, `updated_at`) VALUES (4, 'Cooperative', DEFAULT, NULL);
INSERT INTO `lfs_db`.`business_type` (`id`, `name`, `created_at`, `updated_at`) VALUES (5, 'PEZA Company', DEFAULT, NULL);
INSERT INTO `lfs_db`.`business_type` (`id`, `name`, `created_at`, `updated_at`) VALUES (6, 'Non-Stock', DEFAULT, NULL);

COMMIT;


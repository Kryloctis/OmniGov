# LFS Database Version Control & Maintenance Policy

## 1. Directory Structure Standards

All database-related files, diagrams, and scripts must strictly adhere to the following directory structure within the repository to ensure a clean separation of concerns between documentation, visual design, and executable code.

### 1.1 Documentation & Design (`docs/db/`)
* **Path:** `LFS/docs/db/`
* **Purpose:** This directory is strictly for human-readable documentation (Markdown) and visual design files.
* **Allowed Files:**
  * `.md` files (e.g., `Database_Migration_Plan.md`, `Database_Version_Control_Policy.md`)
  * `.mwb` files (MySQL Workbench visual models, e.g., `lfs_schema_model.mwb`)
* **Prohibited Files:** Executable `.sql` scripts or migration files must not be stored here.

### 1.2 Executable SQL Scripts (`scripts/db/`)
* **Path:** `LFS/scripts/db/`
* **Purpose:** This directory contains all executable SQL commands, separated into three distinct sub-folders based on their lifecycle phase.

#### A. `/baseline/`
* **Purpose:** Contains the absolute, single source of truth for creating a fresh database from scratch.
* **Rules:**
  * Should contain exactly one (or a very small set of) `.sql` file representing the current, entire structue of the production database.
  * Generated via MySQL Workbench export (`File > Export > Forward Engineer SQL CREATE Script`).
  * Only updated during major system resets or milestone releases.
  * **Naming Convention:** `V{Major.Minor}__Baseline_Schema.sql` 

#### B. `/migrations/`
* **Purpose:** The core of version control. Contains incremental changes applied to an *existing* database.
* **Rules:**
  * Contains both Auto-Generated schema change scripts (`ALTER TABLE`) and Handwritten DML scripts (`UPDATE`/`INSERT`).
  * **Naming Convention:** `V{VersionNumber}__{Description}.sql` (e.g., `V1.1__Add_Status_Column.sql`).
  * **Strict Ordering:** Scripts must flow sequentially: Structure Change ➔ Data Migration (DML) ➔ Structure Cleanup (Drops).

#### C. `/seeds/`
* **Purpose:** Contains static, required data needed for the application to function (e.g., lookup tables, roles).
* **Naming Convention:** `S{Number}__{TableName}_Seed.sql` (e.g., `S01__UserRoles_Seed.sql`).

---

## 2. Procedure for Schema Changes

When a developer needs to alter the database schema (add columns, create tables, drop columns), they must follow the "Auto-Generate Script" method. Writing massive `ALTER` statements manually is prohibited due to time constraints and error risks.

### The "Auto-Generate Script" Method
1. **Visual Update:** Open the `.mwb` file in `docs/db/` and make the required structural changes visually.
2. **Generate Script:** Navigate to **Database > Synchronize Model** in MySQL Workbench.
3. **Capture but Do Not Execute:** Proceed through the wizard until the summary page displays the generated SQL. **Do not click Execute.**
4. **Save Script:** Click **Save to File...** and store the `.sql` script in `scripts/db/migrations/` using the strict naming convention.
5. **Commit:** Commit both the updated `.mwb` file and the new `.sql` migration script to version control.

---

## 3. Procedure for Data Manipulation (DML)

Any migration requiring data modification (e.g., moving data from an old column to a new column, calculating new values) must be handwritten as a distinct migration script.

### 3.1 Rules for DML Scripts
1. **Never Mix DML and DDL:** Never put an `UPDATE` statement in the same file as an `ALTER TABLE` statement. They must be separate, sequential files in the `migrations/` folder.
2. **Mandatory Transaction Blocks:** Every DML script that alters data must be wrapped in a transaction block to ensure atomicity.
   ```sql
   START TRANSACTION;
   -- Your UPDATE / INSERT / DELETE logic
   COMMIT;
   ```
3. **Pre-Execution Testing:** Before executing an `UPDATE` or `DELETE` in production, a `SELECT` statement mapping the exact logic must be run manually to verify the outcome.
4. **Batched Execution:** For tables exceeding massive row counts, DML updates should not lock the entire table.

---

## 4. Execution Workflow

When applying changes to the live production database (`bg_zsi_lfs_db`), the execution must happen in this exact order to prevent data loss:

1. **Step 1:** Execute the Schema Creation script (e.g., `V1.1__Add_Columns.sql`).
   - *Result:* New empty columns/tables exist. Old columns still remain untouched.
2. **Step 2:** Execute the Data Migration/DML script (e.g., `V1.2__Migrate_Data.sql`).
   - *Result:* Data is safely mapped from the old structure into the new structure.
3. **Step 3 (If necessary):** Execute the Schema Cleanup script (e.g., `V1.3__Drop_Old_Columns.sql`).
   - *Result:* Old, deprecated columns are removed only *after* all data is confirmed migrated.

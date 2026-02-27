# LFS Database Migration & Maintenance Plan

## 1. Pre-Migration / Database Maintenance Procedure

Before undergoing any schema alterations or Data Manipulation Language (DML) migrations, ensure you strictly follow these standard maintenance and safety procedures to prevent data loss or service disruption:

1. **Notify Stakeholders:** Inform all required administrators and users of LGU Titay and LGU Buug about the scheduled maintenance window to prevent active concurrent sessions.
2. **System Lockout & Traffic Halt:** Temporarily disable UI access or place the application in \"Maintenance Mode\" to prevent incomplete or dirty transactions during migration.
3. **Full Database Backup:** Take a complete SQL dump of the existing `bg_zsi_lfs_db` schema, including all objects (tables, views, routines) and raw data.
   - *Requirement:* Ensure the backup is verified and safely stored locally or on a secure network drive before doing anything else.
4. **Health Check:** Analyze current server metrics (disk space, CPU) to ensure the server has enough resources to perform large updates and batch processes without crashing.
5. **Dry-Run (Recommended):** Perform the migration on a staging or test replica first. This helps measure migration time and spot potential syntax or logic errors without risking production.

---

## 2. Best DML / Data Manipulation Approaches

For the execution of data migration loops and calculations, selecting the correct DML approach is critical for performance, safety, and atomicity:

### Recommended Approach: SQL Transaction Scripting
Using native SQL scripts is generally the safest and fastest way for migrating existing records.
- **Why?** It runs natively on the DBMS side, avoiding network latency bottlenecks. It seamlessly handles atomic transactions and provides reliable rollback mechanics if any unexpected edge case occurs.
- **Implementation Strategy:**
  - **Transaction Blocks:** Always perform DML changes encased in a `START TRANSACTION;` and `COMMIT;` envelope. This guarantees that if one query fails, everything reverts safely.
  - **Batching Execution:** For very large table data rows, avoid locking up the entire table doing a single massive `UPDATE`. Update records in manageable batches (e.g., using `LIMIT 1000` inside a loop/procedure).
  - **Advanced Conditionals:** Utilize powerful native expressions (like `CASE` operations or `IF` constraints) and string functions to concatenate and morph values effectively within queries instead of making manual loops.

### Alternative Approach: Custom CLI/Scripting Tools (C# or Python)
If generating the new string formats requires extremely dense programmatic logic (such as cryptographic hashes or API references) which are difficult in pure SQL, you can use an external Data Access tool (e.g., C# Console background runner/ADO.NET wrapping script).
- **Cons:** Significantly slower due to latency from pulling data and returning it, greater risk of timeouts. Use only if purely native SQL approach is impossible.

---

## 3. Recommended Workflow for Solo Devs (ADO.NET Stack)

Since you are not using Entity Framework (which auto-generates migrations) and rely on ADO.NET, handwriting complex `ALTER TABLE` scripts for large schemas is incredibly time-consuming. You can use MySQL Workbench to **automate** the generation of these scripts without risking direct execution on live data.

### The "Auto-Generate Script" Method
Whenever you update your visual `.mwb` model, follow these steps to securely generate your migration scripts:
1. Make all your schema changes visually in MySQL Workbench (add columns, rename, drop, etc.).
2. Go to **Database > Synchronize Model**.
3. Follow the wizard steps until you reach the **"SQL Script"** or **"Model and Database Differences"** summary page. 
   - *Workbench will now calculate and display all the necessary `ALTER TABLE` statements for you automatically.*
4. **CRITICAL:** Do *not* click "Execute" to run this directly against production. 
5. Instead, click **"Save to File..."** or copy the SQL.
6. Save this file inside your repository as a new migration script (e.g., `scripts/db/migrations/V1.5__Auto_Generated_Schema_Updates.sql`).

**Why this is the best approach for you:**
- **Saves Massive Time:** You get 100% accurate SQL scripts generated instantly based on your visual diagram changes.
- **Safe:** You get to review the script before it ever touches a database, preventing accidental `DROP` statements from ruining production.
- **Maintains Audit Trail:** You commit the generated `.sql` file to Git, giving you perfect version control history, which ADO.NET applications lack by default.

*(Note: Data Manipulation/DML scripts like `UPDATE jev SET status...` must still be handwritten, as Workbench only generates structural schema changes).*

---

## 4. Schema Alterations and Migration Execution Plan

### 4.1 `jev` (Journal Entry Voucher)

**Table Updates:**
- Altered column: `trns_no` ➔ `transaction_no`
- Added column: `status` with data type `ENUM('pending', 'approved', 'disapproved', 'cancelled')`

**View Updates: `view_jev`**
- Altered column mapping to reflect `transaction_no`
- Included the new `status` column mapping

**DML Execution Objectives:**
- **Task 1: Formulate `transaction_no` for legacy entries**
  - *Execution:* Extract `date_entry` records and apply the designated data processing logic via an update script to map unique standardized identifiers into the new `transaction_no` column.
- **Task 2: Migrate status configurations**
  - *Execution:* Evaluate existing discrete flags (`is_approved`, `is_disapproved`, `is_cancelled`). Run a direct SQL `UPDATE` script with `CASE` constructs to populate the new Enum field.
    *Example:*
    ```sql
    UPDATE jev 
    SET status = CASE 
        WHEN is_approved = 1 THEN 'approved'
        ...
    ```

---

### 3.2 `obligation_request`

**Table Updates:**
- Added column: `status` with data type `ENUM('pending', 'approved', 'disapproved', 'cancelled')`

**View Updates: `view_obligation_request`**
- Removed deprecated metric columns: `is_approved`, `is_disapproved`, `is_cancelled`
- Included the new `transaction_no` and `status` column mappings.

**DML Execution Objectives:**
- **Task 1: Migrate status configurations**
  - *Execution:* Similar logic to the JEV task. Apply programmatic data processing via SQL to migrate the three boolean representations into a single `status` enumerator record across servers.

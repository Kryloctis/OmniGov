# LFS Database Deployment & Client Monitoring Checklist

**Purpose:** A strict, repeatable checklist for tracking which client databases have received the latest schema and data migrations. You must check each box after successfully completing a step for a specific client to ensure no databases are left behind or desynchronized.

---

## Deployment Scope

**Target Version:** `V1.1.0`
**Major Changes:**
- Migrated legacy `is_approved`/`is_disapproved`/`is_cancelled` flags to `status` ENUM.
- Standardized `transaction_no` column formatting to `YYYY-0000`.
- Added strict Foreign Keys to `obligation_request` (`funds_id`, etc.).

---

## Client Synchronization Checklist

### [ ] Client 1: LGU Titay
- [ ] **Maintenance Procedure:** Verified nobody is actively using the system.
- [ ] **Backup:** Exported full database dump (`Titay_lfs_db_backup_PRE_V1.1_DATE.sql`)
- [ ] **1. Execute Baseline Synchronization Script (`V1.0.1__Auto_Schema.sql`)**
      *(Using MySQL Workbench > Synchronize Model output)*
- [ ] **2. Execute DML Data Migration (`V1.1__Migrate_Status_Data.sql`)**
      *(This populates `status` ENUM and auto-generates chronologically formatted `transaction_no` strings)*
- [ ] **3. Manually Map Accounts to Obligation Requests (`V1.2__Migrate_Obligation_Request_Accounts.sql`)**
      *(Handwritten logic mapping older requests to their appropriate fund and class IDs)*
- [ ] **4. Enforce Foreign Keys (Post-Population schema lock)**
      *(Use Workbench Synchronize Model again once the IDs above are populated)*
- [ ] **Verify Application Operations:** Run the C# application to ensure data pulls correctly with the new structure.

---

### [ ] Client 2: LGU Buug
- [ ] **Maintenance Procedure:** Verified nobody is actively using the system.
- [ ] **Backup:** Exported full database dump (`Buug_lfs_db_backup_PRE_V1.1_DATE.sql`)
- [ ] **1. Execute Baseline Synchronization Script (`V1.0.1__Auto_Schema.sql`)**
- [ ] **2. Execute DML Data Migration (`V1.1__Migrate_Status_Data.sql`)**
- [ ] **3. Manually Map Accounts to Obligation Requests (`V1.2__Migrate_Obligation_Request_Accounts.sql`)**
- [ ] **4. Enforce Foreign Keys (Post-Population schema lock)**
- [ ] **Verify Application Operations:** Run the C# application confirming `status` strings and `transaction_no` formats match expected `YYYY-0000` structure.

---

### [ ] Client 3: Local Dev Server (`bg_zsi_lfs_db`)
- [ ] **Maintenance Procedure:** Local lockdown.
- [ ] **Backup:** Performed quick local dump.
- [ ] **1. Execute Baseline Synchronization Script (`V1.0.1__Auto_Schema.sql`)**
- [ ] **2. Execute DML Data Migration (`V1.1__Migrate_Status_Data.sql`)**
- [ ] **3. Manually Map Accounts (`V1.2__Migrate_Obligation_Request_Accounts.sql`)**
- [ ] **4. Enforce Foreign Keys (Post-Population schema lock)**

---

## Common Post-Deployment Tasks

After the databases are structurally synchronized, the ADO.NET code *must* be deployed on each client machine to complement the new database structure.
- [ ] ADO.NET Codebase: Updated `JevRepository.cs` to map `status` string instead of legacy boolean flags.
- [ ] ADO.NET Codebase: Updated `ObligationRequestRepository.cs` to map new `status` and `transaction_no`.
- [ ] Forms UI: Grid views and combo boxes updated to pull constraints (e.g. `approved`, `pending`) directly from DB.

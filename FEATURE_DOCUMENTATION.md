# Local Financial System (LFS) - Feature Documentation

## Project Overview
The **Local Financial System (LFS)** is a robust, NGAS-compliant ERP designed for Local Government Units (LGUs). It streamlines financial governance by integrating budget control, accounting integrity, and revenue management.

---

## 1. Budgeting Module
Focuses on fiscal responsibility and adherence to the Annual/Supplemental Budget.
*   **Key Features**: Allotment Classes, FPP Tracking, Obligation Requests (ObR), and SAAOB reporting.
*   **Detailed Documentation**: [Budget Module](./docs/BUDGET_MODULE.md)

---

## 2. Accounting Module
A double-entry bookkeeping system that ensures transparency and regulatory compliance.
*   **Key Features**: JEV entry system, General/Subsidiary Ledgers, and NGAS Financial Statements.
*   **Detailed Documentation**: [Accounting Module](./docs/ACCOUNTING_MODULE.md)

---

## 3. Treasury & RPT Module
Handles the lifeblood of the LGU—revenue collection, property tax enforcement, and cash disbursements.
*   **Key Features**: RPT Billing & Penalties, LTOM Enforcement (Levy/Auction), Official Receipts, and Bank Management.
*   **Detailed Documentation**: [Treasury Module](./docs/TREASURY_MODULE.md)

---

## 4. Cross-Module Features
*   **Database Synchronization**: Syncs assessment data from local assessors to the collection system.
*   **Role-Based Access Control**: Strict segregation of duties for JEV approval and collection posting.
*   **Audit Trails**: Comprehensive logs for all financial adjustments.
*   **NgAS & LTOM Compliance**: Reports are formatted to meet Philippine statutory requirements.

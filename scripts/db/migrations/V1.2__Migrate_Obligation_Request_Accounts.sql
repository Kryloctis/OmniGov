-- Migration V1.2 (TEMPLATE)
-- Purpose: This must be a DML script to map existing Obligation Request records to real `funds_id`, `allotment_classes_id`, and `function_program_project_id`.
-- You MUST map the existing data in the live server to these IDs before V1.3 can run!

START TRANSACTION;

-- Example:
-- UPDATE `obligation_request` 
-- SET `funds_id` = 1, `allotment_classes_id` = 2, `function_program_project_id` = 15
-- WHERE `id` <= 100;

COMMIT;

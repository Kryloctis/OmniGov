    -- Migration V1.1
    -- Purpose: Convert legacy boolean logic into the standardized 'status' Enum column for JEV and Obligation Request.
    -- Safety: This script is encased in a transaction so if any failure occurs during the update, everything rolls back.

    START TRANSACTION;

    -- 1. Migrate Status and Transaction No for `jev`
    -- Generates transaction_no format: YYYY-0000 based on 'date_entry' chronological order
    UPDATE `jev` j
    JOIN (
        SELECT `id`, 
            YEAR(`date_entry`) as txn_year,
            ROW_NUMBER() OVER (PARTITION BY YEAR(`date_entry`) ORDER BY `date_entry` ASC, `id` ASC) as row_num
        FROM `jev`
    ) as seq ON j.id = seq.id
    SET 
        j.`status` = CASE
            WHEN j.`is_approved` = 1 THEN 'approved'
            WHEN j.`is_disapproved` = 1 THEN 'disapproved'
            WHEN j.`is_cancelled` = 1 THEN 'cancelled'
            ELSE 'pending'
        END,
        j.`transaction_no` = CONCAT(seq.txn_year, '-', LPAD(seq.row_num, 4, '0'));

    -- 2. Migrate Status and Transaction No for `obligation_request`
    -- Generates transaction_no format: YYYY-0000 based on 'date_requested' chronological order
    UPDATE `obligation_request` o
    JOIN (
        SELECT `id`, 
            YEAR(`date_requested`) as txn_year,
            ROW_NUMBER() OVER (PARTITION BY YEAR(`date_requested`) ORDER BY `date_requested` ASC, `id` ASC) as row_num
        FROM `obligation_request`
    ) as seq ON o.id = seq.id
    SET 
        o.`status` = CASE
            WHEN o.`is_approved` = 1 THEN 'approved'
            WHEN o.`is_disapproved` = 1 THEN 'disapproved'
            WHEN o.`is_cancelled` = 1 THEN 'cancelled'
            ELSE 'pending'
        END,
        o.`transaction_no` = CONCAT(seq.txn_year, '-', LPAD(seq.row_num, 4, '0'));

    -- Only execute logic if previous updates successful
    COMMIT;

# Microsoft SQL Server Notes

## Index

Each topic below has short interview takeaways and syntax reminders.

### Topics

1. SQL Server basics and database objects
2. Data types
3. Creating and managing databases
4. DDL: tables, constraints, keys, indexes
5. DML: insert, update, delete, merge
6. Querying with SELECT
7. Filtering, sorting, aliases, expressions
8. Joins
9. Aggregation and grouping
10. Subqueries, derived tables, CTEs
11. Set operators
12. Window functions
13. Views
14. Stored procedures
15. Functions
16. Triggers
17. Transactions and TCL
18. Isolation levels, locks, blocking, deadlocks
19. Indexing and performance tuning
20. Execution plans and query optimization
21. Normalization and database design
22. Temporary tables, table variables, and CTE choice
23. Error handling
24. Security and DCL
25. Backup, restore, recovery models
26. SQL Server Agent and jobs
27. Import/export and bulk operations
28. Common interview traps

---

## 1. SQL Server Basics And Database Objects

SQL Server is Microsoft relational database management system. It stores data in databases, and each database contains schemas and objects.

**Takeaway notes:** database = container, schema = namespace/security boundary, table = rows/columns, view = saved query, procedure = executable T-SQL module, function = reusable expression/table logic, index = lookup structure, constraint = data rule.

**Common objects:** `DATABASE`, `SCHEMA`, `TABLE`, `VIEW`, `PROCEDURE`, `FUNCTION`, `TRIGGER`, `INDEX`, `SEQUENCE`, `SYNONYM`.

**Interview point:** SQL Server uses T-SQL, which is Microsoft extension of SQL. It supports procedural constructs like variables, `IF`, `WHILE`, `TRY...CATCH`, stored procedures, and transactions.

## 2. Data Types

Choose data types carefully because they affect storage, performance, indexing, and correctness.

**Common types:** `INT`, `BIGINT`, `DECIMAL(p,s)`, `MONEY`, `BIT`, `CHAR`, `VARCHAR`, `NCHAR`, `NVARCHAR`, `DATE`, `TIME`, `DATETIME2`, `UNIQUEIDENTIFIER`, `VARBINARY`.

**Takeaway notes:** use `NVARCHAR` for Unicode, use `VARCHAR` for non-Unicode, prefer `DATETIME2` over old `DATETIME`, use `DECIMAL` for exact financial calculations, avoid using strings for dates/numbers.

**Interview trap:** `NULL` means unknown/missing, not empty string and not zero. Comparisons need `IS NULL` / `IS NOT NULL`, not `= NULL`.

## 3. Creating And Managing Databases

`CREATE DATABASE` creates a database. `USE` changes current database context. `ALTER DATABASE` changes settings. `DROP DATABASE` deletes it.

```sql
CREATE DATABASE InterviewDb;
GO

USE InterviewDb;
GO

ALTER DATABASE InterviewDb SET RECOVERY SIMPLE;
DROP DATABASE InterviewDb;
```

**Takeaway notes:** `GO` is a client batch separator used by tools like SSMS, not a T-SQL statement. Production database changes should be scripted, reviewed, backed up, and tested.

## 4. DDL: Tables, Constraints, Keys, Indexes

DDL means Data Definition Language. It changes structure: `CREATE`, `ALTER`, `DROP`, `TRUNCATE`.

```sql
CREATE TABLE dbo.Employees
(
    EmployeeId INT IDENTITY(1,1) NOT NULL,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(255) NOT NULL,
    Salary DECIMAL(12,2) NOT NULL,
    DepartmentId INT NULL,
    CreatedAt DATETIME2 NOT NULL CONSTRAINT DF_Employees_CreatedAt DEFAULT SYSUTCDATETIME(),
    CONSTRAINT PK_Employees PRIMARY KEY (EmployeeId),
    CONSTRAINT UQ_Employees_Email UNIQUE (Email),
    CONSTRAINT CK_Employees_Salary CHECK (Salary >= 0)
);
```

**Constraints:** `PRIMARY KEY`, `FOREIGN KEY`, `UNIQUE`, `CHECK`, `DEFAULT`, `NOT NULL`.

**Keys:** primary key uniquely identifies a row, foreign key enforces relationship, candidate key is any unique identifier, composite key uses multiple columns.

**TRUNCATE vs DELETE:** `DELETE` removes rows and can use `WHERE`; `TRUNCATE` removes all rows, is minimally logged, resets identity, cannot run when referenced by FK.

## 5. DML: Insert, Update, Delete, Merge

DML means Data Manipulation Language. It changes data: `INSERT`, `UPDATE`, `DELETE`, `MERGE`.

```sql
INSERT INTO dbo.Employees (FirstName, LastName, Email, Salary, DepartmentId)
VALUES (N'Krish', N'Patel', N'krish@example.com', 75000.00, 1);

UPDATE dbo.Employees
SET Salary = Salary + 5000
WHERE EmployeeId = 1;

DELETE FROM dbo.Employees
WHERE EmployeeId = 1;
```

**Takeaway notes:** always write `WHERE` first mentally for `UPDATE`/`DELETE`; test with `SELECT` before running destructive statements. `MERGE` can upsert but has sharp edges; many teams prefer separate `UPDATE` then `INSERT` patterns for clarity.

## 6. Querying With SELECT

`SELECT` reads data. Logical processing order is not the same as written order.

**Written order:** `SELECT`, `FROM`, `JOIN`, `WHERE`, `GROUP BY`, `HAVING`, `ORDER BY`.

**Logical order:** `FROM`, `JOIN`, `WHERE`, `GROUP BY`, `HAVING`, `SELECT`, `ORDER BY`.

```sql
SELECT EmployeeId, FirstName, LastName, Salary
FROM dbo.Employees
WHERE Salary >= 50000
ORDER BY Salary DESC;
```

**Interview point:** `WHERE` filters rows before grouping; `HAVING` filters groups after aggregation.

## 7. Filtering, Sorting, Aliases, Expressions

Use `WHERE` with operators: `=`, `<>`, `>`, `<`, `>=`, `<=`, `BETWEEN`, `IN`, `LIKE`, `EXISTS`, `IS NULL`.

```sql
SELECT
    FirstName + N' ' + LastName AS FullName,
    Salary,
    CASE
        WHEN Salary >= 100000 THEN 'High'
        WHEN Salary >= 50000 THEN 'Medium'
        ELSE 'Low'
    END AS SalaryBand
FROM dbo.Employees
WHERE DepartmentId IN (1, 2, 3)
  AND Email LIKE N'%@example.com'
ORDER BY Salary DESC;
```

**Takeaway notes:** `LIKE 'A%'` can use an index more easily than `LIKE '%A'`; `ORDER BY` is the only reliable way to guarantee output order.

## 8. Joins

Joins combine rows from tables.

**Types:** `INNER JOIN`, `LEFT JOIN`, `RIGHT JOIN`, `FULL OUTER JOIN`, `CROSS JOIN`, self join.

```sql
SELECT e.EmployeeId, e.FirstName, d.DepartmentName
FROM dbo.Employees AS e
INNER JOIN dbo.Departments AS d
    ON d.DepartmentId = e.DepartmentId;
```

**Takeaway notes:** `INNER JOIN` returns matching rows only, `LEFT JOIN` returns all left rows plus matching right rows, unmatched right columns become `NULL`, `CROSS JOIN` returns Cartesian product.

**Interview trap:** with a `LEFT JOIN`, putting right-table filters in `WHERE` can accidentally turn it into an inner join. Put optional-side filters in the `ON` clause when needed.

## 9. Aggregation And Grouping

Aggregate functions summarize rows: `COUNT`, `SUM`, `AVG`, `MIN`, `MAX`.

```sql
SELECT DepartmentId, COUNT(*) AS EmployeeCount, AVG(Salary) AS AverageSalary
FROM dbo.Employees
GROUP BY DepartmentId
HAVING COUNT(*) >= 2;
```

**Takeaway notes:** every selected non-aggregate column must appear in `GROUP BY`; `COUNT(*)` counts rows, `COUNT(ColumnName)` ignores nulls.

## 10. Subqueries, Derived Tables, CTEs

A subquery is a query inside another query. A derived table is a subquery in `FROM`. A CTE is a named query expression valid for the next statement.

```sql
WITH DepartmentPay AS
(
    SELECT DepartmentId, AVG(Salary) AS AverageSalary
    FROM dbo.Employees
    GROUP BY DepartmentId
)
SELECT *
FROM DepartmentPay
WHERE AverageSalary > 70000;
```

**Takeaway notes:** CTEs improve readability but are not automatically materialized. Recursive CTEs can solve hierarchy problems.

## 11. Set Operators

Set operators combine result sets with compatible columns.

**Operators:** `UNION`, `UNION ALL`, `INTERSECT`, `EXCEPT`.

**Takeaway notes:** `UNION` removes duplicates, `UNION ALL` keeps duplicates and is usually faster. Column count and data types must be compatible.

## 12. Window Functions

Window functions calculate values across related rows while keeping row detail.

```sql
SELECT
    EmployeeId,
    DepartmentId,
    Salary,
    ROW_NUMBER() OVER (PARTITION BY DepartmentId ORDER BY Salary DESC) AS SalaryRank
FROM dbo.Employees;
```

**Common functions:** `ROW_NUMBER`, `RANK`, `DENSE_RANK`, `LAG`, `LEAD`, `SUM() OVER`, `AVG() OVER`.

**Takeaway notes:** `ROW_NUMBER` gives unique sequence, `RANK` leaves gaps after ties, `DENSE_RANK` does not leave gaps.

## 13. Views

A view is a saved query that behaves like a virtual table.

```sql
CREATE VIEW dbo.ActiveEmployees
AS
SELECT EmployeeId, FirstName, LastName, DepartmentId
FROM dbo.Employees
WHERE IsActive = 1;
```

**Takeaway notes:** views simplify access and can hide columns/joins. A normal view does not store data. Indexed views can store results but have restrictions.

## 14. Stored Procedures

Stored procedures are compiled T-SQL modules used to encapsulate operations.

```sql
CREATE OR ALTER PROCEDURE dbo.GetEmployeesByDepartment
    @DepartmentId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT EmployeeId, FirstName, LastName, Salary
    FROM dbo.Employees
    WHERE DepartmentId = @DepartmentId;
END;
```

**Takeaway notes:** procedures support parameters, transactions, output parameters, permissions, and reusable business operations. Use `SET NOCOUNT ON` to avoid extra row count messages.

## 15. Functions

Functions return values. Scalar functions return one value; table-valued functions return a table.

```sql
CREATE OR ALTER FUNCTION dbo.GetAnnualSalary (@MonthlySalary DECIMAL(12,2))
RETURNS DECIMAL(12,2)
AS
BEGIN
    RETURN @MonthlySalary * 12;
END;
```

**Takeaway notes:** inline table-valued functions are often better for performance than scalar functions. Functions should not be used for side effects like modifying tables.

## 16. Triggers

Triggers run automatically after or instead of table changes.

```sql
CREATE TRIGGER dbo.trg_Employees_Audit
ON dbo.Employees
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.EmployeeAudit (EmployeeId, ChangedAt)
    SELECT EmployeeId, SYSUTCDATETIME()
    FROM inserted;
END;
```

**Takeaway notes:** `inserted` and `deleted` are pseudo-tables and can contain multiple rows. Never write a trigger assuming only one row changed.

## 17. Transactions And TCL

TCL means Transaction Control Language: `BEGIN TRANSACTION`, `COMMIT`, `ROLLBACK`, `SAVE TRANSACTION`.

```sql
BEGIN TRY
    BEGIN TRANSACTION;

    UPDATE dbo.Accounts SET Balance = Balance - 100 WHERE AccountId = 1;
    UPDATE dbo.Accounts SET Balance = Balance + 100 WHERE AccountId = 2;

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;

    THROW;
END CATCH;
```

**ACID:** atomicity, consistency, isolation, durability.

**Takeaway notes:** transactions protect multi-step changes. Always handle errors and roll back if needed.

## 18. Isolation Levels, Locks, Blocking, Deadlocks

Isolation controls how transactions see each other changes.

**Levels:** `READ UNCOMMITTED`, `READ COMMITTED`, `REPEATABLE READ`, `SERIALIZABLE`, `SNAPSHOT`.

**Problems:** dirty read, non-repeatable read, phantom read, blocking, deadlock.

**Takeaway notes:** SQL Server default is commonly `READ COMMITTED`. Higher isolation can improve consistency but increase blocking. Snapshot isolation uses row versions to reduce reader/writer blocking.

## 19. Indexing And Performance Tuning

Indexes speed up reads by maintaining sorted lookup structures, but they add write/storage overhead.

**Types:** clustered index, nonclustered index, unique index, filtered index, included columns, columnstore index.

**Takeaway notes:** clustered index defines physical/logical row order for the table data, only one clustered index per table, many nonclustered indexes are allowed. Good indexes match `WHERE`, `JOIN`, `ORDER BY`, and selectivity.

**Common performance issues:** missing indexes, too many indexes, functions on indexed columns, implicit conversions, parameter sniffing, stale statistics, `SELECT *`, non-sargable predicates.

## 20. Execution Plans And Query Optimization

Execution plans show how SQL Server executes a query.

**Operators:** index seek, index scan, table scan, key lookup, nested loops, hash match, merge join, sort.

**Takeaway notes:** seek is often better than scan but not always; scans can be fine for large portions of a table. Read actual execution plans when possible because they include runtime row counts.

## 21. Normalization And Database Design

Normalization reduces duplication and update anomalies.

**Forms:** 1NF = atomic columns, 2NF = no partial dependency on part of composite key, 3NF = no transitive dependency.

**Takeaway notes:** normalize for correctness, denormalize carefully for read performance. Good schema design starts with relationships, constraints, and expected queries.

## 22. Temporary Tables, Table Variables, And CTE Choice

**Options:** local temp table `#Temp`, global temp table `##Temp`, table variable `@Table`, CTE.

**Takeaway notes:** temp tables can have indexes/statistics and are good for larger intermediate sets. Table variables are convenient for small sets. CTEs are readable but only scoped to one following statement.

## 23. Error Handling

Use `TRY...CATCH`, `THROW`, `ERROR_MESSAGE()`, `ERROR_NUMBER()`, and transactions.

```sql
BEGIN TRY
    SELECT 1 / 0;
END TRY
BEGIN CATCH
    SELECT ERROR_NUMBER() AS ErrorNumber, ERROR_MESSAGE() AS ErrorMessage;
    THROW;
END CATCH;
```

**Takeaway notes:** prefer `THROW` over old `RAISERROR` for rethrowing. In transaction code, check `@@TRANCOUNT` before rollback.

## 24. Security And DCL

DCL means Data Control Language: `GRANT`, `REVOKE`, `DENY`.

```sql
CREATE LOGIN AppLogin WITH PASSWORD = 'Use-A-Strong-Password-Here';
CREATE USER AppUser FOR LOGIN AppLogin;
GRANT SELECT, INSERT ON dbo.Employees TO AppUser;
DENY DELETE ON dbo.Employees TO AppUser;
```

**Takeaway notes:** login is server-level, user is database-level. Grant least privilege. `DENY` overrides `GRANT`.

## 25. Backup, Restore, Recovery Models

Backups protect data and support disaster recovery.

**Types:** full backup, differential backup, transaction log backup.

**Recovery models:** simple, full, bulk-logged.

**Takeaway notes:** full recovery needs log backups for point-in-time restore. Simple recovery does not support point-in-time restore through log backups.

## 26. SQL Server Agent And Jobs

SQL Server Agent schedules jobs, alerts, and maintenance tasks.

**Takeaway notes:** common jobs include backups, index maintenance, statistics updates, ETL loads, report refreshes, and cleanup tasks.

## 27. Import/Export And Bulk Operations

SQL Server supports bulk loading through `BULK INSERT`, bcp, SSIS, import/export wizard, and application loaders.

```sql
BULK INSERT dbo.ImportCustomers
FROM 'C:\Data\customers.csv'
WITH
(
    FIRSTROW = 2,
    FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n'
);
```

**Takeaway notes:** validate file format, permissions, delimiters, data types, and error rows before loading production tables.

## 28. Common Interview Traps

`WHERE` vs `HAVING`, `DELETE` vs `TRUNCATE`, `UNION` vs `UNION ALL`, `RANK` vs `DENSE_RANK`, `COUNT(*)` vs `COUNT(column)`, `NULL` comparison, left join filter placement, clustered vs nonclustered index, transaction rollback handling, `IDENTITY` vs primary key, `CHAR` vs `VARCHAR`, `NVARCHAR` vs `VARCHAR`, CTE vs temp table, `EXISTS` vs `IN`, blocking vs deadlock.

**Final revision line:** SQL interviews usually test fundamentals first: schema design, joins, grouping, transactions, indexes, query plans, and safe data modification.

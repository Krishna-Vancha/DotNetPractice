# Microsoft SQL Server Interview Questions And Syntax Practice

Practice these by writing the SQL yourself first, then compare with the syntax reminders. Questions move from basic database creation to DDL, DML, DQL, TCL, DCL, joins, functions, procedures, indexing, and interview scenarios.

---

## 1. Database And Schema Basics

1. Write syntax to create a database named `InterviewDb`.

```sql
CREATE DATABASE InterviewDb;
GO
```

2. Switch to the `InterviewDb` database.

```sql
USE InterviewDb;
GO
```

3. Create a schema named `hr`.

```sql
CREATE SCHEMA hr;
GO
```

4. Rename a database from `InterviewDb` to `InterviewPracticeDb`.

```sql
ALTER DATABASE InterviewDb MODIFY NAME = InterviewPracticeDb;
```

5. Drop a database named `InterviewPracticeDb`.

```sql
DROP DATABASE InterviewPracticeDb;
```

6. What is the difference between a login and a user?

**Answer:** login is server-level authentication; user is database-level access mapped to a login.

---

## 2. DDL: Create, Alter, Drop, Truncate

7. Create a `Departments` table with `DepartmentId` as primary key and `DepartmentName` as unique.

```sql
CREATE TABLE dbo.Departments
(
    DepartmentId INT IDENTITY(1,1) NOT NULL,
    DepartmentName NVARCHAR(100) NOT NULL,
    CONSTRAINT PK_Departments PRIMARY KEY (DepartmentId),
    CONSTRAINT UQ_Departments_DepartmentName UNIQUE (DepartmentName)
);
```

8. Create an `Employees` table with primary key, foreign key, default, check, and unique constraints.

```sql
CREATE TABLE dbo.Employees
(
    EmployeeId INT IDENTITY(1,1) NOT NULL,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(255) NOT NULL,
    Salary DECIMAL(12,2) NOT NULL,
    DepartmentId INT NOT NULL,
    IsActive BIT NOT NULL CONSTRAINT DF_Employees_IsActive DEFAULT (1),
    CreatedAt DATETIME2 NOT NULL CONSTRAINT DF_Employees_CreatedAt DEFAULT SYSUTCDATETIME(),
    CONSTRAINT PK_Employees PRIMARY KEY (EmployeeId),
    CONSTRAINT UQ_Employees_Email UNIQUE (Email),
    CONSTRAINT CK_Employees_Salary CHECK (Salary >= 0),
    CONSTRAINT FK_Employees_Departments FOREIGN KEY (DepartmentId)
        REFERENCES dbo.Departments (DepartmentId)
);
```

9. Add a new nullable column `PhoneNumber` to `Employees`.

```sql
ALTER TABLE dbo.Employees
ADD PhoneNumber NVARCHAR(20) NULL;
```

10. Alter `PhoneNumber` to allow 30 characters.

```sql
ALTER TABLE dbo.Employees
ALTER COLUMN PhoneNumber NVARCHAR(30) NULL;
```

11. Add a check constraint for salary greater than or equal to zero.

```sql
ALTER TABLE dbo.Employees
ADD CONSTRAINT CK_Employees_Salary_NonNegative CHECK (Salary >= 0);
```

12. Drop a constraint.

```sql
ALTER TABLE dbo.Employees
DROP CONSTRAINT CK_Employees_Salary_NonNegative;
```

13. Drop a column.

```sql
ALTER TABLE dbo.Employees
DROP COLUMN PhoneNumber;
```

14. Drop a table.

```sql
DROP TABLE dbo.Employees;
```

15. Truncate a table.

```sql
TRUNCATE TABLE dbo.Employees;
```

16. Difference between `DELETE`, `TRUNCATE`, and `DROP`.

**Answer:** `DELETE` removes selected rows and can use `WHERE`; `TRUNCATE` removes all rows and resets identity; `DROP` removes the table definition and data.

---

## 3. DML: Insert, Update, Delete, Merge

17. Insert one department.

```sql
INSERT INTO dbo.Departments (DepartmentName)
VALUES (N'Engineering');
```

18. Insert multiple departments.

```sql
INSERT INTO dbo.Departments (DepartmentName)
VALUES (N'HR'), (N'Finance'), (N'Sales');
```

19. Insert one employee.

```sql
INSERT INTO dbo.Employees (FirstName, LastName, Email, Salary, DepartmentId)
VALUES (N'Asha', N'Patel', N'asha.patel@example.com', 90000.00, 1);
```

20. Insert rows from another table.

```sql
INSERT INTO dbo.EmployeeArchive (EmployeeId, FullName, Salary)
SELECT EmployeeId, FirstName + N' ' + LastName, Salary
FROM dbo.Employees
WHERE IsActive = 0;
```

21. Update one employee salary.

```sql
UPDATE dbo.Employees
SET Salary = 95000.00
WHERE EmployeeId = 1;
```

22. Update employees by joining another table.

```sql
UPDATE e
SET e.Salary = e.Salary * 1.10
FROM dbo.Employees AS e
INNER JOIN dbo.Departments AS d
    ON d.DepartmentId = e.DepartmentId
WHERE d.DepartmentName = N'Engineering';
```

23. Delete inactive employees.

```sql
DELETE FROM dbo.Employees
WHERE IsActive = 0;
```

24. Delete using a join.

```sql
DELETE e
FROM dbo.Employees AS e
INNER JOIN dbo.Departments AS d
    ON d.DepartmentId = e.DepartmentId
WHERE d.DepartmentName = N'Closed Department';
```

25. Write a basic upsert using `MERGE`.

```sql
MERGE dbo.Departments AS target
USING (VALUES (N'Engineering')) AS source (DepartmentName)
    ON target.DepartmentName = source.DepartmentName
WHEN MATCHED THEN
    UPDATE SET DepartmentName = source.DepartmentName
WHEN NOT MATCHED THEN
    INSERT (DepartmentName) VALUES (source.DepartmentName);
```

26. What is the safety rule before running `UPDATE` or `DELETE`?

**Answer:** write and verify the `WHERE` condition with a `SELECT` first; use a transaction for risky changes.

---

## 4. DQL: Select, Filter, Sort

27. Select all employees.

```sql
SELECT *
FROM dbo.Employees;
```

28. Select specific columns with aliases.

```sql
SELECT
    EmployeeId AS Id,
    FirstName + N' ' + LastName AS FullName,
    Salary
FROM dbo.Employees;
```

29. Filter by salary and active status.

```sql
SELECT EmployeeId, FirstName, Salary
FROM dbo.Employees
WHERE Salary >= 75000
  AND IsActive = 1;
```

30. Use `BETWEEN`, `IN`, and `LIKE`.

```sql
SELECT *
FROM dbo.Employees
WHERE Salary BETWEEN 50000 AND 100000
  AND DepartmentId IN (1, 2, 3)
  AND Email LIKE N'%@example.com';
```

31. Find employees with no department.

```sql
SELECT *
FROM dbo.Employees
WHERE DepartmentId IS NULL;
```

32. Sort employees by salary descending and name ascending.

```sql
SELECT *
FROM dbo.Employees
ORDER BY Salary DESC, LastName ASC;
```

33. Return top 5 highest-paid employees.

```sql
SELECT TOP (5) *
FROM dbo.Employees
ORDER BY Salary DESC;
```

34. Use pagination with `OFFSET` and `FETCH`.

```sql
SELECT *
FROM dbo.Employees
ORDER BY EmployeeId
OFFSET 20 ROWS FETCH NEXT 10 ROWS ONLY;
```

35. Use `CASE` to create a salary band.

```sql
SELECT
    EmployeeId,
    Salary,
    CASE
        WHEN Salary >= 100000 THEN 'High'
        WHEN Salary >= 60000 THEN 'Medium'
        ELSE 'Low'
    END AS SalaryBand
FROM dbo.Employees;
```

---

## 5. Joins

36. Write an inner join between employees and departments.

```sql
SELECT e.EmployeeId, e.FirstName, d.DepartmentName
FROM dbo.Employees AS e
INNER JOIN dbo.Departments AS d
    ON d.DepartmentId = e.DepartmentId;
```

37. Write a left join to show all employees even if department is missing.

```sql
SELECT e.EmployeeId, e.FirstName, d.DepartmentName
FROM dbo.Employees AS e
LEFT JOIN dbo.Departments AS d
    ON d.DepartmentId = e.DepartmentId;
```

38. Find employees without matching department.

```sql
SELECT e.*
FROM dbo.Employees AS e
LEFT JOIN dbo.Departments AS d
    ON d.DepartmentId = e.DepartmentId
WHERE d.DepartmentId IS NULL;
```

39. Write a self join for employee-manager relationship.

```sql
SELECT
    e.FirstName AS EmployeeName,
    m.FirstName AS ManagerName
FROM dbo.Employees AS e
LEFT JOIN dbo.Employees AS m
    ON m.EmployeeId = e.ManagerId;
```

40. Write a cross join.

```sql
SELECT e.EmployeeId, d.DepartmentId
FROM dbo.Employees AS e
CROSS JOIN dbo.Departments AS d;
```

41. What is the difference between `INNER JOIN` and `LEFT JOIN`?

**Answer:** `INNER JOIN` returns only matching rows; `LEFT JOIN` returns all rows from the left table and matching rows from the right table.

---

## 6. Aggregation And Grouping

42. Count all employees.

```sql
SELECT COUNT(*) AS EmployeeCount
FROM dbo.Employees;
```

43. Count employees by department.

```sql
SELECT DepartmentId, COUNT(*) AS EmployeeCount
FROM dbo.Employees
GROUP BY DepartmentId;
```

44. Find average salary by department.

```sql
SELECT DepartmentId, AVG(Salary) AS AverageSalary
FROM dbo.Employees
GROUP BY DepartmentId;
```

45. Show departments having more than 5 employees.

```sql
SELECT DepartmentId, COUNT(*) AS EmployeeCount
FROM dbo.Employees
GROUP BY DepartmentId
HAVING COUNT(*) > 5;
```

46. Difference between `WHERE` and `HAVING`.

**Answer:** `WHERE` filters rows before grouping; `HAVING` filters groups after aggregation.

47. Difference between `COUNT(*)` and `COUNT(ColumnName)`.

**Answer:** `COUNT(*)` counts rows; `COUNT(ColumnName)` ignores null values in that column.

---

## 7. Subqueries, CTEs, Exists

48. Find employees whose salary is above company average.

```sql
SELECT *
FROM dbo.Employees
WHERE Salary > (SELECT AVG(Salary) FROM dbo.Employees);
```

49. Use `EXISTS` to find departments with employees.

```sql
SELECT d.*
FROM dbo.Departments AS d
WHERE EXISTS
(
    SELECT 1
    FROM dbo.Employees AS e
    WHERE e.DepartmentId = d.DepartmentId
);
```

50. Use a CTE for department salary totals.

```sql
WITH DepartmentTotals AS
(
    SELECT DepartmentId, SUM(Salary) AS TotalSalary
    FROM dbo.Employees
    GROUP BY DepartmentId
)
SELECT *
FROM DepartmentTotals
WHERE TotalSalary > 100000;
```

51. Write a recursive CTE pattern.

```sql
WITH EmployeeHierarchy AS
(
    SELECT EmployeeId, ManagerId, FirstName, 0 AS Level
    FROM dbo.Employees
    WHERE ManagerId IS NULL

    UNION ALL

    SELECT e.EmployeeId, e.ManagerId, e.FirstName, h.Level + 1
    FROM dbo.Employees AS e
    INNER JOIN EmployeeHierarchy AS h
        ON h.EmployeeId = e.ManagerId
)
SELECT *
FROM EmployeeHierarchy;
```

52. Difference between `IN` and `EXISTS`.

**Answer:** `IN` compares to a list/result set; `EXISTS` checks whether a correlated subquery returns any row. `EXISTS` is often better for existence checks.

---

## 8. Set Operators

53. Combine two result sets and remove duplicates.

```sql
SELECT Email FROM dbo.Employees
UNION
SELECT Email FROM dbo.Customers;
```

54. Combine two result sets and keep duplicates.

```sql
SELECT Email FROM dbo.Employees
UNION ALL
SELECT Email FROM dbo.Customers;
```

55. Find emails present in both employees and customers.

```sql
SELECT Email FROM dbo.Employees
INTERSECT
SELECT Email FROM dbo.Customers;
```

56. Find employee emails not present in customers.

```sql
SELECT Email FROM dbo.Employees
EXCEPT
SELECT Email FROM dbo.Customers;
```

57. Difference between `UNION` and `UNION ALL`.

**Answer:** `UNION` removes duplicates and may sort/hash; `UNION ALL` keeps duplicates and is usually faster.

---

## 9. Window Functions

58. Assign row numbers by salary descending.

```sql
SELECT
    EmployeeId,
    Salary,
    ROW_NUMBER() OVER (ORDER BY Salary DESC) AS RowNum
FROM dbo.Employees;
```

59. Rank employees inside each department by salary.

```sql
SELECT
    EmployeeId,
    DepartmentId,
    Salary,
    RANK() OVER (PARTITION BY DepartmentId ORDER BY Salary DESC) AS SalaryRank
FROM dbo.Employees;
```

60. Find second highest salary using `DENSE_RANK`.

```sql
WITH Ranked AS
(
    SELECT Salary, DENSE_RANK() OVER (ORDER BY Salary DESC) AS SalaryRank
    FROM dbo.Employees
)
SELECT DISTINCT Salary
FROM Ranked
WHERE SalaryRank = 2;
```

61. Use `LAG` to compare current salary to previous row salary.

```sql
SELECT
    EmployeeId,
    Salary,
    LAG(Salary) OVER (ORDER BY EmployeeId) AS PreviousSalary
FROM dbo.Employees;
```

62. Use running total.

```sql
SELECT
    EmployeeId,
    Salary,
    SUM(Salary) OVER (ORDER BY EmployeeId ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS RunningTotal
FROM dbo.Employees;
```

63. Difference between `ROW_NUMBER`, `RANK`, and `DENSE_RANK`.

**Answer:** `ROW_NUMBER` is unique sequence; `RANK` gives same rank for ties but leaves gaps; `DENSE_RANK` gives same rank for ties without gaps.

---

## 10. Views

64. Create a view for active employees.

```sql
CREATE VIEW dbo.vwActiveEmployees
AS
SELECT EmployeeId, FirstName, LastName, DepartmentId
FROM dbo.Employees
WHERE IsActive = 1;
```

65. Alter a view.

```sql
ALTER VIEW dbo.vwActiveEmployees
AS
SELECT EmployeeId, FirstName, LastName, Email, DepartmentId
FROM dbo.Employees
WHERE IsActive = 1;
```

66. Drop a view.

```sql
DROP VIEW dbo.vwActiveEmployees;
```

67. What is a view?

**Answer:** a saved query that can simplify access, hide complexity, and restrict visible columns/rows.

---

## 11. Stored Procedures

68. Create a stored procedure with one input parameter.

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

69. Execute a stored procedure.

```sql
EXEC dbo.GetEmployeesByDepartment @DepartmentId = 1;
```

70. Create a stored procedure with output parameter.

```sql
CREATE OR ALTER PROCEDURE dbo.GetEmployeeCount
    @DepartmentId INT,
    @EmployeeCount INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT @EmployeeCount = COUNT(*)
    FROM dbo.Employees
    WHERE DepartmentId = @DepartmentId;
END;
```

71. Execute procedure with output parameter.

```sql
DECLARE @Count INT;
EXEC dbo.GetEmployeeCount @DepartmentId = 1, @EmployeeCount = @Count OUTPUT;
SELECT @Count AS EmployeeCount;
```

72. Why use `SET NOCOUNT ON`?

**Answer:** it suppresses extra row count messages and reduces unnecessary client/server chatter.

---

## 12. Functions

73. Create a scalar function.

```sql
CREATE OR ALTER FUNCTION dbo.GetFullName
(
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50)
)
RETURNS NVARCHAR(101)
AS
BEGIN
    RETURN @FirstName + N' ' + @LastName;
END;
```

74. Use a scalar function.

```sql
SELECT dbo.GetFullName(FirstName, LastName) AS FullName
FROM dbo.Employees;
```

75. Create an inline table-valued function.

```sql
CREATE OR ALTER FUNCTION dbo.GetEmployeesAboveSalary (@MinSalary DECIMAL(12,2))
RETURNS TABLE
AS
RETURN
(
    SELECT EmployeeId, FirstName, LastName, Salary
    FROM dbo.Employees
    WHERE Salary > @MinSalary
);
```

76. Use a table-valued function.

```sql
SELECT *
FROM dbo.GetEmployeesAboveSalary(80000);
```

77. Difference between stored procedure and function.

**Answer:** function returns a value/table and can be used in queries; procedure performs operations and is executed with `EXEC`.

---

## 13. Triggers

78. Create an audit table.

```sql
CREATE TABLE dbo.EmployeeAudit
(
    AuditId INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeId INT NOT NULL,
    ActionName NVARCHAR(20) NOT NULL,
    ChangedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
);
```

79. Create an `AFTER INSERT` trigger.

```sql
CREATE TRIGGER dbo.trg_Employees_AfterInsert
ON dbo.Employees
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.EmployeeAudit (EmployeeId, ActionName)
    SELECT EmployeeId, N'INSERT'
    FROM inserted;
END;
```

80. Create an `AFTER DELETE` trigger.

```sql
CREATE TRIGGER dbo.trg_Employees_AfterDelete
ON dbo.Employees
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.EmployeeAudit (EmployeeId, ActionName)
    SELECT EmployeeId, N'DELETE'
    FROM deleted;
END;
```

81. What are `inserted` and `deleted` tables?

**Answer:** trigger pseudo-tables containing affected new rows and old rows. They can contain multiple rows.

---

## 14. TCL: Transactions

82. Write a successful transaction.

```sql
BEGIN TRANSACTION;

UPDATE dbo.Accounts SET Balance = Balance - 100 WHERE AccountId = 1;
UPDATE dbo.Accounts SET Balance = Balance + 100 WHERE AccountId = 2;

COMMIT TRANSACTION;
```

83. Write transaction with rollback.

```sql
BEGIN TRANSACTION;

UPDATE dbo.Accounts SET Balance = Balance - 100 WHERE AccountId = 1;

ROLLBACK TRANSACTION;
```

84. Write transaction with `TRY...CATCH`.

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

85. Use savepoint.

```sql
BEGIN TRANSACTION;

INSERT INTO dbo.Departments (DepartmentName) VALUES (N'Temp1');
SAVE TRANSACTION BeforeTemp2;

INSERT INTO dbo.Departments (DepartmentName) VALUES (N'Temp2');
ROLLBACK TRANSACTION BeforeTemp2;

COMMIT TRANSACTION;
```

86. What does ACID mean?

**Answer:** atomicity, consistency, isolation, durability.

---

## 15. Isolation, Locks, Blocking, Deadlocks

87. Set isolation level to read committed.

```sql
SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
```

88. Set isolation level to serializable.

```sql
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
```

89. Write a query with `NOLOCK`.

```sql
SELECT *
FROM dbo.Employees WITH (NOLOCK);
```

90. Why is `NOLOCK` risky?

**Answer:** it allows dirty reads and can return inconsistent or duplicated/missing rows.

91. What is blocking?

**Answer:** one session waits because another session holds a lock on needed data.

92. What is a deadlock?

**Answer:** two or more sessions wait on each other forever; SQL Server chooses one victim to roll back.

---

## 16. DCL: Security

93. Create a login.

```sql
CREATE LOGIN AppLogin WITH PASSWORD = 'Use-A-Strong-Password-Here';
```

94. Create a database user for that login.

```sql
CREATE USER AppUser FOR LOGIN AppLogin;
```

95. Grant select permission on a table.

```sql
GRANT SELECT ON dbo.Employees TO AppUser;
```

96. Grant insert and update permissions.

```sql
GRANT INSERT, UPDATE ON dbo.Employees TO AppUser;
```

97. Revoke permission.

```sql
REVOKE UPDATE ON dbo.Employees FROM AppUser;
```

98. Deny delete permission.

```sql
DENY DELETE ON dbo.Employees TO AppUser;
```

99. Difference between `REVOKE` and `DENY`.

**Answer:** `REVOKE` removes a grant/deny; `DENY` explicitly blocks permission and overrides grant.

---

## 17. Indexes

100. Create a clustered index.

```sql
CREATE CLUSTERED INDEX IX_Employees_EmployeeId
ON dbo.Employees (EmployeeId);
```

101. Create a nonclustered index.

```sql
CREATE NONCLUSTERED INDEX IX_Employees_DepartmentId
ON dbo.Employees (DepartmentId);
```

102. Create a covering index with included columns.

```sql
CREATE NONCLUSTERED INDEX IX_Employees_DepartmentId_Include
ON dbo.Employees (DepartmentId)
INCLUDE (FirstName, LastName, Salary);
```

103. Create a unique index.

```sql
CREATE UNIQUE INDEX UX_Employees_Email
ON dbo.Employees (Email);
```

104. Create a filtered index.

```sql
CREATE INDEX IX_Employees_Active
ON dbo.Employees (DepartmentId)
WHERE IsActive = 1;
```

105. Drop an index.

```sql
DROP INDEX IX_Employees_DepartmentId ON dbo.Employees;
```

106. Difference between clustered and nonclustered index.

**Answer:** clustered index organizes the table data by key; nonclustered index is a separate structure that points back to rows.

---

## 18. Temporary Objects

107. Create and use a local temp table.

```sql
CREATE TABLE #HighEarners
(
    EmployeeId INT,
    Salary DECIMAL(12,2)
);

INSERT INTO #HighEarners (EmployeeId, Salary)
SELECT EmployeeId, Salary
FROM dbo.Employees
WHERE Salary > 100000;

SELECT * FROM #HighEarners;
```

108. Create and use a table variable.

```sql
DECLARE @EmployeeIds TABLE
(
    EmployeeId INT PRIMARY KEY
);

INSERT INTO @EmployeeIds (EmployeeId)
SELECT EmployeeId
FROM dbo.Employees
WHERE DepartmentId = 1;

SELECT * FROM @EmployeeIds;
```

109. Difference between temp table and table variable.

**Answer:** temp tables are better for larger/intermediate data and can have statistics/indexes; table variables are convenient for small data sets.

---

## 19. Error Handling

110. Write `TRY...CATCH` syntax.

```sql
BEGIN TRY
    SELECT 1 / 0;
END TRY
BEGIN CATCH
    SELECT
        ERROR_NUMBER() AS ErrorNumber,
        ERROR_MESSAGE() AS ErrorMessage,
        ERROR_LINE() AS ErrorLine;
END CATCH;
```

111. Rethrow an error.

```sql
BEGIN CATCH
    THROW;
END CATCH;
```

112. Raise a custom error with `THROW`.

```sql
THROW 50001, 'Custom validation failed.', 1;
```

---

## 20. Variables, Control Flow, Dynamic SQL

113. Declare and set variables.

```sql
DECLARE @MinSalary DECIMAL(12,2) = 75000.00;
DECLARE @DepartmentId INT;

SET @DepartmentId = 1;
```

114. Use `IF...ELSE`.

```sql
IF EXISTS (SELECT 1 FROM dbo.Employees WHERE DepartmentId = 1)
    PRINT 'Employees exist';
ELSE
    PRINT 'No employees';
```

115. Use `WHILE`.

```sql
DECLARE @i INT = 1;

WHILE @i <= 5
BEGIN
    PRINT @i;
    SET @i += 1;
END;
```

116. Use dynamic SQL safely with `sp_executesql`.

```sql
DECLARE @Sql NVARCHAR(MAX) = N'
SELECT EmployeeId, FirstName, LastName
FROM dbo.Employees
WHERE DepartmentId = @DepartmentId;';

EXEC sys.sp_executesql
    @Sql,
    N'@DepartmentId INT',
    @DepartmentId = 1;
```

117. Why avoid string concatenation in dynamic SQL?

**Answer:** it can cause SQL injection, quoting bugs, and poor plan reuse.

---

## 21. Backup, Restore, Bulk

118. Full database backup.

```sql
BACKUP DATABASE InterviewDb
TO DISK = 'C:\Backups\InterviewDb_full.bak'
WITH INIT;
```

119. Restore database.

```sql
RESTORE DATABASE InterviewDb_Restore
FROM DISK = 'C:\Backups\InterviewDb_full.bak'
WITH RECOVERY;
```

120. Bulk insert from CSV.

```sql
BULK INSERT dbo.ImportEmployees
FROM 'C:\Data\employees.csv'
WITH
(
    FIRSTROW = 2,
    FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n'
);
```

---

## 22. Common Interview Query Problems

121. Find duplicate emails.

```sql
SELECT Email, COUNT(*) AS DuplicateCount
FROM dbo.Employees
GROUP BY Email
HAVING COUNT(*) > 1;
```

122. Delete duplicate rows keeping the lowest `EmployeeId`.

```sql
WITH Duplicates AS
(
    SELECT
        EmployeeId,
        ROW_NUMBER() OVER (PARTITION BY Email ORDER BY EmployeeId) AS RowNum
    FROM dbo.Employees
)
DELETE FROM Duplicates
WHERE RowNum > 1;
```

123. Find second highest salary.

```sql
SELECT MAX(Salary) AS SecondHighestSalary
FROM dbo.Employees
WHERE Salary < (SELECT MAX(Salary) FROM dbo.Employees);
```

124. Find nth highest salary using `DENSE_RANK`.

```sql
DECLARE @N INT = 3;

WITH Ranked AS
(
    SELECT Salary, DENSE_RANK() OVER (ORDER BY Salary DESC) AS SalaryRank
    FROM dbo.Employees
)
SELECT DISTINCT Salary
FROM Ranked
WHERE SalaryRank = @N;
```

125. Find employees earning more than their department average.

```sql
WITH DepartmentAverage AS
(
    SELECT DepartmentId, AVG(Salary) AS AverageSalary
    FROM dbo.Employees
    GROUP BY DepartmentId
)
SELECT e.*
FROM dbo.Employees AS e
INNER JOIN DepartmentAverage AS da
    ON da.DepartmentId = e.DepartmentId
WHERE e.Salary > da.AverageSalary;
```

126. Get latest order per customer.

```sql
WITH RankedOrders AS
(
    SELECT
        OrderId,
        CustomerId,
        OrderDate,
        ROW_NUMBER() OVER (PARTITION BY CustomerId ORDER BY OrderDate DESC) AS RowNum
    FROM dbo.Orders
)
SELECT *
FROM RankedOrders
WHERE RowNum = 1;
```

127. Find missing identity values in a table.

```sql
SELECT a.EmployeeId + 1 AS MissingStart
FROM dbo.Employees AS a
LEFT JOIN dbo.Employees AS b
    ON b.EmployeeId = a.EmployeeId + 1
WHERE b.EmployeeId IS NULL;
```

128. Pivot sales by year.

```sql
SELECT *
FROM
(
    SELECT SalesPerson, SalesYear, Amount
    FROM dbo.Sales
) AS sourceData
PIVOT
(
    SUM(Amount)
    FOR SalesYear IN ([2024], [2025], [2026])
) AS p;
```

129. Unpivot year columns into rows.

```sql
SELECT SalesPerson, SalesYear, Amount
FROM dbo.SalesPivoted
UNPIVOT
(
    Amount FOR SalesYear IN ([2024], [2025], [2026])
) AS u;
```

130. Write a query to return departments with zero employees.

```sql
SELECT d.*
FROM dbo.Departments AS d
LEFT JOIN dbo.Employees AS e
    ON e.DepartmentId = d.DepartmentId
WHERE e.EmployeeId IS NULL;
```

---

## 23. Quick Concept Questions

131. What is normalization?

**Answer:** organizing tables to reduce duplication and update anomalies.

132. What is denormalization?

**Answer:** intentionally adding redundancy to improve read performance or simplify queries.

133. What is a primary key?

**Answer:** column or columns that uniquely identify each row and cannot be null.

134. What is a foreign key?

**Answer:** constraint that enforces a relationship to a key in another table.

135. What is an identity column?

**Answer:** auto-generated numeric column using seed and increment.

136. What is a sargable predicate?

**Answer:** a search condition that can use an index efficiently, such as `Column = @Value`.

137. Give example of non-sargable predicate.

```sql
WHERE YEAR(CreatedAt) = 2026
```

Better:

```sql
WHERE CreatedAt >= '20260101'
  AND CreatedAt < '20270101'
```

138. What causes implicit conversion problems?

**Answer:** comparing different data types, such as `NVARCHAR` parameter against `VARCHAR`/numeric/date column, causing scans or wrong estimates.

139. What is parameter sniffing?

**Answer:** SQL Server creates a plan based on first parameter values; that plan may be poor for different values later.

140. What should you inspect for slow query troubleshooting?

**Answer:** actual execution plan, indexes, statistics, row estimates vs actual rows, waits/blocking, reads, CPU, duration, and query predicates.

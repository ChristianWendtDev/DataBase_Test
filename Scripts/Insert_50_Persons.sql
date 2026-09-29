-- Inserts 50 sample rows into dbo.Persons
-- Assumes dbo.Persons has columns: FirstName (nvarchar), LastName (nvarchar), Email (nvarchar), BirthDate (date)

SET NOCOUNT ON;

BEGIN TRANSACTION;

DECLARE @i INT = 1;
WHILE @i <= 50
BEGIN
	INSERT INTO dbo.Persons (FirstName, LastName, Email, BirthDate)
	VALUES (
		'First' + RIGHT('00' + CAST(@i AS varchar(3)), 3),
		'Last' + RIGHT('00' + CAST(@i AS varchar(3)), 3),
		CONCAT('person', @i, '@example.com'),
		DATEADD(DAY, -(@i * 365 % 12000), CAST('1980-01-01' AS date))
	);

	SET @i += 1;
END;

COMMIT TRANSACTION;

-- Verify
SELECT TOP (50) * FROM dbo.Persons ORDER BY (SELECT 0);

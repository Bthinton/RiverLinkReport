--x Create query where transpondernumber, year, and month can be specified and return each crossing by day
--Alternating Color column(grey or white) added to end of table
-- even = white     odd = grey
/*
DECLARE @Monthdays Table(
[Day] int)
DECLARE @Day int = 1
WHILE @Day < 32 
BEGIN
	INSERT INTO @Monthdays (Day) VALUES(@Day)
	SET @Day = @Day + 1
END

DECLARE @TransNumber int,
@Year int,
@Month int

SELECT @Transnumber = 0, @Year = 0, @Month = 3

SELECT t.[TransponderNumber] AS [Transponder Number],
t.[Month],
t.[Year],
(CASE
	WHEN m.[Day] IS NULL THEN 0
	ELSE m.[Day]
END) AS [Day],
(CASE
	WHEN m.[Day] % 2 = 0 THEN 'White'
	ELSE 'Grey'
END) AS [Row Color]
	
	

FROM (
SELECT TransponderNumber,
Day(TransactionDate) AS [Days],
Month(TransactionDate) AS [Month],
Year(TransactionDate) AS [Year]
FROM [Transaction]
) AS t

LEFT OUTER JOIN (
SELECT *
FROM @Monthdays
) AS m on m.[Day] = t.[Days]

WHERE (@Transnumber = 0 OR t.TransponderNumber = @Transnumber)
AND (@Year = 0 OR t.Year = @Year)
AND (@Month = 0 OR t.Month = @Month)
ORDER BY m.[Day] asc



Returns most recent transaction

SELECT max(TransactionDate) FROM [Transaction] 


SELECT TOP 1 TransactionDate
FROM [Transaction]
ORDER BY TransactionDate desc
*/ 


DECLARE @YEAR int = 2017, @Month int = 0, @TransponderNumber int = 11018

SELECT DISTINCT Year(TransactionDate) AS [Year]
FROM [Transaction]
WHERE TransactionType = 'toll'
AND (@Month = 0 OR Month(TransactionDate) = @Month) 
AND (@TransponderNumber = 0 OR TransponderNumber = @TransponderNumber)
ORDER BY Year(TransactionDate)

SELECT DISTINCT Month(TransactionDate) AS [Month]
FROM [Transaction]
WHERE TransactionType = 'toll'
AND (@Year = 0 OR Year(TransactionDate) = @Year)
AND (@TransponderNumber = 0 OR TransponderNumber = @TransponderNumber)
ORDER BY Month(TransactionDate)

SELECT DISTINCT TransponderNumber AS [Transponder Number]
FROM [Transaction]
WHERE TransactionType = 'toll'
AND (@Year = 0 OR Year(TransactionDate) = @Year)
AND (@Month = 0 OR Month(TransactionDate) = @Month)
ORDER BY TransponderNumber


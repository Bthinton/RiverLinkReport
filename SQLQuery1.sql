-- Create query where transpondernumber, year, and month can be specified and return each crossing by day
--Alternating Color column(grey or white) added to end of table
-- even = white     odd = grey

DECLARE @Monthdays Table(
[Day] int)
DECLARE @Day int = 1
WHILE @Day < 32 
BEGIN
	INSERT INTO @Monthdays (Day) VALUES(@Day)
	SET @Day = @Day + 1
END

SELECT * FROM @Monthdays

SELECT * FROM [Transaction] WHERE TransactionType = 'toll' AND TransponderNumber = '11017'
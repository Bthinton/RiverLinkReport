/*
Select [Journal_Id], COUNT([Journal_Id]) AS [Count] FROM [Transaction] Group BY [Journal_Id] Order BY COUNT([Journal_Id]) Desc
Select * FROM [Transaction] Where Journal_Id = 7931512
--Delete From [Transaction] 

--Group by just month and year to return sum of all transponder charges(another derived table)
Select 
TransponderNumber, 
Month(TransactionDate) AS [Month], 
Year(TransactionDate) AS [Year], 
COUNT(TransactionNumber) as [Count],
(case
	WHEN COUNT(TransactionNumber) >= 40 THEN COUNT(TransactionNumber) * 1
	Else COUNT(TransactionNumber) * 2
end) AS [Charges]
From [Transaction] 
Where TransactionType = 'toll' 
Group By TransponderNumber,  Month(TransactionDate), Year(TransactionDate)
Order By Year(TransactionDate) desc, Month(TransactionDate), TransponderNumber

Select 
t.[Month], 
t.[Year],
t.[TotalCharged],
(Case 
	When d.[TotalDiscounted] is Null Then 0
	Else d.[TotalDiscounted]
End) AS TotalDiscounted,
(t.TotalCharged - (Case 
	When d.[TotalDiscounted] is Null Then 0
	Else d.[TotalDiscounted]
End)) AS [AdjustedAmount]

From (Select
Month(TransactionDate) AS [Month], 
Year(TransactionDate) AS [Year], 
Sum(Amount) AS [TotalCharged]
from [Transaction]
Where TransactionType = 'Payment'
Group By Amount,  Month(TransactionDate), Year(TransactionDate)) AS t

Left outer join (Select
Month(TransactionDate) AS [Month], 
Year(TransactionDate) AS [Year], 
Sum(Amount) AS [TotalDiscounted]
from [Transaction]
Where TransactionType = 'Discount'
Group By Month(TransactionDate), Year(TransactionDate)) AS d ON d.[Month] = t.[Month] and d.[Year] = t.[Year]
Order By t.Year, t.Month

Select * From [Transaction] Where TransactionType = 'discount' and Month(TransactionDate) = 1 and Year(TransactionDate) = 2017
*/
Declare @Year int,
@EndingMonth int,
@StartingMonth int

--SET @StartingMonth = 4
--SET @EndingMonth = 5
--SET @Year = 2017

Select @StartingMonth = 4, @EndingMonth = 5, @Year = 2017

Select 
t.[Month],
t.[Year],
(case
	When t.AmountCharged is null Then 0
	Else t.AmountCharged
end) as [AmountCharged],
(case 
	When d.AmountDiscounted is null Then 0
	Else d.AmountDiscounted
end) as [AmountDiscounted],
(case 
	When Summary.CalculatedCharges is null Then 0
	Else Summary.CalculatedCharges
end) as [CalculatedCharges],
((case
	When t.AmountCharged is null Then 0
	Else t.AmountCharged
end) - (case 
	When d.AmountDiscounted is null Then 0
	Else d.AmountDiscounted
end) - (case 
	When Summary.CalculatedCharges is null Then 0
	Else Summary.CalculatedCharges
end)) [AmountOwed]

From (Select  
Month(TransactionDate) AS [Month], 
Year(TransactionDate) AS [Year],
Sum(Amount) AS [AmountCharged]
From [Transaction] 
Where TransactionType = 'toll' 
Group By Amount,  Month(TransactionDate), Year(TransactionDate)) as t

Left outer join (Select  
Month(TransactionDate) AS [Month], 
Year(TransactionDate) AS [Year],
Sum(Amount) AS [AmountDiscounted]
From [Transaction] 
Where TransactionType = 'discount' 
Group By Month(TransactionDate), Year(TransactionDate)) as d on d.Month = t.Month and d.Year = t.Year


Left outer join(Select
S.Month,
S.Year,
Sum(S.Charges) AS [CalculatedCharges]

FROM (Select
TransponderNumber, 
Month(TransactionDate) AS [Month], 
Year(TransactionDate) AS [Year], 
COUNT(TransactionNumber) as [Count],
(case
	WHEN COUNT(TransactionNumber) >= 40 THEN COUNT(TransactionNumber) * 1
	Else COUNT(TransactionNumber) * 2
end) AS [Charges]
From [Transaction] 
Where TransactionType = 'toll' 
Group By TransponderNumber,  Month(TransactionDate), Year(TransactionDate)) as S
Group By S.Month, S.Year) AS Summary ON Summary.Month = t.Month AND Summary.Year = t.Year
WHERE t.Year = @Year AND (@StartingMonth = 0 OR t.Month BETWEEN @StartingMonth and @EndingMonth)
Order By t.Year desc, T.Month desc




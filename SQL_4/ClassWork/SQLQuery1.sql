SELECT LEN('Test');

SELECT P.[Name], LEN(P.[Name]) as 'LEN'
FROM Product as P;

SELECT P.[Name], LEN(P.[Name]) as 'LEN'
FROM Product as P
WHERE LEN(P.[Name]) > 20;

DECLARE @year AS INT
SET @year = YEAR(GETUTCDATE());
SELECT @year;

SELECT MONTH(O.OrderDate) FROM dbo.[Order] as O;

SELECT * FROM dbo.[Order] as O
WHERE YEAR(O.OrderDate) like 2017;

SELECT COUNT(P.Id) FROM Product as P;

SELECT MAX(O.OrderDate) AS 'Max order date', MIN(O.OrderDate) as 'Min order date' 
FROM dbo.[Order] as O;

--3
SELECT MAX(O.CustomerId) FROM [dbo].[Order] AS O;

--4
SELECT AVG(O.Discount) FROM [dbo].[Order] AS O;

--7
 SELECT MAX(LEN(P.Name)) FROM [dbo].[Product] AS P;

--6 
 SELECT MAX(O.OrderDate) FROM [dbo].[Order] AS O
 WHERE YEAR(O.OrderDate) like 2018;

 --2
 SELECT COUNT(DISTINCT OI.OrderId) FROM [dbo].[OrderItem] AS OI;

 SELECT C.Id, C.Name
 FROM [dbo].Customer AS C
 WHERE C.Id IN (
	SELECT O.CustomerId
	FROM [dbo].[Order] AS O
	WHERE YEAR(O.OrderDate) = 2018);

SELECT P1.Id, P1.Name FROM Product AS P1
WHERE LEN(P1.Name) = (
	SELECT MAX(LEN(Name))
	FROM Product);

--1
SELECT O.Id
FROM [dbo].[Order] AS O
WHERE
	O.Discount = (SELECT MAX(O1.Discount) FROM [dbo].[Order] AS O1
	WHERE YEAR(O1.OrderDate) = 2016);

--2
SELECT O.Id FROM [dbo].[Order] AS O
WHERE O.OrderDate = (
	SELECT MIN(O1.OrderDate) FROM [dbo].[Order] AS O1
	WHERE YEAR(O1.OrderDate) = 2019);

--3
SELECT C.Id, C.Name FROM [dbo].[Customer] AS C
WHERE C.Id = (
	SELECT O.CustomerId FROM [dbo].[Order] AS O
	Where O.Discount = (
	SELECT MAX(O1.Discount) FROM [dbo].[Order] AS O1
	WHERE YEAR(O1.OrderDate) = 2016));

--4 
SELECT C.Id, C.Name FROM [dbo].[Customer] AS C
WHERE C.Id = (
	SELECT O.CustomerId FROM [dbo].[Order] AS O
		WHERE O.OrderDate = (
			SELECT MIN(O1.OrderDate) FROM [dbo].[Order] AS O1
			WHERE YEAR(O1.OrderDate) = 2019));

SELECT P.Id AS 'Product ID',  P.Name, P.Price, OI.NumberOfItems, P.Price * OI.NumberOfItems
FROM dbo.OrderItem AS OI
INNER JOIN dbo.Product AS P
	ON P.Id = OI.ProductId
WHERE OI.OrderId = 22

SELECT SUM(P.Price * OI.NumberOfItems) AS 'Total sum'
FROM dbo.OrderItem AS OI
INNER JOIN dbo.Product AS P
	ON P.Id = OI.ProductId
WHERE OI.OrderId = 22


SELECT (SELECT SUM(OI.NumberOfItems * P.Price) AS 'Total sum' FROM [dbo].[Order] AS O
INNER JOIN dbo.Customer AS C ON O.CustomerId = C.Id
INNER JOIN [dbo].[OrderItem] AS OI ON O.Id = OI.OrderId
INNER JOIN [dbo].[Product] AS P ON  OI.ProductId = P.Id
WHERE C.[Name] = 'Мария') 
	/
(SELECT SUM(OI.NumberOfItems * P.Price) AS 'Total sum' FROM [dbo].[Order] AS O
INNER JOIN dbo.Customer AS C ON O.CustomerId = C.Id
INNER JOIN [dbo].[OrderItem] AS OI ON O.Id = OI.OrderId
INNER JOIN [dbo].[Product] AS P ON  OI.ProductId = P.Id) * 100 AS 'Maria percentage';

SELECT SUM(Total) FROM (
SELECT ((1 - ISNULL(O.Discount, 0)) * SUM(OI.NumberOfItems * P.Price)) AS Total FROM [dbo].[Order] AS O
INNER JOIN dbo.Customer AS C ON O.CustomerId = C.Id
INNER JOIN [dbo].[OrderItem] AS OI ON O.Id = OI.OrderId
INNER JOIN [dbo].[Product] AS P ON  OI.ProductId = P.Id
WHERE C.[Name] = 'Мария'
GROUP BY O.Discount) AS SubTotal

SELECT SubTotal.[Name], SUM(Total) FROM (
SELECT C.[Name], ((1 - ISNULL(O.Discount, 0)) * SUM(OI.NumberOfItems * P.Price)) AS Total FROM [dbo].[Order] AS O
INNER JOIN dbo.Customer AS C ON O.CustomerId = C.Id
INNER JOIN [dbo].[OrderItem] AS OI ON O.Id = OI.OrderId
INNER JOIN [dbo].[Product] AS P ON  OI.ProductId = P.Id
GROUP BY O.Discount, C.[Name]) AS SubTotal GROUP BY SubTotal.[Name]


DECLARE @totalSum AS MONEY

SELECT @totalSum = SUM(Total) FROM (
SELECT C.[Name], ((1 - ISNULL(O.Discount, 0)) * SUM(OI.NumberOfItems * P.Price)) AS Total FROM [dbo].[Order] AS O
INNER JOIN dbo.Customer AS C ON O.CustomerId = C.Id
INNER JOIN [dbo].[OrderItem] AS OI ON O.Id = OI.OrderId
INNER JOIN [dbo].[Product] AS P ON  OI.ProductId = P.Id
GROUP BY O.Discount, C.[Name]) AS SubTotal

SELECT SubTotal.[Name], SUM(Total) AS 'Сумма', SUM(Total) / @totalSum * 100 AS 'Доля' FROM (
SELECT C.[Name], ((1 - ISNULL(O.Discount, 0)) * SUM(OI.NumberOfItems * P.Price)) AS Total FROM [dbo].[Order] AS O
INNER JOIN dbo.Customer AS C ON O.CustomerId = C.Id
INNER JOIN [dbo].[OrderItem] AS OI ON O.Id = OI.OrderId
INNER JOIN [dbo].[Product] AS P ON  OI.ProductId = P.Id
GROUP BY O.Discount, C.[Name]) AS SubTotal GROUP BY SubTotal.[Name]

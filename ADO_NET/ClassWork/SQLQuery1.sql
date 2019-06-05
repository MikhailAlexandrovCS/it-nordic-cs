CREATE PROCEDURE dbo.AddProduct(
	@name AS VARCHAR(300),
	@price AS SMALLMONEY,
	@id AS INT OUTPUT)
AS
BEGIN

	INSERT INTO [dbo].[Product]([Name],[Price])
     VALUES (@name, @price)

	SELECT @id = SCOPE_IDENTITY();


END
GO

SELECT * FROM dbo.Product WHERE Id like 21;

CREATE PROCEDURE dbo.AddOrder(
	@customerId AS INT,
	@orderDate AS DATETIMEOFFSET,
	@discount AS FLOAT = NULL,
	@id AS INT OUTPUT)
AS
BEGIN
	INSERT INTO dbo.[Order](CustomerId, OrderDate, Discount)
	VALUES (@customerId, @orderDate, @discount)

	SELECT @id = SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE dbo.AddOrderItem(
	@orderId AS INT,
	@productId AS INT,
	@numberOfItems AS INT)
AS
BEGIN
	INSERT INTO dbo.[OrderItem](OrderId, ProductId, NumberOfItems)
	VALUES (@orderId, @productId, @numberOfItems);
END
GO
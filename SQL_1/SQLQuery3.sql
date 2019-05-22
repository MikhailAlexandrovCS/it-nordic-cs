SELECT
	HolderName,
	ExpirationYear
FROM dbo.CreditCard;


CREATE TABLE PostSending
(
	SenderName nvarchar(60),
	ReceiverName nvarchar(60),
	DocumentTitle varchar(30) null,
	NumberOfPages tinyint,
	SendingDate datetimeoffset,
	ExpectedReceivingDate datetimeoffset
);

INSERT INTO PostSending
	(SenderName,
	ReceiverName,
	DocumentTitle,
	NumberOfPages,
	SendingDate,
	ExpectedReceivingDate)
VALUES
	('Alexandrov Mikhail Andreevich',
	'Tsarev Nikolay Vladimirovich',
	'TestDocumnetName',
	5,
	'2019-06-04',
	'2019-09-19'
	);

SELECT
	*
FROM PostSending;


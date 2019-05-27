CREATE DATABASE AirportInfo;

CREATE TABLE DepartureBoard
(
	flightNumber varchar(6),
	cityCountry nvarchar(30),
	departureTime datetimeoffset,
	flightTime time,
	airLine varchar(20),
	planeModel nvarchar(30)
);

INSERT INTO DepartureBoard
	(flightNumber,
	cityCountry,
	departureTime,
	flightTime,
	airLine,
	planeModel)
VALUES
	('AC9382',
	'Moscow Russia',
	'2019-10-11 13:00',
	'02:00',
	'Aeroflot',
	'SSJ-100'
	);

INSERT INTO DepartureBoard
	(flightNumber,
	cityCountry,
	departureTime,
	flightTime,
	airLine,
	planeModel)
VALUES
	('AM3013',
	'Rome Italy',
	'2020-10-11 09:30',
	'03:30',
	'Pobeda',
	'Boeing'
	);

INSERT INTO DepartureBoard
	(flightNumber,
	cityCountry,
	departureTime,
	flightTime,
	airLine,
	planeModel)
VALUES
	('AC1032',
	'Berlin Germany',
	'2019-09-11 07:00',
	'03:15',
	'S7',
	'Airbus'
	);

SELECT * FROM DepartureBoard;

DROP DATABASE AirportInfo;
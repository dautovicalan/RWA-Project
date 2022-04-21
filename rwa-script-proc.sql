use RwaApartmani

ALTER PROC GetApartments
AS
BEGIN
	SELECT ap.Id, ap.Name, c.Name AS CityName, ap.MaxAdults, ap.MaxChildren, ap.TotalRooms, COUNT(app.ApartmentId) AS PictureNumber, ap.Price	 
	FROM Apartment AS ap
	INNER JOIN City AS c ON c.Id = ap.CityId
	INNER JOIN ApartmentPicture AS app ON app.ApartmentId = ap.Id
	GROUP BY ap.Id, ap.Name, c.Name, ap.MaxAdults, ap.MaxChildren, ap.TotalRooms, ap.Price
END

CREATE PROC GetApartmentById
	@id INT
AS
BEGIN
	SELECT * FROM Apartment WHERE Id = @id
END

ALTER PROC CreateApartment
	@guid UNIQUEIDENTIFIER,
	@createdAt DATETIME,
	@ownerId INT,
	@typeId INT,
	@statusId INT,
	@cityId INT,
	@address NVARCHAR(250),
	@name NVARCHAR(250),
	@nameEng NVARCHAR(250),
	@price MONEY,
	@maxAdults INT,
	@maxChildren INT,
	@totalRooms INT,
	@beachDistance INT
AS
BEGIN
 INSERT INTO Apartment (Guid, CreatedAt, DeletedAt, OwnerId, TypeId, StatusId, CityId, Address, Name, NameEng, Price, MaxAdults, MaxChildren, TotalRooms, BeachDistance)
 VALUES (
 @guid, 
 @createdAt,
 null,
 @ownerId, 
 @typeId, 
 @statusId, 
 @cityId, 
 @address,
 @name, 
 @nameEng, 
 @price, 
 @maxAdults, 
 @maxChildren,
 @totalRooms,
 @beachDistance
 )
END


CREATE PROC GetTags
AS
BEGIN
	SELECT * FROM Tag
END

CREATE PROC GetTagById
	@id INT
AS
BEGIN
	SELECT * FROM Tag WHERE Id = @id
END


CREATE PROC CreateTag
	@guid UNIQUEIDENTIFIER,
	@createdAt DATETIME,
	@typeId INT,
	@name NVARCHAR(250),
	@nameEng NVARCHAR(250)
AS
BEGIN
	INSERT INTO Tag (Guid, CreatedAt, TypeId, Name, NameEng) VALUES (@guid, @createdAt, @typeId, @name, @nameEng)
END

CREATE PROC TagCount
	@id INT
AS
BEGIN
	SELECT COUNT(*) AS 'COUNT' FROM TaggedApartment WHERE TagId = @id
END	


CREATE PROC GetAspNetUsers
AS
BEGIN
	SELECT * FROM AspNetUsers
END

CREATE PROC GetCitys
AS
BEGIN
	SELECT Id, Name FROM City
END


CREATE PROC GetApartmentStatuses
AS
BEGIN
	SELECT Id, NameEng FROM ApartmentStatus
END

CREATE PROC GetApartmentOwners
AS
BEGIN
	SELECT Id, Name FROM ApartmentOwner
END


SELECT ap.Id, ap.Name, c.Name, ap.MaxAdults, ap.MaxChildren, ap.TotalRooms, COUNT(app.ApartmentId) AS PictureNumber, ap.Price	 
FROM Apartment AS ap
INNER JOIN City AS c ON c.Id = ap.CityId
INNER JOIN ApartmentPicture AS app ON app.ApartmentId = ap.Id
GROUP BY ap.Id, ap.Name, c.Name, ap.MaxAdults, ap.MaxChildren, ap.TotalRooms, ap.Price

SELECT * FROM ApartmentPicture
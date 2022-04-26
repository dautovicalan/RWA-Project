use RwaApartmani

ALTER PROC GetApartments
AS
BEGIN
	SELECT ap.Id, ap.Name, c.Name AS CityName, ap.MaxAdults, ap.MaxChildren, ap.TotalRooms, COUNT(app.ApartmentId) AS PictureNumber, ap.Price, ap.BeachDistance, ass.NameEng	 
	FROM Apartment AS ap
	LEFT JOIN City AS c ON c.Id = ap.CityId
	LEFT JOIN ApartmentPicture AS app ON app.ApartmentId = ap.Id
	LEFT JOIN ApartmentStatus AS ass ON ass.Id = ap.StatusId
	WHERE ap.DeletedAt IS NULL
	GROUP BY ap.Id, ap.Name, c.Name, ap.MaxAdults, ap.MaxChildren, ap.TotalRooms, ap.Price, ap.BeachDistance, ass.NameEng
END


ALTER PROC GetApartmentById
	@id INT
AS
BEGIN
	SELECT ap.Id, ap.Name, c.Name AS CityName, ap.MaxAdults, ap.MaxChildren, ap.TotalRooms, COUNT(app.ApartmentId) AS PictureNumber, ap.Price, ap.BeachDistance	 
	FROM Apartment AS ap
	LEFT JOIN City AS c ON c.Id = ap.CityId
	LEFT JOIN ApartmentPicture AS app ON app.ApartmentId = ap.Id
	WHERE ap.Id = @id
	GROUP BY ap.Id, ap.Name, c.Name, ap.MaxAdults, ap.MaxChildren, ap.TotalRooms, ap.Price, ap.BeachDistance
END

CREATE PROC SoftDeleteApartmentById
	@id INT
AS
BEGIN
	UPDATE Apartment
	SET DeletedAt = GETDATE()
	WHERE Id = @id
END

CREATE PROC UpdateApartmentById
	@id INT,
	@statusId INT,
	@totalRooms INT,
	@maxAdults INT,
	@maxChildren INT,
	@beachDistance INT
AS
BEGIN
	UPDATE Apartment
	SET StatusId = @statusId, TotalRooms = @totalRooms, MaxAdults = @maxAdults, 
		MaxChildren = @maxChildren, BeachDistance = @beachDistance
	WHERE Id = @id
END

CREATE PROC CreateApartment
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


ALTER PROC GetTags
AS
BEGIN
	SELECT Tag.Id, Tag.Name, Tag.NameEng AS NameEng, COUNT(TaggedApartment.TagId) AS TagApperance
	FROM Tag
	LEFT JOIN TaggedApartment ON Tag.Id = TaggedApartment.TagId
	GROUP BY Tag.Id, Tag.Name, Tag.NameEng
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

--DELETING TAGS
CREATE PROC DeleteTagById
	@id INT
AS
BEGIN
	DELETE FROM Tag WHERE Id = @id
END

-- DEPRICATED !!
--CREATE PROC TagCount
--	@id INT
--AS
--BEGIN
--	SELECT COUNT(*) AS 'COUNT' FROM TaggedApartment WHERE TagId = @id
--END	

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


create PROC GetApartmentReservations
AS
BEGIN
	SELECT ar.Id, ar.CreatedAt, a.Id AS ApartmentId, a.Name, ar.Details, ar.UserId, ar.UserName, ar.UserEmail, ar.UserPhone, ar.UserAddress
	FROM ApartmentReservation AS ar
	LEFT JOIN Apartment AS a ON a.Id = ar.ApartmentId
END

CREATE PROC CreateApartmentReservationRegisteredUser
	@guid UNIQUEIDENTIFIER,
	@createdAt DATETIME,
	@apartmentId INT,
	@details NVARCHAR(1000),
	@userId INT
AS
BEGIN
 INSERT INTO ApartmentReservation(Guid, CreatedAt, ApartmentId, Details, UserId, UserName, UserEmail, UserPhone, UserAddress)
 VALUES (@guid, @createdAt, @apartmentId, @details, @userId, null, null, null, null)
END

CREATE PROC CreateApartmentReservationNonRegisteredUser
	@guid UNIQUEIDENTIFIER,
	@createdAt DATETIME,
	@apartmentId INT,
	@details NVARCHAR(1000),
	@userName NVARCHAR(250),
	@userEmail NVARCHAR(250),
	@userPhone NVARCHAR(20),
	@userAddress NVARCHAR(1000)
AS
BEGIN
 INSERT INTO ApartmentReservation(Guid, CreatedAt, ApartmentId, Details, UserId, UserName, UserEmail, UserPhone, UserAddress)
 VALUES (@guid, @createdAt, @apartmentId, @details, null, @userName, @userEmail, @userPhone, @userAddress)
END

	SELECT Tag.Id, Tag.Name, Tag.NameEng AS NameEng, COUNT(TaggedApartment.TagId) AS TagApperance
	FROM Tag
	INNER JOIN TaggedApartment ON Tag.Id = TaggedApartment.TagId
	GROUP BY Tag.Id, Tag.Name, Tag.NameEng

SELECT * FROM Apartment

SELECT * FROM ApartmentReservation
SELECT * FROM ApartmentStatus
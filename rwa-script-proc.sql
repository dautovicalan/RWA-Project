use RwaApartmani

ALTER PROC GetApartments
AS
BEGIN
	SELECT ap.Id, ap.Name, c.Name AS CityName, ap.MaxAdults, ap.MaxChildren, ap.TotalRooms, COUNT(app.ApartmentId) AS PictureNumber, ap.Price, ap.BeachDistance, ass.NameEng, ao.Name AS OwnerName, AVG(ar.Stars) AS ApartmentStars
	FROM Apartment AS ap
	LEFT JOIN City AS c ON c.Id = ap.CityId
	LEFT JOIN ApartmentPicture AS app ON app.ApartmentId = ap.Id
	LEFT JOIN ApartmentStatus AS ass ON ass.Id = ap.StatusId
	LEFT JOIN ApartmentOwner AS ao ON ao.Id = ap.OwnerId
	LEFT JOIN ApartmentReview AS ar ON ar.ApartmentId = ap.Id
	WHERE ap.DeletedAt IS NULL
	GROUP BY ap.Id, ap.Name, c.Name, ap.MaxAdults, ap.MaxChildren, ap.TotalRooms, ap.Price, ap.BeachDistance, ass.NameEng, ao.Name 
END

ALTER PROC GetApartmentsFilteredByStatusCity
	@statusId INT,
	@cityId INT
AS
BEGIN
	SELECT ap.Id, ap.Name, c.Name AS CityName, ap.MaxAdults, ap.MaxChildren, ap.TotalRooms, COUNT(app.ApartmentId) AS PictureNumber, ap.Price, ap.BeachDistance, ass.NameEng, AVG(ar.Stars) AS ApartmentStars	 
	FROM Apartment AS ap
	LEFT JOIN City AS c ON c.Id = ap.CityId
	LEFT JOIN ApartmentPicture AS app ON app.ApartmentId = ap.Id
	LEFT JOIN ApartmentStatus AS ass ON ass.Id = ap.StatusId
	LEFT JOIN ApartmentReview AS ar ON ar.ApartmentId = ap.Id
	WHERE ap.DeletedAt IS NULL AND ass.Id = @statusId AND c.Id = @cityId
	GROUP BY ap.Id, ap.Name, c.Name, ap.MaxAdults, ap.MaxChildren, ap.TotalRooms, ap.Price, ap.BeachDistance, ass.NameEng
END


SELECT *
FROM Apartment AS ap
INNER JOIN ApartmentStatus AS ass ON ass.Id = ap.StatusId
INNER JOIN City AS c ON c.Id = ap.CityId
WHERE ass.Id = 1 AND c.Name LIKE 'Zagreb'


SELECT * FROM City

ALTER PROC GetApartmentById
	@id INT
AS
BEGIN
	SELECT ap.Id, ap.Name, c.Name AS CityName, ap.MaxAdults, ap.MaxChildren, ap.TotalRooms, COUNT(app.ApartmentId) AS PictureNumber, ap.Price, ap.BeachDistance, ass.NameEng, ao.Name AS OwnerName, AVG(ar.Stars) AS ApartmentStars	 
	FROM Apartment AS ap
	LEFT JOIN City AS c ON c.Id = ap.CityId
	LEFT JOIN ApartmentPicture AS app ON app.ApartmentId = ap.Id
	LEFT JOIN ApartmentStatus AS ass ON ass.Id = ap.StatusId
	LEFT JOIN ApartmentOwner AS ao ON ao.Id = ap.OwnerId
	LEFT JOIN ApartmentReview AS ar ON ar.ApartmentId = ap.Id
	WHERE ap.Id = @id
	GROUP BY ap.Id, ap.Name, c.Name, ap.MaxAdults, ap.MaxChildren, ap.TotalRooms, ap.Price, ap.BeachDistance, ass.NameEng, ao.Name
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
	@beachDistance INT,
	@createdApartment INT OUTPUT
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
 SELECT @createdApartment = SCOPE_IDENTITY()
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


CREATE PROC GetApartmentTags
	@apartmentId INT
AS
BEGIN
	SELECT Tag.id, Tag.Name, Tag.NameEng, COUNT(TaggedApartment.ApartmentId) AS TagAppearance
	FROM TaggedApartment
	INNER JOIN Tag ON Tag.Id = TaggedApartment.TagId
	WHERE ApartmentId = @apartmentId
	GROUP BY Tag.id, Tag.Name, Tag.NameEng
END

CREATE PROC GetApartmentTagsOposite
	@apartmentId INT
AS
BEGIN
	SELECT Tag.id, Tag.Name, Tag.NameEng, COUNT(TaggedApartment.ApartmentId) AS TagAppearance
	FROM TaggedApartment
	INNER JOIN Tag ON Tag.Id = TaggedApartment.TagId
	WHERE ApartmentId != @apartmentId
	GROUP BY Tag.id, Tag.Name, Tag.NameEng
END

SELECT Tag.id, Tag.Name, Tag.NameEng, COUNT(TaggedApartment.ApartmentId) AS TagAppearance
	FROM TaggedApartment
	INNER JOIN Tag ON Tag.Id = TaggedApartment.TagId
	WHERE TaggedApartment.ApartmentId = 3
	GROUP BY Tag.id, Tag.Name, Tag.NameEng


CREATE PROC InsertTagToApartment
	@apartmentId INT,
	@tagId INT,
	@guid UNIQUEIDENTIFIER
AS
BEGIN
	INSERT INTO TaggedApartment (Guid, ApartmentId, TagId)
	VALUES(@guid, @apartmentId, @tagId)
END

ALTER PROC AuthUser
	@username NVARCHAR(50),
	@password NVARCHAR(128)
AS
BEGIN
	SELECT *
	FROM AspNetUsers
	WHERE UserName = @username AND PasswordHash = @password
END


CREATE PROC RegisterUser
	@email NVARCHAR(256),
	@passwordHash NVARCHAR(MAX),
	@phoneNumber NVARCHAR(MAX),
	@userName NVARCHAR(256),
	@address NVARCHAR(1000)
AS
BEGIN
	INSERT INTO AspNetUsers (Guid, CreatedAt, DeletedAt, Email, EmailConfirmed, PasswordHash, PhoneNumber, PhoneNumberConfirmed, LockoutEnabled, AccessFailedCount, UserName, Address) 
	VALUES(NEWID(), GETDATE(), NULL, @email, 1, @passwordHash, @phoneNumber, 1, 1, 0, @userName, @address)
END

CREATE PROC AuthUser
	@userName NVARCHAR(256),
	@hashedPassword NVARCHAR(MAX)
AS
BEGIN
	SELECT *
	FROM AspNetUsers
	WHERE UserName = @userName AND PasswordHash = @hashedPassword
END

CREATE PROC InsertUserReview	
	@userId INT,
	@apartmentId INT,
	@details NVARCHAR(MAX),
	@stars INT
AS
BEGIN
	INSERT INTO ApartmentReview (Guid, CreatedAt, ApartmentId, UserId, Details, Stars)
	VALUES(NEWID(), GETDATE(), @apartmentId, @userId, @details, @stars)
END

CREATE TABLE ApartPicture
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Guid UNIQUEIDENTIFIER NOT NULL,
	CreatedAt DATETIME2(7) NOT NULL,
	DeletedAt DATETIME2(7) NULL,
	ApartmentId INT NOT NULL,
	Size INT NOT NULL,
	Name NVARCHAR(250) NOT NULL,
	ImageData VARBINARY(MAX) NOT NULL,
	IsRepresentative BIT NULL,
	FOREIGN KEY (ApartmentId) REFERENCES Apartment(Id)
)	

CREATE PROC InsertApartmentPicture
	@apartmentId INT,
	@size INT,
	@imageData VARBINARY(MAX), 
	@name NVARCHAR(250),
	@isRepresentative BIT
AS
BEGIN
	INSERT INTO ApartPicture(Guid, CreatedAt, ApartmentId, Name, Size, ImageData, IsRepresentative)
	VALUES(NEWID(), GETDATE(), @apartmentId, @name, @size, @imageData, @isRepresentative)
END

CREATE PROC GetAllApartmentPictures
	@apartmentId INT
AS
BEGIN
	SELECT Id, Name, ImageData, IsRepresentative
	FROM ApartPicture
	WHERE ApartmentId = @apartmentId
END

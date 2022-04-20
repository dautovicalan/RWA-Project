use RwaApartmani

CREATE PROC GetApartments
AS
BEGIN
	SELECT * FROM Apartment
END

CREATE PROC GetApartmentById
	@id INT
AS
BEGIN
	SELECT * FROM Apartment WHERE Id = @id
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

ALTER PROC TagCount
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
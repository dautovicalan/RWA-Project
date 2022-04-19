use RwaApartmani

SELECT * FROM Apartment

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

EXEC GetTags
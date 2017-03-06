IF OBJECT_ID('dbo.GetContactByIdInJsonFormat') IS NOT NULL 
BEGIN
    DROP PROCEDURE dbo.GetContactByIdInJsonFormat
END

IF OBJECT_ID('dbo.GetContactByIdDapperWithMany') IS NOT NULL 
BEGIN
    DROP PROCEDURE dbo.GetContactByIdDapperWithMany
END


IF OBJECT_ID('dbo.GetContactByIdDapperWithoutMany') IS NOT NULL 
BEGIN
    DROP PROCEDURE dbo.GetContactByIdDapperWithoutMany
END
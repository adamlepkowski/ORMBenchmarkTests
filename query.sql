/****** Script for SelectTopNRows command from SSMS  ******/
SELECT  *   FROM [ORMBenchmarkTests].[dbo].[Contacts]
  SELECT  *   FROM [dbo].[Nationalities]
  SELECT *   FROM [ORMBenchmarkTests].[dbo].[Professions]
  SELECT *   FROM [dbo].[Companies]
  
  SELECT *   FROM [dbo].[Phones]
  SELECT *   FROM [dbo].[PhoneTypes]
  SELECT *   FROM [dbo].[Emails]
  SELECT *   FROM [dbo].[EmailTypes]
  
  SELECT *   FROM [dbo].[Users]
  SELECT *   FROM [dbo].[UserTypes]
  SELECT *   FROM [dbo].[ContactNegotiators]
  SELECT *   FROM [dbo].[Agents]
  SELECT *   FROM [dbo].[Departments]

  DELETE FROM [dbo].[Phones]
  DELETE FROM [dbo].[PhoneTypes]
  DELETE FROM [dbo].[Emails]
  DELETE FROM [dbo].[EmailTypes]
  DELETE FROM [dbo].[Agents]
  DELETE FROM [dbo].[ContactNegotiators]
  DELETE FROM [dbo].[Contacts]
  DELETE FROM [dbo].[Professions]
  DELETE FROM [dbo].[Nationalities]

  DELETE FROM [dbo].[Users]
  DELETE FROM [dbo].[UserTypes]
  DELETE FROM [dbo].[Departments]
  DELETE FROM [dbo].[Companies]
  DELETE FROM [dbo].[AttributeValues]
  DELETE FROM [dbo].[Prices]
  DELETE FROM [dbo].[CurrencyDefinitions]
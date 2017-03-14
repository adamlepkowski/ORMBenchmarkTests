create procedure dbo.GetContactByIdInJsonFormat
@ContactId int
as
-- AUTO GENERATED STATEMENT
SELECT [Contacts].[Id],
 [Contacts].[IntA],
 [Contacts].[IntB],
 [Contacts].[BooleanAttributeA],
 [Contacts].[BooleanAttributeB],
 [Contacts].[StringAttributeA],
 [Contacts].[StringAttributeB],
 [Contacts].[DataTimeAttributeA],
 [Contacts].[DataTimeAttributeB],
 [Contacts].[DecimalAttributeA],
 [Contacts].[DecimalAttributeB],
 [Contacts].[ProfessionId],
 [Contacts_Professions_ProfessionId].[Id] as 'Profession.Id',
 [Contacts_Professions_ProfessionId].[Name] as 'Profession.Name',
 [Contacts].[NationalityId],
 [Contacts_Nationalities_NationalityId].[Id] as 'Nationality.Id',
 [Contacts_Nationalities_NationalityId].[Name] as 'Nationality.Name',
 [Contacts].[CompanyId],
 [Contacts_Companies_CompanyId].[Id] as 'Company.Id',
 [Contacts_Companies_CompanyId].[IntA] as 'Company.IntA',
 [Contacts_Companies_CompanyId].[IntB] as 'Company.IntB',
 [Contacts_Companies_CompanyId].[BooleanAttributeAttributeA] as 'Company.BooleanAttributeAttributeA',
 [Contacts_Companies_CompanyId].[BooleanAttributeB] as 'Company.BooleanAttributeB',
 [Contacts_Companies_CompanyId].[StringAttributeA] as 'Company.StringAttributeA',
 [Contacts_Companies_CompanyId].[StringAttributeB] as 'Company.StringAttributeB',
 [Contacts_Companies_CompanyId].[DataTimeAttributeA] as 'Company.DataTimeAttributeA',
 [Contacts_Companies_CompanyId].[DataTimeAttributeB] as 'Company.DataTimeAttributeB',
 [Contacts_Companies_CompanyId].[DecimalAttributeA] as 'Company.DecimalAttributeA',
 [Contacts_Companies_CompanyId].[DecimalAttributeB] as 'Company.DecimalAttributeB',
 [Contacts].[CreatedById],
 [Contacts_Users_CreatedById].[Id] as 'User.Id',
 [Contacts_Users_CreatedById].[IntA] as 'User.IntA',
 [Contacts_Users_CreatedById].[IntB] as 'User.IntB',
 [Contacts_Users_CreatedById].[BooleanAttributeA] as 'User.BooleanAttributeA',
 [Contacts_Users_CreatedById].[BooleanAttributeB] as 'User.BooleanAttributeB',
 [Contacts_Users_CreatedById].[StringAttributeA] as 'User.StringAttributeA',
 [Contacts_Users_CreatedById].[StringAttributeB] as 'User.StringAttributeB',
 [Contacts_Users_CreatedById].[DataTimeAttributeA] as 'User.DataTimeAttributeA',
 [Contacts_Users_CreatedById].[DataTimeAttributeB] as 'User.DataTimeAttributeB',
 [Contacts_Users_CreatedById].[DecimalAttributeA] as 'User.DecimalAttributeA',
 [Contacts_Users_CreatedById].[DecimalAttributeB] as 'User.DecimalAttributeB',
 [Contacts_Users_CreatedById].[UserTypeId] as 'User.UserTypeId',
 [Contacts_Users_CreatedById_UserTypes_UserTypeId].[Id] as 'User.UserType.Id',
 [Contacts_Users_CreatedById_UserTypes_UserTypeId].[Type] as 'User.UserType.Type',
 [Contacts_Users_CreatedById].[DepartmentId] as 'User.DepartmentId',
 [Contacts_Users_CreatedById_Departments_DepartmentId].[Id] as 'User.Department.Id',
 [Contacts_Users_CreatedById_Departments_DepartmentId].[Name] as 'User.Department.Name',
 [Contacts].[AttributeValuesId],
 [Contacts_AttributeValues_AttributeValuesId].[Id] as 'AttributeValues.Id',
 [Contacts_AttributeValues_AttributeValuesId].[MinIntAttributeA] as 'AttributeValues.MinIntAttributeA',
 [Contacts_AttributeValues_AttributeValuesId].[MaxIntAttributeA] as 'AttributeValues.MaxIntAttributeA',
 [Contacts_AttributeValues_AttributeValuesId].[MinIntAttributeB] as 'AttributeValues.MinIntAttributeB',
 [Contacts_AttributeValues_AttributeValuesId].[MaxIntAttributeB] as 'AttributeValues.MaxIntAttributeB',
 [Contacts_AttributeValues_AttributeValuesId].[MinGuidAttributeA] as 'AttributeValues.MinGuidAttributeA',
 [Contacts_AttributeValues_AttributeValuesId].[MaxGuidAttributeA] as 'AttributeValues.MaxGuidAttributeA',
 [Contacts_AttributeValues_AttributeValuesId].[MinGuidAttributeB] as 'AttributeValues.MinGuidAttributeB',
 [Contacts_AttributeValues_AttributeValuesId].[MaxGuidAttributeB] as 'AttributeValues.MaxGuidAttributeB',
 [Contacts_AttributeValues_AttributeValuesId].[MinStringAttributeA] as 'AttributeValues.MinStringAttributeA',
 [Contacts_AttributeValues_AttributeValuesId].[MaxStringAttributeA] as 'AttributeValues.MaxStringAttributeA',
 [Contacts_AttributeValues_AttributeValuesId].[MinStringAttributeB] as 'AttributeValues.MinStringAttributeB',
 [Contacts_AttributeValues_AttributeValuesId].[MaxStringAttributeB] as 'AttributeValues.MaxStringAttributeB',
 [Contacts_AttributeValues_AttributeValuesId].[MinDecimalAttributeA] as 'AttributeValues.MinDecimalAttributeA',
 [Contacts_AttributeValues_AttributeValuesId].[MaxDecimalAttributeA] as 'AttributeValues.MaxDecimalAttributeA',
 [Contacts_AttributeValues_AttributeValuesId].[MinDecimalAttributeB] as 'AttributeValues.MinDecimalAttributeB',
 [Contacts_AttributeValues_AttributeValuesId].[MaxDecimalAttributeB] as 'AttributeValues.MaxDecimalAttributeB',
 [Contacts_AttributeValues_AttributeValuesId].[MinDateTimeAttributeA] as 'AttributeValues.MinDateTimeAttributeA',
 [Contacts_AttributeValues_AttributeValuesId].[MaxDateTimeAttributeA] as 'AttributeValues.MaxDateTimeAttributeA',
 [Contacts_AttributeValues_AttributeValuesId].[MinDateTimeAttributeB] as 'AttributeValues.MinDateTimeAttributeB',
 [Contacts_AttributeValues_AttributeValuesId].[MaxDateTimeAttributeB] as 'AttributeValues.MaxDateTimeAttributeB',
 [Contacts_AttributeValues_AttributeValuesId].[MinPriceId] as 'AttributeValues.MinPriceId',
 [Contacts_AttributeValues_AttributeValuesId_Prices_MinPriceId].[Id] as 'AttributeValues.MinPrice.Id',
 [Contacts_AttributeValues_AttributeValuesId_Prices_MinPriceId].[CurrencyDefinitionId] as 'AttributeValues.MinPrice.CurrencyDefinitionId',
 [Contacts_AttributeValues_AttributeValuesId_Prices_MinPriceId_CurrencyDefinitions_CurrencyDefinitionId].[Id] as 'AttributeValues.MinPrice.CurrencyDefinition.Id',
 [Contacts_AttributeValues_AttributeValuesId_Prices_MinPriceId_CurrencyDefinitions_CurrencyDefinitionId].[Code] as 'AttributeValues.MinPrice.CurrencyDefinition.Code',
 [Contacts_AttributeValues_AttributeValuesId_Prices_MinPriceId].[Value] as 'AttributeValues.MinPrice.Value',
 [Contacts_AttributeValues_AttributeValuesId].[MaxPriceId] as 'AttributeValues.MaxPriceId',
 [Contacts_AttributeValues_AttributeValuesId_Prices_MaxPriceId].[Id] as 'AttributeValues.MaxPrice.Id',
 [Contacts_AttributeValues_AttributeValuesId_Prices_MaxPriceId].[CurrencyDefinitionId] as 'AttributeValues.MaxPrice.CurrencyDefinitionId',
 [Contacts_AttributeValues_AttributeValuesId_Prices_MaxPriceId_CurrencyDefinitions_CurrencyDefinitionId].[Id] as 'AttributeValues.MaxPrice.CurrencyDefinition.Id',
 [Contacts_AttributeValues_AttributeValuesId_Prices_MaxPriceId_CurrencyDefinitions_CurrencyDefinitionId].[Code] as 'AttributeValues.MaxPrice.CurrencyDefinition.Code',
 [Contacts_AttributeValues_AttributeValuesId_Prices_MaxPriceId].[Value] as 'AttributeValues.MaxPrice.Value'
FROM dbo.Contacts as [Contacts]
 LEFT JOIN dbo.Professions as [Contacts_Professions_ProfessionId] on [Contacts_Professions_ProfessionId].[Id] = [Contacts].[ProfessionId]
 LEFT JOIN dbo.Nationalities as [Contacts_Nationalities_NationalityId] on [Contacts_Nationalities_NationalityId].[Id] = [Contacts].[NationalityId]
 LEFT JOIN dbo.Companies as [Contacts_Companies_CompanyId] on [Contacts_Companies_CompanyId].[Id] = [Contacts].[CompanyId]
 LEFT JOIN dbo.Users as [Contacts_Users_CreatedById] on [Contacts_Users_CreatedById].[Id] = [Contacts].[CreatedById]
 LEFT JOIN dbo.UserTypes as [Contacts_Users_CreatedById_UserTypes_UserTypeId] on [Contacts_Users_CreatedById_UserTypes_UserTypeId].[Id] = [Contacts_Users_CreatedById].[UserTypeId]
 LEFT JOIN dbo.Departments as [Contacts_Users_CreatedById_Departments_DepartmentId] on [Contacts_Users_CreatedById_Departments_DepartmentId].[Id] = [Contacts_Users_CreatedById].[DepartmentId]
 LEFT JOIN dbo.AttributeValues as [Contacts_AttributeValues_AttributeValuesId] on [Contacts_AttributeValues_AttributeValuesId].[Id] = [Contacts].[AttributeValuesId]
 LEFT JOIN dbo.Prices as [Contacts_AttributeValues_AttributeValuesId_Prices_MinPriceId] on [Contacts_AttributeValues_AttributeValuesId_Prices_MinPriceId].[Id] = [Contacts_AttributeValues_AttributeValuesId].[MinPriceId]
 LEFT JOIN dbo.CurrencyDefinitions as [Contacts_AttributeValues_AttributeValuesId_Prices_MinPriceId_CurrencyDefinitions_CurrencyDefinitionId] on [Contacts_AttributeValues_AttributeValuesId_Prices_MinPriceId_CurrencyDefinitions_CurrencyDefinitionId].[Id] = [Contacts_AttributeValues_AttributeValuesId_Prices_MinPriceId].[CurrencyDefinitionId]
 LEFT JOIN dbo.Prices as [Contacts_AttributeValues_AttributeValuesId_Prices_MaxPriceId] on [Contacts_AttributeValues_AttributeValuesId_Prices_MaxPriceId].[Id] = [Contacts_AttributeValues_AttributeValuesId].[MaxPriceId]
 LEFT JOIN dbo.CurrencyDefinitions as [Contacts_AttributeValues_AttributeValuesId_Prices_MaxPriceId_CurrencyDefinitions_CurrencyDefinitionId] on [Contacts_AttributeValues_AttributeValuesId_Prices_MaxPriceId_CurrencyDefinitions_CurrencyDefinitionId].[Id] = [Contacts_AttributeValues_AttributeValuesId_Prices_MaxPriceId].[CurrencyDefinitionId]
 WHERE [Contacts].Id = @ContactId
 FOR JSON PATH, WITHOUT_ARRAY_WRAPPER
 
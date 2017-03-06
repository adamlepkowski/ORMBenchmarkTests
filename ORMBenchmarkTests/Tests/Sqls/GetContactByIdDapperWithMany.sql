CREATE procedure dbo.GetContactByIdDapperWithMany
@ContactId int
as
-- AUTO GENERATED
SELECT [Contacts].[ContactId] as Id,
 [Contacts].*,
 [Contacts_Professions_ProfessionId].[ProfessionId] as Id,
 [Contacts_Professions_ProfessionId].*,
 [Contacts_Nationalities_NationalityId].[NationalityId] as Id,
 [Contacts_Nationalities_NationalityId].*,
 [Contacts_Companies_CompanyId].[CompanyId] as Id,
 [Contacts_Companies_CompanyId].*,
 [Contacts_Users_CreatedById].[UserId] as Id,
 [Contacts_Users_CreatedById].*,
 [Contacts_Users_CreatedById_UserTypes_UserTypeId].[UserTypeId] as Id,
 [Contacts_Users_CreatedById_UserTypes_UserTypeId].*,
 [Contacts_Users_CreatedById_Departments_DepartmentId].[DepartmentId] as Id,
 [Contacts_Users_CreatedById_Departments_DepartmentId].*,
 [Contacts_AttributeValues_AttributeValuesId].[AttributeValuesId] as Id,
 [Contacts_AttributeValues_AttributeValuesId].*,
 [Contacts_AttributeValues_AttributeValuesId_Prices_MinPriceId].[PriceId] as Id,
 [Contacts_AttributeValues_AttributeValuesId_Prices_MinPriceId].*,
 [Contacts_AttributeValues_AttributeValuesId_Prices_MinPriceId_CurrencyDefinitions_CurrencyDefinitionId].[CurrencyDefinitionId] as Id,
 [Contacts_AttributeValues_AttributeValuesId_Prices_MinPriceId_CurrencyDefinitions_CurrencyDefinitionId].*,
 [Contacts_AttributeValues_AttributeValuesId_Prices_MaxPriceId].[PriceId] as Id,
 [Contacts_AttributeValues_AttributeValuesId_Prices_MaxPriceId].*,
 [Contacts_AttributeValues_AttributeValuesId_Prices_MaxPriceId_CurrencyDefinitions_CurrencyDefinitionId].[CurrencyDefinitionId] as Id,
 [Contacts_AttributeValues_AttributeValuesId_Prices_MaxPriceId_CurrencyDefinitions_CurrencyDefinitionId].*
FROM dbo.Contacts as [Contacts]
 LEFT JOIN dbo.Professions as [Contacts_Professions_ProfessionId] on [Contacts_Professions_ProfessionId].[ProfessionId] = [Contacts].[ProfessionId]
 LEFT JOIN dbo.Nationalities as [Contacts_Nationalities_NationalityId] on [Contacts_Nationalities_NationalityId].[NationalityId] = [Contacts].[NationalityId]
 LEFT JOIN dbo.Companies as [Contacts_Companies_CompanyId] on [Contacts_Companies_CompanyId].[CompanyId] = [Contacts].[CompanyId]
 LEFT JOIN dbo.Users as [Contacts_Users_CreatedById] on [Contacts_Users_CreatedById].[UserId] = [Contacts].[CreatedById]
 LEFT JOIN dbo.UserTypes as [Contacts_Users_CreatedById_UserTypes_UserTypeId] on [Contacts_Users_CreatedById_UserTypes_UserTypeId].[UserTypeId] = [Contacts_Users_CreatedById].[UserTypeId]
 LEFT JOIN dbo.Departments as [Contacts_Users_CreatedById_Departments_DepartmentId] on [Contacts_Users_CreatedById_Departments_DepartmentId].[DepartmentId] = [Contacts_Users_CreatedById].[DepartmentId]
 LEFT JOIN dbo.AttributeValues as [Contacts_AttributeValues_AttributeValuesId] on [Contacts_AttributeValues_AttributeValuesId].[AttributeValuesId] = [Contacts].[AttributeValuesId]
 LEFT JOIN dbo.Prices as [Contacts_AttributeValues_AttributeValuesId_Prices_MinPriceId] on [Contacts_AttributeValues_AttributeValuesId_Prices_MinPriceId].[PriceId] = [Contacts_AttributeValues_AttributeValuesId].[MinPriceId]
 LEFT JOIN dbo.CurrencyDefinitions as [Contacts_AttributeValues_AttributeValuesId_Prices_MinPriceId_CurrencyDefinitions_CurrencyDefinitionId] on [Contacts_AttributeValues_AttributeValuesId_Prices_MinPriceId_CurrencyDefinitions_CurrencyDefinitionId].[CurrencyDefinitionId] = [Contacts_AttributeValues_AttributeValuesId_Prices_MinPriceId].[CurrencyDefinitionId]
 LEFT JOIN dbo.Prices as [Contacts_AttributeValues_AttributeValuesId_Prices_MaxPriceId] on [Contacts_AttributeValues_AttributeValuesId_Prices_MaxPriceId].[PriceId] = [Contacts_AttributeValues_AttributeValuesId].[MaxPriceId]
 LEFT JOIN dbo.CurrencyDefinitions as [Contacts_AttributeValues_AttributeValuesId_Prices_MaxPriceId_CurrencyDefinitions_CurrencyDefinitionId] on [Contacts_AttributeValues_AttributeValuesId_Prices_MaxPriceId_CurrencyDefinitions_CurrencyDefinitionId].[CurrencyDefinitionId] = [Contacts_AttributeValues_AttributeValuesId_Prices_MaxPriceId].[CurrencyDefinitionId]
 where [Contacts].ContactId = @ContactId

 select
 p.PhoneId as Id,
 p.*,
 pt.PhoneTypeId as Id,
 pt.*
  from dbo.Phones p left join dbo.PhoneTypes pt on p.PhoneTypeId = pt.PhoneTypeId
   where p.ContactId = @ContactId

   select
 p.EmailId as Id,
 p.*,
 pt.EmailTypeId as Id,
 pt.*
  from dbo.Emails p left join dbo.EmailTypes pt on p.EmailId = pt.EmailTypeId
     where p.ContactId = @ContactId

select
 cn.ContactNegotiatorId as Id,
 cn.*,
	u.UserId as Id,
 u.*,
 ut.UserTypeId as Id,
 ut.*,
 ud.DepartmentId as Id,
 ud.*
  from dbo.ContactNegotiators cn 
  LEFT JOIN dbo.Users as u on u.[UserId] = cn.[CreatedById]
 LEFT JOIN dbo.UserTypes as ut on ut.[UserTypeId] = u.[UserTypeId]
 LEFT JOIN dbo.Departments as ud on ud.DepartmentId = u.DepartmentId
    where cn.ContactId = @ContactId

 select
 a.AgentId as Id,
 a.*,
	u.UserId as Id,
 u.*,
 ut.UserTypeId as Id,
 ut.*,
 ud.DepartmentId as Id,
 ud.*,
 c.CompanyId as Id,
 c.*
  from dbo.Agents a 
  LEFT JOIN dbo.Users as u on u.[UserId] = a.[CreatedById]
 LEFT JOIN dbo.UserTypes as ut on ut.[UserTypeId] = u.[UserTypeId]
 LEFT JOIN dbo.Departments as ud on ud.DepartmentId = u.DepartmentId
  LEFT JOIN dbo.Companies as c on c.CompanyId = a.CompanyId
     where a.ContactId = @ContactId
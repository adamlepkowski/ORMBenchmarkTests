CREATE procedure dbo.GetContactByIdDapperWithMany
@ContactId int
as
-- AUTO GENERATED
SELECT *
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
 where [Contacts].Id = @ContactId

 select *
  from dbo.Phones p left join dbo.PhoneTypes pt on p.PhoneTypeId = pt.[Id]
   where p.ContactId = @ContactId

   select *
  from dbo.Emails p left join dbo.EmailTypes pt on p.[Id] = pt.[Id]
     where p.ContactId = @ContactId

select *
  from dbo.ContactNegotiators cn 
  LEFT JOIN dbo.Users as u on u.[Id] = cn.[CreatedById]
 LEFT JOIN dbo.UserTypes as ut on ut.[Id] = u.[UserTypeId]
 LEFT JOIN dbo.Departments as ud on ud.[Id] = u.DepartmentId
    where cn.ContactId = @ContactId

 select *
  from dbo.Agents a 
  LEFT JOIN dbo.Users as u on u.[Id] = a.[CreatedById]
 LEFT JOIN dbo.UserTypes as ut on ut.[Id] = u.[UserTypeId]
 LEFT JOIN dbo.Departments as ud on ud.[Id] = u.DepartmentId
  LEFT JOIN dbo.Companies as c on c.[Id] = a.CompanyId
     where a.ContactId = @ContactId
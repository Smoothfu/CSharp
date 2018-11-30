CREATE VIEW HumanResources.DepartmentEmployeeVW
	AS SELECT d.DepartmentID,d.Name,d.GroupName,d.ModifiedDate,e.NationalIDNumber,e.LoginID,
	e.OrganizationLevel,e.OrganizationNode,e.JobTitle,e.BirthDate FROM HumanResources.Department d
	left join HumanResources.Employee e
	on d.DepartmentID=e.BusinessEntityID
	 
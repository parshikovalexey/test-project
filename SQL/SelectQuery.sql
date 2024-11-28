SELECT p.[Name], c.[Name]
FROM [dbo].[Products] p
LEFT JOIN [dbo].[ProductCategories] pc ON pc.[ProductId] = p.[Id]
LEFT JOIN [dbo].[Categories] c ON c.[Id] = pc.[CategoryId]

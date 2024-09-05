SELECT p.Name AS ProductName, c.Name AS CategoryName
FROM Products p
         LEFT JOIN ProductsCategories pc ON p.ID = pc.ProductID
         JOIN Categories c ON pc.CategoryID = c.ID;
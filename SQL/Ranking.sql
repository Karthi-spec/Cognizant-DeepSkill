CREATE TABLE Products (
    ProductID INT,
    ProductName VARCHAR(50),
    Category VARCHAR(50),
    Price INT
);

INSERT INTO Products VALUES
(1,'Laptop A','Electronics',70000),
(2,'Laptop B','Electronics',65000),
(3,'Laptop C','Electronics',65000),
(4,'Mouse','Electronics',1000),
(5,'Bed','Furniture',60000),
(6,'Sofa','Furniture',50000),
(7,'Chair','Furniture',10000),
(8,'Table','Furniture',10000);

SELECT ProductName, Category, Price, Row_No
FROM
(
    SELECT ProductName,
           Category,
           Price,
           ROW_NUMBER() OVER(
               PARTITION BY Category
               ORDER BY Price DESC
           ) AS Row_No
    FROM Products
) A
WHERE Row_No <= 3;

SELECT ProductName, Category, Price, Rank_No
FROM
(
    SELECT ProductName,
           Category,
           Price,
           RANK() OVER(
               PARTITION BY Category
               ORDER BY Price DESC
           ) AS Rank_No
    FROM Products
) A
WHERE Rank_No <= 3;

SELECT ProductName, Category, Price, Dense_Rank
FROM
(
    SELECT ProductName,
           Category,
           Price,
           DENSE_RANK() OVER(
               PARTITION BY Category
               ORDER BY Price DESC
           ) AS Dense_Rank
    FROM Products
) A
WHERE Dense_Rank <= 3;
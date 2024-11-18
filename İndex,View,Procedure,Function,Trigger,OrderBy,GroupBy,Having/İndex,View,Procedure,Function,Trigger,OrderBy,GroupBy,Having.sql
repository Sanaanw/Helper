CREATE DATABASE RESTAURANT
CREATE TABLE Meals
(
ID INT PRIMARY KEY IDENTITY,
Name NVARCHAR(20),
Price INT
)
ALTER TABLE MEALS ALTER COLUMN PRICE DECIMAL(18,2)
CREATE TABLE [Tables]
(
ID INT PRIMARY KEY IDENTITY,
Number INT
)
CREATE TABLE Orders
(
ID INT PRIMARY KEY IDENTITY,
MealID INT FOREIGN KEY REFERENCES Meals(ID),
TableID INT FOREIGN KEY REFERENCES [Tables](ID),
OrderTime DateTime NOT NULL
)
INSERT INTO MEALS
VALUES
('Steak',17.50),
('Soup',7.60),
('Fish',15.30)
INSERT INTO [Tables]
VALUES
(1),(2),(3),(4),
(5)

INSERT INTO Orders
VALUES
(1,1,'2024-11-14 10:30'),
(1,2,'2024-11-14 11:00'),
(2,3,'2024-11-14 11:30')


-----Creating View (View konkretdir arqument falan oturmek olmur)
CREATE VIEW OrdersCount
AS
SELECT T.Number AS TableNumber,COUNT(O.ID) AS CountOfOrder FROM [Tables] T
LEFT JOIN Orders O
ON 
T.Number = O.TableID
GROUP BY 
    T.Number
-------Working View
SELECT * FROM OrdersCount


-----------------Creating Procedure
CREATE PROCEDURE st_GetOrderCount @ID INT
AS
SELECT O.ID OrderNumber,M.Name MealName FROM Orders O
LEFT JOIN Meals M
ON
O.MealID=M.ID
Where O.ID=@ID 
----------Working Procedure 
EXEC DBO.st_GetOrderCount 3


---------Creating Function
CREATE FUNCTION GetDataCount()
RETURNS INT
AS BEGIN
DECLARE @Count INT
SELECT @Count=COUNT(*) FROM Meals
RETURN @COUNT
END
---------Working Function
SELECT DBO.GetDataCount() AS CountData


-------------Creating Trigger
CREATE TRIGGER ShowAllDataMeals
on Meals
After INSERT,UPDATE,DELETE
AS
SELECT * FROM Meals
-------- Working Trigger(Silende ekrana cixardir)
DELETE FROM Meals where ID=6

-------Order by (Default is ASC,DESC ise azalan sira)
Select * FROM Meals M
ORDER BY M.ID DESC

-------Group by and Having
SELECT M.Name,SUM(Price) FROM Meals M
GROUP BY M.Name

SELECT M.Name,SUM(Price) FROM Meals M
GROUP BY M.Name
HAVING SUM(Price)>10
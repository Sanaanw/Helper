-------------------------------DDL
--CREATE|DROP|ALTER|TRUNCATE
CREATE DATABASE PB502--Database yaratmaq
DROP DATABASE PB502--Database silmek
USE PB502

DROP TABLE STUDENTS --Table silmek ucun istifade olunur
CREATE TABLE STUDENTS--Table yaratmaq ucun istifade olunur
(
ID int,
[NAME] nvarchar(100),--Default 1 olur
Age int,
IsMarried bit
)

ALTER TABLE STUDENTS ADD Email nvarchar(50)--Sonradan column add etmek ucundur.
Alter table STUDENTS DROP COLUMN EMAIL --Email column silmek ucun istifade olunur.   

EXEC sp_rename Students,Studentss --Table adin deyishmek ucun.
EXEC sp_rename 'Studentss.IsMarried',Gmail--Tabledeki column adin deyshmek ucun.

ALTER TABLE STUDENTSS ALTER COLUMN AGE NVARCHAR(100)--Column typenin deyshmek ucun.

----------------------------------------------------DML
--INSERT|UPDATE|DELETE
INSERT INTO STUDENTSS --Tableye deyer insert etmek ucun.
VALUES
(2,'Senan',18,1,'Senan@gmail.com'),
(3,'Gulnur',19,0,'Gulnur@gmail.com')

insert into studentss--Tableye deyer insert etmek ama secmekle.
(ID,[NAME],AGE,GMAIL)
values
(4,'Gunay',19,'Gunay@gmail.com')

Update Studentss-- UPDATE ETMEK UCUN ISTIFADE OLUNUR
SET
AGE=19 WHERE ID=1;

DELETE FROM STUDENTSS WHERE ID =4 AND NAME IS NOT NULL or ID IN (1,2,3); --Tableden,Datalari silir.

select * from Studentss--Ulduz hamsn verir datanin.
SELECT ID,[NAME] as AD FROM STUDENTSS--Burada nameni ad kimi verir.
SELECT * FROM STUDENTSS WHERE [NAME] LIKE 'S%'--Namesi S ile bashlianlari verir. 

SELECT LEN([NAME]) AS LENGHT FROM STUDENTSS--Tabledeki adlarn uzunlugun cixarir ekrana.

Select MAX(AGE) FROM STUDENTSS -- MAX AGE EKRANA CIXARDIR(max,min avg,sum).

SELECT CHARINDEX('@',GMAIL),Gmail FROM STUDENTSS--Gmaildeki @ isaresinin indeksin verir.

SELECT SUBSTRING (GMAIL,CHARINDEX('@',GMAIL)+1,LEN(GMAIL)),GMAIL FROM STUDENTSS--@ DAN SORAN EKRANA CIXARDIR

SELECT * FROM STUDENTSS WHERE AGE > (SELECT AVG(AGE) FROM STUDENTSS); --yasi avg yasdan boyukleri goruruk

--------------------------------------Relations
CREATE DATABASE PB502Demo
CREATE TABLE GROUPS
(
ID INT PRIMARY KEY IDENTITY,
[NAME] NVARCHAR(100) NOT NULL
)
CREATE TABLE STUDENTS
(
ID INT PRIMARY KEY IDENTITY,
GROUPID INT FOREIGN KEY REFERENCES GROUPS(ID)--One to many relation qurmaq ucundur,
--Group id column var studentde ve o groupsun id si ile elaqeleidir.
)
CREATE TABLE Details
(
[NAME] NVARCHAR(10),
AGE INT , 
STUDENTID INT FOREIGN KEY REFERENCES STUDENTS(ID)
)
CREATE TABLE BOOKS
(
ID INT PRIMARY KEY IDENTITY,
[NAME] NVARCHAR(10) NOT NULL
)
CREATE TABLE GENRES
(
ID INT PRIMARY KEY IDENTITY,
[NAME] NVARCHAR(10) NOT NULL
)
CREATE TABLE BookGenres 
(
ID INT PRIMARY KEY IDENTITY,
BOOKID INT FOREIGN KEY REFERENCES BOOKS(ID),
GENREID INT FOREIGN KEY REFERENCES GENRES(ID)
)

	
 
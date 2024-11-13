-------------------Joins(Horizontal)
CREATE DATABASE GitHub
CREATE TABLE Student
(
ID INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(100)
)
CREATE TABLE DETAILS
(
ID INT PRIMARY KEY IDENTITY,
AGE INT,
GMAIL NVARCHAR(100),
StudentID INT FOREIGN KEY REFERENCES Student(ID)
)
---------------------------------------------1.Inner Join
------------Bir neçə cədvəldəki ortaq məlumatları birləşdirmək üçündür.
--One to One
SELECT * FROM STUDENT
INNER JOIN DETAilS
ON
STUDENT.ID=DETAILS.StudentID
--One To Many
SELECT * FROM Directors
INNER JOIN Movies
ON
Movies.DirectorId=Directors.Id	 
--Many To Many
SELECT * FROM Movies
INNER JOIN MovieGenres
ON
Movies.Id=MovieGenres.MovieId
INNER JOIN Genres
ON
MovieGenres.GenreId=Genres.Id


-----------------2.Left Join
--Birinci yazilan ve ortaq datalari goturur.
Select * from Student
LEFT JOIN DETAILS
ON
Student.ID=DETAILS.StudentID


-----------------3.Right Join
--Ikinci yazilan ve ortaq datalari goturur.
Select * from Student
Right JOIN DETAILS
ON
Student.ID=DETAILS.StudentID

-----------------4.Full Outer Join
--Butun cedvelin datalarinin getirir.
Select * from Student
FULL Outer JOIN DETAILS
ON
Student.ID=DETAILS.StudentID

------------------5.Self Join
CREATE TABLE Position
(
ID INT PRIMARY KEY IDENTITY,
Duty NVARCHAR(100),
ParentID int
)
Select P1.ID,p1.Duty,p2.Duty from Position p1
Left join Position p2
ON
P2.ParentID=P1.ID


-----------------------6.Cross Join
--Butun datalari qarsilasdirir.
CREATE TABLE Products
(
ID INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(20)
)
CREATE TABLE Sizes
(
ID INT PRIMARY KEY IDENTITY,
Size NVARCHAR(20)
)
SELECT P.Name,S.Size FROM Products P
CROSS JOIN
Sizes S

----------------------7.Non equi Join(non-equal)
--Serte uygun datalari getirir gelir
ALTER TABLE Student ADD Point DECIMAL(18,2)
CREATE TABLE Grades
(
ID INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(20),
MinGrade NVARCHAR(20),
MaxGrade NVARCHAR(20)
)
SELECT S.*,G.Name FROM Student S
JOIN
GRADES G
ON
S.Point>=G.MinGrade AND S.Point<=G.MaxGrade

--------------Unions(Vertical)

------Union
CREATE TABLE OldStudent
(
ID INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(20),
Point decimal(18,2)
)
SELECT S.Name FROM STUDENT S
UNION
SELECT os.Name FROM OldStudent Os

-----------------Union All
SELECT S.Name FROM STUDENT S
UNION ALL
SELECT os.Name FROM OldStudent Os

------------------Except
--Left tablede olub,Right Tablede olmuyanlari ekrana cixarir(ortaqlari atir qiraga).
SELECT * FROM STUDENT S
EXCEPT
SELECT * FROM OldStudent Os

----------------------Intersect
--Her iki Tablede Eyni olan datalari ekrana cixardir(ortaqlari)
SELECT S.Name FROM STUDENT S
INTERSECT
SELECT os.Name FROM OldStudent Os


--------------------------Practice
CREATE DATABASE IMDB
CREATE TABLE Directors
(
Id int PRIMARY KEY IDENTITY,
[Name] nvarchar(20)
)
CREATE TABLE Movies
(
Id int PRIMARY KEY IDENTITY,
[Name] nvarchar(20),
Imdb decimal(18,2),
DirectorId int FOREIGN KEY REFERENCES Directors(Id)
)
CREATE TABLE Genres
(
Id int PRIMARY KEY IDENTITY,
[Name] nvarchar(20)
)
CREATE TABLE MovieGenres
(
Id int PRIMARY KEY IDENTITY,
MovieId int FOREIGN KEY REFERENCES Movies(Id),
GenreId int FOREIGN KEY REFERENCES Genres(Id),
)
CREATE TABLE Actors
(
Id int PRIMARY KEY IDENTITY,
[Name] nvarchar(20)
)
CREATE TABLE ActorMovies
(
Id int PRIMARY KEY IDENTITY,
MovieId int FOREIGN KEY REFERENCES Movies(Id),
ActorId int FOREIGN KEY REFERENCES Actors(Id)
)
--All movies with Directory.
SELECT * FROM Directors
INNER JOIN Movies
ON
Movies.DirectorId=Directors.Id	
--All movie with genre.
SELECT Movies.Id,Movies.Name,MovieGenres.MovieId,MovieGenres.GenreId,Genres.Name FROM Movies
INNER JOIN MovieGenres
ON
Movies.Id=MovieGenres.MovieId
INNER JOIN Genres
ON
MovieGenres.GenreId=Genres.Id
--All actors with movie,director and genres.
SELECT A.*,M.Name MovieName,D.Name DirectorName,G.Name GenreName FROM Actors A
INNER JOIN ActorMovies
ON
A.Id=ActorMovies.ActorId
INNER JOIN Movies M
ON
M.Id=ActorMovies.MovieId
INNER JOIN Directors D
ON
D.Id=M.DirectorId
INNER JOIN MovieGenres
ON
M.Id=MovieGenres.MovieId
INNER JOIN Genres G
ON
G.Id=MovieGenres.GenreId
 Select * FROM MOVIES M
 WHERE M.Imdb>7



